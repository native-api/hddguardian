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

    Public Sub PopulateScsiPanels()
        isloading_devsettings = True

        Dim d As Device = devlist(cboDevices.SelectedIndex)

        FillEvents()
        DisplayEvents()
        If optEntire.Checked Then
            SetFullGraph()
        Else
            SetGraph(mcLog.SelectionRange.Start, mcLog.SelectionRange.End)
        End If

        '*******************
        '*** SMART setup ***
        '*******************
        'smart
        If d.Smart.Support = Support.Available Then
            chkScsiSmart.Enabled = Not d.IsVirtual
            If d.Smart.IsEnabled = Support.Enabled Then
                chkScsiSmart.Checked = True
            Else
                chkScsiSmart.Checked = False
            End If
        Else
            chkScsiSmart.Enabled = False
            chkScsiSmart.Checked = False
        End If
        'gltsd
        chkScsiGltsd.Enabled = Not d.IsVirtual
        chkScsiGltsd.Checked = d.Scsi.Features.Gltsd.IsEnabled
        'write cache
        If d.Scsi.Features.WriteCache.Available Then
            chkScsiWCache.Enabled = Not d.IsVirtual
            chkScsiWCache.Checked = d.Scsi.Features.WriteCache.IsEnabled
        Else
            chkScsiWCache.Checked = False
            chkScsiWCache.Enabled = False
        End If
        'read cache
        If d.Scsi.Features.ReadCache.Available Then
            chkScsiRCache.Enabled = Not d.IsVirtual
            chkScsiRCache.Checked = d.Scsi.Features.ReadCache.IsEnabled
        Else
            chkScsiRCache.Checked = False
            chkScsiRCache.Enabled = False
        End If

        '**************
        '*** errors ***
        '**************
        With tvwScsiErrors
            If d.Scsi.ErrorLog.HasLog Then
                lblScsiNoErrors.Visible = False
                .Nodes.Clear()
                If d.Scsi.ErrorLog.Read.HasData Then
                    .Nodes.Add("r", m_scsiread)
                    With .Nodes("r")
                        .Nodes.Add("r_ecc", m_scsiecc)
                        With .Nodes("r_ecc")
                            .Nodes.Add(m_scsifast & ": " & Format(Val(d.Scsi.ErrorLog.Read.EccFast), "#,##0"))
                            .Nodes.Add(m_scsidelayed & ": " & Format(Val(d.Scsi.ErrorLog.Read.EccDelayed), "#,##0"))
                            .Nodes.Add(m_scsirrrw & ": " & Format(Val(d.Scsi.ErrorLog.Read.EccReReadReWrites), "#,##0"))
                        End With
                        .Nodes.Add(m_scsicorrected & ": " & Format(Val(d.Scsi.ErrorLog.Read.ErrorsCorrected), "#,##0"))
                        .Nodes.Add(m_scsialgorithm & ": " & Format(Val(d.Scsi.ErrorLog.Read.CorrectionAlgorithmInvocations), "#,##0"))
                        .Nodes.Add(m_scsigb & ": " & Format(Val(d.Scsi.ErrorLog.Read.GbProcessed), "#,##0.00"))
                        .Nodes.Add(m_scsiuncorrected & ": " & Format(Val(d.Scsi.ErrorLog.Read.UncorrectedErrors), "#,##0"))
                    End With
                End If
                If d.Scsi.ErrorLog.Write.HasData Then
                    .Nodes.Add("w", m_scsiwrite)
                    With .Nodes("w")
                        .Nodes.Add("w_ecc", m_scsiecc)
                        With .Nodes("w_ecc")
                            .Nodes.Add(m_scsifast & ": " & Format(Val(d.Scsi.ErrorLog.Write.EccFast), "#,##0"))
                            .Nodes.Add(m_scsidelayed & ": " & Format(Val(d.Scsi.ErrorLog.Write.EccDelayed), "#,##0"))
                            .Nodes.Add(m_scsirrrw & ": " & Format(Val(d.Scsi.ErrorLog.Write.EccReReadReWrites), "#,##0"))
                        End With
                        .Nodes.Add(m_scsicorrected & ": " & Format(Val(d.Scsi.ErrorLog.Write.ErrorsCorrected), "#,##0"))
                        .Nodes.Add(m_scsialgorithm & ": " & Format(Val(d.Scsi.ErrorLog.Write.CorrectionAlgorithmInvocations), "#,##0"))
                        .Nodes.Add(m_scsigb & ": " & Format(Val(d.Scsi.ErrorLog.Write.GbProcessed), "#,##0.00"))
                        .Nodes.Add(m_scsiuncorrected & ": " & Format(Val(d.Scsi.ErrorLog.Write.UncorrectedErrors), "#,##0"))
                    End With
                End If
                If d.Scsi.ErrorLog.Verify.HasData Then
                    .Nodes.Add("v", m_scsiverify)
                    With .Nodes("v")
                        .Nodes.Add("v_ecc", m_scsiecc)
                        With .Nodes("v_ecc")
                            .Nodes.Add(m_scsifast & ": " & Format(Val(d.Scsi.ErrorLog.Verify.EccFast), "#,##0"))
                            .Nodes.Add(m_scsidelayed & ": " & Format(Val(d.Scsi.ErrorLog.Verify.EccDelayed), "#,##0"))
                            .Nodes.Add(m_scsirrrw & ": " & Format(Val(d.Scsi.ErrorLog.Verify.EccReReadReWrites), "#,##0"))
                        End With
                        .Nodes.Add(m_scsicorrected & ": " & Format(Val(d.Scsi.ErrorLog.Verify.ErrorsCorrected), "#,##0"))
                        .Nodes.Add(m_scsialgorithm & ": " & Format(Val(d.Scsi.ErrorLog.Verify.CorrectionAlgorithmInvocations), "#,##0"))
                        .Nodes.Add(m_scsigb & ": " & Format(Val(d.Scsi.ErrorLog.Verify.GbProcessed), "#,##0.00"))
                        .Nodes.Add(m_scsiuncorrected & ": " & Format(Val(d.Scsi.ErrorLog.Verify.UncorrectedErrors), "#,##0"))
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
            If d.Scsi.SelfTestLog.HasLog Then
                lblScsiTestCounter.Visible = False
                For i As Short = 0 To d.Scsi.SelfTestLog.Item.Count - 1
                    .Items.Add(d.Scsi.SelfTestLog.Item(i).Number)
                    With .Items(.Items.Count - 1)
                        Dim desc As String = d.Scsi.SelfTestLog.Item(i).Description
                        Dim status As String = d.Scsi.SelfTestLog.Item(i).Status
                        For n As Short = 0 To m_scsidescription.Count - 1
                            desc = desc.Replace(m_scsidescription(n).Original, m_scsidescription(n).Change).Trim
                        Next
                        For n As Short = 0 To m_scsiresults.Count - 1
                            status = status.Replace(m_scsiresults(n).Original, m_scsiresults(n).Change).Trim
                        Next
                        .SubItems.Add(desc)
                        If status.Contains("-->") Then
                            .SubItems.Add(status.Replace("-->", d.Scsi.SelfTestLog.Item(i).SegmentNumber))
                        Else
                            .SubItems.Add(status)
                        End If
                        .SubItems.Add(d.Scsi.SelfTestLog.Item(i).SegmentNumber)
                        .SubItems.Add(d.Scsi.SelfTestLog.Item(i).LifeTime)
                        .SubItems.Add(d.Scsi.SelfTestLog.Item(i).LbaOfFirstError)
                        .SubItems.Add(d.Scsi.SelfTestLog.Item(i).SK)
                        .SubItems.Add(d.Scsi.SelfTestLog.Item(i).ASC)
                        .SubItems.Add(d.Scsi.SelfTestLog.Item(i).ASQ)
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
        If IsNumeric(d.Scsi.Test.Duration) Then
            lblScsiTest.Text = lblScsiTest.Tag.ToString.Replace("%1", d.Scsi.Test.Duration).Replace("%2", d.Scsi.Test.Duration \ 60)
            btnScsiRun.Enabled = True
            tlpScsiTest.Visible = Not d.IsVirtual
        Else
            lblScsiTest.Text = d.Scsi.Test.Duration
            btnScsiRun.Enabled = False
        End If

        '*** smartctl section ***
        txtReport.Text = d.Output

        isloading_devsettings = False
    End Sub

End Class
