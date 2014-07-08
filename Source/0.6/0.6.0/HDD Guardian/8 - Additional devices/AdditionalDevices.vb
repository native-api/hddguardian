'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Public Class AdditionalDevicesDlg

    Private Sub AdditionalDevicesDlg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAdditionalCommand.Text = ""
        txtAdditionalDescription.Text = ""
        btnAdditionalAdd.Enabled = False
    End Sub

    Private Sub btnAdditionalCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdditionalCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdditionalAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdditionalAdd.Click
        With Settings.lvwAdditionalDevices
            .Items.Add(txtAdditionalDescription.Text)
            .Items(.Items.Count - 1).SubItems.Add(txtAdditionalCommand.Text)
        End With
        'exit from sub
        Me.Close()
    End Sub

    Private Sub CheckText(sender As Object, e As EventArgs) Handles txtAdditionalDescription.TextChanged, txtAdditionalCommand.TextChanged
        If txtAdditionalCommand.Text.Trim.Length > 0 And txtAdditionalDescription.Text.Trim.Length > 0 Then
            btnAdditionalAdd.Enabled = True
        Else
            btnAdditionalAdd.Enabled = False
        End If
    End Sub
End Class