<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LDM
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LDM))
        Me.sbLdm = New System.Windows.Forms.StatusBar()
        Me.niTrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tmrFlushMem = New System.Windows.Forms.Timer(Me.components)
        Me.tlpMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.rbtReload = New Ribbons.RibbonButton()
        Me.rbtExit = New Ribbons.RibbonButton()
        Me.tlpOptions = New System.Windows.Forms.TableLayoutPanel()
        Me.rcbLogonStart = New Ribbons.RibbonCheckButton()
        Me.rcbStartMinimized = New Ribbons.RibbonCheckButton()
        Me.rcbCloseOnTray = New Ribbons.RibbonCheckButton()
        Me.rcbMonitorUsb = New Ribbons.RibbonCheckButton()
        Me.RibbonVerticalSeparator1 = New Ribbons.RibbonVerticalSeparator()
        Me.RibbonVerticalSeparator2 = New Ribbons.RibbonVerticalSeparator()
        Me.lblTip = New System.Windows.Forms.Label()
        Me.lvwPartitions = New System.Windows.Forms.ListView()
        Me.chLetter = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chLabel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chRead = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chWrite = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tlpMenu.SuspendLayout()
        Me.tlpOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'sbLdm
        '
        Me.sbLdm.Location = New System.Drawing.Point(0, 444)
        Me.sbLdm.Name = "sbLdm"
        Me.sbLdm.Size = New System.Drawing.Size(885, 22)
        Me.sbLdm.TabIndex = 1
        Me.sbLdm.Text = "sbLdm"
        '
        'niTrayIcon
        '
        Me.niTrayIcon.Icon = CType(resources.GetObject("niTrayIcon.Icon"), System.Drawing.Icon)
        Me.niTrayIcon.Text = "NotifyIcon1"
        Me.niTrayIcon.Visible = True
        '
        'tmrFlushMem
        '
        Me.tmrFlushMem.Enabled = True
        Me.tmrFlushMem.Interval = 600000
        '
        'tlpMenu
        '
        Me.tlpMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tlpMenu.ColumnCount = 6
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenu.Controls.Add(Me.rbtReload, 0, 0)
        Me.tlpMenu.Controls.Add(Me.rbtExit, 1, 0)
        Me.tlpMenu.Controls.Add(Me.tlpOptions, 3, 0)
        Me.tlpMenu.Controls.Add(Me.RibbonVerticalSeparator1, 2, 0)
        Me.tlpMenu.Controls.Add(Me.RibbonVerticalSeparator2, 4, 0)
        Me.tlpMenu.Controls.Add(Me.lblTip, 5, 0)
        Me.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlpMenu.Name = "tlpMenu"
        Me.tlpMenu.RowCount = 1
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenu.Size = New System.Drawing.Size(885, 78)
        Me.tlpMenu.TabIndex = 2
        '
        'rbtReload
        '
        Me.rbtReload.AutoSize = True
        Me.rbtReload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.rbtReload.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbtReload.ButtonStyle = Ribbons.RibbonButton.Style.Big
        Me.rbtReload.Icon = Global.ldm.My.Resources.Resources.view_refresh
        Me.rbtReload.Location = New System.Drawing.Point(5, 5)
        Me.rbtReload.Margin = New System.Windows.Forms.Padding(5, 5, 2, 5)
        Me.rbtReload.MaximumSize = New System.Drawing.Size(100, 68)
        Me.rbtReload.MinimumSize = New System.Drawing.Size(0, 68)
        Me.rbtReload.Name = "rbtReload"
        Me.rbtReload.Size = New System.Drawing.Size(56, 68)
        Me.rbtReload.TabIndex = 0
        Me.rbtReload.Text = "rbtReload"
        '
        'rbtExit
        '
        Me.rbtExit.AutoSize = True
        Me.rbtExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.rbtExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rbtExit.ButtonStyle = Ribbons.RibbonButton.Style.Big
        Me.rbtExit.Icon = Global.ldm.My.Resources.Resources.application_exit
        Me.rbtExit.Location = New System.Drawing.Point(65, 5)
        Me.rbtExit.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.rbtExit.MaximumSize = New System.Drawing.Size(100, 68)
        Me.rbtExit.MinimumSize = New System.Drawing.Size(0, 68)
        Me.rbtExit.Name = "rbtExit"
        Me.rbtExit.Size = New System.Drawing.Size(41, 68)
        Me.rbtExit.TabIndex = 1
        Me.rbtExit.Text = "rbtExit"
        '
        'tlpOptions
        '
        Me.tlpOptions.AutoSize = True
        Me.tlpOptions.ColumnCount = 2
        Me.tlpOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpOptions.Controls.Add(Me.rcbLogonStart, 0, 0)
        Me.tlpOptions.Controls.Add(Me.rcbStartMinimized, 0, 1)
        Me.tlpOptions.Controls.Add(Me.rcbCloseOnTray, 0, 2)
        Me.tlpOptions.Controls.Add(Me.rcbMonitorUsb, 1, 0)
        Me.tlpOptions.Location = New System.Drawing.Point(118, 3)
        Me.tlpOptions.Name = "tlpOptions"
        Me.tlpOptions.RowCount = 3
        Me.tlpOptions.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOptions.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOptions.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOptions.Size = New System.Drawing.Size(213, 72)
        Me.tlpOptions.TabIndex = 2
        '
        'rcbLogonStart
        '
        Me.rcbLogonStart.AutoSize = True
        Me.rcbLogonStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.rcbLogonStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rcbLogonStart.Icon = Global.ldm.My.Resources.Resources.fork
        Me.rcbLogonStart.Location = New System.Drawing.Point(2, 2)
        Me.rcbLogonStart.Margin = New System.Windows.Forms.Padding(2)
        Me.rcbLogonStart.Name = "rcbLogonStart"
        Me.rcbLogonStart.Size = New System.Drawing.Size(94, 20)
        Me.rcbLogonStart.TabIndex = 0
        Me.rcbLogonStart.Text = "rcbLogonStart"
        '
        'rcbStartMinimized
        '
        Me.rcbStartMinimized.AutoSize = True
        Me.rcbStartMinimized.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.rcbStartMinimized.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rcbStartMinimized.Icon = Global.ldm.My.Resources.Resources.bottom
        Me.rcbStartMinimized.Location = New System.Drawing.Point(2, 26)
        Me.rcbStartMinimized.Margin = New System.Windows.Forms.Padding(2)
        Me.rcbStartMinimized.Name = "rcbStartMinimized"
        Me.rcbStartMinimized.Size = New System.Drawing.Size(110, 20)
        Me.rcbStartMinimized.TabIndex = 1
        Me.rcbStartMinimized.Text = "rcbStartMinimized"
        '
        'rcbCloseOnTray
        '
        Me.rcbCloseOnTray.AutoSize = True
        Me.rcbCloseOnTray.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.rcbCloseOnTray.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rcbCloseOnTray.Icon = Global.ldm.My.Resources.Resources.system_run
        Me.rcbCloseOnTray.Location = New System.Drawing.Point(2, 50)
        Me.rcbCloseOnTray.Margin = New System.Windows.Forms.Padding(2)
        Me.rcbCloseOnTray.Name = "rcbCloseOnTray"
        Me.rcbCloseOnTray.Size = New System.Drawing.Size(103, 20)
        Me.rcbCloseOnTray.TabIndex = 2
        Me.rcbCloseOnTray.Text = "rcbCloseOnTray"
        '
        'rcbMonitorUsb
        '
        Me.rcbMonitorUsb.AutoSize = True
        Me.rcbMonitorUsb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.rcbMonitorUsb.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.rcbMonitorUsb.Icon = Global.ldm.My.Resources.Resources.hdd_usb_unmount
        Me.rcbMonitorUsb.Location = New System.Drawing.Point(116, 2)
        Me.rcbMonitorUsb.Margin = New System.Windows.Forms.Padding(2)
        Me.rcbMonitorUsb.Name = "rcbMonitorUsb"
        Me.rcbMonitorUsb.Size = New System.Drawing.Size(95, 20)
        Me.rcbMonitorUsb.TabIndex = 3
        Me.rcbMonitorUsb.Text = "rcbMonitorUsb"
        '
        'RibbonVerticalSeparator1
        '
        Me.RibbonVerticalSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator1.Location = New System.Drawing.Point(111, 3)
        Me.RibbonVerticalSeparator1.MaximumSize = New System.Drawing.Size(1, 80)
        Me.RibbonVerticalSeparator1.Name = "RibbonVerticalSeparator1"
        Me.RibbonVerticalSeparator1.Size = New System.Drawing.Size(1, 72)
        Me.RibbonVerticalSeparator1.TabIndex = 3
        '
        'RibbonVerticalSeparator2
        '
        Me.RibbonVerticalSeparator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator2.Location = New System.Drawing.Point(337, 3)
        Me.RibbonVerticalSeparator2.MaximumSize = New System.Drawing.Size(1, 80)
        Me.RibbonVerticalSeparator2.Name = "RibbonVerticalSeparator2"
        Me.RibbonVerticalSeparator2.Size = New System.Drawing.Size(1, 72)
        Me.RibbonVerticalSeparator2.TabIndex = 4
        '
        'lblTip
        '
        Me.lblTip.AutoSize = True
        Me.lblTip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTip.ForeColor = System.Drawing.Color.DimGray
        Me.lblTip.Location = New System.Drawing.Point(344, 5)
        Me.lblTip.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.lblTip.Name = "lblTip"
        Me.lblTip.Size = New System.Drawing.Size(538, 68)
        Me.lblTip.TabIndex = 5
        Me.lblTip.Text = "lblTip"
        '
        'lvwPartitions
        '
        Me.lvwPartitions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwPartitions.CheckBoxes = True
        Me.lvwPartitions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chLetter, Me.chLabel, Me.chRead, Me.chWrite})
        Me.lvwPartitions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwPartitions.FullRowSelect = True
        Me.lvwPartitions.Location = New System.Drawing.Point(0, 78)
        Me.lvwPartitions.MultiSelect = False
        Me.lvwPartitions.Name = "lvwPartitions"
        Me.lvwPartitions.Size = New System.Drawing.Size(885, 366)
        Me.lvwPartitions.TabIndex = 9
        Me.lvwPartitions.UseCompatibleStateImageBehavior = False
        Me.lvwPartitions.View = System.Windows.Forms.View.Details
        '
        'chLetter
        '
        Me.chLetter.Text = "chLetter"
        '
        'chLabel
        '
        Me.chLabel.Text = "chLabel"
        '
        'chRead
        '
        Me.chRead.Text = "chRead"
        Me.chRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chWrite
        '
        Me.chWrite.Text = "chWrite"
        Me.chWrite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LDM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(885, 466)
        Me.Controls.Add(Me.lvwPartitions)
        Me.Controls.Add(Me.tlpMenu)
        Me.Controls.Add(Me.sbLdm)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "LDM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Logical Disk Monitor"
        Me.tlpMenu.ResumeLayout(False)
        Me.tlpMenu.PerformLayout()
        Me.tlpOptions.ResumeLayout(False)
        Me.tlpOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sbLdm As System.Windows.Forms.StatusBar
    Friend WithEvents niTrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents tmrFlushMem As System.Windows.Forms.Timer
    Friend WithEvents tlpMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbtReload As Ribbons.RibbonButton
    Friend WithEvents rbtExit As Ribbons.RibbonButton
    Friend WithEvents tlpOptions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rcbLogonStart As Ribbons.RibbonCheckButton
    Friend WithEvents RibbonVerticalSeparator1 As Ribbons.RibbonVerticalSeparator
    Friend WithEvents rcbStartMinimized As Ribbons.RibbonCheckButton
    Friend WithEvents rcbCloseOnTray As Ribbons.RibbonCheckButton
    Friend WithEvents rcbMonitorUsb As Ribbons.RibbonCheckButton
    Friend WithEvents RibbonVerticalSeparator2 As Ribbons.RibbonVerticalSeparator
    Friend WithEvents lblTip As System.Windows.Forms.Label
    Friend WithEvents lvwPartitions As System.Windows.Forms.ListView
    Friend WithEvents chLetter As System.Windows.Forms.ColumnHeader
    Friend WithEvents chLabel As System.Windows.Forms.ColumnHeader
    Friend WithEvents chRead As System.Windows.Forms.ColumnHeader
    Friend WithEvents chWrite As System.Windows.Forms.ColumnHeader

End Class
