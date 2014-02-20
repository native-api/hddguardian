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

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonMenuItem
    Inherits System.Windows.Forms.Panel

    Dim WithEvents lbl As New Label
    Dim sel As Boolean = False

    Public Sub New()
        lbl.BackColor = Color.FromArgb(255, 255, 255)
        lbl.ForeColor = Color.Black
        lbl.Padding = New Padding(3, 6, 3, 6)
        lbl.Margin = New Padding(1)
        lbl.AutoSize = True
        lbl.Location = New Point(1, 1)

        MyBase.Controls.Add(lbl)
        MyBase.BackColor = Color.FromArgb(255, 255, 255)
        MyBase.Padding = New Padding(0)
        MyBase.Margin = New Padding(2)
        MyBase.AutoSize = True
        MyBase.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink

    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        lbl.BackColor = Color.FromArgb(245, 246, 247)
        Me.BackColor = Color.FromArgb(218, 219, 220)

        MyBase.OnClick(e)
    End Sub

    Private Sub LabelClick() Handles lbl.Click
        For Each Control In Parent.Controls
            If Control.GetType.Name = Me.GetType.Name Then Control.DeSelect()
        Next

        'MyBase.Padding = New Padding(1, 1, 1, 0)
        lbl.BackColor = Color.FromArgb(245, 246, 247)
        Me.BackColor = Color.FromArgb(218, 219, 220)
        'MyBase.BringToFront()

        Me.InvokeOnClick(Me, Nothing)
    End Sub

    Public Sub Deselect()
        lbl.BackColor = Color.FromArgb(255, 255, 255)
        Me.BackColor = Color.FromArgb(255, 255, 255)
        'MyBase.Padding = New Padding(1, 0, 1, 1)
    End Sub

    <System.ComponentModel.BrowsableAttribute(True)> _
    Public Overrides Property Text As String
        Get
            Return lbl.Text
        End Get
        Set(value As String)
            lbl.Text = value
        End Set
    End Property
End Class

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonFileItem
    Inherits System.Windows.Forms.Panel

    Dim WithEvents lbl As New Label
    Dim sel As Boolean = False

    Public Sub New()
        lbl.BackColor = Color.FromArgb(25, 121, 202)
        lbl.ForeColor = Color.White
        lbl.Padding = New Padding(3, 6, 3, 6)
        lbl.Margin = New Padding(1)
        lbl.AutoSize = True
        lbl.Location = New Point(1, 1)

        MyBase.Controls.Add(lbl)
        MyBase.BackColor = Color.FromArgb(25, 121, 202)
        MyBase.Padding = New Padding(0)
        MyBase.Margin = New Padding(2)
        MyBase.AutoSize = True
        MyBase.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
    End Sub

    Private Sub LabelClick() Handles lbl.Click
        Me.InvokeOnClick(Me, Nothing)
    End Sub

    <System.ComponentModel.BrowsableAttribute(True)> _
    Public Overrides Property Text As String
        Get
            Return lbl.Text
        End Get
        Set(value As String)
            lbl.Text = value
        End Set
    End Property
End Class

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonPlaceholder
    Inherits System.Windows.Forms.Panel

    Dim pic As New PictureBox

    Public Sub New()
        pic.BackColor = Color.FromArgb(255, 255, 255)
        pic.Dock = DockStyle.Fill

        MyBase.Controls.Add(pic)
        MyBase.BackColor = Color.FromArgb(255, 255, 255)
        MyBase.Padding = New Padding(0)
        MyBase.Margin = New Padding(0)
    End Sub
