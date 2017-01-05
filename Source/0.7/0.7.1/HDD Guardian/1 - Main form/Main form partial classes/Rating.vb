'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Partial Class Main

    Public Function GetRatingImage(ByVal i As Short) As Bitmap
        Dim curdevice As Device = devlist(i)

        If curdevice.Health = Status.Failed Then Return My.Resources.rating_1

        If AppSettings.Reliability.Enable Then
            If curdevice.Smart.IsEnabled <> Support.Enabled _
                        Or (curdevice.Type = DeviceType.ThreeWare And Not curdevice.IsValid) Then
                Return My.Resources.rating_0
            ElseIf curdevice.Type = DeviceType.SCSI Then
                Select Case curdevice.Scsi.Reliability.Overall
                    Case 5
                        Return My.Resources.rating_5
                    Case 4
                        Return My.Resources.rating_4
                    Case 3
                        Return My.Resources.rating_3
                    Case 2
                        Return My.Resources.rating_2
                    Case 1
                        Return My.Resources.rating_1
                    Case 0
                        Return My.Resources.rating_0
                    Case Else
                        If curdevice.Health = Status.Failed Then
                            Return My.Resources.rating_1
                        Else
                            Return My.Resources.rating_5
                        End If
                End Select
            Else
                Select Case curdevice.ATA.Reliability.Overall
                    Case 5
                        Return My.Resources.rating_5
                    Case 4
                        Return My.Resources.rating_4
                    Case 3
                        Return My.Resources.rating_3
                    Case 2
                        Return My.Resources.rating_2
                    Case 1
                        Return My.Resources.rating_1
                    Case 0
                        Return My.Resources.rating_0
                    Case Else
                        If curdevice.Health = Status.Failed Then
                            Return My.Resources.rating_1
                        Else
                            Return My.Resources.rating_5
                        End If
                End Select
            End If
        Else
            If curdevice.Health = Status.Failed Then
                Return My.Resources.rating_1
            Else
                Return My.Resources.rating_5
            End If
        End If
    End Function

End Class
