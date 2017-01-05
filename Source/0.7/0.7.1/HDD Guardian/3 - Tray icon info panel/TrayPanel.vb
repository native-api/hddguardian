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

Public Class TrayPanel

    Private Sub TrayPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPanelPosition()
    End Sub

    Private Sub SetPanelPosition()
        Dim s As Rectangle

        s = My.Computer.Screen.WorkingArea

        Me.Top = s.Height - Me.Height - 2
        Me.Left = s.Width - Me.Width - 2
    End Sub

    Public Sub SetPanel(ByVal Ssd As Boolean, ByVal model As String, ByVal location As String, ByVal rating As Device.AtaRatings, ByVal temperature As String, ByVal remaininglife As String, ByVal health As Status, ByVal type As DeviceType, ByVal devImage As Bitmap)
        lblDeviceName.Text = model

        Dim loc() As String = location.Split(" ")
        lblDeviceLocation.Text = loc(0)

        With lblHealthInfoValue
            Select Case health
                Case Status.Failed
                    .ForeColor = health_fail
                    .Text = Main.m_healthfailed
                Case Status.Passed
                    .ForeColor = health_passed
                    .Text = Main.m_healthpassed
                Case Status.Unknown
                    .ForeColor = health_unknown
                    .Text = Main.m_healthunknown
            End Select
        End With

        If IsNumeric(temperature) Then
            With lblTempInfoValue
                If AppSettings.General.TemperatureInFahrenheit = True Then
                    .Text = Math.Round(temperature * 1.8 + 32) & "°F"
                Else
                    .Text = temperature & "°C"
                End If
                Select Case Val(temperature)
                    Case 0 To 49
                        .ForeColor = temp_ok
                    Case 50 To 54
                        .ForeColor = temp_high
                    Case Is >= 55
                        .ForeColor = temp_alarm
                End Select
            End With
        Else
            With lblTempInfoValue
                .Text = temperature
                .ForeColor = Color.DarkGray
            End With
        End If

        If IsNumeric(remaininglife) Then
            With lblLifeValue
                .Text = Val(remaininglife) & "%"
                Select Case Val(remaininglife)
                    Case 0
                        .ForeColor = life_out
                    Case 1 To 10
                        .ForeColor = life_low
                    Case Is > 10
                        .ForeColor = life_ok
                End Select
            End With
        Else
            With lblLifeValue
                .Text = remaininglife
                .ForeColor = Color.DarkGray
            End With
        End If

        picDeviceImage.BackgroundImage = Nothing

        picDeviceImage.BackgroundImage = devImage

        If IsNothing(picDeviceImage.BackgroundImage) Then
            If type = DeviceType.USB Then
                picDeviceImage.BackgroundImage = My.Resources.XCraft
            Else
                picDeviceImage.BackgroundImage = My.Resources.Raptor_X
            End If
        End If

        picReliability.Image = Nothing
        If Not AppSettings.Reliability.Enable Then
            picReliability.Visible = False
        Else
            picReliability.Visible = True
        End If

        Select Case rating.Overall
            Case 5
                picReliability.Image = My.Resources.rating_5
            Case 4
                picReliability.Image = My.Resources.rating_4
            Case 3
                picReliability.Image = My.Resources.rating_3
            Case 2
                picReliability.Image = My.Resources.rating_2
            Case 1
                picReliability.Image = My.Resources.rating_1
            Case 0
                picReliability.Image = My.Resources.rating_0
            Case Else
                picReliability.Image = My.Resources.rating_0
        End Select

        SetPanelPosition()
    End Sub
End Class