End Class

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonButton
    Inherits System.Windows.Forms.Panel

    Dim WithEvents icn As New PictureBox
    Dim WithEvents lbl As New Label
    Dim disabledimg, enabledimg As Image
    Dim chk As Boolean = False
    Dim mode As Style = Style.Small

    Enum Style
        Big = 0
        Small = 1
    End Enum

    Public Sub New()
        MyBase.BackColor = Color.FromArgb(245, 246, 247)
        MyBase.AutoSize = True
        MyBase.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink

        Me.MaximumSize = New Size(0, 0)

        'maximum height: 20 pixels

        With icn
            .Parent = Me
            .MinimumSize = New Size(18, 18)
            .MaximumSize = New Size(18, 18)
            .Margin = New Padding(1, 1, 0, 1)
            .SizeMode = PictureBoxSizeMode.CenterImage
            .Location = New Point(1, 1)
        End With

        With lbl
            .Parent = Me
            .AutoSize = True
            .MinimumSize = New Size(0, 18)
            .Margin = New Padding(0, 1, 1, 1)
            .Location = New Point(18, 1)
            .TextAlign = ContentAlignment.MiddleLeft
        End With
    End Sub

    <System.ComponentModel.DefaultValue(Style.Small)> _
    Public Property ButtonStyle As Style
        Get
            Return mode
        End Get
        Set(value As Style)
            mode = value

            If value = Style.Big Then
                Me.MaximumSize = New Size(100, 68)
                Me.MinimumSize = New Size(0, 68)

                'maximum size: height 68 px, width 100 px
                'is possible to place on right side three
                'buttons with small style

                With icn
                    .Parent = Me
                    .MinimumSize = New Size(34, 36)
                    .MaximumSize = New Size(98, 36)
                    .Margin = New Padding(1, 1, 1, 0)
                    .SizeMode = PictureBoxSizeMode.CenterImage
                    .Location = New Point(1, 1)
                End With

                With lbl
                    .Parent = Me
                    .AutoSize = True
                    .AutoEllipsis = True
                    .Margin = New Padding(1, 0, 1, 1)
                    .Location = New Point(1, 37)
                    .MinimumSize = New Size(34, 30)
                    .MaximumSize = New Size(98, 30)
                    .TextAlign = ContentAlignment.TopCenter
                End With
            Else
                Me.MaximumSize = New Size(0, 0)

                'maximum height: 20 pixels

                With icn
                    .Parent = Me
                    .MinimumSize = New Size(18, 18)
                    .MaximumSize = New Size(18, 18)
                    .Margin = New Padding(1, 1, 0, 1)
                    .SizeMode = PictureBoxSizeMode.CenterImage
                    .Location = New Point(1, 1)
                End With

                With lbl
                    .Parent = Me
                    .AutoSize = True
                    .MinimumSize = New Size(0, 18)
                    .MaximumSize = New Size(0, 0)
                    .Margin = New Padding(0, 1, 1, 1)
                    .Location = New Point(19, 1)
                    .TextAlign = ContentAlignment.MiddleLeft
                End With
            End If
        End Set
    End Property

    <System.ComponentModel.BrowsableAttribute(True)> _
    Public Overrides Property Text As String
        Get
            Return lbl.Text
        End Get
        Set(value As String)
            lbl.Text = value
        End Set
    End Property

    Public Overloads Property ForeColor As Color
        Get
            Return lbl.ForeColor
        End Get
        Set(value As Color)
            lbl.ForeColor = value
        End Set
    End Property

    Private Sub MEnter() Handles Me.MouseEnter, lbl.MouseEnter, icn.MouseEnter
        Me.BackColor = Color.FromArgb(196, 223, 249)
        icn.BackColor = Color.FromArgb(238, 243, 247)
        lbl.BackColor = Color.FromArgb(238, 243, 247)
    End Sub

    Private Sub MLeave() Handles Me.MouseLeave, lbl.MouseLeave, icn.MouseLeave
        Me.BackColor = Color.FromArgb(245, 246, 247)
        icn.BackColor = Color.FromArgb(245, 246, 247)
        lbl.BackColor = Color.FromArgb(245, 246, 247)
    End Sub

    Private Sub MMouseDown() Handles Me.MouseDown, lbl.MouseDown, icn.MouseDown
        Me.BackColor = Color.FromArgb(100, 164, 230)
        icn.BackColor = Color.FromArgb(205, 228, 252)
        lbl.BackColor = Color.FromArgb(205, 228, 252)
    End Sub

    Private Sub MMouseUp() Handles Me.MouseUp, lbl.MouseUp, icn.MouseUp
        Me.BackColor = Color.FromArgb(196, 223, 249)
        icn.BackColor = Color.FromArgb(238, 243, 247)
        lbl.BackColor = Color.FromArgb(238, 243, 247)
    End Sub

    Private Sub ChkClick() Handles icn.Click, lbl.Click
        Me.InvokeOnClick(Me, Nothing)
    End Sub

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)

        If Me.Enabled Then
            icn.Image = enabledimg
        Else
            icn.Image = disabledimg
        End If

    End Sub

    Public Property Icon As Image
        Get
            Return icn.Image
        End Get
        Set(value As Image)
            icn.Image = value

            enabledimg = value

            'convert color image to grayscale, also with alpha value
            If Not IsNothing(value) Then
                Dim bm As New Bitmap(value)
                Dim X As Integer
                Dim Y As Integer
                Dim clr As Integer

                For X = 0 To bm.Width - 1
                    For Y = 0 To bm.Height - 1
                        clr = (CInt(bm.GetPixel(X, Y).R) + _
                                   bm.GetPixel(X, Y).G + _
                                   bm.GetPixel(X, Y).B) \ 3
                        bm.SetPixel(X, Y, Color.FromArgb(bm.GetPixel(X, Y).A, clr, clr, clr))
                    Next Y
                Next X

                disabledimg = bm
            End If
        End Set
    End Property

    Private Sub LabelResize() Handles lbl.Resize
        icn.Width = lbl.Width
    End Sub

