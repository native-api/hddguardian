'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2015 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Xml

Public Class Settings

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
        pnlMenu.BackColor = cs.RibbonToolbarBackColor
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
        chkMonitorUsb.ForeColor = cs.ForeColor
        chkCsmi.ForeColor = cs.ForeColor
        chk3ware.ForeColor = cs.ForeColor
        lblNeedRestart.ForeColor = cs.GrayedText
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
        chkMailAlerts.ForeColor = cs.ForeColor
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
        lblSendMailWhen.ForeColor = cs.ForeColor
        For Each c In tlpWhenSendMail.Controls
            If c.GetType.Name = "CheckBox" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        lblReport.ForeColor = cs.GroupText
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
        lblParamToMonitor.ForeColor = cs.ForeColor
        grpGeneric.ForeColor = cs.GroupText
        grpHdd.ForeColor = cs.GroupText
        grpSsd.ForeColor = cs.GroupText
        For Each c In tlpGeneric.Controls
            If c.GetType.Name = "CheckBox" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        For Each c In tlpHdd.Controls
            If c.GetType.Name = "CheckBox" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        For Each c In tlpSsd.Controls
            If c.GetType.Name = "CheckBox" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        'Warnings
        tpWarnings.BackColor = cs.BackColor
        tpWarningsMain.BackColor = cs.BackColor
        tpWarningsParametrs.BackColor = cs.BackColor
        lblWarningsTitle.ForeColor = cs.GroupText
        For Each c In flwWarnings.Controls
            If c.GetType.Name = "CheckBox" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        For Each c In tlpTempThreshold.Controls
            c.ForeColor = cs.ForeColor
            If c.GetType.Name = "NumericUpDown" Then
                c.BackColor = cs.BackColor
            End If
        Next
        lblWarningsPath.ForeColor = cs.GroupText
        grpGenericChange.ForeColor = cs.GroupText
        grpHddChange.ForeColor = cs.GroupText
        grpSsdChange.ForeColor = cs.GroupText
        For Each c In tlpGenericChange.Controls
            If c.GetType.Name = "CheckBox" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        For Each c In tlpHddChange.Controls
            If c.GetType.Name = "CheckBox" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        For Each c In tlpSsdChange.Controls
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

        InvokeOnClick(robGeneral, Nothing)

        isloading_settings = True

        If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            chkTolerance.Enabled = False
            flwTolerance.Enabled = False
            chkMonitorUsb.Enabled = False
            chkCsmi.Enabled = False
            tlpEditController.Enabled = False
            tlpDevicesList.Enabled = False
        End If

        If Not My.Settings.Tolerance Then rbNormal.Checked = True

        isloading_settings = False
    End Sub

#Region "Side menu"
    Private Sub robGeneral_Click(sender As Object, e As EventArgs) Handles robGeneral.Click
        htcSettings.SelectPage(tpGeneral)
    End Sub

    Private Sub robUsbDevices_Click(sender As Object, e As EventArgs) Handles robDetection.Click
        htcSettings.SelectPage(tpDetection)
    End Sub

    Private Sub robMessages_Click(sender As Object, e As EventArgs) Handles robTranslation.Click
        htcSettings.SelectPage(tpTranslation)
    End Sub

    Private Sub robMailAlerts_Click(sender As Object, e As EventArgs) Handles robMailAlerts.Click
        htcSettings.SelectPage(tpMailAlerts)
    End Sub

    Private Sub robUpdate_Click(sender As Object, e As EventArgs) Handles robUpdate.Click
        htcSettings.SelectPage(tpUpdate)
    End Sub

    Private Sub robMonitoring_Click(sender As Object, e As EventArgs) Handles robMonitoring.Click
        htcSettings.SelectPage(tpMonitoring)
    End Sub

    Private Sub robWarnings_Click(sender As Object, e As EventArgs) Handles robWarnings.Click
        htcSettings.SelectPage(tpWarnings)
    End Sub

    Private Sub robShare_Click(sender As Object, e As EventArgs) Handles robShare.Click
        htcSettings.SelectPage(tpShare)
    End Sub

    Private Sub robRating_Click(sender As Object, e As EventArgs) Handles robRating.Click
        htcSettings.SelectPage(tpRating)
    End Sub

    Private Sub robTolerance_Click(sender As Object, e As EventArgs) Handles robTolerance.Click
        htcSettings.SelectPage(tpTolerance)
    End Sub

    Private Sub robAddDevices_Click(sender As Object, e As EventArgs) Handles robControllers.Click
        htcSettings.SelectPage(tpRaidControllers)
    End Sub

    Private Sub robSmartctl_Click(sender As Object, e As EventArgs) Handles robSmartctl.Click
        htcSettings.SelectPage(tpSmartctl)
    End Sub
