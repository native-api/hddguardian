'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Partial Class Main
    Public Sub FillSidePanel()
        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)
        Dim path As String

        '*******************
        '***   general   ***
        '*******************
        'information

        If Not dev.IsVirtual Then
            Dim loc() As String = dev.Location.ToString.Split(" ")
            path = loc(0)
        Else
            If dev.Type = DeviceType.ThreeWare Then
                path = dev.Location
            Else
                path = dev.VirtualDeviceName
            End If
        End If

        lblLocationValue.Text = path
        picManufacturer.Image = dev.ManufacturerLogo
        lnkManufacturer.Text = dev.ManufacturerName
        lnkManufacturer.Tag = dev.ManufacturerWeb

        If dev.Type = DeviceType.SCSI Then
            lblModelValue.Text = dev.Scsi.Info.Product.Replace("N/A", "-")
            lblSerialValue.Text = dev.Scsi.Info.SerialNumber.Replace("N/A", "-")
            exlWwnId.Text = exlWwnId.ScsiText
            exlFirmware.Text = exlFirmware.ScsiText
            exlSectorBlock.Text = exlSectorBlock.ScsiText
            lblWwnIdValue.Text = dev.Scsi.Info.LogicalUnitId.Replace("N/A", "-")
            lblFirmwareValue.Text = dev.Scsi.Info.Revision.Replace("N/A", "-")
            lblSectorBlockValue.Text = dev.Scsi.Info.LogicalBlockSize.Replace("bytes", GetString(4801)).Replace("N/A", "-")
            If IsNumeric(dev.Scsi.Info.UserCapacity) Then
                Dim iec As String
                If Val(dev.Scsi.Info.UserCapacity / 1024 ^ 3) > 1000 Then
                    iec = Format(Val(dev.Scsi.Info.UserCapacity / 1024 ^ 4), "#.0") & " TiB"
                Else
                    iec = Format(Val(dev.Scsi.Info.UserCapacity / 1024 ^ 3), "#,###") & " GiB"
                End If
                Dim si As String
                If Val(dev.Scsi.Info.UserCapacity / 1000 ^ 3) > 1000 Then
                    si = Format(Val(dev.Scsi.Info.UserCapacity / 1000 ^ 4), "#.0") & " TB"
                Else
                    si = Format(Val(dev.Scsi.Info.UserCapacity / 1000 ^ 3), "#,###") & " GB"
                End If
                lblSizeValue.Text = iec & " / " & si
            Else
                lblSizeValue.Text = dev.Scsi.Info.UserCapacity.Replace("N/A", "-")
            End If
            lblRotationRateValue.Text = dev.Scsi.Info.RotationRate.Replace("N/A", "-")
            lblFactoryFormValue.Text = "-"
        Else
            lblModelValue.Text = dev.ATA.Info.Model.Replace("N/A", "-")
            lblSerialValue.Text = dev.ATA.Info.SerialNumber.Replace("N/A", "-")
            exlWwnId.Text = exlWwnId.AtaText
            exlFirmware.Text = exlFirmware.AtaText
            exlSectorBlock.Text = exlSectorBlock.AtaText
            lblWwnIdValue.Text = dev.ATA.Info.WorldWideName.Replace("N/A", "-")
            lblFirmwareValue.Text = dev.ATA.Info.FirmwareVersion.Replace("N/A", "-")
            lblSectorBlockValue.Text = dev.ATA.Info.SectorSize.Replace("bytes", GetString(4801)).Replace("logical", GetString(4802)).Replace("physical", GetString(4803)).Replace("N/A", "-")
            If IsNumeric(dev.ATA.Info.UserCapacity) Then
                Dim iec As String
                If Val(dev.ATA.Info.UserCapacity / 1024 ^ 3) > 1000 Then
                    iec = Format(Val(dev.ATA.Info.UserCapacity / 1024 ^ 4), "#.0") & " TiB"
                Else
                    iec = Format(Val(dev.ATA.Info.UserCapacity / 1024 ^ 3), "#,###") & " GiB"
                End If
                Dim si As String
                If Val(dev.ATA.Info.UserCapacity / 1000 ^ 3) > 1000 Then
                    si = Format(Val(dev.ATA.Info.UserCapacity / 1000 ^ 4), "#.0") & " TB"
                Else
                    si = Format(Val(dev.ATA.Info.UserCapacity / 1000 ^ 3), "#,###") & " GB"
                End If
                lblSizeValue.Text = iec & " / " & si
            Else
                lblSizeValue.Text = dev.ATA.Info.UserCapacity.Replace("N/A", "-")
            End If
            lblRotationRateValue.Text = dev.ATA.Info.RotationRate.Replace("N/A", "-")
            lblFactoryFormValue.Text = dev.ATA.Info.FormFactor.Replace("N/A", "-")
        End If

        lblInterfaceValue.Text = dev.Interface.Replace("N/A", "-")
        lblLetterValue.Text = "-"

        If Not dev.IsVirtual Then
            If Not IsNothing(Drives) Then
                Dim sn As String = ""
                If dev.Type = DeviceType.SCSI Then
                    sn = dev.Scsi.Info.SerialNumber.Replace("WD-", "")
                Else
                    sn = dev.ATA.Info.SerialNumber.Replace("WD-", "")
                End If

                Dim letters As String = ""
                For i As Short = 0 To Drives.Count - 1
                    If Drives(i).SerialNumber.ToString.Contains(sn) Then
                        For p As Short = 0 To Drives(i).Partitions.Count - 1
                            For l As Short = 0 To Drives(i).Partitions(p).Disk.Count - 1
                                letters += Drives(i).Partitions(p).Disk(l).VolumeLetter & ", "
                            Next
                        Next
                        Exit For
                    End If
                Next

                If letters.Contains(":") Then
                    lblLetterValue.Text = letters.Remove(letters.Length - 2, 2)
                Else
                    lblLetterValue.Text = "-"
                End If
            End If
        End If

        'smart
        Select Case dev.Smart.Support
            Case Support.Available
                Select Case dev.Smart.IsEnabled
                    Case Support.Enabled
                        lblSmartInfoValue.Text = m_available & " " & m_enabled
                    Case Support.Disabled
                        lblSmartInfoValue.Text = m_available & " " & m_disabled
                    Case Else
                        lblSmartInfoValue.Text = m_available
                End Select
            Case Support.Unavailable
                lblSmartInfoValue.Text = m_unavailable
            Case Support.Ambiguous
                Select Case dev.Smart.IsEnabled
                    Case Support.Enabled
                        lblSmartInfoValue.Text = m_ambiguous & " " & m_enabled
                    Case Support.Disabled
                        lblSmartInfoValue.Text = m_ambiguous & " " & m_disabled
                    Case Else
                        lblSmartInfoValue.Text = m_ambiguous
                End Select
            Case Support.Unknown
                lblSmartInfoValue.Text = m_unknown
        End Select

        'smartctl database
        If dev.Type = DeviceType.SCSI Then
            tlpDatabase.Visible = False
        Else
            If dev.Type = DeviceType.ThreeWare Then
                tlpDatabase.Visible = False
            Else
                If dev.ATA.Info.InDatabase Then
                    lblDatabaseInfoValue.Text = m_indatabase
                    Dim cs As New ColorScheme
                    lblDatabaseInfoValue.ForeColor = cs.ForeColor
                    cs = Nothing
                    lnkUpdateDatabase.Visible = False
                Else
                    lblDatabaseInfoValue.Text = m_notindatabase
                    lblDatabaseInfoValue.ForeColor = Color.Firebrick
                    lnkUpdateDatabase.Visible = True
                End If
                tlpDatabase.Visible = True
            End If

        End If

        'warnings
        If dev.Type = DeviceType.SCSI Then
            tlpWarnings.Visible = False
        Else
            If dev.Type = DeviceType.ThreeWare Then
                tlpWarnings.Visible = False
            Else
                tlpWarnings.Visible = False
                lblWarningValue.Text = ""
                lnkWeb1.Text = ""
                lnkWeb2.Text = ""
                lnkWeb3.Text = ""

                If dev.ATA.Info.Warning.Message <> "" Then
                    lblWarningValue.Text = dev.ATA.Info.Warning.Message
                    lblWarningValue.ForeColor = status_warning
                    If dev.ATA.Info.Warning.Links(0).Contains("Please see") Then lblWarningValue.Text += " Please see:"
                    lnkWeb1.Text = dev.ATA.Info.Warning.Links(0).Replace("Please see", "").Replace(" and", "").Replace(vbCr, "").Replace(vbLf, "").Trim
                    lnkWeb2.Text = dev.ATA.Info.Warning.Links(1).Replace(vbCr, "").Replace(vbLf, "").Trim
                    lnkWeb3.Text = dev.ATA.Info.Warning.Links(2).Replace(vbCr, "").Replace(vbLf, "").Trim
                    If dev.ATA.Info.Warning.Links(0) <> "" Then
                        lnkWeb1.AutoSize = True
                        lnkWeb2.AutoSize = True
                        lnkWeb3.AutoSize = True
                    End If
                    tlpWarnings.Visible = True
                Else
                    If dev.Smart.Support = Support.Available Then
                        If dev.Smart.IsEnabled <> Support.Enabled Then
                            lblWarningValue.Text = w_smartdisabled
                            lblWarningValue.ForeColor = status_warning
                            tlpWarnings.Visible = True
                        End If
                    Else
                        lblWarningValue.Text = w_smartunavailble
                        lblWarningValue.ForeColor = status_fail
                        tlpWarnings.Visible = True
                    End If
                    If dev.IsVirtual Then
                        If Not IO.File.Exists(dev.Location) Then
                            lblWarningValue.Text = w_repunavailabe
                            lblWarningValue.ForeColor = status_fail
                            tlpWarnings.Visible = True
                        End If
                    End If
                End If
            End If
        End If

        '******************
        '***   health   ***
        '******************
        'summary
        'temperature
        With lblTempValue
            If IsNumeric(dev.Temperature) Then
                Dim temp As String
                If AppSettings.General.TemperatureInFahrenheit = False Then
                    temp = dev.Temperature & "°C"
                Else
                    temp = Math.Round(dev.Temperature * 1.8 + 32) & "°F"
                End If

                Dim limit As Integer = 55
                If dev.Type <> DeviceType.SCSI Then
                    If IsNumeric(dev.ATA.Temperatures.RecommendedMax) Then
                        limit = dev.ATA.Temperatures.RecommendedMax
                    Else
                        limit = 55
                    End If
                End If
                Select Case dev.Temperature
                    Case 0 To limit - 6
                        .ForeColor = temp_ok
                        .Text = temp
                    Case limit - 5 To limit - 1
                        .ForeColor = temp_high
                        .Text = temp
                    Case Is >= limit
                        .ForeColor = temp_alarm
                        .Text = temp
                End Select
            Else
                .Text = "-"
                .ForeColor = Color.FromKnownColor(KnownColor.GrayText)
            End If
        End With

        'remaining life
        With lblRemainingLifeValue
            If dev.Type <> DeviceType.SCSI Then
                If IsNumeric(dev.ATA.Health.RemainingLife) Then
                    .Text = Val(dev.ATA.Health.RemainingLife) & "%"
                    Select Case Val(dev.ATA.Health.RemainingLife)
                        Case 0
                            .ForeColor = life_out
                        Case 1 To 10
                            .ForeColor = life_low
                        Case Is > 10
                            .ForeColor = life_ok
                    End Select
                Else
                    .Text = "-"
                    .ForeColor = Color.DarkGray
                End If
            Else
                .Text = "-"
                .ForeColor = Color.DarkGray
            End If
        End With

        'last test result
        If dev.Type = DeviceType.SCSI Then
            With lblLastTestValue
                If dev.Scsi.SelfTestLog.HasLog Then
                    .Text = dev.Scsi.SelfTestLog.Item(0).Status
                    If .Text.Contains("-->") Then .Text = .Text.Replace("-->", dev.Scsi.SelfTestLog.Item(0).SegmentNumber)

                    For i As Short = 0 To m_scsiresults.Count - 1
                        .Text = .Text.Replace(m_scsiresults(i).Original, m_scsiresults(i).Change & " ")
                        .Text = .Text.Trim().Replace(" ...", "")
                    Next

                    If dev.Scsi.SelfTestLog.Item(0).Status.Contains("Failed") Then
                        .ForeColor = status_fail
                    ElseIf dev.Scsi.SelfTestLog.Item(0).Status.Contains("Aborted") Then
                        .ForeColor = status_warning
                    ElseIf dev.Scsi.SelfTestLog.Item(0).Status.Contains("Incomplete") Then
                        .ForeColor = status_warning
                    Else
                        .ForeColor = status_ok
                    End If
                Else
                    .Text = "-"
                    .ForeColor = status_unknown
                End If
            End With
        Else
            If dev.Type = DeviceType.ThreeWare Then
                lblLastTestValue.ForeColor = status_unknown
                lblLastTestValue.Text = "-"
            Else
                If Not dev.ATA.SelfTests.Supported Then
                    lblLastTestValue.ForeColor = status_unknown
                    lblLastTestValue.Text = "-"
                Else
                    Dim res As Short = Val(dev.LastTestResult.Status)
                    Select Case res
                        Case 0
                            lblLastTestValue.ForeColor = status_ok
                            lblLastTestValue.Text = GetString(950)
                        Case 1 To 2
                            lblLastTestValue.ForeColor = status_warning
                            lblLastTestValue.Text = GetString(950 + res)
                        Case 3 To 8
                            lblLastTestValue.ForeColor = status_fail
                            lblLastTestValue.Text = GetString(950 + res)
                        Case 15
                            lblLastTestValue.ForeColor = status_unknown
                            lblLastTestValue.Text = GetString(959) & " " & GetString(961) & " " & dev.LastTestResult.Remaining & "%"
                        Case Else
                            lblLastTestValue.ForeColor = status_unknown
                            lblLastTestValue.Text = GetString(441)
                    End Select
                End If
            End If
        End If

        'health
        With lblHealthValue
            Select Case dev.Health
                Case Status.Failed
                    .ForeColor = status_fail
                    .Text = h_overallfailed
                Case Status.Passed
                    .ForeColor = status_ok
                    .Text = h_overallpassed
                Case Status.Unknown
                    If dev.Type = DeviceType.ThreeWare Then
                        .ForeColor = status_unknown
                        .Text = "-"
                    Else
                        .ForeColor = status_unknown
                        .Text = h_unknown
                    End If
            End Select
        End With

        'bad sectors/grown defects
        If dev.Type = DeviceType.SCSI Then
            exlBadSectors.Text = exlBadSectors.ScsiText
            With lblBadSectors
                .Text = dev.Scsi.Health.GrownDefectsCount
                If IsNumeric(dev.Scsi.Health.GrownDefectsCount) Then
                    If dev.Scsi.Health.GrownDefectsCount = 0 Then
                        .ForeColor = status_ok
                    Else
                        .ForeColor = status_warning
                    End If
                Else
                    .ForeColor = status_unknown
                End If
            End With
        Else
            exlBadSectors.Text = exlBadSectors.AtaText
            With lblBadSectors
                If IsNumeric(dev.ATA.Health.BadSectorsCount) Then
                    .Text = dev.ATA.Health.BadSectorsCount
                    Select Case Val(dev.ATA.Health.BadSectorsCount)
                        Case Is = 0
                            .ForeColor = status_ok
                        Case 1 To dev.ATA.Health.BadSectorsThreshold
                            .ForeColor = status_warning
                        Case Is > dev.ATA.Health.BadSectorsThreshold
                            .ForeColor = status_fail
                    End Select
                Else
                    .ForeColor = status_unknown
                    .Text = "-"
                End If
            End With
        End If

        'ata errors/non medium errors
        If dev.Type = DeviceType.SCSI Then
            exlErrors.Text = exlErrors.ScsiText
            With lblErrors
                .Text = dev.Scsi.Health.NonMediumErrors
                If IsNumeric(dev.Scsi.Health.NonMediumErrors) Then
                    If dev.Scsi.Health.NonMediumErrors = 0 Then
                        .ForeColor = status_ok
                    Else
                        .ForeColor = status_warning
                    End If
                Else
                    .ForeColor = status_unknown
                End If
            End With
        Else
            exlErrors.Text = exlErrors.AtaText
            With lblErrors
                .Text = dev.ATA.Errors.TotalAmount
                If Not IsNothing(dev.ATA.Errors.Items) Then
                    Select Case Val(dev.ATA.Errors.TotalAmount)
                        Case Is = 0
                            .ForeColor = status_ok
                        Case Is = 1
                            .ForeColor = status_warning
                        Case Is > 1
                            .ForeColor = status_warning
                    End Select
                Else
                    .ForeColor = status_unknown
                    .Text = "-"
                End If
            End With
        End If

        'work time
        lblWorkTimeValue.Text = dev.WorkTime.TotalHours
        If dev.WorkTime.TotalHours <> "N/A" Then
            lblWorkTimeValue.Text += vbCrLf & "(" & dev.WorkTime.Normalized & ")"
        Else
            lblWorkTimeValue.Text = "-"
        End If

        'last update
        lblLastUpdateValue.Text = dev.LastUpdate
        If dev.LastUpdate = "N/A" Then lblLastUpdateValue.Text = "-"

        'rating
        tlpRating.Visible = True
        ReliabilityDetails(dev)
    End Sub


End Class