End Class

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonVerticalSeparator
    Inherits System.Windows.Forms.Panel

    Public Sub New()
        MyBase.MaximumSize = New Size(1, 80)
        MyBase.BackColor = Color.FromArgb(218, 219, 220)
    End Sub

End Class

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonHorizontalSeparator
    Inherits System.Windows.Forms.Panel

    Public Sub New()
        MyBase.MinimumSize = New Size(80, 1)
        MyBase.MaximumSize = New Size(0, 1)
        MyBase.BackColor = Color.FromArgb(218, 219, 220)
    End Sub

End Class

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonOptionButton
    Inherits System.Windows.Forms.Panel

    Dim WithEvents icn As New PictureBox
    Dim WithEvents lbl As New Label
    Dim disabledimg, enabledimg As Image
    Dim chk As Boolean = False
    Dim mode As Style = Style.Small

    Enum Style
        Big = 0
        Small = 1
    End Enum

    Public Sub New()
        MyBase.BackColor = Color.FromArgb(245, 246, 247)
        MyBase.AutoSize = True
        MyBase.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink

        Me.MaximumSize = New Size(0, 0)

        'maximum height: 20 pixels

        With icn
            .Parent = Me
            .MinimumSize = New Size(18, 18)
            .MaximumSize = New Size(18, 18)
            .Margin = New Padding(1, 1, 0, 1)
            .SizeMode = PictureBoxSizeMode.CenterImage
            .Location = New Point(1, 1)
        End With

        With lbl
            .Parent = Me
            .AutoSize = True
            .MinimumSize = New Size(0, 18)
            .Margin = New Padding(0, 1, 1, 1)
            .Location = New Point(18, 1)
            .TextAlign = ContentAlignment.MiddleLeft
        End With
    End Sub

    <System.ComponentModel.DefaultValue(Style.Small)> _
    Public Property ButtonStyle As Style
        Get
            Return mode
        End Get
        Set(value As Style)
            mode = value

            If value = Style.Big Then
                Me.MaximumSize = New Size(80, 68)
                Me.MinimumSize = New Size(0, 68)

                'maximum size: height 68 px, width 80 px
                'is possible to place on right side three
                'buttons with small style

                With icn
                    .Parent = Me
                    .MinimumSize = New Size(34, 36)
                    .MaximumSize = New Size(78, 36)
                    .Margin = New Padding(1, 1, 1, 0)
                    .SizeMode = PictureBoxSizeMode.CenterImage
                    .Location = New Point(1, 1)
                End With

                With lbl
                    .Parent = Me
                    .AutoSize = True
                    .AutoEllipsis = True
                    .Margin = New Padding(1, 0, 1, 1)
                    .Location = New Point(1, 37)
                    .MinimumSize = New Size(34, 30)
                    .MaximumSize = New Size(78, 30)
                    .TextAlign = ContentAlignment.TopCenter
                End With
            Else
                Me.MaximumSize = New Size(0, 0)

                'maximum height: 20 pixels

                With icn
                    .Parent = Me
                    .MinimumSize = New Size(18, 18)
                    .MaximumSize = New Size(18, 18)
                    .Margin = New Padding(1, 1, 0, 1)
                    .SizeMode = PictureBoxSizeMode.CenterImage
                    .Location = New Point(1, 1)
                End With

                With lbl
                    .Parent = Me
                    .AutoSize = True
                    .MinimumSize = New Size(0, 18)
                    .MaximumSize = New Size(0, 0)
                    .Margin = New Padding(0, 1, 1, 1)
                    .Location = New Point(19, 1)
                    .TextAlign = ContentAlignment.MiddleLeft
                End With
            End If
        End Set
    End Property

    <System.ComponentModel.DefaultValue(False)> _
    Public Property Checked As Boolean
        Get
            Return chk
        End Get
        Set(value As Boolean)
            chk = value

            If value = True Then
                Me.BackColor = Color.FromArgb(100, 164, 230)
                icn.BackColor = Color.FromArgb(205, 228, 252)
                lbl.BackColor = Color.FromArgb(205, 228, 252)
            Else
                Me.BackColor = Color.FromArgb(245, 246, 247)
                icn.BackColor = Color.FromArgb(245, 246, 247)
                lbl.BackColor = Color.FromArgb(245, 246, 247)
            End If
        End Set
    End Property

    <System.ComponentModel.BrowsableAttribute(True)> _
    Public Overrides Property Text As String
        Get
            Return lbl.Text
        End Get
        Set(value As String)
            lbl.Text = value
        End Set
    End Property

    Public Overloads Property ForeColor As Color
        Get
            Return lbl.ForeColor
        End Get
        Set(value As Color)
            lbl.ForeColor = value
        End Set
    End Property

    Private Sub MEnter() Handles Me.MouseEnter, lbl.MouseEnter, icn.MouseEnter
        If Me.Checked Then
            Me.BackColor = Color.FromArgb(100, 164, 230)
            icn.BackColor = Color.FromArgb(205, 228, 252)
            lbl.BackColor = Color.FromArgb(205, 228, 252)
        Else
            Me.BackColor = Color.FromArgb(196, 223, 249)
            icn.BackColor = Color.FromArgb(238, 243, 247)
            lbl.BackColor = Color.FromArgb(238, 243, 247)
        End If
    End Sub

    Private Sub MLeave() Handles Me.MouseLeave, lbl.MouseLeave, icn.MouseLeave
        If Me.Checked Then
            Me.BackColor = Color.FromArgb(100, 164, 230)
            icn.BackColor = Color.FromArgb(205, 228, 252)
            lbl.BackColor = Color.FromArgb(205, 228, 252)
        Else
            Me.BackColor = Color.FromArgb(245, 246, 247)
            icn.BackColor = Color.FromArgb(245, 246, 247)
            lbl.BackColor = Color.FromArgb(245, 246, 247)
        End If
    End Sub

    Private Sub ChkClick() Handles icn.Click, lbl.Click
        Me.InvokeOnClick(Me, Nothing)
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        If Me.Checked Then Exit Sub

        For Each Control In Parent.Controls
            If Control.GetType.Name = Me.GetType.Name And Control.Name <> Me.Name Then Control.Checked = False
        Next

        Me.Checked = True

        MyBase.OnClick(e)
    End Sub

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)

        If Me.Enabled Then
            icn.Image = enabledimg
        Else
            icn.Image = disabledimg
        End If

    End Sub

    Public Property Icon As Image
        Get
            Return icn.Image
        End Get
        Set(value As Image)
            icn.Image = value

            enabledimg = value

            'convert color image to grayscale, also with alpha value
            If Not IsNothing(value) Then
                Dim bm As New Bitmap(value)
                Dim X As Integer
                Dim Y As Integer
                Dim clr As Integer

                For X = 0 To bm.Width - 1
                    For Y = 0 To bm.Height - 1
                        clr = (CInt(bm.GetPixel(X, Y).R) + _
                                   bm.GetPixel(X, Y).G + _
                                   bm.GetPixel(X, Y).B) \ 3
                        bm.SetPixel(X, Y, Color.FromArgb(bm.GetPixel(X, Y).A, clr, clr, clr))
                    Next Y
                Next X

                disabledimg = bm
            End If
        End Set
    End Property

    Private Sub LabelResize() Handles lbl.Resize
        icn.Width = lbl.Width
    End Sub

