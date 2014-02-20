'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Partial Class Main

    Public Sub PopulateScsiPanels()
        isloading_devsettings = True

        Dim d As Device = devlist(cboDevices.SelectedIndex)

        '*** summary ***
        'temperature
        With lblScsiTempValue
            If IsNumeric(d.Temperature) Then
                If My.Settings.TempFahrenheit Then
                    .Text = Math.Round(d.Temperature * 1.8 + 32) & "°F"
                Else
                    .Text = d.Temperature & "°C"
                End If
                Select Case Val(d.Temperature)
                    Case 0 To 49
                        .ForeColor = temp_ok
                    Case 50 To 54
                        .ForeColor = temp_high
                    Case Is >= 55
                        .ForeColor = temp_alarm
                End Select
            Else
                .Text = "N/A"
                .ForeColor = Color.FromKnownColor(KnownColor.GrayText)
            End If
        End With
        'last test
        With lblScsiLastTestValue
            If d.ScsiHasSelfTestLog Then
                .Text = d.ScsiSelfTests(0).Status
                If .Text.Contains("-->") Then .Text = .Text.Replace("-->", d.ScsiSelfTests(0).SegmentNumber)

                For i As Short = 0 To m_scsiresults.Count - 1
                    .Text = .Text.Replace(m_scsiresults(i).Original, m_scsiresults(i).Change & " ")
                    .Text = .Text.Trim().Replace(" ...", "")
                Next

                Select Case d.ScsiSelfTests(0).Status
                    Case d.ScsiSelfTests(0).Status.Contains("Failed")
                        .ForeColor = status_fail
                    Case d.ScsiSelfTests(0).Status.Contains("Aborted")
                        .ForeColor = status_warning
                    Case d.ScsiSelfTests(0).Status.Contains("Incomplete")
                        .ForeColor = status_warning
                    Case Else
                        .ForeColor = status_ok
                End Select
            Else
                .Text = "N/A"
                .ForeColor = status_unknown
            End If
        End With
        'health value
        With lblScsiHealthValue
            Select Case d.Health
                Case Status.Unkonwn
                    .ForeColor = health_unknown
                    .Text = "N/A"
                Case Status.Passed
                    .ForeColor = health_passed
                    .Text = h_overallpassed
                Case Status.Failed
                    .ForeColor = health_fail
                    .Text = h_overallfailed
            End Select
        End With
        'grown defects
        With lblScsiGrownDefects
            .Text = .Tag & ": " & d.GrownDefectsCount
            If IsNumeric(d.GrownDefectsCount) Then
                If d.GrownDefectsCount = 0 Then
                    .ForeColor = status_ok
                Else
                    .ForeColor = status_warning
                End If
            Else
                .ForeColor = status_unknown
            End If
        End With
        'non medium errors count
        With lblScsiErrors
            .Text = .Tag & ": " & d.NonMediumErrors
            If IsNumeric(d.NonMediumErrors) Then
                If d.NonMediumErrors = 0 Then
                    .ForeColor = status_ok
                Else
                    .ForeColor = status_warning
                End If
            Else
                .ForeColor = status_unknown
            End If
        End With
        'last update
        lblScsiLastUpdateValue.Text = d.LastCheck

        '*** device info ***

        lblScsiModel.Text = d.Model
        lblScsiRevisionValue.Text = d.Revision
        lblScsiSerialValue.Text = d.SerialNumber
        lblScsiUnitIdValue.Text = d.LogicalUnitId
        If IsNumeric(d.UserCapacity) Then
            lblScsiTotalSizeValue.Text = Format(Val(d.UserCapacity), "#,###") & " bytes"
        Else
            lblScsiTotalSizeValue.Text = "N/A"
        End If
        lblScsiBlockSizeValue.Text = d.LogicalBlockSize
        lblScsiRotationValue.Text = d.RotationRate
        lblScsiProtocolValue.Text = d.InterfaceProtocol
        With lblScsiSmartStatusValue
            Select Case d.SmartSupport
                Case Support.Available
                    Select Case d.SmartEnabled
                        Case Support.Enabled
                            .Text = m_available & " " & m_enabled
                        Case Support.Disabled
                            .Text = m_available & " " & m_disabled
                        Case Else
                            .Text = m_available
                    End Select
                Case Support.Unavailable
                    .Text = m_unavailable
                Case Support.Ambiguous
                    Select Case d.SmartEnabled
                        Case Support.Enabled
                            .Text = m_ambiguous & " " & m_enabled
                        Case Support.Disabled
                            .Text = m_ambiguous & " " & m_disabled
                        Case Else
                            .Text = m_ambiguous
                    End Select
                Case Support.Unknown
                    .Text = m_unknown
            End Select
        End With

        '*******************
        '*** SMART setup ***
        '*******************
        'smart
        If d.SmartSupport = Support.Available Then
            If d.Type = DeviceType.Virtual Then
                chkScsiSmart.Enabled = False
            Else
                chkScsiSmart.Enabled = True
            End If
            If d.SmartEnabled = Support.Enabled Then
                chkScsiSmart.Checked = True
            Else
                chkScsiSmart.Checked = False
            End If
        Else
            chkScsiSmart.Enabled = False
            chkScsiSmart.Checked = False
        End If
        'gltsd
        If d.Type = DeviceType.Virtual Then
            chkScsiGltsd.Enabled = False
        Else
            chkScsiGltsd.Enabled = True
        End If
        chkScsiGltsd.Checked = d.ScsiGltsdStatus
        'write cache
        If d.ScsiWriteCacheAvailable Then
            If d.Type = DeviceType.Virtual Then
                chkScsiWCache.Enabled = False
            Else
                chkScsiWCache.Enabled = True
            End If
            chkScsiWCache.Checked = d.ScsiWriteCacheEnabled
        Else
            chkScsiWCache.Checked = False
            chkScsiWCache.Enabled = False
        End If
        'read cache
        If d.ScsiReadCacheAvailable Then
            If d.Type = DeviceType.Virtual Then
                chkScsiRCache.Enabled = False
            Else
                chkScsiRCache.Enabled = True
            End If
            chkScsiRCache.Checked = d.ScsiReadCacheEnabled
        Else
            chkScsiRCache.Checked = False
            chkScsiRCache.Enabled = False
        End If

        '**************
        '*** errors ***
        '**************
        With tvwScsiErrors
            If d.ScsiHasErrorLog Then
                lblScsiNoErrors.Visible = False
                .Nodes.Clear()
                If d.ReadErrors.HaveEntries Then
                    .Nodes.Add("r", m_scsiread)
                    With .Nodes("r")
                        .Nodes.Add("r_ecc", m_scsiecc)
                        With .Nodes("r_ecc")
                            .Nodes.Add(m_scsifast & ": " & Format(Val(d.ReadErrors.EccFast), "#,##0"))
                            .Nodes.Add(m_scsidelayed & ": " & Format(Val(d.ReadErrors.EccDelayed), "#,##0"))
                            .Nodes.Add(m_scsirrrw & ": " & Format(Val(d.ReadErrors.EccReReadsReWrites), "#,##0"))
                        End With
                        .Nodes.Add(m_scsicorrected & ": " & Format(Val(d.ReadErrors.ErrorsCorrected), "#,##0"))
                        .Nodes.Add(m_scsialgorithm & ": " & Format(Val(d.ReadErrors.CorrectionAlgorithmInvocations), "#,##0"))
                        .Nodes.Add(m_scsigb & ": " & Format(Val(d.ReadErrors.GbProcessed), "#,##0.00"))
                        .Nodes.Add(m_scsiuncorrected & ": " & Format(Val(d.ReadErrors.UncorrectedErrors), "#,##0"))
                    End With
                End If
                If d.WriteErrors.HaveEntries Then
                    .Nodes.Add("w", m_scsiwrite)
                    With .Nodes("w")
                        .Nodes.Add("w_ecc", m_scsiecc)
                        With .Nodes("w_ecc")
                            .Nodes.Add(m_scsifast & ": " & Format(Val(d.WriteErrors.EccFast), "#,##0"))
                            .Nodes.Add(m_scsidelayed & ": " & Format(Val(d.WriteErrors.EccDelayed), "#,##0"))
                            .Nodes.Add(m_scsirrrw & ": " & Format(Val(d.WriteErrors.EccReReadsReWrites), "#,##0"))
                        End With
                        .Nodes.Add(m_scsicorrected & ": " & Format(Val(d.WriteErrors.ErrorsCorrected), "#,##0"))
                        .Nodes.Add(m_scsialgorithm & ": " & Format(Val(d.WriteErrors.CorrectionAlgorithmInvocations), "#,##0"))
                        .Nodes.Add(m_scsigb & ": " & Format(Val(d.WriteErrors.GbProcessed), "#,##0.00"))
                        .Nodes.Add(m_scsiuncorrected & ": " & Format(Val(d.WriteErrors.UncorrectedErrors), "#,##0"))
                    End With
                End If
                If d.VerifyErrors.HaveEntries Then
                    .Nodes.Add("v", m_scsiverify)
                    With .Nodes("v")
                        .Nodes.Add("v_ecc", m_scsiecc)
                        With .Nodes("v_ecc")
                            .Nodes.Add(m_scsifast & ": " & Format(Val(d.VerifyErrors.EccFast), "#,##0"))
                            .Nodes.Add(m_scsidelayed & ": " & Format(Val(d.VerifyErrors.EccDelayed), "#,##0"))
                            .Nodes.Add(m_scsirrrw & ": " & Format(Val(d.VerifyErrors.EccReReadsReWrites), "#,##0"))
                        End With
                        .Nodes.Add(m_scsicorrected & ": " & Format(Val(d.VerifyErrors.ErrorsCorrected), "#,##0"))
                        .Nodes.Add(m_scsialgorithm & ": " & Format(Val(d.VerifyErrors.CorrectionAlgorithmInvocations), "#,##0"))
                        .Nodes.Add(m_scsigb & ": " & Format(Val(d.VerifyErrors.GbProcessed), "#,##0.00"))
                        .Nodes.Add(m_scsiuncorrected & ": " & Format(Val(d.VerifyErrors.UncorrectedErrors), "#,##0"))
                    End With
                End If
                .Visible = True
            Else
                lblScsiNoErrors.Visible = True
                .Visible = False
            End If
        End With

        '*********************
        '*** tests results ***
        '*********************
        With lvwScsiTests
            .Items.Clear()
            If d.ScsiSelfTests.Count > 0 Then
                lblScsiTestCounter.Visible = False
                For i As Short = 0 To d.ScsiSelfTests.Count - 1
                    .Items.Add(d.ScsiSelfTests(i).Num)
                    With .Items(.Items.Count - 1)
                        Dim desc As String = d.ScsiSelfTests(i).Description
                        Dim status As String = d.ScsiSelfTests(i).Status
                        For n As Short = 0 To m_scsidescription.Count - 1
                            desc = desc.Replace(m_scsidescription(n).Original, m_scsidescription(n).Change).Trim
                        Next
                        For n As Short = 0 To m_scsiresults.Count - 1
                            status = status.Replace(m_scsiresults(n).Original, m_scsiresults(n).Change).Trim
                        Next
                        .SubItems.Add(desc)
                        If status.Contains("-->") Then
                            .SubItems.Add(status.Replace("-->", d.ScsiSelfTests(i).SegmentNumber))
                        Else
                            .SubItems.Add(status)
                        End If
                        .SubItems.Add(d.ScsiSelfTests(i).SegmentNumber)
                        .SubItems.Add(d.ScsiSelfTests(i).LifeTime)
                        .SubItems.Add(d.ScsiSelfTests(i).LbaFirstError)
                        .SubItems.Add(d.ScsiSelfTests(i).SK)
                        .SubItems.Add(d.ScsiSelfTests(i).ASC)
                        .SubItems.Add(d.ScsiSelfTests(i).ASQ)
                    End With
                Next
                .Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                .Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                .Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                .Columns(3).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                .Columns(4).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                .Columns(5).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                .Columns(6).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                .Columns(7).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                .Columns(8).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                .Visible = True
            Else
                lblScsiTestCounter.Visible = True
                .Visible = False
            End If
        End With
        '*** run test ***
        pnlScsiTestRun.Visible = False
        btnScsiStop.Visible = False
        If IsNumeric(d.ScsiTestDuration) Then
            lblScsiTest.Text = lblScsiTest.Tag.ToString.Replace("%1", d.ScsiTestDuration).Replace("%2", d.ScsiTestDuration \ 60)
            btnScsiRun.Enabled = True

            If d.Type = DeviceType.Virtual Then
                tlpScsiTest.Visible = False
            Else
                tlpScsiTest.Visible = True
            End If
        Else
            lblScsiTest.Text = d.ScsiTestDuration
            btnScsiRun.Enabled = False
        End If

        '*** smartctl section ***
        txtReport.Text = d.Output
        'chkTolerance.Enabled = False
        'chkTolerance.Checked = False
        'chkAttributes.Enabled = False
        'chkAttributes.Checked = False
        'chkFirmware.Enabled = False
        'chkFirmware.Checked = False
        'chkPowerMode.Enabled = False
        'chkPowerMode.Checked = False

        isloading_devsettings = False

        FillBottomPanel()
        SetManufacturer()
        'SetOsPicture()
        'SetRating()
    End Sub

End Class
