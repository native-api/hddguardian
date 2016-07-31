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

Public Class SettingsForm

    Dim m_sharingfolder As String

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Main.SetWindowTheme(lvwControllers.Handle, "explorer", Nothing)
    End Sub

#Region "Color scheme"
    Private Sub ColorScheme()
        'setting window colors
        Dim cs As New ColorScheme
        pnlMenu.BackColor = cs.BackColor
        lblSmartctl.ForeColor = cs.GroupText
        Me.BackColor = cs.BackColor
        'General
        tpGeneral.BackColor = cs.BackColor
        lblGeneralTitle.ForeColor = cs.GroupText
        lblStartup.ForeColor = cs.GroupText
        lblBehaviour.ForeColor = cs.GroupText
        lblUpdates.ForeColor = cs.GroupText
        lblFahrenheit.ForeColor = cs.GroupText
        lblDebug.ForeColor = cs.GroupText
        For Each c In tlpStartup.Controls
            c.ForeColor = cs.ForeColor
        Next
        For Each c In tlpBehaviour.Controls
            c.ForeColor = cs.ForeColor
        Next
        For Each c In tlpUpdates.Controls
            c.ForeColor = cs.ForeColor
        Next
        chkFahrenheit.ForeColor = cs.ForeColor
        chkDebug.ForeColor = cs.ForeColor
        'Device detection
        tpDetection.BackColor = cs.BackColor
        lblDetectionTitle.ForeColor = cs.GroupText
        chkCsmi.ForeColor = cs.ForeColor
        chk3ware.ForeColor = cs.ForeColor
        lblNeedRestart.ForeColor = cs.GrayedText
        lblAdditional.ForeColor = cs.GroupText
        lblAdditionalInfo.ForeColor = cs.GrayedText
        lnkAdditional.ForeColor = cs.LinkColor
        'Translations
        tpTranslation.BackColor = cs.BackColor
        lblTranslationTitle.ForeColor = cs.GroupText
        lblLanguageInfo.ForeColor = cs.GroupText
        optAutomatic.ForeColor = cs.ForeColor
        optCustom.ForeColor = cs.ForeColor
        For Each c In tlpLanguageInfo.Controls
            c.ForeColor = cs.ForeColor
        Next
        'Mail alerts
        tpMailAlerts.BackColor = cs.BackColor
        lblMailAlertsTitle.ForeColor = cs.GroupText
        For Each c In tlpCustomServer.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.ForeColor
            ElseIf c.GetType.Name = "CheckBox" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        For Each c In tlpAdditionalMessage.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        rbNoReport.ForeColor = cs.ForeColor
        rbDaily.ForeColor = cs.ForeColor
        rbWeekly.ForeColor = cs.ForeColor
        'Data update
        tpUpdate.BackColor = cs.BackColor
        lblUpdateTitle.ForeColor = cs.GroupText
        lblUpdate.ForeColor = cs.ForeColor
        For Each c In tlpUpdate.Controls
            c.ForeColor = cs.ForeColor
            c.BackColor = cs.BackColor
        Next
        'Monitoring
        tpMonitoring.BackColor = BackColor
        lblMonitoringTitle.ForeColor = cs.GroupText
        For Each c In tlpActions.Controls
            c.ForeColor = cs.ForeColor
        Next
        lblGeneric.ForeColor = cs.GroupText
        lblHdd.ForeColor = cs.GroupText
        lblSsd.ForeColor = cs.GroupText
        'Warnings
        tpWarnings.BackColor = cs.BackColor
        lblWarningsTitle.ForeColor = cs.GroupText
        For Each c In tlpWarningsContent.Controls
            If c.GetType.Name = "CheckBox" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        'Sharing
        tpShare.BackColor = cs.BackColor
        lblShareTitle.ForeColor = cs.GroupText
        lblSharing.ForeColor = cs.GroupText
        lblSelFolder.ForeColor = cs.ForeColor
        lblFolder.ForeColor = cs.GrayedText
        lblXmlCreate.ForeColor = cs.GroupText
        chkXml.ForeColor = cs.ForeColor
        lblXml.ForeColor = cs.ForeColor
        lblXmlPath.ForeColor = cs.GrayedText
        'Rating
        tpRating.BackColor = cs.BackColor
        lblRatingTitle.ForeColor = cs.GroupText
        chkRating.ForeColor = cs.ForeColor
        chkTuneUp.ForeColor = cs.ForeColor
        For Each c In tlpTuneUp.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.ForeColor
            ElseIf c.GetType.Name = "NumericUpDown" Then
                c.ForeColor = cs.ForeColor
                c.BackColor = cs.BackColor
            End If
        Next
        'Tolerance
        tpTolerance.BackColor = cs.BackColor
        lblToleranceTitle.ForeColor = cs.GroupText
        lblInfoTolerance.ForeColor = cs.GrayedText
        For Each c In flwTolerance.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.GrayedText
            ElseIf c.GetType.Name = "RadioButton" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        'RAID controllers
        lblControllers.ForeColor = cs.GroupText
        lblNeedRestartControllers.ForeColor = cs.GrayedText
        lvwControllers.BackColor = cs.BackColor
        lvwControllers.ForeColor = cs.ForeColor
        For Each c In tlpAreca.Controls
            c.ForeColor = cs.ForeColor
            c.BackColor = cs.BackColor
        Next
        lblArecaSata.ForeColor = cs.GroupText
        lblArecaScsi.ForeColor = cs.GroupText
        'Smartctl
        tpSmartctl.BackColor = cs.BackColor
        lblSmartctlVersion.ForeColor = cs.GroupText
        chkSmartctl.ForeColor = cs.ForeColor
        lblSmartctlFolder.ForeColor = cs.ForeColor
        lblSmartctlPath.ForeColor = cs.GrayedText
    End Sub
#End Region

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        ColorScheme()
        LoadAdditionalDevices()

        With lvwControllers
            .Items.Clear()
            If Not IsNothing(Main.raidcontrollers) Then
                For i As Short = 0 To Main.raidcontrollers.Count - 1
                    Dim c As ControllerData = Main.raidcontrollers(i)
                    .Items.Add(c.Name)
                    .Items(.Items.Count - 1).SubItems.Add(c.Bridge)
                    If c.AllowScsi Then
                        .Items(.Items.Count - 1).SubItems.Add(Main.m_yes)
                        .Items(.Items.Count - 1).SubItems.Add(Main.m_yes)
                    Else
                        .Items(.Items.Count - 1).SubItems.Add(Main.m_yes)
                        .Items(.Items.Count - 1).SubItems.Add(Main.m_no)
                    End If
                    .Items(.Items.Count - 1).SubItems.Add(c.Tester)
                    c = Nothing
                Next
            End If
        End With
        btnControllerEdit.Enabled = False
        btnControllerRemove.Enabled = False
    End Sub

    Private Sub Settings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Main.SetWindowTheme(lvwControllers.Handle, "explorer", Nothing)

        InvokeOnClick(mrrGeneral, Nothing)

        isloading_settings = True

        If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            chkTolerance.Enabled = False
            flwTolerance.Enabled = False
            chkCsmi.Enabled = False
            tlpEditController.Enabled = False
            tlpDevicesList.Enabled = False
        End If

        If Not AppSettings.Smartctl.SetTolerance Then rbNormal.Checked = True

        isloading_settings = False
    End Sub

