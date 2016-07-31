'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2016 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Xml

Public Class Main

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
        Try
            ' Chiamata richiesta dalla finestra di progettazione.
            InitializeComponent()

            ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

            SetWindowTheme(tvwComputer.Handle, "explorer", Nothing)
            SetWindowTheme(lvwAttrFormat.Handle, "explorer", Nothing)
            SetWindowTheme(lvwDevices.Handle, "explorer", Nothing)
            SetWindowTheme(lvwEvents.Handle, "explorer", Nothing)
            SetWindowTheme(lvwSelfTest.Handle, "explorer", Nothing)
            SetWindowTheme(lvwSmart.Handle, "explorer", Nothing)
            SetWindowTheme(lvwLog.Handle, "explorer", Nothing)
            SetWindowTheme(lvwScsiTests.Handle, "explorer", Nothing)
            SetWindowTheme(tvwScsiErrors.Handle, "explorer", Nothing)
            SetWindowTheme(lvwProgLog.Handle, "explorer", Nothing)
            SetWindowTheme(lvwTasks.Handle, "explorer", Nothing)

            If AppSettings.General.RememberWindowSize Then
                If AppSettings.General.IsMaximized Then
                    Me.WindowState = FormWindowState.Maximized
                Else
                    Me.Size = New Size(AppSettings.General.WindowSize)
                End If
            End If
        Catch ex As Exception
            Debug.Print(ex.StackTrace)
        End Try

    End Sub
#End Region

#Region "Help links"
    Private Sub HelpLinks()
        picOverviewHelp.Tag = My.Resources.help_overview
        picWmiDevicesHelp.Tag = My.Resources.help_system
        picPlannerHelp.Tag = My.Resources.help_planner
        With SettingsForm
            .picHelpSetupGeneral.Tag = My.Resources.help_general_settings
            .picHelpSetupTranslation.Tag = My.Resources.help_languages
            .picHelpSetupDetection.Tag = My.Resources.help_device_detection
            .picHelpSetupUpdate.Tag = My.Resources.help_devices_update
            .picHelpSetupMonitoring.Tag = My.Resources.help_monitoring
            .picHelpSetupWarnings.Tag = My.Resources.help_warnings
            .picHelpSetupMailAlerts.Tag = My.Resources.help_mail_alerts
            .picHelpSetupRating.Tag = My.Resources.help_device_rating
            .picHelpSetupShare.Tag = My.Resources.help_output_sharing
            .picHelpSetupTolerance.Tag = My.Resources.help_tolerance
            .picHelpSetupControllers.Tag = My.Resources.help_raidcontrollers
            .picHelpSetupSmartctl.Tag = My.Resources.help_smartctl
        End With
        About.lnkHddGuardian.Tag = My.Resources.project_site
    End Sub
#End Region

#Region "Main form"

    Private Sub Main_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If tvwComputer.Nodes.Count > 0 Then tvwComputer.Nodes(0).Expand()
        SetWindowTheme(lvwDevices.Handle, "explorer", Nothing)
    End Sub

    Private Sub frmMain_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        On Error Resume Next

        If AppSettings.General.HideToTray Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.ShowInTaskbar = False
                Me.Visible = False
                niTrayIcon.Visible = True
            Else
                Me.ShowInTaskbar = True
                Me.Visible = True
                If Not IsNothing(niTrayIcon) And Not Me.Disposing Then niTrayIcon.Visible = AppSettings.General.AlwaysDisplayTrayIcon
            End If
        End If

        Memory.FlushMemory()
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        For Each d In devlist
            d.Tray.Dispose()
        Next
        niTrayIcon.Visible = False
        Me.Dispose()
        End
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim confirm As MsgBoxResult

        If AppSettings.General.CloseToTray Then
            If Me.WindowState = FormWindowState.Normal Or Me.WindowState = FormWindowState.Maximized Then
                e.Cancel = True
                Me.WindowState = FormWindowState.Minimized
                Me.ShowInTaskbar = False
                Me.Visible = False
                niTrayIcon.Visible = True
            End If
        Else
            If AppSettings.General.ConfirmOnExit And e.CloseReason = CloseReason.UserClosing Then
                confirm = MsgBox(m_exitmsg, MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, m_exit)
                If confirm = MsgBoxResult.Cancel Then e.Cancel = True
            End If
        End If

    End Sub

    Dim on_debug As Boolean = False
    Dim savedebug As Boolean = False

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppSettings.Load()
        ApplyColorScheme()
        LoadPrivate()
        LoadIcons()

        isloading_settings = True
        'translate interface
        InterfaceTranslation()

        SettingsForm.LoadSettings()
        mrcSidePanel.Checked = AppSettings.General.DisplaySidePanel

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
        TaskList()

        'set main window title
        With My.Application.Info
            Me.Text = .Title.ToString & " " & .Version.Major.ToString & "." & .Version.Minor.ToString & "." & .Version.Build.ToString
            If My.Resources.prerelease <> "" Then
                If My.Resources.prerelease > 0 Then
                    Me.Text += " | beta " & My.Resources.prerelease
                End If
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
        'load license, change log, credits
        About.lblLicense.Text = My.Resources.License
        About.lblChangeLog.Text = My.Resources.Changelog
        About.lblTranslators.Text = My.Resources.translators
        About.lblTesters.Text = My.Resources.testers
        'set version and copyright
        With My.Application.Info
            About.lblVersion.Text = .Version.Major.ToString & "." & .Version.Minor.ToString & "." & .Version.Build.ToString
            If My.Resources.prerelease <> "" Then
                If My.Resources.prerelease > 0 Then
                    About.lblVersion.Text += " | beta " & My.Resources.prerelease
                End If
            End If
            About.lblCopyright.Text = .Copyright
        End With

        'uncheck and disable smartctl options
        chkAttributes.Checked = False
        pnlAttributes.Enabled = False
        chkFirmware.Checked = False
        flwFirmware.Enabled = False
        chkPowerMode.Checked = False
        flwPowerMode.Enabled = False

        LoadAttribInfos()
        LoadManufacturers()

        Search()
        CollectDevices()
        tslSmartctl.Text = devlist(0).SmartctlVersion
        FillDevicesList()
        FillSidePanel()
        FillManageDeviceList()
        optEntire.Checked = True
        VitalsCheck()
        OverallHealthCheck()

        'disable from devices overview and context menu the function to scan for external
        'devices if user are not an administrator
        mnuSearchUsb.Enabled = isadmin
        mrbRescanUsb.Enabled = isadmin

        If AppSettings.General.RunMinimized Then
            Me.WindowState = FormWindowState.Minimized
            If AppSettings.General.HideToTray Then
                Me.ShowInTaskbar = False
                Me.Visible = False
                niTrayIcon.Visible = True
            End If
        End If

        'select overview page
        extOverview.Checked = True

        'populate all panels for the first device in list
        If devlist(0).Type <> DeviceType.SCSI Then
            PopulateAtaPanels()
        Else
            PopulateScsiPanels()
        End If

        Memory.FlushMemory()
        isloading = False
        SetWindowTheme(lvwDevices.Handle, "explorer", Nothing)

        HelpLinks()
    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'display a warning when administration rights are missed
        If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            If AppSettings.General.RunMinimized Then
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

    Private Sub Main_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        If AppSettings.General.RememberWindowSize Then
            If Me.WindowState <> FormWindowState.Minimized Then AppSettings.General.WindowSize = Me.Size
            If Me.WindowState = FormWindowState.Maximized Then AppSettings.General.IsMaximized = True Else AppSettings.General.IsMaximized = False
            If Not isloading_settings Then SettingsForm.SaveSettings("main resize")
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
                niTrayIcon.Visible = AppSettings.General.AlwaysDisplayTrayIcon
            Case Windows.Forms.MouseButtons.Middle
                'if is pressed the middle button refresh all devices
                UpdateAll(DeviceType.ATA)
                UpdateAll(DeviceType.USB)
                UpdateAll(DeviceType.SCSI)
                UpdateAll(DeviceType.ThreeWare)
            Case Windows.Forms.MouseButtons.Right
                'none. Automatically display trayicon context menu
        End Select
    End Sub
#End Region

