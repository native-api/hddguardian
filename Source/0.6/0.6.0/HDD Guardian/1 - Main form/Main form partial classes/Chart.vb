'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Xml

Partial Class Main

    Private Sub SetGraph()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If Not IsNothing(dev.Log) Then
            With chrChart
                .Series(0).Points.Clear()
                .Series(0).MarkerSize = 0

                For i As Short = 0 To dev.Log.Count - 1
                    If dev.Log(i).EventName = cboChartEvents.SelectedItem Then
                        Dim p As New DataVisualization.Charting.DataPoint
                        p.YValues(0) = Convert.ToDouble(dev.Log(i).OldValue.Replace("°C", ""))

                        .Series(0).Points.Add(p)
                        Exit For
                    End If
                Next

                For i As Short = 0 To dev.Log.Count - 1
                    If dev.Log(i).EventName = cboChartEvents.SelectedItem Then
                        Dim p As New DataVisualization.Charting.DataPoint
                        p.YValues(0) = Convert.ToDouble(dev.Log(i).NewValue.Replace("°C", ""))

                        .Series(0).Points.Add(p)
                    End If
                Next
            End With
        End If

    End Sub

    Private Sub FillList()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If Not IsNothing(dev.Log) Then
            If dev.Log.Count > 0 Then
                With lvwChart
                    .Items.Clear()
                    For i As Short = 0 To dev.Log.Count - 1
                        If dev.Log(i).EventName = cboChartEvents.SelectedItem Then

                            Dim y As String = dev.Log(i).Year
                            Dim m As String = String.Format("{0:D2}", Convert.ToInt16(dev.Log(i).Month))
                            Dim d As String = String.Format("{0:D2}", Convert.ToInt16(dev.Log(i).Day))
                            Dim t() As String = dev.Log(i).Hour.Split(":")
                            Dim h As String = String.Format("{0:D2}", Convert.ToInt16(t(0))) & ":" & _
                                String.Format("{0:D2}", Convert.ToInt16(t(1))) & ":" & _
                                String.Format("{0:D2}", Convert.ToInt16(t(2)))

                            Dim timeofevent As String = ""

                            Dim dt As DateTime
                            If DateTime.TryParseExact(d & " " & m & " " & y & " " & h, "dd MM yyyy HH:mm:ss", Nothing, Nothing, dt) Then
                                timeofevent = FormatDateTime(dt, DateFormat.ShortDate) & ", " & FormatDateTime(dt, DateFormat.ShortTime)
                            End If

                            .Items.Add(timeofevent)

                            With .Items(.Items.Count - 1).SubItems
                                .Add(dev.Log(i).OldValue.Replace("°C", ""))
                                .Add(dev.Log(i).NewValue.Replace("°C", ""))

                                Dim variation As String = dev.Log(i).Variation.Replace("°C", "")

                                If IsNumeric(variation) Then
                                    If Convert.ToDouble(variation) > 0 Then
                                        .Add("+" & dev.Log(i).Variation.Replace("°C", ""))
                                    Else
                                        .Add(dev.Log(i).Variation.Replace("°C", ""))
                                    End If
                                End If

                            End With

                        End If
                    Next
                    .Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                    lblEvents.Text = lblEvents.Tag.ToString.Replace("%", .Items.Count)
                End With
            End If
        End If

    End Sub

    Public Sub FillChartEvents()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        tlpChart.Visible = False
        lvwChart.Visible = False
        chrChart.Visible = False
        lblChartCount.Visible = True
        lblChartCount.Text = m_nologfordevice

        If Not IsNothing(dev.Log) Then
            If dev.Log.Count > 0 Then

                With cboChartEvents
                    .Items.Clear()

                    For i As Short = 0 To dev.Log.Count - 1

                        Dim notduplicate As Boolean = True

                        For l As Short = 0 To .Items.Count - 1
                            If dev.Log(i).EventName = .Items(l) Then
                                notduplicate = False
                                Exit For
                            End If
                        Next

                        If notduplicate Then
                            .Items.Add(dev.Log(i).EventName)
                        End If
                    Next

                    If .Items.Count > 0 Then .SelectedIndex = 0

                End With

                tlpChart.Visible = True
                lvwChart.Visible = True
                chrChart.Visible = True
                lblChartCount.Visible = False
            End If
        End If

    End Sub
End Class
