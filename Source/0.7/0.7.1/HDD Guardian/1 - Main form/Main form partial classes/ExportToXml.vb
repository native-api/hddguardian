'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Xml

Partial Class Main

    Private Sub ExportToXml()
        Dim output As XmlWriterSettings = New XmlWriterSettings()
        output.Indent = True

        Dim folder As String = AppSettings.Sharing.XmlFolder
        If Not IO.Directory.Exists(folder) Then Exit Sub

        If isloading = False Then
            Using write As XmlWriter = XmlWriter.Create(folder & "\hddguardian.xml", output)
                'begin writing.
                write.WriteStartDocument()
                write.WriteStartElement("devices") 'root element
                'devices infos
                For i As Short = 0 To devlist.Count - 1
                    write.WriteStartElement("device")
                    write.WriteAttributeString("type", devlist(i).Type.ToString)
                    If devlist(i).Type = DeviceType.SCSI Then
                        write.WriteAttributeString("model", devlist(i).Scsi.Info.Product)
                    Else
                        write.WriteAttributeString("model", devlist(i).ATA.Info.Model)
                    End If
                    write.WriteAttributeString("temperature", devlist(i).Temperature)
                    If IsNumeric(devlist(i).Temperature) Then
                        write.WriteAttributeString("fahrenheit", Math.Round(devlist(i).Temperature * 1.8 + 32))
                    Else
                        write.WriteAttributeString("fahrenheit", devlist(i).Temperature)
                    End If
                    write.WriteAttributeString("overallhealth", devlist(i).Health.ToString)
                    write.WriteEndElement()
                Next
                'end of root element & write the document
                write.WriteEndElement()
                write.WriteEndDocument()
            End Using
        End If
    End Sub

End Class
