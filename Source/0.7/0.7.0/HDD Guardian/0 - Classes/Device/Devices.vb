'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2016 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Xml

<Flags()>
Public Enum DeviceType
    ATA = 0
    USB = 1
    SCSI = 2
    ThreeWare = 3
End Enum

Public Class Device
    Private Const _ataCmd As String = "-x -g wcreorder "
    Private Const _scsiCmd As String = "-x -g all "
    Private _y, _yy, _m, _mm, _d, _dd, _h, _hh As String

    'commons
    Private smartctl As New Console
    Private devOutput() As String
    Private devOrigContent As String
    Private devLastCheck As String
    Private devType As DeviceType
    Private devIsValid As Boolean
    Private devLocation As String
    Private devOptions As String = ""
    Private devSmart As New DeviceSmart(Me)
    Private devSmartAvailable, devSmartEnabled As Support
    Private devMissingAdminRights As Boolean = False
    Private devIsVirtual As Boolean = False
    Private devTrayIcon As New TrayIcon(Me)
    Private devTray As New DeviceTrayIcon(Me)
    Private devHealth As Status = Status.Unknown
    Private devTemperature As String = "N/A"
    Private devFileName As String = ""
    Private devVirtualName As String
    Private devLastTest As DeviceLastTest
    Private devAlreadyWarned As Boolean = True
    Private devWorkTime As New DeviceWorkTime(Me)
    Private devMailNotification As New DeviceMailNotification
    Private devSaveLog As Boolean = True
    Private devIsOptical As Boolean = False
    Private devIsShared As Boolean
    Private trayDisplayLife As Boolean
    Private devIsAvailable As Boolean = True
    Private devLog As New List(Of DeviceLog)

    Private Sub GetTimeStrings()
        _y = Main.GetString(517)
        _yy = Main.GetString(518)
        _m = Main.GetString(519)
        _mm = Main.GetString(520)
        _h = Main.GetString(523)
        _hh = Main.GetString(524)
        _d = Main.GetString(521)
        _dd = Main.GetString(522)
    End Sub

    Public Sub New(ByVal Location As String, ByVal Type As DeviceType, Optional ByVal LoadDeviceSettings As Boolean = True,
                   Optional ByVal IsVirtual As Boolean = False, Optional VirtualDescription As String = "")
        GetTimeStrings()

        devType = Type
        devLocation = Location
        devIsVirtual = IsVirtual

        If Not IsVirtual Then
            Select Case Type
                Case DeviceType.ATA
                    devOutput = smartctl.SendCmd("-i " & Location)

                    If GetInfo("SMART support is").Contains("[this device: CD/DVD]") Then
                        devIsOptical = True
                    Else
                        devIsOptical = False
                    End If
                    _ataDevice = New AtaDevice(Me)
                Case DeviceType.SCSI
                    devOutput = smartctl.SendCmd(_scsiCmd & Location)

                    If GetInfo("Device type") = "disk" Then
                        scsiIsDisk = True
                    Else
                        scsiIsDisk = False
                    End If
                    _scsiDevice = New ScsiDevice(Me)
                Case DeviceType.ThreeWare
                    devType = DeviceType.ThreeWare
                    devLocation = "/dev/tw_cli/clip"
                    devIsOptical = False
                    devSaveLog = False
                    devIsValid = False
                    devTrayIcon = Nothing
                    _ataDevice = New AtaDevice(Me)
                Case DeviceType.USB
                    devOutput = smartctl.SendCmd("-i " & Location)
                    ataDoubleDeck = CheckDoubleDeck()
                    _ataDevice = New AtaDevice(Me)
            End Select
        Else
            devVirtualName = VirtualDescription
            If IO.File.Exists(Location) Then
                devOutput = IO.File.ReadAllLines(Location)
                devOrigContent = IO.File.ReadAllText(Location)
            Else
                devIsAvailable = False
                Dim fname As String = IO.Path.GetFileName(Location)
                Dim mirror As String = My.Application.Info.DirectoryPath & "\Data\" & My.User.Name & "\" & fname
                If IO.File.Exists(mirror) Then devOrigContent = IO.File.ReadAllText(mirror)
            End If

            If GetInfo("Device type") = "disk" Then
                scsiIsDisk = True
                devType = DeviceType.SCSI
                _scsiDevice = New ScsiDevice(Me)
            Else
                scsiIsDisk = False
                devType = DeviceType.ATA
                _ataDevice = New AtaDevice(Me)
            End If

            devTrayIcon = Nothing
        End If

        If Not devIsOptical Then
            devFileName = GenerateDeviceFileName()

            If LoadDeviceSettings Then
                LoadSettings()
                LoadLog()
            Else
                devSaveLog = False
            End If

            Update()
        End If

        If Not IsNothing(devTrayIcon) Then
            With devTrayIcon
                .Model = ataDeviceModel
                .Type = devType
                .Location = devLocation
            End With
            UpdateTrayIcon()
        End If
    End Sub

