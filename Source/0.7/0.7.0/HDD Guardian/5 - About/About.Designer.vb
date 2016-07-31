<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim tpAbout As System.Windows.Forms.TabPage
        Dim picLogo As System.Windows.Forms.PictureBox
        Dim tlpContacts As System.Windows.Forms.TableLayoutPanel
        Dim tpCredits As System.Windows.Forms.TabPage
        Dim flwCredits As System.Windows.Forms.FlowLayoutPanel
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label22 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label24 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim tpLicense As System.Windows.Forms.TabPage
        Me.tlpAbout = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFramework = New System.Windows.Forms.Label()
        Me.lnkCodePlex = New System.Windows.Forms.LinkLabel()
        Me.picCodePlex = New System.Windows.Forms.PictureBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lnkHddGuardian = New hdd_guardian.NewLink()
        Me.lnkSmartMonTools = New System.Windows.Forms.LinkLabel()
        Me.lnkGpl = New System.Windows.Forms.LinkLabel()
        Me.lnkKamiyamane = New System.Windows.Forms.LinkLabel()
        Me.lnkCcBy = New System.Windows.Forms.LinkLabel()
        Me.lnkOxygen = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lnkLgplOxygen = New System.Windows.Forms.LinkLabel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lnkCrystal = New System.Windows.Forms.LinkLabel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lnkEveraldo = New System.Windows.Forms.LinkLabel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lnkLgplCrystal = New System.Windows.Forms.LinkLabel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lnkOpenClipart = New System.Windows.Forms.LinkLabel()
        Me.lnkBrandsOfTheWorld = New System.Windows.Forms.LinkLabel()
        Me.lnkWesternDigital = New System.Windows.Forms.LinkLabel()
        Me.lnkCoolerMaster = New System.Windows.Forms.LinkLabel()
        Me.lnkOxygen2 = New System.Windows.Forms.LinkLabel()
        Me.lblLicense = New System.Windows.Forms.Label()
        Me.lblTesters = New System.Windows.Forms.Label()
        Me.lblTranslators = New System.Windows.Forms.Label()
        Me.tabAbout = New System.Windows.Forms.TabControl()
        Me.tpContributors = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.tpChangeLog = New System.Windows.Forms.TabPage()
        Me.lblChangeLog = New System.Windows.Forms.Label()
        tpAbout = New System.Windows.Forms.TabPage()
        picLogo = New System.Windows.Forms.PictureBox()
        tlpContacts = New System.Windows.Forms.TableLayoutPanel()
        tpCredits = New System.Windows.Forms.TabPage()
        flwCredits = New System.Windows.Forms.FlowLayoutPanel()
        Label14 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label22 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Label24 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label17 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        tpLicense = New System.Windows.Forms.TabPage()
        tpAbout.SuspendLayout()
        Me.tlpAbout.SuspendLayout()
        CType(picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpContacts.SuspendLayout()
        CType(Me.picCodePlex, System.ComponentModel.ISupportInitialize).BeginInit()
        tpCredits.SuspendLayout()
        flwCredits.SuspendLayout()
        tpLicense.SuspendLayout()
        Me.tabAbout.SuspendLayout()
        Me.tpContributors.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpChangeLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'tpAbout
        '
        tpAbout.Controls.Add(Me.tlpAbout)
        tpAbout.Location = New System.Drawing.Point(4, 22)
        tpAbout.Name = "tpAbout"
        tpAbout.Size = New System.Drawing.Size(689, 309)
        tpAbout.TabIndex = 2
        tpAbout.Text = "HDD Guardian"
        tpAbout.UseVisualStyleBackColor = True
        '
        'tlpAbout
        '
        Me.tlpAbout.AutoSize = True
        Me.tlpAbout.ColumnCount = 1
        Me.tlpAbout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAbout.Controls.Add(picLogo, 0, 0)
        Me.tlpAbout.Controls.Add(Me.lblFramework, 0, 5)
        Me.tlpAbout.Controls.Add(tlpContacts, 0, 4)
        Me.tlpAbout.Controls.Add(Me.lblVersion, 0, 2)
        Me.tlpAbout.Controls.Add(Me.lblCopyright, 0, 3)
        Me.tlpAbout.Controls.Add(Me.lnkHddGuardian, 0, 1)
        Me.tlpAbout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpAbout.Location = New System.Drawing.Point(0, 0)
        Me.tlpAbout.Name = "tlpAbout"
        Me.tlpAbout.RowCount = 7
        Me.tlpAbout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAbout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAbout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAbout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAbout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAbout.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAbout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpAbout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpAbout.Size = New System.Drawing.Size(689, 309)
        Me.tlpAbout.TabIndex = 14
        '
        'picLogo
        '
        picLogo.Anchor = System.Windows.Forms.AnchorStyles.Top
        picLogo.Image = Global.hdd_guardian.My.Resources.Resources._64
        picLogo.Location = New System.Drawing.Point(312, 10)
        picLogo.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        picLogo.Name = "picLogo"
        picLogo.Size = New System.Drawing.Size(64, 64)
        picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        picLogo.TabIndex = 1
        picLogo.TabStop = False
        '
        'lblFramework
        '
        Me.lblFramework.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFramework.AutoSize = True
        Me.lblFramework.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblFramework.Location = New System.Drawing.Point(309, 173)
        Me.lblFramework.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.lblFramework.Name = "lblFramework"
        Me.lblFramework.Size = New System.Drawing.Size(70, 13)
        Me.lblFramework.TabIndex = 7
        Me.lblFramework.Text = "lblFramework"
        Me.lblFramework.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tlpContacts
        '
        tlpContacts.Anchor = System.Windows.Forms.AnchorStyles.Top
        tlpContacts.AutoSize = True
        tlpContacts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpContacts.ColumnCount = 2
        tlpContacts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        tlpContacts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpContacts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        tlpContacts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        tlpContacts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        tlpContacts.Controls.Add(Me.lnkCodePlex, 1, 0)
        tlpContacts.Controls.Add(Me.picCodePlex, 0, 0)
        tlpContacts.Location = New System.Drawing.Point(260, 143)
        tlpContacts.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        tlpContacts.Name = "tlpContacts"
        tlpContacts.RowCount = 1
        tlpContacts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpContacts.Size = New System.Drawing.Size(169, 22)
        tlpContacts.TabIndex = 13
        '
        'lnkCodePlex
        '
        Me.lnkCodePlex.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkCodePlex.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lnkCodePlex.AutoSize = True
        Me.lnkCodePlex.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkCodePlex.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkCodePlex.Location = New System.Drawing.Point(24, 4)
        Me.lnkCodePlex.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkCodePlex.Name = "lnkCodePlex"
        Me.lnkCodePlex.Size = New System.Drawing.Size(145, 13)
        Me.lnkCodePlex.TabIndex = 15
        Me.lnkCodePlex.TabStop = True
        Me.lnkCodePlex.Tag = "http://hddguardian.codeplex.com/"
        Me.lnkCodePlex.Text = "CodePlex Project home page"
        '
        'picCodePlex
        '
        Me.picCodePlex.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.picCodePlex.Image = Global.hdd_guardian.My.Resources.Resources.codeplex
        Me.picCodePlex.Location = New System.Drawing.Point(3, 3)
        Me.picCodePlex.Name = "picCodePlex"
        Me.picCodePlex.Size = New System.Drawing.Size(16, 16)
        Me.picCodePlex.TabIndex = 16
        Me.picCodePlex.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblVersion.AutoSize = True
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblVersion.Location = New System.Drawing.Point(318, 107)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(52, 13)
        Me.lblVersion.TabIndex = 3
        Me.lblVersion.Text = "lblVersion"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCopyright
        '
        Me.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblCopyright.Location = New System.Drawing.Point(312, 125)
        Me.lblCopyright.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(64, 13)
        Me.lblCopyright.TabIndex = 2
        Me.lblCopyright.Text = "lblCopyright"
        Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkHddGuardian
        '
        Me.lnkHddGuardian.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkHddGuardian.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lnkHddGuardian.AutoSize = True
        Me.lnkHddGuardian.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkHddGuardian.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkHddGuardian.Location = New System.Drawing.Point(307, 89)
        Me.lnkHddGuardian.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.lnkHddGuardian.Name = "lnkHddGuardian"
        Me.lnkHddGuardian.Size = New System.Drawing.Size(74, 13)
        Me.lnkHddGuardian.TabIndex = 14
        Me.lnkHddGuardian.TabStop = True
        Me.lnkHddGuardian.Text = "HDD Guardian"
        '
        'tpCredits
        '
        tpCredits.Controls.Add(flwCredits)
        tpCredits.Controls.Add(Label12)
        tpCredits.Location = New System.Drawing.Point(4, 22)
        tpCredits.Name = "tpCredits"
        tpCredits.Padding = New System.Windows.Forms.Padding(3)
        tpCredits.Size = New System.Drawing.Size(689, 309)
        tpCredits.TabIndex = 1
        tpCredits.Text = "Credits"
        tpCredits.UseVisualStyleBackColor = True
        '
        'flwCredits
        '
        flwCredits.Controls.Add(Me.lnkSmartMonTools)
        flwCredits.Controls.Add(Label14)
        flwCredits.Controls.Add(Me.lnkGpl)
        flwCredits.Controls.Add(Label15)
        flwCredits.Controls.Add(Label1)
        flwCredits.Controls.Add(Me.lnkKamiyamane)
        flwCredits.Controls.Add(Label22)
        flwCredits.Controls.Add(Me.lnkCcBy)
        flwCredits.Controls.Add(Label13)
        flwCredits.Controls.Add(Me.lnkOxygen)
        flwCredits.Controls.Add(Me.Label3)
        flwCredits.Controls.Add(Me.lnkLgplOxygen)
        flwCredits.Controls.Add(Me.Label16)
        flwCredits.Controls.Add(Me.lnkCrystal)
        flwCredits.Controls.Add(Me.Label20)
        flwCredits.Controls.Add(Me.lnkEveraldo)
        flwCredits.Controls.Add(Me.Label25)
        flwCredits.Controls.Add(Me.lnkLgplCrystal)
        flwCredits.Controls.Add(Me.Label21)
        flwCredits.Controls.Add(Me.Label23)
        flwCredits.Controls.Add(Me.lnkOpenClipart)
        flwCredits.Controls.Add(Label24)
        flwCredits.Controls.Add(Me.lnkBrandsOfTheWorld)
        flwCredits.Controls.Add(Label2)
        flwCredits.Controls.Add(Me.lnkWesternDigital)
        flwCredits.Controls.Add(Label4)
        flwCredits.Controls.Add(Label11)
        flwCredits.Controls.Add(Me.lnkCoolerMaster)
        flwCredits.Controls.Add(Label17)
        flwCredits.Controls.Add(Label5)
        flwCredits.Controls.Add(Me.lnkOxygen2)
        flwCredits.Dock = System.Windows.Forms.DockStyle.Top
        flwCredits.Location = New System.Drawing.Point(3, 3)
        flwCredits.Name = "flwCredits"
        flwCredits.Size = New System.Drawing.Size(683, 277)
        flwCredits.TabIndex = 40
        '
        'lnkSmartMonTools
        '
        Me.lnkSmartMonTools.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSmartMonTools.AutoSize = True
        flwCredits.SetFlowBreak(Me.lnkSmartMonTools, True)
        Me.lnkSmartMonTools.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkSmartMonTools.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSmartMonTools.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkSmartMonTools.Location = New System.Drawing.Point(3, 0)
        Me.lnkSmartMonTools.Margin = New System.Windows.Forms.Padding(3, 0, 3, 5)
        Me.lnkSmartMonTools.Name = "lnkSmartMonTools"
        Me.lnkSmartMonTools.Size = New System.Drawing.Size(159, 13)
        Me.lnkSmartMonTools.TabIndex = 1
        Me.lnkSmartMonTools.TabStop = True
        Me.lnkSmartMonTools.Tag = "http://smartmontools.sourceforge.net/"
        Me.lnkSmartMonTools.Text = "S.M.A.R.T. Monitoring Tools"
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Location = New System.Drawing.Point(19, 18)
        Label14.Margin = New System.Windows.Forms.Padding(19, 0, 0, 0)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(287, 13)
        Label14.TabIndex = 17
        Label14.Text = "Copyright © Bruce Allen, Christian Franke, released under"
        '
        'lnkGpl
        '
        Me.lnkGpl.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkGpl.AutoSize = True
        Me.lnkGpl.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkGpl.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkGpl.Location = New System.Drawing.Point(306, 18)
        Me.lnkGpl.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkGpl.Name = "lnkGpl"
        Me.lnkGpl.Size = New System.Drawing.Size(58, 13)
        Me.lnkGpl.TabIndex = 0
        Me.lnkGpl.TabStop = True
        Me.lnkGpl.Tag = "http://www.gnu.org/licenses/gpl-2.0.html"
        Me.lnkGpl.Text = "GNU GPL 2"
        '
        'Label15
        '
        Label15.AutoSize = True
        flwCredits.SetFlowBreak(Label15, True)
        Label15.Location = New System.Drawing.Point(364, 18)
        Label15.Margin = New System.Windows.Forms.Padding(0)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(39, 13)
        Label15.TabIndex = 18
        Label15.Text = "license"
        '
        'Label1
        '
        Label1.AutoSize = True
        flwCredits.SetFlowBreak(Label1, True)
        Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(3, 46)
        Label1.Margin = New System.Windows.Forms.Padding(3, 15, 3, 5)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(136, 13)
        Label1.TabIndex = 0
        Label1.Text = "HDD Guardian graphics"
        '
        'lnkKamiyamane
        '
        Me.lnkKamiyamane.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkKamiyamane.AutoSize = True
        Me.lnkKamiyamane.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkKamiyamane.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkKamiyamane.Location = New System.Drawing.Point(19, 64)
        Me.lnkKamiyamane.Margin = New System.Windows.Forms.Padding(19, 0, 0, 7)
        Me.lnkKamiyamane.Name = "lnkKamiyamane"
        Me.lnkKamiyamane.Size = New System.Drawing.Size(64, 13)
        Me.lnkKamiyamane.TabIndex = 3
        Me.lnkKamiyamane.TabStop = True
        Me.lnkKamiyamane.Tag = "http://p.yusukekamiyamane.com/"
        Me.lnkKamiyamane.Text = "Fugue icons"
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.Location = New System.Drawing.Point(83, 64)
        Label22.Margin = New System.Windows.Forms.Padding(0)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(198, 13)
        Label22.TabIndex = 8
        Label22.Text = "by Yusuke Kamiyamane, released under"
        '
        'lnkCcBy
        '
        Me.lnkCcBy.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkCcBy.AutoSize = True
        Me.lnkCcBy.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkCcBy.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkCcBy.Location = New System.Drawing.Point(281, 64)
        Me.lnkCcBy.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkCcBy.Name = "lnkCcBy"
        Me.lnkCcBy.Size = New System.Drawing.Size(56, 13)
        Me.lnkCcBy.TabIndex = 2
        Me.lnkCcBy.TabStop = True
        Me.lnkCcBy.Tag = "http://creativecommons.org/licenses/by/3.0/"
        Me.lnkCcBy.Text = "CC-BY 3.0"
        '
        'Label13
        '
        Label13.AutoSize = True
        flwCredits.SetFlowBreak(Label13, True)
        Label13.Location = New System.Drawing.Point(337, 64)
        Label13.Margin = New System.Windows.Forms.Padding(0)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(39, 13)
        Label13.TabIndex = 19
        Label13.Text = "license"
        '
        'lnkOxygen
        '
        Me.lnkOxygen.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkOxygen.AutoSize = True
        Me.lnkOxygen.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkOxygen.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkOxygen.Location = New System.Drawing.Point(19, 84)
        Me.lnkOxygen.Margin = New System.Windows.Forms.Padding(19, 0, 0, 7)
        Me.lnkOxygen.Name = "lnkOxygen"
        Me.lnkOxygen.Size = New System.Drawing.Size(72, 13)
        Me.lnkOxygen.TabIndex = 43
        Me.lnkOxygen.TabStop = True
        Me.lnkOxygen.Tag = "http://pkgs.fedoraproject.org/repo/pkgs/oxygen-icon-theme/oxygen-icons-4.12.1.tar" & _
    ".xz/430f63ae998dba8e7bbe64ce3924060c/"
        Me.lnkOxygen.Text = "Oxygen icons"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(91, 84)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "by Oxygen Team, released under"
        '
        'lnkLgplOxygen
        '
        Me.lnkLgplOxygen.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkLgplOxygen.AutoSize = True
        Me.lnkLgplOxygen.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkLgplOxygen.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkLgplOxygen.Location = New System.Drawing.Point(259, 84)
        Me.lnkLgplOxygen.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkLgplOxygen.Name = "lnkLgplOxygen"
        Me.lnkLgplOxygen.Size = New System.Drawing.Size(54, 13)
        Me.lnkLgplOxygen.TabIndex = 45
        Me.lnkLgplOxygen.TabStop = True
        Me.lnkLgplOxygen.Tag = "http://www.gnu.org/licenses/lgpl.html"
        Me.lnkLgplOxygen.Text = "GNU LGPL"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        flwCredits.SetFlowBreak(Me.Label16, True)
        Me.Label16.Location = New System.Drawing.Point(313, 84)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "license"
        '
        'lnkCrystal
        '
        Me.lnkCrystal.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkCrystal.AutoSize = True
        Me.lnkCrystal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkCrystal.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkCrystal.Location = New System.Drawing.Point(19, 104)
        Me.lnkCrystal.Margin = New System.Windows.Forms.Padding(19, 0, 0, 7)
        Me.lnkCrystal.Name = "lnkCrystal"
        Me.lnkCrystal.Size = New System.Drawing.Size(105, 13)
        Me.lnkCrystal.TabIndex = 47
        Me.lnkCrystal.TabStop = True
        Me.lnkCrystal.Tag = "http://www.crystalxp.net/galerie/num.4538.htm"
        Me.lnkCrystal.Text = "Crystal Project icons"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(124, 104)
        Me.Label20.Margin = New System.Windows.Forms.Padding(0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(19, 13)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "by"
        '
        'lnkEveraldo
        '
        Me.lnkEveraldo.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkEveraldo.AutoSize = True
        Me.lnkEveraldo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkEveraldo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkEveraldo.Location = New System.Drawing.Point(143, 104)
        Me.lnkEveraldo.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkEveraldo.Name = "lnkEveraldo"
        Me.lnkEveraldo.Size = New System.Drawing.Size(85, 13)
        Me.lnkEveraldo.TabIndex = 53
        Me.lnkEveraldo.TabStop = True
        Me.lnkEveraldo.Tag = "http://www.everaldo.com"
        Me.lnkEveraldo.Text = "Everaldo Coelho"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(228, 104)
        Me.Label25.Margin = New System.Windows.Forms.Padding(0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(100, 13)
        Me.Label25.TabIndex = 54
        Me.Label25.Text = "and released under"
        '
        'lnkLgplCrystal
        '
        Me.lnkLgplCrystal.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkLgplCrystal.AutoSize = True
        Me.lnkLgplCrystal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkLgplCrystal.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkLgplCrystal.Location = New System.Drawing.Point(328, 104)
        Me.lnkLgplCrystal.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkLgplCrystal.Name = "lnkLgplCrystal"
        Me.lnkLgplCrystal.Size = New System.Drawing.Size(54, 13)
        Me.lnkLgplCrystal.TabIndex = 49
        Me.lnkLgplCrystal.TabStop = True
        Me.lnkLgplCrystal.Tag = "http://www.gnu.org/licenses/lgpl.html"
        Me.lnkLgplCrystal.Text = "GNU LGPL"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        flwCredits.SetFlowBreak(Me.Label21, True)
        Me.Label21.Location = New System.Drawing.Point(382, 104)
        Me.Label21.Margin = New System.Windows.Forms.Padding(0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 13)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "license"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(19, 124)
        Me.Label23.Margin = New System.Windows.Forms.Padding(19, 0, 0, 7)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(160, 13)
        Me.Label23.TabIndex = 51
        Me.Label23.Text = "Computers icons are taken from"
        '
        'lnkOpenClipart
        '
        Me.lnkOpenClipart.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkOpenClipart.AutoSize = True
        flwCredits.SetFlowBreak(Me.lnkOpenClipart, True)
        Me.lnkOpenClipart.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkOpenClipart.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkOpenClipart.Location = New System.Drawing.Point(179, 124)
        Me.lnkOpenClipart.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkOpenClipart.Name = "lnkOpenClipart"
        Me.lnkOpenClipart.Size = New System.Drawing.Size(100, 13)
        Me.lnkOpenClipart.TabIndex = 52
        Me.lnkOpenClipart.TabStop = True
        Me.lnkOpenClipart.Tag = "https://openclipart.org/"
        Me.lnkOpenClipart.Text = "OpenClipart Library"
        '
        'Label24
        '
        Label24.AutoSize = True
        Label24.Location = New System.Drawing.Point(19, 144)
        Label24.Margin = New System.Windows.Forms.Padding(19, 0, 0, 7)
        Label24.Name = "Label24"
        Label24.Size = New System.Drawing.Size(102, 13)
        Label24.TabIndex = 28
        Label24.Text = "Most logos are from"
        '
        'lnkBrandsOfTheWorld
        '
        Me.lnkBrandsOfTheWorld.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkBrandsOfTheWorld.AutoSize = True
        flwCredits.SetFlowBreak(Me.lnkBrandsOfTheWorld, True)
        Me.lnkBrandsOfTheWorld.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkBrandsOfTheWorld.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkBrandsOfTheWorld.Location = New System.Drawing.Point(121, 144)
        Me.lnkBrandsOfTheWorld.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkBrandsOfTheWorld.Name = "lnkBrandsOfTheWorld"
        Me.lnkBrandsOfTheWorld.Size = New System.Drawing.Size(103, 13)
        Me.lnkBrandsOfTheWorld.TabIndex = 5
        Me.lnkBrandsOfTheWorld.TabStop = True
        Me.lnkBrandsOfTheWorld.Tag = "www.brandsoftheworld.com"
        Me.lnkBrandsOfTheWorld.Text = "Brands of the World"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(19, 164)
        Label2.Margin = New System.Windows.Forms.Padding(19, 0, 0, 7)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(117, 13)
        Label2.TabIndex = 32
        Label2.Text = "The basic hard disk is a"
        '
        'lnkWesternDigital
        '
        Me.lnkWesternDigital.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkWesternDigital.AutoSize = True
        Me.lnkWesternDigital.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkWesternDigital.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkWesternDigital.Location = New System.Drawing.Point(136, 164)
        Me.lnkWesternDigital.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkWesternDigital.Name = "lnkWesternDigital"
        Me.lnkWesternDigital.Size = New System.Drawing.Size(80, 13)
        Me.lnkWesternDigital.TabIndex = 7
        Me.lnkWesternDigital.TabStop = True
        Me.lnkWesternDigital.Tag = "www.wdc.com"
        Me.lnkWesternDigital.Text = "Western Digital"
        '
        'Label4
        '
        Label4.AutoSize = True
        flwCredits.SetFlowBreak(Label4, True)
        Label4.Location = New System.Drawing.Point(216, 164)
        Label4.Margin = New System.Windows.Forms.Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(49, 13)
        Label4.TabIndex = 33
        Label4.Text = "Raptor X"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(19, 184)
        Label11.Margin = New System.Windows.Forms.Padding(19, 0, 0, 7)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(170, 13)
        Label11.TabIndex = 38
        Label11.Text = "The basic removable hard disk is a"
        '
        'lnkCoolerMaster
        '
        Me.lnkCoolerMaster.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkCoolerMaster.AutoSize = True
        Me.lnkCoolerMaster.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkCoolerMaster.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkCoolerMaster.Location = New System.Drawing.Point(189, 184)
        Me.lnkCoolerMaster.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkCoolerMaster.Name = "lnkCoolerMaster"
        Me.lnkCoolerMaster.Size = New System.Drawing.Size(71, 13)
        Me.lnkCoolerMaster.TabIndex = 39
        Me.lnkCoolerMaster.TabStop = True
        Me.lnkCoolerMaster.Tag = "www.coolermaster.com"
        Me.lnkCoolerMaster.Text = "CoolerMaster"
        '
        'Label17
        '
        Label17.AutoSize = True
        flwCredits.SetFlowBreak(Label17, True)
        Label17.Location = New System.Drawing.Point(260, 184)
        Label17.Margin = New System.Windows.Forms.Padding(0)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(38, 13)
        Label17.TabIndex = 40
        Label17.Text = "XCraft"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(19, 204)
        Label5.Margin = New System.Windows.Forms.Padding(19, 0, 0, 3)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(348, 13)
        Label5.TabIndex = 37
        Label5.Text = "HDD Guardian icon (except 16x16 px size) are created using icons from"
        '
        'lnkOxygen2
        '
        Me.lnkOxygen2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkOxygen2.AutoSize = True
        Me.lnkOxygen2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkOxygen2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkOxygen2.Location = New System.Drawing.Point(367, 204)
        Me.lnkOxygen2.Margin = New System.Windows.Forms.Padding(0)
        Me.lnkOxygen2.Name = "lnkOxygen2"
        Me.lnkOxygen2.Size = New System.Drawing.Size(72, 13)
        Me.lnkOxygen2.TabIndex = 8
        Me.lnkOxygen2.TabStop = True
        Me.lnkOxygen2.Tag = "http://download.kde.org/stable/4.12.1/src/oxygen-icons-4.12.1.tar.xz.mirrorlist"
        Me.lnkOxygen2.Text = "Oxygen icons"
        '
        'Label12
        '
        Label12.Dock = System.Windows.Forms.DockStyle.Bottom
        Label12.Location = New System.Drawing.Point(3, 293)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(683, 13)
        Label12.TabIndex = 15
        Label12.Text = "All logos and images are intellectual property of the copyright and/or trademark " & _
    "holder."
        Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(0, 8)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(423, 13)
        Label10.TabIndex = 4
        Label10.Text = "Thanks to all the people that have supported this project with their spontaneous " & _
    "work!"
        '
        'Label8
        '
        Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Label8.AutoSize = True
        Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(143, 4)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(50, 13)
        Label8.TabIndex = 2
        Label8.Text = "Testers"
        '
        'Label6
        '
        Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(25, 4)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(72, 13)
        Label6.TabIndex = 0
        Label6.Text = "Translators"
        '
        'tpLicense
        '
        tpLicense.AutoScroll = True
        tpLicense.Controls.Add(Me.lblLicense)
        tpLicense.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        tpLicense.Location = New System.Drawing.Point(4, 22)
        tpLicense.Name = "tpLicense"
        tpLicense.Size = New System.Drawing.Size(689, 309)
        tpLicense.TabIndex = 3
        tpLicense.Text = "License"
        tpLicense.UseVisualStyleBackColor = True
        '
        'lblLicense
        '
        Me.lblLicense.AutoSize = True
        Me.lblLicense.Location = New System.Drawing.Point(8, 8)
        Me.lblLicense.MaximumSize = New System.Drawing.Size(660, 0)
        Me.lblLicense.MinimumSize = New System.Drawing.Size(660, 0)
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(660, 14)
        Me.lblLicense.TabIndex = 0
        Me.lblLicense.Text = "lblLicense"
        '
        'lblTesters
        '
        Me.lblTesters.AutoSize = True
        Me.lblTesters.Location = New System.Drawing.Point(143, 22)
        Me.lblTesters.MaximumSize = New System.Drawing.Size(660, 0)
        Me.lblTesters.Name = "lblTesters"
        Me.lblTesters.Size = New System.Drawing.Size(53, 13)
        Me.lblTesters.TabIndex = 3
        Me.lblTesters.Text = "lblTesters"
        '
        'lblTranslators
        '
        Me.lblTranslators.AutoSize = True
        Me.lblTranslators.Location = New System.Drawing.Point(25, 22)
        Me.lblTranslators.MaximumSize = New System.Drawing.Size(660, 0)
        Me.lblTranslators.Name = "lblTranslators"
        Me.lblTranslators.Size = New System.Drawing.Size(53, 13)
        Me.lblTranslators.TabIndex = 1
        Me.lblTranslators.Text = "lblTesters"
        '
        'tabAbout
        '
        Me.tabAbout.Controls.Add(tpAbout)
        Me.tabAbout.Controls.Add(tpCredits)
        Me.tabAbout.Controls.Add(Me.tpContributors)
        Me.tabAbout.Controls.Add(tpLicense)
        Me.tabAbout.Controls.Add(Me.tpChangeLog)
        Me.tabAbout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabAbout.Location = New System.Drawing.Point(3, 3)
        Me.tabAbout.Name = "tabAbout"
        Me.tabAbout.SelectedIndex = 0
        Me.tabAbout.Size = New System.Drawing.Size(697, 335)
        Me.tabAbout.TabIndex = 6
        '
        'tpContributors
        '
        Me.tpContributors.Controls.Add(Me.TableLayoutPanel2)
        Me.tpContributors.Controls.Add(Label10)
        Me.tpContributors.Location = New System.Drawing.Point(4, 22)
        Me.tpContributors.Name = "tpContributors"
        Me.tpContributors.Size = New System.Drawing.Size(689, 309)
        Me.tpContributors.TabIndex = 4
        Me.tpContributors.Text = "Contributors"
        Me.tpContributors.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Label6, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Label8, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTesters, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTranslators, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.PictureBox2, 3, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(688, 280)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.hdd_guardian.My.Resources.Resources.language
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.hdd_guardian.My.Resources.Resources.tester
        Me.PictureBox2.Location = New System.Drawing.Point(123, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'tpChangeLog
        '
        Me.tpChangeLog.AutoScroll = True
        Me.tpChangeLog.Controls.Add(Me.lblChangeLog)
        Me.tpChangeLog.Location = New System.Drawing.Point(4, 22)
        Me.tpChangeLog.Name = "tpChangeLog"
        Me.tpChangeLog.Size = New System.Drawing.Size(689, 309)
        Me.tpChangeLog.TabIndex = 5
        Me.tpChangeLog.Text = "Change Log"
        Me.tpChangeLog.UseVisualStyleBackColor = True
        '
        'lblChangeLog
        '
        Me.lblChangeLog.AutoSize = True
        Me.lblChangeLog.Location = New System.Drawing.Point(8, 8)
        Me.lblChangeLog.MaximumSize = New System.Drawing.Size(660, 0)
        Me.lblChangeLog.MinimumSize = New System.Drawing.Size(660, 0)
        Me.lblChangeLog.Name = "lblChangeLog"
        Me.lblChangeLog.Size = New System.Drawing.Size(660, 13)
        Me.lblChangeLog.TabIndex = 1
        Me.lblChangeLog.Text = "lblChangeLog"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 341)
        Me.Controls.Add(Me.tabAbout)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        tpAbout.ResumeLayout(False)
        tpAbout.PerformLayout()
        Me.tlpAbout.ResumeLayout(False)
        Me.tlpAbout.PerformLayout()
        CType(picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        tlpContacts.ResumeLayout(False)
        tlpContacts.PerformLayout()
        CType(Me.picCodePlex, System.ComponentModel.ISupportInitialize).EndInit()
        tpCredits.ResumeLayout(False)
        flwCredits.ResumeLayout(False)
        flwCredits.PerformLayout()
        tpLicense.ResumeLayout(False)
        tpLicense.PerformLayout()
        Me.tabAbout.ResumeLayout(False)
        Me.tpContributors.ResumeLayout(False)
        Me.tpContributors.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpChangeLog.ResumeLayout(False)
        Me.tpChangeLog.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabAbout As System.Windows.Forms.TabControl
    Friend WithEvents lblFramework As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lnkSmartMonTools As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkGpl As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkKamiyamane As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkCcBy As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkBrandsOfTheWorld As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkWesternDigital As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkCoolerMaster As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkOxygen2 As System.Windows.Forms.LinkLabel
    Friend WithEvents tpContributors As System.Windows.Forms.TabPage
    Friend WithEvents lblLicense As System.Windows.Forms.Label
    Friend WithEvents tlpAbout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lnkOxygen As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lnkLgplOxygen As System.Windows.Forms.LinkLabel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lnkCrystal As System.Windows.Forms.LinkLabel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lnkEveraldo As System.Windows.Forms.LinkLabel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lnkLgplCrystal As System.Windows.Forms.LinkLabel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lnkOpenClipart As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkHddGuardian As hdd_guardian.NewLink
    Friend WithEvents tpChangeLog As System.Windows.Forms.TabPage
    Friend WithEvents lblChangeLog As System.Windows.Forms.Label
    Friend WithEvents lnkCodePlex As System.Windows.Forms.LinkLabel
    Friend WithEvents picCodePlex As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTesters As System.Windows.Forms.Label
    Friend WithEvents lblTranslators As System.Windows.Forms.Label
End Class
