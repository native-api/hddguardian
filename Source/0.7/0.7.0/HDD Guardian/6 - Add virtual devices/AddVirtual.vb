'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2016 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Public Class AddVirtualDevice

    Dim content() As String

    Private Function GetInfo(ByVal info As String) As String
        Dim value As String = "N/A"
        For i As Integer = 0 To content.Length - 1
            If content(i).ToLower.Contains(info.ToLower) Then
                Dim result() As String = content(i).Split(":", 2, StringSplitOptions.RemoveEmptyEntries)
                If result(1).Trim.Contains("[No Information Found]") Then
                    Return "N/A"
                Else
                    Return result(1).Trim
                End If
            End If
        Next
        Return value
    End Function

    Private Sub AddVirtual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cs As New ColorScheme
        Me.BackColor = cs.BackColor
        pnlBottom.BackColor = cs.StatusBarBackColor
        lblDescription.ForeColor = cs.ForeColor
        lblLocation.ForeColor = cs.ForeColor
        lblFile.ForeColor = cs.GrayedText
        '-------------------------------------------

        txtDescription.Text = ""
        lblFile.Text = ""
        btnAdd.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        btnAdd.Enabled = False

        With dlgVirtual
            .FileName = ""
            .Filter = "*.txt|*.txt"
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                content = IO.File.ReadAllLines(.FileName)
                Dim havedata As Boolean = False
                For i As Short = 0 To content.Length - 1
                    If content(i).Contains("START OF INFORMATION SECTION") Then
                        havedata = True
                        Exit For
                    End If
                Next
                If havedata Then
                    lblFile.Text = IO.Path.GetFileNameWithoutExtension(.FileName)
                    lblFile.Tag = .FileName
                    btnAdd.Enabled = True
                Else
                    MsgBox(Main.m_nogooddata, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Main.m_dataerror)
                End If
            End If
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Main.AddVirtual(txtDescription.Text, lblFile.Tag)

        'exit from sub
        Me.Close()
    End Sub
End Class