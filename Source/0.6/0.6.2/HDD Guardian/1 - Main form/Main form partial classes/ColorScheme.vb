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

Public Class ColorScheme
    Public ReadOnly BackColor, ForeColor As Color
    Public ReadOnly StatusBarBackColor, RibbonToolbarBackColor As Color
    Public ReadOnly GrayedText, RibbonGrayedText As Color
    Public ReadOnly GroupText, HorizontalLine As Color
    Public ReadOnly LinkColor, ActiveLinkColor As Color

    Declare Unicode Function IsThemeActive Lib "uxtheme" () As Boolean

    Public Sub New()
        If IsThemeActive Then
            BackColor = Color.FromArgb(255, 255, 255)
            ForeColor = Color.FromArgb(0, 0, 0)
            StatusBarBackColor = Color.FromArgb(245, 245, 245)
            RibbonToolbarBackColor = Color.FromArgb(245, 246, 247)
            GrayedText = Color.FromArgb(105, 105, 105)
            RibbonGrayedText = Color.FromArgb(192, 192, 192)
            GroupText = Color.FromArgb(29, 174, 255)
            HorizontalLine = Color.FromArgb(192, 192, 192)
            LinkColor = Color.FromArgb(0, 102, 204)
            ActiveLinkColor = Color.FromArgb(51, 153, 255)
        Else
            BackColor = Color.FromKnownColor(KnownColor.Window)
            ForeColor = Color.FromKnownColor(KnownColor.WindowText)
            StatusBarBackColor = Color.FromKnownColor(KnownColor.ButtonFace)
            RibbonToolbarBackColor = Color.FromKnownColor(KnownColor.MenuBar)
            GrayedText = Color.FromKnownColor(KnownColor.GrayText)
            RibbonGrayedText = Color.FromKnownColor(KnownColor.InactiveCaptionText)
            GroupText = Color.FromKnownColor(KnownColor.Highlight)
            HorizontalLine = Color.FromKnownColor(KnownColor.WindowFrame)
            LinkColor = Color.FromKnownColor(KnownColor.HotTrack)
            ActiveLinkColor = Color.FromKnownColor(KnownColor.Highlight)
        End If
    End Sub
End Class

