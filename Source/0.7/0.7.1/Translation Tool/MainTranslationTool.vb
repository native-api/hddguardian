'Translation Tool is the HDD Guardian translation utility
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Xml

Public Class MainTranslationTool
    Structure CultureCodes
        Dim Code, Description As String
    End Structure

    Class CultureCollection
        Inherits List(Of CultureCodes)
    End Class

    Dim cultures As New CultureCollection
    Dim isloading As Boolean = False
    Public isclosing As Boolean = False

#Region "Main form"
    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        isclosing = True
    End Sub

    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            'MsgBox("HDD Guardian Translation Tool require administration rights.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error")
            'End
        End If

        Dim c() As String = My.Resources.cultures.Split(vbCrLf)
        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmldoc.LoadXml(My.Resources.cultures)
        m_nodelist = m_xmldoc.SelectNodes("/cultures/item")

        isloading = True
        LoadDefaultTranslation()

        LoadDefaultAttributes()
        isloading = False

        For Each m_node In m_nodelist
            Dim cult As String = m_node.Attributes.GetNamedItem("culture").Value
            Dim zone As String = m_node.Attributes.GetNamedItem("zone").Value
            cboCulture.Items.Add(cult)
            Dim item As New CultureCodes
            item.Code = cult
            item.Description = zone
            cultures.Add(item)
        Next

        'cboCulture.Sorted = True
        cboCulture.SelectedIndex = 0
        lblSelLanguage.Text = cultures(cboCulture.SelectedIndex).Description
        txtLanguage.Enabled = False
        txtLanguage.ResetText()
        txtTranslator.Enabled = False
        txtTranslator.ResetText()
        tlpVersion.Enabled = False
        txtMajor.ResetText()
        txtMinor.ResetText()
        txtRevision.ResetText()

        lblChoosenCulture.Text = "-"
        fpbAttributes.Value = 0
        fpbInterface.Value = 0
        lblTranlsationInterface.Text = ""
        lblTranslationAttributes.Text = ""

        InvokeOnClick(robProject, Nothing)
    End Sub
#End Region

#Region "Toolbar"
    Private Sub robInterface_Click(sender As Object, e As EventArgs) Handles robInterface.Click
        isloading = True
        robProject.Checked = False
        htcMain.SelectPage(tpInterface)
        isloading = False
    End Sub

    Private Sub robAttributes_Click(sender As Object, e As EventArgs) Handles robAttributes.Click
        isloading = True
        robProject.Checked = False
        htcMain.SelectPage(tpAttributes)
        isloading = False
    End Sub

    Private Sub robProject_Click(sender As Object, e As EventArgs) Handles robProject.Click
        robInterface.Checked = False
        robAttributes.Checked = False
        htcMain.SelectPage(tpMangement)
    End Sub
#End Region

