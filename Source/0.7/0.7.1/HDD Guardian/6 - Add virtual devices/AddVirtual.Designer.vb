<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddVirtualDevice
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
        Dim tlpVirtual As System.Windows.Forms.TableLayoutPanel
        Me.tlpBrowseFile = New System.Windows.Forms.TableLayoutPanel()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.dlgVirtual = New System.Windows.Forms.OpenFileDialog()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.picSeparator = New System.Windows.Forms.PictureBox()
        tlpVirtual = New System.Windows.Forms.TableLayoutPanel()
        tlpVirtual.SuspendLayout()
        Me.tlpBrowseFile.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        CType(Me.picSeparator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpVirtual
        '
        tlpVirtual.AutoSize = True
        tlpVirtual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpVirtual.BackColor = System.Drawing.Color.Transparent
        tlpVirtual.ColumnCount = 2
        tlpVirtual.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpVirtual.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpVirtual.Controls.Add(Me.tlpBrowseFile, 1, 1)
        tlpVirtual.Controls.Add(Me.lblDescription, 0, 0)
        tlpVirtual.Controls.Add(Me.txtDescription, 1, 0)
        tlpVirtual.Controls.Add(Me.lblLocation, 0, 1)
        tlpVirtual.Dock = System.Windows.Forms.DockStyle.Top
        tlpVirtual.Location = New System.Drawing.Point(0, 10)
        tlpVirtual.Name = "tlpVirtual"
        tlpVirtual.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        tlpVirtual.RowCount = 2
        tlpVirtual.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpVirtual.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpVirtual.Size = New System.Drawing.Size(492, 56)
        tlpVirtual.TabIndex = 6
        '
        'tlpBrowseFile
        '
        Me.tlpBrowseFile.AutoSize = True
        Me.tlpBrowseFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpBrowseFile.ColumnCount = 2
        Me.tlpBrowseFile.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpBrowseFile.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpBrowseFile.Controls.Add(Me.btnBrowse, 1, 0)
        Me.tlpBrowseFile.Controls.Add(Me.lblFile, 0, 0)
        Me.tlpBrowseFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpBrowseFile.Location = New System.Drawing.Point(81, 27)
        Me.tlpBrowseFile.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpBrowseFile.Name = "tlpBrowseFile"
        Me.tlpBrowseFile.RowCount = 1
        Me.tlpBrowseFile.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpBrowseFile.Size = New System.Drawing.Size(406, 29)
        Me.tlpBrowseFile.TabIndex = 10
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnBrowse.Location = New System.Drawing.Point(374, 3)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(29, 23)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblFile
        '
        Me.lblFile.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFile.AutoEllipsis = True
        Me.lblFile.AutoSize = True
        Me.lblFile.ForeColor = System.Drawing.Color.DimGray
        Me.lblFile.Location = New System.Drawing.Point(3, 8)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(33, 13)
        Me.lblFile.TabIndex = 5
        Me.lblFile.Text = "lblFile"
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDescription.AutoSize = True
        Me.lblDescription.ForeColor = System.Drawing.Color.Black
        Me.lblDescription.Location = New System.Drawing.Point(8, 7)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(70, 13)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "lblDescription"
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtDescription.Location = New System.Drawing.Point(84, 3)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(400, 21)
        Me.txtDescription.TabIndex = 4
        '
        'lblLocation
        '
        Me.lblLocation.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLocation.AutoSize = True
        Me.lblLocation.ForeColor = System.Drawing.Color.Black
        Me.lblLocation.Location = New System.Drawing.Point(8, 35)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(57, 13)
        Me.lblLocation.TabIndex = 2
        Me.lblLocation.Text = "lblLocation"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(328, 16)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "btnAdd"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(408, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dlgVirtual
        '
        Me.dlgVirtual.FileName = "OpenFileDialog1"
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlBottom.Controls.Add(Me.picSeparator)
        Me.pnlBottom.Controls.Add(Me.btnAdd)
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 121)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(492, 48)
        Me.pnlBottom.TabIndex = 9
        '
        'picSeparator
        '
        Me.picSeparator.BackgroundImage = Global.hdd_guardian.My.Resources.Resources.border
        Me.picSeparator.Dock = System.Windows.Forms.DockStyle.Top
        Me.picSeparator.Location = New System.Drawing.Point(0, 0)
        Me.picSeparator.Name = "picSeparator"
        Me.picSeparator.Size = New System.Drawing.Size(492, 8)
        Me.picSeparator.TabIndex = 0
        Me.picSeparator.TabStop = False
        '
        'AddVirtualDevice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(492, 169)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(tlpVirtual)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddVirtualDevice"
        Me.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AddVirtual"
        tlpVirtual.ResumeLayout(False)
        tlpVirtual.PerformLayout()
        Me.tlpBrowseFile.ResumeLayout(False)
        Me.tlpBrowseFile.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        CType(Me.picSeparator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dlgVirtual As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents picSeparator As System.Windows.Forms.PictureBox
    Friend WithEvents tlpBrowseFile As System.Windows.Forms.TableLayoutPanel
End Class
