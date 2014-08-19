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

Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Xml

Public Class Settings

    Dim m_sharingfolder As String

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Main.SetWindowTheme(lvwAdditionalDevices.Handle, "explorer", Nothing)
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadAdditionalDevices()
    End Sub

    Private Sub Settings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        InvokeOnClick(robGeneral, Nothing)

        isloading_settings = True

        If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            chkPowerMode.Enabled = False
            flwPowerMode.Enabled = False
            chkTolerance.Enabled = False
            flwTolerance.Enabled = False
            chkMonitorUsb.Enabled = False
            chkCsmi.Enabled = False
            tlpAddDevice.Enabled = False
            tlpDevicesList.Enabled = False
        End If

        If Not My.Settings.Tolerance Then rbNormal.Checked = True
        If Not My.Settings.PowerMode Then rbNever.Checked = True

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

    Private Sub robPowerMode_Click(sender As Object, e As EventArgs) Handles robPowerMode.Click
        htcSettings.SelectPage(tpPowerMode)
    End Sub

    Private Sub robAddDevices_Click(sender As Object, e As EventArgs) Handles robAddDevices.Click
        htcSettings.SelectPage(tpAddDevices)
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
            tlpParamChange.Enabled = chkParamChng.Checked
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
            numErrors.Value = .TuneErrors
            numCurPend.Value = .Tune197
            numOfflUnc.Value = .Tune198

            '****************************
            '*** mail alerts settings ***
            '****************************
            chkMailAlerts.Checked = .MailSend
            tlpMail.Enabled = .MailSend
            tlpWhenSendMail.Enabled = .MailSend
            tlpCustomServer.Enabled = .MailSend
            lblMailDestination.Enabled = .MailSend
            lblSetMailServer.Enabled = .MailSend
            txtMail.Text = .MailDestination
            chkMailDeviceFail.Checked = .MailFail
            chkMailExcessiveTemp.Checked = .MailTemperature
            chkMailReliabilityDown.Checked = .MailReliability
            txtCustomMail.Text = .ServerLogin
            Dim dec As New Aes
            If .ServerPassword.Length > 0 Then txtPassword.Text = dec.Decrypt(.ServerPassword, Main.aes_key, Main.aes_iv)
            txtSmtp.Text = .ServerHost
            txtPort.Text = .ServerPort
            chkSsl.Checked = .ServerUseSsl

            '*************************
            '*** language settings ***
            '*************************
            optAutomatic.Checked = .AutomaticTranslation
            If Not .AutomaticTranslation Then
                optCustom.Checked = True
                cboLanguage.Enabled = True
                tlpLanguageInfo.Visible = False
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

            '***************************
            '*** smartctl power mode ***
            '***************************
            chkPowerMode.Checked = .PowerMode
            flwPowerMode.Enabled = .PowerMode
            If .PowerMode Then
                Select Case .PowerModeLevel
                    Case "-n never "
                        rbNever.Checked = True
                    Case "-n sleep "
                        rbSleep.Checked = True
                    Case "-n standby "
                        rbStandby.Checked = True
                    Case "-n idle "
                        rbIdle.Checked = True
                End Select
            End If

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
            'temperatures
            .TempFahrenheit = chkFahrenheit.Checked
            'debug
            .Debug = chkDebug.Checked

            '*************************
            '*** devices detection ***
            '*************************
            .MonitorUsb = chkMonitorUsb.Checked
            .EnableCsmi = chkCsmi.Checked

            '*****************
            '*** languages ***
            '*****************
            .AutomaticTranslation = optAutomatic.Checked
            If Not .AutomaticTranslation Then .Language = Main.translations(cboLanguage.SelectedIndex).CultureCode

            '*******************
            '*** mail alerts ***
            '*******************
            .MailSend = chkMailAlerts.Checked
            .MailDestination = txtMail.Text
            .MailFail = chkMailDeviceFail.Checked
            .MailTemperature = chkMailExcessiveTemp.Checked
            .MailReliability = chkMailReliabilityDown.Checked
            'mailserver
            .ServerLogin = txtMail.Text
            Dim en As New Aes
            If txtPassword.Text.Length > 0 Then .ServerPassword = en.Encrypt(txtPassword.Text, Main.aes_key, Main.aes_iv)
            .ServerHost = txtSmtp.Text
            .ServerPort = txtPort.Text
            .ServerUseSsl = chkSsl.Checked

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
            .TuneErrors = numErrors.Value
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

            '******************
            '*** power mode ***
            '******************
            .PowerMode = chkPowerMode.Checked
            If .PowerMode Then
                If rbNever.Checked Then .PowerModeLevel = "-n never "
                If rbSleep.Checked Then .PowerModeLevel = "-n sleep "
                If rbStandby.Checked Then .PowerModeLevel = "-n standby "
                If rbIdle.Checked Then .PowerModeLevel = "-n idle "
            End If

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
            End With
        End If
    End Sub

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

    Private Sub chkDebug_CheckedChanged(sender As Object, e As EventArgs) Handles chkDebug.CheckedChanged
        If Not isloading_settings Then
            SaveSettings()
            Main.rmiDebug.Visible = chkDebug.Checked
            If Not Main.rmiDebug.Visible Then InvokeOnClick(Main.rmiOverview, System.EventArgs.Empty)
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
        tlpParamChange.Enabled = chkParamChng.Checked
    End Sub
