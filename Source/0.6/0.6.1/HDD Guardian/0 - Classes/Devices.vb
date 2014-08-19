'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class Devices
    Inherits List(Of Device)
End Class

<Flags()> _
Public Enum DeviceType
    ATA = 0
    Virtual = 1
    USB = 2
    SCSI = 3
End Enum

Public Class Device

#Region "Tray icon"

    Private Class TrayIcon

        Private Class Icons
            Inherits List(Of Icon)
        End Class

        Private WithEvents ti As New NotifyIcon
        Dim m_visible As Boolean
        Dim m_title, m_content As String
        Dim m_icon As System.Drawing.Icon
        Dim WithEvents mousefollower As New Timer
        Dim isrunning As Boolean = False
        Dim mouseposition, localposition, lastposition As Point

        Public Sub Dispose()
            ti.Dispose()
        End Sub

        Private Sub mousefollowerTick(sender As Object, e As EventArgs) Handles mousefollower.Tick
            mouseposition = Cursor.Position()

            If localposition = lastposition And lastposition <> mouseposition Then
                TrayPanel.Hide()
                mousefollower.Stop()
                isrunning = False
                Exit Sub
            End If

            isrunning = True
        End Sub

        Private Sub ti_MouseMove(sender As Object, e As MouseEventArgs) Handles ti.MouseMove
            If My.Settings.InfoPanel Then
                If Main.WindowState = FormWindowState.Minimized Then
                    localposition = Cursor.Position
                    lastposition = Cursor.Position

                    mousefollower.Interval = 1
                    If Not isrunning Then mousefollower.Start()

                    If TrayPanel.Visible Then
                        Exit Sub
                    Else
                        TrayPanel.SetPanel(m_ssd, m_model, m_location, m_rating, m_temperature, m_remaininglife, m_health, m_type)
                        TrayPanel.Show(Main)
                    End If
                End If
            Else
                TrayPanel.Hide()
            End If
        End Sub

        Private Sub ti_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ti.MouseDown
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left
                    'restore main screen
                    TrayPanel.Hide()
                    Main.WindowState = FormWindowState.Normal
                    Main.ShowInTaskbar = True
                    Main.Visible = True
                    Main.Activate()
                    Main.niTrayIcon.Visible = My.Settings.AlwaysShowTrayIcon
                Case Windows.Forms.MouseButtons.Middle
                    'if is pressed the middle button refresh all devices
                    Main.CheckForUpdates()
                    Main.UpdateAll(DeviceType.ATA)
                    Main.UpdateAll(DeviceType.USB)
                    Main.UpdateAll(DeviceType.Virtual)
                Case Windows.Forms.MouseButtons.Right
                    'show device tooltip
                    'Me.ti.ShowBalloonTip(3000)
            End Select
        End Sub

        Public Property Visible As Boolean
            Get
                Return m_visible
            End Get
            Set(ByVal value As Boolean)
                m_visible = value
                Me.ti.Visible = value
            End Set
        End Property

        Public Property Title As String
            Get
                Return m_title
            End Get
            Set(ByVal value As String)
                m_title = value
                Me.ti.BalloonTipTitle = value
                Me.ti.Text = value
            End Set
        End Property

        Public Property Content As String
            Get
                Return m_content
            End Get
            Set(ByVal value As String)
                m_content = value
                Me.ti.BalloonTipText = value
            End Set
        End Property

        Public Property exIcon As System.Drawing.Icon
            Get
                Return m_icon
            End Get
            Set(ByVal value As System.Drawing.Icon)
                m_icon = value
                Me.ti.Icon = value
            End Set
        End Property

#Region "Properties for Info Panel"
        Dim m_model, m_location, m_temperature, m_remaininglife As String
        Dim m_rating As Ratings
        Dim m_health As Status
        Dim m_type As DeviceType
        Dim m_ssd As Boolean

        Public Property IsSsd As Boolean
            Get
                Return m_ssd
            End Get
            Set(value As Boolean)
                m_ssd = value
            End Set
        End Property

        Public Property Model As String
            Get
                Return m_model
            End Get
            Set(value As String)
                m_model = value
            End Set
        End Property

        Public Property Location As String
            Get
                Return m_location
            End Get
            Set(value As String)
                m_location = value
            End Set
        End Property

        Public Property Temperature As String
            Get
                Return m_temperature
            End Get
            Set(value As String)
                m_temperature = value
            End Set
        End Property

        Public Property RemainingLife As String
            Get
                Return m_remaininglife
            End Get
            Set(value As String)
                m_remaininglife = value
            End Set
        End Property

        Public Property Rating As Ratings
            Get
                Return m_rating
            End Get
            Set(value As Ratings)
                m_rating = value
            End Set
        End Property

        Public Property Health As Status
            Get
                Return m_health
            End Get
            Set(value As Status)
                m_health = value
            End Set
        End Property

        Public Property Type As DeviceType
            Get
                Return m_type
            End Get
            Set(value As DeviceType)
                m_type = value
            End Set
        End Property
#End Region

        Public Sub SetIcon(ByVal value As String, ByVal health As Status, Optional ByVal displaylife As Boolean = False)
            If Not displaylife Then
                If IsNumeric(value) Then
                    If value > 99 Then value = 99
                    If value < 0 Then value = 0
                End If
            End If

            Select Case health
                Case Status.Failed
                    If displaylife Then
                        If IsNumeric(value) Then
                            ti.Icon = Main.ssd_bad(value)
                        Else
                            ti.Icon = Main.ssd_bad(101)
                        End If
                    Else
                        If My.Settings.TempFahrenheit = True Then
                            If IsNumeric(value) Then
                                ti.Icon = Main.fahrenheit_bad(value)
                            Else
                                ti.Icon = Main.fahrenheit_bad(100)
                            End If
                        Else
                            If IsNumeric(value) Then
                                ti.Icon = Main.celsius_bad(value)
                            Else
                                ti.Icon = Main.celsius_bad(100)
                            End If
                        End If
                    End If
                Case Status.Passed
                    If displaylife Then
                        If IsNumeric(value) Then
                            ti.Icon = Main.ssd_good(value)
                        Else
                            ti.Icon = Main.ssd_good(101)
                        End If
                    Else
                        If My.Settings.TempFahrenheit = True Then
                            If IsNumeric(value) Then
                                ti.Icon = Main.fahrenheit_good(value)
                            Else
                                ti.Icon = Main.fahrenheit_good(100)
                            End If
                        Else
                            If IsNumeric(value) Then
                                ti.Icon = Main.celsius_good(value)
                            Else
                                ti.Icon = Main.celsius_good(100)
                            End If
                        End If
                    End If
                Case Status.Unkonwn
                    ti.Icon = Main.unknown
            End Select
        End Sub

    End Class

