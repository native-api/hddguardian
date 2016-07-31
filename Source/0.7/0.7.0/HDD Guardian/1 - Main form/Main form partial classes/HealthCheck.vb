'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2016 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Partial Class Main

    <System.Runtime.InteropServices.DllImportAttribute("user32.dll")> _
    Private Shared Function DestroyIcon(ByVal handle As IntPtr) As Boolean
    End Function

    Dim err, tempthresh, chkhealth As String

    Private Sub VitalsCheck()
        err = ""

        If Not IO.Directory.Exists(logpath) Then IO.Directory.CreateDirectory(logpath)

        For i As Short = 0 To devlist.Count - 1
            Dim dev As Device = devlist(i)
            If dev.Type <> DeviceType.SCSI Then
                Dim v As Device.AtaVital = dev.ATA.AttributesTracking.Variation
                Dim o As Device.AtaVital = dev.ATA.AttributesTracking.Oldest
                Dim n As Device.AtaVital = dev.ATA.AttributesTracking.Newest
                Dim havechanges As Boolean = False
                Dim model As String = dev.ATA.Info.Model
                Dim d As Double = 0
                Dim txt As String = ""
                Dim errors As String = ""

                If dev.AlreadyWarned = False Then
                    'now, compare vital parameters for each type of vital checked
                    With AppSettings.VitalParameters
                        If .ReallocatedSectors.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #5: Reallocated sector count
                            Dim idname As String = "Reallocated sector count"
                            txt = ""
                            If IsNumeric(v.ReallSect) Then
                                d = Convert.ToDouble(v.ReallSect)
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is > 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.ReallSect &
                                            " " & m_to & " " & n.ReallSect & " [" & m_degradation & "]"
                                    Case Is < 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.ReallSect &
                                            " " & m_to & " " & n.ReallSect & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .SpinRetry.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #10: Spin retry count
                            Dim idname As String = "Spin retry count"
                            txt = ""
                            If IsNumeric(v.SpinRetry) Then
                                d = Convert.ToDouble(v.SpinRetry)
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is > 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SpinRetry &
                                            " " & m_to & " " & n.SpinRetry & " [" & m_degradation & "]"
                                    Case Is < 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SpinRetry &
                                            " " & m_to & " " & n.SpinRetry & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .ReallocationEvents.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #196: Rellocated event count
                            Dim idname As String = "Rellocated event count"
                            txt = ""
                            If IsNumeric(v.ReallEvent) Then
                                d = Convert.ToDouble(v.ReallEvent)
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is > 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.ReallEvent &
                                            " " & m_to & " " & n.ReallEvent & " [" & m_degradation & "]"
                                    Case Is < 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.ReallEvent &
                                            " " & m_to & " " & n.ReallEvent & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .PendingSectors.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #197: Current pending sector
                            Dim idname As String = "Current pending sector"
                            txt = ""
                            If IsNumeric(v.CurPending) Then
                                d = Convert.ToDouble(v.CurPending)
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is > 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.CurPending &
                                            " " & m_to & " " & n.CurPending & " [" & m_degradation & "]"
                                    Case Is < 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.CurPending &
                                            " " & m_to & " " & n.CurPending & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .OfflineUncorrectable.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #198: Offline uncorrectable
                            Dim idname As String = "Offline uncorrectable"
                            txt = ""
                            If IsNumeric(v.OfflineUnc) Then
                                d = Convert.ToDouble(v.OfflineUnc)
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is > 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.OfflineUnc &
                                            " " & m_to & " " & n.OfflineUnc & " [" & m_degradation & "]"
                                    Case Is < 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.OfflineUnc &
                                            " " & m_to & " " & n.OfflineUnc & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .SoftReadErrors.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #201: Soft read error rate
                            Dim idname As String = "Soft read error rate"
                            txt = ""
                            If IsNumeric(v.SoftRead) Then
                                d = Convert.ToDouble(v.SoftRead)
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is > 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SoftRead &
                                            " " & m_to & " " & n.SoftRead & " [" & m_degradation & "]"
                                    Case Is < 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SoftRead &
                                            " " & m_to & " " & n.SoftRead & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .DiskShift.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #220: Disk shift
                            Dim idname As String = "Disk shift"
                            txt = ""
                            If IsNumeric(v.DiskShift) Then
                                d = Convert.ToDouble(v.DiskShift)
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is > 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.DiskShift &
                                            " " & m_to & " " & n.DiskShift & " [" & m_degradation & "]"
                                    Case Is < 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.DiskShift &
                                            " " & m_to & " " & n.DiskShift & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .Temperature.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #194: Temperature
                            Dim idname As String = "Temperature"
                            txt = ""
                            If IsNumeric(v.Temperature) Then
                                d = Convert.ToDouble(v.Temperature)
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is > 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Temperature & "°C" &
                                            " " & m_to & " " & n.Temperature & "°C [" & m_degradation & "]"
                                    Case Is < 0
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Temperature & "°C" &
                                            " " & m_to & " " & n.Temperature & "°C [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .Indilinx.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #209: Remaining Life (%)
                            Dim idname As String = "Remaining Life (%)"
                            txt = ""
                            If IsNumeric(v.Indilinx) Then
                                d = Convert.ToDouble(v.Indilinx)
                                'value start to 100 and go to 0
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is < 0 'sample: 99 - 100 = -1, is a degradation...
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Indilinx &
                                            " " & m_to & " " & n.Indilinx & " [" & m_degradation & "]"
                                    Case Is > 0 'sample: 100 - 99 = 1, is a recovery
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Indilinx &
                                            " " & m_to & " " & n.Indilinx & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .Intel.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #233: Media Wearout Indicator
                            Dim idname As String = "Media Wearout Indicator"
                            txt = ""
                            If IsNumeric(v.Intel) Then
                                d = Convert.ToDouble(v.Intel)
                                'value start to 100 and go to 1
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is < 0 'sample: 99 - 100 = -1, is a degradation...
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Intel &
                                            " " & m_to & " " & n.Intel & " [" & m_degradation & "]"
                                    Case Is > 0 'sample: 100 - 99 = 1, is a recovery
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Intel &
                                            " " & m_to & " " & n.Intel & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .Micron.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #202: Percentage Lifetime Used
                            Dim idname As String = "Percentage Lifetime Used"
                            txt = ""
                            If IsNumeric(v.Micron) Then
                                d = Convert.ToDouble(v.Micron)
                                'value start to 0 and go to 100
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is > 0 'sample: 100 - 99 = 1, is a degradation...
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Micron &
                                            " " & m_to & " " & n.Micron & " [" & m_degradation & "]"
                                    Case Is > 0 'sample: 99 - 100 = -1, is a recovery
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Micron &
                                            " " & m_to & " " & n.Micron & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .Samsung.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #177: Wear Leveling Count
                            Dim idname As String = "Wear Leveling Count"
                            txt = ""
                            If IsNumeric(v.Samsung) Then
                                d = Convert.ToDouble(v.Samsung)
                                'value start to 100 and go to 1
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is < 0 'sample: 99 - 100 = -1, is a degradation...
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Samsung &
                                            " " & m_to & " " & n.Samsung & " [" & m_degradation & "]"
                                    Case Is > 0 'sample: 100 - 99 = 1, is a recovery
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Samsung &
                                            " " & m_to & " " & n.Samsung & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        If .SandForce.HasFlag(CustomSettings.SettingsVital.Vital.Alarm) Then 'ID #231: SSD Life Left
                            Dim idname As String = "SSD Life Left"
                            txt = ""
                            If IsNumeric(v.SandForce) Then
                                d = Convert.ToDouble(v.SandForce)
                                'value start to 100 and go to 1
                                Select Case d
                                    Case Is = 0
                                        txt = ""
                                    Case Is < 0 'sample: 99 - 100 = -1, is a degradation...
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SandForce &
                                            " " & m_to & " " & n.SandForce & " [" & m_degradation & "]"
                                    Case Is > 0 'sample: 100 - 99 = 1, is a recovery
                                        txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SandForce &
                                            " " & m_to & " " & n.SandForce & " [" & m_recovery & "]"
                                End Select
                                If txt <> "" Then havechanges = True
                            End If
                            errors += txt
                        End If

                        'track total amount of errors
                        Dim idstr As String = "Errors"
                        txt = ""
                        If IsNumeric(v.Errors) Then
                            d = Convert.ToDouble(v.Errors)
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is > 0
                                    txt = vbCrLf & "   " & idstr & " - " & m_from & " " & o.Errors &
                                        " " & m_to & " " & n.Errors & " [" & m_degradation & "]"
                                Case Is < 0 'normally errors can't decrease...
                                    txt = vbCrLf & "   " & idstr & " - " & m_from & " " & o.Errors &
                                        " " & m_to & " " & n.Errors & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                            errors += txt
                        End If

                        If havechanges Then
                            err = err & model & errors & vbCrLf
                        End If
                    End With

                    dev.AlreadyWarned = True
                End If
            End If
        Next

        If err.Length > 0 Then
            Dim last As Short = err.LastIndexOf("]")
            err = err.Substring(0, last + 1)
        End If
    End Sub

    Private Sub TemperatureCheck()
        tempthresh = ""
        If AppSettings.Warnings.Notify.HasFlag(CustomSettings.SettingsWarning.Triggers.HighTemp) Then
            Dim tmax As Short = 49

            For Each Device In devlist
                If Device.Type <> DeviceType.SCSI Then
                    If IsNumeric(Device.ATA.Temperatures.RecommendedMax) Then tmax = Device.ATA.Temperatures.RecommendedMax - 1
                    If IsNumeric(Device.Temperature) Then
                        If Convert.ToSingle(Device.Temperature) > tmax Then
                            tempthresh = tempthresh & Device.ATA.Info.Model & ": " & Device.Temperature & "°C" & vbCrLf
                        End If
                    End If
                Else
                    If IsNumeric(Device.Temperature) Then
                        If Convert.ToSingle(Device.Temperature) > tmax Then
                            tempthresh = tempthresh & Device.Scsi.Info.Product & ": " & Device.Temperature & "°C" & vbCrLf
                        End If
                    End If
                End If
            Next

            If tempthresh.Length > 0 And tempthresh.LastIndexOf(vbCrLf) = tempthresh.Length - 1 Then
                tempthresh = tempthresh.Substring(0, tempthresh.Length - 2)
            End If
        End If
    End Sub

    Private Sub OverallHealthCheck()
        chkhealth = ""
        If AppSettings.Warnings.Notify.HasFlag(CustomSettings.SettingsWarning.Triggers.Failure) Then
            Dim failure As Boolean = False
            For Each Device In devlist
                If Device.Health = Status.Failed Then
                    If Device.Type <> DeviceType.SCSI Then
                        chkhealth += Device.ATA.Info.Model & vbCrLf
                        failure = True
                    Else
                        chkhealth += Device.Scsi.Info.Product & vbCrLf
                        failure = True
                    End If
                End If
            Next

            'HDD Guardian tray icon image change between combinations of devices failure and program updates
            Try
                If failure Then
                    If picNewVersion.Visible Then
                        niTrayIcon.Icon = My.Resources.icn_upd_ko
                    Else
                        niTrayIcon.Icon = My.Resources.icn_ko
                    End If
                Else
                    If picNewVersion.Visible Then
                        niTrayIcon.Icon = My.Resources.icn_upd_ok
                    Else
                        niTrayIcon.Icon = My.Resources.icn_ok
                    End If
                End If
            Catch ex As Exception
                Dim diagnostic As New System.Diagnostics.StackTrace(ex, True)
                PrintDebug("Error on OverallHealthCheck: " & ex.Message)
                PrintDebug("at line of code: " & diagnostic.GetFrame(0).GetFileLineNumber & " on file " & diagnostic.GetFrame(0).GetFileName)
            End Try

            If chkhealth.Length > 0 And chkhealth.LastIndexOf(vbCrLf) = chkhealth.Length - 1 Then
                chkhealth = chkhealth.Substring(0, chkhealth.Length - 2)
            End If
        End If
    End Sub