#End Region

#Region "Sharing"
    Private Sub btnBrwsFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        numOfflUnc.ValueChanged, numCurPend.ValueChanged, numErrors.ValueChanged

        Main.SetRating()
        Main.ReliabilityDetails()
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub Reset(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles _
        lnkResetErrors.LinkClicked, lnkResetCurPending.LinkClicked, lnkResetOfflUnc.LinkClicked

        Select Case sender.Name
            Case lnkResetErrors.Name
                numErrors.Value = numErrors.Tag
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
        tlpWhenSendMail.Enabled = chkMailAlerts.Checked
        tlpMail.Enabled = chkMailAlerts.Checked
        tlpCustomServer.Enabled = chkMailAlerts.Checked
        lblMailDestination.Enabled = chkMailAlerts.Checked
        lblSetMailServer.Enabled = chkMailAlerts.Checked
    End Sub

    Private Sub txtMail_TextChanged(sender As Object, e As EventArgs) Handles txtMail.TextChanged
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub lnkTestMail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTestMail.LinkClicked
        Main.SendMail("HDD Guardian test mail", Main.GetString(3708))
    End Sub

    Private Sub ServerSetupChanged(sender As Object, e As EventArgs) Handles _
        txtCustomMail.TextChanged, txtPassword.TextChanged, txtSmtp.TextChanged, txtPort.TextChanged, _
         chkSsl.CheckedChanged

        If Not isloading_settings Then SaveSettings()

        tlpCustomServer.Enabled = chkMailAlerts.Checked
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

#Region "Power mode"
    Private Sub chkPowerMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPowerMode.CheckedChanged
        flwPowerMode.Enabled = chkPowerMode.Checked
        If Not isloading_settings Then SaveSettings()
    End Sub

    Private Sub ChangePowerMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbIdle.CheckedChanged, rbNever.CheckedChanged, rbSleep.CheckedChanged, rbStandby.CheckedChanged
        If Not isloading_settings Then SaveSettings()
    End Sub

#End Region

#Region "Translations"
    Private Sub optAutomatic_CheckedChanged(sender As Object, e As EventArgs) Handles optAutomatic.CheckedChanged
        If optAutomatic.Checked Then
            cboLanguage.Enabled = False
            tlpLanguageInfo.Visible = False
            lblVersionValue.Text = ""
            lblTranslatorValue.Text = ""
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
                tlpLanguageInfo.Visible = True
                lblTranslatorValue.Text = Main.translations(cboLanguage.SelectedIndex).Translator
                lblVersionValue.Text = Main.translations(cboLanguage.SelectedIndex).Version
                SaveSettings()
            End If
        End If
    End Sub

    Private Sub cboLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLanguage.SelectedIndexChanged
        If optAutomatic.Checked Then Exit Sub

        If cboLanguage.Enabled And Not isloading_settings Then
            SaveSettings()

            lblTranslatorValue.Text = Main.translations(cboLanguage.SelectedIndex).Translator
            lblVersionValue.Text = Main.translations(cboLanguage.SelectedIndex).Version

            Main.ChangeLanguage()
        End If
    End Sub

#End Region

#Region "Additional devices"
    Private Sub btnAddDevice_Click(sender As Object, e As EventArgs) Handles btnAddDevice.Click
        Dim before As Short = lvwAdditionalDevices.Items.Count

        AdditionalDevicesDlg.ShowDialog(Me)
        btnRemoveDevice.Enabled = False

        If lvwAdditionalDevices.Items.Count > before Then SaveAdditionalDevices()
    End Sub

    Private Sub lvwAdditionalDevices_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvwAdditionalDevices.ItemSelectionChanged
        btnRemoveDevice.Enabled = e.IsSelected
    End Sub

    Private Sub btnRemoveDevice_Click(sender As Object, e As EventArgs) Handles btnRemoveDevice.Click
        With lvwAdditionalDevices
            .Items(.SelectedItems(0).Index).Remove()

            If .Items.Count > 0 Then
                .Items(0).Selected = True
            Else
                btnRemoveDevice.Enabled = False
            End If
        End With

        SaveAdditionalDevices()
    End Sub

    Private Sub SaveAdditionalDevices()
        Try
            Dim output As XmlWriterSettings = New XmlWriterSettings()
            output.Indent = True

            Using write As XmlWriter = XmlWriter.Create(My.Application.Info.DirectoryPath & "\additional.xml", output)
                write.WriteStartDocument()
                write.WriteStartElement("additionaldevices")

                If lvwAdditionalDevices.Items.Count > 0 Then
                    For i As Short = 0 To lvwAdditionalDevices.Items.Count - 1
                        write.WriteStartElement("device")
                        write.WriteAttributeString("description", lvwAdditionalDevices.Items(i).Text)
                        write.WriteAttributeString("command", lvwAdditionalDevices.Items(i).SubItems(1).Text)
                        write.WriteEndElement()
                    Next
                End If

                write.WriteEndElement()
                write.WriteEndDocument()
            End Using
        Catch ex As Exception
            Main.PrintDebug("Encountered an error while saving additional devices list: " & ex.ToString, True)
        End Try
    End Sub

    Private Sub LoadAdditionalDevices()
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\additional.xml") Then
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            m_xmldoc.Load(My.Application.Info.DirectoryPath & "\additional.xml")
            m_nodelist = m_xmldoc.SelectNodes("/devices/device")

            lvwAdditionalDevices.Items.Clear()

            For Each m_node In m_nodelist
                With lvwAdditionalDevices
                    .Items.Add(m_node.Attributes.GetNamedItem("description").Value)
                    .Items(.Items.Count - 1).SubItems.Add(m_node.Attributes.GetNamedItem("command").Value)
                End With
            Next
        End If
    End Sub

#End Region

#Region "Help icons"
    Private Sub Help_Click(sender As Object, e As EventArgs) Handles picHelpSetupGeneral.Click, picHelpSetupDetection.Click, _
        picHelpSetupMailAlerts.Click, picHelpSetupMonitoring.Click, picHelpSetupPowerMode.Click, _
        picHelpSetupRating.Click, picHelpSetupShare.Click, picHelpSetupTolerance.Click, _
        picHelpSetupTranslation.Click, picHelpSetupUpdate.Click, picHelpSetupWarnings.Click, picHelpSetupAddDevice.Click

        Try
            System.Diagnostics.Process.Start(sender.Tag)
        Catch ex As Exception
            Main.PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub
#End Region

End Class