#End Region

#Region "Load/save settings"

    Public Sub LoadSettings()
        isloading_settings = True

        With My.Settings
            'check if settings upgrade was already done
            If Not .AreSettingsUpgraded Then .Upgrade()

            '************************
            '*** general settings ***
            '************************
            If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                chkStartupLink.Checked = TaskExist()
            Else
                chkStartupLink.Checked = ShortcutExists()
            End If
            chkRunMinimized.Checked = .StartMinimized
            chkMinimizeInTray.Checked = .MinimizeOnTray
            chkCloseOnTray.Checked = .CloseOnTray
            chkAlwaysShowTray.Checked = .AlwaysShowTrayIcon
            chkConfirmExit.Checked = .ConfirmOnExit
            chkUpdates.Checked = .CheckUpdates
            chkLanguageUpdates.Checked = .LanguageUpdate
            chkFahrenheit.Checked = .TempFahrenheit
            chkMonitorUsb.Checked = .MonitorUsb
            chkDebug.Checked = .Debug
            chkInfoPanel.Checked = .InfoPanel
            Main.rmiDebug.Visible = .Debug
            chkRememberSize.Checked = .RememberWindowSize

            '*************************
            '*** devices detection ***
            '*************************
            chkMonitorUsb.Checked = .MonitorUsb
            chkCsmi.Checked = .EnableCsmi
            chk3ware.Checked = .ThreewareDevice

            '**********************
            '*** update setting ***
            '**********************
            'internal
            numUpdate.Value = .DataUpdate
            Main.tmrRefresh.Interval = .DataUpdate * 60 * 1000
            Main.tmrRefresh.Enabled = True
            'external
            numUpdateExt.Value = .ExternalDevicesUpdate
            Main.tmrRefreshExt.Interval = .ExternalDevicesUpdate * 60 * 1000
            If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                Main.tmrRefreshExt.Enabled = True
                numUpdateExt.Enabled = True
            Else
                Main.tmrRefreshExt.Enabled = False
                numUpdateExt.Enabled = False
            End If
            'virtual
            numUpdateVirtual.Value = .VirtualDevicesUpdate
            Main.tmrRefreshVirtual.Interval = .VirtualDevicesUpdate * 60 * 1000
            Main.tmrRefreshVirtual.Enabled = True

            '************************
            '*** warning settings ***
            '************************
            'imminent failure
            chkFailure.Checked = .ImminentFailure
            'temperature
            chkTempThresh.Checked = .TemperatureThreshold
            chkCustomTemp.Checked = .CustomTemperature
            chkCustomTemp.Enabled = .TemperatureThreshold
            numTemp.Value = .CustomTemperatureValue
            numTemp.Enabled = .CustomTemperature
            lblTemp.Text = "°C/" & Math.Round(numTemp.Value * 1.8 + 32) & "°F"
            'vital parameter change
            chkParamChng.Checked = .VitalParameters
            nlChooseParams.Enabled = chkParamChng.Checked
            'general
            chkTempChng.Checked = .WarningTemp
            'HDD
            chkReallSectCtChng.Checked = .WarningReallocatedSector
            chkSpinRetryCtChng.Checked = .WarningSpinRetry
            chkReallEvCtChng.Checked = .WarningReallocatedEvent
            chkCurPenSectChng.Checked = .WarningCurrentPendingSector
            chkOfflUncChng.Checked = .WarningOfflineUncorrectable
            chkSoftReadErrChng.Checked = .WarningSoftReadErrorRate
            chkDiskShiftChng.Checked = .WarningDiskShift
            'SSD warning settings
            chkIndilinxChng.Checked = .WarningIndilinx
            chkIntelChng.Checked = .WarningIntel
            chkMicronChng.Checked = .WarningMicron
            chkSamsungChng.Checked = .WarningSamsung
            chkSandForceChng.Checked = .WarningSandForce

            '************************************
            '*** attributes tracking settings ***
            '************************************
            'general
            chkTemp.Checked = .Temperature
            'HDD
            chkReallSectCt.Checked = .ReallocatedSector
            chkSpinRetryCt.Checked = .SpinRetry
            chkReallEvCt.Checked = .ReallocatedEvent
            chkCurPenSect.Checked = .CurrentPendingSector
            chkOfflUnc.Checked = .OfflineUncorrectable
            chkSoftReadErr.Checked = .SoftReadErrorRate
            chkDiskShift.Checked = .DiskShift
            'SSD warning settings
            chkIndilinx.Checked = .Indilinx
            chkIntel.Checked = .Intel
            chkMicron.Checked = .Micron
            chkSamsung.Checked = .Samsung
            chkSandForce.Checked = .SandForce

            '*********************
            '*** share setting ***
            '*********************
            lblFolder.Text = ""
            lblFolder.Text = .SharingFolder
            If lblFolder.Text.Length = 0 Then lblFolder.Text = lblFolder.Tag
            m_sharingfolder = .SharingFolder

            chkXml.Checked = .ExportToXml
            btnXml.Enabled = .ExportToXml
            lblXmlPath.Text = ""
            lblXmlPath.Text = .XmlFolder
            If lblXmlPath.Text.Length = 0 Then lblXmlPath.Text = lblXmlPath.Tag

            '***********************
            '*** rating settings ***
            '***********************
            chkTuneUp.Checked = False
            tlpTuneUp.Enabled = False
            chkRating.Checked = False
            chkRating.Checked = .EnableRating
            chkTuneUp.Checked = .EnableTune
            numReall.Value = .Tune196
            numCurPend.Value = .Tune197
            numOfflUnc.Value = .Tune198

            '****************************
            '*** mail alerts settings ***
            '****************************
            chkMailAlerts.Checked = .MailSend
            tabMail.Enabled = .MailSend
            txtMailFrom.Text = .MailFrom
            txtMailTo.Text = .MailTo
            chkMailDeviceFail.Checked = .MailFail
            chkMailExcessiveTemp.Checked = .MailTemperature
            chkMailReliabilityDown.Checked = .MailReliability
            txtMailUserId.Text = .MailServerLogin
            Dim dec As New Aes
            If .MailServerPassword.Length > 0 Then txtMailPassword.Text = dec.Decrypt(.MailServerPassword, Main.aes_key, Main.aes_iv)
            txtSmtp.Text = .MailServerHost
            txtPort.Text = .MailServerPort
            chkSsl.Checked = .MailServerUseSsl
            rbNoReport.Checked = .MailNoReport
            rbWeekly.Checked = .MailWeeklyReport
            cboDays.Enabled = .MailWeeklyReport
            rbDaily.Checked = .MailDailyReport
            mtbDaily.Enabled = .MailDailyReport
            mtbDaily.Text = .MailDailyTime
            If .MailDailyReport Or .MailWeeklyReport Then nlSendReport.Enabled = True Else nlSendReport.Enabled = False
            txtMailSubject.Text = .MailSubject
            txtMailContent.Text = .MailContent

            '*************************
            '*** language settings ***
            '*************************
            optAutomatic.Checked = .AutomaticTranslation
            If Not .AutomaticTranslation Then
                optCustom.Checked = True
                cboLanguage.Enabled = True
                lblVersionValue.Text = ""
                lblTranslatorValue.Text = ""
                'language are selected from LoadLanguage routine
            End If

            '**************************
            '*** smartctl tolerance ***
            '**************************
            chkTolerance.Checked = .Tolerance
            flwTolerance.Enabled = .Tolerance
            If .Tolerance Then
                Select Case .ToleranceLevel
                    Case "-T normal "
                        rbNormal.Checked = True
                    Case "-T conservative "
                        rbConservative.Checked = True
                    Case "-T verypermissive "
                        rbVeryPermissive.Checked = True
                End Select
            End If

            '************************************
            '*** smartctl alternative version ***
            '************************************
            chkSmartctl.Checked = .SmartctlAlternative
            flwSmartctl.Enabled = .SmartctlAlternative
            lblSmartctlPath.Text = .SmartctlFolder

            '********************************
            '**** areca device detection ****
            '********************************
            numArecaSata.Value = .ArecaSata
            numArecaEnclosure1.Value = .ArecaEnclosure1
            numArecaEnclosure2.Value = .ArecaEnclosure2
            numArecaEnclosure3.Value = .ArecaEnclosure3
            numArecaEnclosure4.Value = .ArecaEnclosure4
            numArecaEnclosure5.Value = .ArecaEnclosure5
            numArecaEnclosure6.Value = .ArecaEnclosure6
            numArecaEnclosure7.Value = .ArecaEnclosure7
            numArecaEnclosure8.Value = .ArecaEnclosure8

        End With

        isloading_settings = False
    End Sub

    Public Sub SaveSettings()

        With My.Settings
            .AreSettingsUpgraded = True

            '***************
            '*** general ***
            '***************
            'startup link setting is not saved
            .StartMinimized = chkRunMinimized.Checked
            'behaviour
            .MinimizeOnTray = chkMinimizeInTray.Checked
            .CloseOnTray = chkCloseOnTray.Checked
            .AlwaysShowTrayIcon = chkAlwaysShowTray.Checked
            .ConfirmOnExit = chkConfirmExit.Checked
            .RememberWindowSize = chkRememberSize.Checked
            .WindowSize = Main.Size
            If Main.WindowState = FormWindowState.Maximized Then .Maximized = True Else .Maximized = False
            .InfoPanel = chkInfoPanel.Checked
            'updates
            .CheckUpdates = chkUpdates.Checked
            .LanguageUpdate = chkLanguageUpdates.Checked
            'temperatures
            .TempFahrenheit = chkFahrenheit.Checked
            'debug
            .Debug = chkDebug.Checked

            '*************************
            '*** devices detection ***
            '*************************
            .MonitorUsb = chkMonitorUsb.Checked
            .EnableCsmi = chkCsmi.Checked
            .ThreewareDevice = chk3ware.Checked

            '*****************
            '*** languages ***
            '*****************
            .AutomaticTranslation = optAutomatic.Checked
            If Not .AutomaticTranslation Then .Language = Main.translations(cboLanguage.SelectedIndex).CultureCode

            '*******************
            '*** mail alerts ***
            '*******************
            .MailSend = chkMailAlerts.Checked
            .MailFrom = txtMailFrom.Text
            .MailTo = txtMailTo.Text
            .MailFail = chkMailDeviceFail.Checked
            .MailTemperature = chkMailExcessiveTemp.Checked
            .MailReliability = chkMailReliabilityDown.Checked
            'mailserver
            .MailServerLogin = txtMailUserId.Text
            Dim en As New Aes
            If txtMailPassword.Text.Length > 0 Then .MailServerPassword = en.Encrypt(txtMailPassword.Text, Main.aes_key, Main.aes_iv)
            .MailServerHost = txtSmtp.Text
            .MailServerPort = txtPort.Text
            .MailServerUseSsl = chkSsl.Checked
            .MailNoReport = rbNoReport.Checked
            .MailWeeklyReport = rbWeekly.Checked
            .MailDayNumber = cboDays.SelectedIndex
            .MailDailyReport = rbDaily.Checked
            .MailDailyTime = mtbDaily.Text
            .MailSubject = txtMailSubject.Text
            .MailContent = txtMailContent.Text

            '*******************
            '*** data update ***
            '*******************
            .DataUpdate = numUpdate.Value
            .ExternalDevicesUpdate = numUpdateExt.Value
            .VirtualDevicesUpdate = numUpdateVirtual.Value

            '******************
            '*** monitoring ***
            '******************
            'general
            .Temperature = chkTemp.Checked
            'HDD
            .ReallocatedSector = chkReallSectCt.Checked
            .SpinRetry = chkSpinRetryCt.Checked
            .ReallocatedEvent = chkReallEvCt.Checked
            .CurrentPendingSector = chkCurPenSect.Checked
            .OfflineUncorrectable = chkOfflUnc.Checked
            .SoftReadErrorRate = chkSoftReadErr.Checked
            .DiskShift = chkDiskShift.Checked
            'SSD
            .Indilinx = chkIndilinx.Checked
            .Intel = chkIntel.Checked
            .Micron = chkMicron.Checked
            .Samsung = chkSamsung.Checked
            .SandForce = chkSandForce.Checked

            '****************
            '*** warnings ***
            '****************
            .ImminentFailure = chkFailure.Checked
            'temperature threshold
            .TemperatureThreshold = chkTempThresh.Checked
            .CustomTemperature = chkCustomTemp.Checked
            .CustomTemperatureValue = numTemp.Value
            'vital parameter change
            .VitalParameters = chkParamChng.Checked
            'general
            .WarningTemp = chkTempChng.Checked
            'HDD
            .WarningReallocatedSector = chkReallSectCtChng.Checked
            .WarningSpinRetry = chkSpinRetryCtChng.Checked
            .WarningReallocatedEvent = chkReallEvCtChng.Checked
            .WarningCurrentPendingSector = chkCurPenSectChng.Checked
            .WarningOfflineUncorrectable = chkOfflUncChng.Checked
            .WarningSoftReadErrorRate = chkSoftReadErrChng.Checked
            .WarningDiskShift = chkDiskShiftChng.Checked
            'SSD
            .WarningIndilinx = chkIndilinxChng.Checked
            .WarningIntel = chkIntelChng.Checked
            .WarningMicron = chkMicronChng.Checked
            .WarningSamsung = chkSamsungChng.Checked
            .WarningSandForce = chkSandForceChng.Checked

            '***************
            '*** sharing ***
            '***************
            If IO.Directory.Exists(lblFolder.Text) Then .SharingFolder = lblFolder.Text
            .ExportToXml = chkXml.Checked
            If IO.Directory.Exists(lblXmlPath.Text) Then .XmlFolder = lblXmlPath.Text

            '**************
            '*** rating ***
            '**************
            .EnableRating = chkRating.Checked
            .EnableTune = chkTuneUp.Checked
            .Tune196 = numReall.Value
            .Tune197 = numCurPend.Value
            .Tune198 = numOfflUnc.Value

            '*****************
            '*** tolerance ***
            '*****************
            .Tolerance = chkTolerance.Checked
            If .Tolerance Then
                If rbNormal.Checked Then .ToleranceLevel = "-T normal "
                If rbConservative.Checked Then .ToleranceLevel = "-T conservative "
                If rbVeryPermissive.Checked Then .ToleranceLevel = "-T verypermissive "
            End If

            '************************************
            '*** smartctl alternative version ***
            '************************************
            .SmartctlAlternative = chkSmartctl.Checked
            .SmartctlFolder = lblSmartctlPath.Text

            '********************************
            '**** areca device detection ****
            '********************************
            .ArecaSata = numArecaSata.Value
            .ArecaEnclosure1 = numArecaEnclosure1.Value
            .ArecaEnclosure2 = numArecaEnclosure2.Value
            .ArecaEnclosure3 = numArecaEnclosure3.Value
            .ArecaEnclosure4 = numArecaEnclosure4.Value
            .ArecaEnclosure5 = numArecaEnclosure5.Value
            .ArecaEnclosure6 = numArecaEnclosure6.Value
            .ArecaEnclosure7 = numArecaEnclosure7.Value
            .ArecaEnclosure8 = numArecaEnclosure8.Value

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
        If Not isloading_settings Then SaveSettings()
        Main.niTrayIcon.Visible = chkAlwaysShowTray.Checked
    End Sub

    Private Sub chkUpdates_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUpdates.CheckedChanged
        If Not isloading_settings Then
            SaveSettings()
            If chkUpdates.Checked Then Main.CheckForUpdates()
        End If
    End Sub

    Private Sub chkFahrenheit_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFahrenheit.CheckedChanged
        If Not isloading_settings Then
            SaveSettings()

            With Main
                'update device list
                With .lvwDevices
                    For i As Short = 0 To .Items.Count - 1
                        If IsNumeric(Main.devlist(i).Temperature) Then
                            If My.Settings.TempFahrenheit = True Then
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
                    With .lblTempInfoValue
                        If My.Settings.TempFahrenheit = True Then
                            .Text = Math.Round(d.Temperature * 1.8 + 32) & "°F"
                        Else
                            .Text = d.Temperature & "°C"
                        End If
                    End With
                End If
                'update device info panel
                Dim dev As Device = .devlist(.cboDevices.SelectedIndex)
                With .lblTempValue
                    If IsNumeric(dev.Temperature) Then
                        Dim temp As String
                        If My.Settings.TempFahrenheit = False Then
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
            SaveSettings()
            Main.rmiDebug.Visible = chkDebug.Checked
            If Not Main.rmiDebug.Visible Then InvokeOnClick(Main.rmiOverview, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub chkLanguageUpdates_CheckedChanged(sender As Object, e As EventArgs) Handles chkLanguageUpdates.CheckedChanged
        If Not isloading_settings Then
            SaveSettings()
            If chkUpdates.Checked Then Main.LanguagesUpdate()
        End If
    End Sub
#End Region

#Region "Device detection"
    Private Sub chkMonitorUsb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMonitorUsb.CheckedChanged
        If Not isloading_settings Then
            SaveSettings()
            If chkMonitorUsb.Checked = False Then
                Main.StopMonitorDeviceConnection()
            Else
                Main.StartMonitorDeviceConnection()
            End If
        End If
    End Sub

    Private Sub chk3ware_CheckedChanged(sender As Object, e As EventArgs) Handles chk3ware.CheckedChanged
        If Not isloading_settings Then
            SaveSettings()
            If chk3ware.Checked Then
                With Main
                    .devlist.Add(New Device(True))
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
                        If .devlist(i).Type = DeviceType.Threeware Then
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
#End Region

#Region "Update"
    Private Sub numUpdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numUpdate.ValueChanged
        If Not isloading_settings Then SaveSettings()
        Main.tmrRefresh.Interval = numUpdate.Value * 60 * 1000
        Main.tmrRefresh.Enabled = True
    End Sub

    Private Sub numUpdateExt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numUpdateExt.ValueChanged
        If Not isloading_settings Then SaveSettings()
        Main.tmrRefreshExt.Interval = numUpdateExt.Value * 60 * 1000
        Main.tmrRefreshExt.Enabled = True
    End Sub

    Private Sub numUpdateVirtual_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numUpdateVirtual.ValueChanged
        If Not isloading_settings Then SaveSettings()
        Main.tmrRefreshVirtual.Interval = numUpdateVirtual.Value * 60 * 1000
        Main.tmrRefreshVirtual.Enabled = True
    End Sub
#End Region

#Region "Monitoring"
    Private Sub lnkInvertHddSel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkInvertHddSel.LinkClicked
        'this is a trick: setting to true the variable 'isloading_settings',
        'prevent a multiple writing of the settings file!
        isloading_settings = True

        chkReallEvCt.Checked = Not chkReallEvCt.Checked
        chkReallSectCt.Checked = Not chkReallSectCt.Checked
        chkSoftReadErr.Checked = Not chkSoftReadErr.Checked
        chkSpinRetryCt.Checked = Not chkSpinRetryCt.Checked
        chkCurPenSect.Checked = Not chkCurPenSect.Checked
        chkOfflUnc.Checked = Not chkOfflUnc.Checked
        chkDiskShift.Checked = Not chkDiskShift.Checked

        SaveSettings()
        isloading_settings = False
    End Sub

    Private Sub lnkInvertSsdSel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkInvertSsdSel.LinkClicked
        'this is a trick: setting to true the variable 'isloading_settings',
        'prevent a multiple writing of the settings file!
        isloading_settings = True

        chkIndilinx.Checked = Not chkIndilinx.Checked
        chkIntel.Checked = Not chkIntel.Checked
        chkMicron.Checked = Not chkMicron.Checked
        chkSamsung.Checked = Not chkSamsung.Checked
        chkSandForce.Checked = Not chkSandForce.Checked

        SaveSettings()
        isloading_settings = False
    End Sub

    Private Sub monitoring(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCurPenSect.CheckedChanged, chkDiskShift.CheckedChanged, _
        chkIndilinx.CheckedChanged, chkIntel.CheckedChanged, chkMicron.CheckedChanged, chkOfflUnc.CheckedChanged, chkReallEvCt.CheckedChanged, _
        chkSamsung.CheckedChanged, chkSandForce.CheckedChanged, chkSoftReadErr.CheckedChanged, chkSpinRetryCt.CheckedChanged, _
        chkTemp.CheckedChanged, chkReallSectCt.CheckedChanged

        If Not isloading_settings Then SaveSettings()
    End Sub
#End Region

#Region "Warnings"
    Private Sub warnings(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFailure.CheckedChanged, _
        chkTempChng.CheckedChanged, chkCurPenSectChng.CheckedChanged, chkDiskShiftChng.CheckedChanged, _
        chkIndilinxChng.CheckedChanged, chkIntelChng.CheckedChanged, chkMicronChng.CheckedChanged, chkOfflUncChng.CheckedChanged, _
        chkReallEvCtChng.CheckedChanged, chkReallSectCtChng.CheckedChanged, chkSamsungChng.CheckedChanged, chkSandForceChng.CheckedChanged, _
        chkSoftReadErrChng.CheckedChanged, chkSpinRetryCtChng.CheckedChanged

        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub numTemp_ValueChanged(sender As Object, e As EventArgs) Handles numTemp.ValueChanged
        lblTemp.Text = "°C/" & Math.Round(numTemp.Value * 1.8 + 32) & "°F"
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub lnkHddChngInvert_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkHddChngInvert.LinkClicked
        'this is a trick: setting to true the variable 'isloading_settings',
        'prevent a multiple writing of the settings file!
        isloading_settings = True

        chkReallEvCtChng.Checked = Not chkReallEvCtChng.Checked
        chkReallSectCtChng.Checked = Not chkReallSectCtChng.Checked
        chkSoftReadErrChng.Checked = Not chkSoftReadErrChng.Checked
        chkSpinRetryCtChng.Checked = Not chkSpinRetryCtChng.Checked
        chkCurPenSectChng.Checked = Not chkCurPenSectChng.Checked
        chkOfflUncChng.Checked = Not chkOfflUncChng.Checked
        chkDiskShiftChng.Checked = Not chkDiskShiftChng.Checked

        SaveSettings()
        isloading_settings = False
    End Sub

    Private Sub lnkSsdChngInvert_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSsdChngInvert.LinkClicked
        'this is a trick: setting to true the variable 'isloading_settings',
        'prevent a multiple writing of the settings file!
        isloading_settings = True

        chkIndilinxChng.Checked = Not chkIndilinxChng.Checked
        chkIntelChng.Checked = Not chkIntelChng.Checked
        chkMicronChng.Checked = Not chkMicronChng.Checked
        chkSamsungChng.Checked = Not chkSamsungChng.Checked
        chkSandForceChng.Checked = Not chkSandForceChng.Checked

        SaveSettings()
        isloading_settings = False
    End Sub

    Private Sub chkTempThresh_CheckedChanged(sender As Object, e As EventArgs) Handles chkTempThresh.CheckedChanged
        If Not isloading_settings Then SaveSettings()
        chkCustomTemp.Enabled = chkTempThresh.Checked
    End Sub

    Private Sub chkCustomTemp_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustomTemp.CheckedChanged
        If Not isloading_settings Then SaveSettings()
        numTemp.Enabled = chkCustomTemp.Checked
    End Sub

    Private Sub chkParamChng_CheckedChanged(sender As Object, e As EventArgs) Handles chkParamChng.CheckedChanged
        If Not isloading_settings Then SaveSettings()
        nlChooseParams.Enabled = chkParamChng.Checked
    End Sub

    Private Sub nlChooseParams_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles nlChooseParams.LinkClicked
        htcWarnings.SelectPage(tpWarningsParametrs)
    End Sub

    Private Sub nlBackToWarnings_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles nlBackToWarnings.LinkClicked
        htcWarnings.SelectPage(tpWarningsMain)
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

                SaveSettings()
            End If
        End With
    End Sub

    Private Sub chkXml_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkXml.CheckedChanged
        btnXml.Enabled = chkXml.Checked
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub btnXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXml.Click
        With Main.dlgFolder
            .Description = lblXml.Text
            Dim result As DialogResult = .ShowDialog(Me)
            If result = DialogResult.OK Then
                lblXmlPath.Text = .SelectedPath
                lblXmlPath.Visible = True
                SaveSettings()
            End If
        End With
    End Sub
#End Region

#Region "Reliability"
    Private Sub chkRating_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRating.CheckedChanged
        chkTuneUp.Enabled = chkRating.Checked
        If Not isloading_settings Then SaveSettings()

        If chkRating.Checked Then
            If Not isloading_settings Then Main.SetRating()
        Else
            Main.picReliability.Image = Nothing
        End If
    End Sub

    Private Sub chkTuneUp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTuneUp.CheckedChanged
        tlpTuneUp.Enabled = chkTuneUp.Checked
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub TunersValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        numOfflUnc.ValueChanged, numCurPend.ValueChanged, numReall.ValueChanged

        Main.SetRating()
        Main.ReliabilityDetails()
        If Not isloading_settings Then SaveSettings()
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
    Private Sub mailcheckboxes(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMailAlerts.CheckedChanged, _
        chkMailDeviceFail.CheckedChanged, chkMailExcessiveTemp.CheckedChanged, chkMailReliabilityDown.CheckedChanged

        If Not isloading_settings Then SaveSettings()
        tabMail.Enabled = chkMailAlerts.Checked
    End Sub

    Private Sub txtMailFrom_TextChanged(sender As Object, e As EventArgs) Handles txtMailFrom.TextChanged
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub txtMailTo_TextChanged(sender As Object, e As EventArgs) Handles txtMailTo.TextChanged
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub lnkTestMail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTestMail.LinkClicked
        Main.SendMail("HDD Guardian test mail", Main.GetString(3708))
    End Sub

    Private Sub rbNoReport_CheckedChanged(sender As Object, e As EventArgs) Handles rbNoReport.CheckedChanged
        If Not isloading_settings Then SaveSettings()
        If rbNoReport.Checked Then
            mtbDaily.Enabled = False
            cboDays.Enabled = False
        End If
    End Sub

    Private Sub rbDaily_CheckedChanged(sender As Object, e As EventArgs) Handles rbDaily.CheckedChanged
        If Not isloading_settings Then SaveSettings()
        If rbDaily.Checked Then
            mtbDaily.Enabled = True
            cboDays.Enabled = False
        End If
    End Sub

    Private Sub rbWeekly_CheckedChanged(sender As Object, e As EventArgs) Handles rbWeekly.CheckedChanged
        If Not isloading_settings Then SaveSettings()
        If rbWeekly.Checked Then
            mtbDaily.Enabled = False
            cboDays.Enabled = True
        End If
    End Sub

    Private Sub mtbDaily_TextChanged(sender As Object, e As EventArgs) Handles mtbDaily.TextChanged
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub nlSendReport_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles nlSendReport.LinkClicked
        Main.RegularReport(True)
    End Sub

    Private Sub cboDays_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDays.SelectedIndexChanged
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub txtMailSubject_TextChanged(sender As Object, e As EventArgs) Handles txtMailSubject.TextChanged
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub txtMailContent_TextChanged(sender As Object, e As EventArgs) Handles txtMailContent.TextChanged
        If Not isloading_settings Then SaveSettings()
    End Sub
#End Region

#Region "Tolerance"
    Private Sub chkTolerance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTolerance.CheckedChanged
        flwTolerance.Enabled = chkTolerance.Checked
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub ChangeTolerance(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbConservative.CheckedChanged, rbNormal.CheckedChanged, rbVeryPermissive.CheckedChanged
        If Not isloading_settings Then SaveSettings()
    End Sub

#End Region

#Region "Translations"
    Private Sub optAutomatic_CheckedChanged(sender As Object, e As EventArgs) Handles optAutomatic.CheckedChanged
        If optAutomatic.Checked Then
            cboLanguage.Enabled = False
            If Not isloading_settings Then
                SaveSettings()
                Main.ChangeLanguage()
            End If
        End If
    End Sub

    Private Sub optCustom_CheckedChanged(sender As Object, e As EventArgs) Handles optCustom.CheckedChanged
        If optCustom.Checked Then
            cboLanguage.Enabled = True
            If Not isloading_settings Then
                cboLanguage.SelectedIndex = 0
                SaveSettings()
            End If
        End If
    End Sub

    Private Sub cboLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLanguage.SelectedIndexChanged
        If optAutomatic.Checked Then Exit Sub

        If cboLanguage.Enabled And Not isloading_settings Then
            SaveSettings()

            'lblTranslatorValue.Text = Main.translations(cboLanguage.SelectedIndex).Translator
            'lblVersionValue.Text = Main.translations(cboLanguage.SelectedIndex).Version

            Main.ChangeLanguage()
        End If
    End Sub

#End Region

#Region "Additional devices"
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
        If Not isloading_settings Then SaveSettings()
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

                SaveSettings()
            End If
        End With
    End Sub

#End Region

End Class