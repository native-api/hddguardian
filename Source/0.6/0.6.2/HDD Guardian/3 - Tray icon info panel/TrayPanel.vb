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

    Public Sub SetPanel(ByVal Ssd As Boolean, ByVal model As String, ByVal location As String, ByVal rating As Ratings, ByVal temperature As String, ByVal remaininglife As String, ByVal health As Status, ByVal type As DeviceType)
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
                Case Status.Unkonwn
                    .ForeColor = health_unknown
                    .Text = Main.m_healthunknown
            End Select
        End With

        If IsNumeric(temperature) Then
            With lblTempInfoValue
                If My.Settings.TempFahrenheit = True Then
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

        'try to detect manufacturer from device model
        For i As Short = 0 To Main.manufacturersList.Count - 1
            If Not IsNothing(model) Then
                Dim re As New Regex(Main.manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                If re.Match(model).Success Then
                    If type = DeviceType.USB Then
                        picDeviceImage.BackgroundImage = Main.manufacturersList(i).USB
                    Else
                        If Ssd Then
                            picDeviceImage.BackgroundImage = Main.manufacturersList(i).SDD
                        Else
                            picDeviceImage.BackgroundImage = Main.manufacturersList(i).HDD
                        End If
                    End If
                    Exit For
                End If
            End If
        Next

        If IsNothing(picDeviceImage.BackgroundImage) Then
            If type = DeviceType.USB Then
                picDeviceImage.BackgroundImage = My.Resources.XCraft
            Else
                picDeviceImage.BackgroundImage = My.Resources.Raptor_X
            End If
        End If

        picReliability.Image = Nothing
        If Not My.Settings.EnableRating Then
            picReliability.Visible = False
        Else
            picReliability.Visible = True
        End If

        Select Case rating.Overall
            Case 5
                picReliability.Image = My.Resources.r5_star
            Case 4
                picReliability.Image = My.Resources.r4_star
            Case 3
                picReliability.Image = My.Resources.r3_star
            Case 2
                picReliability.Image = My.Resources.r2_star
            Case 1
                picReliability.Image = My.Resources.r1_star
            Case 0
                picReliability.Image = My.Resources.r0_star
            Case Else
                picReliability.Image = My.Resources.r0_star
        End Select

        SetPanelPosition()
    End Sub
End Class