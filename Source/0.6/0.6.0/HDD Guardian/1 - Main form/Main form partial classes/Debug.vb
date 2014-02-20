'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Partial Class Main

    Public Sub PrintDebug(ByVal msg As String, Optional ByVal iserror As Boolean = False, Optional ByVal important As Boolean = False)

        With lvwProgLog
            .Items.Add(Now)
            .Items(.Items.Count - 1).SubItems.Add(msg)
            If iserror Then .Items(.Items.Count - 1).ForeColor = Color.Red
            If important Then .Items(.Items.Count - 1).ForeColor = Color.Blue
        End With

        If on_debug Or savedebug Then

            Dim strtoprint As String = String.Format("{0:D2}", Now.Hour) & ":" & _
                            String.Format("{0:D2}", Now.Minute & ":" & _
                            String.Format("{0:D2}", Now.Second) & "." & _
                            String.Format("{0:D3}", Now.Millisecond) & " - " & _
                            msg & vbCrLf)

            If on_debug Then DebugWindow.txtDebug.AppendText(strtoprint)

            If savedebug Then
                Dim folder As String = My.Computer.FileSystem.SpecialDirectories.Desktop
                IO.File.AppendAllText(folder & "\hddguardian_debug.txt", strtoprint)
            End If
        End If
    End Sub

End Class
