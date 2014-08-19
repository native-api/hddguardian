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

Partial Class Main
    Sub CheckForUpdates()
        'this sub check for HDD Guardian new versions...

        If My.Settings.CheckUpdates = True Then
            Try
                Dim version As String
                Dim sr As IO.StreamReader
                Dim wc As New Net.WebClient()

                sr = New IO.StreamReader(wc.OpenRead("https://hddguardian.svn.codeplex.com/svn/version.txt"))

                version = sr.ReadToEnd

                Dim last() As String = version.Split(".")
                Dim curr() As String = My.Application.Info.Version.ToString.Split(".")
                Dim diff As Short = (last(0) * 1000 + last(1) * 100 + last(2) * 10) - _
                                    (curr(0) * 1000 + curr(1) * 100 + curr(2) * 10)
                If diff <= 0 Then
                    picNewVersion.Visible = False
                Else
                    picNewVersion.Visible = True
                    ttMain.SetToolTip(picNewVersion, picNewVersion.Tag.ToString.Remove("%", version))
                End If
            Catch
            End Try
        End If
    End Sub

End Class
