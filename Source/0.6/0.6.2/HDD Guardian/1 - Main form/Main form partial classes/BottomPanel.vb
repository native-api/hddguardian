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

Partial Class Main

    Public Sub FillBottomPanel()
        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)
        Dim size, model, path, firmware, serial As String

        If (dev.Type = DeviceType.ATA Or dev.Type = DeviceType.USB Or dev.Type = DeviceType.SCSI) _
            Or (dev.Type = DeviceType.Virtual And IO.File.Exists(dev.Location)) _
            Or dev.Type = DeviceType.Threeware Then
            If Not dev.Type = DeviceType.Virtual Then
                Dim loc() As String = dev.Location.ToString.Split(" ")
                path = loc(0)
            Else
                path = dev.VirtualDeviceInfo.Description
            End If
            model = dev.Model
            size = dev.UserCapacity
            serial = dev.SerialNumber
        Else
            With dev.VirtualDeviceInfo
                path = .Description
                model = .Model
                Dim s() As String = .UserSize.Split("bytes")
                size = ""
                For i As Integer = 0 To s(0).Length - 1
                    If IsNumeric(s(0).Chars(i)) Then size = size & s(0).Chars(i)
                Next
                If IsNumeric(size) Then
                    Dim iec As String
                    If Val(size / 1024 ^ 3) > 1000 Then
                        iec = Format(Val(size / 1024 ^ 4), "#.#") & " TiB"
                    Else
                        iec = Format(Val(size / 1024 ^ 3), "#,###") & " GiB"
                    End If
                    Dim si As String
                    If Val(size / 1000 ^ 3) > 1000 Then
                        si = Format(Val(size / 1000 ^ 4), "#.#") & " TB"
                    Else
                        si = Format(Val(size / 1000 ^ 3), "#,###") & " GB"
                    End If
                    size = iec & " / " & si
                Else
                    size = .UserSize
                End If
                firmware = .Firmware
                serial = .SerialNumber
            End With
        End If

        If IsNumeric(size) Then
            Dim iec As String
            If Val(size / 1024 ^ 3) > 1000 Then
                iec = Format(Val(size / 1024 ^ 4), "#.0") & " TiB"
            Else
                iec = Format(Val(size / 1024 ^ 3), "#,###") & " GiB"
            End If
            Dim si As String
            If Val(size / 1000 ^ 3) > 1000 Then
                si = Format(Val(size / 1000 ^ 4), "#.0") & " TB"
            Else
                si = Format(Val(size / 1000 ^ 3), "#,###") & " GB"
            End If
            lblDeviceSize.Text = iec & " / " & si
        Else
            lblDeviceSize.Text = size
        End If
        lblDeviceName.Text = model
        lblDeviceLocation.Text = path
        lblSerialNumberValue.Text = serial

        With lblHealthInfoValue
            Select Case dev.Health
                Case Status.Failed
                    .ForeColor = health_fail
                    .Text = m_healthfailed
                Case Status.Passed
                    .ForeColor = health_passed
                    .Text = m_healthpassed
                Case Status.Unkonwn
                    .ForeColor = health_unknown
                    .Text = m_healthunknown
            End Select
        End With

        If IsNumeric(dev.Temperature) Then
            With lblTempInfoValue
                If My.Settings.TempFahrenheit = True Then
                    .Text = Math.Round(dev.Temperature * 1.8 + 32) & "°F"
                Else
                    .Text = dev.Temperature & "°C"
                End If
                Select Case Val(dev.Temperature)
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
                .Text = dev.Temperature
                .ForeColor = Color.DarkGray
            End With
        End If

        If IsNumeric(dev.RemainingLife) Then
            With lblLifeValue
                .Text = Val(dev.RemainingLife) & "%"
                Select Case Val(dev.RemainingLife)
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
                .Text = dev.RemainingLife
                .ForeColor = Color.DarkGray
            End With
        End If

        If dev.IsScsi Then
            lblFirmware.Text = lblFirmware.ScsiText
            lblFirmwareValue.Text = dev.Revision
            lblAtaErrors.Text = lblAtaErrors.ScsiText
            lblAtaErrorsValue.Text = dev.GrownDefectsCount
            lblBadSectorsInfo.Text = lblBadSectorsInfo.ScsiText
            lblBadSectorsInfoValue.Text = dev.NonMediumErrors
            With lblAtaErrorsValue
                If IsNumeric(dev.GrownDefectsCount) Then
                    If dev.GrownDefectsCount = 0 Then
                        .ForeColor = status_ok
                    Else
                        .ForeColor = status_warning
                    End If
                Else
                    .ForeColor = Color.DarkGray
                End If
            End With
            With lblBadSectorsInfoValue
                If IsNumeric(dev.NonMediumErrors) Then
                    If dev.NonMediumErrors = 0 Then
                        .ForeColor = status_ok
                    Else
                        .ForeColor = status_warning
                    End If
                Else
                    .ForeColor = Color.DarkGray
                End If
            End With
        Else
            lblFirmware.Text = lblFirmware.AtaText
            lblFirmwareValue.Text = dev.FirmwareVersion
            lblAtaErrors.Text = lblAtaErrors.AtaText
            lblBadSectorsInfo.Text = lblBadSectorsInfo.AtaText
            With lblBadSectorsInfoValue
                If IsNumeric(dev.BadSectorsCount) Then
                    lblBadSectorsInfoValue.Text = dev.BadSectorsCount
                    Select Case Val(dev.BadSectorsCount)
                        Case 0
                            .ForeColor = status_ok
                        Case 1 To 50
                            .ForeColor = status_warning
                        Case Is > 50
                            .ForeColor = status_fail
                    End Select
                Else
                    lblBadSectorsInfoValue.Text = "N/A"
                    .ForeColor = status_unknown
                End If
                If dev.Type = DeviceType.Threeware And Not dev.IsValidDevice Then
                    lblBadSectorsInfoValue.Text = "N/A"
                    .ForeColor = status_unknown
                End If
            End With
            With lblAtaErrorsValue
                If Not IsNothing(dev.Errors) Then
                    lblAtaErrorsValue.Text = dev.TotalErrors
                    Select Val(dev.TotalErrors)
                        Case 0
                            .ForeColor = status_ok
                        Case Else '1 To 10
                            .ForeColor = status_warning
                            'Case Is > 10
                            '.ForeColor = status_warning
                    End Select
                Else
                    lblAtaErrorsValue.Text = "N/A"
                    .ForeColor = status_unknown
                End If
            End With
        End If

        lblWorkTimeValue.Text = dev.WorkTime
        If dev.WorkTime <> "N/A" Then
            ttMain.SetToolTip(lblWorkTimeValue, dev.WorkTimeHuman)
        Else
            lblWorkTimeValue.Text = m_unknown
            ttMain.SetToolTip(lblWorkTimeValue, Nothing)
        End If

        SetDeviceImage()
        'SetBottomPanelManufacturer()
        SetRating()

    End Sub

End Class
