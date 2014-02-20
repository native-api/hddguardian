'Toolbox is a tool for solving some HDD Guardian issues with unknown devices
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System
Imports System.Management
Imports System.ComponentModel

Public Class MainToolbox

#Region "Smartctl console with --scan option"
    Private Sub SmartctlScan()
        Dim prompt As New Console

        '╚╝═╔╗║

        btnConsoleSave.Enabled = False

        With txtConsole
            .Clear()
            .AppendText("╔═════════════════════════════════╗" & vbCrLf)
            .AppendText("║  Scan for internal ATA devices  ║" & vbCrLf)
            .AppendText("╚═════════════════════════════════╝" & vbCrLf)
            .AppendText("smartctl --scan -d ata" & vbCrLf)
            .AppendText(vbCrLf)

            Dim internal As String = prompt.SendCmd("--scan -d ata")
            .AppendText(internal)
            .AppendText(vbCrLf)

            Dim int_devices() As String = Nothing
            Dim int_arr() As String = internal.Split(vbCrLf)
            Dim d As Integer = -1
            For i As Integer = 0 To int_arr.Length - 2
                If int_arr(i).Contains("#") Then
                    d += 1
                    ReDim Preserve int_devices(d)
                    Dim dev As String() = int_arr(i).Split("#")
                    int_devices(d) = dev(0).Trim
                End If
            Next

            If Not IsNothing(int_devices) Then
                .AppendText("::: " & int_devices.Count & " internal devices detected :::" & vbCrLf)
                .AppendText(vbCrLf)

                For i As Short = 0 To int_devices.Length - 1
                    Dim name() As String = int_devices(i).Split(" ")
                    .AppendText("::: Scan device " & name(0) & " :::" & vbCrLf)
                    .AppendText("smartctl -a -g all -P use " & int_devices(i) & vbCrLf)
                    .AppendText(vbCrLf)
                    .AppendText(prompt.SendCmd("-a -d ata -g all -P use " & int_devices(i)))
                    .AppendText(vbCrLf)
                Next i
            Else
                .AppendText("::: no internal devices detected :::" & vbCrLf)
                .AppendText(vbCrLf)
            End If

            .AppendText("╔═════════════════════════════════╗" & vbCrLf)
            .AppendText("║  Scan for external USB devices  ║" & vbCrLf)
            .AppendText("╚═════════════════════════════════╝" & vbCrLf)
            .AppendText("smartctl --scan -d usb" & vbCrLf)
            .AppendText(vbCrLf)

            Dim external As String = prompt.SendCmd("--scan -d usb")
            .AppendText(external)
            .AppendText(vbCrLf)

            Dim ext_devices() As String = Nothing
            Dim ext_arr() As String = external.Split(vbCrLf)
            Dim de As Integer = -1
            For i As Integer = 0 To ext_arr.Length - 2
                If ext_arr(i).Contains("#") Then
                    de += 1
                    ReDim Preserve ext_devices(de)
                    Dim dev As String() = ext_arr(i).Split("#")
                    ext_devices(de) = dev(0).Trim
                End If
            Next

            If Not IsNothing(ext_devices) Then
                .AppendText("::: " & ext_devices.Count & " external devices detected :::" & vbCrLf)
                .AppendText(vbCrLf)

                For i As Short = 0 To ext_devices.Length - 1
                    Dim name() As String = ext_devices(i).Split(" ")
                    .AppendText("::: Scan device " & name(0) & " :::" & vbCrLf)
                    .AppendText("smartctl -a -g all -P use " & ext_devices(i) & vbCrLf)
                    .AppendText(vbCrLf)
                    .AppendText(prompt.SendCmd("-a -g all -P use " & ext_devices(i)))
                    .AppendText(vbCrLf)
                Next i

            Else
                .AppendText("::: no external devices detected :::" & vbCrLf)
                .AppendText(vbCrLf)
            End If


            .AppendText("╔═════════════════════════════════╗" & vbCrLf)
            .AppendText("║      Scan for SCSI devices      ║" & vbCrLf)
            .AppendText("╚═════════════════════════════════╝" & vbCrLf)
            .AppendText("smartctl --scan -d scsi" & vbCrLf)
            .AppendText(vbCrLf)

            Dim scsi As String = prompt.SendCmd("--scan -d scsi")
            .AppendText(scsi)
            .AppendText(vbCrLf)

            Dim scsi_devices() As String = Nothing
            Dim scsi_arr() As String = scsi.Split(vbCrLf)
            Dim ds As Integer = -1
            For i As Integer = 0 To scsi_arr.Length - 2
                If scsi_arr(i).Contains("#") Then
                    ds += 1
                    ReDim Preserve scsi_devices(ds)
                    Dim dev As String() = scsi_arr(i).Split("#")
                    scsi_devices(ds) = dev(0).Trim
                End If
            Next

            If Not IsNothing(scsi_devices) Then
                .AppendText("::: " & scsi_devices.Count & " SCSI devices detected :::" & vbCrLf)
                .AppendText(vbCrLf)

                For i As Short = 0 To scsi_devices.Length - 1
                    Dim name() As String = scsi_devices(i).Split(" ")
                    .AppendText("::: Scan device " & name(0) & " :::" & vbCrLf)
                    .AppendText("smartctl -a -g all " & scsi_devices(i) & vbCrLf)
                    .AppendText(vbCrLf)
                    .AppendText(prompt.SendCmd("-a -g all " & scsi_devices(i)))
                    .AppendText(vbCrLf)
                Next i

            Else
                .AppendText("::: no SCSI devices detected :::" & vbCrLf)
                .AppendText(vbCrLf)
            End If

            .AppendText("╔═════════════════════════════════╗" & vbCrLf)
            .AppendText("║  Scan for Intel Matrix devices  ║" & vbCrLf)
            .AppendText("╚═════════════════════════════════╝" & vbCrLf)
            .AppendText("smartctl --scan -d csmi" & vbCrLf)
            .AppendText(vbCrLf)


            Dim intel As String = prompt.SendCmd("--scan -d csmi")
            .AppendText(intel)
            .AppendText(vbCrLf)

            Dim csmi_devices() As String = Nothing
            Dim csmi_arr() As String = intel.Split(vbCrLf)
            Dim dc As Integer = -1
            For i As Integer = 0 To csmi_arr.Length - 2
                If csmi_arr(i).Contains("#") Then
                    dc += 1
                    ReDim Preserve csmi_devices(dc)
                    Dim dev As String() = csmi_arr(i).Split("#")
                    csmi_devices(dc) = dev(0).Trim
                End If
            Next

            If Not IsNothing(csmi_devices) Then
                .AppendText("::: " & csmi_devices.Count & " Intel Matrix connected devices detected :::" & vbCrLf)
                .AppendText(vbCrLf)

                For i As Short = 0 To csmi_devices.Length - 1
                    Dim name() As String = csmi_devices(i).Split(" ")
                    .AppendText("::: Scan device " & name(0) & " :::" & vbCrLf)
                    .AppendText("smartctl -a -g all -P use " & csmi_devices(i) & vbCrLf)
                    .AppendText(vbCrLf)
                    .AppendText(prompt.SendCmd("-a -g all -P use " & csmi_devices(i)))
                    .AppendText(vbCrLf)
                Next i

            Else
                .AppendText("::: no Intel Matrix connected devices detected :::" & vbCrLf)
                .AppendText(vbCrLf)
            End If

        End With

        btnConsoleSave.Enabled = True
    End Sub

    Private Sub btnConsoleSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsoleSave.Click
        Dim savedialog As New SaveFileDialog
        Dim res As DialogResult

        savedialog.DefaultExt = "txt"
        savedialog.AddExtension = True
        savedialog.Filter = "*.txt|*.txt"
        savedialog.FileName = "output"
        res = savedialog.ShowDialog(Me)
        If res = DialogResult.OK Then
            IO.File.WriteAllText(savedialog.FileName, txtConsole.Text)
        End If
    End Sub
