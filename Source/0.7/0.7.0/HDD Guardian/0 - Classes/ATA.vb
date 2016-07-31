'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2015 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class ATA

    Private smartctl As New Console
    Private m_output() As String
    Private m_isoptical As Boolean = False
    Private m_type As DeviceType
    Private m_info As AtaInfo

    Public Sub New(ByVal location As String, ByVal type As DeviceType, Optional ByVal loadsettings As Boolean = True)

        If location.Contains("/dev/") Then
            'a real device: smartctl is executed for recover infos about it
            m_output = smartctl.SendCmd("-i " & location)
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
            checkifoptical = Nothing
        End If

        If Not m_isoptical Then
            If Not IsNothing(m_output) Then

                m_info = New AtaInfo(m_output, type)

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
                .Location = m_location
            End With
            UpdateTrayIcon()
        End If
    End Sub

    Public ReadOnly Property Info As AtaInfo
        Get
            Return m_info
        End Get
    End Property


#Region "Device information"
    Public Class AtaInfo

        Private m_output() As String
        Private m_type As DeviceType
        Private m_doubledeck As String
        Private m_modelfamily, m_devicemodel, m_serialnumber As String
        Private m_firmware, m_size As String
        Private m_ataversion, m_atastandard
        Private m_wwn, m_sectorsize As String
        Private m_lastcheck As String
        Private m_indatabase As Boolean
        Private m_healthpassed As Status = Status.Unkonwn
        Private m_sataversion As String
        Private m_rotation As String
        Private m_ssd As Boolean = False
        Private m_form As String = "N/A"
        Private m_warnings As Warnings
        Private m_isvalid As Boolean = True

        Public Sub New(ByVal output() As String, ByVal type As DeviceType)
            m_output = output
            m_type = type
            m_doubledeck = CheckDoubleDeck()
            m_modelfamily = GetInfo(m_output, "Model Family")
            m_devicemodel = GetInfo(m_output, "Device Model")
            m_serialnumber = GetInfo(m_output, "Serial Number")
            m_firmware = GetInfo(m_output, "Firmware Version")
            Dim size As String = GetInfo(m_output, "User Capacity")
            Dim s() As String = size.Split("bytes")
            m_size = ToNumber(s(0))
            size = Nothing
            s = Nothing
            If m_size = "" Then m_size = "N/A"
            Dim db As String = GetInfo(m_output, "Device is")
            If db.Contains("Not") Then m_indatabase = False Else m_indatabase = True
            db = Nothing
            m_ataversion = GetInfo(m_output, "ATA Version is")
            m_atastandard = GetInfo(m_output, "ATA Standard is")
            m_sataversion = GetInfo(m_output, "SATA Version is")
            m_rotation = GetInfo(m_output, "Rotation Rate")
            If m_rotation.Contains("Solid State Device") Then m_ssd = True
            m_form = GetInfo(m_output, "Form Factor").ToString.Replace(" inches", """")
            m_wwn = GetInfo(m_output, "LU WWN Device Id")
            m_sectorsize = GetInfo(m_output, "Sector Size")

            'get the eventual warning message
            Dim w As Integer = GetIndexOf(m_output, "==> WARNING:")
            Dim txt As String = "", lnk1 As String = "", lnk2 As String = "", lnk3 As String = ""
            Dim lnkcount As Short = 0
            If w > 0 Then
                For i As Integer = w To m_output.Length - 1
                    If m_output(i).Trim.Length = 0 Then Exit For

                    Dim t As String = m_output(i)

                    If Not t.Contains("http") Then
                        If t.Contains("==>") Then
                            txt = GetInfo(m_output, "==> WARNING")
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
                                    alert = Nothing
                                End If
                            Case 2
                                lnk2 = m_output(i)
                            Case 3
                                lnk3 = m_output(i)
                        End Select
                    End If
                    t = Nothing
                Next
            End If
            With m_warnings
                .Warning = txt
                .Link1 = lnk1.Replace(vbCr, "").Replace(vbLf, "")
                .Link2 = lnk2.Replace(vbCr, "").Replace(vbLf, "")
                .Link3 = lnk3.Replace(vbCr, "").Replace(vbLf, "")
            End With
            w = Nothing
            txt = Nothing
            lnk1 = Nothing
            lnk2 = Nothing
            lnk3 = Nothing
            lnkcount = Nothing

            m_isvalid = CheckIfValid()
        End Sub

        Private Function CheckDoubleDeck() As Boolean
            For i As Short = 0 To m_output.Length - 2
                If m_output(i).Contains("Two devices connected, try '-d usbjmicron,[01]") Then
                    Return True
                End If
            Next
            Return False
        End Function

        Private Function CheckIfValid() As Boolean
            If Not IsNothing(m_devicemodel) Then
                If m_devicemodel.Contains("My Book") Then
                    Return False
                End If
            End If
            For i As Short = 0 To m_output.Length - 2
                If m_output(i).Contains("START OF INFORMATION SECTION") Then
                    Return True
                End If
            Next
            Return False
        End Function

        Public ReadOnly Property Family As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "N/A"
                Return m_modelfamily
            End Get
        End Property

        Public ReadOnly Property Model As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "3ware clipboard"
                Return m_devicemodel
            End Get
        End Property

        Public ReadOnly Property SerialNumber As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "N/A"
                Return m_serialnumber
            End Get
        End Property

        Public ReadOnly Property WorldWideName As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "N/A"
                Return m_wwn
            End Get
        End Property

        Public ReadOnly Property FirmwareVersion As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "N/A"
                Return m_firmware
            End Get
        End Property

        Public ReadOnly Property UserCapacity As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "N/A"
                Return m_size
            End Get
        End Property

        Public ReadOnly Property SectorSize As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "N/A"
                Return m_sectorsize
            End Get
        End Property

        Public ReadOnly Property RotationRate As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "N/A"
                Return m_rotation
            End Get
        End Property

        Public ReadOnly Property InDatabase As Boolean
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return False
                Return m_indatabase
            End Get
        End Property

        Public ReadOnly Property AtaVersion As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "N/A"

                If m_atastandard <> "N/A" Then
                    Return m_ataversion & " (" & m_atastandard & ")"
                Else
                    Return m_ataversion
                End If
            End Get
        End Property

        Public ReadOnly Property SataVersion As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "N/A"
                Return m_sataversion
            End Get
        End Property

        Public ReadOnly Property LastCheck As String
            Get
                If m_type = DeviceType.Threeware And Not m_isvalid Then Return "N/A"

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
                    months = Nothing
                    Dim dt As DateTime
                    If DateTime.TryParseExact(newdate, "dddd MMMM dd HH mm ss yyyy", Nothing, Nothing, dt) Then
                        Return FormatDateTime(dt, DateFormat.LongDate) & ", " & FormatDateTime(dt, DateFormat.LongTime)
                    Else
                        newdate = Nothing
                        Return m_lastcheck
                    End If
                Else
                    months = Nothing
                    newdate = Nothing
                    Return "N/A"
                End If
            End Get
        End Property
    End Class
#End Region

#Region "Device features"
    Public Class AtaFeatures

        Private m_output() As String
        Private m_location As String
        Private m_type As DeviceType
        Private m_smart As AtaSmart 'available, m_smartenabled As Support
        Private m_aam As AtaAam
        Private m_apm As AtaApm
        'Private m_aam, m_recommendedaam, m_apm,
        Private m_standby As Short
        'Private m_aamstatus, m_apmstatus,
        Private m_cache, m_lookahead, m_cachereorder As Feature

        Public Sub New(ByVal output() As String, ByVal type As DeviceType, ByVal location As String)
            m_output = output
            m_location = location
            m_type = type

            m_smart = New AtaSmart(output, type, location)
            m_aam = New AtaAam(output, location)
            m_apm = New AtaApm(output, location)

            'get features included in smartctl 5.43
            Dim lookahead As String = GetInfo(m_output, "Rd look-ahead is")
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
            lookahead = Nothing

            Dim cache As String = GetInfo(m_output, "Write cache is")
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
            cache = Nothing

            'get new feature included in smartctl 6.2
            Dim reorder As String = GetInfo(m_output, "Wt Cache Reorder")
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
            reorder = Nothing
        End Sub

        Public ReadOnly Property LookAhead As Feature
            Get
                Return m_lookahead
            End Get
        End Property

        Public ReadOnly Property WriteCache As Feature
            Get
                Return m_cache
            End Get
        End Property

        Public ReadOnly Property CacheReorder As Feature
            Get
                Return m_cachereorder
            End Get
        End Property

        Public ReadOnly Property Smart As AtaSmart
            Get
                Return m_smart
            End Get
        End Property

        Public ReadOnly Property Aam As AtaAam
            Get
                Return m_aam
            End Get
        End Property

        Public ReadOnly Property Apm As AtaApm
            Get
                Return m_apm
            End Get
        End Property

#Region "SMART class"
        Public Class AtaSmart

            Private m_available As Support
            Private m_enabled As Boolean
            Private m_output() As String
            Private m_type As DeviceType
            Private m_location As String

            Public Sub New(ByVal output() As String, ByVal type As DeviceType, ByVal location As String)
                m_output = output
                m_type = type
                m_location = location

                Dim support As String = GetInfo(output, "SMART support is")
                If support.Contains("Available") Then
                    m_available = hdd_guardian.Support.Available
                ElseIf support.Contains("Ambiguous") Then
                    m_available = hdd_guardian.Support.Ambiguous
                Else
                    m_available = hdd_guardian.Support.Unavailable
                End If
                support = Nothing
                Dim enabled As String = GetInfo(output, "SMART support is: Enabled")
                If enabled.Contains("Enabled") Then
                    m_enabled = True ' hdd_guardian.Support.Enabled
                Else
                    m_enabled = False ' hdd_guardian.Support.Disabled
                End If
                enabled = Nothing
            End Sub

            Private Function IsValid() As Boolean
                Dim m_devicemodel = GetInfo(m_output, "Device Model")
                If Not IsNothing(m_devicemodel) Then
                    If m_devicemodel.Contains("My Book") Then
                        Return False
                    End If
                End If
                For i As Short = 0 To m_output.Length - 2
                    If m_output(i).Contains("START OF INFORMATION SECTION") Then
                        Return True
                    End If
                Next
                Return False
            End Function

            Public ReadOnly Property Available As Support
                Get
                    If m_type = DeviceType.Threeware And Not IsValid() Then Return Support.Unavailable
                    Return m_available
                End Get
            End Property

            Public Property Enabled As Boolean
                Get
                    If m_type = DeviceType.Threeware And Not IsValid() Then Return Support.Unavailable
                    Return m_enabled
                End Get
                Set(value As Boolean)
                    If m_type = DeviceType.ATA Then
                        Dim smartctl As New Console

                        If value = SmartFeature.Enable Then
                            Dim feature() As String = smartctl.SendCmd("-s on " & m_location)
                        Else
                            Dim feature() As String = smartctl.SendCmd("-s off " & m_location)
                        End If
                    End If
                End Set
            End Property

        End Class
#End Region

#Region "AAM class"
        Public Class AtaAam
            Private m_value As Short
            Private m_status As Feature
            Private m_recommended As Short
            Private m_location As String

            Public Sub New(ByVal output() As String, ByVal location As String)
                m_location = location

                Dim aamfeature As String = GetInfo(output, "AAM feature is")
                If aamfeature <> "N/A" Then
                    If aamfeature.Contains("Disabled") Then
                        m_status = Feature.Disable
                    ElseIf aamfeature.Contains("Unavailable") Then
                        m_status = Feature.Unavailable
                    End If
                Else
                    Dim aam As String = GetInfo(output, "AAM level is")
                    If aam <> "N/A" Then
                        Dim arr_aam() As String = aam.Split(":")
                        Dim arr_value() As String = arr_aam(0).Split(" ")
                        m_value = arr_value(0)
                        m_recommended = arr_aam(1)
                        m_status = Feature.Enable
                        arr_aam = Nothing
                        arr_value = Nothing
                    Else
                        m_status = Feature.Unknown
                    End If
                    aam = Nothing
                End If
                aamfeature = Nothing
            End Sub

            Public Property Value As Short
                Get
                    Return m_value
                End Get
                Set(ByVal value As Short)
                    Dim smartctl As New Console
                    smartctl.SendCmd("-s aam," & value & " " & m_location)
                End Set
            End Property

            Public ReadOnly Property Recommended As Short
                Get
                    Return m_recommended
                End Get
            End Property

            Public ReadOnly Property Status As Feature
                Get
                    Return m_status
                End Get
            End Property
        End Class
#End Region

#Region "APM class"
        Public Class AtaApm
            Private m_value As Short
            Private m_status As Feature
            Private m_location As String

            Public Sub New(ByVal output() As String, ByVal location As String)
                m_location = location

                Dim apmfeature As String = GetInfo(output, "APM feature is")
                If apmfeature <> "N/A" Then
                    If apmfeature.Contains("Disabled") Then
                        m_status = Feature.Disable
                    ElseIf apmfeature.Contains("Unavailable") Then
                        m_status = Feature.Unavailable
                    End If
                Else
                    Dim apm As String = GetInfo(output, "APM level is")
                    If apm <> "N/A" Then
                        Dim arr_apm() As String = apm.Split(" ")
                        m_value = arr_apm(0)
                        m_status = Feature.Enable
                        arr_apm = Nothing
                    Else
                        m_status = Feature.Unknown
                    End If
                    apm = Nothing
                End If
                apmfeature = Nothing
            End Sub

            Public Property Value As Short
                Get
                    Return m_value
                End Get
                Set(ByVal value As Short)
                    Dim smartctl As New Console
                    smartctl.SendCmd("-s apm," & value & " " & m_location)
                End Set
            End Property

            Public ReadOnly Property Status As Feature
                Get
                    Return m_status
                End Get
            End Property
        End Class
#End Region

    End Class
#End Region

#Region "Device data"
    Public Class AtaData

        Private m_output() As String

        
        'Private m_modelfamily, m_devicemodel As String
        
        Private m_errors As AtaErrorLog
        Private m_attributes As AtaAttributes

        Sub New(ByVal output() As String)
            m_output = output
            'm_modelfamily = GetInfo(m_output, "Model Family")
            'm_devicemodel = GetInfo(m_output, "Device Model")


            m_errors = New AtaErrorLog(m_output)
            m_attributes = New AtaAttributes(m_output)

            'GetAttributes()

            GetSelfTest()
            GetSelective()
            GetTemperatures()
        End Sub

        Public ReadOnly Property Errors As AtaErrorLog
            Get
                Return m_errors
            End Get
        End Property

#Region "Attributes table"
        Public Class AtaAttributes
            Public Structure AtaVitals
                Dim Now As Vitals
                Dim Before As Vitals
                Dim Variation As Vitals
            End Structure

            Private m_vitalslog As New List(Of Log)
            Private m_output() As String
            Private m_devicemodel As String
            Private m_modelfamily As String
            Private m_serialnumber As String
            Private m_attributes As New List(Of Attribute)
            Private m_oldvitals, m_newvitals, m_vitals As Vitals
            Private m_temperature As String = "N/A"
            Private m_id5threshold As String
            Private m_badsectors As String = "N/A"
            Private m_ssd As Boolean = False
            Private m_remaininglife As String = "N/A"
            Private m_worktime As String = "N/A"
            Private m_worktimehuman As String = "N/A"
            Private m_vitallist As New AtaVitals
            Private m_devicefilename As String
            Private m_savelog As Boolean = False

            Public Sub New(ByVal output() As String)
                m_output = output
                m_modelfamily = GetInfo(m_output, "Model Family")
                m_devicemodel = GetInfo(m_output, "Device Model")
                m_serialnumber = GetInfo(m_output, "Serial Number")
                m_devicefilename = GenerateDeviceFileName()

                GetAttributes()

            End Sub

            Private Function GetRawValue(ByVal attribute() As String) As String
                If attribute.Length = 10 Then
                    Return attribute(9)
                Else
                    Return attribute(7)
                End If
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

            Private Function GenerateDeviceFileName() As String
                'this routine create the file name string and skip all non valid characters
                Dim fns As String = m_devicemodel & "_" & m_serialnumber

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

            Private Function GetNormalizedValue(ByVal attribute() As String) As String
                Return attribute(3)
            End Function

            Private Function GetThresholdValue(ByVal attribute() As String) As String
                Dim value As String = attribute(5)

                If IsNumeric(value) Then
                    Return value
                Else
                    Dim newvalue As String = Nothing

                    Dim re5 As New Regex("^(ExcelStor|Hitachi|HD|HU|HT|HE|HD|IBM|IC|DT).*", RegexOptions.IgnoreCase)
                    If re5.Match(m_devicemodel).Success Or re5.Match(m_modelfamily).Success Then newvalue = "5"
                    re5 = Nothing

                    Dim re10 As New Regex("^Samsung.*", RegexOptions.IgnoreCase)
                    If re10.Match(m_devicemodel).Success Or re10.Match(m_modelfamily).Success Then newvalue = "10"
                    re10 = Nothing

                    Dim re20 As New Regex("^Quantum.*", RegexOptions.IgnoreCase)
                    If re20.Match(m_devicemodel).Success Or re20.Match(m_modelfamily).Success Then newvalue = "20"
                    re20 = Nothing

                    Dim re24 As New Regex("^Fujitsu.*", RegexOptions.IgnoreCase)
                    If re24.Match(m_devicemodel).Success Or re24.Match(m_modelfamily).Success Then newvalue = "24"
                    re24 = Nothing

                    Dim re36 As New Regex("^(Seagate|ST(1|2|3|5|7|6|9)).*", RegexOptions.IgnoreCase)
                    If re36.Match(m_devicemodel).Success Or re36.Match(m_modelfamily).Success Then newvalue = "36"
                    re36 = Nothing

                    Dim re50 As New Regex("^(Toshiba|TOS).*", RegexOptions.IgnoreCase)
                    If re50.Match(m_devicemodel).Success Or re50.Match(m_modelfamily).Success Then newvalue = "50"
                    re50 = Nothing

                    Dim re63 As New Regex("^(Maxtor|STM).*", RegexOptions.IgnoreCase)
                    If re63.Match(m_devicemodel).Success Or re63.Match(m_modelfamily).Success Then newvalue = "63"
                    re63 = Nothing

                    Dim re140 As New Regex("^WDC.*", RegexOptions.IgnoreCase)
                    If re140.Match(m_devicemodel).Success Or re140.Match(m_modelfamily).Success Then newvalue = "140"
                    re140 = Nothing

                    If IsNothing(newvalue) Then
                        Return "0"
                    Else
                        Return newvalue
                    End If
                End If
            End Function

            Private Sub AtaWorkTime(ByVal wt As String)
                Dim t As Integer
                If Not IsNumeric(wt) Then
                    Dim tt() As String = wt.Split("h")
                    t = Val(tt(0))
                    If m_modelfamily.Contains("Intel 520") And t > 894794 Then
                        t = t - 894794
                    End If
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
                    arr = Nothing

                    Return val
                End If
            End Function

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
                            If m_output(ri).Contains("9 Power_On") Then AtaWorkTime(GetRawValue(attr))

                            If m_output(ri).Contains("10 Spin_Retry_Count") Then m_newvitals.SpinRetry = GetRawValue(attr)
                            If m_output(ri).Contains("196 Reallocated_Event_Count") Then
                                If m_output(ri).Contains("(") Then
                                    Dim str() As String = GetRawValue(attr).Split("(")
                                    m_newvitals.ReallEvent = str(0).Trim
                                Else
                                    m_newvitals.ReallEvent = GetRawValue(attr)
                                End If
                            End If
                            If m_output(ri).Contains("197 Current_Pending_Sector") Then
                                If m_output(ri).Contains("(") Then
                                    Dim str() As String = GetRawValue(attr).Split("(")
                                    m_newvitals.CurPending = str(0).Trim
                                Else
                                    m_newvitals.CurPending = GetRawValue(attr)
                                End If
                            End If
                            If m_output(ri).Contains("197 Total_Pending_Sectors") Then 'appears in some Samsung devices
                                If m_output(ri).Contains("(") Then
                                    Dim str() As String = GetRawValue(attr).Split("(")
                                    m_newvitals.CurPending = str(0).Trim
                                Else
                                    m_newvitals.CurPending = GetRawValue(attr)
                                End If
                            End If
                            If m_output(ri).Contains("198 Offline_Uncorrectable") Then
                                If m_output(ri).Contains("(") Then
                                    Dim str() As String = GetRawValue(attr).Split("(")
                                    m_newvitals.OfflineUnc = str(0).Trim
                                Else
                                    m_newvitals.OfflineUnc = GetRawValue(attr)
                                End If
                            End If
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

                CompareVitals()

                m_vitallist.Now = m_newvitals
                m_vitallist.Before = m_oldvitals
                m_vitallist.Variation = m_vitals

            End Sub

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
                    If Not m_savelog Then Exit Sub
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
                    Main.PrintDebug("Encountered an error while saving " & m_devicemodel & " log: " & e.ToString, True)
                End Try
            End Sub

            Public ReadOnly Property Attributes As List(Of Attribute)
                Get
                    Return m_attributes
                End Get
            End Property

            Public ReadOnly Property Temperature As String
                Get
                    Return m_temperature
                End Get
            End Property

            Public ReadOnly Property Vitals As AtaVitals
                Get
                    Return m_vitallist
                End Get
            End Property

            Public ReadOnly Property RemainingLife As String
                Get
                    If m_type = DeviceType.Threeware And Not m_isvaliddevice Then Return "N/A"
                    Return m_remaininglife
                End Get
            End Property

            Public ReadOnly Property BadSectorsCount As String
                Get
                    If m_type = DeviceType.Threeware And Not m_isvaliddevice Then Return "N/A"
                    Return m_badsectors
                End Get
            End Property

            Public Property SaveLog As Boolean
                Get
                    Return m_savelog
                End Get
                Set(value As Boolean)
                    m_savelog = value
                End Set
            End Property

        End Class
#End Region

#Region "Error log"
        Public Class AtaErrorLog
            Private m_errors As New List(Of SmartError)
            Private m_totalerrors As String
            Private m_output() As String
            Private m_version As String

            Public Sub New(ByVal output() As String)
                m_output = output
                GetRevision()
                GetErrors()
            End Sub

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

            Private Sub GetRevision()
                Dim i As Short

                i = GetIndexOf("SMART Error Log Version")
                If i > 0 Then
                    Dim rev() As String = m_output(i).Split(":")
                    m_version = rev(1).Trim
                Else
                    m_version = "N/A"
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

                Dim tot As String = GetInfo(m_output, "ATA Error Count")

                If tot = "N/A" Then
                    m_totalerrors = 0
                    'm_newvitals.Errors = 0
                    Exit Sub
                Else
                    Dim last As Integer = Val(tot)
                    m_totalerrors = last
                    'm_newvitals.Errors = last
                    Dim first As Integer
                    If last < 6 Then first = 1 Else first = last - 4


                    m_errors.Clear()

                    For i As Long = last To last - 4 Step -1
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
            End Sub

            Public ReadOnly Property Log As List(Of SmartError)
                Get
                    Return m_errors
                End Get
            End Property

            Public ReadOnly Property Total As String
                Get
                    Return m_totalerrors
                End Get
            End Property

            Public ReadOnly Property Version As String
                Get
                    Return m_version
                End Get
            End Property
        End Class
#End Region

#Region "Self-test log"
        Private m_selftests As New List(Of SelfTest)
        Private m_lasttest As LastTest

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

            Dim i As Integer = GetIndexOf(m_output, "SMART Self-test log")
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

                'here are gathered the last test values
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
#End Region

#Region "Selective self-test log"
        Private m_selectives As New List(Of Selectives)

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
#End Region

#Region "Temperatures"
        Private m_temperatures As Temperatures

        Private Sub GetTemperatures()
            Dim temps As Temperatures

            Dim cycle As String = GetInfo(m_output, "Power Cycle Min/Max Temperature").Replace("Celsius", "").Trim
            Dim life As String = GetInfo(m_output, "Lifetime    Min/Max Temperature").Replace("Celsius", "").Trim
            Dim rec As String = GetInfo(m_output, "Min/Max recommended Temperature").Replace("Celsius", "").Trim
            Dim limit As String = GetInfo(m_output, "Min/Max Temperature Limit").Replace("Celsius", "").Trim

            If cycle <> "N/A" Then
                Dim arr() As String = cycle.Split("/")
                temps.CycleMin = arr(0).Trim
                temps.CycleMax = arr(1).Trim
            Else
                temps.CycleMin = cycle
                temps.CycleMax = cycle
            End If

            If life <> "N/A" Then
                Dim arr() As String = life.Split("/")
                temps.LifetimeMin = arr(0).Trim
                temps.LifetimeMax = arr(1).Trim
            Else
                temps.LifetimeMin = life
                temps.LifetimeMax = life
            End If

            If rec <> "N/A" Then
                Dim arr() As String = rec.Split("/")
                temps.RecommendedMin = arr(0).Trim
                temps.RecommendedMax = arr(1).Trim
            Else
                temps.RecommendedMin = rec
                temps.RecommendedMax = rec
            End If

            If limit <> "N/A" Then
                Dim arr() As String = limit.Split("/")
                temps.LimitMin = arr(0).Trim
                temps.LimitMax = arr(1).Trim
            Else
                temps.LimitMin = limit
                temps.LimitMax = limit
            End If

            m_temperatures = temps
        End Sub
#End Region

    End Class
#End Region

End Class
