'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2016 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Xml
Partial Class Main
    Sub CheckForUpdates()
        'this sub check for HDD Guardian new versions...

        If AppSettings.General.CheckForUpdates = True Then
            Try
                Dim version As String
                Dim sr As IO.StreamReader
                Dim wc As New Net.WebClient()

                sr = New IO.StreamReader(wc.OpenRead("https://hddguardian.svn.codeplex.com/svn/version.txt"))

                version = sr.ReadToEnd

                Dim last() As String = version.Split(".")
                Dim curr() As String = My.Application.Info.Version.ToString.Split(".")
                Dim diff As Short = (last(0) * 1000 + last(1) * 100 + last(2) * 10) - _
                                    (curr(0) * 1000 + curr(1) * 100 + curr(2) * 10)
                If diff <= 0 Then
                    picNewVersion.Visible = False
                Else
                    picNewVersion.Visible = True
                    ttMain.SetToolTip(picNewVersion, picNewVersion.Tag.ToString.Remove("%", version))
                End If
            Catch
            End Try
        End If
    End Sub

    Public Class Cultures
        Inherits List(Of Culture)
    End Class

    Public Structure Culture
        Dim CultureId, Version As String
    End Structure

    Sub LanguagesUpdate()
        'get the list of available cultures; note that the built-in english are never updated...
        'PrintDebug("Entering language update routine")
        Dim culturelist As New Cultures
        Try
            Dim xmlculture As New XmlDocument
            Dim culturenodes As XmlNodeList

            xmlculture.Load("https://hddguardian.svn.codeplex.com/svn/languages/cultures.xml")
            culturenodes = xmlculture.SelectNodes("/cultures")

            With culturelist
                .Clear()
                For Each n As XmlNode In culturenodes
                    For i As Short = 0 To n.ChildNodes.Count - 1
                        If n.ChildNodes(i).Name <> "#comment" Then
                            Dim c As Culture
                            c.CultureId = n.ChildNodes(i).Attributes.GetNamedItem("name").Value
                            c.Version = n.ChildNodes(i).Attributes.GetNamedItem("version").Value
                            .Add(c)
                        End If
                    Next
                Next
            End With
        Catch ex As Exception
            'in case of errors: probably the internet connection is not available...
            'PrintDebug("Error occurred while checking languages versions")
            Exit Sub
        End Try

        'If IsNothing(culturelist) Then PrintDebug("Culture list is empty!")

        If Not IsNothing(culturelist) Then
            'PrintDebug("Culture list count: " & culturelist.Count)
            Dim curculture As String = My.Computer.Info.InstalledUICulture.Name 'it gets, by example, "es-AR"
            Dim languagesfolder As String = My.Application.Info.DirectoryPath & "\languages\"
            Dim cult() As String = curculture.Split("-")

            'try to detect if a non existing translation is now available
            'PrintDebug("Exist folder '" & languagesfolder & curculture & "'? " & IO.Directory.Exists(languagesfolder & curculture))
            'PrintDebug("Exist folder '" & languagesfolder & cult(0) & "'? " & IO.Directory.Exists(languagesfolder & cult(0)))

            If Not IO.Directory.Exists(languagesfolder & curculture) And Not IO.Directory.Exists(languagesfolder & cult(0)) Then
                'PrintDebug("New translation available for current culture UI")
                For i As Short = 0 To culturelist.Count - 1
                    If culturelist(i).CultureId = curculture Or culturelist(i).CultureId = cult(0) Then
                        'download files
                        'translation info
                        My.Computer.Network.DownloadFile("https://hddguardian.svn.codeplex.com/svn/languages/" & culturelist(i).CultureId & "/info.xml", _
                                                        languagesfolder & culturelist(i).CultureId & "_temp\info.xml", "", "", False, 2000, True)
                        'interface translation
                        My.Computer.Network.DownloadFile("https://hddguardian.svn.codeplex.com/svn/languages/" & culturelist(i).CultureId & "/interface.xml", _
                                                        languagesfolder & culturelist(i).CultureId & "_temp\interface.xml", "", "", False, 2000, True)
                        'attributes meaning
                        My.Computer.Network.DownloadFile("https://hddguardian.svn.codeplex.com/svn/languages/" & culturelist(i).CultureId & "/attributes.xml", _
                                                        languagesfolder & culturelist(i).CultureId & "_temp\attributes.xml", "", "", False, 2000, True)
                        'check if files are downloaded correctly...
                        Dim fi As IO.FileInfo
                        Dim ok As Short = 0
                        fi = My.Computer.FileSystem.GetFileInfo(languagesfolder & culturelist(i).CultureId & "_temp\info.xml")
                        If fi.Length > 0 Then ok += 1
                        fi = My.Computer.FileSystem.GetFileInfo(languagesfolder & culturelist(i).CultureId & "_temp\interface.xml")
                        If fi.Length > 0 Then ok += 1
                        fi = My.Computer.FileSystem.GetFileInfo(languagesfolder & culturelist(i).CultureId & "_temp\attributes.xml")
                        If fi.Length > 0 Then ok += 1
                        If ok = 3 Then
                            My.Computer.FileSystem.RenameDirectory(languagesfolder & culturelist(i).CultureId & "_temp", culturelist(i).CultureId)
                            'the current culture is downloaded and applyed!
                            If AppSettings.Language.AutomaticTranslation Then ChangeLanguage()
                        Else
                            My.Computer.FileSystem.DeleteDirectory(languagesfolder & culturelist(i).CultureId & "_temp", FileIO.DeleteDirectoryOption.DeleteAllContents)
                        End If
                        
                        Exit For
                    End If
                Next
                Exit Sub
            End If

            'try to apply the current selected translation (except the built-in english)
            If AppSettings.Language.AutomaticTranslation And Not curculture.Contains("en") Then
                'PrintDebug("Try to update current culture translation...")
                Try
                    'get version of remote file
                    Dim nv() As String = Nothing
                    Dim c_id As String = ""
                    For i As Short = 0 To culturelist.Count - 1
                        If curculture.Contains(culturelist(i).CultureId) Then
                            nv = culturelist(i).Version.ToString.Split(".")
                            c_id = culturelist(i).CultureId
                            Exit For
                        End If
                    Next
                    'PrintDebug("Last version: " & nv(0) & "." & nv(1) & "." & nv(2))


                    If Not IsNothing(nv) Then
                        'get version of installed file
                        Dim cv() As String = Nothing
                        For i As Short = 0 To translations.Count - 1
                            If curculture.Contains(translations(i).CultureCode) Then
                                cv = translations(i).Version.Split(".")
                                Exit For
                            End If
                        Next
                        'PrintDebug("Bundled version: " & cv(0) & "." & cv(1) & "." & cv(2))

                        'calculate the difference between the two versions...
                        Dim diff As Integer = (nv(0) * 10000 + nv(1) * 1000 + nv(2)) - _
                                              (cv(0) * 10000 + cv(1) * 1000 + cv(2))

                        If diff > 0 Then
                            'PrintDebug("Downloading new version")
                            'download files in the new folder
                            'translation info

                            My.Computer.Network.DownloadFile("https://hddguardian.svn.codeplex.com/svn/languages/" & c_id & "/info.xml", _
                                                            languagesfolder & c_id & "_temp\info.xml", "", "", False, 2000, True)
                            'interface translation
                            My.Computer.Network.DownloadFile("https://hddguardian.svn.codeplex.com/svn/languages/" & c_id & "/interface.xml", _
                                                            languagesfolder & c_id & "_temp\interface.xml", "", "", False, 2000, True)
                            'attributes meaning
                            My.Computer.Network.DownloadFile("https://hddguardian.svn.codeplex.com/svn/languages/" & c_id & "/attributes.xml", _
                                                            languagesfolder & c_id & "_temp\attributes.xml", "", "", False, 2000, True)
                            'move files if size is > 0
                            Dim fi As IO.FileInfo
                            fi = My.Computer.FileSystem.GetFileInfo(languagesfolder & c_id & "_temp\info.xml")
                            If fi.Length > 0 Then My.Computer.FileSystem.MoveFile(languagesfolder & c_id & "_temp\info.xml", languagesfolder & c_id & "\info.xml", True)
                            fi = My.Computer.FileSystem.GetFileInfo(languagesfolder & c_id & "_temp\interface.xml")
                            If fi.Length > 0 Then My.Computer.FileSystem.MoveFile(languagesfolder & c_id & "_temp\interface.xml", languagesfolder & c_id & "\interface.xml", True)
                            fi = My.Computer.FileSystem.GetFileInfo(languagesfolder & c_id & "_temp\attributes.xml")
                            If fi.Length > 0 Then My.Computer.FileSystem.MoveFile(languagesfolder & c_id & "_temp\attributes.xml", languagesfolder & c_id & "\attributes.xml", True)
                            My.Computer.FileSystem.DeleteDirectory(languagesfolder & c_id & "_temp", FileIO.DeleteDirectoryOption.DeleteAllContents)
                            'reload language
                            ChangeLanguage()
                        End If
                    End If
                Catch ex As Exception
                    'PrintDebug("Error occurred while downloading new language version")
                End Try
            End If
        End If
    End Sub

End Class
