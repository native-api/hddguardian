'HDD Guardian is a GUI for smartcl utility, part of smartmontools
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

Partial Class Main

    Dim m_attributesmeanings As New AttrMeanings
    Dim m_MicronMeanings As New MicronMeanings
    Dim m_IntelMeanings As New IntelMeanings
    Dim m_IndilinxMeanings As New IndilinxMeanings
    Dim m_JMicronMeanings As New JmicronMeanings
    Dim m_SamsungMeanings As New SamsungMeanings
    Dim m_SandForceMeanings As New SandForceMeanings
    Dim m_SmartMeanings As New SmartMeanings
    Dim m_SanDiskMeanings As New SanDiskMeanings
    Dim m_AdtronMeanings As New AdtronMeanings

#Region "Private meanings classes"
    Private Class AttrMeanings
        Inherits List(Of AttrTable)
    End Class

    Private Class MicronMeanings
        Inherits List(Of AttrTable)
    End Class

    Private Class IntelMeanings
        Inherits List(Of AttrTable)
    End Class

    Private Class IndilinxMeanings
        Inherits List(Of AttrTable)
    End Class

    Private Class JmicronMeanings
        Inherits List(Of AttrTable)
    End Class

    Private Class SamsungMeanings
        Inherits List(Of AttrTable)
    End Class

    Private Class SandForceMeanings
        Inherits List(Of AttrTable)
    End Class

    Private Class SmartMeanings
        Inherits List(Of AttrTable)
    End Class

    Private Class SanDiskMeanings
        Inherits List(Of AttrTable)
    End Class

    Private Class AdtronMeanings
        Inherits List(Of AttrTable)
    End Class
