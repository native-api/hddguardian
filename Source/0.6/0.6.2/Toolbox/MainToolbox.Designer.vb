<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainToolbox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainToolbox))
        Me.tlpMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.robConsole = New toolbox.RibbonOptionButton()
        Me.robUsb = New toolbox.RibbonOptionButton()
        Me.robSystem = New toolbox.RibbonOptionButton()
        Me.htcMain = New toolbox.HeadlessTabControl()
        Me.tpConsole = New System.Windows.Forms.TabPage()
        Me.tlpConsoleDock = New System.Windows.Forms.TableLayoutPanel()
        Me.txtConsole = New System.Windows.Forms.TextBox()
        Me.btnConsoleSave = New System.Windows.Forms.Button()
        Me.tpUsb = New System.Windows.Forms.TabPage()
        Me.tlpUsbDock = New System.Windows.Forms.TableLayoutPanel()
        Me.txtUsb = New System.Windows.Forms.TextBox()
        Me.btnUsbSave = New System.Windows.Forms.Button()
        Me.tpSystem = New System.Windows.Forms.TabPage()
        Me.tlpWmiDock = New System.Windows.Forms.TableLayoutPanel()
        Me.txtWmi = New System.Windows.Forms.TextBox()
        Me.btnWmiSave = New System.Windows.Forms.Button()
        Me.HorizontalLine1 = New toolbox.HorizontalLine()
        Me.tlpMenu.SuspendLayout()
        Me.htcMain.SuspendLayout()
        Me.tpConsole.SuspendLayout()
        Me.tlpConsoleDock.SuspendLayout()
        Me.tpUsb.SuspendLayout()
        Me.tlpUsbDock.SuspendLayout()
        Me.tpSystem.SuspendLayout()
        Me.tlpWmiDock.SuspendLayout()
        CType(Me.HorizontalLine1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMenu
        '
        Me.tlpMenu.AutoSize = True
        Me.tlpMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tlpMenu.ColumnCount = 3
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenu.Controls.Add(Me.robConsole, 0, 0)
        Me.tlpMenu.Controls.Add(Me.robUsb, 1, 0)
        Me.tlpMenu.Controls.Add(Me.robSystem, 2, 0)
        Me.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlpMenu.Name = "tlpMenu"
        Me.tlpMenu.RowCount = 1
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenu.Size = New System.Drawing.Size(871, 78)
        Me.tlpMenu.TabIndex = 0
        '
        'robConsole
        '
        Me.robConsole.AutoSize = True
        Me.robConsole.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robConsole.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robConsole.ButtonStyle = toolbox.RibbonOptionButton.Style.Big
        Me.robConsole.Icon = Global.toolbox.My.Resources.Resources.konsole
        Me.robConsole.Location = New System.Drawing.Point(5, 5)
        Me.robConsole.Margin = New System.Windows.Forms.Padding(5, 5, 2, 5)
        Me.robConsole.MaximumSize = New System.Drawing.Size(80, 68)
        Me.robConsole.MinimumSize = New System.Drawing.Size(0, 68)
        Me.robConsole.Name = "robConsole"
        Me.robConsole.Size = New System.Drawing.Size(73, 68)
        Me.robConsole.TabIndex = 0
        Me.robConsole.Text = "Smartctl scan"
        '
        'robUsb
        '
        Me.robUsb.AutoSize = True
        Me.robUsb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robUsb.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robUsb.ButtonStyle = toolbox.RibbonOptionButton.Style.Big
        Me.robUsb.Icon = Global.toolbox.My.Resources.Resources.usb
        Me.robUsb.Location = New System.Drawing.Point(82, 5)
        Me.robUsb.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.robUsb.MaximumSize = New System.Drawing.Size(80, 68)
        Me.robUsb.MinimumSize = New System.Drawing.Size(0, 68)
        Me.robUsb.Name = "robUsb"
        Me.robUsb.Size = New System.Drawing.Size(53, 68)
        Me.robUsb.TabIndex = 1
        Me.robUsb.Text = "USB scan"
        '
        'robSystem
        '
        Me.robSystem.AutoSize = True
        Me.robSystem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robSystem.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robSystem.ButtonStyle = toolbox.RibbonOptionButton.Style.Big
        Me.robSystem.Icon = Global.toolbox.My.Resources.Resources.system
        Me.robSystem.Location = New System.Drawing.Point(139, 5)
        Me.robSystem.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.robSystem.MaximumSize = New System.Drawing.Size(80, 68)
        Me.robSystem.MinimumSize = New System.Drawing.Size(0, 68)
        Me.robSystem.Name = "robSystem"
        Me.robSystem.Size = New System.Drawing.Size(63, 68)
        Me.robSystem.TabIndex = 2
        Me.robSystem.Text = "System information"
        '
        'htcMain
        '
        Me.htcMain.Controls.Add(Me.tpConsole)
        Me.htcMain.Controls.Add(Me.tpUsb)
        Me.htcMain.Controls.Add(Me.tpSystem)
        Me.htcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htcMain.Location = New System.Drawing.Point(0, 79)
        Me.htcMain.Name = "htcMain"
        Me.htcMain.SelectedIndex = 0
        Me.htcMain.Size = New System.Drawing.Size(871, 416)
        Me.htcMain.TabIndex = 2
        '
        'tpConsole
        '
        Me.tpConsole.Controls.Add(Me.tlpConsoleDock)
        Me.tpConsole.Location = New System.Drawing.Point(4, 22)
        Me.tpConsole.Name = "tpConsole"
        Me.tpConsole.Size = New System.Drawing.Size(863, 390)
        Me.tpConsole.TabIndex = 0
        Me.tpConsole.Text = "tpConsole"
        Me.tpConsole.UseVisualStyleBackColor = True
        '
        'tlpConsoleDock
        '
        Me.tlpConsoleDock.ColumnCount = 1
        Me.tlpConsoleDock.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpConsoleDock.Controls.Add(Me.txtConsole, 0, 0)
        Me.tlpConsoleDock.Controls.Add(Me.btnConsoleSave, 0, 1)
        Me.tlpConsoleDock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpConsoleDock.Location = New System.Drawing.Point(0, 0)
        Me.tlpConsoleDock.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpConsoleDock.Name = "tlpConsoleDock"
        Me.tlpConsoleDock.RowCount = 2
        Me.tlpConsoleDock.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpConsoleDock.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpConsoleDock.Size = New System.Drawing.Size(863, 390)
        Me.tlpConsoleDock.TabIndex = 1
        '
        'txtConsole
        '
        Me.txtConsole.BackColor = System.Drawing.Color.Black
        Me.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConsole.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsole.ForeColor = System.Drawing.Color.White
        Me.txtConsole.Location = New System.Drawing.Point(0, 0)
        Me.txtConsole.Margin = New System.Windows.Forms.Padding(0)
        Me.txtConsole.Multiline = True
        Me.txtConsole.Name = "txtConsole"
        Me.txtConsole.ReadOnly = True
        Me.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtConsole.Size = New System.Drawing.Size(863, 361)
        Me.txtConsole.TabIndex = 0
        '
        'btnConsoleSave
        '
        Me.btnConsoleSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsoleSave.Location = New System.Drawing.Point(785, 364)
        Me.btnConsoleSave.Name = "btnConsoleSave"
        Me.btnConsoleSave.Size = New System.Drawing.Size(75, 23)
        Me.btnConsoleSave.TabIndex = 1
        Me.btnConsoleSave.Text = "Save"
        Me.btnConsoleSave.UseVisualStyleBackColor = True
        '
        'tpUsb
        '
        Me.tpUsb.Controls.Add(Me.tlpUsbDock)
        Me.tpUsb.Location = New System.Drawing.Point(4, 22)
        Me.tpUsb.Name = "tpUsb"
        Me.tpUsb.Size = New System.Drawing.Size(863, 390)
        Me.tpUsb.TabIndex = 1
        Me.tpUsb.Text = "tpUsb"
        Me.tpUsb.UseVisualStyleBackColor = True
        '
        'tlpUsbDock
        '
        Me.tlpUsbDock.ColumnCount = 1
        Me.tlpUsbDock.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpUsbDock.Controls.Add(Me.txtUsb, 0, 0)
        Me.tlpUsbDock.Controls.Add(Me.btnUsbSave, 0, 1)
        Me.tlpUsbDock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpUsbDock.Location = New System.Drawing.Point(0, 0)
        Me.tlpUsbDock.Name = "tlpUsbDock"
        Me.tlpUsbDock.RowCount = 2
        Me.tlpUsbDock.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpUsbDock.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpUsbDock.Size = New System.Drawing.Size(863, 390)
        Me.tlpUsbDock.TabIndex = 2
        '
        'txtUsb
        '
        Me.txtUsb.BackColor = System.Drawing.Color.Black
        Me.txtUsb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUsb.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsb.ForeColor = System.Drawing.Color.White
        Me.txtUsb.Location = New System.Drawing.Point(0, 0)
        Me.txtUsb.Margin = New System.Windows.Forms.Padding(0)
        Me.txtUsb.Multiline = True
        Me.txtUsb.Name = "txtUsb"
        Me.txtUsb.ReadOnly = True
        Me.txtUsb.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtUsb.Size = New System.Drawing.Size(863, 361)
        Me.txtUsb.TabIndex = 0
        '
        'btnUsbSave
        '
        Me.btnUsbSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUsbSave.Location = New System.Drawing.Point(785, 364)
        Me.btnUsbSave.Name = "btnUsbSave"
        Me.btnUsbSave.Size = New System.Drawing.Size(75, 23)
        Me.btnUsbSave.TabIndex = 1
        Me.btnUsbSave.Text = "Save"
        Me.btnUsbSave.UseVisualStyleBackColor = True
        '
        'tpSystem
        '
        Me.tpSystem.Controls.Add(Me.tlpWmiDock)
        Me.tpSystem.Location = New System.Drawing.Point(4, 22)
        Me.tpSystem.Name = "tpSystem"
        Me.tpSystem.Size = New System.Drawing.Size(863, 390)
        Me.tpSystem.TabIndex = 2
        Me.tpSystem.Text = "tpSystem"
        Me.tpSystem.UseVisualStyleBackColor = True
        '
        'tlpWmiDock
        '
        Me.tlpWmiDock.ColumnCount = 1
        Me.tlpWmiDock.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpWmiDock.Controls.Add(Me.txtWmi, 0, 0)
        Me.tlpWmiDock.Controls.Add(Me.btnWmiSave, 0, 1)
        Me.tlpWmiDock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpWmiDock.Location = New System.Drawing.Point(0, 0)
        Me.tlpWmiDock.Name = "tlpWmiDock"
        Me.tlpWmiDock.RowCount = 2
        Me.tlpWmiDock.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpWmiDock.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWmiDock.Size = New System.Drawing.Size(863, 390)
        Me.tlpWmiDock.TabIndex = 2
        '
        'txtWmi
        '
        Me.txtWmi.BackColor = System.Drawing.Color.Black
        Me.txtWmi.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWmi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWmi.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWmi.ForeColor = System.Drawing.Color.White
        Me.txtWmi.Location = New System.Drawing.Point(0, 0)
        Me.txtWmi.Margin = New System.Windows.Forms.Padding(0)
        Me.txtWmi.Multiline = True
        Me.txtWmi.Name = "txtWmi"
        Me.txtWmi.ReadOnly = True
        Me.txtWmi.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtWmi.Size = New System.Drawing.Size(863, 361)
        Me.txtWmi.TabIndex = 0
        '
        'btnWmiSave
        '
        Me.btnWmiSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWmiSave.Location = New System.Drawing.Point(785, 364)
        Me.btnWmiSave.Name = "btnWmiSave"
        Me.btnWmiSave.Size = New System.Drawing.Size(75, 23)
        Me.btnWmiSave.TabIndex = 1
        Me.btnWmiSave.Text = "Save"
        Me.btnWmiSave.UseVisualStyleBackColor = True
        '
        'HorizontalLine1
        '
        Me.HorizontalLine1.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine1.Dock = System.Windows.Forms.DockStyle.Top
        Me.HorizontalLine1.Location = New System.Drawing.Point(0, 78)
        Me.HorizontalLine1.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine1.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine1.Name = "HorizontalLine1"
        Me.HorizontalLine1.Size = New System.Drawing.Size(871, 1)
        Me.HorizontalLine1.TabIndex = 1
        Me.HorizontalLine1.TabStop = False
        '
        'MainToolbox
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(871, 495)
        Me.Controls.Add(Me.htcMain)
        Me.Controls.Add(Me.HorizontalLine1)
        Me.Controls.Add(Me.tlpMenu)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainToolbox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HDD Guardian Toolbox"
        Me.tlpMenu.ResumeLayout(False)
        Me.tlpMenu.PerformLayout()
        Me.htcMain.ResumeLayout(False)
        Me.tpConsole.ResumeLayout(False)
        Me.tlpConsoleDock.ResumeLayout(False)
        Me.tlpConsoleDock.PerformLayout()
        Me.tpUsb.ResumeLayout(False)
        Me.tlpUsbDock.ResumeLayout(False)
        Me.tlpUsbDock.PerformLayout()
        Me.tpSystem.ResumeLayout(False)
        Me.tlpWmiDock.ResumeLayout(False)
        Me.tlpWmiDock.PerformLayout()
        CType(Me.HorizontalLine1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlpMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents robConsole As toolbox.RibbonOptionButton
    Friend WithEvents robUsb As toolbox.RibbonOptionButton
    Friend WithEvents robSystem As toolbox.RibbonOptionButton
    Friend WithEvents HorizontalLine1 As toolbox.HorizontalLine
    Friend WithEvents htcMain As toolbox.HeadlessTabControl
    Friend WithEvents tpConsole As System.Windows.Forms.TabPage
    Friend WithEvents tpUsb As System.Windows.Forms.TabPage
    Friend WithEvents tpSystem As System.Windows.Forms.TabPage
    Friend WithEvents tlpConsoleDock As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtConsole As System.Windows.Forms.TextBox
    Friend WithEvents btnConsoleSave As System.Windows.Forms.Button
    Friend WithEvents tlpUsbDock As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtUsb As System.Windows.Forms.TextBox
    Friend WithEvents btnUsbSave As System.Windows.Forms.Button
    Friend WithEvents tlpWmiDock As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtWmi As System.Windows.Forms.TextBox
    Friend WithEvents btnWmiSave As System.Windows.Forms.Button

End Class
