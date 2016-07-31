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

    Public Sub PopulateAtaPanels()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If dev.IsValid Then
            FillSmartctlPanels()
            SmartAttributes()
            SmartSwitches()
            Performace()
            AtaErrors()
            SelfTestLog()
            UpdateTestTiming()
            Temperatures()

            'set events logs
            FillEvents()
            DisplayEvents()
            'FillList()
            If optEntire.Checked Then
                SetFullGraph()
            Else
                SetGraph(mcLog.SelectionRange.Start, mcLog.SelectionRange.End)
            End If
        End If

        DisableFunctions()
    End Sub

    Private Sub SmartSwitches()

        Dim dev As Device = devlist(cboDevices.SelectedIndex)
        isloading_features = True

        Select Case dev.Smart.Support
            Case Support.Available

                If dev.Smart.IsEnabled = Support.Enabled Then
                    chkEnableSmart.Checked = True
                Else
                    chkEnableSmart.Checked = False
                End If
                chkEnableSmart.Enabled = Not dev.IsVirtual

                'the offline collection is available only if SMART is enabled
                If dev.ATA.Features.OfflineAuto.Status = Support.Enabled Then
                    chkEnableOffline.Checked = True
                    chkEnableOffline.Enabled = Not dev.IsVirtual
                Else
                    chkEnableOffline.Checked = False
                    chkEnableOffline.Enabled = Not dev.IsVirtual
                End If

                'also, the autosave of attributes is available only if SMART is enabled
                If Not IsNothing(dev.Options) Then
                    If dev.Options.Contains("-S on") Then
                        chkEnableAutosave.Checked = True
                        chkEnableAutosave.Enabled = Not dev.IsVirtual
                    Else
                        chkEnableAutosave.Checked = False
                        chkEnableAutosave.Enabled = Not dev.IsVirtual
                    End If
                Else
                    chkEnableAutosave.Checked = False
                End If
            Case Support.Disabled
                chkEnableSmart.Checked = False
                chkEnableOffline.Checked = False
                chkEnableAutosave.Checked = False
                chkEnableSmart.Enabled = Not dev.IsVirtual
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
        Select Case dev.ATA.Features.Aam.Status
            Case Feature.Disabled
                trkAam.Value = 0
                lblAamValue.Text = lblAamValue.Tag & ": " & trkAam.Value
                trkAam.Enabled = Not dev.IsVirtual
                lblAamValue.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            Case Feature.Enabled
                trkAam.Value = dev.ATA.Features.Aam.Value
                lblAamValue.Text = lblAamValue.Tag & ": " & trkAam.Value
                trkAam.Enabled = Not dev.IsVirtual
                lblAamValue.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                lnkSetAam.Visible = True
                If Not IsNothing(dev.ATA.Features.Aam.RecommendedValue) Then
                    lnkSetRecommended.Visible = True
                    lblAamRecommended.Text = lblAamRecommended.Tag & ": " & dev.ATA.Features.Aam.RecommendedValue
                    lblAamRecommended.Visible = True
                End If
            Case Feature.Unavailable
                trkAam.Value = 0
                lnkSetAam.Visible = False
                lblAamValue.Text = m_notavailable
                lblAamValue.ForeColor = Color.Red
        End Select
        lnkUndoAam.Visible = False

        'APM
        tlpApmWaitMessage.Visible = False
        lnkSetApm.Visible = False
        trkApm.Enabled = False
        Select Case dev.ATA.Features.Apm.Status
            Case Feature.Disabled
                trkApm.Value = 0
                lblApmValue.Text = lblApmValue.Tag & ": " & trkApm.Value
                trkApm.Enabled = Not dev.IsVirtual
                lblApmValue.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            Case Feature.Enabled
                trkApm.Value = dev.ATA.Features.Apm.Value
                lblApmValue.Text = lblApmValue.Tag & ": " & trkApm.Value
                trkApm.Enabled = Not dev.IsVirtual
                lblApmValue.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                lnkSetApm.Visible = True
            Case Feature.Unavailable
                trkApm.Value = 0
                lnkSetApm.Visible = False
                lblApmValue.Text = m_notavailable
                lblApmValue.ForeColor = Color.Red
        End Select
        lnkUndoApm.Visible = False

        'Standby
        tlpStandbyWaitMessage.Visible = False
        trkStandby.Value = 0
        lblStandbyValue.Text = lblStandbyValue.Tag & ": 0 (off)"
        trkStandby.Enabled = True
        If dev.IsVirtual Or dev.MissingAdminRights Then
            trkStandby.Enabled = False
            lnkSetStandby.Visible = False
            lblStandbyValue.Text = m_unabletodetermine
            lblStandbyValue.ForeColor = Color.Red
        Else
            lblStandbyValue.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            trkStandby.Value = dev.ATA.Features.Standby
            lnkSetStandby.Visible = True
        End If
        lnkUndoStandby.Visible = False

        'Read/write options
        tlpWaitRWMessage.Visible = False
        isloading_performance = True
        'Cache
        chkCache.Enabled = True
        chkCache.Enabled = Not dev.IsVirtual
        Select Case dev.ATA.Features.WriteCache.Enabled
            Case Feature.Disabled
                chkCache.Checked = False
            Case Feature.Enabled
                chkCache.Checked = True
            Case Else
                chkCache.Enabled = False
                chkCache.Checked = False
        End Select
        'Look-ahead
        chkLookAhead.Enabled = True
        chkLookAhead.Enabled = Not dev.IsVirtual
        Select Case dev.ATA.Features.LookAhead
            Case Feature.Disabled
                chkLookAhead.Checked = False
            Case Feature.Enabled
                chkLookAhead.Checked = True
            Case Else
                chkLookAhead.Enabled = False
                chkLookAhead.Checked = False
        End Select
        'Write Cache reorder
        chkCacheReorder.Enabled = True
        chkCacheReorder.Enabled = Not dev.IsVirtual
        Select Case dev.ATA.Features.WriteCache.Reorder
            Case Feature.Disabled
                chkCacheReorder.Checked = False
            Case Feature.Enabled
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

        If Not IsNothing(dev.ATA.Attributes) Then
            With lvwSmart
                .Visible = True
                .Items.Clear()
                .SmallImageList = imlAttr
                'set the first column to sort the listview, but it have no values to sort...
                .ListViewItemSorter = New ListViewComparer(0, SortOrder.None)
                For Each attr As Device.AtaAttribute In dev.ATA.Attributes.Items

                    Select Case attr.WhenFailed
                        Case "FAILING NOW", "NOW"
                            .Items.Add("", 2)
                            .Items.Item(.Items.Count - 1).ForeColor = Color.Firebrick
                        Case "In the past", "Past"
                            .Items.Add("", 1)
                            .Items.Item(.Items.Count - 1).ForeColor = Color.DarkOrange
                        Case Else
                            .Items.Add("", 0)
                            .Items.Item(.Items.Count - 1).ForeColor = .ForeColor
                    End Select

                    Dim i As Integer = .Items.Count - 1
                    .Items(i).UseItemStyleForSubItems = False
                    .Items(i).SubItems.Add(attr.Id)
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
                    If idname = "Reallocated Sector Ct" Or
                            idname = "Spin Retry Count" Or
                            idname = "Reallocated Event Count" Or
                            idname = "Current Pending Sector" Or
                            idname = "Offline Uncorrectable" Or
                            idname = "Soft Read Error Rate" Or
                            idname = "Disk Shift" Then
                        If IsNumeric(.Items(Item).SubItems(6).Text) Then
                            If Convert.ToSingle(.Items(Item).SubItems(6).Text) > 0 And .Items(Item).ForeColor = .ForeColor Then
                                .Items(Item).ForeColor = Color.DeepPink
                                .Items(Item).ImageIndex = 3

                                For si As Short = 0 To .Items(Item).SubItems.Count - 1
                                    .Items(Item).SubItems(si).ForeColor = .Items(Item).ForeColor
                                Next
                            End If
                        End If

                        If .Items(Item).SubItems(6).Text.Contains("(") Then
                            Dim v() As String = .Items(Item).SubItems(6).Text.Split("(")
                            If Convert.ToSingle(v(0).Trim) > 0 And .Items(Item).ForeColor = .ForeColor Then
                                .Items(Item).ForeColor = Color.DeepPink
                                .Items(Item).ImageIndex = 3

                                For si As Short = 0 To .Items(Item).SubItems.Count - 1
                                    .Items(Item).SubItems(si).ForeColor = .Items(Item).ForeColor
                                Next
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

        lblDataStructure.Text = lblDataStructure.Tag & dev.ATA.Attributes.Revision

    End Sub

    Private Sub AtaErrors()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        flwError.Visible = False
        tabErrors.Visible = False

        If dev.MissingAdminRights Then
            lblErrLogVer.Text = m_missadminrights
        Else
            Dim err As Long = dev.ATA.Errors.TotalAmount
            optError1.Visible = False
            optError2.Visible = False
            optError3.Visible = False
            optError4.Visible = False
            optError5.Visible = False
            lblErrLogVer.Text = lblErrLogVer.Tag & dev.ATA.Errors.Version

            If dev.ATA.Errors.Supported Then
                lblErrLogVer.Visible = True
                If err = 0 Then
                    lblErrorLog.Text = e_noerror
                    Exit Sub
                Else
                    flwError.Visible = True
                    tabErrors.Visible = True
                    lblErrorLog.Text = e_select
                End If

                optError1.Checked = True

                For i As Short = 0 To dev.ATA.Errors.Items.Count - 1
                    If err - i < 1 Then Exit For
                    Select Case i
                        Case 0
                            optError1.Text = err - i
                            optError1.Visible = True
                            DisplayAtaError(err - i)
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

    Private Function ShortErrorsToDescription(ByVal err As String) As String
        'replace short error description codes
        err = err.Replace("obs", "obs: OBSolete" & vbCrLf & GetString(1680)) 'Obsolete; first this, because "obs" string can appear on some languages, I think...
        err = err.Replace("ABRT", "ABRT: command ABoRTed" & vbCrLf & GetString(1670)) 'Command Aborted
        err = err.Replace("AMNF", "AMNF: Address Mark Not Found" & vbCrLf & GetString(1671)) 'Address Mark Not Found
        err = err.Replace("CCTO", "CCTO: Command Completion Time limit Out" & vbCrLf & GetString(1672)) 'Command Completion Timed Out
        err = err.Replace("EOM", "EOM: End Of Media" & vbCrLf & GetString(1673)) 'End Of Media
        err = err.Replace("ICRC", "ICRC: Interface Cyclic Redundancy Code error" & vbCrLf & GetString(1674)) 'Interface Cyclic Rendundancy Code (CRC) error
        err = err.Replace("IDNF", "IDNF: IDentity Not Found" & vbCrLf & GetString(1675)) 'Identity Not Found
        err = err.Replace("ILI", "ILI: Illegal Length Indicator" & vbCrLf & GetString(1676)) '(packet command-set specific)
        err = err.Replace("MCR", "MCR: Media Change Request" & vbCrLf & GetString(1678)) 'Media Change Request
        err = err.Replace("MC", "MC: Media Changed" & vbCrLf & GetString(1677)) 'Media Changed
        err = err.Replace("NM", "NM: No Media" & vbCrLf & GetString(1679)) 'No Media
        err = err.Replace("TK0NF", "TK0NF: TracK 0 Not Found" & vbCrLf & GetString(1681)) 'Track 0 Not Found
        err = err.Replace("UNC", "UNC: UNCorrectable error in data" & vbCrLf & GetString(1682)) 'Uncorrectable Error in Data
        err = err.Replace("WP", "WP: media is Write Protected" & vbCrLf & GetString(1683)) 'Media is Write Protected
        Return err
    End Function

    Private Function UpperCaseFirst(ByVal txt As String) As String
        If IsNothing(txt) Then Return Nothing
        If txt.Length = 0 Then Return Nothing
        txt = txt.ToLower
        Dim c() As Char = txt.ToCharArray
        Dim ucs As String = c(0).ToString.ToUpper
        For i As Short = 1 To c.Count - 1
            ucs += c(i)
        Next
        c = Nothing
        Return ucs
    End Function

    Private Sub DisplayAtaError(ByVal e As String)
        If Not IsNumeric(e) Then Exit Sub

        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If dev.ATA.Errors.Items.Count > 0 Then
            If e > dev.ATA.Errors.TotalAmount Then Exit Sub

            Dim err As Device.AtaError = dev.ATA.Errors.Items(dev.ATA.Errors.TotalAmount - e)
            Dim reg As Device.AtaRegister = err.Register

            flwError.Visible = True
            'rpRegisters.Visible = True
            'lblCommands.Visible = True
            'cpCommands.Visible = True
            tabErrors.Visible = True

            'symple view
            lblErrorNumberValue.Text = err.Number
            Dim elt() As String = err.Lifetime.Trim.Split(" ")
            Dim wt() As String = dev.WorkTime.TotalHours.Split(" ")
            If wt(0) >= elt(0) Then
                lblErrorElapsed.Text = GetString(1661)
                lblErrorElapsedValue.Text = wt(0) - elt(0) & " h"
            Else
                lblErrorElapsed.Text = GetString(1662)
                lblErrorElapsedValue.Text = err.Lifetime & " h"
            End If

            Dim errstatus As String = err.Status
            For i As Short = 0 To m_devicestatus.Count - 1
                errstatus = errstatus.Replace(m_devicestatus(i).Original, m_devicestatus(i).Change)
            Next
            lblErrorStatusValue.Text = UpperCaseFirst(errstatus)

            elt = Nothing
            lblErrorDescriptionValue.Text = ""
            If Not IsNothing(reg.Error) Then
                Dim lba() As String = reg.Error.Replace("at LBA =", "|").Split("|")

                If lba.Length > 1 Then
                    lblErrorLbaValue.Text = lba(1).Trim
                Else
                    lblErrorLbaValue.Text = "-"
                End If

                lba(0) = lba(0).Replace("Error:", "").Replace("at LBA =", "").Replace("sectors", "").Replace(", ", vbCrLf & vbCrLf).Trim
                Dim ls() As String = lba(0).Split(" ")
                If ls.Count > 1 Then
                    'we have a sector counter!
                    lblErrorSectorsValue.Text = ls(1).Trim
                Else
                    lblErrorSectorsValue.Text = "-"
                End If
                lblErrorDescriptionValue.Text = ShortErrorsToDescription(ls(0))
                ls = Nothing
                lba = Nothing
            End If

            'detailed view
            lblPowerOn.Text = lblPowerOn.Tag.ToString.Replace("%", err.Number) & err.Lifetime
            'Dim errstatus As String = err.Status
            'For i As Short = 0 To m_devicestatus.Count - 1
            'errstatus = errstatus.Replace(m_devicestatus(i).Original, m_devicestatus(i).Change)
            'Next
            lblDeviceStatus.Text = lblDeviceStatus.Tag & " " & errstatus ' err.Status

            rpRegisters.SetRegisters(reg.ER, reg.ST, reg.SC, reg.SN, reg.CL, reg.CH, reg.DH, ReplaceShortErrors(reg.Error))

            cpCommands.HideRows(5 - err.Commands.Count)
            If err.Commands(0).PowerUp.Contains(":") Then
                cpCommands.SetPowerUpTooltip(t_poweron, t_powerontxt)
            Else
                cpCommands.SetPowerUpTooltip(t_timestamp, t_timestamptxt)
            End If
            For i As Short = 0 To err.Commands.Count - 1
                cpCommands.AddCommand(err.Commands(i).CR, err.Commands(i).FR, err.Commands(i).SC,
                                               err.Commands(i).SN, err.Commands(i).CL, err.Commands(i).CH,
                                               err.Commands(i).DH, err.Commands(i).DC, err.Commands(i).PowerUp,
                                               err.Commands(i).Feature)
            Next
        End If

        dev = Nothing
    End Sub

    Private Sub SelfTestLog()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If dev.MissingAdminRights Then
            lblSelfTests.Text = lblSelfTests.Tag.ToString.Replace("%", m_unknown.ToLower)
            lvwSelfTest.Visible = False
            lblNoSelfTests.Visible = True
            lblNoSelfTests.Text = m_missadminrights
        Else
            If dev.ATA.SelfTests.Supported Then
                lblSelfTests.Text = lblSelfTests.Tag.ToString.Replace("%", dev.ATA.SelfTests.Version)
                With lvwSelfTest
                    lblNoSelfTests.Visible = False
                    .Visible = True
                    .Enabled = True
                    .Items.Clear()
                    If dev.ATA.SelfTests.Items.Count > 0 Then
                        For i As Short = 0 To dev.ATA.SelfTests.Items.Count - 1
                            Dim st As Device.AtaSelfTest = dev.ATA.SelfTests.Items(i)
                            .Items.Add(st.Number)
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
                            '.Items(.Items.Count - 1).SubItems.Add(st.LifeTime)

                            Dim elt() As String = st.LifeTime.Trim.Split(" ")
                            Dim wt() As String = dev.WorkTime.TotalHours.Split(" ")
                            If wt(0) >= elt(0) Then
                                .Items(.Items.Count - 1).SubItems.Add(wt(0) - elt(0) & " h")
                            Else
                                .Items(.Items.Count - 1).SubItems.Add(st.LifeTime & " h")
                            End If

                            .Items(.Items.Count - 1).SubItems.Add(st.FirstError)
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

        dev = Nothing
    End Sub

    Private Sub UpdateTestTiming()
        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)

        If dev.IsVirtual Then
            flwTests.Visible = False
            tlpTestProgress.Visible = False
        Else
            flwTests.Visible = True
            btnRun.Visible = True

            If Not (My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)) _
                Or dev.IsVirtual Then
                flwTests.Visible = False
                tlpTestProgress.Visible = False
            Else
                flwTests.Visible = True
                tlpTestProgress.Visible = True
                flwProgress.Visible = False
                btnStop.Enabled = False
            End If

            If Not IsNothing(dev.ATA.Test.PollingTimes.Offline) Then
                Dim od() As String = dev.ATA.Test.PollingTimes.Offline.Split(" ")
                'test timing is always in seconds
                If IsNumeric(od(0)) Then
                    optOffline.Enabled = True
                    Dim polltime As Long = Val(od(0))
                    Dim h As Long = Val(od(0)) \ 3600
                    Dim m As Long = (Val(od(0)) - h * 3600) \ 60
                    Dim s As Long = Val(od(0)) - h * 3600 - m * 60
                    lblOfflineDuration.Text = lblOfflineDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":" & String.Format("{0:D2}", s)
                Else
                    optOffline.Enabled = False
                    lblOfflineDuration.Text = lblOfflineDuration.Tag & "-"
                End If
            Else
                optOffline.Enabled = False
                lblOfflineDuration.Text = lblOfflineDuration.Tag & "-"
            End If

            If Not IsNothing(dev.ATA.Test.PollingTimes.Short) Then
                Dim st() As String = dev.ATA.Test.PollingTimes.Short.Split(" ")
                'test timing is always in minutes
                If IsNumeric(st(0)) Then
                    optShort.Enabled = True
                    Dim polltime As Long = Val(st(0))
                    Dim h As Long = Val(st(0)) \ 60
                    Dim m As Long = Val(st(0)) - h * 60
                    lblShortDuration.Text = lblShortDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":00"
                Else
                    optShort.Enabled = False
                    lblShortDuration.Text = lblShortDuration.Tag & "-"
                End If
            Else
                optShort.Enabled = False
                lblShortDuration.Text = lblShortDuration.Tag & "-"
            End If

            If Not IsNothing(dev.ATA.Test.PollingTimes.Extended) Then
                Dim et() As String = dev.ATA.Test.PollingTimes.Extended.Split(" ")
                'test timing is always in minutes
                If IsNumeric(et(0)) Then
                    optLong.Enabled = True
                    Dim polltime As Long = Val(et(0))
                    Dim h As Long = Val(et(0)) \ 60
                    Dim m As Long = Val(et(0)) - h * 60
                    lblLongDuration.Text = lblLongDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":00"
                Else
                    optLong.Enabled = False
                    lblLongDuration.Text = lblLongDuration.Tag & "-"
                End If
            Else
                optLong.Enabled = False
                lblLongDuration.Text = lblLongDuration.Tag & "-"
            End If

            If Not IsNothing(dev.ATA.Test.PollingTimes.Conveyance) Then
                Dim ct() As String = dev.ATA.Test.PollingTimes.Conveyance.Split(" ")
                'test timing is always in minutes
                If IsNumeric(ct(0)) Then
                    optConveyance.Enabled = True
                    Dim polltime As Long = Val(ct(0))
                    Dim h As Long = Val(ct(0)) \ 60
                    Dim m As Long = Val(ct(0)) - h * 60
                    lblConveyanceDuration.Text = lblConveyanceDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":00"
                Else
                    optConveyance.Enabled = False
                    lblConveyanceDuration.Text = lblConveyanceDuration.Tag & "-"
                End If
            Else
                optConveyance.Enabled = False
                lblConveyanceDuration.Text = lblConveyanceDuration.Tag & "-"
            End If
        End If
    End Sub

    Private Sub DisableFunctions()
        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)
        'disable some functions not available for virtual devices
        If dev.IsVirtual Or Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            chkAttributes.Checked = False
            chkAttributes.Enabled = False
            chkFirmware.Checked = False
            chkFirmware.Enabled = False
            chkPowerMode.Checked = False
            chkPowerMode.Enabled = False
            chkAsmedia.Checked = False
            chkAsmedia.Enabled = False
            Exit Sub
        End If

        chkAsmedia.Enabled = asmedia
    End Sub

    Public Sub ReliabilityDetails(ByVal d As Device)
        If lvwDevices.Items.Count = 0 Then Exit Sub

        Dim reliability As Device.AtaReliability
        'With cboDevices ' lvwDevices
        'If Not IsNothing(.SelectedIndex) Then ' .SelectedItems.Count) Then
        'Dim d As Device = devlist(.SelectedIndex)
        reliability = d.ATA.Reliability

        'overall
        lblOverallRating.Text = d.ATA.Reliability.Overall & "/5"
        With picOverall
            Select Case d.ATA.Reliability.Overall
                Case 5
                    .Image = My.Resources.rating_5
                Case 4
                    .Image = My.Resources.rating_4
                Case 3
                    .Image = My.Resources.rating_3
                Case 2
                    .Image = My.Resources.rating_2
                Case 1
                    .Image = My.Resources.rating_1
                Case Else
                    .Image = My.Resources.rating_0
            End Select
        End With

        If d.ATA.IsSsd Then
            lblRating2.Visible = False
            lblRating2Value.Visible = False
            picRating2.Visible = False
            lblRating3.Visible = False
            lblRating3Value.Visible = False
            picRating3.Visible = False
            lblRating4.Visible = False
            lblRating4Value.Visible = False
            picRating4.Visible = False

            Dim rel As String = 0
            lblRating1Value.Text = "N/A"

            If IsNumeric(d.ATA.AttributesTracking.Newest.Indilinx) Then
                lblRating1.Text = ssd_indilinx
                lblRating1Value.Text = d.ATA.AttributesTracking.Newest.Indilinx & "/100"
                rel = reliability.Indilinx
            ElseIf IsNumeric(d.ATA.AttributesTracking.Newest.Intel) Then
                lblRating1.Text = ssd_intel
                lblRating1Value.Text = d.ATA.AttributesTracking.Newest.Intel & "/100"
                rel = reliability.Intel
            ElseIf IsNumeric(d.ATA.AttributesTracking.Newest.Micron) Then
                lblRating1.Text = ssd_micron
                lblRating1Value.Text = d.ATA.AttributesTracking.Newest.Micron & "/0"
                rel = reliability.Micron
            ElseIf IsNumeric(d.ATA.AttributesTracking.Newest.Samsung) Then
                lblRating1.Text = ssd_samsung
                lblRating1Value.Text = d.ATA.AttributesTracking.Newest.Samsung & "/100"
                rel = reliability.Samsung
            ElseIf IsNumeric(d.ATA.AttributesTracking.Newest.SandForce) Then
                lblRating1.Text = ssd_sandforce
                lblRating1Value.Text = d.ATA.AttributesTracking.Newest.SandForce & "/100"
                rel = reliability.SandForce
            Else
                lblRating1.Visible = False
                lblRating1Value.Visible = False
                picRating1.Visible = False
            End If

            With picRating1
                Select Case rel
                    Case 5
                        .Image = My.Resources.rating_5
                    Case 4
                        .Image = My.Resources.rating_4
                    Case 3
                        .Image = My.Resources.rating_3
                    Case 2
                        .Image = My.Resources.rating_2
                    Case 1
                        .Image = My.Resources.rating_1
                    Case Else
                        .Image = My.Resources.rating_0
                End Select
            End With

        Else
            lblRating2.Visible = True
            lblRating2Value.Visible = True
            picRating2.Visible = True
            lblRating3.Visible = True
            lblRating3Value.Visible = True
            picRating3.Visible = True
            lblRating4.Visible = True
            lblRating4Value.Visible = True
            picRating4.Visible = True

            lblRating1.Text = hdd_badsectors
            If Not IsNumeric(d.ATA.AttributesTracking.Newest.ReallSect) Then
                lblRating1Value.Text = "N/A"
                picRating1.Image = My.Resources.rating_0
            Else
                lblRating1Value.Text = d.ATA.AttributesTracking.Newest.ReallSect & "/" & d.ATA.Health.BadSectorsThreshold
                With picRating1
                    Select Case reliability.ReallocationCount
                        Case 5
                            .Image = My.Resources.rating_5
                        Case 4
                            .Image = My.Resources.rating_4
                        Case 3
                            .Image = My.Resources.rating_3
                        Case 2
                            .Image = My.Resources.rating_2
                        Case 1
                            .Image = My.Resources.rating_1
                        Case Else
                            .Image = My.Resources.rating_0
                    End Select
                End With
            End If

            lblRating2.Text = hdd_reallevents
            If Not IsNumeric(d.ATA.AttributesTracking.Newest.ReallEvent) Then
                lblRating2Value.Text = "N/A"
                picRating2.Image = My.Resources.rating_0
            Else
                lblRating2Value.Text = d.ATA.AttributesTracking.Newest.ReallEvent & "/" & AppSettings.Reliability.ReallocationEvents
                With picRating2
                    Select Case reliability.ReallocationEvents
                        Case 5
                            .Image = My.Resources.rating_5
                        Case 4
                            .Image = My.Resources.rating_4
                        Case 3
                            .Image = My.Resources.rating_3
                        Case 2
                            .Image = My.Resources.rating_2
                        Case 1
                            .Image = My.Resources.rating_1
                        Case Else
                            .Image = My.Resources.rating_0
                    End Select
                End With
            End If

            lblRating3.Text = hdd_curpending
            If Not IsNumeric(d.ATA.AttributesTracking.Newest.CurPending) Then
                lblRating3Value.Text = "N/A"
                picRating3.Image = My.Resources.rating_0
            Else
                lblRating3Value.Text = d.ATA.AttributesTracking.Newest.CurPending & "/" & AppSettings.Reliability.PendingSectors
                With picRating3
                    Select Case reliability.CurrentPending
                        Case 5
                            .Image = My.Resources.rating_5
                        Case 4
                            .Image = My.Resources.rating_4
                        Case 3
                            .Image = My.Resources.rating_3
                        Case 2
                            .Image = My.Resources.rating_2
                        Case 1
                            .Image = My.Resources.rating_1
                        Case Else
                            .Image = My.Resources.rating_0
                    End Select
                End With
            End If

            lblRating4.Text = hdd_offlunc
            If Not IsNumeric(d.ATA.AttributesTracking.Newest.OfflineUnc) Then
                lblRating4Value.Text = "N/A"
                picRating4.Image = My.Resources.rating_0
            Else
                lblRating4Value.Text = d.ATA.AttributesTracking.Newest.OfflineUnc & "/" & AppSettings.Reliability.UncorrectableSectors
                With picRating4
                    Select Case reliability.OfflineUncorrectable
                        Case 5
                            .Image = My.Resources.rating_5
                        Case 4
                            .Image = My.Resources.rating_4
                        Case 3
                            .Image = My.Resources.rating_3
                        Case 2
                            .Image = My.Resources.rating_2
                        Case 1
                            .Image = My.Resources.rating_1
                        Case Else
                            .Image = My.Resources.rating_0
                    End Select
                End With
            End If
        End If

        'End If
        'End With
    End Sub

    Public Sub Temperatures()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        lblCurrentTempValue.Text = CorF(dev.Temperature)

        lblCycleMin.Text = CorF(dev.ATA.Temperatures.CycleMin)
        lblCycleMax.Text = CorF(dev.ATA.Temperatures.CycleMax)

        With tbCycle
            If IsNumeric(dev.ATA.Temperatures.CycleMin) Then
                .SetTemperatures(dev.ATA.Temperatures.CycleMin, dev.ATA.Temperatures.CycleMax)
            Else
                .SetTemperatures(0, 0)
            End If
        End With

        lblLifeTimeMin.Text = CorF(dev.ATA.Temperatures.LifeTimeMin)
        lblLifeTimeMax.Text = CorF(dev.ATA.Temperatures.LifeTimeMax)

        With tbLifeTime
            If IsNumeric(dev.ATA.Temperatures.LifeTimeMin) Then
                .SetTemperatures(dev.ATA.Temperatures.LifeTimeMin, dev.ATA.Temperatures.LifeTimeMax)
            Else
                .SetTemperatures(0, 0)
            End If
        End With

        lblRecommendedMin.Text = CorF(dev.ATA.Temperatures.RecommendedMin)
        lblRecommendedMax.Text = CorF(dev.ATA.Temperatures.RecommendedMax)

        With tbRecommended
            If IsNumeric(dev.ATA.Temperatures.RecommendedMin) Then
                .SetTemperatures(dev.ATA.Temperatures.RecommendedMin, dev.ATA.Temperatures.RecommendedMax)
            Else
                .SetTemperatures(0, 0)
            End If
        End With

        lblLimitMin.Text = CorF(dev.ATA.Temperatures.LimitMin)
        lblLimitMax.Text = CorF(dev.ATA.Temperatures.LimitMax)

        With tbLimit
            If IsNumeric(dev.ATA.Temperatures.LimitMin) Then
                .SetTemperatures(dev.ATA.Temperatures.LimitMin, dev.ATA.Temperatures.LimitMax)
            Else
                .SetTemperatures(0, 0)
            End If
        End With

        lblZero.Text = CorF(0)
    End Sub

    Public Function CorF(ByVal temperature As String) As String
        If Not IsNumeric(temperature) Then
            Return "-"
        Else
            If AppSettings.General.TemperatureInFahrenheit = False Then
                Return temperature & "°C"
            Else
                Return Math.Round(temperature * 1.8 + 32) & "°F"
            End If
        End If
    End Function
End Class