#Region "Timers"

    Private Async Sub RefreshNonRemovable(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefresh.Tick

        'PrintDebug("Checking for updated devices values")

        CheckForUpdates()
        LanguagesUpdate()
        RegularReport()

        Await Task.Run(Sub()
                           UpdateAll(DeviceType.ATA)
                           UpdateAll(DeviceType.SCSI)

                           'export a Xml report
                           If AppSettings.Sharing.XmlReport And IO.Directory.Exists(AppSettings.Sharing.XmlFolder) Then
                               ExportToXml()
                           End If
                       End Sub)

        If devlist(cboDevices.SelectedIndex).Type = DeviceType.SCSI Then
            PopulateScsiPanels()
        Else
            PopulateAtaPanels()
        End If

        For i As Short = 0 To lvwDevices.Items.Count - 1
            If devlist(i).Type = DeviceType.ATA Or DeviceType.SCSI Then
                OverviewUpdate(i)
            End If
        Next

        If devlist(lvwDevices.SelectedItems(0).Index).Type = DeviceType.ATA Or DeviceType.SCSI Then
            DisplayWarnings()
            SendNotificationMail()
            SoundNotification()
            PowerOff()
            ShareOutput()
        End If

        tslSmartctl.Text = devlist(0).SmartctlVersion

    End Sub

    Private Async Sub RefreshRemovable(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefreshExt.Tick
        Await Task.Run(Sub()
                           UpdateAll(DeviceType.USB)

                           'and now, from 0.4.0.0, export a Xml report!
                           If AppSettings.Sharing.XmlReport And IO.Directory.Exists(AppSettings.Sharing.XmlFolder) Then
                               ExportToXml()
                           End If
                       End Sub)

        If devlist(lvwDevices.SelectedItems(0).Index).Type = DeviceType.USB Then
            DisplayWarnings()
            SendNotificationMail()
            SoundNotification()
            PowerOff()
            ShareOutput()
        End If

    End Sub

#End Region

#Region "Tray icon context menu"
    Private Sub mnuRestore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuRestoreTray.Click
        If Me.WindowState = FormWindowState.Minimized Then
            If AppSettings.General.RememberWindowSize Then
                If AppSettings.General.IsMaximized Then
                    Me.WindowState = FormWindowState.Maximized
                Else
                    Me.Size = AppSettings.General.WindowSize
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
            niTrayIcon.Visible = AppSettings.General.AlwaysDisplayTrayIcon
        End If
    End Sub

    Private Sub ExitProgram(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExitTray.Click
        Dim confirm As MsgBoxResult
        If AppSettings.General.ConfirmOnExit Then
            confirm = MsgBox(m_exitmsg, MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, m_exit)
            If confirm = MsgBoxResult.Cancel Then Exit Sub
        End If

        For Each d In devlist
            d.Tray.Dispose()
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
                'If Not d.type=devicetype.scsi Then mnuPerformance.PerformClick()
            Case Keys.F7
                'mnuMonitoring.PerformClick()
            Case Keys.F8
                'If Not d.type=devicetype.scsi Then mnuAdvanced.PerformClick()
            Case Keys.F9
                'mnuSmartctl.PerformClick()
            Case Keys.F1
                'mnuHelp.PerformClick()
        End Select

        'If e.Alt And e.KeyValue = Keys.F4 Then mnuExit.PerformClick()
    End Sub
#End Region

#Region "Main menu"
    Private Sub rmFile_Click(sender As Object, e As EventArgs) Handles rmFile.Click
        cmFile.Show(rmFile, New Point(rmFile.Location.X - 2, rmFile.Location.Y + rmFile.Height - 2))
    End Sub

    Private Sub extOverview_CheckedChanged(sender As Object, e As EventArgs) Handles extOverview.CheckedChanged
        If extOverview.Checked Then htcMain.SelectPage(tpOverview)
    End Sub

    Private Sub extManage_CheckedChanged(sender As Object, e As EventArgs) Handles extManage.CheckedChanged
        If extManage.Checked Then htcMain.SelectPage(tpManage)
    End Sub

    Private Sub extSystem_CheckedChanged(sender As Object, e As EventArgs) Handles extSystem.CheckedChanged
        If extSystem.Checked Then htcMain.SelectPage(tpWmiDevices)
    End Sub

    Private Sub extDebug_CheckedChanged(sender As Object, e As EventArgs) Handles extDebug.CheckedChanged
        If extDebug.Checked Then htcMain.SelectPage(tpDebug)
    End Sub

    Private Sub extPlanner_CheckedChanged(sender As Object, e As EventArgs) Handles extPlanner.CheckedChanged
        If extPlanner.Checked Then htcMain.SelectPage(tpPlanner)
    End Sub

#End Region

#Region "File menu items"
    Private Sub mnuReloadDevices_Click(sender As Object, e As EventArgs) Handles mnuReloadDevices.Click
        FillDevicesList()
        FillManageDeviceList()
    End Sub

    Private Sub mnuUpdateDatabase_Click(sender As Object, e As EventArgs) Handles mnuUpdateDatabase.Click
        If AppSettings.Smartctl.AlternativeVersion Then
            If System.IO.File.Exists(AppSettings.Smartctl.ExecutableFolder & "\smartctl\update-smart-drivedb.exe") Then
                Shell(AppSettings.Smartctl.ExecutableFolder & "\smartctl\update-smart-drivedb.exe", AppWinStyle.NormalFocus, False)
            End If
        Else
            If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\smartctl\update-smart-drivedb.exe") Then
                Shell(My.Application.Info.DirectoryPath & "\smartctl\update-smart-drivedb.exe", AppWinStyle.NormalFocus, False)
            End If
        End If
    End Sub

    Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click
        SettingsForm.ShowDialog(Me)
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        About.ShowDialog(Me)
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Dim confirm As MsgBoxResult
        If AppSettings.General.ConfirmOnExit Then
            confirm = MsgBox(m_exitmsg, MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, m_exit)
            If confirm = MsgBoxResult.Cancel Then Exit Sub
        End If

        For Each d In devlist
            d.Tray.Dispose()
        Next

        If AppSettings.General.RememberWindowSize Then
            AppSettings.General.WindowSize = Me.Size
            If Me.WindowState = FormWindowState.Maximized Then AppSettings.General.IsMaximized = True Else AppSettings.General.IsMaximized = False
            SettingsForm.SaveSettings("exit")
        End If

        niTrayIcon.Visible = False
        Me.Dispose()
        End
    End Sub
#End Region

#Region "Devices Overview"

#Region "Ribbon buttons"
    Private Async Sub mrbUpdateAll_Click(sender As Object, e As EventArgs) Handles mrbUpdateAll.Click
        Await Task.Run(Sub()
                           UpdateAll(DeviceType.ATA)
                           UpdateAll(DeviceType.SCSI)
                           UpdateAll(DeviceType.USB)
                           UpdateAll(DeviceType.ThreeWare)
                       End Sub)
        Memory.FlushMemory()
    End Sub

    Private Sub mrbRescanUsb_Click(sender As Object, e As EventArgs) Handles mrbRescanUsb.Click
        'UsbDevicesComparison()
        'eSataDevicesComparison()
        RemoveUsbDevices()
        AddUsbDevices()

        Memory.FlushMemory()
    End Sub

    Private Sub mrbAddVirtual_Click(sender As Object, e As EventArgs) Handles mrbAddVirtual.Click
        Dim after As Short

        after = lvwDevices.Items.Count

        AddVirtualDevice.ShowDialog(Me)

        If lvwDevices.Items.Count > after Then UpdateCurrent()

        Memory.FlushMemory()
    End Sub

    Private Sub picOverviewHelp_Click(sender As Object, e As EventArgs) Handles picOverviewHelp.Click
        Try
            System.Diagnostics.Process.Start(My.Resources.help_overview)
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub

    Private Sub mrcSidePanel_CheckedChanged(sender As Object, e As EventArgs) Handles mrcSidePanel.CheckedChanged
        AppSettings.General.DisplaySidePanel = mrcSidePanel.Checked
        With tlpOverview
            If mrcSidePanel.Checked Then
                .ColumnStyles(2).SizeType = SizeType.Absolute
                If AppSettings.General.SidePanelWidth < 275 Then
                    .ColumnStyles(2).Width = 275
                    AppSettings.General.SidePanelWidth = 275
                Else
                    .ColumnStyles(2).Width = AppSettings.General.SidePanelWidth
                End If
                .ColumnStyles(1).SizeType = SizeType.AutoSize
                tlpDeviceInfo.Visible = True
                rspOverview.Visible = True
            Else
                .ColumnStyles(2).SizeType = SizeType.AutoSize
                .ColumnStyles(1).SizeType = SizeType.AutoSize
                tlpDeviceInfo.Visible = False
                rspOverview.Visible = False
            End If
        End With
        AppSettings.Save()
    End Sub
#End Region

#Region "Devices list"
    Dim current As Short
    Dim loadnow As Boolean = True

    Private Sub SetMenu(ByVal dev As Device)
        If Not IO.Directory.Exists(AppSettings.Sharing.XmlFolder) Then
            mnuXmlCreate.Enabled = False
            mnuXmlCreate.Checked = False
        Else
            mnuXmlCreate.Enabled = True
            mnuXmlCreate.Checked = AppSettings.Sharing.XmlReport
        End If

        mnuInfoPanel.Checked = AppSettings.General.DisplayInfoPanel

        If IsNothing(dev) Then
            mnuTrayLife.Enabled = False
            mnuTrayLife.Checked = False
            mnuTrayTemperature.Enabled = False
            mnuTrayTemperature.Checked = False
            mnuShareThis.Enabled = False
            mnuShareThis.Checked = False
            Exit Sub
        End If

        If Not IO.Directory.Exists(AppSettings.Sharing.OutputFolder) Then
            mnuShareThis.Enabled = False
            mnuShareThis.Checked = False
        Else
            mnuShareThis.Enabled = True
            mnuShareThis.Checked = dev.IsShared
        End If

        If dev.IsVirtual Then
            mnuRemoveVirtualDev.Enabled = True
            mnuShareThis.Enabled = False
            mnuShareThis.Checked = False
            mnuTrayLife.Enabled = False
            mnuTrayLife.Checked = False
            mnuTrayTemperature.Enabled = False
            mnuTrayTemperature.Checked = False
        ElseIf dev.Type = DeviceType.ThreeWare Then
            mnuRemoveVirtualDev.Enabled = False
            mnuShareThis.Enabled = False
            mnuShareThis.Checked = False
            mnuTrayLife.Enabled = False
            mnuTrayLife.Checked = False
            mnuTrayTemperature.Enabled = False
            mnuTrayTemperature.Checked = False
        Else
            mnuRemoveVirtualDev.Enabled = False
            If dev.Type = DeviceType.SCSI Then
                mnuTrayLife.Enabled = False
            Else
                mnuTrayLife.Enabled = dev.ATA.IsSsd
            End If
            mnuTrayTemperature.Enabled = IsNumeric(dev.Temperature)
        End If

        If mnuShareThis.Enabled Then mnuShareThis.Checked = dev.IsShared

        If Not IO.Directory.Exists(AppSettings.Sharing.XmlFolder) Then
            mnuXmlCreate.Enabled = False
            mnuXmlCreate.Checked = False
        Else
            mnuXmlCreate.Enabled = True
            mnuXmlCreate.Checked = AppSettings.Sharing.XmlReport
        End If

        If Not dev.IsVirtual Then
            If dev.Tray.Show Then
                If dev.Tray.DisplayLife Then
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
        End If
    End Sub

    Private Sub lvwDevices_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles lvwDevices.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub lvwDevices_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles lvwDevices.DrawSubItem
        If IsNothing(e) Then Exit Sub

        Dim x As Integer = e.Item.Position.X
        Dim y As Integer = e.Item.Position.Y

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault

        'icon and rating
        e.Graphics.DrawImage(GetDeviceImage(e.Item.Index), New Rectangle(x + 11, y + 3, 32, 32))
        e.Graphics.DrawImage(GetRatingImage(e.Item.Index), New Rectangle(x + 3, e.Bounds.Bottom - 15, 48, 8))

        Dim colStart As Integer = x + 54
        Dim tfFlags As TextFormatFlags = TextFormatFlags.Left + TextFormatFlags.Bottom + TextFormatFlags.EndEllipsis

        'device name and last update
        TextRenderer.DrawText(e.Graphics, e.Item.Text, New Font(e.Item.Font.FontFamily, 10, FontStyle.Regular, GraphicsUnit.Point), New Rectangle(x + 54, y + 3, 300, 19), e.Item.ForeColor, Nothing, TextFormatFlags.Left + TextFormatFlags.Top + TextFormatFlags.EndEllipsis)
        Dim textWidth As Integer = TextRenderer.MeasureText(GetString(413) & ":", e.Item.Font).Width
        TextRenderer.DrawText(e.Graphics, GetString(413) & ":", e.Item.Font, New Rectangle(colStart, y + 22, textWidth, 19), Color.Gray, Nothing, tfFlags)
        colStart += textWidth + 2
        TextRenderer.DrawText(e.Graphics, e.Item.SubItems(1).Text.Replace("N/A", "-"), e.Item.Font, New Rectangle(colStart, y + 22, 200, 19), e.Item.SubItems(1).ForeColor, Nothing, tfFlags)

        If colStart + 150 < x + 54 + 300 Then colStart = x + 54 + 300 Else colStart += 150

        'temperature and remaining life
        textWidth = TextRenderer.MeasureText(GetString(402) & ":", e.Item.Font).Width
        TextRenderer.DrawText(e.Graphics, GetString(402) & ":", e.Item.Font, New Rectangle(colStart, y + 3, textWidth, 19), Color.Gray, Nothing, tfFlags)
        TextRenderer.DrawText(e.Graphics, e.Item.SubItems(2).Text.Replace("N/A", "-"), e.Item.Font, New Rectangle(colStart + textWidth, y + 3, 50, 19), e.Item.SubItems(2).ForeColor, Nothing, tfFlags)
        textWidth = TextRenderer.MeasureText(GetString(403) & ":", e.Item.Font).Width
        TextRenderer.DrawText(e.Graphics, GetString(403) & ":", e.Item.Font, New Rectangle(colStart, y + 22, textWidth, 19), Color.Gray, Nothing, tfFlags)
        TextRenderer.DrawText(e.Graphics, e.Item.SubItems(3).Text.Replace("N/A", "-"), e.Item.Font, New Rectangle(colStart + textWidth, y + 22, 50, 19), e.Item.SubItems(3).ForeColor, Nothing, tfFlags)

        colStart += ColumnWidth({GetString(402) & ":", GetString(403) & ":"}, e.Item.Font) + 70

        'bad sectors, ata errors, non medium errors and grown defects
        Dim s_e, i_e As String 'i_e = interface error; s_e = surface error
        If devlist(e.Item.Index).Type = DeviceType.SCSI Then
            s_e = GetString(411)
            i_e = GetString(412)
        Else
            s_e = GetString(407)
            i_e = GetString(408)
        End If
        textWidth = TextRenderer.MeasureText(s_e & ":", e.Item.Font).Width
        TextRenderer.DrawText(e.Graphics, s_e & ":", e.Item.Font, New Rectangle(colStart, y + 3, textWidth, 19), Color.Gray, Nothing, tfFlags)
        TextRenderer.DrawText(e.Graphics, e.Item.SubItems(4).Text.Replace("N/A", "-"), e.Item.Font, New Rectangle(colStart + textWidth, y + 3, 50, 19), e.Item.SubItems(4).ForeColor, Nothing, tfFlags)
        textWidth = TextRenderer.MeasureText(i_e & ":", e.Item.Font).Width
        TextRenderer.DrawText(e.Graphics, i_e & ":", e.Item.Font, New Rectangle(colStart, y + 22, textWidth, 19), Color.Gray, Nothing, tfFlags)
        TextRenderer.DrawText(e.Graphics, e.Item.SubItems(5).Text.Replace("N/A", "-"), e.Item.Font, New Rectangle(colStart + textWidth, y + 22, 50, 19), e.Item.SubItems(5).ForeColor, Nothing, tfFlags)

        colStart += ColumnWidth({GetString(411) & ":", GetString(412) & ":", GetString(407) & ":", GetString(408) & ":"}, e.Item.Font) + 50

        'smart check and last error result
        textWidth = TextRenderer.MeasureText(GetString(409) & ":", e.Item.Font).Width
        TextRenderer.DrawText(e.Graphics, GetString(409) & ":", e.Item.Font, New Rectangle(colStart, y + 3, textWidth, 19), Color.Gray, Nothing, tfFlags)
        TextRenderer.DrawText(e.Graphics, e.Item.SubItems(6).Text.Replace("N/A", "-"), e.Item.Font, New Rectangle(colStart + textWidth, y + 3, 100, 19), e.Item.SubItems(6).ForeColor, Nothing, tfFlags)
        textWidth = TextRenderer.MeasureText(GetString(410) & ":", e.Item.Font).Width
        TextRenderer.DrawText(e.Graphics, GetString(410) & ":", e.Item.Font, New Rectangle(colStart, y + 22, textWidth, 19), Color.Gray, Nothing, tfFlags)
        TextRenderer.DrawText(e.Graphics, e.Item.SubItems(7).Text.Replace("N/A", "-"), e.Item.Font, New Rectangle(colStart + textWidth, y + 22, 100, 19), e.Item.SubItems(7).ForeColor, Nothing, tfFlags)

        colStart += ColumnWidth({GetString(409) & ":", GetString(410) & ":"}, e.Item.Font) + 100

        'set column width
        lvwDevices.Columns(0).Width = colStart

        'separation line
        Dim p As New Pen(New SolidBrush(Color.FromArgb(220, 220, 220)))
        e.Graphics.DrawLine(p, 5, e.Item.Bounds.Bottom, e.Item.Bounds.Right - 5, e.Item.Bounds.Bottom)
        p.Dispose()
    End Sub

    Public Function ColumnWidth(ByVal strings() As String, ByVal f As Font) As Integer
        If strings.Count = 0 Then
            Return 0
        Else
            Array.Sort(strings, AddressOf CompareStringsByLength)
            Return TextRenderer.MeasureText(strings(strings.Count - 1), f).Width
        End If
    End Function

    Private Shared Function CompareStringsByLength(ByVal x As String, ByVal y As String) As Integer
        If x Is Nothing Then
            If y Is Nothing Then
                ' If x is Nothing and y is Nothing, they're equal.  
                Return 0
            Else
                ' If x is Nothing and y is not Nothing, y is greater.  
                Return -1
            End If
        Else
            ' If x is not Nothing.. 
            If y Is Nothing Then
                ' ..and y is Nothing, x is greater. 
                Return 1
            Else
                ' ..and y is not Nothing, compare the  
                ' lengths of the two strings. 
                Dim retval As Integer =
                    x.Length.CompareTo(y.Length)

                If retval <> 0 Then
                    ' If the strings are not of equal length, 
                    ' the longer string is greater. 
                    Return retval
                Else
                    ' If the strings are of equal length, 
                    ' sort them with ordinary string comparison. 
                    Return x.CompareTo(y)
                End If
            End If
        End If

    End Function

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
                mnuRefreshSel.Enabled = True
                If devlist(lvItem.Index).Type <> DeviceType.ThreeWare Then
                    If devlist(lvItem.Index).Type = DeviceType.SCSI Then
                        mnuTitle.Text = devlist(lvItem.Index).Scsi.Info.Product
                    Else
                        mnuTitle.Text = devlist(lvItem.Index).ATA.Info.Model
                    End If
                Else
                    mnuTitle.Text = "3ware clipboard"
                End If
                SetMenu(devlist(lvItem.Index))
                cmDevices.Show(CType(sender, ListView), New Point(e.X, e.Y))
            ElseIf e.Button = MouseButtons.Right And IsNothing(lvItem) Then
                mnuRemoveVirtualDev.Enabled = False
                mnuRefreshSel.Enabled = False
                mnuTitle.Text = "HDD Guardian"
                SetMenu(Nothing)
                cmDevices.Show(CType(sender, ListView), New Point(e.X, e.Y))
            End If
        Catch ex As Exception
            'Dim diagnostic As New System.Diagnostics.StackTrace(ex, True)
            'PrintDebug("Error on devices list: " & ex.Message)
            'PrintDebug("at line of code: " & diagnostic.GetFrame(0).GetFileLineNumber & " on file " & diagnostic.GetFrame(0).GetFileName)
        End Try

    End Sub

    Private Sub lvwDevices_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvwDevices.ItemSelectionChanged
        If isloading Then Exit Sub
        If e.IsSelected And loadnow And Not Me.ResizeRedraw Then

            Dim dev As Device = devlist(e.ItemIndex)
            FillSidePanel()

            If htcMain.SelectedTab Is tpOverview Then
                cboDevices.SelectedIndex = lvwDevices.SelectedItems(0).Index
            End If
        End If
    End Sub

    Private Sub lvwDevices_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvwDevices.MouseDoubleClick
        Dim lvItem As ListViewItem = lvwDevices.GetItemAt(e.X, e.Y)
        If Not IsNothing(lvItem) Then
            extManage.Checked = True
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
        LanguagesUpdate()
        RegularReport()

        UpdateAll(DeviceType.ATA)
        UpdateAll(DeviceType.SCSI)
        UpdateAll(DeviceType.USB)

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

        AddVirtualDevice.ShowDialog(Me)

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
        RemoveVirtual(devlist(i).Location)
        devlist.RemoveAt(i)

        FillManageDeviceList()
        lvwDevices.Items(0).Selected = True
    End Sub
#End Region

#Region "Tray icon"
    Private Sub mnuTrayTemperature_Click(sender As Object, e As EventArgs) Handles mnuTrayTemperature.Click
        mnuTrayLife.Checked = False
        mnuTrayTemperature.Checked = Not mnuTrayTemperature.Checked

        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)
        dev.Tray.DisplayLife = False
        dev.Tray.Show = mnuTrayTemperature.Checked
    End Sub

    Private Sub mnuTrayLife_Click(sender As Object, e As EventArgs) Handles mnuTrayLife.Click
        mnuTrayTemperature.Checked = False
        mnuTrayLife.Checked = Not mnuTrayLife.Checked

        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)
        dev.Tray.DisplayLife = True
        dev.Tray.Show = mnuTrayLife.Checked
    End Sub

    Private Sub mnuInfoPanel_Click(sender As Object, e As EventArgs) Handles mnuInfoPanel.Click
        mnuInfoPanel.Checked = Not mnuInfoPanel.Checked
        SettingsForm.chkInfoPanel.Checked = mnuInfoPanel.Checked
    End Sub
#End Region

#Region "Sharing"
    Private Sub mnuSharingFolder_Click(sender As Object, e As EventArgs) Handles mnuSharingFolder.Click
        With dlgFolder
            .Description = SettingsForm.lblSelFolder.Text
            Dim result As DialogResult = .ShowDialog(Me)
            If result = DialogResult.OK Then
                mnuShareThis.Enabled = True

                SettingsForm.lblFolder.Text = .SelectedPath
                SettingsForm.lblFolder.Visible = True
                'Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)

                'isloading_features = True
                'CommonPanels.chkEnableShare.Checked = dev.IsShared
                'CommonPanels.chkEnableShare.Enabled = True
                'isloading_features = False

                SettingsForm.SaveSettings("sharing")
            End If
        End With
    End Sub


    Private Sub mnuShareThis_Click(sender As Object, e As EventArgs) Handles mnuShareThis.Click
        mnuShareThis.Checked = Not mnuShareThis.Checked
        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)
        dev.IsShared = mnuShareThis.Checked
        SettingsForm.SaveSettings("menu share")
    End Sub
