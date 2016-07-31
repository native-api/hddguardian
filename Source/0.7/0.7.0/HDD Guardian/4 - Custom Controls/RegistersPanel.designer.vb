<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistersPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.tlpRegisters = New System.Windows.Forms.TableLayoutPanel()
        Me.lblER = New System.Windows.Forms.Label()
        Me.lblST = New System.Windows.Forms.Label()
        Me.lblSC = New System.Windows.Forms.Label()
        Me.lblSN = New System.Windows.Forms.Label()
        Me.lblCL = New System.Windows.Forms.Label()
        Me.lblCH = New System.Windows.Forms.Label()
        Me.lblDH = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.ttRegisters = New System.Windows.Forms.ToolTip(Me.components)
        Me.tlpRegisters.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpRegisters
        '
        Me.tlpRegisters.AutoSize = True
        Me.tlpRegisters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpRegisters.ColumnCount = 8
        Me.tlpRegisters.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpRegisters.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpRegisters.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpRegisters.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpRegisters.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpRegisters.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpRegisters.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpRegisters.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRegisters.Controls.Add(Me.lblER, 0, 0)
        Me.tlpRegisters.Controls.Add(Me.lblST, 1, 0)
        Me.tlpRegisters.Controls.Add(Me.lblSC, 2, 0)
        Me.tlpRegisters.Controls.Add(Me.lblSN, 3, 0)
        Me.tlpRegisters.Controls.Add(Me.lblCL, 4, 0)
        Me.tlpRegisters.Controls.Add(Me.lblCH, 5, 0)
        Me.tlpRegisters.Controls.Add(Me.lblDH, 6, 0)
        Me.tlpRegisters.Controls.Add(Me.lblError, 7, 0)
        Me.tlpRegisters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRegisters.Location = New System.Drawing.Point(0, 0)
        Me.tlpRegisters.Name = "tlpRegisters"
        Me.tlpRegisters.RowCount = 1
        Me.tlpRegisters.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRegisters.Size = New System.Drawing.Size(419, 75)
        Me.tlpRegisters.TabIndex = 0
        '
        'lblER
        '
        Me.lblER.AutoSize = True
        Me.lblER.BackColor = System.Drawing.Color.GhostWhite
        Me.lblER.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblER.ForeColor = System.Drawing.Color.MediumSlateBlue
        Me.lblER.Location = New System.Drawing.Point(0, 0)
        Me.lblER.Margin = New System.Windows.Forms.Padding(0)
        Me.lblER.Name = "lblER"
        Me.lblER.Padding = New System.Windows.Forms.Padding(0, 2, 0, 1)
        Me.lblER.Size = New System.Drawing.Size(20, 75)
        Me.lblER.TabIndex = 7
        Me.lblER.Text = "lblER"
        Me.lblER.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblST
        '
        Me.lblST.AutoSize = True
        Me.lblST.BackColor = System.Drawing.Color.GhostWhite
        Me.lblST.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblST.ForeColor = System.Drawing.Color.Black
        Me.lblST.Location = New System.Drawing.Point(20, 0)
        Me.lblST.Margin = New System.Windows.Forms.Padding(0)
        Me.lblST.Name = "lblST"
        Me.lblST.Padding = New System.Windows.Forms.Padding(0, 2, 0, 1)
        Me.lblST.Size = New System.Drawing.Size(20, 75)
        Me.lblST.TabIndex = 8
        Me.lblST.Text = "lblST"
        Me.lblST.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSC
        '
        Me.lblSC.AutoSize = True
        Me.lblSC.BackColor = System.Drawing.Color.GhostWhite
        Me.lblSC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSC.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblSC.Location = New System.Drawing.Point(40, 0)
        Me.lblSC.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSC.Name = "lblSC"
        Me.lblSC.Padding = New System.Windows.Forms.Padding(0, 2, 0, 1)
        Me.lblSC.Size = New System.Drawing.Size(20, 75)
        Me.lblSC.TabIndex = 9
        Me.lblSC.Text = "lblSC"
        Me.lblSC.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSN
        '
        Me.lblSN.AutoSize = True
        Me.lblSN.BackColor = System.Drawing.Color.GhostWhite
        Me.lblSN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSN.ForeColor = System.Drawing.Color.DarkKhaki
        Me.lblSN.Location = New System.Drawing.Point(60, 0)
        Me.lblSN.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSN.Name = "lblSN"
        Me.lblSN.Padding = New System.Windows.Forms.Padding(0, 2, 0, 1)
        Me.lblSN.Size = New System.Drawing.Size(20, 75)
        Me.lblSN.TabIndex = 10
        Me.lblSN.Text = "lblSN"
        Me.lblSN.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCL
        '
        Me.lblCL.AutoSize = True
        Me.lblCL.BackColor = System.Drawing.Color.GhostWhite
        Me.lblCL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCL.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.lblCL.Location = New System.Drawing.Point(80, 0)
        Me.lblCL.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCL.Name = "lblCL"
        Me.lblCL.Padding = New System.Windows.Forms.Padding(0, 2, 0, 1)
        Me.lblCL.Size = New System.Drawing.Size(20, 75)
        Me.lblCL.TabIndex = 11
        Me.lblCL.Text = "lblCL"
        Me.lblCL.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCH
        '
        Me.lblCH.AutoSize = True
        Me.lblCH.BackColor = System.Drawing.Color.GhostWhite
        Me.lblCH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCH.ForeColor = System.Drawing.Color.MediumTurquoise
        Me.lblCH.Location = New System.Drawing.Point(100, 0)
        Me.lblCH.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCH.Name = "lblCH"
        Me.lblCH.Padding = New System.Windows.Forms.Padding(0, 2, 0, 1)
        Me.lblCH.Size = New System.Drawing.Size(20, 75)
        Me.lblCH.TabIndex = 12
        Me.lblCH.Text = "lblCH"
        Me.lblCH.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDH
        '
        Me.lblDH.AutoSize = True
        Me.lblDH.BackColor = System.Drawing.Color.GhostWhite
        Me.lblDH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDH.ForeColor = System.Drawing.Color.Blue
        Me.lblDH.Location = New System.Drawing.Point(120, 0)
        Me.lblDH.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDH.Name = "lblDH"
        Me.lblDH.Padding = New System.Windows.Forms.Padding(0, 2, 0, 1)
        Me.lblDH.Size = New System.Drawing.Size(20, 75)
        Me.lblDH.TabIndex = 13
        Me.lblDH.Text = "lblDH"
        Me.lblDH.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.BackColor = System.Drawing.Color.GhostWhite
        Me.lblError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblError.ForeColor = System.Drawing.Color.Black
        Me.lblError.Location = New System.Drawing.Point(140, 0)
        Me.lblError.Margin = New System.Windows.Forms.Padding(0)
        Me.lblError.Name = "lblError"
        Me.lblError.Padding = New System.Windows.Forms.Padding(0, 2, 0, 1)
        Me.lblError.Size = New System.Drawing.Size(279, 75)
        Me.lblError.TabIndex = 14
        Me.lblError.Text = "lblError"
        '
        'RegistersPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpRegisters)
        Me.Name = "RegistersPanel"
        Me.Size = New System.Drawing.Size(419, 75)
        Me.tlpRegisters.ResumeLayout(False)
        Me.tlpRegisters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ttRegisters As System.Windows.Forms.ToolTip
    Private WithEvents tlpRegisters As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblER As System.Windows.Forms.Label
    Private WithEvents lblST As System.Windows.Forms.Label
    Private WithEvents lblSC As System.Windows.Forms.Label
    Private WithEvents lblSN As System.Windows.Forms.Label
    Private WithEvents lblCL As System.Windows.Forms.Label
    Private WithEvents lblCH As System.Windows.Forms.Label
    Private WithEvents lblDH As System.Windows.Forms.Label
    Private WithEvents lblError As System.Windows.Forms.Label

End Class
