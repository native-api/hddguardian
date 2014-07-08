<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrayPanel
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
        Me.tlpDeviceInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpInfoPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDeviceName = New System.Windows.Forms.Label()
        Me.lblDeviceLocation = New System.Windows.Forms.Label()
        Me.lblTempInfo = New System.Windows.Forms.Label()
        Me.lblTempInfoValue = New System.Windows.Forms.Label()
        Me.lblLife = New System.Windows.Forms.Label()
        Me.lblLifeValue = New System.Windows.Forms.Label()
        Me.lblHealthInfoValue = New System.Windows.Forms.Label()
        Me.lblHealthInfo = New System.Windows.Forms.Label()
        Me.picReliability = New System.Windows.Forms.PictureBox()
        Me.picDeviceImage = New System.Windows.Forms.PictureBox()
        Me.tlpDeviceInfo.SuspendLayout()
        Me.tlpInfoPanel.SuspendLayout()
        CType(Me.picReliability, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDeviceImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpDeviceInfo
        '
        Me.tlpDeviceInfo.AutoSize = True
        Me.tlpDeviceInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDeviceInfo.BackColor = System.Drawing.Color.White
        Me.tlpDeviceInfo.ColumnCount = 2
        Me.tlpDeviceInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDeviceInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDeviceInfo.Controls.Add(Me.tlpInfoPanel, 1, 0)
        Me.tlpDeviceInfo.Controls.Add(Me.picDeviceImage, 0, 0)
        Me.tlpDeviceInfo.Location = New System.Drawing.Point(1, 1)
        Me.tlpDeviceInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpDeviceInfo.Name = "tlpDeviceInfo"
        Me.tlpDeviceInfo.RowCount = 1
        Me.tlpDeviceInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDeviceInfo.Size = New System.Drawing.Size(362, 70)
        Me.tlpDeviceInfo.TabIndex = 23
        '
        'tlpInfoPanel
        '
        Me.tlpInfoPanel.AutoSize = True
        Me.tlpInfoPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpInfoPanel.ColumnCount = 3
        Me.tlpInfoPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpInfoPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpInfoPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpInfoPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpInfoPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpInfoPanel.Controls.Add(Me.lblDeviceName, 0, 0)
        Me.tlpInfoPanel.Controls.Add(Me.lblDeviceLocation, 0, 1)
        Me.tlpInfoPanel.Controls.Add(Me.lblTempInfo, 1, 0)
        Me.tlpInfoPanel.Controls.Add(Me.lblTempInfoValue, 2, 0)
        Me.tlpInfoPanel.Controls.Add(Me.lblLife, 1, 1)
        Me.tlpInfoPanel.Controls.Add(Me.lblLifeValue, 2, 1)
        Me.tlpInfoPanel.Controls.Add(Me.lblHealthInfoValue, 2, 2)
        Me.tlpInfoPanel.Controls.Add(Me.lblHealthInfo, 1, 2)
        Me.tlpInfoPanel.Controls.Add(Me.picReliability, 0, 2)
        Me.tlpInfoPanel.Location = New System.Drawing.Point(70, 8)
        Me.tlpInfoPanel.Margin = New System.Windows.Forms.Padding(0, 8, 8, 8)
        Me.tlpInfoPanel.Name = "tlpInfoPanel"
        Me.tlpInfoPanel.RowCount = 3
        Me.tlpInfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpInfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpInfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpInfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpInfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpInfoPanel.Size = New System.Drawing.Size(284, 54)
        Me.tlpInfoPanel.TabIndex = 2
        '
        'lblDeviceName
        '
        Me.lblDeviceName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDeviceName.AutoSize = True
        Me.lblDeviceName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeviceName.ForeColor = System.Drawing.Color.Black
        Me.lblDeviceName.Location = New System.Drawing.Point(3, 2)
        Me.lblDeviceName.Name = "lblDeviceName"
        Me.lblDeviceName.Size = New System.Drawing.Size(90, 13)
        Me.lblDeviceName.TabIndex = 1
        Me.lblDeviceName.Text = "lblDeviceName"
        '
        'lblDeviceLocation
        '
        Me.lblDeviceLocation.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDeviceLocation.AutoSize = True
        Me.lblDeviceLocation.ForeColor = System.Drawing.Color.DimGray
        Me.lblDeviceLocation.Location = New System.Drawing.Point(3, 20)
        Me.lblDeviceLocation.Name = "lblDeviceLocation"
        Me.lblDeviceLocation.Size = New System.Drawing.Size(89, 13)
        Me.lblDeviceLocation.TabIndex = 3
        Me.lblDeviceLocation.Text = "lblDeviceLocation"
        '
        'lblTempInfo
        '
        Me.lblTempInfo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTempInfo.AutoSize = True
        Me.lblTempInfo.ForeColor = System.Drawing.Color.DimGray
        Me.lblTempInfo.Location = New System.Drawing.Point(124, 2)
        Me.lblTempInfo.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblTempInfo.Name = "lblTempInfo"
        Me.lblTempInfo.Size = New System.Drawing.Size(63, 13)
        Me.lblTempInfo.TabIndex = 8
        Me.lblTempInfo.Text = "lblTempInfo"
        '
        'lblTempInfoValue
        '
        Me.lblTempInfoValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTempInfoValue.AutoSize = True
        Me.lblTempInfoValue.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTempInfoValue.Location = New System.Drawing.Point(187, 2)
        Me.lblTempInfoValue.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblTempInfoValue.Name = "lblTempInfoValue"
        Me.lblTempInfoValue.Size = New System.Drawing.Size(89, 13)
        Me.lblTempInfoValue.TabIndex = 11
        Me.lblTempInfoValue.Text = "lblTempInfoValue"
        '
        'lblLife
        '
        Me.lblLife.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblLife.AutoSize = True
        Me.lblLife.ForeColor = System.Drawing.Color.DimGray
        Me.lblLife.Location = New System.Drawing.Point(153, 20)
        Me.lblLife.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblLife.Name = "lblLife"
        Me.lblLife.Size = New System.Drawing.Size(34, 13)
        Me.lblLife.TabIndex = 13
        Me.lblLife.Text = "lblLife"
        '
        'lblLifeValue
        '
        Me.lblLifeValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLifeValue.AutoSize = True
        Me.lblLifeValue.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblLifeValue.Location = New System.Drawing.Point(187, 20)
        Me.lblLifeValue.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblLifeValue.Name = "lblLifeValue"
        Me.lblLifeValue.Size = New System.Drawing.Size(60, 13)
        Me.lblLifeValue.TabIndex = 16
        Me.lblLifeValue.Text = "lblLifeValue"
        '
        'lblHealthInfoValue
        '
        Me.lblHealthInfoValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHealthInfoValue.AutoSize = True
        Me.lblHealthInfoValue.ForeColor = System.Drawing.Color.Black
        Me.lblHealthInfoValue.Location = New System.Drawing.Point(187, 38)
        Me.lblHealthInfoValue.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblHealthInfoValue.Name = "lblHealthInfoValue"
        Me.lblHealthInfoValue.Size = New System.Drawing.Size(94, 13)
        Me.lblHealthInfoValue.TabIndex = 20
        Me.lblHealthInfoValue.Text = "lblHealthInfoValue"
        '
        'lblHealthInfo
        '
        Me.lblHealthInfo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblHealthInfo.AutoSize = True
        Me.lblHealthInfo.ForeColor = System.Drawing.Color.DimGray
        Me.lblHealthInfo.Location = New System.Drawing.Point(119, 38)
        Me.lblHealthInfo.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblHealthInfo.Name = "lblHealthInfo"
        Me.lblHealthInfo.Size = New System.Drawing.Size(68, 13)
        Me.lblHealthInfo.TabIndex = 19
        Me.lblHealthInfo.Text = "lblHealthInfo"
        '
        'picReliability
        '
        Me.picReliability.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.picReliability.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picReliability.Location = New System.Drawing.Point(6, 40)
        Me.picReliability.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.picReliability.Name = "picReliability"
        Me.picReliability.Size = New System.Drawing.Size(100, 10)
        Me.picReliability.TabIndex = 12
        Me.picReliability.TabStop = False
        '
        'picDeviceImage
        '
        Me.picDeviceImage.BackColor = System.Drawing.Color.Transparent
        Me.picDeviceImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picDeviceImage.Location = New System.Drawing.Point(8, 8)
        Me.picDeviceImage.Margin = New System.Windows.Forms.Padding(8)
        Me.picDeviceImage.MinimumSize = New System.Drawing.Size(54, 54)
        Me.picDeviceImage.Name = "picDeviceImage"
        Me.picDeviceImage.Size = New System.Drawing.Size(54, 54)
        Me.picDeviceImage.TabIndex = 0
        Me.picDeviceImage.TabStop = False
        '
        'TrayPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(389, 90)
        Me.Controls.Add(Me.tlpDeviceInfo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TrayPanel"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "TrayPanel"
        Me.TopMost = True
        Me.tlpDeviceInfo.ResumeLayout(False)
        Me.tlpDeviceInfo.PerformLayout()
        Me.tlpInfoPanel.ResumeLayout(False)
        Me.tlpInfoPanel.PerformLayout()
        CType(Me.picReliability, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDeviceImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlpDeviceInfo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpInfoPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDeviceName As System.Windows.Forms.Label
    Friend WithEvents lblDeviceLocation As System.Windows.Forms.Label
    Friend WithEvents lblTempInfo As System.Windows.Forms.Label
    Friend WithEvents lblTempInfoValue As System.Windows.Forms.Label
    Friend WithEvents lblLife As System.Windows.Forms.Label
    Friend WithEvents lblLifeValue As System.Windows.Forms.Label
    Friend WithEvents lblHealthInfoValue As System.Windows.Forms.Label
    Friend WithEvents lblHealthInfo As System.Windows.Forms.Label
    Friend WithEvents picReliability As System.Windows.Forms.PictureBox
    Friend WithEvents picDeviceImage As System.Windows.Forms.PictureBox
End Class