#End Region

    Private Structure AttrTable
        Dim SmartctlName, Name, Description As String
    End Structure

    Public Sub LoadAttribInfos()
        Dim curculture As String = My.Computer.Info.InstalledUICulture.Name 'it gets, by example, "es-AR"
        Dim languagesfolder As String = My.Application.Info.DirectoryPath & "\languages\"
        Dim cult() As String = curculture.Split("-")
        Dim curculturefolder0 As String = languagesfolder & curculture
        Dim curculturefolder1 As String = languagesfolder & cult(0)
        Dim m_external As Boolean = False

        Dim m_xmldoc As New XmlDocument
        Dim e_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        'load internal (english) attributes meanings
        m_xmldoc.LoadXml(My.Resources.dafault_attributes)
        m_nodelist = m_xmldoc.SelectNodes("/table/attribute")

        m_attributesmeanings.Clear()
        m_MicronMeanings.Clear()
        m_IntelMeanings.Clear()
        m_IndilinxMeanings.Clear()
        m_JMicronMeanings.Clear()
        m_SamsungMeanings.Clear()
        m_SandForceMeanings.Clear()
        m_SmartMeanings.Clear()
        m_SanDiskMeanings.Clear()
        m_AdtronMeanings.Clear()

        For Each m_node In m_nodelist
            Dim group As String = m_node.Attributes.GetNamedItem("group").Value
            Dim smartctlname As String = m_node.Attributes.GetNamedItem("smartctl").Value
            Dim attr As New AttrTable

            If smartctlname.Length > 0 Then
                attr.SmartctlName = smartctlname.Replace("_", " ")
                attr.Name = m_node.ChildNodes.Item(0).InnerText
                attr.Description = m_node.ChildNodes.Item(1).InnerText.Replace(vbCrLf, "").Trim
            End If

            'separate meanings by group, for a faster vendor-based meaning search...
            Select Case group
                Case Is = "Generic"
                    m_attributesmeanings.Add(attr)
                Case Is = "Micron"
                    m_MicronMeanings.Add(attr)
                Case Is = "Intel"
                    m_IntelMeanings.Add(attr)
                Case Is = "Indilinx"
                    m_IndilinxMeanings.Add(attr)
                Case Is = "JMicron"
                    m_JMicronMeanings.Add(attr)
                Case Is = "Samsung"
                    m_SamsungMeanings.Add(attr)
                Case Is = "SandForce"
                    m_SandForceMeanings.Add(attr)
                Case Is = "Smart"
                    m_SmartMeanings.Add(attr)
                Case Is = "SanDisk"
                    m_SanDiskMeanings.Add(attr)
                Case Is = "Adtron"
                    m_AdtronMeanings.Add(attr)
            End Select
        Next

        If My.Settings.AutomaticTranslation Then
            'search if exists an external translation for current culture, following, for sample, culture "es-AR"
            If FileIO.FileSystem.DirectoryExists(curculturefolder0) Then 'check if subfolder named "es-AR" exists
                If IO.File.Exists(curculturefolder0 & "\attributes.xml") Then
                    e_xmldoc.Load(curculturefolder0 & "\attributes.xml")
                    m_external = True
                End If
            ElseIf FileIO.FileSystem.DirectoryExists(curculturefolder1) Then 'check if subfolder named "es" exists
                If IO.File.Exists(curculturefolder1 & "\attributes.xml") Then
                    e_xmldoc.Load(curculturefolder1 & "\attributes.xml")
                    m_external = True
                End If
            End If
        Else
            If FileIO.FileSystem.DirectoryExists(languagesfolder & My.Settings.Language) Then
                If IO.File.Exists(languagesfolder & My.Settings.Language & "\attributes.xml") Then
                    e_xmldoc.Load(languagesfolder & My.Settings.Language & "\attributes.xml")
                    m_external = True
                End If
            End If
        End If

        'replace translation strings that exists into the external translation:
        'if external translation is incomplete, are used the strings into the internal translation
        If m_external Then
            Try
                m_nodelist = e_xmldoc.SelectNodes("/table/attribute")

                For Each m_node In m_nodelist
                    Dim group As String = m_node.Attributes.GetNamedItem("group").Value
                    Dim smartctlname As String = m_node.Attributes.GetNamedItem("smartctl").Value.Replace("_", " ")
                    Dim attr As New AttrTable

                    attr.SmartctlName = smartctlname
                    attr.Name = m_node.ChildNodes.Item(0).InnerText
                    attr.Description = m_node.ChildNodes.Item(1).InnerText.Replace(vbCrLf, "").Trim

                    If smartctlname.Length > 0 Then
                        Select Case group
                            Case Is = "Generic"
                                For i As Short = 0 To m_attributesmeanings.Count - 1
                                    If m_attributesmeanings(i).SmartctlName = smartctlname Then
                                        m_attributesmeanings.RemoveAt(i)
                                        m_attributesmeanings.Add(attr)
                                        Exit For
                                    End If
                                Next
                            Case Is = "Micron"
                                For i As Short = 0 To m_MicronMeanings.Count - 1
                                    If m_MicronMeanings(i).SmartctlName = smartctlname Then
                                        m_MicronMeanings.RemoveAt(i)
                                        m_MicronMeanings.Add(attr)
                                        Exit For
                                    End If
                                Next
                            Case Is = "Intel"
                                For i As Short = 0 To m_IntelMeanings.Count - 1
                                    If m_IntelMeanings(i).SmartctlName = smartctlname Then
                                        m_IntelMeanings.RemoveAt(i)
                                        m_IntelMeanings.Add(attr)
                                        Exit For
                                    End If
                                Next
                            Case Is = "Indilinx"
                                For i As Short = 0 To m_IndilinxMeanings.Count - 1
                                    If m_IndilinxMeanings(i).SmartctlName = smartctlname Then
                                        m_IndilinxMeanings.RemoveAt(i)
                                        m_IndilinxMeanings.Add(attr)
                                        Exit For
                                    End If
                                Next
                            Case Is = "JMicron"
                                For i As Short = 0 To m_JMicronMeanings.Count - 1
                                    If m_JMicronMeanings(i).SmartctlName = smartctlname Then
                                        m_JMicronMeanings.RemoveAt(i)
                                        m_JMicronMeanings.Add(attr)
                                        Exit For
                                    End If
                                Next
                            Case Is = "Samsung"
                                For i As Short = 0 To m_SamsungMeanings.Count - 1
                                    If m_SamsungMeanings(i).SmartctlName = smartctlname Then
                                        m_SamsungMeanings.RemoveAt(i)
                                        m_SamsungMeanings.Add(attr)
                                        Exit For
                                    End If
                                Next
                            Case Is = "SandForce"
                                For i As Short = 0 To m_SandForceMeanings.Count - 1
                                    If m_SandForceMeanings(i).SmartctlName = smartctlname Then
                                        m_SandForceMeanings.RemoveAt(i)
                                        m_SandForceMeanings.Add(attr)
                                        Exit For
                                    End If
                                Next
                            Case Is = "Smart"
                                For i As Short = 0 To m_SmartMeanings.Count - 1
                                    If m_SmartMeanings(i).SmartctlName = smartctlname Then
                                        m_SmartMeanings.RemoveAt(i)
                                        m_SmartMeanings.Add(attr)
                                        Exit For
                                    End If
                                Next
                            Case Is = "SanDisk"
                                For i As Short = 0 To m_SanDiskMeanings.Count - 1
                                    If m_SanDiskMeanings(i).SmartctlName = smartctlname Then
                                        m_SanDiskMeanings.RemoveAt(i)
                                        m_SanDiskMeanings.Add(attr)
                                        Exit For
                                    End If
                                Next
                            Case Is = "Adtron"
                                For i As Short = 0 To m_AdtronMeanings.Count - 1
                                    If m_AdtronMeanings(i).SmartctlName = smartctlname Then
                                        m_AdtronMeanings.RemoveAt(i)
                                        m_AdtronMeanings.Add(attr)
                                        Exit For
                                    End If
                                Next
                        End Select
                    End If
                Next
            Catch
            End Try
        End If
    End Sub

End Class
