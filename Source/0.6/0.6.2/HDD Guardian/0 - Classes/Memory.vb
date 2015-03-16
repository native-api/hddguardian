'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2015 Samuele Parise
'
'I've found this routine on AddressOf.com site, and if executed,
'it removes the unused memory of application, setting the used
'memory around a size of 600k!
'Since on AddressOf.com I've not found any informations about code license
'I've removed the previous GPL 2.0 license notice.

Public Class Memory

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" ( _
      ByVal process As IntPtr, _
      ByVal minimumWorkingSetSize As Integer, _
      ByVal maximumWorkingSetSize As Integer) As Integer

    Public Shared Sub FlushMemory()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
            'Main.PrintDebug("Removing HDD Guardian unused memory (RAM)", False, True)
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
        End If
    End Sub

End Class
