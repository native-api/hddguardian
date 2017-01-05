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

Module InterfaceTranslation

    Public Sub LoadDefaultTranslation()
        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmldoc.LoadXml(My.Resources.default_interface)
        m_nodelist = m_xmldoc.SelectNodes("/interface/group")

        For Each m_node In m_nodelist
            Dim id As String = m_node.Attributes.GetNamedItem("id").Value
            Dim title As String = m_node.Attributes.GetNamedItem("title").Value

            With MainTranslationTool.lvwTranslation
                .Groups.Add(id, title)
                .Groups(.Groups.Count - 1).Tag = id

                Dim s_node As XmlNode

                For Each s_node In m_node.ChildNodes
                    If Not IsNothing(s_node) And s_node.NodeType <> XmlNodeType.Comment Then
                        .Items.Add(s_node.Attributes.GetNamedItem("text").Value)
                        .Items(.Items.Count - 1).Tag = s_node.Attributes.GetNamedItem("id").Value
                        .Items(.Items.Count - 1).Group = .Groups(id)
                        .Items(.Items.Count - 1).SubItems.Add("")
                    End If
                Next
            End With
        Next

        With MainTranslationTool
            .chDefaultCulture.Width = .lvwTranslation.ClientRectangle.Width / 2
            .chNewCulture.Width = .lvwTranslation.ClientRectangle.Width / 2
            With .lvwTranslation
                .Items(0).Selected = True

                For i As Short = 0 To .Items.Count - 1
                    .Items(i).ForeColor = Color.Red
                Next
            End With
        End With
    End Sub

    Public Sub SaveTranslation()
        If MainTranslationTool.isclosing Then Exit Sub

        Dim output As XmlWriterSettings = New XmlWriterSettings()
        output.Indent = True

        Dim folder As String = My.Application.Info.DirectoryPath & "\" & MainTranslationTool.cboCulture.SelectedItem.ToString & "\"
        If Not IO.Directory.Exists(folder) Then Exit Sub


        Using write As XmlWriter = XmlWriter.Create(folder & "interface.xml", output)
            ' Begin writing.
            write.WriteStartDocument()
            write.WriteStartElement("interface") 'root element
            'translation groups
            For g As Short = 0 To MainTranslationTool.lvwTranslation.Groups.Count - 1
                write.WriteStartElement("group")
                write.WriteAttributeString("id", MainTranslationTool.lvwTranslation.Groups(g).Tag)
                write.WriteAttributeString("title", MainTranslationTool.lvwTranslation.Groups(g).Header)
                'group strings
                For i As Short = 0 To MainTranslationTool.lvwTranslation.Groups(g).Items.Count - 1
                    write.WriteStartElement("string")
                    write.WriteAttributeString("id", MainTranslationTool.lvwTranslation.Groups(g).Items(i).Tag)
                    write.WriteAttributeString("text", MainTranslationTool.lvwTranslation.Groups(g).Items(i).SubItems(1).Text)
                    write.WriteEndElement()
                Next
                'end group
                write.WriteEndElement()
            Next

            'end of root element & write the document
            write.WriteEndElement()
            write.WriteEndDocument()
        End Using
    End Sub

    Public Sub SaveEmptyTranslation()
        If MainTranslationTool.isclosing Then Exit Sub

        Dim folder As String = My.Application.Info.DirectoryPath & "\" & MainTranslationTool.cboCulture.SelectedItem.ToString & "\"

        If Not IO.Directory.Exists(folder) Then
            IO.Directory.CreateDirectory(folder)

            Dim output As XmlWriterSettings = New XmlWriterSettings()
            output.Indent = True

            If Not IO.Directory.Exists(folder) Then Exit Sub

            Using write As XmlWriter = XmlWriter.Create(folder & "interface.xml", output)
                'begin writing
                write.WriteStartDocument()
                write.WriteStartElement("interface") 'root element
                'all groups
                With MainTranslationTool.lvwTranslation
                    For i As Short = 0 To .Groups.Count - 1
                        write.WriteStartElement("group")
                        write.WriteAttributeString("id", .Groups(i).Tag)
                        write.WriteAttributeString("text", .Groups(i).Header)
                        'an empty translation item
                        write.WriteStartElement("string")
                        write.WriteAttributeString("id", "")
                        write.WriteAttributeString("text", "")
                        write.WriteEndElement()
                        'end of group
                        write.WriteEndElement()
                    Next
                End With
                'end of root element & write the document
                write.WriteEndElement()
                write.WriteEndDocument()
            End Using
        End If
    End Sub

    Public Sub LoadTranslation()
        Dim folder As String = My.Application.Info.DirectoryPath & "\" & MainTranslationTool.cboCulture.SelectedItem.ToString & "\"

        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode


        m_xmldoc.Load(folder & "interface.xml")
        m_nodelist = m_xmldoc.SelectNodes("/interface/group")

        For Each m_node In m_nodelist
            Dim id As String = m_node.Attributes.GetNamedItem("id").Value
            Dim title As String = m_node.Attributes.GetNamedItem("title").Value

            With MainTranslationTool.lvwTranslation
                Dim s_node As XmlNode

                For Each s_node In m_node.ChildNodes
                    If Not IsNothing(s_node) And s_node.NodeType <> XmlNodeType.Comment Then
                        Dim txt_id As String = s_node.Attributes.GetNamedItem("id").Value
                        Dim txt As String = s_node.Attributes.GetNamedItem("text").Value

                        For g As Short = 0 To .Groups.Count - 1
                            If .Groups(g).Tag = id Then
                                For i As Short = 0 To .Groups(g).Items.Count - 1
                                    If .Groups(g).Items(i).Tag = txt_id Then
                                        .Groups(g).Items(i).SubItems(1).Text = txt
                                        If txt.Trim.Length > 0 Then .Groups(g).Items(i).ForeColor = Color.FromKnownColor(KnownColor.WindowText)
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End With
        Next
    End Sub

End Module
