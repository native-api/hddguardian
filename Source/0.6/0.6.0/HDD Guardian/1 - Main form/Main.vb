'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Xml

Public Class Main

    Enum StoringDevice
        Fixed = 0
        Removable = 1
    End Enum

    Dim installdevice As StoringDevice = StoringDevice.Fixed
    Dim tab_size As Size = New Size(568, 321)
    Dim tab_loc As Point = New Point(184, 88)
    Public isloading As Boolean = True
    Dim isadmin As Boolean = True

#Region "UTX Theme call"
    Private Random As Random
    <DllImport("uxtheme.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function SetWindowTheme(ByVal hWnd As IntPtr, ByVal appName As String, ByVal partList As String) As Integer

    End Function

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        SetWindowTheme(tvwComputer.Handle, "explorer", Nothing)
        SetWindowTheme(lvwAttrFormat.Handle, "explorer", Nothing)
        SetWindowTheme(lvwDevices.Handle, "explorer", Nothing)
        SetWindowTheme(lvwLog.Handle, "explorer", Nothing)
        SetWindowTheme(lvwSelective.Handle, "explorer", Nothing)
        SetWindowTheme(lvwSelfTest.Handle, "explorer", Nothing)
        SetWindowTheme(lvwSmart.Handle, "explorer", Nothing)
        SetWindowTheme(lvwChart.Handle, "explorer", Nothing)
        SetWindowTheme(lvwScsiTests.Handle, "explorer", Nothing)
        SetWindowTheme(tvwScsiErrors.Handle, "explorer", Nothing)
        SetWindowTheme(lvwProgLog.Handle, "explorer", Nothing)
        'SetWindowTheme(Settings.lvwTranlsations.Handle, "explorer", Nothing)
    End Sub
#End Region

#Region "Main form"

    Private Sub Main_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If tvwComputer.Nodes.Count > 0 Then tvwComputer.Nodes(0).Expand()
        SetWindowTheme(lvwDevices.Handle, "explorer", Nothing)
    End Sub

    Private Sub frmMain_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        On Error Resume Next

        If My.Settings.MinimizeOnTray Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.ShowInTaskbar = False
                Me.Visible = False
                niTrayIcon.Visible = True
            Else
                Me.ShowInTaskbar = True
                Me.Visible = True
                If Not IsNothing(niTrayIcon) Then niTrayIcon.Visible = My.Settings.AlwaysShowTrayIcon
            End If
        End If

        Memory.FlushMemory()
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        For Each d In devlist
            d.DisposeTrayIcon()
        Next
        niTrayIcon.Visible = False
        StopMonitorDeviceConnection()
        Me.Dispose()
        End
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim confirm As MsgBoxResult

        If My.Settings.CloseOnTray Then
            If Me.WindowState = FormWindowState.Normal Or Me.WindowState = FormWindowState.Maximized Then
                e.Cancel = True
                Me.WindowState = FormWindowState.Minimized
                Me.ShowInTaskbar = False
                Me.Visible = False
                niTrayIcon.Visible = True
            End If
        End If

        If My.Settings.ConfirmOnExit And e.CloseReason = CloseReason.UserClosing Then
            confirm = MsgBox(m_exitmsg, MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, m_exit)
            If confirm = MsgBoxResult.Cancel Then e.Cancel = True
        End If
    End Sub

    Dim on_debug As Boolean = False
    Dim savedebug As Boolean = False

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPrivate()

        Settings.LoadSettings()

        'translate interface
        InterfaceTranslation()

        'check if smartctl.exe is in the hdd guardian folder:
        'if not, the program will be closed.
        If Not IO.File.Exists(My.Application.Info.DirectoryPath & "\smartctl\smartctl.exe") Then
            MsgBox(m_nosmartctl, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, m_error)
            Me.Dispose()
            End
        End If

        'command line options
        If My.Application.CommandLineArgs.Contains("-debug") Then
            on_debug = True
            DebugWindow.Show()
        End If
        If My.Application.CommandLineArgs.Contains("-savedebug") Then savedebug = True

        isloading = True

        If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            isadmin = False
            picAdmin.Visible = True
            PrintDebug("*** Missing admin rigths! ***", False, True)
        Else
            isadmin = True
            picAdmin.Visible = False
        End If

        picNewVersion.Visible = False

        AnalyzeWMI()

        LoadTrayIcons()

        'set main window title
        With My.Application.Info
            Me.Text = .Title.ToString & " " & .Version.Major.ToString & "." & .Version.Minor.ToString & "." & .Version.Build.ToString
            If My.Resources.prerelease > 0 Then
                Me.Text += " | beta " & My.Resources.prerelease
            End If
            niTrayIcon.Text = Me.Text
        End With

        PrintDebug(Me.Text)

        '********************
        '*** about dialog ***
        '********************
        'set .NET Framework version label
        With System.Environment.Version
            About.lblFramework.Text = ".NET Framework version " & .ToString
        End With
        'load license nd change log
        About.lblLicense.Text = My.Resources.License
        About.lblChangeLog.Text = My.Resources.Changelog
        'set version and copyright
        With My.Application.Info
            About.lblVersion.Text = .Version.Major.ToString & "." & .Version.Minor.ToString & "." & .Version.Build.ToString
            If My.Resources.prerelease > 0 Then
                About.lblVersion.Text += " | beta " & My.Resources.prerelease
            End If
            About.lblCopyright.Text = .Copyright
        End With

        'uncheck and hide device options
        chkAttributes.Checked = False
        pnlAttributes.Visible = False
        chkFirmware.Checked = False
        flwFirmware.Visible = False

        LoadAttribInfos()
        LoadManufacturers()
        LoadIcons()

        Search()
        CollectDevices()
        FillDevicesList()
        FillBottomPanel()
        FillManageDeviceList()
        VitalsCheck()
        OverallHealthCheck()

        'disable from devices overview and context menu the function to scan for external
        'devices if user are not an administrator
        mnuSearchUsb.Enabled = isadmin
        rbtRescanUsb.Enabled = isadmin

        If My.Settings.StartMinimized Then
            Me.WindowState = FormWindowState.Minimized
            If My.Settings.MinimizeOnTray Then
                Me.ShowInTaskbar = False
                Me.Visible = False
                niTrayIcon.Visible = True
            End If
        End If

        If My.Settings.RememberWindowSize Then Me.Size = My.Settings.WindowSize

        'start monitoring for incoming/outcoming devices
        'only if user have administration rights, because smartctl
        'fail to open usb ports if user have a limited account
        If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            Me.Text += " | " & ApplicationServices.BuiltInRole.Administrator.ToString
            If My.Settings.MonitorUsb Then StartMonitorDeviceConnection()
        End If

        'select overview page
        InvokeOnClick(rmiOverview, System.EventArgs.Empty)

        'populate all panels for the first device in list

        If devlist(0).Type <> DeviceType.SCSI Then
            PopulateAtaPanels()
        Else
            PopulateScsiPanels()
        End If

        Memory.FlushMemory()
        isloading = False
        SetWindowTheme(lvwDevices.Handle, "explorer", Nothing)

        FillBottomPanel()
    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'display a warning when administration rights are missed
        If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            If My.Settings.StartMinimized Then
                With niTrayIcon
                    .BalloonTipTitle = GetString(4506)
                    .BalloonTipText = GetString(4507)
                    .BalloonTipIcon = ToolTipIcon.Warning
                    .ShowBalloonTip(10000)
                End With
            Else
                MsgBox(GetString(4507), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetString(4506))
            End If
        End If
    End Sub

    Private Sub Main_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If My.Settings.RememberWindowSize Then
            My.Settings.WindowSize = Me.Size

            If Me.WindowState = FormWindowState.Maximized Then My.Settings.Maximized = True Else My.Settings.Maximized = False

            If Not isloading_settings Then Settings.SaveSettings()
        End If
    End Sub
#End Region

#Region "Flush memory timer"
    Private Sub tmrFlushMem_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrFlushMem.Tick
        Memory.FlushMemory()
    End Sub
#End Region

#Region "Tray icon"
    Private Sub niTrayIcon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niTrayIcon.MouseDown
        niTrayIcon.ContextMenu = cmTrayIcon

        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left
                'restore main screen
                Me.WindowState = FormWindowState.Normal
                Me.ShowInTaskbar = True
                Me.Visible = True
                Me.Activate()
                niTrayIcon.Visible = My.Settings.AlwaysShowTrayIcon
            Case Windows.Forms.MouseButtons.Middle
                'if is pressed the middle button refresh all devices
                UpdateAll(DeviceType.ATA)
                UpdateAll(DeviceType.USB)
                UpdateAll(DeviceType.Virtual)
            Case Windows.Forms.MouseButtons.Right
                'none. Automatically display trayicon context menu
        End Select
    End Sub
#End Region

#Region "Timers"
    Private Sub RefreshNonRemovable(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefresh.Tick
        PrintDebug("Checking for updated devices values")
        CheckForUpdates()
        PrintDebug("Updating internal devices")
        UpdateAll(DeviceType.ATA)
        UpdateAll(DeviceType.SCSI)
    End Sub

    Private Sub RefreshRemovable(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefreshExt.Tick
        UpdateAll(DeviceType.USB)
    End Sub

    Private Sub RefreshVirtual(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefreshVirtual.Tick
        UpdateAll(DeviceType.Virtual)
    End Sub
#End Region

#Region "Tray icon context menu"
    Private Sub DevRefresh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CheckForUpdates()
        UpdateAll(DeviceType.ATA)
        UpdateAll(DeviceType.SCSI)
        UpdateAll(DeviceType.USB)
        UpdateAll(DeviceType.Virtual)

        Memory.FlushMemory()
    End Sub

    Private Sub mnuRestore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRestoreTray.Click
        If Me.WindowState = FormWindowState.Minimized Then
            If My.Settings.RememberWindowSize Then
                If My.Settings.Maximized Then
                    Me.WindowState = FormWindowState.Maximized
                Else
                    Me.Size = My.Settings.WindowSize
                    Me.WindowState = FormWindowState.Normal
                End If
            Else
                Me.WindowState = FormWindowState.Normal
            End If
            'Me.Size = New Size(757, 460)
            'Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            Me.Visible = True
            Me.Activate()
            niTrayIcon.Visible = My.Settings.AlwaysShowTrayIcon
        End If
    End Sub

    Private Sub ExitProgram(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExitTray.Click
        Dim confirm As MsgBoxResult
        If My.Settings.ConfirmOnExit Then
            confirm = MsgBox(m_exitmsg, MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, m_exit)
            If confirm = MsgBoxResult.Cancel Then Exit Sub
        End If

        For Each d In devlist
            d.DisposeTrayIcon()
        Next

        niTrayIcon.Visible = False
        Me.Dispose()
        End
    End Sub
#End Region

#Region "Keyboard shortcuts"
    Private Sub ShortcutKeys(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim d As Device = devlist(lvwDevices.SelectedItems(0).Index)

        Select Case e.KeyValue
            Case Keys.F5
                'mnuMain.PerformClick()
            Case Keys.F6
                'If Not d.IsScsi Then mnuPerformance.PerformClick()
            Case Keys.F7
                'mnuMonitoring.PerformClick()
            Case Keys.F8
                'If Not d.IsScsi Then mnuAdvanced.PerformClick()
            Case Keys.F9
                'mnuSmartctl.PerformClick()
            Case Keys.F1
                'mnuHelp.PerformClick()
        End Select

        'If e.Alt And e.KeyValue = Keys.F4 Then mnuExit.PerformClick()
    End Sub
#End Region

#Region "Main menu"
    Private Sub rfiFile_Click(sender As Object, e As EventArgs) Handles rfiFile.Click
        cmFile.Show(rfiFile, New Point(rfiFile.Location.X - 2, rfiFile.Location.Y + rfiFile.Height - 2))
    End Sub

    Private Sub rmiOverview_Click(sender As Object, e As EventArgs) Handles rmiOverview.Click
        htcMain.SelectPage(tpOverview)
    End Sub

    Private Sub rmiManage_Click(sender As Object, e As EventArgs) Handles rmiManage.Click
        htcMain.SelectPage(tpManage)
    End Sub

    Private Sub rmiWmiDevices_Click(sender As Object, e As EventArgs) Handles rmiWmiDevices.Click
        htcMain.SelectPage(tpWmiDevices)
    End Sub

    Private Sub rmiDebug_Click(sender As Object, e As EventArgs) Handles rmiDebug.Click
        htcMain.SelectPage(tpDebug)
    End Sub
#End Region

#Region "File menu items"
    Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click
        Settings.ShowDialog(Me)
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        About.ShowDialog(Me)
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Dim confirm As MsgBoxResult
        If My.Settings.ConfirmOnExit Then
            confirm = MsgBox(m_exitmsg, MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, m_exit)
            If confirm = MsgBoxResult.Cancel Then Exit Sub
        End If

        StopMonitorDeviceConnection()

        For Each d In devlist
            d.DisposeTrayIcon()
        Next

        niTrayIcon.Visible = False
        Me.Dispose()
        End
    End Sub
#End Region

#Region "Devices Overview"

#Region "Ribbon buttons"
    Private Sub rbtUpdateAll_Click(sender As Object, e As EventArgs) Handles rbtUpdateAll.Click
        UpdateAll(DeviceType.ATA)
        UpdateAll(DeviceType.SCSI)
        UpdateAll(DeviceType.USB)
        UpdateAll(DeviceType.Virtual)

        Memory.FlushMemory()
    End Sub

    Private Sub rbtRescanUsb_Click(sender As Object, e As EventArgs) Handles rbtRescanUsb.Click
        'UsbDevicesComparison()
        'eSataDevicesComparison()
        RemoveUsbDevices()
        AddUsbDevices()

        Memory.FlushMemory()
    End Sub

    Private Sub rbtAddVirtual_Click(sender As Object, e As EventArgs) Handles rbtAddVirtual.Click
        Dim after As Short

        after = lvwDevices.Items.Count

        AddVirtual.ShowDialog(Me)

        If lvwDevices.Items.Count > after Then UpdateCurrent()

        Memory.FlushMemory()
    End Sub

    Private Sub picOverviewHelp_Click(sender As Object, e As EventArgs) Handles picOverviewHelp.Click
        Try
            System.Diagnostics.Process.Start("http://code.google.com/p/hddguardian/wiki/overview")
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub
#End Region

#Region "Devices list"
    Dim current As Short
    Dim loadnow As Boolean = True

    Private Sub SetMenu(ByVal dev As Device)
        If Not IO.Directory.Exists(My.Settings.XmlFolder) Then
            mnuXmlCreate.Enabled = False
            mnuXmlCreate.Checked = False
        Else
            mnuXmlCreate.Enabled = True
            mnuXmlCreate.Checked = My.Settings.ExportToXml
        End If

        mnuInfoPanel.Checked = My.Settings.InfoPanel

        If IsNothing(dev) Then
            mnuTrayLife.Enabled = False
            mnuTrayLife.Checked = False
            mnuTrayTemperature.Enabled = False
            mnuTrayTemperature.Checked = False
            mnuShareThis.Enabled = False
            mnuShareThis.Checked = False
            Exit Sub
        End If

        If Not IO.Directory.Exists(My.Settings.SharingFolder) Then
            mnuShareThis.Enabled = False
            mnuShareThis.Checked = False
        Else
            mnuShareThis.Enabled = True
            mnuShareThis.Checked = dev.IsShared
        End If

        If dev.Type = DeviceType.Virtual Then
            mnuRemoveVirtualDev.Enabled = True
            mnuShareThis.Enabled = False
            mnuShareThis.Checked = False
            mnuTrayLife.Enabled = False
            mnuTrayLife.Checked = False
            mnuTrayTemperature.Enabled = False
            mnuTrayTemperature.Checked = False
        Else
            mnuRemoveVirtualDev.Enabled = False
            mnuTrayLife.Enabled = dev.IsSsd
            mnuTrayTemperature.Enabled = True
        End If

        If mnuShareThis.Enabled Then mnuShareThis.Checked = dev.IsShared

        If Not IO.Directory.Exists(My.Settings.XmlFolder) Then
            mnuXmlCreate.Enabled = False
            mnuXmlCreate.Checked = False
        Else
            mnuXmlCreate.Enabled = True
            mnuXmlCreate.Checked = My.Settings.ExportToXml
        End If

        If dev.DisplayTrayIcon Then
            If dev.DisplayLife Then
                mnuTrayLife.Checked = True
                mnuTrayTemperature.Checked = False
            Else
                mnuTrayTemperature.Checked = True
                mnuTrayLife.Checked = False
            End If
        Else
            mnuTrayLife.Checked = False
            mnuTrayTemperature.Checked = False
        End If

    End Sub

    Private Sub lvwDevices_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles lvwDevices.Invalidated
        Main.SetWindowTheme(lvwDevices.Handle, "explorer", Nothing)
    End Sub

    Private Sub lvwDevices_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvwDevices.MouseUp
        Try
            Dim lvItem As ListViewItem

            lvItem = lvwDevices.GetItemAt(e.X, e.Y)

            If Not IsNothing(lvItem) Then current = lvwDevices.SelectedItems(0).Index
            lvwDevices.Items(current).Selected = True

            If e.Button = MouseButtons.Right And Not IsNothing(lvItem) Then
                lvwDevices.Items(lvItem.Index).Selected = True
                Dim dev As Device = devlist(lvItem.Index)
                mnuRefreshSel.Enabled = True
                SetMenu(dev)
                mnuTitle.Text = dev.Model
                cmDevices.Show(CType(sender, ListView), New Point(e.X, e.Y))
            ElseIf e.Button = MouseButtons.Right And IsNothing(lvItem) Then
                mnuRemoveVirtualDev.Enabled = False
                mnuRefreshSel.Enabled = False
                mnuTitle.Text = "HDD Guardian"
                SetMenu(Nothing)
                cmDevices.Show(CType(sender, ListView), New Point(e.X, e.Y))
            End If
        Catch ex As Exception
            PrintDebug("Error on devices list: " & ex.Message)
        End Try

    End Sub

    Private Sub lvwDevices_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwDevices.ItemSelectionChanged
        If isloading Then Exit Sub
        If e.IsSelected And loadnow And Not Me.ResizeRedraw Then

            Dim dev As Device = devlist(e.ItemIndex)

            FillBottomPanel()

            If dev.TestIsRunnig Then
                pnlProgress.Visible = True
                tlpTest.Enabled = False
                btnRun.Enabled = False
                tmrTest.Start()
            Else
                pnlProgress.Visible = False
                tlpTest.Enabled = True
                btnRun.Enabled = True
                tmrTest.Stop()
            End If
        End If
    End Sub
#End Region

#Region "Devices list context menu"

#Region "Refresh"
    Private Sub mnuUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRefreshSel.Click
        UpdateCurrent()

        Memory.FlushMemory()
    End Sub

    Private Sub mnuUpdateAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRefreshAll.Click
        CheckForUpdates()
        UpdateAll(DeviceType.ATA)
        UpdateAll(DeviceType.SCSI)
        UpdateAll(DeviceType.USB)
        UpdateAll(DeviceType.Virtual)

        Memory.FlushMemory()
    End Sub
#End Region

#Region "Search USB"
    Private Sub mnuRescanExternal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSearchUsb.Click
        'UsbDevicesComparison()
        'eSataDevicesComparison()
        RemoveUsbDevices()
        AddUsbDevices()

        Memory.FlushMemory()
    End Sub
#End Region

#Region "Virtual devices"
    Private Sub mnuAddVirtual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddVirtualDev.Click
        Dim cur As Short = lvwDevices.Items.Count

        AddVirtual.ShowDialog(Me)

        If lvwDevices.Items.Count > cur Then UpdateCurrent()

        Memory.FlushMemory()
    End Sub

    Private Sub mnuRemoveVirtual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRemoveVirtualDev.Click
        Dim virtualfolder As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData _
                                      .Substring(0, My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.LastIndexOf("\")) _
                                      & "\Virtual devices\"
        Dim i As Short = lvwDevices.SelectedItems(0).Index

        With lvwDevices
            .Items(i).Remove()
            .Groups(2).Header = .Groups(2).Tag & " - " & .Groups(2).Items.Count
            .Items(0).Selected = True
            SetWindowTheme(.Handle, "explorer", Nothing)
        End With
        File.Delete(virtualfolder & devlist(i).DeviceFileName & ".vd")
        devlist.RemoveAt(i)

        FillManageDeviceList()
    End Sub
#End Region

#Region "Tray icon"
    Private Sub mnuTrayTemperature_Click(sender As Object, e As EventArgs) Handles mnuTrayTemperature.Click
        mnuTrayLife.Checked = False
        mnuTrayTemperature.Checked = Not mnuTrayTemperature.Checked

        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)
        dev.DisplayLife = False
        dev.DisplayTrayIcon = mnuTrayTemperature.Checked
    End Sub

    Private Sub mnuTrayLife_Click(sender As Object, e As EventArgs) Handles mnuTrayLife.Click
        mnuTrayTemperature.Checked = False
        mnuTrayLife.Checked = Not mnuTrayLife.Checked

        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)
        dev.DisplayLife = True
        dev.DisplayTrayIcon = mnuTrayLife.Checked
    End Sub

    Private Sub mnuInfoPanel_Click(sender As Object, e As EventArgs) Handles mnuInfoPanel.Click
        mnuInfoPanel.Checked = Not mnuInfoPanel.Checked
        Settings.chkInfoPanel.Checked = mnuInfoPanel.Checked
    End Sub
#End Region

#Region "Sharing"
    Private Sub mnuSharingFolder_Click(sender As Object, e As EventArgs) Handles mnuSharingFolder.Click
        With dlgFolder
            .Description = Settings.lblSelFolder.Text
            Dim result As DialogResult = .ShowDialog(Me)
            If result = DialogResult.OK Then
                mnuShareThis.Enabled = True

                Settings.lblFolder.Text = .SelectedPath
                Settings.lblFolder.Visible = True
                'Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)

                'isloading_features = True
                'CommonPanels.chkEnableShare.Checked = dev.IsShared
                'CommonPanels.chkEnableShare.Enabled = True
                'isloading_features = False

                Settings.SaveSettings() '("sharing")
            End If
        End With
    End Sub


    Private Sub mnuShareThis_Click(sender As Object, e As EventArgs) Handles mnuShareThis.Click
        mnuShareThis.Checked = Not mnuShareThis.Checked
        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)
        dev.IsShared = mnuShareThis.Checked
        Settings.SaveSettings() '("")
    End Sub
#End Region

#Region "Xml"
    Private Sub mnuXmlFolder_Click(sender As Object, e As EventArgs) Handles mnuXmlFolder.Click
        With dlgFolder
            .Description = Settings.lblXml.Text
            Dim result As DialogResult = .ShowDialog(Me)
            If result = DialogResult.OK Then
                mnuXmlCreate.Enabled = True
                Settings.lblXmlPath.Text = .SelectedPath
                Settings.lblXmlPath.Visible = True
                Settings.SaveSettings() '("")
            End If
        End With
    End Sub

    Private Sub mnuXmlCreate_Click(sender As Object, e As EventArgs) Handles mnuXmlCreate.Click
        mnuXmlCreate.Checked = Not mnuXmlCreate.Checked
        Settings.chkXml.Checked = mnuXml.Checked
        Settings.btnXml.Enabled = mnuXml.Checked
        If Not isloading_settings Then Settings.SaveSettings() '("")
    End Sub
#End Region

#End Region

#Region "Bottom panel"
    Private Sub lnkManufacturer_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkManufacturer.LinkClicked
        Try
            System.Diagnostics.Process.Start(sender.Tag)
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub
#End Region

#End Region

#Region "Manage"

#Region "Manage: device selection"
    Private Sub cboDevices_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cboDevices.DrawItem
        Dim column1, column2, column3 As Integer

        For Each d As Device In devlist
            Dim txtsize As Size
            If Not d.Type = DeviceType.Virtual Then
                Dim loc() As String = d.Location.ToString.Split(" ")
                txtsize = TextRenderer.MeasureText(loc(0), Me.Font)
            Else
                txtsize = TextRenderer.MeasureText(d.VirtualDeviceInfo.Description, Me.Font)
            End If
            If txtsize.Width + 5 > column1 Then column1 = txtsize.Width + 5

            Dim txtsize2 As Size = TextRenderer.MeasureText(d.Model, Me.Font)
            If txtsize2.Width + 5 > column2 Then column2 = txtsize2.Width + 5

            Dim txtsize3 As Size = TextRenderer.MeasureText(d.SerialNumber, Me.Font)
            If txtsize3.Width + 5 > column3 Then column3 = txtsize3.Width + 5
        Next

        e.DrawBackground()

        Try
            Dim di As Device = devlist(e.Index)

            Dim xLeft As Integer = e.Bounds.Location.X
            Dim yTop As Integer = e.Bounds.Location.Y

            'draw first string (location/description)
            If Not di.Type = DeviceType.Virtual Then
                Dim loc() As String = di.Location.ToString.Split(" ")
                TextRenderer.DrawText(e.Graphics, loc(0), e.Font, New Point(xLeft, yTop), Color.LightGray)
            Else
                TextRenderer.DrawText(e.Graphics, di.VirtualDeviceInfo.Description, e.Font, New Point(xLeft, yTop), Color.LightGray)
            End If
            'draw second string (device model)
            TextRenderer.DrawText(e.Graphics, di.Model, e.Font, New Point(column1, yTop), e.ForeColor, TextFormatFlags.Left)
            'draw third string (device serial number)
            TextRenderer.DrawText(e.Graphics, di.SerialNumber, e.Font, New Point(column1 + column2, yTop), e.ForeColor, TextFormatFlags.Left)

            e.DrawFocusRectangle()
        Catch
        End Try
    End Sub

    Private Sub cboDevices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDevices.SelectedIndexChanged
        DisableSections()

        If devlist(cboDevices.SelectedIndex).IsScsi Then
            MoveToScsi()
            PopulateScsiPanels()
        Else
            MoveToAta()
            PopulateAtaPanels()
        End If
    End Sub

    Public Sub DisableSections()
        Dim d As Device = devlist(cboDevices.SelectedIndex)

        For Each Control In tlpInfo.Controls
            Control.Enabled = True
        Next
        For Each Control In tlpSetup.Controls
            Control.Enabled = True
        Next
        For Each Control In tlpErrorsTests.Controls
            Control.Enabled = True
        Next
        For Each Control In tlpSmartctl.Controls
            Control.Enabled = True
        Next

        If d.IsScsi Then
            robAttributes.Enabled = False
            robAam.Enabled = False
            robApm.Enabled = False
            robStandby.Enabled = False
            robReadWrite.Enabled = False
            'robTolerance.Enabled = False
            robRemap.Enabled = False
            robFirmware.Enabled = False
            'robPowerMode.Enabled = False
        End If

        If d.SmartEnabled <> Support.Enabled Then
            For Each Control In tlpInfo.Controls
                Control.Enabled = False
            Next
            robInfo.Enabled = True
            For Each Control In tlpSetup.Controls
                Control.Enabled = False
            Next
            For Each Control In tlpErrorsTests.Controls
                Control.Enabled = False
            Next
            For Each Control In tlpSmartctl.Controls
                Control.Enabled = False
            Next
            robOutput.Enabled = True

            If d.IsScsi Then
                htcInfo.SelectPage(tpScsiInfo)
            Else
                htcInfo.SelectPage(tpAtaInfo)
            End If

            InvokeOnClick(robInfo, Nothing)
        End If
    End Sub

    Public Sub MoveToScsi()
        'info
        If robAttributes.Checked Then InvokeOnClick(robInfo, Nothing)
        If htcInfo.SelectedTab Is tpAtaInfo Then htcInfo.SelectPage(tpScsiInfo)
        If htcInfo.SelectedTab Is tpAtaHealth Then htcInfo.SelectPage(tpScsiHealth)
        'setup
        If robAam.Checked Or robApm.Checked Or robStandby.Checked Or robReadWrite.Checked Then InvokeOnClick(robSmartSetup, Nothing)
        If htcSetup.SelectedTab Is tpAtaSmartSetup Then htcSetup.SelectPage(tpScsiSmartSetup)
        'errors and tests
        If htcErrorsTests.SelectedTab Is tpAtaErrors Then htcErrorsTests.SelectPage(tpScsiErrors)
        If htcErrorsTests.SelectedTab Is tpAtaTests Then htcErrorsTests.SelectPage(tpScsiTests)
        If htcErrorsTests.SelectedTab Is tpAtaRunTest Then htcErrorsTests.SelectPage(tpScsiRunTest)
        'smartctl
        'If robTolerance.Checked Or robRemap.Checked Or robFirmware.Checked Or robPowerMode.Checked Then InvokeOnClick(robOutput, Nothing)
        If robRemap.Checked Or robFirmware.Checked Then InvokeOnClick(robOutput, Nothing)
    End Sub

    Public Sub MoveToAta()
        'info
        If htcInfo.SelectedTab Is tpScsiInfo Then htcInfo.SelectPage(tpAtaInfo)
        If htcInfo.SelectedTab Is tpScsiHealth Then htcInfo.SelectPage(tpAtaHealth)
        'setup
        If htcSetup.SelectedTab Is tpScsiSmartSetup Then htcSetup.SelectPage(tpAtaSmartSetup)
        'errors and tests
        If htcErrorsTests.SelectedTab Is tpScsiErrors Then htcErrorsTests.SelectPage(tpAtaErrors)
        If htcErrorsTests.SelectedTab Is tpScsiTests Then htcErrorsTests.SelectPage(tpAtaTests)
        If htcErrorsTests.SelectedTab Is tpScsiRunTest Then htcErrorsTests.SelectPage(tpAtaRunTest)
        'smartctl is not needed
    End Sub

    Private Sub btnReloadDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReloadDevice.Click
        If devlist(cboDevices.SelectedIndex).IsScsi Then
            MoveToScsi()
            PopulateScsiPanels()
        Else
            MoveToAta()
            PopulateAtaPanels()
        End If

        DisableSections()
    End Sub
#End Region

#Region "Manage: ribbon buttons"

    Enum Sections
        Info = 0
        Setup = 1
        ErrorsTests = 2
        Smartctl = 3
    End Enum

    Private Sub DeselectSection(ByVal s As Sections)
        Select Case s
            Case Sections.Info
                For Each Control In tlpInfo.Controls
                    Control.Checked = False
                Next
            Case Sections.Setup
                For Each Control In tlpSetup.Controls
                    Control.Checked = False
                Next
            Case Sections.ErrorsTests
                For Each Control In tlpErrorsTests.Controls
                    Control.Checked = False
                Next
            Case Sections.Smartctl
                For Each Control In tlpSmartctl.Controls
                    Control.Checked = False
                Next
        End Select
    End Sub

    Private Sub picManageHelp_Click(sender As Object, e As EventArgs) Handles picManageHelp.Click
        Try
            System.Diagnostics.Process.Start(picManageHelp.Tag)
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub

#Region "Info"
    Private Sub robInfo_Click(sender As Object, e As EventArgs) Handles robInfo.Click
        If Not htcManage.SelectedTab Is tpInfo Then
            htcManage.SelectPage(tpInfo)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.ErrorsTests)
            DeselectSection(Sections.Smartctl)
        End If

        Dim d As Device = devlist(cboDevices.SelectedIndex)

        If d.IsScsi Then
            htcInfo.SelectPage(tpScsiInfo)
        Else
            htcInfo.SelectPage(tpAtaInfo)
        End If

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/device_informations"
    End Sub

    Private Sub robHealth_Click(sender As Object, e As EventArgs) Handles robHealth.Click
        If Not htcManage.SelectedTab Is tpInfo Then
            htcManage.SelectPage(tpInfo)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.ErrorsTests)
            DeselectSection(Sections.Smartctl)
        End If

        Dim d As Device = devlist(cboDevices.SelectedIndex)

        If d.IsScsi Then
            htcInfo.SelectPage(tpScsiHealth)
        Else
            htcInfo.SelectPage(tpAtaHealth)
        End If

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/device_health"
    End Sub

    Private Sub robAttributes_Click(sender As Object, e As EventArgs) Handles robAttributes.Click
        If Not htcManage.SelectedTab Is tpInfo Then
            htcManage.SelectPage(tpInfo)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.ErrorsTests)
            DeselectSection(Sections.Smartctl)
        End If

        htcInfo.SelectPage(tpAtaSmartAttributes)
    End Sub

    Private Sub robEventsLog_Click(sender As Object, e As EventArgs) Handles robEventsLog.Click
        If Not htcManage.SelectedTab Is tpInfo Then
            htcManage.SelectPage(tpInfo)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.ErrorsTests)
            DeselectSection(Sections.Smartctl)
        End If

        htcInfo.SelectPage(tpEventsLog)

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/events_log"
    End Sub

    Private Sub robEventsChart_Click(sender As Object, e As EventArgs) Handles robEventsChart.Click
        If Not htcManage.SelectedTab Is tpInfo Then
            htcManage.SelectPage(tpInfo)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.ErrorsTests)
            DeselectSection(Sections.Smartctl)
        End If

        htcInfo.SelectPage(tpEventsChart)

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/events_chart"
    End Sub