#End Region

    Public Class AttributesCollection
        Inherits List(Of Attribute)
    End Class

    Public Class CapabilitiesCollection
        Inherits List(Of DevCapabilities)
    End Class

    Public Class ErrorCollection
        Inherits List(Of SmartError)
    End Class

    Public Class SelfTestCollection
        Inherits List(Of SelfTest)
    End Class

    Public Class SelectivesCollection
        Inherits List(Of Selectives)
    End Class

    Public Class DeviceLog
        Inherits List(Of Log)
    End Class

    Private m_output() As String
    Private m_origcontent As String
    Private m_modelfamily, m_devicemodel, m_serialnumber As String
    Private m_firmware, m_size As String
    Private m_ataversion, m_atastandard
    Private m_wwn, m_sectorsize As String
    Private m_lastcheck As String
    Private m_indatabase As Boolean
    Private m_healthpassed As Status = Status.Unkonwn
    Private m_smartavailable, m_smartenabled As Support
    Private m_offlinedatacollection As Support
    Private m_attributes As New AttributesCollection
    Private m_capabilites As New CapabilitiesCollection
    Private m_errors As New ErrorCollection
    Private m_totalerrors As String
    Private m_selftests As New SelfTestCollection
    Private m_selectives As New SelectivesCollection
    Private m_lasttest As LastTest
    Private m_temperature As String = "N/A"
    Private m_location As String
    Private m_options As String=""
    Private m_type As DeviceType
    Private m_oldvitals, m_newvitals, m_vitals As Vitals
    Private m_vitalslog As New DeviceLog
    Private m_warnings As Warnings
    Private smartctl As New Console
    Private m_pollingtimes As PollingTimes
    Private m_revisions As Revisions
    Private m_displaylife, m_isshared As Boolean
    Private m_os, m_smartctl As String
    Private m_testisrunning As Boolean = False
    Private m_testtiming As TestTiming
    Private m_vdinfo As VirtualDeviceInfo
    Private m_isunavailable As Boolean = False
    Private m_selftestupported, m_selectivesupported As Boolean
    Private m_errorloggingsupport As Boolean
    Private m_isvaliddevice As Boolean
    Private m_id5threshold As String
    Private m_reliability As Ratings
    Private m_aam, m_recommendedaam, m_apm, m_standby As Short
    Private m_aamstatus, m_apmstatus, m_cache, m_lookahead, m_cachereorder As Feature
    Private m_isoptical As Boolean = False
    Private m_raid As Boolean = False
    Private m_raidvolume As String
    Private m_sataversion As String
    Private m_rotation As String
    Private m_badsectors As String = "N/A"
    Private m_ssd As Boolean = False
    Private m_remaininglife As String = "N/A"
    Private m_devtrayicon As New TrayIcon
    Private m_alreadydysplayedwarnings As Boolean = True
    Private m_dontsavelog As Boolean = False
    Private m_devicefilename As String = ""
    Private m_missingadminrights As Boolean = False
    Private m_doubledeck As Boolean = False
    Private m_worktime As String = "N/A"
    Private m_worktimehuman As String = "N/A"
    Private m_additional As Boolean = False
    Private m_description As String = ""

    Public Sub New(ByVal description As String, ByVal command As String, Optional ByVal loadsettings As Boolean = True)
        m_output = smartctl.SendCmd("-i " & command)
        m_type = DeviceType.ATA
        m_location = command
        m_additional = True
        m_description = description

        If Not IsNothing(m_output) Then
            Dim checkifoptical As String = GetInfo("SMART support is")
            If checkifoptical.Contains("[this device: CD/DVD]") Then
                m_isoptical = True
            Else
                m_isoptical = False
            End If
        End If

        If Not m_isoptical Then
            If Not IsNothing(m_output) Then
                m_devicemodel = GetInfo("Device Model")
                m_serialnumber = GetInfo("Serial Number")
                m_devicefilename = GenerateDeviceFileName()
                If loadsettings Then
                    LoadDeviceSettings()
                    LoadDeviceLog()
                Else
                    m_dontsavelog = True
                End If
                Update()
            End If
        End If

        If Not IsNothing(m_devtrayicon) Then
            With m_devtrayicon
                .Model = m_devicemodel
                .Type = m_type
                .Location = m_description
            End With
        End If
    End Sub

    Public Sub New(ByVal location As String, ByVal type As DeviceType, Optional ByVal loadsettings As Boolean = True)

        If location.Contains("/dev/") Then
            'a real device: smartctl is executed for recover infos about it
            If type = DeviceType.ATA Or type = DeviceType.USB Then
                m_output = smartctl.SendCmd("-i " & location)
            ElseIf type = DeviceType.SCSI Then
                'SCSI output is very small, so all info are gathered
                m_output = smartctl.SendCmd("-a -g all " & location)
            End If
        Else
            'a virtual device (a file containing a smartctl report)
            If IO.File.Exists(location) Then
                m_output = IO.File.ReadAllLines(location)
                m_origcontent = IO.File.ReadAllText(location)
            Else
                m_isunavailable = True
            End If

            m_devtrayicon = Nothing
        End If

        m_type = type
        m_location = location

        If type = DeviceType.ATA Then
            Dim checkifoptical As String = GetInfo("SMART support is")
            If checkifoptical.Contains("[this device: CD/DVD]") Then
                m_isoptical = True
            Else
                m_isoptical = False
            End If
        End If

        If type = DeviceType.SCSI Or type = DeviceType.Virtual Then
            Dim isdisk As String = GetInfo("Device type")
            If isdisk = "disk" Then
                m_isdisk = True
            Else
                m_isdisk = False
            End If
        End If

        If Not m_isoptical Then
            If Not IsNothing(m_output) Then
                If m_isdisk Then
                    m_devicemodel = GetInfo("Product")
                    m_serialnumber = GetInfo("Serial number")
                Else
                    m_devicemodel = GetInfo("Device Model")
                    m_serialnumber = GetInfo("Serial Number")
                End If

                m_devicefilename = GenerateDeviceFileName()

                m_doubledeck = CheckDoubleDeck()

                If loadsettings Then
                    LoadDeviceSettings()
                    LoadDeviceLog()
                Else
                    m_dontsavelog = True
                End If

                Update()
            End If
        End If

        If Not IsNothing(m_devtrayicon) Then
            With m_devtrayicon
                .Model = m_devicemodel
                .Type = m_type
                .Location = m_location
            End With
        End If
    End Sub

    Private Function GenerateDeviceFileName() As String
        'this routine create the file name string and skip all non valid characters
        Dim fns As String = m_devicemodel & "_" & m_serialnumber

        Dim fn() As Char = fns.ToCharArray
        Dim vfn As String = ""

        For Each c As Char In fn
            Select Case c.ToString
                'validate only the following characters:
                Case "-", "a" To "z", "A" To "Z", "0" To "9", "_", " "
                    vfn += c
                Case Else
                    'discard all the others characters.
            End Select
        Next

        Return vfn
    End Function

    Private Function CheckDoubleDeck() As Boolean
        For i As Short = 0 To m_output.Length - 2
            If m_output(i).Contains("Two devices connected, try '-d usbjmicron,[01]") Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function CheckIfValid() As Boolean
        If m_devicemodel.Contains("My Book") Then
            Return False
        End If


        For i As Short = 0 To m_output.Length - 2
            If m_output(i).Contains("START OF INFORMATION SECTION") Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function GetInfo(ByVal info As String) As String
        Dim value As String = "N/A"
        If IsNothing(m_output) Then Return value
        For i As Integer = 0 To m_output.Length - 2
            If m_output(i).Contains(info) Then
                Dim result() As String = m_output(i).Split(":", 2, StringSplitOptions.RemoveEmptyEntries)
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
        For i As Integer = start To m_output.Length - 2
            If m_output(i).Contains(text) Then
                value = i
                Exit For
            End If
        Next
        Return value
    End Function

    Private Function ConvertToFlags(ByVal value As String) As AttributeFlags
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
            Return val
        End If
    End Function

    Private Function GetRawValue(ByVal attribute() As String) As String
        If attribute.Length = 10 Then
            Return attribute(9)
        Else
            Return attribute(7)
        End If
    End Function

    Private Function GetThresholdValue(ByVal attribute() As String) As String
        Dim value As String = attribute(5)

        If IsNumeric(value) Then
            Return value
        Else
            Dim newvalue As String = Nothing

            Dim re5 As New Regex("^(ExcelStor|Hitachi|HD|HU|HT|HE|HD|IBM|IC|DT).*", RegexOptions.IgnoreCase)
            If re5.Match(m_devicemodel).Success Or re5.Match(m_modelfamily).Success Then newvalue = "5"

            Dim re10 As New Regex("^Samsung.*", RegexOptions.IgnoreCase)
            If re10.Match(m_devicemodel).Success Or re10.Match(m_modelfamily).Success Then newvalue = "10"

            Dim re20 As New Regex("^Quantum.*", RegexOptions.IgnoreCase)
            If re20.Match(m_devicemodel).Success Or re20.Match(m_modelfamily).Success Then newvalue = "20"

            Dim re24 As New Regex("^Fujitsu.*", RegexOptions.IgnoreCase)
            If re24.Match(m_devicemodel).Success Or re24.Match(m_modelfamily).Success Then newvalue = "24"

            Dim re36 As New Regex("^(Seagate|ST(1|2|3|5|7|6|9)).*", RegexOptions.IgnoreCase)
            If re36.Match(m_devicemodel).Success Or re36.Match(m_modelfamily).Success Then newvalue = "36"

            Dim re50 As New Regex("^(Toshiba|TOS).*", RegexOptions.IgnoreCase)
            If re50.Match(m_devicemodel).Success Or re50.Match(m_modelfamily).Success Then newvalue = "50"

            Dim re63 As New Regex("^(Maxtor|STM).*", RegexOptions.IgnoreCase)
            If re63.Match(m_devicemodel).Success Or re63.Match(m_modelfamily).Success Then newvalue = "63"

            Dim re140 As New Regex("^WDC.*", RegexOptions.IgnoreCase)
            If re140.Match(m_devicemodel).Success Or re140.Match(m_modelfamily).Success Then newvalue = "140"

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

    Private Sub GetDeviceInfo()
        If m_output.Length > 0 Then
            m_modelfamily = GetInfo("Model Family")
            m_devicemodel = GetInfo("Device Model")
            m_serialnumber = GetInfo("Serial Number")
            m_firmware = GetInfo("Firmware Version")
            Dim size As String = GetInfo("User Capacity")
            Dim s() As String = size.Split("bytes")
            m_size = ToNumber(s(0))
            If m_size = "" Then m_size = "N/A"
            Dim db As String = GetInfo("Device is")
            If db.Contains("Not") Then m_indatabase = False Else m_indatabase = True
            m_ataversion = GetInfo("ATA Version is")
            m_atastandard = GetInfo("ATA Standard is")
            m_sataversion = GetInfo("SATA Version is")
            m_rotation = GetInfo("Rotation Rate")
            If m_rotation.Contains("Solid State Device") Then m_ssd = True
            Dim support As String = GetInfo("SMART support is")
            If support.Contains("Available") Then
                m_smartavailable = hdd_guardian.Support.Available
            ElseIf support.Contains("Ambiguous") Then
                m_smartavailable = hdd_guardian.Support.Ambiguous
            Else
                m_smartavailable = hdd_guardian.Support.Unavailable
            End If
            Dim enabled As String = GetInfo("SMART support is: Enabled")
            If enabled.Contains("Enabled") Then
                m_smartenabled = hdd_guardian.Support.Enabled
            Else
                m_smartenabled = hdd_guardian.Support.Disabled
            End If

            m_wwn = GetInfo("LU WWN Device Id")
            m_sectorsize = GetInfo("Sector Size")

            'get features included in smartctl 5.43
            Dim aamfeature As String = GetInfo("AAM feature is")
            If aamfeature <> "N/A" Then
                If aamfeature.Contains("Disabled") Then
                    m_aamstatus = Feature.Disable
                ElseIf aamfeature.Contains("Unavailable") Then
                    m_aamstatus = Feature.Unavailable
                End If
            Else
                Dim aam As String = GetInfo("AAM level is")
                If aam <> "N/A" Then
                    Dim arr_aam() As String = aam.Split(":")
                    Dim arr_value() As String = arr_aam(0).Split(" ")
                    m_aam = arr_value(0)
                    m_recommendedaam = arr_aam(1)
                    m_aamstatus = Feature.Enable
                Else
                    m_aamstatus = Feature.Unknown
                End If
            End If

            Dim apmfeature As String = GetInfo("APM feature is")
            If apmfeature <> "N/A" Then
                If apmfeature.Contains("Disabled") Then
                    m_apmstatus = Feature.Disable
                ElseIf apmfeature.Contains("Unavailable") Then
                    m_apmstatus = Feature.Unavailable
                End If
            Else
                Dim apm As String = GetInfo("APM level is")
                If apm <> "N/A" Then
                    Dim arr_apm() As String = apm.Split(" ")
                    m_apm = arr_apm(0)
                    m_apmstatus = Feature.Enable
                Else
                    m_apmstatus = Feature.Unknown
                End If
            End If

            Dim lookahead As String = GetInfo("Rd look-ahead is")
            If lookahead <> "N/A" Then
                If lookahead.Contains("Disabled") Then
                    m_lookahead = Feature.Disable
                ElseIf lookahead.Contains("Unavailable") Then
                    m_lookahead = Feature.Unavailable
                Else
                    m_lookahead = Feature.Enable
                End If
            Else
                m_lookahead = Feature.Unknown
            End If

            Dim cache As String = GetInfo("Write cache is")
            If cache <> "N/A" Then
                If cache.Contains("Disabled") Then
                    m_cache = Feature.Disable
                ElseIf cache.Contains("Unavailable") Then
                    m_cache = Feature.Unavailable
                Else
                    m_cache = Feature.Enable
                End If
            Else
                m_cache = Feature.Unknown
            End If

            'get new feature included in smartctl 6.2
            Dim reorder As String = GetInfo("Wt Cache Reorder")
            If reorder <> "N/A" Then
                If reorder.Contains("Disabled") Then
                    m_cachereorder = Feature.Disable
                ElseIf reorder.Contains("Unavailable") Then
                    m_cachereorder = Feature.Unavailable
                Else
                    m_cachereorder = Feature.Enable
                End If
            Else
                m_cachereorder = Feature.Unknown
            End If

            'get the eventual warning message
            Dim w As Integer = GetIndexOf("==> WARNING:")
            Dim txt As String = "", lnk1 As String = "", lnk2 As String = "", lnk3 As String = ""
            Dim lnkcount As Short = 0
            If w > 0 Then
                For i As Integer = w To m_output.Length - 1
                    If m_output(i).Trim.Length = 0 Then Exit For

                    Dim t As String = m_output(i)

                    If Not t.Contains("http") Then
                        If t.Contains("==>") Then
                            txt = GetInfo("==> WARNING")
                        Else
                            txt = txt & " " & m_output(i)
                        End If
                    Else
                        lnkcount += 1
                        Select Case lnkcount
                            Case 1

                                If m_output(i).StartsWith("http") Then
                                    lnk1 = m_output(i)
                                Else
                                    Dim alert() As String = m_output(i).Split(" ")
                                    For a As Integer = 0 To alert.Length - 1
                                        If alert(a).Contains("http") Then
                                            lnk1 = alert(a)
                                            Exit For
                                        Else
                                            txt = txt & " " & alert(a)
                                        End If
                                    Next
                                End If
                            Case 2
                                lnk2 = m_output(i)
                            Case 3
                                lnk3 = m_output(i)
                        End Select
                    End If
                Next
            End If
            With m_warnings
                .Warning = txt
                .Link1 = lnk1.Replace(vbCr, "").Replace(vbLf, "")
                .Link2 = lnk2.Replace(vbCr, "").Replace(vbLf, "")
                .Link3 = lnk3.Replace(vbCr, "").Replace(vbLf, "")
            End With
        End If
    End Sub

    Private Sub GetHealth()
        Dim i As Integer = GetIndexOf("SMART overall-health")
        If i > 0 Then
            Dim h As String = m_output(i)
            If h.Contains("PASSED") Then
                m_healthpassed = Status.Passed
            ElseIf h.Contains("FAILED") Then
                m_healthpassed = Status.Failed
            Else
                m_healthpassed = Status.Unkonwn
            End If
        Else
            m_healthpassed = Status.Unkonwn
        End If

    End Sub

    Private Sub GetCapabilities()
        Dim s As Integer = GetIndexOf("General SMART Values") + 1
        Dim e As Integer = GetIndexOf("SMART Attributes Data Structure") - 2

        m_capabilites.Clear()

        'get offline data collection status
        Dim status As String = GetInfo("Auto Offline Data Collection")
        If status.Contains("Enabled") Then
            m_offlinedatacollection = Support.Enabled
        Else
            m_offlinedatacollection = Support.Disabled
        End If

        For i As Integer = s To e
            Dim curr As Short = GetIndexOf("(", i)
            Dim nxt As Short = GetIndexOf("(", i + 1) - 1
            If nxt = 0 Or nxt > e Or nxt < curr Then nxt = e

            Dim cap As New DevCapabilities
            For ci As Short = curr To nxt
                Dim currow() As String = m_output(ci). _
                Replace("(", "|").Replace(")", "|").Replace(ControlChars.Tab, ""). _
                Split("|", 3, StringSplitOptions.RemoveEmptyEntries)

                With cap
                    If currow.Length = 3 Then
                        Dim firstpart As String = ""
                        If ci > s And Not m_output(ci - 1).Contains(".") Then firstpart = m_output(ci - 1).Replace(vbLf, "") & " "
                        Dim n As String = firstpart & currow(0).Trim
                        .Name = n.Replace("  ", " ").Replace(vbCrLf, "")
                        .Value = currow(1).Trim
                        .Meaning = currow(2).Trim
                    Else
                        If ci <> nxt Then
                            .Meaning = .Meaning & " " & currow(0).Trim
                        Else
                            If currow(0).Contains(".") Then .Meaning = .Meaning & " " & currow(0).Trim
                        End If

                    End If
                End With
            Next
            cap.Meaning = cap.Meaning.Replace("  ", " ").Replace(". ", ".").Replace(".", "." & vbCrLf)
            i = nxt
            m_capabilites.Add(cap)
        Next
    End Sub

    Private Sub Reliability()
        'This sub calculate a 5 star rating reliability of disk, based upon ID 5, 197, 198 and the total count of errors.
        'For SSD devices report a 5 star rating based upon their health percentages
        '*** Note: run after GetAttributes and GetErrors routines! ***

        Dim toterrors As String = m_totalerrors
        Dim id5 As String = m_newvitals.ReallSect
        Dim id197 As String = m_newvitals.CurPending
        Dim id198 As String = m_newvitals.OfflineUnc
        Dim r_5 As Double = 0
        Dim r_197 As Double = 0
        Dim r_198 As Double = 0
        Dim divider As Short = 180
        'first, for each parameter are calculated the percentage value based upon
        'the threshold, then are calculated a rating from 0 to 5

        Dim r_e As Double = Math.Round(toterrors / My.Settings.TuneErrors * 100)
        If System.Double.IsNaN(r_e) Then r_e = 0
        If r_e > 100 Then r_e = 100
        m_reliability.Errors = Math.Round(5 - r_e / 20)
        If m_reliability.Errors < 1 Then m_reliability.Errors = 1

        If Not IsNothing(id5) Then
            r_5 = Math.Round(id5 / m_id5threshold * 100)
            If System.Double.IsNaN(r_5) Then r_5 = 0
            If r_5 > 100 Then r_5 = 100
            m_reliability.ReallocationCount = Math.Round(5 - r_5 / 20)
            If m_reliability.ReallocationCount < 1 Then m_reliability.ReallocationCount = 1
        Else
            r_5 = 0
            m_reliability.ReallocationCount = Nothing
            divider -= 28
        End If

        If Not IsNothing(id197) Then
            r_197 = Math.Round(id197 / My.Settings.Tune197 * 100)
            If System.Double.IsNaN(r_197) Then r_197 = 0
            If r_197 > 100 Then r_197 = 100
            m_reliability.CurrentPending = Math.Round(5 - r_197 / 20)
            If m_reliability.CurrentPending < 1 Then m_reliability.CurrentPending = 1
        Else
            r_197 = 0
            m_reliability.CurrentPending = Nothing
            divider -= 32
        End If

        If Not IsNothing(id198) Then
            r_198 = Math.Round(id198 / My.Settings.Tune198 * 100)
            If System.Double.IsNaN(r_198) Then r_198 = 0
            If r_198 > 100 Then r_198 = 100
            m_reliability.OfflineUncorrectable = Math.Round(5 - r_198 / 20)
            If m_reliability.OfflineUncorrectable < 1 Then m_reliability.OfflineUncorrectable = 1
        Else
            r_198 = 0
            m_reliability.OfflineUncorrectable = Nothing
            divider -= 42
        End If

        'the overall reliability are calculated adding a "gravity index" for each parameter
        'and then calculating a rating from 1 to 5
        m_reliability.Overall = Math.Round(5 - (r_e * 3.9 + r_5 * 1.4 + r_197 * 1.6 + r_198 * 2.1) / divider)
        If m_reliability.Overall < 1 Then m_reliability.Overall = 1

        'check if SSD vital parameters have stored a value and then calculate the rating
        'basic formula are: R=round(V/20)
        'values starts from 100 and goes to 0 (1 for Intel)
        With m_newvitals
            If m_ssd Then m_reliability.Overall = 0

            If Not IsNothing(.Micron) Then
                'here the formula is: R=round((100-V)/20)
                'because the value start from 0 and goes to 100
                m_reliability.Overall = Math.Round(((100 - .Micron) / 20))
                m_reliability.Micron = m_reliability.Overall
            End If
            If Not IsNothing(.Intel) Then
                m_reliability.Overall = Math.Round(.Intel / 20)
                m_reliability.Intel = m_reliability.Overall
            End If
            If Not IsNothing(.Indilinx) Then
                m_reliability.Overall = Math.Round(.Indilinx / 20)
                m_reliability.Indilinx = m_reliability.Overall
            End If
            If Not IsNothing(.Samsung) Then
                m_reliability.Overall = Math.Round(.Samsung / 20)
                m_reliability.Samsung = m_reliability.Overall
            End If
            If Not IsNothing(.SandForce) Then
                m_reliability.Overall = Math.Round(.SandForce / 20)
                m_reliability.SandForce = m_reliability.Overall
            End If
        End With
        If m_reliability.Overall > 5 Then m_reliability.Overall = 5
    End Sub

    Private Sub AtaWorkTime(ByVal wt As String)
        Dim t As Integer
        If Not IsNumeric(wt) Then
            Dim tt() As String = wt.Split("h")
            t = Val(tt(0))
        Else
            t = Val(wt)
        End If

        'calculate years of activity
        Dim y As Integer = t \ (365 * 24)
        'calculate months of activity
        Dim m As Integer = (t - y * 365 * 24) \ (30 * 24)
        'calculate days of activity
        Dim d As Integer = (t - y * 365 * 24 - m * 30 * 24) \ 24
        'calculate hours of activity
        Dim h As Integer = t - y * 365 * 24 - m * 30 * 24 - d * 24

        'now, build time string
        Dim ts As String = ""

        If t = 1 Then
            m_worktime = t & " " & Main._h
        Else
            m_worktime = t & " " & Main._hh
        End If

        If y > 0 Then
            If y = 1 Then
                ts += y & " " & Main._y
            Else
                ts += y & " " & Main._yy
            End If
        End If

        If m > 0 Then
            If ts.Length > 0 And y > 0 Then ts += ", "
            If m = 1 Then
                ts += m & " " & Main._m
            Else
                ts += m & " " & Main._mm
            End If
        End If

        If d > 0 Then
            If ts.Length > 0 And (m > 0 Or y > 0) Then ts += ", "
            If d = 1 Then
                ts += d & " " & Main._d
            Else
                ts += d & " " & Main._dd
            End If
        End If

        If h > 0 Then
            If ts.Length > 0 And (m > 0 Or y > 0 Or d > 0) Then ts += ", "
            If h = 1 Then
                ts += h & " " & Main._h
            Else
                ts += h & " " & Main._hh
            End If
        End If

        m_worktimehuman = ts
    End Sub

    Private Sub GetAttributes()
        'get all attributes

        'smartctl attribute table samples:
        'version 5.37 ************************************************************************************************
        '  1 Raw_Read_Error_Rate     POSR--   200   200   051    Pre-fail  Always       -       0
        'version from 5.38 to 5.40 ***********************************************************************************
        '  1 Raw_Read_Error_Rate     0x000e   100   253   006    Old_age   Always       -       0
        'version 5.39, with inconsistent identities: the following two lines before the attributes will be jumped ****
        '2 Throughput_Performance  0x2600   000   000   000    Old_age   Offline  FAILING_NOW 281474959933440
        '2 Throughput_Performance  <== Data Page      |  WARNING: PREVIOUS ATTRIBUTE HAS TWO
        '0 Unknown_Attribute       <== Threshold Page |  INCONSISTENT IDENTITIES IN THE DATA
        'version 5.41, with option "-f brief" ************************************************************************
        '  1 Raw_Read_Error_Rate     POSR--   200   200   051    -    0
        Dim i As Integer = GetIndexOf("ID#")
        m_attributes.Clear()

        If Not IsNothing(m_newvitals) Then m_oldvitals = m_newvitals

        If i > 0 Then
            For ri As Integer = i + 1 To m_output.Length - 1
                Dim attr() As String = m_output(ri).Trim.Split(" ", 10, StringSplitOptions.RemoveEmptyEntries)
                If attr.Length = 0 Then Exit For
                If Not IsNumeric(attr(0)) Then Exit For

                If Not m_output(ri).Contains("<==") Then

                    'temperature is get here...
                    If m_output(ri).Contains("194 Temperature_Celsius") Then
                        Dim t() As String = GetRawValue(attr).Replace(vbCr, "").Replace(vbLf, "").Split("(")
                        Dim temp As String = Math.Round(Decimal.Parse(t(0).Trim, New Globalization.CultureInfo("en-US"))).ToString
                        m_temperature = temp
                        m_newvitals.Temperature = temp

                        'this block is for correct a wrong temperature report in some OCZ Agility
                        'devices based upon SandForce interface: the device is not equipped with
                        'a thermal sensor but the raw value of temperature reports a fixed fake
                        'value of 128°C. Theorically a firmware update to version 2.15 solve this
                        'situation, changing the fixed value to 30°C, but sometimes this issue
                        'remains unsolved and HDD Guardian shows many alarms for nothing.
                        If m_devicemodel.StartsWith("OCZ") And m_temperature.StartsWith("128") Then
                            m_temperature = "30"
                            m_newvitals.Temperature = "30"
                        End If
                    End If

                    'if 194 attribute faild, is get the airflow temperature (attribute 190)
                    If Not IsNumeric(m_temperature) Then
                        If m_output(ri).Contains("190 Airflow_Temperature_Cel") Then
                            Dim t() As String = GetRawValue(attr).Replace(vbCr, "").Replace(vbLf, "").Split("(")
                            Dim temp As String = Math.Round(Decimal.Parse(t(0).Trim, New Globalization.CultureInfo("en-US"))).ToString
                            m_temperature = temp
                            m_newvitals.Temperature = temp
                        End If
                    End If

                    'vital parameters are get here, with only exception of temperature, see 3 row top if this
                    If m_output(ri).Contains("5 Reallocated_Sector_Ct") Then
                        m_id5threshold = GetThresholdValue(attr)

                        If m_output(ri).Contains("(") Then
                            Dim str() As String = GetRawValue(attr).Split("(")
                            m_newvitals.ReallSect = str(0).Trim
                            m_badsectors = str(0).Trim
                        Else
                            m_newvitals.ReallSect = GetRawValue(attr)
                            m_badsectors = GetRawValue(attr)
                        End If
                    End If

                    'get the total working time of device
                    If m_output(ri).Contains("9 Power_On_Hours_and_Msec") Or m_output(ri).Contains("9 Power_On_Hours") Then AtaWorkTime(GetRawValue(attr))

                    If m_output(ri).Contains("10 Spin_Retry_Count") Then m_newvitals.SpinRetry = GetRawValue(attr)
                    If m_output(ri).Contains("196 Reallocated_Event_Count") Then m_newvitals.ReallEvent = GetRawValue(attr)
                    If m_output(ri).Contains("197 Current_Pending_Sector") Then m_newvitals.CurPending = GetRawValue(attr)
                    If m_output(ri).Contains("197 Total_Pending_Sectors") Then m_newvitals.CurPending = GetRawValue(attr) 'appears in some Samsung devices
                    If m_output(ri).Contains("198 Offline_Uncorrectable") Then m_newvitals.OfflineUnc = GetRawValue(attr)
                    If m_output(ri).Contains("201 Soft_Read_Error_Rate") Then m_newvitals.SoftRead = GetRawValue(attr)
                    If m_output(ri).Contains("220 Disk_Shift") Then m_newvitals.DiskShift = GetRawValue(attr)

                    'and now, from version 0.3, we monitor also the health percentages of SSD!
                    'note: I have some reserves for Micron and Samsung values, because I don't have
                    'found a very helpful output...
                    If m_output(ri).Contains("202 Perc_Rated_Life_Used") Then
                        m_newvitals.Micron = GetRawValue(attr)
                        m_remaininglife = 100 - m_newvitals.Micron
                        m_ssd = True
                    End If
                    If m_output(ri).Contains("209 Remaining_Lifetime_Perc") Then
                        Dim v As String = GetNormalizedValue(attr)
                        If IsNumeric(v) Then
                            m_newvitals.Indilinx = GetNormalizedValue(attr)
                        Else
                            m_newvitals.Indilinx = GetRawValue(attr)
                        End If
                        m_remaininglife = m_newvitals.Indilinx
                        m_ssd = True
                    End If
                    If m_output(ri).Contains("233 Media_Wearout_Indicator") Then
                        m_newvitals.Intel = GetNormalizedValue(attr)
                        m_remaininglife = m_newvitals.Intel
                        m_ssd = True
                    End If
                    If m_output(ri).Contains("177 Wear_Leveling_Count") And m_output(ri).Contains("Always") Then
                        'some times Samsung's SSD report bad values into the attributes table.
                        'This is a row with good values:
                        '177 Wear_Leveling_Count    0x0013   099   099   019    Pre-fail  Always    -       8
                        'instaed, this one, report a value of 0 for each column:
                        '177 Wear_Leveling_Count    0x0000   000   000   000    Old_age   Offline   -       0
                        'so, avoiding to catch che results when the row can't contains the word "Always", you get
                        'only the good data (or, at least, is what I hope).
                        m_newvitals.Samsung = GetNormalizedValue(attr)
                        m_remaininglife = m_newvitals.Samsung
                        m_ssd = True
                    End If
                    If m_output(ri).Contains("231 SSD_Life_Left") Then
                        m_newvitals.SandForce = GetNormalizedValue(attr)
                        m_remaininglife = m_newvitals.SandForce
                        m_ssd = True
                    End If

                    Dim attrib As New Attribute
                    With attrib
                        .ID = attr(0)
                        .Name = attr(1).Replace("_", " ")
                        .Flag = ConvertToFlags(attr(2))
                        .Value = attr(3)
                        .Worst = attr(4)
                        .Threshold = attr(5)
                        If attr.Length = 10 Then
                            'extended output, like examples 5.37, 5.38
                            If attr(6).Contains("Pre-fail") Then _
                                .Type = AttributeType.PreFail Else _
                                .Type = AttributeType.OldAge
                            If attr(7).Contains("Always") Then _
                                .Updated = AttributeUpdate.Always Else _
                                .Updated = AttributeUpdate.Offline
                            .WhenFailed = attr(8).Replace("_", " ")
                            .RawValue = attr(9)
                        Else
                            'brief output, like example 5.41
                            If .Flag.HasFlag(AttributeFlags.SelfPreserving) Then _
                                .Type = AttributeType.PreFail Else _
                                .Type = AttributeType.OldAge
                            If .Flag.HasFlag(AttributeFlags.UpdatedOnline) Then _
                                .Updated = AttributeUpdate.Always Else _
                                .Updated = AttributeUpdate.Offline
                            .WhenFailed = attr(6).Replace("_", " ")
                            .RawValue = attr(7)
                        End If
                    End With
                    m_attributes.Add(attrib)
                End If
            Next
        End If
    End Sub

    Private Sub GetErrors()
        'error structure example from 5.22 to now
        'Error 109 occurred at disk power-on lifetime: 585 hours (24 days + 9 hours)
        'When the command that caused the error occurred, the device was active or idle.
        '
        '  After command completion occurred, registers were:
        '  ER ST SC SN CL CH DH
        '  -- -- -- -- -- -- --
        '  40 51 40 e8 1a 1d e5  Error: WP at LBA = 0x051d1ae8 = 85793512
        '
        '  Commands leading to the command that caused the error were:
        '  CR FR SC SN CL CH DH DC   Powered_Up_Time  Command/Feature_Name
        '  -- -- -- -- -- -- -- --  ----------------  --------------------
        '  c5 00 08 df 00 60 00 58      01:01:29.900  WRITE MULTIPLE
        '  c4 00 40 e7 1a 1d 05 58      01:01:27.270  READ MULTIPLE
        '  c5 00 08 2f 00 5e 00 58      01:01:27.030  WRITE MULTIPLE
        '  c5 00 08 2f 46 5e 00 58      01:01:27.025  WRITE MULTIPLE
        '  c5 00 48 e7 45 5e 00 58      01:01:27.015  WRITE MULTIPLE
        '
        'note that not always are displayed 5 errors, also when you have a great number of it!

        Dim tot As String = GetInfo("ATA Error Count")

        If tot = "N/A" Then
            m_totalerrors = 0
            m_newvitals.Errors = 0
            Exit Sub
        Else
            Dim last As Integer = Val(tot)
            m_totalerrors = last
            m_newvitals.Errors = last
            Dim first As Integer
            If last < 6 Then first = 1 Else first = last - 4


            m_errors.Clear()

            For i As Short = last To last - 4 Step -1
                Dim r As Short = GetIndexOf("Error " & i)
                If r > 0 Then
                    Dim e As New SmartError
                    With e
                        'set error #
                        .Number = i
                        'set error lifetime
                        Dim lt() As String = m_output(r).Split(":")
                        .Lifetime = lt(1).Trim
                        'set device status
                        Dim status() As String = m_output(r + 1).Split(",")
                        .Status = status(1).Replace("the device was", "") _
                            .Replace(".", "").Trim
                        'set registers
                        Dim rr As Integer = GetIndexOf("--", r) + 1
                        Dim regval() As String = m_output(rr).Trim.Split(" ", 8, StringSplitOptions.RemoveEmptyEntries)
                        With .Registers
                            .ER = regval(0)
                            .ST = regval(1)
                            .SC = regval(2)
                            .SN = regval(3)
                            .CL = regval(4)
                            .CH = regval(5)
                            .DH = regval(6)
                            If regval.Length = 8 Then
                                .ErrorText = regval(7)
                            Else
                                .ErrorText = ""
                            End If
                        End With
                        'set commands
                        .Commands = New SmartError.CmdCollection
                        Dim cr As Integer = GetIndexOf("--", rr) + 1
                        For ci As Integer = cr To cr + 4
                            Dim cmd() As String = m_output(ci).Trim.Split(" ", 10, StringSplitOptions.RemoveEmptyEntries)
                            If cmd.Length > 0 Then
                                Dim l As Integer = ci - cr

                                Dim c As New Command

                                With c
                                    .CR = cmd(0)
                                    .FR = cmd(1)
                                    .SC = cmd(2)
                                    .SN = cmd(3)
                                    .CL = cmd(4)
                                    .CH = cmd(5)
                                    .DH = cmd(6)
                                    .DC = cmd(7)
                                    .PowerUp = cmd(8)
                                    .Feature = cmd(9)
                                End With
                                .Commands.Add(c)
                            Else
                                Exit For
                            End If
                        Next
                    End With
                    m_errors.Add(e)
                End If
            Next
        End If

        'm_newvitals.Errors = m_totalerrors
    End Sub

    Private Sub GetSelfTest()
        'self-test log structure sample from 5.22 to now
        '===============================================================================================
        'a log with errors (errors are from variuos devices):
        'SMART Self-test log structure revision number 1
        'Num  Test_Description    Status                  Remaining  LifeTime(hours)  LBA_of_first_error
        '# 1  Extended offline    Completed: read failure       80%     18841         0x001f807f 
        '# 2  Extended offline    Completed: servo/seek failure 90%      1816         -
        '# 8  Short offline       Completed without error       00%     18051         -
        '===============================================================================================
        'a log without errors:
        'SMART Self-test log structure revision number 1
        'No self-tests have been logged.  [To run self-tests, use: smartctl -t]
        '===============================================================================================
        'generally, if you get the structure revision line, the device support self-tests.

        Dim i As Integer = GetIndexOf("SMART Self-test log")
        If m_output(i + 1).Contains("No self-tests have been logged") Or i = 0 Then
            With m_lasttest
                .IsPassed = False
                .Status = Status.Unkonwn
                .Remaining = ""
            End With
            Exit Sub
        End If

        m_selftests.Clear()

        For r As Integer = i + 2 To m_output.Length - 1
            Dim row As String = m_output(r).Replace(vbCr, "").Replace(vbLf, "")
            If Not row.StartsWith("#") Then Exit For
            Dim st() As String = m_output(r).Replace("#", "").Trim.Replace("  ", "_") _
                               .Split("_", 6, StringSplitOptions.RemoveEmptyEntries)

            'here is getted the last test values
            If st(0) = 1 Then
                With m_lasttest
                    If st(2).Contains("without") Then .IsPassed = Status.Passed Else .IsPassed = Status.Failed
                    If st(2).Contains("%") Then
                        .Status = st(2).Substring(0, st(2).Length - 4).Trim
                        .Remaining = st(2).Substring(st.Length - 3, 3).Trim
                    Else
                        .Status = st(2).Trim
                        .Remaining = st(3).Trim
                    End If
                End With
            End If

            Dim t As New SelfTest
            With t
                .Num = st(0)
                .Description = st(1)
                If st(2).Contains("%") Then
                    .Status = st(2).Substring(0, st(2).Length - 4).Trim
                    .Remaining = st(2).Substring(st.Length - 3, 3).Trim
                    .LifeTime = st(3).Trim
                    .FirstError = st(4).Trim
                Else
                    .Status = st(2).Trim
                    .Remaining = st(3).Trim
                    .LifeTime = st(4).Trim
                    .FirstError = st(5).Trim
                End If
            End With
            m_selftests.Add(t)
        Next

    End Sub

    Private Sub GetSelective()
        'selective self-test log structure sample from 5.31 to now
        '===============================================================================================
        'SMART Selective self-test log data structure revision number 1
        ' SPAN   MIN_LBA   MAX_LBA  CURRENT_TEST_STATUS
        '    1  15926000  15993000  Completed [00% left] (0-65535)
        '    2         0         0  Not_testing
        '    3         0         0  Not_testing
        '    4         0         0  Not_testing
        '    5         0         0  Not_testing
        'Selective self-test flags (0x0):
        '  After scanning selected spans, do NOT read-scan remainder of disk.
        'If Selective self-test is pending on power-up, resume after 0 minute delay.
        '===============================================================================================
        'the log text of a device not supporting selective self-test:
        'Device does not support Selective Self Tests/Logging
        '===============================================================================================
        'generally, if you get the structure revision line, the device support self-tests.

        Dim i As Integer = GetIndexOf("SMART Selective self-test")
        If i = 0 Then Exit Sub
        i = GetIndexOf("SPAN", i)
        m_selectives.Clear()

        For r As Integer = i + 1 To i + 5

            Dim row() As String = m_output(r).Trim.Split(" ", 4, StringSplitOptions.RemoveEmptyEntries)
            If Not IsNumeric(row(0).Trim) Then Exit Sub

            Dim s As New Selectives

            With s
                .Span = row(0).Trim
                .MinLba = row(1).Trim
                .MaxLba = row(2).Trim
                .Status = row(3).Trim.Replace("_", " ")
            End With

            m_selectives.Add(s)
        Next
    End Sub

    Private Sub GetPollingTimes()
        Dim i As Short

        i = GetIndexOf("Total time to complete Offline")
        If i > 0 Then
            Dim timing() As String = m_output(i + 1).Split("(")
            m_pollingtimes.OfflineData = timing(1).Replace(")", "").Replace(".", "").Trim
        Else
            m_pollingtimes.OfflineData = "N/A"
        End If

        i = GetIndexOf("Short self-test routine")
        If i > 0 Then
            Dim timing() As String = m_output(i + 1).Split("(")
            m_pollingtimes.ShortTest = timing(1).Replace(")", "").Replace(".", "").Trim
        Else
            m_pollingtimes.ShortTest = "N/A"
        End If

        i = GetIndexOf("Extended self-test routine")
        If i > 0 Then
            Dim timing() As String = m_output(i + 1).Split("(")
            m_pollingtimes.ExtendedTest = timing(1).Replace(")", "").Replace(".", "").Trim
        Else
            m_pollingtimes.ExtendedTest = "N/A"
        End If

        i = GetIndexOf("Conveyance self-test routine")
        If i > 0 Then
            Dim timing() As String = m_output(i + 1).Split("(")
            m_pollingtimes.ConveyanceTest = timing(1).Replace(")", "").Replace(".", "").Trim
        Else
            m_pollingtimes.ConveyanceTest = "N/A"
        End If
    End Sub

    Private Sub GetRevisions()
        Dim i As Short

        i = GetIndexOf("SMART Attributes Data Structure revision number")
        If i > 0 Then
            Dim rev() As String = m_output(i).Split(":")
            m_revisions.AttributesTable = rev(1).Trim
        Else
            m_revisions.AttributesTable = "N/A"
        End If

        i = GetIndexOf("SMART Error Log Version")
        If i > 0 Then
            Dim rev() As String = m_output(i).Split(":")
            m_revisions.ErrorLog = rev(1).Trim
        Else
            m_revisions.ErrorLog = "N/A"
        End If

        i = GetIndexOf("SMART Self-test log structure revision number")
        If i > 0 Then
            Dim rev() As String = m_output(i).Split(" ")
            m_revisions.SelfTestLog = rev(rev.Length - 1)
        Else
            m_revisions.SelfTestLog = "N/A"
        End If

        i = GetIndexOf("SMART Selective self-test log data structure revision number")
        If i > 0 Then
            Dim rev() As String = m_output(i).Split(" ")
            m_revisions.SelectiveSelfTestLog = rev(rev.Length - 1)
        Else
            m_revisions.SelectiveSelfTestLog = "N/A"
        End If

    End Sub

    Private Sub GetOS()
        m_os = "N/A"
        For i As Short = 0 To 3
            If m_output(i).Contains("[") Then
                Dim s As Short = m_output(i).IndexOf("[") + 1
                Dim e As Short = m_output(i).IndexOf("]")
                m_os = m_output(i).Substring(s, e - s)
                Exit For
            End If
        Next
    End Sub

    Private Sub SelfTestSupporting()

        If GetIndexOf("Self-test Log not supported") > 0 Then
            m_selftestupported = False
        ElseIf GetIndexOf("Self-test log structure revision number") > 0 Then
            m_selftestupported = True
        Else
            m_selftestupported = False
        End If

        If GetIndexOf("Device does not support Selective Self Tests/Logging") > 0 Then
            m_selectivesupported = False
        ElseIf GetIndexOf("Selective self-test log data structure revision number") > 0 Then
            m_selectivesupported = True
        Else
            m_selectivesupported = False
        End If

    End Sub

    Private Sub ErrorLoggingSupport()
        If GetIndexOf("Error Log not supported") > 0 Then
            m_errorloggingsupport = False
        ElseIf GetIndexOf("Error Log Version:") > 0 Then
            m_errorloggingsupport = True
        Else
            m_errorloggingsupport = False
        End If
    End Sub

    Public Sub SetSmartStatus(ByVal value As SmartFeature)
        If m_type = DeviceType.ATA Then

            If value = SmartFeature.Enable Then
                Dim feature() As String = smartctl.SendCmd("-s on " & m_location)
            Else
                Dim feature() As String = smartctl.SendCmd("-s off " & m_location)
            End If
        End If
    End Sub

    Public Sub SetOfflineCollectionStatus(ByVal value As SmartFeature)
        If m_type = DeviceType.ATA Then

            If value = SmartFeature.Enable Then
                Dim feature() As String = smartctl.SendCmd("-o on " & m_location)
            Else
                Dim feature() As String = smartctl.SendCmd("-o off " & m_location)
            End If
        End If
    End Sub

    Public Sub RunTest(ByVal test As TestType)
        m_testisrunning = True
        Select Case test
            Case TestType.Abort
                smartctl.SendCmd("-X " & m_location)
                m_testisrunning = False
            Case TestType.Offline
                smartctl.SendCmd("-t offline " & m_location)
                Dim s As Date = Now
                Dim t As Integer = ConvertToSeconds(m_pollingtimes.OfflineData)
                Dim e As Date = s.AddSeconds(t)
                m_testtiming.Start = s
                m_testtiming.Duration = t
                m_testtiming.Conclusion = e
            Case TestType.ShortTest
                smartctl.SendCmd("-t short " & m_location)
                Dim s As Date = Now
                Dim t As Integer = ConvertToSeconds(m_pollingtimes.ShortTest)
                Dim e As Date = s.AddSeconds(t)
                m_testtiming.Start = s
                m_testtiming.Duration = t
                m_testtiming.Conclusion = e
            Case TestType.LongTest
                smartctl.SendCmd("-t long " & m_location)
                Dim s As Date = Now
                Dim t As Integer = ConvertToSeconds(m_pollingtimes.ExtendedTest)
                Dim e As Date = s.AddSeconds(t)
                m_testtiming.Start = s
                m_testtiming.Duration = t
                m_testtiming.Conclusion = e
            Case TestType.Conveyance
                smartctl.SendCmd("-t conveyance " & m_location)
                Dim s As Date = Now
                Dim t As Integer = ConvertToSeconds(m_pollingtimes.ConveyanceTest)
                Dim e As Date = s.AddSeconds(t)
                m_testtiming.Start = s
                m_testtiming.Duration = t
                m_testtiming.Conclusion = e
            Case TestType.ScsiLongTest
                smartctl.SendCmd("-t long " & m_location)
                Dim s As Date = Now
                Dim t As Integer = Val(m_testduration)
                Dim e As Date = s.AddSeconds(t)
                m_testtiming.Start = s
                m_testtiming.Duration = t
                m_testtiming.Conclusion = e
        End Select
    End Sub

    Public ReadOnly Property Family As String
        Get
            Return m_modelfamily
        End Get
    End Property

    Public ReadOnly Property Model As String
        Get
            Return m_devicemodel
        End Get
    End Property

    Public ReadOnly Property Type As DeviceType
        Get
            Return m_type
        End Get
    End Property

    Public ReadOnly Property Location As String
        Get
            If m_additional Then Return m_description Else Return m_location
        End Get
    End Property

    Public ReadOnly Property SmartSupport As Support
        Get
            Return m_smartavailable
        End Get
    End Property

    Public ReadOnly Property SmartEnabled As Support
        Get
            Return m_smartenabled
        End Get
    End Property

    Public ReadOnly Property OfflineCollectionStatus As Support
        Get
            Return m_offlinedatacollection
        End Get
    End Property

    Public ReadOnly Property SerialNumber As String
        Get
            Return m_serialnumber
        End Get
    End Property

    Public ReadOnly Property FirmwareVersion As String
        Get
            Return m_firmware
        End Get
    End Property

    Public ReadOnly Property UserCapacity As String
        Get
            Return m_size
        End Get
    End Property

    Public ReadOnly Property WorldWideName As String
        Get
            Return m_wwn
        End Get
    End Property

    Public ReadOnly Property SectorSize As String
        Get
            Return m_sectorsize
        End Get
    End Property

    Public ReadOnly Property InDatabase As Boolean
        Get
            Return m_indatabase
        End Get
    End Property

    Public ReadOnly Property AtaVersion As String
        Get
            If m_isvirtual = True And IO.File.Exists(m_location) Then

            Else

            End If
            If m_atastandard <> "N/A" Then
                Return m_ataversion & " (" & m_atastandard & ")"
            Else
                Return m_ataversion
            End If
        End Get
    End Property

    'Public ReadOnly Property AtaStandard As String
    '    Get
    '        Return m_atastandard
    '    End Get
    'End Property

    Public ReadOnly Property LastCheck As String
        Get
            Dim months() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
            Dim newdate As String = m_lastcheck

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

                Dim dt As DateTime
                If DateTime.TryParseExact(newdate, "dddd MMMM dd HH mm ss yyyy", Nothing, Nothing, dt) Then
                    Return FormatDateTime(dt, DateFormat.LongDate) & ", " & FormatDateTime(dt, DateFormat.LongTime)
                Else
                    Return m_lastcheck
                End If
            Else
                Return "N/A"
            End If
        End Get
    End Property

    Public ReadOnly Property Warning As Warnings
        Get
            Return m_warnings
        End Get
    End Property

    Public ReadOnly Property Capabilities As CapabilitiesCollection
        Get
            Return m_capabilites
        End Get
    End Property

    Public ReadOnly Property Attributes As AttributesCollection
        Get
            Return m_attributes
        End Get
    End Property

    Public ReadOnly Property Errors As ErrorCollection
        Get
            If m_smartenabled <> Support.Enabled Then m_errors = Nothing

            Return m_errors
        End Get
    End Property

    Public ReadOnly Property TotalErrors As String
        Get
            Return m_totalerrors
        End Get
    End Property

    Public ReadOnly Property SelfTests As SelfTestCollection
        Get
            Return m_selftests
        End Get
    End Property

    Public ReadOnly Property SelectiveSelfTest As SelectivesCollection
        Get
            Return m_selectives
        End Get
    End Property

    Public ReadOnly Property Health As Status
        Get
            Return m_healthpassed
        End Get
    End Property

    Public ReadOnly Property LastTestResults As LastTest
        Get
            Return m_lasttest
        End Get
    End Property

    Public ReadOnly Property Temperature As String
        Get
            Return m_temperature
        End Get
    End Property

    Public ReadOnly Property RemainingLife As String
        Get
            Return m_remaininglife
        End Get
    End Property

    Public ReadOnly Property VitalParametersVariation As Vitals
        Get
            Return m_vitals
        End Get
    End Property

    Public ReadOnly Property NewVitalParameters As Vitals
        Get
            Return m_newvitals
        End Get
    End Property

    Public ReadOnly Property OldVitalParameters As Vitals
        Get
            Return m_oldvitals
        End Get
    End Property

    Public ReadOnly Property BadSectorsCount As String
        Get
            Return m_badsectors
        End Get
    End Property

    Public ReadOnly Property Output As String
        Get
            Dim value As String = ""

            If Not m_isunavailable Then
                If IO.File.Exists(m_location) Then
                    value = IO.File.ReadAllText(m_location) 'm_origcontent
                Else
                    For i As Integer = 0 To m_output.Length - 1
                        If Not IsNothing(m_output(i)) Then
                            If i > 0 Then
                                value += m_output(i).Replace(vbLf, vbCrLf)
                            Else
                                value += m_output(i).Replace(vbLf, "")
                            End If
                        Else
                            value += m_output(i)
                        End If
                    Next
                End If
            End If

            Return value
        End Get
    End Property

    Public ReadOnly Property TestsPollingTime As PollingTimes
        Get
            Return m_pollingtimes
        End Get
    End Property

    Public ReadOnly Property DataStructuresRev As Revisions
        Get
            Return m_revisions
        End Get
    End Property

    Public ReadOnly Property OS As String
        Get
            Return m_os
        End Get
    End Property

    Public ReadOnly Property SmartctlVersion As String
        Get
            Return m_smartctl
        End Get
    End Property

    Public Property VirtualDeviceInfo As VirtualDeviceInfo
        Get
            Return m_vdinfo
        End Get
        Set(ByVal value As VirtualDeviceInfo)
            m_vdinfo = value
            If m_isunavailable Then
                m_devicemodel = m_vdinfo.Model
                m_serialnumber = m_vdinfo.SerialNumber
                m_firmware = m_vdinfo.Firmware
                m_size = m_vdinfo.UserSize
                m_smartavailable = Support.Unknown
                m_smartenabled = Support.Unknown
            End If
        End Set
    End Property

    Public Property TestIsRunnig As Boolean
        Get
            Return m_testisrunning
        End Get
        Set(ByVal value As Boolean)
            m_testisrunning = value
        End Set
    End Property

    Public Property DisplayLife As Boolean
        Get
            Return m_displaylife
        End Get
        Set(ByVal value As Boolean)
            m_displaylife = value
            SaveDeviceSettings()
        End Set
    End Property

    Public Property IsShared As Boolean
        Get
            Return m_isshared
        End Get
        Set(ByVal value As Boolean)
            m_isshared = value
            SaveDeviceSettings()
        End Set
    End Property

    Public ReadOnly Property AamStatus As Feature
        Get
            Return m_aamstatus
        End Get
    End Property

    Public Property AamValue As String
        Get
            Return m_aam
        End Get
        Set(ByVal value As String)
            smartctl.SendCmd("-s aam," & value & " " & m_location)
            Update()
        End Set
    End Property

    Public ReadOnly Property RecommendedAAM As Short
        Get
            Return m_recommendedaam
        End Get
    End Property

    Public Property ApmValue As String
        Get
            Return m_apm
        End Get
        Set(ByVal value As String)
            smartctl.SendCmd("-s apm," & value & " " & m_location)
            Update()
        End Set
    End Property

    Public ReadOnly Property ApmStatus As Feature
        Get
            Return m_apmstatus
        End Get
    End Property

    Public Property Standby As String
        Get
            Return m_standby
        End Get
        Set(ByVal value As String)
            smartctl.SendCmd("-s standby," & value & " " & m_location)
            m_standby = value
            SaveDeviceSettings()
        End Set
    End Property

    Public Property Cache As Feature
        Get
            Return m_cache
        End Get
        Set(ByVal value As Feature)
            If value = Feature.Enable Then
                smartctl.SendCmd("-s wcache,on " & m_location)
            ElseIf value = Feature.Disable Then
                smartctl.SendCmd("-s wcache,off " & m_location)
            End If
            Update()
        End Set
    End Property

    Public Property CacheReorder As Feature
        Get
            Return m_cachereorder
        End Get
        Set(ByVal value As Feature)
            If value = Feature.Enable Then
                smartctl.SendCmd("-s wcreorder,on " & m_location)
            ElseIf value = Feature.Disable Then
                smartctl.SendCmd("-s wcreorder,off " & m_location)
            End If
            Update()
        End Set
    End Property

    Public Property LookAhead As Feature
        Get
            Return m_lookahead
        End Get
        Set(ByVal value As Feature)
            If value = Feature.Enable Then
                smartctl.SendCmd("-s lookahead,on " & m_location)
            ElseIf value = Feature.Disable Then
                smartctl.SendCmd("-s lookahead,off " & m_location)
            End If
            Update()
        End Set
    End Property

    Public ReadOnly Property TestTiming As TestTiming
        Get
            Return m_testtiming
        End Get
    End Property

    Public ReadOnly Property IsSupportedSeftTest As Boolean
        Get
            Return m_selftestupported
        End Get
    End Property

    Public ReadOnly Property IsSupportedSelective As Boolean
        Get
            Return m_selectivesupported
        End Get
    End Property

    Public ReadOnly Property IsSupportedErrorLogging As Boolean
        Get
            Return m_errorloggingsupport
        End Get
    End Property

    Public ReadOnly Property IsSsd As Boolean
        Get
            Return m_ssd
        End Get
    End Property

    Public ReadOnly Property BadSectorsThreshold As Short
        Get
            Return m_id5threshold
        End Get
    End Property

    Public Sub Update()
        Main.PrintDebug("Updating " & m_devicemodel & " (" & m_serialnumber & ") output")

        If m_type = DeviceType.ATA Or m_type = DeviceType.USB Then
            Dim cmdlineoptions As String = m_options
            If My.Settings.Tolerance Then cmdlineoptions += My.Settings.ToleranceLevel
            If My.Settings.PowerMode Then cmdlineoptions += My.Settings.PowerModeLevel

            m_output = smartctl.SendCmd("-a -g all -g wcreorder -P use " & cmdlineoptions.Replace(vbCrLf, "") & " " & m_location)
        ElseIf m_type = DeviceType.SCSI Then
            m_output = smartctl.SendCmd("-a -g all " & m_location)
        Else
            If IO.File.Exists(m_location) Then
                m_output = IO.File.ReadAllLines(m_location)
                m_isunavailable = False
            Else
                'if a file is stored into a non local device, is possible
                'that file is unaccessible for a showdown of the net
                m_isunavailable = True
                m_devicemodel = m_vdinfo.Model
                m_serialnumber = m_vdinfo.SerialNumber
                m_firmware = m_vdinfo.Firmware
                m_size = m_vdinfo.UserSize
                m_smartavailable = Support.Unknown
                m_smartenabled = Support.Unknown
                m_healthpassed = Status.Unkonwn
                m_temperature = "N/A"
                m_atastandard = "N/A"
                m_ataversion = "N/A"
                Exit Sub
            End If
        End If

        If GetIndexOf("Warning: Limited functionality due to missing admin rights") > 0 Then m_missingadminrights = True

        m_isvaliddevice = CheckIfValid()

        If m_isvaliddevice Then

            m_lastcheck = GetInfo("Local Time is")

            If m_isdisk Then
                GetScsiAttributes()
                GetScsiErrorLog()
                GetScsiSelfTest()
            Else
                GetDeviceInfo()
                GetHealth()
                GetCapabilities()
                GetPollingTimes()
                GetAttributes()
                GetErrors()
                GetRevisions()
                GetSelfTest()
                GetSelective()
                SelfTestSupporting()
                ErrorLoggingSupport()
            End If

            GetOS()
            Reliability()
            UpdateTrayIcon()

            CompareVitals()
            m_alreadydysplayedwarnings = False
        End If

    End Sub

    Public ReadOnly Property MissingAdminRights As Boolean
        Get
            Return m_missingadminrights
        End Get
    End Property

    Public Property AlreadyDisplayedWarnings As Boolean
        Get
            Return m_alreadydysplayedwarnings
        End Get
        Set(ByVal value As Boolean)
            m_alreadydysplayedwarnings = value
        End Set
    End Property

    Public Property Options As String
        Get
            Return m_options
        End Get
        Set(ByVal value As String)
            m_options = value
            SaveDeviceSettings()
        End Set
    End Property

    Public ReadOnly Property IsValidDevice As Boolean
        Get
            Return m_isvaliddevice
        End Get
    End Property

    Public ReadOnly Property ReliabilityRating As Ratings
        Get
            Return m_reliability
        End Get
    End Property

    Public ReadOnly Property IsOptical As Boolean
        Get
            Return m_isoptical
        End Get
    End Property

    Public ReadOnly Property RotationRate As String
        Get
            Return m_rotation
        End Get
    End Property

    Public ReadOnly Property SataVersion As String
        Get
            Return m_sataversion
        End Get
    End Property

    Private Sub CompareVitals()
        'Dim tolog As Boolean = False
        Dim l As Log

        l.Year = Now.Year
        l.Month = Now.Month
        l.Day = Now.Day
        l.Hour = Now.Hour & ":" & Now.Minute & ":" & Now.Second

        If Not IsNothing(m_oldvitals) And Not IsNothing(m_newvitals) Then

            If My.Settings.CurrentPendingSector Then
                If IsNumeric(m_oldvitals.CurPending) And IsNumeric(m_newvitals.CurPending) Then
                    m_vitals.CurPending = Convert.ToSingle(m_newvitals.CurPending) - Convert.ToSingle(m_oldvitals.CurPending)
                    If m_vitals.CurPending <> 0 Then
                        With l
                            .EventName = "Current pending sectors"
                            .OldValue = m_oldvitals.CurPending
                            .NewValue = m_newvitals.CurPending
                            .Variation = m_vitals.CurPending
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.DiskShift Then
                If IsNumeric(m_oldvitals.DiskShift) And IsNumeric(m_newvitals.DiskShift) Then
                    m_vitals.DiskShift = Convert.ToSingle(m_newvitals.DiskShift) - Convert.ToSingle(m_oldvitals.DiskShift)
                    If m_vitals.DiskShift <> 0 Then
                        With l
                            .EventName = "Disk shift"
                            .OldValue = m_oldvitals.DiskShift
                            .NewValue = m_newvitals.DiskShift
                            .Variation = m_vitals.DiskShift
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If IsNumeric(m_oldvitals.Errors) And IsNumeric(m_newvitals.Errors) Then
                m_vitals.Errors = Convert.ToSingle(m_newvitals.Errors) - Convert.ToSingle(m_oldvitals.Errors)
                If m_vitals.Errors <> 0 Then
                    With l
                        .EventName = "ATA Errors"
                        .OldValue = m_oldvitals.Errors
                        .NewValue = m_newvitals.Errors
                        .Variation = m_vitals.Errors
                    End With
                    m_vitalslog.Add(l)
                End If
            End If

            If My.Settings.Indilinx Then
                If IsNumeric(m_oldvitals.Indilinx) And IsNumeric(m_newvitals.Indilinx) Then
                    m_vitals.Indilinx = Convert.ToSingle(m_newvitals.Indilinx) - Convert.ToSingle(m_oldvitals.Indilinx)
                    If m_vitals.Indilinx <> 0 Then
                        With l
                            .EventName = "Remaining life percentage"
                            .OldValue = m_oldvitals.Indilinx
                            .NewValue = m_newvitals.Indilinx
                            .Variation = m_vitals.Indilinx
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.Intel Then
                If IsNumeric(m_oldvitals.Intel) And IsNumeric(m_newvitals.Intel) Then
                    m_vitals.Intel = Convert.ToSingle(m_newvitals.Intel) - Convert.ToSingle(m_oldvitals.Intel)
                    If m_vitals.Intel <> 0 Then
                        With l
                            .EventName = "Media wearout indicator"
                            .OldValue = m_oldvitals.Intel
                            .NewValue = m_newvitals.Intel
                            .Variation = m_vitals.Intel
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.Micron Then
                If IsNumeric(m_oldvitals.Micron) And IsNumeric(m_newvitals.Micron) Then
                    m_vitals.Micron = Convert.ToSingle(m_newvitals.Micron) - Convert.ToSingle(m_oldvitals.Micron)
                    If m_vitals.Micron <> 0 Then
                        With l
                            .EventName = "Percentage lifetime used"
                            .OldValue = m_oldvitals.Micron
                            .NewValue = m_newvitals.Micron
                            .Variation = m_vitals.Micron
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.OfflineUncorrectable Then
                If IsNumeric(m_oldvitals.OfflineUnc) And IsNumeric(m_newvitals.OfflineUnc) Then
                    m_vitals.OfflineUnc = Convert.ToSingle(m_newvitals.OfflineUnc) - Convert.ToSingle(m_oldvitals.OfflineUnc)
                    If m_vitals.OfflineUnc <> 0 Then
                        With l
                            .EventName = "Offline uncorrectable"
                            .OldValue = m_oldvitals.OfflineUnc
                            .NewValue = m_newvitals.OfflineUnc
                            .Variation = m_vitals.OfflineUnc
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.ReallocatedEvent Then
                If IsNumeric(m_oldvitals.ReallEvent) And IsNumeric(m_newvitals.ReallEvent) Then
                    m_vitals.ReallEvent = Convert.ToSingle(m_newvitals.ReallEvent) - Convert.ToSingle(m_oldvitals.ReallEvent)
                    If m_vitals.ReallEvent <> 0 Then
                        With l
                            .EventName = "Reallocated event count"
                            .OldValue = m_oldvitals.ReallEvent
                            .NewValue = m_newvitals.ReallEvent
                            .Variation = m_vitals.ReallEvent
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.ReallocatedSector Then
                If IsNumeric(m_oldvitals.ReallSect) And IsNumeric(m_newvitals.ReallSect) Then
                    m_vitals.ReallSect = Convert.ToSingle(m_newvitals.ReallSect) - Convert.ToSingle(m_oldvitals.ReallSect)
                    If m_vitals.ReallSect <> 0 Then
                        With l
                            .EventName = "Reallocated sector count"
                            .OldValue = m_oldvitals.ReallSect
                            .NewValue = m_newvitals.ReallSect
                            .Variation = m_vitals.ReallSect
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.Samsung Then
                If IsNumeric(m_oldvitals.Samsung) And IsNumeric(m_newvitals.Samsung) Then
                    m_vitals.Samsung = Convert.ToSingle(m_newvitals.Samsung) - Convert.ToSingle(m_oldvitals.Samsung)
                    If m_vitals.Samsung <> 0 Then
                        With l
                            .EventName = "Wear leveling count"
                            .OldValue = m_oldvitals.Samsung
                            .NewValue = m_newvitals.Samsung
                            .Variation = m_vitals.Samsung
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.SandForce Then
                If IsNumeric(m_oldvitals.SandForce) And IsNumeric(m_newvitals.SandForce) Then
                    m_vitals.SandForce = Convert.ToSingle(m_newvitals.SandForce) - Convert.ToSingle(m_oldvitals.SandForce)
                    If m_vitals.SandForce <> 0 Then
                        With l
                            .EventName = "SSD life left"
                            .OldValue = m_oldvitals.SandForce
                            .NewValue = m_newvitals.SandForce
                            .Variation = m_vitals.SandForce
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.SoftReadErrorRate Then
                If IsNumeric(m_oldvitals.SoftRead) And IsNumeric(m_newvitals.SoftRead) Then
                    m_vitals.SoftRead = Convert.ToSingle(m_newvitals.SoftRead) - Convert.ToSingle(m_oldvitals.SoftRead)
                    If m_vitals.SoftRead <> 0 Then
                        With l
                            .EventName = "Soft read error rate"
                            .OldValue = m_oldvitals.SoftRead
                            .NewValue = m_newvitals.SoftRead
                            .Variation = m_vitals.SoftRead
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.SpinRetry Then
                If IsNumeric(m_oldvitals.SpinRetry) And IsNumeric(m_newvitals.SpinRetry) Then
                    m_vitals.SpinRetry = Convert.ToSingle(m_newvitals.SpinRetry) - Convert.ToSingle(m_oldvitals.SpinRetry)
                    If m_vitals.SpinRetry <> 0 Then
                        With l
                            .EventName = "Spin retry count"
                            .OldValue = m_oldvitals.SpinRetry
                            .NewValue = m_newvitals.SpinRetry
                            .Variation = m_vitals.SpinRetry
                        End With
                        m_vitalslog.Add(l)
                    End If
                End If
            End If

            If My.Settings.Temperature Then
                If IsNumeric(m_oldvitals.Temperature) And IsNumeric(m_newvitals.Temperature) Then
                    m_vitals.Temperature = Convert.ToSingle(m_newvitals.Temperature) - Convert.ToSingle(m_oldvitals.Temperature)
                    'If m_newvitals.Temperature >= 50 Or m_oldvitals.Temperature >= 50 Then
                    If m_vitals.Temperature <> 0 Then
                        With l
                            .EventName = "Temperature"
                            .OldValue = m_oldvitals.Temperature
                            .NewValue = m_newvitals.Temperature
                            .Variation = m_vitals.Temperature
                        End With
                        m_vitalslog.Add(l)
                    End If
                    'End If
                End If
            End If

            'm_oldvitals = m_newvitals
        End If

        If IsNothing(m_newvitals) And Not IsNothing(m_oldvitals) Then m_newvitals = m_oldvitals

        If Not IsNothing(m_vitalslog) Then SaveDeviceLog()
    End Sub

    Private Sub SaveDeviceLog()
        Try
            If m_dontsavelog Then Exit Sub
            If m_devicemodel = "N/A" Or m_serialnumber = "N/A" Then Exit Sub

            Main.PrintDebug("Saving " & m_devicemodel & " (" & m_serialnumber & ") log")

            Dim f As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData. _
            Substring(0, My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.LastIndexOf("\")) & "\logs"

            If Not IO.Directory.Exists(f & "\") Then IO.Directory.CreateDirectory(f & "\")

            Dim output As XmlWriterSettings = New XmlWriterSettings()
            output.Indent = True
            Using write As XmlWriter = XmlWriter.Create(f & "\" & m_devicefilename & ".xml", output)
                write.WriteStartDocument()
                write.WriteStartElement("log")

                If Not IsNothing(m_vitalslog) Then
                    For i As Short = 0 To m_vitalslog.Count - 1
                        write.WriteStartElement("logitem")
                        write.WriteAttributeString("year", m_vitalslog(i).Year)
                        write.WriteAttributeString("month", m_vitalslog(i).Month)
                        write.WriteAttributeString("day", m_vitalslog(i).Day)
                        write.WriteAttributeString("hour", m_vitalslog(i).Hour)
                        write.WriteAttributeString("event", m_vitalslog(i).EventName)
                        write.WriteAttributeString("from", m_vitalslog(i).OldValue)
                        write.WriteAttributeString("to", m_vitalslog(i).NewValue)
                        write.WriteAttributeString("variation", m_vitalslog(i).Variation)
                        write.WriteEndElement()
                    Next
                End If

                If Not IsNothing(m_newvitals) Then
                    write.WriteStartElement("values")
                    write.WriteAttributeString("current_pending", m_newvitals.CurPending)
                    write.WriteAttributeString("disk_shift", m_newvitals.DiskShift)
                    write.WriteAttributeString("ata_errors", m_newvitals.Errors)
                    write.WriteAttributeString("indilinx", m_newvitals.Indilinx)
                    write.WriteAttributeString("intel", m_newvitals.Intel)
                    write.WriteAttributeString("micron", m_newvitals.Micron)
                    write.WriteAttributeString("offline_uncorrectable", m_newvitals.OfflineUnc)
                    write.WriteAttributeString("reallocation_events", m_newvitals.ReallEvent)
                    write.WriteAttributeString("reallocated_sectors", m_newvitals.ReallSect)
                    write.WriteAttributeString("samsung", m_newvitals.Samsung)
                    write.WriteAttributeString("sandforce", m_newvitals.SandForce)
                    write.WriteAttributeString("soft_read", m_newvitals.SoftRead)
                    write.WriteAttributeString("spin_retry", m_newvitals.SpinRetry)
                    write.WriteAttributeString("temperature", m_newvitals.Temperature)
                    write.WriteEndElement()
                End If

                write.WriteEndElement()
                write.WriteEndDocument()
            End Using
        Catch e As Exception
            Main.PrintDebug("Encountered an error while saving " & m_devicemodel & " (" & m_serialnumber & ") log: " & e.ToString, True)
        End Try
    End Sub

    Private Sub LoadDeviceLog()
        Try
            Main.PrintDebug("Loading " & m_devicemodel & " (" & m_serialnumber & ") log")

            Dim fo As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData. _
            Substring(0, My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.LastIndexOf("\")) & "\logs"
            Dim fi As String = "\" & m_devicefilename & ".xml"

            If Not IO.Directory.Exists(fo & "\") Then IO.Directory.CreateDirectory(fo & "\")

            If IO.File.Exists(fo & fi) Then
                Dim m_xmldoc As New XmlDocument
                Dim m_nodelist As XmlNodeList
                Dim m_node As XmlNode
                m_xmldoc.Load(fo & fi)
                m_nodelist = m_xmldoc.SelectNodes("/log/logitem")
                Dim l As New Log
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
                    m_vitalslog.Add(l)
                Next

                m_nodelist = m_xmldoc.SelectNodes("/log/values")
                For Each m_node In m_nodelist
                    With m_oldvitals
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

                Main.PrintDebug("Loaded " & m_vitalslog.Count & " events")
            End If
        Catch e As Exception
            Main.PrintDebug("Encountered an error while loading " & m_devicemodel & " (" & m_serialnumber & ") log: " & e.ToString, True)
        End Try
    End Sub

    Private Sub SaveDeviceSettings()
        Main.PrintDebug("Saving " & m_devicemodel & " (" & m_serialnumber & ") settings")

        If m_type = DeviceType.Virtual Then Exit Sub

        Dim l As Short = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.LastIndexOf("\")
        Dim folder As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.Substring(0, l + 1)

        Dim output As XmlWriterSettings = New XmlWriterSettings()
        output.Indent = True
        Using write As XmlWriter = XmlWriter.Create(folder & "\" & m_devicefilename & ".xml", output)
            write.WriteStartDocument()
            write.WriteStartElement("monitoring")
            write.WriteStartElement("settings")
            write.WriteAttributeString("trayicon", m_devtrayicon.Visible)
            write.WriteAttributeString("displaylife", m_displaylife)
            write.WriteAttributeString("share", m_isshared)
            write.WriteEndElement()
            write.WriteEndElement()
            write.WriteEndDocument()
        End Using

        l = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.LastIndexOf("\")
        folder = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.Substring(0, l + 1)

        Using write As XmlWriter = XmlWriter.Create(folder & "\" & m_devicefilename & ".xml", output)
            write.WriteStartElement("smartctl")
            write.WriteStartElement("settings")
            write.WriteAttributeString("options", m_options)
            write.WriteAttributeString("standby", m_standby)
            write.WriteEndElement()
            write.WriteEndElement()
            write.WriteEndDocument()
        End Using
    End Sub

    Private Sub LoadDeviceSettings()
        Main.PrintDebug("Loading " & m_devicemodel & " (" & m_serialnumber & ") settings")
        If m_type = DeviceType.Virtual Then Exit Sub

        Dim l As Short = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.LastIndexOf("\")
        Dim folder As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.Substring(0, l + 1)

        If IO.File.Exists(folder & m_devicefilename & ".xml") Then
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            Try
                m_xmldoc.Load(folder & m_devicefilename & ".xml")
                m_nodelist = m_xmldoc.SelectNodes("/monitoring/settings")
                For Each m_node In m_nodelist
                    m_devtrayicon.Visible = m_node.Attributes.GetNamedItem("trayicon").Value
                    m_displaylife = m_node.Attributes.GetNamedItem("displaylife").Value
                    m_isshared = m_node.Attributes.GetNamedItem("share").Value
                Next
            Catch ex As Exception
                Main.PrintDebug("Error loading device monitoring settings: " & ex.ToString, True)
            End Try
        End If

        l = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.LastIndexOf("\")
        folder = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.Substring(0, l + 1)

        If IO.File.Exists(folder & m_devicefilename & ".xml") Then
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            Try
                m_xmldoc.Load(folder & m_devicefilename & ".xml")
                m_nodelist = m_xmldoc.SelectNodes("/smartctl/settings")
                For Each m_node In m_nodelist
                    m_options = m_node.Attributes.GetNamedItem("options").Value
                    m_standby = m_node.Attributes.GetNamedItem("standby").Value
                Next
            Catch ex As Exception
                Main.PrintDebug("Error loading device smartctl settings: " & ex.ToString, True)
            End Try
        End If
    End Sub

    Public ReadOnly Property Log As DeviceLog
        Get
            Return m_vitalslog
        End Get
    End Property

    Public Property DisplayTrayIcon As Boolean
        Get
            Return m_devtrayicon.Visible
        End Get
        Set(ByVal value As Boolean)
            If Not IsNothing(m_devtrayicon) Then
                m_devtrayicon.Visible = value
                'If value = False Then m_devtrayicon.Dispose()
                SaveDeviceSettings()
            Else
                m_devtrayicon = New TrayIcon
                m_devtrayicon.Visible = value
                SaveDeviceSettings()
            End If
        End Set
    End Property

    Public Sub DisposeTrayIcon()
        If Not IsNothing(m_devtrayicon) Then m_devtrayicon.Dispose()
    End Sub

    Private Sub UpdateTrayIcon()

        If m_type = DeviceType.Virtual Then Exit Sub

        Dim iconvalue As String = ""
        With m_devtrayicon

            .Health = m_healthpassed
            .RemainingLife = m_remaininglife
            .Temperature = m_temperature
            .Rating = m_reliability

            If m_displaylife Then
                .SetIcon(m_remaininglife, m_healthpassed, True)
                iconvalue = Main.m_remaininglife & ": " & m_remaininglife & "%"
            Else
                .SetIcon(m_temperature, m_healthpassed)
                If IsNumeric(m_temperature) Then
                    If My.Settings.TempFahrenheit = True Then
                        iconvalue = Main.m_temperature & ": " & Math.Round(m_temperature * 1.8 + 32) & "°F"
                    Else
                        iconvalue = Main.m_temperature & ": " & m_temperature & "°C"
                    End If
                Else
                    iconvalue = Main.m_temperature & ": " & m_temperature
                End If
            End If

            .Title = m_devicemodel
            If m_type <> DeviceType.SCSI Then

            End If
            Dim rating As String = ""
            Select Case m_reliability.Overall
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

            Select Case m_healthpassed
                Case Status.Failed
                    .Content = iconvalue & vbCrLf & _
                        Main.m_overallhealth & ": " & Main.h_overallfailed & rating
                Case Status.Passed
                    .Content = iconvalue & vbCrLf & _
                        Main.m_overallhealth & ": " & Main.h_overallpassed & rating
                Case Status.Unkonwn
                    .Content = iconvalue & vbCrLf & _
                        Main.m_overallhealth & ": " & Main.h_unknown & rating
            End Select
        End With
    End Sub

    Public Class MailNotification
        Dim m_alreadysendtemp As Boolean = False
        Dim m_alreadysendhealth As Boolean = False

        Public Property Temperature As Boolean
            Get
                Return m_alreadysendtemp
            End Get
            Set(value As Boolean)
                m_alreadysendtemp = value
            End Set
        End Property

        Public Property Health As Boolean
            Get
                Return m_alreadysendhealth
            End Get
            Set(value As Boolean)
                m_alreadysendhealth = value
            End Set
        End Property
    End Class

    Dim m_notification As New MailNotification

    Public Property AlreadySentNotification As MailNotification
        Get
            Return m_notification
        End Get
        Set(value As MailNotification)
            m_notification = value
        End Set
    End Property

    Public ReadOnly Property DeviceFileName As String
        Get
            Return m_devicefilename
        End Get
    End Property

    Public ReadOnly Property DeviceInterface As String
        Get
            If m_isscsi Then
                If Not IsNothing(m_protocol) Then
                    If m_protocol.Length > 0 Then
                        Return m_protocol
                    Else
                        Return "SCSI"
                    End If
                End If
            End If

            If Not IsNothing(m_sataversion) Then
                If m_sataversion <> "N/A" Then
                    Dim sataver() As String = m_sataversion.Split(",")
                    Return sataver(0)
                Else
                    If IsNumeric(m_ataversion) Then
                        Select Case m_ataversion
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
                        If m_ataversion.ToString.Contains("ATA/ATAPI") Then
                            If m_ataversion.ToString.Contains("ATA/ATAPI-7") Then
                                Return "ATA"
                            Else
                                Return "PATA"
                            End If
                        ElseIf m_ataversion.ToString.Contains("ATA8") Then
                            Return "SATA"
                        Else
                            If m_sataversion <> "N/A" Then
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

    Public ReadOnly Property IsDoubleDeck As Boolean
        Get
            Return m_doubledeck
        End Get
    End Property

    Public ReadOnly Property WorkTime As String
        Get
            If m_isscsi Then
                Return m_scsiworktime
            Else
                Return m_worktime
            End If
        End Get
    End Property

    Public ReadOnly Property WorkTimeHuman As String
        Get
            If m_isscsi Then
                Return m_scsiworktimehuman
            Else
                Return m_worktimehuman
            End If
        End Get
    End Property
End Class

Public Structure DevCapabilities
    Dim Name As String
    Dim Value As String
    Dim Meaning As String
End Structure

Public Structure Attribute
    Public ID As String
    Public Name As String
    Public Flag As AttributeFlags
    Public Value As String
    Public Worst As String
    Public Threshold As String
    Public Type As AttributeType
    Public Updated As AttributeUpdate
    Public WhenFailed As String
    Public RawValue As String
End Structure

Public Structure SmartError
    Public Class CmdCollection
        Inherits List(Of Command)
    End Class

    Dim Number As Integer
    Dim Lifetime As String
    Dim Status As String
    Dim Registers As Register
    Dim Commands As CmdCollection
End Structure

Public Structure Register
    Dim ER, ST, SC, SN, CL, CH, DH, ErrorText As String
End Structure

Public Structure Command
    Dim CR, FR, SC, SN, CL, CH, DH, DC, PowerUp, Feature As String
End Structure

Public Structure SelfTest
    Dim Num, Description, Status, Remaining, LifeTime, FirstError As String
End Structure

Public Structure Selectives
    Dim Span, MinLba, MaxLba, Status As String
End Structure

Public Structure LastTest
    Dim IsPassed As Status
    Dim Status, Remaining As String
End Structure

Public Structure Vitals
    '*** HDD vital values ***
    '5 Reallocated_Sector_Ct
    '10 Spin_Retry_Count
    '194 Temperature_Celsius
    '196 Reallocated_Event_Count
    '197 Current_Pending_Sector
    '198 Offline_Uncorrectable
    '201 Soft_Read_Error_Rate
    '220 Disk_Shift
    '*** SSD vital percentages ***
    '202 Perc_Rated_Life_Used    [Micron]
    '209 Remaining_Lifetime_Perc [Indilinx]
    '233 Media_Wearout_Indicator [Intel]
    '177 Wear_Leveling_Count     [Samsung]
    '231 SSD_Life_Left           [SandForce]
    '*** from 0.4 track also the total amount of ATA errors! ***
    Dim ReallSect, SpinRetry, Temperature, ReallEvent, CurPending, OfflineUnc, SoftRead, DiskShift, _
        Micron, Indilinx, Intel, Samsung, SandForce, Errors As String
End Structure

Public Structure Warnings
    Dim Warning, Link1, Link2, Link3 As String
End Structure

Public Structure PollingTimes
    Dim OfflineData, ShortTest, ExtendedTest, ConveyanceTest As String
End Structure

Public Structure Revisions
    Dim AttributesTable, ErrorLog, SelfTestLog, SelectiveSelfTestLog As String
End Structure

Public Structure TestTiming
    Dim Start, Conclusion As Date
    Dim Duration As Integer
End Structure

Public Structure VirtualDeviceInfo
    Dim Description, Model, UserSize, SerialNumber, Firmware As String
End Structure

Public Structure Ratings
    Dim Overall, _
        Errors, OfflineUncorrectable, ReallocationCount, CurrentPending, _
        Indilinx, Intel, Micron, Samsung, SandForce As Short
End Structure

Public Structure Log
    Dim Year, Month, Day, Hour, EventName, OldValue, NewValue, Variation As String
End Structure

<Flags()> _
Public Enum Status
    Unkonwn = 0
    Passed = 1
    Failed = 2
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

<Flags()> _
Public Enum TestType
    Abort = 0
    Offline = 1
    ShortTest = 2
    LongTest = 3
    Conveyance = 4
    ScsiLongTest = 5
End Enum

<Flags()> _
Public Enum Feature
    Disable = 0
    Enable = 1
    Unavailable = 2
    Unknown = 3
End Enum