#End Region

#Region "Xml"
    Private Sub mnuXmlFolder_Click(sender As Object, e As EventArgs) Handles mnuXmlFolder.Click
        With dlgFolder
            .Description = SettingsForm.lblXml.Text
            Dim result As DialogResult = .ShowDialog(Me)
            If result = DialogResult.OK Then
                mnuXmlCreate.Enabled = True
                SettingsForm.lblXmlPath.Text = .SelectedPath
                SettingsForm.lblXmlPath.Visible = True
                SettingsForm.SaveSettings("xml folder")
            End If
        End With
    End Sub

    Private Sub mnuXmlCreate_Click(sender As Object, e As EventArgs) Handles mnuXmlCreate.Click
        mnuXmlCreate.Checked = Not mnuXmlCreate.Checked
        SettingsForm.chkXml.Checked = mnuXmlCreate.Checked
        SettingsForm.btnXml.Enabled = mnuXmlCreate.Checked
        If Not isloading_settings Then SettingsForm.SaveSettings("xml create")
    End Sub
#End Region

#End Region

#Region "Side panel and separator"
    Private Sub rspOverview_MouseMove(sender As Object, e As MouseEventArgs) Handles rspOverview.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            With tlpOverview
                If .Width - (rspOverview.Left + e.X) < 275 Then Exit Sub
                AppSettings.General.SidePanelWidth = .Width - (rspOverview.Left + e.X)
                .ColumnStyles(2).SizeType = SizeType.Absolute
                .ColumnStyles(0).SizeType = SizeType.Percent
                .ColumnStyles(2).Width = .Width - (rspOverview.Left + e.X)
            End With
        End If
    End Sub

    Private Sub picSeparator_MouseUp(sender As Object, e As MouseEventArgs)
        'in this manner is avoid to save many times application settings when moving the side panel separator
        AppSettings.Save()
    End Sub

    Private Sub lnkManufacturer_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkManufacturer.LinkClicked
        Try
            System.Diagnostics.Process.Start(sender.Tag)
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub

    Private Sub lnkUpdateDatabase_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUpdateDatabase.LinkClicked
        If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\smartctl\update-smart-drivedb.exe") Then
            Shell(My.Application.Info.DirectoryPath & "\smartctl\update-smart-drivedb.exe", AppWinStyle.NormalFocus, False)
        End If
    End Sub

    Private Sub WarningLinks_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkWeb1.LinkClicked, lnkWeb2.LinkClicked, lnkWeb3.LinkClicked
        Try
            System.Diagnostics.Process.Start(sender.Text)
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
            If Not d.IsVirtual Then
                Dim loc() As String = d.Location.ToString.Split(" ")
                txtsize = TextRenderer.MeasureText(loc(0), Me.Font)
            Else
                txtsize = TextRenderer.MeasureText(d.VirtualDeviceName, Me.Font)
            End If
            If txtsize.Width + 5 > column1 Then column1 = txtsize.Width + 5

            Dim txtsize2 As Size
            If d.Type = DeviceType.SCSI Then
                txtsize2 = TextRenderer.MeasureText(d.Scsi.Info.Product, Me.Font)
            Else
                txtsize2 = TextRenderer.MeasureText(d.ATA.Info.Model, Me.Font)
            End If
            If txtsize2.Width + 5 > column2 Then column2 = txtsize2.Width + 5

            Dim txtsize3 As Size
            If d.Type = DeviceType.SCSI Then
                txtsize3 = TextRenderer.MeasureText(d.Scsi.Info.SerialNumber, Me.Font)
            Else
                txtsize3 = TextRenderer.MeasureText(d.ATA.Info.SerialNumber, Me.Font)
            End If
            If txtsize3.Width + 5 > column3 Then column3 = txtsize3.Width + 5
        Next

        e.DrawBackground()

        Try
            Dim di As Device = devlist(e.Index)

            Dim xLeft As Integer = e.Bounds.Location.X
            Dim yTop As Integer = e.Bounds.Location.Y

            'draw first string (location/description)
            If Not di.IsVirtual Then
                Dim loc() As String = di.Location.ToString.Split(" ")
                TextRenderer.DrawText(e.Graphics, loc(0), e.Font, New Point(xLeft, yTop), Color.LightGray)
            Else
                TextRenderer.DrawText(e.Graphics, di.VirtualDeviceName, e.Font, New Point(xLeft, yTop), Color.LightGray)
            End If
            If di.Type = DeviceType.SCSI Then
                'draw second string (device model)
                TextRenderer.DrawText(e.Graphics, di.Scsi.Info.Product, e.Font, New Point(column1, yTop), e.ForeColor, TextFormatFlags.Left)
                'draw third string (device serial number)
                TextRenderer.DrawText(e.Graphics, di.Scsi.Info.SerialNumber, e.Font, New Point(column1 + column2, yTop), e.ForeColor, TextFormatFlags.Left)
            Else
                'draw second string (device model)
                TextRenderer.DrawText(e.Graphics, di.ATA.Info.Model, e.Font, New Point(column1, yTop), e.ForeColor, TextFormatFlags.Left)
                'draw third string (device serial number)
                TextRenderer.DrawText(e.Graphics, di.ATA.Info.SerialNumber, e.Font, New Point(column1 + column2, yTop), e.ForeColor, TextFormatFlags.Left)
            End If

            e.DrawFocusRectangle()
        Catch
        End Try
    End Sub

    Private Sub cboDevices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDevices.SelectedIndexChanged
        DisableSections()

        If devlist(cboDevices.SelectedIndex).Type = DeviceType.SCSI Then
            MoveToScsi()
            PopulateScsiPanels()
            If devlist(cboDevices.SelectedIndex).Scsi.Test.IsRunning Then
                pnlScsiTestRun.Visible = True
                btnScsiStop.Visible = True
                btnScsiRun.Enabled = False
                tmrTest.Start()
            Else
                pnlScsiTestRun.Visible = False
                btnScsiStop.Visible = False
                btnScsiRun.Enabled = True
                tmrTest.Stop()
            End If
        Else
            MoveToAta()
            PopulateAtaPanels()
            If Not devlist(cboDevices.SelectedIndex).IsVirtual Then
                flwTests.Visible = True
                If devlist(cboDevices.SelectedIndex).ATA.Test.IsRunning Then
                    lblExtimatedEnd.Text = lblExtimatedEnd.Tag & devlist(cboDevices.SelectedIndex).ATA.Test.EndTest
                    prbTestProgress.Value = devlist(cboDevices.SelectedIndex).ATA.Test.Percentage
                    lblProgress.Text = devlist(cboDevices.SelectedIndex).ATA.Test.Percentage & "%"
                    Select Case devlist(cboDevices.SelectedIndex).ATA.Test.RunningTest
                        Case Device.AtaTest.TestType.Conveyance
                            optConveyance.Checked = True
                        Case Device.AtaTest.TestType.Extended
                            optLong.Checked = True
                        Case Device.AtaTest.TestType.Offline
                            optOffline.Checked = True
                        Case Device.AtaTest.TestType.Short
                            optShort.Checked = True
                    End Select
                    tmrTest.Start()
                    flwProgress.Visible = True
                    btnRun.Enabled = False
                    btnStop.Enabled = True
                    flwTests.Enabled = False
                Else
                    flwProgress.Visible = False
                    flwTests.Enabled = True
                    btnRun.Enabled = True
                    btnStop.Enabled = False
                    tmrTest.Stop()
                End If
            Else
                flwProgress.Visible = False
                flwTests.Visible = False
            End If

        End If

        If htcMain.SelectedTab Is tpManage Then
            lvwDevices.Items(cboDevices.SelectedIndex).Selected = True
        End If

        If cboDevices.SelectedIndex = 0 Then
            mrbLeft.Enabled = False
        Else
            mrbLeft.Enabled = True
        End If
        If cboDevices.SelectedIndex = cboDevices.Items.Count - 1 Then
            mrbRight.Enabled = False
        Else
            mrbRight.Enabled = True
        End If
    End Sub

    Public Sub DisableSections()
        Dim d As Device = devlist(cboDevices.SelectedIndex)

        For Each Control In tlpSideMenu.Controls
            If Control.GetType <> GetType(Label) Then Control.Enabled = True
        Next

        If Not isadmin Then
            mrrTemperatures.Enabled = False
            mrrSmartSetup.Enabled = False
            mrrAam.Enabled = False
            mrrApm.Enabled = False
            mrrStandby.Enabled = False
            mrrReadWrite.Enabled = False
            mrrErrorsLog.Enabled = False
            mrrTestsLog.Enabled = False
            mrrRunTest.Enabled = False
            mrrAdvanced.Enabled = False
            Exit Sub
        End If

        If asmedia Then
            If d.Type = DeviceType.ATA Then
                If d.ATA.Attributes.Items.Count = 0 Then
                    mrrAttributes.Enabled = False
                    mrrEvents.Enabled = False
                    mrrTemperatures.Enabled = False
                    mrrSmartSetup.Enabled = False
                    mrrAam.Enabled = False
                    mrrApm.Enabled = False
                    mrrStandby.Enabled = False
                    mrrReadWrite.Enabled = False
                    mrrErrorsLog.Enabled = False
                    mrrTestsLog.Enabled = False
                    mrrRunTest.Enabled = False
                    mrrOutput.Checked = True
                    tlpPowerModeContent.Enabled = False
                    tlpRemapContent.Enabled = False
                    tlpFirmwareContent.Enabled = False
                    d = Nothing
                    Exit Sub
                End If
            End If
        End If

        If d.Type = DeviceType.ThreeWare And Not d.IsValid Then
            mrrAttributes.Enabled = False
            mrrEvents.Enabled = False
            mrrTemperatures.Enabled = False
            mrrSmartSetup.Enabled = False
            mrrAam.Enabled = False
            mrrApm.Enabled = False
            mrrStandby.Enabled = False
            mrrReadWrite.Enabled = False
            mrrErrorsLog.Enabled = False
            mrrTestsLog.Enabled = False
            mrrRunTest.Enabled = False
            mrrAdvanced.Enabled = False
            mrrOutput.Enabled = True
            mrrOutput.Checked = True
            'robInfo.Enabled = True
            'htcInfo.SelectPage(tpAtaInfo)
            d = Nothing
            Exit Sub
        End If

        If d.Type = DeviceType.ThreeWare Then
            mrrEvents.Enabled = False
            mrrTemperatures.Enabled = False
            mrrSmartSetup.Enabled = False
            mrrAam.Enabled = False
            mrrApm.Enabled = False
            mrrStandby.Enabled = False
            mrrReadWrite.Enabled = False
            mrrRunTest.Enabled = False
            mrrAdvanced.Enabled = False
        End If

        If d.Type = DeviceType.SCSI Then
            mrrTemperatures.Enabled = False
            mrrAttributes.Enabled = False
            mrrAam.Enabled = False
            mrrApm.Enabled = False
            mrrStandby.Enabled = False
            mrrReadWrite.Enabled = False
            mrrAdvanced.Enabled = False
        End If

        If d.Smart.IsEnabled <> Support.Enabled Then
            mrrAttributes.Enabled = False
            mrrEvents.Enabled = False
            mrrTemperatures.Enabled = False
            mrrSmartSetup.Enabled = False
            mrrAam.Enabled = False
            mrrApm.Enabled = False
            mrrStandby.Enabled = False
            mrrReadWrite.Enabled = False
            mrrErrorsLog.Enabled = False
            mrrTestsLog.Enabled = False
            mrrRunTest.Enabled = False
            mrrAdvanced.Enabled = False
            mrrOutput.Enabled = True
            mrrOutput.Checked = True
        End If

        d = Nothing
    End Sub

    Public Sub MoveToScsi()
        'info
        If mrrAttributes.Checked Or mrrTemperatures.Checked Then InvokeOnClick(mrrEvents, Nothing)
        ' If htcInfo.SelectedTab Is tpAtaInfo Then htcInfo.SelectPage(tpScsiInfo)
        'If htcInfo.SelectedTab Is tpAtaHealth Then htcInfo.SelectPage(tpScsiHealth)
        'setup
        If mrrAam.Checked Or mrrApm.Checked Or mrrStandby.Checked Or mrrReadWrite.Checked Then InvokeOnClick(mrrSmartSetup, Nothing)
        If htcSetup.SelectedTab Is tpAtaSmartSetup Then htcSetup.SelectPage(tpScsiSmartSetup)
        'errors and tests
        If htcErrorsTests.SelectedTab Is tpAtaErrors Then htcErrorsTests.SelectPage(tpScsiErrors)
        If htcErrorsTests.SelectedTab Is tpAtaTests Then htcErrorsTests.SelectPage(tpScsiTests)
        If htcErrorsTests.SelectedTab Is tpAtaRunTest Then htcErrorsTests.SelectPage(tpScsiRunTest)
        'smartctl
        If mrrAdvanced.Checked Then mrrOutput.Checked = True 'InvokeOnClick(robOutput, Nothing)
    End Sub

    Public Sub MoveToAta()
        'info
        'If htcInfo.SelectedTab Is tpScsiInfo Then htcInfo.SelectPage(tpAtaInfo)
        'If htcInfo.SelectedTab Is tpScsiHealth Then htcInfo.SelectPage(tpAtaHealth)
        'setup
        If htcSetup.SelectedTab Is tpScsiSmartSetup Then htcSetup.SelectPage(tpAtaSmartSetup)
        'errors and tests
        If htcErrorsTests.SelectedTab Is tpScsiErrors Then htcErrorsTests.SelectPage(tpAtaErrors)
        If htcErrorsTests.SelectedTab Is tpScsiTests Then htcErrorsTests.SelectPage(tpAtaTests)
        If htcErrorsTests.SelectedTab Is tpScsiRunTest Then htcErrorsTests.SelectPage(tpAtaRunTest)
        'smartctl is not needed
    End Sub

    Private Sub mrbLeft_Click(sender As Object, e As EventArgs) Handles mrbLeft.Click
        cboDevices.SelectedIndex = cboDevices.SelectedIndex - 1
    End Sub

    Private Sub mrbRight_Click(sender As Object, e As EventArgs) Handles mrbRight.Click
        cboDevices.SelectedIndex = cboDevices.SelectedIndex + 1
    End Sub

    Private Sub mrbReloadDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mrbReloadDevice.Click
        UpdateCurrent()

        If devlist(cboDevices.SelectedIndex).Type = DeviceType.SCSI Then
            MoveToScsi()
            PopulateScsiPanels()
        Else
            MoveToAta()
            PopulateAtaPanels()
        End If

        DisableSections()
    End Sub
