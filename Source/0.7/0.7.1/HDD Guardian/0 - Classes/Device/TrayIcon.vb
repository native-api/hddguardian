'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Partial Class Device

    Private Class TrayIcon

        <System.Runtime.InteropServices.DllImportAttribute("user32.dll")>
        Private Shared Function DestroyIcon(ByVal handle As IntPtr) As Boolean
        End Function

        Private WithEvents ti As New NotifyIcon
        Dim m_visible As Boolean
        Dim m_title, m_content As String
        Dim m_icon As System.Drawing.Icon
        Dim WithEvents mousefollower As New Timer
        Dim isrunning As Boolean = False
        Dim mouseposition, localposition, lastposition As Point
        Dim pd As Device

        Public Sub Dispose()
            ti.Dispose()
        End Sub

        Public Sub New(ByRef parentDevice As Device)
            pd = parentDevice
        End Sub

        Private Sub mousefollowerTick(sender As Object, e As EventArgs) Handles mousefollower.Tick
            mouseposition = Cursor.Position()

            If localposition = lastposition And lastposition <> mouseposition Then
                TrayPanel.Hide()
                mousefollower.Stop()
                isrunning = False
                Exit Sub
            End If

            isrunning = True
        End Sub

        Private Sub ti_MouseMove(sender As Object, e As MouseEventArgs) Handles ti.MouseMove
            If AppSettings.General.DisplayInfoPanel Then
                If Main.WindowState = FormWindowState.Minimized Then
                    localposition = Cursor.Position
                    lastposition = Cursor.Position

                    mousefollower.Interval = 1
                    If Not isrunning Then mousefollower.Start()

                    If TrayPanel.Visible Then
                        Exit Sub
                    Else
                        TrayPanel.SetPanel(m_ssd, m_model, devlocation, m_rating, m_temperature, m_remaininglife, m_health, devtype, devImage)
                        TrayPanel.Show(Main)
                    End If
                End If
            Else
                TrayPanel.Hide()
            End If
        End Sub

        Private Sub ti_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ti.MouseDown
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left
                    'restore main screen
                    TrayPanel.Hide()
                    Main.WindowState = FormWindowState.Normal
                    Main.ShowInTaskbar = True
                    Main.Visible = True
                    Main.Activate()
                    Main.niTrayIcon.Visible = AppSettings.General.AlwaysDisplayTrayIcon
                Case Windows.Forms.MouseButtons.Middle
                    'if is pressed the middle button refresh all devices
                    Main.CheckForUpdates()
                    Main.UpdateAll(DeviceType.ATA)
                    Main.UpdateAll(DeviceType.USB)
                Case Windows.Forms.MouseButtons.Right

            End Select
        End Sub

        Public Property Visible As Boolean
            Get
                Return m_visible
            End Get
            Set(ByVal value As Boolean)
                m_visible = value
                Me.ti.Visible = value
            End Set
        End Property

        Public Property Title As String
            Get
                Return m_title
            End Get
            Set(ByVal value As String)
                m_title = value
                Me.ti.BalloonTipTitle = value
                Me.ti.Text = value
            End Set
        End Property

        Public Property Content As String
            Get
                Return m_content
            End Get
            Set(ByVal value As String)
                m_content = value
                Me.ti.BalloonTipText = value
            End Set
        End Property

        Public Property exIcon As System.Drawing.Icon
            Get
                Return m_icon
            End Get
            Set(ByVal value As System.Drawing.Icon)
                m_icon = value
                Me.ti.Icon = value
            End Set
        End Property

#Region "Properties for Info Panel"
        Dim m_model, devlocation, m_temperature, m_remaininglife As String
        Dim m_rating As AtaRatings
        Dim m_health As Status
        Dim devtype As DeviceType
        Dim m_ssd As Boolean
        Dim devImage As Bitmap

        Public Property DeviceImage As Bitmap
            Get
                Return devImage
            End Get
            Set(value As Bitmap)
                devImage = value
            End Set
        End Property

        Public Property IsSsd As Boolean
            Get
                Return m_ssd
            End Get
            Set(value As Boolean)
                m_ssd = value
            End Set
        End Property

        Public Property Model As String
            Get
                Return m_model
            End Get
            Set(value As String)
                m_model = value
            End Set
        End Property

        Public Property Location As String
            Get
                Return devlocation
            End Get
            Set(value As String)
                devlocation = value
            End Set
        End Property

        Public Property Temperature As String
            Get
                Return m_temperature
            End Get
            Set(value As String)
                m_temperature = value
            End Set
        End Property

        Public Property RemainingLife As String
            Get
                Return m_remaininglife
            End Get
            Set(value As String)
                m_remaininglife = value
            End Set
        End Property

        Public Property Rating As AtaRatings
            Get
                Return m_rating
            End Get
            Set(value As AtaRatings)
                m_rating = value
            End Set
        End Property

        Public Property Health As Status
            Get
                Return m_health
            End Get
            Set(value As Status)
                m_health = value
            End Set
        End Property

        Public Property Type As DeviceType
            Get
                Return devtype
            End Get
            Set(value As DeviceType)
                devtype = value
            End Set
        End Property
