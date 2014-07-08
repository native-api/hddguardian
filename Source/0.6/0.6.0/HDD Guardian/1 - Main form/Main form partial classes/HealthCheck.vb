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

Partial Class Main

    Dim err, tempthresh, chkhealth As String

    Private Sub VitalsCheck()
        err = ""
        If My.Settings.VitalParameters = False Then Exit Sub

        If Not IO.Directory.Exists(logpath) Then IO.Directory.CreateDirectory(logpath)

        For i As Short = 0 To devlist.Count - 1
            Dim dev As Device = devlist(i)
            Dim v As Vitals = dev.VitalParametersVariation
            Dim o As Vitals = dev.OldVitalParameters
            Dim n As Vitals = dev.NewVitalParameters
            Dim havechanges As Boolean = False
            Dim model As String = dev.Model
            Dim d As Double = 0
            Dim txt As String = ""
            Dim errors As String = ""

            If dev.AlreadyDisplayedWarnings = False Then
                'now, compare vital parameters for each type of vital checked
                With My.Settings
                    If .WarningReallocatedSector Then 'ID #5: Reallocated sector count
                        Dim idname As String = "Reallocated sector count"
                        txt = ""
                        If IsNumeric(v.ReallSect) Then
                            d = Convert.ToDouble(v.ReallSect)
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is > 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.ReallSect & _
                                        " " & m_to & " " & n.ReallSect & " [" & m_degradation & "]"
                                Case Is < 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.ReallSect & _
                                        " " & m_to & " " & n.ReallSect & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningSpinRetry Then 'ID #10: Spin retry count
                        Dim idname As String = "Spin retry count"
                        txt = ""
                        If IsNumeric(v.SpinRetry) Then
                            d = Convert.ToDouble(v.SpinRetry)
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is > 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SpinRetry & _
                                        " " & m_to & " " & n.SpinRetry & " [" & m_degradation & "]"
                                Case Is < 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SpinRetry & _
                                        " " & m_to & " " & n.SpinRetry & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningReallocatedEvent Then 'ID #196: Rellocated event count
                        Dim idname As String = "Rellocated event count"
                        txt = ""
                        If IsNumeric(v.ReallEvent) Then
                            d = Convert.ToDouble(v.ReallEvent)
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is > 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.ReallEvent & _
                                        " " & m_to & " " & n.ReallEvent & " [" & m_degradation & "]"
                                Case Is < 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.ReallEvent & _
                                        " " & m_to & " " & n.ReallEvent & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningCurrentPendingSector Then 'ID #197: Current pending sector
                        Dim idname As String = "Current pending sector"
                        txt = ""
                        If IsNumeric(v.CurPending) Then
                            d = Convert.ToDouble(v.CurPending)
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is > 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.CurPending & _
                                        " " & m_to & " " & n.CurPending & " [" & m_degradation & "]"
                                Case Is < 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.CurPending & _
                                        " " & m_to & " " & n.CurPending & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningOfflineUncorrectable Then 'ID #198: Offline uncorrectable
                        Dim idname As String = "Offline uncorrectable"
                        txt = ""
                        If IsNumeric(v.OfflineUnc) Then
                            d = Convert.ToDouble(v.OfflineUnc)
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is > 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.OfflineUnc & _
                                        " " & m_to & " " & n.OfflineUnc & " [" & m_degradation & "]"
                                Case Is < 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.OfflineUnc & _
                                        " " & m_to & " " & n.OfflineUnc & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningSoftReadErrorRate Then 'ID #201: Soft read error rate
                        Dim idname As String = "Soft read error rate"
                        txt = ""
                        If IsNumeric(v.SoftRead) Then
                            d = Convert.ToDouble(v.SoftRead)
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is > 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SoftRead & _
                                        " " & m_to & " " & n.SoftRead & " [" & m_degradation & "]"
                                Case Is < 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SoftRead & _
                                        " " & m_to & " " & n.SoftRead & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningDiskShift Then 'ID #220: Disk shift
                        Dim idname As String = "Disk shift"
                        txt = ""
                        If IsNumeric(v.DiskShift) Then
                            d = Convert.ToDouble(v.DiskShift)
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is > 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.DiskShift & _
                                        " " & m_to & " " & n.DiskShift & " [" & m_degradation & "]"
                                Case Is < 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.DiskShift & _
                                        " " & m_to & " " & n.DiskShift & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningTemp Then 'ID #194: Temperature
                        Dim idname As String = "Temperature"
                        txt = ""
                        If IsNumeric(v.Temperature) Then
                            d = Convert.ToDouble(v.Temperature)
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is > 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Temperature & "°C" & _
                                        " " & m_to & " " & n.Temperature & "°C [" & m_degradation & "]"
                                Case Is < 0
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Temperature & "°C" & _
                                        " " & m_to & " " & n.Temperature & "°C [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningIndilinx Then 'ID #209: Remaining Life (%)
                        Dim idname As String = "Remaining Life (%)"
                        txt = ""
                        If IsNumeric(v.Indilinx) Then
                            d = Convert.ToDouble(v.Indilinx)
                            'value start to 100 and go to 0
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is < 0 'sample: 99 - 100 = -1, is a degradation...
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Indilinx & _
                                        " " & m_to & " " & n.Indilinx & " [" & m_degradation & "]"
                                Case Is > 0 'sample: 100 - 99 = 1, is a recovery
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Indilinx & _
                                        " " & m_to & " " & n.Indilinx & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningIntel Then 'ID #233: Media Wearout Indicator
                        Dim idname As String = "Media Wearout Indicator"
                        txt = ""
                        If IsNumeric(v.Intel) Then
                            d = Convert.ToDouble(v.Intel)
                            'value start to 100 and go to 1
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is < 0 'sample: 99 - 100 = -1, is a degradation...
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Intel & _
                                        " " & m_to & " " & n.Intel & " [" & m_degradation & "]"
                                Case Is > 0 'sample: 100 - 99 = 1, is a recovery
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Intel & _
                                        " " & m_to & " " & n.Intel & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningMicron Then 'ID #202: Percentage Lifetime Used
                        Dim idname As String = "Percentage Lifetime Used"
                        txt = ""
                        If IsNumeric(v.Micron) Then
                            d = Convert.ToDouble(v.Micron)
                            'value start to 0 and go to 100
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is > 0 'sample: 100 - 99 = 1, is a degradation...
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Micron & _
                                        " " & m_to & " " & n.Micron & " [" & m_degradation & "]"
                                Case Is > 0 'sample: 99 - 100 = -1, is a recovery
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Micron & _
                                        " " & m_to & " " & n.Micron & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningSamsung Then 'ID #177: Wear Leveling Count
                        Dim idname As String = "Wear Leveling Count"
                        txt = ""
                        If IsNumeric(v.Samsung) Then
                            d = Convert.ToDouble(v.Samsung)
                            'value start to 100 and go to 1
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is < 0 'sample: 99 - 100 = -1, is a degradation...
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Samsung & _
                                        " " & m_to & " " & n.Samsung & " [" & m_degradation & "]"
                                Case Is > 0 'sample: 100 - 99 = 1, is a recovery
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.Samsung & _
                                        " " & m_to & " " & n.Samsung & " [" & m_recovery & "]"
                            End Select
                            If txt <> "" Then havechanges = True
                        End If
                        errors += txt
                    End If

                    If .WarningSandForce Then 'ID #231: SSD Life Left
                        Dim idname As String = "SSD Life Left"
                        txt = ""
                        If IsNumeric(v.SandForce) Then
                            d = Convert.ToDouble(v.SandForce)
                            'value start to 100 and go to 1
                            Select Case d
                                Case Is = 0
                                    txt = ""
                                Case Is < 0 'sample: 99 - 100 = -1, is a degradation...
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SandForce & _
                                        " " & m_to & " " & n.SandForce & " [" & m_degradation & "]"
                                Case Is > 0 'sample: 100 - 99 = 1, is a recovery
                                    txt = vbCrLf & "   " & idname & " - " & m_from & " " & o.SandForce & _
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
                                txt = vbCrLf & "   " & idstr & " - " & m_from & " " & o.Errors & _
                                    " " & m_to & " " & n.Errors & " [" & m_degradation & "]"
                            Case Is < 0 'normally errors can't decrease...
                                txt = vbCrLf & "   " & idstr & " - " & m_from & " " & o.Errors & _
                                    " " & m_to & " " & n.Errors & " [" & m_recovery & "]"
                        End Select
                        If txt <> "" Then havechanges = True
                        errors += txt
                    End If

                    If havechanges Then
                        err = err & model & errors & vbCrLf
                    End If
                End With

                dev.AlreadyDisplayedWarnings = True
            End If
        Next

        If err.Length > 0 Then
            Dim last As Short = err.LastIndexOf("]")
            err = err.Substring(0, last + 1)
        End If
    End Sub

    Private Sub TemperatureCheck()
        tempthresh = ""
        If My.Settings.TemperatureThreshold = False Then Exit Sub

        Dim tmax As Short = 49
        If My.Settings.CustomTemperature Then
            tmax = Val(My.Settings.CustomTemperatureValue) - 1
        End If

        For Each Device In devlist
            If IsNumeric(Device.Temperature) Then
                If Convert.ToSingle(Device.Temperature) > tmax Then
                    tempthresh = tempthresh & Device.Model & ": " & Device.Temperature & "°C" & vbCrLf
                End If
            End If
        Next

        If tempthresh.Length > 0 And tempthresh.LastIndexOf(vbCrLf) = tempthresh.Length - 1 Then
            tempthresh = tempthresh.Substring(0, tempthresh.Length - 2)
        End If
    End Sub

    Private Sub OverallHealthCheck()
        chkhealth = ""

        Dim failure As Boolean = False
        For Each Device In devlist
            If Device.Health = Status.Failed Then
                chkhealth += Device.Model & vbCrLf
                failure = True
            End If
        Next

        'HDD Guardian tray icon type change between combinations of devices failure and program updates...
        If failure Then
            Dim healthicon As Bitmap
            If picNewVersion.Visible = True Then healthicon = My.Resources.update_ko Else healthicon = My.Resources.some_problems
            Dim geticon As IntPtr = healthicon.Clone(New Rectangle(0, 0, 16, 16), healthicon.PixelFormat).GetHicon
            niTrayIcon.Icon = Icon.FromHandle(geticon)
        Else
            Dim healthicon As Bitmap
            If picNewVersion.Visible = True Then healthicon = My.Resources.update_ok Else healthicon = My.Resources.all_ok
            Dim geticon As IntPtr = healthicon.Clone(New Rectangle(0, 0, 16, 16), healthicon.PixelFormat).GetHicon
            niTrayIcon.Icon = Icon.FromHandle(geticon)
        End If

        If chkhealth.Length > 0 And chkhealth.LastIndexOf(vbCrLf) = chkhealth.Length - 1 Then
            chkhealth = chkhealth.Substring(0, chkhealth.Length - 2)
        End If

        If My.Settings.ImminentFailure = False Then chkhealth = ""
    End Sub

