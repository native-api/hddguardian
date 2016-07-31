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

    Private Sub SetGraph(ByVal StartDate As Date, ByVal EndDate As Date)
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If Not IsNothing(dev.Log) Then
            With chrChart
                .Series(0).Points.Clear()
                .Series(0).MarkerSize = numPointSize.Value
                .Series(1).Points.Clear()

                For i As Short = 0 To dev.Log.Count - 1
                    If dev.Log.Item(i).Event = lvwEvents.SelectedItems(0).Text Then
                        Dim p As New DataVisualization.Charting.DataPoint

                        Dim y As String = dev.Log(i).Year
                        Dim m As String = String.Format("{0:D2}", Convert.ToInt16(dev.Log(i).Month))
                        Dim d As String = String.Format("{0:D2}", Convert.ToInt16(dev.Log(i).Day))
                        Dim t() As String = dev.Log(i).Hour.Split(":")

                        If New DateTime(y, m, d) <= EndDate And New DateTime(y, m, d) >= StartDate Then
                            Dim dt As New System.DateTime(y, m, d, t(0), t(1), t(2))

                            .Series(0).Points.AddXY(dt.ToOADate, Convert.ToDouble(dev.Log(i).NewValue.Replace("°C", "")))
                            If dev.Log.Item(i).Event = "Temperature" Then
                                Dim limit As Integer = 55
                                If dev.Type <> DeviceType.SCSI Then
                                    If IsNumeric(dev.ATA.Temperatures.RecommendedMax) Then
                                        limit = dev.ATA.Temperatures.RecommendedMax
                                    Else
                                        limit = 55
                                    End If
                                End If
                                .Series(1).Points.AddXY(dt.ToOADate, limit)
                                .Series(1).Points(0).Label = .Tag & " (" & limit & ")"
                            End If
                            If chkChartValues.Checked Then .Series(0).Points.Item(.Series(0).Points.Count - 1).Label = dev.Log(i).NewValue
                        End If
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub SetFullGraph()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If Not IsNothing(dev.Log) Then
            With chrChart
                .Series(0).Points.Clear()
                .Series(0).MarkerSize = numPointSize.Value
                .Series(1).Points.Clear()

                For i As Short = 0 To dev.Log.Count - 1
                    If dev.Log.Item(i).Event = lvwEvents.SelectedItems(0).Text Then
                        Dim p As New DataVisualization.Charting.DataPoint

                        Dim y As String = dev.Log(i).Year
                        Dim m As String = String.Format("{0:D2}", Convert.ToInt16(dev.Log(i).Month))
                        Dim d As String = String.Format("{0:D2}", Convert.ToInt16(dev.Log(i).Day))
                        Dim t() As String = dev.Log(i).Hour.Split(":")

                        Dim dt As New System.DateTime(y, m, d, t(0), t(1), t(2))
                        .Series(0).Points.AddXY(dt.ToOADate, Convert.ToDouble(dev.Log(i).NewValue.Replace("°C", "")))
                        If dev.Log.Item(i).Event = "Temperature" Then
                            Dim limit As Integer = 55
                            If dev.Type <> DeviceType.SCSI Then
                                If IsNumeric(dev.ATA.Temperatures.RecommendedMax) Then
                                    limit = dev.ATA.Temperatures.RecommendedMax
                                Else
                                    limit = 55
                                End If
                            End If
                            .Series(1).Points.AddXY(dt.ToOADate, limit)
                            .Series(1).Points(0).Label = .Tag & " (" & limit & ")"
                        End If
                        If chkChartValues.Checked Then .Series(0).Points.Item(.Series(0).Points.Count - 1).Label = dev.Log(i).NewValue
                    End If
                Next
            End With
        End If
    End Sub

    Public Sub DisplayEvents()
        lvwLog.Items.Clear()
        lvwLog.Groups.Clear()

        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If Not IsNothing(dev.Log) Then
            If dev.Log.Count > 0 Then
                With dev
                    For i As Integer = 0 To .Log.Count - 1
                        Dim celsius As String = ""
                        Dim ev As String = .Log(i).Event
                        If ev = "Temperature" Then celsius = "°C"
                        Dim y As String = dev.Log(i).Year
                        Dim m As String = String.Format("{0:D2}", Convert.ToInt16(dev.Log(i).Month))
                        Dim d As String = String.Format("{0:D2}", Convert.ToInt16(dev.Log(i).Day))
                        Dim t() As String = dev.Log(i).Hour.Split(":")
                        Dim h As String = String.Format("{0:D2}", Convert.ToInt16(t(0))) & ":" &
                                String.Format("{0:D2}", Convert.ToInt16(t(1))) & ":" &
                                String.Format("{0:D2}", Convert.ToInt16(t(2)))
                        Dim old As String = .Log(i).OldValue
                        Dim last As String = .Log(i).NewValue
                        Dim var As String = .Log(i).Variation

                        With lvwLog
                            .SmallImageList = imlLog
                            Dim timeofevent As String = ""
                            Dim dt As DateTime
                            If DateTime.TryParseExact(d & " " & m & " " & y & " " & h, "dd MM yyyy HH:mm:ss", Nothing, Nothing, dt) Then
                                timeofevent = FormatDateTime(dt, DateFormat.ShortDate) & ", " & FormatDateTime(dt, DateFormat.ShortTime)
                            End If

                            Dim toAdd As Boolean = True

                            If optSelection.Checked Then
                                If New DateTime(y, m, d) < mcLog.SelectionRange.Start Or
                                    New DateTime(y, m, d) > mcLog.SelectionRange.End Then toAdd = False
                            End If

                            If Not ev = lvwEvents.SelectedItems(0).Text Then toAdd = False

                            If Not IsNothing(.Groups) Then
                                Dim addGroup As Boolean = True
                                For g As Short = 0 To .Groups.Count - 1
                                    If .Groups(g).Header = New DateTime(y, m, d) Then addGroup = False
                                Next
                                If addGroup Then .Groups.Add(New DateTime(y, m, d), New DateTime(y, m, d))
                            Else
                                    .Groups.Add(New DateTime(y, m, d), New DateTime(y, m, d))
                            End If

                            If toAdd Then
                                Dim li As New ListViewItem(h, .Groups(.Groups.Count - 1))
                                '.Items.Add(timeofevent)
                                .Items.Add(li)
                                .Items(.Items.Count - 1).SubItems.Add(old & celsius)
                                .Items(.Items.Count - 1).SubItems.Add(last & celsius)
                                .Items(.Items.Count - 1).SubItems.Add(var & celsius)

                                If ev.ToLower = "remaining life (%)" _
                                    Or ev.ToLower = "remaining life percentage" _
                                    Or ev.ToLower = "media wearout indicator" _
                                    Or ev.ToLower = "wear leveling count" _
                                    Or ev.ToLower = "ssd life left" Then
                                    If Convert.ToDouble(Val(var)) < 0 Then
                                        .Items(.Items.Count - 1).ForeColor = Color.Red
                                        .Items(.Items.Count - 1).ImageKey = "warning"
                                    Else
                                        .Items(.Items.Count - 1).ForeColor = Color.DarkGreen
                                        .Items(.Items.Count - 1).ImageKey = "ok"
                                    End If
                                Else
                                    If Convert.ToDouble(Val(var)) > 0 Then
                                        .Items(.Items.Count - 1).ForeColor = Color.Red
                                        .Items(.Items.Count - 1).ImageKey = "warning"
                                    Else
                                        .Items(.Items.Count - 1).ForeColor = Color.DarkGreen
                                        .Items(.Items.Count - 1).ImageKey = "ok"
                                    End If
                                End If
                            End If
                        End With
                    Next
                End With

                With lvwLog
                    .HeaderStyle = ColumnHeaderStyle.Nonclickable
                    .Enabled = True
                    .Visible = True
                    btnExport.Visible = True
                    SetWindowTheme(.Handle, "explorer", Nothing)
                End With
            Else
                lvwLog.Visible = False
            End If
        End If

        If lvwLog.Items.Count > 0 Then
            tabLog.Visible = True
            lblNoPeriodEvents.Visible = False
        Else
            tabLog.Visible = False
            lblNoPeriodEvents.Visible = True
        End If
    End Sub

    Public Sub FillEvents()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        tlpDisplayEvent.Visible = False
        tlpEventChart.Visible = False
        lblNoEvents.Visible = True

        If Not IsNothing(dev.Log) Then
            If dev.Log.Count > 0 Then

                With lvwEvents
                    .Items.Clear()
                    Dim eventCount As Short = 0
                    Dim eventList() As String = {"Current pending sectors", "Disk shift", "ATA Errors", "Remaining life percentage",
                        "Media wearout indicator", "Percentage lifetime used", "Offline uncorrectable", "Reallocated event count",
                        "Reallocated sector count", "Wear leveling count", "SSD life left", "Soft read error rate", "Spin retry count",
                        "Temperature"}

                    For e As Short = 0 To eventList.Count - 1
                        eventCount = 0

                        For i As Short = 0 To dev.Log.Count - 1
                            If dev.Log(i).Event = eventList(e) Then eventCount += 1
                        Next

                        If eventCount > 0 Then
                            .Items.Add(eventList(e))
                            .Items(.Items.Count - 1).SubItems.Add(eventCount)
                        End If
                    Next

                    If .Items.Count > 0 Then .Items(0).Selected = True
                    .Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                    .Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                End With

                tlpDisplayEvent.Visible = True
                tlpEventChart.Visible = True
                lblNoEvents.Visible = False
            End If
        End If

    End Sub
End Class
