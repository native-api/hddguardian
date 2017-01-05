'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
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
        tpOverview.BackColor = cs.BackColor
        tlpMenuItems.BackColor = cs.RibbonToolbarBackColor
        lvwDevices.BackColor = cs.BackColor
        lvwDevices.ForeColor = cs.ForeColor
        tlpMessages.BackColor = cs.BackColor
        'side panel
        For Each c In tlpGeneral.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                ElseIf c.tag = "Title" Then
                    c.ForeColor = cs.GroupText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            End If
        Next
        For Each c In tlpGeneralInfo.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            ElseIf c.GetType.Name = "ExtendedLabel" Then
                c.ForeColor = cs.GrayedText
            End If
        Next
        For Each c In tlpHealth.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                ElseIf c.tag = "Title" Then
                    c.ForeColor = cs.GroupText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            End If
        Next
        For Each c In tlpSummary.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            End If
        Next
        For Each c In tlpRatingTable.Controls
            If c.GetType.Name = "Label" Then
                If c.Tag = "Grayed" Then
                    c.ForeColor = cs.GrayedText
                Else
                    c.ForeColor = cs.ForeColor
                End If
            End If
        Next

        '************ Manage ************
        tpManage.BackColor = cs.BackColor
        pnlComboBorder.BackColor = cs.HorizontalLine
        cboDevices.BackColor = cs.BackColor
        cboDevices.ForeColor = cs.ForeColor
        tlpSelDevice.BackColor = cs.RibbonToolbarBackColor
        tlpManageMenuContent.BackColor = cs.RibbonToolbarBackColor
        tlpSideMenu.BackColor = cs.BackColor
        For Each c In tlpSideMenu.Controls
            If c.GetType.Name = "Label" Then
                c.ForeColor = cs.GrayedText
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
        'Events log
        lvwEvents.ForeColor = cs.ForeColor
        lvwEvents.BackColor = cs.BackColor
        'Events chart
        tpEvents.BackColor = cs.BackColor
        lblNoEvents.ForeColor = cs.ForeColor
        lvwLog.ForeColor = cs.ForeColor
        lvwLog.BackColor = cs.BackColor
        mcLog.BackColor = cs.BackColor
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
        lblErrLogVer.ForeColor = cs.GrayedText
        lblNoError.ForeColor = cs.ForeColor
        'ATA tests
        tpAtaTests.BackColor = cs.BackColor
        lblSelfTests.ForeColor = cs.GrayedText
        lblNoSelfTests.ForeColor = cs.ForeColor
        lvwSelfTest.BackColor = cs.BackColor
        lvwSelfTest.ForeColor = cs.ForeColor
        'ATA run test
        tpAtaRunTest.BackColor = cs.BackColor
        lblInfoTest.ForeColor = cs.GrayedText
        lblProgress.ForeColor = cs.ForeColor
        lblExtimatedEnd.ForeColor = cs.ForeColor
        'SCSI errors
        tpScsiErrors.BackColor = cs.BackColor
        lblScsiNoErrors.ForeColor = cs.ForeColor
        lvwScsiErrors.BackColor = cs.BackColor
        lvwScsiErrors.ForeColor = cs.ForeColor
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
        tlpSystem.BackColor = cs.BackColor
        For Each c In tlpHrwDetails.Controls
            If c.Tag = "Group" Then
                c.ForeColor = cs.GroupText
            Else
                c.ForeColor = cs.ForeColor
            End If
        Next
        '************ Debug ************
        tlpDebugMenu.BackColor = cs.RibbonToolbarBackColor
        lvwProgLog.BackColor = cs.BackColor
        lvwProgLog.ForeColor = cs.ForeColor
        '************ Task planner ************
        tlpTask.BackColor = cs.RibbonToolbarBackColor

    End Sub
End Class

