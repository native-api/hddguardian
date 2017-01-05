'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

'add a reference to "Microsoft.Win32.TaskScheduler.dll"

Imports Microsoft.Win32.TaskScheduler

Partial Class SettingsForm
    Dim ts As New TaskService

    Public Sub CreateTask()
        Dim td As TaskDefinition = ts.NewTask

        With td
            .RegistrationInfo.Description = "HDD Guardian"
            .Triggers.Add(New LogonTrigger)
            .Principal.RunLevel = TaskRunLevel.Highest
            .Actions.Add(New ExecAction(My.Application.Info.DirectoryPath & "\hddguardian.exe"))
        End With

        ts.RootFolder.RegisterTaskDefinition("HDD Guardian", td)
    End Sub

    Public Sub DeleteTask()
        ts.RootFolder.DeleteTask("HDD Guardian")
    End Sub

    Public Function TaskExist() As Boolean
        Dim t As Task = ts.FindTask("HDD Guardian")

        If Not IsNothing(t) Then
            Dim def As TaskDefinition = t.Definition

            For i As Short = 0 To def.Actions.Count
                If def.Actions(i).ActionType = TaskActionType.Execute Then
                    Dim at As ExecAction = def.Actions(i)

                    If at.Path = My.Application.Info.DirectoryPath & "\hddguardian.exe" Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Next

            Return False
        Else
            Return False
        End If
    End Function
End Class