#Region "Functions"
    Private Function GenerateDeviceFileName() As String
        'this routine create the file name string and skip all non valid characters
        Dim fns As String = ""
        If devType = DeviceType.SCSI Then
            fns = GetInfo("Product") & "_" & GetInfo("Serial number")
        Else
            fns = GetInfo("Device Model") & "_" & GetInfo("Serial Number")
        End If


        Dim fn() As Char = fns.ToCharArray
        Dim vfn As String = ""

        For Each c As Char In fn
            Select Case c.ToString
                'validate only the following characters:
                Case "-", "a" To "z", "A" To "Z", "0" To "9", "_", " ", ".", ","
                    vfn += c
                Case Else
                    'discard all the others characters.
            End Select
        Next

        Return vfn
    End Function

    Private Function CheckDoubleDeck() As Boolean
        For i As Short = 0 To devOutput.Length - 2
            If devOutput(i).Contains("Two devices connected, try '-d usbjmicron,[01]") Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function CheckIfValid() As Boolean
        If Not IsNothing(ataDeviceModel) Then
            If ataDeviceModel.Contains("My Book") Then
                Return False
            End If
        End If

        For i As Short = 0 To devOutput.Length - 2
            If devOutput(i).Contains("START OF INFORMATION SECTION") Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function GetInfo(ByVal info As String) As String
        Dim value As String = "N/A"
        If IsNothing(devOutput) Then Return value
        For i As Integer = 0 To devOutput.Length - 2
            If devOutput(i).Contains(info) Then
                Dim result() As String = devOutput(i).Split(":", 2, StringSplitOptions.RemoveEmptyEntries)
                If result(1).Trim.Contains("[No Information Found]") Then
                    Return "N/A"
                Else
                    Return result(1).Trim
                End If
            End If
        Next
        Return value
    End Function

    Private Function ToNumber(ByVal value As String) As String
        Dim number As String = ""
        For i As Integer = 0 To value.Length - 1
            If IsNumeric(value.Chars(i)) Then number = number & value.Chars(i)
        Next
        Return number
    End Function

    Private Function GetIndexOf(ByVal text As String, Optional ByVal start As Integer = 0) As Integer
        Dim value As Integer = 0
        For i As Integer = start To devOutput.Length - 2
            If Not IsNothing(devOutput(i)) Then
                If devOutput(i).Contains(text) Then
                    value = i
                    Exit For
                End If
            End If
        Next
        Return value
    End Function

    Private Shared Function ConvertToFlags(ByVal value As String) As AttributeFlags
        If value.Contains("x") Then
            'a simple hex value to convert in integer
            Return Convert.ToInt16(value, 16)
        Else
            'a string to convert in integer

            '5.37                           5.41                            values
            '||||||_ M self-preserving      ||||||_ K auto-keep             1
            '|||||__ C event count          |||||__ C event count           2
            '||||___ R error rate           ||||___ R error rate            4
            '|||____ S speed/performance    |||____ S speed/performance     8
            '||_____ O updated online       ||_____ O updated online        16
            '|______ P prefailure warning   |______ P prefailure warning    32
            '
            'the "M" letter are replaced with a "K" in 5.41, but for a full compatibility
            'with older output, the letter "M" are also converted

            Dim v As String = value


            v = v.Replace("P", "32+") _
            .Replace("O", "16+") _
            .Replace("S", "8+") _
            .Replace("R", "4+") _
            .Replace("C", "2+") _
            .Replace("M", "1") _
            .Replace("K", "1") _
            .Replace("-", "")


            Dim arr() As String = v.Split("+", 6, StringSplitOptions.RemoveEmptyEntries)
            Dim val As Integer = 0

            For i As Integer = 0 To arr.Length - 1
                val += arr(i)
            Next
            arr = Nothing

            Return val
        End If
    End Function

    Private Function GetRawValue(ByVal attribute() As String) As String
        If attribute.Length = 10 Then
            If Not IsNumeric(attribute(7)) Then
                Return attribute(9)
            Else
                Return attribute(7)
            End If
        Else
            Dim t() As String = attribute(7).Split(" ")
            Return t(0).Trim
        End If
    End Function

    Private Function GetThresholdValue(ByVal attribute() As String) As String
        Dim value As String = attribute(5)

        If IsNumeric(value) Then
            Return value
        Else
            Dim newvalue As String = Nothing

            Dim re5 As New Regex("^(ExcelStor|Hitachi|HD|HU|HT|HE|HD|IBM|IC|DT).*", RegexOptions.IgnoreCase)
            If re5.Match(ataDeviceModel).Success Or re5.Match(ataModelFamily).Success Then newvalue = "5"
            re5 = Nothing

            Dim re10 As New Regex("^Samsung.*", RegexOptions.IgnoreCase)
            If re10.Match(ataDeviceModel).Success Or re10.Match(ataModelFamily).Success Then newvalue = "10"
            re10 = Nothing

            Dim re20 As New Regex("^Quantum.*", RegexOptions.IgnoreCase)
            If re20.Match(ataDeviceModel).Success Or re20.Match(ataModelFamily).Success Then newvalue = "20"
            re20 = Nothing

            Dim re24 As New Regex("^Fujitsu.*", RegexOptions.IgnoreCase)
            If re24.Match(ataDeviceModel).Success Or re24.Match(ataModelFamily).Success Then newvalue = "24"
            re24 = Nothing

            Dim re36 As New Regex("^(Seagate|ST(1|2|3|5|7|6|9)).*", RegexOptions.IgnoreCase)
            If re36.Match(ataDeviceModel).Success Or re36.Match(ataModelFamily).Success Then newvalue = "36"
            re36 = Nothing

            Dim re50 As New Regex("^(Toshiba|TOS).*", RegexOptions.IgnoreCase)
            If re50.Match(ataDeviceModel).Success Or re50.Match(ataModelFamily).Success Then newvalue = "50"
            re50 = Nothing

            Dim re63 As New Regex("^(Maxtor|STM).*", RegexOptions.IgnoreCase)
            If re63.Match(ataDeviceModel).Success Or re63.Match(ataModelFamily).Success Then newvalue = "63"
            re63 = Nothing

            Dim re140 As New Regex("^WDC.*", RegexOptions.IgnoreCase)
            If re140.Match(ataDeviceModel).Success Or re140.Match(ataModelFamily).Success Then newvalue = "140"
            re140 = Nothing

            If IsNothing(newvalue) Then
                Return "0"
            Else
                Return newvalue
            End If
        End If
    End Function

    Private Function GetNormalizedValue(ByVal attribute() As String) As String
        Return attribute(3)
    End Function

    Private Function ReplaceShortErrors(ByVal err As String) As String 'not used from version 0.6.0
        'replace short error description codes
        err = err.Replace("ABRT", "Command Aborted")
        err = err.Replace("AMNF", "Address Mark Not Fount")
        err = err.Replace("CCTO", "Command Completion Timed Out")
        err = err.Replace("EOM", "End Of Media")
        err = err.Replace("ICRC", "Interface Cyclic Rendundancy Code (CRC) error")
        err = err.Replace("IDNF", "Identity Not Found")
        err = err.Replace("ILI", "(packet command-set specific)")
        err = err.Replace("MCR", "Media Change Request")
        err = err.Replace("MC", "Media Changed")
        err = err.Replace("NM", "No Media")
        err = err.Replace("obs", "Obsolete")
        err = err.Replace("TK0NF", "Track 0 Not Found")
        err = err.Replace("UNC", "Uncorrectable Error in Data")
        err = err.Replace("WP", "Media is Write Protected")
        Return err
    End Function

    Private Function ConvertToSeconds(ByVal duration As String) As Integer
        If duration.Contains("minutes") Then
            Return Val(duration) * 60
        Else
            Return Val(duration)
        End If
    End Function