#Region "Display warnings"

    Dim WithEvents tmrDelay As New Timer
    Dim Warning As Integer

    Public Async Sub DisplayWarnings()
        Await Task.Run(Sub()
                           VitalsCheck()
                           TemperatureCheck()
                           OverallHealthCheck()
                       End Sub)

        tmrDelay.Interval = 3000
        tmrDelay.Start()
        Warning = 0
    End Sub

    Private Sub DelayWarnings() Handles tmrDelay.Tick
        ShowWarningsBaloons(Warning)
        If Warning = 2 Then tmrDelay.Stop()
        Warning += 1
    End Sub

    Enum BaloonMsgs
        Failure = 0
        Temperature
        Health
    End Enum

    Private Sub ShowWarningsBaloons(ByVal Baloon As BaloonMsgs)
        Select Case Baloon
            Case BaloonMsgs.Failure
                'device failure message
                If chkhealth.Length > 0 And niTrayIcon.Visible = True Then
                    With niTrayIcon
                        .BalloonTipIcon = ToolTipIcon.Error
                        .BalloonTipTitle = m_failuretitle
                        .BalloonTipText = m_failuretxt.Replace("%", chkhealth)
                        .ShowBalloonTip(3000)
                    End With
                End If
            Case BaloonMsgs.Temperature
                'device temperature message
                If tempthresh.Length > 0 And niTrayIcon.Visible = True Then
                    With niTrayIcon
                        .BalloonTipIcon = ToolTipIcon.Warning
                        .BalloonTipTitle = m_temperaturealarm
                        .BalloonTipText = tempthresh
                        .ShowBalloonTip(3000)
                    End With
                End If
            Case BaloonMsgs.Health
                'raw values variation message
                If err.Length > 0 And niTrayIcon.Visible = True Then
                    With niTrayIcon
                        .BalloonTipIcon = ToolTipIcon.Warning
                        .BalloonTipTitle = m_alarmdevstatus
                        .BalloonTipText = err
                        .ShowBalloonTip(3000)
                    End With
                End If
        End Select
    End Sub