#End Region

#Region "Setup"
    Private Sub robSmartSetup_Click(sender As Object, e As EventArgs) Handles robSmartSetup.Click
        If Not htcManage.SelectedTab Is tpSetup Then
            htcManage.SelectPage(tpSetup)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.ErrorsTests)
            DeselectSection(Sections.Smartctl)
        End If

        Dim d As Device = devlist(cboDevices.SelectedIndex)

        If d.IsScsi Then
            htcSetup.SelectPage(tpScsiSmartSetup)
        Else
            htcSetup.SelectPage(tpAtaSmartSetup)
        End If

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/smart_setup"
    End Sub

    Private Sub robAam_Click(sender As Object, e As EventArgs) Handles robAam.Click
        If Not htcManage.SelectedTab Is tpSetup Then
            htcManage.SelectPage(tpSetup)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.ErrorsTests)
            DeselectSection(Sections.Smartctl)
        End If

        htcSetup.SelectPage(tpAtaAam)

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/aam"
    End Sub

    Private Sub robApm_Click(sender As Object, e As EventArgs) Handles robApm.Click
        If Not htcManage.SelectedTab Is tpSetup Then
            htcManage.SelectPage(tpSetup)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.ErrorsTests)
            DeselectSection(Sections.Smartctl)
        End If

        htcSetup.SelectPage(tpAtaApm)

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/apm"
    End Sub

    Private Sub robStandby_Click(sender As Object, e As EventArgs) Handles robStandby.Click
        If Not htcManage.SelectedTab Is tpSetup Then
            htcManage.SelectPage(tpSetup)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.ErrorsTests)
            DeselectSection(Sections.Smartctl)
        End If

        htcSetup.SelectPage(tpAtaStandby)

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/standby"
    End Sub

    Private Sub robReadWrite_Click(sender As Object, e As EventArgs) Handles robReadWrite.Click
        If Not htcManage.SelectedTab Is tpSetup Then
            htcManage.SelectPage(tpSetup)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.ErrorsTests)
            DeselectSection(Sections.Smartctl)
        End If

        htcSetup.SelectPage(tpAtaReadWrite)

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/readwrite_options"
    End Sub