#Region "Project management"
    Private Sub cboCulture_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCulture.SelectedIndexChanged
        lblSelLanguage.Text = cultures(cboCulture.SelectedIndex).Description

        Dim folder As String = My.Application.Info.DirectoryPath & "\" & cboCulture.SelectedItem.ToString & "\"
        isloading = True

        If IO.Directory.Exists(folder) Then
            txtLanguage.Clear()
            txtTranslator.Clear()
            txtMajor.Clear()
            txtMinor.Clear()
            txtRevision.Clear()

            If IO.File.Exists(folder & "info.xml") Then
                LoadTranslatorInfo()

                If IO.File.Exists(folder & "interface.xml") Then
                    LoadTranslation()
                Else
                    SaveEmptyTranslation()
                End If

                If IO.File.Exists(folder & "attributes.xml") Then
                    LoadAttributes()
                Else
                    SaveEmptyAttributes()
                End If
            Else
                SaveTranslatorInfo()
                SaveEmptyTranslation()
                SaveEmptyAttributes()
            End If

            'On Error Resume Next
            lvwTranslation.Items(0).Selected = True
            lvwAttributes.Items(0).Selected = True
            txtNew.Text = lvwTranslation.Items(0).SubItems(1).Text
            txtNewAttr.Text = lvwAttributes.Items(0).SubItems(2).Text
            txtLanguage.Enabled = True
            txtTranslator.Enabled = True
            tlpVersion.Enabled = True

            btnCreate.Enabled = False
            btnSave.Enabled = True
            btnFolder.Enabled = True
            'tpMangement.Enabled = True
            robAttributes.Enabled = True
            robInterface.Enabled = True

            lblChoosenCulture.Text = cboCulture.SelectedItem.ToString & " / " & cultures(cboCulture.SelectedIndex).Description
        Else
            txtLanguage.Enabled = False
            txtLanguage.ResetText()
            txtTranslator.Enabled = False
            txtTranslator.ResetText()
            tlpVersion.Enabled = False
            txtMajor.Text = "0"
            txtMinor.Text = "0"
            txtRevision.Text = "0"

            For i As Short = 0 To lvwAttributes.Items.Count - 1
                lvwAttributes.Items(i).SubItems(2).Text = ""
                lvwAttributes.Items(i).ForeColor = Color.Red
            Next

            For i As Short = 0 To lvwTranslation.Items.Count - 1
                lvwTranslation.Items(i).SubItems(1).Text = ""
                lvwTranslation.Items(i).ForeColor = Color.Red
            Next

            btnCreate.Enabled = True
            btnSave.Enabled = False
            btnFolder.Enabled = False
            'tabTranslation.Enabled = False
            robAttributes.Enabled = False
            robInterface.Enabled = False
        End If

        InterfaceTranslationProgress()
        AttributesTranslationProgress()

        isloading = False
    End Sub

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Dim folder As String = My.Application.Info.DirectoryPath & "\" & cboCulture.SelectedItem.ToString & "\"

        If Not IO.Directory.Exists(folder) Then
            IO.Directory.CreateDirectory(folder)

            Dim output As XmlWriterSettings = New XmlWriterSettings()
            output.Indent = True

            If Not IO.Directory.Exists(folder) Then Exit Sub

            SaveEmptyTranslation()

            SaveEmptyAttributes()

            SaveTranslatorInfo()

            'tabTranslation.Enabled = True
            robAttributes.Enabled = True
            robInterface.Enabled = True
            btnSave.Enabled = True
            btnFolder.Enabled = True
            btnCreate.Enabled = False

            txtLanguage.Enabled = True
            txtTranslator.Enabled = True
            tlpVersion.Enabled = True
        End If
    End Sub

    Private Sub txtLanguage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLanguage.TextChanged
        If txtLanguage.Text.Length = 0 Or txtTranslator.Text.Length = 0 Then
            btnCreate.Enabled = False
        Else
            btnCreate.Enabled = True
        End If
    End Sub

    Private Sub txtTranslator_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTranslator.TextChanged
        If txtLanguage.Text.Length = 0 Or txtTranslator.Text.Length = 0 Then
            btnCreate.Enabled = False
        Else
            btnCreate.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveTranslatorInfo()
        SaveTranslation()
        SaveAttributes()
    End Sub

    Private Sub btnFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFolder.Click
        Process.Start("explorer.exe", My.Application.Info.DirectoryPath & "\" & cboCulture.SelectedItem.ToString & "\")
    End Sub

    Private Sub Validate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMajor.KeyPress, txtMinor.KeyPress, txtRevision.KeyPress
        Select Case e.KeyChar
            Case "0" To "9", ControlChars.Back.ToString
                'do nothing, all ok (boxes accepts only numbers and backspace for editing purposes)!
            Case Else
                e.KeyChar = ""
        End Select
    End Sub
#End Region

#Region "Interface translation"
    Private Sub lvwTranslation_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwTranslation.ItemSelectionChanged
        If e.IsSelected _
            Then txtDefault.Text = lvwTranslation.SelectedItems(0).Text.Replace("\", vbCrLf)

        If e.Item.SubItems(1).Text.Length > 0 Then
            txtNew.Text = e.Item.SubItems(1).Text.Replace("\", vbCrLf)
        Else
            txtNew.Text = ""
        End If
    End Sub

    Private Sub txtNew_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNew.KeyPress
        If e.KeyChar = """" Then e.KeyChar = "'"
    End Sub

    Private Sub txtNew_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNew.TextChanged
        Try
            Dim i As Short = lvwTranslation.SelectedItems(0).Index

            lvwTranslation.Items(i).SubItems(1).Text = txtNew.Text.Replace(vbCrLf, "\")

            If txtNew.Text.Length > 0 Then
                lvwTranslation.Items(i).ForeColor = Color.FromKnownColor(KnownColor.WindowText)
            Else
                lvwTranslation.Items(i).ForeColor = Color.Red
            End If

            SetForSameItem(lvwTranslation.Items(i).Text, txtNew.Text)
        Catch
        End Try
    End Sub

    Private Sub lvwTranslation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwTranslation.SelectedIndexChanged
        If Not isloading Then
            SaveTranslation()
            InterfaceTranslationProgress()
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        With lvwTranslation
            Dim i As Short = .SelectedItems(0).Index + 1
            If i > .Items.Count - 1 Then i = 0
            .Items(i).Selected = True
            .Items(i).EnsureVisible()
        End With
    End Sub
#End Region

#Region "Attributes translation"
    Private Sub lvwAttributes_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwAttributes.ItemSelectionChanged
        If e.IsSelected Then txtDefaultAttr.Text = e.Item.SubItems(1).Text

        If e.Item.SubItems(2).Text.Length > 0 Then
            txtNewAttr.Text = e.Item.SubItems(2).Text
        Else
            txtNewAttr.Text = ""
        End If
    End Sub

    Private Sub txtNewAttr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewAttr.TextChanged
        Try
            Dim i As Short = lvwAttributes.SelectedItems(0).Index

            lvwAttributes.Items(i).SubItems(2).Text = txtNewAttr.Text.Replace(vbCrLf, " ")

            If txtNewAttr.Text.Length > 0 Then
                lvwAttributes.Items(i).ForeColor = Color.FromKnownColor(KnownColor.WindowText)
            Else
                lvwAttributes.Items(i).ForeColor = Color.Red
            End If

        Catch
        End Try
    End Sub

    Private Sub lvwAttributes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwAttributes.SelectedIndexChanged
        If Not isloading Then
            SaveAttributes()
            AttributesTranslationProgress()
        End If
    End Sub

    Private Sub btnNextAttr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextAttr.Click
        With lvwAttributes
            Dim i As Short = .SelectedItems(0).Index + 1
            If i > .Items.Count - 1 Then i = 0
            .Items(i).Selected = True
            .Items(i).EnsureVisible()
        End With
    End Sub
#End Region

#Region "Custom subs"
    Private Sub SetForSameItem(ByVal origText As String, newText As String)
        With lvwTranslation
            For i As Short = 0 To .Items.Count - 1
                If Not IsNothing(.Items(i).SubItems(1)) Then
                    If .Items(i).SubItems(1).Text.Length = 0 And .Items(i).Text = origText Then
                            .Items(i).SubItems(1).Text = newText
                            .Items(i).ForeColor = Color.FromKnownColor(KnownColor.WindowText)
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub InterfaceTranslationProgress()
        Dim tot As Short = lvwTranslation.Items.Count
        Dim completed As Short = 0

        Try
            For Each item As ListViewItem In lvwTranslation.Items
                If item.SubItems(1).Text.Length > 0 Then
                    completed += 1
                End If
            Next
        Catch
        End Try

        fpbInterface.MaxValue = lvwTranslation.Items.Count
        fpbInterface.Value = completed

        lblTranlsationInterface.Text = completed & "/" & tot
    End Sub

    Private Sub AttributesTranslationProgress()
        Dim tot As Short = lvwAttributes.Items.Count
        Dim completed As Short = 0

        Try
            For Each item As ListViewItem In lvwAttributes.Items
                If item.SubItems(2).Text.Length > 0 Then
                    completed += 1
                End If
            Next
        Catch
        End Try

        fpbAttributes.MaxValue = lvwAttributes.Items.Count
        fpbAttributes.Value = completed

        lblTranslationAttributes.Text = completed & "/" & tot
    End Sub
#End Region

End Class