#End Region

#Region "Smartctl search for unknown USB bridges or multi dock devices"
    Private Sub btnUsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsbSave.Click
        Dim savedialog As New SaveFileDialog
        Dim res As DialogResult

        savedialog.DefaultExt = "txt"
        savedialog.AddExtension = True
        savedialog.Filter = "*.txt|*.txt"
        savedialog.FileName = "usbtest"
        res = savedialog.ShowDialog(Me)
        If res = DialogResult.OK Then
            IO.File.WriteAllText(savedialog.FileName, txtUsb.Text)
        End If
    End Sub

    Private Sub UsbScanner()
        Dim prompt As New Console

        btnUsbSave.Enabled = False

        '╚╝═╔╗║

        With txtUsb
            .Clear()
            .AppendText("╔═════════════════════════════════════════════════════════╗" & vbCrLf)
            .AppendText("║  Testing all devices searching for unknown USB bridges  ║" & vbCrLf)
            .AppendText("╚═════════════════════════════════════════════════════════╝" & vbCrLf)
            .AppendText(vbCrLf)

            For i As Short = 97 To 122
                .AppendText(vbCrLf)
                .AppendText("**** Scan /dev/sd" & Chr(i) & " ****" & vbCrLf)
                .AppendText(vbCrLf)
                Dim scan As String = prompt.SendCmd(" -a /dev/sd" & Chr(i))
                .AppendText(scan)
                .AppendText(vbCrLf)

                If scan.Contains("Unknown USB bridge") Then
                    .AppendText("!!!! Unknown USB bridge detected !!!" & vbCrLf)
                    .AppendText(vbCrLf)
                    .AppendText("**** Try to treat /dev/sd" & Chr(i) & " as SCSI to ATA (SAT) ****" & vbCrLf)
                    .AppendText(vbCrLf)
                    Dim sat As String = prompt.SendCmd(" -a /dev/sd" & Chr(i) & " -d sat")
                    .AppendText(sat)
                    .AppendText(vbCrLf)
                    Dim sat12 As String = prompt.SendCmd(" -a /dev/sd" & Chr(i) & " -d sat,12")
                    .AppendText(sat12)
                    .AppendText(vbCrLf)
                    .AppendText("**** Try to treat /dev/sd" & Chr(i) & " as UsbCypress ****" & vbCrLf)
                    .AppendText(vbCrLf)
                    Dim cypress As String = prompt.SendCmd(" -a /dev/sd" & Chr(i) & " -d usbcypress")
                    .AppendText(cypress)
                    .AppendText(vbCrLf)
                    .AppendText("**** Try to treat /dev/sd" & Chr(i) & " as UsbSunPlus ****" & vbCrLf)
                    .AppendText(vbCrLf)
                    Dim sunplus As String = prompt.SendCmd(" -a /dev/sd" & Chr(i) & " -d usbsunplus")
                    .AppendText(sunplus)
                    .AppendText(vbCrLf)
                    .AppendText("**** Try to treat /dev/sd" & Chr(i) & " as UsbJMicron ****" & vbCrLf)
                    .AppendText(vbCrLf)
                    Dim jmicron As String = prompt.SendCmd(" -a /dev/sd" & Chr(i) & " -d usbjmicron")
                    .AppendText(jmicron)
                    .AppendText(vbCrLf)
                    Dim jmicronx As String = prompt.SendCmd(" -a /dev/sd" & Chr(i) & " -d usbjmicron,x")
                    .AppendText(jmicronx)
                    .AppendText(vbCrLf)
                End If
            Next

            .AppendText("╔════════════════════════════════════════════════════════════════╗" & vbCrLf)
            .AppendText("║                         Scan completed                         ║" & vbCrLf)
            .AppendText("╚════════════════════════════════════════════════════════════════╝" & vbCrLf)
        End With

        btnUsbSave.Enabled = True
    End Sub
