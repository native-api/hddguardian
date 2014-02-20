'Logical Disk Monitor is a simple tool to monitor partitions read/write with
'possibility to display a tray icon for each partition
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2013-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System
Imports System.IO
Imports System.Management
Imports System.Runtime.InteropServices

Public Class ActivityIcon

    Private Class IconsList
        Inherits List(Of Icon)
    End Class

    Private WithEvents ti As New NotifyIcon
    Private WithEvents m_read As New PerformanceCounter
    Private WithEvents m_write As New PerformanceCounter
    Private WithEvents updater As New Timer
    Private m_visible As Boolean
    Private m_partition As String
    Private icons As New IconsList

    Private Sub ti_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ti.MouseDown
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left
                'restore main screen
                LDM.WindowState = FormWindowState.Normal
                LDM.ShowInTaskbar = True
                LDM.Visible = True
                LDM.Activate()
                LDM.niTrayIcon.Visible = False
            Case Windows.Forms.MouseButtons.Middle
                'do nothing
            Case Windows.Forms.MouseButtons.Right
                'hmmm... open an explorer window?
        End Select
    End Sub

    Public Sub New(ByVal drive As String, ByVal drivename As String)
        m_partition = drive

        With m_read
            .CategoryName = "LogicalDisk"
            .CounterName = "Disk Read Bytes/sec"
            .InstanceName = drive
        End With
        With m_write
            .CategoryName = "LogicalDisk"
            .CounterName = "Disk Write Bytes/sec"
            .InstanceName = drive
        End With

        '65 is the Unicode index for "A" char
        Dim iconindex As Integer = Char.ConvertToUtf32(drive.ToUpper, 0) - 65

        'get the drive activity icons and put these images into the imagelist
        Dim trayicons As Bitmap = My.Resources.drive_activity
        'icon without activity
        Dim rect As New Rectangle(iconindex * 16, 0, 16, 16)
        Dim geticon As IntPtr = trayicons.Clone(rect, trayicons.PixelFormat).GetHicon
        icons.Add(System.Drawing.Icon.FromHandle(geticon))
        'icon with read activity
        Dim rect_r As New Rectangle(iconindex * 16, 16, 16, 16)
        Dim geticon_r As IntPtr = trayicons.Clone(rect_r, trayicons.PixelFormat).GetHicon
        icons.Add(System.Drawing.Icon.FromHandle(geticon_r))
        'icon with write activity
        Dim rect_w As New Rectangle(iconindex * 16, 2 * 16, 16, 16)
        Dim geticon_w As IntPtr = trayicons.Clone(rect_w, trayicons.PixelFormat).GetHicon
        icons.Add(System.Drawing.Icon.FromHandle(geticon_w))
        'icon with full activity
        Dim rect_rw As New Rectangle(iconindex * 16, 3 * 16, 16, 16)
        Dim geticon_rw As IntPtr = trayicons.Clone(rect_rw, trayicons.PixelFormat).GetHicon
        icons.Add(System.Drawing.Icon.FromHandle(geticon_rw))

        'set a basic icon
        ti.Icon = icons(0)
        ti.Text = drivename & " (" & drive & ")"

        'start the updater timer
        updater.Interval = 1000
        updater.Start()

    End Sub

    Public Sub Dispose()
        ti.Visible = False
        m_read.Dispose()
        m_write.Dispose()
        updater.Stop()
        updater.Dispose()
        ti.Dispose()
    End Sub

    Private Sub refresh() Handles updater.Tick
        Try
            Dim read As String = m_read.NextValue
            Dim write As String = m_write.NextValue

            Dim both As Integer = 0
            If (read > 0) Then
                both += 1
            End If

            If (write > 0) Then
                both += 2
            End If

            Select Case both
                Case 0 'none
                    ti.Icon = icons(0)
                Case 1 'read
                    ti.Icon = icons(1)
                Case 2 'write
                    ti.Icon = icons(2)
                Case 3 'both
                    ti.Icon = icons(3)
            End Select

            With LDM.lvwPartitions
                For i As Short = 0 To .Items.Count - 1
                    If .Items(i).Text = m_partition Then
                        .Items(i).SubItems(2).Text = "0"
                        .Items(i).SubItems(3).Text = "0"
                        'Dim r() As String = read.Split(",")
                        'Dim w() As String = write.Split(",")
                        If Val(read) > 0 Then .Items(i).SubItems(2).Text = Format(Val(read), "#,###,###")
                        If Val(write) > 0 Then .Items(i).SubItems(3).Text = Format(Val(write), "#,###,###")
                    End If
                Next
            End With
        Catch
        End Try
    End Sub

    Public Property Visible As Boolean
        Get
            Return m_visible
        End Get
        Set(ByVal value As Boolean)
            m_visible = value
            Me.ti.Visible = value
        End Set
    End Property

    Public Function PartitionIsAvailable() As Boolean
        If System.IO.Directory.Exists(m_partition) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class

