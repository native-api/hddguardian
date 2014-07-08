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


'Here is gathered data about system hardware and their hard disks.
'This is a new version rewritten in October 2012: the data is all gathered at program startup
'and is only possible to update this details manually clicking on the button "update" or
'automatically when a removable device is added or removed.

Imports System.Management
Imports System.ComponentModel

Public Class DiskDrive
    Inherits List(Of Drive)
End Class

Public Structure Drive
    Public Class DiskPartition
        Inherits List(Of Partition)
    End Class

    Dim Caption, Model, Index, NumberOfPartitons, Size As String
    'Cylinders, Heads, Sectors, Tracks, _
    'BytesPerSector, SectorsPerTrack, TracksPerCylinder As String
    Dim Partitions As DiskPartition
End Structure

Public Structure Partition
    Public Class LogicalDisk
        Inherits List(Of Disk)
    End Class

    Dim DiskIndex, DeviceID, Bootable, BootPartition, Description, NumberOfBlocks, _
        BlockSize, PrimaryPartition, Size As String
    Dim Disk As LogicalDisk
End Structure

Public Structure Disk
    Dim VolumeLetter, VolumeName, SerialNumber, FileSystem, TotalSize As String
End Structure

Public Structure Hardware
    Dim Cpu, Ram, Motherboard, VideoCard As String
End Structure

