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

Public Class Console
    Private WithEvents Cmd As Process

    Public Function SendCmd(ByVal command As String) As String()
        Dim output() As String
        Dim lines() As String

        Main.PrintDebug("Calling smartctl with options '" & command & "'")

        Cmd = New Process

        'setup for hidden command window
        Cmd.StartInfo.RedirectStandardInput = True
        Cmd.StartInfo.RedirectStandardOutput = True
        Cmd.StartInfo.UseShellExecute = False 'required to redirect, but this can't enable to set admin rigths to smartctl!
        Cmd.StartInfo.CreateNoWindow = True 'this command avoid the creation of window
        Cmd.StartInfo.FileName = "cmd" 'the command window interpreter
        Cmd.StartInfo.WorkingDirectory = My.Application.Info.DirectoryPath & "\smartctl" 'set working folder

        'If System.Environment.OSVersion.Version.Major >= 6 Then 'Win Vista or higher
        'Cmd.StartInfo.Verb = "runas" 'start process as admin, but fails because UseShellExecute=False
        'End If

        Cmd.Start() 'start hidden command window from current folder
        Cmd.StandardInput.WriteLine("smartctl " & command) 'write command to cmd window
        'for a general purpose use remove '"smartctl " &' from the previous row
        Cmd.StandardInput.WriteLine("exit") 'exit from cmd window
        lines = Cmd.StandardOutput.ReadToEnd.Split(vbCrLf) 'load output into an array

        Cmd.Close() 'release the resources

        'copy the "lines" array into the "output" array, excluding the first 4 lines of
        'standard output (OS info and the command sent by this function) and the last
        'line (where is sent the DOS command "exit")
        ReDim output(lines.Length - 7) 'expand the output array
        Array.ConstrainedCopy(lines, 4, output, 0, lines.Length - 7)

        Return output 'return the "output" array

        Cmd.Kill()
    End Function
End Class
