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

Partial Public Class TaskEditor
    Dim ts As New TaskService
    Public EditMode = False
    Dim _devList As New List(Of TaskDevice)

    Structure TaskDevice
        Dim Name, [Long], [Short] As String
    End Structure

    Private Sub GetTask()
        For Each tasks As Task In ts.AllTasks
            If tasks.Name = Main.lvwTasks.SelectedItems(0).Tag Then
                Dim d As TaskDefinition = tasks.Definition
                Dim tc As TriggerCollection = d.Triggers

                If d.Actions(0).ActionType = TaskActionType.Execute Then
                    Dim ex As ExecAction = d.Actions(0)
                    If ex.Arguments.Contains("short") Then
                        cboTest.SelectedIndex = 0
                    Else
                        cboTest.SelectedIndex = 1
                    End If
                End If

                Select Case d.Triggers(0).TriggerType
                    Case TaskTriggerType.Daily
                        Dim dt As DailyTrigger = d.Triggers(0)
                        cboType.SelectedIndex = 0
                        numSpan.Value = dt.DaysInterval
                        dtTime.Value = dt.StartBoundary
                    Case TaskTriggerType.Weekly
                        Dim wt As WeeklyTrigger = d.Triggers(0)
                        cboType.SelectedIndex = 1
                        numSpan.Value = wt.WeeksInterval
                        chkDay0.Checked = wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Monday)
                        chkDay1.Checked = wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Tuesday)
                        chkDay2.Checked = wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Wednesday)
                        chkDay3.Checked = wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Thursday)
                        chkDay4.Checked = wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Friday)
                        chkDay5.Checked = wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Saturday)
                        chkDay6.Checked = wt.DaysOfWeek.HasFlag(DaysOfTheWeek.Sunday)
                        dtTime.Value = wt.StartBoundary
                End Select
            End If
        Next
    End Sub

    Private Sub TaskEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDevice.Text = Main.GetString(6010)
        lblTest.Text = Main.GetString(6020)
        lblType.Text = Main.GetString(6024)
        lblTestDuration.Tag = Main.GetString(6023)
        lblTime.Text = Main.GetString(6030)
        lblSpan.Text = Main.GetString(6027)
        lblSpanType.Text = Main.GetString(6028)

        dtTime.Format = DateTimePickerFormat.Custom

        cboDevice.Items.Clear()
        For i As Short = 0 To Main.devlist.Count - 1
            If Not Main.devlist(i).IsVirtual Then
                If Main.devlist(i).Type = DeviceType.ATA Or Main.devlist(i).Type = DeviceType.USB Then
                    cboDevice.Items.Add(Main.devlist(i).Location)

                    Dim d As New TaskDevice
                    d.Name = Main.devlist(i).Location
                    d.Long = Main.devlist(i).ATA.Test.PollingTimes.Extended
                    d.Short = Main.devlist(i).ATA.Test.PollingTimes.Short

                    _devList.Add(d)
                End If
            End If
        Next
        cboDevice.SelectedIndex = 0

        cboTest.Items.Clear()
        cboTest.Items.Add(Main.GetString(6021))
        cboTest.Items.Add(Main.GetString(6022))
        cboTest.SelectedIndex = 0

        lblTestDuration.Text = lblTestDuration.Tag & ": " & _devList(0).Short

        cboType.Items.Clear()
        cboType.Items.Add(Main.GetString(6025))
        cboType.Items.Add(Main.GetString(6026))
        cboType.SelectedIndex = 0

        chkDay0.Text = FirstUpper(WeekdayName(1))
        chkDay1.Text = FirstUpper(WeekdayName(2))
        chkDay2.Text = FirstUpper(WeekdayName(3))
        chkDay3.Text = FirstUpper(WeekdayName(4))
        chkDay4.Text = FirstUpper(WeekdayName(5))
        chkDay5.Text = FirstUpper(WeekdayName(6))
        chkDay6.Text = FirstUpper(WeekdayName(7))

        btnSet.Text = Main.GetString(6040)
        btnCancel.Text = Main.GetString(6041)

        If EditMode Then
            For i As Short = 0 To _devList.Count - 1
                If _devList(i).Name = Main.lvwTasks.SelectedItems(0).Text Then
                    cboDevice.SelectedIndex = i
                    Exit For
                End If
            Next
            GetTask()
        End If

    End Sub

    Public Function FirstUpper(ByVal text As String) As String
        Dim f As String = text.Substring(0, 1).ToUpper
        Dim r As String = text.Substring(1, text.Length - 1).ToLower
        Return f & r
    End Function

    Private Sub cboDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDevice.SelectedIndexChanged
        cboTest_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub cboTest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTest.SelectedIndexChanged
        If cboTest.SelectedIndex = 0 Then
            lblTestDuration.Text = lblTestDuration.Tag & ": " & _devList(cboDevice.SelectedIndex).Short
        Else
            lblTestDuration.Text = lblTestDuration.Tag & ": " & _devList(cboDevice.SelectedIndex).Long
        End If
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        If cboType.SelectedIndex = 0 Then
            tlpDays.Enabled = False
            For Each c In tlpDays.Controls
                c.checked = True
            Next
            lblSpanType.Text = Main.GetString(6028)
        Else
            tlpDays.Enabled = True
            lblSpanType.Text = Main.GetString(6029)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        Dim td As TaskDefinition = ts.NewTask
        td.RegistrationInfo.Author = "HDD Guardian"
        Dim taskName As String = ""

        With td
            If cboTest.SelectedIndex = 0 Then
                .RegistrationInfo.Description = "Run a SMART short test on device " & cboDevice.SelectedItem.ToString
                .Actions.Add(New ExecAction(My.Application.Info.DirectoryPath & "\smartctl\smartctl.exe", "-t short " & cboDevice.SelectedItem.ToString))
                taskName = "smartctl_short" & cboDevice.SelectedItem.ToString.Replace("/", "_")
            Else
                .RegistrationInfo.Description = "Run a SMART extended test on device " & cboDevice.SelectedItem.ToString
                .Actions.Add(New ExecAction(My.Application.Info.DirectoryPath & "\smartctl\smartctl.exe", "-t long " & cboDevice.SelectedItem.ToString))
                taskName = "smartctl_long" & cboDevice.SelectedItem.ToString.Replace("/", "_")
            End If

            If cboType.SelectedIndex = 0 Then
                Dim dt As New DailyTrigger
                dt.DaysInterval = numSpan.Value
                Dim t() As String = dtTime.Text.Split(":")
                dt.StartBoundary = New Date(Now.Year, Now.Month, Now.Day, Val(t(0)), Val(t(1)), 0)
                .Triggers.Add(dt)
            Else
                Dim wt As New WeeklyTrigger
                wt.DaysOfWeek = Nothing
                If chkDay0.Checked Then wt.DaysOfWeek += DaysOfTheWeek.Monday
                If chkDay1.Checked Then wt.DaysOfWeek += DaysOfTheWeek.Tuesday
                If chkDay2.Checked Then wt.DaysOfWeek += DaysOfTheWeek.Wednesday
                If chkDay3.Checked Then wt.DaysOfWeek += DaysOfTheWeek.Thursday
                If chkDay4.Checked Then wt.DaysOfWeek += DaysOfTheWeek.Friday
                If chkDay5.Checked Then wt.DaysOfWeek += DaysOfTheWeek.Saturday
                If chkDay6.Checked Then wt.DaysOfWeek += DaysOfTheWeek.Sunday
                wt.WeeksInterval = numSpan.Value
                Dim t() As String = dtTime.Text.Split(":")
                wt.StartBoundary = New Date(Now.Year, Now.Month, Now.Day, Val(t(0)), Val(t(1)), 0)
                .Triggers.Add(wt)
            End If

            .Principal.RunLevel = TaskRunLevel.Highest
        End With

        ts.RootFolder.RegisterTaskDefinition(taskName, td)

        Main.TaskList()
        Me.Close()
    End Sub
End Class