Partial Class Main
    Dim Hrw As Hardware
    Dim WithEvents drivesBGWorker As New BackgroundWorker
    Dim Drives As New DiskDrive

    Public Sub AnalyzeWMI()
        drivesBGWorker.RunWorkerAsync()
    End Sub

    Private Sub StartWork() Handles drivesBGWorker.DoWork
        GetData()
        GetHardwareData()
    End Sub

    Private Sub WorkCompleted() Handles drivesBGWorker.RunWorkerCompleted
        PopulateHardware()
    End Sub

    Public Sub UpdateHardware()
        tvwComputer.Visible = False
        tvwComputer.Nodes.Clear()
        Drives.Clear()

        tlpLoadWmi.Visible = True

        If Not drivesBGWorker.IsBusy Then AnalyzeWMI()
    End Sub

    Private Sub PopulateHardware()
        With tvwComputer
            .ImageList = imlDevice
            .Nodes.Clear()

            .Nodes.Add("root", My.Computer.Name, 5, 5)

            For d As Short = 0 To Drives.Count - 1
                With .Nodes("root")
                    .Nodes.Add("d" & d, Drives(d).Model, 4, 4)
                    .Nodes(.Nodes.Count - 1).Tag = Drives(d).Index
                End With

                For p As Short = 0 To Drives(d).Partitions.Count - 1
                    With .Nodes("root").Nodes("d" & d)
                        .Nodes.Add("p" & p, Drives(d).Partitions(p).DeviceID.Replace("#", ""), 2, 2)
                        .Nodes(.Nodes.Count - 1).Tag = Drives(d).Index
                    End With

                    For l As Short = 0 To Drives(d).Partitions(p).Disk.Count - 1
                        With .Nodes("root").Nodes("d" & d).Nodes("p" & p)
                            If Drives(d).Partitions(p).Disk(l).VolumeName.Length > 0 Then
                                .Nodes.Add("l" & l, Drives(d).Partitions(p).Disk(l).VolumeName & " (" & Drives(d).Partitions(p).Disk(l).VolumeLetter & ")", 3, 3)
                                .Nodes(.Nodes.Count - 1).Tag = Drives(d).Index
                            Else
                                .Nodes.Add("l" & l, "(" & Drives(d).Partitions(p).Disk(l).VolumeLetter & ")", 3, 3)
                                .Nodes(.Nodes.Count - 1).Tag = Drives(d).Index
                            End If

                        End With
                    Next
                Next
            Next

            .Nodes(0).Expand()
            .SelectedNode = .Nodes(0)

            tlpLoadWmi.Visible = False
            .Visible = True
        End With

    End Sub

    Private Sub ShowDetails()
        For Each control In tlpWmiDetails.Controls
            If control.GetType = GetType(Label) Then control.Text = ""
        Next

        With tvwComputer
            Dim path() As String = .SelectedNode.FullPath.Split("\")
            Select Case path.Length
                Case 1
                    With Me
                        Select Case My.Settings.ComputerType
                            Case Is = "0"
                                .picWmi.Image = My.Resources.pc_office
                            Case Is = "1"
                                .picWmi.Image = My.Resources.pc_game
                            Case Is = "2"
                                .picWmi.Image = My.Resources.pc_laptop
                            Case Else
                                .picWmi.Image = My.Resources.pc_office
                        End Select
                        .lblInfo1.Text = m_motherboard & ":"
                        .lblInfo2.Text = m_processor & ":"
                        .lblInfo3.Text = m_ram & ":"
                        .lblInfo4.Text = m_video & ":"
                        .lblInfo1Value.Text = Hrw.Motherboard
                        .lblInfo2Value.Text = Hrw.Cpu
                        .lblInfo3Value.Text = Hrw.Ram
                        .lblInfo4Value.Text = Hrw.VideoCard
                    End With
                Case 2
                    For i As Short = 0 To Drives.Count - 1
                        If Drives(i).Model = path(1) And Drives(i).Index = .SelectedNode.Tag Then
                            With Me
                                .picWmi.Image = My.Resources.device_harddisk
                                .lblInfo1.Text = m_deviceindex & ":"
                                .lblInfo2.Text = m_partitions & ":"
                                .lblInfo3.Text = m_totalsize & ":"
                                .lblInfo1Value.Text = Drives(i).Index
                                .lblInfo2Value.Text = Drives(i).NumberOfPartitons
                                .lblInfo3Value.Text = Drives(i).Size
                            End With
                            Exit For
                        End If
                    Next
                Case 3
                    For i As Short = 0 To Drives.Count - 1
                        If Drives(i).Model = path(1) And Drives(i).Index = .SelectedNode.Tag Then
                            For p As Short = 0 To Drives(i).Partitions.Count - 1
                                If Drives(i).Partitions(p).DeviceID.Replace("#", "").Contains(path(2)) Then
                                    With Me
                                        .picWmi.Image = My.Resources.device_partition
                                        .lblInfo1.Text = m_bootable & ":"
                                        .lblInfo2.Text = m_bootpartition & ":"
                                        .lblInfo3.Text = m_primarypartition & ":"
                                        .lblInfo4.Text = m_type & ":"
                                        .lblInfo5.Text = m_numofblocks & ":"
                                        .lblInfo6.Text = m_blocksize & ":"
                                        .lblInfo7.Text = m_totalsize & ":"
                                        .lblInfo1Value.Text = Drives(i).Partitions(p).Bootable
                                        .lblInfo2Value.Text = Drives(i).Partitions(p).BootPartition
                                        .lblInfo3Value.Text = Drives(i).Partitions(p).PrimaryPartition
                                        .lblInfo4Value.Text = Drives(i).Partitions(p).Description
                                        .lblInfo5Value.Text = Drives(i).Partitions(p).NumberOfBlocks
                                        .lblInfo6Value.Text = Drives(i).Partitions(p).BlockSize
                                        .lblInfo7Value.Text = Drives(i).Partitions(p).Size
                                    End With
                                    Exit For
                                End If
                            Next
                            Exit For
                        End If
                    Next
                Case 4
                    For i As Short = 0 To Drives.Count - 1
                        If Drives(i).Model = path(1) And Drives(i).Index = .SelectedNode.Tag Then
                            For p As Short = 0 To Drives(i).Partitions.Count - 1
                                If Drives(i).Partitions(p).DeviceID.Replace("#", "").Contains(path(2)) Then
                                    For l As Short = 0 To Drives(i).Partitions(p).Disk.Count - 1
                                        If path(3).Contains(Drives(i).Partitions(p).Disk(l).VolumeLetter) Then
                                            With Me
                                                .picWmi.Image = My.Resources.device_folder
                                                .lblInfo1.Text = m_serialnumber & ":"
                                                .lblInfo2.Text = m_filesystem & ":"
                                                .lblInfo3.Text = m_totalsize & ":"
                                                .lblInfo1Value.Text = Drives(i).Partitions(p).Disk(l).SerialNumber
                                                .lblInfo2Value.Text = Drives(i).Partitions(p).Disk(l).FileSystem
                                                .lblInfo3Value.Text = Drives(i).Partitions(p).Disk(l).TotalSize
                                            End With
                                            Exit For
                                        End If
                                    Next
                                    Exit For
                                End If
                            Next
                            Exit For
                        End If
                    Next
            End Select

        End With
    End Sub

    Private Sub GetHardwareData()
        '╔══════════════════════════════╗
        '║        Win32_Processor       ║
        '╚══════════════════════════════╝
        Dim win32_processor As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_Processor")
        For Each cpu As ManagementObject In win32_processor.Get()
            Hrw.Cpu = cpu("Name").ToString.Trim
        Next


        '╔══════════════════════════════╗
        '║        Win32_BaseBoard       ║
        '╚══════════════════════════════╝
        Dim win32_baseboard As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_BaseBoard")
        For Each board As ManagementObject In win32_baseboard.Get()
            Hrw.Motherboard = board("Manufacturer").ToString.Trim & " " & board("Product").ToString.Trim
        Next


        '╔══════════════════════════════╗
        '║     Win32_PhysicalMemory     ║
        '╚══════════════════════════════╝
        Dim win32_physicalmemory As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_PhysicalMemory")
        'Dim ram_manufacturer As String = win32_physicalmemory.Get("Manufacturer").ToString.Trim
        'Dim partnumber As String = win32_physicalmemory.Get("PartNumber").ToString.Trim
        Dim totalsize As String = 0

        For Each bank As ManagementObject In win32_physicalmemory.Get()
            totalsize += bank("Capacity")
        Next

        Hrw.Ram = Format(totalsize / 1024 ^ 2, "#,###") & " MiB"

        '╔══════════════════════════════╗
        '║     Win32_VideoController    ║
        '╚══════════════════════════════╝
        Dim win32_videocontroller As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_VideoController")
        For Each card As ManagementObject In win32_videocontroller.Get()
            Hrw.VideoCard = card("Name").ToString.Trim
        Next

    End Sub

    Private Sub GetData()
        '╔══════════════════════════════╗
        '║        Win32_DiskDrive       ║
        '╚══════════════════════════════╝
        Dim win32_diskdrive As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_DiskDrive")

        For Each diskdrive As ManagementObject In win32_diskdrive.Get()
            Dim d As New Drive
            Dim i As String
            Dim mediatype As String

            d.Caption = diskdrive("Caption")
            d.Model = diskdrive("Model")
            d.Index = diskdrive("Index")
            mediatype = diskdrive("MediaType")

            If Not IsNothing(mediatype) Then
                'under WinXP some times appear a tab character into the MediaType value...
                mediatype = diskdrive("MediaType").ToString.Replace(vbTab, " ")
            End If

            i = d.Index
            Dim full As String = diskdrive("Size")
            Dim t_si As String = ""
            Dim t_iec As String = ""

            Select Case Val(full)
                Case 0 To 1024
                    t_iec = Format(full, "#,###") & " Bytes"
                Case 1024 + 1 To 1024 ^ 2
                    t_iec = Format(full / 1024, "#,###") & " KiB"
                Case 1024 ^ 2 + 1 To 1024 ^ 3
                    t_iec = Format(full / 1024 ^ 2, "#,###") & " MiB"
                Case 1024 ^ 3 + 1 To 1024 ^ 4
                    t_iec = Format(full / 1024 ^ 3, "#,###") & " GiB"
                Case Is > 1024 ^ 4
                    t_iec = Format(full / 1024 ^ 4, "#.0") & " TiB"
            End Select

            Select Case Val(full)
                Case 0 To 1000 - 1
                    t_si = ""
                Case 1000 To 1000 ^ 2 - 1
                    t_si = " / " & Format(full / 1000, "#,###") & " KB"
                Case 1000 ^ 2 To 1000 ^ 3 - 1
                    t_si = " / " & Format(full / 1000 ^ 2, "#,###") & " MB"
                Case 1000 ^ 3 To 1000 ^ 4 - 1
                    t_si = " / " & Format(full / 1000 ^ 3, "#,###") & " GB"
                Case Is > 1000 ^ 4
                    t_si = " / " & Format(full / 1000 ^ 4, "#.0") & " TB"
            End Select

            d.Size = t_iec & t_si

            d.NumberOfPartitons = diskdrive("Partitions")

            'The following values are removed because aren't related to physical devices
            '--------------------------------------------------------------------------
            'd.Cylinders = Format(diskdrive("TotalCylinders"), "#,###")
            'd.Heads = Format(diskdrive("TotalHeads"), "#,###")
            'd.Sectors = Format(diskdrive("TotalSectors"), "#,###")
            'd.Tracks = Format(diskdrive("TotalTracks"), "#,###")
            'd.BytesPerSector = Format(diskdrive("BytesPerSector"), "#,###")
            'd.SectorsPerTrack = Format(diskdrive("SectorsPerTrack"), "#,###")
            'd.TracksPerCylinder = Format(diskdrive("TracksPerCylinder"), "#,###")
            '--------------------------------------------------------------------------

            d.Partitions = New Drive.DiskPartition

            '╔══════════════════════════════╗
            '║      Win32_DiskPartition     ║
            '╚══════════════════════════════╝
            Dim win32_diskpartition As New ManagementObjectSearcher("root/CIMV2", " SELECT * FROM Win32_DiskPartition WHERE DiskIndex = " & i)

            For Each diskpartition As ManagementObject In win32_diskpartition.Get()
                Dim p As New Partition
                Dim dev_id As String

                p.DiskIndex = diskpartition("DiskIndex")
                p.DeviceID = diskpartition("DeviceID").Replace("Disk", m_disk).Replace("Partition", m_partition)
                dev_id = diskpartition("DeviceID")
                Dim bootable As String = diskpartition("Bootable")
                If Not IsNothing(bootable) Then
                    p.Bootable = bootable.Replace("False", m_no).Replace("True", m_yes)
                Else
                    p.Bootable = ""
                End If
                Dim bootpartition As String = diskpartition("BootPartition")
                If Not IsNothing(bootpartition) Then
                    p.BootPartition = bootpartition.Replace("False", m_no).Replace("True", m_yes)
                Else
                    p.BootPartition = ""
                End If
                p.Description = diskpartition("Description")
                Dim blocks As ULong = diskpartition("NumberOfBlocks")
                p.NumberOfBlocks = Format(blocks, "#,###")
                Dim block_size As ULong = diskpartition("BlockSize")
                p.BlockSize = block_size & " Bytes"
                Dim primarypartition As String = diskpartition("PrimaryPartition")
                If Not IsNothing(primarypartition) Then
                    p.PrimaryPartition = primarypartition.Replace("False", m_no).Replace("True", m_yes)
                Else
                    p.PrimaryPartition = ""
                End If
                p.Disk = New Partition.LogicalDisk
                Dim ptot As ULong = blocks * block_size

                Dim p_si As String = ""
                Dim p_iec As String = ""
                Select Case Val(ptot)
                    Case 0 To 1024
                        p_iec = Format(ptot, "#,###") & " Bytes"
                    Case 1024 + 1 To 1024 ^ 2
                        p_iec = Format(ptot / 1024, "#,###") & " KiB"
                    Case 1024 ^ 2 + 1 To 1024 ^ 3
                        p_iec = Format(ptot / 1024 ^ 2, "#,###") & " MiB"
                    Case 1024 ^ 3 + 1 To 1024 ^ 4
                        p_iec = Format(ptot / 1024 ^ 3, "#,###") & " GiB"
                    Case Is > 1024 ^ 4
                        p_iec = Format(ptot / 1024 ^ 4, "#.0") & " TiB"
                End Select

                Select Case Val(ptot)
                    Case 0 To 1000 - 1
                        p_si = ""
                    Case 1000 To 1000 ^ 2 - 1
                        p_si = " / " & Format(ptot / 1000, "#,###") & " KB"
                    Case 1000 ^ 2 To 1000 ^ 3 - 1
                        p_si = " / " & Format(ptot / 1000 ^ 2, "#,###") & " MB"
                    Case 1000 ^ 3 To 1000 ^ 4 - 1
                        p_si = " / " & Format(ptot / 1000 ^ 3, "#,###") & " GB"
                    Case Is > 1000 ^ 4
                        p_si = " / " & Format(ptot / 1000 ^ 4, "#.0") & " TB"
                End Select

                p.Size = p_iec & p_si

                '╔══════════════════════════════╗
                '║ Win32_LogicalDiskToPartition ║
                '╚══════════════════════════════╝
                Dim win32_logicaldisktopartition As New ManagementObjectSearcher("root\CIMV2", _
                                "SELECT * FROM Win32_LogicalDiskToPartition")

                For Each logicaldisktopartition As ManagementObject In win32_logicaldisktopartition.Get
                    Dim antecedent As String = logicaldisktopartition("Antecedent")
                    If antecedent.Contains(dev_id) Then
                        Dim dependent() As String = logicaldisktopartition("Dependent").ToString.Split("=")
                        Dim letter As String = dependent(1).Replace("""", "'")

                        '╔══════════════════════════════╗
                        '║       Win32_LogicalDisk      ║
                        '╚══════════════════════════════╝
                        Dim win32_logicaldisk As New ManagementObjectSearcher("root\CIMV2", _
                                    "SELECT * FROM Win32_LogicalDisk WHERE DeviceID = " & letter)

                        For Each logicaldisk As ManagementObject In win32_logicaldisk.Get
                            Dim ld As Disk

                            ld.VolumeLetter = logicaldisk("Caption")
                            ld.VolumeName = logicaldisk("VolumeName")
                            ld.SerialNumber = logicaldisk("VolumeSerialNumber").ToString.Insert(4, "-")
                            ld.FileSystem = logicaldisk("FileSystem")

                            Dim tot As String = logicaldisk("Size")

                            Dim si As String = ""
                            Dim iec As String = ""

                            Select Case Val(tot)
                                Case 0 To 1024
                                    iec = Format(tot, "#,###") & " Bytes"
                                Case 1024 + 1 To 1024 ^ 2
                                    iec = Format(tot / 1024, "#,###") & " KiB"
                                Case 1024 ^ 2 + 1 To 1024 ^ 3
                                    iec = Format(tot / 1024 ^ 2, "#,###") & " MiB"
                                Case 1024 ^ 3 + 1 To 1024 ^ 4
                                    iec = Format(tot / 1024 ^ 3, "#,###") & " GiB"
                                Case Is > 1024 ^ 4
                                    iec = Format(tot / 1024 ^ 4, "#.0") & " TiB"
                            End Select

                            Select Case Val(tot)
                                Case 0 To 1000 - 1
                                    si = ""
                                Case 1000 To 1000 ^ 2 - 1
                                    si = " / " & Format(tot / 1000, "#,###") & " KB"
                                Case 1000 ^ 2 To 1000 ^ 3 - 1
                                    si = " / " & Format(tot / 1000 ^ 2, "#,###") & " MB"
                                Case 1000 ^ 3 To 1000 ^ 4 - 1
                                    si = " / " & Format(tot / 1000 ^ 3, "#,###") & " GB"
                                Case Is > 1000 ^ 4
                                    si = " / " & Format(tot / 1000 ^ 4, "#,0") & " TB"
                            End Select

                            ld.TotalSize = iec & si

                            p.Disk.Add(ld)
                        Next
                    End If
                Next
                d.Partitions.Add(p)
            Next

            '*** from Win32_DiskDrive class page in MS Dev Center ***
            'MediaType
            'Starting with Windows Vista, possible values are:
            '- External hard disk media
            '- Removable media other than floppy
            '- Fixed hard disk media
            '- Format is unknown
            'For Windows Server 2003, Windows XP, Windows 2000, and Windows NT 4.0 possible values are:
            '- Removable media
            '- Fixed hard disk  <- this value is also used for external hard disks...
            '- Unknown

            'we have to avoid unknown devices and removable media
            If Not IsNothing(mediatype) Then
                If mediatype.ToLower.Contains("hard") Then
                    Drives.Add(d)
                End If
            End If
        Next
    End Sub
End Class
