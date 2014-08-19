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

    'from version 0.5.0 tray icons are coded into each device, with exclusions of images

    Public Class Icons
        Inherits List(Of Icon)
    End Class

    Public celsius_good As New Icons
    Public celsius_bad As New Icons
    Public fahrenheit_good As New Icons
    Public fahrenheit_bad As New Icons
    Public ssd_good As New Icons
    Public ssd_bad As New Icons
    Public unknown As Icon


    Public Sub LoadTrayIcons()
        Dim celsius As Bitmap = My.Resources.devices_tray_icons

        For i As Short = 0 To 100
            Dim rect As New Rectangle(i * 16, 16, 16, 16)
            Dim geticon As IntPtr = celsius.Clone(rect, celsius.PixelFormat).GetHicon
            celsius_bad.Add(Icon.FromHandle(geticon))
        Next

        For i As Short = 0 To 100
            Dim rect As New Rectangle(i * 16, 0, 16, 16)
            Dim geticon As IntPtr = celsius.Clone(rect, celsius.PixelFormat).GetHicon
            celsius_good.Add(Icon.FromHandle(geticon))
        Next

        Dim rect_u As New Rectangle(101 * 16, 0, 16, 16)
        Dim geticon_u As IntPtr = celsius.Clone(rect_u, celsius.PixelFormat).GetHicon
        unknown = Icon.FromHandle(geticon_u)

        celsius.Dispose()

        Dim fahrenheit As Bitmap = My.Resources.devices_tray_icons_F

        For i As Short = 0 To 100
            Dim rect As New Rectangle(i * 16, 16, 16, 16)
            Dim geticon As IntPtr = fahrenheit.Clone(rect, fahrenheit.PixelFormat).GetHicon
            fahrenheit_bad.Add(Icon.FromHandle(geticon))
        Next

        For i As Short = 0 To 100
            Dim rect As New Rectangle(i * 16, 0, 16, 16)
            Dim geticon As IntPtr = fahrenheit.Clone(rect, fahrenheit.PixelFormat).GetHicon
            fahrenheit_good.Add(Icon.FromHandle(geticon))
        Next

        fahrenheit.Dispose()

        Dim ssd As Bitmap = My.Resources.ssd_tray_icons

        For i As Short = 0 To 101
            Dim rect As New Rectangle(i * 16, 16, 16, 16)
            Dim geticon As IntPtr = ssd.Clone(rect, ssd.PixelFormat).GetHicon
            ssd_bad.Add(Icon.FromHandle(geticon))
        Next

        For i As Short = 0 To 101
            Dim rect As New Rectangle(i * 16, 0, 16, 16)
            Dim geticon As IntPtr = ssd.Clone(rect, ssd.PixelFormat).GetHicon
            ssd_good.Add(Icon.FromHandle(geticon))
        Next

        ssd.Dispose()
    End Sub

End Class
