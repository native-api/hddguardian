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
    Public Structure VirtualDevice
        Public Sub New(ByVal desc As String, ByVal location As String)
            Description = desc
            Path = location
        End Sub

        Dim Description, Path As String
    End Structure

    Dim VirtualDevices As New List(Of VirtualDevice)

    Public Sub LoadVirtual()
        Dim file As String = My.Application.Info.DirectoryPath & "\Data\" & My.User.Name & "\virtualdevices.xml"

        If IO.File.Exists(file) Then
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            Try
                m_xmldoc.Load(file)
                m_nodelist = m_xmldoc.SelectNodes("/virtual/device")
                For Each m_node In m_nodelist
                    Dim vd As New VirtualDevice
                    vd.Description = m_node.Attributes.GetNamedItem("description").Value
                    vd.Path = m_node.Attributes.GetNamedItem("path").Value

                    If Not IsNothing(VirtualDevices) Then
                        Dim add As Boolean = True
                        For i As Short = 0 To VirtualDevices.Count - 1
                            If VirtualDevices(i).Path = vd.Path Then
                                add = False
                                Exit For
                            End If
                        Next
                        If add Then VirtualDevices.Add(vd)
                    Else
                        VirtualDevices.Add(vd)
                    End If
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub SaveVirtual()
        Try
            Dim folder As String = My.Application.Info.DirectoryPath & "\Data\" & My.User.Name
            Dim file As String = folder & "\virtualdevices.xml"

            If Not IO.Directory.Exists(folder & "\") Then IO.Directory.CreateDirectory(folder & "\")

            If IsNothing(VirtualDevices) Then Exit Sub

            Dim output As XmlWriterSettings = New XmlWriterSettings()
            output.Indent = True
            Using write As XmlWriter = XmlWriter.Create(file)
                write.WriteStartDocument()
                write.WriteStartElement("virtual")
                For i As Short = 0 To VirtualDevices.Count - 1
                    write.WriteStartElement("device")
                    write.WriteAttributeString("description", VirtualDevices(i).Description)
                    write.WriteAttributeString("path", VirtualDevices(i).Path)
                    write.WriteEndElement()
                Next
                write.WriteEndElement()
                write.WriteEndDocument()
            End Using
        Catch e As Exception

        End Try
    End Sub

    Public Sub AddVirtual(ByVal description As String, ByVal path As String)
        If IsNothing(description) Or IsNothing(path) Then Exit Sub

        Dim add As Boolean = True
        For i As Short = 0 To VirtualDevices.Count - 1
            If VirtualDevices(i).Path = path Then
                add = False
                Exit For
            End If
        Next
        If add Then
            VirtualDevices.Add(New VirtualDevice(description, path))
            'copy the original file as backup...
            Dim fname As String = IO.Path.GetFileNameWithoutExtension(path)
            IO.File.Copy(path, My.Application.Info.DirectoryPath & "\Data\" & My.User.Name & "\" & fname)
            'add virtual device to devices listview and collection
            devlist.Add(New Device(path, DeviceType.ATA, False, True))
            Dim dev As Device = devlist(devlist.Count - 1)

            With lvwDevices
                If dev.Type = DeviceType.SCSI Then
                    .Items.Add(New ListViewItem(dev.Scsi.Info.Product, .Groups(2)))
                Else
                    .Items.Add(New ListViewItem(dev.ATA.Info.Model, .Groups(2)))
                End If

                Dim i As Short = .Items.Count - 1
                .Items(i).UseItemStyleForSubItems = False
                .Items(i).SubItems.Add(dev.LastUpdate)

                If IsNumeric(dev.Temperature) Then
                    If AppSettings.General.TemperatureInFahrenheit = True Then
                        .Items(i).SubItems.Add(Math.Round(dev.Temperature * 1.8 + 32) & "°F")
                    Else
                        .Items(i).SubItems.Add(dev.Temperature & "°C")
                    End If
                    Select Case Val(dev.Temperature)
                        Case 0 To 49
                            .Items(i).SubItems(1).ForeColor = temp_ok
                        Case 50 To 54
                            .Items(i).SubItems(1).ForeColor = temp_high
                        Case Is >= 55
                            .Items(i).SubItems(1).ForeColor = temp_alarm
                    End Select
                Else
                    .Items(i).SubItems.Add(dev.Temperature)
                    .Items(i).SubItems(1).ForeColor = Color.DarkGray
                End If

                If dev.Type = DeviceType.SCSI Then
                    .Items(i).SubItems.Add("-")
                    .Items(i).SubItems(2).ForeColor = Color.DarkGray
                Else
                    If IsNumeric(dev.ATA.Health.RemainingLife) Then
                        .Items(i).SubItems.Add(Val(dev.ATA.Health.RemainingLife) & "%")
                        Select Case Val(dev.ATA.Health.RemainingLife)
                            Case 0
                                .Items(i).SubItems(2).ForeColor = life_out
                            Case 1 To 10
                                .Items(i).SubItems(2).ForeColor = life_low
                            Case Is > 10
                                .Items(i).SubItems(2).ForeColor = life_ok
                        End Select
                    Else
                        .Items(i).SubItems.Add(dev.ATA.Health.RemainingLife)
                        .Items(i).SubItems(2).ForeColor = Color.DarkGray
                    End If
                End If


                If dev.Type = DeviceType.SCSI Then
                    If IsNumeric(dev.Scsi.Health.GrownDefectsCount) Then
                        .Items(i).SubItems.Add(Val(dev.Scsi.Health.GrownDefectsCount))
                        Select Case Val(dev.Scsi.Health.GrownDefectsCount)
                            Case Is = 0
                                .Items(i).SubItems(4).ForeColor = status_ok
                            Case Else
                                .Items(i).SubItems(4).ForeColor = status_warning
                        End Select
                    Else
                        .Items(i).SubItems.Add(dev.Scsi.Health.GrownDefectsCount)
                        .Items(i).SubItems(4).ForeColor = status_unknown
                    End If

                    If IsNumeric(dev.Scsi.Health.NonMediumErrors) Then
                        .Items(i).SubItems.Add(Val(dev.Scsi.Health.NonMediumErrors))
                        Select Case Val(dev.Scsi.Health.NonMediumErrors)
                            Case Is = 0
                                .Items(i).SubItems(5).ForeColor = status_ok
                            Case Else
                                .Items(i).SubItems(5).ForeColor = status_warning
                        End Select
                    Else
                        .Items(i).SubItems.Add(dev.Scsi.Health.NonMediumErrors)
                        .Items(i).SubItems(5).ForeColor = status_unknown
                    End If
                Else
                    If IsNumeric(dev.ATA.Health.BadSectorsCount) Then
                        .Items(i).SubItems.Add(Val(dev.ATA.Health.BadSectorsCount))
                        Select Case Val(dev.ATA.Health.BadSectorsCount)
                            Case Is = 0
                                .Items(i).SubItems(4).ForeColor = status_ok
                            Case 1 To dev.ATA.Health.BadSectorsThreshold
                                .Items(i).SubItems(4).ForeColor = status_warning
                            Case Is > dev.ATA.Health.BadSectorsThreshold
                                .Items(i).SubItems(4).ForeColor = status_fail
                        End Select
                    Else
                        .Items(i).SubItems.Add(dev.ATA.Health.BadSectorsCount)
                        .Items(i).SubItems(4).ForeColor = status_unknown
                    End If

                    If IsNumeric(dev.ATA.Errors.TotalAmount) Then
                        .Items(i).SubItems.Add(Val(dev.ATA.Errors.TotalAmount))
                        Select Case Val(dev.ATA.Errors.TotalAmount)
                            Case Is = 0
                                .Items(i).SubItems(5).ForeColor = status_ok
                            Case Is >= 1
                                .Items(i).SubItems(5).ForeColor = status_warning
                        End Select
                    Else
                        .Items(i).SubItems.Add(dev.ATA.Errors.TotalAmount)
                        .Items(i).SubItems(5).ForeColor = status_unknown
                    End If
                End If

                Select Case dev.Health
                    Case Status.Passed
                        .Items(i).SubItems.Add(GetString(430))
                        .Items(i).SubItems(6).ForeColor = status_ok
                    Case Status.Failed
                        .Items(i).SubItems.Add(GetString(443))
                        .Items(i).SubItems(6).ForeColor = status_fail
                    Case Status.Unknown
                        .Items(i).SubItems.Add(GetString(439))
                        .Items(i).SubItems(6).ForeColor = status_unknown
                End Select

                If dev.Type = DeviceType.SCSI Then
                    If dev.Scsi.SelfTestLog.HasLog Then
                        If dev.Scsi.SelfTestLog.Item(0).Status.Contains("Failed") Then
                            .Items(i).SubItems.Add(GetString(443))
                            .Items(i).SubItems(7).ForeColor = status_fail
                        ElseIf dev.scsi.SelfTestLog.Item(0).Status.Contains("Aborted") Then
                            .Items(i).SubItems.Add(GetString(431))
                            .Items(i).SubItems(7).ForeColor = status_warning
                        ElseIf dev.scsi.SelfTestLog.Item(0).Status.Contains("Incomplete") Then
                            .Items(i).SubItems.Add(GetString(442))
                            .Items(i).SubItems(7).ForeColor = status_warning
                        Else
                            .Items(i).SubItems.Add(GetString(430))
                            .Items(i).SubItems(7).ForeColor = status_ok
                        End If
                    Else
                        .Items(i).SubItems.Add("-")
                        .Items(i).SubItems(7).ForeColor = status_unknown
                    End If
                Else
                    Dim res As Short = Val(dev.LastTestResult.Status)
                    Select Case res
                        Case 0
                            .Items(i).SubItems.Add(GetString(430))
                            .Items(i).SubItems(7).ForeColor = status_ok
                        Case 1 To 2
                            .Items(i).SubItems.Add(GetString(430 + res))
                            .Items(i).SubItems(7).ForeColor = status_warning
                        Case 3 To 8
                            .Items(i).SubItems.Add(GetString(430 + res))
                            .Items(i).SubItems(7).ForeColor = status_fail
                        Case 15
                            .Items(i).SubItems.Add(GetString(439))
                            .Items(i).SubItems(7).ForeColor = status_fail
                        Case 24
                            .Items(i).SubItems.Add(GetString(440) & " (" & dev.LastTestResult.Remaining & "%)")
                            .Items(i).SubItems(7).ForeColor = status_unknown
                        Case Else
                            .Items(i).SubItems.Add(GetString(441))
                            .Items(i).SubItems(7).ForeColor = status_unknown
                    End Select
                End If

                FillManageDeviceList()

                .Items(i).Selected = True
                .Items(i).EnsureVisible()

                .Groups(2).Header = .Groups(2).Tag & " - " & .Groups(2).Items.Count
                Main.SetWindowTheme(.Handle, "explorer", Nothing)
            End With
        End If

        SaveVirtual()
    End Sub

    Public Sub RemoveVirtual(ByVal path As String)
        If IsNothing(path) Then Exit Sub

        For i As Short = 0 To VirtualDevices.Count - 1
            If VirtualDevices(i).Path = path Then
                'delete the "mirrored" file
                Dim fname As String = IO.Path.GetFileNameWithoutExtension(path)
                IO.File.Copy(path, My.Application.Info.DirectoryPath & "\Data\" & My.User.Name & "\" & fname)

                VirtualDevices.RemoveAt(i)
                SaveVirtual()
                Exit For
            End If
        Next
    End Sub

End Class
