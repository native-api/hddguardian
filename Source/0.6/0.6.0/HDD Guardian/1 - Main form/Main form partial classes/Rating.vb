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

    Public Sub SetRating()
        If lvwDevices.Items.Count = 0 Then Exit Sub

        Dim curdevice As Device = devlist(lvwDevices.SelectedItems(0).Index)

        picReliability.Image = Nothing
        If Not My.Settings.EnableRating Then
            picReliability.Visible = False
            lblReliability.Visible = False
            Exit Sub
        Else
            picReliability.Visible = True
            lblReliability.Visible = True
        End If


        If curdevice.IsScsi Or curdevice.SmartEnabled <> Support.Enabled Then
            picReliability.Image = My.Resources.r0_star
        Else
            Dim rel As String = 0

            Select Case curdevice.ReliabilityRating.Overall
                Case 5
                    picReliability.Image = My.Resources.r5_star
                Case 4
                    picReliability.Image = My.Resources.r4_star
                Case 3
                    picReliability.Image = My.Resources.r3_star
                Case 2
                    picReliability.Image = My.Resources.r2_star
                Case 1
                    picReliability.Image = My.Resources.r1_star
                Case 0
                    picReliability.Image = My.Resources.r0_star
                Case Else
                    picReliability.Image = My.Resources.r0_star
            End Select
        End If
    End Sub

End Class