#End Region

#Region "Mail notifications"
    Public Sub SendNotificationMail()
        'temperature
        If AppSettings.Warnings.SendMail.HasFlag(CustomSettings.SettingsWarning.Triggers.HighTemp) Then
            Dim tmax As Short = 49
            Dim threshold As String = ""

            For Each Device In devlist
                If Device.Type <> DeviceType.SCSI Then
                    If IsNumeric(Device.ATA.Temperatures.RecommendedMax) Then tmax = Device.ATA.Temperatures.RecommendedMax - 1
                End If

                If IsNumeric(Device.Temperature) Then
                    If Convert.ToSingle(Device.Temperature) > tmax And Not Device.MailNotification.SentTemperature Then
                        threshold = threshold & Device.Scsi.Info.Product & " (" & Device.Location & ")" & vbCrLf
                    End If
                End If
            Next

            If threshold.Length > 0 Then
                Dim tresult As Boolean = SendMail(GetString(4042), GetString(3721) & vbCrLf & vbCrLf & threshold)

                For Each Device In devlist
                    If tresult = True And Convert.ToSingle(Device.Temperature) > tmax Then
                        Device.MailNotification.SentTemperature = True
                    End If
                Next
            End If
        End If

        'health
        If AppSettings.Warnings.SendMail.HasFlag(CustomSettings.SettingsWarning.Triggers.Failure) Then
            Dim health As String = ""
            For Each Device In devlist
                If Device.Type <> DeviceType.SCSI Then
                    If Device.Health = Status.Failed And Not Device.MailNotification.SentHealth Then
                        health += Device.ATA.Info.Model & " (" & Device.Location & ")" & vbCrLf
                    End If
                Else
                    If Device.Health = Status.Failed And Not Device.MailNotification.SentHealth Then
                        health += Device.Scsi.Info.Product & " (" & Device.Location & ")" & vbCrLf
                    End If
                End If
            Next

            If health.Length > 0 Then
                Dim hresult As Boolean = SendMail(GetString(4041), GetString(3720) & vbCrLf & vbCrLf & health)
                For Each Device In devlist
                    If Device.Health = Status.Failed And hresult = True Then
                        Device.MailNotification.SentHealth = True
                    End If
                Next
            End If
        End If
    End Sub
