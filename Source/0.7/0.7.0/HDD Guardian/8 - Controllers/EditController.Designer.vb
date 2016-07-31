<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditController
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
        Me.tlpController = New System.Windows.Forms.TableLayoutPanel()
        Me.lblController = New System.Windows.Forms.Label()
        Me.lblLayer = New System.Windows.Forms.Label()
        Me.lblAllowedDevices = New System.Windows.Forms.Label()
        Me.cboLayers = New System.Windows.Forms.ComboBox()
        Me.cboAllowed = New System.Windows.Forms.ComboBox()
        Me.lblTester = New System.Windows.Forms.Label()
        Me.txtTester = New System.Windows.Forms.TextBox()
        Me.cboControllers = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.picSeparator = New System.Windows.Forms.PictureBox()
        Me.tlpController.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        CType(Me.picSeparator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpController
        '
        Me.tlpController.AutoSize = True
        Me.tlpController.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpController.BackColor = System.Drawing.Color.Transparent
        Me.tlpController.ColumnCount = 2
        Me.tlpController.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpController.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpController.Controls.Add(Me.lblController, 0, 0)
        Me.tlpController.Controls.Add(Me.lblLayer, 0, 1)
        Me.tlpController.Controls.Add(Me.lblAllowedDevices, 0, 2)
        Me.tlpController.Controls.Add(Me.cboLayers, 1, 1)
        Me.tlpController.Controls.Add(Me.cboAllowed, 1, 2)
        Me.tlpController.Controls.Add(Me.lblTester, 0, 3)
        Me.tlpController.Controls.Add(Me.txtTester, 1, 3)
        Me.tlpController.Controls.Add(Me.cboControllers, 1, 0)
        Me.tlpController.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpController.Location = New System.Drawing.Point(0, 10)
        Me.tlpController.Name = "tlpController"
        Me.tlpController.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.tlpController.RowCount = 4
        Me.tlpController.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpController.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpController.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpController.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpController.Size = New System.Drawing.Size(338, 108)
        Me.tlpController.TabIndex = 6
        '
        'lblController
        '
        Me.lblController.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblController.AutoSize = True
        Me.lblController.ForeColor = System.Drawing.Color.Black
        Me.lblController.Location = New System.Drawing.Point(8, 7)
        Me.lblController.Name = "lblController"
        Me.lblController.Size = New System.Drawing.Size(64, 13)
        Me.lblController.TabIndex = 0
        Me.lblController.Text = "lblController"
        '
        'lblLayer
        '
        Me.lblLayer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLayer.AutoSize = True
        Me.lblLayer.ForeColor = System.Drawing.Color.Black
        Me.lblLayer.Location = New System.Drawing.Point(8, 34)
        Me.lblLayer.Name = "lblLayer"
        Me.lblLayer.Size = New System.Drawing.Size(44, 13)
        Me.lblLayer.TabIndex = 2
        Me.lblLayer.Text = "lblLayer"
        '
        'lblAllowedDevices
        '
        Me.lblAllowedDevices.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAllowedDevices.AutoSize = True
        Me.lblAllowedDevices.ForeColor = System.Drawing.Color.Black
        Me.lblAllowedDevices.Location = New System.Drawing.Point(8, 61)
        Me.lblAllowedDevices.Name = "lblAllowedDevices"
        Me.lblAllowedDevices.Size = New System.Drawing.Size(91, 13)
        Me.lblAllowedDevices.TabIndex = 5
        Me.lblAllowedDevices.Text = "lblAllowedDevices"
        '
        'cboLayers
        '
        Me.cboLayers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLayers.FormattingEnabled = True
        Me.cboLayers.Items.AddRange(New Object() {"-d ata", "-d sat"})
        Me.cboLayers.Location = New System.Drawing.Point(105, 30)
        Me.cboLayers.Name = "cboLayers"
        Me.cboLayers.Size = New System.Drawing.Size(225, 21)
        Me.cboLayers.TabIndex = 1
        '
        'cboAllowed
        '
        Me.cboAllowed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboAllowed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAllowed.FormattingEnabled = True
        Me.cboAllowed.Items.AddRange(New Object() {"SATA", "SATA, SCSI"})
        Me.cboAllowed.Location = New System.Drawing.Point(105, 57)
        Me.cboAllowed.Name = "cboAllowed"
        Me.cboAllowed.Size = New System.Drawing.Size(225, 21)
        Me.cboAllowed.TabIndex = 2
        '
        'lblTester
        '
        Me.lblTester.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTester.AutoSize = True
        Me.lblTester.ForeColor = System.Drawing.Color.Black
        Me.lblTester.Location = New System.Drawing.Point(8, 88)
        Me.lblTester.Name = "lblTester"
        Me.lblTester.Size = New System.Drawing.Size(48, 13)
        Me.lblTester.TabIndex = 8
        Me.lblTester.Text = "lblTester"
        '
        'txtTester
        '
        Me.txtTester.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTester.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTester.Location = New System.Drawing.Point(105, 84)
        Me.txtTester.Name = "txtTester"
        Me.txtTester.Size = New System.Drawing.Size(225, 21)
        Me.txtTester.TabIndex = 3
        '
        'cboControllers
        '
        Me.cboControllers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboControllers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboControllers.FormattingEnabled = True
        Me.cboControllers.Location = New System.Drawing.Point(105, 3)
        Me.cboControllers.Name = "cboControllers"
        Me.cboControllers.Size = New System.Drawing.Size(225, 21)
        Me.cboControllers.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(176, 16)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "btnAdd"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(256, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlBottom
        '
        Me.pnlBottom.AutoSize = True
        Me.pnlBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlBottom.Controls.Add(Me.picSeparator)
        Me.pnlBottom.Controls.Add(Me.btnAdd)
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 234)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(338, 42)
        Me.pnlBottom.TabIndex = 9
        '
        'picSeparator
        '
        Me.picSeparator.BackgroundImage = Global.hdd_guardian.My.Resources.Resources.border
        Me.picSeparator.Dock = System.Windows.Forms.DockStyle.Top
        Me.picSeparator.Location = New System.Drawing.Point(0, 0)
        Me.picSeparator.Name = "picSeparator"
        Me.picSeparator.Size = New System.Drawing.Size(338, 8)
        Me.picSeparator.TabIndex = 0
        Me.picSeparator.TabStop = False
        '
        'EditController
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(338, 276)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.tlpController)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditController"
        Me.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EditController"
        Me.tlpController.ResumeLayout(False)
        Me.tlpController.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        CType(Me.picSeparator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblController As System.Windows.Forms.Label
    Friend WithEvents lblLayer As System.Windows.Forms.Label
    Friend WithEvents txtTester As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents picSeparator As System.Windows.Forms.PictureBox
    Friend WithEvents lblAllowedDevices As System.Windows.Forms.Label
    Friend WithEvents cboLayers As System.Windows.Forms.ComboBox
    Friend WithEvents cboAllowed As System.Windows.Forms.ComboBox
    Friend WithEvents lblTester As System.Windows.Forms.Label
    Friend WithEvents cboControllers As System.Windows.Forms.ComboBox
    Friend WithEvents tlpController As System.Windows.Forms.TableLayoutPanel
End Class