Partial Class Main
    Sub ApplyColorScheme()
        Dim cs As New ColorScheme
        'Main window
        Me.BackColor = cs.BackColor

        '************ Overview ************

        tlpMenuItems.BackColor = cs.RibbonToolbarBackColor
        lvwDevices.BackColor = cs.BackColor
        lvwDevices.ForeColor = cs.ForeColor
        pnlInfo.BackColor = cs.StatusBarBackColor
        For Each c In tlpInfoPanel.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Normal" Then
                    c.ForeColor = cs.ForeColor
                ElseIf c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                End If
            End If
        Next
        For Each c In tlpInfoPanel.Controls
            If c.GetType.Name = "ExtendedLabel" Then
                c.ForeColor = cs.GrayedText
            End If
        Next

        '************ Manage ************
        lblSelDevice.ForeColor = cs.ForeColor
        pnlComboBorder.BackColor = cs.HorizontalLine
        cboDevices.BackColor = cs.BackColor
        cboDevices.ForeColor = cs.ForeColor
        tlpSelDevice.BackColor = cs.RibbonToolbarBackColor
        tlpManageMenuContent.BackColor = cs.RibbonToolbarBackColor
        For Each c In tlpManageMenuContent.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.GrayedText
            End If
        Next
        'ATA health status
        tpAtaHealth.BackColor = cs.BackColor
        For Each c In tlpHealthStatus.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            End If
        Next
        'ATA info panel
        tpAtaInfo.BackColor = cs.BackColor
        For Each c In tlpAtaInfoPanels.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.GrayedText
            End If
        Next
        For Each c In flwManufacturer.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.ForeColor
            ElseIf c.GetType.Name = "NewLink" Then
                c.LinkColor = cs.LinkColor
                c.ActiveLinkColor = cs.ActiveLinkColor
            End If
        Next
        For Each c In tlpAtaDevice.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        lblInDatabase.ForeColor = cs.ForeColor
        lnkUpdateDatabase.LinkColor = cs.LinkColor
        lnkUpdateDatabase.ActiveLinkColor = cs.ActiveLinkColor
        lblWarningValue.ForeColor = cs.ForeColor
        For Each c In flwManufacturer.Controls
            If c.GetType.Name = "NewLink" Then
                c.LinkColor = cs.LinkColor
                c.ActiveLinkColor = cs.ActiveLinkColor
            End If
        Next
        'SMART attributes
        tpAtaSmartAttributes.BackColor = cs.BackColor
        lvwSmart.BackColor = cs.BackColor
        lvwSmart.ForeColor = cs.ForeColor
        For Each c In tlpAttributeDetails.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Group" Then
                    c.ForeColor = cs.GroupText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            End If
        Next
        For Each c In tlpGraph.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        'SCSI health status
        tpScsiHealth.BackColor = cs.BackColor
        For Each c In tlpScsiHealth.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            End If
        Next
        'SCSI info panel
        tpScsiInfo.BackColor = cs.BackColor
        For Each c In tlpScsiInfo.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.GrayedText
            End If
        Next
        For Each c In flwScsiVendor.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.GrayedText
            ElseIf c.GetType.Name = "NewLink" Then
                c.LinkColor = cs.LinkColor
                c.ActiveLinkColor = cs.ActiveLinkColor
            End If
        Next
        'Events log
        tpEventsLog.BackColor = cs.BackColor
        lblLogItems.ForeColor = cs.ForeColor
        lvwLog.ForeColor = cs.ForeColor
        lvwLog.BackColor = cs.BackColor
        'Events chart
        tpEventsChart.BackColor = cs.BackColor
        lblEvents.ForeColor = cs.ForeColor
        lblChartCount.ForeColor = cs.ForeColor
        lvwChart.ForeColor = cs.ForeColor
        lvwChart.BackColor = cs.BackColor
        'Temperatures
        tpTemperatures.BackColor = cs.BackColor
        For Each c In tlpTemperatures.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                ElseIf c.Tag = "Group" Then
                    c.ForeColor = cs.GroupText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            End If
        Next
        For Each c In tlpTempGraphs.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            End If
        Next
        For Each c In tlpTempMeans.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            End If
        Next
        'ATA SMART setup
        tpAtaSmartSetup.BackColor = cs.BackColor
        For Each c In tlpAtaSmart.Controls
            If c.Tag = "Grayed" Then
                c.ForeColor = cs.GrayedText
            Else
                c.ForeColor = cs.ForeColor
            End If
        Next
        'SCSI SMART setup
        tpScsiSmartSetup.BackColor = cs.BackColor
        For Each c In tlpScsiSmart.Controls
            If c.Tag = "Grayed" Then
                c.ForeColor = cs.GrayedText
            Else
                c.ForeColor = cs.ForeColor
            End If
        Next
        'AAM
        tpAtaAam.BackColor = cs.BackColor
        lblInfoAam.ForeColor = cs.GrayedText
        lblQuiet.ForeColor = cs.GrayedText
        lblLoudest.ForeColor = cs.GrayedText
        lblAamValue.ForeColor = cs.ForeColor
        lblAamRecommended.ForeColor = cs.ForeColor
        lblAamWaitMessage.ForeColor = cs.ForeColor
        trkAam.BackColor = cs.BackColor
        'APM
        tpAtaApm.BackColor = cs.BackColor
        lblInfoApm.ForeColor = cs.GrayedText
        lblApmValue.ForeColor = cs.ForeColor
        lblApmWaitMessage.ForeColor = cs.ForeColor
        trkApm.BackColor = cs.BackColor
        'Standby
        tpAtaStandby.BackColor = cs.BackColor
        lblInfoStandby.ForeColor = cs.GrayedText
        lblStandbyValue.ForeColor = cs.ForeColor
        lblStandbyWaitMessage.ForeColor = cs.ForeColor
        'ATA read/write options
        tpAtaReadWrite.BackColor = cs.BackColor
        lblAdminOther.ForeColor = cs.GrayedText
        For Each c In flwOtherFeatures.Controls
            If c.Tag = "Grayed" Then
                c.ForeColor = cs.GrayedText
            Else
                c.ForeColor = cs.ForeColor
            End If
        Next
        lblWaitRWMessage.ForeColor = cs.ForeColor
        'ATA errors
        tpAtaErrors.BackColor = cs.BackColor
        lblAdminErrors.ForeColor = cs.GrayedText
        lblErrLogVer.ForeColor = cs.ForeColor
        lblErrorLog.ForeColor = cs.ForeColor
        For Each c In tlpErrorDescription.Controls
            If c.Tag = "Grayed" Then
                c.ForeColor = cs.GrayedText
            Else
                c.ForeColor = cs.ForeColor
            End If
        Next
        For Each c In tlpErrorDetail.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.ForeColor
            End If
        Next
        'ATA tests
        tpAtaTests.BackColor = cs.BackColor
        lblAdminTests.ForeColor = cs.GrayedText
        lblSelfTests.ForeColor = cs.GrayedText
        lblNoSelfTests.ForeColor = cs.ForeColor
        lvwSelfTest.BackColor = cs.BackColor
        lvwSelfTest.ForeColor = cs.ForeColor
        lblSelective.ForeColor = cs.GrayedText
        lblNoSelective.ForeColor = cs.ForeColor
        lvwSelective.BackColor = cs.BackColor
        lvwSelective.ForeColor = cs.ForeColor
        'ATA run test
        tpAtaRunTest.BackColor = cs.BackColor
        lblInfoTest.ForeColor = cs.GrayedText
        lblSelectTest.ForeColor = cs.ForeColor
        lblDuration.ForeColor = cs.ForeColor
        lblTestInfo.ForeColor = cs.GrayedText
        lblTestInfo.BackColor = cs.BackColor
        lblProgress.ForeColor = cs.ForeColor
        lblExtimatedEnd.ForeColor = cs.ForeColor
        'SCSI errors
        tpScsiErrors.BackColor = cs.BackColor
        lblScsiNoErrors.ForeColor = cs.ForeColor
        tvwScsiErrors.BackColor = cs.BackColor
        tvwScsiErrors.ForeColor = cs.ForeColor
        'SCSI tests
        tpScsiTests.BackColor = cs.BackColor
        lblScsiTestCounter.ForeColor = cs.ForeColor
        lvwScsiTests.BackColor = cs.BackColor
        lvwScsiTests.ForeColor = cs.ForeColor
        'SCSI run test
        tpScsiRunTest.BackColor = cs.BackColor
        lblScsiInfoTest.ForeColor = cs.GrayedText
        lblScsiTest.ForeColor = cs.ForeColor
        lblScsiProgress.ForeColor = cs.ForeColor
        lblScsiExtimatedEnd.ForeColor = cs.ForeColor
        'Smartctl output
        tpOutput.BackColor = cs.BackColor
        txtReport.BackColor = cs.BackColor
        txtReport.ForeColor = cs.ForeColor
        'Advanced
        tpAdvanced.BackColor = cs.BackColor
        lblAdminAdvanced.ForeColor = cs.GrayedText
        lblPowerInfo.ForeColor = cs.GrayedText
        chkPowerMode.ForeColor = cs.ForeColor
        For Each c In flwPowerMode.Controls
            If c.Tag = "Grayed" Then
                c.ForeColor = cs.GrayedText
            Else
                c.ForeColor = cs.ForeColor
            End If
        Next
        lblRemapInfo.ForeColor = cs.GrayedText
        chkAttributes.ForeColor = cs.ForeColor
        lvwAttrFormat.BackColor = cs.BackColor
        lvwAttrFormat.ForeColor = cs.ForeColor
        lblFirmwareDebugInfo.ForeColor = cs.GrayedText
        chkFirmware.ForeColor = cs.ForeColor
        For Each c In flwFirmware.Controls
            If c.Tag = "Grayed" Then
                c.ForeColor = cs.GrayedText
            Else
                c.ForeColor = cs.ForeColor
            End If
        Next
        '************ System ************
        tlpWmiMenuItems.BackColor = cs.RibbonToolbarBackColor
        lblLoadWmi.ForeColor = cs.ForeColor
        tvwComputer.BackColor = cs.BackColor
        tvwComputer.ForeColor = cs.ForeColor
        pnlWmiInfo.BackColor = cs.StatusBarBackColor
        For Each c In tlpWmiDetails.Controls
            If c.Tag = "Grayed" Then
                c.ForeColor = cs.GrayedText
            Else
                c.ForeColor = cs.ForeColor
            End If
        Next
        '************ Debug ************
        tlpDebugMenu.BackColor = cs.RibbonToolbarBackColor
        lvwProgLog.BackColor = cs.BackColor
        lvwProgLog.ForeColor = cs.ForeColor

    End Sub
End Class

