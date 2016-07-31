'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2016 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Management
Imports System.ComponentModel
Imports System.Xml
Imports System.Threading.Tasks
Imports System.Runtime.InteropServices

Public Structure ControllerData
    Dim Name, Tester, Bridge As String
    Dim AllowScsi As Boolean
End Structure

Partial Class Main
    Public atadevices() As String
    Public satdevices() As String
    Public usbdevices() As String
    Public csmidevices() As String
    Public scsidevices() As String

    Public arecadevices() As String
    Public raiddevices() As String
    Public raidcontrollers As New List(Of ControllerData)

    Public devlist As New List(Of Device)
    Public scsicontrollers As New Collection
    Public raid As New RaidControllers
    Public asmedia As Boolean = DetectASMedia()

    Private Sub LoadRaidControllers()
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\controllers.xml") Then
            PrintDebug("*** Loading RAID controllers list ***", False, True)
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            m_xmldoc.Load(My.Application.Info.DirectoryPath & "\controllers.xml")
            m_nodelist = m_xmldoc.SelectNodes("/controllers/controller")

            raidcontrollers.Clear()

            For Each m_node In m_nodelist
                Dim c As New ControllerData
                c.Name = m_node.Attributes.GetNamedItem("name").Value
                c.Tester = m_node.Attributes.GetNamedItem("tester").Value
                c.Bridge = m_node.Attributes.GetNamedItem("bridge").Value
                c.AllowScsi = m_node.Attributes.GetNamedItem("allowscsi").Value
                raidcontrollers.Add(c)
                c = Nothing
            Next

            PrintDebug("Loaded RAID controllers: " & raidcontrollers.Count)
        End If
    End Sub

    Private Sub GatherScsiControllers()
        Dim win32_scsicontroller As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_SCSIController")

        scsicontrollers.Clear()

        For Each scsi As ManagementObject In win32_scsicontroller.Get()
            scsicontrollers.Add(scsi("Name").ToString.Trim)
        Next

    End Sub

    Private Function DetectASMedia() As Boolean
        Dim win32_scsicontroller As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_SCSIController")

        For Each ide As ManagementObject In win32_scsicontroller.Get()
            If ide("Name").ToString.Trim = "Asmedia 106x SATA Controller" Then Return True
        Next

        Return False
    End Function

    Private Sub Search()
        Dim smartctl As New Console
        PrintDebug("*** Searching devices ***", False, True)
        PrintDebug("Searching Intel Matrix devices...")

        'collect devices under Intel Matrix using command "--scan -d csmi"
        If AppSettings.Detection.Csmi Then
            Dim csmiscan() As String = smartctl.SendCmd("--scan -d csmi")
            Dim csmicount As Short = 0
            For i As Integer = 0 To csmiscan.Count - 2 'the last item is an empty line
                If InStr(csmiscan(i), "/dev/csmi") < InStr(csmiscan(i), "#") And InStr(csmiscan(i), "/dev/csmi") >= 0 Then
                    Dim matrix As String() = csmiscan(i).Split("#")
                    'add matrix devices only if are not optical (CD/DVD)
                    Dim d As New Device(matrix(0).Replace(vbCr, "").Replace(vbLf, ""), DeviceType.ATA, False)
                    If Not d.IsOptical And d.IsValid Then
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
        'the "-d ata" and "-d sat" option at the end collect only fixed (non removable, like usb) devices
        Dim scan() As String = smartctl.SendCmd("--scan -d ata")
        Dim atacount As Short = 0
        For i As Integer = 0 To scan.Count - 2 'the last item is an empty line
            If InStr(scan(i), "/dev/sd") < InStr(scan(i), "#") And InStr(scan(i), "/dev/sd") >= 0 Then
                Dim dev As String() = scan(i).Split("#")
                'add devices only if valid devices
                Dim d As New Device(dev(0).Replace(vbCr, "").Replace(vbLf, ""), DeviceType.ATA, False)
                If d.IsValid Then
                    ReDim Preserve atadevices(atacount)
                    atadevices(atacount) = dev(0).Replace(vbCr, "").Replace(vbLf, "")
                    atacount += 1
                End If
                d = Nothing
            End If
        Next

        Dim satscan() As String = smartctl.SendCmd("--scan -d sat")
        Dim satcount As Short = 0
        For i As Integer = 0 To satscan.Count - 2 'the last item is an empty line
            If InStr(satscan(i), "/dev/sd") < InStr(satscan(i), "#") And InStr(satscan(i), "/dev/sd") >= 0 Then
                Dim dev As String() = satscan(i).Split("#")
                'add devices only if valid devices
                Dim d As New Device(dev(0).Replace(vbCr, "").Replace(vbLf, ""), DeviceType.ATA, False)
                If d.IsValid Then
                    ReDim Preserve satdevices(satcount)
                    satdevices(satcount) = dev(0).Replace(vbCr, "").Replace(vbLf, "")
                    satcount += 1
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
                    If usbscan(i).Contains("ATA device") Then 'this avoid to display some devices like the storage of a Vodafone Internet Key
                        ReDim Preserve usbdevices(i)
                        Dim usbdev As String() = usbscan(i).Split("#")
                        usbdevices(i) = usbdev(0).Replace(vbCr, "").Replace(vbLf, "").Trim
                    End If
                End If
            Next
        End If

        If Not IsNothing(usbdevices) Then PrintDebug("Devices found: " & usbdevices.Count, False, True) Else PrintDebug("No USB devices found", False, True)

        '********************************************* RAID controllers section *********************************************
        LoadRaidControllers()
        raid.Gather()

        If raid.ControllersCount > 0 Then
            Dim ac_count As Short = 0 'areca controllers counter
            Dim ad_count As Short = 0 'areca devices counter

            For i As Short = 0 To raid.ControllersCount - 1
                If raid.ControllerName(i).ToLower.StartsWith("areca") Then
                    PrintDebug("Detected an Areca controller")
                    'Areca controller detected
                    If raid.ControllerName(i).ToLower.Contains("sata raid") Then
                        PrintDebug("Entering Areca SATA RAID routine")
                        'Areca SATA RAID controller
                        Dim c As Short = ac_count

                        For n As Short = 1 To AppSettings.Areca.SataDevices
                            Dim areca As New Device("-d areca," & n & " /dev/arcmsr" & c, DeviceType.ATA, False)

                            PrintDebug("Checking -d areca," & n & " /dev/arcmsr" & c)

                            If areca.IsValid Then
                                ReDim Preserve arecadevices(ad_count)
                                PrintDebug("Adding to list -d areca," & n & " /dev/arcmsr" & c)
                                arecadevices(ad_count) = "-d areca," & n & " /dev/arcmsr" & c
                                ad_count += 1
                                areca = Nothing
                            Else
                                areca = Nothing
                                Exit For
                            End If
                        Next

                        ac_count += 1

                    ElseIf raid.ControllerName(i).ToLower.Contains("sas raid") Then
                        PrintDebug("Entering Areca SAS RAID routine")
                        'Areca SAS RAID controller
                        Dim c As Short = ac_count

                        For e As Short = 1 To 8
                            Dim ntot As Short = 0

                            Select Case e
                                Case 1
                                    ntot = AppSettings.Areca.SasEnclosure1
                                Case 2
                                    ntot = AppSettings.Areca.SasEnclosure2
                                Case 3
                                    ntot = AppSettings.Areca.SasEnclosure3
                                Case 4
                                    ntot = AppSettings.Areca.SasEnclosure4
                                Case 5
                                    ntot = AppSettings.Areca.SasEnclosure5
                                Case 6
                                    ntot = AppSettings.Areca.SasEnclosure6
                                Case 7
                                    ntot = AppSettings.Areca.SasEnclosure7
                                Case 8
                                    ntot = AppSettings.Areca.SasEnclosure8
                            End Select
                            PrintDebug("Selected enclosure " & e & " with " & ntot & " possible devices")

                            If ntot > 0 Then
                                For n As Short = 1 To ntot
                                    Dim areca As New Device("-d areca," & n & "/" & e & " /dev/arcmsr" & c, DeviceType.ATA, False)

                                    PrintDebug("Checking -d areca," & n & "/" & e & " /dev/arcmsr" & c)

                                    If areca.IsValid Then
                                        ReDim Preserve arecadevices(ad_count)
                                        PrintDebug("Adding -d areca," & n & "/" & e & " /dev/arcmsr" & c)
                                        arecadevices(ad_count) = "-d areca," & n & "/" & e & " /dev/arcmsr" & c
                                        ad_count += 1
                                        areca = Nothing
                                    Else
                                        areca = Nothing
                                        Exit For
                                    End If
                                Next
                            Else
                                PrintDebug("Skipped enclosure " & e & " (" & ntot & " possible devices)")
                            End If
                        Next

                        ac_count += 1

                    End If
                    If Not IsNothing(arecadevices) Then PrintDebug("Total Areca connected devices: " & arecadevices.Count)
                Else
                    'non-Areca controllers
                    PrintDebug("Entering standard RAID routine")
                    For c As Short = 0 To raidcontrollers.Count - 1
                        If raid.ControllerName(i).Contains(raidcontrollers(c).Name) Then
                            PrintDebug("Detected '" & raidcontrollers(c).Name & "' controller (SCSI allowed: " &
                                       raidcontrollers(c).AllowScsi & "; bridge type: " & raidcontrollers(c).Bridge & ")")

                            Dim allowscsi As Boolean = raidcontrollers(c).AllowScsi
                            Dim layer As String = raidcontrollers(c).Bridge
                            Dim raidscan() As String = smartctl.SendCmd("--scan -d scsi")
                            For r As Integer = 0 To raidscan.Count - 2 'the last item is an empty line
                                If InStr(raidscan(r), "/dev/sd") < InStr(raidscan(r), "#") And InStr(raidscan(r), "/dev/sd") >= 0 Then
                                    Dim raidcmd As String() = raidscan(r).Split("#")

                                    PrintDebug("Checking " & raidscan(r))

                                    If allowscsi Then
                                        Dim raid As New Device(raidcmd(0).Trim.Replace(vbCr, "").Replace(vbLf, ""), DeviceType.SCSI, False)
                                        If raid.Scsi.Info.Product = "N/A" Then
                                            ReDim Preserve raiddevices(r)
                                            raiddevices(r) = raidcmd(0).Replace("-d scsi", layer).Trim.Replace(vbCr, "").Replace(vbLf, "")
                                            PrintDebug("Adding " & raidcmd(0).Replace("-d scsi", layer).Trim.Replace(vbCr, "").Replace(vbLf, ""))
                                        Else
                                            ReDim Preserve raiddevices(r)
                                            raiddevices(r) = raidcmd(0).Replace(vbCr, "").Replace(vbLf, "")
                                            PrintDebug("Adding " & raidcmd(0).Replace(vbCr, "").Replace(vbLf, ""))
                                        End If
                                    Else
                                        ReDim Preserve raiddevices(r)
                                        raiddevices(r) = raidcmd(0).Replace("-d scsi", layer).Trim.Replace(vbCr, "").Replace(vbLf, "")
                                        PrintDebug("Adding " & raidcmd(0).Replace("-d scsi", layer).Trim.Replace(vbCr, "").Replace(vbLf, ""))
                                    End If
                                    raidcmd = Nothing
                                End If
                            Next
                        End If
                    Next
                    If Not IsNothing(raiddevices) Then PrintDebug("Total RAID connected devices: " & raiddevices.Count)
                End If
            Next

        End If

        PrintDebug("Searching SCSI devices...")
        'add also SCSI devices, but only if a RAID controller
        'are not detected and CSMI device list is empty
        Dim isunknown As Boolean = True
        If raid.ControllersCount > 0 Then
            For i As Short = 0 To raid.ControllersCount - 1
                For c As Short = 0 To raidcontrollers.Count - 1
                    If raid.ControllerName(i).Contains(raidcontrollers(c).Name) Then
                        isunknown = False
                        Exit For
                    End If
                Next
                If Not isunknown Then Exit For
            Next
        End If
        If isunknown And IsNothing(csmidevices) And raid.ControllersCount > 0 Then

            Dim scsiscan() As String = smartctl.SendCmd("--scan -d scsi")
            Dim scsicount As Short = 0
            For i As Integer = 0 To scsiscan.Count - 2 'the last item is an empty line
                If InStr(scsiscan(i), "/dev/sd") < InStr(scsiscan(i), "#") And InStr(scsiscan(i), "/dev/sd") >= 0 Then
                    Dim scsidev As String() = scsiscan(i).Split("#")
                    Dim d As New Device(scsidev(0).Replace(vbCr, "").Replace(vbLf, ""), DeviceType.SCSI, False)
                    If d.IsValid Then
                        ReDim Preserve scsidevices(scsicount)
                        scsidevices(scsicount) = scsidev(0).Replace(vbCr, "").Replace(vbLf, "")
                        scsicount += 1
                    End If
                    d = Nothing
                End If
            Next
        End If
        If Not IsNothing(scsidevices) Then PrintDebug("Devices found: " & scsidevices.Count, False, True) Else PrintDebug("No SCSI devices found", False, True)

        'if no devices are found on system, display a message and then exits from application...
        If IsNothing(atadevices) And IsNothing(satdevices) And IsNothing(csmidevices) And IsNothing(scsidevices) _
            And IsNothing(raiddevices) And IsNothing(arecadevices) And IsNothing(scsidevices) Then

            'display a warning when administration rights are missed
            If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                MsgBox(GetString(4507), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetString(4506))
            End If

            MsgBox(m_nodevices, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, m_error)

            niTrayIcon.Visible = False
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
                If Not matrixdevice.IsOptical And matrixdevice.IsValid Then
                    devlist.Add(matrixdevice)
                End If
                matrixdevice = Nothing
            Next
            csmidevices = Nothing
        End If

        'then devices under a RAID controller...
        If Not IsNothing(raiddevices) Then
            PrintDebug("*** Adding RAID devices ***", False, True)
            For d As Integer = 0 To raiddevices.Count - 1
                'note that on PERC H200 can be connected SCSI and ATA devices!
                If raiddevices(d).Contains("-d scsi") Then
                    Dim raiddevice As New Device(raiddevices(d), DeviceType.SCSI)
                    Dim isduplicate As Boolean = False
                    For i As Integer = 0 To devlist.Count - 1
                        'check if the serial number and the device model are already in list:
                        'you can have the same model but not the same serial number or
                        'the same serial number but a different model...
                        If devlist(i).Type = DeviceType.SCSI Then
                            If raiddevice.Scsi.Info.SerialNumber = devlist(i).Scsi.Info.SerialNumber And
                                    raiddevice.Scsi.Info.Product = devlist(i).Scsi.Info.Product Then
                                isduplicate = True
                            End If
                        End If
                    Next

                    If Not isduplicate And Not raiddevice.IsOptical And Not raiddevice.Scsi.Info.Product.Contains("COVECUBECoveFs") Then
                        devlist.Add(raiddevice)
                    End If

                    raiddevice = Nothing
                Else
                    Dim raiddevice As New Device(raiddevices(d), DeviceType.ATA)
                    Dim isduplicate As Boolean = False
                    For i As Integer = 0 To devlist.Count - 1
                        'check if the serial number and the device model are already in list:
                        'you can have the same model but not the same serial number or
                        'the same serial number but a different model...
                        If devlist(i).Type <> DeviceType.SCSI Then
                            If raiddevice.ATA.Info.SerialNumber = devlist(i).ATA.Info.SerialNumber And
                                    raiddevice.ATA.Info.Model = devlist(i).ATA.Info.Model Then
                                isduplicate = True
                            End If
                        End If

                    Next

                    If Not isduplicate And Not raiddevice.IsOptical And Not raiddevice.ATA.Info.Model.Contains("COVECUBECoveFs") Then
                        devlist.Add(raiddevice)
                    End If
                    raiddevice = Nothing
                End If
            Next
            raiddevices = Nothing
        End If

        'then, the normal ATA devices: it check also if a device is already listed with the Intel Matrix system, added with previous RAID block
        If Not IsNothing(atadevices) Then
            PrintDebug("*** Adding ATA devices ***", False, True)
            For d As Integer = 0 To atadevices.Count - 1
                PrintDebug("Adding " & atadevices(d))
                Dim devtoadd As New Device(atadevices(d), DeviceType.ATA, False)
                'devtoadd.Update()
                Dim isduplicate As Boolean = False
                If devtoadd.IsValid Then
                    For i As Integer = 0 To devlist.Count - 1
                        'check if the serial number and the device model are already in list:
                        'you can have the same model but not the same serial number or
                        'the same serial number but a different model...
                        If devlist(i).Type <> DeviceType.SCSI Then
                            If devtoadd.ATA.Info.SerialNumber = devlist(i).ATA.Info.SerialNumber And
                                                        devtoadd.ATA.Info.Model = devlist(i).ATA.Info.Model Then
                                isduplicate = True
                            End If
                        End If

                    Next

                    If Not isduplicate And Not devtoadd.ATA.Info.Model.Contains("COVECUBECoveFs") Then
                        devlist.Add(New Device(atadevices(d), DeviceType.ATA))
                    End If
                End If
                devtoadd = Nothing
            Next
            atadevices = Nothing
        End If

        If Not IsNothing(satdevices) Then
            PrintDebug("*** Adding ATA (SAT) devices ***", False, True)
            For d As Integer = 0 To satdevices.Count - 1
                PrintDebug("Adding " & satdevices(d))
                Dim devtoadd As New Device(satdevices(d), DeviceType.ATA, False)
                'devtoadd.Update()
                Dim isduplicate As Boolean = False
                If devtoadd.IsValid Then
                    For i As Integer = 0 To devlist.Count - 1
                        'check if the serial number and the device model are already in list:
                        'you can have the same model but not the same serial number or
                        'the same serial number but a different model...
                        If devlist(i).Type <> DeviceType.SCSI Then
                            If devtoadd.ATA.Info.SerialNumber = devlist(i).ATA.Info.SerialNumber And
                                                        devtoadd.ATA.Info.Model = devlist(i).ATA.Info.Model Then
                                isduplicate = True
                            End If
                        End If
                    Next

                    If Not isduplicate And Not devtoadd.ATA.Info.Model.Contains("COVECUBECoveFs") Then
                        devlist.Add(New Device(satdevices(d), DeviceType.ATA))
                    End If
                End If
                devtoadd = Nothing
            Next
            satdevices = Nothing
        End If

        'then devices under Areca controllers...
        If Not IsNothing(arecadevices) Then
            PrintDebug("*** Adding devices under Areca controllers ***", False, True)
            For d As Integer = 0 To arecadevices.Count - 1
                devlist.Add(New Device(arecadevices(d), DeviceType.ATA))
            Next
            arecadevices = Nothing
        End If

        'then SCSI devices...
        If Not IsNothing(scsidevices) Then
            PrintDebug("*** Adding SCSI devices ***", False, True)
            For d As Integer = 0 To scsidevices.Count - 1
                PrintDebug("Adding " & scsidevices(d))
                Dim scsidevice As New Device(scsidevices(d), DeviceType.SCSI)
                If scsidevice.Scsi.IsScsiDisk And Not scsidevice.Scsi.Info.Product.Contains("COVECUBECoveFs") And Not scsidevice.Scsi.Info.Vendor.Contains("Areca") Then
                    PrintDebug("Adding to devices list " & scsidevice.Location)
                    devlist.Add(scsidevice)
                End If
                scsidevice = Nothing
            Next
            scsidevices = Nothing
        End If

        'then add usb devices...
        If Not IsNothing(usbdevices) Then
            PrintDebug("*** Adding USB devices ***", False, True)
            For d As Integer = 0 To usbdevices.Count - 1
                If Not IsNothing(usbdevices(d)) Then
                    PrintDebug("Adding " & usbdevices(d))
                    Dim usb As New Device(usbdevices(d), DeviceType.USB)
                    If usb.ATA.IsDoubleDeck Then
                        PrintDebug("Detected double docking station device", False, True)

                        Dim p_0 As New Device(usbdevices(d) & ",0", DeviceType.USB, False)
                        Dim skip_0 As Boolean = False

                        For i As Short = 0 To devlist.Count - 1
                            If devlist(i).Type <> DeviceType.SCSI Then
                                If p_0.ATA.Info.Model = devlist(i).ATA.Info.Model And p_0.ATA.Info.SerialNumber = devlist(i).ATA.Info.SerialNumber Then
                                    skip_0 = True
                                    Exit For
                                End If
                            End If
                        Next

                        If Not skip_0 Then
                            PrintDebug("Adding " & p_0.ATA.Info.Model & " (" & p_0.ATA.Info.SerialNumber & ")")
                            If p_0.IsValid Then devlist.Add(New Device(usbdevices(d) & ",0", DeviceType.USB))
                        Else
                            PrintDebug("Device " & p_0.ATA.Info.Model & " (" & p_0.ATA.Info.SerialNumber & ") already in list, skipping...")
                            Dim p_1 As New Device(usbdevices(d) & ",1", DeviceType.USB, False)
                            Dim skip_1 As Boolean = False

                            For i As Short = 0 To devlist.Count - 1
                                If p_1.ATA.Info.Model = devlist(i).ATA.Info.Model And p_1.ATA.Info.SerialNumber = devlist(i).ATA.Info.SerialNumber Then
                                    skip_1 = True
                                    Exit For
                                End If
                            Next

                            If Not skip_1 Then
                                PrintDebug("Adding " & p_1.ATA.Info.Model & " (" & p_1.ATA.Info.SerialNumber & ")")
                                If p_1.IsValid Then devlist.Add(New Device(usbdevices(d) & ",1", DeviceType.USB))
                            End If

                            p_1 = Nothing
                        End If

                        p_0 = Nothing
                    Else
                        If usb.IsValid Then devlist.Add(usb)
                    End If
                    usb = Nothing
                End If
            Next
            usbdevices = Nothing
        End If

        'adding additional devices that are not detected by smartctl or HDD Guardian...
        If AppSettings.Detection.Additional.Length > 0 Then
            Dim ad() As String = AppSettings.Detection.Additional.Split(",")
            For i As Short = 0 To ad.Count - 1
                If ad(i).Contains("[USB]") Then
                    Dim add_d As New Device(ad(i).Replace("[USB]", "").Trim, DeviceType.USB)
                    If add_d.IsValid Then devlist.Add(add_d)
                    add_d = Nothing
                ElseIf ad(i).Contains("scsi") Then
                    Dim add_d As New Device(ad(i).Trim, DeviceType.SCSI)
                    If add_d.Scsi.IsScsiDisk And Not add_d.Scsi.Info.Product.Contains("COVECUBECoveFs") And Not add_d.Scsi.Info.Vendor.Contains("Areca") And add_d.IsValid Then
                        devlist.Add(add_d)
                    End If
                    add_d = Nothing
                Else 'for sure an ATA...
                    Dim add_d As New Device(ad(i).Trim, DeviceType.ATA)
                    If Not add_d.Scsi.Info.Product.Contains("COVECUBECoveFs") And add_d.IsValid Then
                        devlist.Add(add_d)
                    End If
                    add_d = Nothing
                End If
            Next
        End If

        'then, finally, add virtual devices (files)
        LoadVirtual()

        If Not IsNothing(VirtualDevices) Then
            For i As Short = 0 To VirtualDevices.Count - 1
                devlist.Add(New Device(VirtualDevices(i).Path, DeviceType.ATA, False, True, VirtualDevices(i).Description))
            Next
        End If

        'if fail to detect devices on system, display a message and then exits from application...
        If IsNothing(devlist) Then
            'display a warning when administration rights are missed
            If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                MsgBox(GetString(4507), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetString(4506))
            End If
            MsgBox(m_nodevices, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, m_error)

            niTrayIcon.Visible = False
            Me.Dispose()
            End
        End If

        If AppSettings.Detection.Add3ware Then devlist.Add(New Device("", DeviceType.ThreeWare, False, True))
    End Sub

    Private Sub FillDevicesList()
        PrintDebug("Populating devices overview")

        Dim HealthImages As New ImageList
        With HealthImages
            .ImageSize = New Size(48, 48)
            .Images.Add(My.Resources.pc_office)
        End With

        With lvwDevices
            .Items.Clear()
            .SmallImageList = HealthImages

            For Each dev As Device In devlist
                If Not dev.IsVirtual Then
                    If dev.Type = DeviceType.ATA Then
                        Dim lvi As New ListViewItem(dev.ATA.Info.Model, .Groups(0))
                        .Items.Add(lvi)
                    ElseIf dev.Type = DeviceType.SCSI Then
                        Dim lvi As New ListViewItem(dev.Scsi.Info.Product, .Groups(0))
                        .Items.Add(lvi)
                    ElseIf dev.Type = DeviceType.USB Then
                        Dim lvi As New ListViewItem(dev.ATA.Info.Model, .Groups(1))
                        .Items.Add(lvi)
                    End If
                ElseIf dev.IsVirtual Or dev.Type = DeviceType.ThreeWare Then
                    If dev.Type = DeviceType.ATA Then
                        Dim lvi As New ListViewItem(dev.ATA.Info.Model, .Groups(2))
                        .Items.Add(lvi)
                    ElseIf dev.Type = DeviceType.SCSI Then
                        Dim lvi As New ListViewItem(dev.Scsi.Info.Product, .Groups(2))
                        .Items.Add(lvi)
                    End If
                End If

                Dim i As Integer = .Items.Count - 1
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
                            .Items(i).SubItems(2).ForeColor = temp_ok
                        Case 50 To 54
                            .Items(i).SubItems(2).ForeColor = temp_high
                        Case Is >= 55
                            .Items(i).SubItems(2).ForeColor = temp_alarm
                    End Select
                Else
                    .Items(i).SubItems.Add(dev.Temperature)
                    .Items(i).SubItems(2).ForeColor = Color.DarkGray
                End If


                If dev.Type = DeviceType.SCSI Then
                    .Items(i).SubItems.Add("-")
                    .Items(i).SubItems(3).ForeColor = Color.DarkGray

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
                    If IsNumeric(dev.ATA.Health.RemainingLife) Then
                        .Items(i).SubItems.Add(Val(dev.ATA.Health.RemainingLife) & "%")
                        Select Case Val(dev.ATA.Health.RemainingLife)
                            Case 0
                                .Items(i).SubItems(3).ForeColor = life_out
                            Case 1 To 10
                                .Items(i).SubItems(3).ForeColor = life_low
                            Case Is > 10
                                .Items(i).SubItems(3).ForeColor = life_ok
                        End Select
                    Else
                        .Items(i).SubItems.Add(dev.ATA.Health.RemainingLife)
                        .Items(i).SubItems(3).ForeColor = Color.DarkGray
                    End If

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
                        ElseIf dev.Scsi.SelfTestLog.Item(0).Status.Contains("Aborted") Then
                            .Items(i).SubItems.Add(GetString(431))
                            .Items(i).SubItems(7).ForeColor = status_warning
                        ElseIf dev.Scsi.SelfTestLog.Item(0).Status.Contains("Incomplete") Then
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
            Next

            .Items(0).Selected = True

            .Groups(0).Header = .Groups(0).Tag & " - " & .Groups(0).Items.Count
            .Groups(1).Header = .Groups(1).Tag & " - " & .Groups(1).Items.Count
            .Groups(2).Header = .Groups(2).Tag & " - " & .Groups(2).Items.Count

            SetWindowTheme(.Handle, "explorer", Nothing)

        End With

        optOffline.Checked = True
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

        'With lvwDevices
        'update devices smartctl output
        For Each dev As Device In devlist
            If dev.Type = type Then
                dev.Update()
                'this boolean variable checks if they're some
                'devices of selected type
                updateview = True
            End If
        Next

        'If updateview = True Then
        'For i As Short = 0 To lvwDevices.Items.Count - 1
        'If devlist(i).Type = type Then
        'OverviewUpdate(i)
        'End If
        'Next
        'End If

        'check if the currently displayed device is of the type
        'that are currently updated
        'If devlist(.SelectedItems(0).Index).Type = type Then
        'DisplayWarnings()
        'SendNotificationMail()
        'ShareOutput()
        'End If
        'End With
    End Sub

    Public Sub UpdateCurrent()
        With lvwDevices
            Dim i As Short = .SelectedItems(0).Index

            devlist(i).Update()

            OverviewUpdate(i)

            'PopulateAtaPanels()
            DisplayWarnings()
            SendNotificationMail()
            SoundNotification()
            PowerOff()
            ShareOutput()
        End With
    End Sub

    Public Sub OverviewUpdate(ByVal i As Integer)
        With lvwDevices
            'update last check
            .Items(i).SubItems(1).Text = devlist(i).LastUpdate

            'update device temperatures and colors
            If IsNumeric(devlist(i).Temperature) Then
                If AppSettings.General.TemperatureInFahrenheit = True Then
                    .Items(i).SubItems(2).Text = Math.Round(devlist(i).Temperature * 1.8 + 32) & "°F"
                Else
                    .Items(i).SubItems(2).Text = devlist(i).Temperature & "°C"
                End If
                Select Case Val(devlist(i).Temperature)
                    Case 0 To 49
                        .Items(i).SubItems(2).ForeColor = temp_ok
                    Case 50 To 54
                        .Items(i).SubItems(2).ForeColor = temp_high
                    Case Is >= 55
                        .Items(i).SubItems(2).ForeColor = temp_alarm
                End Select
            Else
                .Items(i).SubItems(2).Text = devlist(i).Temperature
                .Items(i).SubItems(2).ForeColor = Color.DarkGray
            End If


            If devlist(i).Type = DeviceType.SCSI Then
                .Items(i).SubItems(3).Text = "-"
                .Items(i).SubItems(3).ForeColor = Color.DarkGray

                'update grown defects
                If IsNumeric(devlist(i).Scsi.Health.GrownDefectsCount) Then
                    .Items(i).SubItems(4).Text = devlist(i).Scsi.Health.GrownDefectsCount
                    Select Case Val(devlist(i).Scsi.Health.GrownDefectsCount)
                        Case Is = 0
                            .Items(i).SubItems(4).ForeColor = status_ok
                        Case Else
                            .Items(i).SubItems(4).ForeColor = status_warning
                    End Select
                Else
                    .Items(i).SubItems(4).Text = devlist(i).Scsi.Health.GrownDefectsCount
                    .Items(i).SubItems(4).ForeColor = status_unknown
                End If
                'update non medium errors
                If IsNumeric(devlist(i).Scsi.Health.NonMediumErrors) Then
                    .Items(i).SubItems(5).Text = devlist(i).Scsi.Health.NonMediumErrors
                    Select Case Val(devlist(i).Scsi.Health.NonMediumErrors)
                        Case Is = 0
                            .Items(i).SubItems(5).ForeColor = status_ok
                        Case Is >= 1
                            .Items(i).SubItems(5).ForeColor = status_warning
                    End Select
                Else
                    .Items(i).SubItems(5).Text = devlist(i).Scsi.Health.NonMediumErrors
                    .Items(i).SubItems(5).ForeColor = status_unknown
                End If
            Else
                'update device remaining health and colors
                If IsNumeric(devlist(i).ATA.Health.RemainingLife) Then
                    .Items(i).SubItems(3).Text = Val(devlist(i).ATA.Health.RemainingLife) & "%"
                    Select Case Val(devlist(i).ATA.Health.RemainingLife)
                        Case 0
                            .Items(i).SubItems(3).ForeColor = life_out
                        Case 1 To 10
                            .Items(i).SubItems(3).ForeColor = life_low
                        Case Is > 10
                            .Items(i).SubItems(3).ForeColor = life_ok
                    End Select
                Else
                    .Items(i).SubItems(3).Text = devlist(i).ATA.Health.RemainingLife
                    .Items(i).SubItems(3).ForeColor = Color.DarkGray
                End If

                'update bad sectors
                If IsNumeric(devlist(i).ATA.Health.BadSectorsCount) Then
                    .Items(i).SubItems(4).Text = devlist(i).ATA.Health.BadSectorsCount
                    Select Case Val(devlist(i).ATA.Health.BadSectorsCount)
                        Case Is = 0
                            .Items(i).SubItems(4).ForeColor = status_ok
                        Case 1 To devlist(i).ATA.Health.BadSectorsThreshold
                            .Items(i).SubItems(4).ForeColor = status_warning
                        Case Is > devlist(i).ATA.Health.BadSectorsThreshold
                            .Items(i).SubItems(4).ForeColor = status_fail
                    End Select
                Else
                    .Items(i).SubItems(4).Text = devlist(i).ATA.Health.BadSectorsCount
                    .Items(i).SubItems(4).ForeColor = status_unknown
                End If
                'update total ata errors
                If IsNumeric(devlist(i).ATA.Errors.TotalAmount) Then
                    .Items(i).SubItems(5).Text = devlist(i).ATA.Errors.TotalAmount
                    Select Case Val(devlist(i).ATA.Errors.TotalAmount)
                        Case Is = 0
                            .Items(i).SubItems(5).ForeColor = status_ok
                        Case Is >= 1
                            .Items(i).SubItems(5).ForeColor = status_warning
                    End Select
                Else
                    .Items(i).SubItems(5).Text = devlist(i).ATA.Errors.TotalAmount
                    .Items(i).SubItems(5).ForeColor = status_unknown
                End If
            End If


            Select Case devlist(i).Health
                Case Status.Passed
                    .Items(i).SubItems(6).Text = GetString(430)
                    .Items(i).SubItems(6).ForeColor = status_ok
                Case Status.Failed
                    .Items(i).SubItems(6).Text = GetString(443)
                    .Items(i).SubItems(6).ForeColor = status_fail
                Case Status.Unknown
                    .Items(i).SubItems(6).Text = GetString(439)
                    .Items(i).SubItems(6).ForeColor = status_unknown
            End Select


            If devlist(i).Type = DeviceType.SCSI Then
                If devlist(i).Scsi.SelfTestLog.HasLog Then
                    If devlist(i).Scsi.SelfTestLog.Item(0).Status.Contains("Failed") Then
                        .Items(i).SubItems(7).Text = GetString(443)
                        .Items(i).SubItems(7).ForeColor = status_fail
                    ElseIf devlist(i).scsi.SelfTestLog.Item(0).Status.Contains("Aborted") Then
                        .Items(i).SubItems(7).Text = GetString(431)
                        .Items(i).SubItems(7).ForeColor = status_warning
                    ElseIf devlist(i).scsi.SelfTestLog.Item(0).Status.Contains("Incomplete") Then
                        .Items(i).SubItems(7).Text = GetString(442)
                        .Items(i).SubItems(7).ForeColor = status_warning
                    Else
                        .Items(i).SubItems(7).Text = GetString(430)
                        .Items(i).SubItems(7).ForeColor = status_ok
                    End If
                Else
                    .Items(i).SubItems(7).Text = "-"
                    .Items(i).SubItems(7).ForeColor = status_unknown
                End If
            Else
                Dim res As Short = Val(devlist(i).LastTestResult.Status)
                Select Case res
                    Case 0
                        .Items(i).SubItems(7).Text = GetString(430)
                        .Items(i).SubItems(7).ForeColor = status_ok
                    Case 1 To 2
                        .Items(i).SubItems(7).Text = GetString(430 + res)
                        .Items(i).SubItems(7).ForeColor = status_warning
                    Case 3 To 8
                        .Items(i).SubItems(7).Text = GetString(430 + res)
                        .Items(i).SubItems(7).ForeColor = status_fail
                    Case 15
                        .Items(i).SubItems(7).Text = GetString(439)
                        .Items(i).SubItems(7).ForeColor = status_fail
                    Case 24
                        .Items(i).SubItems(7).Text = GetString(440) & " (" & devlist(i).LastTestResult.Remaining & "%)"
                        .Items(i).SubItems(7).ForeColor = status_unknown
                    Case Else
                        .Items(i).SubItems(7).Text = GetString(441)
                        .Items(i).SubItems(7).ForeColor = status_unknown
                End Select
            End If

            If devlist(i).Type = DeviceType.ThreeWare Then
                If devlist(i).IsValid Then
                    FillManageDeviceList()
                Else
                    .Items(i).ImageIndex = 1
                    .Items(i).SubItems(1).Text = "[no data]"
                    .Items(i).SubItems(2).Text = "[no data]"
                    .Items(i).SubItems(2).ForeColor = Color.DarkGray
                    .Items(i).SubItems(3).Text = "[no data]"
                    .Items(i).SubItems(3).ForeColor = Color.DarkGray
                    .Items(i).SubItems(4).Text = "[no data]"
                    .Items(i).SubItems(4).ForeColor = Color.DarkGray
                    .Items(i).SubItems(5).Text = "[no data]"
                    .Items(i).SubItems(5).ForeColor = Color.DarkGray
                    .Items(i).SubItems(6).Text = "[no data]"
                    .Items(i).SubItems(6).ForeColor = Color.DarkGray
                    .Items(i).SubItems(7).Text = "[no data]"
                    .Items(i).SubItems(7).ForeColor = Color.DarkGray
                End If
            End If
        End With
    End Sub

    Private Sub ShareOutput()
        'PrintDebug("Start sharing output")

        Dim outputfolder = AppSettings.Sharing.OutputFolder

        If IO.Directory.Exists(outputfolder) Then
            For i As Short = 0 To devlist.Count - 1
                Dim dev As Device = devlist(i)
                If dev.Type = DeviceType.ATA And dev.IsShared = True Then
                    'PrintDebug("Generating report: " & dev.Model & " (" & dev.SerialNumber & ")")

                    IO.File.WriteAllText(outputfolder & "\" & dev.ATA.Info.Model & "_" & dev.ATA.Info.SerialNumber & ".txt", dev.Output)
                End If
            Next
        End If

        'PrintDebug("End sharing output")
    End Sub

    Public Sub FillManageDeviceList()
        cboDevices.Items.Clear()

        For i As Short = 0 To devlist.Count - 1
            cboDevices.Items.Add(devlist(i))
        Next

        cboDevices.SelectedIndex = 0
        InvokeOnClick(mrrAttributes, Nothing)
    End Sub

End Class