Partial Class LDM
    Dim isloading As Boolean = False
    Dim icns() As ActivityIcon

    Public Sub PartitionsActivity()
        LoadPartitions()

        If Not IsNothing(icns) Then
            For i As Short = 0 To icns.Count - 1
                If Not icns(i).PartitionIsAvailable Then icns(i).Dispose()
            Next
        End If

        AddActivityTrayIcons()
        LoadActivitySettings()
    End Sub

    Private Sub DestroyActivityIcons()
        If IsNothing(icns) Then Exit Sub
        For i As Short = 0 To icns.Count - 1
            icns(i).Dispose()
        Next
    End Sub

    Public Sub LoadPartitions()
        isloading = True
        'when a listview is populated with checkboxes it fire also che "itemchecked" event, so is necessary a variable to
        'avoid the erase of drive to monitor into the setting file

        Dim imlDevice As New ImageList
        imlDevice.Images.Add(My.Resources.drive_folder)

        lvwPartitions.Items.Clear()
        lvwPartitions.SmallImageList = imlDevice

        Dim drives As New ManagementObjectSearcher( _
                    "root\CIMV2", _
                    "SELECT * FROM Win32_LogicalDisk")

        For Each drive As ManagementObject In drives.Get()
            Dim drivetype As String = drive("DriveType")

            Select Case drivetype
                Case 3 'fixed drive
                    With lvwPartitions
                        Dim caption As String = drive("Caption")

                        .Items.Add(drive("Caption"), 0)

                        Try
                            .Items(.Items.Count - 1).SubItems.Add(drive("VolumeName"))
                        Catch
                            .Items(.Items.Count - 1).SubItems.Add("")
                        End Try
                        .Items(.Items.Count - 1).SubItems.Add("0")
                        .Items(.Items.Count - 1).SubItems.Add("0")


                        .Columns(0).Width = 100
                        .Columns(1).Width = 200
                        .Columns(2).Width = 100
                        .Columns(3).Width = 100
                    End With
                Case Else
                    'do nothing...
            End Select
        Next

        sbLdm.Text = sbLdm.Tag & ": " & lvwPartitions.Items.Count

        isloading = False
    End Sub

    Private Sub AddActivityTrayIcons()

        ReDim icns(lvwPartitions.Items.Count - 1)

        With lvwPartitions
            For i As Short = 0 To icns.Count - 1
                icns(i) = New ActivityIcon(.Items(i).Text, .Items(i).SubItems(1).Text)
            Next
        End With
    End Sub

    Private Sub LoadActivitySettings()
        If My.Settings.PartitionsToMonitor.Length > 0 Then
            Dim tomonitor() As String = My.Settings.PartitionsToMonitor.Split("|")

            isloading = True

            For Each item As ListViewItem In lvwPartitions.Items
                For i As Short = 0 To tomonitor.Count - 1
                    If item.Text = tomonitor(i) Then
                        item.Checked = True
                        Exit For
                    End If
                Next
            Next

            isloading = False
        Else
            Exit Sub
        End If
    End Sub

    Private Sub SaveActivitySettings()
        Dim tomonitor As String = ""

        For Each item As ListViewItem In lvwPartitions.Items
            If item.Checked Then tomonitor += item.Text & "|"
        Next

        If tomonitor.Length > 0 Then tomonitor = tomonitor.Substring(0, tomonitor.Length - 1)

        My.Settings.PartitionsToMonitor = tomonitor
        My.Settings.Save()
    End Sub
End Class
