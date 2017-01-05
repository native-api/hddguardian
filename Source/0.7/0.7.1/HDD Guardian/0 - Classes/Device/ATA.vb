'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System.Xml

Partial Class Device

#Region "ATA variables"
    Private _ataDevice As AtaDevice

    Private ataModelFamily, ataDeviceModel, ataSerialNumber As String
    Private ataFirmware, ataSize As String
    Private ataVersion, ataStandard As String
    Private ataWwn, ataSectorSize As String
    Private ataInDatabase As Boolean
    Private ataWarnings As AtaWarning
    Private ataForm As String = "N/A"
    Private ataAam, ataRecommendedAam, ataApm, ataStandby As String
    Private ataAamStatus, ataApmStatus, ataCache, ataLookAhead, ataCacheReorder As Feature
    Private ataSataVersion As String
    Private ataRotation As String
    Private ataOfflineAuto As Support
    Private ataAttributes As New List(Of AtaAttribute)
    Private ataAttributesRevision As String
    Private ataErrors As New List(Of AtaError)
    Private ataErrorLogVer As String
    Private ataErrorLogSupported As Boolean
    Private ataTotalErrors As String
    Private ataSelfTests As New List(Of AtaSelfTest)
    Private ataSelfTestVersion As String
    Private ataSelfTestSupported As Boolean
    Private ataRemainingLife As String = "N/A"
    Private ataIsSsd As Boolean = False
    Private ataBadSectorsThreshold As Short = 256 'usually HDD's spare area is from 256 to 1024 (or 2560) sectors
    Private ataBadSectors As String = "N/A"
    Private ataOldVitals, ataNewVitals, ataVitals As AtaVitalParameters
    Private ataTemps As Temperatures
    Private ataDoubleDeck As Boolean = False
    Private ataWorkTime As String = "N/A"
    Private ataWorkTimeHuman As String = "N/A"
    Private ataRating As AtaRatings
    Private ataOfflineTest, ataShortTest, ataLongTest, ataConveyanceTest As String
#End Region