#End Region

#Region "Play sound"
    Public Sub SoundNotification()
        Dim highTemp As Boolean = False
        Dim deviceFailure As Boolean = False

        'temperature
        If AppSettings.Warnings.PlaySound.HasFlag(CustomSettings.SettingsWarning.Triggers.HighTemp) Then
            Dim tmax As Short = 49
            Dim threshold As String = ""

            For Each Device In devlist
                If Device.Type <> DeviceType.SCSI Then
                    If IsNumeric(Device.ATA.Temperatures.RecommendedMax) Then tmax = Device.ATA.Temperatures.RecommendedMax - 1
                End If

                If IsNumeric(Device.Temperature) Then
                    If Convert.ToSingle(Device.Temperature) > tmax Then
                        highTemp = True
                        Exit For
                    End If
                End If
            Next
        End If

        'health
        If AppSettings.Warnings.PlaySound.HasFlag(CustomSettings.SettingsWarning.Triggers.Failure) Then
            Dim health As String = ""
            For Each Device In devlist
                If Device.Health = Status.Failed Then
                    deviceFailure = True
                    Exit For
                End If
            Next
        End If

        'play sound
        If highTemp Or deviceFailure Then
            If IO.File.Exists(AppSettings.Warnings.SoundFile) Then My.Computer.Audio.Play(AppSettings.Warnings.SoundFile)
        End If
    End Sub

