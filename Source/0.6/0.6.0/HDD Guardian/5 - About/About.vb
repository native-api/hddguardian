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

Public Class About

    Private Sub ExternalLink(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles _
        lnkHddGuardian.LinkClicked, _
        lnkGoogleCode.LinkClicked, lnkCodePlex.LinkClicked, lnkGroup.LinkClicked, lnkEmail.LinkClicked, lnkPlus.LinkClicked, _
        lnkSmartMonTools.LinkClicked, lnkGpl.LinkClicked, _
        lnkKamiyamane.LinkClicked, lnkCcBy.LinkClicked, _
        lnkOxygen.LinkClicked, lnkLgplOxygen.LinkClicked, _
        lnkCrystal.LinkClicked, lnkEveraldo.LinkClicked, lnkLgplCrystal.LinkClicked, _
        lnkOpenClipart.LinkClicked, _
        lnkBrandsOfTheWorld.LinkClicked, _
        lnkWesternDigital.LinkClicked, _
        lnkCoolerMaster.LinkClicked, _
        lnkOxygen2.LinkClicked

        Try
            System.Diagnostics.Process.Start(sender.Tag)
        Catch ex As Exception
            Main.PrintDebug("External link error: " & ex.ToString, True)
        End Try
    End Sub
End Class