#End Region

#Region "Manage: ribbon buttons and separator"

    Private Sub picManageHelp_Click(sender As Object, e As EventArgs) Handles picManageHelp.Click
        Try
            System.Diagnostics.Process.Start(picManageHelp.Tag)
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub

    Private Sub rspManage_MouseMove(sender As Object, e As MouseEventArgs) Handles rspManage.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            With tlpManage
                If rspManage.Left + e.X < 150 Then Exit Sub
                AppSettings.General.ManageSideMenuWidth = rspManage.Left + e.X
                .ColumnStyles(2).SizeType = SizeType.Percent
                .ColumnStyles(0).SizeType = SizeType.Absolute
                .ColumnStyles(0).Width = rspManage.Left + e.X
            End With
        End If
    End Sub

    Private Sub picSeparatorManage_MouseUp(sender As Object, e As MouseEventArgs)
        'in this manner is avoid to save many times application settings when moving the separator
        AppSettings.Save()
    End Sub

#Region "Info"
    Private Sub mrrAttributes_CheckedChanged(sender As Object, e As EventArgs) Handles mrrAttributes.CheckedChanged
        If sender.checked Then
            htcInfo.SelectPage(tpAtaSmartAttributes)

            If Not htcManage.SelectedTab Is tpInfo Then
                htcManage.SelectPage(tpInfo)
            End If

            picManageHelp.Tag = My.Resources.help_smart_attributes
        End If
    End Sub

    Private Sub mrrEventsChart_CheckedChanged(sender As Object, e As EventArgs) Handles mrrEvents.CheckedChanged
        If sender.checked Then
            htcInfo.SelectPage(tpEvents)

            If Not htcManage.SelectedTab Is tpInfo Then
                htcManage.SelectPage(tpInfo)
            End If

            picManageHelp.Tag = My.Resources.help_events_chart
        End If
    End Sub

    Private Sub mrrTemperatures_CheckedChanged(sender As Object, e As EventArgs) Handles mrrTemperatures.CheckedChanged
        If sender.checked Then
            htcInfo.SelectPage(tpTemperatures)

            If Not htcManage.SelectedTab Is tpInfo Then
                htcManage.SelectPage(tpInfo)
            End If

            picManageHelp.Tag = My.Resources.help_temperatures
        End If
    End Sub