#End Region

#Region "Errors and tests"
    Private Sub robErrorsLog_Click(sender As Object, e As EventArgs) Handles robErrorsLog.Click
        If Not htcManage.SelectedTab Is tpErrorsTests Then
            htcManage.SelectPage(tpErrorsTests)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.Smartctl)
        End If

        Dim d As Device = devlist(cboDevices.SelectedIndex)

        If d.IsScsi Then
            htcErrorsTests.SelectPage(tpScsiErrors)
        Else
            htcErrorsTests.SelectPage(tpAtaErrors)
        End If

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/errors"
    End Sub

    Private Sub robTestsLog_Click(sender As Object, e As EventArgs) Handles robTestsLog.Click
        If Not htcManage.SelectedTab Is tpErrorsTests Then
            htcManage.SelectPage(tpErrorsTests)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.Smartctl)
        End If

        Dim d As Device = devlist(cboDevices.SelectedIndex)

        If d.IsScsi Then
            htcErrorsTests.SelectPage(tpScsiTests)
        Else
            htcErrorsTests.SelectPage(tpAtaTests)
        End If

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/tests_log"
    End Sub

    Private Sub robRunTest_Click(sender As Object, e As EventArgs) Handles robRunTest.Click
        If Not htcManage.SelectedTab Is tpErrorsTests Then
            htcManage.SelectPage(tpErrorsTests)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.Smartctl)
        End If

        Dim d As Device = devlist(cboDevices.SelectedIndex)

        If d.IsScsi Then
            htcErrorsTests.SelectPage(tpScsiRunTest)
        Else
            htcErrorsTests.SelectPage(tpAtaRunTest)
        End If

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/run_test"
    End Sub