#End Region

#Region "Subs"
    Public Sub Update()
        If (devType = DeviceType.ATA Or devType = DeviceType.USB) And Not devIsVirtual Then
            Dim cmdlineoptions As String = devOptions
            If AppSettings.Smartctl.SetTolerance Then cmdlineoptions += AppSettings.Smartctl.Tolerance
            If AppSettings.Smartctl.SetPowerMode Then cmdlineoptions += AppSettings.Smartctl.PowerMode
            If cmdlineoptions.Contains("-d sat") Then
                'this keep safe if a device is moved from an asmedia controller to a standard one...
                Dim temp_output() As String = smartctl.SendCmd("-a -d sat " & devLocation.Replace("-d ata", ""))
                Dim verified As Boolean = False
                For i As Short = 0 To temp_output.Count - 2
                    If temp_output(i).Contains("START OF INFORMATION SECTION") Then
                        verified = True
                        Exit For
                    End If
                Next
                temp_output = Nothing

                If verified = True Then
                    devOutput = smartctl.SendCmd(_ataCmd & cmdlineoptions.Replace(vbCrLf, "") & " " & devLocation.Replace("-d ata", ""))
                Else
                    cmdlineoptions = cmdlineoptions.Replace("-d sat", "")
                    SaveSettings()
                    devOutput = smartctl.SendCmd(_ataCmd & cmdlineoptions.Replace(vbCrLf, "") & " " & devLocation)
                End If
            Else
                devOutput = smartctl.SendCmd(_ataCmd & cmdlineoptions.Replace(vbCrLf, "") & " " & devLocation)
            End If


        ElseIf (devType = DeviceType.SCSI) And Not devIsVirtual Then
            devOutput = smartctl.SendCmd(_scsiCmd & devLocation)
        ElseIf devType = DeviceType.ThreeWare Then
            devOutput = smartctl.SendCmd("-a /dev/tw_cli/clip")
        Else 'a virtual device!
            If IO.File.Exists(devLocation) Then
                devOutput = IO.File.ReadAllLines(devLocation)
                Dim fname As String = IO.Path.GetFileName(devLocation)
                IO.File.Copy(devLocation, My.Application.Info.DirectoryPath & "\Data\" & My.User.Name & "\" & fname, True)
                devIsAvailable = True
            Else
                'if a file is stored into a non local device, is possible
                'that file is unaccessible for a showdown of the net
                devIsAvailable = False
                Dim fname As String = IO.Path.GetFileName(devLocation)
                Dim mirror As String = My.Application.Info.DirectoryPath & "\Data\" & My.User.Name & "\" & fname
                If IO.File.Exists(mirror) Then devOrigContent = IO.File.ReadAllText(mirror)
                Exit Sub
            End If
        End If

        If GetIndexOf("Warning: Limited functionality due to missing admin rights") > 0 Then devMissingAdminRights = True

        devIsValid = CheckIfValid()

        'If devisvalid Then

        devLastCheck = GetInfo("Local Time is")

        If scsiIsDisk Then
            GetScsiAttributes()
            GetScsiErrorLog()
            GetScsiSelfTest()
        Else
            GetDeviceInfo()
            GetHealth()
            GetCapabilities()
            GetAttributes()
            GetErrors()
            LastSelfTest()
            GetSelfTest()
            GetTemperatures()
            GetTestTiming()
        End If

        Reliability()
        UpdateTrayIcon()

        CompareVitals()
        devAlreadyWarned = False
    End Sub

    Private Sub CompareVitals()
        'Dim tolog As Boolean = False
        Dim l As LogItem

        l.Year = Now.Year
        l.Month = Now.Month
        l.Day = Now.Day
        l.Hour = Now.Hour & ":" & Now.Minute & ":" & Now.Second

        If Not IsNothing(ataOldVitals) And Not IsNothing(ataNewVitals) Then
            With AppSettings.VitalParameters

                If .PendingSectors.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.CurPending) And IsNumeric(ataNewVitals.CurPending) Then
                        ataVitals.CurPending = Convert.ToSingle(ataNewVitals.CurPending) - Convert.ToSingle(ataOldVitals.CurPending)
                        If ataVitals.CurPending <> 0 Then
                            With l
                                .EventName = "Current pending sectors"
                                .OldValue = ataOldVitals.CurPending
                                .NewValue = ataNewVitals.CurPending
                                .Variation = ataVitals.CurPending
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .DiskShift.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.DiskShift) And IsNumeric(ataNewVitals.DiskShift) Then
                        ataVitals.DiskShift = Convert.ToSingle(ataNewVitals.DiskShift) - Convert.ToSingle(ataOldVitals.DiskShift)
                        If ataVitals.DiskShift <> 0 Then
                            With l
                                .EventName = "Disk shift"
                                .OldValue = ataOldVitals.DiskShift
                                .NewValue = ataNewVitals.DiskShift
                                .Variation = ataVitals.DiskShift
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If IsNumeric(ataOldVitals.Errors) And IsNumeric(ataNewVitals.Errors) Then
                    ataVitals.Errors = Convert.ToSingle(ataNewVitals.Errors) - Convert.ToSingle(ataOldVitals.Errors)
                    If ataVitals.Errors <> 0 Then
                        With l
                            .EventName = "ATA Errors"
                            .OldValue = ataOldVitals.Errors
                            .NewValue = ataNewVitals.Errors
                            .Variation = ataVitals.Errors
                        End With
                        devLog.Add(New DeviceLog(l))
                    End If
                End If

                If .Indilinx.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.Indilinx) And IsNumeric(ataNewVitals.Indilinx) Then
                        ataVitals.Indilinx = Convert.ToSingle(ataNewVitals.Indilinx) - Convert.ToSingle(ataOldVitals.Indilinx)
                        If ataVitals.Indilinx <> 0 Then
                            With l
                                .EventName = "Remaining life percentage"
                                .OldValue = ataOldVitals.Indilinx
                                .NewValue = ataNewVitals.Indilinx
                                .Variation = ataVitals.Indilinx
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .Intel.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.Intel) And IsNumeric(ataNewVitals.Intel) Then
                        ataVitals.Intel = Convert.ToSingle(ataNewVitals.Intel) - Convert.ToSingle(ataOldVitals.Intel)
                        If ataVitals.Intel <> 0 Then
                            With l
                                .EventName = "Media wearout indicator"
                                .OldValue = ataOldVitals.Intel
                                .NewValue = ataNewVitals.Intel
                                .Variation = ataVitals.Intel
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .Micron.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.Micron) And IsNumeric(ataNewVitals.Micron) Then
                        ataVitals.Micron = Convert.ToSingle(ataNewVitals.Micron) - Convert.ToSingle(ataOldVitals.Micron)
                        If ataVitals.Micron <> 0 Then
                            With l
                                .EventName = "Percentage lifetime used"
                                .OldValue = ataOldVitals.Micron
                                .NewValue = ataNewVitals.Micron
                                .Variation = ataVitals.Micron
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .OfflineUncorrectable.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.OfflineUnc) And IsNumeric(ataNewVitals.OfflineUnc) Then
                        ataVitals.OfflineUnc = Convert.ToSingle(ataNewVitals.OfflineUnc) - Convert.ToSingle(ataOldVitals.OfflineUnc)
                        If ataVitals.OfflineUnc <> 0 Then
                            With l
                                .EventName = "Offline uncorrectable"
                                .OldValue = ataOldVitals.OfflineUnc
                                .NewValue = ataNewVitals.OfflineUnc
                                .Variation = ataVitals.OfflineUnc
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .ReallocationEvents.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.ReallEvent) And IsNumeric(ataNewVitals.ReallEvent) Then
                        ataVitals.ReallEvent = Convert.ToSingle(ataNewVitals.ReallEvent) - Convert.ToSingle(ataOldVitals.ReallEvent)
                        If ataVitals.ReallEvent <> 0 Then
                            With l
                                .EventName = "Reallocated event count"
                                .OldValue = ataOldVitals.ReallEvent
                                .NewValue = ataNewVitals.ReallEvent
                                .Variation = ataVitals.ReallEvent
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .ReallocatedSectors.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.ReallSect) And IsNumeric(ataNewVitals.ReallSect) Then
                        ataVitals.ReallSect = Convert.ToSingle(ataNewVitals.ReallSect) - Convert.ToSingle(ataOldVitals.ReallSect)
                        If ataVitals.ReallSect <> 0 Then
                            With l
                                .EventName = "Reallocated sector count"
                                .OldValue = ataOldVitals.ReallSect
                                .NewValue = ataNewVitals.ReallSect
                                .Variation = ataVitals.ReallSect
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .Samsung.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.Samsung) And IsNumeric(ataNewVitals.Samsung) Then
                        ataVitals.Samsung = Convert.ToSingle(ataNewVitals.Samsung) - Convert.ToSingle(ataOldVitals.Samsung)
                        If ataVitals.Samsung <> 0 Then
                            With l
                                .EventName = "Wear leveling count"
                                .OldValue = ataOldVitals.Samsung
                                .NewValue = ataNewVitals.Samsung
                                .Variation = ataVitals.Samsung
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .SandForce.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.SandForce) And IsNumeric(ataNewVitals.SandForce) Then
                        ataVitals.SandForce = Convert.ToSingle(ataNewVitals.SandForce) - Convert.ToSingle(ataOldVitals.SandForce)
                        If ataVitals.SandForce <> 0 Then
                            With l
                                .EventName = "SSD life left"
                                .OldValue = ataOldVitals.SandForce
                                .NewValue = ataNewVitals.SandForce
                                .Variation = ataVitals.SandForce
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .SoftReadErrors.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.SoftRead) And IsNumeric(ataNewVitals.SoftRead) Then
                        ataVitals.SoftRead = Convert.ToSingle(ataNewVitals.SoftRead) - Convert.ToSingle(ataOldVitals.SoftRead)
                        If ataVitals.SoftRead <> 0 Then
                            With l
                                .EventName = "Soft read error rate"
                                .OldValue = ataOldVitals.SoftRead
                                .NewValue = ataNewVitals.SoftRead
                                .Variation = ataVitals.SoftRead
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .SpinRetry.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.SpinRetry) And IsNumeric(ataNewVitals.SpinRetry) Then
                        ataVitals.SpinRetry = Convert.ToSingle(ataNewVitals.SpinRetry) - Convert.ToSingle(ataOldVitals.SpinRetry)
                        If ataVitals.SpinRetry <> 0 Then
                            With l
                                .EventName = "Spin retry count"
                                .OldValue = ataOldVitals.SpinRetry
                                .NewValue = ataNewVitals.SpinRetry
                                .Variation = ataVitals.SpinRetry
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                    End If
                End If

                If .Temperature.HasFlag(CustomSettings.SettingsVital.Vital.Track) Then
                    If IsNumeric(ataOldVitals.Temperature) And IsNumeric(ataNewVitals.Temperature) Then
                        ataVitals.Temperature = Convert.ToSingle(ataNewVitals.Temperature) - Convert.ToSingle(ataOldVitals.Temperature)
                        'If atanewvitals.Temperature >= 50 Or ataoldvitals.Temperature >= 50 Then
                        If ataVitals.Temperature <> 0 Then
                            With l
                                .EventName = "Temperature"
                                .OldValue = ataOldVitals.Temperature
                                .NewValue = ataNewVitals.Temperature
                                .Variation = ataVitals.Temperature
                            End With
                            devLog.Add(New DeviceLog(l))
                        End If
                        'End If
                    End If
                End If
            End With


            'ataoldvitals = atanewvitals
        End If

        If IsNothing(ataNewVitals) And Not IsNothing(ataOldVitals) Then ataNewVitals = ataOldVitals
        If Not IsNothing(devLog) Then SaveLog()
    End Sub

    Private Sub SaveLog()
        Try
            If Not devSaveLog Then Exit Sub
            If ataDeviceModel = "N/A" Or ataSerialNumber = "N/A" Then Exit Sub

            Dim f As String = My.Application.Info.DirectoryPath & "\Data\" & My.Computer.Name & "\logs"

            If Not IO.Directory.Exists(f & "\") Then IO.Directory.CreateDirectory(f & "\")

            Dim output As XmlWriterSettings = New XmlWriterSettings()
            output.Indent = True
            Using write As XmlWriter = XmlWriter.Create(f & "\" & devFileName & ".xml", output)
                write.WriteStartDocument()
                write.WriteStartElement("log")

                If Not IsNothing(devLog) Then
                    For i As Short = 0 To devLog.Count - 1
                        write.WriteStartElement("logitem")
                        write.WriteAttributeString("year", devLog(i).Year)
                        write.WriteAttributeString("month", devLog(i).Month)
                        write.WriteAttributeString("day", devLog(i).Day)
                        write.WriteAttributeString("hour", devLog(i).Hour)
                        write.WriteAttributeString("event", devLog(i).Event)
                        write.WriteAttributeString("from", devLog(i).OldValue)
                        write.WriteAttributeString("to", devLog(i).NewValue)
                        write.WriteAttributeString("variation", devLog(i).Variation)
                        write.WriteEndElement()
                    Next
                End If

                If Not IsNothing(ataNewVitals) Then
                    write.WriteStartElement("values")
                    write.WriteAttributeString("current_pending", ataNewVitals.CurPending)
                    write.WriteAttributeString("disk_shift", ataNewVitals.DiskShift)
                    write.WriteAttributeString("ata_errors", ataNewVitals.Errors)
                    write.WriteAttributeString("indilinx", ataNewVitals.Indilinx)
                    write.WriteAttributeString("intel", ataNewVitals.Intel)
                    write.WriteAttributeString("micron", ataNewVitals.Micron)
                    write.WriteAttributeString("offline_uncorrectable", ataNewVitals.OfflineUnc)
                    write.WriteAttributeString("reallocation_events", ataNewVitals.ReallEvent)
                    write.WriteAttributeString("reallocated_sectors", ataNewVitals.ReallSect)
                    write.WriteAttributeString("samsung", ataNewVitals.Samsung)
                    write.WriteAttributeString("sandforce", ataNewVitals.SandForce)
                    write.WriteAttributeString("soft_read", ataNewVitals.SoftRead)
                    write.WriteAttributeString("spin_retry", ataNewVitals.SpinRetry)
                    write.WriteAttributeString("temperature", ataNewVitals.Temperature)
                    write.WriteEndElement()
                End If

                write.WriteEndElement()
                write.WriteEndDocument()
            End Using
        Catch e As Exception
            'Main.PrintDebug("Encountered an error while saving " & atadevicemodel & " (" & ataserialnumber & ") log: " & e.ToString, True)
        End Try
    End Sub

    Private Sub LoadLog()
        Try
            Dim fo As String = My.Application.Info.DirectoryPath & "\Data\" & My.Computer.Name & "\logs"
            Dim fi As String = "\" & devFileName & ".xml"

            If Not IO.Directory.Exists(fo & "\") Then IO.Directory.CreateDirectory(fo & "\")

            If IO.File.Exists(fo & fi) Then
                Dim m_xmldoc As New XmlDocument
                Dim m_nodelist As XmlNodeList
                Dim m_node As XmlNode
                m_xmldoc.Load(fo & fi)
                m_nodelist = m_xmldoc.SelectNodes("/log/logitem")
                Dim l As New LogItem
                For Each m_node In m_nodelist
                    With l
                        .Year = m_node.Attributes.GetNamedItem("year").Value
                        .Month = m_node.Attributes.GetNamedItem("month").Value
                        .Day = m_node.Attributes.GetNamedItem("day").Value
                        .Hour = m_node.Attributes.GetNamedItem("hour").Value
                        .EventName = m_node.Attributes.GetNamedItem("event").Value
                        .OldValue = m_node.Attributes.GetNamedItem("from").Value
                        .NewValue = m_node.Attributes.GetNamedItem("to").Value
                        .Variation = m_node.Attributes.GetNamedItem("variation").Value
                    End With
                    devLog.Add(New DeviceLog(l))
                Next

                m_nodelist = m_xmldoc.SelectNodes("/log/values")
                For Each m_node In m_nodelist
                    With ataOldVitals
                        .CurPending = m_node.Attributes.GetNamedItem("current_pending").Value
                        .DiskShift = m_node.Attributes.GetNamedItem("disk_shift").Value
                        .Errors = m_node.Attributes.GetNamedItem("ata_errors").Value
                        .Indilinx = m_node.Attributes.GetNamedItem("indilinx").Value
                        .Intel = m_node.Attributes.GetNamedItem("intel").Value
                        .Micron = m_node.Attributes.GetNamedItem("micron").Value
                        .OfflineUnc = m_node.Attributes.GetNamedItem("offline_uncorrectable").Value
                        .ReallEvent = m_node.Attributes.GetNamedItem("reallocation_events").Value
                        .ReallSect = m_node.Attributes.GetNamedItem("reallocated_sectors").Value
                        .Samsung = m_node.Attributes.GetNamedItem("samsung").Value
                        .SandForce = m_node.Attributes.GetNamedItem("sandforce").Value
                        .SoftRead = m_node.Attributes.GetNamedItem("soft_read").Value
                        .SpinRetry = m_node.Attributes.GetNamedItem("spin_retry").Value
                        .Temperature = m_node.Attributes.GetNamedItem("temperature").Value
                    End With
                Next
            End If
        Catch e As Exception

        End Try
    End Sub

    Private Sub SaveSettings()
        If devIsVirtual Then Exit Sub

        Dim folder As String = My.Application.Info.DirectoryPath & "\Data\" & My.User.Name
        Dim output As XmlWriterSettings = New XmlWriterSettings()
        output.Indent = True
        Using write As XmlWriter = XmlWriter.Create(folder & "\" & devFileName & ".xml", output)
            write.WriteStartDocument()
            write.WriteStartElement("monitoring")
            write.WriteStartElement("settings")
            write.WriteAttributeString("trayicon", devTrayIcon.Visible)
            write.WriteAttributeString("displaylife", trayDisplayLife)
            write.WriteAttributeString("share", devIsShared)
            write.WriteEndElement()
            write.WriteEndElement()
            write.WriteEndDocument()
        End Using

        folder = My.Application.Info.DirectoryPath & "\Data\" & My.Computer.Name
        Using write As XmlWriter = XmlWriter.Create(folder & "\" & devFileName & ".xml", output)
            write.WriteStartElement("smartctl")
            write.WriteStartElement("settings")
            write.WriteAttributeString("options", devOptions)
            write.WriteAttributeString("standby", ataStandby)
            write.WriteEndElement()
            write.WriteEndElement()
            write.WriteEndDocument()
        End Using
    End Sub

    Private Sub LoadSettings()
        If devIsVirtual Then Exit Sub

        Dim folder As String = My.Application.Info.DirectoryPath & "\Data\" & My.User.Name

        If IO.File.Exists(folder & "\" & devFileName & ".xml") Then
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            Try
                m_xmldoc.Load(folder & "\" & devFileName & ".xml")
                m_nodelist = m_xmldoc.SelectNodes("/monitoring/settings")
                For Each m_node In m_nodelist
                    devTrayIcon.Visible = m_node.Attributes.GetNamedItem("trayicon").Value
                    trayDisplayLife = m_node.Attributes.GetNamedItem("displaylife").Value
                    devIsShared = m_node.Attributes.GetNamedItem("share").Value
                Next
            Catch ex As Exception

            End Try
        End If

        folder = My.Application.Info.DirectoryPath & "\Data\" & My.Computer.Name

        If IO.File.Exists(folder & "\" & devFileName & ".xml") Then
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            Try
                m_xmldoc.Load(folder & "\" & devFileName & ".xml")
                m_nodelist = m_xmldoc.SelectNodes("/smartctl/settings")
                For Each m_node In m_nodelist
                    devOptions = m_node.Attributes.GetNamedItem("options").Value
                    ataStandby = m_node.Attributes.GetNamedItem("standby").Value
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub UpdateTrayIcon()

        If devIsVirtual Or devType = DeviceType.ThreeWare Then Exit Sub

        Dim iconvalue As String = ""
        With devTrayIcon

            .Health = devHealth
            .RemainingLife = ataRemainingLife
            .Temperature = devTemperature
            .Rating = ataRating

            If trayDisplayLife Then
                .SetIcon()
                iconvalue = Main.m_remaininglife & ": " & ataRemainingLife & "%"
            Else
                .SetIcon()
                If IsNumeric(devTemperature) Then
                    If AppSettings.General.TemperatureInFahrenheit = True Then
                        iconvalue = Main.m_temperature & ": " & Math.Round(devTemperature * 1.8 + 32) & "°F"
                    Else
                        iconvalue = Main.m_temperature & ": " & devTemperature & "°C"
                    End If
                Else
                    iconvalue = Main.m_temperature & ": " & devTemperature
                End If
            End If

            .Title = ataDeviceModel

            Dim rating As String = ""
            Select Case ataRating.Overall
                Case 5
                    rating = vbCrLf & Main.m_reliability & "*****"
                Case 4
                    rating = vbCrLf & Main.m_reliability & "****"
                Case 3
                    rating = vbCrLf & Main.m_reliability & "***"
                Case 2
                    rating = vbCrLf & Main.m_reliability & "**"
                Case 1
                    rating = vbCrLf & Main.m_reliability & "*"
                Case Else
            End Select

            Select Case devHealth
                Case Status.Failed
                    .Content = iconvalue & vbCrLf &
                        Main.m_overallhealth & ": " & Main.h_overallfailed & rating
                Case Status.Passed
                    .Content = iconvalue & vbCrLf &
                        Main.m_overallhealth & ": " & Main.h_overallpassed & rating
                Case Status.Unknown
                    .Content = iconvalue & vbCrLf &
                        Main.m_overallhealth & ": " & Main.h_unknown & rating
            End Select
        End With
    End Sub
#End Region

#Region "Devices common classes and properties"
#Region "Common classes"
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class DeviceSmart
        Dim pd As Device

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public ReadOnly Property Support As Support
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return Support.Unavailable
                Return pd.devSmartAvailable
            End Get
        End Property

        Public ReadOnly Property IsEnabled As Support
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return Support.Unavailable
                Return pd.devSmartEnabled
            End Get
        End Property

        Public Sub Enable()
            pd.smartctl.SendCmd("-s on " & pd.devLocation)
        End Sub

        Public Sub Disable()
            pd.smartctl.SendCmd("-s off " & pd.devLocation)
        End Sub
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class DeviceLastTest
        Dim _status As TestStatus
        Dim _remaining As String = ""

        Public Sub New(ByVal status As TestStatus, Optional ByVal remaining As String = "")
            _status = status
            _remaining = remaining
        End Sub

        Public ReadOnly Property Status As TestStatus
            Get
                Return _status
            End Get
        End Property

        Public ReadOnly Property Remaining As String
            Get
                Return _remaining
            End Get
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class DeviceTrayIcon
        Dim pd As Device

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public Property DisplayLife As Boolean
            Get
                Return pd.trayDisplayLife
            End Get
            Set(ByVal value As Boolean)
                pd.trayDisplayLife = value
                pd.SaveSettings()
            End Set
        End Property

        Public Property Show As Boolean
            Get
                If pd.devType = DeviceType.ThreeWare Then
                    Return False
                Else
                    Return pd.devTrayIcon.Visible
                End If
            End Get
            Set(ByVal value As Boolean)
                If Not pd.devType = DeviceType.ThreeWare Then
                    If Not IsNothing(pd.devTrayIcon) Then
                        pd.devTrayIcon.Visible = value
                        If value = True Then pd.UpdateTrayIcon()
                        'If value = False Then devtrayicon.Dispose()
                        pd.SaveSettings()
                    Else
                        pd.devTrayIcon = New TrayIcon(pd)
                        pd.devTrayIcon.Visible = value
                        If value = True Then pd.UpdateTrayIcon()
                        pd.SaveSettings()
                    End If
                End If
            End Set
        End Property

        Public Sub Dispose()
            If Not IsNothing(pd.devTrayIcon) Then pd.devTrayIcon.Dispose()
        End Sub
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class DeviceWorkTime
        Dim pd As Device

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public ReadOnly Property TotalHours As String
            Get
                If pd.devType = DeviceType.SCSI Then
                    Return pd.scsiWorkTime
                Else
                    If Not pd.devIsValid Then Return "N/A"
                    Return pd.ataWorkTime
                End If
            End Get
        End Property

        Public ReadOnly Property Normalized As String
            Get
                If pd.devType = DeviceType.SCSI Then
                    Return pd.scsiWorkTimeHuman
                Else
                    If Not pd.devIsValid Then Return "N/A"
                    Return pd.ataWorkTimeHuman
                End If
            End Get
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class DeviceMailNotification
        Dim tempSended As Boolean = False
        Dim healthSended As Boolean = False

        Public Property SentTemperature As Boolean
            Get
                Return tempSended
            End Get
            Set(value As Boolean)
                tempSended = value
            End Set
        End Property

        Public Property SentHealth As Boolean
            Get
                Return healthSended
            End Get
            Set(value As Boolean)
                healthSended = value
            End Set
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class DeviceLog
        Dim l As LogItem

        Public Sub New(ByVal logItem As LogItem)
            l = logItem
        End Sub

        Public ReadOnly Property Year As String
            Get
                Return l.Year
            End Get
        End Property

        Public ReadOnly Property Month As String
            Get
                Return l.Month
            End Get
        End Property
        Public ReadOnly Property Day As String
            Get
                Return l.Day
            End Get
        End Property
        Public ReadOnly Property Hour As String
            Get
                Return l.Hour
            End Get
        End Property
        Public ReadOnly Property [Event] As String
            Get
                Return l.EventName
            End Get
        End Property
        Public ReadOnly Property OldValue As String
            Get
                Return l.OldValue
            End Get
        End Property
        Public ReadOnly Property NewValue As String
            Get
                Return l.NewValue
            End Get
        End Property
        Public ReadOnly Property Variation As String
            Get
                Return l.Variation
            End Get
        End Property
    End Class
#End Region

#Region "Common properties"
    Public ReadOnly Property Type As DeviceType
        Get
            Return devType
        End Get
    End Property

    Public ReadOnly Property Location As String
        Get
            Return devLocation
        End Get
    End Property

    Public ReadOnly Property LastUpdate As String
        Get
            If devType = DeviceType.ThreeWare And Not devIsValid Then Return "N/A"

            Dim months() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
            Dim newdate As String = devLastCheck

            If Not IsNothing(newdate) Then
                For i As Short = 0 To months.Count - 1
                    newdate = newdate.Replace(months(i), Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(i + 1))
                Next
                newdate = newdate.Replace("Fri", Globalization.DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Friday)) _
                    .Replace("Mon", Globalization.DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Monday)) _
                    .Replace("Sat", Globalization.DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Saturday)) _
                    .Replace("Sun", Globalization.DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Sunday)) _
                    .Replace("Thu", Globalization.DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Thursday)) _
                    .Replace("Tue", Globalization.DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Tuesday)) _
                    .Replace("Wed", Globalization.DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Wednesday)) _
                    .Replace(":", " ")
                months = Nothing
                Dim dt As DateTime
                If DateTime.TryParseExact(newdate, "dddd MMMM dd HH mm ss yyyy", Nothing, Nothing, dt) Then
                    Return FormatDateTime(dt, DateFormat.ShortDate) & ", " & FormatDateTime(dt, DateFormat.LongTime)
                Else
                    newdate = Nothing
                    Return devLastCheck
                End If
            Else
                months = Nothing
                newdate = Nothing
                Return "N/A"
            End If
        End Get
    End Property

    Public ReadOnly Property Smart As DeviceSmart
        Get
            Return devSmart
        End Get
    End Property

    Public ReadOnly Property Output As String
        Get
            Dim value As String = ""

            If devIsAvailable Then
                If IO.File.Exists(devLocation) Then
                    value = IO.File.ReadAllText(devLocation)
                Else
                    For i As Integer = 0 To devOutput.Length - 1
                        If Not IsNothing(devOutput(i)) Then
                            If i > 0 Then
                                value += devOutput(i).Replace(vbLf, vbCrLf)
                            Else
                                value += devOutput(i).Replace(vbLf, "")
                            End If
                        Else
                            value += devOutput(i)
                        End If
                    Next
                End If
            End If

            Return value
        End Get
    End Property

    Public ReadOnly Property IsOptical As Boolean
        Get
            Return devIsOptical
        End Get
    End Property

    Public Property IsShared As Boolean
        Get
            Return devIsShared
        End Get
        Set(ByVal value As Boolean)
            devIsShared = value
            SaveSettings()
        End Set
    End Property

    Public ReadOnly Property SmartctlVersion As String
        Get
            For i As Short = 0 To devOutput.Count - 1
                If devOutput(i).Trim.StartsWith("smartctl") Then
                    Dim smartctl() As String = devOutput(i).Trim.Split(" ")
                    Return smartctl(0) & " " & smartctl(1)
                End If
            Next
            Return ""
        End Get
    End Property

    Public ReadOnly Property MissingAdminRights As Boolean
        Get
            Return devMissingAdminRights
        End Get
    End Property

    Public Property Options As String
        Get
            Return devOptions
        End Get
        Set(ByVal value As String)
            devOptions = value
            SaveSettings()
        End Set
    End Property

    Public ReadOnly Property IsValid As Boolean
        Get
            Return devIsValid
        End Get
    End Property

    Public ReadOnly Property Health As Status
        Get
            If devType = DeviceType.ThreeWare And Not devIsValid Then Return Status.Unknown
            Return devHealth
        End Get
    End Property

    Public ReadOnly Property Temperature As String
        Get
            If devType = DeviceType.ThreeWare And Not devIsValid Then Return "N/A"
            Return devTemperature
        End Get
    End Property

    Public ReadOnly Property FileName As String
        Get
            Return devFileName
        End Get
    End Property

    Public ReadOnly Property [Interface] As String
        Get
            If devType = DeviceType.SCSI Then
                If Not IsNothing(scsiProtocol) Then
                    If scsiProtocol.Length > 0 Then
                        Return scsiProtocol
                    Else
                        Return "SCSI"
                    End If
                End If
            End If

            If Not IsNothing(ataSataVersion) Then
                If ataSataVersion <> "N/A" Then
                    Dim sataver() As String = ataSataVersion.Split(",")
                    Return sataver(0)
                Else
                    If IsNumeric(ataVersion) Then
                        Select Case ataVersion
                            Case 0 To 6
                                Return "PATA"
                            Case 7
                                Return "ATA"
                            Case 8
                                Return "SATA"
                            Case Else
                                Return "N/A"
                        End Select
                    Else
                        If ataVersion.ToString.Contains("ATA/ATAPI") Then
                            If ataVersion.ToString.Contains("ATA/ATAPI-7") Then
                                Return "ATA"
                            Else
                                Return "PATA"
                            End If
                        ElseIf ataVersion.ToString.Contains("ATA8") Then
                            Return "SATA"
                        Else
                            If ataSataVersion <> "N/A" Then
                                Return "SATA"
                            Else
                                Return "N/A"
                            End If
                        End If
                    End If
                End If
            Else
                Return "N/A"
            End If

        End Get
    End Property

    Public ReadOnly Property IsVirtual As Boolean
        Get
            Return devIsVirtual
        End Get
    End Property

    Public ReadOnly Property VirtualDeviceName As String
        Get
            Return devVirtualName
        End Get
    End Property

    Public ReadOnly Property LastTestResult As DeviceLastTest
        Get
            Return devLastTest
        End Get
    End Property

    Public Property AlreadyWarned As Boolean
        Get
            Return devAlreadyWarned
        End Get
        Set(ByVal value As Boolean)
            devAlreadyWarned = value
        End Set
    End Property

    Public ReadOnly Property Tray As DeviceTrayIcon
        Get
            Return devTray
        End Get
    End Property

    Public ReadOnly Property WorkTime As DeviceWorkTime
        Get
            Return devWorkTime
        End Get
    End Property

    Public Property MailNotification As DeviceMailNotification
        Get
            Return devMailNotification
        End Get
        Set(value As DeviceMailNotification)
            devMailNotification = value
        End Set
    End Property

    Public Structure LogItem
        Dim Year, Month, Day, Hour, EventName, OldValue, NewValue, Variation As String
    End Structure

    Public ReadOnly Property Log As List(Of DeviceLog)
        Get
            Return devLog
        End Get
    End Property
#End Region
#End Region
End Class

Public Structure DevCapabilities
    Dim Name As String
    Dim Value As String
    Dim Meaning As String
End Structure

<Flags()>
Public Enum TestStatus
    Passed = 0
    Aborted = 1
    HostReset = 2
    UnknownError = 3
    FailureUnknown = 4
    FailureElectric = 5
    FailureServo = 6
    FailureRead = 7
    FailureDamage = 8
    Unknown = 15
    InProgress = 24
    Reserved = 100
End Enum

<Flags()> _
Public Enum Status
    Unknown = 0
    Passed = 1
    Failed = 2
    Aborted = 3
End Enum

<Flags()> _
Public Enum SmartFeature
    Enable = 0
    Disable = 1
End Enum

<Flags()> _
Public Enum Support
    Enabled = 0
    Disabled = 1
    Available = 2
    Unavailable = 4
    Ambiguous = 8
    Unknown = 16
End Enum

<Flags()> _
Public Enum AttributeFlags
    None = 0
    Prefailure = 1
    UpdatedOnline = 2
    Performance = 4
    ErrorRate = 8
    EventCount = 16
    SelfPreserving = 32
End Enum

<Flags()> _
Public Enum AttributeType
    PreFail = 0
    OldAge = 1
End Enum

<Flags()> _
Public Enum AttributeUpdate
    Always = 0
    Offline = 1
End Enum

Public Enum Feature
    Disabled = 0
    Enabled = 1
    Unavailable = 2
End Enum