End Class

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonCheckButton
    Inherits System.Windows.Forms.Panel

    Dim WithEvents icn As New PictureBox
    Dim WithEvents lbl As New Label
    Dim chk As Boolean = False
    Dim mode As Style = Style.Small

    Enum Style
        Big = 0
        Small = 1
    End Enum

    Public Sub New()
        MyBase.BackColor = Color.FromArgb(245, 246, 247)
        MyBase.AutoSize = True
        MyBase.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink

        Me.MaximumSize = New Size(0, 0)

        'maximum height: 20 pixels

        With icn
            .Parent = Me
            .MinimumSize = New Size(18, 18)
            .MaximumSize = New Size(18, 18)
            .Margin = New Padding(1, 1, 0, 1)
            .SizeMode = PictureBoxSizeMode.CenterImage
            .Location = New Point(1, 1)
        End With

        With lbl
            .Parent = Me
            .AutoSize = True
            .MinimumSize = New Size(0, 18)
            .Margin = New Padding(0, 1, 1, 1)
            .Location = New Point(18, 1)
            .TextAlign = ContentAlignment.MiddleLeft
        End With
    End Sub

    <System.ComponentModel.DefaultValue(Style.Small)> _
    Public Property ButtonStyle As Style
        Get
            Return mode
        End Get
        Set(value As Style)
            mode = value

            If value = Style.Big Then
                Me.MaximumSize = New Size(80, 68)
                Me.MinimumSize = New Size(0, 68)

                'maximum size: height 68 px, width 80 px
                'is possible to place on right side three
                'buttons with small style

                With icn
                    .Parent = Me
                    .MinimumSize = New Size(34, 36)
                    .MaximumSize = New Size(78, 36)
                    .Margin = New Padding(1, 1, 1, 0)
                    .SizeMode = PictureBoxSizeMode.CenterImage
                    .Location = New Point(1, 1)
                End With

                With lbl
                    .Parent = Me
                    .AutoSize = True
                    .AutoEllipsis = True
                    .Margin = New Padding(1, 0, 1, 1)
                    .Location = New Point(1, 37)
                    .MinimumSize = New Size(34, 30)
                    .MaximumSize = New Size(78, 30)
                    .TextAlign = ContentAlignment.TopCenter
                End With
            Else
                Me.MaximumSize = New Size(0, 0)

                'maximum height: 20 pixels

                With icn
                    .Parent = Me
                    .MinimumSize = New Size(18, 18)
                    .MaximumSize = New Size(18, 18)
                    .Margin = New Padding(1, 1, 0, 1)
                    .SizeMode = PictureBoxSizeMode.CenterImage
                    .Location = New Point(1, 1)
                End With

                With lbl
                    .Parent = Me
                    .AutoSize = True
                    .MinimumSize = New Size(0, 18)
                    .MaximumSize = New Size(0, 0)
                    .Margin = New Padding(0, 1, 1, 1)
                    .Location = New Point(19, 1)
                    .TextAlign = ContentAlignment.MiddleLeft
                End With
            End If
        End Set
    End Property

    <System.ComponentModel.DefaultValue(False)> _
    Public Property Checked As Boolean
        Get
            Return chk
        End Get
        Set(value As Boolean)
            chk = value

            If value = True Then
                Me.BackColor = Color.FromArgb(100, 164, 230)
                icn.BackColor = Color.FromArgb(205, 228, 252)
                lbl.BackColor = Color.FromArgb(205, 228, 252)
            Else
                Me.BackColor = Color.FromArgb(245, 246, 247)
                icn.BackColor = Color.FromArgb(245, 246, 247)
                lbl.BackColor = Color.FromArgb(245, 246, 247)
            End If
        End Set
    End Property

    <System.ComponentModel.BrowsableAttribute(True)> _
    Public Overrides Property Text As String
        Get
            Return lbl.Text
        End Get
        Set(value As String)
            lbl.Text = value
        End Set
    End Property

    Public Overloads Property ForeColor As Color
        Get
            Return lbl.ForeColor
        End Get
        Set(value As Color)
            lbl.ForeColor = value
        End Set
    End Property

    Private Sub MEnter() Handles Me.MouseEnter, lbl.MouseEnter, icn.MouseEnter
        If Me.Checked Then
            Me.BackColor = Color.FromArgb(100, 164, 230)
            icn.BackColor = Color.FromArgb(205, 228, 252)
            lbl.BackColor = Color.FromArgb(205, 228, 252)
        Else
            Me.BackColor = Color.FromArgb(196, 223, 249)
            icn.BackColor = Color.FromArgb(238, 243, 247)
            lbl.BackColor = Color.FromArgb(238, 243, 247)
        End If
    End Sub

    Private Sub MLeave() Handles Me.MouseLeave, lbl.MouseLeave, icn.MouseLeave
        If Me.Checked Then
            Me.BackColor = Color.FromArgb(100, 164, 230)
            icn.BackColor = Color.FromArgb(205, 228, 252)
            lbl.BackColor = Color.FromArgb(205, 228, 252)
        Else
            Me.BackColor = Color.FromArgb(245, 246, 247)
            icn.BackColor = Color.FromArgb(245, 246, 247)
            lbl.BackColor = Color.FromArgb(245, 246, 247)
        End If
    End Sub

    Private Sub ChkClick() Handles icn.Click, lbl.Click
        Me.InvokeOnClick(Me, Nothing)
        Me.Checked = Not Me.Checked

        If Me.Checked = False Then
            Me.BackColor = Color.FromArgb(196, 223, 249)
            icn.BackColor = Color.FromArgb(238, 243, 247)
            lbl.BackColor = Color.FromArgb(238, 243, 247)
        End If
    End Sub

    Public Property Icon As Image
        Get
            Return icn.Image
        End Get
        Set(value As Image)
            icn.Image = value
        End Set
    End Property

    Private Sub LabelResize() Handles lbl.Resize
        icn.Width = lbl.Width
    End Sub

End Class