#End Region

#Region "WMI query"
    Private Sub btnWmiSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWmiSave.Click
        Dim savedialog As New SaveFileDialog
        Dim res As DialogResult

        savedialog.DefaultExt = "txt"
        savedialog.AddExtension = True
        savedialog.Filter = "*.txt|*.txt"
        savedialog.FileName = "wmiquery"
        res = savedialog.ShowDialog(Me)
        If res = DialogResult.OK Then
            IO.File.WriteAllText(savedialog.FileName, txtWmi.Text)
        End If
    End Sub

    Private Sub WmiQuery()

        btnWmiSave.Enabled = False

        With txtWmi

            On Error Resume Next

            '╚╝═╔╗║

            .AppendText("╔══════════════════════════════╗" & vbCrLf)
            .AppendText("║        Win32_Processor       ║" & vbCrLf)
            .AppendText("╚══════════════════════════════╝" & vbCrLf)
            Dim win32_processor As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_Processor")
            For Each cpu As ManagementObject In win32_processor.Get()
                .AppendText("CPU                : " & cpu("Name").ToString.Trim & vbCrLf)
            Next
            .AppendText("--" & vbCrLf)


            .AppendText("╔══════════════════════════════╗" & vbCrLf)
            .AppendText("║        Win32_BaseBoard       ║" & vbCrLf)
            .AppendText("╚══════════════════════════════╝" & vbCrLf)
            Dim win32_baseboard As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_BaseBoard")
            For Each board As ManagementObject In win32_baseboard.Get()
                .AppendText("Mother board       : " & board("Manufacturer").ToString.Trim & " " & board("Product").ToString.Trim & vbCrLf)
            Next
            .AppendText("--" & vbCrLf)

            .AppendText("╔══════════════════════════════╗" & vbCrLf)
            .AppendText("║     Win32_PhysicalMemory     ║" & vbCrLf)
            .AppendText("╚══════════════════════════════╝" & vbCrLf)
            Dim win32_physicalmemory As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_PhysicalMemory")

            Dim totalsize As String = 0

            For Each bank As ManagementObject In win32_physicalmemory.Get()
                totalsize += bank("Capacity")
            Next
            .AppendText("RAM                : " & Format(totalsize / 1024 ^ 2, "#,###") & " MiB" & vbCrLf)
            .AppendText("--" & vbCrLf)


            .AppendText("╔══════════════════════════════╗" & vbCrLf)
            .AppendText("║     Win32_VideoController    ║" & vbCrLf)
            .AppendText("╚══════════════════════════════╝" & vbCrLf)
            Dim win32_videocontroller As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_VideoController")
            For Each card As ManagementObject In win32_videocontroller.Get()
                .AppendText("Video card         : " & card("Name").ToString.Trim & vbCrLf)
            Next
            .AppendText("--" & vbCrLf)


            .AppendText("╔══════════════════════════════╗" & vbCrLf)
            .AppendText("║      Win32_IDEController     ║" & vbCrLf)
            .AppendText("╚══════════════════════════════╝" & vbCrLf)
            Dim win32_idecontroller As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_IDEController")
            For Each ide As ManagementObject In win32_idecontroller.Get()
                .AppendText("Name               : " & ide("Name").ToString.Trim & vbCrLf)
            Next
            .AppendText("--" & vbCrLf)


            .AppendText("╔══════════════════════════════╗" & vbCrLf)
            .AppendText("║     Win32_SCSIController     ║" & vbCrLf)
            .AppendText("╚══════════════════════════════╝" & vbCrLf)
            Dim win32_scsicontroller As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_SCSIController")
            For Each scsi As ManagementObject In win32_scsicontroller.Get()
                .AppendText("Name               : " & scsi("Name").ToString.Trim & vbCrLf)
            Next
            .AppendText("--" & vbCrLf)


            .AppendText("╔══════════════════════════════╗" & vbCrLf)
            .AppendText("║        Win32_DiskDrive       ║" & vbCrLf)
            .AppendText("╚══════════════════════════════╝" & vbCrLf)

            Dim searcher As New ManagementObjectSearcher( _
                "root\CIMV2", _
                "SELECT * FROM Win32_DiskDrive")

            For Each queryObj As ManagementObject In searcher.Get()
                .AppendText("Caption            : " & queryObj("Caption") & vbCrLf)
                .AppendText("Model              : " & queryObj("Model") & vbCrLf)
                .AppendText("Index              : " & queryObj("Index") & vbCrLf)
                .AppendText("Size               : " & queryObj("Size") & vbCrLf)
                .AppendText("Partitions         : " & queryObj("Partitions") & vbCrLf)
                .AppendText("Cylinders          : " & queryObj("TotalCylinders") & vbCrLf)
                .AppendText("Heads              : " & queryObj("TotalHeads") & vbCrLf)
                .AppendText("Sectors            : " & queryObj("TotalSectors") & vbCrLf)
                .AppendText("Tracks             : " & queryObj("TotalTracks") & vbCrLf)
                .AppendText("Bytes per sector   : " & queryObj("BytesPerSector") & vbCrLf)
                .AppendText("Sectors per track  : " & queryObj("SectorsPerTrack") & vbCrLf)
                .AppendText("Tracks per cylinder: " & queryObj("TracksPerCylinder") & vbCrLf)
                .AppendText("Media type         : " & queryObj("MediaType") & vbCrLf)
                .AppendText("--" & vbCrLf)
            Next


            .AppendText("╔══════════════════════════════╗" & vbCrLf)
            .AppendText("║      Win32_DiskPartition     ║" & vbCrLf)
            .AppendText("╚══════════════════════════════╝" & vbCrLf)

            Dim partitioninfos As New ManagementObjectSearcher( _
                "root\CIMV2", _
                "SELECT * FROM Win32_DiskPartition")

            For Each queryPartition As ManagementObject In partitioninfos.Get
                .AppendText("Disk index         : " & queryPartition("DiskIndex") & vbCrLf)
                .AppendText("DeviceID           : " & queryPartition("DeviceID") & vbCrLf)
                .AppendText("Bootable           : " & queryPartition("Bootable") & vbCrLf)
                .AppendText("Boot partition     : " & queryPartition("BootPartition") & vbCrLf)
                .AppendText("Description        : " & queryPartition("Description") & vbCrLf)
                .AppendText("Number of blocks   : " & queryPartition("NumberOfBlocks") & vbCrLf)
                .AppendText("Block size         : " & queryPartition("BlockSize") & vbCrLf)
                .AppendText("Primary Partition  : " & queryPartition("PrimaryPartition") & vbCrLf)
                .AppendText("--" & vbCrLf)
            Next


            .AppendText("╔══════════════════════════════╗" & vbCrLf)
            .AppendText("║ Win32_LogicalDiskToPartition ║" & vbCrLf)
            .AppendText("╚══════════════════════════════╝" & vbCrLf)

            Dim volumes As New ManagementObjectSearcher( _
                "root\CIMV2", _
                "SELECT * FROM Win32_LogicalDiskToPartition")

            For Each queryVolume As ManagementObject In volumes.Get
                .AppendText("Antecedent         : " & queryVolume("Antecedent") & vbCrLf)
                .AppendText("Dependent          : " & queryVolume("Dependent") & vbCrLf)
                .AppendText("--" & vbCrLf)
            Next


            .AppendText("╔══════════════════════════════╗" & vbCrLf)
            .AppendText("║       Win32_LogicalDisk      ║" & vbCrLf)
            .AppendText("╚══════════════════════════════╝" & vbCrLf)

            Dim volume As New ManagementObjectSearcher( _
                                "root\CIMV2", _
                                "SELECT * FROM Win32_LogicalDisk")

            For Each queryDetails As ManagementObject In volume.Get
                .AppendText("Volume letter      : " & queryDetails("Caption") & vbCrLf)
                .AppendText("Volume name        : " & queryDetails("VolumeName") & vbCrLf)
                .AppendText("Serial number      : " & queryDetails("VolumeSerialNumber") & vbCrLf)
                .AppendText("File system        : " & queryDetails("FileSystem") & vbCrLf)
                .AppendText("Total size         : " & queryDetails("Size") & vbCrLf)
                .AppendText("Free space         : " & queryDetails("FreeSpace") & vbCrLf)
                .AppendText("--" & vbCrLf)
            Next
        End With

        btnWmiSave.Enabled = True
    End Sub
#End Region

    Private Sub MainToolbox_Load(sender As Object, e As EventArgs) Handles Me.Load
        SmartctlScan()
        UsbScanner()
        WmiQuery()

        InvokeOnClick(robConsole, Nothing)
    End Sub

    Private Sub robConsole_Click(sender As Object, e As EventArgs) Handles robConsole.Click
        htcMain.SelectPage(tpConsole)
    End Sub

    Private Sub robUsb_Click(sender As Object, e As EventArgs) Handles robUsb.Click
        htcMain.SelectPage(tpUsb)
    End Sub

    Private Sub robSystem_Click(sender As Object, e As EventArgs) Handles robSystem.Click
        htcMain.SelectPage(tpSystem)
    End Sub
End Class
