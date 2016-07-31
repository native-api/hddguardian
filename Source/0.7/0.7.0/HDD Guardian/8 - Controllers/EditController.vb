'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2016 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Management
Imports System.ComponentModel

Public Class EditController

    Private Sub EditController_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cs As New ColorScheme
        Me.BackColor = cs.BackColor
        For Each c In tlpController.Controls
            If c.GetType.Name = "Label" Then
                c.Forecolor = cs.ForeColor
            End If
        Next
        pnlBottom.BackColor = cs.StatusBarBackColor
        '-------------------------------------------

        If SettingsForm.editmode = True Then
            cboControllers.Items.Clear()
            With SettingsForm.lvwControllers
                cboControllers.Items.Add(.Items(.SelectedItems(0).Index).Text)

                cboControllers.SelectedIndex = 0

                For i As Short = 0 To cboLayers.Items.Count - 1
                    If cboLayers.Items(i) = .Items(.SelectedItems(0).Index).SubItems(1).Text Then
                        cboLayers.SelectedIndex = i
                        Exit For
                    End If
                Next

                If .Items(.SelectedItems(0).Index).SubItems(3).Text = Main.m_yes Then
                    cboAllowed.SelectedIndex = 1
                Else
                    cboAllowed.SelectedIndex = 0
                End If

                txtTester.Text = .Items(.SelectedItems(0).Index).SubItems(4).Text
            End With
            btnAdd.Enabled = True
            btnAdd.Text = Main.GetString(4643)
        Else
            'get installed SCSI controllers
            Dim win32_scsicontroller As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_SCSIController")
            cboControllers.Items.Clear()
            For Each scsi As ManagementObject In win32_scsicontroller.Get()
                cboControllers.Items.Add(scsi("Name").ToString.Trim)
            Next
            win32_scsicontroller = Nothing

            If cboControllers.Items.Count > 0 Then
                cboControllers.SelectedIndex = 0
                btnAdd.Enabled = True
            Else
                btnAdd.Enabled = False
            End If

            cboLayers.SelectedIndex = 0
            cboAllowed.SelectedIndex = 0
            txtTester.Text = ""

            btnAdd.Text = Main.GetString(4620)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        With SettingsForm
            If .editmode Then
                With .lvwControllers.SelectedItems(0)
                    '.Text value remain the same...
                    .SubItems(1).Text = cboLayers.SelectedItem
                    If cboAllowed.SelectedIndex = 0 Then
                        'SATA
                        .SubItems(2).Text = Main.m_yes
                        'SCSI
                        .SubItems(3).Text = Main.m_no
                    Else
                        'SATA
                        .SubItems(2).Text = Main.m_yes
                        'SCSI
                        .SubItems(3).Text = Main.m_yes
                    End If
                    .SubItems(4).Text = txtTester.Text
                End With
                Me.Close()
            Else
                With .lvwControllers
                    .Items.Add(cboControllers.SelectedItem)
                    .Items(.Items.Count - 1).SubItems.Add(cboLayers.SelectedItem)
                    If cboAllowed.SelectedIndex = 0 Then
                        'SATA
                        .Items(.Items.Count - 1).SubItems.Add(Main.m_yes)
                        'SCSI
                        .Items(.Items.Count - 1).SubItems.Add(Main.m_no)
                    Else
                        'SATA
                        .Items(.Items.Count - 1).SubItems.Add(Main.m_yes)
                        'SCSI
                        .Items(.Items.Count - 1).SubItems.Add(Main.m_yes)
                    End If
                    .Items(.Items.Count - 1).SubItems.Add(txtTester.Text)
                End With
                Me.Close()
            End If
        End With

        'Me.Close()
    End Sub

End Class