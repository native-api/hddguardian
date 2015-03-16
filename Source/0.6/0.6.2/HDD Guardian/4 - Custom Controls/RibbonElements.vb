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

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonMenuItem
    Inherits System.Windows.Forms.Panel

    Declare Unicode Function IsThemeActive Lib "uxtheme" () As Boolean

    Dim WithEvents lbl As New Label
    Dim sel As Boolean = False
    Dim back, fore, border, selected As Color

    Public Sub New()
        If IsThemeActive Then
            back = Color.FromArgb(255, 255, 255)
            fore = Color.FromArgb(0, 0, 0)
            border = Color.FromArgb(218, 219, 220)
            selected = Color.FromArgb(245, 246, 247)
        Else
            back = Color.FromKnownColor(KnownColor.Window)
            fore = Color.FromKnownColor(KnownColor.WindowText)
            border = Color.FromKnownColor(KnownColor.ButtonShadow)
            selected = Color.FromKnownColor(KnownColor.ButtonFace)
        End If

        lbl.BackColor = back
        lbl.ForeColor = fore
        lbl.Padding = New Padding(3, 6, 3, 6)
        lbl.Margin = New Padding(1)
        lbl.AutoSize = True
        lbl.Location = New Point(1, 1)

        MyBase.BackColor = back
        MyBase.Padding = New Padding(0)
        MyBase.Margin = New Padding(2)
        MyBase.AutoSize = True
        MyBase.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
        MyBase.Controls.Add(lbl)

    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        For Each Control In Parent.Controls
            If Control.GetType.Name = Me.GetType.Name Then Control.DeSelect()
        Next

        lbl.BackColor = selected
        Me.BackColor = border

        MyBase.OnClick(e)
    End Sub

    Private Sub LabelClick() Handles lbl.Click
        For Each Control In Parent.Controls
            If Control.GetType.Name = Me.GetType.Name Then Control.DeSelect()
        Next

        lbl.BackColor = border
        Me.BackColor = selected

        Me.InvokeOnClick(Me, Nothing)
    End Sub

    Public Sub Deselect()
        lbl.BackColor = back
        Me.BackColor = back
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
End Class 'unused...

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonButton
    Inherits System.Windows.Forms.Panel

    Declare Unicode Function IsThemeActive Lib "uxtheme" () As Boolean

    Dim WithEvents icn As New PictureBox
    Dim WithEvents lbl As New Label
    Dim WithEvents tt As New ToolTip
    Dim disabledimg, enabledimg As Image
    Dim chk As Boolean = False
    Dim mode As Style = Style.Small
    Dim back, fore As Color
    Dim me_border, me_inner, md_border, md_inner, mu_border, mu_inner As Color

    Enum Style
        Big = 0
        Small = 1
    End Enum

    Public Sub New()
        If IsThemeActive Then
            back = Color.FromArgb(245, 246, 247)
            fore = Color.FromArgb(0, 0, 0)
            me_border = Color.FromArgb(196, 223, 249)
            me_inner = Color.FromArgb(238, 243, 247)
            md_border = Color.FromArgb(100, 164, 230)
            md_inner = Color.FromArgb(205, 228, 252)
            mu_border = Color.FromArgb(196, 223, 249)
            mu_inner = Color.FromArgb(238, 243, 247)
        Else
            back = Color.FromKnownColor(KnownColor.MenuBar)
            fore = Color.FromKnownColor(KnownColor.WindowText)
            me_border = Color.FromKnownColor(KnownColor.InactiveCaption)
            me_inner = Color.FromKnownColor(KnownColor.GradientInactiveCaption)
            md_border = Color.FromKnownColor(KnownColor.ActiveCaption)
            md_inner = Color.FromKnownColor(KnownColor.GradientActiveCaption)
            mu_border = Color.FromKnownColor(KnownColor.InactiveCaption)
            mu_inner = Color.FromKnownColor(KnownColor.GradientInactiveCaption)
        End If

        MyBase.BackColor = back
        MyBase.AutoSize = True
        MyBase.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink

        Me.MaximumSize = New Size(0, 0)

        'maximum height: 20 pixels

        With icn
            .BackColor = back
            .Parent = Me
            .MinimumSize = New Size(18, 18)
            .MaximumSize = New Size(18, 18)
            .Margin = New Padding(1, 1, 0, 1)
            .SizeMode = PictureBoxSizeMode.CenterImage
            .Location = New Point(1, 1)
            .BackColor = back
        End With

        With lbl
            BackColor = back
            .Parent = Me
            .AutoSize = True
            .MinimumSize = New Size(0, 18)
            .Margin = New Padding(0, 1, 1, 1)
            .Location = New Point(18, 1)
            .TextAlign = ContentAlignment.MiddleLeft
            .ForeColor = fore
            .BackColor = back
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
                Me.MaximumSize = New Size(150, 68)
                Me.MinimumSize = New Size(0, 68)

                'maximum size: height 68 px, width 150 px
                'is possible to place on right side three
                'buttons with small style

                With icn
                    .Parent = Me
                    .MinimumSize = New Size(34, 36)
                    .MaximumSize = New Size(148, 36)
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
                    .MaximumSize = New Size(148, 30)
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

    Private Function IsEllipsed() As Boolean
        Dim s As SizeF = CreateGraphics.MeasureString(lbl.Text, lbl.Font, lbl.Width)

        If s.Height > lbl.Height Then
            Return True
        End If

        Return False
    End Function

    Private Sub MEnter() Handles Me.MouseEnter, lbl.MouseEnter, icn.MouseEnter
        Me.BackColor = me_border
        icn.BackColor = me_inner
        lbl.BackColor = me_inner

        If IsEllipsed() And ButtonStyle = Style.Big Then
            tt.SetToolTip(lbl, lbl.Text)
        Else
            tt.RemoveAll()
        End If
    End Sub

    Private Sub MLeave() Handles Me.MouseLeave, lbl.MouseLeave, icn.MouseLeave
        Me.BackColor = back
        icn.BackColor = back
        lbl.BackColor = back
    End Sub

    Private Sub MMouseDown() Handles Me.MouseDown, lbl.MouseDown, icn.MouseDown
        Me.BackColor = md_border
        icn.BackColor = md_inner
        lbl.BackColor = md_inner
    End Sub

    Private Sub MMouseUp() Handles Me.MouseUp, lbl.MouseUp, icn.MouseUp
        Me.BackColor = mu_border
        icn.BackColor = mu_inner
        lbl.BackColor = mu_inner
    End Sub

    Private Sub ChkClick() Handles icn.Click, lbl.Click
        Me.InvokeOnClick(Me, Nothing)

        Me.BackColor = back
        icn.BackColor = back
        lbl.BackColor = back
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

    Declare Unicode Function IsThemeActive Lib "uxtheme" () As Boolean

    Public Sub New()
        If IsThemeActive Then
            MyBase.BackColor = Color.FromArgb(218, 219, 220)
        Else
            MyBase.BackColor = Color.FromKnownColor(KnownColor.ControlDark)
        End If
        MyBase.MaximumSize = New Size(1, 80)

    End Sub
