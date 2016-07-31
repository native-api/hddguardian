'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2016 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Management
Imports System.ComponentModel

Public Class RaidControllers
    Dim controllers As New Collection

    Public Sub Gather()
        Dim win32_scsicontroller As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_SCSIController")

        controllers.Clear()

        For Each contr As ManagementObject In win32_scsicontroller.Get()
            Main.PrintDebug("Adding installed SCSI controller(s) to the list...")
            If Not IsNothing(contr("Name")) Then
                Main.PrintDebug("Adding '" & contr("Name") & "'")
                controllers.Add(contr("Name").ToString.Trim)
            Else
                Main.PrintDebug("Skipping a value (null)")
            End If
        Next

        Main.PrintDebug("Detected " & controllers.Count & " SCSI controller(s)")
    End Sub

    Public ReadOnly Property ControllersCount
        Get
            If Not IsNothing(controllers) Then
                Return controllers.Count
            Else
                Return 0
            End If
        End Get
    End Property

    Public Function ControllerName(ByVal index As Short) As String
        If Not IsNothing(controllers) Then
            Return controllers(index + 1) 'collections items starts from 1, not 0
        Else
            Return Nothing
        End If
    End Function

End Class
