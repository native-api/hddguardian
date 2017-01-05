'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Public Class AddCustomAttribute

    Private Sub cboAttributes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAttributes.SelectedIndexChanged
        Dim cboBox As ComboBox = sender

        lblAttribute.Visible = True
        If cboAttributes.SelectedIndex > 0 Then
            lblAttribute.Text = Main.m_attributes(cboAttributes.SelectedIndex)
        End If

        Select Case cboBox.SelectedIndex
            Case 0
                cboID.SelectedIndex = 0
                cboFormat.SelectedIndex = 0
                txtName.Text = ""
                lblAttribute.Visible = False
            Case 1
                cboID.SelectedIndex = 10
                cboFormat.SelectedIndex = 10
                txtName.Text = "Power_On_Minutes"
            Case 2
                cboID.SelectedIndex = 10
                cboFormat.SelectedIndex = 11
                txtName.Text = "Power_On_Seconds"
            Case 3
                cboID.SelectedIndex = 10
                cboFormat.SelectedIndex = 12
                txtName.Text = "Power_On_Half_Minutes"
            Case 4
                cboID.SelectedIndex = 10
                cboFormat.SelectedIndex = 13
                txtName.Text = "Temperature_Celsius"
            Case 5
                cboID.SelectedIndex = 193
                cboFormat.SelectedIndex = 6
                txtName.Text = "Emerg_Retract_Cycle_Ct"
            Case 6
                cboID.SelectedIndex = 194
                cboFormat.SelectedIndex = 5
                txtName.Text = "Load-Unload_Cycle_Count"
            Case 7
                cboID.SelectedIndex = 195
                cboFormat.SelectedIndex = 14
                txtName.Text = "Temperature_Celsius_x10"
            Case 8
                cboID.SelectedIndex = 195
                cboFormat.SelectedIndex = 6
                txtName.Text = "Unknown_Attribute"
            Case 9
                cboID.SelectedIndex = 198
                cboFormat.SelectedIndex = 6
                txtName.Text = "Total_Pending_Sectors"
            Case 10
                cboID.SelectedIndex = 199
                cboFormat.SelectedIndex = 6
                txtName.Text = "Total_Offl_Uncorrectabl"
            Case 11
                cboID.SelectedIndex = 199
                cboFormat.SelectedIndex = 6
                txtName.Text = "Offline_Scan_UNC_SectCt"
            Case 12
                cboID.SelectedIndex = 201
                cboFormat.SelectedIndex = 6
                txtName.Text = "Write_Error_Count"
            Case 13
                cboID.SelectedIndex = 202
                cboFormat.SelectedIndex = 6
                txtName.Text = "Detected_TA_Count"
            Case 14
                cboID.SelectedIndex = 221
                cboFormat.SelectedIndex = 6
                txtName.Text = "Temperature_Celsius"
        End Select
        If cboID.SelectedIndex > 0 Then cboID.Enabled = False Else cboID.Enabled = True
        If cboFormat.SelectedIndex > 0 Then cboFormat.Enabled = False Else cboFormat.Enabled = True
        If txtName.Text.Length > 0 Then txtName.Enabled = False Else txtName.Enabled = True

        btnAdd.Enabled = ValidateEntries()
    End Sub

    Private Sub cboFormat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFormat.SelectedIndexChanged
        If cboFormat.SelectedIndex = 0 Then
            lblAttributeFormat.Visible = False
        Else
            lblAttributeFormat.Visible = True
            lblAttributeFormat.Text = Main.m_formats(cboFormat.SelectedIndex)
        End If
    End Sub

    Private Sub cboID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboID.SelectedIndexChanged
        Dim cboBox As ComboBox = sender

        Select Case cboBox.SelectedItem.ToString
            Case ""
                cboFormat.SelectedIndex = 0
            Case "3"
                cboFormat.SelectedIndex = 3
            Case "5"
                cboFormat.SelectedIndex = 4
            Case "190"
                cboFormat.SelectedIndex = 13
            Case "194"
                cboFormat.SelectedIndex = 13
            Case "196"
                cboFormat.SelectedIndex = 4
            Case Else
                cboFormat.SelectedIndex = 6
        End Select
        btnAdd.Enabled = ValidateEntries()
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        Select Case e.KeyChar.ToString
            Case "-", "a" To "z", "A" To "Z", "0" To "9", "_", ControlChars.Back.ToString
                'accept ONLY letters, numbers, underscores, lines and backspaces (for editing) digits;
                'arrow keys and cancel key is also accepted by textbox.
            Case Else
                'discard all the others digits.
                e.KeyChar = ""
        End Select
    End Sub

    Private Function ValidateEntries() As Boolean
        If cboFormat.SelectedIndex = 0 Or cboID.SelectedIndex = 0 Then Return False Else Return True
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        With Main.lvwAttrFormat
            .Items.Add(cboID.Text)
            .Items(.Items.Count - 1).SubItems.Add(cboFormat.Text)
            .Items(.Items.Count - 1).SubItems.Add(txtName.Text)
        End With
        Main.btnRemove.Enabled = False
        Main.SaveDeviceSettings()

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub AddCustomAttribute_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cs As New ColorScheme
        Me.BackColor = cs.BackColor
        lblAttribute.ForeColor = cs.GrayedText
        lblID.ForeColor = cs.ForeColor
        lblFormat.ForeColor = cs.ForeColor
        lblAttributeFormat.ForeColor = cs.GrayedText
        lblName.ForeColor = cs.ForeColor
        pnlBottom.BackColor = cs.StatusBarBackColor
    End Sub
End Class