#Region "Side menu"
    Private Sub mrrGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles mrrGeneral.CheckedChanged
        If sender.checked Then htcSettings.SelectPage(tpGeneral)
    End Sub

    Private Sub mrrDetection_CheckedChanged(sender As Object, e As EventArgs) Handles mrrDetection.CheckedChanged
        If sender.checked Then htcSettings.SelectPage(tpDetection)
    End Sub

    Private Sub mrrTranslation_CheckedChanged(sender As Object, e As EventArgs) Handles mrrTranslation.CheckedChanged
        If sender.checked Then htcSettings.SelectPage(tpTranslation)
    End Sub

    Private Sub mrrMail_CheckedChanged(sender As Object, e As EventArgs) Handles mrrMail.CheckedChanged
        If sender.checked Then htcSettings.SelectPage(tpMailAlerts)
    End Sub

    Private Sub mrrUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles mrrUpdate.CheckedChanged
        If sender.checked Then htcSettings.SelectPage(tpUpdate)
    End Sub

    Private Sub mrrMonitoring_CheckedChanged(sender As Object, e As EventArgs) Handles mrrMonitoring.CheckedChanged
        If sender.checked Then htcSettings.SelectPage(tpMonitoring)
    End Sub

    Private Sub mrrWarnings_CheckedChanged(sender As Object, e As EventArgs) Handles mrrWarnings.CheckedChanged
        If sender.checked Then htcSettings.SelectPage(tpWarnings)
    End Sub

    Private Sub mrrShare_CheckedChanged(sender As Object, e As EventArgs) Handles mrrShare.CheckedChanged
        If sender.checked Then htcSettings.SelectPage(tpShare)
    End Sub

    Private Sub mrrRating_CheckedChanged(sender As Object, e As EventArgs) Handles mrrRating.CheckedChanged
        If sender.checked Then htcSettings.SelectPage(tpRating)
    End Sub

    Private Sub mrrTolerance_CheckedChanged(sender As Object, e As EventArgs) Handles mrrTolerance.Click
        If sender.checked Then htcSettings.SelectPage(tpTolerance)
    End Sub

    Private Sub mrrControllers_CheckedChanged(sender As Object, e As EventArgs) Handles mrrControllers.Click
        If sender.checked Then htcSettings.SelectPage(tpRaidControllers)
    End Sub

    Private Sub mrrSmartctl_CheckedChanged(sender As Object, e As EventArgs) Handles mrrSmartctl.CheckedChanged
        If sender.checked Then htcSettings.SelectPage(tpSmartctl)
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        AppSettings.Import()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        AppSettings.Export()
    End Sub
#End Region

