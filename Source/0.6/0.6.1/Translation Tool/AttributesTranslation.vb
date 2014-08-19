'Translation Tool is the HDD Guardian translation utility
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Xml

Module AttributesTranslation

    Public Sub LoadDefaultAttributes()
        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmldoc.LoadXml(My.Resources.default_attributes)
        m_nodelist = m_xmldoc.SelectNodes("/table/attribute")

        For Each m_node In m_nodelist
            Dim smartctlname As String = m_node.Attributes.GetNamedItem("smartctl").Value
            Dim group As String = m_node.Attributes.GetNamedItem("group").Value
            Dim havegroup As Boolean = False
            If smartctlname.Length > 0 Then
                With MainTranslationTool.lvwAttributes
                    .ShowGroups = True
                    'If .Groups.Count > 0 Then
                    For i As Short = 0 To .Groups.Count - 1
                        If .Groups(i).Header = group Then
                            havegroup = True
                            Exit For
                        End If
                    Next
                    If Not havegroup Then .Groups.Add(New ListViewGroup(group, group))
                    'End If

                    .Items.Add(m_node.ChildNodes.Item(0).InnerText)
                    .Items(.Items.Count - 1).Group = .Groups(group)
                    .Items(.Items.Count - 1).Tag = smartctlname
                    .Items(.Items.Count - 1).SubItems.Add(m_node.ChildNodes.Item(1).InnerText.Replace(vbCrLf, "").Trim)
                    .Items(.Items.Count - 1).SubItems.Add("")
                End With
            End If
        Next
        MainTranslationTool.chItemName.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        MainTranslationTool.chDefaultAttr.Width = (MainTranslationTool.lvwAttributes.ClientRectangle.Width - MainTranslationTool.chItemName.Width) / 2
        MainTranslationTool.chNewAttr.Width = (MainTranslationTool.lvwAttributes.ClientRectangle.Width - MainTranslationTool.chItemName.Width) / 2
        MainTranslationTool.lvwAttributes.Items(0).Selected = True
    End Sub

    Public Sub SaveAttributes()
        If MainTranslationTool.isclosing Then Exit Sub

        Dim output As XmlWriterSettings = New XmlWriterSettings()
        output.Indent = True

        Dim folder As String = My.Application.Info.DirectoryPath & "\" & MainTranslationTool.cboCulture.SelectedItem.ToString & "\"
        If Not IO.Directory.Exists(folder) Then Exit Sub

        Using write As XmlWriter = XmlWriter.Create(folder & "attributes.xml", output)
            ' Begin writing.
            write.WriteStartDocument()
            write.WriteStartElement("table") 'root element
            'the attributes meanings strings
            For i As Short = 0 To MainTranslationTool.lvwAttributes.Items.Count - 1
                If MainTranslationTool.lvwAttributes.Items(i).SubItems(2).Text.Length > 0 Then
                    write.WriteStartElement("attribute") 'start attribute
                    write.WriteAttributeString("smartctl", MainTranslationTool.lvwAttributes.Items(i).Tag.ToString)
                    write.WriteAttributeString("group", MainTranslationTool.lvwAttributes.Items(i).Group.Header)
                    write.WriteStartElement("name") 'start attribute name
                    write.WriteString(MainTranslationTool.lvwAttributes.Items(i).Text)
                    write.WriteEndElement()
                    write.WriteStartElement("description") 'start attribute meaning
                    write.WriteString(MainTranslationTool.lvwAttributes.Items(i).SubItems(2).Text)
                    write.WriteEndElement()
                    write.WriteEndElement()
                End If
            Next
            'end of root element & write the document
            write.WriteEndElement()
            write.WriteEndDocument()
        End Using
    End Sub

    Public Sub SaveEmptyAttributes()
        If MainTranslationTool.isclosing Then Exit Sub

        Dim folder As String = My.Application.Info.DirectoryPath & "\" & MainTranslationTool.cboCulture.SelectedItem.ToString & "\"

        If Not IO.Directory.Exists(folder) Then
            IO.Directory.CreateDirectory(folder)

            Dim output As XmlWriterSettings = New XmlWriterSettings()
            output.Indent = True

            Using write As XmlWriter = XmlWriter.Create(folder & "attributes.xml", output)
                ' Begin writing.
                write.WriteStartDocument() 'start document
                write.WriteStartElement("table") 'root element
                write.WriteStartElement("attribute") 'start attribute
                write.WriteAttributeString("smartctl", "") 'smartctl attribute name
                write.WriteAttributeString("group", "") 'attribute group
                write.WriteStartElement("name") 'attribute name
                write.WriteEndElement() 'end attribute name
                write.WriteStartElement("description") 'attribute description
                write.WriteEndElement() 'end attribute description
                write.WriteEndElement() 'end attribute
                write.WriteEndElement() 'end root
                write.WriteEndDocument() 'end document
            End Using
        End If
    End Sub

    Public Sub LoadAttributes()
        Dim folder As String = My.Application.Info.DirectoryPath & "\" & MainTranslationTool.cboCulture.SelectedItem.ToString & "\"

        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        On Error Resume Next
        m_xmldoc.Load(folder & "attributes.xml")
        m_nodelist = m_xmldoc.SelectNodes("/table/attribute")

        With MainTranslationTool.lvwAttributes
            For i As Short = 0 To .Items.Count - 1
                .Items(i).SubItems(2).Text = ""
                .Items(i).ForeColor = Color.Red
            Next
        End With

        For Each m_node In m_nodelist
            Dim smartctlname As String = m_node.Attributes.GetNamedItem("smartctl").Value
            Dim group As String = m_node.Attributes.GetNamedItem("group").Value
            Dim txt As String = m_node.ChildNodes.Item(1).InnerText.Replace(vbCrLf, "").Trim
            If smartctlname.Length > 0 Then
                With MainTranslationTool.lvwAttributes
                    For i As Short = 0 To .Items.Count - 1
                        If .Items(i).Tag = smartctlname And .Items(i).Group.Header = group Then
                            .Items(i).SubItems(2).Text = txt
                            If txt.Trim.Length > 0 Then .Items(i).ForeColor = Color.FromKnownColor(KnownColor.WindowText)
                        End If
                    Next
                End With
            End If
        Next
    End Sub

End Module
