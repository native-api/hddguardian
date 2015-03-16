'Translation Tool is the HDD Guardian translation utility
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2015 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Xml

Module TranslatorInfo

    Public Sub LoadTranslatorInfo()
        Dim folder As String = My.Application.Info.DirectoryPath & "\" & MainTranslationTool.cboCulture.SelectedItem.ToString & "\"

        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        'Dim m_node As XmlNode


        m_xmldoc.Load(folder & "info.xml")

        m_nodelist = m_xmldoc.SelectNodes("/info")

        MainTranslationTool.txtLanguage.Text = m_nodelist(0).ChildNodes(0).InnerText
        MainTranslationTool.txtTranslator.Text = m_nodelist(0).ChildNodes(1).InnerText

        Dim v() As String = m_nodelist(0).ChildNodes(2).InnerText.Split(".")

        Select Case v.Count
            Case 1
                MainTranslationTool.txtMajor.Text = v(0)
                MainTranslationTool.txtMinor.Text = "0"
                MainTranslationTool.txtRevision.Text = "0"
            Case 2
                MainTranslationTool.txtMajor.Text = v(0)
                MainTranslationTool.txtMinor.Text = "0"
                MainTranslationTool.txtRevision.Text = "0"
            Case 3
                MainTranslationTool.txtMajor.Text = v(0)
                MainTranslationTool.txtMinor.Text = v(1)
                MainTranslationTool.txtRevision.Text = v(2)
        End Select

    End Sub

    Public Sub SaveTranslatorInfo()
        If MainTranslationTool.isclosing Then Exit Sub

        Dim output As XmlWriterSettings = New XmlWriterSettings()
        output.Indent = True

        Dim folder As String = My.Application.Info.DirectoryPath & "\" & MainTranslationTool.cboCulture.SelectedItem.ToString & "\"
        If Not IO.Directory.Exists(folder) Then Exit Sub


        Using write As XmlWriter = XmlWriter.Create(folder & "info.xml", output)
            ' Begin writing.
            write.WriteStartDocument()
            write.WriteStartElement("info") 'root element

            'language
            write.WriteStartElement("language")
            write.WriteString(MainTranslationTool.txtLanguage.Text)
            write.WriteEndElement()

            'translator
            write.WriteStartElement("translator")
            write.WriteString(MainTranslationTool.txtTranslator.Text)
            write.WriteEndElement()

            'version
            write.WriteStartElement("version")
            write.WriteString(MainTranslationTool.txtMajor.Text & "." & MainTranslationTool.txtMinor.Text & "." & MainTranslationTool.txtRevision.Text)
            write.WriteEndElement()

            'end of root element & write the document
            write.WriteEndElement()
            write.WriteEndDocument()
        End Using

    End Sub

End Module
