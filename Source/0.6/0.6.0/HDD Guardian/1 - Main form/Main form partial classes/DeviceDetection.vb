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

Imports System.Management
Imports System.ComponentModel
Imports System.Xml

Partial Class Main
    Public atadevices() As String
    Public usbdevices() As String
    Public csmidevices() As String
    Public scsidevices() As String
    Public lsidevices() As String
    Public delldevices() As String
    Public win8devices() As String
    Public intelrstdevices() As String
    Public devlist As New Devices

    Private Enum ScsiController
        IntelQM77 = 0 'Intel(R) Mobile Express Chipset SATA RAID Controller [Issue 24, Zhenyu Wu]
        LsiFalcon = 1 'LSI Adapter, SAS2 2008 Falcon                        [Issue 25, Miletibw]
        DellH200 = 2  'Dell PERC H200 Adapter                               [Support group, Brian Elias]
        Win8_SSC = 3  'Microsoft Storage Spaces Controller                  [Support group, Edward J. Ouellette]
    End Enum

    Private Function CheckScsiController(ByVal controller As scsicontroller) As Boolean
        Dim win32_scsicontroller As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_SCSIController")
        Dim stringtoget As String = ""

        Select Case controller
            Case scsicontroller.IntelQM77
                stringtoget = "Intel(R) Mobile Express Chipset SATA RAID Controller"
            Case scsicontroller.LsiFalcon
                stringtoget = "LSI Adapter, SAS2 2008 Falcon"
            Case ScsiController.DellH200
                stringtoget = "Dell PERC H200 Adapter"
            Case ScsiController.Win8_SSC
                stringtoget = "Microsoft Storage Spaces Controller"
        End Select

        For Each scsi As ManagementObject In win32_scsicontroller.Get()
            If scsi("Name").ToString.Trim.Contains(stringtoget) Then
                Return True
                Exit For
            End If
        Next

        Return False
    End Function

    Private Sub Search()
        Dim smartctl As New Console
        PrintDebug("*** Searching devices ***", False, True)
        PrintDebug("Searching Intel Matrix devices...")

        'collect devices under Intel Matrix using command "--scan -d csmi"
        If My.Settings.EnableCsmi Then
            Dim csmiscan() As String = smartctl.SendCmd("--scan -d csmi")
            Dim csmicount As Short = 0
            For i As Integer = 0 To csmiscan.Count - 2 'the last item is an empty line
                If InStr(csmiscan(i), "/dev/csmi") < InStr(csmiscan(i), "#") And InStr(csmiscan(i), "/dev/csmi") >= 0 Then
                    Dim matrix As String() = csmiscan(i).Split("#")
                    'add matrix devices only if are not optical (CD/DVD)
                    Dim d As New Device(matrix(0).Replace(vbCr, "").Replace(vbLf, ""), DeviceType.ATA, False)
                    If Not d.IsOptical And d.IsValidDevice Then
                        ReDim Preserve csmidevices(csmicount)
                        csmidevices(csmicount) = matrix(0).Replace(vbCr, "").Replace(vbLf, "")
                        csmicount += 1
                    End If
                    d = Nothing
                End If
            Next
        End If

        If Not IsNothing(csmidevices) Then PrintDebug("Devices found: " & csmidevices.Count, False, True) Else PrintDebug("No Intel Matrix devices found", False, True)
        PrintDebug("Searching (S)ATA devices...")

        'search devices: now, the local devices are searched by smartctl with "--scan -d ata" option
        'the "-d ata" option at the end collect only fixed (non removable, like usb) devices
        Dim scan() As String = smartctl.SendCmd("--scan -d ata")
        Dim atacount As Short = 0
        For i As Integer = 0 To scan.Count - 2 'the last item is an empty line
            If InStr(scan(i), "/dev/sd") < InStr(scan(i), "#") And InStr(scan(i), "/dev/sd") >= 0 Then
                Dim dev As String() = scan(i).Split("#")
                'add devices only if valid devices
                Dim d As New Device(dev(0).Replace(vbCr, "").Replace(vbLf, ""), DeviceType.ATA, False)
                If d.IsValidDevice Then
                    ReDim Preserve atadevices(atacount)
                    atadevices(atacount) = dev(0).Replace(vbCr, "").Replace(vbLf, "")
                    atacount += 1
                End If
                d = Nothing
            End If
        Next

        If Not IsNothing(atadevices) Then PrintDebug("Devices found: " & atadevices.Count, False, True) Else PrintDebug("No (S)ATA devices found", False, True)
        PrintDebug("Searching USB devices...")

        'collect usb devices: smartctl with "--scan -d usb" option is able to find devices under known interfaces
        'the "-d usb" option at the end collect only removable, like usb, devices. But only if user have admin rights.
        If isadmin Then
            Dim usbscan() As String = smartctl.SendCmd("--scan -d usb")
            ReDim usbdevices(0)
            For i As Integer = 0 To usbscan.Count - 2 'the last item is an empty line
                If InStr(usbscan(i), "/dev/sd") < InStr(usbscan(i), "#") And InStr(usbscan(i), "/dev/sd") >= 0 Then
                    ReDim Preserve usbdevices(i)
                    Dim usbdev As String() = usbscan(i).Split("#")
                    usbdevices(i) = usbdev(0).Replace(vbCr, "").Replace(vbLf, "").Trim
                End If
            Next
        End If

        If Not IsNothing(usbdevices) Then PrintDebug("Devices found: " & usbdevices.Count, False, True) Else PrintDebug("No USB devices found", False, True)

        '********************************************* This section if for ATA devices under SCSI controllers *****************************************
        'Some ATA devices are connected under a SCSI controller and listed ad SCSI devices but data aren't available using the "-d scsi" option with
        'smartctl: in some cases is needed to change the "-d scsi" with "-d ata" and in some other with "-d sat" option.

        If CheckScsiController(ScsiController.IntelQM77) Then
            Dim intelscan() As String = smartctl.SendCmd("--scan -d scsi")
            For i As Integer = 0 To intelscan.Count - 2 'the last item is an empty line
                If InStr(intelscan(i), "/dev/sd") < InStr(intelscan(i), "#") And InStr(intelscan(i), "/dev/sd") >= 0 Then
                    ReDim Preserve intelrstdevices(i)
                    Dim intel As String() = intelscan(i).Split("#")
                    intelrstdevices(i) = intel(0).Replace("-d scsi", "-d ata").Trim.Replace(vbCr, "").Replace(vbLf, "")
                End If
            Next
        End If

        If CheckScsiController(ScsiController.LsiFalcon) Then
            Dim lsiscan() As String = smartctl.SendCmd("--scan -d scsi")
            For i As Integer = 0 To lsiscan.Count - 2 'the last item is an empty line
                If InStr(lsiscan(i), "/dev/sd") < InStr(lsiscan(i), "#") And InStr(lsiscan(i), "/dev/sd") >= 0 Then
                    ReDim Preserve lsidevices(i)
                    Dim lsi As String() = lsiscan(i).Split("#")
                    lsidevices(i) = lsi(0).Replace("-d scsi", "-d sat").Trim.Replace(vbCr, "").Replace(vbLf, "")
                End If
            Next
        End If

        If CheckScsiController(ScsiController.DellH200) Then
            Dim dellscan() As String = smartctl.SendCmd("--scan -d scsi")
            For i As Integer = 0 To dellscan.Count - 2 'the last item is an empty line
                If InStr(dellscan(i), "/dev/sd") < InStr(dellscan(i), "#") And InStr(dellscan(i), "/dev/sd") >= 0 Then
                    Dim dell As String() = dellscan(i).Split("#")
                    Dim h200 As New Device(dell(0).Trim.Replace(vbCr, "").Replace(vbLf, ""), DeviceType.SCSI, False)

                    If h200.Model = "N/A" Then
                        ReDim Preserve delldevices(i)
                        delldevices(i) = dell(0).Replace("-d scsi", "-d sat").Trim.Replace(vbCr, "").Replace(vbLf, "")
                    Else
                        ReDim Preserve delldevices(i)
                        delldevices(i) = dell(0).Replace(vbCr, "").Replace(vbLf, "")
                    End If
                End If
            Next
        End If

        If CheckScsiController(ScsiController.Win8_SSC) Then
            Dim ssc_scan() As String = smartctl.SendCmd("--scan -d scsi")
            For i As Integer = 0 To ssc_scan.Count - 2 'the last item is an empty line
                If InStr(ssc_scan(i), "/dev/sd") < InStr(ssc_scan(i), "#") And InStr(ssc_scan(i), "/dev/sd") >= 0 Then
                    ReDim Preserve win8devices(i)
                    Dim ssc As String() = ssc_scan(i).Split("#")
                    win8devices(i) = ssc(0).Replace("-d scsi", "-d ata").Trim.Replace(vbCr, "").Replace(vbLf, "")
                End If
            Next
        End If

        '*********************************************************************************************************************************************

        PrintDebug("Searching SCSI devices...")
        'add also SCSI devices, but only if LSI Falcon, Intel QM77, Dell PERC H200 and Windwos 8 Storage Spaces Controller
        'are not detected and CSMI device list is empty
        If Not CheckScsiController(ScsiController.IntelQM77) And _
            Not CheckScsiController(ScsiController.LsiFalcon) And _
            Not CheckScsiController(ScsiController.DellH200) And _
            Not CheckScsiController(ScsiController.Win8_SSC) And _
            IsNothing(csmidevices) Then

            Dim scsiscan() As String = smartctl.SendCmd("--scan -d scsi")
            Dim scsicount As Short = 0
            For i As Integer = 0 To scsiscan.Count - 2 'the last item is an empty line
                If InStr(scsiscan(i), "/dev/sd") < InStr(scsiscan(i), "#") And InStr(scsiscan(i), "/dev/sd") >= 0 Then
                    Dim scsidev As String() = scsiscan(i).Split("#")
                    Dim d As New Device(scsidev(0).Replace(vbCr, "").Replace(vbLf, ""), DeviceType.SCSI, False)
                    If d.IsValidDevice Then
                        ReDim Preserve scsidevices(scsicount)
                        scsidevices(scsicount) = scsidev(0).Replace(vbCr, "").Replace(vbLf, "")
                        scsicount += 1
                    End If
                    d = Nothing
                End If
            Next
        End If
        If Not IsNothing(scsidevices) Then PrintDebug("Devices found: " & scsidevices.Count, False, True) Else PrintDebug("No SCSI devices found", False, True)

        'if no devices are founded on system, display a message and then exits from application...
        If IsNothing(atadevices) And IsNothing(csmidevices) And IsNothing(intelrstdevices) And IsNothing(scsidevices) _
            And IsNothing(delldevices) And IsNothing(win8devices) And IsNothing(scsidevices) Then

            'display a warning when administration rights are missed
            If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                MsgBox(GetString(4507), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetString(4506))
            End If

            MsgBox(m_nodevices, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, m_error)

            niTrayIcon.Visible = False
            StopMonitorDeviceConnection()
            Me.Dispose()
            End
        End If

    End Sub

    Private Sub CollectDevices()
        PrintDebug("*** Collecting devices ***", False, True)
        'first, add local devices...
        'first of all the devices under Intel Matrix system...
        If Not IsNothing(csmidevices) Then
            PrintDebug("*** Adding Intel Matrix devices ***", False, True)
            For d As Integer = 0 To csmidevices.Count - 1
                Dim matrixdevice As New Device(csmidevices(d), DeviceType.ATA)
                If Not matrixdevice.IsOptical And matrixdevice.IsValidDevice Then
                    devlist.Add(matrixdevice)
                End If
                matrixdevice = Nothing
            Next
        End If

        'then devices under Intel RST system...
        If Not IsNothing(intelrstdevices) Then
            PrintDebug("*** Adding Intel RST devices ***", False, True)
            For d As Integer = 0 To intelrstdevices.Count - 1
                Dim rstdevice As New Device(intelrstdevices(d), DeviceType.ATA)
                If Not rstdevice.IsOptical Then
                    devlist.Add(rstdevice)
                End If
                rstdevice = Nothing
            Next
        End If

        'then, the normal ATA devices: it check also if a device is already listed with the Intel Matrix system
        If Not IsNothing(atadevices) Then
            PrintDebug("*** Adding ATA devices ***", False, True)
            For d As Integer = 0 To atadevices.Count - 1
                PrintDebug("Adding " & atadevices(d))
                Dim devtoadd As New Device(atadevices(d), DeviceType.ATA)
                'devtoadd.Update()
                Dim isduplicate As Boolean = False
                If devtoadd.IsValidDevice Then
                    For i As Integer = 0 To devlist.Count - 1
                        'check if the serial number and the device model are already in list:
                        'you can have the same model but not the same serial number or
                        'the same serial number but a different model...
                        If devtoadd.SerialNumber = devlist(i).SerialNumber And _
                            devtoadd.Model = devlist(i).Model Then
                            isduplicate = True
                        End If
                    Next

                    If Not isduplicate Then
                        devlist.Add(devtoadd)
                    End If
                End If
                devtoadd = Nothing
            Next
        End If

        'then devices under a LSI controller...
        If Not IsNothing(lsidevices) Then
            PrintDebug("*** Adding LSI devices ***", False, True)
            For d As Integer = 0 To lsidevices.Count - 1
                Dim lsidevice As New Device(lsidevices(d), DeviceType.ATA)
                If Not lsidevice.IsOptical Then
                    devlist.Add(lsidevice)
                End If
                lsidevice = Nothing
            Next
        End If

        'then devices under a Dell PERC H200 controller...
        If Not IsNothing(delldevices) Then
            PrintDebug("*** Adding Dell PERC H200 devices ***", False, True)
            For d As Integer = 0 To delldevices.Count - 1
                'note that on PERC H200 can be connected SCSI and ATA devices!
                If delldevices(d).Contains("-d scsi") Then
                    Dim delldevice As New Device(delldevices(d), DeviceType.SCSI)
                    If Not delldevice.IsOptical Then devlist.Add(delldevice)
                    delldevice = Nothing
                Else
                    Dim delldevice As New Device(delldevices(d), DeviceType.ATA)
                    If Not delldevice.IsOptical Then devlist.Add(delldevice)
                    delldevice = Nothing
                End If
            Next
        End If

        'then devices under Windows 8 Storage Spaces Controller...
        If Not IsNothing(win8devices) Then
            PrintDebug("*** Adding Windows 8 Storage Spaces Controller devices ***", False, True)
            For d As Integer = 0 To win8devices.Count - 1
                devlist.Add(New Device(win8devices(d), DeviceType.ATA))
            Next
        End If

        'then SCSI devices...
        If Not IsNothing(scsidevices) Then
            PrintDebug("*** Adding SCSI devices ***", False, True)
            For d As Integer = 0 To scsidevices.Count - 1
                PrintDebug("Adding " & scsidevices(d))
                Dim scsidevice As New Device(scsidevices(d), DeviceType.SCSI)
                If scsidevice.IsDisk Then
                    PrintDebug("Adding to devices list " & scsidevice.Location)
                    devlist.Add(scsidevice)
                End If
                scsidevice = Nothing
            Next
        End If

        'then add usb devices...
        If Not IsNothing(usbdevices) Then
            PrintDebug("*** Adding USB devices ***", False, True)
            For d As Integer = 0 To usbdevices.Count - 1
                If Not IsNothing(usbdevices(d)) Then
                    PrintDebug("Adding " & usbdevices(d))
                    Dim usb As New Device(usbdevices(d), DeviceType.USB)
                    If usb.IsDoubleDeck Then
                        PrintDebug("Detected double docking station device", False, True)

                        Dim p_0 As New Device(usbdevices(d) & ",0", DeviceType.USB, False)
                        Dim skip_0 As Boolean = False

                        For i As Short = 0 To devlist.Count - 1
                            If p_0.Model = devlist(i).Model And p_0.SerialNumber = devlist(i).SerialNumber Then
                                skip_0 = True
                                Exit For
                            End If
                        Next

                        If Not skip_0 Then
                            PrintDebug("Adding " & p_0.Model & " (" & p_0.SerialNumber & ")")
                            If p_0.IsValidDevice Then devlist.Add(New Device(usbdevices(d) & ",0", DeviceType.USB))
                        Else
                            PrintDebug("Device " & p_0.Model & " (" & p_0.SerialNumber & ") already in list, skipping...")
                            Dim p_1 As New Device(usbdevices(d) & ",1", DeviceType.USB, False)
                            Dim skip_1 As Boolean = False

                            For i As Short = 0 To devlist.Count - 1
                                If p_1.Model = devlist(i).Model And p_1.SerialNumber = devlist(i).SerialNumber Then
                                    skip_1 = True
                                    Exit For
                                End If
                            Next

                            If Not skip_1 Then
                                PrintDebug("Adding " & p_1.Model & " (" & p_1.SerialNumber & ")")
                                If p_1.IsValidDevice Then devlist.Add(New Device(usbdevices(d) & ",1", DeviceType.USB))
                            End If

                            p_1 = Nothing
                        End If

                        p_0 = Nothing
                    Else
                        If usb.IsValidDevice Then devlist.Add(usb)
                    End If
                    usb = Nothing
                End If
            Next
        End If

        'adding additional devices, like devices behind an ARECA controller...
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\additional.xml") Then
            PrintDebug("*** Adding additional devices ***", False, True)
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            m_xmldoc.Load(My.Application.Info.DirectoryPath & "\additional.xml")
            m_nodelist = m_xmldoc.SelectNodes("/devices/device")

            For Each m_node In m_nodelist
                Dim desc As String = m_node.Attributes.GetNamedItem("description").Value
                Dim cmd As String = m_node.Attributes.GetNamedItem("command").Value
                Dim additional As New Device(desc, cmd, False)

                If additional.IsValidDevice Then
                    PrintDebug("Adding " & additional.Model & " (" & additional.SerialNumber & ")")
                    devlist.Add(New Device(desc, cmd))
                End If

                additional = Nothing
            Next
        End If

        'then, finally, add virtual devices (files)
        Dim virtualfolder As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData _
                                      .Substring(0, My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.LastIndexOf("\")) _
                                      & "\Virtual devices\"

        If IO.Directory.Exists(virtualfolder) Then
            PrintDebug("*** Adding virtual devices ***", False, True)
            If IO.Directory.EnumerateFiles(virtualfolder, "*.vd").Count = 0 Then Exit Sub
            For Each file As String In IO.Directory.GetFiles(virtualfolder, "*.vd")
                PrintDebug("Loading " & file.ToString.Replace(virtualfolder, ""))
                Dim content() As String = IO.File.ReadAllLines(file)
                devlist.Add(New Device(content(0), DeviceType.Virtual))
                Dim vd As Device = devlist(devlist.Count - 1)
                Dim vdi As VirtualDeviceInfo
                With vdi
                    .Description = content(1)
                    .Model = content(2)
                    .UserSize = content(3)
                    .SerialNumber = content(4)
                    .Firmware = content(5)
                End With
                vd.VirtualDeviceInfo = vdi
            Next
        End If

        'if no devices are founded on system, display a message and then exits from application...
        If IsNothing(devlist) Then
            'display a warning when administration rights are missed
            If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                MsgBox(GetString(4507), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetString(4506))
            End If
            MsgBox(m_nodevices, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, m_error)

            niTrayIcon.Visible = False
            StopMonitorDeviceConnection()
            Me.Dispose()
            End
        End If
    End Sub

    Private Sub FillDevicesList()
        PrintDebug("Populating devices overview")
        'listview item scheme
        '
        'ColHead    |Name  |Temp        |Life          | Type       | Size
        '           -------------------------------------------------------------
        'Item       |model |temperature |remainig life |device type | device size
        'Tag        |      |            |              |            |
        '
        'each string is colored differently: model string color is related to device health,
        'temperature and remainig life strings color are related to three different ranges

        Dim HealthImages As New ImageList
        With HealthImages
            .ColorDepth = ColorDepth.Depth32Bit
            .Images.Add(My.Resources.failed_never)
            .Images.Add(My.Resources.failed_unknown)
            .Images.Add(My.Resources.failed_now)
            .Images.Add(My.Resources.failed_inthepast)
        End With


        With lvwDevices
            .Items.Clear()
            .SmallImageList = HealthImages

            For Each dev As Device In devlist
                If dev.Type = DeviceType.ATA Or dev.Type = DeviceType.SCSI Then
                    Dim lvi As New ListViewItem(dev.Model, .Groups(0))
                    .Items.Add(lvi)
                ElseIf dev.Type = DeviceType.Virtual Then
                    Dim lvi As New ListViewItem(dev.Model, .Groups(2))
                    .Items.Add(lvi)
                Else 'device is sure a removable one...
                    Dim lvi As New ListViewItem(dev.Model, .Groups(1))
                    .Items.Add(lvi)
                End If

                Dim i As Integer = .Items.Count - 1
                .Items(i).UseItemStyleForSubItems = False

                If dev.InDatabase Then
                    Select Case dev.ReliabilityRating.Overall
                        Case 4 To 5
                            .Items(i).ImageIndex = 0
                        Case 2 To 3
                            .Items(i).ImageIndex = 3
                        Case 1
                            .Items(i).ImageIndex = 2
                        Case Else
                            .Items(i).ImageIndex = 1
                    End Select
                    If dev.Health = Status.Failed Then .Items(i).ImageIndex = 2
                Else 'here are rated unknown SATA and SCSI devices
                    Select Case dev.Health
                        Case Status.Unkonwn
                            .Items(i).ImageIndex = 1
                        Case Status.Failed
                            .Items(i).ImageIndex = 2
                        Case Status.Passed
                            .Items(i).ImageIndex = 0
                    End Select
                End If

                If IsNumeric(dev.Temperature) Then
                    If My.Settings.TempFahrenheit = True Then
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

                If IsNumeric(dev.RemainingLife) Then
                    .Items(i).SubItems.Add(Val(dev.RemainingLife) & "%")
                    Select Case Val(dev.RemainingLife)
                        Case 0
                            .Items(i).SubItems(2).ForeColor = life_out
                        Case 1 To 10
                            .Items(i).SubItems(2).ForeColor = life_low
                        Case Is > 10
                            .Items(i).SubItems(2).ForeColor = life_ok
                    End Select
                Else
                    .Items(i).SubItems.Add(dev.RemainingLife)
                    .Items(i).SubItems(2).ForeColor = Color.DarkGray
                End If

                .Items(i).SubItems.Add(dev.DeviceInterface)

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
                    .Items(i).SubItems.Add(iec & " / " & si)
                Else
                    .Items(i).SubItems.Add(dev.UserCapacity)
                End If

                If dev.Type = DeviceType.Virtual Then
                    If Not IO.File.Exists(dev.Location) Then
                        Dim size As String = ""
                        With dev.VirtualDeviceInfo
                            Dim s() As String = .UserSize.Split("bytes")
                            For c As Integer = 0 To s(0).Length - 1
                                If IsNumeric(s(0).Chars(c)) Then size = size & s(0).Chars(c)
                            Next
                            If IsNumeric(size) Then
                                Dim iec As String
                                If Val(size / 1024 ^ 3) > 1000 Then
                                    iec = Format(Val(size / 1024 ^ 4), "#.#") & " TiB"
                                Else
                                    iec = Format(Val(size / 1024 ^ 3), "#,###") & " GiB"
                                End If
                                Dim si As String
                                If Val(size / 1000 ^ 3) > 1000 Then
                                    si = Format(Val(size / 1000 ^ 4), "#.#") & " TB"
                                Else
                                    si = Format(Val(size / 1000 ^ 3), "#,###") & " GB"
                                End If
                                size = iec & " / " & si
                            Else
                                size = .UserSize
                            End If
                        End With
                        .Items(i).SubItems(4).Text = size
                    End If
                End If
            Next

            .Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            .Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            .Columns(3).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            .Columns(3).Width = .Columns(3).Width + 10
            .Columns(4).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)

            .Items(0).Selected = True

            .Groups(0).Header = .Groups(0).Tag & " - " & .Groups(0).Items.Count
            .Groups(1).Header = .Groups(1).Tag & " - " & .Groups(1).Items.Count
            .Groups(2).Header = .Groups(2).Tag & " - " & .Groups(2).Items.Count

            SetWindowTheme(.Handle, "explorer", Nothing)
        End With

        cboTest.SelectedIndex = 0
    End Sub

    Private Sub PopulateCapabilities()
        'Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)
        'With clCapabilities
        '.Clear()
        'For i As Short = 0 To dev.Capabilities.Count - 1
        '.Add(dev.Capabilities(i).Name, _
        'dev.Capabilities(i).Value, _
        'dev.Capabilities(i).Meaning)
        'Next
        'End With
    End Sub

    'the following sub is public because is called when a virtual device is added
    'from the dialog box
    Public Sub UpdateAll(ByVal type As DeviceType)
        Dim updateview As Boolean = False

        With lvwDevices
            'update devices smartctl output
            For Each dev As Device In devlist
                If dev.Type = type Then
                    dev.Update()
                    'this boolean variable checks if they're some
                    'devices of selected type
                    updateview = True
                End If
            Next

            If updateview = True Then
                For i As Short = 0 To .Items.Count - 1
                    If devlist(i).Type = type Then
                        OverviewUpdate(i)
                    End If
                Next

                'check if the currently displayed device is of the type
                'that are currently updated
                If devlist(.SelectedItems(0).Index).Type = type Then
                    DisplayWarnings()
                    SendNotificationMail()
                    ShareOutput()
                End If

                'and now, from 0.4.0.0, export a Xml report!
                If My.Settings.ExportToXml And IO.Directory.Exists(My.Settings.XmlFolder) Then
                    ExportToXml()
                End If
            End If
        End With
    End Sub

    Public Sub UpdateCurrent()
        With lvwDevices
            Dim i As Short = .SelectedItems(0).Index

            devlist(i).Update()

            'update color of device name
            OverviewUpdate(i)

            'PopulateAtaPanels()
            DisplayWarnings()
            SendNotificationMail()
            ShareOutput()
        End With
    End Sub

    Public Sub OverviewUpdate(ByVal i As Integer)
        With lvwDevices
            'update device icon
            If devlist(i).InDatabase Then
                Select Case devlist(i).ReliabilityRating.Overall
                    Case 4 To 5
                        .Items(i).ImageIndex = 0
                    Case 2 To 3
                        .Items(i).ImageIndex = 3
                    Case 1
                        .Items(i).ImageIndex = 2
                    Case Else
                        .Items(i).ImageIndex = 1
                End Select
                If devlist(i).Health = Status.Failed Then .Items(i).ImageIndex = 2
            Else 'here are rated unknown SATA and SCSI devices
                Select Case devlist(i).Health
                    Case Status.Unkonwn
                        .Items(i).ImageIndex = 1
                    Case Status.Failed
                        .Items(i).ImageIndex = 2
                    Case Status.Passed
                        .Items(i).ImageIndex = 0
                End Select
            End If

            'update device temperatures and colors
            If IsNumeric(devlist(i).Temperature) Then
                If My.Settings.TempFahrenheit = True Then
                    .Items(i).SubItems(1).Text = Math.Round(devlist(i).Temperature * 1.8 + 32) & "°F"
                Else
                    .Items(i).SubItems(1).Text = devlist(i).Temperature & "°C"
                End If
                Select Case Val(devlist(i).Temperature)
                    Case 0 To 49
                        .Items(i).SubItems(1).ForeColor = temp_ok
                    Case 50 To 54
                        .Items(i).SubItems(1).ForeColor = temp_high
                    Case Is >= 55
                        .Items(i).SubItems(1).ForeColor = temp_alarm
                End Select
            Else
                .Items(i).SubItems(1).Text = devlist(i).Temperature
                .Items(i).SubItems(1).ForeColor = Color.DarkGray
            End If
            'update device remaining health and colors
            If IsNumeric(devlist(i).RemainingLife) Then
                .Items(i).SubItems(2).Text = Val(devlist(i).RemainingLife) & "%"
                Select Case Val(devlist(i).RemainingLife)
                    Case 0
                        .Items(i).SubItems(2).ForeColor = life_out
                    Case 1 To 10
                        .Items(i).SubItems(2).ForeColor = life_low
                    Case Is > 10
                        .Items(i).SubItems(2).ForeColor = life_ok
                End Select
            Else
                .Items(i).SubItems(2).Text = devlist(i).RemainingLife
                .Items(i).SubItems(2).ForeColor = Color.DarkGray
            End If

        End With
    End Sub

    Private Sub ShareOutput()
        PrintDebug("Start sharing output")

        Dim outputfolder = My.Settings.SharingFolder

        If IO.Directory.Exists(outputfolder) Then
            For i As Short = 0 To devlist.Count - 1
                Dim dev As Device = devlist(i)
                If dev.Type = DeviceType.ATA And dev.IsShared = True Then
                    PrintDebug("Generating report: " & dev.Model & " (" & dev.SerialNumber & ")")

                    IO.File.WriteAllText(outputfolder & "\" & dev.Model & "_" & dev.SerialNumber & ".txt", dev.Output)
                End If
            Next
        End If

        PrintDebug("End sharing output")
    End Sub

    Public Sub FillManageDeviceList()
        cboDevices.Items.Clear()

        For i As Short = 0 To devlist.Count - 1
            cboDevices.Items.Add(devlist(i))

            cboDevices.SelectedIndex = 0
            InvokeOnClick(robInfo, Nothing)
        Next
    End Sub

End Class
