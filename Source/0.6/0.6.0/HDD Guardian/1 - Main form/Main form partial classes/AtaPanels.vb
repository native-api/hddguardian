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

    Public Sub PopulateAtaPanels()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        GeneralInfo()
        FillSmartctlPanels()
        SmartAttributes()
        SmartSwitches()
        Performace()
        AtaErrors()
        SelfTestLog()
        SelectiveSelfTestLog()
        UpdateTestTiming()
        SetRating()
        ReliabilityDetails()

        'set events logs
        DisplayLogEvents()
        FillChartEvents()
        FillList()
        SetGraph()

        SetManufacturer()
        DisableFunctions()
    End Sub

    Private Sub GeneralInfo()
        Dim dev As Device = devlist(cboDevices.SelectedIndex) 'devlist(lvwDevices.SelectedItems(0).Index)
        '************************
        '***   manufacturer   ***
        '************************
        lblModel.Text = dev.Model
        If dev.Family <> "N/A" Then
            lblFamily.Text = dev.Family
            lblFamily.Visible = True
        Else
            lblFamily.Visible = False
        End If
        '**************************
        '***   device details   ***
        '**************************
        lblSerialValue.Text = dev.SerialNumber
        lblWwnValue.Text = dev.WorldWideName
        lblFirmwareInfoValue.Text = dev.FirmwareVersion

        If dev.Type = DeviceType.Virtual And Not IsNothing(dev.VirtualDeviceInfo) Then
            Dim s() As String = dev.VirtualDeviceInfo.UserSize.Split("bytes")
            Dim size As String = ""
            For i As Integer = 0 To s(0).Length - 1
                If IsNumeric(s(0).Chars(i)) Then size = size & s(0).Chars(i)
            Next
            If IsNumeric(size) Then
                lblTotalSizeValue.Text = Format(Val(size), "#,###") & " " & m_bytes
            Else
                lblTotalSizeValue.Text = "N/A"
            End If
        Else
            If IsNumeric(dev.UserCapacity) Then
                lblTotalSizeValue.Text = Format(Val(dev.UserCapacity), "#,###") & " " & m_bytes
            Else
                lblTotalSizeValue.Text = "N/A"
            End If
        End If


        If Not IsNothing(dev.SectorSize) Then
            lblSectorSizeValue.Text = dev.SectorSize.Replace("bytes", m_bytes).Replace("logical", m_logical).Replace("physical", m_physical)
        End If
        lblAtaVersionValue.Text = dev.AtaVersion
        Select Case dev.SmartSupport
            Case Support.Available
                Select Case dev.SmartEnabled
                    Case Support.Enabled
                        lblSmartStatusValue.Text = m_available & " " & m_enabled
                    Case Support.Disabled
                        lblSmartStatusValue.Text = m_available & " " & m_disabled
                    Case Else
                        lblSmartStatusValue.Text = m_available
                End Select
            Case Support.Unavailable
                lblSmartStatusValue.Text = m_unavailable
            Case Support.Ambiguous
                Select Case dev.SmartEnabled
                    Case Support.Enabled
                        lblSmartStatusValue.Text = m_ambiguous & " " & m_enabled
                    Case Support.Disabled
                        lblSmartStatusValue.Text = m_ambiguous & " " & m_disabled
                    Case Else
                        lblSmartStatusValue.Text = m_ambiguous
                End Select
            Case Support.Unknown
                lblSmartStatusValue.Text = m_unknown
        End Select
        lblRotationValue.Text = dev.RotationRate
        lblSataVersionValue.Text = dev.SataVersion
        '*************************
        '***   health status   ***
        '*************************
        'temperature
        With lblTempValue
            If IsNumeric(dev.Temperature) Then
                Dim temp As String
                If My.Settings.TempFahrenheit = False Then
                    temp = dev.Temperature & "°C"
                Else
                    temp = Math.Round(dev.Temperature * 1.8 + 32) & "°F"
                End If
                Select Case dev.Temperature
                    Case 0 To 49
                        .ForeColor = temp_ok
                        .Text = temp
                    Case 50 To 54
                        .ForeColor = temp_high
                        .Text = temp
                    Case Is >= 55
                        .ForeColor = temp_high
                        .Text = temp
                End Select
            Else
                .Text = "N/A"
                .ForeColor = Color.FromKnownColor(KnownColor.GrayText)
            End If
        End With
        'remaining life
        With lblRemainingLifeValue
            If IsNumeric(dev.RemainingLife) Then
                .Text = Val(dev.RemainingLife) & "%"
                Select Case Val(dev.RemainingLife)
                    Case 0
                        .ForeColor = life_out
                    Case 1 To 10
                        .ForeColor = life_low
                    Case Is > 10
                        .ForeColor = life_ok
                End Select
            Else
                .Text = "N/A"
                .ForeColor = Color.DarkGray
            End If
        End With
        'last test results
        Dim res As String = dev.LastTestResults.Status
        If Not IsNothing(res) Then
            For i As Short = 0 To m_testresults.Count - 1
                res = res.Replace(m_testresults(i).Original, m_testresults(i).Change)
            Next
        End If
        With lblLastTestValue
            Select Case dev.LastTestResults.IsPassed
                Case Status.Failed
                    Dim remaining As Short = 100 - Val(dev.LastTestResults.Remaining)
                    .ForeColor = status_warning
                    .Text = res & " " & m_testresults(m_testresults.Count - 1).Change & " " & remaining & "%"
                Case Status.Passed
                    .ForeColor = status_ok
                    .Text = res
                Case Status.Unkonwn
                    .ForeColor = Color.DarkGray
                    .Text = "N/A"
            End Select
        End With
        'overall health
        With lblHealthValue
            Select Case dev.Health
                Case Status.Failed
                    .ForeColor = status_fail
                    .Text = h_overallfailed
                Case Status.Passed
                    .ForeColor = status_ok
                    .Text = h_overallpassed
                Case Status.Unkonwn
                    .ForeColor = Color.DarkGray
                    .Text = h_unknown
            End Select
        End With
        'bad sectors
        If dev.IsSsd Then
            lblBadSectors.Visible = False
        Else
            With lblBadSectors
                .Visible = True
                Select Case dev.BadSectorsCount
                    Case Is = 0
                        .ForeColor = status_ok
                        .Text = badsect_no
                    Case Is = 1
                        .ForeColor = status_warning
                        .Text = badsect_one
                    Case 2 To 50
                        .ForeColor = status_warning
                        .Text = badsect_few.Replace("%", dev.BadSectorsCount)
                    Case Is > 50
                        .ForeColor = status_fail
                        .Text = badsect_several.Replace("%", dev.BadSectorsCount)
                    Case Else
                        .ForeColor = status_unknown
                        .Text = "N/A"
                End Select
            End With
        End If

        'ata errors
        With lblErrorsAta
            If Not IsNothing(dev.Errors) Then
                Select Case dev.Errors.Count
                    Case Is = 0
                        .ForeColor = status_ok
                        .Text = error_no
                    Case Is = 1
                        .ForeColor = status_warning
                        .Text = error_one
                    Case 1 To 10
                        .ForeColor = status_warning
                        .Text = error_few.Replace("%", dev.Errors.Count)
                    Case Is > 10
                        .ForeColor = status_fail
                        .Text = error_several.Replace("%", dev.Errors.Count)
                End Select
            Else
                .ForeColor = status_unknown
                .Text = "N/A"
            End If
        End With
        'last update
        lblLastUpdateValue.Text = dev.LastCheck
        '****************************
        '*** in smartctl database ***
        '****************************
        If dev.InDatabase Then
            lblInDatabase.Text = m_indatabase
            lblInDatabase.ForeColor = Color.Black
        Else
            lblInDatabase.Text = m_notindatabase
            lblInDatabase.ForeColor = Color.Firebrick
        End If
        '****************
        '*** warnings ***
        '****************
        If dev.Warning.Warning <> "" Then
            lblWarningValue.Text = dev.Warning.Warning
            lblWarningValue.ForeColor = status_warning
            If dev.Warning.Link1.Contains("Please see") Then lblWarningValue.Text += " Please see:"
            lnkWeb1.Text = dev.Warning.Link1.Replace("Please see", "").Replace(" and", "").Replace(vbCr, "").Replace(vbLf, "").Trim
            lnkWeb2.Text = dev.Warning.Link2.Replace(vbCr, "").Replace(vbLf, "").Trim
            lnkWeb3.Text = dev.Warning.Link3.Replace(vbCr, "").Replace(vbLf, "").Trim
        Else
            If dev.SmartSupport = Support.Available Then
                If dev.SmartEnabled = Support.Enabled Then
                    lblWarningValue.Text = w_no
                    lblWarningValue.ForeColor = Color.Black
                Else
                    lblWarningValue.Text = w_smartdisabled
                    lblWarningValue.ForeColor = status_warning
                End If
            Else
                lblWarningValue.Text = w_smartunavailble
                lblWarningValue.ForeColor = status_fail
            End If
            If dev.Type = DeviceType.Virtual Then
                If Not IO.File.Exists(dev.Location) Then
                    lblWarningValue.Text = w_repunavailabe
                    lblWarningValue.ForeColor = status_fail
                End If
            End If
        End If

        If dev.Warning.Link1 <> "" Then
            lnkWeb1.AutoSize = True
            lnkWeb2.AutoSize = True
            lnkWeb3.AutoSize = True
        Else
            lnkWeb1.AutoSize = False
            lnkWeb1.Size = New Size(0, 0)
            lnkWeb2.AutoSize = False
            lnkWeb2.Size = New Size(0, 0)
            lnkWeb3.AutoSize = False
            lnkWeb3.Size = New Size(0, 0)
        End If
    End Sub

    Private Sub SmartSwitches()

        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)
        isloading_features = True

        Select Case dev.SmartEnabled
            Case Support.Enabled
                chkEnableSmart.Checked = True

                If dev.Type <> DeviceType.Virtual Then
                    chkEnableSmart.Enabled = True
                Else
                    chkEnableSmart.Enabled = False
                End If

                'the offline collection is available only if SMART is enabled
                If dev.OfflineCollectionStatus = Support.Enabled Then
                    chkEnableOffline.Checked = True
                    If dev.Type <> DeviceType.Virtual Then
                        chkEnableOffline.Enabled = True
                    Else
                        chkEnableOffline.Enabled = False
                    End If
                Else
                    chkEnableOffline.Checked = False
                    If dev.Type <> DeviceType.Virtual Then
                        chkEnableOffline.Enabled = True
                    Else
                        chkEnableOffline.Enabled = False
                    End If
                End If

                'also, the autosave of attributes is available only if SMART is enabled
                If Not IsNothing(dev.Options) Then
                    If dev.Options.Contains("-S on") Then
                        chkEnableAutosave.Checked = True
                        If dev.Type <> DeviceType.Virtual Then
                            chkEnableAutosave.Enabled = True
                        Else
                            chkEnableAutosave.Enabled = False
                        End If
                    Else
                        chkEnableAutosave.Checked = False
                        If dev.Type <> DeviceType.Virtual Then
                            chkEnableAutosave.Enabled = True
                        Else
                            chkEnableAutosave.Enabled = False
                        End If
                    End If
                Else
                    chkEnableAutosave.Checked = False
                End If
            Case Support.Disabled
                chkEnableSmart.Checked = False
                chkEnableOffline.Checked = False
                chkEnableAutosave.Checked = False

                If dev.Type <> DeviceType.Virtual Then
                    chkEnableSmart.Enabled = True
                Else
                    chkEnableSmart.Enabled = False
                End If
            Case Support.Unknown
                chkEnableSmart.Checked = False
                chkEnableOffline.Checked = False
                chkEnableAutosave.Checked = False
                chkEnableSmart.Enabled = False
                chkEnableOffline.Enabled = False
                chkEnableAutosave.Enabled = False
        End Select

        'the attribute autosave is setted when smartctl option are parsed
        If dev.Type = DeviceType.ATA Or dev.Type = DeviceType.USB Then
            chkEnableAutosave.Enabled = True
            ParseOptions(dev.Options)
        End If

        If (dev.Type = DeviceType.ATA Or dev.Type = DeviceType.USB) Then 'And installdevice = StoringDevice.Fixed Then
            'selected device is a physical one and hddguardian is installed into a fixed device:
            'monitoring features are available
        Else
            chkEnableAutosave.Enabled = False
        End If

        If dev.MissingAdminRights Then
            chkEnableSmart.Enabled = False
            chkEnableOffline.Enabled = False
            chkEnableAutosave.Enabled = False
        End If

        isloading_features = False
    End Sub

    Private Sub Performace()
        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)

        'AAM
        tlpAamWaitMessage.Visible = False
        trkAam.Enabled = False
        lnkSetAam.Visible = False
        lnkSetRecommended.Visible = False
        lblAamRecommended.Visible = False
        Select Case dev.AamStatus
            Case Feature.Disable
                trkAam.Value = 0
                lblAamValue.Text = lblAamValue.Tag & ": " & trkAam.Value
                If dev.Type <> DeviceType.Virtual Then trkAam.Enabled = True
                lblAamValue.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            Case Feature.Enable
                trkAam.Value = dev.AamValue
                lblAamValue.Text = lblAamValue.Tag & ": " & trkAam.Value
                If dev.Type <> DeviceType.Virtual Then trkAam.Enabled = True
                lblAamValue.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                lnkSetAam.Visible = True
                If Not IsNothing(dev.RecommendedAAM) Then
                    lnkSetRecommended.Visible = True
                    lblAamRecommended.Text = lblAamRecommended.Tag & ": " & dev.RecommendedAAM
                    lblAamRecommended.Visible = True
                End If
            Case Feature.Unavailable
                trkAam.Value = 0
                lnkSetAam.Visible = False
                lblAamValue.Text = m_notavailable
                lblAamValue.ForeColor = Color.Red
            Case Feature.Unknown
                trkAam.Value = 0
                lnkSetAam.Visible = False
                lblAamValue.Text = m_unabletodetermine
                lblAamValue.ForeColor = Color.Red
        End Select
        lnkUndoAam.Visible = False

        'APM
        tlpApmWaitMessage.Visible = False
        lnkSetApm.Visible = False
        trkApm.Enabled = False
        Select Case dev.ApmStatus
            Case Feature.Disable
                trkApm.Value = 0
                lblApmValue.Text = lblApmValue.Tag & ": " & trkApm.Value
                If dev.Type <> DeviceType.Virtual Then trkApm.Enabled = True
                lblApmValue.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            Case Feature.Enable
                trkApm.Value = dev.ApmValue
                lblApmValue.Text = lblApmValue.Tag & ": " & trkApm.Value
                If dev.Type <> DeviceType.Virtual Then trkApm.Enabled = True
                lblApmValue.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                lnkSetApm.Visible = True
            Case Feature.Unavailable
                trkApm.Value = 0
                lnkSetApm.Visible = False
                lblApmValue.Text = m_notavailable
                lblApmValue.ForeColor = Color.Red
            Case Feature.Unknown
                trkApm.Value = 0
                lnkSetApm.Visible = False
                lblApmValue.Text = m_unabletodetermine
                lblApmValue.ForeColor = Color.Red
        End Select
        lnkUndoApm.Visible = False

        'Standby
        tlpStandbyWaitMessage.Visible = False
        trkStandby.Value = 0
        lblStandbyValue.Text = lblStandbyValue.Tag & ": 0 (off)"
        trkStandby.Enabled = True
        If dev.Type = DeviceType.Virtual Or dev.MissingAdminRights Then
            trkStandby.Enabled = False
            lnkSetStandby.Visible = False
            lblStandbyValue.Text = m_unabletodetermine
            lblStandbyValue.ForeColor = Color.Red
        Else
            lblStandbyValue.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            trkStandby.Value = dev.Standby
            lnkSetStandby.Visible = True
        End If
        lnkUndoStandby.Visible = False

        'Read/write options
        tlpWaitRWMessage.Visible = False
        isloading_performance = True
        'Cache
        chkCache.Enabled = True
        If dev.Type = DeviceType.Virtual Then chkCache.Enabled = False
        Select Case dev.Cache
            Case Feature.Disable
                chkCache.Checked = False
            Case Feature.Enable
                chkCache.Checked = True
            Case Else
                chkCache.Enabled = False
                chkCache.Checked = False
        End Select
        'Look-ahead
        chkLookAhead.Enabled = True
        If dev.Type = DeviceType.Virtual Then chkLookAhead.Enabled = False
        Select Case dev.LookAhead
            Case Feature.Disable
                chkLookAhead.Checked = False
            Case Feature.Enable
                chkLookAhead.Checked = True
            Case Else
                chkLookAhead.Enabled = False
                chkLookAhead.Checked = False
        End Select
        'Write Cache reorder
        chkCacheReorder.Enabled = True
        If dev.Type = DeviceType.Virtual Then chkCacheReorder.Enabled = False
        Select Case dev.CacheReorder
            Case Feature.Disable
                chkCacheReorder.Checked = False
            Case Feature.Enable
                chkCacheReorder.Checked = True
            Case Else
                chkCacheReorder.Enabled = False
                chkCacheReorder.Checked = False
        End Select

        If dev.MissingAdminRights Then
            trkAam.Enabled = False
            trkApm.Enabled = False
            trkStandby.Enabled = False
            chkLookAhead.Enabled = False
            chkCache.Enabled = False
            chkCacheReorder.Enabled = False
        End If

        isloading_performance = False
    End Sub

    Private Sub SmartAttributes()
        'listview item scheme
        '
        'ColHead    |Type |ID    |Attribute |Current |Worst  |Thresh     |Raw       |
        '           -----------------------------------------------------------------
        'Item       |icon |.ID   |.Name     |.Value  |.Worst |.Threshold |.RawValue |
        'tag        |     |.Flag |          |        |       |           |          |
        'the "type" column show only an icon

        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)

        If Not IsNothing(dev.Attributes) Then
            With lvwSmart
                .Visible = True
                .Items.Clear()
                .SmallImageList = imlAttr
                'set the first column to sort the listview, but it have no values to sort...
                .ListViewItemSorter = New ListViewComparer(0, SortOrder.None)
                For Each attr As Attribute In dev.Attributes

                    Select Case attr.WhenFailed
                        Case "FAILING NOW"
                            .Items.Add("", 2)
                            .Items.Item(.Items.Count - 1).ForeColor = Color.Firebrick
                        Case "In the past"
                            .Items.Add("", 1)
                            .Items.Item(.Items.Count - 1).ForeColor = Color.DarkOrange
                        Case Else
                            .Items.Add("", 0)
                            .Items.Item(.Items.Count - 1).ForeColor = Color.Black
                    End Select

                    Dim i As Integer = .Items.Count - 1
                    .Items(i).UseItemStyleForSubItems = False
                    .Items(i).SubItems.Add(attr.ID)
                    .Items(i).SubItems(0).Tag = attr.Flag
                    .Items(i).SubItems.Add(attr.Name)
                    .Items(i).SubItems.Add(attr.Value)
                    .Items(i).SubItems.Add(attr.Worst)
                    .Items(i).SubItems.Add(attr.Threshold)
                    .Items(i).SubItems.Add(attr.RawValue)

                    For si As Short = 0 To .Items(i).SubItems.Count - 1
                        .Items(i).SubItems(si).ForeColor = .Items(i).ForeColor
                    Next

                Next
                'set the second column (ID) to sort the listview...
                .ListViewItemSorter = New ListViewComparer(1, SortOrder.Ascending)

                For Item As Short = 0 To lvwSmart.Items.Count - 1
                    'check ID name and then, if raw value is a number and if it's >0
                    'change text foreground color
                    Dim idname As String = .Items(Item).SubItems(2).Text
                    If idname = "Reallocated Sector Ct" Or _
                            idname = "Spin Retry Count" Or _
                            idname = "Reallocated Event Count" Or _
                            idname = "Current Pending Sector" Or _
                            idname = "Offline Uncorrectable" Or _
                            idname = "Soft Read Error Rate" Or _
                            idname = "Disk Shift" Then
                        If IsNumeric(.Items(Item).SubItems(6).Text) Then
                            If Convert.ToSingle(.Items(Item).SubItems(6).Text) > 0 And .Items(Item).ForeColor = Color.FromKnownColor(KnownColor.WindowText) Then
                                .Items(Item).ForeColor = Color.DeepPink
                                .Items(Item).ImageIndex = 3
                            End If
                        End If

                        If .Items(Item).SubItems(6).Text.Contains("(") Then
                            Dim v() As String = .Items(Item).SubItems(6).Text.Split("(")
                            If Convert.ToSingle(v(0).Trim) > 0 And .Items(Item).ForeColor = Color.FromKnownColor(KnownColor.WindowText) Then
                                .Items(Item).ForeColor = Color.DeepPink
                                .Items(Item).ImageIndex = 3
                            End If
                        End If
                    End If

                Next

                For ColumnIndex = 0 To lvwSmart.Columns.Count - 2
                    .Columns(ColumnIndex).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                Next ColumnIndex
                .Columns(6).Width = 150

                If .Items.Count > 0 Then .Items(0).Selected = True

            End With
        Else
            With lvwSmart
                .Visible = False
                .Items.Clear()
            End With
        End If

        lblDataStructure.Text = lblDataStructure.Tag & dev.DataStructuresRev.AttributesTable

    End Sub

    Private Sub AtaErrors()
        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)

        flwError.Visible = False
        rpRegisters.Visible = False
        lblCommands.Visible = False
        cpCommands.Visible = False

        If dev.MissingAdminRights Then
            lblErrLogVer.Text = m_missadminrights
        Else
            Dim err As Short = dev.TotalErrors
            optError1.Visible = False
            optError2.Visible = False
            optError3.Visible = False
            optError4.Visible = False
            optError5.Visible = False
            lblErrLogVer.Text = lblErrLogVer.Tag & dev.DataStructuresRev.ErrorLog

            If dev.IsSupportedErrorLogging Then
                lblErrLogVer.Visible = True
                If err = 0 Then
                    'flwError.Visible = False
                    'rpRegisters.Visible = False
                    'lblCommands.Visible = False
                    'cpCommands.Visible = False
                    lblErrorLog.Text = e_noerror
                    Exit Sub
                Else
                    flwError.Visible = True
                    rpRegisters.Visible = True
                    lblCommands.Visible = True
                    cpCommands.Visible = True
                    lblErrorLog.Text = e_select
                End If

                optError1.Checked = True

                For i As Short = 0 To dev.Errors.Count - 1
                    If err - i < 1 Then Exit For
                    Select Case i
                        Case 0
                            optError1.Text = err - i
                            optError1.Visible = True
                        Case 1
                            optError2.Text = err - i
                            optError2.Visible = True
                        Case 2
                            optError3.Text = err - i
                            optError3.Visible = True
                        Case 3
                            optError4.Text = err - i
                            optError4.Visible = True
                        Case 4
                            optError5.Text = err - i
                            optError5.Visible = True
                    End Select
                Next
            Else
                lblErrLogVer.Text = e_noerrorlogging
            End If
        End If

    End Sub

    Private Function ReplaceShortErrors(ByVal err As String) As String
        'replace short error description codes
        err = err.Replace("obs", GetString(1650)) 'Obsolete; first this, because "obs" string can appear on some languages, I think...
        err = err.Replace("ABRT", GetString(1640)) 'Command Aborted
        err = err.Replace("AMNF", GetString(1641)) 'Address Mark Not Found
        err = err.Replace("CCTO", GetString(1642)) 'Command Completion Timed Out
        err = err.Replace("EOM", GetString(1643)) 'End Of Media
        err = err.Replace("ICRC", GetString(1644)) 'Interface Cyclic Rendundancy Code (CRC) error
        err = err.Replace("IDNF", GetString(1645)) 'Identity Not Found
        err = err.Replace("ILI", GetString(1646)) '(packet command-set specific)
        err = err.Replace("MCR", GetString(1647)) 'Media Change Request
        err = err.Replace("MC", GetString(1648)) 'Media Changed
        err = err.Replace("NM", GetString(1649)) 'No Media
        err = err.Replace("TK0NF", GetString(1651)) 'Track 0 Not Found
        err = err.Replace("UNC", GetString(1652)) 'Uncorrectable Error in Data
        err = err.Replace("WP", GetString(1653)) 'Media is Write Protected
        Return err
    End Function

    Private Sub DisplayAtaError(ByVal e As Integer)
        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)


        If dev.Errors.Count > 0 Then
            If e > dev.Errors.Count Then Exit Sub

            Dim err As SmartError = dev.Errors(e - 1)
            Dim reg As Register = err.Registers

            flwError.Visible = True
            rpRegisters.Visible = True
            lblCommands.Visible = True
            cpCommands.Visible = True

            lblPowerOn.Text = lblPowerOn.Tag.ToString.Replace("%", err.Number) & err.Lifetime
            Dim errstatus As String = err.Status
            For i As Short = 0 To m_devicestatus.Count - 1
                errstatus = errstatus.Replace(m_devicestatus(i).Original, m_devicestatus(i).Change)
            Next
            lblDeviceStatus.Text = lblDeviceStatus.Tag & " " & errstatus ' err.Status

            rpRegisters.SetRegisters(reg.ER, reg.ST, reg.SC, reg.SN, reg.CL, reg.CH, reg.DH, ReplaceShortErrors(reg.ErrorText))

            cpCommands.HideRows(5 - err.Commands.Count)
            If err.Commands(0).PowerUp.Contains(":") Then
                cpCommands.SetPowerUpTooltip(t_poweron, t_powerontxt)
            Else
                cpCommands.SetPowerUpTooltip(t_timestamp, t_timestamptxt)
            End If
            For i As Short = 0 To err.Commands.Count - 1
                cpCommands.AddCommand(err.Commands(i).CR, err.Commands(i).FR, err.Commands(i).SC, _
                                               err.Commands(i).SN, err.Commands(i).CL, err.Commands(i).CH, _
                                               err.Commands(i).DH, err.Commands(i).DC, err.Commands(i).PowerUp, _
                                               err.Commands(i).Feature)
            Next
        End If
    End Sub

    Private Sub SelfTestLog()
        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)

        If dev.MissingAdminRights Then
            lblSelfTests.Text = lblSelfTests.Tag.ToString.Replace("%", m_unknown.ToLower)
            lvwSelfTest.Visible = False
            lblNoSelfTests.Visible = True
            lblNoSelfTests.Text = m_missadminrights
        Else
            If dev.IsSupportedSeftTest Then
                lblSelfTests.Text = lblSelfTests.Tag.ToString.Replace("%", dev.DataStructuresRev.SelfTestLog)
                With lvwSelfTest
                    lblNoSelfTests.Visible = False
                    .Visible = True
                    .Enabled = True
                    .Items.Clear()
                    If dev.SelfTests.Count > 0 Then
                        For i As Short = 0 To dev.SelfTests.Count - 1
                            Dim st As SelfTest = dev.SelfTests(i)
                            .Items.Add(st.Num)
                            Dim desc As String = st.Description
                            For d As Short = 0 To m_statusdescr.Count - 1
                                desc = desc.Replace(m_statusdescr(d).Original, m_statusdescr(d).Change)
                            Next
                            .Items(.Items.Count - 1).SubItems.Add(desc)

                            Dim res As String = st.Status
                            For s As Short = 0 To m_testresults.Count - 1
                                res = res.Replace(m_testresults(s).Original, m_testresults(s).Change)
                            Next
                            .Items(.Items.Count - 1).SubItems.Add(res)

                            .Items(.Items.Count - 1).SubItems.Add(st.Remaining)
                            .Items(.Items.Count - 1).SubItems.Add(st.LifeTime)
                            .Items(.Items.Count - 1).SubItems.Add(st.FirstError)
                            'If i Mod 2 <> 0 Then .Items(.Items.Count - 1).BackColor = Color.FromArgb(243, 245, 247)
                        Next
                        .HeaderStyle = ColumnHeaderStyle.Nonclickable
                        .Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                        .Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                        .Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                        .Columns(3).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                        .Columns(4).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                        .Columns(5).Width = 100
                    Else
                        .Visible = False
                        lblNoSelfTests.Text = GetString(1703)
                        lblNoSelfTests.Visible = True
                    End If
                End With
            Else
                lblSelfTests.Text = lblSelfTests.Tag.ToString.Replace("%", m_unknown.ToLower)
                lblNoSelfTests.Text = GetString(1701)
                lblNoSelfTests.Visible = True
                lvwSelfTest.Visible = False
            End If
        End If

    End Sub

    Private Sub SelectiveSelfTestLog()
        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)
        If dev.MissingAdminRights Then
            lblSelective.Text = lblSelective.Tag.ToString.Replace("%", m_unknown.ToLower)
            lvwSelective.Visible = False
            lblNoSelective.Visible = True
            lblNoSelective.Text = m_missadminrights
        Else
            If dev.IsSupportedSelective Then
                lblSelective.Text = lblSelective.Tag.ToString.Replace("%", dev.DataStructuresRev.SelectiveSelfTestLog)
                With lvwSelective
                    lblNoSelective.Visible = False
                    .Visible = True
                    .Enabled = True
                    .Items.Clear()
                    If dev.SelectiveSelfTest.Count > 0 Then
                        For i As Short = 0 To dev.SelectiveSelfTest.Count - 1
                            Dim sel As Selectives = dev.SelectiveSelfTest(i)
                            .Items.Add(sel.Span)
                            .Items(.Items.Count - 1).SubItems.Add(sel.MinLba)
                            .Items(.Items.Count - 1).SubItems.Add(sel.MaxLba)
                            Dim status As String = sel.Status
                            For d As Short = 0 To m_statusdescr.Count - 1
                                status = sel.Status.Replace(m_statusdescr(d).Original, m_statusdescr(d).Change)
                            Next
                            .Items(.Items.Count - 1).SubItems.Add(status)
                            'If i Mod 2 <> 0 Then .Items(.Items.Count - 1).BackColor = Color.FromArgb(243, 245, 247)
                        Next
                        .Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                        .Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                        .Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                        .Columns(3).Width = 150
                    Else
                        .Visible = False
                        lblNoSelective.Text = GetString(1704)
                        lblNoSelective.Visible = True
                    End If
                End With
            Else
                lblSelective.Text = lblSelective.Tag.ToString.Replace("%", m_unknown.ToLower)
                lblNoSelective.Text = GetString(1702)
                lblNoSelective.Visible = True
                lvwSelective.Visible = False
            End If
        End If

    End Sub

    Private Sub UpdateTestTiming()
        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)

        btnRun.Visible = True
        If Not (My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)) _
            Or dev.Type = DeviceType.Virtual Then
            tlpTest.Visible = False
            tlpTestProgress.Visible = False
        Else
            tlpTest.Visible = True
            tlpTestProgress.Visible = False
        End If

        Select Case cboTest.SelectedIndex
            Case 0
                Dim t() As String = dev.TestsPollingTime.OfflineData.Split(" ")
                'test timing is always in seconds
                If IsNumeric(t(0)) Then
                    Dim polltime As Short = Val(t(0))
                    Dim h As Short = Val(t(0)) \ 3600
                    Dim m As Short = (Val(t(0)) - h * 3600) \ 60
                    Dim s As Short = Val(t(0)) - h * 3600 - m * 60
                    lblDuration.Text = lblDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":" & String.Format("{0:D2}", s)
                Else
                    lblDuration.Text = lblDuration.Tag & dev.TestsPollingTime.OfflineData
                End If
            Case 1
                Dim t() As String = dev.TestsPollingTime.ShortTest.Split(" ")
                'test timing are always in minutes
                If IsNumeric(t(0)) Then
                    Dim polltime As Short = Val(t(0))
                    Dim h As Short = Val(t(0)) \ 60
                    Dim m As Short = Val(t(0)) - h * 60
                    lblDuration.Text = lblDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":00"
                Else
                    lblDuration.Text = lblDuration.Tag & dev.TestsPollingTime.ShortTest
                End If
            Case 2
                Dim t() As String = dev.TestsPollingTime.ExtendedTest.Split(" ")
                'test timing are always in minutes
                If IsNumeric(t(0)) Then
                    Dim polltime As Short = Val(t(0))
                    Dim h As Short = Val(t(0)) \ 60
                    Dim m As Short = Val(t(0)) - h * 60
                    lblDuration.Text = lblDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":00"
                Else
                    lblDuration.Text = lblDuration.Tag & dev.TestsPollingTime.ExtendedTest
                End If
            Case 3
                Dim t() As String = dev.TestsPollingTime.ConveyanceTest.Split(" ")
                'test timing are always in minutes
                If IsNumeric(t(0)) Then
                    Dim polltime As Short = Val(t(0))
                    Dim h As Short = Val(t(0)) \ 60
                    Dim m As Short = Val(t(0)) - h * 60
                    lblDuration.Text = lblDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":00"
                Else
                    lblDuration.Text = lblDuration.Tag & dev.TestsPollingTime.ConveyanceTest
                End If
        End Select
        If lblDuration.Text.Contains("N/A") Or dev.Type = DeviceType.Virtual Then btnRun.Visible = False
    End Sub

    Private Sub DisableFunctions()
        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)
        'disable some functions not available for virtual devices
        If dev.Type = DeviceType.Virtual Or Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            chkAttributes.Checked = False
            chkAttributes.Enabled = False
            chkFirmware.Checked = False
            chkFirmware.Enabled = False
        End If
    End Sub

    Public Sub ReliabilityDetails()
        If lvwDevices.Items.Count = 0 Then Exit Sub

        Dim reliability As Ratings
        With cboDevices ' lvwDevices
            If Not IsNothing(.SelectedIndex) Then ' .SelectedItems.Count) Then
                Dim d As Device = devlist(.SelectedIndex)
                reliability = d.ReliabilityRating

                lblRating2.Visible = True
                lblRating2Value.Visible = True
                picRating2.Visible = True

                If d.IsSsd Then
                    lblRating3.Visible = False
                    lblRating3Value.Visible = False
                    picRating3.Visible = False
                    lblRating4.Visible = False
                    lblRating4Value.Visible = False
                    picRating4.Visible = False

                    lblRating1.Text = ata_errors
                    If Not IsNumeric(d.NewVitalParameters.Errors) Then
                        lblRating1Value.Text = "N/A"
                        picRating1.Image = My.Resources.r0_star
                    Else
                        lblRating1Value.Text = d.NewVitalParameters.Errors & "/" & My.Settings.TuneErrors
                        With picRating1
                            Select Case reliability.Errors
                                Case 5
                                    .Image = My.Resources.r5_star
                                Case 4
                                    .Image = My.Resources.r4_star
                                Case 3
                                    .Image = My.Resources.r3_star
                                Case 2
                                    .Image = My.Resources.r2_star
                                Case 1
                                    .Image = My.Resources.r1_star
                                Case Else
                                    .Image = My.Resources.r0_star
                            End Select
                        End With
                    End If

                    Dim rel As String = 0
                    lblRating2Value.Text = "N/A"

                    If IsNumeric(d.NewVitalParameters.Indilinx) Then
                        lblRating2.Text = ssd_indilinx
                        lblRating2Value.Text = d.NewVitalParameters.Indilinx & "/100"
                        rel = reliability.Indilinx
                    ElseIf IsNumeric(d.NewVitalParameters.Intel) Then
                        lblRating2.Text = ssd_intel
                        lblRating2Value.Text = d.NewVitalParameters.Intel & "/100"
                        rel = reliability.Intel
                    ElseIf IsNumeric(d.NewVitalParameters.Micron) Then
                        lblRating2.Text = ssd_micron
                        lblRating2Value.Text = d.NewVitalParameters.Micron & "/0"
                        rel = reliability.Micron
                    ElseIf IsNumeric(d.NewVitalParameters.Samsung) Then
                        lblRating2.Text = ssd_samsung
                        lblRating2Value.Text = d.NewVitalParameters.Samsung & "/100"
                        rel = reliability.Samsung
                    ElseIf IsNumeric(d.NewVitalParameters.SandForce) Then
                        lblRating2.Text = ssd_sandforce
                        lblRating2Value.Text = d.NewVitalParameters.SandForce & "/100"
                        rel = reliability.SandForce
                    Else
                        lblRating2.Visible = False
                        lblRating2Value.Visible = False
                        picRating2.Visible = False
                    End If

                    With picRating2
                        Select Case rel
                            Case 5
                                .Image = My.Resources.r5_star
                            Case 4
                                .Image = My.Resources.r4_star
                            Case 3
                                .Image = My.Resources.r3_star
                            Case 2
                                .Image = My.Resources.r2_star
                            Case 1
                                .Image = My.Resources.r1_star
                            Case Else
                                .Image = My.Resources.r0_star
                        End Select
                    End With

                Else
                    lblRating3.Visible = True
                    lblRating3Value.Visible = True
                    picRating3.Visible = True
                    lblRating4.Visible = True
                    lblRating4Value.Visible = True
                    picRating4.Visible = True

                    lblRating1.Text = ata_errors
                    If Not IsNumeric(d.NewVitalParameters.Errors) Then
                        lblRating1Value.Text = "N/A"
                        picRating1.Image = My.Resources.r0_star
                    Else
                        lblRating1Value.Text = d.NewVitalParameters.Errors & "/" & My.Settings.TuneErrors
                        With picRating1
                            Select Case reliability.Errors
                                Case 5
                                    .Image = My.Resources.r5_star
                                Case 4
                                    .Image = My.Resources.r4_star
                                Case 3
                                    .Image = My.Resources.r3_star
                                Case 2
                                    .Image = My.Resources.r2_star
                                Case 1
                                    .Image = My.Resources.r1_star
                                Case Else
                                    .Image = My.Resources.r0_star
                            End Select
                        End With
                    End If

                    lblRating2.Text = hdd_badsectors
                    If Not IsNumeric(d.NewVitalParameters.ReallSect) Then
                        lblRating2Value.Text = "N/A"
                        picRating2.Image = My.Resources.r0_star
                    Else
                        lblRating2Value.Text = d.NewVitalParameters.ReallSect & "/" & d.BadSectorsThreshold
                        With picRating2
                            Select Case reliability.ReallocationCount
                                Case 5
                                    .Image = My.Resources.r5_star
                                Case 4
                                    .Image = My.Resources.r4_star
                                Case 3
                                    .Image = My.Resources.r3_star
                                Case 2
                                    .Image = My.Resources.r2_star
                                Case 1
                                    .Image = My.Resources.r1_star
                                Case Else
                                    .Image = My.Resources.r0_star
                            End Select
                        End With
                    End If

                    lblRating3.Text = hdd_curpending
                    If Not IsNumeric(d.NewVitalParameters.CurPending) Then
                        lblRating3Value.Text = "N/A"
                        picRating3.Image = My.Resources.r0_star
                    Else
                        lblRating3Value.Text = d.NewVitalParameters.CurPending & "/" & My.Settings.Tune197
                        With picRating3
                            Select Case reliability.CurrentPending
                                Case 5
                                    .Image = My.Resources.r5_star
                                Case 4
                                    .Image = My.Resources.r4_star
                                Case 3
                                    .Image = My.Resources.r3_star
                                Case 2
                                    .Image = My.Resources.r2_star
                                Case 1
                                    .Image = My.Resources.r1_star
                                Case Else
                                    .Image = My.Resources.r0_star
                            End Select
                        End With
                    End If

                    lblRating4.Text = hdd_offlunc
                    If Not IsNumeric(d.NewVitalParameters.OfflineUnc) Then
                        lblRating4Value.Text = "N/A"
                        picRating4.Image = My.Resources.r0_star
                    Else
                        lblRating4Value.Text = d.NewVitalParameters.OfflineUnc & "/" & My.Settings.Tune198
                        With picRating4
                            Select Case reliability.OfflineUncorrectable
                                Case 5
                                    .Image = My.Resources.r5_star
                                Case 4
                                    .Image = My.Resources.r4_star
                                Case 3
                                    .Image = My.Resources.r3_star
                                Case 2
                                    .Image = My.Resources.r2_star
                                Case 1
                                    .Image = My.Resources.r1_star
                                Case Else
                                    .Image = My.Resources.r0_star
                            End Select
                        End With
                    End If
                End If

            End If
        End With
    End Sub
End Class