#Region "Load/save settings"

    Public Sub LoadSettings()
        isloading_settings = True

        With AppSettings

            '************************
            '*** general settings ***
            '************************
            With .General
                If .RunWithWindows Then
                    chkStartupLink.Checked = True
                    If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                        CreateTask()
                        'chkStartupLink.Checked = TaskExist()
                    Else
                        CreateShortcut()
                        'chkStartupLink.Checked = ShortcutExists()
                    End If
                Else
                    chkStartupLink.Checked = False
                End If

                chkRunMinimized.Checked = .RunMinimized
                chkMinimizeInTray.Checked = .HideToTray
                chkCloseOnTray.Checked = .CloseToTray
                chkAlwaysShowTray.Checked = .AlwaysDisplayTrayIcon
                chkConfirmExit.Checked = .ConfirmOnExit
                chkUpdates.Checked = .CheckForUpdates
                chkLanguageUpdates.Checked = .CheckLanguageUpdates
                chkFahrenheit.Checked = .TemperatureInFahrenheit
                chkDebug.Checked = .DisplayDebug
                Main.extDebug.Visible = .DisplayDebug
                chkInfoPanel.Checked = .DisplayInfoPanel
                chkRememberSize.Checked = .RememberWindowSize
                Main.tlpManage.ColumnStyles(0).Width = .ManageSideMenuWidth
                Main.tlpSystem.ColumnStyles(0).Width = .SystemTreeWidth
                Main.chkChartValues.Checked = .DisplayValues
                Main.numPointSize.Value = .PointsSize
            End With

            '*************************
            '*** devices detection ***
            '*************************
            With .Detection
                chkCsmi.Checked = .Csmi
                chk3ware.Checked = .Add3ware
                txtAdditional.Text = .Additional
            End With

            '**********************
            '*** update setting ***
            '**********************
            With .Refresh
                'internal
                numUpdate.Value = .Internal
                Main.tmrRefresh.Interval = .Internal * 60 * 1000
                Main.tmrRefresh.Enabled = True
                'external
                numUpdateExt.Value = .External
                Main.tmrRefreshExt.Interval = .External * 60 * 1000
                If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                    Main.tmrRefreshExt.Enabled = True
                    numUpdateExt.Enabled = True
                Else
                    Main.tmrRefreshExt.Enabled = False
                    numUpdateExt.Enabled = False
                End If
                'virtual
                numUpdateVirtual.Value = .Virtual
                Main.tmrRefreshVirtual.Interval = .Virtual * 60 * 1000
                Main.tmrRefreshVirtual.Enabled = True
            End With

            '*********************
            '*** notifications ***
            '*********************
            With .Warnings
                cboPopUp.SelectedIndex = .Notify
                cboSendMail.SelectedIndex = .SendMail
                cboPlaySound.SelectedIndex = .PlaySound
                cboPowerOff.SelectedIndex = .PowerOff
                txtSound.Text = .SoundFile
                numTimeout.Value = .TimeOut
                chkForce.Checked = .ForceClose
            End With

            '************************************
            '*** attributes tracking settings ***
            '************************************
            With .VitalParameters
                'general
                cboTemp.SelectedIndex = .Temperature
                'HDD
                cboReallSectCt.SelectedIndex = .ReallocatedSectors
                cboSpinRetryCt.SelectedIndex = .SpinRetry
                cboReallEvCt.SelectedIndex = .ReallocationEvents
                cboCurPenSect.SelectedIndex = .PendingSectors
                cboOfflUnc.SelectedIndex = .OfflineUncorrectable
                cboSoftReadErr.SelectedIndex = .SoftReadErrors
                cboDiskShift.SelectedIndex = .DiskShift
                'SSD
                cboIndilinx.SelectedIndex = .Indilinx
                cboIntel.SelectedIndex = .Intel
                cboMicron.SelectedIndex = .Micron
                cboSamsung.SelectedIndex = .Samsung
                cboSandForce.SelectedIndex = .SandForce
            End With
            
            '*********************
            '*** share setting ***
            '*********************
            With .Sharing
                lblFolder.Text = ""
                lblFolder.Text = .OutputFolder
                If lblFolder.Text.Length = 0 Then lblFolder.Text = lblFolder.Tag
                m_sharingfolder = .OutputFolder

                chkXml.Checked = .XmlReport
                btnXml.Enabled = .XmlReport
                lblXmlPath.Text = ""
                lblXmlPath.Text = .XmlFolder
                If lblXmlPath.Text.Length = 0 Then lblXmlPath.Text = lblXmlPath.Tag
            End With

            '***********************
            '*** rating settings ***
            '***********************
            With .Reliability
                chkTuneUp.Checked = False
                tlpTuneUp.Enabled = False
                chkRating.Checked = False
                chkRating.Checked = .Enable
                chkTuneUp.Checked = .CustomThreshold
                numReall.Value = .ReallocationEvents
                numCurPend.Value = .PendingSectors
                numOfflUnc.Value = .UncorrectableSectors
            End With

            '****************************
            '*** mail alerts settings ***
            '****************************
            With .Mail
                txtMailFrom.Text = .Sender
                txtMailTo.Text = .Destination
                txtMailUserId.Text = .Login
                Dim dec As New Aes
                If .Password.Length > 0 Then txtMailPassword.Text = dec.Decrypt(.Password, Main.aes_key, Main.aes_iv)
                txtSmtp.Text = .SmtpServer
                txtPort.Text = .SmtpPort
                chkSsl.Checked = .UseSsl
                Select Case .Report
                    Case CustomSettings.SettingsMail.MailReport.Daily
                        rbDaily.Checked = True
                        mtbDaily.Enabled = True
                        mtbDaily.Text = .ReportDay
                    Case CustomSettings.SettingsMail.MailReport.None
                        rbNoReport.Checked = True
                    Case CustomSettings.SettingsMail.MailReport.Weekly
                        rbWeekly.Checked = True
                        cboDays.Enabled = True
                End Select

                If .Report = CustomSettings.SettingsMail.MailReport.Daily Or .Report = CustomSettings.SettingsMail.MailReport.Weekly Then _
                    nlSendReport.Enabled = True Else nlSendReport.Enabled = False

                txtMailSubject.Text = .Subject
                txtMailContent.Text = .Body

                tlpLessSecure.Visible = False
                Select Case .SmtpServer
                    Case "smtp.gmail.com"
                        cboProviders.SelectedIndex = 1
                        tlpLessSecure.Visible = True
                    Case "smtp-mail.outlook.com"
                        cboProviders.SelectedIndex = 2
                    Case "smtp.mail.yahoo.com"
                        cboProviders.SelectedIndex = 3
                    Case Else
                        cboProviders.SelectedIndex = 0
                End Select
            End With


            '*************************
            '*** language settings ***
            '*************************
            With .Language
                optAutomatic.Checked = .AutomaticTranslation
                If Not .AutomaticTranslation Then
                    optCustom.Checked = True
                    cboLanguage.Enabled = True
                    'language is selected from LoadLanguage routine
                End If
            End With

            '**************************
            '*** smartctl tolerance ***
            '**************************
            With .Smartctl
                chkTolerance.Checked = .SetTolerance
                flwTolerance.Enabled = .SetTolerance
                If .SetTolerance Then
                    Select Case .Tolerance
                        Case "-T normal "
                            rbNormal.Checked = True
                        Case "-T conservative "
                            rbConservative.Checked = True
                        Case "-T verypermissive "
                            rbVeryPermissive.Checked = True
                    End Select
                End If
            End With

            '************************************
            '*** smartctl alternative version ***
            '************************************
            With .Smartctl
                chkSmartctl.Checked = .AlternativeVersion
                flwSmartctl.Enabled = .AlternativeVersion
                lblSmartctlPath.Text = ""
                If IO.Directory.Exists(.ExecutableFolder) Then
                    lblSmartctlPath.Text = .ExecutableFolder
                Else
                    lblSmartctlPath.Text = ""
                End If
            End With

            '********************************
            '**** areca device detection ****
            '********************************
            With .Areca
                numArecaSata.Value = .SataDevices
                numArecaEnclosure1.Value = .SasEnclosure1
                numArecaEnclosure2.Value = .SasEnclosure2
                numArecaEnclosure3.Value = .SasEnclosure3
                numArecaEnclosure4.Value = .SasEnclosure4
                numArecaEnclosure5.Value = .SasEnclosure5
                numArecaEnclosure6.Value = .SasEnclosure6
                numArecaEnclosure7.Value = .SasEnclosure7
                numArecaEnclosure8.Value = .SasEnclosure8
            End With
        End With

        isloading_settings = False
    End Sub

    Public Sub SaveSettings(ByVal who As String)
        Debug.Print(">>>> sender: " & who)
        With AppSettings
            '***************
            '*** general ***
            '***************
            With .General
                If TaskExist() Or ShortcutExists() Then .RunWithWindows = True

                'startup link setting is not saved
                .RunMinimized = chkRunMinimized.Checked
                'behaviour
                .HideToTray = chkMinimizeInTray.Checked
                .CloseToTray = chkCloseOnTray.Checked
                .AlwaysDisplayTrayIcon = chkAlwaysShowTray.Checked
                .ConfirmOnExit = chkConfirmExit.Checked
                .RememberWindowSize = chkRememberSize.Checked
                .WindowSize = Main.Size
                If Main.WindowState = FormWindowState.Maximized Then .IsMaximized = True Else .IsMaximized = False
                .DisplayInfoPanel = chkInfoPanel.Checked
                'updates
                .CheckForUpdates = chkUpdates.Checked
                .CheckLanguageUpdates = chkLanguageUpdates.Checked
                'temperatures
                .TemperatureInFahrenheit = chkFahrenheit.Checked
                'debug
                .DisplayDebug = chkDebug.Checked
            End With

            '*************************
            '*** devices detection ***
            '*************************
            With .Detection
                .Csmi = chkCsmi.Checked
                .Add3ware = chk3ware.Checked
                .Additional = txtAdditional.Text
            End With

            '*****************
            '*** languages ***
            '*****************
            With .Language
                .AutomaticTranslation = optAutomatic.Checked
                If optCustom.Checked Then .PreferredLanguage = Main.translations(cboLanguage.SelectedIndex).CultureCode
            End With

            '*******************
            '*** mail alerts ***
            '*******************
            With .Mail
                .Sender = txtMailFrom.Text
                .Destination = txtMailTo.Text
                'mailserver
                .Login = txtMailUserId.Text
                Dim en As New Aes
                If txtMailPassword.Text.Length > 0 Then .Password = en.Encrypt(txtMailPassword.Text, Main.aes_key, Main.aes_iv) Else .Password = ""
                .SmtpServer = txtSmtp.Text
                .SmtpPort = txtPort.Text
                .UseSsl = chkSsl.Checked
                If rbNoReport.Checked Then .Report = CustomSettings.SettingsMail.MailReport.None
                If rbWeekly.Checked Then .Report = CustomSettings.SettingsMail.MailReport.Weekly
                If rbDaily.Checked Then .Report = CustomSettings.SettingsMail.MailReport.Daily
                .ReportDay = cboDays.SelectedIndex
                .ReportTime = mtbDaily.Text
                .Subject = txtMailSubject.Text
                .Body = txtMailContent.Text
            End With

            '*******************
            '*** data update ***
            '*******************
            With .Refresh
                .Internal = numUpdate.Value
                .External = numUpdateExt.Value
                .Virtual = numUpdateVirtual.Value
            End With

            '***************************
            '*** attributes tracking ***
            '***************************
            With .VitalParameters
                'general
                .Temperature = cboTemp.SelectedIndex
                'HDD
                .ReallocatedSectors = cboReallSectCt.SelectedIndex
                .SpinRetry = cboSpinRetryCt.SelectedIndex
                .ReallocationEvents = cboReallEvCt.SelectedIndex
                .PendingSectors = cboCurPenSect.SelectedIndex
                .OfflineUncorrectable = cboOfflUnc.SelectedIndex
                .SoftReadErrors = cboSoftReadErr.SelectedIndex
                .DiskShift = cboDiskShift.SelectedIndex
                'SSD
                .Indilinx = cboIndilinx.SelectedIndex
                .Intel = cboIntel.SelectedIndex
                .Micron = cboMicron.SelectedIndex
                .Samsung = cboSamsung.SelectedIndex
                .SandForce = cboSandForce.SelectedIndex
            End With

            '*********************
            '*** notifications ***
            '*********************
            With .Warnings
                .PlaySound = cboPlaySound.SelectedIndex
                .PowerOff = cboPowerOff.SelectedIndex
                .SendMail = cboSendMail.SelectedIndex
                .Notify = cboPopUp.SelectedIndex
                .ForceClose = chkForce.Checked
                .SoundFile = txtSound.Text
                .TimeOut = numTimeout.Value
            End With

            '***************
            '*** sharing ***
            '***************
            With .Sharing
                If IO.Directory.Exists(lblFolder.Text) Then
                    .OutputFolder = lblFolder.Text
                Else
                    .OutputFolder = ""
                End If
                .XmlReport = chkXml.Checked
                If IO.Directory.Exists(lblXmlPath.Text) Then
                    .XmlFolder = lblXmlPath.Text
                Else
                    .XmlFolder = ""
                End If
            End With

            '**************
            '*** rating ***
            '**************
            With .Reliability
                .Enable = chkRating.Checked
                .CustomThreshold = chkTuneUp.Checked
                .ReallocationEvents = numReall.Value
                .PendingSectors = numCurPend.Value
                .UncorrectableSectors = numOfflUnc.Value
            End With

            '*****************
            '*** tolerance ***
            '*****************
            With .Smartctl
                .SetTolerance = chkTolerance.Checked
                If .SetTolerance Then
                    If rbNormal.Checked Then .Tolerance = "-T normal "
                    If rbConservative.Checked Then .Tolerance = "-T conservative "
                    If rbVeryPermissive.Checked Then .Tolerance = "-T verypermissive "
                End If
            End With

            '************************************
            '*** smartctl alternative version ***
            '************************************
            With .Smartctl
                .AlternativeVersion = chkSmartctl.Checked
                If IO.Directory.Exists(lblSmartctlPath.Text) Then
                    .ExecutableFolder = lblSmartctlPath.Text
                Else
                    .ExecutableFolder = ""
                End If

            End With

            '********************************
            '**** areca device detection ****
            '********************************
            With .Areca
                .SataDevices = numArecaSata.Value
                .SasEnclosure1 = numArecaEnclosure1.Value
                .SasEnclosure2 = numArecaEnclosure2.Value
                .SasEnclosure3 = numArecaEnclosure3.Value
                .SasEnclosure4 = numArecaEnclosure4.Value
                .SasEnclosure5 = numArecaEnclosure5.Value
                .SasEnclosure6 = numArecaEnclosure6.Value
                .SasEnclosure7 = numArecaEnclosure7.Value
                .SasEnclosure8 = numArecaEnclosure8.Value
            End With

            'save settings
            .Save()
        End With
    End Sub