#End Region

#Region "Smartctl"
    Private Sub robOutput_Click(sender As Object, e As EventArgs) Handles robOutput.Click
        If Not htcManage.SelectedTab Is tpSmartctl Then
            htcManage.SelectPage(tpSmartctl)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.ErrorsTests)
        End If

        htcSmartctl.SelectPage(tpOutput)

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/smartctl_output"
    End Sub

    Private Sub robRemap_Click(sender As Object, e As EventArgs) Handles robRemap.Click
        If Not htcManage.SelectedTab Is tpSmartctl Then
            htcManage.SelectPage(tpSmartctl)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.ErrorsTests)
        End If

        htcSmartctl.SelectPage(tpAttrRemap)

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/smartctl_remap"
    End Sub

    Private Sub robFirmware_Click(sender As Object, e As EventArgs) Handles robFirmware.Click
        If Not htcManage.SelectedTab Is tpSmartctl Then
            htcManage.SelectPage(tpSmartctl)
            DeselectSection(Sections.Info)
            DeselectSection(Sections.Setup)
            DeselectSection(Sections.ErrorsTests)
        End If

        htcSmartctl.SelectPage(tpFirmware)

        picManageHelp.Tag = "http://code.google.com/p/hddguardian/wiki/smartctl_firmware"
    End Sub
#End Region

#End Region

#Region "ATA"

#Region "Info"
    Private Sub lnkUpdateDatabase_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUpdateDatabase.LinkClicked
        If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\update-smart-drivedb.exe") Then
            Shell(My.Application.Info.DirectoryPath & "\update-smart-drivedb.exe", AppWinStyle.NormalFocus, False)
        End If
    End Sub

    Private Sub lnkAtaManufacturer_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAtaManufacturer.LinkClicked
        Try
            System.Diagnostics.Process.Start(sender.Tag)
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub

    Private Sub WarningLinks_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkWeb1.LinkClicked, lnkWeb2.LinkClicked, lnkWeb3.LinkClicked
        Try
            System.Diagnostics.Process.Start(sender.Text)
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub
#End Region