#End Region

#Region "Setup"
    Private Sub mrrSmartSetup_CheckedChanged(sender As Object, e As EventArgs) Handles mrrSmartSetup.CheckedChanged
        If sender.checked Then
            Dim d As Device = devlist(cboDevices.SelectedIndex)

            If d.Type = DeviceType.SCSI Then
                htcSetup.SelectPage(tpScsiSmartSetup)
            Else
                htcSetup.SelectPage(tpAtaSmartSetup)
            End If

            If Not htcManage.SelectedTab Is tpSetup Then
                htcManage.SelectPage(tpSetup)
            End If

            picManageHelp.Tag = My.Resources.help_smart_setup
        End If
    End Sub

    Private Sub mrrAam_CheckedChanged(sender As Object, e As EventArgs) Handles mrrAam.CheckedChanged
        If sender.checked Then
            htcSetup.SelectPage(tpAtaAam)

            If Not htcManage.SelectedTab Is tpSetup Then
                htcManage.SelectPage(tpSetup)
            End If

            picManageHelp.Tag = My.Resources.help_aam
        End If
    End Sub

    Private Sub mrrApm_CheckedChanged(sender As Object, e As EventArgs) Handles mrrApm.CheckedChanged
        If sender.checked Then
            htcSetup.SelectPage(tpAtaApm)

            If Not htcManage.SelectedTab Is tpSetup Then
                htcManage.SelectPage(tpSetup)
            End If

            picManageHelp.Tag = My.Resources.help_apm
        End If
    End Sub

    Private Sub mrrStandby_CheckedChanged(sender As Object, e As EventArgs) Handles mrrStandby.CheckedChanged
        If sender.checked Then
            htcSetup.SelectPage(tpAtaStandby)

            If Not htcManage.SelectedTab Is tpSetup Then
                htcManage.SelectPage(tpSetup)
            End If

            picManageHelp.Tag = My.Resources.help_standby
        End If
    End Sub

    Private Sub mrrReadWrite_CheckedChanged(sender As Object, e As EventArgs) Handles mrrReadWrite.CheckedChanged
        If sender.checked Then
            htcSetup.SelectPage(tpAtaReadWrite)

            If Not htcManage.SelectedTab Is tpSetup Then
                htcManage.SelectPage(tpSetup)
            End If

            picManageHelp.Tag = My.Resources.help_read_write
        End If
    End Sub
#End Region

#Region "Errors and tests"
    Private Sub mrrErrorsLog_CheckedChanged(sender As Object, e As EventArgs) Handles mrrErrorsLog.CheckedChanged
        If sender.checked Then
            Dim d As Device = devlist(cboDevices.SelectedIndex)

            If d.Type = DeviceType.SCSI Then
                htcErrorsTests.SelectPage(tpScsiErrors)
            Else
                htcErrorsTests.SelectPage(tpAtaErrors)
            End If

            If Not htcManage.SelectedTab Is tpErrorsTests Then
                htcManage.SelectPage(tpErrorsTests)
            End If

            picManageHelp.Tag = My.Resources.help_errors_log
        End If
    End Sub

    Private Sub mrrTestsLog_CheckedChanged(sender As Object, e As EventArgs) Handles mrrTestsLog.CheckedChanged
        If sender.checked Then
            Dim d As Device = devlist(cboDevices.SelectedIndex)

            If d.Type = DeviceType.SCSI Then
                htcErrorsTests.SelectPage(tpScsiTests)
            Else
                htcErrorsTests.SelectPage(tpAtaTests)
            End If

            If Not htcManage.SelectedTab Is tpErrorsTests Then
                htcManage.SelectPage(tpErrorsTests)
            End If

            picManageHelp.Tag = My.Resources.help_self_tests
        End If
    End Sub

    Private Sub mrrRunTest_CheckedChanged(sender As Object, e As EventArgs) Handles mrrRunTest.CheckedChanged
        If sender.checked Then
            Dim d As Device = devlist(cboDevices.SelectedIndex)

            If d.Type = DeviceType.SCSI Then
                htcErrorsTests.SelectPage(tpScsiRunTest)
                tlpScsiTest.Visible = Not d.IsVirtual
            Else
                htcErrorsTests.SelectPage(tpAtaRunTest)
                flwTests.Visible = Not d.IsVirtual
            End If

            If Not htcManage.SelectedTab Is tpErrorsTests Then
                htcManage.SelectPage(tpErrorsTests)
            End If

            picManageHelp.Tag = My.Resources.help_run_test
        End If
    End Sub
#End Region