#End Region

#Region "General"
    Private Sub chkStartupLink_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStartupLink.CheckedChanged
        If System.Environment.OSVersion.Version.Major >= 6 And My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            'Vista or higher and only with administrator account
            If chkStartupLink.Checked Then
                If Not TaskExist() Then CreateTask()
                'delete shortcut into Startup folder, if exist...
                If ShortcutExists() Then DeleteShortcut()
            Else
                DeleteTask()
            End If
        Else
            If chkStartupLink.Checked Then
                If Not ShortcutExists() Then CreateShortcut()
            Else
                DeleteShortcut()
            End If
        End If
    End Sub

    Private Sub look_n_feel(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        chkRunMinimized.CheckedChanged, chkMinimizeInTray.CheckedChanged, chkCloseOnTray.CheckedChanged, _
        chkAlwaysShowTray.CheckedChanged, chkConfirmExit.CheckedChanged, chkInfoPanel.CheckedChanged, chkRememberSize.CheckedChanged
        If Not isloading_settings Then SaveSettings("look 'n feel: " & sender.name)
        Main.niTrayIcon.Visible = chkAlwaysShowTray.Checked
    End Sub

    Private Sub chkUpdates_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUpdates.CheckedChanged
        If Not isloading_settings Then
            SaveSettings("chk updates")
            If chkUpdates.Checked Then Main.CheckForUpdates()
        End If
    End Sub

    Private Sub chkFahrenheit_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFahrenheit.CheckedChanged
        If Not isloading_settings Then
            SaveSettings("chk fahrenheit")

            With Main
                'update device list
                With .lvwDevices
                    For i As Short = 0 To .Items.Count - 1
                        If IsNumeric(Main.devlist(i).Temperature) Then
                            If AppSettings.General.TemperatureInFahrenheit = True Then
                                .Items(i).SubItems(1).Text = (Math.Round(Main.devlist(i).Temperature * 1.8 + 32) & "°F")
                            Else
                                .Items(i).SubItems(1).Text = (Main.devlist(i).Temperature & "°C")
                            End If
                        End If
                    Next
                End With
                'update bottom panel
                Dim d As Device = .devlist(.lvwDevices.SelectedItems(0).Index)
                If IsNumeric(d.Temperature) Then
                    'With .lblTempInfoValue
                    'If My.Settings.TempFahrenheit = True Then
                    '.Text = Math.Round(d.Temperature * 1.8 + 32) & "°F"
                    'Else
                    '.Text = d.Temperature & "°C"
                    'End If
                    'End With
                End If
                'update device info panel
                Dim dev As Device = .devlist(.cboDevices.SelectedIndex)
                With .lblTempValue
                    If IsNumeric(dev.Temperature) Then
                        Dim temp As String
                        If AppSettings.General.TemperatureInFahrenheit = False Then
                            temp = dev.Temperature & "°C"
                        Else
                            temp = Math.Round(dev.Temperature * 1.8 + 32) & "°F"
                        End If
                    End If
                End With
                'update temperatures panel
                .Temperatures()
            End With
        End If
    End Sub

    Private Sub chkDebug_CheckedChanged(sender As Object, e As EventArgs) Handles chkDebug.CheckedChanged
        If Not isloading_settings Then
            SaveSettings("chk debug")
            Main.extDebug.Visible = chkDebug.Checked

            If Not Main.extDebug.Visible Then Main.extOverview.Checked = True ' InvokeOnClick(Main.rmiOverview, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub chkLanguageUpdates_CheckedChanged(sender As Object, e As EventArgs) Handles chkLanguageUpdates.CheckedChanged
        If Not isloading_settings Then
            SaveSettings("chk language updates")
            If chkUpdates.Checked Then Main.LanguagesUpdate()
        End If
    End Sub
#End Region

#Region "Device detection"
    Private Sub chk3ware_CheckedChanged(sender As Object, e As EventArgs) Handles chk3ware.CheckedChanged
        If Not isloading_settings Then
            SaveSettings("3 ware")
            If chk3ware.Checked Then
                With Main
                    .devlist.Add(New Device("", DeviceType.ThreeWare, False, True))
                    .lvwDevices.Items.Add(New ListViewItem("3ware clipboard", .lvwDevices.Groups(2)))
                    With .lvwDevices
                        .Items(.Items.Count - 1).UseItemStyleForSubItems = False
                        .Items(.Items.Count - 1).SubItems.Add("[no data]")
                        .Items(.Items.Count - 1).SubItems(1).ForeColor = Color.DarkGray
                        .Items(.Items.Count - 1).SubItems.Add("[no data]")
                        .Items(.Items.Count - 1).SubItems(2).ForeColor = Color.DarkGray
                        .Items(.Items.Count - 1).SubItems.Add("N/A")
                        .Items(.Items.Count - 1).SubItems.Add("N/A")
                        .Items(.Items.Count - 1).ImageIndex = 1
                        .Groups(1).Header = .Groups(1).Tag & " - " & .Groups(1).Items.Count
                    End With
                    .FillManageDeviceList()
                End With
            Else
                With Main
                    For i As Short = 0 To .devlist.Count - 1
                        If .devlist(i).Type = DeviceType.ThreeWare Then
                            .devlist.RemoveAt(i)
                            With .lvwDevices
                                If .Items(i).Selected Then .Items(0).Selected = True
                                .Items(i).Remove()
                                .Groups(1).Header = .Groups(1).Tag & " - " & .Groups(1).Items.Count
                            End With
                            Exit For
                        End If
                    Next
                    .FillManageDeviceList()
                End With
            End If
        End If
    End Sub

    Private Sub txtAdditional_TextChanged(sender As Object, e As EventArgs) Handles txtAdditional.TextChanged
        If Not isloading_settings Then
            SaveSettings(sender.name)
        End If
    End Sub

    Private Sub lnkAdditional_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAdditional.LinkClicked
        If AppSettings.Detection.Additional.Length > 0 Then
            Dim toadd() As String = AppSettings.Detection.Additional.ToString.Split(",")
            For i As Short = 0 To toadd.Count - 1
                Dim addIt As Boolean = False
                Dim test As Device

                If toadd(i).Contains("[USB]") Then
                    test = New Device(toadd(i).Replace("[USB]", "").Trim, DeviceType.USB, False)
                ElseIf toadd(i).Contains("scsi") Then
                    test = New Device(toadd(i).Trim, DeviceType.SCSI, False)
                Else
                    test = New Device(toadd(i).Trim, DeviceType.ATA, False)
                End If

                For d As Short = 0 To Main.devlist.Count - 1
                    If Main.devlist(d).Type = test.Type Then
                        If test.Type = DeviceType.SCSI Then
                            If Main.devlist(d).Scsi.Info.Product = test.Scsi.Info.Product And Main.devlist(d).Scsi.Info.SerialNumber = test.Scsi.Info.SerialNumber Then
                                addIt = False
                                Exit For
                            End If
                        Else
                            If Main.devlist(d).ATA.Info.Model = test.ATA.Info.Model And Main.devlist(d).ATA.Info.SerialNumber = test.ATA.Info.SerialNumber Then
                                addIt = False
                                Exit For
                            End If
                        End If
                    End If
                Next

                If addit Then
                    If test.IsValid Then
                        Main.devlist.Add(test)

                        With Main.lvwDevices
                            Dim g As Integer = 0
                            If test.Type = DeviceType.ATA Then
                                g = 0
                            ElseIf test.Type = DeviceType.SCSI Then
                                g = 0
                            Else
                                g = 1
                            End If

                            Dim li As Short = 0

                            If test.Type = DeviceType.SCSI Then
                                .Items.Add(New ListViewItem(test.Scsi.Info.Product, .Groups(g)))
                                li = .Items.Count - 1
                                .Items(li).UseItemStyleForSubItems = False

                                Select Case test.Health
                                    Case Status.Unknown
                                        .Items(li).ImageIndex = 1
                                    Case Status.Failed
                                        .Items(li).ImageIndex = 2
                                    Case Status.Passed
                                        .Items(li).ImageIndex = 0
                                End Select
                            Else
                                .Items.Add(New ListViewItem(test.ATA.Info.Model, .Groups(g)))
                                li = .Items.Count - 1
                                .Items(li).UseItemStyleForSubItems = False

                                If test.ATA.Info.InDatabase Then
                                    Select Case test.ATA.Reliability.Overall
                                        Case 4 To 5
                                            .Items(li).ImageIndex = 0
                                        Case 2 To 3
                                            .Items(li).ImageIndex = 3
                                        Case 1
                                            .Items(li).ImageIndex = 2
                                        Case Else
                                            .Items(li).ImageIndex = 1
                                    End Select
                                    If test.Health = Status.Failed Then .Items(li).ImageIndex = 2
                                Else 'unknown SATA
                                    Select Case test.Health
                                        Case Status.Unknown
                                            .Items(li).ImageIndex = 1
                                        Case Status.Failed
                                            .Items(li).ImageIndex = 2
                                        Case Status.Passed
                                            .Items(li).ImageIndex = 0
                                    End Select
                                End If


                            End If

                            If IsNumeric(test.Temperature) Then
                                If AppSettings.General.TemperatureInFahrenheit = True Then
                                    .Items(li).SubItems.Add(Math.Round(test.Temperature * 1.8 + 32) & "°F")
                                Else
                                    .Items(li).SubItems.Add(test.Temperature & "°C")
                                End If
                                Select Case Val(test.Temperature)
                                    Case 0 To 49
                                        .Items(li).SubItems(1).ForeColor = temp_ok
                                    Case 50 To 54
                                        .Items(li).SubItems(1).ForeColor = temp_high
                                    Case Is >= 55
                                        .Items(li).SubItems(1).ForeColor = temp_alarm
                                End Select
                            Else
                                .Items(li).SubItems.Add(test.Temperature)
                                .Items(li).SubItems(1).ForeColor = Color.DarkGray
                            End If

                            If test.Type = DeviceType.SCSI Then
                                .Items(li).SubItems.Add("-")
                                .Items(li).SubItems(2).ForeColor = Color.DarkGray
                                .Items(li).SubItems.Add(test.Interface)
                                If IsNumeric(test.Scsi.Info.UserCapacity) Then
                                    Dim iec As String = ""
                                    If Val(test.Scsi.Info.UserCapacity / 1024 ^ 3) > 1000 Then
                                        iec = Format(Val(test.Scsi.Info.UserCapacity / 1024 ^ 4), "#.#") & " TiB"
                                    Else
                                        iec = Format(Val(test.Scsi.Info.UserCapacity / 1024 ^ 3), "#,###") & " GiB"
                                    End If
                                    Dim si As String = ""
                                    If Val(test.Scsi.Info.UserCapacity / 1000 ^ 3) > 1000 Then
                                        si = Format(Val(test.Scsi.Info.UserCapacity / 1000 ^ 4), "#.#") & " TB"
                                    Else
                                        si = Format(Val(test.Scsi.Info.UserCapacity / 1000 ^ 3), "#,###") & " GB"
                                    End If
                                    .Items(li).SubItems.Add(iec & " / " & si)
                                Else
                                    .Items(li).SubItems.Add(test.Scsi.Info.UserCapacity)
                                End If
                            Else
                                If IsNumeric(test.ATA.Health.RemainingLife) Then
                                    .Items(li).SubItems.Add(Val(test.ATA.Health.RemainingLife) & "%")
                                    Select Case Val(test.ATA.Health.RemainingLife)
                                        Case 0
                                            .Items(li).SubItems(2).ForeColor = life_out
                                        Case 1 To 10
                                            .Items(li).SubItems(2).ForeColor = life_low
                                        Case Is > 10
                                            .Items(li).SubItems(2).ForeColor = life_ok
                                    End Select
                                Else
                                    .Items(li).SubItems.Add(test.ATA.Health.RemainingLife)
                                    .Items(li).SubItems(2).ForeColor = Color.DarkGray
                                End If

                                .Items(li).SubItems.Add(test.Interface)

                                If IsNumeric(test.ATA.Info.UserCapacity) Then
                                    Dim iec As String = ""
                                    If Val(test.ATA.Info.UserCapacity / 1024 ^ 3) > 1000 Then
                                        iec = Format(Val(test.ATA.Info.UserCapacity / 1024 ^ 4), "#.#") & " TiB"
                                    Else
                                        iec = Format(Val(test.ATA.Info.UserCapacity / 1024 ^ 3), "#,###") & " GiB"
                                    End If
                                    Dim si As String = ""
                                    If Val(test.ATA.Info.UserCapacity / 1000 ^ 3) > 1000 Then
                                        si = Format(Val(test.ATA.Info.UserCapacity / 1000 ^ 4), "#.#") & " TB"
                                    Else
                                        si = Format(Val(test.ATA.Info.UserCapacity / 1000 ^ 3), "#,###") & " GB"
                                    End If
                                    .Items(li).SubItems.Add(iec & " / " & si)
                                Else
                                    .Items(li).SubItems.Add(test.ATA.Info.UserCapacity)
                                End If
                            End If


                            Main.FillManageDeviceList()

                            .Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                            .Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                            .Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                            .Columns(3).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                            .Columns(3).Width = .Columns(3).Width + 10
                            .Columns(4).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)

                            .Groups(2).Header = .Groups(g).Tag & " - " & .Groups(g).Items.Count
                            Main.SetWindowTheme(.Handle, "explorer", Nothing)
                        End With
                    End If
                End If
            Next
        End If
    End Sub
