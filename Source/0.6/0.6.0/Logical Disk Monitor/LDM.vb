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
Imports System.ComponentModel
Imports System.Xml

Public Class LDM

    Dim WithEvents device_arrival As New BackgroundWorker
    Dim WithEvents device_remove As New BackgroundWorker

#Region "UTX Theme call"
    Private Random As Random
    <DllImport("uxtheme.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function SetWindowTheme(ByVal hWnd As IntPtr, ByVal appName As String, ByVal partList As String) As Integer

    End Function

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        SetWindowTheme(lvwPartitions.Handle, "explorer", Nothing)

    End Sub
#End Region

#Region "Main form"
    Private Sub LDM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyLanguage()

        isloading = True
        rcbCloseOnTray.Checked = My.Settings.CloseOnTray
        rcbStartMinimized.Checked = My.Settings.StartMinimized
        isloading = False

        LoadPartitions()
        AddActivityTrayIcons()
        LoadActivitySettings()

        With niTrayIcon
            .Text = My.Application.Info.ProductName
        End With


        If My.Settings.StartMinimized Then
            Me.WindowState = FormWindowState.Minimized
            If My.Settings.CloseOnTray Then
                Me.ShowInTaskbar = False
                Me.Visible = False
                niTrayIcon.Visible = True
            End If
        End If

        rcbLogonStart.Checked = ShortcutExists()

        'start to monitor devices changes
        If My.Settings.MonitorUsb Then
            rcbMonitorUsb.Checked = True
            StartMonitorDevicesInstances()
        End If
    End Sub

    Private Sub LDM_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        On Error Resume Next

        If Me.WindowState = FormWindowState.Minimized Then
            If My.Settings.CloseOnTray Then
                Me.ShowInTaskbar = False
                Me.Visible = False
                niTrayIcon.Visible = True
            Else
                Me.ShowInTaskbar = True
                Me.Visible = True
            End If
        Else
            Me.ShowInTaskbar = True
            Me.Visible = True
        End If

        Memory.FlushMemory()
    End Sub

    Private Sub LDM_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.CloseOnTray Then
            If Me.WindowState = FormWindowState.Normal Then
                e.Cancel = True
                Me.WindowState = FormWindowState.Minimized
                Me.ShowInTaskbar = False
                Me.Visible = False
                niTrayIcon.Visible = True
            End If
            Exit Sub
        End If

        media_connect.Stop()
        media_disconnect.Stop()

        DestroyActivityIcons()
        niTrayIcon.Visible = False
        Me.Dispose()
        End
    End Sub
#End Region

#Region "Logical disk monitoring"
    Private Sub lvwpartitions_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwPartitions.ItemChecked
        On Error Resume Next
        For Each item As ListViewItem In lvwPartitions.Items
            If Not IsNothing(icns) Then
                If item.Checked Then
                    icns(item.Index).Visible = True
                Else
                    icns(item.Index).Visible = False
                End If
            End If
        Next

        If Not isloading Then SaveActivitySettings()
    End Sub

    Private Sub rbtReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtReload.Click
        PartitionsActivity()
    End Sub
#End Region

#Region "Settings"
    Private Sub rcbLogonStart_Click(sender As Object, e As EventArgs) Handles rcbLogonStart.Click
        If isloading Then Exit Sub

        If rcbLogonStart.Checked Then
            CreateShortcut()
        Else
            DeleteShortcut()
        End If
    End Sub

    Private Sub rcbStartMinimized_Click(sender As Object, e As EventArgs) Handles rcbStartMinimized.Click
        If isloading Then Exit Sub

        My.Settings.StartMinimized = rcbStartMinimized.Checked
        My.Settings.Save()
    End Sub

    Private Sub rcbCloseOnTray_Click(sender As Object, e As EventArgs) Handles rcbCloseOnTray.Click
        If isloading Then Exit Sub

        My.Settings.CloseOnTray = rcbCloseOnTray.Checked
        My.Settings.Save()
    End Sub

    Private Sub rcbMonitorUsb_Click(sender As Object, e As EventArgs) Handles rcbMonitorUsb.Click
        If isloading Then Exit Sub

        If rcbMonitorUsb.Checked Then
            StartMonitorDevicesInstances()
        Else
            media_connect.Stop()
            media_disconnect.Stop()
        End If

        My.Settings.MonitorUsb = rcbMonitorUsb.Checked
        My.Settings.Save()
    End Sub
#End Region

#Region "Exit"
    Private Sub rbtExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtExit.Click
        device_arrival.Dispose()
        device_remove.Dispose()

        DestroyActivityIcons()
        niTrayIcon.Visible = False
        Me.Dispose()
        End
    End Sub
#End Region

#Region "Devices remove/arrival"
    Dim WithEvents media_connect As New ManagementEventWatcher
    Dim WithEvents media_disconnect As New ManagementEventWatcher


    Private Sub StartMonitorDevicesInstances()
        media_connect = New ManagementEventWatcher
        media_connect.Query = New WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_PnPEntity' AND TargetInstance.Caption LIKE '%USB Device%'")
        media_connect.Start()

        media_disconnect = New ManagementEventWatcher
        media_disconnect.Query = New WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_PnPEntity' AND TargetInstance.Caption LIKE '%USB Device%'")
        media_disconnect.Start()
    End Sub

    Private Delegate Sub DevReload()

    Private Sub DeviceChange(ByVal sender As Object, ByVal e As System.Management.EventArrivedEventArgs) Handles media_connect.EventArrived, media_disconnect.EventArrived
        Dim ReloadDelegate As DevReload
        ReloadDelegate = AddressOf PartitionsActivity

        Me.Invoke(ReloadDelegate)
    End Sub

#End Region

#Region "Language"
    Dim language As New Hashtable

    Private Sub LoadInternalLanguage()
        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmldoc.LoadXml(My.Resources.language)

        m_nodelist = m_xmldoc.SelectNodes("/interface/string")

        With language
            .Clear()
            For Each m_node In m_nodelist
                .Add(m_node.Attributes.GetNamedItem("id").Value, _
                     m_node.Attributes.GetNamedItem("text").Value)
            Next
        End With
    End Sub

    Private Function GetString(ByVal value As Short) As String
        Dim val As String = String.Format("{0:D4}", value)
        Return language(val).ToString.Replace("\", vbCrLf)
    End Function

    Private Sub ApplyLanguage()
        LoadInternalLanguage()

        lblTip.Text = GetString(1)

        chLetter.Text = GetString(2)
        chLabel.Text = GetString(3)
        chRead.Text = GetString(4)
        chWrite.Text = GetString(5)
        rbtReload.Text = GetString(6)
        rbtExit.Text = GetString(7)
        rcbLogonStart.Text = GetString(8)
        rcbStartMinimized.Text = GetString(9)
        rcbCloseOnTray.Text = GetString(10)
        sbLdm.Tag = GetString(12)
        rcbMonitorUsb.Text = GetString(13)
    End Sub
#End Region

#Region "Memory flush"
    Private Sub tmrFlushMem_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrFlushMem.Tick
        Memory.FlushMemory()
    End Sub
#End Region

#Region "Tray icon"
    Private Sub niTrayIcon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niTrayIcon.MouseDown

        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left
                'restore main screen
                Me.WindowState = FormWindowState.Normal
                Me.ShowInTaskbar = True
                Me.Visible = True
                Me.Activate()
                niTrayIcon.Visible = False
            Case Windows.Forms.MouseButtons.Middle

            Case Windows.Forms.MouseButtons.Right

        End Select
    End Sub
#End Region

End Class
