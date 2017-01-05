'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports Microsoft.Win32.TaskScheduler

Partial Class Main
    Dim ts As New TaskService

    Private Sub FixPath(ByVal t As Task)
        If Not IO.Directory.Exists(t.Path) Then
            Dim f As String = My.Application.Info.DirectoryPath & "\smartcl"

            If AppSettings.Smartctl.AlternativeVersion Then
                If IO.Directory.Exists(AppSettings.Smartctl.ExecutableFolder) Then
                    f = AppSettings.Smartctl.ExecutableFolder
                End If
            End If

            If t.Definition.Actions(0).ActionType = TaskActionType.Execute Then
                Dim ex As ExecAction = t.Definition.Actions(0)
                t.Definition.Actions.Clear()
                t.Definition.Actions.Add(New ExecAction(f & "\smartctl.exe", ex.Arguments))
            End If

            t.RegisterChanges()
        End If
    End Sub

    Public Sub TaskList()
        Dim _atEvery As String = GetString(6050)
        Dim _day As String = GetString(6051)
        Dim _days As String = GetString(6052)
        Dim _every As String = GetString(6053)
        Dim _week As String = GetString(6054)
        Dim _weeks As String = GetString(6055)

        'first, check and fix all existing tasks for wrong excutable path...
        For Each tasks As Task In ts.AllTasks
            If tasks.Name.StartsWith("smartctl") Then FixPath(tasks)
        Next

        'then, load all tasks in list...
        lvwTasks.Items.Clear()
        lvwTasks.SmallImageList = imlTask
        For Each tasks As Task In ts.AllTasks
            If tasks.Name.StartsWith("smartctl") Then
                Dim d As TaskDefinition = tasks.Definition
                Dim tc As TriggerCollection = d.Triggers
                Dim li As New ListViewItem
                Dim p, args As String

                li.Text = tasks.Name.Replace("smartctl", "").Replace("short", "").Replace("long", "").Replace("_", "/")
                li.Tag = tasks.Name
                li.ImageIndex = 0

                If d.Actions(0).ActionType = TaskActionType.Execute Then
                    Dim ex As ExecAction = d.Actions(0)

                    p = ex.Path
                    args = ex.Arguments
                    If args.Contains("short") Then
                        li.SubItems.Add(GetString(6021))
                        li.SubItems(1).Tag = "short"
                    Else
                        li.SubItems.Add(GetString(6022))
                        li.SubItems(1).Tag = "long"
                    End If
                End If

                Dim plan As String = ""
                Select Case d.Triggers(0).TriggerType
                    Case TaskTriggerType.Daily
                        Dim dt As DailyTrigger = d.Triggers(0)
                        plan += _atEvery.Replace("%", dt.StartBoundary.Hour & ":" & dt.StartBoundary.Minute.ToString("00"))
                        If dt.DaysInterval > 1 Then
                            plan += " " & dt.DaysInterval & " " & _days
                        Else
                            plan += " " & _day
                        End If
                    Case TaskTriggerType.Weekly
                        Dim wt As WeeklyTrigger = d.Triggers(0)
                        plan += _atEvery.Replace("%", wt.StartBoundary.Hour & ":" & wt.StartBoundary.Minute.ToString("00")) & " "
                        If wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Monday) Then plan += WeekdayName(1) & ", "
                        If wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Tuesday) Then plan += WeekdayName(2) & ", "
                        If wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Wednesday) Then plan += WeekdayName(3) & ", "
                        If wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Thursday) Then plan += WeekdayName(4) & ", "
                        If wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Friday) Then plan += WeekdayName(5) & ", "
                        If wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Saturday) Then plan += WeekdayName(6) & ", "
                        If wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Sunday) Then plan += WeekdayName(7) & ", "

                        plan = plan.Substring(0, plan.Length - 2)

                        If wt.WeeksInterval > 1 Then
                            plan += " " & _every & " " & wt.WeeksInterval & " " & _weeks
                        Else
                            plan += " " & _every & " " & _week
                        End If
                End Select
                li.SubItems.Add(plan)
                lvwTasks.Items.Add(li)
            End If
        Next
        lvwTasks.Columns(0).Width = 100
        lvwTasks.Columns(1).Width = 100
        lvwTasks.Columns(2).Width = 350

        If lvwTasks.Items.Count > 0 Then
            lvwTasks.Items(0).Selected = True
            mrbTaskEdit.Enabled = True
            mrbTaskDelete.Enabled = True
            mrbTaskTrash.Enabled = True
            mnuTaskEdit.Enabled = True
            mnuTaskDelete.Enabled = True
            mnuTaskTrash.Enabled = True
        Else
            mrbTaskEdit.Enabled = False
            mrbTaskDelete.Enabled = False
            mrbTaskTrash.Enabled = False
            mnuTaskEdit.Enabled = False
            mnuTaskDelete.Enabled = False
            mnuTaskTrash.Enabled = False
        End If
    End Sub

    Private Sub DeleteAllTasks()
        For Each tasks As Task In ts.AllTasks
            If tasks.Name.StartsWith("smartctl") Then ts.RootFolder.DeleteTask(tasks.Name)
        Next

        mrbTaskEdit.Enabled = False
        mrbTaskDelete.Enabled = False
        mrbTaskTrash.Enabled = False
        mnuTaskEdit.Enabled = False
        mnuTaskDelete.Enabled = False
        mnuTaskTrash.Enabled = False
    End Sub

End Class