#End Region

#Region "Update"
    Private Sub numUpdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numUpdate.ValueChanged
        If Not isloading_settings Then SaveSettings(sender.name)
        Main.tmrRefresh.Interval = numUpdate.Value * 60 * 1000
        Main.tmrRefresh.Enabled = True
    End Sub

    Private Sub numUpdateExt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numUpdateExt.ValueChanged
        If Not isloading_settings Then SaveSettings(sender.name)
        Main.tmrRefreshExt.Interval = numUpdateExt.Value * 60 * 1000
        Main.tmrRefreshExt.Enabled = True
    End Sub

    Private Sub numUpdateVirtual_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numUpdateVirtual.ValueChanged
        If Not isloading_settings Then SaveSettings(sender.name)
        Main.tmrRefreshVirtual.Interval = numUpdateVirtual.Value * 60 * 1000
        Main.tmrRefreshVirtual.Enabled = True
    End Sub
#End Region

#Region "Vital parameters"
    Private Sub vitals(sender As Object, e As EventArgs) Handles cboTemp.SelectedIndexChanged, cboCurPenSect.SelectedIndexChanged, _
        cboDiskShift.SelectedIndexChanged, cboIndilinx.SelectedIndexChanged, cboIntel.SelectedIndexChanged, cboMicron.SelectedIndexChanged, _
        cboOfflUnc.SelectedIndexChanged, cboReallEvCt.SelectedIndexChanged, cboReallSectCt.SelectedIndexChanged, cboSamsung.SelectedIndexChanged, _
        cboSandForce.SelectedIndexChanged, cboSoftReadErr.SelectedIndexChanged, cboSpinRetryCt.SelectedIndexChanged

        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub
