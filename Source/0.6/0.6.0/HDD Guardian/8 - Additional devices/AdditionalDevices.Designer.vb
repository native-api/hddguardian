<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdditionalDevicesDlg
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
        Dim tlpAdditional As System.Windows.Forms.TableLayoutPanel
        Me.txtAdditionalCommand = New System.Windows.Forms.TextBox()
        Me.lblAdditionalDescription = New System.Windows.Forms.Label()
        Me.txtAdditionalDescription = New System.Windows.Forms.TextBox()
        Me.lblAdditionalCommand = New System.Windows.Forms.Label()
        Me.btnAdditionalAdd = New System.Windows.Forms.Button()
        Me.btnAdditionalCancel = New System.Windows.Forms.Button()
        Me.pnlAdditionalBottom = New System.Windows.Forms.Panel()
        Me.picAdditionalSeparator = New System.Windows.Forms.PictureBox()
        tlpAdditional = New System.Windows.Forms.TableLayoutPanel()
        tlpAdditional.SuspendLayout()
        Me.pnlAdditionalBottom.SuspendLayout()
        CType(Me.picAdditionalSeparator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpAdditional
        '
        tlpAdditional.AutoSize = True
        tlpAdditional.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpAdditional.BackColor = System.Drawing.Color.Transparent
        tlpAdditional.ColumnCount = 2
        tlpAdditional.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpAdditional.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpAdditional.Controls.Add(Me.txtAdditionalCommand, 1, 1)
        tlpAdditional.Controls.Add(Me.lblAdditionalDescription, 0, 0)
        tlpAdditional.Controls.Add(Me.txtAdditionalDescription, 1, 0)
        tlpAdditional.Controls.Add(Me.lblAdditionalCommand, 0, 1)
        tlpAdditional.Dock = System.Windows.Forms.DockStyle.Top
        tlpAdditional.Location = New System.Drawing.Point(0, 10)
        tlpAdditional.Name = "tlpAdditional"
        tlpAdditional.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        tlpAdditional.RowCount = 2
        tlpAdditional.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpAdditional.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpAdditional.Size = New System.Drawing.Size(492, 54)
        tlpAdditional.TabIndex = 6
        '
        'txtAdditionalCommand
        '
        Me.txtAdditionalCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdditionalCommand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAdditionalCommand.Location = New System.Drawing.Point(131, 30)
        Me.txtAdditionalCommand.Name = "txtAdditionalCommand"
        Me.txtAdditionalCommand.Size = New System.Drawing.Size(353, 21)
        Me.txtAdditionalCommand.TabIndex = 5
        '
        'lblAdditionalDescription
        '
        Me.lblAdditionalDescription.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAdditionalDescription.AutoSize = True
        Me.lblAdditionalDescription.ForeColor = System.Drawing.Color.Black
        Me.lblAdditionalDescription.Location = New System.Drawing.Point(8, 7)
        Me.lblAdditionalDescription.Name = "lblAdditionalDescription"
        Me.lblAdditionalDescription.Size = New System.Drawing.Size(117, 13)
        Me.lblAdditionalDescription.TabIndex = 0
        Me.lblAdditionalDescription.Text = "lblAdditionalDescription"
        '
        'txtAdditionalDescription
        '
        Me.txtAdditionalDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdditionalDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAdditionalDescription.Location = New System.Drawing.Point(131, 3)
        Me.txtAdditionalDescription.Name = "txtAdditionalDescription"
        Me.txtAdditionalDescription.Size = New System.Drawing.Size(353, 21)
        Me.txtAdditionalDescription.TabIndex = 4
        '
        'lblAdditionalCommand
        '
        Me.lblAdditionalCommand.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAdditionalCommand.AutoSize = True
        Me.lblAdditionalCommand.ForeColor = System.Drawing.Color.Black
        Me.lblAdditionalCommand.Location = New System.Drawing.Point(8, 34)
        Me.lblAdditionalCommand.Name = "lblAdditionalCommand"
        Me.lblAdditionalCommand.Size = New System.Drawing.Size(111, 13)
        Me.lblAdditionalCommand.TabIndex = 2
        Me.lblAdditionalCommand.Text = "lblAdditionalCommand"
        '
        'btnAdditionalAdd
        '
        Me.btnAdditionalAdd.Location = New System.Drawing.Point(328, 16)
        Me.btnAdditionalAdd.Name = "btnAdditionalAdd"
        Me.btnAdditionalAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdditionalAdd.TabIndex = 7
        Me.btnAdditionalAdd.Text = "btnAdditionalAdd"
        Me.btnAdditionalAdd.UseVisualStyleBackColor = True
        '
        'btnAdditionalCancel
        '
        Me.btnAdditionalCancel.Location = New System.Drawing.Point(408, 16)
        Me.btnAdditionalCancel.Name = "btnAdditionalCancel"
        Me.btnAdditionalCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnAdditionalCancel.TabIndex = 8
        Me.btnAdditionalCancel.Text = "btnAdditionalCancel"
        Me.btnAdditionalCancel.UseVisualStyleBackColor = True
        '
        'pnlAdditionalBottom
        '
        Me.pnlAdditionalBottom.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlAdditionalBottom.Controls.Add(Me.picAdditionalSeparator)
        Me.pnlAdditionalBottom.Controls.Add(Me.btnAdditionalAdd)
        Me.pnlAdditionalBottom.Controls.Add(Me.btnAdditionalCancel)
        Me.pnlAdditionalBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAdditionalBottom.Location = New System.Drawing.Point(0, 120)
        Me.pnlAdditionalBottom.Name = "pnlAdditionalBottom"
        Me.pnlAdditionalBottom.Size = New System.Drawing.Size(492, 49)
        Me.pnlAdditionalBottom.TabIndex = 9
        '
        'picAdditionalSeparator
        '
        Me.picAdditionalSeparator.BackgroundImage = Global.hdd_guardian.My.Resources.Resources.border
        Me.picAdditionalSeparator.Dock = System.Windows.Forms.DockStyle.Top
        Me.picAdditionalSeparator.Location = New System.Drawing.Point(0, 0)
        Me.picAdditionalSeparator.Name = "picAdditionalSeparator"
        Me.picAdditionalSeparator.Size = New System.Drawing.Size(492, 8)
        Me.picAdditionalSeparator.TabIndex = 0
        Me.picAdditionalSeparator.TabStop = False
        '
        'AdditionalDevicesDlg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(492, 169)
        Me.Controls.Add(Me.pnlAdditionalBottom)
        Me.Controls.Add(tlpAdditional)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdditionalDevicesDlg"
        Me.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AdditionalDevices"
        tlpAdditional.ResumeLayout(False)
        tlpAdditional.PerformLayout()
        Me.pnlAdditionalBottom.ResumeLayout(False)
        CType(Me.picAdditionalSeparator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAdditionalDescription As System.Windows.Forms.Label
    Friend WithEvents lblAdditionalCommand As System.Windows.Forms.Label
    Friend WithEvents txtAdditionalDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnAdditionalAdd As System.Windows.Forms.Button
    Friend WithEvents btnAdditionalCancel As System.Windows.Forms.Button
    Friend WithEvents pnlAdditionalBottom As System.Windows.Forms.Panel
    Friend WithEvents picAdditionalSeparator As System.Windows.Forms.PictureBox
    Friend WithEvents txtAdditionalCommand As System.Windows.Forms.TextBox
End Class
