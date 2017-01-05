'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Public Class Console
    Private WithEvents Cmd As Process

    Public Sub Shutdown(ByVal command As String)
        Cmd = New Process

        'setup for hidden command window
        Cmd.StartInfo.RedirectStandardInput = True
        Cmd.StartInfo.RedirectStandardOutput = True
        Cmd.StartInfo.UseShellExecute = False 'required to redirect
        Cmd.StartInfo.CreateNoWindow = False 'this command avoid the creation of window
        Cmd.StartInfo.FileName = "cmd" 'the command window interpreter
        Cmd.Start() 'start hidden command window from current folder
        Cmd.StandardInput.WriteLine("shutdown " & command) 'write command to cmd window
        'for a general purpose use remove '"shutdown " &' from the previous row
        Cmd.StandardInput.WriteLine("exit") 'exit from cmd window
        Cmd.Close() 'release the resources
        Cmd.Dispose()
    End Sub

    Public Function Smartctl(ByVal command As String, Optional ByVal workingfolder As String = Nothing) As String()
        Dim output() As String
        Dim lines() As String

        Cmd = New Process

        'setup for hidden command window
        Cmd.StartInfo.RedirectStandardInput = True
        Cmd.StartInfo.RedirectStandardOutput = True
        Cmd.StartInfo.UseShellExecute = False 'required to redirect
        Cmd.StartInfo.CreateNoWindow = True 'this command avoid the creation of window
        Cmd.StartInfo.FileName = "cmd" 'the command window interpreter
        If IsNothing(workingfolder) Then 'set working folder
            Cmd.StartInfo.WorkingDirectory = My.Application.Info.DirectoryPath & "\smartctl"
            Main.PrintDebug("Calling bundled smartctl with options '" & command & "'")
        Else
            Cmd.StartInfo.WorkingDirectory = workingfolder
            Main.PrintDebug("Calling an alternative version of smartctl to check version")
        End If

        If AppSettings.Smartctl.AlternativeVersion Then
            If IO.Directory.Exists(AppSettings.Smartctl.ExecutableFolder) Then
                Cmd.StartInfo.WorkingDirectory = AppSettings.Smartctl.ExecutableFolder
                Main.PrintDebug("Calling an alternative version of smartctl with options '" & command & "'")
            End If
        End If

        Cmd.Start() 'start hidden command window from current folder
        Cmd.StandardInput.WriteLine("smartctl " & command) 'write command to cmd window
        'for a general purpose use remove '"smartctl " &' from the previous row
        Cmd.StandardInput.WriteLine("exit") 'exit from cmd window
        lines = Cmd.StandardOutput.ReadToEnd.Split(vbCrLf) 'load output into an array

        Cmd.Close() 'release the resources
        Cmd.Dispose()

        'copy the "lines" array into the "output" array, excluding the first 4 lines of
        'standard output (OS info and the command sent by this function) and the last
        'line (where is sent the DOS command "exit")
        Try
            ReDim output(lines.Length - 7) 'expand the output array
            Array.ConstrainedCopy(lines, 4, output, 0, lines.Length - 7)

            Return output 'return the "output" array
        Catch ex As Exception
            Dim txt As String = ""
            For i As Short = 0 To lines.Count - 1
                txt += lines(i) & vbCrLf
            Next

            MsgBox(txt, MsgBoxStyle.Critical, "Error")

            Return Nothing
        End Try

    End Function
End Class
