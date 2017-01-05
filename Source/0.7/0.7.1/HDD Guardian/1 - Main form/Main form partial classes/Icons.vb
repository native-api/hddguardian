'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.IO

Partial Class Main
    Public imlDevice As New ImageList
    Public imlAttr As New ImageList
    Public imlLog As New ImageList
    Public imlTask As New ImageList

    Private Sub LoadIcons()
        On Error Resume Next

        Dim iconsfolder As String = My.Application.Info.DirectoryPath & "\graphics\icons\"
        Dim pichelp As Image = Image.FromFile(iconsfolder & "help.png")

        picAdmin.Image = Image.FromFile(iconsfolder & "exclamation.png")
        picNewVersion.Image = Image.FromFile(iconsfolder & "new.png")

        '****************
        '*** overview ***
        '****************
        mrbUpdateAll.Icon = Image.FromFile(iconsfolder & "device-update.png")
        mrbRescanUsb.Icon = Image.FromFile(iconsfolder & "usb-search.png")
        mrbAddVirtual.Icon = Image.FromFile(iconsfolder & "drive-add.png")
        mrcSidePanel.Icon = Image.FromFile(iconsfolder & "sidebar.png")
        'help
        picOverviewHelp.Image = pichelp

        '*************
        '*** debug ***
        '*************
        mrbDebugSave.Icon = Image.FromFile(iconsfolder & "save.png")
        mrbDebugClean.Icon = Image.FromFile(iconsfolder & "bin.png")

        '********************
        '*** test planner ***
        '********************
        mrbTaskNew.Icon = Image.FromFile(iconsfolder & "task-add.png")
        mrbTaskEdit.Icon = Image.FromFile(iconsfolder & "task-edit.png")
        mrbTaskDelete.Icon = Image.FromFile(iconsfolder & "task-delete.png")
        mrbTaskTrash.Icon = Image.FromFile(iconsfolder & "bin.png")

        '*****************************
        '*** manage ribbon buttons ***
        '*****************************
        'help
        picManageHelp.Image = pichelp

        '************************
        '*** device selection ***
        '************************
        mrbLeft.Icon = Image.FromFile(iconsfolder & "navigation-left.png")
        mrbLeft.MaximumSize = New Size(24, 24)
        mrbLeft.MinimumSize = New Size(24, 24)
        mrbRight.Icon = Image.FromFile(iconsfolder & "navigation-right.png")
        mrbRight.MaximumSize = New Size(24, 24)
        mrbRight.MinimumSize = New Size(24, 24)
        mrbReloadDevice.Image = Image.FromFile(iconsfolder & "update.png")
        mrbReloadDevice.MaximumSize = New Size(24, 24)
        mrbReloadDevice.MinimumSize = New Size(24, 24)

        '************************
        '*** advanced section ***
        '************************
        Dim advImgList As New ImageList
        With advImgList
            .ColorDepth = ColorDepth.Depth32Bit
            .Images.Add(Image.FromFile(iconsfolder & "format.png"))
            .Images.Add(Image.FromFile(iconsfolder & "debug.png"))
            .Images.Add(Image.FromFile(iconsfolder & "powermode.png"))
            .Images.Add(My.Resources.asmedia)
        End With
        tabAdvanced.ImageList = advImgList
        tpRemap.ImageIndex = 0
        tpFirmware.ImageIndex = 1
        tpPower.ImageIndex = 2
        tpAsmedia.ImageIndex = 3

        '****************************
        '*** events log and chart ***
        '****************************
        'log
        btnReload.Image = Image.FromFile(iconsfolder & "update.png")
        btnExport.Image = Image.FromFile(iconsfolder & "export.png")
        With imlLog
            .ImageSize = New Size(16, 16)
            .ColorDepth = ColorDepth.Depth32Bit
            .Images.Clear()
            .Images.Add("ok", Image.FromFile(iconsfolder & "status_good.png"))
            .Images.Add("warning", Image.FromFile(iconsfolder & "status_bad.png"))
        End With

        '**********************
        '*** advanced panel ***
        '**********************
        imlAttr.ColorDepth = ColorDepth.Depth32Bit
        With imlAttr.Images
            .Clear()
            .Add("never", My.Resources.failed_never)
            .Add("inthepast", My.Resources.failed_inthepast)
            .Add("now", My.Resources.failed_now)
            .Add("warning", My.Resources.failed_warning)
            .Add("unknown", My.Resources.failed_unknown)
        End With

        '********************
        '*** task planner ***
        '********************
        mrbTaskNew.Icon = Image.FromFile(iconsfolder & "task-add.png")
        mrbTaskEdit.Icon = Image.FromFile(iconsfolder & "task-edit.png")
        mrbTaskDelete.Icon = Image.FromFile(iconsfolder & "task-delete.png")
        mrbTaskTrash.Icon = Image.FromFile(iconsfolder & "bin.png")
        With imlTask
            .ColorDepth = ColorDepth.Depth32Bit
            .Images.Clear()
            .Images.Add("task", Image.FromFile(iconsfolder & "task.png"))
        End With
        picPlannerHelp.Image = pichelp

        '***********************
        '*** settings window ***
        '***********************
        With SettingsForm
            .btnExport.Image = Image.FromFile(iconsfolder & "settings-export.png")
            .btnImport.Image = Image.FromFile(iconsfolder & "settings-import.png")
            'warning
            .picNeedRestart.Image = Image.FromFile(iconsfolder & "exclamation.png")
            .picNeedRestartControllers.Image = Image.FromFile(iconsfolder & "exclamation.png")
            .picForce.Image = Image.FromFile(iconsfolder & "exclamation.png")
            .picLessSecure.Image = Image.FromFile(iconsfolder & "exclamation.png")
            'help icons
            .picHelpSetupGeneral.Image = pichelp
            .picHelpSetupDetection.Image = pichelp
            .picHelpSetupTranslation.Image = pichelp
            .picHelpSetupUpdate.Image = pichelp
            .picHelpSetupMonitoring.Image = pichelp
            .picHelpSetupWarnings.Image = pichelp
            .picHelpSetupShare.Image = pichelp
            .picHelpSetupRating.Image = pichelp
            .picHelpSetupMailAlerts.Image = pichelp
            .picHelpSetupTolerance.Image = pichelp
            .picHelpSetupControllers.Image = pichelp
            .picHelpSetupSmartctl.Image = pichelp
        End With

        '**************
        '*** system ***
        '**************
        imlDevice.Images.Clear()
        imlDevice.ColorDepth = ColorDepth.Depth32Bit
        imlDevice.Images.Add("pie", Image.FromFile(iconsfolder & "pie.png"))
        imlDevice.Images.Add("windrive", My.Resources.drive)
        imlDevice.Images.Add("pc", Image.FromFile(iconsfolder & "monitor.png"))
        mrbRefresh.Icon = Image.FromFile(iconsfolder & "update.png")
        picWmiDevicesHelp.Image = pichelp
        picBios.Image = Image.FromFile(iconsfolder & "hrw-bios.png")
        picMotherboard.Image = Image.FromFile(iconsfolder & "hrw-motherboard.png")
        picProcessor.Image = Image.FromFile(iconsfolder & "hrw-cpu.png")
        picRam.Image = Image.FromFile(iconsfolder & "hrw-ram.png")
        picVideoCard.Image = Image.FromFile(iconsfolder & "hrw-video_card.png")
        picDisk.Image = My.Resources.device_disk
        picPartition.Image = My.Resources.device_partition
        picLogical.Image = My.Resources.device_disk
        picNoBench.Image = Image.FromFile(iconsfolder & "exclamation.png")
        picBenchInfo.Image = Image.FromFile(iconsfolder & "information.png")

        '*********************
        '*** debug buttons ***
        '*********************
        mrbDebugSave.Icon = Image.FromFile(iconsfolder & "save.png")
        mrbDebugClean.Icon = Image.FromFile(iconsfolder & "bin.png")
    End Sub

End Class