#Region "ATA data processors"

    Private Sub GetDeviceInfo()
        If devOutput.Length > 0 Then
            ataModelFamily = GetInfo("Model Family")
            ataDeviceModel = GetInfo("Device Model").Replace("VID:90", "")
            ataSerialNumber = GetInfo("Serial Number")
            ataFirmware = GetInfo("Firmware Version")
            Dim size As String = GetInfo("User Capacity")
            Dim s() As String = size.Split("bytes")
            ataSize = ToNumber(s(0))
            size = Nothing
            s = Nothing
            If ataSize = "" Then ataSize = "N/A"
            Dim db As String = GetInfo("Device is")
            If db.Contains("Not") Then ataInDatabase = False Else ataInDatabase = True
            db = Nothing
            ataVersion = GetInfo("ATA Version is")
            ataStandard = GetInfo("ATA Standard is")
            ataSataVersion = GetInfo("SATA Version is")
            ataRotation = GetInfo("Rotation Rate")
            If ataRotation.Contains("Solid State Device") Then ataIsSsd = True
            Dim support As String = GetInfo("SMART support is")
            If support.Contains("Available") Then
                devSmartAvailable = hdd_guardian.Support.Available
            ElseIf support.Contains("Ambiguous") Then
                devSmartAvailable = hdd_guardian.Support.Ambiguous
            Else
                devSmartAvailable = hdd_guardian.Support.Unavailable
            End If
            support = Nothing
            Dim enabled As String = GetInfo("SMART support is: Enabled")
            If enabled.Contains("Enabled") Then
                devSmartEnabled = hdd_guardian.Support.Enabled
            Else
                devSmartEnabled = hdd_guardian.Support.Disabled
            End If
            enabled = Nothing

            ataForm = GetInfo("Form Factor").ToString.Replace(" inches", """")

            ataWwn = GetInfo("LU WWN Device Id")
            ataSectorSize = GetInfo("Sector Size")

            'get features included in smartctl 5.43
            Dim aamfeature As String = GetInfo("AAM feature is")
            If aamfeature <> "N/A" Then
                If aamfeature.Contains("Disabled") Then
                    ataAamStatus = Feature.Disabled
                ElseIf aamfeature.Contains("Unavailable") Then
                    ataAamStatus = Feature.Unavailable
                End If
            Else
                Dim aam As String = GetInfo("AAM level is")
                If aam <> "N/A" Then
                    Dim arr_aam() As String = aam.Split(":")
                    Dim arr_value() As String = arr_aam(0).Split(" ")
                    ataAam = arr_value(0)
                    ataRecommendedAam = arr_aam(1)
                    ataAamStatus = Feature.Enabled
                    arr_aam = Nothing
                    arr_value = Nothing
                End If
                aam = Nothing
            End If
            aamfeature = Nothing

            Dim apmfeature As String = GetInfo("APM feature is")
            If apmfeature <> "N/A" Then
                If apmfeature.Contains("Disabled") Then
                    ataApmStatus = Feature.Disabled
                ElseIf apmfeature.Contains("Unavailable") Then
                    ataApmStatus = Feature.Unavailable
                End If
            Else
                Dim apm As String = GetInfo("APM level is")
                If apm <> "N/A" Then
                    Dim arr_apm() As String = apm.Split(" ")
                    ataApm = arr_apm(0)
                    ataApmStatus = Feature.Enabled
                    arr_apm = Nothing
                End If
                apm = Nothing
            End If
            apmfeature = Nothing

            Dim lookahead As String = GetInfo("Rd look-ahead is")
            If lookahead <> "N/A" Then
                If lookahead.Contains("Disabled") Then
                    ataLookAhead = Feature.Disabled
                ElseIf lookahead.Contains("Unavailable") Then
                    ataLookAhead = Feature.Unavailable
                Else
                    ataLookAhead = Feature.Enabled
                End If
            End If
            lookahead = Nothing

            Dim cache As String = GetInfo("Write cache is")
            If cache <> "N/A" Then
                If cache.Contains("Disabled") Then
                    ataCache = Feature.Disabled
                ElseIf cache.Contains("Unavailable") Then
                    ataCache = Feature.Unavailable
                Else
                    ataCache = Feature.Enabled
                End If
            End If
            cache = Nothing

            'get new feature included in smartctl 6.2
            Dim reorder As String = GetInfo("Wt Cache Reorder")
            If reorder <> "N/A" Then
                If reorder.Contains("Disabled") Then
                    ataCacheReorder = Feature.Disabled
                ElseIf reorder.Contains("Unavailable") Then
                    ataCacheReorder = Feature.Unavailable
                Else
                    ataCacheReorder = Feature.Enabled
                End If
            End If
            reorder = Nothing

            'get the eventual warning message
            Dim w As Integer = GetIndexOf("==> WARNING:")
            Dim txt As String = "", lnks(2) As String
            Dim lnkcount As Short = 0
            lnks(0) = ""
            lnks(1) = ""
            lnks(2) = ""
            If w > 0 Then
                For i As Integer = w To devOutput.Length - 1
                    If devOutput(i).Trim.Length = 0 Then Exit For

                    Dim t As String = devOutput(i)

                    If Not t.Contains("http") Then
                        If t.Contains("==>") Then
                            txt = GetInfo("==> WARNING")
                        Else
                            txt = txt & " " & devOutput(i)
                        End If
                    Else
                        lnkcount += 1
                        Select Case lnkcount
                            Case 1
                                If devOutput(i).StartsWith("http") Then
                                    lnks(0) = devOutput(i)
                                Else
                                    Dim alert() As String = devOutput(i).Split(" ")
                                    For a As Integer = 0 To alert.Length - 1
                                        If alert(a).Contains("http") Then
                                            lnks(0) = alert(a)
                                            Exit For
                                        Else
                                            txt = txt & " " & alert(a)
                                        End If
                                    Next
                                    alert = Nothing
                                End If
                            Case 2
                                lnks(1) = devOutput(i)
                            Case 3
                                lnks(2) = devOutput(i)
                        End Select
                    End If
                    t = Nothing
                Next
            End If
            ataWarnings = New AtaWarning(txt, lnks)
            txt = Nothing
            lnks = Nothing
        End If
    End Sub

    Private Sub GetHealth()
        Dim i As Integer = GetIndexOf("SMART overall-health")
        If i > 0 Then
            Dim h As String = devOutput(i)
            If h.Contains("PASSED") Then
                devHealth = Status.Passed
            ElseIf h.Contains("FAILED") Then
                devHealth = Status.Failed
            Else
                devHealth = Status.Unknown
            End If
            h = Nothing
        Else
            devHealth = Status.Unknown
        End If
    End Sub

    Private Sub GetCapabilities()
        Dim s As Integer = GetIndexOf("General SMART Values") + 1
        Dim e As Integer = GetIndexOf("SMART Attributes Data Structure") - 2

        'get offline data collection status
        Dim status As String = GetInfo("Auto Offline Data Collection")
        If status.Contains("Enabled") Then
            ataOfflineAuto = Support.Enabled
        Else
            ataOfflineAuto = Support.Disabled
        End If
        status = Nothing

        For i As Integer = s To e
            Dim curr As Short = GetIndexOf("(", i)
            Dim nxt As Short = GetIndexOf("(", i + 1) - 1
            If nxt = 0 Or nxt > e Or nxt < curr Then nxt = e

            Dim cap As New DevCapabilities
            For ci As Short = curr To nxt
                Dim currow() As String = devOutput(ci).
                Replace("(", "|").Replace(")", "|").Replace(ControlChars.Tab, "").
                Split("|", 3, StringSplitOptions.RemoveEmptyEntries)

                With cap
                    If currow.Length = 3 Then
                        Dim firstpart As String = ""
                        If ci > s And Not devOutput(ci - 1).Contains(".") Then firstpart = devOutput(ci - 1).Replace(vbLf, "") & " "
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
            cap = Nothing
            curr = Nothing
            nxt = Nothing
        Next

        s = Nothing
        e = Nothing
    End Sub

    Private Sub Reliability()
        'This sub calculate a 5 star rating reliability of disk, based upon ID 5, 196, 197 and 198.
        'ATA errors from version 0.6.2 are displayed only for warning purposes.
        'For SSD devices report a 5 star rating based upon their health percentages
        '*** Note: run after GetAttributes and GetErrors routines! ***

        Dim id5 As String = ataNewVitals.ReallSect
        Dim id196 As String = ataNewVitals.ReallEvent
        Dim id197 As String = ataNewVitals.CurPending
        Dim id198 As String = ataNewVitals.OfflineUnc
        Dim r_5 As Double = 0
        Dim r_196 As Double = 0
        Dim r_197 As Double = 0
        Dim r_198 As Double = 0
        Dim divider As Short = 180
        'first, for each parameter are calculated the percentage value based upon
        'the threshold, then are calculated a rating from 0 to 5

        If Not IsNothing(id5) Then
            r_5 = Math.Round(id5 / Val(ataBadSectorsThreshold) * 100)
            If System.Double.IsNaN(r_5) Then r_5 = 0
            If r_5 > 100 Then r_5 = 100
            ataRating.ReallocationCount = Math.Round(5 - r_5 / 20)
            If ataRating.ReallocationCount < 1 Then ataRating.ReallocationCount = 1
        Else
            r_5 = 0
            ataRating.ReallocationCount = Nothing
            divider -= 42
        End If

        If Not IsNothing(id196) Then
            r_196 = Math.Round(id196 / AppSettings.Reliability.ReallocationEvents * 100)
            If System.Double.IsNaN(r_196) Then r_196 = 0
            If r_196 > 100 Then r_196 = 100
            ataRating.ReallocationEvents = Math.Round(5 - r_196 / 20)
            If ataRating.ReallocationEvents < 1 Then ataRating.ReallocationEvents = 1
        Else
            r_196 = 0
            ataRating.ReallocationEvents = Nothing
            divider -= 28
        End If

        If Not IsNothing(id197) Then
            r_197 = Math.Round(id197 / AppSettings.Reliability.PendingSectors * 100)
            If System.Double.IsNaN(r_197) Then r_197 = 0
            If r_197 > 100 Then r_197 = 100
            ataRating.CurrentPending = Math.Round(5 - r_197 / 20)
            If ataRating.CurrentPending < 1 Then ataRating.CurrentPending = 1
        Else
            r_197 = 0
            ataRating.CurrentPending = Nothing
            divider -= 32
        End If

        If Not IsNothing(id198) Then
            r_198 = Math.Round(id198 / AppSettings.Reliability.UncorrectableSectors * 100)
            If System.Double.IsNaN(r_198) Then r_198 = 0
            If r_198 > 100 Then r_198 = 100
            ataRating.OfflineUncorrectable = Math.Round(5 - r_198 / 20)
            If ataRating.OfflineUncorrectable < 1 Then ataRating.OfflineUncorrectable = 1
        Else
            r_198 = 0
            ataRating.OfflineUncorrectable = Nothing
            divider -= 78
        End If

        'the overall reliability are calculated adding a "gravity index" for each parameter
        'and then calculating a rating from 1 to 5
        If divider > 0 Then
            ataRating.Overall = Math.Round(5 - (r_5 * 2.1 + r_196 * 1.4 + r_197 * 1.6 + r_198 * 3.9) / divider)
            If ataRating.Overall < 1 Then ataRating.Overall = 1
        Else
            ataRating.Overall = -1
        End If
        'check if SSD vital parameters have stored a value and then calculate the rating
        'basic formula are: R=round(V/20)
        'values starts from 100 and goes to 0 (1 for Intel)
        With ataNewVitals
            If ataIsSsd Then ataRating.Overall = -1

            If Not IsNothing(.Micron) Then
                'here the formula is: R=round((100-V)/20)
                'because the value start from 0 and goes to 100
                ataRating.Overall = Math.Round(((100 - .Micron) / 20))
                ataRating.Micron = ataRating.Overall
            End If
            If Not IsNothing(.Intel) Then
                ataRating.Overall = Math.Round(.Intel / 20)
                ataRating.Intel = ataRating.Overall
            End If
            If Not IsNothing(.Indilinx) Then
                ataRating.Overall = Math.Round(.Indilinx / 20)
                ataRating.Indilinx = ataRating.Overall
            End If
            If Not IsNothing(.Samsung) Then
                ataRating.Overall = Math.Round(.Samsung / 20)
                ataRating.Samsung = ataRating.Overall
            End If
            If Not IsNothing(.SandForce) Then
                ataRating.Overall = Math.Round(.SandForce / 20)
                ataRating.SandForce = ataRating.Overall
            End If
        End With
        If ataRating.Overall > 5 Then ataRating.Overall = 5
        If devIsValid = False Then ataRating.Overall = -1

        id5 = Nothing
        id196 = Nothing
        id197 = Nothing
        id198 = Nothing
        r_5 = Nothing
        r_196 = Nothing
        r_197 = Nothing
        r_198 = Nothing
        divider = Nothing
    End Sub

    Private Sub WorkTimeAta(ByVal wt As String)
        Dim t As Integer
        If Not IsNothing(wt) Then
            If Not IsNumeric(wt) Then
                Dim tt() As String = wt.Split("h")
                t = Val(tt(0))
                If ataModelFamily.Contains("Intel 520") And t > 894794 Then
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
                ataWorkTime = t & " " & _h
            Else
                ataWorkTime = t & " " & _hh
            End If

            If y > 0 Then
                If y = 1 Then
                    ts += y & " " & _y
                Else
                    ts += y & " " & _yy
                End If
            End If

            If m > 0 Then
                If ts.Length > 0 And y > 0 Then ts += ", "
                If m = 1 Then
                    ts += m & " " & _m
                Else
                    ts += m & " " & _mm
                End If
            End If

            If d > 0 Then
                If ts.Length > 0 And (m > 0 Or y > 0) Then ts += ", "
                If d = 1 Then
                    ts += d & " " & _d
                Else
                    ts += d & " " & _dd
                End If
            End If

            If h > 0 Then
                If ts.Length > 0 And (m > 0 Or y > 0 Or d > 0) Then ts += ", "
                If h = 1 Then
                    ts += h & " " & _h
                Else
                    ts += h & " " & _hh
                End If
            End If

            ataWorkTimeHuman = ts
        Else
            ataWorkTime = "N/A"
            ataWorkTimeHuman = "N/A"
        End If
    End Sub

    Private Sub GetAttributes()
        'get all attributes

        'smartctl attribute table samples:
        'version 5.37 ************************************************************************************************
        '  1 Raw_Read_Error_Rate     POSR--   200   200   051    Pre-fail  Always       -       0
        'version from 5.38 to 5.40 ***********************************************************************************
        '  1 Raw_Read_Error_Rate     0x000e   100   253   006    Old_age   Always       -       0
        'version 5.39, with inconsistent identities: the following two lines before the attributes will be jumped ****
        '  2 Throughput_Performance  0x2600   000   000   000    Old_age   Offline  FAILING_NOW 281474959933440
        '  2 Throughput_Performance  <== Data Page      |  WARNING: PREVIOUS ATTRIBUTE HAS TWO
        '  0 Unknown_Attribute       <== Threshold Page |  INCONSISTENT IDENTITIES IN THE DATA
        'version 5.41, with option "-f brief" ************************************************************************
        '  1 Raw_Read_Error_Rate     POSR--   200   200   051    -    0

        Dim r As Integer = GetIndexOf("SMART Attributes Data Structure revision number")
        If r > 0 Then
            Dim rev() As String = devOutput(r).Split(":")
            ataAttributesRevision = rev(1).Trim
        Else
            ataAttributesRevision = "N/A"
        End If

        Dim i As Integer = GetIndexOf("ID#")
        Dim matchOld As String = "[0-9]{1,3}\s+[a-zA-Z0-9_ -]{23}\s+[-+POSRCKM]{6}\s+[0-9]{3}\s+[0-9]{3}\s+[0-9-]{3}\s+(Pre-fail|Old_age)\s+(Always|Offline)\s+(-|FAILING_NOW|In_the_past)\s+.*"
        Dim matchNew As String = "[0-9]{1,3}\s+[a-zA-Z0-9_ -]{23}\s+0x[0-9a-f]{4}\s+[0-9]{3}\s+[0-9]{3}\s+[0-9-]{3}\s+(Pre-fail|Old_age)\s+(Always|Offline)\s+(-|FAILING_NOW|In_the_past)\s+.*"
        Dim matchBrief As String = "[0-9]{1,3}\s+[a-zA-Z0-9_ -]{23}\s+[-+POSRCKM]{6}\s+[0-9]{3}\s+[0-9]{3}\s+[0-9-]{3}\s+(-|NOW|Past|FAILING_NOW|In_the_past)\s+.*"

        ataAttributes.Clear()

        If Not IsNothing(ataNewVitals) Then ataOldVitals = ataNewVitals

        If i > 0 Then
            For ri As Integer = i + 1 To devOutput.Length - 1
                Dim attr() As String = Nothing
                Dim reOld As New Regex(matchOld, RegexOptions.IgnoreCase)
                Dim reNew As New Regex(matchNew, RegexOptions.IgnoreCase)
                Dim reBrief As New Regex(matchBrief, RegexOptions.IgnoreCase)

                If reOld.Match(devOutput(ri).Trim).Success Or reNew.Match(devOutput(ri).Trim).Success Then
                    attr = devOutput(ri).Trim.Split(" ", 10, StringSplitOptions.RemoveEmptyEntries)
                ElseIf reBrief.Match(devOutput(ri).Trim).Success Then
                    attr = devOutput(ri).Trim.Split(" ", 8, StringSplitOptions.RemoveEmptyEntries)
                End If

                reOld = Nothing
                reNew = Nothing
                reBrief = Nothing

                If Not devOutput(ri).Contains("<==") Then
                    If IsNothing(attr) Then Exit For
                    If Not IsNumeric(attr(0)) Then Exit For

                    'temperature is get here...
                    If devOutput(ri).Contains("194 Temperature_Celsius") Then
                        Dim t() As String = GetRawValue(attr).Replace(vbCr, "").Replace(vbLf, "").Split("(")
                        Dim temp As String = Math.Round(Decimal.Parse(t(0).Trim, New Globalization.CultureInfo("en-US"))).ToString
                        devTemperature = temp
                        ataNewVitals.Temperature = temp

                        'this block is for correct a wrong temperature report in some OCZ Agility
                        'devices based upon SandForce interface: the device is not equipped with
                        'a thermal sensor but the raw value of temperature reports a fixed fake
                        'value of 128°C. Theorically a firmware update to version 2.15 solve this
                        'situation, changing the fixed value to 30°C, but sometimes this issue
                        'remains unsolved and HDD Guardian shows many alarms for nothing.
                        If ataDeviceModel.StartsWith("OCZ") And devTemperature.StartsWith("128") Then
                            devTemperature = "30"
                            ataNewVitals.Temperature = "30"
                        End If
                    End If

                    'if 194 attribute fails, is get the airflow temperature (attribute 190)
                    If Not IsNumeric(devTemperature) Then
                        If devOutput(ri).Contains("190 Airflow_Temperature_Cel") Then
                            Dim t() As String = GetRawValue(attr).Replace(vbCr, "").Replace(vbLf, "").Split("(")
                            Dim temp As String = Math.Round(Decimal.Parse(t(0).Trim, New Globalization.CultureInfo("en-US"))).ToString
                            devTemperature = temp
                            ataNewVitals.Temperature = temp
                        End If
                    End If

                    'vital parameters are get here, with only exception of temperature, see 3 row top if this
                    If devOutput(ri).Contains("5 Reallocated_Sector_Ct") Or devOutput(ri).Contains("5 Runtime_Bad_Block") Then
                        If devOutput(ri).Contains("(") Then
                            Dim str() As String = GetRawValue(attr).Split("(")
                            ataNewVitals.ReallSect = str(0).Trim
                            ataBadSectors = str(0).Trim
                        Else
                            ataNewVitals.ReallSect = GetRawValue(attr)
                            ataBadSectors = GetRawValue(attr)
                        End If
                    End If

                    'get the total working time of device
                    If devOutput(ri).Contains("9 Power_On") Then WorkTimeAta(GetRawValue(attr))

                    If devOutput(ri).Contains("10 Spin_Retry_Count") Then ataNewVitals.SpinRetry = GetRawValue(attr)
                    If devOutput(ri).Contains("196 Reallocated_Event_Count") Then
                        If devOutput(ri).Contains("(") Then
                            Dim str() As String = GetRawValue(attr).Split("(")
                            ataNewVitals.ReallEvent = str(0).Trim
                        Else
                            ataNewVitals.ReallEvent = GetRawValue(attr)
                        End If
                    End If
                    If devOutput(ri).Contains("197 Current_Pending_Sector") Then
                        If devOutput(ri).Contains("(") Then
                            Dim str() As String = GetRawValue(attr).Split("(")
                            ataNewVitals.CurPending = str(0).Trim
                        Else
                            ataNewVitals.CurPending = GetRawValue(attr)
                        End If
                    End If
                    If devOutput(ri).Contains("197 Total_Pending_Sectors") Then 'appears in some Samsung devices
                        If devOutput(ri).Contains("(") Then
                            Dim str() As String = GetRawValue(attr).Split("(")
                            ataNewVitals.CurPending = str(0).Trim
                        Else
                            ataNewVitals.CurPending = GetRawValue(attr)
                        End If
                    End If
                    If devOutput(ri).Contains("198 Offline_Uncorrectable") Then
                        If devOutput(ri).Contains("(") Then
                            Dim str() As String = GetRawValue(attr).Split("(")
                            ataNewVitals.OfflineUnc = str(0).Trim
                        Else
                            ataNewVitals.OfflineUnc = GetRawValue(attr)
                        End If
                    End If
                    If devOutput(ri).Contains("201 Soft_Read_Error_Rate") Then ataNewVitals.SoftRead = GetRawValue(attr)
                    If devOutput(ri).Contains("220 Disk_Shift") Then ataNewVitals.DiskShift = GetRawValue(attr)

                    'and now, from version 0.3, we monitor also the health percentages of SSD!
                    'note: I have some reserves for Micron and Samsung values, because I don't have
                    'found a very helpful output...
                    If devOutput(ri).Contains("202 Perc_Rated_Life_Used") Then
                        ataNewVitals.Micron = GetRawValue(attr)
                        ataRemainingLife = 100 - ataNewVitals.Micron
                        ataIsSsd = True
                    End If
                    If devOutput(ri).Contains("209 Remaining_Lifetime_Perc") Then
                        Dim v As String = GetNormalizedValue(attr)
                        If IsNumeric(v) Then
                            ataNewVitals.Indilinx = GetNormalizedValue(attr)
                        Else
                            ataNewVitals.Indilinx = GetRawValue(attr)
                        End If
                        ataRemainingLife = ataNewVitals.Indilinx
                        ataIsSsd = True
                    End If
                    If devOutput(ri).Contains("233 Remaining_Lifetime_Perc") Then
                        Dim v As String = GetNormalizedValue(attr)
                        If IsNumeric(v) Then
                            ataNewVitals.Indilinx = GetNormalizedValue(attr)
                        Else
                            ataNewVitals.Indilinx = GetRawValue(attr)
                        End If
                        ataRemainingLife = ataNewVitals.Indilinx
                        ataIsSsd = True
                    End If
                    If devOutput(ri).Contains("233 Media_Wearout_Indicator") Then
                        ataNewVitals.Intel = GetNormalizedValue(attr)
                        ataRemainingLife = ataNewVitals.Intel
                        ataIsSsd = True
                    End If
                    If (devOutput(ri).Contains("177 Wear_Leveling_Count") Or devOutput(ri).Contains("173 Wear_Leveling_Count")) And
                        (devOutput(ri).Contains("Always") Or Not devOutput(i).Contains("0x0000")) Then
                        'some times Samsung's SSD report bad values into the attributes table.
                        'These are two rows with good values:
                        '177 Wear_Leveling_Count    0x0013   099   099   019    Pre-fail  Always    -       8
                        '177 Wear_Leveling_Count     PO--C-   081   081   000    -    224
                        'instead, this one, report a value of 0 for each column:
                        '177 Wear_Leveling_Count    0x0000   000   000   000    Old_age   Offline   -       0
                        'so, avoiding to catch che results when the row can't contains the word "Always", you get
                        'only the good data (or, at least, is what I hope).
                        ataNewVitals.Samsung = GetNormalizedValue(attr)
                        ataRemainingLife = ataNewVitals.Samsung
                        ataIsSsd = True
                    End If
                    If devOutput(ri).Contains("231 SSD_Life_Left") Then
                        ataNewVitals.SandForce = GetNormalizedValue(attr)
                        ataRemainingLife = ataNewVitals.SandForce
                        ataIsSsd = True
                    End If

                    ataAttributes.Add(New AtaAttribute(attr))
                    attr = Nothing
                End If
            Next
        Else
            devTemperature = "N/A"
            ataBadSectors = "N/A"
            With ataNewVitals
                .CurPending = Nothing
                .DiskShift = Nothing
                .Errors = Nothing
                .Indilinx = Nothing
                .Intel = Nothing
                .Micron = Nothing
                .OfflineUnc = Nothing
                .ReallEvent = Nothing
                .ReallSect = Nothing
                .Samsung = Nothing
                .SandForce = Nothing
                .SoftRead = Nothing
                .SpinRetry = Nothing
                .Temperature = Nothing
            End With
            ataRemainingLife = "N/A"
            WorkTimeAta(Nothing)
        End If

        matchOld = Nothing
        matchNew = Nothing
        matchBrief = Nothing
    End Sub

    Private Sub GetErrors()
        'error structure example from 5.22
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
        '-------------------------------------------------------------------------------------
        'output from smartctl version 6.5
        'Error 1290 [9] occurred at disk power-On lifetime: 5461 hours (227 days + 13 hours)
        'When the command that caused the error occurred, the device was active Or idle.
        '
        '  After Command completion occurred, registers were
        '  er --ST COUNT  LBA_48  LH LM LL DV DC
        '  -- -- --== --== == == -- -- -- -- --
        '  40 -- 51 00 00 00 00 0e a9 63 09 00 00  Error: UNC at LBA = 0x0ea96309 = 245981961
        '
        '  Commands leading to the command that caused the error were
        '  CR FEATR COUNT  LBA_48  LH LM LL DV DC  Powered_Up_Time  Command/Feature_Name
        '  --== --== --== == == -- -- -- -- --  ---------------  --------------------
        '  25 ff ff 00 80 00 00 0e a9 63 00 40 02     01:48:45.211  READ DMA EXT
        '  25 ff ff 00 80 00 00 0e 9c 3b 00 40 02     01:48:36.257  READ DMA EXT
        '  25 ff ff 00 80 00 00 0e 9c 3a 80 40 02     01:48:36.245  READ DMA EXT
        '  25 ff ff 00 80 00 00 0e 98 9b 80 40 02     01:48:34.362  READ DMA EXT
        '  25 ff ff 00 80 00 00 0e 8e fa 00 40 02     01:48:29.449  READ DMA EXT

        Dim er As Integer = GetIndexOf("SMART Error Log Version")
        If er > 0 Then
            Dim rev() As String = devOutput(er).Split(":")
            If rev(1).Trim.Contains("(") Then
                Dim revv() As String = rev(1).Trim.Split("(")
                ataErrorLogVer = revv(0).Trim
            Else
                ataErrorLogVer = rev(1).Trim
            End If
        Else
            ataErrorLogVer = "N/A"
        End If

        If ataErrorLogVer = "N/A" Then
            er = GetIndexOf("SMART Extended Comprehensive Error Log Version")
            If er > 0 Then
                Dim rev() As String = devOutput(er).Split(":")
                If rev(1).Trim.Contains("(") Then
                    Dim revv() As String = rev(1).Trim.Split("(")
                    ataErrorLogVer = revv(0).Trim
                Else
                    ataErrorLogVer = rev(1).Trim
                End If
            Else
                ataErrorLogVer = "N/A"
            End If
        End If

        If GetIndexOf("Error Log not supported") > 0 Then
            ataErrorLogSupported = False
        ElseIf GetIndexOf("Error Log Version:") > 0 Then
            ataErrorLogSupported = True
        Else
            ataErrorLogSupported = False
        End If

        Dim tot As String = GetInfo("ATA Error Count")
        If tot = "N/A" Then tot = GetInfo("Device Error Count")

        If tot = "N/A" Then
            ataTotalErrors = "-"
            ataNewVitals.Errors = 0
            Exit Sub
        Else
            Dim last As Integer = Val(tot)
            ataTotalErrors = last
            ataNewVitals.Errors = last

            ataErrors.Clear()

            For i As Long = last To 1 Step -1
                Dim r As Short = GetIndexOf("Error " & i)
                If r > 0 Then
                    'get error lifetime
                    Dim lt() As String = devOutput(r).Split(":")
                    'get device status
                    Dim status() As String = devOutput(r + 1).Split(",")
                    'get error type
                    Dim errorType As String
                    Dim errRow As Integer = GetIndexOf("Error:", r)
                    If errRow > 0 Then
                        Dim err() As String = devOutput(errRow).Trim.Split(":", 2, StringSplitOptions.RemoveEmptyEntries)
                        errorType = err(1)
                    Else
                        errorType = "-"
                    End If

                    Dim ataErr As New AtaError(i, lt(1).Trim, status(1).Replace("the device was", "").Replace(".", "").Trim, errorType)

                    ataErrors.Add(ataErr)
                Else
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub LastSelfTest()
        'here is get the last self test result
        Dim i As Short
        Dim res As String
        Dim remaining As Short = 0

        i = GetIndexOf("Self-test execution status")

        If i > 0 Then
            Dim result() As String = devOutput(i).Split(")")
            res = result(0).Replace("(", "").Replace("Self-test execution status:", "").Trim
        Else
            res = "-"
            devLastTest = New DeviceLastTest(TestStatus.Unknown)
            Exit Sub
        End If

        If res.Length = 3 Then
            remaining = 100 - Val(res.Substring(2) & "0")
        End If

        res = res >> 4

        Select Case Val(res)
            Case 0 To 8
                devLastTest = New DeviceLastTest(res, 0)
            Case Is = 15
                devLastTest = New DeviceLastTest(res, remaining)
            Case Else
                devLastTest = New DeviceLastTest(TestStatus.Reserved, 0)
        End Select
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
        Dim v As Integer = GetIndexOf("SMART Self-test log structure revision number")
        If v > 0 Then
            Dim rev() As String = devOutput(v).Split(" ")
            ataSelfTestVersion = rev(rev.Length - 1)
        Else
            ataSelfTestVersion = "N/A"
        End If

        v = GetIndexOf("SMART Extended Self-test Log Version")
        If v > 0 Then
            Dim rev_sect() As String = devOutput(v).Split(":")
            Dim rev() As String = rev_sect(1).Trim.Split(" ")
            ataSelfTestVersion = rev(0)
        Else
            ataSelfTestVersion = "N/A"
        End If

        If GetIndexOf("Self-test Log not supported") > 0 Then
            ataSelfTestSupported = False
        ElseIf GetIndexOf("Self-test log structure revision number") > 0 Or GetIndexOf("Extended Self-test Log Version") > 0 Then
            ataSelfTestSupported = True
        Else
            ataSelfTestSupported = False
        End If

        Dim i As Integer = GetIndexOf("SMART Self-test log")
        If i = 0 Then i = GetIndexOf("SMART Extended Self-test Log")

        ataSelfTests.Clear()

        For r As Integer = i + 2 To devOutput.Length - 1
            Dim row As String = devOutput(r).Replace(vbCr, "").Replace(vbLf, "")
            If Not row.StartsWith("#") Then Exit For
            Dim st() As String = devOutput(r).Replace("#", "").Trim.Replace("  ", "_") _
                               .Split("_", 6, StringSplitOptions.RemoveEmptyEntries)

            ataSelfTests.Add(New AtaSelfTest(st))
            st = Nothing
        Next
    End Sub

    Private Sub GetTemperatures()
        Dim temps As Temperatures

        Dim cycle As String = GetInfo("Power Cycle Min/Max Temperature").Replace("Celsius", "").Trim
        Dim life As String = GetInfo("Lifetime    Min/Max Temperature").Replace("Celsius", "").Trim
        Dim rec As String = GetInfo("Min/Max recommended Temperature").Replace("Celsius", "").Trim
        Dim limit As String = GetInfo("Min/Max Temperature Limit").Replace("Celsius", "").Trim

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
            If ataDeviceModel.Trim.StartsWith("ST") And Val(arr(1).Trim) = 0 Then 'a Seagate model
                temps.RecommendedMax = 60
            Else
                temps.RecommendedMax = arr(1).Trim
            End If
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

        ataTemps = temps
        temps = Nothing
    End Sub

    Private Sub GetTestTiming()
        Dim i As Short

        i = GetIndexOf("Total time to complete Offline")
        If i > 0 Then
            Dim timing() As String = devOutput(i + 1).Split("(")
            ataOfflineTest = timing(1).Replace(")", "").Replace(".", "").Trim
        Else
            ataOfflineTest = "N/A"
        End If

        i = GetIndexOf("Short self-test routine")
        If i > 0 Then
            Dim timing() As String = devOutput(i + 1).Split("(")
            ataShortTest = timing(1).Replace(")", "").Replace(".", "").Trim
        Else
            ataShortTest = "N/A"
        End If

        i = GetIndexOf("Extended self-test routine")
        If i > 0 Then
            Dim timing() As String = devOutput(i + 1).Split("(")
            ataLongTest = timing(1).Replace(")", "").Replace(".", "").Trim
        Else
            ataLongTest = "N/A"
        End If

        i = GetIndexOf("Conveyance self-test routine")
        If i > 0 Then
            Dim timing() As String = devOutput(i + 1).Split("(")
            ataConveyanceTest = timing(1).Replace(")", "").Replace(".", "").Trim
        Else
            ataConveyanceTest = "N/A"
        End If
    End Sub
#End Region

#Region "ATA classes"
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaDevice
        Dim pd As Device
        Dim _ataInfo As AtaInfo
        Dim _ataFeatures As AtaFeatures
        Dim _ataAttributes As AtaAttributesTable
        Dim _ataErrors As AtaErrorsLog
        Dim _ataSelfTests As AtaSelfTestLog
        Dim _ataHealth As AtaHealth
        Dim _ataTracking As AtaAttributesTracking
        Dim _ataTemperatures As AtaTemperatures
        Dim _ataTest As AtaTest
        Dim _ataReliability As AtaReliability

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
            _ataInfo = New AtaInfo(parentDevice)
            _ataFeatures = New AtaFeatures(parentDevice)
            _ataAttributes = New AtaAttributesTable(parentDevice)
            _ataErrors = New AtaErrorsLog(parentDevice)
            _ataSelfTests = New AtaSelfTestLog(parentDevice)
            _ataHealth = New AtaHealth(parentDevice)
            _ataTracking = New AtaAttributesTracking(parentDevice)
            _ataTemperatures = New AtaTemperatures(parentDevice)
            _ataTest = New AtaTest(parentDevice)
            _ataReliability = New AtaReliability(parentDevice)
        End Sub

        Public ReadOnly Property Info As AtaInfo
            Get
                Return _ataInfo
            End Get
        End Property

        Public ReadOnly Property Features As AtaFeatures
            Get
                Return _ataFeatures
            End Get
        End Property

        Public ReadOnly Property Attributes As AtaAttributesTable
            Get
                Return _ataAttributes
            End Get
        End Property

        Public ReadOnly Property Errors As AtaErrorsLog
            Get
                Return _ataErrors
            End Get
        End Property

        Public ReadOnly Property SelfTests As AtaSelfTestLog
            Get
                Return _ataSelfTests
            End Get
        End Property

        Public ReadOnly Property Health As AtaHealth
            Get
                Return _ataHealth
            End Get
        End Property

        Public ReadOnly Property AttributesTracking As AtaAttributesTracking
            Get
                Return _ataTracking
            End Get
        End Property

        Public ReadOnly Property Temperatures As AtaTemperatures
            Get
                Return _ataTemperatures
            End Get
        End Property

        Public ReadOnly Property Test As AtaTest
            Get
                Return _ataTest
            End Get
        End Property

        Public ReadOnly Property Reliability As AtaReliability
            Get
                Return _ataReliability
            End Get
        End Property

        Public ReadOnly Property IsSsd As Boolean
            Get
                Return pd.ataIsSsd
            End Get
        End Property

        Public ReadOnly Property IsDoubleDeck As Boolean
            Get
                Return pd.ataDoubleDeck
            End Get
        End Property

    End Class

    <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaInfo
        Dim pd As Device
        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public ReadOnly Property Family As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataModelFamily
            End Get
        End Property

        Public ReadOnly Property Model As String
            Get
                If pd.devType = DeviceType.ThreeWare Then Return "3ware clipboard"
                Return pd.ataDeviceModel
            End Get
        End Property

        Public ReadOnly Property SerialNumber As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataSerialNumber
            End Get
        End Property

        Public ReadOnly Property FirmwareVersion As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataFirmware
            End Get
        End Property

        Public ReadOnly Property UserCapacity As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataSize
            End Get
        End Property

        Public ReadOnly Property WorldWideName As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataWwn
            End Get
        End Property

        Public ReadOnly Property SectorSize As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataSectorSize
            End Get
        End Property

        Public ReadOnly Property InDatabase As Boolean
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return False
                Return pd.ataInDatabase
            End Get
        End Property

        Public ReadOnly Property AtaVersion As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"

                If pd.ataStandard <> "N/A" Then
                    Return pd.ataVersion & " (" & pd.ataStandard & ")"
                Else
                    Return pd.ataVersion
                End If
            End Get
        End Property

        Public ReadOnly Property FormFactor As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataForm
            End Get
        End Property

        Public ReadOnly Property Warning As AtaWarning
            Get
                Return pd.ataWarnings
            End Get
        End Property

        Public ReadOnly Property RotationRate As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                If Not IsNothing(pd.ataModelFamily) Then
                    If pd.ataModelFamily.ToLower.Contains("western digital") And
                                    pd.ataModelFamily.ToLower.Contains("green") Then pd.ataRotation = "IntelliPower"
                    If pd.ataModelFamily.ToLower.Contains("hitachi deskstar") And
                        (pd.ataModelFamily.ToLower.Contains("5k1000") Or pd.ataModelFamily.ToLower.Contains("5k4000")) Then pd.ataRotation = "CoolSpin"
                End If

                Return pd.ataRotation
            End Get
        End Property

        Public ReadOnly Property SataVersion As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataSataVersion
            End Get
        End Property

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaWarning
        Dim _msg, _links() As String
        Public Sub New(ByVal message As String, ByVal links() As String)
            _msg = message
            _links = links
        End Sub

        Public ReadOnly Property Message As String
            Get
                Return _msg
            End Get
        End Property

        Public ReadOnly Property Links As String()
            Get
                Return _links
            End Get
        End Property

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaFeatures
        Dim pd As Device
        Dim _aam As AtaAam
        Dim _apm As AtaApm
        Dim _cache As AtaWriteCache
        Dim _offlineAuto As AtaOfflineAuto

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
            _aam = New AtaAam(parentDevice)
            _apm = New AtaApm(parentDevice)
            _cache = New AtaWriteCache(parentDevice)
            _offlineAuto = New AtaOfflineAuto(parentDevice)
        End Sub

        Public Class AtaAam
            Dim pd As Device
            Public Sub New(ByRef parentDevice As Device)
                pd = parentDevice
            End Sub

            Public ReadOnly Property Status As Feature
                Get
                    Return pd.ataAamStatus
                End Get
            End Property

            Public Property Value As String
                Get
                    Return pd.ataAam
                End Get
                Set(ByVal value As String)
                    pd.prompt.Smartctl("-s aam," & value & " " & pd.devLocation)
                    pd.Update()
                End Set
            End Property

            Public ReadOnly Property RecommendedValue As Short
                Get
                    Return pd.ataRecommendedAam
                End Get
            End Property
        End Class

        Public ReadOnly Property Aam As AtaAam
            Get
                Return _aam
            End Get
        End Property

        Public Class AtaApm
            Dim pd As Device
            Public Sub New(ByRef parentDevice As Device)
                pd = parentDevice
            End Sub

            Public Property Value As String
                Get
                    Return pd.ataApm
                End Get
                Set(ByVal value As String)
                    pd.prompt.Smartctl("-s apm," & value & " " & pd.devLocation)
                    pd.ataApm = value
                    pd.SaveSettings()
                    pd.Update()
                End Set
            End Property

            Public ReadOnly Property Status As Feature
                Get
                    Return pd.ataApmStatus
                End Get
            End Property
        End Class

        Public ReadOnly Property Apm As AtaApm
            Get
                Return _apm
            End Get
        End Property

        Public Property Standby As String
            Get
                Return pd.ataStandby
            End Get
            Set(ByVal value As String)
                pd.prompt.Smartctl("-s standby," & value & " " & pd.devLocation)
                pd.ataStandby = value
                pd.SaveSettings()
            End Set
        End Property

        Public Class AtaWriteCache
            Dim pd As Device
            Public Sub New(ByRef parentDevice As Device)
                pd = parentDevice
            End Sub

            Public Property Enabled As Feature
                Get
                    Return pd.ataCache
                End Get
                Set(ByVal value As Feature)
                    If value = Feature.Enabled Then
                        pd.prompt.Smartctl("-s wcache,on " & pd.devLocation)
                    ElseIf value = Feature.Disabled Then
                        pd.prompt.Smartctl("-s wcache,off " & pd.devLocation)
                    End If
                    pd.Update()
                End Set
            End Property

            Public Property Reorder As Feature
                Get
                    Return pd.ataCacheReorder
                End Get
                Set(ByVal value As Feature)
                    If value = Feature.Enabled Then
                        pd.prompt.Smartctl("-s wcreorder,on " & pd.devLocation)
                    ElseIf value = Feature.Disabled Then
                        pd.prompt.Smartctl("-s wcreorder,off " & pd.devLocation)
                    End If
                    pd.Update()
                End Set
            End Property
        End Class

        Public ReadOnly Property WriteCache As AtaWriteCache
            Get
                Return _cache
            End Get
        End Property

        Public Property LookAhead As Feature
            Get
                Return pd.ataLookAhead
            End Get
            Set(ByVal value As Feature)
                If value = Feature.Enabled Then
                    pd.prompt.Smartctl("-s lookahead,on " & pd.devLocation)
                ElseIf value = Feature.Disabled Then
                    pd.prompt.Smartctl("-s lookahead,off " & pd.devLocation)
                End If
                pd.Update()
            End Set
        End Property

        Public Class AtaOfflineAuto
            Dim pd As Device
            Public Sub New(ByRef parentDevice As Device)
                pd = parentDevice
            End Sub

            Public ReadOnly Property Status As Support
                Get
                    Return pd.ataOfflineAuto
                End Get
            End Property

            Public Sub Enable()
                Dim feature() As String = pd.prompt.Smartctl("-o on " & pd.devLocation)
            End Sub

            Public Sub Disable()
                Dim feature() As String = pd.prompt.Smartctl("-o off " & pd.devLocation)
            End Sub

        End Class

        Public ReadOnly Property OfflineAuto As AtaOfflineAuto
            Get
                Return _offlineAuto
            End Get
        End Property

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaAttributesTable
        Dim pd As Device
        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public ReadOnly Property Items As List(Of AtaAttribute)
            Get
                Return pd.ataAttributes
            End Get
        End Property

        Public ReadOnly Property Revision As String
            Get
                Return pd.ataAttributesRevision
            End Get
        End Property

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaAttribute
        Dim _id, _name, _value, _worst, _threshold, _whenFailed, _rawValue As String
        Dim _flag As AttributeFlags
        Dim _type As AttributeType
        Dim _updated As AttributeUpdate

        Public Sub New(ByVal attributeData() As String)
            With attributeData
                _id = attributeData(0)
                _name = attributeData(1).Replace("_", " ")
                _flag = ConvertToFlags(attributeData(2))
                _value = attributeData(3)
                _worst = attributeData(4)
                _threshold = attributeData(5)
                If attributeData.Length = 10 Then
                    'extended output, like examples 5.37, 5.38
                    If attributeData(6).Contains("Pre-fail") Then _
                            _type = AttributeType.PreFail Else _
                            _type = AttributeType.OldAge
                    If attributeData(7).Contains("Always") Then _
                            _updated = AttributeUpdate.Always Else _
                            _updated = AttributeUpdate.Offline
                    _whenFailed = attributeData(8).Replace("_", " ")
                    _rawValue = attributeData(9)
                Else
                    'brief output, like example 5.41
                    If _flag.HasFlag(AttributeFlags.SelfPreserving) Then _
                            _type = AttributeType.PreFail Else _
                            _type = AttributeType.OldAge
                    If _flag.HasFlag(AttributeFlags.UpdatedOnline) Then _
                            _updated = AttributeUpdate.Always Else _
                            _updated = AttributeUpdate.Offline
                    _whenFailed = attributeData(6).Replace("_", " ")
                    _rawValue = attributeData(7)
                End If
            End With
        End Sub

        Public ReadOnly Property Id As String
            Get
                Return _id
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return _name
            End Get
        End Property

        Public ReadOnly Property Flag As AttributeFlags
            Get
                Return _flag
            End Get
        End Property

        Public ReadOnly Property Value As String
            Get
                Return _value
            End Get
        End Property

        Public ReadOnly Property Worst As String
            Get
                Return _worst
            End Get
        End Property

        Public ReadOnly Property Threshold As String
            Get
                Return _threshold
            End Get
        End Property

        Public ReadOnly Property Type As AttributeType
            Get
                Return _type
            End Get
        End Property

        Public ReadOnly Property Updated As AttributeUpdate
            Get
                Return _updated
            End Get
        End Property

        Public ReadOnly Property WhenFailed As String
            Get
                Return _whenFailed
            End Get
        End Property

        Public ReadOnly Property RawValue As String
            Get
                Return _rawValue
            End Get
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaErrorsLog
        Dim pd As Device
        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public ReadOnly Property Items As List(Of AtaError)
            Get
                If pd.devSmartEnabled <> Support.Enabled Then Return Nothing
                Return pd.ataErrors
            End Get
        End Property

        Public ReadOnly Property Version As String
            Get
                Return pd.ataErrorLogVer
            End Get
        End Property

        Public ReadOnly Property TotalAmount As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataTotalErrors
            End Get
        End Property

        Public ReadOnly Property Supported As Boolean
            Get
                Return pd.ataErrorLogSupported
            End Get
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaError
        Dim _number As Integer
        Dim _lifeTime As String
        Dim _status As String
        Dim _error As String

        Public Sub New(ByVal number As Integer, ByVal lifeTime As String, ByVal status As String, ByVal [error] As String)
            _number = number
            _lifeTime = lifeTime
            _status = status
            _error = [error]
        End Sub

        Public ReadOnly Property Number As Integer
            Get
                Return _number
            End Get
        End Property

        Public ReadOnly Property LifeTime As String
            Get
                Return _lifeTime
            End Get
        End Property

        Public ReadOnly Property Status As String
            Get
                Return _status
            End Get
        End Property

        Public ReadOnly Property [Error] As String
            Get
                Return _error
            End Get
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaSelfTest
        Dim _num, _desc, _status, _remaining, _lifeTime, _firstError As String
        Public Sub New(ByVal test() As String)
            _num = test(0)
            _desc = test(1)
            If test(2).Contains("%") Then
                _status = test(2).Substring(0, test(2).Length - 4).Trim
                _remaining = test(2).Substring(test(2).Length - 3, 3).Trim
                _lifeTime = test(3).Trim
                _firstError = test(4).Trim
            Else
                _status = test(2).Trim
                _remaining = test(3).Trim
                _lifeTime = test(4).Trim
                _firstError = test(5).Trim
            End If
        End Sub

        Public ReadOnly Property Number As String
            Get
                Return _num
            End Get
        End Property

        Public ReadOnly Property Description As String
            Get
                Return _desc
            End Get
        End Property

        Public ReadOnly Property Status As String
            Get
                Return _status
            End Get
        End Property

        Public ReadOnly Property Remaining As String
            Get
                Return _remaining
            End Get
        End Property

        Public ReadOnly Property LifeTime As String
            Get
                Return _lifeTime
            End Get
        End Property

        Public ReadOnly Property FirstError As String
            Get
                Return _firstError
            End Get
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaSelfTestLog
        Dim pd As Device

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public ReadOnly Property Version As String
            Get
                Return pd.ataSelfTestVersion
            End Get
        End Property

        Public ReadOnly Property Items As List(Of AtaSelfTest)
            Get
                Return pd.ataSelfTests
            End Get
        End Property

        Public ReadOnly Property Supported As Boolean
            Get
                Return pd.ataSelfTestSupported
            End Get
        End Property

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaHealth
        Dim pd As Device

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public ReadOnly Property RemainingLife As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataRemainingLife
            End Get
        End Property

        Public ReadOnly Property BadSectorsCount As String
            Get
                If pd.devType = DeviceType.ThreeWare And Not pd.devIsValid Then Return "N/A"
                Return pd.ataBadSectors
            End Get
        End Property

        Public ReadOnly Property BadSectorsThreshold As Short
            Get
                Return pd.ataBadSectorsThreshold
            End Get
        End Property

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaVital
        Dim vp As AtaVitalParameters

        Public Sub New(ByVal params As AtaVitalParameters)
            vp = params
        End Sub

        Public ReadOnly Property CurPending As String
            Get
                Return vp.CurPending
            End Get
        End Property

        Public ReadOnly Property DiskShift As String
            Get
                Return vp.DiskShift
            End Get
        End Property

        Public ReadOnly Property Errors As String
            Get
                Return vp.Errors
            End Get
        End Property

        Public ReadOnly Property Indilinx As String
            Get
                Return vp.Indilinx
            End Get
        End Property

        Public ReadOnly Property Intel As String
            Get
                Return vp.Intel
            End Get
        End Property

        Public ReadOnly Property Micron As String
            Get
                Return vp.Micron
            End Get
        End Property

        Public ReadOnly Property OfflineUnc As String
            Get
                Return vp.OfflineUnc
            End Get
        End Property

        Public ReadOnly Property ReallEvent As String
            Get
                Return vp.ReallEvent
            End Get
        End Property

        Public ReadOnly Property ReallSect As String
            Get
                Return vp.ReallSect
            End Get
        End Property

        Public ReadOnly Property Samsung As String
            Get
                Return vp.Samsung
            End Get
        End Property

        Public ReadOnly Property SandForce As String
            Get
                Return vp.SandForce
            End Get
        End Property

        Public ReadOnly Property SoftRead As String
            Get
                Return vp.SoftRead
            End Get
        End Property

        Public ReadOnly Property SpinRetry As String
            Get
                Return vp.SpinRetry
            End Get
        End Property

        Public ReadOnly Property Temperature As String
            Get
                Return vp.Temperature
            End Get
        End Property

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaAttributesTracking
        Dim pd As Device

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public ReadOnly Property Variation As AtaVital
            Get
                Dim v As New AtaVital(pd.ataVitals)
                Return v
            End Get
        End Property

        Public ReadOnly Property Newest As AtaVital
            Get
                Dim v As New AtaVital(pd.ataNewVitals)
                Return v
            End Get
        End Property

        Public ReadOnly Property Oldest As AtaVital
            Get
                Dim v As New AtaVital(pd.ataOldVitals)
                Return v
            End Get
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaTemperatures
        Dim pd As Device

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public ReadOnly Property CycleMax As String
            Get
                Return pd.ataTemps.CycleMax
            End Get
        End Property

        Public ReadOnly Property CycleMin As String
            Get
                Return pd.ataTemps.CycleMin
            End Get
        End Property

        Public ReadOnly Property LifeTimeMax As String
            Get
                Return pd.ataTemps.LifetimeMax
            End Get
        End Property

        Public ReadOnly Property LifeTimeMin As String
            Get
                Return pd.ataTemps.LifetimeMin
            End Get
        End Property

        Public ReadOnly Property LimitMax As String
            Get
                Return pd.ataTemps.LimitMax
            End Get
        End Property

        Public ReadOnly Property LimitMin As String
            Get
                Return pd.ataTemps.LimitMin
            End Get
        End Property

        Public ReadOnly Property RecommendedMax As String
            Get
                Return pd.ataTemps.RecommendedMax
            End Get
        End Property

        Public ReadOnly Property RecommendedMin As String
            Get
                Return pd.ataTemps.RecommendedMin
            End Get
        End Property

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaTest
        Public Enum TestType
            Offline = 0
            [Short] = 1
            Extended = 2
            Conveyance = 3
        End Enum

        Dim pd As Device
        Dim _percentage As Long
        Dim _endTest As Date
        Dim _startTest As Date
        Dim _isRunning As Boolean = False
        Dim WithEvents _timer As New Timer
        Dim _polling As TestPolling
        Dim _runningTest As TestType

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
            _polling = New TestPolling(parentDevice)
        End Sub

        Private Function ToSeconds(ByVal duration As String) As Integer
            If duration.Contains("minutes") Then
                Return Val(duration) * 60
            Else
                Return Val(duration)
            End If
        End Function

        Public Sub Run(ByVal test As TestType)
            _percentage = 0
            _runningTest = test
            Dim d As String = "0"
            Select Case test
                Case TestType.Offline
                    pd.prompt.Smartctl("-t offline " & pd.devLocation)
                    d = _polling.Offline
                Case TestType.Short
                    pd.prompt.Smartctl("-t short " & pd.devLocation)
                    d = _polling.Short
                Case TestType.Extended
                    pd.prompt.Smartctl("-t long " & pd.devLocation)
                    d = _polling.Extended
                Case TestType.Conveyance
                    pd.prompt.Smartctl("-t conveyance " & pd.devLocation)
                    d = _polling.Conveyance
            End Select
            _isRunning = True
            _startTest = Now
            _endTest = _startTest.AddSeconds(ToSeconds(d))
            With _timer
                .Interval = 1000 '1 second
                .Start()
            End With
        End Sub

        Private Sub _timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _timer.Tick
            If Now <= _endTest Then
                _percentage = 100 - ((_endTest.Ticks - Now.Ticks) * 100 \ (_endTest.Ticks - _startTest.Ticks))
                _isRunning = True
            Else
                _percentage = 0
                _isRunning = False
                _endTest = Now
                _timer.Stop()
                'update device output
                pd.Update()
                'test result messagebox
                Dim t As String = ""
                Dim r As String = ""
                Select Case _runningTest
                    Case 0
                        t = Main.GetString(1802)
                    Case 1
                        t = Main.GetString(1803)
                    Case 2
                        t = Main.GetString(1804)
                    Case 3
                        t = Main.GetString(1805)
                End Select
                Dim msgstyle As MsgBoxStyle = MsgBoxStyle.Information
                Select Case pd.devLastTest.Status
                    Case 0
                        r = Main.GetString(950)
                    Case 1 To 2
                        r = Main.GetString(950 + pd.devLastTest.Status)
                        msgstyle = MsgBoxStyle.Exclamation
                    Case 3 To 8
                        r = Main.GetString(950 + pd.devLastTest.Status)
                        msgstyle = MsgBoxStyle.Critical
                    Case 15
                        r = Main.GetString(959) & " " & Main.GetString(961) & " " & pd.LastTestResult.Remaining & "%"
                    Case Else
                        r = Main.GetString(441)
                End Select
                Dim dev() As String = pd.devLocation.Split(" ")
                Dim msg As String = Main.GetString(4811) & ": " & dev(0).Trim & vbCrLf & vbCrLf &
                    Main.GetString(4812) & ": " & t & vbCrLf & vbCrLf &
                    Main.GetString(4813) & ": " & r

                MsgBox(msg, msgstyle + MsgBoxStyle.OkOnly, Main.GetString(4810))
            End If
        End Sub

        Public Sub Abort()
            pd.prompt.Smartctl("-X " & pd.devLocation)
            _timer.Stop()
            _percentage = 0
            _isRunning = False
            _endTest = Now
        End Sub

        Public ReadOnly Property RunningTest As TestType
            Get
                Return _runningTest
            End Get
        End Property

        Public ReadOnly Property Percentage As Long
            Get
                Return _percentage
            End Get
        End Property

        Public ReadOnly Property EndTest As Date
            Get
                Return _endTest
            End Get
        End Property

        Public ReadOnly Property IsRunning As Boolean
            Get
                Return _isRunning
            End Get
        End Property

        Public ReadOnly Property PollingTimes As TestPolling
            Get
                Return _polling
            End Get
        End Property

        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Class TestPolling
            Dim pd As Device

            Public Sub New(ByRef parentDevice As Device)
                pd = parentDevice
            End Sub

            Public ReadOnly Property Offline As String
                Get
                    Return pd.ataOfflineTest
                End Get
            End Property

            Public ReadOnly Property [Short] As String
                Get
                    Return pd.ataShortTest
                End Get
            End Property

            Public ReadOnly Property Extended As String
                Get
                    Return pd.ataLongTest
                End Get
            End Property

            Public ReadOnly Property Conveyance As String
                Get
                    Return pd.ataConveyanceTest
                End Get
            End Property
        End Class
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Structure AtaRatings
        Dim Overall,
        OfflineUncorrectable, ReallocationCount, ReallocationEvents, CurrentPending,
        Indilinx, Intel, Micron, Samsung, SandForce As Short
    End Structure

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class AtaReliability
        Dim pd As Device

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Public ReadOnly Property Overall As Short
            Get
                Return pd.ataRating.Overall
            End Get
        End Property

        Public ReadOnly Property OfflineUncorrectable As Short
            Get
                Return pd.ataRating.OfflineUncorrectable
            End Get
        End Property

        Public ReadOnly Property ReallocationCount As Short
            Get
                Return pd.ataRating.ReallocationCount
            End Get
        End Property

        Public ReadOnly Property ReallocationEvents As Short
            Get
                Return pd.ataRating.ReallocationEvents
            End Get
        End Property

        Public ReadOnly Property Indilinx As Short
            Get
                Return pd.ataRating.Indilinx
            End Get
        End Property

        Public ReadOnly Property Intel As Short
            Get
                Return pd.ataRating.Intel
            End Get
        End Property

        Public ReadOnly Property Micron As Short
            Get
                Return pd.ataRating.Micron
            End Get
        End Property

        Public ReadOnly Property Samsung As Short
            Get
                Return pd.ataRating.Samsung
            End Get
        End Property

        Public ReadOnly Property SandForce As Short
            Get
                Return pd.ataRating.SandForce
            End Get
        End Property

        Public ReadOnly Property CurrentPending As Short
            Get
                Return pd.ataRating.CurrentPending
            End Get
        End Property
    End Class
#End Region

#Region "ATA structures"
    Public Structure AtaVitalParameters
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
        '233 Remaining_Lifetime_Perc [Indilinx / OCZ]
        '233 Media_Wearout_Indicator [Intel]
        '177 Wear_Leveling_Count     [Samsung]
        '231 SSD_Life_Left           [SandForce]
        '*** from 0.4 track also the total amount of ATA errors! ***
        Dim ReallSect, SpinRetry, Temperature, ReallEvent, CurPending, OfflineUnc, SoftRead, DiskShift,
        Micron, Indilinx, Intel, Samsung, SandForce, Errors As String
    End Structure

    Public Structure Temperatures
        Dim CycleMin, CycleMax, LifetimeMin, LifetimeMax, RecommendedMin, RecommendedMax, LimitMin, LimitMax As String
    End Structure
#End Region

#Region "ATA properties"
    Public ReadOnly Property ATA As AtaDevice
        Get
            Return _ataDevice
        End Get
    End Property
#End Region

End Class