#End Region

        Public Sub SetIcon()
            Dim imgBack As Bitmap = My.Resources.tray_health_ok
            Dim imgNumbers As Bitmap = My.Resources.tray_icons

            Dim g As Graphics = Graphics.FromImage(imgBack)

            'background color for temperature / remaining life number color
            If pd.trayDisplayLife Then
                If IsNumeric(pd.ataRemainingLife) Then
                    Select Case pd.ataRemainingLife
                        Case 0
                            g.FillRectangle(Brushes.Red, 0, 0, 16, 16)
                        Case 1 To 10
                            g.FillRectangle(Brushes.Yellow, 0, 0, 16, 16)
                        Case Is > 10
                            g.FillRectangle(Brushes.Lime, 0, 0, 16, 16)
                    End Select
                Else
                    g.FillRectangle(Brushes.White, 0, 0, 16, 16)
                End If
            Else
                Dim limit As Integer = 55
                If pd.Type <> DeviceType.SCSI Then
                    If IsNumeric(pd.ataTemps.RecommendedMax) Then
                        limit = pd.ataTemps.RecommendedMax
                    Else
                        limit = 55
                    End If
                End If
                If IsNumeric(pd.Temperature) Then
                    Select Case pd.devTemperature
                        Case 0 To limit - 6
                            g.FillRectangle(Brushes.DeepSkyBlue, 0, 0, 16, 16)
                        Case limit - 5 To limit - 1
                            g.FillRectangle(Brushes.Yellow, 0, 0, 16, 16)
                        Case Is >= limit
                            g.FillRectangle(Brushes.Red, 0, 0, 16, 16)
                    End Select
                Else
                    g.FillRectangle(Brushes.White, 0, 0, 16, 16)
                End If
            End If

            'get icon temperature / health number
            Dim num As String = 0
            If pd.trayDisplayLife Then
                If IsNumeric(pd.ataRemainingLife) Then
                    num = pd.ataRemainingLife
                Else
                    num = "-"
                End If
            Else
                If IsNumeric(pd.devTemperature) Then
                    If AppSettings.General.TemperatureInFahrenheit Then
                        num = Math.Round(pd.devTemperature * 1.8 + 32)
                        If num > 210 Then num = 210
                        If num < 0 Then num = 0
                    Else
                        num = pd.devTemperature
                        If num > 210 Then num = 210
                        If num < 0 Then num = 0
                    End If
                Else
                    num = "-"
                End If
            End If

            If IsNumeric(num) Then
                Dim row, col As Integer
                row = Val(num.Substring(0, num.Length - 1))
                col = Val(num.Substring(num.Length - 1, 1))
                Dim rectNumbers As New Rectangle(col * 16, row * 16, 16, 16)
                Dim imgNumber As Bitmap = imgNumbers.Clone(rectNumbers, imgNumbers.PixelFormat)
                g.DrawImage(imgNumber, 0, 0)
                imgNumber.Dispose()
            Else
                Dim rectNumbers As New Rectangle(16, 336, 16, 16)
                Dim imgNumber As Bitmap = imgNumbers.Clone(rectNumbers, imgNumbers.PixelFormat)
                g.DrawImage(imgNumber, 0, 0)
                imgNumber.Dispose()
            End If

            'get health bar
            Select Case pd.devHealth
                Case Status.Passed
                    g.DrawImage(My.Resources.tray_health_ok, 0, 0)
                Case Status.Failed
                    g.DrawImage(My.Resources.tray_health_ko, 0, 0)
                Case Else
                    'do nothing
            End Select

            'set icon
            Dim oldIcon As Icon = ti.Icon
            Dim rect As New Rectangle(0, 0, 16, 16)
            Dim geticon As IntPtr = imgBack.Clone(rect, imgBack.PixelFormat).GetHicon
            Dim icn As Icon = Icon.FromHandle(geticon)
            ti.Icon = icn
            If Not IsNothing(oldIcon) Then DestroyIcon(oldIcon.Handle)

            'disposing resources
            g = Nothing
            imgBack.Dispose()
            imgNumbers.Dispose()
        End Sub

    End Class

End Class