#Region "Display warnings"

    Dim WithEvents tmrDelay As New Timer
    Dim Warning As Integer

    Public Sub DisplayWarnings()
        VitalsCheck()
        TemperatureCheck()
        OverallHealthCheck()
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
        With niTrayIcon
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
        End With
    End Sub

#End Region

#Region "Mail notifications"

    Public Sub SendNotificationMail()

        If Not My.Settings.MailSend Then Exit Sub

        'temperature
        If My.Settings.MailTemperature Then
            Dim tmax As Short = 49
            Dim threshold As String = ""
            If My.Settings.CustomTemperature Then
                tmax = Val(My.Settings.CustomTemperatureValue) - 1
            End If

            For Each Device In devlist
                If IsNumeric(Device.Temperature) Then
                    If Convert.ToSingle(Device.Temperature) > tmax And Not Device.AlreadySentNotification.Temperature Then
                        threshold = threshold & Device.Model & " (" & Device.Location & ")" & vbCrLf
                    End If
                End If
            Next

            If threshold.Length > 0 Then
                Dim tresult As Boolean = SendMail(GetString(3706), GetString(3721) & vbCrLf & vbCrLf & threshold)

                For Each Device In devlist
                    If tresult = True And Convert.ToSingle(Device.Temperature) > tmax Then
                        Device.AlreadySentNotification.Temperature = True
                    End If
                Next
            End If
        End If

        'health
        If My.Settings.MailFail Then
            Dim health As String = ""
            For Each Device In devlist
                If Device.Health = Status.Failed And Not Device.AlreadySentNotification.Health Then
                    health += Device.Model & " (" & Device.Location & ")" & vbCrLf
                End If
            Next

            If health.Length > 0 Then
                Dim hresult As Boolean = SendMail(GetString(3705), GetString(3720) & vbCrLf & vbCrLf & health)
                For Each Device In devlist
                    If Device.Health = Status.Failed And hresult = True Then
                        Device.AlreadySentNotification.Health = True
                    End If
                Next
            End If
        End If
    End Sub
#End Region

End Class