#End Region

#Region "Power off"
    Public Sub PowerOff()
        Dim highTemp As Boolean = False
        Dim deviceFailure As Boolean = False

        'temperature
        If AppSettings.Warnings.PowerOff.HasFlag(CustomSettings.SettingsWarning.Triggers.HighTemp) Then
            Dim tmax As Short = 49
            Dim threshold As String = ""

            For Each Device In devlist
                If Not Device.IsVirtual Then
                    If Device.Type <> DeviceType.SCSI Then
                        If IsNumeric(Device.ATA.Temperatures.RecommendedMax) Then tmax = Device.ATA.Temperatures.RecommendedMax - 1
                    End If

                    If IsNumeric(Device.Temperature) Then
                        If Convert.ToSingle(Device.Temperature) > tmax Then
                            highTemp = True
                            Exit For
                        End If
                    End If
                End If
            Next
        End If

        'health
        If AppSettings.Warnings.PowerOff.HasFlag(CustomSettings.SettingsWarning.Triggers.Failure) Then
            Dim health As String = ""
            For Each Device In devlist
                If Not Device.IsVirtual Then
                    If Device.Health = Status.Failed Then
                        deviceFailure = True
                        Exit For
                    End If
                End If
            Next
        End If

        'power off
        If deviceFailure Then
            Dim c As New Console
            Dim t As Short = AppSettings.Warnings.TimeOut
            If System.Environment.OSVersion.Version.Major >= 6 And My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                'Vista or higher
                If AppSettings.Warnings.ForceClose Then
                    c.SendCmd("shutdown /s /t " & t & " /f /c ""HDD Guardian: device failure"" /d u:1:7")
                Else
                    c.SendCmd("shutdown /s /t " & t & " /c ""HDD Guardian: device failure"" /d u:1:7")
                End If
            Else
                If AppSettings.Warnings.ForceClose Then
                    c.SendCmd("shutdown -s -t " & t & " -f -c ""HDD Guardian: device failure"" -d u:1:7")
                Else
                    c.SendCmd("shutdown -s -t " & t & " -c ""HDD Guardian: device failure"" -d u:1:7")
                End If
            End If

            If IO.File.Exists(AppSettings.Warnings.SoundFile) Then My.Computer.Audio.Play(AppSettings.Warnings.SoundFile)
        End If

        If highTemp Then
            Dim c As New Console
            Dim t As Short = AppSettings.Warnings.TimeOut
            If System.Environment.OSVersion.Version.Major >= 6 And My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                'Vista or higher
                If AppSettings.Warnings.ForceClose Then
                    c.SendCmd("shutdown /s /t " & t & " /f /c ""HDD Guardian: excessive temperature"" /d u:1:7")
                Else
                    c.SendCmd("shutdown /s /t " & t & " /c ""HDD Guardian: excessive temperature"" /d u:1:7")
                End If
            Else
                If AppSettings.Warnings.ForceClose Then
                    c.SendCmd("shutdown -s -t " & t & " -f -c ""HDD Guardian: excessive temperature"" -d u:1:7")
                Else
                    c.SendCmd("shutdown -s -t " & t & " -c ""HDD Guardian: excessive temperature"" -d u:1:7")
                End If
            End If

            If IO.File.Exists(AppSettings.Warnings.SoundFile) Then My.Computer.Audio.Play(AppSettings.Warnings.SoundFile)
        End If
    End Sub

#End Region

End Class
