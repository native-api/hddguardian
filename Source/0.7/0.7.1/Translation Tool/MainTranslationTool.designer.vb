<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainTranslationTool
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainTranslationTool))
        Me.ttFolder = New System.Windows.Forms.ToolTip()
        Me.tlpMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.tlpProgress = New System.Windows.Forms.TableLayoutPanel()
        Me.lblInterface = New System.Windows.Forms.Label()
        Me.lblAttributes = New System.Windows.Forms.Label()
        Me.fpbInterface = New translationtool.FlatProgressBar()
        Me.fpbAttributes = New translationtool.FlatProgressBar()
        Me.lblCultureTranslated = New System.Windows.Forms.Label()
        Me.lblChoosenCulture = New System.Windows.Forms.Label()
        Me.lblTranlsationInterface = New System.Windows.Forms.Label()
        Me.lblTranslationAttributes = New System.Windows.Forms.Label()
        Me.RibbonVerticalSeparator4 = New translationtool.RibbonVerticalSeparator()
        Me.RibbonVerticalSeparator3 = New translationtool.RibbonVerticalSeparator()
        Me.lblTranslation = New System.Windows.Forms.Label()
        Me.robProject = New translationtool.RibbonOptionButton()
        Me.tlpTranslation = New System.Windows.Forms.TableLayoutPanel()
        Me.robInterface = New translationtool.RibbonOptionButton()
        Me.robAttributes = New translationtool.RibbonOptionButton()
        Me.lblProject = New System.Windows.Forms.Label()
        Me.RibbonVerticalSeparator1 = New translationtool.RibbonVerticalSeparator()
        Me.RibbonVerticalSeparator2 = New translationtool.RibbonVerticalSeparator()
        Me.RibbonHorizontalSeparator1 = New translationtool.RibbonHorizontalSeparator()
        Me.htcMain = New translationtool.HeadlessTabControl()
        Me.tpMangement = New System.Windows.Forms.TabPage()
        Me.tlpLanguage = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpVersion = New System.Windows.Forms.TableLayoutPanel()
        Me.txtRevision = New System.Windows.Forms.TextBox()
        Me.txtMinor = New System.Windows.Forms.TextBox()
        Me.txtMajor = New System.Windows.Forms.TextBox()
        Me.lblMajor = New System.Windows.Forms.Label()
        Me.lblMinor = New System.Windows.Forms.Label()
        Me.lblRevision = New System.Windows.Forms.Label()
        Me.btnFolder = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblCulture = New System.Windows.Forms.Label()
        Me.cboCulture = New System.Windows.Forms.ComboBox()
        Me.lblSelLanguage = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.lblLanguage = New System.Windows.Forms.Label()
        Me.txtTranslator = New System.Windows.Forms.TextBox()
        Me.txtLanguage = New System.Windows.Forms.TextBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblTranslator = New System.Windows.Forms.Label()
        Me.lblVersionNote = New System.Windows.Forms.Label()
        Me.tpInterface = New System.Windows.Forms.TabPage()
        Me.tlpInterface = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.lvwTranslation = New System.Windows.Forms.ListView()
        Me.chDefaultCulture = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNewCulture = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtDefault = New System.Windows.Forms.TextBox()
        Me.txtNew = New System.Windows.Forms.TextBox()
        Me.lblDefault = New System.Windows.Forms.Label()
        Me.lblNew = New System.Windows.Forms.Label()
        Me.tpAttributes = New System.Windows.Forms.TabPage()
        Me.tlpAttributes = New System.Windows.Forms.TableLayoutPanel()
        Me.lvwAttributes = New System.Windows.Forms.ListView()
        Me.chItemName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDefaultAttr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNewAttr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnNextAttr = New System.Windows.Forms.Button()
        Me.lblDefaultAttr = New System.Windows.Forms.Label()
        Me.txtNewAttr = New System.Windows.Forms.TextBox()
        Me.txtDefaultAttr = New System.Windows.Forms.TextBox()
        Me.lblNewAttr = New System.Windows.Forms.Label()
        Me.tlpMenu.SuspendLayout()
        Me.tlpProgress.SuspendLayout()
        Me.tlpTranslation.SuspendLayout()
        Me.htcMain.SuspendLayout()
        Me.tpMangement.SuspendLayout()
        Me.tlpLanguage.SuspendLayout()
        Me.tlpVersion.SuspendLayout()
        Me.tpInterface.SuspendLayout()
        Me.tlpInterface.SuspendLayout()
        Me.tpAttributes.SuspendLayout()
        Me.tlpAttributes.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMenu
        '
        Me.tlpMenu.AutoSize = True
        Me.tlpMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tlpMenu.ColumnCount = 6
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenu.Controls.Add(Me.lblProgress, 4, 1)
        Me.tlpMenu.Controls.Add(Me.tlpProgress, 4, 0)
        Me.tlpMenu.Controls.Add(Me.RibbonVerticalSeparator4, 3, 1)
        Me.tlpMenu.Controls.Add(Me.RibbonVerticalSeparator3, 3, 0)
        Me.tlpMenu.Controls.Add(Me.lblTranslation, 2, 1)
        Me.tlpMenu.Controls.Add(Me.robProject, 0, 0)
        Me.tlpMenu.Controls.Add(Me.tlpTranslation, 2, 0)
        Me.tlpMenu.Controls.Add(Me.lblProject, 0, 1)
        Me.tlpMenu.Controls.Add(Me.RibbonVerticalSeparator1, 1, 0)
        Me.tlpMenu.Controls.Add(Me.RibbonVerticalSeparator2, 1, 1)
        Me.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlpMenu.Name = "tlpMenu"
        Me.tlpMenu.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.tlpMenu.RowCount = 2
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenu.Size = New System.Drawing.Size(816, 110)
        Me.tlpMenu.TabIndex = 2
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblProgress.AutoSize = True
        Me.lblProgress.ForeColor = System.Drawing.Color.Silver
        Me.lblProgress.Location = New System.Drawing.Point(406, 91)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(105, 13)
        Me.lblProgress.TabIndex = 29
        Me.lblProgress.Text = "Translation progress"
        '
        'tlpProgress
        '
        Me.tlpProgress.AutoSize = True
        Me.tlpProgress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpProgress.ColumnCount = 3
        Me.tlpProgress.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpProgress.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpProgress.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpProgress.Controls.Add(Me.lblInterface, 0, 1)
        Me.tlpProgress.Controls.Add(Me.lblAttributes, 0, 2)
        Me.tlpProgress.Controls.Add(Me.fpbInterface, 1, 1)
        Me.tlpProgress.Controls.Add(Me.fpbAttributes, 1, 2)
        Me.tlpProgress.Controls.Add(Me.lblCultureTranslated, 0, 0)
        Me.tlpProgress.Controls.Add(Me.lblChoosenCulture, 1, 0)
        Me.tlpProgress.Controls.Add(Me.lblTranlsationInterface, 2, 1)
        Me.tlpProgress.Controls.Add(Me.lblTranslationAttributes, 2, 2)
        Me.tlpProgress.Location = New System.Drawing.Point(214, 6)
        Me.tlpProgress.Name = "tlpProgress"
        Me.tlpProgress.RowCount = 3
        Me.tlpProgress.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpProgress.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpProgress.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpProgress.Size = New System.Drawing.Size(489, 58)
        Me.tlpProgress.TabIndex = 3
        '
        'lblInterface
        '
        Me.lblInterface.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblInterface.AutoSize = True
        Me.lblInterface.ForeColor = System.Drawing.Color.Black
        Me.lblInterface.Location = New System.Drawing.Point(49, 23)
        Me.lblInterface.Name = "lblInterface"
        Me.lblInterface.Size = New System.Drawing.Size(52, 13)
        Me.lblInterface.TabIndex = 0
        Me.lblInterface.Text = "Interface"
        '
        'lblAttributes
        '
        Me.lblAttributes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblAttributes.AutoSize = True
        Me.lblAttributes.ForeColor = System.Drawing.Color.Black
        Me.lblAttributes.Location = New System.Drawing.Point(3, 42)
        Me.lblAttributes.Name = "lblAttributes"
        Me.lblAttributes.Size = New System.Drawing.Size(98, 13)
        Me.lblAttributes.TabIndex = 1
        Me.lblAttributes.Text = "Attributes meaning"
        '
        'fpbInterface
        '
        Me.fpbInterface.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.fpbInterface.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.fpbInterface.Barcolor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.fpbInterface.Location = New System.Drawing.Point(107, 23)
        Me.fpbInterface.MaxValue = 253
        Me.fpbInterface.Name = "fpbInterface"
        Me.fpbInterface.Padding = New System.Windows.Forms.Padding(1)
        Me.fpbInterface.Size = New System.Drawing.Size(255, 13)
        Me.fpbInterface.TabIndex = 2
        Me.fpbInterface.Value = 50
        '
        'fpbAttributes
        '
        Me.fpbAttributes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.fpbAttributes.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.fpbAttributes.Barcolor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.fpbAttributes.Location = New System.Drawing.Point(107, 42)
        Me.fpbAttributes.MaxValue = 253
        Me.fpbAttributes.Name = "fpbAttributes"
        Me.fpbAttributes.Padding = New System.Windows.Forms.Padding(1)
        Me.fpbAttributes.Size = New System.Drawing.Size(255, 13)
        Me.fpbAttributes.TabIndex = 3
        Me.fpbAttributes.Value = 50
        '
        'lblCultureTranslated
        '
        Me.lblCultureTranslated.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCultureTranslated.AutoSize = True
        Me.lblCultureTranslated.ForeColor = System.Drawing.Color.Black
        Me.lblCultureTranslated.Location = New System.Drawing.Point(59, 3)
        Me.lblCultureTranslated.Name = "lblCultureTranslated"
        Me.lblCultureTranslated.Size = New System.Drawing.Size(42, 13)
        Me.lblCultureTranslated.TabIndex = 4
        Me.lblCultureTranslated.Text = "Culture"
        '
        'lblChoosenCulture
        '
        Me.lblChoosenCulture.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblChoosenCulture.AutoSize = True
        Me.lblChoosenCulture.ForeColor = System.Drawing.Color.Black
        Me.lblChoosenCulture.Location = New System.Drawing.Point(107, 3)
        Me.lblChoosenCulture.Name = "lblChoosenCulture"
        Me.lblChoosenCulture.Size = New System.Drawing.Size(94, 13)
        Me.lblChoosenCulture.TabIndex = 5
        Me.lblChoosenCulture.Text = "lblChoosenCulture"
        '
        'lblTranlsationInterface
        '
        Me.lblTranlsationInterface.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTranlsationInterface.AutoSize = True
        Me.lblTranlsationInterface.Location = New System.Drawing.Point(368, 23)
        Me.lblTranlsationInterface.Name = "lblTranlsationInterface"
        Me.lblTranlsationInterface.Size = New System.Drawing.Size(115, 13)
        Me.lblTranlsationInterface.TabIndex = 6
        Me.lblTranlsationInterface.Text = "lblTranlsationInterface"
        '
        'lblTranslationAttributes
        '
        Me.lblTranslationAttributes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTranslationAttributes.AutoSize = True
        Me.lblTranslationAttributes.Location = New System.Drawing.Point(368, 42)
        Me.lblTranslationAttributes.Name = "lblTranslationAttributes"
        Me.lblTranslationAttributes.Size = New System.Drawing.Size(118, 13)
        Me.lblTranslationAttributes.TabIndex = 7
        Me.lblTranslationAttributes.Text = "lblTranslationAttributes"
        '
        'RibbonVerticalSeparator4
        '
        Me.RibbonVerticalSeparator4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonVerticalSeparator4.Location = New System.Drawing.Point(207, 81)
        Me.RibbonVerticalSeparator4.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.RibbonVerticalSeparator4.MaximumSize = New System.Drawing.Size(1, 0)
        Me.RibbonVerticalSeparator4.Name = "RibbonVerticalSeparator4"
        Me.RibbonVerticalSeparator4.Size = New System.Drawing.Size(1, 26)
        Me.RibbonVerticalSeparator4.TabIndex = 29
        '
        'RibbonVerticalSeparator3
        '
        Me.RibbonVerticalSeparator3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonVerticalSeparator3.Location = New System.Drawing.Point(207, 3)
        Me.RibbonVerticalSeparator3.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.RibbonVerticalSeparator3.MaximumSize = New System.Drawing.Size(1, 0)
        Me.RibbonVerticalSeparator3.Name = "RibbonVerticalSeparator3"
        Me.RibbonVerticalSeparator3.Size = New System.Drawing.Size(1, 78)
        Me.RibbonVerticalSeparator3.TabIndex = 29
        '
        'lblTranslation
        '
        Me.lblTranslation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTranslation.AutoSize = True
        Me.lblTranslation.ForeColor = System.Drawing.Color.Silver
        Me.lblTranslation.Location = New System.Drawing.Point(93, 91)
        Me.lblTranslation.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.lblTranslation.Name = "lblTranslation"
        Me.lblTranslation.Size = New System.Drawing.Size(102, 13)
        Me.lblTranslation.TabIndex = 28
        Me.lblTranslation.Text = "Translation sections"
        '
        'robProject
        '
        Me.robProject.AutoSize = True
        Me.robProject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robProject.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robProject.ButtonStyle = translationtool.RibbonOptionButton.Style.Big
        Me.robProject.Icon = Global.translationtool.My.Resources.Resources.applications_development_translation
        Me.robProject.Location = New System.Drawing.Point(5, 8)
        Me.robProject.Margin = New System.Windows.Forms.Padding(5, 5, 2, 5)
        Me.robProject.MaximumSize = New System.Drawing.Size(80, 68)
        Me.robProject.MinimumSize = New System.Drawing.Size(0, 68)
        Me.robProject.Name = "robProject"
        Me.robProject.Size = New System.Drawing.Size(71, 68)
        Me.robProject.TabIndex = 0
        Me.robProject.Text = "Project management"
        '
        'tlpTranslation
        '
        Me.tlpTranslation.AutoSize = True
        Me.tlpTranslation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTranslation.ColumnCount = 2
        Me.tlpTranslation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTranslation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTranslation.Controls.Add(Me.robInterface, 0, 0)
        Me.tlpTranslation.Controls.Add(Me.robAttributes, 1, 0)
        Me.tlpTranslation.Location = New System.Drawing.Point(85, 3)
        Me.tlpTranslation.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpTranslation.Name = "tlpTranslation"
        Me.tlpTranslation.RowCount = 1
        Me.tlpTranslation.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTranslation.Size = New System.Drawing.Size(119, 78)
        Me.tlpTranslation.TabIndex = 3
        '
        'robInterface
        '
        Me.robInterface.AutoSize = True
        Me.robInterface.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robInterface.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robInterface.ButtonStyle = translationtool.RibbonOptionButton.Style.Big
        Me.robInterface.Icon = Global.translationtool.My.Resources.Resources.view_remove
        Me.robInterface.Location = New System.Drawing.Point(2, 5)
        Me.robInterface.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.robInterface.MaximumSize = New System.Drawing.Size(80, 68)
        Me.robInterface.MinimumSize = New System.Drawing.Size(0, 68)
        Me.robInterface.Name = "robInterface"
        Me.robInterface.Size = New System.Drawing.Size(54, 68)
        Me.robInterface.TabIndex = 0
        Me.robInterface.Text = "Interface"
        '
        'robAttributes
        '
        Me.robAttributes.AutoSize = True
        Me.robAttributes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robAttributes.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robAttributes.ButtonStyle = translationtool.RibbonOptionButton.Style.Big
        Me.robAttributes.Icon = Global.translationtool.My.Resources.Resources.info
        Me.robAttributes.Location = New System.Drawing.Point(60, 5)
        Me.robAttributes.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.robAttributes.MaximumSize = New System.Drawing.Size(80, 68)
        Me.robAttributes.MinimumSize = New System.Drawing.Size(0, 68)
        Me.robAttributes.Name = "robAttributes"
        Me.robAttributes.Size = New System.Drawing.Size(57, 68)
        Me.robAttributes.TabIndex = 1
        Me.robAttributes.Text = "Attributes meaning"
        '
        'lblProject
        '
        Me.lblProject.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblProject.AutoSize = True
        Me.lblProject.ForeColor = System.Drawing.Color.Silver
        Me.lblProject.Location = New System.Drawing.Point(24, 91)
        Me.lblProject.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(29, 13)
        Me.lblProject.TabIndex = 27
        Me.lblProject.Text = "Main"
        '
        'RibbonVerticalSeparator1
        '
        Me.RibbonVerticalSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonVerticalSeparator1.Location = New System.Drawing.Point(81, 3)
        Me.RibbonVerticalSeparator1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.RibbonVerticalSeparator1.MaximumSize = New System.Drawing.Size(1, 0)
        Me.RibbonVerticalSeparator1.Name = "RibbonVerticalSeparator1"
        Me.RibbonVerticalSeparator1.Size = New System.Drawing.Size(1, 78)
        Me.RibbonVerticalSeparator1.TabIndex = 28
        '
        'RibbonVerticalSeparator2
        '
        Me.RibbonVerticalSeparator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonVerticalSeparator2.Location = New System.Drawing.Point(81, 81)
        Me.RibbonVerticalSeparator2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.RibbonVerticalSeparator2.MaximumSize = New System.Drawing.Size(1, 0)
        Me.RibbonVerticalSeparator2.Name = "RibbonVerticalSeparator2"
        Me.RibbonVerticalSeparator2.Size = New System.Drawing.Size(1, 26)
        Me.RibbonVerticalSeparator2.TabIndex = 29
        '
        'RibbonHorizontalSeparator1
        '
        Me.RibbonHorizontalSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonHorizontalSeparator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonHorizontalSeparator1.Location = New System.Drawing.Point(0, 110)
        Me.RibbonHorizontalSeparator1.MaximumSize = New System.Drawing.Size(0, 1)
        Me.RibbonHorizontalSeparator1.MinimumSize = New System.Drawing.Size(80, 1)
        Me.RibbonHorizontalSeparator1.Name = "RibbonHorizontalSeparator1"
        Me.RibbonHorizontalSeparator1.Size = New System.Drawing.Size(816, 1)
        Me.RibbonHorizontalSeparator1.TabIndex = 4
        '
        'htcMain
        '
        Me.htcMain.Controls.Add(Me.tpMangement)
        Me.htcMain.Controls.Add(Me.tpInterface)
        Me.htcMain.Controls.Add(Me.tpAttributes)
        Me.htcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htcMain.Location = New System.Drawing.Point(0, 110)
        Me.htcMain.Name = "htcMain"
        Me.htcMain.SelectedIndex = 0
        Me.htcMain.Size = New System.Drawing.Size(816, 417)
        Me.htcMain.TabIndex = 3
        '
        'tpMangement
        '
        Me.tpMangement.Controls.Add(Me.tlpLanguage)
        Me.tpMangement.Location = New System.Drawing.Point(4, 22)
        Me.tpMangement.Name = "tpMangement"
        Me.tpMangement.Size = New System.Drawing.Size(808, 391)
        Me.tpMangement.TabIndex = 0
        Me.tpMangement.Text = "tpMangement"
        Me.tpMangement.UseVisualStyleBackColor = True
        '
        'tlpLanguage
        '
        Me.tlpLanguage.AutoSize = True
        Me.tlpLanguage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpLanguage.ColumnCount = 4
        Me.tlpLanguage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLanguage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLanguage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLanguage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLanguage.Controls.Add(Me.tlpVersion, 1, 3)
        Me.tlpLanguage.Controls.Add(Me.btnFolder, 3, 2)
        Me.tlpLanguage.Controls.Add(Me.btnSave, 3, 1)
        Me.tlpLanguage.Controls.Add(Me.lblCulture, 0, 0)
        Me.tlpLanguage.Controls.Add(Me.cboCulture, 1, 0)
        Me.tlpLanguage.Controls.Add(Me.lblSelLanguage, 2, 0)
        Me.tlpLanguage.Controls.Add(Me.btnCreate, 3, 0)
        Me.tlpLanguage.Controls.Add(Me.lblLanguage, 0, 1)
        Me.tlpLanguage.Controls.Add(Me.txtTranslator, 1, 2)
        Me.tlpLanguage.Controls.Add(Me.txtLanguage, 1, 1)
        Me.tlpLanguage.Controls.Add(Me.lblVersion, 0, 3)
        Me.tlpLanguage.Controls.Add(Me.lblTranslator, 0, 2)
        Me.tlpLanguage.Controls.Add(Me.lblVersionNote, 1, 4)
        Me.tlpLanguage.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpLanguage.Location = New System.Drawing.Point(0, 0)
        Me.tlpLanguage.Name = "tlpLanguage"
        Me.tlpLanguage.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.tlpLanguage.RowCount = 5
        Me.tlpLanguage.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLanguage.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLanguage.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLanguage.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLanguage.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLanguage.Size = New System.Drawing.Size(808, 190)
        Me.tlpLanguage.TabIndex = 1
        '
        'tlpVersion
        '
        Me.tlpVersion.AutoSize = True
        Me.tlpVersion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpVersion.ColumnCount = 2
        Me.tlpVersion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpVersion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpVersion.Controls.Add(Me.txtRevision, 1, 2)
        Me.tlpVersion.Controls.Add(Me.txtMinor, 1, 1)
        Me.tlpVersion.Controls.Add(Me.txtMajor, 1, 0)
        Me.tlpVersion.Controls.Add(Me.lblMajor, 0, 0)
        Me.tlpVersion.Controls.Add(Me.lblMinor, 0, 1)
        Me.tlpVersion.Controls.Add(Me.lblRevision, 0, 2)
        Me.tlpVersion.Location = New System.Drawing.Point(126, 93)
        Me.tlpVersion.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpVersion.Name = "tlpVersion"
        Me.tlpVersion.RowCount = 3
        Me.tlpVersion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpVersion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpVersion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpVersion.Size = New System.Drawing.Size(141, 81)
        Me.tlpVersion.TabIndex = 2
        '
        'txtRevision
        '
        Me.txtRevision.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRevision.Location = New System.Drawing.Point(56, 57)
        Me.txtRevision.MaxLength = 2
        Me.txtRevision.Name = "txtRevision"
        Me.txtRevision.Size = New System.Drawing.Size(82, 21)
        Me.txtRevision.TabIndex = 5
        '
        'txtMinor
        '
        Me.txtMinor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMinor.Location = New System.Drawing.Point(56, 30)
        Me.txtMinor.MaxLength = 2
        Me.txtMinor.Name = "txtMinor"
        Me.txtMinor.Size = New System.Drawing.Size(82, 21)
        Me.txtMinor.TabIndex = 4
        '
        'txtMajor
        '
        Me.txtMajor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtMajor.Location = New System.Drawing.Point(56, 3)
        Me.txtMajor.MaxLength = 2
        Me.txtMajor.Name = "txtMajor"
        Me.txtMajor.Size = New System.Drawing.Size(82, 21)
        Me.txtMajor.TabIndex = 3
        '
        'lblMajor
        '
        Me.lblMajor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMajor.AutoSize = True
        Me.lblMajor.Location = New System.Drawing.Point(3, 7)
        Me.lblMajor.Name = "lblMajor"
        Me.lblMajor.Size = New System.Drawing.Size(34, 13)
        Me.lblMajor.TabIndex = 0
        Me.lblMajor.Text = "Major"
        '
        'lblMinor
        '
        Me.lblMinor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMinor.AutoSize = True
        Me.lblMinor.Location = New System.Drawing.Point(3, 34)
        Me.lblMinor.Name = "lblMinor"
        Me.lblMinor.Size = New System.Drawing.Size(33, 13)
        Me.lblMinor.TabIndex = 1
        Me.lblMinor.Text = "Minor"
        '
        'lblRevision
        '
        Me.lblRevision.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRevision.AutoSize = True
        Me.lblRevision.Location = New System.Drawing.Point(3, 61)
        Me.lblRevision.Name = "lblRevision"
        Me.lblRevision.Size = New System.Drawing.Size(47, 13)
        Me.lblRevision.TabIndex = 2
        Me.lblRevision.Text = "Revision"
        '
        'btnFolder
        '
        Me.btnFolder.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFolder.Location = New System.Drawing.Point(693, 66)
        Me.btnFolder.Name = "btnFolder"
        Me.btnFolder.Size = New System.Drawing.Size(112, 24)
        Me.btnFolder.TabIndex = 16
        Me.btnFolder.Text = "Open project folder"
        Me.btnFolder.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSave.Location = New System.Drawing.Point(693, 36)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 24)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save project"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblCulture
        '
        Me.lblCulture.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCulture.AutoSize = True
        Me.lblCulture.ForeColor = System.Drawing.Color.Black
        Me.lblCulture.Location = New System.Drawing.Point(3, 11)
        Me.lblCulture.Name = "lblCulture"
        Me.lblCulture.Size = New System.Drawing.Size(120, 13)
        Me.lblCulture.TabIndex = 3
        Me.lblCulture.Text = "Language culture code:"
        Me.lblCulture.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCulture
        '
        Me.cboCulture.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboCulture.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboCulture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCulture.Location = New System.Drawing.Point(129, 7)
        Me.cboCulture.Name = "cboCulture"
        Me.cboCulture.Size = New System.Drawing.Size(88, 21)
        Me.cboCulture.TabIndex = 0
        '
        'lblSelLanguage
        '
        Me.lblSelLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSelLanguage.AutoEllipsis = True
        Me.lblSelLanguage.AutoSize = True
        Me.lblSelLanguage.Location = New System.Drawing.Point(447, 11)
        Me.lblSelLanguage.Name = "lblSelLanguage"
        Me.lblSelLanguage.Size = New System.Drawing.Size(78, 13)
        Me.lblSelLanguage.TabIndex = 14
        Me.lblSelLanguage.Text = "lblSelLanguage"
        Me.lblSelLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCreate.Location = New System.Drawing.Point(693, 6)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(112, 24)
        Me.btnCreate.TabIndex = 4
        Me.btnCreate.Text = "Create project"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'lblLanguage
        '
        Me.lblLanguage.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.ForeColor = System.Drawing.Color.Black
        Me.lblLanguage.Location = New System.Drawing.Point(65, 41)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(58, 13)
        Me.lblLanguage.TabIndex = 10
        Me.lblLanguage.Text = "Language:"
        Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTranslator
        '
        Me.txtTranslator.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtTranslator.Location = New System.Drawing.Point(129, 67)
        Me.txtTranslator.Name = "txtTranslator"
        Me.txtTranslator.Size = New System.Drawing.Size(312, 21)
        Me.txtTranslator.TabIndex = 2
        '
        'txtLanguage
        '
        Me.txtLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtLanguage.Location = New System.Drawing.Point(129, 37)
        Me.txtLanguage.Name = "txtLanguage"
        Me.txtLanguage.Size = New System.Drawing.Size(312, 21)
        Me.txtLanguage.TabIndex = 1
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(77, 100)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(46, 13)
        Me.lblVersion.TabIndex = 8
        Me.lblVersion.Text = "Version:"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTranslator
        '
        Me.lblTranslator.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTranslator.AutoSize = True
        Me.lblTranslator.ForeColor = System.Drawing.Color.Black
        Me.lblTranslator.Location = New System.Drawing.Point(63, 71)
        Me.lblTranslator.Name = "lblTranslator"
        Me.lblTranslator.Size = New System.Drawing.Size(60, 13)
        Me.lblTranslator.TabIndex = 6
        Me.lblTranslator.Text = "Translator:"
        Me.lblTranslator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVersionNote
        '
        Me.lblVersionNote.AutoSize = True
        Me.lblVersionNote.Location = New System.Drawing.Point(129, 177)
        Me.lblVersionNote.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblVersionNote.Name = "lblVersionNote"
        Me.lblVersionNote.Size = New System.Drawing.Size(153, 13)
        Me.lblVersionNote.TabIndex = 17
        Me.lblVersionNote.Text = "Version accepts only numbers!"
        '
        'tpInterface
        '
        Me.tpInterface.Controls.Add(Me.tlpInterface)
        Me.tpInterface.Location = New System.Drawing.Point(4, 22)
        Me.tpInterface.Name = "tpInterface"
        Me.tpInterface.Size = New System.Drawing.Size(808, 391)
        Me.tpInterface.TabIndex = 1
        Me.tpInterface.Text = "tpInterface"
        Me.tpInterface.UseVisualStyleBackColor = True
        '
        'tlpInterface
        '
        Me.tlpInterface.ColumnCount = 2
        Me.tlpInterface.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpInterface.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpInterface.Controls.Add(Me.btnNext, 1, 4)
        Me.tlpInterface.Controls.Add(Me.lvwTranslation, 0, 0)
        Me.tlpInterface.Controls.Add(Me.txtDefault, 0, 2)
        Me.tlpInterface.Controls.Add(Me.txtNew, 0, 4)
        Me.tlpInterface.Controls.Add(Me.lblDefault, 0, 1)
        Me.tlpInterface.Controls.Add(Me.lblNew, 0, 3)
        Me.tlpInterface.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpInterface.Location = New System.Drawing.Point(0, 0)
        Me.tlpInterface.Name = "tlpInterface"
        Me.tlpInterface.RowCount = 5
        Me.tlpInterface.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpInterface.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInterface.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpInterface.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpInterface.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpInterface.Size = New System.Drawing.Size(808, 391)
        Me.tlpInterface.TabIndex = 0
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(709, 364)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(96, 24)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'lvwTranslation
        '
        Me.lvwTranslation.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDefaultCulture, Me.chNewCulture})
        Me.lvwTranslation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwTranslation.FullRowSelect = True
        Me.lvwTranslation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwTranslation.HideSelection = False
        Me.lvwTranslation.Location = New System.Drawing.Point(3, 3)
        Me.lvwTranslation.MultiSelect = False
        Me.lvwTranslation.Name = "lvwTranslation"
        Me.lvwTranslation.Size = New System.Drawing.Size(700, 140)
        Me.lvwTranslation.TabIndex = 0
        Me.lvwTranslation.UseCompatibleStateImageBehavior = False
        Me.lvwTranslation.View = System.Windows.Forms.View.Details
        '
        'chDefaultCulture
        '
        Me.chDefaultCulture.Text = "Default"
        '
        'chNewCulture
        '
        Me.chNewCulture.Text = "New culture"
        '
        'txtDefault
        '
        Me.txtDefault.BackColor = System.Drawing.SystemColors.Window
        Me.txtDefault.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDefault.Location = New System.Drawing.Point(3, 162)
        Me.txtDefault.Multiline = True
        Me.txtDefault.Name = "txtDefault"
        Me.txtDefault.ReadOnly = True
        Me.txtDefault.Size = New System.Drawing.Size(700, 103)
        Me.txtDefault.TabIndex = 1
        '
        'txtNew
        '
        Me.txtNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNew.Location = New System.Drawing.Point(3, 284)
        Me.txtNew.Multiline = True
        Me.txtNew.Name = "txtNew"
        Me.txtNew.Size = New System.Drawing.Size(700, 104)
        Me.txtNew.TabIndex = 2
        '
        'lblDefault
        '
        Me.lblDefault.AutoSize = True
        Me.lblDefault.Location = New System.Drawing.Point(3, 146)
        Me.lblDefault.Name = "lblDefault"
        Me.lblDefault.Size = New System.Drawing.Size(69, 13)
        Me.lblDefault.TabIndex = 2
        Me.lblDefault.Text = "Default text:"
        '
        'lblNew
        '
        Me.lblNew.AutoSize = True
        Me.lblNew.Location = New System.Drawing.Point(3, 268)
        Me.lblNew.Name = "lblNew"
        Me.lblNew.Size = New System.Drawing.Size(55, 13)
        Me.lblNew.TabIndex = 4
        Me.lblNew.Text = "New text:"
        '
        'tpAttributes
        '
        Me.tpAttributes.Controls.Add(Me.tlpAttributes)
        Me.tpAttributes.Location = New System.Drawing.Point(4, 22)
        Me.tpAttributes.Name = "tpAttributes"
        Me.tpAttributes.Size = New System.Drawing.Size(808, 391)
        Me.tpAttributes.TabIndex = 2
        Me.tpAttributes.Text = "tpAttributes"
        Me.tpAttributes.UseVisualStyleBackColor = True
        '
        'tlpAttributes
        '
        Me.tlpAttributes.ColumnCount = 2
        Me.tlpAttributes.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAttributes.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpAttributes.Controls.Add(Me.lvwAttributes, 0, 0)
        Me.tlpAttributes.Controls.Add(Me.btnNextAttr, 1, 4)
        Me.tlpAttributes.Controls.Add(Me.lblDefaultAttr, 0, 1)
        Me.tlpAttributes.Controls.Add(Me.txtNewAttr, 0, 4)
        Me.tlpAttributes.Controls.Add(Me.txtDefaultAttr, 0, 2)
        Me.tlpAttributes.Controls.Add(Me.lblNewAttr, 0, 3)
        Me.tlpAttributes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpAttributes.Location = New System.Drawing.Point(0, 0)
        Me.tlpAttributes.Name = "tlpAttributes"
        Me.tlpAttributes.RowCount = 5
        Me.tlpAttributes.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpAttributes.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributes.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpAttributes.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributes.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpAttributes.Size = New System.Drawing.Size(808, 391)
        Me.tlpAttributes.TabIndex = 0
        '
        'lvwAttributes
        '
        Me.lvwAttributes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chItemName, Me.chDefaultAttr, Me.chNewAttr})
        Me.lvwAttributes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwAttributes.FullRowSelect = True
        Me.lvwAttributes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwAttributes.HideSelection = False
        Me.lvwAttributes.Location = New System.Drawing.Point(3, 3)
        Me.lvwAttributes.MultiSelect = False
        Me.lvwAttributes.Name = "lvwAttributes"
        Me.lvwAttributes.Size = New System.Drawing.Size(700, 140)
        Me.lvwAttributes.TabIndex = 0
        Me.lvwAttributes.UseCompatibleStateImageBehavior = False
        Me.lvwAttributes.View = System.Windows.Forms.View.Details
        '
        'chItemName
        '
        Me.chItemName.Text = "Attribute name"
        '
        'chDefaultAttr
        '
        Me.chDefaultAttr.Text = "Default"
        '
        'chNewAttr
        '
        Me.chNewAttr.Text = "New culture"
        '
        'btnNextAttr
        '
        Me.btnNextAttr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNextAttr.Location = New System.Drawing.Point(709, 364)
        Me.btnNextAttr.Name = "btnNextAttr"
        Me.btnNextAttr.Size = New System.Drawing.Size(96, 24)
        Me.btnNextAttr.TabIndex = 3
        Me.btnNextAttr.Text = "Next"
        Me.btnNextAttr.UseVisualStyleBackColor = True
        '
        'lblDefaultAttr
        '
        Me.lblDefaultAttr.AutoSize = True
        Me.lblDefaultAttr.Location = New System.Drawing.Point(3, 146)
        Me.lblDefaultAttr.Name = "lblDefaultAttr"
        Me.lblDefaultAttr.Size = New System.Drawing.Size(69, 13)
        Me.lblDefaultAttr.TabIndex = 7
        Me.lblDefaultAttr.Text = "Default text:"
        '
        'txtNewAttr
        '
        Me.txtNewAttr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNewAttr.Location = New System.Drawing.Point(3, 284)
        Me.txtNewAttr.Multiline = True
        Me.txtNewAttr.Name = "txtNewAttr"
        Me.txtNewAttr.Size = New System.Drawing.Size(700, 104)
        Me.txtNewAttr.TabIndex = 2
        '
        'txtDefaultAttr
        '
        Me.txtDefaultAttr.BackColor = System.Drawing.SystemColors.Window
        Me.txtDefaultAttr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDefaultAttr.Location = New System.Drawing.Point(3, 162)
        Me.txtDefaultAttr.Multiline = True
        Me.txtDefaultAttr.Name = "txtDefaultAttr"
        Me.txtDefaultAttr.ReadOnly = True
        Me.txtDefaultAttr.Size = New System.Drawing.Size(700, 103)
        Me.txtDefaultAttr.TabIndex = 1
        '
        'lblNewAttr
        '
        Me.lblNewAttr.AutoSize = True
        Me.lblNewAttr.Location = New System.Drawing.Point(3, 268)
        Me.lblNewAttr.Name = "lblNewAttr"
        Me.lblNewAttr.Size = New System.Drawing.Size(55, 13)
        Me.lblNewAttr.TabIndex = 9
        Me.lblNewAttr.Text = "New text:"
        '
        'MainTranslationTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(816, 527)
        Me.Controls.Add(Me.RibbonHorizontalSeparator1)
        Me.Controls.Add(Me.htcMain)
        Me.Controls.Add(Me.tlpMenu)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(832, 565)
        Me.Name = "MainTranslationTool"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HDD Guardian Translation Tool"
        Me.tlpMenu.ResumeLayout(False)
        Me.tlpMenu.PerformLayout()
        Me.tlpProgress.ResumeLayout(False)
        Me.tlpProgress.PerformLayout()
        Me.tlpTranslation.ResumeLayout(False)
        Me.tlpTranslation.PerformLayout()
        Me.htcMain.ResumeLayout(False)
        Me.tpMangement.ResumeLayout(False)
        Me.tpMangement.PerformLayout()
        Me.tlpLanguage.ResumeLayout(False)
        Me.tlpLanguage.PerformLayout()
        Me.tlpVersion.ResumeLayout(False)
        Me.tlpVersion.PerformLayout()
        Me.tpInterface.ResumeLayout(False)
        Me.tlpInterface.ResumeLayout(False)
        Me.tlpInterface.PerformLayout()
        Me.tpAttributes.ResumeLayout(False)
        Me.tlpAttributes.ResumeLayout(False)
        Me.tlpAttributes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCulture As System.Windows.Forms.Label
    Friend WithEvents cboCulture As System.Windows.Forms.ComboBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents txtTranslator As System.Windows.Forms.TextBox
    Friend WithEvents lblTranslator As System.Windows.Forms.Label
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents lblNew As System.Windows.Forms.Label
    Friend WithEvents txtDefault As System.Windows.Forms.TextBox
    Friend WithEvents lblDefault As System.Windows.Forms.Label
    Friend WithEvents lvwTranslation As System.Windows.Forms.ListView
    Friend WithEvents chDefaultCulture As System.Windows.Forms.ColumnHeader
    Friend WithEvents chNewCulture As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtNewAttr As System.Windows.Forms.TextBox
    Friend WithEvents lblNewAttr As System.Windows.Forms.Label
    Friend WithEvents txtDefaultAttr As System.Windows.Forms.TextBox
    Friend WithEvents lblDefaultAttr As System.Windows.Forms.Label
    Friend WithEvents lvwAttributes As System.Windows.Forms.ListView
    Friend WithEvents chDefaultAttr As System.Windows.Forms.ColumnHeader
    Friend WithEvents chNewAttr As System.Windows.Forms.ColumnHeader
    Friend WithEvents chItemName As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents txtLanguage As System.Windows.Forms.TextBox
    Friend WithEvents lblLanguage As System.Windows.Forms.Label
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnNextAttr As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblSelLanguage As System.Windows.Forms.Label
    Friend WithEvents btnFolder As System.Windows.Forms.Button
    Friend WithEvents ttFolder As System.Windows.Forms.ToolTip
    Friend WithEvents tlpMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents robProject As RibbonOptionButton
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents RibbonVerticalSeparator1 As RibbonVerticalSeparator
    Friend WithEvents RibbonVerticalSeparator2 As RibbonVerticalSeparator
    Friend WithEvents RibbonVerticalSeparator4 As RibbonVerticalSeparator
    Friend WithEvents RibbonVerticalSeparator3 As RibbonVerticalSeparator
    Friend WithEvents lblTranslation As System.Windows.Forms.Label
    Friend WithEvents tlpTranslation As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents robInterface As RibbonOptionButton
    Friend WithEvents robAttributes As RibbonOptionButton
    Friend WithEvents tlpProgress As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblInterface As System.Windows.Forms.Label
    Friend WithEvents lblAttributes As System.Windows.Forms.Label
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents fpbInterface As translationtool.FlatProgressBar
    Friend WithEvents fpbAttributes As translationtool.FlatProgressBar
    Friend WithEvents htcMain As translationtool.HeadlessTabControl
    Friend WithEvents tpMangement As System.Windows.Forms.TabPage
    Friend WithEvents tpInterface As System.Windows.Forms.TabPage
    Friend WithEvents tlpInterface As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tpAttributes As System.Windows.Forms.TabPage
    Friend WithEvents lblCultureTranslated As System.Windows.Forms.Label
    Friend WithEvents lblChoosenCulture As System.Windows.Forms.Label
    Friend WithEvents tlpLanguage As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpAttributes As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtMajor As System.Windows.Forms.TextBox
    Friend WithEvents RibbonHorizontalSeparator1 As translationtool.RibbonHorizontalSeparator
    Friend WithEvents lblTranlsationInterface As System.Windows.Forms.Label
    Friend WithEvents lblTranslationAttributes As System.Windows.Forms.Label
    Friend WithEvents tlpVersion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtRevision As System.Windows.Forms.TextBox
    Friend WithEvents txtMinor As System.Windows.Forms.TextBox
    Friend WithEvents lblMajor As System.Windows.Forms.Label
    Friend WithEvents lblMinor As System.Windows.Forms.Label
    Friend WithEvents lblRevision As System.Windows.Forms.Label
    Friend WithEvents lblVersionNote As System.Windows.Forms.Label

End Class
