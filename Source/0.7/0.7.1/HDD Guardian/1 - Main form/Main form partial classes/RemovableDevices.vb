'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Partial Class Main

    Private Const WM_DEVICECHANGE As Integer = &H219
    Private Const DBT_DEVICEARRIVAL As Integer = &H8000
    Private Const DBT_DEVICEREMOVECOMPLETE As Integer = &H8004
    Private Const DBT_DEVTYP_VOLUME As Integer = &H2

    Protected Overrides Sub WndProc(ByRef M As System.Windows.Forms.Message)
        'These are the required subclassing codes for detecting device based removal and arrival.
        If M.Msg = WM_DEVICECHANGE Then
            Select Case M.WParam
            'Check if a device was added.
                Case DBT_DEVICEARRIVAL
                    Dim devType As Integer = Runtime.InteropServices.Marshal.ReadInt32(M.LParam, 4)
                    If devType = DBT_DEVTYP_VOLUME Then
                        PrintDebug("A new device is connected")
                        AddUsbDevices()
                    End If
                'Check if the message was for the removal of a device.
                Case DBT_DEVICEREMOVECOMPLETE
                    Dim devType As Integer = Runtime.InteropServices.Marshal.ReadInt32(M.LParam, 4)
                    If devType = DBT_DEVTYP_VOLUME Then
                        PrintDebug("A device was removed")
                        RemoveUsbDevices()
                    End If
            End Select
        End If
        MyBase.WndProc(M)
    End Sub

    Sub RemoveUsbDevices()
        Try
            For i As Short = devlist.Count - 1 To 0 Step -1

                lvwDevices.Items(0).Selected = True

                If devlist(i).Type = DeviceType.USB Then
                    devlist(i).Update()
                    If Not devlist(i).IsValid Then
                        devlist(i).Tray.Dispose()
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
        Dim prompt As New Console
        Dim usb() As String = Nothing

        Try
            'querying smartctl for usb devices
            Dim usbscan() As String = prompt.Smartctl("--scan -d usb")
            For i As Integer = 0 To usbscan.Count - 2 'the last item is an empty line
                If InStr(usbscan(i), "/dev/sd") < InStr(usbscan(i), "#") And InStr(usbscan(i), "/dev/sd") >= 0 Then
                    If isCherryTrail Then
                        ReDim Preserve usb(i)
                        Dim usbdev As String() = usbscan(i).Split("#")
                        usb(i) = usbdev(0).Trim.Replace("-d scsi", "-d sat")
                    Else
                        If usbscan(i).Contains("ATA device") Then 'this avoid to display some devices like the storage of a Vodafone Internet Key
                            ReDim Preserve usb(i)
                            Dim usbdev As String() = usbscan(i).Split("#")
                            usb(i) = usbdev(0).Trim
                        End If
                    End If
                End If
            Next

            If AppSettings.Detection.Additional.Length > 0 Then
                Dim ad() As String = AppSettings.Detection.Additional.Split(",")
                For i As Short = 0 To ad.Count - 1
                    If ad(i).Contains("[USB]") Then
                        ReDim Preserve usb(usb.Count)
                        usb(usb.Count) = ad(i).Replace("[USB]", "").Trim
                    End If
                Next
            End If

            If IsNothing(usb) Then Exit Sub

            Dim somethingadd As Boolean = False

            For i As Short = 0 To usb.Count - 1
                If Not IsNothing(usb(i)) Then
                    Dim newusb As New Device(usb(i), DeviceType.USB, False)

                    If newusb.ATA.IsDoubleDeck Then
                        PrintDebug("Detected double docking station device", True)

                        Dim p_0 As New Device(usb(i) & ",0", DeviceType.USB, False)
                        Dim skip_0 As Boolean = False

                        For i_0 As Short = 0 To devlist.Count - 1
                            If devlist(i_0).Type = DeviceType.USB Then
                                If p_0.ATA.Info.Model = devlist(i_0).ATA.Info.Model And p_0.ATA.Info.SerialNumber = devlist(i_0).ATA.Info.SerialNumber Then
                                    skip_0 = True
                                    Exit For
                                End If
                            End If
                        Next

                        If Not skip_0 Then
                            PrintDebug("Adding " & p_0.ATA.Info.Model & " (" & p_0.ATA.Info.SerialNumber & ")")
                            If p_0.IsValid Then
                                devlist.Add(New Device(usb(i) & ",0", DeviceType.USB))
                                AddToList(devlist(devlist.Count - 1))
                                somethingadd = True
                            End If
                        Else
                            PrintDebug("Device " & p_0.ATA.Info.Model & " (" & p_0.ATA.Info.SerialNumber & ") already in list, skipping...")
                            Dim p_1 As New Device(usb(i) & ",1", DeviceType.USB, False)
                            Dim skip_1 As Boolean = False

                            For i_1 As Short = 0 To devlist.Count - 1
                                If devlist(i_1).Type = DeviceType.USB Then
                                    If p_1.ATA.Info.Model = devlist(i_1).ATA.Info.Model And p_1.ATA.Info.SerialNumber = devlist(i_1).ATA.Info.SerialNumber Then
                                        skip_1 = True
                                        Exit For
                                    End If
                                End If
                            Next

                            If Not skip_1 Then
                                PrintDebug("Adding " & p_1.ATA.Info.Model & " (" & p_1.ATA.Info.SerialNumber & ")")
                                If p_1.IsValid Then
                                    devlist.Add(New Device(usb(i) & ",1", DeviceType.USB))
                                    AddToList(devlist(devlist.Count - 1))
                                    somethingadd = True
                                End If
                            End If

                            p_1 = Nothing
                        End If

                        p_0 = Nothing
                    Else
                        If newusb.IsValid Then
                            Dim skip As Boolean = False

                            For c As Short = 0 To devlist.Count - 1
                                If devlist(c).Type = DeviceType.USB Then
                                    If newusb.ATA.Info.Model = devlist(c).ATA.Info.Model And newusb.ATA.Info.SerialNumber = devlist(c).ATA.Info.SerialNumber Then
                                        skip = True
                                        Exit For
                                    End If
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
                End If
            Next

            If somethingadd Then
                FillManageDeviceList()
                UpdateHardware()
            End If

        Catch ex As Exception
            PrintDebug("An error occurred adding an USB device to list: " & ex.Message)
        End Try
    End Sub

    Private Sub AddToList(ByVal dev As Device)
        With lvwDevices
            Dim lvi As New ListViewItem(dev.ATA.Info.Model, .Groups(1))
            .Items.Add(lvi)
            Dim a As Short = .Items.Count - 1
            .Items(a).UseItemStyleForSubItems = False

            'last update
            .Items(a).SubItems.Add(dev.LastUpdate)

            'temperature
            If IsNumeric(dev.Temperature) Then
                If AppSettings.General.TemperatureInFahrenheit = True Then
                    .Items(a).SubItems.Add(Math.Round(dev.Temperature * 1.8 + 32) & "°F")
                Else
                    .Items(a).SubItems.Add(dev.Temperature & "°C")
                End If
                Select Case Val(dev.Temperature)
                    Case 0 To 49
                        .Items(a).SubItems(2).ForeColor = temp_ok
                    Case 50 To 54
                        .Items(a).SubItems(2).ForeColor = temp_high
                    Case Is >= 55
                        .Items(a).SubItems(2).ForeColor = temp_alarm
                End Select
            Else
                .Items(a).SubItems.Add(dev.Temperature)
                .Items(a).SubItems(2).ForeColor = Color.DarkGray
            End If

            'remaining life (for external SSD)
            If IsNumeric(dev.ATA.Health.RemainingLife) Then
                .Items(a).SubItems.Add(Val(dev.ATA.Health.RemainingLife) & "%")
                Select Case Val(dev.ATA.Health.RemainingLife)
                    Case 0
                        .Items(a).SubItems(3).ForeColor = life_out
                    Case 1 To 10
                        .Items(a).SubItems(3).ForeColor = life_low
                    Case Is > 10
                        .Items(a).SubItems(3).ForeColor = life_ok
                End Select
            Else
                .Items(a).SubItems.Add(dev.ATA.Health.RemainingLife)
                .Items(a).SubItems(3).ForeColor = Color.DarkGray
            End If

            If IsNumeric(dev.ATA.Health.BadSectorsCount) Then
                .Items(a).SubItems.Add(Val(dev.ATA.Health.BadSectorsCount))
                Select Case Val(dev.ATA.Health.BadSectorsCount)
                    Case Is = 0
                        .Items(a).SubItems(4).ForeColor = status_ok
                    Case 1 To dev.ATA.Health.BadSectorsThreshold
                        .Items(a).SubItems(4).ForeColor = status_warning
                    Case Is > dev.ATA.Health.BadSectorsThreshold
                        .Items(a).SubItems(4).ForeColor = status_fail
                End Select
            Else
                .Items(a).SubItems.Add(dev.ATA.Health.BadSectorsCount)
                .Items(a).SubItems(4).ForeColor = status_unknown
            End If

            If IsNumeric(dev.ATA.Errors.TotalAmount) Then
                .Items(a).SubItems.Add(Val(dev.ATA.Errors.TotalAmount))
                Select Case Val(dev.ATA.Errors.TotalAmount)
                    Case Is = 0
                        .Items(a).SubItems(5).ForeColor = status_ok
                    Case Is >= 1
                        .Items(a).SubItems(5).ForeColor = status_warning
                End Select
            Else
                .Items(a).SubItems.Add(dev.ATA.Errors.TotalAmount)
                .Items(a).SubItems(5).ForeColor = status_unknown
            End If

            Select Case dev.Health
                Case Status.Passed
                    .Items(a).SubItems.Add(GetString(430))
                    .Items(a).SubItems(6).ForeColor = status_ok
                Case Status.Failed
                    .Items(a).SubItems.Add(GetString(443))
                    .Items(a).SubItems(6).ForeColor = status_fail
                Case Status.Unknown
                    .Items(a).SubItems.Add(GetString(439))
                    .Items(a).SubItems(6).ForeColor = status_unknown
            End Select

            Dim res As Short = Val(dev.LastTestResult.Status)
            Select Case res
                Case 0
                    .Items(a).SubItems.Add(GetString(430))
                    .Items(a).SubItems(7).ForeColor = status_ok
                Case 1 To 2
                    .Items(a).SubItems.Add(GetString(430 + res))
                    .Items(a).SubItems(7).ForeColor = status_warning
                Case 3 To 8
                    .Items(a).SubItems.Add(GetString(430 + res))
                    .Items(a).SubItems(7).ForeColor = status_fail
                Case 15
                    .Items(a).SubItems.Add(GetString(439))
                    .Items(a).SubItems(7).ForeColor = status_fail
                Case 24
                    .Items(a).SubItems.Add(GetString(440) & " (" & dev.LastTestResult.Remaining & "%)")
                    .Items(a).SubItems(7).ForeColor = status_unknown
                Case Else
                    .Items(a).SubItems.Add(GetString(441))
                    .Items(a).SubItems(7).ForeColor = status_unknown
            End Select

            .Groups(1).Header = .Groups(1).Tag & " - " & .Groups(1).Items.Count
            SetWindowTheme(.Handle, "explorer", Nothing)
        End With
    End Sub

End Class
