<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskEditor
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
        Me.btnSet = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tlpTask = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDevice = New System.Windows.Forms.Label()
        Me.dtTime = New System.Windows.Forms.DateTimePicker()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.cboDevice = New System.Windows.Forms.ComboBox()
        Me.lblTest = New System.Windows.Forms.Label()
        Me.cboTest = New System.Windows.Forms.ComboBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.tlpDays = New System.Windows.Forms.TableLayoutPanel()
        Me.chkDay0 = New System.Windows.Forms.CheckBox()
        Me.chkDay5 = New System.Windows.Forms.CheckBox()
        Me.chkDay3 = New System.Windows.Forms.CheckBox()
        Me.chkDay2 = New System.Windows.Forms.CheckBox()
        Me.chkDay1 = New System.Windows.Forms.CheckBox()
        Me.chkDay4 = New System.Windows.Forms.CheckBox()
        Me.chkDay6 = New System.Windows.Forms.CheckBox()
        Me.lblTestDuration = New System.Windows.Forms.Label()
        Me.flwSpan = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSpan = New System.Windows.Forms.Label()
        Me.numSpan = New System.Windows.Forms.NumericUpDown()
        Me.lblSpanType = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.pnlBorder = New System.Windows.Forms.Panel()
        Me.tlpTask.SuspendLayout()
        Me.tlpDays.SuspendLayout()
        Me.flwSpan.SuspendLayout()
        CType(Me.numSpan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(392, 16)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(75, 23)
        Me.btnSet.TabIndex = 16
        Me.btnSet.Text = "btnSet"
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(472, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tlpTask
        '
        Me.tlpTask.AutoSize = True
        Me.tlpTask.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTask.ColumnCount = 2
        Me.tlpTask.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTask.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTask.Controls.Add(Me.lblDevice, 0, 0)
        Me.tlpTask.Controls.Add(Me.dtTime, 1, 6)
        Me.tlpTask.Controls.Add(Me.lblTime, 0, 6)
        Me.tlpTask.Controls.Add(Me.cboDevice, 1, 0)
        Me.tlpTask.Controls.Add(Me.lblTest, 0, 1)
        Me.tlpTask.Controls.Add(Me.cboTest, 1, 1)
        Me.tlpTask.Controls.Add(Me.lblType, 0, 3)
        Me.tlpTask.Controls.Add(Me.cboType, 1, 3)
        Me.tlpTask.Controls.Add(Me.tlpDays, 1, 5)
        Me.tlpTask.Controls.Add(Me.lblTestDuration, 1, 2)
        Me.tlpTask.Controls.Add(Me.flwSpan, 1, 4)
        Me.tlpTask.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpTask.Location = New System.Drawing.Point(0, 0)
        Me.tlpTask.Name = "tlpTask"
        Me.tlpTask.RowCount = 7
        Me.tlpTask.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTask.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTask.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTask.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTask.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTask.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTask.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTask.Size = New System.Drawing.Size(560, 220)
        Me.tlpTask.TabIndex = 14
        '
        'lblDevice
        '
        Me.lblDevice.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDevice.AutoSize = True
        Me.lblDevice.Location = New System.Drawing.Point(3, 7)
        Me.lblDevice.Name = "lblDevice"
        Me.lblDevice.Size = New System.Drawing.Size(49, 13)
        Me.lblDevice.TabIndex = 8
        Me.lblDevice.Text = "lblDevice"
        '
        'dtTime
        '
        Me.dtTime.CustomFormat = "HH:mm"
        Me.dtTime.Location = New System.Drawing.Point(58, 196)
        Me.dtTime.Name = "dtTime"
        Me.dtTime.ShowUpDown = True
        Me.dtTime.Size = New System.Drawing.Size(84, 21)
        Me.dtTime.TabIndex = 4
        Me.dtTime.Value = New Date(2016, 2, 24, 12, 0, 0, 0)
        '
        'lblTime
        '
        Me.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(3, 200)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(39, 13)
        Me.lblTime.TabIndex = 7
        Me.lblTime.Text = "lblTime"
        '
        'cboDevice
        '
        Me.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDevice.FormattingEnabled = True
        Me.cboDevice.Location = New System.Drawing.Point(58, 3)
        Me.cboDevice.Name = "cboDevice"
        Me.cboDevice.Size = New System.Drawing.Size(197, 21)
        Me.cboDevice.TabIndex = 0
        '
        'lblTest
        '
        Me.lblTest.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTest.AutoSize = True
        Me.lblTest.Location = New System.Drawing.Point(3, 34)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(38, 13)
        Me.lblTest.TabIndex = 10
        Me.lblTest.Text = "lblTest"
        '
        'cboTest
        '
        Me.cboTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTest.FormattingEnabled = True
        Me.cboTest.Location = New System.Drawing.Point(58, 30)
        Me.cboTest.Name = "cboTest"
        Me.cboTest.Size = New System.Drawing.Size(197, 21)
        Me.cboTest.TabIndex = 1
        '
        'lblType
        '
        Me.lblType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(3, 88)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(41, 13)
        Me.lblType.TabIndex = 12
        Me.lblType.Text = "lblType"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(58, 84)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(197, 21)
        Me.cboType.TabIndex = 2
        '
        'tlpDays
        '
        Me.tlpDays.AutoSize = True
        Me.tlpDays.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDays.ColumnCount = 4
        Me.tlpDays.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpDays.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpDays.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpDays.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpDays.Controls.Add(Me.chkDay0, 0, 0)
        Me.tlpDays.Controls.Add(Me.chkDay5, 1, 1)
        Me.tlpDays.Controls.Add(Me.chkDay3, 3, 0)
        Me.tlpDays.Controls.Add(Me.chkDay2, 2, 0)
        Me.tlpDays.Controls.Add(Me.chkDay1, 1, 0)
        Me.tlpDays.Controls.Add(Me.chkDay4, 0, 1)
        Me.tlpDays.Controls.Add(Me.chkDay6, 2, 1)
        Me.tlpDays.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpDays.Location = New System.Drawing.Point(58, 144)
        Me.tlpDays.Name = "tlpDays"
        Me.tlpDays.RowCount = 2
        Me.tlpDays.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDays.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDays.Size = New System.Drawing.Size(499, 46)
        Me.tlpDays.TabIndex = 3
        '
        'chkDay0
        '
        Me.chkDay0.AutoSize = True
        Me.chkDay0.Location = New System.Drawing.Point(3, 3)
        Me.chkDay0.Name = "chkDay0"
        Me.chkDay0.Size = New System.Drawing.Size(67, 17)
        Me.chkDay0.TabIndex = 0
        Me.chkDay0.Text = "chkDay0"
        Me.chkDay0.UseVisualStyleBackColor = True
        '
        'chkDay5
        '
        Me.chkDay5.AutoSize = True
        Me.chkDay5.Location = New System.Drawing.Point(127, 26)
        Me.chkDay5.Name = "chkDay5"
        Me.chkDay5.Size = New System.Drawing.Size(67, 17)
        Me.chkDay5.TabIndex = 5
        Me.chkDay5.Text = "chkDay5"
        Me.chkDay5.UseVisualStyleBackColor = True
        '
        'chkDay3
        '
        Me.chkDay3.AutoSize = True
        Me.chkDay3.Location = New System.Drawing.Point(375, 3)
        Me.chkDay3.Name = "chkDay3"
        Me.chkDay3.Size = New System.Drawing.Size(67, 17)
        Me.chkDay3.TabIndex = 3
        Me.chkDay3.Text = "chkDay3"
        Me.chkDay3.UseVisualStyleBackColor = True
        '
        'chkDay2
        '
        Me.chkDay2.AutoSize = True
        Me.chkDay2.Location = New System.Drawing.Point(251, 3)
        Me.chkDay2.Name = "chkDay2"
        Me.chkDay2.Size = New System.Drawing.Size(67, 17)
        Me.chkDay2.TabIndex = 2
        Me.chkDay2.Text = "chkDay2"
        Me.chkDay2.UseVisualStyleBackColor = True
        '
        'chkDay1
        '
        Me.chkDay1.AutoSize = True
        Me.chkDay1.Location = New System.Drawing.Point(127, 3)
        Me.chkDay1.Name = "chkDay1"
        Me.chkDay1.Size = New System.Drawing.Size(67, 17)
        Me.chkDay1.TabIndex = 1
        Me.chkDay1.Text = "chkDay1"
        Me.chkDay1.UseVisualStyleBackColor = True
        '
        'chkDay4
        '
        Me.chkDay4.AutoSize = True
        Me.chkDay4.Location = New System.Drawing.Point(3, 26)
        Me.chkDay4.Name = "chkDay4"
        Me.chkDay4.Size = New System.Drawing.Size(67, 17)
        Me.chkDay4.TabIndex = 4
        Me.chkDay4.Text = "chkDay4"
        Me.chkDay4.UseVisualStyleBackColor = True
        '
        'chkDay6
        '
        Me.chkDay6.AutoSize = True
        Me.chkDay6.Location = New System.Drawing.Point(251, 26)
        Me.chkDay6.Name = "chkDay6"
        Me.chkDay6.Size = New System.Drawing.Size(67, 17)
        Me.chkDay6.TabIndex = 6
        Me.chkDay6.Text = "chkDay6"
        Me.chkDay6.UseVisualStyleBackColor = True
        '
        'lblTestDuration
        '
        Me.lblTestDuration.AutoSize = True
        Me.lblTestDuration.Location = New System.Drawing.Point(58, 57)
        Me.lblTestDuration.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTestDuration.MinimumSize = New System.Drawing.Size(0, 21)
        Me.lblTestDuration.Name = "lblTestDuration"
        Me.lblTestDuration.Size = New System.Drawing.Size(79, 21)
        Me.lblTestDuration.TabIndex = 16
        Me.lblTestDuration.Text = "lblTestDuration"
        Me.lblTestDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'flwSpan
        '
        Me.flwSpan.AutoSize = True
        Me.flwSpan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flwSpan.Controls.Add(Me.lblSpan)
        Me.flwSpan.Controls.Add(Me.numSpan)
        Me.flwSpan.Controls.Add(Me.lblSpanType)
        Me.flwSpan.Location = New System.Drawing.Point(58, 111)
        Me.flwSpan.Name = "flwSpan"
        Me.flwSpan.Size = New System.Drawing.Size(165, 27)
        Me.flwSpan.TabIndex = 17
        '
        'lblSpan
        '
        Me.lblSpan.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSpan.AutoSize = True
        Me.lblSpan.Location = New System.Drawing.Point(3, 7)
        Me.lblSpan.Name = "lblSpan"
        Me.lblSpan.Size = New System.Drawing.Size(41, 13)
        Me.lblSpan.TabIndex = 0
        Me.lblSpan.Text = "lblSpan"
        '
        'numSpan
        '
        Me.numSpan.Location = New System.Drawing.Point(50, 3)
        Me.numSpan.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSpan.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSpan.Name = "numSpan"
        Me.numSpan.Size = New System.Drawing.Size(41, 21)
        Me.numSpan.TabIndex = 1
        Me.numSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numSpan.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblSpanType
        '
        Me.lblSpanType.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSpanType.AutoSize = True
        Me.lblSpanType.Location = New System.Drawing.Point(97, 7)
        Me.lblSpanType.Name = "lblSpanType"
        Me.lblSpanType.Size = New System.Drawing.Size(65, 13)
        Me.lblSpanType.TabIndex = 2
        Me.lblSpanType.Text = "lblSpanType"
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlBottom.Controls.Add(Me.pnlBorder)
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Controls.Add(Me.btnSet)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 282)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(560, 48)
        Me.pnlBottom.TabIndex = 17
        '
        'pnlBorder
        '
        Me.pnlBorder.BackgroundImage = Global.hdd_guardian.My.Resources.Resources.border
        Me.pnlBorder.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBorder.Location = New System.Drawing.Point(0, 0)
        Me.pnlBorder.Name = "pnlBorder"
        Me.pnlBorder.Size = New System.Drawing.Size(560, 8)
        Me.pnlBorder.TabIndex = 17
        '
        'TaskEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(560, 330)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.tlpTask)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TaskEditor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TaskEditor"
        Me.tlpTask.ResumeLayout(False)
        Me.tlpTask.PerformLayout()
        Me.tlpDays.ResumeLayout(False)
        Me.tlpDays.PerformLayout()
        Me.flwSpan.ResumeLayout(False)
        Me.flwSpan.PerformLayout()
        CType(Me.numSpan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSet As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tlpTask As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDevice As System.Windows.Forms.Label
    Friend WithEvents dtTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents cboDevice As System.Windows.Forms.ComboBox
    Friend WithEvents lblTest As System.Windows.Forms.Label
    Friend WithEvents cboTest As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents tlpDays As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkDay0 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDay5 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDay3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDay2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDay1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDay4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDay6 As System.Windows.Forms.CheckBox
    Friend WithEvents lblTestDuration As System.Windows.Forms.Label
    Friend WithEvents flwSpan As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblSpan As System.Windows.Forms.Label
    Friend WithEvents numSpan As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSpanType As System.Windows.Forms.Label
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents pnlBorder As System.Windows.Forms.Panel
End Class