#End Region

#Region "Notifications"
    Private Sub notifications_actions(sender As Object, e As EventArgs) Handles cboPopUp.SelectedIndexChanged, _
        cboPlaySound.SelectedIndexChanged, cboPowerOff.SelectedIndexChanged, cboSendMail.SelectedIndexChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub lnkMailSetup_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMailSetup.LinkClicked
        mrrMail.PerformClick()
    End Sub

    Private Sub txtSound_TextChanged(sender As Object, e As EventArgs) Handles txtSound.TextChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub numTimeout_ValueChanged(sender As Object, e As EventArgs) Handles numTimeout.ValueChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub lnkTimeout_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTimeout.LinkClicked
        numTimeout.Value = 30
    End Sub

    Private Sub chkForce_CheckedChanged(sender As Object, e As EventArgs) Handles chkForce.CheckedChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub lnkBrowse_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkBrowse.LinkClicked
        Dim dlg As New OpenFileDialog
        Dim res As DialogResult

        With dlg
            .AddExtension = True
            .CheckPathExists = True
            .DefaultExt = "wav"
            .Filter = "Waveform Audio File Format|*.wav"
            res = .ShowDialog()
        End With

        If res = DialogResult.OK Then txtSound.Text = dlg.FileName
    End Sub

    Private Sub lnkPlay_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPlay.LinkClicked
        If IO.File.Exists(AppSettings.Warnings.SoundFile) Then My.Computer.Audio.Play(AppSettings.Warnings.SoundFile)
    End Sub

#End Region

