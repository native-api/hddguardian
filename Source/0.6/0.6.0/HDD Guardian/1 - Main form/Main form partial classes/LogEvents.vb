'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Xml

Public Structure OldLogItem
    Dim Device, Year, Month, Day, Hour, EventName, OldValue, NewValue, Variation As String
End Structure

Class OldLogItems
    Inherits List(Of OldLogItem)
End Class

Partial Class Main

    Dim logpath As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData. _
        Substring(0, My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.LastIndexOf("\")) & "\logs\"

    Dim oldlog As New OldLogItems

End Class