#Region "SMART setup"

    Private Sub chkEnableSmart_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkEnableSmart.MouseDown
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If dev.Type = DeviceType.Virtual Or isloading_features Then Exit Sub

        Select Case dev.SmartEnabled ' chkEnableSmart.Checked
            Case Support.Disabled   'True
                dev.SetSmartStatus(SmartFeature.Enable)
                dev.Update()
                Select Case dev.SmartEnabled
                    Case Support.Enabled
                        MsgBox(m_smartenabled.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                        chkEnableSmart.Checked = True
                        chkEnableOffline.Enabled = True
                        chkEnableAutosave.Enabled = True
                    Case Support.Ambiguous
                        MsgBox(m_smartambiguous.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, m_message)
                        chkEnableSmart.Checked = False
                    Case Support.Disabled
                        MsgBox(m_smartnotsupported.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, m_message)
                        chkEnableSmart.Checked = False
                End Select
            Case Support.Enabled  ' False
                Dim qst As MsgBoxResult = MsgBox(m_qdisablesmart.Replace("%", dev.Model), MsgBoxStyle.YesNo + MsgBoxStyle.Question, m_question)
                If qst = MsgBoxResult.Yes Then
                    dev.SetSmartStatus(SmartFeature.Disable)
                    dev.Update()
                    MsgBox(m_smartdisabled.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                    chkEnableSmart.Checked = False
                    chkEnableOffline.Checked = False
                    chkEnableOffline.Enabled = False
                    chkEnableAutosave.Checked = False
                    chkEnableAutosave.Enabled = False
                End If
        End Select

        PopulateAtaPanels()
        'PopulateCapabilities()
    End Sub

    Private Sub chkEnableOffline_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkEnableOffline.MouseDown
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If dev.Type = DeviceType.Virtual Or isloading_features Then Exit Sub

        Select Case dev.OfflineCollectionStatus ' chkEnableOffline.Checked
            Case Support.Enabled  ' True
                Dim qst As MsgBoxResult = MsgBox(m_qdisableoffldata.Replace("%", dev.Model), MsgBoxStyle.YesNo + MsgBoxStyle.Question, m_question)
                If qst = MsgBoxResult.Yes Then
                    dev.SetOfflineCollectionStatus(SmartFeature.Disable)
                    dev.Update()
                    If dev.OfflineCollectionStatus = Support.Disabled Then
                        MsgBox(m_offldatadisabled.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                        chkEnableOffline.Checked = False
                    ElseIf dev.OfflineCollectionStatus = Support.Enabled Then
                        MsgBox(m_unabletodisable.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                        chkEnableOffline.Checked = True
                    End If
                End If
            Case Support.Disabled ' False
                dev.SetOfflineCollectionStatus(SmartFeature.Enable)
                dev.Update()
                txtReport.Text = dev.Output
                Select Case dev.OfflineCollectionStatus
                    Case Support.Enabled
                        MsgBox(m_offldataenabled.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                        chkEnableOffline.Checked = True
                    Case Support.Disabled
                        MsgBox(m_offldatanotsupported.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, m_message)
                        chkEnableOffline.Checked = False
                End Select
        End Select

        PopulateAtaPanels()
        'UpdateCurrent()
    End Sub

    Private Sub chkEnableAutosave_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableAutosave.CheckedChanged
        If isloading_devsettings Or lvwDevices.Items.Count = 0 Then Exit Sub

        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If dev.Type = DeviceType.Virtual Then Exit Sub

        'If installdevice = StoringDevice.Fixed Then
        SaveDeviceSettings()

        'Else
        'SaveDeviceSettings()
        'End If
    End Sub

#End Region

#Region "AAM"
    Private Sub trkAam_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkAam.Scroll
        lnkSetAam.Visible = True
        lnkUndoAam.Visible = True
        lblAamValue.Text = lblAamValue.Tag & ": " & trkAam.Value
    End Sub

    Private Sub lnkSetAam_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSetAam.LinkClicked
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        lnkUndoAam.Visible = False

        tlpAamWaitMessage.Visible = True
        lblAamWaitMessage.Refresh()
        picLoaderAam.Refresh()

        If trkAam.Value = 0 Then
            dev.AamValue = "off"
        Else
            dev.AamValue = trkAam.Value
        End If

        tlpAamWaitMessage.Visible = False

        txtReport.Text = dev.Output
    End Sub

    Private Sub lnkSetRecommended_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSetRecommended.LinkClicked
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        lnkUndoAam.Visible = False

        tlpAamWaitMessage.Visible = True
        lblAamWaitMessage.Refresh()
        picLoaderAam.Refresh()

        lblAamValue.Text = lblAamValue.Tag & ": " & dev.RecommendedAAM
        trkAam.Value = dev.RecommendedAAM
        dev.AamValue = dev.RecommendedAAM

        tlpAamWaitMessage.Visible = False

        txtReport.Text = dev.Output
    End Sub

    Private Sub lnkUndoAam_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUndoAam.LinkClicked
        Dim dev As Device = devlist(cboDevices.SelectedIndex)
        trkAam.Value = dev.AamValue
        lnkUndoAam.Visible = False
    End Sub
#End Region

#Region "APM"
    Private Sub trkApm_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkApm.Scroll
        lnkSetApm.Visible = True
        lnkUndoApm.Visible = True
        lblApmValue.Text = lblApmValue.Tag & ": " & trkApm.Value
    End Sub

    Private Sub lnkSetApm_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSetApm.LinkClicked
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        lnkUndoApm.Visible = False
        
        tlpApmWaitMessage.Visible = True
        lblApmWaitMessage.Refresh()
        picLoaderApm.Refresh()

        If trkApm.Value = 0 Then
            dev.ApmValue = "off"
        Else
            dev.ApmValue = trkApm.Value
        End If

        tlpApmWaitMessage.Visible = False

        txtReport.Text = dev.Output
    End Sub

    Private Sub lnkUndoApm_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUndoApm.LinkClicked
        Dim dev As Device = devlist(cboDevices.SelectedIndex)
        trkApm.Value = dev.ApmValue
        lnkUndoApm.Visible = False
    End Sub
#End Region

#Region "Standby"
    Private Sub trkStandby_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkStandby.Scroll
        lnkUndoStandby.Visible = True
        Select Case trkStandby.Value
            Case 0
                lblStandbyValue.Text = lblStandbyValue.Tag & ": 0 (" & m_off & ")"
            Case 1 To 240
                Dim time As Short = trkStandby.Value * 5
                Dim minutes, seconds As Short
                If time > 60 Then
                    minutes = time \ 60
                    seconds = (time / 60 - minutes) * 60
                Else
                    minutes = 0
                    seconds = time
                End If
                Dim min As String = String.Format("{0:D2}", minutes)
                Dim sec As String = String.Format("{0:D2}", seconds)
                lblStandbyValue.Text = lblStandbyValue.Tag & ": " & trkStandby.Value & " (" & min & "'" & sec & """)"
            Case 241 To 251
                Dim time As Short = trkStandby.Value * 30
                Dim minutes, hours As Short
                If time > 60 Then
                    hours = time \ 60
                    minutes = (time / 60 - hours) * 60
                Else
                    hours = 0
                    minutes = time
                End If
                Dim min As String = String.Format("{0:D2}", minutes)
                Dim h As String = String.Format("{0:D2}", hours)
                lblStandbyValue.Text = lblStandbyValue.Tag & ": " & trkStandby.Value & " (" & h & "h " & min & "')"
            Case 252
                lblStandbyValue.Text = lblStandbyValue.Tag & ": " & trkStandby.Value & " (21'00"")"
            Case 253
                lblStandbyValue.Text = lblStandbyValue.Tag & ": " & trkStandby.Value & " (" & m_vendortime & ")"
            Case 254
                lblStandbyValue.Text = lblStandbyValue.Tag & ": " & trkStandby.Value & " (" & m_reserved & ")"
            Case 255
                lblStandbyValue.Text = lblStandbyValue.Tag & ": " & trkStandby.Value & " (21'15"")"
        End Select
    End Sub

    Private Sub lnkSetStandby_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSetStandby.LinkClicked
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        lnkUndoStandby.Visible = True

        tlpStandbyWaitMessage.Visible = True
        lblStandbyWaitMessage.Refresh()
        picLoaderStandby.Refresh()

        dev.Standby = trkStandby.Value

        tlpStandbyWaitMessage.Visible = False
    End Sub

    Private Sub lnkUndoStandby_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUndoStandby.LinkClicked
        Dim dev As Device = devlist(cboDevices.SelectedIndex)
        trkStandby.Value = dev.Standby
        lnkUndoStandby.Visible = False
    End Sub
#End Region

#Region "Read/write options"
    Private Sub chkCache_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCache.CheckedChanged
        If Not isloading_performance Then
            Dim dev As Device = devlist(cboDevices.SelectedIndex)

            tlpWaitRWMessage.Visible = True
            lblWaitRWMessage.Refresh()
            picLoaderRW.Refresh()

            Select Case chkCache.Checked
                Case False
                    dev.Cache = Feature.Disable
                Case True
                    dev.Cache = Feature.Enable
            End Select

            tlpWaitRWMessage.Visible = False

            txtReport.Text = dev.Output
        End If
    End Sub

    Private Sub chkLookAhead_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLookAhead.CheckedChanged
        If Not isloading_performance Then
            Dim dev As Device = devlist(cboDevices.SelectedIndex)

            tlpWaitRWMessage.Visible = True
            lblWaitRWMessage.Refresh()
            picLoaderRW.Refresh()

            Select Case chkLookAhead.Checked
                Case False
                    dev.LookAhead = Feature.Disable
                Case True
                    dev.LookAhead = Feature.Enable
            End Select

            tlpWaitRWMessage.Visible = False

            txtReport.Text = dev.Output
        End If
    End Sub

    Private Sub chkCacheReorder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCacheReorder.CheckedChanged
        If Not isloading_performance Then
            Dim dev As Device = devlist(cboDevices.SelectedIndex)

            tlpWaitRWMessage.Visible = True
            lblWaitRWMessage.Refresh()
            picLoaderRW.Refresh()

            Select Case chkLookAhead.Checked
                Case False
                    dev.CacheReorder = Feature.Disable
                Case True
                    dev.CacheReorder = Feature.Enable
            End Select

            tlpWaitRWMessage.Visible = False

            txtReport.Text = dev.Output
        End If
    End Sub
#End Region

#Region "SMART attributes"

    Private Sub CatchAttributeInfo(ByVal itemname As String)
        Dim haveinfo As Boolean = False
        Dim family As String = devlist(cboDevices.SelectedIndex).Family

        'SSD devices
        If family.StartsWith("Crucial/Micron") Then
            For i As Short = 0 To m_MicronMeanings.Count - 1
                If m_MicronMeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_MicronMeanings(i).Name
                    lblMeaning.Text = m_MicronMeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        ElseIf family.StartsWith("SandForce") Then
            For i As Short = 0 To m_SandForceMeanings.Count - 1
                If m_SandForceMeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_SandForceMeanings(i).Name
                    lblMeaning.Text = m_SandForceMeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        ElseIf family.StartsWith("Indilinx") Then
            For i As Short = 0 To m_IndilinxMeanings.Count - 1
                If m_IndilinxMeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_IndilinxMeanings(i).Name
                    lblMeaning.Text = m_IndilinxMeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        ElseIf family.StartsWith("Intel") Or family.StartsWith("Kingston") Then 'some Intel SSDs are branded Kingston
            For i As Short = 0 To m_IntelMeanings.Count - 1
                If m_IntelMeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_IntelMeanings(i).Name
                    lblMeaning.Text = m_IntelMeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        ElseIf family.StartsWith("JMicron") Then
            For i As Short = 0 To m_JMicronMeanings.Count - 1
                If m_JMicronMeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_JMicronMeanings(i).Name
                    lblMeaning.Text = m_JMicronMeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        ElseIf family.StartsWith("Samsung based SSDs") Then
            For i As Short = 0 To m_SamsungMeanings.Count - 1
                If m_SamsungMeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_SamsungMeanings(i).Name
                    lblMeaning.Text = m_SamsungMeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        ElseIf family.StartsWith("SMART") Then
            For i As Short = 0 To m_SmartMeanings.Count - 1
                If m_SmartMeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_SmartMeanings(i).Name
                    lblMeaning.Text = m_SmartMeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        ElseIf family.StartsWith("SanDisk") Then
            For i As Short = 0 To m_SanDiskMeanings.Count - 1
                If m_SanDiskMeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_SanDiskMeanings(i).Name
                    lblMeaning.Text = m_SanDiskMeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        ElseIf family.StartsWith("Adtron") Then
            For i As Short = 0 To m_AdtronMeanings.Count - 1
                If m_AdtronMeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_AdtronMeanings(i).Name
                    lblMeaning.Text = m_AdtronMeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        Else 'HDD
            For i As Short = 0 To m_attributesmeanings.Count - 1
                If m_attributesmeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_attributesmeanings(i).Name
                    lblMeaning.Text = m_attributesmeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        End If

        If haveinfo = False Then
            For i As Short = 0 To m_attributesmeanings.Count - 1
                If m_attributesmeanings(i).SmartctlName = itemname Then
                    lblTitle.Text = m_attributesmeanings(i).Name
                    lblMeaning.Text = m_attributesmeanings(i).Description
                    haveinfo = True
                    Exit For
                End If
            Next
        End If
        If haveinfo = False Then
            lblTitle.Text = m_attributesmeanings(0).Name
            lblMeaning.Text = m_attributesmeanings(0).Description
        End If
    End Sub

    Private Sub SetFlagsAndGraph(ByVal f As AttributeFlags, ByVal current As Integer, worst As Integer, threshold As Integer)
        Dim sel_no As Color = Color.LightGray
        Dim sel_yes As Color = Color.Black

        If f.HasFlag(AttributeFlags.ErrorRate) Then lblErrRate.ForeColor = sel_yes Else lblErrRate.ForeColor = sel_no
        If f.HasFlag(AttributeFlags.EventCount) Then lblEvCount.ForeColor = sel_yes Else lblEvCount.ForeColor = sel_no
        If f.HasFlag(AttributeFlags.Performance) Then lblSpeed.ForeColor = sel_yes Else lblSpeed.ForeColor = sel_no
        If f.HasFlag(AttributeFlags.Prefailure) Then lblPrefailure.ForeColor = sel_yes Else lblSpeed.ForeColor = sel_no
        If f.HasFlag(AttributeFlags.SelfPreserving) Then lblSelfPres.ForeColor = sel_yes Else lblSelfPres.ForeColor = sel_no
        If f.HasFlag(AttributeFlags.UpdatedOnline) Then lblOnline.ForeColor = sel_yes Else lblOnline.ForeColor = sel_no

        fpbCurValue.Value = current
        fpbThreshold.Value = threshold
        fpbWorst.Value = worst

    End Sub

    Private Sub lvwSmart_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwSmart.Enter
        Dim itemname As String = ""
        Dim type As String = ""
        Dim update As String = ""
        Dim flags As AttributeFlags


        If lvwSmart.SelectedItems.Count > 0 Then
            With lvwSmart.SelectedItems(0)
                itemname = .SubItems(2).Text
                flags = .SubItems(0).Tag
            End With

            CatchAttributeInfo(itemname)
        End If
    End Sub

    Private Sub lvwSmart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSmart.SelectedIndexChanged
        Dim itemname As String = ""
        Dim type As String = ""
        Dim update As String = ""
        Dim flags As AttributeFlags
        Dim haveinfo As Boolean = False

        If lvwSmart.SelectedItems.Count > 0 Then
            With lvwSmart.SelectedItems(0)
                itemname = .SubItems(2).Text
                flags = .SubItems(0).Tag
                SetFlagsAndGraph(flags, Val(.SubItems(3).Text), Val(.SubItems(4).Text), Val(.SubItems(5).Text))
                CatchAttributeInfo(itemname)
            End With
        End If
    End Sub

#End Region

#Region "Smart error log"
    Private Sub Error_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optError1.CheckedChanged, optError2.CheckedChanged, _
        optError3.CheckedChanged, optError4.CheckedChanged, optError5.CheckedChanged

        Try
            Dim err As Short = Val(sender.Name.ToString.Substring(8, 1))
            DisplayAtaError(err)
        Catch ex As Exception
            PrintDebug("Error displaying ATA errors: " & ex.ToString, True)
        End Try
    End Sub
#End Region

#Region "Run test"
    Private Sub cboTest_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTest.SelectedIndexChanged
        lblTestInfo.Text = m_tests(cboTest.SelectedIndex).Info
        pnlProgress.Visible = False
        btnRun.Visible = True

        If cboDevices.Items.Count = 0 Then Exit Sub

        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        Select Case cboTest.SelectedIndex
            Case 0
                Dim t() As String = dev.TestsPollingTime.OfflineData.Split(" ")
                'test timing is always in seconds
                If IsNumeric(t(0)) Then
                    Dim polltime As Short = Val(t(0))
                    Dim h As Short = Val(t(0)) \ 3600
                    Dim m As Short = (Val(t(0)) - h * 3600) \ 60
                    Dim s As Short = Val(t(0)) - h * 3600 - m * 60
                    lblDuration.Text = lblDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":" & String.Format("{0:D2}", s)
                Else
                    lblDuration.Text = lblDuration.Tag & dev.TestsPollingTime.OfflineData
                End If
            Case 1
                Dim t() As String = dev.TestsPollingTime.ShortTest.Split(" ")
                'test timing are always in minutes
                If IsNumeric(t(0)) Then
                    Dim polltime As Short = Val(t(0))
                    Dim h As Short = Val(t(0)) \ 60
                    Dim m As Short = Val(t(0)) - h * 60
                    lblDuration.Text = lblDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":00"
                Else
                    lblDuration.Text = lblDuration.Tag & dev.TestsPollingTime.ShortTest
                End If
            Case 2
                Dim t() As String = dev.TestsPollingTime.ExtendedTest.Split(" ")
                'test timing are always in minutes
                If IsNumeric(t(0)) Then
                    Dim polltime As Short = Val(t(0))
                    Dim h As Short = Val(t(0)) \ 60
                    Dim m As Short = Val(t(0)) - h * 60
                    lblDuration.Text = lblDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":00"
                Else
                    lblDuration.Text = lblDuration.Tag & dev.TestsPollingTime.ExtendedTest
                End If
            Case 3
                Dim t() As String = dev.TestsPollingTime.ConveyanceTest.Split(" ")
                'test timing are always in minutes
                If IsNumeric(t(0)) Then
                    Dim polltime As Short = Val(t(0))
                    Dim h As Short = Val(t(0)) \ 60
                    Dim m As Short = Val(t(0)) - h * 60
                    lblDuration.Text = lblDuration.Tag & h & ":" & String.Format("{0:D2}", m) & ":00"
                Else
                    lblDuration.Text = lblDuration.Tag & dev.TestsPollingTime.ConveyanceTest
                End If
        End Select
        If lblDuration.Text.Contains("N/A") Or dev.Type = DeviceType.Virtual Then btnRun.Visible = False
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If dev.IsScsi Then
            dev.RunTest(TestType.ScsiLongTest)

            btnScsiRun.Enabled = False
            prbScsiTestProgress.Value = 0
            prbScsiTestProgress.Maximum = dev.TestTiming.Duration
            lblScsiProgress.Text = "0%"
            lblScsiExtimatedEnd.Text = lblScsiExtimatedEnd.Tag & dev.TestTiming.Conclusion
            btnScsiStop.Enabled = True
            btnScsiStop.Visible = True
            pnlScsiTestRun.Visible = True
            tmrTest.Start()
        Else

            Select Case cboTest.SelectedIndex
                Case 0 'offline data collection
                    dev.RunTest(TestType.Offline)
                Case 1 'short test
                    dev.RunTest(TestType.ShortTest)
                Case 2 'extended test
                    dev.RunTest(TestType.LongTest)
                Case 3 'conveyance test
                    dev.RunTest(TestType.Conveyance)
            End Select

            tlpTest.Enabled = False

            prbTestProgress.Value = 0
            prbTestProgress.Maximum = dev.TestTiming.Duration
            lblProgress.Text = "0%"
            lblExtimatedEnd.Text = lblExtimatedEnd.Tag & dev.TestTiming.Conclusion
            btnStop.Enabled = True
            tlpTestProgress.Visible = True
            tmrTest.Start()
        End If


    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Dim response As MsgBoxResult = MsgBox(m_abortmsg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, m_aborttitle)
        If response = MsgBoxResult.Yes Then
            Dim dev As Device = devlist(cboDevices.SelectedIndex)
            dev.RunTest(TestType.Abort)
        End If
    End Sub

    Private Sub tmrTest_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTest.Tick
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If dev.IsScsi Then
            If dev.TestIsRunnig Then
                Dim span As TimeSpan = Now - dev.TestTiming.Start
                If span.TotalSeconds <= dev.TestTiming.Duration Then
                    prbScsiTestProgress.Maximum = dev.TestTiming.Duration
                    prbScsiTestProgress.Value = span.TotalSeconds
                    lblScsiProgress.Text = span.TotalSeconds * 100 \ dev.TestTiming.Duration & "%"
                Else
                    UpdateAll(DeviceType.SCSI)
                    pnlScsiTestRun.Visible = False
                    btnScsiStop.Visible = False

                    prbScsiTestProgress.Value = 0
                    btnScsiRun.Enabled = True
                    dev.TestIsRunnig = False
                    tmrTest.Stop()
                End If
            End If
        Else
            If dev.TestIsRunnig Then
                Dim span As TimeSpan = Now - dev.TestTiming.Start
                If span.TotalSeconds <= dev.TestTiming.Duration Then
                    prbTestProgress.Maximum = dev.TestTiming.Duration
                    prbTestProgress.Value = span.TotalSeconds
                    lblProgress.Text = span.TotalSeconds * 100 \ dev.TestTiming.Duration & "%"
                Else
                    UpdateAll(DeviceType.ATA)
                    UpdateAll(DeviceType.USB)
                    tlpTestProgress.Visible = False
                    prbTestProgress.Value = 0

                    tlpTest.Enabled = True
                    btnRun.Enabled = True
                    dev.TestIsRunnig = False
                    tmrTest.Stop()
                End If
            End If
        End If
    End Sub
#End Region

#Region "Attributes remap"
    Private Sub chkAttributes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAttributes.CheckedChanged
        pnlAttributes.Visible = chkAttributes.Checked
        btnRemove.Enabled = False
        If Not pnlAttributes.Enabled Then
            lvwAttrFormat.Items.Clear()
        End If
        If chkAttributes.Checked = False Then
            SaveDeviceSettings()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AddCustomAttribute.ShowDialog(Me)
    End Sub

    Private Sub lvwAttrFormat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwAttrFormat.SelectedIndexChanged
        If lvwAttrFormat.SelectedItems.Count > 0 Then btnRemove.Enabled = True
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        lvwAttrFormat.SelectedItems(0).Remove()
        btnRemove.Enabled = False
        SaveDeviceSettings()
    End Sub
#End Region

#Region "Firmware debug"
    Private Sub chkFirmware_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFirmware.CheckedChanged
        flwFirmware.Visible = chkFirmware.Checked
        If Not flwFirmware.Enabled Then
            cboFirmware.SelectedIndex = 0
            chkFixSwap.Checked = False
        End If
        If Not isloading_devsettings Then SaveDeviceSettings()
    End Sub

    Private Sub cboFirmware_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirmware.SelectedIndexChanged
        lblFirmwareDebug.Text = m_firmware(cboFirmware.SelectedIndex + 1)
        If Not isloading_devsettings Then SaveDeviceSettings()
    End Sub

    Private Sub chkNoLogDir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoLogDir.CheckedChanged
        If Not isloading_devsettings Then SaveDeviceSettings()
    End Sub

    Private Sub chkXErrorLba_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not isloading_devsettings Then SaveDeviceSettings()
    End Sub

    Private Sub chkFixSwap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFixSwap.CheckedChanged
        If Not isloading_devsettings Then SaveDeviceSettings()
    End Sub
#End Region

#End Region

#Region "SCSI"

#Region "Info"
    Private Sub lnkVendor_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkVendor.LinkClicked
        Try
            System.Diagnostics.Process.Start(sender.Tag)
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub
#End Region

#Region "SMART setup"

    Private Sub chkScsiSmart_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkScsiSmart.MouseDown
        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)

        If dev.Type = DeviceType.Virtual Or isloading_features Then Exit Sub

        Select Case dev.SmartEnabled
            Case Support.Disabled
                dev.SetSmartStatus(SmartFeature.Enable)
                dev.Update()
                Select Case dev.SmartEnabled
                    Case Support.Enabled
                        MsgBox(m_smartenabled.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                        chkScsiSmart.Checked = True
                        chkScsiSmart.Enabled = True
                    Case Support.Ambiguous
                        MsgBox(m_smartambiguous.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, m_message)
                        chkScsiSmart.Checked = False
                    Case Support.Disabled
                        MsgBox(m_smartnotsupported.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, m_message)
                        chkScsiSmart.Checked = False
                End Select
            Case Support.Enabled
                Dim qst As MsgBoxResult = MsgBox(m_qdisablesmart.Replace("%", dev.Model), MsgBoxStyle.YesNo + MsgBoxStyle.Question, m_question)
                If qst = MsgBoxResult.Yes Then
                    dev.SetSmartStatus(SmartFeature.Disable)
                    dev.Update()
                    MsgBox(m_smartdisabled.Replace("%", dev.Model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                    chkScsiSmart.Checked = False
                    chkScsiGltsd.Checked = False
                    chkScsiGltsd.Enabled = False
                    chkScsiWCache.Checked = False
                    chkScsiWCache.Enabled = False
                    chkScsiRCache.Checked = False
                    chkScsiRCache.Enabled = False
                End If
        End Select

        PopulateScsiPanels()
    End Sub


    Private Sub chkScsiGltsd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScsiGltsd.CheckedChanged
        If Not isloading_performance Then
            Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)

            'pnlApply.Parent = tpScsiFeatures
            'pnlApply.Visible = True
            'picApply.Refresh()
            'lblApply.Refresh()

            Select Case chkScsiGltsd.Checked
                Case False
                    dev.ScsiGltsd = Feature.Disable
                Case True
                    dev.ScsiGltsd = Feature.Enable
            End Select

            'pnlApply.Visible = False

            PopulateScsiPanels()
        End If
    End Sub

    Private Sub chkScsiWCache_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScsiWCache.CheckedChanged
        If Not isloading_performance Then
            Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)

            'pnlApply.Parent = tpScsiFeatures
            'pnlApply.Visible = True
            'picApply.Refresh()
            'lblApply.Refresh()

            Select Case chkScsiWCache.Checked
                Case False
                    dev.ScsiWriteCache = Feature.Disable
                Case True
                    dev.ScsiWriteCache = Feature.Enable
            End Select

            'pnlApply.Visible = False

            PopulateScsiPanels()
        End If
    End Sub

    Private Sub chkScsiRCache_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScsiRCache.CheckedChanged
        If Not isloading_performance Then
            Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)

            'pnlApply.Parent = tpScsiFeatures
            'pnlApply.Visible = True
            'picApply.Refresh()
            'lblApply.Refresh()

            Select Case chkScsiRCache.Checked
                Case False
                    dev.ScsiReadCache = Feature.Disable
                Case True
                    dev.ScsiReadCache = Feature.Enable
            End Select

            'pnlApply.Visible = False

            PopulateScsiPanels()
        End If
    End Sub
#End Region

#End Region

#Region "Commons"

#Region "Log viewer"

    Public Sub DisplayLogEvents()
        lvwLog.Items.Clear()

        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If Not IsNothing(dev.Log) Then
            If dev.Log.Count > 0 Then

                Dim y As String = dteLog.Value.Year
                Dim m As String = dteLog.Value.Month
                Dim d As String = dteLog.Value.Day

                With dev
                    For i As Integer = 0 To .Log.Count - 1
                        If .Log(i).Year = y And .Log(i).Month = m And .Log(i).Day = d Then
                            Dim celsius As String = ""
                            Dim ev As String = .Log(i).EventName
                            If ev = "Temperature" Then celsius = "°C"
                            Dim t() As String = .Log(i).Hour.ToString.Split(":")
                            Dim h As String = String.Format("{0:D2}", Convert.ToInt16(t(0)))
                            Dim min As String = String.Format("{0:D2}", Convert.ToInt16(t(1)))
                            Dim sec As String = String.Format("{0:D2}", Convert.ToInt16(t(2)))
                            Dim old As String = .Log(i).OldValue
                            Dim last As String = .Log(i).NewValue
                            Dim var As String = .Log(i).Variation

                            With lvwLog
                                .SmallImageList = imlLog
                                .Items.Add(ev)
                                .Items(.Items.Count - 1).SubItems.Add(h & ":" & min & ":" & sec)
                                .Items(.Items.Count - 1).SubItems.Add(old & celsius)
                                .Items(.Items.Count - 1).SubItems.Add(last & celsius)
                                .Items(.Items.Count - 1).SubItems.Add(var & celsius)

                                If ev.ToLower = "remaining life (%)" _
                                    Or ev.ToLower = "remaining life percentage" _
                                    Or ev.ToLower = "media wearout indicator" _
                                    Or ev.ToLower = "wear leveling count" _
                                    Or ev.ToLower = "ssd life left" Then
                                    If Convert.ToDouble(Val(var)) < 0 Then
                                        .Items(.Items.Count - 1).ForeColor = Color.Red
                                        .Items(.Items.Count - 1).ImageKey = "warning"
                                    Else
                                        .Items(.Items.Count - 1).ForeColor = Color.Blue
                                        .Items(.Items.Count - 1).ImageKey = "ok"
                                    End If
                                Else
                                    If Convert.ToDouble(Val(var)) > 0 Then
                                        .Items(.Items.Count - 1).ForeColor = Color.Red
                                        .Items(.Items.Count - 1).ImageKey = "warning"
                                    Else
                                        .Items(.Items.Count - 1).ForeColor = Color.Blue
                                        .Items(.Items.Count - 1).ImageKey = "ok"
                                    End If
                                End If
                            End With
                        End If
                    Next
                End With

                With lvwLog
                    .Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                    .Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)

                    .HeaderStyle = ColumnHeaderStyle.Nonclickable
                    .Enabled = True
                    .Visible = True
                    btnSaveLog.Visible = True
                    Main.SetWindowTheme(.Handle, "explorer", Nothing)
                    lblLogItems.Visible = False
                End With

                If lvwLog.Items.Count = 0 Then
                    lvwLog.Visible = False
                    lblLogItems.Text = m_nologforthisday
                    lblLogItems.Top = 32
                    lblLogItems.Visible = True
                Else
                    lblLogItems.Visible = False
                    lvwLog.Top = 32
                    lvwLog.Height = 256
                    lvwLog.Visible = True
                End If

                tlpLogViewer.Visible = True
                btnCopy.Enabled = False
            Else
                tlpLogViewer.Visible = False
                lvwLog.Visible = False
                lblLogItems.Text = m_nologfordevice
                lblLogItems.Top = 0
                lblLogItems.Visible = True
            End If
        End If

    End Sub

    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReload.Click
        DisplayLogEvents()
    End Sub

    Private Sub btnToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToday.Click
        dteLog.Value = Today
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        dteLog.Value = dteLog.Value.AddDays(-1)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        dteLog.Value = dteLog.Value.AddDays(1)
    End Sub

    Private Sub dteLog_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dteLog.ValueChanged
        DisplayLogEvents()
    End Sub

    Private Sub lvwLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwLog.SelectedIndexChanged
        If lvwLog.SelectedItems.Count > 0 Then
            btnCopy.Enabled = True
        Else
            btnCopy.Enabled = False
        End If
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        If lvwLog.SelectedItems.Count > 0 Then
            With lvwLog.Items(lvwLog.SelectedItems(0).Index)
                Dim y As String = dteLog.Value.Year
                Dim m As String = dteLog.Value.Month
                Dim d As String = dteLog.Value.Day
                Dim newdate As String = String.Format("{0:D4}", Convert.ToInt16(y)) & " " & String.Format("{0:D2}", Convert.ToInt16(m)) & " " & String.Format("{0:D2}", Convert.ToInt16((d)))
                Dim datetocopy As String = ""

                Dim dt As DateTime
                If DateTime.TryParseExact(newdate, "yyyy MM dd", Nothing, Nothing, dt) Then
                    datetocopy = FormatDateTime(dt, DateFormat.ShortDate)
                End If

                Dim i As Short = lvwDevices.SelectedItems(0).Index

                Clipboard.SetText(devlist(i).Model & "," & devlist(i).SerialNumber & "," & datetocopy & "," & .Text & "," & .SubItems(1).Text & _
                                  "," & .SubItems(2).Text & "," & .SubItems(3).Text & "," & .SubItems(4).Text)
            End With
        End If
    End Sub

    Private Sub btnSaveLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLog.Click
        Dim txtlog As String
        Dim d As Short = cboDevices.SelectedIndex  ' lvwDevices.SelectedItems(0).Index

        txtlog = "*** DEVICE INFORMATIONS ***" & vbCrLf
        txtlog += "Model family    : " & devlist(d).Family & vbCrLf
        txtlog += "Device model    : " & devlist(d).Model & vbCrLf
        txtlog += "Serial number   : " & devlist(d).SerialNumber & vbCrLf
        txtlog += "Firmware version: " & devlist(d).FirmwareVersion & vbCrLf
        txtlog += vbCrLf
        txtlog += "*** DEVICE HEALTH ***" & vbCrLf
        txtlog += "Overall health  : " & devlist(d).Health.ToString & vbCrLf
        txtlog += "Bad sectors     : " & devlist(d).BadSectorsCount & vbCrLf
        txtlog += "ATA errors      : " & devlist(d).TotalErrors & vbCrLf
        txtlog += "Reliability     : " & New String("*"c, devlist(d).ReliabilityRating.Overall) & vbCrLf
        txtlog += vbCrLf
        txtlog += "*** DEVICE EVENTS LOG ***" & vbCrLf
        txtlog += String.Format("{0,-13}{1,-11}{2,-25}{3,11}{4,11}{5,11}", "Date", "Time", "Event", "Old Value", "New Value", "Variation") & vbCrLf
        txtlog += New String("-"c, 82) & vbCrLf
        For i As Short = 0 To devlist(d).Log.Count - 1
            With devlist(d).Log(i)
                Dim newdate As String = String.Format("{0:D4}", Convert.ToInt16(.Year)) & " " & String.Format("{0:D2}", Convert.ToInt16(.Month)) & " " & String.Format("{0:D2}", Convert.ToInt16(.Day))
                Dim datetocopy As String = ""

                Dim dt As DateTime
                If DateTime.TryParseExact(newdate, "yyyy MM dd", Nothing, Nothing, dt) Then
                    datetocopy = FormatDateTime(dt, DateFormat.ShortDate)
                End If

                Dim t() As String = .Hour.Split(":")
                Dim tc As String = String.Format("{0:D2}", Convert.ToInt16(t(0))) & ":" & String.Format("{0:D2}", Convert.ToInt16(t(1))) & ":" & String.Format("{0:D2}", Convert.ToInt16(t(2)))

                txtlog += String.Format("{0,-13}{1,-11}{2,-25}{3,11}{4,11}{5,11}", datetocopy, tc, .EventName, .OldValue, .NewValue, .Variation) & vbCrLf
            End With
        Next

        Dim sf As New SaveFileDialog
        Dim res As DialogResult
        sf.AddExtension = True
        sf.DefaultExt = "txt"
        sf.Filter = "*.txt|*.txt"
        sf.FileName = devlist(d).DeviceFileName
        res = sf.ShowDialog(Me)
        If res = DialogResult.OK Then
            IO.File.WriteAllText(sf.FileName, txtlog)
        End If

    End Sub

#End Region

#Region "Log chart"
    Private Sub cboChartEvents_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboChartEvents.SelectedIndexChanged
        FillList()
        SetGraph()
    End Sub

    Private Sub rbList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With lvwChart
            .Visible = True
            '.Top = 32
            '.Height = 256
        End With
        With chrChart
            .Visible = False
        End With
    End Sub

    Private Sub rbChart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With lvwChart
            .Visible = False
        End With
        With chrChart
            .Visible = True
            '.Top = 32
            '.Height = 256
        End With
    End Sub

    Private Sub rbSplit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With lvwChart
            .Visible = True
            .Top = 32
            .Height = 128
        End With
        With chrChart
            .Visible = True
            .Top = 168
            .Height = 128
        End With
    End Sub

    Private Sub lvwChart_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwChart.ItemSelectionChanged
        If lvwChart.SelectedItems.Count > 1 Then
            With chrChart
                .Series(0).Points.Clear()
                .Series(0).MarkerSize = 0

                Dim p As New DataVisualization.Charting.DataPoint
                p.YValues(0) = Convert.ToDouble(lvwChart.SelectedItems(0).SubItems(1).Text.Replace("°C", ""))

                .Series(0).Points.Add(p)

                For i As Short = 0 To lvwChart.SelectedItems.Count - 1
                    Dim pt As New DataVisualization.Charting.DataPoint
                    pt.YValues(0) = Convert.ToDouble(lvwChart.SelectedItems(i).SubItems(2).Text.Replace("°C", ""))

                    .Series(0).Points.Add(pt)
                Next
            End With
        Else
            SetGraph()
        End If
    End Sub

#End Region

#Region "Smartctl output"

    Public Sub FillSmartctlPanels()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)
        'put complete output into the Smartctl->Output section
        txtReport.Text = dev.Output
        'populate (if necessary) the section under Smartctl->Tolerance, Smartctl->Attributes remap,
        'Smartctl->Firmware debug and Smartctl->Power mode
        ParseOptions(dev.Options)
    End Sub

    Private Sub btnSaveOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveOutput.Click
        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)
        Dim savedialog As New SaveFileDialog
        Dim res As DialogResult

        savedialog.DefaultExt = "txt"
        savedialog.AddExtension = True
        savedialog.Filter = "*.txt|*.txt"
        savedialog.FileName = dev.Model & "_" & dev.SerialNumber
        res = savedialog.ShowDialog(Me)
        If res = DialogResult.OK Then
            File.WriteAllText(savedialog.FileName, txtReport.Text)
        End If
    End Sub

#End Region

#End Region

#End Region

#Region "System"
    Private Sub rbtRefresh_Click(sender As Object, e As EventArgs) Handles rbtRefresh.Click
        UpdateHardware()
    End Sub

    Private Sub tvwComputer_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwComputer.AfterSelect
        ShowDetails()
    End Sub

    Private Sub picWmiDevicesHelp_Click(sender As Object, e As EventArgs) Handles picWmiDevicesHelp.Click
        Try
            System.Diagnostics.Process.Start("http://code.google.com/p/hddguardian/wiki/system")
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub

    Private Sub picWmi_MouseUp(sender As Object, e As MouseEventArgs) Handles picWmi.MouseUp
        Dim path() As String = tvwComputer.SelectedNode.FullPath.Split("\")
        If path.Length = 1 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then cmDeviceImage.Show(sender, e.Location)
        End If
    End Sub

    Private Sub mnuProfessional_Click(sender As Object, e As EventArgs) Handles mnuProfessional.Click
        picWmi.Image = My.Resources.pc_office
        My.Settings.ComputerType = "0"
        My.Settings.Save()
    End Sub

    Private Sub mnuGamer_Click(sender As Object, e As EventArgs) Handles mnuGamer.Click
        picWmi.Image = My.Resources.pc_game
        My.Settings.ComputerType = "1"
        My.Settings.Save()
    End Sub

    Private Sub mnuLaptop_Click(sender As Object, e As EventArgs) Handles mnuLaptop.Click
        picWmi.Image = My.Resources.pc_laptop
        My.Settings.ComputerType = "2"
        My.Settings.Save()
    End Sub
#End Region

#Region "Debug"
    Private Sub rbtSaveDebug_Click(sender As Object, e As EventArgs) Handles rbtSaveDebug.Click
        Dim debuglog As String = ""

        With lvwProgLog
            For i As Short = 0 To .Items.Count - 1
                debuglog += .Items(i).Text & vbTab & .Items(i).SubItems(1).Text & vbCrLf
            Next
        End With

        Dim sf As New SaveFileDialog
        Dim res As DialogResult
        sf.AddExtension = True
        sf.DefaultExt = "txt"
        sf.Filter = "*.txt|*.txt"
        sf.FileName = "hddguardian_debug"
        res = sf.ShowDialog(Me)
        If res = DialogResult.OK Then
            IO.File.WriteAllText(sf.FileName, debuglog)
        End If
    End Sub
#End Region

#Region "Missing admin rights icon"
    Private Sub picAdmin_MouseEnter(sender As Object, e As EventArgs) Handles picAdmin.MouseEnter
        ttMain.ToolTipTitle = GetString(4506)
        ttMain.ToolTipIcon = ToolTipIcon.Warning
    End Sub

    Private Sub picAdmin_MouseLeave(sender As Object, e As EventArgs) Handles picAdmin.MouseLeave
        ttMain.Hide(picAdmin)
        ttMain.ToolTipTitle = ""
        ttMain.ToolTipIcon = ToolTipIcon.None
    End Sub
#End Region

#Region "Private settings"
    'Here are loaded settings from a file that are not published for reasons
    'of security and privacy.

    Public defaultmail, password, aes_key, aes_iv As String

    Private Sub LoadPrivate()
        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmldoc.LoadXml(My.Resources.privatedata)

        m_nodelist = m_xmldoc.SelectNodes("/private")

        For Each m_node In m_nodelist
            defaultmail = m_node.ChildNodes.Item(0).InnerText
            password = m_node.ChildNodes.Item(1).InnerText
            aes_key = m_node.ChildNodes.Item(2).InnerText
            aes_iv = m_node.ChildNodes.Item(3).InnerText
        Next
    End Sub

#End Region

End Class
