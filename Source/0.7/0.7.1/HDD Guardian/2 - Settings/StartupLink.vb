'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

'add a reference to "Windows Script Host Object Model"
'menu project-> add reference-> tab COM

Imports IWshRuntimeLibrary
Imports System

Partial Class SettingsForm

    Private appName As String = My.Application.Info.AssemblyName & ".exe"
    Private startupFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)

    Public Sub CreateShortcut()
        Dim appPath As String = My.Application.Info.DirectoryPath
        Dim Wshell As New WshShell
        Dim SC As WshShortcut

        'here indicates the location where create startup shortcut
        SC = Wshell.CreateShortcut(startupFolder & "\" & "HDD Guardian.lnk")
        'here indicates where link points
        SC.TargetPath = appPath & "\" & appName
        'and here save the shortcut... that's all!
        SC.Save()
    End Sub

    Public Function ShortcutExists() As Boolean
        'return if shortcut file exists or not...
        If IO.File.Exists(startupFolder & "\" & "HDD Guardian.lnk") Then
            Dim shell As New WshShell()
            Dim lnk As IWshShortcut = DirectCast(shell.CreateShortcut(startupFolder & "\HDD Guardian.lnk"), IWshShortcut)

            If lnk.TargetPath <> My.Application.Info.DirectoryPath & "\" & appName Then CreateShortcut()
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub DeleteShortcut()
        'delete the shortcut, if exists...
        If IO.File.Exists(startupFolder & "\" & "HDD Guardian.lnk") Then
            IO.File.Delete(startupFolder & "\" & "HDD Guardian.lnk")
        End If
    End Sub
End Class
