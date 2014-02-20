'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class NewLink
    Inherits LinkLabel

    Public Sub New()
        MyBase.LinkColor = Color.FromArgb(0, 102, 204)
        MyBase.ActiveLinkColor = Color.FromArgb(51, 153, 255)
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

    Public Sub New()
        MyBase.BackColor = Color.Silver
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