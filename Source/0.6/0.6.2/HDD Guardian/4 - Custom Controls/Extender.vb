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

Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class NewLink
    Inherits LinkLabel

    Declare Unicode Function IsThemeActive Lib "uxtheme" () As Boolean

    Public Sub New()
        If IsThemeActive Then
            MyBase.LinkColor = Color.FromArgb(0, 102, 204)
            MyBase.ActiveLinkColor = Color.FromArgb(51, 153, 255)
        Else
            MyBase.LinkColor = Color.FromKnownColor(KnownColor.HotTrack)
            MyBase.ActiveLinkColor = Color.FromKnownColor(KnownColor.Highlight)
        End If
        MyBase.LinkBehavior = Windows.Forms.LinkBehavior.HoverUnderline
    End Sub

    Private Sub M_Enter() Handles MyBase.MouseEnter
        MyBase.LinkColor = Color.FromArgb(51, 153, 255)
    End Sub

    Private Sub M_Leave() Handles MyBase.MouseLeave
        MyBase.LinkColor = Color.FromArgb(0, 102, 204)
    End Sub

End Class

Public Class ExtendedLabel
    Inherits System.Windows.Forms.Label

    Dim ata_txt
    Public Property AtaText As String
        Get
            Return ata_txt
        End Get
        Set(value As String)
            ata_txt = value
        End Set
    End Property

    Dim scsi_txt
    Public Property ScsiText As String
        Get
            Return scsi_txt
        End Get
        Set(value As String)
            scsi_txt = value
        End Set
    End Property
End Class

Public Class HorizontalLine
    Inherits PictureBox
    Declare Unicode Function IsThemeActive Lib "uxtheme" () As Boolean
    Public Sub New()
        If IsThemeActive Then
            MyBase.BackColor = Color.Silver
        Else
            MyBase.BackColor = Color.FromKnownColor(KnownColor.WindowFrame)
        End If
        MyBase.Height = 1
        MyBase.Margin = New Padding(3, 9, 3, 9)
        MyBase.MaximumSize = New Size(0, 1)
    End Sub
End Class

Public Class FlatProgressBar
    Inherits Windows.Forms.Panel

    Dim picValue As New PictureBox
    Dim c As Color
    Dim curvalue As Integer

    Public Sub New()
        MyBase.BackColor = Color.FromArgb(188, 188, 188)
        MyBase.Padding = New Padding(1)
        MyBase.Width = 255
        MyBase.Height = 13

        Dim pnlBack As New Windows.Forms.Panel
        pnlBack.Parent = Me
        pnlBack.Dock = DockStyle.Fill
        pnlBack.BackColor = Color.FromArgb(230, 230, 230)

        curvalue = 50
        c = Color.FromArgb(30, 168, 218)

        picValue.Parent = pnlBack
        picValue.Dock = DockStyle.Left
        picValue.Width = curvalue
        picValue.BackColor = c
    End Sub

    Private Sub RePaint() Handles MyBase.SizeChanged
        If curvalue = 0 Then picValue.Width = 0 Else picValue.Width = (Me.Width - 2) / (253 / (curvalue + 1))
    End Sub

    Public Property Value As Integer
        Get
            Return curvalue
        End Get
        Set(value As Integer)
            If value > 253 Then value = 253
            If value < 0 Then value = 0
            curvalue = value

            If curvalue = 0 Then picValue.Width = 0 Else picValue.Width = (Me.Width - 2) / (253 / (curvalue + 1))
        End Set
    End Property

    Public Property Barcolor As Color
        Get
            Return c
        End Get
        Set(value As Color)
            c = value
            picValue.BackColor = c
        End Set
    End Property

End Class

Public Class TemperaturesBar
    Inherits Windows.Forms.Panel

    Dim picValue, picZero As New PictureBox
    Dim c As Color
    Dim m_minvalue, m_maxvalue As Integer

    Public Sub New()
        MyBase.BackColor = Color.FromArgb(188, 188, 188)
        MyBase.Padding = New Padding(1)
        MyBase.Width = 402
        MyBase.Height = 13

        Dim pnlBack As New Windows.Forms.Panel
        pnlBack.Parent = Me
        pnlBack.Dock = DockStyle.Fill
        pnlBack.BackColor = Color.FromArgb(230, 230, 230)

        m_minvalue = -50
        m_maxvalue = 50
        c = Color.FromArgb(30, 168, 218)

        picValue.Parent = pnlBack
        picValue.Dock = DockStyle.None
        picValue.Left = 200 + m_minvalue * 2
        picValue.Width = m_maxvalue * 2 - m_minvalue * 2
        picValue.Height = 11
        picValue.BackColor = c

        picZero.Parent = pnlBack
        picZero.BringToFront()
        picZero.Left = 200
        picZero.Width = 1
        picZero.Height = 11
        picZero.BackColor = Color.DimGray
    End Sub

    Public Sub SetTemperatures(ByVal TempMin As Integer, ByVal TempMax As Integer)
        Dim min, max As Integer

        min = TempMin
        If TempMin > 200 Then min = 200
        If TempMin < -100 Then min = -100
        m_minvalue = min

        max = TempMax
        If TempMax > 200 Then max = 200
        If TempMax < -100 Then max = -100
        m_maxvalue = max

        picValue.Visible = False
        picValue.Left = 200 + min * 2
        picValue.Width = max * 2 - min * 2
        If picValue.Width = 0 Then picValue.Width = 1
        picValue.Visible = True
    End Sub

    Public Property Barcolor As Color
        Get
            Return c
        End Get
        Set(value As Color)
            c = value
            picValue.BackColor = c
        End Set
    End Property

End Class