#Region "Smartctl"
    Private Sub mrrOutput_CheckedChanged(sender As Object, e As EventArgs) Handles mrrOutput.CheckedChanged
        If sender.checked Then
            htcSmartctl.SelectPage(tpOutput)

            If Not htcManage.SelectedTab Is tpSmartctl Then
                htcManage.SelectPage(tpSmartctl)
            End If

            picManageHelp.Tag = My.Resources.help_device_output
        End If
    End Sub

    Private Sub mrrAdvanced_CheckedChanged(sender As Object, e As EventArgs) Handles mrrAdvanced.CheckedChanged
        If sender.checked Then
            htcSmartctl.SelectPage(tpAdvanced)

            If Not htcManage.SelectedTab Is tpSmartctl Then
                htcManage.SelectPage(tpSmartctl)
            End If

            picManageHelp.Tag = My.Resources.help_advanced
        End If
    End Sub

    Private Sub mrrSmartctl_CheckedChanged(sender As Object, e As EventArgs) Handles mrrSmartctl.CheckedChanged
        If sender.checked Then
            Dim c As New Console
            Dim v() As String = c.SendCmd("-V")
            c = Nothing

            lblVersion.Text = ""
            For i As Short = 0 To v.Count - 1
                lblVersion.Text += v(i)
            Next

            htcSmartctl.SelectPage(tpVersion)

            If Not htcManage.SelectedTab Is tpSmartctl Then
                htcManage.SelectPage(tpSmartctl)
            End If

            'picManageHelp.Tag = My.Resources.help_version
        End If
    End Sub
#End Region

#End Region

#Region "ATA"

