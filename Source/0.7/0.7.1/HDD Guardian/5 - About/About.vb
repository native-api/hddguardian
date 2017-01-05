'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Public Class About

    Private Sub ExternalLink(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles _
        lnkHddGuardian.LinkClicked, lnkCodePlex.LinkClicked,
        lnkSmartMonTools.LinkClicked, lnkGpl.LinkClicked,
        lnkKamiyamane.LinkClicked, lnkCcBy.LinkClicked,
        lnkOxygen.LinkClicked, lnkLgplOxygen.LinkClicked,
        lnkCrystal.LinkClicked, lnkEveraldo.LinkClicked, lnkLgplCrystal.LinkClicked,
        lnkOpenClipart.LinkClicked,
        lnkBrandsOfTheWorld.LinkClicked,
        lnkWesternDigital.LinkClicked,
        lnkCoolerMaster.LinkClicked,
        lnkOxygen2.LinkClicked,
        lnkDiskSpd.LinkClicked, lnkMit.LinkClicked,
        lnkFatCow.LinkClicked, lnkCcByUs.LinkClicked

        Try
            System.Diagnostics.Process.Start(sender.Tag)
        Catch ex As Exception
            Main.PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub

End Class