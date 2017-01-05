'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.ComponentModel
Imports System.ComponentModel.Design

<System.ComponentModel.DefaultEvent("Click")>
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

Namespace MimicExplorer
    Public Class ExplorerTab
        Inherits RadioButton

        Declare Unicode Function IsThemeActive Lib "uxtheme" () As Boolean

        Dim back, fore, border, selected, over, down, inner As Color

        Public Sub New()
            If IsThemeActive Then
                back = Color.FromArgb(255, 255, 255)
                fore = Color.FromArgb(0, 0, 0)
                border = Color.FromArgb(218, 219, 220)
                selected = Color.FromArgb(245, 246, 247)
                over = Color.FromArgb(253, 253, 255)
                down = Color.FromArgb(245, 255, 255)
                inner = Color.FromArgb(235, 236, 236)
            Else
                back = Color.FromKnownColor(KnownColor.Window)
                fore = Color.FromKnownColor(KnownColor.ControlText)
                border = Color.FromArgb(218, 219, 220)
                selected = Color.FromKnownColor(KnownColor.ButtonFace)
                over = Color.FromKnownColor(KnownColor.ButtonHighlight)
                down = Color.FromKnownColor(KnownColor.ButtonShadow)
                inner = Color.FromKnownColor(KnownColor.ButtonFace)
            End If

            MyBase.FlatStyle = FlatStyle.Flat
            MyBase.Appearance = Appearance.Button
            MyBase.FlatAppearance.BorderSize = 0
            MyBase.MinimumSize = New Size(58, 24)
            Me.BackColor = back
            Me.ForeColor = fore
            Me.FlatAppearance.MouseDownBackColor = Color.Transparent
            Me.FlatAppearance.CheckedBackColor = selected
        End Sub

        Dim _mouseOver As Boolean = False

        Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
            MyBase.OnPaint(pevent)

            Dim pBorder As New Pen(border)
            Dim pBack As New Pen(back)
            Dim pInner As New Pen(inner)

            If Me.Checked Then
                pevent.Graphics.DrawRectangle(pBorder, New Rectangle(0, 0, Me.Width - 1, Me.Height))
                Me.FlatAppearance.MouseOverBackColor = selected
            Else
                If _mouseOver Then
                    pevent.Graphics.DrawRectangle(pBack, New Rectangle(0, 0, Me.Width - 1, Me.Height))
                    pevent.Graphics.DrawRectangle(pInner, New Rectangle(1, 1, Me.Width - 3, Me.Height))
                    pevent.Graphics.DrawLine(pBorder, 0, Me.Height - 1, Me.Width - 1, Me.Height - 1)
                Else
                    pevent.Graphics.DrawLine(pBorder, 0, Me.Height - 1, Me.Width - 1, Me.Height - 1)
                End If
            End If
        End Sub

        Private Sub MEnter() Handles Me.MouseEnter
            If Me.Checked Then
                Me.FlatAppearance.CheckedBackColor = selected
                Me.FlatAppearance.MouseOverBackColor = selected
                Me.FlatAppearance.MouseDownBackColor = selected
            Else
                Me.FlatAppearance.MouseOverBackColor = over
                Me.FlatAppearance.MouseDownBackColor = over
            End If
        End Sub

        Private Sub MLeave() Handles Me.MouseLeave
            If Me.Checked Then
                Me.FlatAppearance.CheckedBackColor = selected
                Me.FlatAppearance.MouseOverBackColor = selected
                Me.FlatAppearance.MouseDownBackColor = selected
            Else
                Me.FlatAppearance.MouseOverBackColor = over
                Me.FlatAppearance.MouseDownBackColor = down
            End If
        End Sub

        Protected Overrides Sub OnCheckedChanged(e As EventArgs)
            MyBase.OnCheckedChanged(e)
            If Me.Checked Then
                Me.FlatAppearance.CheckedBackColor = selected
                Me.FlatAppearance.MouseOverBackColor = selected
                Me.FlatAppearance.MouseDownBackColor = selected
            Else
                Me.FlatAppearance.MouseOverBackColor = over
                Me.FlatAppearance.MouseDownBackColor = down
            End If
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnMouseDown(mevent As MouseEventArgs)
            MyBase.OnMouseDown(mevent)
            Me.FlatAppearance.MouseOverBackColor = selected
            Me.FlatAppearance.MouseDownBackColor = selected
        End Sub

        Protected Overrides Sub OnMouseEnter(eventargs As EventArgs)
            MyBase.OnMouseEnter(eventargs)
            _mouseOver = True
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnMouseLeave(eventargs As EventArgs)
            MyBase.OnMouseLeave(eventargs)
            _mouseOver = False
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnLeave(e As EventArgs)
            MyBase.OnLeave(e)
            _mouseOver = False
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnEnter(e As EventArgs)
            MyBase.OnEnter(e)
            _mouseOver = True
            Me.RaisePaintEvent(Me, Nothing)
        End Sub
    End Class

    Public Class RibbonRadio
        Inherits RadioButton

        Dim over As Color = Color.FromArgb(242, 242, 242)
        Dim check As Color = Color.FromArgb(168, 214, 250)

        Public Sub New()
            MyBase.FlatStyle = FlatStyle.Flat
            MyBase.Appearance = Appearance.Button
            MyBase.FlatAppearance.BorderSize = 0
            MyBase.Margin = New Padding(0, 0, 0, 0)
            MyBase.Padding = New Padding(10, 0, 0, 0)
            MyBase.TextImageRelation = TextImageRelation.ImageBeforeText
            Me.BackColor = Color.Transparent
            Me.FlatAppearance.MouseDownBackColor = Color.Transparent
        End Sub

        Dim _disabledimg, _enabledimg As Image
        Dim _mouseOver As Boolean = False

        Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
            pevent.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            pevent.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault

            Dim bCheck As New SolidBrush(check)
            Dim bOver As New SolidBrush(over)
            Dim bBack As New SolidBrush(Me.Parent.BackColor)

            If Me.Checked Then
                pevent.Graphics.FillRectangle(bCheck, New Rectangle(-1, -1, Me.Width + 1, Me.Height + 1))
            Else
                If _mouseOver Then
                    pevent.Graphics.FillRectangle(bOver, New Rectangle(-1, -1, Me.Width + 1, Me.Height + 1))
                Else
                    pevent.Graphics.FillRectangle(bBack, New Rectangle(-1, -1, Me.Width + 1, Me.Height + 1))
                End If
            End If

            TextRenderer.DrawText(pevent.Graphics, Me.Text, Me.Font, New Rectangle(Me.Padding.Left, 0, Me.Width - Me.Padding.Left, Me.Height), Me.ForeColor, TextFormatFlags.EndEllipsis + TextFormatFlags.VerticalCenter)
        End Sub

        Protected Overrides Sub OnEnabledChanged(e As EventArgs)
            MyBase.OnEnabledChanged(e)
            Me.Visible = Me.Enabled
        End Sub

        Public Shadows ReadOnly Property Image()
            Get
                Return Nothing
            End Get
        End Property

        Private Sub MEnter() Handles Me.MouseEnter
            If Me.Checked Then
                Me.FlatAppearance.MouseOverBackColor = check
                Me.FlatAppearance.MouseDownBackColor = check
            Else
                Me.FlatAppearance.MouseOverBackColor = over
                Me.FlatAppearance.MouseDownBackColor = over
            End If
        End Sub

        Private Sub MLeave() Handles Me.MouseLeave
            If Me.Checked Then
                Me.FlatAppearance.CheckedBackColor = check
                Me.FlatAppearance.MouseDownBackColor = check
            Else
                Me.FlatAppearance.CheckedBackColor = Color.Transparent
                Me.FlatAppearance.MouseDownBackColor = Color.Transparent
            End If
        End Sub

        Protected Overrides Sub OnCheckedChanged(e As EventArgs)
            MyBase.OnCheckedChanged(e)
            If Me.Checked Then
                Me.FlatAppearance.CheckedBackColor = check
                Me.FlatAppearance.MouseDownBackColor = check
            Else
                Me.FlatAppearance.MouseDownBackColor = Color.Transparent
            End If
        End Sub

        Protected Overrides Sub OnMouseDown(mevent As MouseEventArgs)
            MyBase.OnMouseDown(mevent)
            Me.FlatAppearance.MouseOverBackColor = check
            Me.FlatAppearance.MouseDownBackColor = check
            Me.Checked = True
        End Sub

        Protected Overrides Sub OnMouseEnter(eventargs As EventArgs)
            MyBase.OnMouseEnter(eventargs)
            _mouseOver = True
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnMouseLeave(eventargs As EventArgs)
            MyBase.OnMouseLeave(eventargs)
            _mouseOver = False
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnLeave(e As EventArgs)
            MyBase.OnLeave(e)
            _mouseOver = False
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnEnter(e As EventArgs)
            MyBase.OnEnter(e)
            _mouseOver = True
            Me.RaisePaintEvent(Me, Nothing)
        End Sub
    End Class

    Public Class RibbonButton
        Inherits Button

        Dim over As Color = Color.FromArgb(230, 230, 230)
        Dim down As Color = Color.FromArgb(168, 214, 250)

        Public Sub New()
            MyBase.FlatStyle = FlatStyle.Flat
            MyBase.FlatAppearance.BorderSize = 0
            MyBase.MinimumSize = New Size(56, 22)
            MyBase.TextImageRelation = TextImageRelation.ImageBeforeText
            Me.BackColor = Color.Transparent
            Me.FlatAppearance.MouseDownBackColor = down
            Me.FlatAppearance.MouseOverBackColor = Color.Transparent
        End Sub

        Dim _disabledimg, _enabledimg As Image
        Dim _mouseOver As Boolean = False
        Dim _mouseDown As Boolean = False
        Dim _tabStop As Boolean = False
        Dim _drawText As Boolean = True

        Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
            pevent.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            pevent.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault

            Dim rOver As New SolidBrush(over)
            Dim rDown As New SolidBrush(down)
            Dim rBack As New SolidBrush(Me.Parent.BackColor)

            If _mouseOver Then
                pevent.Graphics.FillRectangle(rOver, New Rectangle(-1, -1, Me.Width + 1, Me.Height + 1))
                If _mouseDown Then
                    pevent.Graphics.FillRectangle(rDown, New Rectangle(-1, -1, Me.Width + 1, Me.Height + 1))
                End If
            Else
                pevent.Graphics.FillRectangle(rBack, New Rectangle(-1, -1, Me.Width + 1, Me.Height + 1))
            End If

            If Not IsNothing(Me.Image) Then
                Dim m As Short = Me.Height / 2 - 8
                pevent.Graphics.DrawImage(Me.Image, m, m, 16, 16)
            End If

            Dim lm As Short
            If Not IsNothing(Me.Image) Then lm = 18 Else lm = 0

            If _drawText Then
                If Me.Enabled Then
                    TextRenderer.DrawText(pevent.Graphics, Me.Text, Me.Font, New Rectangle(lm, 0, Me.Width - lm, Me.Height), Me.ForeColor)
                Else
                    TextRenderer.DrawText(pevent.Graphics, Me.Text, Me.Font, New Rectangle(lm, 0, Me.Width - lm, Me.Height), Color.FromKnownColor(KnownColor.GrayText))
                End If
            End If
        End Sub

        Protected Overrides Sub OnEnabledChanged(e As EventArgs)
            MyBase.OnEnabledChanged(e)

            If Me.Enabled Then
                Me.Image = _enabledimg
            Else
                Me.Image = _disabledimg
            End If
        End Sub

        Public Property Icon As Image
            Get
                If Me.Enabled Then
                    Return _enabledimg
                Else
                    Return _disabledimg
                End If
            End Get
            Set(value As Image)
                Me.Image = value

                _enabledimg = value

                'convert color image to grayscale, also with alpha value
                If Not IsNothing(value) Then
                    Dim bm As New Bitmap(value)
                    Dim X As Integer
                    Dim Y As Integer
                    Dim clr As Integer

                    For X = 0 To bm.Width - 1
                        For Y = 0 To bm.Height - 1
                            clr = (CInt(bm.GetPixel(X, Y).R) +
                                       bm.GetPixel(X, Y).G +
                                       bm.GetPixel(X, Y).B) \ 3
                            bm.SetPixel(X, Y, Color.FromArgb(bm.GetPixel(X, Y).A, clr, clr, clr))
                        Next Y
                    Next X

                    _disabledimg = bm

                    If Image.Height > 16 Then
                        Me.MinimumSize = New Size(80, 66)
                        Me.TextImageRelation = TextImageRelation.ImageAboveText
                    Else
                        Me.MinimumSize = New Size(80, 22)
                        Me.MaximumSize = New Size(0, 22)
                        Me.TextImageRelation = TextImageRelation.ImageBeforeText
                    End If
                Else
                    Me.MinimumSize = New Size(80, 22)
                    Me.MaximumSize = New Size(0, 22)
                    Me.TextImageRelation = TextImageRelation.ImageBeforeText
                End If
            End Set
        End Property

        <DefaultValue(True)>
        Public Property DrawText As Boolean
            Get
                Return _drawText
            End Get
            Set(value As Boolean)
                _drawText = value
            End Set
        End Property

        Protected Overrides Sub OnLostFocus(e As EventArgs)
            Me.FlatAppearance.MouseOverBackColor = Color.Transparent
            Me.RaisePaintEvent(Me, Nothing)
            MyBase.OnLostFocus(e)
        End Sub

        Protected Overrides Sub OnGotFocus(e As EventArgs)
            MyBase.OnGotFocus(e)
            If Not _mouseOver Then
                Me.FlatAppearance.MouseOverBackColor = over
                Me.RaisePaintEvent(Me, Nothing)
            End If
        End Sub

        Protected Overrides Sub OnMouseDown(mevent As MouseEventArgs)
            MyBase.OnMouseDown(mevent)
            _mouseDown = True
            Me.FlatAppearance.MouseDownBackColor = down
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnMouseUp(mevent As MouseEventArgs)
            _mouseDown = False
            Me.FlatAppearance.MouseOverBackColor = over
            Me.RaisePaintEvent(Me, Nothing)
            MyBase.OnMouseUp(mevent)
        End Sub

        Protected Overrides Sub OnMouseEnter(eventargs As EventArgs)
            MyBase.OnMouseEnter(eventargs)
            _mouseOver = True
            Me.FlatAppearance.MouseOverBackColor = over
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnMouseLeave(eventargs As EventArgs)
            MyBase.OnMouseLeave(eventargs)
            _mouseOver = False
            Me.FlatAppearance.MouseOverBackColor = over
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnLeave(e As EventArgs)
            MyBase.OnLeave(e)
            _tabStop = False
            Me.FlatAppearance.MouseOverBackColor = over
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnEnter(e As EventArgs)
            MyBase.OnEnter(e)
            _tabStop = True
            Me.FlatAppearance.MouseOverBackColor = over
            Me.RaisePaintEvent(Me, Nothing)
        End Sub
    End Class

    Public Class RibbonMenu
        Inherits Button

        Public Sub New()
            MyBase.FlatStyle = FlatStyle.Flat
            MyBase.FlatAppearance.BorderSize = 0
            MyBase.MinimumSize = New Size(56, 23)
            MyBase.TextImageRelation = TextImageRelation.ImageBeforeText
            Me.ForeColor = Color.White
            Me.BackColor = Color.FromArgb(25, 121, 202)
            Me.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 121, 202)
            Me.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 140, 225)
        End Sub

        Protected Overrides Sub OnLostFocus(e As EventArgs)
            MyBase.OnLostFocus(e)
            Me.FlatAppearance.BorderColor = Color.FromArgb(25, 121, 202)
            Me.FlatAppearance.CheckedBackColor = Color.FromArgb(25, 121, 202)
        End Sub

    End Class

    Public Class RibbonCheck
        Inherits CheckBox

        Dim over As Color = Color.FromArgb(230, 230, 230)
        Dim check As Color = Color.FromArgb(168, 214, 250)

        Public Sub New()
            MyBase.FlatStyle = FlatStyle.Flat
            MyBase.Appearance = Appearance.Button
            MyBase.FlatAppearance.BorderSize = 0
            MyBase.MinimumSize = New Size(56, 22)
            MyBase.MaximumSize = New Size(0, 22)
            MyBase.TextImageRelation = TextImageRelation.ImageBeforeText
            Me.BackColor = Color.Transparent
            Me.FlatAppearance.MouseDownBackColor = Color.Transparent
        End Sub

        Dim _disabledimg, _enabledimg As Image
        Dim _mouseOver As Boolean = False

        Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
            MyBase.OnPaint(pevent)

            If Me.Checked Then
                Me.FlatAppearance.MouseOverBackColor = check
                Me.FlatAppearance.MouseDownBackColor = check
            Else
                If _mouseOver Then
                    Me.FlatAppearance.MouseOverBackColor = over
                    Me.FlatAppearance.MouseDownBackColor = over
                Else

                End If
            End If
        End Sub

        Protected Overrides Sub OnCheckedChanged(e As EventArgs)
            MyBase.OnCheckedChanged(e)
            If Me.Checked Then
                Me.FlatAppearance.CheckedBackColor = check
                Me.FlatAppearance.MouseDownBackColor = check
            Else
                Me.FlatAppearance.CheckedBackColor = Color.Transparent
                Me.FlatAppearance.MouseDownBackColor = Color.Transparent
            End If
        End Sub

        Protected Overrides Sub OnEnabledChanged(e As EventArgs)
            MyBase.OnEnabledChanged(e)

            If Me.Enabled Then
                Me.Image = _enabledimg
            Else
                Me.Image = _disabledimg
            End If

        End Sub

        Public Property Icon As Image
            Get
                If Me.Enabled Then
                    Return _enabledimg
                Else
                    Return _disabledimg
                End If
            End Get
            Set(value As Image)
                Me.Image = value

                _enabledimg = value

                'convert color image to grayscale, also with alpha value
                If Not IsNothing(value) Then
                    Dim bm As New Bitmap(value)
                    Dim X As Integer
                    Dim Y As Integer
                    Dim clr As Integer

                    For X = 0 To bm.Width - 1
                        For Y = 0 To bm.Height - 1
                            clr = (CInt(bm.GetPixel(X, Y).R) +
                                   bm.GetPixel(X, Y).G +
                                   bm.GetPixel(X, Y).B) \ 3
                            bm.SetPixel(X, Y, Color.FromArgb(bm.GetPixel(X, Y).A, clr, clr, clr))
                        Next Y
                    Next X

                    _disabledimg = bm
                    bm.Dispose()
                End If
            End Set
        End Property

        Private Sub MEnter() Handles Me.MouseEnter
            If Me.Checked Then
                Me.FlatAppearance.MouseOverBackColor = check
                Me.FlatAppearance.MouseDownBackColor = check
            Else
                Me.FlatAppearance.MouseOverBackColor = over
                Me.FlatAppearance.MouseDownBackColor = over
            End If
        End Sub

        Private Sub MLeave() Handles Me.MouseLeave
            If Me.Checked Then
                Me.FlatAppearance.CheckedBackColor = check
                Me.FlatAppearance.MouseDownBackColor = check
            Else
                Me.FlatAppearance.CheckedBackColor = Color.Transparent
                Me.FlatAppearance.MouseDownBackColor = Color.Transparent
            End If
        End Sub

        Protected Overrides Sub OnMouseDown(mevent As MouseEventArgs)
            MyBase.OnMouseDown(mevent)
            If mevent.Button = MouseButtons.Left Then
                Me.FlatAppearance.MouseOverBackColor = check
                Me.FlatAppearance.MouseDownBackColor = check
            End If
        End Sub

        Protected Overrides Sub OnMouseEnter(eventargs As EventArgs)
            MyBase.OnMouseEnter(eventargs)
            _mouseOver = True
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnMouseLeave(eventargs As EventArgs)
            MyBase.OnMouseLeave(eventargs)
            _mouseOver = False
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnLeave(e As EventArgs)
            MyBase.OnLeave(e)
            _mouseOver = False
            Me.RaisePaintEvent(Me, Nothing)
        End Sub

        Protected Overrides Sub OnEnter(e As EventArgs)
            MyBase.OnEnter(e)
            _mouseOver = True
            Me.RaisePaintEvent(Me, Nothing)
        End Sub
    End Class

    Public Class RibbonSplitter
        Inherits Panel

        Dim WithEvents line As New Panel
        Public Sub New()
            MyBase.Size = New Size(3, 100)
            MyBase.Padding = New Padding(1)
            MyBase.Dock = DockStyle.Left
            MyBase.Cursor = Cursors.SizeWE
            MyBase.BackColor = Color.Transparent
            Me.Controls.Add(line)
            line.Dock = DockStyle.Fill
            line.Cursor = Cursors.SizeWE
            line.BackColor = Color.FromArgb(218, 219, 220)
        End Sub

        Private Sub lineMove(sender As Object, e As MouseEventArgs) Handles line.MouseMove
            Me.OnMouseMove(e)
        End Sub

    End Class
End Namespace