#Region "SMART setup"

    Private Sub chkEnableSmart_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkEnableSmart.MouseDown
        Dim dev As Device = devlist(cboDevices.SelectedIndex)
        Dim model As String = ""

        If dev.Type = DeviceType.SCSI Then
            model = dev.Scsi.Info.Product
        Else
            model = dev.ATA.Info.Model
        End If

        If dev.IsVirtual Or isloading_features Then Exit Sub

        Select Case dev.Smart.IsEnabled ' chkEnableSmart.Checked
            Case Support.Disabled   'True
                dev.Smart.Enable()
                dev.Update()
                Select Case dev.Smart.IsEnabled
                    Case Support.Enabled
                        MsgBox(m_smartenabled.Replace("%", model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                        chkEnableSmart.Checked = True
                        chkEnableOffline.Enabled = True
                        chkEnableAutosave.Enabled = True
                    Case Support.Ambiguous
                        MsgBox(m_smartambiguous.Replace("%", model), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, m_message)
                        chkEnableSmart.Checked = False
                    Case Support.Disabled
                        MsgBox(m_smartnotsupported.Replace("%", model), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, m_message)
                        chkEnableSmart.Checked = False
                End Select
            Case Support.Enabled  ' False
                Dim qst As MsgBoxResult = MsgBox(m_qdisablesmart.Replace("%", model), MsgBoxStyle.YesNo + MsgBoxStyle.Question, m_question)
                If qst = MsgBoxResult.Yes Then
                    dev.Smart.Disable()
                    dev.Update()
                    MsgBox(m_smartdisabled.Replace("%", model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
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
        Dim model As String = ""

        If dev.Type = DeviceType.SCSI Then
            model = dev.Scsi.Info.Product
        Else
            model = dev.ATA.Info.Model
        End If

        If dev.IsVirtual Or isloading_features Then Exit Sub

        Select Case dev.ATA.Features.OfflineAuto.Status
            Case Support.Enabled  ' True
                Dim qst As MsgBoxResult = MsgBox(m_qdisableoffldata.Replace("%", model), MsgBoxStyle.YesNo + MsgBoxStyle.Question, m_question)
                If qst = MsgBoxResult.Yes Then
                    dev.ATA.Features.OfflineAuto.Disable()
                    dev.Update()
                    If dev.ATA.Features.OfflineAuto.Status = Support.Disabled Then
                        MsgBox(m_offldatadisabled.Replace("%", model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                        chkEnableOffline.Checked = False
                    ElseIf dev.ATA.Features.OfflineAuto.Status = Support.Enabled Then
                        MsgBox(m_unabletodisable.Replace("%", model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                        chkEnableOffline.Checked = True
                    End If
                End If
            Case Support.Disabled ' False
                dev.ATA.Features.OfflineAuto.Enable()
                dev.Update()
                txtReport.Text = dev.Output
                Select Case dev.ATA.Features.OfflineAuto.Status
                    Case Support.Enabled
                        MsgBox(m_offldataenabled.Replace("%", model), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                        chkEnableOffline.Checked = True
                    Case Support.Disabled
                        MsgBox(m_offldatanotsupported.Replace("%", model), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, m_message)
                        chkEnableOffline.Checked = False
                End Select
        End Select

        PopulateAtaPanels()
        'UpdateCurrent()
    End Sub

    Private Sub chkEnableAutosave_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableAutosave.CheckedChanged
        If isloading_devsettings Or lvwDevices.Items.Count = 0 Then Exit Sub

        Dim dev As Device = devlist(cboDevices.SelectedIndex)
        If dev.IsVirtual Then Exit Sub
        SaveDeviceSettings()
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
            dev.ATA.Features.Aam.Value = "off"
        Else
            dev.ATA.Features.Aam.Value = trkAam.Value
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

        lblAamValue.Text = lblAamValue.Tag & ": " & dev.ATA.Features.Aam.RecommendedValue
        trkAam.Value = dev.ATA.Features.Aam.RecommendedValue
        dev.ATA.Features.Aam.Value = dev.ATA.Features.Aam.RecommendedValue

        tlpAamWaitMessage.Visible = False

        txtReport.Text = dev.Output
    End Sub

    Private Sub lnkUndoAam_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUndoAam.LinkClicked
        Dim dev As Device = devlist(cboDevices.SelectedIndex)
        trkAam.Value = dev.ATA.Features.Aam.Value
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
            dev.ATA.Features.Apm.Value = "off"
        Else
            dev.ATA.Features.Apm.Value = trkApm.Value
        End If

        tlpApmWaitMessage.Visible = False

        txtReport.Text = dev.Output
    End Sub

    Private Sub lnkUndoApm_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUndoApm.LinkClicked
        Dim dev As Device = devlist(cboDevices.SelectedIndex)
        trkApm.Value = dev.ATA.Features.Apm.Value
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

        dev.ATA.Features.Standby = trkStandby.Value

        tlpStandbyWaitMessage.Visible = False
    End Sub

    Private Sub lnkUndoStandby_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUndoStandby.LinkClicked
        Dim dev As Device = devlist(cboDevices.SelectedIndex)
        trkStandby.Value = dev.ATA.Features.Standby
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
                    dev.ATA.Features.WriteCache.Enabled = Feature.Disabled
                Case True
                    dev.ATA.Features.WriteCache.Enabled = Feature.Enabled
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
                    dev.ATA.Features.LookAhead = Feature.Disabled
                Case True
                    dev.ATA.Features.LookAhead = Feature.Enabled
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
                    dev.ATA.Features.WriteCache.Reorder = Feature.Disabled
                Case True
                    dev.ATA.Features.WriteCache.Reorder = Feature.Enabled
            End Select

            tlpWaitRWMessage.Visible = False

            txtReport.Text = dev.Output
        End If
    End Sub
#End Region

#Region "SMART attributes"

    Private Sub CatchAttributeInfo(ByVal itemname As String)
        Dim haveinfo As Boolean = False
        Dim family As String = devlist(cboDevices.SelectedIndex).ATA.Info.Family

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
        Dim cs As New ColorScheme
        Dim sel_no As Color = cs.HorizontalLine
        Dim sel_yes As Color = cs.ForeColor

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
    Private Sub Error_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optError1.CheckedChanged, optError2.CheckedChanged,
        optError3.CheckedChanged, optError4.CheckedChanged, optError5.CheckedChanged

        Try
            'Dim err As Short = Val(sender.Name.ToString.Substring(8, 1))
            DisplayAtaError(sender.Text)
        Catch ex As Exception
            PrintDebug("Error displaying ATA errors: " & ex.ToString, True)
        End Try
    End Sub
#End Region

#Region "Run test"

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If optOffline.Checked Then dev.ATA.Test.Run(Device.AtaTest.TestType.Offline)
        If optShort.Checked Then dev.ATA.Test.Run(Device.AtaTest.TestType.Short)
        If optLong.Checked Then dev.ATA.Test.Run(Device.AtaTest.TestType.Extended)
        If optConveyance.Checked Then dev.ATA.Test.Run(Device.AtaTest.TestType.Conveyance)

        btnRun.Enabled = False
        flwTests.Enabled = False

        prbTestProgress.Value = 0
        prbTestProgress.Maximum = 100
        lblProgress.Text = "0%"
        lblExtimatedEnd.Text = lblExtimatedEnd.Tag & dev.ATA.Test.EndTest ' lblExtimatedEnd.Tag & dev.TestTiming.Conclusion
        btnStop.Enabled = True
        flwProgress.Visible = True
        tmrTest.Start()

        tlpTestProgress.Visible = True

    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Dim response As MsgBoxResult = MsgBox(m_abortmsg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, m_aborttitle)
        If response = MsgBoxResult.Yes Then
            Dim dev As Device = devlist(cboDevices.SelectedIndex)
            If dev.Type = DeviceType.SCSI Then
                dev.Scsi.Test.Abort()
            Else
                dev.ATA.Test.Abort()
            End If
            flwTests.Enabled = True
            btnRun.Enabled = True
            tlpTestProgress.Visible = False
        End If
    End Sub

    Private Sub tmrTest_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTest.Tick
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If dev.Type = DeviceType.SCSI Then
            If dev.Scsi.Test.IsRunning Then
                lblScsiProgress.Text = dev.Scsi.Test.Percentage & "%"
                prbScsiTestProgress.Value = dev.Scsi.Test.Percentage
            Else
                tlpTestProgress.Visible = False
                btnRun.Enabled = True
                btnStop.Enabled = False
            End If
        Else
            If dev.ATA.Test.IsRunning Then
                lblProgress.Text = dev.ATA.Test.Percentage & "%"
                prbTestProgress.Value = dev.ATA.Test.Percentage
            Else
                tlpTestProgress.Visible = False
                btnRun.Enabled = True
                btnStop.Enabled = False
            End If
        End If
    End Sub
#End Region

#Region "Attributes remap"
    Private Sub chkAttributes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAttributes.CheckedChanged
        pnlAttributes.Enabled = chkAttributes.Checked
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
        flwFirmware.Enabled = chkFirmware.Checked
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

    Private Sub chkXErrorLba_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkXErrorLba.CheckedChanged
        If Not isloading_devsettings Then SaveDeviceSettings()
    End Sub

    Private Sub chkFixSwap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFixSwap.CheckedChanged
        If Not isloading_devsettings Then SaveDeviceSettings()
    End Sub
#End Region

#Region "Power mode"
    Private Sub chkPowerMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPowerMode.CheckedChanged
        flwPowerMode.Enabled = chkPowerMode.Checked

        If Not isloading_devsettings Then
            If chkPowerMode.Checked Then
                rbIdle.Checked = True
            Else
                rbIdle.Checked = False
            End If
        End If

        If Not isloading_devsettings Then SaveDeviceSettings()
    End Sub

    Private Sub ChangePowerMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIdle.CheckedChanged, rbNever.CheckedChanged, rbSleep.CheckedChanged, rbStandby.CheckedChanged
        If Not isloading_devsettings Then SaveDeviceSettings()
    End Sub
#End Region

#Region "Smartctl version info"

#End Region

#Region "ASMedia controller debug"
    Private Sub chkAsmedia_CheckedChanged(sender As Object, e As EventArgs) Handles chkAsmedia.CheckedChanged
        If Not isloading_devsettings Then
            Dim testdrive As New Device(devlist(cboDevices.SelectedIndex).Location.Replace("-d ata", "-d sat"), DeviceType.ATA, False)
            If testdrive.IsValid Then
                SaveDeviceSettings()
                UpdateAll(DeviceType.ATA)
                PopulateAtaPanels()
                DisableSections()
                FillSidePanel()
            Else
                chkAsmedia.Checked = False
            End If
            testdrive = Nothing
        End If
    End Sub
#End Region

#End Region

#Region "SCSI"

#Region "SMART setup"

    Private Sub chkScsiSmart_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkScsiSmart.MouseDown
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        If dev.IsVirtual Or isloading_features Then Exit Sub

        Select Case dev.Smart.IsEnabled
            Case Support.Disabled
                dev.Smart.Enable()
                dev.Update()
                Select Case dev.Smart.IsEnabled
                    Case Support.Enabled
                        MsgBox(m_smartenabled.Replace("%", dev.Scsi.Info.Product), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
                        chkScsiSmart.Checked = True
                        chkScsiSmart.Enabled = True
                    Case Support.Ambiguous
                        MsgBox(m_smartambiguous.Replace("%", dev.Scsi.Info.Product), MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, m_message)
                        chkScsiSmart.Checked = False
                    Case Support.Disabled
                        MsgBox(m_smartnotsupported.Replace("%", dev.Scsi.Info.Product), MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, m_message)
                        chkScsiSmart.Checked = False
                End Select
            Case Support.Enabled
                Dim qst As MsgBoxResult = MsgBox(m_qdisablesmart.Replace("%", dev.Scsi.Info.Product), MsgBoxStyle.YesNo + MsgBoxStyle.Question, m_question)
                If qst = MsgBoxResult.Yes Then
                    dev.Smart.Disable()
                    dev.Update()
                    MsgBox(m_smartdisabled.Replace("%", dev.Scsi.Info.Product), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, m_message)
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
        If Not isloading_features Then
            Dim dev As Device = devlist(cboDevices.SelectedIndex)

            If Not dev.IsVirtual Then
                Select Case chkScsiGltsd.Checked
                    Case False
                        dev.Scsi.Features.Gltsd.Disable()
                    Case True
                        dev.Scsi.Features.Gltsd.Enable()
                End Select
            End If

            PopulateScsiPanels()
        End If
    End Sub

    Private Sub chkScsiWCache_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScsiWCache.CheckedChanged
        If Not isloading_features Then
            Dim dev As Device = devlist(cboDevices.SelectedIndex)

            If Not dev.IsVirtual Then
                Select Case chkScsiWCache.Checked
                    Case False
                        dev.Scsi.Features.WriteCache.Disable()
                    Case True
                        dev.Scsi.Features.WriteCache.Enable()
                End Select
            End If

            PopulateScsiPanels()
        End If
    End Sub

    Private Sub chkScsiRCache_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkScsiRCache.CheckedChanged
        If Not isloading_features Then
            Dim dev As Device = devlist(cboDevices.SelectedIndex)

            If Not dev.IsVirtual Then
                Select Case chkScsiRCache.Checked
                    Case False
                        dev.Scsi.Features.ReadCache.Disable()
                    Case True
                        dev.Scsi.Features.ReadCache.Enable()
                End Select
            End If

            PopulateScsiPanels()
        End If
    End Sub
#End Region

#Region "Run test"
    Private Sub btnScsiRun_Click(sender As Object, e As EventArgs) Handles btnScsiRun.Click
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        dev.Scsi.Test.Run()

        btnScsiRun.Enabled = False
        prbScsiTestProgress.Value = 0
        prbScsiTestProgress.Maximum = 100
        lblScsiProgress.Text = "0%"
        lblScsiExtimatedEnd.Text = dev.Scsi.Test.EndTest  'lblScsiExtimatedEnd.Tag & dev.TestTiming.Conclusion
        btnScsiStop.Enabled = True
        btnScsiStop.Visible = True
        pnlScsiTestRun.Visible = True
        tmrTest.Start()

    End Sub
#End Region

#End Region

#Region "Commons"

#Region "Events"

    Private Sub optEntire_CheckedChanged(sender As Object, e As EventArgs) Handles optEntire.CheckedChanged
        If optEntire.Checked Then
            SetFullGraph()
            DisplayEvents()
        End If
    End Sub

    Private Sub optSelection_CheckedChanged(sender As Object, e As EventArgs) Handles optSelection.CheckedChanged
        If optSelection.Checked Then
            SetGraph(mcLog.SelectionRange.Start, mcLog.SelectionRange.End)
            DisplayEvents()
        End If
    End Sub

    Private Sub mcLog_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mcLog.DateSelected
        If optSelection.Checked Then
            SetGraph(mcLog.SelectionRange.Start, mcLog.SelectionRange.End)
            DisplayEvents()
        End If
    End Sub

    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReload.Click
        If optSelection.Checked Then
            SetGraph(mcLog.SelectionRange.Start, mcLog.SelectionRange.End)
        Else
            SetFullGraph()
        End If
        DisplayEvents()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim txtlog As String = ""
        Dim d As Short = cboDevices.SelectedIndex  ' lvwDevices.SelectedItems(0).Index

        Dim sf As New SaveFileDialog
        Dim res As DialogResult
        sf.AddExtension = True
        sf.DefaultExt = "txt"
        sf.Filter = "Text file (*.txt)|*.txt|Comma-separated values (*.csv)|*.csv"
        sf.FileName = devlist(d).FileName
        res = sf.ShowDialog(Me)
        If res = DialogResult.OK Then
            Select Case sf.FilterIndex
                Case 1 'txt
                    txtlog = "*** DEVICE INFORMATIONS ***" & vbCrLf
                    If devlist(d).Type = DeviceType.SCSI Then
                        txtlog += "Device model    : " & devlist(d).Scsi.Info.Product & vbCrLf
                        txtlog += "Serial number   : " & devlist(d).Scsi.Info.SerialNumber & vbCrLf
                        txtlog += "Revision        : " & devlist(d).Scsi.Info.Revision & vbCrLf
                        txtlog += vbCrLf
                        txtlog += "*** DEVICE HEALTH ***" & vbCrLf
                        txtlog += "Overall health  : " & devlist(d).Health.ToString & vbCrLf
                        txtlog += "Grown defects   : " & devlist(d).Scsi.Health.GrownDefectsCount & vbCrLf
                        txtlog += "Non medium err. : " & devlist(d).Scsi.Health.NonMediumErrors & vbCrLf
                    Else
                        txtlog += "Model family    : " & devlist(d).ATA.Info.Family & vbCrLf
                        txtlog += "Device model    : " & devlist(d).ATA.Info.Model & vbCrLf
                        txtlog += "Serial number   : " & devlist(d).ATA.Info.SerialNumber & vbCrLf
                        txtlog += "Firmware version: " & devlist(d).ATA.Info.FirmwareVersion & vbCrLf
                        txtlog += vbCrLf
                        txtlog += "*** DEVICE HEALTH ***" & vbCrLf
                        txtlog += "Overall health  : " & devlist(d).Health.ToString & vbCrLf
                        txtlog += "Bad sectors     : " & devlist(d).ATA.Health.BadSectorsCount & vbCrLf
                        txtlog += "ATA errors      : " & devlist(d).ATA.Errors.TotalAmount & vbCrLf
                        txtlog += "Reliability     : " & New String("*"c, devlist(d).ATA.Reliability.Overall) & vbCrLf
                    End If
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

                            txtlog += String.Format("{0,-13}{1,-11}{2,-25}{3,11}{4,11}{5,11}", datetocopy, tc, .Event, .OldValue, .NewValue, .Variation) & vbCrLf
                        End With
                    Next
                Case 2 'csv
                    txtlog += "Date,Time,Event,Old Value,New Value,Variation" & vbCrLf
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

                            txtlog += datetocopy & "," & tc & "," & .Event & "," & .OldValue & "," & .NewValue & "," & .Variation & vbCrLf
                        End With
                    Next
            End Select

            IO.File.WriteAllText(sf.FileName, txtlog)
        End If
    End Sub

    Private Sub lvwLog_KeyDown(sender As Object, e As KeyEventArgs) Handles lvwLog.KeyDown
        Select Case e.KeyCode
            Case Keys.A And e.Control
                For i As Short = 0 To lvwLog.Items.Count - 1
                    lvwLog.Items(i).Selected = True
                Next
            Case Keys.D5 And e.Control
                For i As Short = 0 To lvwLog.Items.Count - 1
                    lvwLog.Items(i).Selected = True
                Next
            Case Keys.C And e.Control
                If lvwLog.SelectedItems.Count > 0 Then
                    Dim clipboardText As String = ""

                    For l As Short = 0 To lvwLog.SelectedItems.Count - 1
                        Dim i As Short = lvwDevices.SelectedItems(0).Index
                        Dim item As ListViewItem = lvwLog.SelectedItems(l)
                        If devlist(i).Type = DeviceType.SCSI Then
                            clipboardText += devlist(i).Scsi.Info.Product & "," & devlist(i).Scsi.Info.SerialNumber & "," & item.Group.Header & "," & item.Text & "," & item.SubItems(1).Text &
                                              "," & item.SubItems(2).Text & "," & item.SubItems(3).Text & vbCrLf
                        Else
                            clipboardText += devlist(i).ATA.Info.Model & "," & devlist(i).ATA.Info.SerialNumber & "," & item.Group.Header & "," & item.Text & "," & item.SubItems(1).Text &
                                              "," & item.SubItems(2).Text & "," & item.SubItems(3).Text & vbCrLf
                        End If
                    Next
                    Clipboard.SetText(clipboardText)
                End If
        End Select
    End Sub

    Private Sub lvwLog_MouseUp(sender As Object, e As MouseEventArgs) Handles lvwLog.MouseUp
        Try
            Dim lvItem As ListViewItem

            lvItem = lvwLog.GetItemAt(e.X, e.Y)

            If Not IsNothing(lvItem) Then current = lvwLog.SelectedItems(0).Index
            lvwLog.Items(current).Selected = True

            If e.Button = MouseButtons.Right And Not IsNothing(lvItem) Then
                lvwLog.Items(lvItem.Index).Selected = True
                mnuCopyLog.Enabled = True
                cmLog.Show(CType(sender, ListView), New Point(e.X, e.Y))
            ElseIf e.Button = MouseButtons.Right And IsNothing(lvItem) Then
                mnuCopyLog.Enabled = False
                cmLog.Show(CType(sender, ListView), New Point(e.X, e.Y))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuCopyLog_Click(sender As Object, e As EventArgs) Handles mnuCopyLog.Click
        If lvwLog.SelectedItems.Count > 0 Then
            Dim clipboardText As String = ""

            For l As Short = 0 To lvwLog.SelectedItems.Count - 1
                Dim i As Short = lvwDevices.SelectedItems(0).Index
                Dim item As ListViewItem = lvwLog.SelectedItems(l)
                If devlist(i).Type = DeviceType.SCSI Then
                    clipboardText += devlist(i).Scsi.Info.Product & "," & devlist(i).Scsi.Info.SerialNumber & "," & item.Group.Header & "," & item.Text & "," & item.SubItems(1).Text &
                                      "," & item.SubItems(2).Text & "," & item.SubItems(3).Text & vbCrLf
                Else
                    clipboardText += devlist(i).ATA.Info.Model & "," & devlist(i).ATA.Info.SerialNumber & "," & item.Group.Header & "," & item.Text & "," & item.SubItems(1).Text &
                                      "," & item.SubItems(2).Text & "," & item.SubItems(3).Text & vbCrLf
                End If
            Next
            Clipboard.SetText(clipboardText)
        End If
    End Sub

    Private Sub mnuCopyAllLog_Click(sender As Object, e As EventArgs) Handles mnuCopyAllLog.Click
        If lvwLog.SelectedItems.Count > 0 Then
            Dim clipboardText As String = ""

            For l As Short = 0 To lvwLog.Items.Count - 1
                Dim i As Short = lvwDevices.SelectedItems(0).Index
                Dim item As ListViewItem = lvwLog.Items(l)
                If devlist(i).Type = DeviceType.SCSI Then
                    clipboardText += devlist(i).Scsi.Info.Product & "," & devlist(i).Scsi.Info.SerialNumber & "," & item.Group.Header & "," & item.Text & "," & item.SubItems(1).Text &
                                      "," & item.SubItems(2).Text & "," & item.SubItems(3).Text & vbCrLf
                Else
                    clipboardText += devlist(i).ATA.Info.Model & "," & devlist(i).ATA.Info.SerialNumber & "," & item.Group.Header & "," & item.Text & "," & item.SubItems(1).Text &
                                      "," & item.SubItems(2).Text & "," & item.SubItems(3).Text & vbCrLf
                End If
            Next
            Clipboard.SetText(clipboardText)
        End If
    End Sub

    Private Sub chkChartValues_CheckedChanged(sender As Object, e As EventArgs) Handles chkChartValues.CheckedChanged
        If Not isloading_settings Then
            If optSelection.Checked Then
                SetGraph(mcLog.SelectionRange.Start, mcLog.SelectionRange.End)
            Else
                SetFullGraph()
            End If

            AppSettings.General.DisplayValues = chkChartValues.Checked
            AppSettings.Save()
        End If
    End Sub

    Private Sub numPointSize_ValueChanged(sender As Object, e As EventArgs) Handles numPointSize.ValueChanged
        If Not isloading_settings Then
            If optSelection.Checked Then
                SetGraph(mcLog.SelectionRange.Start, mcLog.SelectionRange.End)
            Else
                SetFullGraph()
            End If

            AppSettings.General.PointsSize = numPointSize.Value
            AppSettings.Save()
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
        savedialog.FileName = dev.FileName
        res = savedialog.ShowDialog(Me)
        If res = DialogResult.OK Then
            File.WriteAllText(savedialog.FileName, txtReport.Text)
        End If
    End Sub

#End Region

#End Region

#End Region

#Region "System"
    Private Sub mrbRefresh_Click(sender As Object, e As EventArgs) Handles mrbRefresh.Click
        UpdateHardware()
    End Sub

    Private Sub tvwComputer_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwComputer.AfterSelect
        ShowDetails()
    End Sub

    Private Sub picWmiDevicesHelp_Click(sender As Object, e As EventArgs) Handles picWmiDevicesHelp.Click
        Try
            System.Diagnostics.Process.Start(picWmiDevicesHelp.Tag)
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub

    Private Sub picWmi_MouseUp(sender As Object, e As MouseEventArgs) Handles picWmi.MouseUp
        Dim path() As String = tvwComputer.SelectedNode.FullPath.Split("\")
        If path.Length = 1 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Select Case AppSettings.General.ComputerType
                    Case 0
                        mnuProfessional.Checked = True
                        mnuGamer.Checked = False
                        mnuLaptop.Checked = False
                    Case 1
                        mnuProfessional.Checked = False
                        mnuGamer.Checked = True
                        mnuLaptop.Checked = False
                    Case 2
                        mnuProfessional.Checked = False
                        mnuGamer.Checked = False
                        mnuLaptop.Checked = True
                End Select
                cmDeviceImage.Show(sender, e.Location)
            End If
        End If
    End Sub

    Private Sub mnuProfessional_Click(sender As Object, e As EventArgs) Handles mnuProfessional.Click
        picWmi.Image = My.Resources.pc_office
        AppSettings.General.ComputerType = "0"
        AppSettings.Save()
    End Sub

    Private Sub mnuGamer_Click(sender As Object, e As EventArgs) Handles mnuGamer.Click
        picWmi.Image = My.Resources.pc_game
        AppSettings.General.ComputerType = "1"
        AppSettings.Save()
    End Sub

    Private Sub mnuLaptop_Click(sender As Object, e As EventArgs) Handles mnuLaptop.Click
        picWmi.Image = My.Resources.pc_laptop
        AppSettings.General.ComputerType = "2"
        AppSettings.Save()
    End Sub

    Private Sub rspSystem_MouseMove(sender As Object, e As MouseEventArgs) Handles rspSystem.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            With tlpSystem
                If rspSystem.Left + e.X < 150 Then Exit Sub
                AppSettings.General.SystemTreeWidth = rspSystem.Left + e.X
                .ColumnStyles(2).SizeType = SizeType.Percent
                .ColumnStyles(0).SizeType = SizeType.Absolute
                .ColumnStyles(0).Width = rspSystem.Left + e.X
            End With
        End If
    End Sub

    Private Sub picSeparatorSystem_MouseUp(sender As Object, e As MouseEventArgs)
        'in this manner is avoid to save many times application settings when moving the separator
        AppSettings.Save()
    End Sub
#End Region

#Region "Debug"
    Private Sub mrbSaveDebug_Click(sender As Object, e As EventArgs) Handles mrbDebugSave.Click
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

    Private Sub mrbClean_Click(sender As Object, e As EventArgs) Handles mrbDebugClean.Click
        lvwProgLog.Items.Clear()
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

    Public aes_key, aes_iv As String

    Private Sub LoadPrivate()
        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmldoc.LoadXml(My.Resources.privatedata)

        m_nodelist = m_xmldoc.SelectNodes("/private")

        For Each m_node In m_nodelist
            aes_key = m_node.ChildNodes.Item(0).InnerText
            aes_iv = m_node.ChildNodes.Item(1).InnerText
        Next
    End Sub

#End Region

#Region "Task planner"
    Private Sub lvwTasks_MouseUp(sender As Object, e As MouseEventArgs) Handles lvwTasks.MouseUp
        Try
            Dim lvItem As ListViewItem

            lvItem = lvwTasks.GetItemAt(e.X, e.Y)

            If IsNothing(lvItem) Then
                mnuTaskEdit.Enabled = False
                mnuTaskDelete.Enabled = False
            Else
                lvwTasks.Items(lvItem.Index).Selected = True
                mnuTaskEdit.Enabled = True
                mnuTaskDelete.Enabled = True
            End If
            mnuTaskTrash.Enabled = Not IsNothing(lvwTasks.Items)
            mrbTaskEdit.Enabled = mnuTaskEdit.Enabled
            mrbTaskDelete.Enabled = mnuTaskDelete.Enabled
            mrbTaskTrash.Enabled = mnuTaskTrash.Enabled

            If e.Button = MouseButtons.Right Then
                cmTask.Show(CType(sender, ListView), New Point(e.X, e.Y))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mrbTaskDelete_Click(sender As Object, e As EventArgs) Handles mrbTaskDelete.Click, mnuTaskDelete.Click
        Dim confirm As MsgBoxResult
        confirm = MsgBox(GetString(6063), MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, GetString(6065))
        If confirm = MsgBoxResult.Ok Then
            ts.RootFolder.DeleteTask(lvwTasks.SelectedItems(0).Tag)
            If lvwTasks.Items.Count > 0 Then
                lvwTasks.Items(0).Selected = True
                mrbTaskEdit.Enabled = True
                mrbTaskDelete.Enabled = True
                mrbTaskTrash.Enabled = True
                mnuTaskEdit.Enabled = True
                mnuTaskDelete.Enabled = True
                mnuTaskTrash.Enabled = True
            Else
                mrbTaskEdit.Enabled = False
                mrbTaskDelete.Enabled = False
                mrbTaskTrash.Enabled = False
                mnuTaskEdit.Enabled = False
                mnuTaskDelete.Enabled = False
                mnuTaskTrash.Enabled = False
            End If
            TaskList()
        End If
    End Sub

    Private Sub mrbTaskTrash_Click(sender As Object, e As EventArgs) Handles mrbTaskTrash.Click, mnuTaskTrash.Click
        Dim confirm As MsgBoxResult
        confirm = MsgBox(GetString(6064), MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, GetString(6065))
        If confirm = MsgBoxResult.Ok Then
            DeleteAllTasks()
            TaskList()
        End If
    End Sub

    Private Sub mrbTaskNew_Click(sender As Object, e As EventArgs) Handles mrbTaskNew.Click, mnuTaskNew.Click
        TaskEditor.EditMode = False
        TaskEditor.Text = GetString(6061)
        TaskEditor.ShowDialog()
    End Sub

    Private Sub picPlannerHelp_Click(sender As Object, e As EventArgs) Handles picPlannerHelp.Click
        Try
            System.Diagnostics.Process.Start(picPlannerHelp.Tag)
        Catch ex As Exception
            PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub

    Private Sub mrbTaskEdit_Click(sender As Object, e As EventArgs) Handles mrbTaskEdit.Click, mnuTaskEdit.Click
        TaskEditor.EditMode = True
        TaskEditor.Text = GetString(6062)
        TaskEditor.ShowDialog()
    End Sub
#End Region

End Class
