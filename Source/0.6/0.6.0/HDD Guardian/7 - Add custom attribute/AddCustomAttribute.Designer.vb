<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCustomAttribute
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
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.picSeparator = New System.Windows.Forms.PictureBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.cboFormat = New System.Windows.Forms.ComboBox()
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.cboID = New System.Windows.Forms.ComboBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.cboAttributes = New System.Windows.Forms.ComboBox()
        Me.lblAttribute = New System.Windows.Forms.Label()
        Me.lblAttributeFormat = New System.Windows.Forms.Label()
        Me.flwAttribute = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlBottom.SuspendLayout()
        CType(Me.picSeparator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flwAttribute.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlBottom.Controls.Add(Me.picSeparator)
        Me.pnlBottom.Controls.Add(Me.btnAdd)
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 191)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(489, 49)
        Me.pnlBottom.TabIndex = 10
        '
        'picSeparator
        '
        Me.picSeparator.BackgroundImage = Global.hdd_guardian.My.Resources.Resources.border
        Me.picSeparator.Dock = System.Windows.Forms.DockStyle.Top
        Me.picSeparator.Location = New System.Drawing.Point(0, 0)
        Me.picSeparator.Name = "picSeparator"
        Me.picSeparator.Size = New System.Drawing.Size(489, 8)
        Me.picSeparator.TabIndex = 0
        Me.picSeparator.TabStop = False
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
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(115, 138)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(240, 21)
        Me.txtName.TabIndex = 15
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(3, 138)
        Me.lblName.Margin = New System.Windows.Forms.Padding(3)
        Me.lblName.MaximumSize = New System.Drawing.Size(106, 0)
        Me.lblName.MinimumSize = New System.Drawing.Size(106, 21)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(106, 21)
        Me.lblName.TabIndex = 17
        Me.lblName.Text = "lblName"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFormat
        '
        Me.cboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.flwAttribute.SetFlowBreak(Me.cboFormat, True)
        Me.cboFormat.FormattingEnabled = True
        Me.cboFormat.Location = New System.Drawing.Point(115, 84)
        Me.cboFormat.Name = "cboFormat"
        Me.cboFormat.Size = New System.Drawing.Size(240, 21)
        Me.cboFormat.TabIndex = 14
        '
        'lblFormat
        '
        Me.lblFormat.AutoSize = True
        Me.lblFormat.ForeColor = System.Drawing.Color.Black
        Me.lblFormat.Location = New System.Drawing.Point(3, 84)
        Me.lblFormat.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFormat.MaximumSize = New System.Drawing.Size(106, 0)
        Me.lblFormat.MinimumSize = New System.Drawing.Size(106, 21)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(106, 21)
        Me.lblFormat.TabIndex = 16
        Me.lblFormat.Text = "lblFormat"
        Me.lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboID
        '
        Me.cboID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.flwAttribute.SetFlowBreak(Me.cboID, True)
        Me.cboID.FormattingEnabled = True
        Me.cboID.Location = New System.Drawing.Point(115, 57)
        Me.cboID.Name = "cboID"
        Me.cboID.Size = New System.Drawing.Size(240, 21)
        Me.cboID.TabIndex = 12
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.ForeColor = System.Drawing.Color.Black
        Me.lblID.Location = New System.Drawing.Point(3, 57)
        Me.lblID.Margin = New System.Windows.Forms.Padding(3)
        Me.lblID.MaximumSize = New System.Drawing.Size(106, 0)
        Me.lblID.MinimumSize = New System.Drawing.Size(106, 21)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(106, 21)
        Me.lblID.TabIndex = 13
        Me.lblID.Text = "lblID"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAttributes
        '
        Me.cboAttributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.flwAttribute.SetFlowBreak(Me.cboAttributes, True)
        Me.cboAttributes.FormattingEnabled = True
        Me.cboAttributes.Location = New System.Drawing.Point(3, 3)
        Me.cboAttributes.Name = "cboAttributes"
        Me.cboAttributes.Size = New System.Drawing.Size(352, 21)
        Me.cboAttributes.TabIndex = 11
        '
        'lblAttribute
        '
        Me.lblAttribute.AutoSize = True
        Me.flwAttribute.SetFlowBreak(Me.lblAttribute, True)
        Me.lblAttribute.ForeColor = System.Drawing.Color.DimGray
        Me.lblAttribute.Location = New System.Drawing.Point(20, 29)
        Me.lblAttribute.Margin = New System.Windows.Forms.Padding(20, 2, 3, 7)
        Me.lblAttribute.Name = "lblAttribute"
        Me.lblAttribute.Size = New System.Drawing.Size(60, 13)
        Me.lblAttribute.TabIndex = 18
        Me.lblAttribute.Text = "lblAttribute"
        '
        'lblAttributeFormat
        '
        Me.lblAttributeFormat.AutoSize = True
        Me.flwAttribute.SetFlowBreak(Me.lblAttributeFormat, True)
        Me.lblAttributeFormat.ForeColor = System.Drawing.Color.DimGray
        Me.lblAttributeFormat.Location = New System.Drawing.Point(20, 110)
        Me.lblAttributeFormat.Margin = New System.Windows.Forms.Padding(20, 2, 3, 7)
        Me.lblAttributeFormat.Name = "lblAttributeFormat"
        Me.lblAttributeFormat.Size = New System.Drawing.Size(94, 13)
        Me.lblAttributeFormat.TabIndex = 19
        Me.lblAttributeFormat.Text = "lblAttributeFormat"
        '
        'flwAttribute
        '
        Me.flwAttribute.AutoSize = True
        Me.flwAttribute.Controls.Add(Me.cboAttributes)
        Me.flwAttribute.Controls.Add(Me.lblAttribute)
        Me.flwAttribute.Controls.Add(Me.lblID)
        Me.flwAttribute.Controls.Add(Me.cboID)
        Me.flwAttribute.Controls.Add(Me.lblFormat)
        Me.flwAttribute.Controls.Add(Me.cboFormat)
        Me.flwAttribute.Controls.Add(Me.lblAttributeFormat)
        Me.flwAttribute.Controls.Add(Me.lblName)
        Me.flwAttribute.Controls.Add(Me.txtName)
        Me.flwAttribute.Dock = System.Windows.Forms.DockStyle.Top
        Me.flwAttribute.Location = New System.Drawing.Point(0, 0)
        Me.flwAttribute.Name = "flwAttribute"
        Me.flwAttribute.Size = New System.Drawing.Size(489, 162)
        Me.flwAttribute.TabIndex = 20
        '
        'AddCustomAttribute
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(489, 240)
        Me.Controls.Add(Me.flwAttribute)
        Me.Controls.Add(Me.pnlBottom)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddCustomAttribute"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AddCustomAttribute"
        Me.pnlBottom.ResumeLayout(False)
        CType(Me.picSeparator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flwAttribute.ResumeLayout(False)
        Me.flwAttribute.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents picSeparator As System.Windows.Forms.PictureBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cboFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblFormat As System.Windows.Forms.Label
    Friend WithEvents cboID As System.Windows.Forms.ComboBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents cboAttributes As System.Windows.Forms.ComboBox
    Friend WithEvents flwAttribute As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblAttribute As System.Windows.Forms.Label
    Friend WithEvents lblAttributeFormat As System.Windows.Forms.Label
End Class
