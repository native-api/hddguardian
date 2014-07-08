'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System
Imports System.Management
Imports System.ComponentModel

Partial Class Main

    Dim WithEvents media_connect As New ManagementEventWatcher
    Dim WithEvents media_disconnect As New ManagementEventWatcher

    Sub RemoveUsbDevices()
        Try
            For i As Short = devlist.Count - 1 To 0 Step -1

                lvwDevices.Items(0).Selected = True

                If devlist(i).Type = DeviceType.USB Then
                    devlist(i).Update()
                    If Not devlist(i).IsValidDevice Then
                        devlist(i).DisposeTrayIcon()
                        devlist.RemoveAt(i)
                        With lvwDevices
                            .Items(i).Remove()
                            .Groups(1).Header = .Groups(1).Tag & " - " & .Groups(1).Items.Count
                            SetWindowTheme(.Handle, "explorer", Nothing)
                        End With
                        FillManageDeviceList()
                        UpdateHardware()
                    End If
                End If
            Next
        Catch ex As Exception
            PrintDebug("An error occurred removing an USB device from list: " & ex.Message)
        End Try
    End Sub

    Sub AddUsbDevices()
        Dim smartctl As New Console
        Dim usb() As String = Nothing

        Try
            'querying smartctl for usb devices
            Dim usbscan() As String = smartctl.SendCmd("--scan -d usb")
            For i As Integer = 0 To usbscan.Count - 2 'the last item is an empty line
                If InStr(usbscan(i), "/dev/sd") < InStr(usbscan(i), "#") And InStr(usbscan(i), "/dev/sd") >= 0 Then
                    ReDim Preserve usb(i)
                    Dim usbdev As String() = usbscan(i).Split("#")
                    usb(i) = usbdev(0).Trim
                End If
            Next

            Dim somethingadd As Boolean = False

            For i As Short = 0 To usb.Count - 1
                Dim newusb As New Device(usb(i), DeviceType.USB, False)

                If newusb.IsDoubleDeck Then
                    PrintDebug("Detected double docking station device", True)

                    Dim p_0 As New Device(usb(i) & ",0", DeviceType.USB, False)
                    Dim skip_0 As Boolean = False

                    For i_0 As Short = 0 To devlist.Count - 1
                        If p_0.Model = devlist(i_0).Model And p_0.SerialNumber = devlist(i_0).SerialNumber Then
                            skip_0 = True
                            Exit For
                        End If
                    Next

                    If Not skip_0 Then
                        PrintDebug("Adding " & p_0.Model & " (" & p_0.SerialNumber & ")")
                        If p_0.IsValidDevice Then
                            devlist.Add(New Device(usb(i) & ",0", DeviceType.USB))
                            AddToList(devlist(devlist.Count - 1))
                            somethingadd = True
                        End If
                    Else
                        PrintDebug("Device " & p_0.Model & " (" & p_0.SerialNumber & ") already in list, skipping...")
                        Dim p_1 As New Device(usb(i) & ",1", DeviceType.USB, False)
                        Dim skip_1 As Boolean = False

                        For i_1 As Short = 0 To devlist.Count - 1
                            If p_1.Model = devlist(i_1).Model And p_1.SerialNumber = devlist(i_1).SerialNumber Then
                                skip_1 = True
                                Exit For
                            End If
                        Next

                        If Not skip_1 Then
                            PrintDebug("Adding " & p_1.Model & " (" & p_1.SerialNumber & ")")
                            If p_1.IsValidDevice Then
                                devlist.Add(New Device(usb(i) & ",1", DeviceType.USB))
                                AddToList(devlist(devlist.Count - 1))
                                somethingadd = True
                            End If
                        End If

                        p_1 = Nothing
                    End If

                    p_0 = Nothing
                Else
                    If newusb.IsValidDevice Then
                        Dim skip As Boolean = False

                        For c As Short = 0 To devlist.Count - 1
                            If newusb.Model = devlist(c).Model And newusb.SerialNumber = devlist(c).SerialNumber Then
                                skip = True
                                Exit For
                            End If
                        Next

                        If Not skip Then
                            devlist.Add(New Device(usb(i), DeviceType.USB))
                            AddToList(devlist(devlist.Count - 1))
                            somethingadd = True
                        End If
                    End If
                End If

                newusb = Nothing
            Next

            Dim d_now = devlist.Count

            'If My.Settings.MultiDock Then AddMultiDock()

            If somethingadd Or devlist.Count > d_now Then
                FillManageDeviceList()
                UpdateHardware()
            End If

        Catch ex As Exception
            PrintDebug("An error occurred adding an USB device to list: " & ex.Message)
        End Try
    End Sub

    Private Sub AddToList(ByVal dev As Device)
        With lvwDevices
            Dim lvi As New ListViewItem(dev.Model, .Groups(1))
            .Items.Add(lvi)
            Dim a As Short = .Items.Count - 1
            .Items(a).UseItemStyleForSubItems = False

            'reliability/health icon
            If dev.InDatabase Then
                Select Case dev.ReliabilityRating.Overall
                    Case 4 To 5
                        .Items(a).ImageIndex = 0
                    Case 2 To 3
                        .Items(a).ImageIndex = 3
                    Case 1
                        .Items(a).ImageIndex = 2
                    Case Else
                        .Items(a).ImageIndex = 1
                End Select
                If dev.Health = Status.Failed Then .Items(a).ImageIndex = 2
            Else 'here are rated unknown SATA and SCSI devices
                Select Case dev.Health
                    Case Status.Unkonwn
                        .Items(a).ImageIndex = 1
                    Case Status.Failed
                        .Items(a).ImageIndex = 2
                    Case Status.Passed
                        .Items(a).ImageIndex = 0
                End Select
            End If

            'temperature
            If IsNumeric(dev.Temperature) Then
                If My.Settings.TempFahrenheit = True Then
                    .Items(a).SubItems.Add(Math.Round(dev.Temperature * 1.8 + 32) & "°F")
                Else
                    .Items(a).SubItems.Add(dev.Temperature & "°C")
                End If
                Select Case Val(dev.Temperature)
                    Case 0 To 49
                        .Items(a).SubItems(1).ForeColor = temp_ok
                    Case 50 To 54
                        .Items(a).SubItems(1).ForeColor = temp_high
                    Case Is >= 55
                        .Items(a).SubItems(1).ForeColor = temp_alarm
                End Select
            Else
                .Items(a).SubItems.Add(dev.Temperature)
                .Items(a).SubItems(1).ForeColor = Color.DarkGray
            End If

            'remaining life (for external SSD)
            If IsNumeric(dev.RemainingLife) Then
                .Items(a).SubItems.Add(Val(dev.RemainingLife) & "%")
                Select Case Val(dev.RemainingLife)
                    Case 0
                        .Items(a).SubItems(2).ForeColor = life_out
                    Case 1 To 10
                        .Items(a).SubItems(2).ForeColor = life_low
                    Case Is > 10
                        .Items(a).SubItems(2).ForeColor = life_ok
                End Select
            Else
                .Items(a).SubItems.Add(dev.RemainingLife)
                .Items(a).SubItems(2).ForeColor = Color.DarkGray
            End If

            'interface type
            .Items(a).SubItems.Add(dev.DeviceInterface)

            'size
            If IsNumeric(dev.UserCapacity) Then
                Dim iec As String = ""
                If Val(dev.UserCapacity / 1024 ^ 3) > 1000 Then
                    iec = Format(Val(dev.UserCapacity / 1024 ^ 4), "#.#") & " TiB"
                Else
                    iec = Format(Val(dev.UserCapacity / 1024 ^ 3), "#,###") & " GiB"
                End If
                Dim si As String = ""
                If Val(dev.UserCapacity / 1000 ^ 3) > 1000 Then
                    si = Format(Val(dev.UserCapacity / 1000 ^ 4), "#.#") & " TB"
                Else
                    si = Format(Val(dev.UserCapacity / 1000 ^ 3), "#,###") & " GB"
                End If
                .Items(a).SubItems.Add(iec & " / " & si)
            Else
                .Items(a).SubItems.Add(dev.UserCapacity)
            End If

            .Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            .Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            .Columns(3).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns(3).Width = .Columns(3).Width + 10
            .Columns(4).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)

            .Groups(1).Header = .Groups(1).Tag & " - " & .Groups(1).Items.Count
            SetWindowTheme(.Handle, "explorer", Nothing)
        End With
    End Sub

    Public Sub StartMonitorDeviceConnection()
        Try
            media_connect = New ManagementEventWatcher
            'media_connect.Query = New WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_DiskDrive' AND TargetInstance.InterfaceType = 'USB'")
            media_connect.Query = New WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_PnPEntity' AND TargetInstance.Caption LIKE '%USB Device%'")
            media_connect.Start()

            media_disconnect = New ManagementEventWatcher
            'media_disconnect.Query = New WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_DiskDrive' AND TargetInstance.InterfaceType = 'USB'")
            media_disconnect.Query = New WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_PnPEntity' AND TargetInstance.Caption LIKE '%USB Device%'")
            media_disconnect.Start()

            PrintDebug("External devices connect/disconnect routine successfully started", False, True)
        Catch ex As Exception
            PrintDebug("Error with external connect/disconnect routine: " & ex.ToString, True)
        End Try
    End Sub

    Private Delegate Sub RemoveUsb()
    Private Delegate Sub AddUsb()

    Private Sub DeviceConnect(ByVal sender As Object, ByVal e As System.Management.EventArrivedEventArgs) Handles media_connect.EventArrived
        Dim UsbDelegate As AddUsb
        UsbDelegate = AddressOf AddUsbDevices

        Me.Invoke(UsbDelegate)
    End Sub

    Private Sub DeviceDisconnect(ByVal sender As Object, ByVal e As System.Management.EventArrivedEventArgs) Handles media_disconnect.EventArrived
        Dim UsbDelegate As RemoveUsb
        UsbDelegate = AddressOf RemoveUsbDevices

        Me.Invoke(UsbDelegate)
    End Sub

    Public Sub StopMonitorDeviceConnection()
        media_connect.Stop()
        media_disconnect.Stop()
        PrintDebug("External devices connect/disconnect routine successfully stopped", False, True)
    End Sub

End Class
