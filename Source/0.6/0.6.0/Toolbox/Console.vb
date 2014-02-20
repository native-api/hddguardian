'Toolbox is a tool for solving some HDD Guardian issues with unknown devices
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Public Class Console
    Private WithEvents Cmd As Process

    Public Function SendCmd(ByVal command As String) As String
        Dim output As String
        'Dim lines() As String

        Cmd = New Process

        'setup for hidden command window
        If System.Environment.OSVersion.Version.Major > 6 Then 'Win Vista or higher
            Cmd.StartInfo.Verb = "runas" 'start process as admin
        End If
        Cmd.StartInfo.RedirectStandardInput = True
        Cmd.StartInfo.RedirectStandardOutput = True
        Cmd.StartInfo.UseShellExecute = False 'required to redirect
        Cmd.StartInfo.CreateNoWindow = True 'this command avoid the creation of window
        Cmd.StartInfo.FileName = "cmd" 'the command window interpreter
        Cmd.StartInfo.WorkingDirectory = My.Application.Info.DirectoryPath & "\smartctl" 'set working folder

        Cmd.Start() 'start hidden command window from current folder
        Cmd.StandardInput.WriteLine("smartctl " & command) 'write command to cmd window
        'for a general purpose use remove '"smartctl " &' from the previous row

        'Dim output As String = Cmd.StandardOutput.ReadToEnd

        'Debug.Print(output)

        Cmd.StandardInput.WriteLine("exit") 'exit from cmd window
        'lines = Cmd.StandardOutput.ReadToEnd.Split(vbCrLf) 'load output into an array

        output = Cmd.StandardOutput.ReadToEnd
        Cmd.Close() 'release the resources

        'copy the "lines" array into the "output" array, excluding the first 4 lines of
        'standard output (OS info and the command sent by this function) and the last
        'line (where is sent the DOS command "exit")
        'ReDim output(lines.Length - 7) 'expand the output array
        'Array.ConstrainedCopy(lines, 4, output, 0, lines.Length - 7)

        Return output 'return the "output" array

        Cmd.Kill()
    End Function
End Class