#Region "Sharing"
    Private Sub btnBrwsFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrwsFolder.Click
        With Main.dlgFolder
            .Description = lblSelFolder.Text
            Dim result As DialogResult = .ShowDialog(Me)
            If result = DialogResult.OK Then
                lblFolder.Text = .SelectedPath
                lblFolder.Visible = True
                Dim dev As Device = Main.devlist(Main.lvwDevices.SelectedItems(0).Index)

                SaveSettings(sender.name)
            End If
        End With
    End Sub

    Private Sub chkXml_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkXml.CheckedChanged
        btnXml.Enabled = chkXml.Checked
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub btnXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXml.Click
        With Main.dlgFolder
            .Description = lblXml.Text
            Dim result As DialogResult = .ShowDialog(Me)
            If result = DialogResult.OK Then
                lblXmlPath.Text = .SelectedPath
                lblXmlPath.Visible = True
                SaveSettings(sender.name)
            End If
        End With
    End Sub
#End Region

#Region "Reliability"
    Private Sub chkRating_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRating.CheckedChanged
        chkTuneUp.Enabled = chkRating.Checked
        If Not isloading_settings Then SaveSettings(sender.name)

        If chkRating.Checked Then
            'If Not isloading_settings Then Main.SetRating()
        Else
            'Main.picReliability.Image = Nothing
        End If
    End Sub

    Private Sub chkTuneUp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTuneUp.CheckedChanged
        tlpTuneUp.Enabled = chkTuneUp.Checked
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub TunersValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        numOfflUnc.ValueChanged, numCurPend.ValueChanged, numReall.ValueChanged

        'Main.SetRating()
        'Main.ReliabilityDetails()
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub Reset(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles _
        lnkResetReall.LinkClicked, lnkResetCurPending.LinkClicked, lnkResetOfflUnc.LinkClicked, lnkResetReall.LinkClicked

        Select Case sender.Name
            Case lnkResetReall.Name
                numReall.Value = numReall.Tag
            Case lnkResetCurPending.Name
                numCurPend.Value = numCurPend.Tag
            Case lnkResetOfflUnc.Name
                numOfflUnc.Value = numOfflUnc.Tag
        End Select
    End Sub

#End Region

#Region "Mail alerts"
    Private Sub txtMailFrom_TextChanged(sender As Object, e As EventArgs) Handles txtMailFrom.TextChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub txtMailTo_TextChanged(sender As Object, e As EventArgs) Handles txtMailTo.TextChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub lnkTestMail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTestMail.LinkClicked
        Main.SendMail("HDD Guardian test mail", Main.GetString(3708))
    End Sub

    Private Sub rbNoReport_CheckedChanged(sender As Object, e As EventArgs) Handles rbNoReport.CheckedChanged
        If Not isloading_settings Then SaveSettings(sender.name)
        If rbNoReport.Checked Then
            mtbDaily.Enabled = False
            cboDays.Enabled = False
        End If
    End Sub

    Private Sub rbDaily_CheckedChanged(sender As Object, e As EventArgs) Handles rbDaily.CheckedChanged
        If Not isloading_settings Then SaveSettings(sender.name)
        If rbDaily.Checked Then
            mtbDaily.Enabled = True
            cboDays.Enabled = False
        End If
    End Sub

    Private Sub rbWeekly_CheckedChanged(sender As Object, e As EventArgs) Handles rbWeekly.CheckedChanged
        If Not isloading_settings Then SaveSettings(sender.name)
        If rbWeekly.Checked Then
            mtbDaily.Enabled = False
            cboDays.Enabled = True
        End If
    End Sub

    Private Sub mtbDaily_TextChanged(sender As Object, e As EventArgs) Handles mtbDaily.TextChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub nlSendReport_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles nlSendReport.LinkClicked
        Main.RegularReport(True)
    End Sub

    Private Sub cboDays_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDays.SelectedIndexChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub txtMailSubject_TextChanged(sender As Object, e As EventArgs) Handles txtMailSubject.TextChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub txtMailContent_TextChanged(sender As Object, e As EventArgs) Handles txtMailContent.TextChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub txtMailPassword_TextChanged(sender As Object, e As EventArgs) Handles txtMailPassword.TextChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub cboProviders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProviders.SelectedIndexChanged
        If isloading_settings Then Exit Sub 'this allow to not change SMTP, port and encryption when loading settings

        tlpLessSecure.Visible = False
        isloading_settings = True 'this allow to avoid multiple settings save
        Select Case cboProviders.SelectedIndex
            Case 0 'custom
                txtSmtp.Text = ""
                txtPort.Text = ""
                chkSsl.Checked = False
            Case 1 'Google
                txtSmtp.Text = "smtp.gmail.com"
                txtPort.Text = "587"
                chkSsl.Checked = True
                tlpLessSecure.Visible = True
            Case 2 'Microsoft
                txtSmtp.Text = "smtp-mail.outlook.com"
                txtPort.Text = "587"
                chkSsl.Checked = True
            Case 3 'Yahoo
                txtSmtp.Text = "smtp.mail.yahoo.com "
                txtPort.Text = "587"
                chkSsl.Checked = True
        End Select
        isloading_settings = False
        SaveSettings(sender.name)
    End Sub

    Private Sub lnkLessSecure_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLessSecure.LinkClicked
        Try
            System.Diagnostics.Process.Start("https://www.google.com/settings/security/lesssecureapps")
        Catch ex As Exception
            Main.PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub
#End Region

#Region "Tolerance"
    Private Sub chkTolerance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTolerance.CheckedChanged
        flwTolerance.Enabled = chkTolerance.Checked
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub ChangeTolerance(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbConservative.CheckedChanged, rbNormal.CheckedChanged, rbVeryPermissive.CheckedChanged
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

#End Region

#Region "Translations"
    Private Sub optAutomatic_CheckedChanged(sender As Object, e As EventArgs) Handles optAutomatic.CheckedChanged
        If optAutomatic.Checked Then
            cboLanguage.Enabled = False
            If Not isloading_settings Then
                SaveSettings(sender.name)
                Main.ChangeLanguage()
            End If
        End If
    End Sub

    Private Sub optCustom_CheckedChanged(sender As Object, e As EventArgs) Handles optCustom.CheckedChanged
        If optCustom.Checked Then
            cboLanguage.Enabled = True
            If Not isloading_settings Then
                cboLanguage.SelectedIndex = 0
                SaveSettings(sender.name)
            End If
        End If
    End Sub

    Private Sub cboLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLanguage.SelectedIndexChanged
        If optAutomatic.Checked Then Exit Sub

        If cboLanguage.Enabled And Not isloading_settings Then
            SaveSettings(sender.name)

            'lblTranslatorValue.Text = Main.translations(cboLanguage.SelectedIndex).Translator
            'lblVersionValue.Text = Main.translations(cboLanguage.SelectedIndex).Version
            isloading_settings = True
            Main.ChangeLanguage()
            isloading_settings = False
        End If
    End Sub

#End Region

#Region "RAID controllers"
    Public editmode As Boolean = False

    Private Sub btnControllerAdd_Click(sender As Object, e As EventArgs) Handles btnControllerAdd.Click
        Dim before As Short = lvwControllers.Items.Count
        editmode = False

        EditController.Text = Main.GetString(4640)
        EditController.ShowDialog(Me)
        'btnControllerRemove.Enabled = False
        'btnControllerEdit.Enabled = False

        If lvwControllers.Items.Count > before Then SaveControllers()
    End Sub

    Private Sub lvwControllers_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvwControllers.ItemSelectionChanged
        btnControllerRemove.Enabled = e.IsSelected
        btnControllerEdit.Enabled = e.IsSelected
    End Sub

    Private Sub btnControllerEdit_Click(sender As Object, e As EventArgs) Handles btnControllerEdit.Click
        editmode = True

        EditController.Text = Main.GetString(4641)
        EditController.ShowDialog(Me)

        SaveControllers()
    End Sub

    Private Sub btnControllerRemove_Click(sender As Object, e As EventArgs) Handles btnControllerRemove.Click
        Dim confirm As MsgBoxResult

        With lvwControllers
            confirm = MsgBox(.SelectedItems(0).Text & vbCrLf & vbCrLf & Main.GetString(4650), MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, Main.GetString(5201))
            If confirm = MsgBoxResult.Ok Then
                .Items(.SelectedItems(0).Index).Remove()

                If .Items.Count > 0 Then
                    .Items(0).Selected = True
                Else
                    btnControllerRemove.Enabled = False
                    btnControllerEdit.Enabled = False
                End If
                SaveControllers()
            End If
        End With
    End Sub

    Private Sub SaveControllers()
        Try
            Dim output As XmlWriterSettings = New XmlWriterSettings()
            output.Indent = True

            Using write As XmlWriter = XmlWriter.Create(My.Application.Info.DirectoryPath & "\controllers.xml", output)
                write.WriteStartDocument()
                write.WriteStartElement("controllers")

                If lvwControllers.Items.Count > 0 Then
                    For i As Short = 0 To lvwControllers.Items.Count - 1
                        write.WriteStartElement("controller")
                        write.WriteAttributeString("name", lvwControllers.Items(i).Text)
                        write.WriteAttributeString("tester", lvwControllers.Items(i).SubItems(4).Text)
                        write.WriteAttributeString("bridge", lvwControllers.Items(i).SubItems(1).Text)
                        If lvwControllers.Items(i).SubItems(3).Text = Main.m_yes Then
                            write.WriteAttributeString("allowscsi", "1")
                        Else
                            write.WriteAttributeString("allowscsi", "0")
                        End If
                        write.WriteEndElement()
                    Next
                End If

                write.WriteEndElement()
                write.WriteEndDocument()
            End Using
        Catch ex As Exception
            Main.PrintDebug("Encountered an error while saving RAID controllers list: " & ex.ToString, True)
        End Try
    End Sub

    Private Sub LoadAdditionalDevices()
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\additional.xml") Then
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            m_xmldoc.Load(My.Application.Info.DirectoryPath & "\additional.xml")
            m_nodelist = m_xmldoc.SelectNodes("/devices/device")

            lvwControllers.Items.Clear()

            For Each m_node In m_nodelist
                With lvwControllers
                    .Items.Add(m_node.Attributes.GetNamedItem("description").Value)
                    .Items(.Items.Count - 1).SubItems.Add(m_node.Attributes.GetNamedItem("command").Value)
                End With
            Next
        End If
    End Sub

    Private Sub numAreca_ValueChanged(sender As Object, e As EventArgs) Handles numArecaSata.ValueChanged, numArecaEnclosure1.ValueChanged, _
        numArecaEnclosure2.ValueChanged, numArecaEnclosure3.ValueChanged, numArecaEnclosure4.ValueChanged, numArecaEnclosure5.ValueChanged, _
        numArecaEnclosure7.ValueChanged, numArecaEnclosure8.ValueChanged

        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

#End Region

#Region "Help icons"
    Private Sub Help_Click(sender As Object, e As EventArgs) Handles picHelpSetupGeneral.Click, picHelpSetupDetection.Click, _
        picHelpSetupMailAlerts.Click, picHelpSetupMonitoring.Click, _
        picHelpSetupRating.Click, picHelpSetupShare.Click, picHelpSetupTolerance.Click, _
        picHelpSetupTranslation.Click, picHelpSetupUpdate.Click, picHelpSetupWarnings.Click, picHelpSetupControllers.Click, _
        picHelpSetupSmartctl.Click

        Try
            System.Diagnostics.Process.Start(sender.Tag)
        Catch ex As Exception
            Main.PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub
#End Region

#Region "Alternative smartctl version"
    Private Sub chkSmartctl_CheckedChanged(sender As Object, e As EventArgs) Handles chkSmartctl.CheckedChanged
        flwSmartctl.Enabled = chkSmartctl.Checked
        If Not isloading_settings Then SaveSettings(sender.name)
    End Sub

    Private Sub btnBrwsSmartctl_Click(sender As Object, e As EventArgs) Handles btnBrwsSmartctl.Click
        With Main.dlgFolder
            .Description = lblSmartctlFolder.Text
            Dim result As DialogResult = .ShowDialog(Me)
            If result = DialogResult.OK Then

                'check if into the folder is present smartctl
                If IO.File.Exists(.SelectedPath & "\smartctl.exe") Then
                    'smartctl is present, now check his version and compare with the one bundled with HDD Guardian
                    Dim smartctl As New Console
                    Dim b_version As String = 0
                    Dim s_version As String = 0
                    Dim bundled() As String = smartctl.SendCmd("-V")
                    Dim selected() As String = smartctl.SendCmd("-V", .SelectedPath)

                    For i As Short = 0 To bundled.Count - 1
                        If bundled(i).Contains("smartmontools release") Then
                            Dim v() As String = bundled(i).Split(" ")
                            Dim v1() As String = v(2).Split(".")
                            b_version = v1(0) * 100 + v1(1)
                            v = Nothing
                            v1 = Nothing
                            bundled = Nothing
                            Exit For
                        End If
                    Next

                    For i As Short = 0 To selected.Count - 1
                        If selected(i).Contains("smartmontools release") Then
                            Dim v() As String = selected(i).Split(" ")
                            Dim v1() As String = v(2).Split(".")
                            s_version = v1(0) * 100 + v1(1)
                            v = Nothing
                            v1 = Nothing
                            selected = Nothing
                            Exit For
                        End If
                    Next

                    If s_version >= b_version Then
                        lblSmartctlPath.Text = .SelectedPath
                    Else
                        'selected version is older than the one shipped
                        MsgBox(Main.GetString(4411), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Main.GetString(4420))
                    End If
                Else
                    'smartctl is not present
                    MsgBox(Main.GetString(4421), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Main.GetString(4420))
                    lblSmartctlPath.Text = ""
                End If

                SaveSettings(sender.name)
            End If
        End With
    End Sub

#End Region

End Class