End Class

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonHorizontalSeparator
    Inherits System.Windows.Forms.Panel

    Declare Unicode Function IsThemeActive Lib "uxtheme" () As Boolean

    Public Sub New()
        If IsThemeActive Then
            MyBase.BackColor = Color.FromArgb(218, 219, 220)
        Else
            MyBase.BackColor = Color.FromKnownColor(KnownColor.ControlDark)
        End If

        MyBase.MinimumSize = New Size(80, 1)
        MyBase.MaximumSize = New Size(0, 1)
    End Sub

End Class

<System.ComponentModel.DefaultEvent("Click")> _
Public Class RibbonOptionButton
    Inherits System.Windows.Forms.Panel

    Declare Unicode Function IsThemeActive Lib "uxtheme" () As Boolean

    Dim WithEvents icn As New PictureBox
    Dim WithEvents lbl As New Label
    Dim disabledimg, enabledimg As Image
    Dim chk As Boolean = False
    Dim mode As Style = Style.Small
    Dim back, fore As Color
    Dim chk_border, chk_inner, hover_border, hover_inner As Color

    Enum Style
        Big = 0
        Small = 1
    End Enum

    Public Sub New()
        If IsThemeActive Then
            back = Color.FromArgb(245, 246, 247)
            fore = Color.FromArgb(0, 0, 0)
            chk_border = Color.FromArgb(100, 164, 230)
            chk_inner = Color.FromArgb(205, 228, 252)
            hover_border = Color.FromArgb(196, 223, 249)
            hover_inner = Color.FromArgb(238, 243, 247)
        Else
            back = Color.FromKnownColor(KnownColor.MenuBar)
            fore = Color.FromKnownColor(KnownColor.WindowText)
            hover_border = Color.FromKnownColor(KnownColor.InactiveCaption)
            hover_inner = Color.FromKnownColor(KnownColor.GradientInactiveCaption)
            chk_border = Color.FromKnownColor(KnownColor.ActiveCaption)
            chk_inner = Color.FromKnownColor(KnownColor.GradientActiveCaption)

        End If

        MyBase.BackColor = back
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
            .BackColor = back
        End With

        With lbl
            .Parent = Me
            .AutoSize = True
            .MinimumSize = New Size(0, 18)
            .Margin = New Padding(0, 1, 1, 1)
            .Location = New Point(18, 1)
            .TextAlign = ContentAlignment.MiddleLeft
            .ForeColor = fore
            .BackColor = back
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
                Me.BackColor = chk_border
                icn.BackColor = chk_inner
                lbl.BackColor = chk_inner
            Else
                Me.BackColor = back
                icn.BackColor = back
                lbl.BackColor = back
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
            Me.BackColor = chk_border
            icn.BackColor = chk_inner
            lbl.BackColor = chk_inner
        Else
            Me.BackColor = hover_border
            icn.BackColor = hover_inner
            lbl.BackColor = hover_inner
        End If
    End Sub

    Private Sub MLeave() Handles Me.MouseLeave, lbl.MouseLeave, icn.MouseLeave
        If Me.Checked Then
            Me.BackColor = chk_border
            icn.BackColor = chk_inner
            lbl.BackColor = chk_inner
        Else
            Me.BackColor = back
            icn.BackColor = back
            lbl.BackColor = back
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

End Class 'unused...