'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2015 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Public Class HeadlessTabControl
    Inherits TabControl

    Protected Overrides Sub WndProc(ByRef m As Message)
        'hide tabs intercepting the TCM_ADJUSTRECT (&H1328) message
        If m.Msg = &H1328 AndAlso Not DesignMode Then
            m.Result = CType(1, IntPtr)
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Dim blocked As Boolean = True

    Protected Overrides Sub OnSelecting(e As TabControlCancelEventArgs)
        'suppress the CTRL+TAB to select another panel during runtime
        If Not DesignMode Then e.Cancel = blocked
    End Sub

    Public Overloads Sub SelectPage(ByVal i As Integer)
        blocked = False
        Me.SelectTab(i)
        blocked = True
    End Sub

    Public Overloads Sub SelectPage(ByVal p As TabPage)
        blocked = False
        Me.SelectTab(p)
        blocked = True
    End Sub
End Class
