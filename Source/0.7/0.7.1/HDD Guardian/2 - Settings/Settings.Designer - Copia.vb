<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim tlpGeneralTitle As System.Windows.Forms.TableLayoutPanel
        Dim tlpDetectionTitle As System.Windows.Forms.TableLayoutPanel
        Dim tlpMessagesTitle As System.Windows.Forms.TableLayoutPanel
        Dim tlpMailAlertsTitle As System.Windows.Forms.TableLayoutPanel
        Dim tlpUpdateTitle As System.Windows.Forms.TableLayoutPanel
        Dim tlpMonitoringTitle As System.Windows.Forms.TableLayoutPanel
        Dim tlpHdd As System.Windows.Forms.TableLayoutPanel
        Dim tlpWarningsTitle As System.Windows.Forms.TableLayoutPanel
        Dim flwXml As System.Windows.Forms.FlowLayoutPanel
        Dim tlpShareTitle As System.Windows.Forms.TableLayoutPanel
        Dim flwShare As System.Windows.Forms.FlowLayoutPanel
        Dim tlpRatingTitle As System.Windows.Forms.TableLayoutPanel
        Dim tlpToleranceTitle As System.Windows.Forms.TableLayoutPanel
        Dim tlpAddDevicesTitle As System.Windows.Forms.TableLayoutPanel
        Dim FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
        Dim tlpSmartctlTitle As System.Windows.Forms.TableLayoutPanel
        Me.picHelpSetupGeneral = New System.Windows.Forms.PictureBox()
        Me.lblGeneralTitle = New System.Windows.Forms.Label()
        Me.picHelpSetupDetection = New System.Windows.Forms.PictureBox()
        Me.lblDetectionTitle = New System.Windows.Forms.Label()
        Me.picHelpSetupTranslation = New System.Windows.Forms.PictureBox()
        Me.lblTranslationTitle = New System.Windows.Forms.Label()
        Me.picHelpSetupMailAlerts = New System.Windows.Forms.PictureBox()
        Me.lblMailAlertsTitle = New System.Windows.Forms.Label()
        Me.picHelpSetupUpdate = New System.Windows.Forms.PictureBox()
        Me.lblUpdateTitle = New System.Windows.Forms.Label()
        Me.picHelpSetupMonitoring = New System.Windows.Forms.PictureBox()
        Me.lblMonitoringTitle = New System.Windows.Forms.Label()
        Me.chkSandForce = New System.Windows.Forms.CheckBox()
        Me.chkIndilinx = New System.Windows.Forms.CheckBox()
        Me.chkSamsung = New System.Windows.Forms.CheckBox()
        Me.chkIntel = New System.Windows.Forms.CheckBox()
        Me.chkMicron = New System.Windows.Forms.CheckBox()
        Me.lblSsd = New System.Windows.Forms.Label()
        Me.lnkInvertHddSel = New hdd_guardian.NewLink()
        Me.chkDiskShift = New System.Windows.Forms.CheckBox()
        Me.chkSoftReadErr = New System.Windows.Forms.CheckBox()
        Me.chkOfflUnc = New System.Windows.Forms.CheckBox()
        Me.lnkInvertSsdSel = New hdd_guardian.NewLink()
        Me.chkCurPenSect = New System.Windows.Forms.CheckBox()
        Me.chkReallEvCt = New System.Windows.Forms.CheckBox()
        Me.chkSpinRetryCt = New System.Windows.Forms.CheckBox()
        Me.chkReallSectCt = New System.Windows.Forms.CheckBox()
        Me.lblHdd = New System.Windows.Forms.Label()
        Me.chkTemp = New System.Windows.Forms.CheckBox()
        Me.lblGeneric = New System.Windows.Forms.Label()
        Me.picHelpSetupWarnings = New System.Windows.Forms.PictureBox()
        Me.lblWarningsTitle = New System.Windows.Forms.Label()
        Me.lblXml = New System.Windows.Forms.Label()
        Me.btnXml = New System.Windows.Forms.Button()
        Me.lblXmlPath = New System.Windows.Forms.Label()
        Me.picHelpSetupShare = New System.Windows.Forms.PictureBox()
        Me.lblShareTitle = New System.Windows.Forms.Label()
        Me.btnBrwsFolder = New System.Windows.Forms.Button()
        Me.lblFolder = New System.Windows.Forms.Label()
        Me.picHelpSetupRating = New System.Windows.Forms.PictureBox()
        Me.lblRatingTitle = New System.Windows.Forms.Label()
        Me.picHelpSetupTolerance = New System.Windows.Forms.PictureBox()
        Me.lblToleranceTitle = New System.Windows.Forms.Label()
        Me.picHelpSetupAddDevice = New System.Windows.Forms.PictureBox()
        Me.lblAddDevices = New System.Windows.Forms.Label()
        Me.lblSmartctlFolder = New System.Windows.Forms.Label()
        Me.btnBrwsSmartctl = New System.Windows.Forms.Button()
        Me.lblSmartctlPath = New System.Windows.Forms.Label()
        Me.picHelpSmartctl = New System.Windows.Forms.PictureBox()
        Me.lblSmartctlVersion = New System.Windows.Forms.Label()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.tlpMenuItems = New System.Windows.Forms.TableLayoutPanel()
        Me.robGeneral = New hdd_guardian.RibbonOptionButton()
        Me.robTranslation = New hdd_guardian.RibbonOptionButton()
        Me.robDetection = New hdd_guardian.RibbonOptionButton()
        Me.robShare = New hdd_guardian.RibbonOptionButton()
        Me.robUpdate = New hdd_guardian.RibbonOptionButton()
        Me.robMonitoring = New hdd_guardian.RibbonOptionButton()
        Me.robWarnings = New hdd_guardian.RibbonOptionButton()
        Me.robMailAlerts = New hdd_guardian.RibbonOptionButton()
        Me.robRating = New hdd_guardian.RibbonOptionButton()
        Me.RibbonHorizontalSeparator1 = New hdd_guardian.RibbonHorizontalSeparator()
        Me.lblSmartctl = New System.Windows.Forms.Label()
        Me.robTolerance = New hdd_guardian.RibbonOptionButton()
        Me.robAddDevices = New hdd_guardian.RibbonOptionButton()
        Me.robSmartctl = New hdd_guardian.RibbonOptionButton()
        Me.htcSettings = New hdd_guardian.HeadlessTabControl()
        Me.tpGeneral = New System.Windows.Forms.TabPage()
        Me.tlpGeneral = New System.Windows.Forms.TableLayoutPanel()
        Me.chkFahrenheit = New System.Windows.Forms.CheckBox()
        Me.HorizontalLine7 = New hdd_guardian.HorizontalLine()
        Me.lblStartup = New System.Windows.Forms.Label()
        Me.lblBehaviour = New System.Windows.Forms.Label()
        Me.lblUpdates = New System.Windows.Forms.Label()
        Me.lblFahrenheit = New System.Windows.Forms.Label()
        Me.lblDebug = New System.Windows.Forms.Label()
        Me.chkDebug = New System.Windows.Forms.CheckBox()
        Me.tlpBehaviour = New System.Windows.Forms.TableLayoutPanel()
        Me.chkMinimizeInTray = New System.Windows.Forms.CheckBox()
        Me.chkCloseOnTray = New System.Windows.Forms.CheckBox()
        Me.chkAlwaysShowTray = New System.Windows.Forms.CheckBox()
        Me.chkConfirmExit = New System.Windows.Forms.CheckBox()
        Me.chkRememberSize = New System.Windows.Forms.CheckBox()
        Me.chkInfoPanel = New System.Windows.Forms.CheckBox()
        Me.tlpStartup = New System.Windows.Forms.TableLayoutPanel()
        Me.chkStartupLink = New System.Windows.Forms.CheckBox()
        Me.chkRunMinimized = New System.Windows.Forms.CheckBox()
        Me.tlpUpdates = New System.Windows.Forms.TableLayoutPanel()
        Me.chkUpdates = New System.Windows.Forms.CheckBox()
        Me.chkLanguageUpdates = New System.Windows.Forms.CheckBox()
        Me.tpDetection = New System.Windows.Forms.TabPage()
        Me.tlpDetectionContent = New System.Windows.Forms.TableLayoutPanel()
        Me.HorizontalLine1 = New hdd_guardian.HorizontalLine()
        Me.chkMonitorUsb = New System.Windows.Forms.CheckBox()
        Me.chkCsmi = New System.Windows.Forms.CheckBox()
        Me.tlpNeedRestart = New System.Windows.Forms.TableLayoutPanel()
        Me.picNeedRestart = New System.Windows.Forms.PictureBox()
        Me.lblNeedRestart = New System.Windows.Forms.Label()
        Me.tpTranslation = New System.Windows.Forms.TabPage()
        Me.tlpMessagesContent = New System.Windows.Forms.TableLayoutPanel()
        Me.HorizontalLine2 = New hdd_guardian.HorizontalLine()
        Me.optAutomatic = New System.Windows.Forms.RadioButton()
        Me.optCustom = New System.Windows.Forms.RadioButton()
        Me.lblLanguageInfo = New System.Windows.Forms.Label()
        Me.cboLanguage = New System.Windows.Forms.ComboBox()
        Me.tlpLanguageInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblTranslator = New System.Windows.Forms.Label()
        Me.lblVersionValue = New System.Windows.Forms.Label()
        Me.lblTranslatorValue = New System.Windows.Forms.Label()
        Me.tpMailAlerts = New System.Windows.Forms.TabPage()
        Me.tlpMailAlertsContent = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpWhenSendMail = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSendMailWhen = New System.Windows.Forms.Label()
        Me.chkMailDeviceFail = New System.Windows.Forms.CheckBox()
        Me.chkMailExcessiveTemp = New System.Windows.Forms.CheckBox()
        Me.chkMailReliabilityDown = New System.Windows.Forms.CheckBox()
        Me.HorizontalLine3 = New hdd_guardian.HorizontalLine()
        Me.tlpMail = New System.Windows.Forms.TableLayoutPanel()
        Me.txtMail = New System.Windows.Forms.TextBox()
        Me.lnkTestMail = New hdd_guardian.NewLink()
        Me.chkMailAlerts = New System.Windows.Forms.CheckBox()
        Me.lblSetMailServer = New System.Windows.Forms.Label()
        Me.tlpCustomServer = New System.Windows.Forms.TableLayoutPanel()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.txtSmtp = New System.Windows.Forms.TextBox()
        Me.chkSsl = New System.Windows.Forms.CheckBox()
        Me.lblSmtp = New System.Windows.Forms.Label()
        Me.lblCustomMail = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtCustomMail = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.lblMailDestination = New System.Windows.Forms.Label()
        Me.tlpReport = New System.Windows.Forms.TableLayoutPanel()
        Me.lblReport = New System.Windows.Forms.Label()
        Me.chkReport = New System.Windows.Forms.CheckBox()
        Me.cboDays = New System.Windows.Forms.ComboBox()
        Me.nlSendReport = New hdd_guardian.NewLink()
        Me.tpUpdate = New System.Windows.Forms.TabPage()
        Me.tlpUpdateContent = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpUpdate = New System.Windows.Forms.TableLayoutPanel()
        Me.lblVirtual = New System.Windows.Forms.Label()
        Me.numUpdateVirtual = New System.Windows.Forms.NumericUpDown()
        Me.lblMinutesVirt = New System.Windows.Forms.Label()
        Me.lblExternal = New System.Windows.Forms.Label()
        Me.numUpdateExt = New System.Windows.Forms.NumericUpDown()
        Me.lblMinutesExt = New System.Windows.Forms.Label()
        Me.lblMinutes = New System.Windows.Forms.Label()
        Me.numUpdate = New System.Windows.Forms.NumericUpDown()
        Me.lblInternal = New System.Windows.Forms.Label()
        Me.lblUpdate = New System.Windows.Forms.Label()
        Me.HorizontalLine4 = New hdd_guardian.HorizontalLine()
        Me.tpMonitoring = New System.Windows.Forms.TabPage()
        Me.tlpMonitoringContent = New System.Windows.Forms.TableLayoutPanel()
        Me.HorizontalLine8 = New hdd_guardian.HorizontalLine()
        Me.lblParamToMonitor = New System.Windows.Forms.Label()
        Me.tpWarnings = New System.Windows.Forms.TabPage()
        Me.tlpWarningsContent = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpParamChange = New System.Windows.Forms.TableLayoutPanel()
        Me.chkIndilinxChng = New System.Windows.Forms.CheckBox()
        Me.chkSamsungChng = New System.Windows.Forms.CheckBox()
        Me.chkIntelChng = New System.Windows.Forms.CheckBox()
        Me.chkMicronChng = New System.Windows.Forms.CheckBox()
        Me.lblSsdChange = New System.Windows.Forms.Label()
        Me.lnkHddChngInvert = New hdd_guardian.NewLink()
        Me.chkDiskShiftChng = New System.Windows.Forms.CheckBox()
        Me.chkSoftReadErrChng = New System.Windows.Forms.CheckBox()
        Me.lnkSsdChngInvert = New hdd_guardian.NewLink()
        Me.chkOfflUncChng = New System.Windows.Forms.CheckBox()
        Me.chkCurPenSectChng = New System.Windows.Forms.CheckBox()
        Me.chkReallEvCtChng = New System.Windows.Forms.CheckBox()
        Me.chkSpinRetryCtChng = New System.Windows.Forms.CheckBox()
        Me.chkReallSectCtChng = New System.Windows.Forms.CheckBox()
        Me.chkTempChng = New System.Windows.Forms.CheckBox()
        Me.lblHddChange = New System.Windows.Forms.Label()
        Me.chkSandForceChng = New System.Windows.Forms.CheckBox()
        Me.lblGenericChange = New System.Windows.Forms.Label()
        Me.chkParamChng = New System.Windows.Forms.CheckBox()
        Me.chkTempThresh = New System.Windows.Forms.CheckBox()
        Me.chkFailure = New System.Windows.Forms.CheckBox()
        Me.HorizontalLine5 = New hdd_guardian.HorizontalLine()
        Me.tlpTempThreshold = New System.Windows.Forms.TableLayoutPanel()
        Me.chkCustomTemp = New System.Windows.Forms.CheckBox()
        Me.numTemp = New System.Windows.Forms.NumericUpDown()
        Me.lblTemp = New System.Windows.Forms.Label()
        Me.tpShare = New System.Windows.Forms.TabPage()
        Me.tlpShareContent = New System.Windows.Forms.TableLayoutPanel()
        Me.chkXml = New System.Windows.Forms.CheckBox()
        Me.lblSelFolder = New System.Windows.Forms.Label()
        Me.HorizontalLine9 = New hdd_guardian.HorizontalLine()
        Me.lblSharing = New System.Windows.Forms.Label()
        Me.lblXmlCreate = New System.Windows.Forms.Label()
        Me.tpRating = New System.Windows.Forms.TabPage()
        Me.tlpRatingContent = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpTuneUp = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCurPendTune = New System.Windows.Forms.Label()
        Me.lnkResetOfflUnc = New hdd_guardian.NewLink()
        Me.lblErrorsTune = New System.Windows.Forms.Label()
        Me.lblOfflUncTune = New System.Windows.Forms.Label()
        Me.lnkResetCurPending = New hdd_guardian.NewLink()
        Me.numErrors = New System.Windows.Forms.NumericUpDown()
        Me.numCurPend = New System.Windows.Forms.NumericUpDown()
        Me.lnkResetErrors = New hdd_guardian.NewLink()
        Me.numOfflUnc = New System.Windows.Forms.NumericUpDown()
        Me.chkTuneUp = New System.Windows.Forms.CheckBox()
        Me.chkRating = New System.Windows.Forms.CheckBox()
        Me.HorizontalLine6 = New hdd_guardian.HorizontalLine()
        Me.tpTolerance = New System.Windows.Forms.TabPage()
        Me.tlpToleranceContent = New System.Windows.Forms.TableLayoutPanel()
        Me.flwTolerance = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbNormal = New System.Windows.Forms.RadioButton()
        Me.lblNormal = New System.Windows.Forms.Label()
        Me.rbConservative = New System.Windows.Forms.RadioButton()
        Me.lblConservative = New System.Windows.Forms.Label()
        Me.rbVeryPermissive = New System.Windows.Forms.RadioButton()
        Me.lblVeryPermissive = New System.Windows.Forms.Label()
        Me.lblInfoTolerance = New System.Windows.Forms.Label()
        Me.chkTolerance = New System.Windows.Forms.CheckBox()
        Me.HorizontalLine10 = New hdd_guardian.HorizontalLine()
        Me.tpAddDevices = New System.Windows.Forms.TabPage()
        Me.tlpAddDevices = New System.Windows.Forms.TableLayoutPanel()
        Me.lblInfoAddDevices = New System.Windows.Forms.Label()
        Me.HorizontalLine11 = New hdd_guardian.HorizontalLine()
        Me.tlpDevicesList = New System.Windows.Forms.TableLayoutPanel()
        Me.lvwAdditionalDevices = New System.Windows.Forms.ListView()
        Me.chDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chCommand = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tlpAddDevice = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAddDevice = New System.Windows.Forms.Button()
        Me.btnRemoveDevice = New System.Windows.Forms.Button()
        Me.tpSmartctl = New System.Windows.Forms.TabPage()
        Me.tlpSmartctl = New System.Windows.Forms.TableLayoutPanel()
        Me.chkSmartctl = New System.Windows.Forms.CheckBox()
        Me.HorizontalLine12 = New hdd_guardian.HorizontalLine()
        tlpGeneralTitle = New System.Windows.Forms.TableLayoutPanel()
        tlpDetectionTitle = New System.Windows.Forms.TableLayoutPanel()
        tlpMessagesTitle = New System.Windows.Forms.TableLayoutPanel()
        tlpMailAlertsTitle = New System.Windows.Forms.TableLayoutPanel()
        tlpUpdateTitle = New System.Windows.Forms.TableLayoutPanel()
        tlpMonitoringTitle = New System.Windows.Forms.TableLayoutPanel()
        tlpHdd = New System.Windows.Forms.TableLayoutPanel()
        tlpWarningsTitle = New System.Windows.Forms.TableLayoutPanel()
        flwXml = New System.Windows.Forms.FlowLayoutPanel()
        tlpShareTitle = New System.Windows.Forms.TableLayoutPanel()
        flwShare = New System.Windows.Forms.FlowLayoutPanel()
        tlpRatingTitle = New System.Windows.Forms.TableLayoutPanel()
        tlpToleranceTitle = New System.Windows.Forms.TableLayoutPanel()
        tlpAddDevicesTitle = New System.Windows.Forms.TableLayoutPanel()
        FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        tlpSmartctlTitle = New System.Windows.Forms.TableLayoutPanel()
        tlpGeneralTitle.SuspendLayout()
        CType(Me.picHelpSetupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpDetectionTitle.SuspendLayout()
        CType(Me.picHelpSetupDetection, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpMessagesTitle.SuspendLayout()
        CType(Me.picHelpSetupTranslation, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpMailAlertsTitle.SuspendLayout()
        CType(Me.picHelpSetupMailAlerts, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpUpdateTitle.SuspendLayout()
        CType(Me.picHelpSetupUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpMonitoringTitle.SuspendLayout()
        CType(Me.picHelpSetupMonitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpHdd.SuspendLayout()
        tlpWarningsTitle.SuspendLayout()
        CType(Me.picHelpSetupWarnings, System.ComponentModel.ISupportInitialize).BeginInit()
        flwXml.SuspendLayout()
        tlpShareTitle.SuspendLayout()
        CType(Me.picHelpSetupShare, System.ComponentModel.ISupportInitialize).BeginInit()
        flwShare.SuspendLayout()
        tlpRatingTitle.SuspendLayout()
        CType(Me.picHelpSetupRating, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpToleranceTitle.SuspendLayout()
        CType(Me.picHelpSetupTolerance, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpAddDevicesTitle.SuspendLayout()
        CType(Me.picHelpSetupAddDevice, System.ComponentModel.ISupportInitialize).BeginInit()
        FlowLayoutPanel1.SuspendLayout()
        tlpSmartctlTitle.SuspendLayout()
        CType(Me.picHelpSmartctl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMenu.SuspendLayout()
        Me.tlpMenuItems.SuspendLayout()
        Me.htcSettings.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.tlpGeneral.SuspendLayout()
        CType(Me.HorizontalLine7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpBehaviour.SuspendLayout()
        Me.tlpStartup.SuspendLayout()
        Me.tlpUpdates.SuspendLayout()
        Me.tpDetection.SuspendLayout()
        Me.tlpDetectionContent.SuspendLayout()
        CType(Me.HorizontalLine1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpNeedRestart.SuspendLayout()
        CType(Me.picNeedRestart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTranslation.SuspendLayout()
        Me.tlpMessagesContent.SuspendLayout()
        CType(Me.HorizontalLine2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpLanguageInfo.SuspendLayout()
        Me.tpMailAlerts.SuspendLayout()
        Me.tlpMailAlertsContent.SuspendLayout()
        Me.tlpWhenSendMail.SuspendLayout()
        CType(Me.HorizontalLine3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMail.SuspendLayout()
        Me.tlpCustomServer.SuspendLayout()
        Me.tlpReport.SuspendLayout()
        Me.tpUpdate.SuspendLayout()
        Me.tlpUpdateContent.SuspendLayout()
        Me.tlpUpdate.SuspendLayout()
        CType(Me.numUpdateVirtual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUpdateExt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HorizontalLine4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMonitoring.SuspendLayout()
        Me.tlpMonitoringContent.SuspendLayout()
        CType(Me.HorizontalLine8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpWarnings.SuspendLayout()
        Me.tlpWarningsContent.SuspendLayout()
        Me.tlpParamChange.SuspendLayout()
        CType(Me.HorizontalLine5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpTempThreshold.SuspendLayout()
        CType(Me.numTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpShare.SuspendLayout()
        Me.tlpShareContent.SuspendLayout()
        CType(Me.HorizontalLine9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpRating.SuspendLayout()
        Me.tlpRatingContent.SuspendLayout()
        Me.tlpTuneUp.SuspendLayout()
        CType(Me.numErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCurPend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOfflUnc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HorizontalLine6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTolerance.SuspendLayout()
        Me.tlpToleranceContent.SuspendLayout()
        Me.flwTolerance.SuspendLayout()
        CType(Me.HorizontalLine10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAddDevices.SuspendLayout()
        Me.tlpAddDevices.SuspendLayout()
        CType(Me.HorizontalLine11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpDevicesList.SuspendLayout()
        Me.tlpAddDevice.SuspendLayout()
        Me.tpSmartctl.SuspendLayout()
        Me.tlpSmartctl.SuspendLayout()
        CType(Me.HorizontalLine12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpGeneralTitle
        '
        tlpGeneralTitle.AutoSize = True
        tlpGeneralTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpGeneralTitle.ColumnCount = 2
        tlpGeneralTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpGeneralTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpGeneralTitle.Controls.Add(Me.picHelpSetupGeneral, 1, 0)
        tlpGeneralTitle.Controls.Add(Me.lblGeneralTitle, 0, 0)
        tlpGeneralTitle.Dock = System.Windows.Forms.DockStyle.Top
        tlpGeneralTitle.Location = New System.Drawing.Point(0, 0)
        tlpGeneralTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpGeneralTitle.Name = "tlpGeneralTitle"
        tlpGeneralTitle.RowCount = 1
        tlpGeneralTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpGeneralTitle.Size = New System.Drawing.Size(565, 33)
        tlpGeneralTitle.TabIndex = 3
        '
        'picHelpSetupGeneral
        '
        Me.picHelpSetupGeneral.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupGeneral.Location = New System.Drawing.Point(546, 8)
        Me.picHelpSetupGeneral.Name = "picHelpSetupGeneral"
        Me.picHelpSetupGeneral.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupGeneral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupGeneral.TabIndex = 2
        Me.picHelpSetupGeneral.TabStop = False
        '
        'lblGeneralTitle
        '
        Me.lblGeneralTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblGeneralTitle.AutoSize = True
        Me.lblGeneralTitle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGeneralTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblGeneralTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblGeneralTitle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblGeneralTitle.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblGeneralTitle.Name = "lblGeneralTitle"
        Me.lblGeneralTitle.Size = New System.Drawing.Size(96, 33)
        Me.lblGeneralTitle.TabIndex = 0
        Me.lblGeneralTitle.Text = "lblGeneralTitle"
        Me.lblGeneralTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpDetectionTitle
        '
        tlpDetectionTitle.AutoSize = True
        tlpDetectionTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpDetectionTitle.ColumnCount = 2
        tlpDetectionTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpDetectionTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpDetectionTitle.Controls.Add(Me.picHelpSetupDetection, 1, 0)
        tlpDetectionTitle.Controls.Add(Me.lblDetectionTitle, 0, 0)
        tlpDetectionTitle.Dock = System.Windows.Forms.DockStyle.Top
        tlpDetectionTitle.Location = New System.Drawing.Point(0, 0)
        tlpDetectionTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpDetectionTitle.Name = "tlpDetectionTitle"
        tlpDetectionTitle.RowCount = 1
        tlpDetectionTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpDetectionTitle.Size = New System.Drawing.Size(582, 33)
        tlpDetectionTitle.TabIndex = 3
        '
        'picHelpSetupDetection
        '
        Me.picHelpSetupDetection.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupDetection.Location = New System.Drawing.Point(563, 8)
        Me.picHelpSetupDetection.Name = "picHelpSetupDetection"
        Me.picHelpSetupDetection.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupDetection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupDetection.TabIndex = 2
        Me.picHelpSetupDetection.TabStop = False
        '
        'lblDetectionTitle
        '
        Me.lblDetectionTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDetectionTitle.AutoSize = True
        Me.lblDetectionTitle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetectionTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDetectionTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblDetectionTitle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblDetectionTitle.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblDetectionTitle.Name = "lblDetectionTitle"
        Me.lblDetectionTitle.Size = New System.Drawing.Size(108, 33)
        Me.lblDetectionTitle.TabIndex = 0
        Me.lblDetectionTitle.Text = "lblDetectionTitle"
        Me.lblDetectionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpMessagesTitle
        '
        tlpMessagesTitle.AutoSize = True
        tlpMessagesTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpMessagesTitle.ColumnCount = 2
        tlpMessagesTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpMessagesTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpMessagesTitle.Controls.Add(Me.picHelpSetupTranslation, 1, 0)
        tlpMessagesTitle.Controls.Add(Me.lblTranslationTitle, 0, 0)
        tlpMessagesTitle.Dock = System.Windows.Forms.DockStyle.Top
        tlpMessagesTitle.Location = New System.Drawing.Point(0, 0)
        tlpMessagesTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpMessagesTitle.Name = "tlpMessagesTitle"
        tlpMessagesTitle.RowCount = 1
        tlpMessagesTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpMessagesTitle.Size = New System.Drawing.Size(582, 33)
        tlpMessagesTitle.TabIndex = 3
        '
        'picHelpSetupTranslation
        '
        Me.picHelpSetupTranslation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupTranslation.Location = New System.Drawing.Point(563, 8)
        Me.picHelpSetupTranslation.Name = "picHelpSetupTranslation"
        Me.picHelpSetupTranslation.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupTranslation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupTranslation.TabIndex = 2
        Me.picHelpSetupTranslation.TabStop = False
        '
        'lblTranslationTitle
        '
        Me.lblTranslationTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTranslationTitle.AutoSize = True
        Me.lblTranslationTitle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTranslationTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTranslationTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTranslationTitle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblTranslationTitle.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblTranslationTitle.Name = "lblTranslationTitle"
        Me.lblTranslationTitle.Size = New System.Drawing.Size(118, 33)
        Me.lblTranslationTitle.TabIndex = 0
        Me.lblTranslationTitle.Text = "lblTranslationTitle"
        Me.lblTranslationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpMailAlertsTitle
        '
        tlpMailAlertsTitle.AutoSize = True
        tlpMailAlertsTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpMailAlertsTitle.ColumnCount = 2
        tlpMailAlertsTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpMailAlertsTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpMailAlertsTitle.Controls.Add(Me.picHelpSetupMailAlerts, 1, 0)
        tlpMailAlertsTitle.Controls.Add(Me.lblMailAlertsTitle, 0, 0)
        tlpMailAlertsTitle.Dock = System.Windows.Forms.DockStyle.Top
        tlpMailAlertsTitle.Location = New System.Drawing.Point(0, 0)
        tlpMailAlertsTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpMailAlertsTitle.Name = "tlpMailAlertsTitle"
        tlpMailAlertsTitle.RowCount = 1
        tlpMailAlertsTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpMailAlertsTitle.Size = New System.Drawing.Size(565, 33)
        tlpMailAlertsTitle.TabIndex = 3
        '
        'picHelpSetupMailAlerts
        '
        Me.picHelpSetupMailAlerts.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupMailAlerts.Location = New System.Drawing.Point(546, 8)
        Me.picHelpSetupMailAlerts.Name = "picHelpSetupMailAlerts"
        Me.picHelpSetupMailAlerts.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupMailAlerts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupMailAlerts.TabIndex = 2
        Me.picHelpSetupMailAlerts.TabStop = False
        '
        'lblMailAlertsTitle
        '
        Me.lblMailAlertsTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMailAlertsTitle.AutoSize = True
        Me.lblMailAlertsTitle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMailAlertsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblMailAlertsTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblMailAlertsTitle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblMailAlertsTitle.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblMailAlertsTitle.Name = "lblMailAlertsTitle"
        Me.lblMailAlertsTitle.Size = New System.Drawing.Size(107, 33)
        Me.lblMailAlertsTitle.TabIndex = 0
        Me.lblMailAlertsTitle.Text = "lblMailAlertsTitle"
        Me.lblMailAlertsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpUpdateTitle
        '
        tlpUpdateTitle.AutoSize = True
        tlpUpdateTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpUpdateTitle.ColumnCount = 2
        tlpUpdateTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpUpdateTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpUpdateTitle.Controls.Add(Me.picHelpSetupUpdate, 1, 0)
        tlpUpdateTitle.Controls.Add(Me.lblUpdateTitle, 0, 0)
        tlpUpdateTitle.Dock = System.Windows.Forms.DockStyle.Top
        tlpUpdateTitle.Location = New System.Drawing.Point(0, 0)
        tlpUpdateTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpUpdateTitle.Name = "tlpUpdateTitle"
        tlpUpdateTitle.RowCount = 1
        tlpUpdateTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpUpdateTitle.Size = New System.Drawing.Size(582, 33)
        tlpUpdateTitle.TabIndex = 3
        '
        'picHelpSetupUpdate
        '
        Me.picHelpSetupUpdate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupUpdate.Location = New System.Drawing.Point(563, 8)
        Me.picHelpSetupUpdate.Name = "picHelpSetupUpdate"
        Me.picHelpSetupUpdate.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupUpdate.TabIndex = 2
        Me.picHelpSetupUpdate.TabStop = False
        '
        'lblUpdateTitle
        '
        Me.lblUpdateTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUpdateTitle.AutoSize = True
        Me.lblUpdateTitle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblUpdateTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblUpdateTitle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblUpdateTitle.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblUpdateTitle.Name = "lblUpdateTitle"
        Me.lblUpdateTitle.Size = New System.Drawing.Size(94, 33)
        Me.lblUpdateTitle.TabIndex = 0
        Me.lblUpdateTitle.Text = "lblUpdateTitle"
        Me.lblUpdateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpMonitoringTitle
        '
        tlpMonitoringTitle.AutoSize = True
        tlpMonitoringTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpMonitoringTitle.ColumnCount = 2
        tlpMonitoringTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpMonitoringTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpMonitoringTitle.Controls.Add(Me.picHelpSetupMonitoring, 1, 0)
        tlpMonitoringTitle.Controls.Add(Me.lblMonitoringTitle, 0, 0)
        tlpMonitoringTitle.Dock = System.Windows.Forms.DockStyle.Top
        tlpMonitoringTitle.Location = New System.Drawing.Point(0, 0)
        tlpMonitoringTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpMonitoringTitle.Name = "tlpMonitoringTitle"
        tlpMonitoringTitle.RowCount = 1
        tlpMonitoringTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpMonitoringTitle.Size = New System.Drawing.Size(582, 33)
        tlpMonitoringTitle.TabIndex = 3
        '
        'picHelpSetupMonitoring
        '
        Me.picHelpSetupMonitoring.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupMonitoring.Location = New System.Drawing.Point(563, 8)
        Me.picHelpSetupMonitoring.Name = "picHelpSetupMonitoring"
        Me.picHelpSetupMonitoring.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupMonitoring.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupMonitoring.TabIndex = 2
        Me.picHelpSetupMonitoring.TabStop = False
        '
        'lblMonitoringTitle
        '
        Me.lblMonitoringTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMonitoringTitle.AutoSize = True
        Me.lblMonitoringTitle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonitoringTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblMonitoringTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblMonitoringTitle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblMonitoringTitle.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblMonitoringTitle.Name = "lblMonitoringTitle"
        Me.lblMonitoringTitle.Size = New System.Drawing.Size(113, 33)
        Me.lblMonitoringTitle.TabIndex = 0
        Me.lblMonitoringTitle.Text = "lblMonitoringTitle"
        Me.lblMonitoringTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpHdd
        '
        tlpHdd.AutoSize = True
        tlpHdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpHdd.ColumnCount = 2
        tlpHdd.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        tlpHdd.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        tlpHdd.Controls.Add(Me.chkSandForce, 1, 5)
        tlpHdd.Controls.Add(Me.chkIndilinx, 1, 1)
        tlpHdd.Controls.Add(Me.chkSamsung, 1, 4)
        tlpHdd.Controls.Add(Me.chkIntel, 1, 2)
        tlpHdd.Controls.Add(Me.chkMicron, 1, 3)
        tlpHdd.Controls.Add(Me.lblSsd, 1, 0)
        tlpHdd.Controls.Add(Me.lnkInvertHddSel, 0, 11)
        tlpHdd.Controls.Add(Me.chkDiskShift, 0, 10)
        tlpHdd.Controls.Add(Me.chkSoftReadErr, 0, 9)
        tlpHdd.Controls.Add(Me.chkOfflUnc, 0, 8)
        tlpHdd.Controls.Add(Me.lnkInvertSsdSel, 1, 6)
        tlpHdd.Controls.Add(Me.chkCurPenSect, 0, 7)
        tlpHdd.Controls.Add(Me.chkReallEvCt, 0, 6)
        tlpHdd.Controls.Add(Me.chkSpinRetryCt, 0, 5)
        tlpHdd.Controls.Add(Me.chkReallSectCt, 0, 4)
        tlpHdd.Controls.Add(Me.lblHdd, 0, 3)
        tlpHdd.Controls.Add(Me.chkTemp, 0, 1)
        tlpHdd.Controls.Add(Me.lblGeneric, 0, 0)
        tlpHdd.Dock = System.Windows.Forms.DockStyle.Fill
        tlpHdd.Location = New System.Drawing.Point(0, 74)
        tlpHdd.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        tlpHdd.Name = "tlpHdd"
        tlpHdd.RowCount = 12
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpHdd.Size = New System.Drawing.Size(579, 268)
        tlpHdd.TabIndex = 21
        '
        'chkSandForce
        '
        Me.chkSandForce.AutoSize = True
        Me.chkSandForce.ForeColor = System.Drawing.Color.Black
        Me.chkSandForce.Location = New System.Drawing.Point(292, 114)
        Me.chkSandForce.Name = "chkSandForce"
        Me.chkSandForce.Size = New System.Drawing.Size(93, 17)
        Me.chkSandForce.TabIndex = 13
        Me.chkSandForce.Text = "chkSandForce"
        Me.chkSandForce.UseVisualStyleBackColor = True
        '
        'chkIndilinx
        '
        Me.chkIndilinx.AutoSize = True
        Me.chkIndilinx.ForeColor = System.Drawing.Color.Black
        Me.chkIndilinx.Location = New System.Drawing.Point(292, 22)
        Me.chkIndilinx.Name = "chkIndilinx"
        Me.chkIndilinx.Size = New System.Drawing.Size(76, 17)
        Me.chkIndilinx.TabIndex = 9
        Me.chkIndilinx.Text = "chkIndilinx"
        Me.chkIndilinx.UseVisualStyleBackColor = True
        '
        'chkSamsung
        '
        Me.chkSamsung.AutoSize = True
        Me.chkSamsung.ForeColor = System.Drawing.Color.Black
        Me.chkSamsung.Location = New System.Drawing.Point(292, 91)
        Me.chkSamsung.Name = "chkSamsung"
        Me.chkSamsung.Size = New System.Drawing.Size(85, 17)
        Me.chkSamsung.TabIndex = 12
        Me.chkSamsung.Text = "chkSamsung"
        Me.chkSamsung.UseVisualStyleBackColor = True
        '
        'chkIntel
        '
        Me.chkIntel.AutoSize = True
        Me.chkIntel.ForeColor = System.Drawing.Color.Black
        Me.chkIntel.Location = New System.Drawing.Point(292, 45)
        Me.chkIntel.Name = "chkIntel"
        Me.chkIntel.Size = New System.Drawing.Size(64, 17)
        Me.chkIntel.TabIndex = 10
        Me.chkIntel.Text = "chkIntel"
        Me.chkIntel.UseVisualStyleBackColor = True
        '
        'chkMicron
        '
        Me.chkMicron.AutoSize = True
        Me.chkMicron.ForeColor = System.Drawing.Color.Black
        Me.chkMicron.Location = New System.Drawing.Point(292, 68)
        Me.chkMicron.Name = "chkMicron"
        Me.chkMicron.Size = New System.Drawing.Size(73, 17)
        Me.chkMicron.TabIndex = 11
        Me.chkMicron.Text = "chkMicron"
        Me.chkMicron.UseVisualStyleBackColor = True
        '
        'lblSsd
        '
        Me.lblSsd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSsd.AutoSize = True
        Me.lblSsd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSsd.Location = New System.Drawing.Point(289, 3)
        Me.lblSsd.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblSsd.Name = "lblSsd"
        Me.lblSsd.Size = New System.Drawing.Size(34, 13)
        Me.lblSsd.TabIndex = 12
        Me.lblSsd.Text = "lblSsd"
        '
        'lnkInvertHddSel
        '
        Me.lnkInvertHddSel.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkInvertHddSel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lnkInvertHddSel.AutoSize = True
        Me.lnkInvertHddSel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkInvertHddSel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkInvertHddSel.Location = New System.Drawing.Point(20, 252)
        Me.lnkInvertHddSel.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.lnkInvertHddSel.Name = "lnkInvertHddSel"
        Me.lnkInvertHddSel.Size = New System.Drawing.Size(83, 13)
        Me.lnkInvertHddSel.TabIndex = 8
        Me.lnkInvertHddSel.TabStop = True
        Me.lnkInvertHddSel.Text = "lnkInvertHddSel"
        '
        'chkDiskShift
        '
        Me.chkDiskShift.AutoSize = True
        Me.chkDiskShift.ForeColor = System.Drawing.Color.Black
        Me.chkDiskShift.Location = New System.Drawing.Point(3, 229)
        Me.chkDiskShift.Name = "chkDiskShift"
        Me.chkDiskShift.Size = New System.Drawing.Size(83, 17)
        Me.chkDiskShift.TabIndex = 7
        Me.chkDiskShift.Text = "chkDiskShift"
        Me.chkDiskShift.UseVisualStyleBackColor = True
        '
        'chkSoftReadErr
        '
        Me.chkSoftReadErr.AutoSize = True
        Me.chkSoftReadErr.ForeColor = System.Drawing.Color.Black
        Me.chkSoftReadErr.Location = New System.Drawing.Point(3, 206)
        Me.chkSoftReadErr.Name = "chkSoftReadErr"
        Me.chkSoftReadErr.Size = New System.Drawing.Size(101, 17)
        Me.chkSoftReadErr.TabIndex = 6
        Me.chkSoftReadErr.Text = "chkSoftReadErr"
        Me.chkSoftReadErr.UseVisualStyleBackColor = True
        '
        'chkOfflUnc
        '
        Me.chkOfflUnc.AutoSize = True
        Me.chkOfflUnc.ForeColor = System.Drawing.Color.Black
        Me.chkOfflUnc.Location = New System.Drawing.Point(3, 183)
        Me.chkOfflUnc.Name = "chkOfflUnc"
        Me.chkOfflUnc.Size = New System.Drawing.Size(78, 17)
        Me.chkOfflUnc.TabIndex = 5
        Me.chkOfflUnc.Text = "chkOfflUnc"
        Me.chkOfflUnc.UseVisualStyleBackColor = True
        '
        'lnkInvertSsdSel
        '
        Me.lnkInvertSsdSel.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkInvertSsdSel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lnkInvertSsdSel.AutoSize = True
        Me.lnkInvertSsdSel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkInvertSsdSel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkInvertSsdSel.Location = New System.Drawing.Point(309, 139)
        Me.lnkInvertSsdSel.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.lnkInvertSsdSel.Name = "lnkInvertSsdSel"
        Me.lnkInvertSsdSel.Size = New System.Drawing.Size(81, 13)
        Me.lnkInvertSsdSel.TabIndex = 14
        Me.lnkInvertSsdSel.TabStop = True
        Me.lnkInvertSsdSel.Text = "lnkInvertSsdSel"
        '
        'chkCurPenSect
        '
        Me.chkCurPenSect.AutoSize = True
        Me.chkCurPenSect.ForeColor = System.Drawing.Color.Black
        Me.chkCurPenSect.Location = New System.Drawing.Point(3, 160)
        Me.chkCurPenSect.Name = "chkCurPenSect"
        Me.chkCurPenSect.Size = New System.Drawing.Size(98, 17)
        Me.chkCurPenSect.TabIndex = 4
        Me.chkCurPenSect.Text = "chkCurPenSect"
        Me.chkCurPenSect.UseVisualStyleBackColor = True
        '
        'chkReallEvCt
        '
        Me.chkReallEvCt.AutoSize = True
        Me.chkReallEvCt.ForeColor = System.Drawing.Color.Black
        Me.chkReallEvCt.Location = New System.Drawing.Point(3, 137)
        Me.chkReallEvCt.Name = "chkReallEvCt"
        Me.chkReallEvCt.Size = New System.Drawing.Size(88, 17)
        Me.chkReallEvCt.TabIndex = 3
        Me.chkReallEvCt.Text = "chkReallEvCt"
        Me.chkReallEvCt.UseVisualStyleBackColor = True
        '
        'chkSpinRetryCt
        '
        Me.chkSpinRetryCt.AutoSize = True
        Me.chkSpinRetryCt.ForeColor = System.Drawing.Color.Black
        Me.chkSpinRetryCt.Location = New System.Drawing.Point(3, 114)
        Me.chkSpinRetryCt.Name = "chkSpinRetryCt"
        Me.chkSpinRetryCt.Size = New System.Drawing.Size(100, 17)
        Me.chkSpinRetryCt.TabIndex = 2
        Me.chkSpinRetryCt.Text = "chkSpinRetryCt"
        Me.chkSpinRetryCt.UseVisualStyleBackColor = True
        '
        'chkReallSectCt
        '
        Me.chkReallSectCt.AutoSize = True
        Me.chkReallSectCt.ForeColor = System.Drawing.Color.Black
        Me.chkReallSectCt.Location = New System.Drawing.Point(3, 91)
        Me.chkReallSectCt.Name = "chkReallSectCt"
        Me.chkReallSectCt.Size = New System.Drawing.Size(97, 17)
        Me.chkReallSectCt.TabIndex = 1
        Me.chkReallSectCt.Text = "chkReallSectCt"
        Me.chkReallSectCt.UseVisualStyleBackColor = True
        '
        'lblHdd
        '
        Me.lblHdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHdd.AutoSize = True
        Me.lblHdd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHdd.Location = New System.Drawing.Point(0, 72)
        Me.lblHdd.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblHdd.Name = "lblHdd"
        Me.lblHdd.Size = New System.Drawing.Size(36, 13)
        Me.lblHdd.TabIndex = 11
        Me.lblHdd.Text = "lblHdd"
        '
        'chkTemp
        '
        Me.chkTemp.AutoSize = True
        Me.chkTemp.ForeColor = System.Drawing.Color.Black
        Me.chkTemp.Location = New System.Drawing.Point(3, 22)
        Me.chkTemp.Name = "chkTemp"
        Me.chkTemp.Size = New System.Drawing.Size(68, 17)
        Me.chkTemp.TabIndex = 0
        Me.chkTemp.Text = "chkTemp"
        Me.chkTemp.UseVisualStyleBackColor = True
        '
        'lblGeneric
        '
        Me.lblGeneric.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGeneric.AutoSize = True
        Me.lblGeneric.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblGeneric.Location = New System.Drawing.Point(0, 3)
        Me.lblGeneric.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblGeneric.Name = "lblGeneric"
        Me.lblGeneric.Size = New System.Drawing.Size(53, 13)
        Me.lblGeneric.TabIndex = 17
        Me.lblGeneric.Text = "lblGeneric"
        '
        'tlpWarningsTitle
        '
        tlpWarningsTitle.AutoSize = True
        tlpWarningsTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpWarningsTitle.ColumnCount = 2
        tlpWarningsTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpWarningsTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpWarningsTitle.Controls.Add(Me.picHelpSetupWarnings, 1, 0)
        tlpWarningsTitle.Controls.Add(Me.lblWarningsTitle, 0, 0)
        tlpWarningsTitle.Dock = System.Windows.Forms.DockStyle.Top
        tlpWarningsTitle.Location = New System.Drawing.Point(0, 0)
        tlpWarningsTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpWarningsTitle.Name = "tlpWarningsTitle"
        tlpWarningsTitle.RowCount = 1
        tlpWarningsTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpWarningsTitle.Size = New System.Drawing.Size(565, 33)
        tlpWarningsTitle.TabIndex = 3
        '
        'picHelpSetupWarnings
        '
        Me.picHelpSetupWarnings.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupWarnings.Location = New System.Drawing.Point(546, 8)
        Me.picHelpSetupWarnings.Name = "picHelpSetupWarnings"
        Me.picHelpSetupWarnings.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupWarnings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupWarnings.TabIndex = 2
        Me.picHelpSetupWarnings.TabStop = False
        '
        'lblWarningsTitle
        '
        Me.lblWarningsTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWarningsTitle.AutoSize = True
        Me.lblWarningsTitle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarningsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblWarningsTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblWarningsTitle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblWarningsTitle.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblWarningsTitle.Name = "lblWarningsTitle"
        Me.lblWarningsTitle.Size = New System.Drawing.Size(107, 33)
        Me.lblWarningsTitle.TabIndex = 0
        Me.lblWarningsTitle.Text = "lblWarningsTitle"
        Me.lblWarningsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'flwXml
        '
        flwXml.AutoSize = True
        flwXml.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        flwXml.Controls.Add(Me.lblXml)
        flwXml.Controls.Add(Me.btnXml)
        flwXml.Controls.Add(Me.lblXmlPath)
        flwXml.Dock = System.Windows.Forms.DockStyle.Fill
        flwXml.Location = New System.Drawing.Point(0, 206)
        flwXml.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        flwXml.Name = "flwXml"
        flwXml.Size = New System.Drawing.Size(579, 69)
        flwXml.TabIndex = 21
        '
        'lblXml
        '
        Me.lblXml.AutoSize = True
        flwXml.SetFlowBreak(Me.lblXml, True)
        Me.lblXml.ForeColor = System.Drawing.Color.Black
        Me.lblXml.Location = New System.Drawing.Point(0, 0)
        Me.lblXml.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblXml.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblXml.Name = "lblXml"
        Me.lblXml.Size = New System.Drawing.Size(33, 16)
        Me.lblXml.TabIndex = 20
        Me.lblXml.Text = "lblXml"
        Me.lblXml.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnXml
        '
        flwXml.SetFlowBreak(Me.btnXml, True)
        Me.btnXml.Location = New System.Drawing.Point(0, 23)
        Me.btnXml.Margin = New System.Windows.Forms.Padding(0)
        Me.btnXml.Name = "btnXml"
        Me.btnXml.Size = New System.Drawing.Size(75, 23)
        Me.btnXml.TabIndex = 2
        Me.btnXml.Text = "btnXml"
        Me.btnXml.UseVisualStyleBackColor = True
        '
        'lblXmlPath
        '
        Me.lblXmlPath.AutoSize = True
        flwXml.SetFlowBreak(Me.lblXmlPath, True)
        Me.lblXmlPath.ForeColor = System.Drawing.Color.DimGray
        Me.lblXmlPath.Location = New System.Drawing.Point(0, 46)
        Me.lblXmlPath.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblXmlPath.MinimumSize = New System.Drawing.Size(0, 23)
        Me.lblXmlPath.Name = "lblXmlPath"
        Me.lblXmlPath.Size = New System.Drawing.Size(55, 23)
        Me.lblXmlPath.TabIndex = 1
        Me.lblXmlPath.Text = "lblXmlPath"
        Me.lblXmlPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpShareTitle
        '
        tlpShareTitle.AutoSize = True
        tlpShareTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpShareTitle.ColumnCount = 2
        tlpShareTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpShareTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpShareTitle.Controls.Add(Me.picHelpSetupShare, 1, 0)
        tlpShareTitle.Controls.Add(Me.lblShareTitle, 0, 0)
        tlpShareTitle.Dock = System.Windows.Forms.DockStyle.Top
        tlpShareTitle.Location = New System.Drawing.Point(0, 0)
        tlpShareTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpShareTitle.Name = "tlpShareTitle"
        tlpShareTitle.RowCount = 1
        tlpShareTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpShareTitle.Size = New System.Drawing.Size(582, 33)
        tlpShareTitle.TabIndex = 3
        '
        'picHelpSetupShare
        '
        Me.picHelpSetupShare.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupShare.Location = New System.Drawing.Point(563, 8)
        Me.picHelpSetupShare.Name = "picHelpSetupShare"
        Me.picHelpSetupShare.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupShare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupShare.TabIndex = 2
        Me.picHelpSetupShare.TabStop = False
        '
        'lblShareTitle
        '
        Me.lblShareTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblShareTitle.AutoSize = True
        Me.lblShareTitle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShareTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblShareTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblShareTitle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblShareTitle.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblShareTitle.Name = "lblShareTitle"
        Me.lblShareTitle.Size = New System.Drawing.Size(84, 33)
        Me.lblShareTitle.TabIndex = 0
        Me.lblShareTitle.Text = "lblShareTitle"
        Me.lblShareTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'flwShare
        '
        flwShare.AutoSize = True
        flwShare.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        flwShare.Controls.Add(Me.btnBrwsFolder)
        flwShare.Controls.Add(Me.lblFolder)
        flwShare.Dock = System.Windows.Forms.DockStyle.Fill
        flwShare.Location = New System.Drawing.Point(0, 91)
        flwShare.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        flwShare.Name = "flwShare"
        flwShare.Size = New System.Drawing.Size(579, 46)
        flwShare.TabIndex = 0
        '
        'btnBrwsFolder
        '
        flwShare.SetFlowBreak(Me.btnBrwsFolder, True)
        Me.btnBrwsFolder.Location = New System.Drawing.Point(0, 0)
        Me.btnBrwsFolder.Margin = New System.Windows.Forms.Padding(0)
        Me.btnBrwsFolder.Name = "btnBrwsFolder"
        Me.btnBrwsFolder.Size = New System.Drawing.Size(75, 23)
        Me.btnBrwsFolder.TabIndex = 0
        Me.btnBrwsFolder.Text = "btnBrwsFolder"
        Me.btnBrwsFolder.UseVisualStyleBackColor = True
        '
        'lblFolder
        '
        Me.lblFolder.AutoSize = True
        Me.lblFolder.ForeColor = System.Drawing.Color.DimGray
        Me.lblFolder.Location = New System.Drawing.Point(0, 23)
        Me.lblFolder.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblFolder.MinimumSize = New System.Drawing.Size(0, 23)
        Me.lblFolder.Name = "lblFolder"
        Me.lblFolder.Size = New System.Drawing.Size(47, 23)
        Me.lblFolder.TabIndex = 1
        Me.lblFolder.Text = "lblFolder"
        Me.lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpRatingTitle
        '
        tlpRatingTitle.AutoSize = True
        tlpRatingTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpRatingTitle.ColumnCount = 2
        tlpRatingTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpRatingTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpRatingTitle.Controls.Add(Me.picHelpSetupRating, 1, 0)
        tlpRatingTitle.Controls.Add(Me.lblRatingTitle, 0, 0)
        tlpRatingTitle.Dock = System.Windows.Forms.DockStyle.Top
        tlpRatingTitle.Location = New System.Drawing.Point(0, 0)
        tlpRatingTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpRatingTitle.Name = "tlpRatingTitle"
        tlpRatingTitle.RowCount = 1
        tlpRatingTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpRatingTitle.Size = New System.Drawing.Size(582, 33)
        tlpRatingTitle.TabIndex = 3
        '
        'picHelpSetupRating
        '
        Me.picHelpSetupRating.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupRating.Location = New System.Drawing.Point(563, 8)
        Me.picHelpSetupRating.Name = "picHelpSetupRating"
        Me.picHelpSetupRating.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupRating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupRating.TabIndex = 2
        Me.picHelpSetupRating.TabStop = False
        '
        'lblRatingTitle
        '
        Me.lblRatingTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRatingTitle.AutoSize = True
        Me.lblRatingTitle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRatingTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblRatingTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblRatingTitle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblRatingTitle.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblRatingTitle.Name = "lblRatingTitle"
        Me.lblRatingTitle.Size = New System.Drawing.Size(87, 33)
        Me.lblRatingTitle.TabIndex = 0
        Me.lblRatingTitle.Text = "lblRatingTitle"
        Me.lblRatingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpToleranceTitle
        '
        tlpToleranceTitle.AutoSize = True
        tlpToleranceTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpToleranceTitle.ColumnCount = 2
        tlpToleranceTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpToleranceTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpToleranceTitle.Controls.Add(Me.picHelpSetupTolerance, 1, 0)
        tlpToleranceTitle.Controls.Add(Me.lblToleranceTitle, 0, 0)
        tlpToleranceTitle.Dock = System.Windows.Forms.DockStyle.Fill
        tlpToleranceTitle.Location = New System.Drawing.Point(0, 0)
        tlpToleranceTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpToleranceTitle.Name = "tlpToleranceTitle"
        tlpToleranceTitle.RowCount = 1
        tlpToleranceTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpToleranceTitle.Size = New System.Drawing.Size(582, 33)
        tlpToleranceTitle.TabIndex = 26
        '
        'picHelpSetupTolerance
        '
        Me.picHelpSetupTolerance.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupTolerance.Location = New System.Drawing.Point(563, 8)
        Me.picHelpSetupTolerance.Name = "picHelpSetupTolerance"
        Me.picHelpSetupTolerance.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupTolerance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupTolerance.TabIndex = 2
        Me.picHelpSetupTolerance.TabStop = False
        '
        'lblToleranceTitle
        '
        Me.lblToleranceTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblToleranceTitle.AutoSize = True
        Me.lblToleranceTitle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToleranceTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblToleranceTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblToleranceTitle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblToleranceTitle.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblToleranceTitle.Name = "lblToleranceTitle"
        Me.lblToleranceTitle.Size = New System.Drawing.Size(111, 33)
        Me.lblToleranceTitle.TabIndex = 0
        Me.lblToleranceTitle.Text = "lblToleranceTitle"
        Me.lblToleranceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpAddDevicesTitle
        '
        tlpAddDevicesTitle.AutoSize = True
        tlpAddDevicesTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpAddDevicesTitle.ColumnCount = 2
        tlpAddDevicesTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpAddDevicesTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpAddDevicesTitle.Controls.Add(Me.picHelpSetupAddDevice, 1, 0)
        tlpAddDevicesTitle.Controls.Add(Me.lblAddDevices, 0, 0)
        tlpAddDevicesTitle.Dock = System.Windows.Forms.DockStyle.Fill
        tlpAddDevicesTitle.Location = New System.Drawing.Point(0, 0)
        tlpAddDevicesTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpAddDevicesTitle.Name = "tlpAddDevicesTitle"
        tlpAddDevicesTitle.RowCount = 1
        tlpAddDevicesTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpAddDevicesTitle.Size = New System.Drawing.Size(582, 33)
        tlpAddDevicesTitle.TabIndex = 27
        '
        'picHelpSetupAddDevice
        '
        Me.picHelpSetupAddDevice.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSetupAddDevice.Location = New System.Drawing.Point(563, 8)
        Me.picHelpSetupAddDevice.Name = "picHelpSetupAddDevice"
        Me.picHelpSetupAddDevice.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSetupAddDevice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSetupAddDevice.TabIndex = 2
        Me.picHelpSetupAddDevice.TabStop = False
        '
        'lblAddDevices
        '
        Me.lblAddDevices.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAddDevices.AutoSize = True
        Me.lblAddDevices.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddDevices.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAddDevices.Location = New System.Drawing.Point(0, 0)
        Me.lblAddDevices.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblAddDevices.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblAddDevices.Name = "lblAddDevices"
        Me.lblAddDevices.Size = New System.Drawing.Size(95, 33)
        Me.lblAddDevices.TabIndex = 0
        Me.lblAddDevices.Text = "lblAddDevices"
        Me.lblAddDevices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowLayoutPanel1
        '
        FlowLayoutPanel1.AutoSize = True
        FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        FlowLayoutPanel1.Controls.Add(Me.lblSmartctlFolder)
        FlowLayoutPanel1.Controls.Add(Me.btnBrwsSmartctl)
        FlowLayoutPanel1.Controls.Add(Me.lblSmartctlPath)
        FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        FlowLayoutPanel1.Location = New System.Drawing.Point(0, 79)
        FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New System.Drawing.Size(579, 69)
        FlowLayoutPanel1.TabIndex = 21
        '
        'lblSmartctlFolder
        '
        Me.lblSmartctlFolder.AutoSize = True
        FlowLayoutPanel1.SetFlowBreak(Me.lblSmartctlFolder, True)
        Me.lblSmartctlFolder.ForeColor = System.Drawing.Color.Black
        Me.lblSmartctlFolder.Location = New System.Drawing.Point(0, 0)
        Me.lblSmartctlFolder.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblSmartctlFolder.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblSmartctlFolder.Name = "lblSmartctlFolder"
        Me.lblSmartctlFolder.Size = New System.Drawing.Size(86, 16)
        Me.lblSmartctlFolder.TabIndex = 20
        Me.lblSmartctlFolder.Text = "lblSmartctlFolder"
        Me.lblSmartctlFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBrwsSmartctl
        '
        FlowLayoutPanel1.SetFlowBreak(Me.btnBrwsSmartctl, True)
        Me.btnBrwsSmartctl.Location = New System.Drawing.Point(0, 23)
        Me.btnBrwsSmartctl.Margin = New System.Windows.Forms.Padding(0)
        Me.btnBrwsSmartctl.Name = "btnBrwsSmartctl"
        Me.btnBrwsSmartctl.Size = New System.Drawing.Size(75, 23)
        Me.btnBrwsSmartctl.TabIndex = 1
        Me.btnBrwsSmartctl.Text = "btnBrwsSmartctl"
        Me.btnBrwsSmartctl.UseVisualStyleBackColor = True
        '
        'lblSmartctlPath
        '
        Me.lblSmartctlPath.AutoSize = True
        FlowLayoutPanel1.SetFlowBreak(Me.lblSmartctlPath, True)
        Me.lblSmartctlPath.ForeColor = System.Drawing.Color.DimGray
        Me.lblSmartctlPath.Location = New System.Drawing.Point(0, 46)
        Me.lblSmartctlPath.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblSmartctlPath.MinimumSize = New System.Drawing.Size(0, 23)
        Me.lblSmartctlPath.Name = "lblSmartctlPath"
        Me.lblSmartctlPath.Size = New System.Drawing.Size(78, 23)
        Me.lblSmartctlPath.TabIndex = 1
        Me.lblSmartctlPath.Text = "lblSmartctlPath"
        Me.lblSmartctlPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpSmartctlTitle
        '
        tlpSmartctlTitle.AutoSize = True
        tlpSmartctlTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpSmartctlTitle.ColumnCount = 2
        tlpSmartctlTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpSmartctlTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpSmartctlTitle.Controls.Add(Me.picHelpSmartctl, 1, 0)
        tlpSmartctlTitle.Controls.Add(Me.lblSmartctlVersion, 0, 0)
        tlpSmartctlTitle.Dock = System.Windows.Forms.DockStyle.Top
        tlpSmartctlTitle.Location = New System.Drawing.Point(0, 0)
        tlpSmartctlTitle.Margin = New System.Windows.Forms.Padding(0)
        tlpSmartctlTitle.Name = "tlpSmartctlTitle"
        tlpSmartctlTitle.RowCount = 1
        tlpSmartctlTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpSmartctlTitle.Size = New System.Drawing.Size(582, 33)
        tlpSmartctlTitle.TabIndex = 3
        '
        'picHelpSmartctl
        '
        Me.picHelpSmartctl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picHelpSmartctl.Location = New System.Drawing.Point(563, 8)
        Me.picHelpSmartctl.Name = "picHelpSmartctl"
        Me.picHelpSmartctl.Size = New System.Drawing.Size(16, 16)
        Me.picHelpSmartctl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picHelpSmartctl.TabIndex = 2
        Me.picHelpSmartctl.TabStop = False
        '
        'lblSmartctlVersion
        '
        Me.lblSmartctlVersion.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSmartctlVersion.AutoSize = True
        Me.lblSmartctlVersion.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSmartctlVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSmartctlVersion.Location = New System.Drawing.Point(0, 0)
        Me.lblSmartctlVersion.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblSmartctlVersion.MinimumSize = New System.Drawing.Size(0, 33)
        Me.lblSmartctlVersion.Name = "lblSmartctlVersion"
        Me.lblSmartctlVersion.Size = New System.Drawing.Size(120, 33)
        Me.lblSmartctlVersion.TabIndex = 0
        Me.lblSmartctlVersion.Text = "lblSmartctlVersion"
        Me.lblSmartctlVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlMenu
        '
        Me.pnlMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.pnlMenu.Controls.Add(Me.tlpMenuItems)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlMenu.Size = New System.Drawing.Size(200, 431)
        Me.pnlMenu.TabIndex = 0
        '
        'tlpMenuItems
        '
        Me.tlpMenuItems.ColumnCount = 1
        Me.tlpMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenuItems.Controls.Add(Me.robGeneral, 0, 0)
        Me.tlpMenuItems.Controls.Add(Me.robTranslation, 0, 1)
        Me.tlpMenuItems.Controls.Add(Me.robDetection, 0, 2)
        Me.tlpMenuItems.Controls.Add(Me.robShare, 0, 8)
        Me.tlpMenuItems.Controls.Add(Me.robUpdate, 0, 3)
        Me.tlpMenuItems.Controls.Add(Me.robMonitoring, 0, 4)
        Me.tlpMenuItems.Controls.Add(Me.robWarnings, 0, 5)
        Me.tlpMenuItems.Controls.Add(Me.robMailAlerts, 0, 6)
        Me.tlpMenuItems.Controls.Add(Me.robRating, 0, 7)
        Me.tlpMenuItems.Controls.Add(Me.RibbonHorizontalSeparator1, 0, 10)
        Me.tlpMenuItems.Controls.Add(Me.lblSmartctl, 0, 11)
        Me.tlpMenuItems.Controls.Add(Me.robTolerance, 0, 13)
        Me.tlpMenuItems.Controls.Add(Me.robAddDevices, 0, 14)
        Me.tlpMenuItems.Controls.Add(Me.robSmartctl, 0, 12)
        Me.tlpMenuItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMenuItems.Location = New System.Drawing.Point(5, 5)
        Me.tlpMenuItems.Name = "tlpMenuItems"
        Me.tlpMenuItems.RowCount = 15
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.Size = New System.Drawing.Size(190, 421)
        Me.tlpMenuItems.TabIndex = 0
        '
        'robGeneral
        '
        Me.robGeneral.AutoSize = True
        Me.robGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robGeneral.Icon = Nothing
        Me.robGeneral.Location = New System.Drawing.Point(3, 3)
        Me.robGeneral.Name = "robGeneral"
        Me.robGeneral.Size = New System.Drawing.Size(79, 20)
        Me.robGeneral.TabIndex = 0
        Me.robGeneral.Text = "robGeneral"
        '
        'robTranslation
        '
        Me.robTranslation.AutoSize = True
        Me.robTranslation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robTranslation.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robTranslation.Icon = Nothing
        Me.robTranslation.Location = New System.Drawing.Point(3, 29)
        Me.robTranslation.Name = "robTranslation"
        Me.robTranslation.Size = New System.Drawing.Size(95, 20)
        Me.robTranslation.TabIndex = 1
        Me.robTranslation.Text = "robTranslation"
        '
        'robDetection
        '
        Me.robDetection.AutoSize = True
        Me.robDetection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robDetection.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robDetection.Icon = Nothing
        Me.robDetection.Location = New System.Drawing.Point(3, 55)
        Me.robDetection.Name = "robDetection"
        Me.robDetection.Size = New System.Drawing.Size(88, 20)
        Me.robDetection.TabIndex = 2
        Me.robDetection.Text = "robDetection"
        '
        'robShare
        '
        Me.robShare.AutoSize = True
        Me.robShare.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robShare.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robShare.Icon = Nothing
        Me.robShare.Location = New System.Drawing.Point(3, 211)
        Me.robShare.Name = "robShare"
        Me.robShare.Size = New System.Drawing.Size(70, 20)
        Me.robShare.TabIndex = 8
        Me.robShare.Text = "robShare"
        '
        'robUpdate
        '
        Me.robUpdate.AutoSize = True
        Me.robUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robUpdate.Icon = Nothing
        Me.robUpdate.Location = New System.Drawing.Point(3, 81)
        Me.robUpdate.Name = "robUpdate"
        Me.robUpdate.Size = New System.Drawing.Size(77, 20)
        Me.robUpdate.TabIndex = 3
        Me.robUpdate.Text = "robUpdate"
        '
        'robMonitoring
        '
        Me.robMonitoring.AutoSize = True
        Me.robMonitoring.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robMonitoring.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robMonitoring.Icon = Nothing
        Me.robMonitoring.Location = New System.Drawing.Point(3, 107)
        Me.robMonitoring.Name = "robMonitoring"
        Me.robMonitoring.Size = New System.Drawing.Size(92, 20)
        Me.robMonitoring.TabIndex = 4
        Me.robMonitoring.Text = "robMonitoring"
        '
        'robWarnings
        '
        Me.robWarnings.AutoSize = True
        Me.robWarnings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robWarnings.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robWarnings.Icon = Nothing
        Me.robWarnings.Location = New System.Drawing.Point(3, 133)
        Me.robWarnings.Name = "robWarnings"
        Me.robWarnings.Size = New System.Drawing.Size(87, 20)
        Me.robWarnings.TabIndex = 5
        Me.robWarnings.Text = "robWarnings"
        '
        'robMailAlerts
        '
        Me.robMailAlerts.AutoSize = True
        Me.robMailAlerts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robMailAlerts.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robMailAlerts.Icon = Nothing
        Me.robMailAlerts.Location = New System.Drawing.Point(3, 159)
        Me.robMailAlerts.Name = "robMailAlerts"
        Me.robMailAlerts.Size = New System.Drawing.Size(88, 20)
        Me.robMailAlerts.TabIndex = 6
        Me.robMailAlerts.Text = "robMailAlerts"
        '
        'robRating
        '
        Me.robRating.AutoSize = True
        Me.robRating.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robRating.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robRating.Icon = Nothing
        Me.robRating.Location = New System.Drawing.Point(3, 185)
        Me.robRating.Name = "robRating"
        Me.robRating.Size = New System.Drawing.Size(73, 20)
        Me.robRating.TabIndex = 7
        Me.robRating.Text = "robRating"
        '
        'RibbonHorizontalSeparator1
        '
        Me.RibbonHorizontalSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonHorizontalSeparator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonHorizontalSeparator1.Location = New System.Drawing.Point(3, 237)
        Me.RibbonHorizontalSeparator1.MaximumSize = New System.Drawing.Size(0, 1)
        Me.RibbonHorizontalSeparator1.MinimumSize = New System.Drawing.Size(80, 1)
        Me.RibbonHorizontalSeparator1.Name = "RibbonHorizontalSeparator1"
        Me.RibbonHorizontalSeparator1.Size = New System.Drawing.Size(184, 1)
        Me.RibbonHorizontalSeparator1.TabIndex = 9
        '
        'lblSmartctl
        '
        Me.lblSmartctl.AutoSize = True
        Me.lblSmartctl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSmartctl.Location = New System.Drawing.Point(3, 244)
        Me.lblSmartctl.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSmartctl.Name = "lblSmartctl"
        Me.lblSmartctl.Size = New System.Drawing.Size(56, 13)
        Me.lblSmartctl.TabIndex = 10
        Me.lblSmartctl.Text = "lblSmartctl"
        '
        'robTolerance
        '
        Me.robTolerance.AutoSize = True
        Me.robTolerance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robTolerance.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robTolerance.Icon = Nothing
        Me.robTolerance.Location = New System.Drawing.Point(3, 289)
        Me.robTolerance.Name = "robTolerance"
        Me.robTolerance.Size = New System.Drawing.Size(89, 20)
        Me.robTolerance.TabIndex = 10
        Me.robTolerance.Text = "robTolerance"
        '
        'robAddDevices
        '
        Me.robAddDevices.AutoSize = True
        Me.robAddDevices.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robAddDevices.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robAddDevices.Icon = Nothing
        Me.robAddDevices.Location = New System.Drawing.Point(3, 315)
        Me.robAddDevices.Name = "robAddDevices"
        Me.robAddDevices.Size = New System.Drawing.Size(98, 20)
        Me.robAddDevices.TabIndex = 11
        Me.robAddDevices.Text = "robAddDevices"
        '
        'robSmartctl
        '
        Me.robSmartctl.AutoSize = True
        Me.robSmartctl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.robSmartctl.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.robSmartctl.Icon = Nothing
        Me.robSmartctl.Location = New System.Drawing.Point(3, 263)
        Me.robSmartctl.Name = "robSmartctl"
        Me.robSmartctl.Size = New System.Drawing.Size(81, 20)
        Me.robSmartctl.TabIndex = 9
        Me.robSmartctl.Text = "robSmartctl"
        Me.robSmartctl.Visible = False
        '
        'htcSettings
        '
        Me.htcSettings.Controls.Add(Me.tpGeneral)
        Me.htcSettings.Controls.Add(Me.tpDetection)
        Me.htcSettings.Controls.Add(Me.tpTranslation)
        Me.htcSettings.Controls.Add(Me.tpMailAlerts)
        Me.htcSettings.Controls.Add(Me.tpUpdate)
        Me.htcSettings.Controls.Add(Me.tpMonitoring)
        Me.htcSettings.Controls.Add(Me.tpWarnings)
        Me.htcSettings.Controls.Add(Me.tpShare)
        Me.htcSettings.Controls.Add(Me.tpRating)
        Me.htcSettings.Controls.Add(Me.tpTolerance)
        Me.htcSettings.Controls.Add(Me.tpAddDevices)
        Me.htcSettings.Controls.Add(Me.tpSmartctl)
        Me.htcSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htcSettings.Location = New System.Drawing.Point(200, 0)
        Me.htcSettings.Multiline = True
        Me.htcSettings.Name = "htcSettings"
        Me.htcSettings.SelectedIndex = 0
        Me.htcSettings.Size = New System.Drawing.Size(596, 431)
        Me.htcSettings.TabIndex = 1
        Me.htcSettings.TabStop = False
        '
        'tpGeneral
        '
        Me.tpGeneral.AutoScroll = True
        Me.tpGeneral.BackColor = System.Drawing.Color.White
        Me.tpGeneral.Controls.Add(Me.tlpGeneral)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 40)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(588, 387)
        Me.tpGeneral.TabIndex = 0
        Me.tpGeneral.Text = "tpGeneral"
        '
        'tlpGeneral
        '
        Me.tlpGeneral.AutoSize = True
        Me.tlpGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpGeneral.ColumnCount = 1
        Me.tlpGeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGeneral.Controls.Add(tlpGeneralTitle, 0, 0)
        Me.tlpGeneral.Controls.Add(Me.chkFahrenheit, 0, 12)
        Me.tlpGeneral.Controls.Add(Me.HorizontalLine7, 0, 1)
        Me.tlpGeneral.Controls.Add(Me.lblStartup, 0, 2)
        Me.tlpGeneral.Controls.Add(Me.lblBehaviour, 0, 5)
        Me.tlpGeneral.Controls.Add(Me.lblUpdates, 0, 8)
        Me.tlpGeneral.Controls.Add(Me.lblFahrenheit, 0, 11)
        Me.tlpGeneral.Controls.Add(Me.lblDebug, 0, 14)
        Me.tlpGeneral.Controls.Add(Me.chkDebug, 0, 15)
        Me.tlpGeneral.Controls.Add(Me.tlpBehaviour, 0, 6)
        Me.tlpGeneral.Controls.Add(Me.tlpStartup, 0, 3)
        Me.tlpGeneral.Controls.Add(Me.tlpUpdates, 0, 9)
        Me.tlpGeneral.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpGeneral.Location = New System.Drawing.Point(3, 3)
        Me.tlpGeneral.Name = "tlpGeneral"
        Me.tlpGeneral.RowCount = 17
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGeneral.Size = New System.Drawing.Size(565, 408)
        Me.tlpGeneral.TabIndex = 24
        '
        'chkFahrenheit
        '
        Me.chkFahrenheit.AutoSize = True
        Me.chkFahrenheit.ForeColor = System.Drawing.Color.Black
        Me.chkFahrenheit.Location = New System.Drawing.Point(3, 306)
        Me.chkFahrenheit.Name = "chkFahrenheit"
        Me.chkFahrenheit.Size = New System.Drawing.Size(94, 17)
        Me.chkFahrenheit.TabIndex = 10
        Me.chkFahrenheit.Text = "chkFahrenheit"
        Me.chkFahrenheit.UseVisualStyleBackColor = True
        '
        'HorizontalLine7
        '
        Me.HorizontalLine7.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine7.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine7.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine7.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine7.Name = "HorizontalLine7"
        Me.HorizontalLine7.Size = New System.Drawing.Size(565, 1)
        Me.HorizontalLine7.TabIndex = 8
        Me.HorizontalLine7.TabStop = False
        '
        'lblStartup
        '
        Me.lblStartup.AutoSize = True
        Me.lblStartup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblStartup.Location = New System.Drawing.Point(0, 55)
        Me.lblStartup.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblStartup.Name = "lblStartup"
        Me.lblStartup.Size = New System.Drawing.Size(53, 13)
        Me.lblStartup.TabIndex = 9
        Me.lblStartup.Text = "lblStartup"
        '
        'lblBehaviour
        '
        Me.lblBehaviour.AutoSize = True
        Me.lblBehaviour.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblBehaviour.Location = New System.Drawing.Point(0, 117)
        Me.lblBehaviour.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblBehaviour.Name = "lblBehaviour"
        Me.lblBehaviour.Size = New System.Drawing.Size(65, 13)
        Me.lblBehaviour.TabIndex = 10
        Me.lblBehaviour.Text = "lblBehaviour"
        '
        'lblUpdates
        '
        Me.lblUpdates.AutoSize = True
        Me.lblUpdates.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblUpdates.Location = New System.Drawing.Point(0, 225)
        Me.lblUpdates.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblUpdates.Name = "lblUpdates"
        Me.lblUpdates.Size = New System.Drawing.Size(57, 13)
        Me.lblUpdates.TabIndex = 11
        Me.lblUpdates.Text = "lblUpdates"
        '
        'lblFahrenheit
        '
        Me.lblFahrenheit.AutoSize = True
        Me.lblFahrenheit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblFahrenheit.Location = New System.Drawing.Point(0, 287)
        Me.lblFahrenheit.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblFahrenheit.Name = "lblFahrenheit"
        Me.lblFahrenheit.Size = New System.Drawing.Size(69, 13)
        Me.lblFahrenheit.TabIndex = 12
        Me.lblFahrenheit.Text = "lblFahrenheit"
        '
        'lblDebug
        '
        Me.lblDebug.AutoSize = True
        Me.lblDebug.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDebug.Location = New System.Drawing.Point(0, 349)
        Me.lblDebug.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblDebug.Name = "lblDebug"
        Me.lblDebug.Size = New System.Drawing.Size(48, 13)
        Me.lblDebug.TabIndex = 14
        Me.lblDebug.Text = "lblDebug"
        '
        'chkDebug
        '
        Me.chkDebug.AutoSize = True
        Me.chkDebug.ForeColor = System.Drawing.Color.Black
        Me.chkDebug.Location = New System.Drawing.Point(3, 368)
        Me.chkDebug.Name = "chkDebug"
        Me.chkDebug.Size = New System.Drawing.Size(73, 17)
        Me.chkDebug.TabIndex = 11
        Me.chkDebug.Text = "chkDebug"
        Me.chkDebug.UseVisualStyleBackColor = True
        '
        'tlpBehaviour
        '
        Me.tlpBehaviour.AutoSize = True
        Me.tlpBehaviour.ColumnCount = 2
        Me.tlpBehaviour.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpBehaviour.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpBehaviour.Controls.Add(Me.chkMinimizeInTray, 0, 0)
        Me.tlpBehaviour.Controls.Add(Me.chkCloseOnTray, 0, 1)
        Me.tlpBehaviour.Controls.Add(Me.chkAlwaysShowTray, 0, 2)
        Me.tlpBehaviour.Controls.Add(Me.chkConfirmExit, 1, 0)
        Me.tlpBehaviour.Controls.Add(Me.chkRememberSize, 1, 1)
        Me.tlpBehaviour.Controls.Add(Me.chkInfoPanel, 1, 2)
        Me.tlpBehaviour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpBehaviour.Location = New System.Drawing.Point(0, 133)
        Me.tlpBehaviour.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpBehaviour.Name = "tlpBehaviour"
        Me.tlpBehaviour.RowCount = 3
        Me.tlpBehaviour.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBehaviour.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBehaviour.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBehaviour.Size = New System.Drawing.Size(565, 69)
        Me.tlpBehaviour.TabIndex = 16
        '
        'chkMinimizeInTray
        '
        Me.chkMinimizeInTray.AutoSize = True
        Me.chkMinimizeInTray.ForeColor = System.Drawing.Color.Black
        Me.chkMinimizeInTray.Location = New System.Drawing.Point(3, 3)
        Me.chkMinimizeInTray.Name = "chkMinimizeInTray"
        Me.chkMinimizeInTray.Size = New System.Drawing.Size(113, 17)
        Me.chkMinimizeInTray.TabIndex = 2
        Me.chkMinimizeInTray.Text = "chkMinimizeInTray"
        Me.chkMinimizeInTray.UseVisualStyleBackColor = True
        '
        'chkCloseOnTray
        '
        Me.chkCloseOnTray.AutoSize = True
        Me.chkCloseOnTray.ForeColor = System.Drawing.Color.Black
        Me.chkCloseOnTray.Location = New System.Drawing.Point(3, 26)
        Me.chkCloseOnTray.Name = "chkCloseOnTray"
        Me.chkCloseOnTray.Size = New System.Drawing.Size(104, 17)
        Me.chkCloseOnTray.TabIndex = 3
        Me.chkCloseOnTray.Text = "chkCloseOnTray"
        Me.chkCloseOnTray.UseVisualStyleBackColor = True
        '
        'chkAlwaysShowTray
        '
        Me.chkAlwaysShowTray.AutoSize = True
        Me.chkAlwaysShowTray.ForeColor = System.Drawing.Color.Black
        Me.chkAlwaysShowTray.Location = New System.Drawing.Point(3, 49)
        Me.chkAlwaysShowTray.Name = "chkAlwaysShowTray"
        Me.chkAlwaysShowTray.Size = New System.Drawing.Size(124, 17)
        Me.chkAlwaysShowTray.TabIndex = 4
        Me.chkAlwaysShowTray.Text = "chkAlwaysShowTray"
        Me.chkAlwaysShowTray.UseVisualStyleBackColor = True
        '
        'chkConfirmExit
        '
        Me.chkConfirmExit.AutoSize = True
        Me.chkConfirmExit.ForeColor = System.Drawing.Color.Black
        Me.chkConfirmExit.Location = New System.Drawing.Point(285, 3)
        Me.chkConfirmExit.Name = "chkConfirmExit"
        Me.chkConfirmExit.Size = New System.Drawing.Size(97, 17)
        Me.chkConfirmExit.TabIndex = 5
        Me.chkConfirmExit.Text = "chkConfirmExit"
        Me.chkConfirmExit.UseVisualStyleBackColor = True
        '
        'chkRememberSize
        '
        Me.chkRememberSize.AutoSize = True
        Me.chkRememberSize.ForeColor = System.Drawing.Color.Black
        Me.chkRememberSize.Location = New System.Drawing.Point(285, 26)
        Me.chkRememberSize.Name = "chkRememberSize"
        Me.chkRememberSize.Size = New System.Drawing.Size(112, 17)
        Me.chkRememberSize.TabIndex = 6
        Me.chkRememberSize.Text = "chkRememberSize"
        Me.chkRememberSize.UseVisualStyleBackColor = True
        '
        'chkInfoPanel
        '
        Me.chkInfoPanel.AutoSize = True
        Me.chkInfoPanel.ForeColor = System.Drawing.Color.Black
        Me.chkInfoPanel.Location = New System.Drawing.Point(285, 49)
        Me.chkInfoPanel.Name = "chkInfoPanel"
        Me.chkInfoPanel.Size = New System.Drawing.Size(88, 17)
        Me.chkInfoPanel.TabIndex = 7
        Me.chkInfoPanel.Text = "chkInfoPanel"
        Me.chkInfoPanel.UseVisualStyleBackColor = True
        '
        'tlpStartup
        '
        Me.tlpStartup.AutoSize = True
        Me.tlpStartup.ColumnCount = 2
        Me.tlpStartup.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpStartup.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpStartup.Controls.Add(Me.chkStartupLink, 0, 0)
        Me.tlpStartup.Controls.Add(Me.chkRunMinimized, 1, 0)
        Me.tlpStartup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpStartup.Location = New System.Drawing.Point(0, 71)
        Me.tlpStartup.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpStartup.Name = "tlpStartup"
        Me.tlpStartup.RowCount = 1
        Me.tlpStartup.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpStartup.Size = New System.Drawing.Size(565, 23)
        Me.tlpStartup.TabIndex = 17
        '
        'chkStartupLink
        '
        Me.chkStartupLink.AutoSize = True
        Me.chkStartupLink.ForeColor = System.Drawing.Color.Black
        Me.chkStartupLink.Location = New System.Drawing.Point(3, 3)
        Me.chkStartupLink.Name = "chkStartupLink"
        Me.chkStartupLink.Size = New System.Drawing.Size(96, 17)
        Me.chkStartupLink.TabIndex = 0
        Me.chkStartupLink.Text = "chkStartupLink"
        Me.chkStartupLink.UseVisualStyleBackColor = True
        '
        'chkRunMinimized
        '
        Me.chkRunMinimized.AutoSize = True
        Me.chkRunMinimized.ForeColor = System.Drawing.Color.Black
        Me.chkRunMinimized.Location = New System.Drawing.Point(285, 3)
        Me.chkRunMinimized.Name = "chkRunMinimized"
        Me.chkRunMinimized.Size = New System.Drawing.Size(106, 17)
        Me.chkRunMinimized.TabIndex = 1
        Me.chkRunMinimized.Text = "chkRunMinimized"
        Me.chkRunMinimized.UseVisualStyleBackColor = True
        '
        'tlpUpdates
        '
        Me.tlpUpdates.AutoSize = True
        Me.tlpUpdates.ColumnCount = 2
        Me.tlpUpdates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpUpdates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpUpdates.Controls.Add(Me.chkUpdates, 0, 0)
        Me.tlpUpdates.Controls.Add(Me.chkLanguageUpdates, 1, 0)
        Me.tlpUpdates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpUpdates.Location = New System.Drawing.Point(0, 241)
        Me.tlpUpdates.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpUpdates.Name = "tlpUpdates"
        Me.tlpUpdates.RowCount = 1
        Me.tlpUpdates.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpUpdates.Size = New System.Drawing.Size(565, 23)
        Me.tlpUpdates.TabIndex = 18
        '
        'chkUpdates
        '
        Me.chkUpdates.AutoSize = True
        Me.chkUpdates.ForeColor = System.Drawing.Color.Black
        Me.chkUpdates.Location = New System.Drawing.Point(3, 3)
        Me.chkUpdates.Name = "chkUpdates"
        Me.chkUpdates.Size = New System.Drawing.Size(82, 17)
        Me.chkUpdates.TabIndex = 8
        Me.chkUpdates.Text = "chkUpdates"
        Me.chkUpdates.UseVisualStyleBackColor = True
        '
        'chkLanguageUpdates
        '
        Me.chkLanguageUpdates.AutoSize = True
        Me.chkLanguageUpdates.ForeColor = System.Drawing.Color.Black
        Me.chkLanguageUpdates.Location = New System.Drawing.Point(285, 3)
        Me.chkLanguageUpdates.Name = "chkLanguageUpdates"
        Me.chkLanguageUpdates.Size = New System.Drawing.Size(129, 17)
        Me.chkLanguageUpdates.TabIndex = 9
        Me.chkLanguageUpdates.Text = "chkLanguageUpdates"
        Me.chkLanguageUpdates.UseVisualStyleBackColor = True
        '
        'tpDetection
        '
        Me.tpDetection.BackColor = System.Drawing.Color.White
        Me.tpDetection.Controls.Add(Me.tlpDetectionContent)
        Me.tpDetection.Location = New System.Drawing.Point(4, 40)
        Me.tpDetection.Name = "tpDetection"
        Me.tpDetection.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDetection.Size = New System.Drawing.Size(588, 387)
        Me.tpDetection.TabIndex = 1
        Me.tpDetection.Text = "tpDetection"
        '
        'tlpDetectionContent
        '
        Me.tlpDetectionContent.AutoSize = True
        Me.tlpDetectionContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDetectionContent.ColumnCount = 1
        Me.tlpDetectionContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDetectionContent.Controls.Add(Me.HorizontalLine1, 0, 1)
        Me.tlpDetectionContent.Controls.Add(tlpDetectionTitle, 0, 0)
        Me.tlpDetectionContent.Controls.Add(Me.chkMonitorUsb, 0, 2)
        Me.tlpDetectionContent.Controls.Add(Me.chkCsmi, 0, 3)
        Me.tlpDetectionContent.Controls.Add(Me.tlpNeedRestart, 0, 4)
        Me.tlpDetectionContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpDetectionContent.Location = New System.Drawing.Point(3, 3)
        Me.tlpDetectionContent.Name = "tlpDetectionContent"
        Me.tlpDetectionContent.RowCount = 5
        Me.tlpDetectionContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDetectionContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDetectionContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDetectionContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDetectionContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDetectionContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpDetectionContent.Size = New System.Drawing.Size(582, 115)
        Me.tlpDetectionContent.TabIndex = 24
        '
        'HorizontalLine1
        '
        Me.HorizontalLine1.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine1.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine1.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine1.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine1.Name = "HorizontalLine1"
        Me.HorizontalLine1.Size = New System.Drawing.Size(582, 1)
        Me.HorizontalLine1.TabIndex = 24
        Me.HorizontalLine1.TabStop = False
        '
        'chkMonitorUsb
        '
        Me.chkMonitorUsb.AutoSize = True
        Me.chkMonitorUsb.ForeColor = System.Drawing.Color.Black
        Me.chkMonitorUsb.Location = New System.Drawing.Point(3, 55)
        Me.chkMonitorUsb.Name = "chkMonitorUsb"
        Me.chkMonitorUsb.Size = New System.Drawing.Size(96, 17)
        Me.chkMonitorUsb.TabIndex = 1
        Me.chkMonitorUsb.Text = "chkMonitorUsb"
        Me.chkMonitorUsb.UseVisualStyleBackColor = True
        '
        'chkCsmi
        '
        Me.chkCsmi.AutoSize = True
        Me.chkCsmi.ForeColor = System.Drawing.Color.Black
        Me.chkCsmi.Location = New System.Drawing.Point(3, 78)
        Me.chkCsmi.Name = "chkCsmi"
        Me.chkCsmi.Size = New System.Drawing.Size(64, 17)
        Me.chkCsmi.TabIndex = 2
        Me.chkCsmi.Text = "chkCsmi"
        Me.chkCsmi.UseVisualStyleBackColor = True
        '
        'tlpNeedRestart
        '
        Me.tlpNeedRestart.AutoSize = True
        Me.tlpNeedRestart.ColumnCount = 2
        Me.tlpNeedRestart.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNeedRestart.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNeedRestart.Controls.Add(Me.picNeedRestart, 0, 0)
        Me.tlpNeedRestart.Controls.Add(Me.lblNeedRestart, 1, 0)
        Me.tlpNeedRestart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpNeedRestart.Location = New System.Drawing.Point(19, 99)
        Me.tlpNeedRestart.Margin = New System.Windows.Forms.Padding(19, 1, 0, 0)
        Me.tlpNeedRestart.Name = "tlpNeedRestart"
        Me.tlpNeedRestart.RowCount = 1
        Me.tlpNeedRestart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpNeedRestart.Size = New System.Drawing.Size(563, 16)
        Me.tlpNeedRestart.TabIndex = 26
        '
        'picNeedRestart
        '
        Me.picNeedRestart.Location = New System.Drawing.Point(0, 0)
        Me.picNeedRestart.Margin = New System.Windows.Forms.Padding(0)
        Me.picNeedRestart.Name = "picNeedRestart"
        Me.picNeedRestart.Size = New System.Drawing.Size(16, 16)
        Me.picNeedRestart.TabIndex = 0
        Me.picNeedRestart.TabStop = False
        '
        'lblNeedRestart
        '
        Me.lblNeedRestart.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblNeedRestart.AutoSize = True
        Me.lblNeedRestart.ForeColor = System.Drawing.Color.DimGray
        Me.lblNeedRestart.Location = New System.Drawing.Point(19, 1)
        Me.lblNeedRestart.Name = "lblNeedRestart"
        Me.lblNeedRestart.Size = New System.Drawing.Size(78, 13)
        Me.lblNeedRestart.TabIndex = 1
        Me.lblNeedRestart.Text = "lblNeedRestart"
        '
        'tpTranslation
        '
        Me.tpTranslation.BackColor = System.Drawing.Color.White
        Me.tpTranslation.Controls.Add(Me.tlpMessagesContent)
        Me.tpTranslation.Location = New System.Drawing.Point(4, 40)
        Me.tpTranslation.Name = "tpTranslation"
        Me.tpTranslation.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTranslation.Size = New System.Drawing.Size(588, 387)
        Me.tpTranslation.TabIndex = 2
        Me.tpTranslation.Text = "tpTranslation"
        '
        'tlpMessagesContent
        '
        Me.tlpMessagesContent.AutoSize = True
        Me.tlpMessagesContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMessagesContent.ColumnCount = 1
        Me.tlpMessagesContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMessagesContent.Controls.Add(tlpMessagesTitle, 0, 0)
        Me.tlpMessagesContent.Controls.Add(Me.HorizontalLine2, 0, 1)
        Me.tlpMessagesContent.Controls.Add(Me.optAutomatic, 0, 2)
        Me.tlpMessagesContent.Controls.Add(Me.optCustom, 0, 3)
        Me.tlpMessagesContent.Controls.Add(Me.lblLanguageInfo, 0, 5)
        Me.tlpMessagesContent.Controls.Add(Me.cboLanguage, 0, 4)
        Me.tlpMessagesContent.Controls.Add(Me.tlpLanguageInfo, 0, 6)
        Me.tlpMessagesContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMessagesContent.Location = New System.Drawing.Point(3, 3)
        Me.tlpMessagesContent.Name = "tlpMessagesContent"
        Me.tlpMessagesContent.RowCount = 7
        Me.tlpMessagesContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMessagesContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMessagesContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMessagesContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMessagesContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMessagesContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMessagesContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMessagesContent.Size = New System.Drawing.Size(582, 381)
        Me.tlpMessagesContent.TabIndex = 24
        '
        'HorizontalLine2
        '
        Me.HorizontalLine2.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine2.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine2.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine2.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine2.Name = "HorizontalLine2"
        Me.HorizontalLine2.Size = New System.Drawing.Size(582, 1)
        Me.HorizontalLine2.TabIndex = 24
        Me.HorizontalLine2.TabStop = False
        '
        'optAutomatic
        '
        Me.optAutomatic.AutoSize = True
        Me.optAutomatic.ForeColor = System.Drawing.Color.Black
        Me.optAutomatic.Location = New System.Drawing.Point(3, 55)
        Me.optAutomatic.Name = "optAutomatic"
        Me.optAutomatic.Size = New System.Drawing.Size(89, 17)
        Me.optAutomatic.TabIndex = 0
        Me.optAutomatic.TabStop = True
        Me.optAutomatic.Text = "optAutomatic"
        Me.optAutomatic.UseVisualStyleBackColor = True
        '
        'optCustom
        '
        Me.optCustom.AutoSize = True
        Me.optCustom.ForeColor = System.Drawing.Color.Black
        Me.optCustom.Location = New System.Drawing.Point(3, 78)
        Me.optCustom.Name = "optCustom"
        Me.optCustom.Size = New System.Drawing.Size(77, 17)
        Me.optCustom.TabIndex = 1
        Me.optCustom.TabStop = True
        Me.optCustom.Text = "optCustom"
        Me.optCustom.UseVisualStyleBackColor = True
        '
        'lblLanguageInfo
        '
        Me.lblLanguageInfo.AutoSize = True
        Me.lblLanguageInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblLanguageInfo.Location = New System.Drawing.Point(3, 139)
        Me.lblLanguageInfo.Margin = New System.Windows.Forms.Padding(3, 20, 3, 3)
        Me.lblLanguageInfo.Name = "lblLanguageInfo"
        Me.lblLanguageInfo.Size = New System.Drawing.Size(84, 13)
        Me.lblLanguageInfo.TabIndex = 4
        Me.lblLanguageInfo.Text = "lblLanguageInfo"
        '
        'cboLanguage
        '
        Me.cboLanguage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLanguage.FormattingEnabled = True
        Me.cboLanguage.Location = New System.Drawing.Point(20, 98)
        Me.cboLanguage.Margin = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.cboLanguage.Name = "cboLanguage"
        Me.cboLanguage.Size = New System.Drawing.Size(562, 21)
        Me.cboLanguage.TabIndex = 2
        '
        'tlpLanguageInfo
        '
        Me.tlpLanguageInfo.AutoSize = True
        Me.tlpLanguageInfo.ColumnCount = 2
        Me.tlpLanguageInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLanguageInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLanguageInfo.Controls.Add(Me.lblVersion, 0, 0)
        Me.tlpLanguageInfo.Controls.Add(Me.lblTranslator, 0, 1)
        Me.tlpLanguageInfo.Controls.Add(Me.lblVersionValue, 1, 0)
        Me.tlpLanguageInfo.Controls.Add(Me.lblTranslatorValue, 1, 1)
        Me.tlpLanguageInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpLanguageInfo.Location = New System.Drawing.Point(3, 155)
        Me.tlpLanguageInfo.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.tlpLanguageInfo.Name = "tlpLanguageInfo"
        Me.tlpLanguageInfo.RowCount = 2
        Me.tlpLanguageInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLanguageInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLanguageInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpLanguageInfo.Size = New System.Drawing.Size(576, 38)
        Me.tlpLanguageInfo.TabIndex = 28
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(0, 3)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(52, 13)
        Me.lblVersion.TabIndex = 0
        Me.lblVersion.Text = "lblVersion"
        '
        'lblTranslator
        '
        Me.lblTranslator.AutoSize = True
        Me.lblTranslator.ForeColor = System.Drawing.Color.Black
        Me.lblTranslator.Location = New System.Drawing.Point(0, 22)
        Me.lblTranslator.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblTranslator.Name = "lblTranslator"
        Me.lblTranslator.Size = New System.Drawing.Size(66, 13)
        Me.lblTranslator.TabIndex = 1
        Me.lblTranslator.Text = "lblTranslator"
        '
        'lblVersionValue
        '
        Me.lblVersionValue.AutoSize = True
        Me.lblVersionValue.ForeColor = System.Drawing.Color.Black
        Me.lblVersionValue.Location = New System.Drawing.Point(69, 3)
        Me.lblVersionValue.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblVersionValue.Name = "lblVersionValue"
        Me.lblVersionValue.Size = New System.Drawing.Size(78, 13)
        Me.lblVersionValue.TabIndex = 2
        Me.lblVersionValue.Text = "lblVersionValue"
        '
        'lblTranslatorValue
        '
        Me.lblTranslatorValue.AutoSize = True
        Me.lblTranslatorValue.ForeColor = System.Drawing.Color.Black
        Me.lblTranslatorValue.Location = New System.Drawing.Point(69, 22)
        Me.lblTranslatorValue.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblTranslatorValue.Name = "lblTranslatorValue"
        Me.lblTranslatorValue.Size = New System.Drawing.Size(92, 13)
        Me.lblTranslatorValue.TabIndex = 3
        Me.lblTranslatorValue.Text = "lblTranslatorValue"
        '
        'tpMailAlerts
        '
        Me.tpMailAlerts.AutoScroll = True
        Me.tpMailAlerts.BackColor = System.Drawing.Color.White
        Me.tpMailAlerts.Controls.Add(Me.tlpMailAlertsContent)
        Me.tpMailAlerts.Location = New System.Drawing.Point(4, 40)
        Me.tpMailAlerts.Name = "tpMailAlerts"
        Me.tpMailAlerts.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMailAlerts.Size = New System.Drawing.Size(588, 387)
        Me.tpMailAlerts.TabIndex = 3
        Me.tpMailAlerts.Text = "tpMailAlerts"
        '
        'tlpMailAlertsContent
        '
        Me.tlpMailAlertsContent.AutoSize = True
        Me.tlpMailAlertsContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMailAlertsContent.ColumnCount = 1
        Me.tlpMailAlertsContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMailAlertsContent.Controls.Add(Me.tlpWhenSendMail, 0, 7)
        Me.tlpMailAlertsContent.Controls.Add(Me.HorizontalLine3, 0, 1)
        Me.tlpMailAlertsContent.Controls.Add(Me.tlpMail, 0, 6)
        Me.tlpMailAlertsContent.Controls.Add(tlpMailAlertsTitle, 0, 0)
        Me.tlpMailAlertsContent.Controls.Add(Me.chkMailAlerts, 0, 2)
        Me.tlpMailAlertsContent.Controls.Add(Me.lblSetMailServer, 0, 3)
        Me.tlpMailAlertsContent.Controls.Add(Me.tlpCustomServer, 0, 4)
        Me.tlpMailAlertsContent.Controls.Add(Me.lblMailDestination, 0, 5)
        Me.tlpMailAlertsContent.Controls.Add(Me.tlpReport, 0, 8)
        Me.tlpMailAlertsContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpMailAlertsContent.Location = New System.Drawing.Point(3, 3)
        Me.tlpMailAlertsContent.Name = "tlpMailAlertsContent"
        Me.tlpMailAlertsContent.RowCount = 9
        Me.tlpMailAlertsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMailAlertsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMailAlertsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMailAlertsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMailAlertsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMailAlertsContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMailAlertsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMailAlertsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMailAlertsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMailAlertsContent.Size = New System.Drawing.Size(565, 430)
        Me.tlpMailAlertsContent.TabIndex = 24
        '
        'tlpWhenSendMail
        '
        Me.tlpWhenSendMail.AutoSize = True
        Me.tlpWhenSendMail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpWhenSendMail.ColumnCount = 1
        Me.tlpWhenSendMail.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpWhenSendMail.Controls.Add(Me.lblSendMailWhen, 0, 0)
        Me.tlpWhenSendMail.Controls.Add(Me.chkMailDeviceFail, 0, 1)
        Me.tlpWhenSendMail.Controls.Add(Me.chkMailExcessiveTemp, 0, 2)
        Me.tlpWhenSendMail.Controls.Add(Me.chkMailReliabilityDown, 0, 3)
        Me.tlpWhenSendMail.Location = New System.Drawing.Point(17, 287)
        Me.tlpWhenSendMail.Margin = New System.Windows.Forms.Padding(17, 3, 3, 3)
        Me.tlpWhenSendMail.Name = "tlpWhenSendMail"
        Me.tlpWhenSendMail.RowCount = 4
        Me.tlpWhenSendMail.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWhenSendMail.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWhenSendMail.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWhenSendMail.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWhenSendMail.Size = New System.Drawing.Size(142, 88)
        Me.tlpWhenSendMail.TabIndex = 25
        '
        'lblSendMailWhen
        '
        Me.lblSendMailWhen.AutoSize = True
        Me.lblSendMailWhen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSendMailWhen.Location = New System.Drawing.Point(3, 3)
        Me.lblSendMailWhen.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSendMailWhen.Name = "lblSendMailWhen"
        Me.lblSendMailWhen.Size = New System.Drawing.Size(87, 13)
        Me.lblSendMailWhen.TabIndex = 0
        Me.lblSendMailWhen.Text = "lblSendMailWhen"
        '
        'chkMailDeviceFail
        '
        Me.chkMailDeviceFail.AutoSize = True
        Me.chkMailDeviceFail.ForeColor = System.Drawing.Color.Black
        Me.chkMailDeviceFail.Location = New System.Drawing.Point(6, 22)
        Me.chkMailDeviceFail.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.chkMailDeviceFail.Name = "chkMailDeviceFail"
        Me.chkMailDeviceFail.Size = New System.Drawing.Size(108, 17)
        Me.chkMailDeviceFail.TabIndex = 9
        Me.chkMailDeviceFail.Text = "chkMailDeviceFail"
        Me.chkMailDeviceFail.UseVisualStyleBackColor = True
        '
        'chkMailExcessiveTemp
        '
        Me.chkMailExcessiveTemp.AutoSize = True
        Me.chkMailExcessiveTemp.ForeColor = System.Drawing.Color.Black
        Me.chkMailExcessiveTemp.Location = New System.Drawing.Point(6, 45)
        Me.chkMailExcessiveTemp.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.chkMailExcessiveTemp.Name = "chkMailExcessiveTemp"
        Me.chkMailExcessiveTemp.Size = New System.Drawing.Size(133, 17)
        Me.chkMailExcessiveTemp.TabIndex = 10
        Me.chkMailExcessiveTemp.Text = "chkMailExcessiveTemp"
        Me.chkMailExcessiveTemp.UseVisualStyleBackColor = True
        '
        'chkMailReliabilityDown
        '
        Me.chkMailReliabilityDown.AutoSize = True
        Me.chkMailReliabilityDown.ForeColor = System.Drawing.Color.Black
        Me.chkMailReliabilityDown.Location = New System.Drawing.Point(6, 68)
        Me.chkMailReliabilityDown.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.chkMailReliabilityDown.Name = "chkMailReliabilityDown"
        Me.chkMailReliabilityDown.Size = New System.Drawing.Size(132, 17)
        Me.chkMailReliabilityDown.TabIndex = 11
        Me.chkMailReliabilityDown.Text = "chkMailReliabilityDown"
        Me.chkMailReliabilityDown.UseVisualStyleBackColor = True
        Me.chkMailReliabilityDown.Visible = False
        '
        'HorizontalLine3
        '
        Me.HorizontalLine3.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine3.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine3.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine3.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine3.Name = "HorizontalLine3"
        Me.HorizontalLine3.Size = New System.Drawing.Size(565, 1)
        Me.HorizontalLine3.TabIndex = 24
        Me.HorizontalLine3.TabStop = False
        '
        'tlpMail
        '
        Me.tlpMail.AutoSize = True
        Me.tlpMail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMail.ColumnCount = 2
        Me.tlpMail.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMail.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMail.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMail.Controls.Add(Me.txtMail, 0, 0)
        Me.tlpMail.Controls.Add(Me.lnkTestMail, 1, 0)
        Me.tlpMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMail.Location = New System.Drawing.Point(17, 254)
        Me.tlpMail.Margin = New System.Windows.Forms.Padding(17, 3, 3, 3)
        Me.tlpMail.Name = "tlpMail"
        Me.tlpMail.RowCount = 1
        Me.tlpMail.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMail.Size = New System.Drawing.Size(545, 27)
        Me.tlpMail.TabIndex = 23
        '
        'txtMail
        '
        Me.txtMail.BackColor = System.Drawing.Color.White
        Me.txtMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMail.ForeColor = System.Drawing.Color.Black
        Me.txtMail.Location = New System.Drawing.Point(6, 3)
        Me.txtMail.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.txtMail.Name = "txtMail"
        Me.txtMail.Size = New System.Drawing.Size(471, 21)
        Me.txtMail.TabIndex = 7
        '
        'lnkTestMail
        '
        Me.lnkTestMail.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkTestMail.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lnkTestMail.AutoSize = True
        Me.lnkTestMail.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkTestMail.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkTestMail.Location = New System.Drawing.Point(483, 7)
        Me.lnkTestMail.Name = "lnkTestMail"
        Me.lnkTestMail.Size = New System.Drawing.Size(59, 13)
        Me.lnkTestMail.TabIndex = 8
        Me.lnkTestMail.TabStop = True
        Me.lnkTestMail.Text = "lnkTestMail"
        '
        'chkMailAlerts
        '
        Me.chkMailAlerts.AutoSize = True
        Me.chkMailAlerts.ForeColor = System.Drawing.Color.Black
        Me.chkMailAlerts.Location = New System.Drawing.Point(3, 55)
        Me.chkMailAlerts.Name = "chkMailAlerts"
        Me.chkMailAlerts.Size = New System.Drawing.Size(88, 17)
        Me.chkMailAlerts.TabIndex = 1
        Me.chkMailAlerts.Text = "chkMailAlerts"
        Me.chkMailAlerts.UseVisualStyleBackColor = True
        '
        'lblSetMailServer
        '
        Me.lblSetMailServer.AutoSize = True
        Me.lblSetMailServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSetMailServer.Location = New System.Drawing.Point(20, 78)
        Me.lblSetMailServer.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.lblSetMailServer.Name = "lblSetMailServer"
        Me.lblSetMailServer.Size = New System.Drawing.Size(83, 13)
        Me.lblSetMailServer.TabIndex = 28
        Me.lblSetMailServer.Text = "lblSetMailServer"
        '
        'tlpCustomServer
        '
        Me.tlpCustomServer.AutoSize = True
        Me.tlpCustomServer.ColumnCount = 3
        Me.tlpCustomServer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCustomServer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCustomServer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCustomServer.Controls.Add(Me.txtPort, 1, 3)
        Me.tlpCustomServer.Controls.Add(Me.txtSmtp, 1, 2)
        Me.tlpCustomServer.Controls.Add(Me.chkSsl, 1, 4)
        Me.tlpCustomServer.Controls.Add(Me.lblSmtp, 0, 2)
        Me.tlpCustomServer.Controls.Add(Me.lblCustomMail, 0, 0)
        Me.tlpCustomServer.Controls.Add(Me.lblPassword, 0, 1)
        Me.tlpCustomServer.Controls.Add(Me.txtCustomMail, 1, 0)
        Me.tlpCustomServer.Controls.Add(Me.txtPassword, 1, 1)
        Me.tlpCustomServer.Controls.Add(Me.lblPort, 0, 3)
        Me.tlpCustomServer.Location = New System.Drawing.Point(17, 97)
        Me.tlpCustomServer.Margin = New System.Windows.Forms.Padding(17, 3, 3, 3)
        Me.tlpCustomServer.Name = "tlpCustomServer"
        Me.tlpCustomServer.RowCount = 5
        Me.tlpCustomServer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCustomServer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCustomServer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCustomServer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCustomServer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCustomServer.Size = New System.Drawing.Size(545, 131)
        Me.tlpCustomServer.TabIndex = 27
        '
        'txtPort
        '
        Me.txtPort.BackColor = System.Drawing.Color.White
        Me.txtPort.ForeColor = System.Drawing.Color.Black
        Me.txtPort.Location = New System.Drawing.Point(80, 84)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(228, 21)
        Me.txtPort.TabIndex = 5
        '
        'txtSmtp
        '
        Me.txtSmtp.BackColor = System.Drawing.Color.White
        Me.txtSmtp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSmtp.ForeColor = System.Drawing.Color.Black
        Me.txtSmtp.Location = New System.Drawing.Point(80, 57)
        Me.txtSmtp.Name = "txtSmtp"
        Me.txtSmtp.Size = New System.Drawing.Size(228, 21)
        Me.txtSmtp.TabIndex = 4
        '
        'chkSsl
        '
        Me.chkSsl.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkSsl.AutoSize = True
        Me.chkSsl.ForeColor = System.Drawing.Color.Black
        Me.chkSsl.Location = New System.Drawing.Point(80, 111)
        Me.chkSsl.Name = "chkSsl"
        Me.chkSsl.Size = New System.Drawing.Size(55, 17)
        Me.chkSsl.TabIndex = 6
        Me.chkSsl.Text = "chkSsl"
        Me.chkSsl.UseVisualStyleBackColor = True
        '
        'lblSmtp
        '
        Me.lblSmtp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSmtp.AutoSize = True
        Me.lblSmtp.ForeColor = System.Drawing.Color.Black
        Me.lblSmtp.Location = New System.Drawing.Point(3, 61)
        Me.lblSmtp.Name = "lblSmtp"
        Me.lblSmtp.Size = New System.Drawing.Size(41, 13)
        Me.lblSmtp.TabIndex = 6
        Me.lblSmtp.Text = "lblSmtp"
        '
        'lblCustomMail
        '
        Me.lblCustomMail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCustomMail.AutoSize = True
        Me.lblCustomMail.ForeColor = System.Drawing.Color.Black
        Me.lblCustomMail.Location = New System.Drawing.Point(3, 7)
        Me.lblCustomMail.Name = "lblCustomMail"
        Me.lblCustomMail.Size = New System.Drawing.Size(71, 13)
        Me.lblCustomMail.TabIndex = 0
        Me.lblCustomMail.Text = "lblCustomMail"
        '
        'lblPassword
        '
        Me.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPassword.AutoSize = True
        Me.lblPassword.ForeColor = System.Drawing.Color.Black
        Me.lblPassword.Location = New System.Drawing.Point(3, 34)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(63, 13)
        Me.lblPassword.TabIndex = 1
        Me.lblPassword.Text = "lblPassword"
        '
        'txtCustomMail
        '
        Me.txtCustomMail.BackColor = System.Drawing.Color.White
        Me.txtCustomMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCustomMail.ForeColor = System.Drawing.Color.Black
        Me.txtCustomMail.Location = New System.Drawing.Point(80, 3)
        Me.txtCustomMail.Name = "txtCustomMail"
        Me.txtCustomMail.Size = New System.Drawing.Size(228, 21)
        Me.txtCustomMail.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.Location = New System.Drawing.Point(80, 30)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(228, 21)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'lblPort
        '
        Me.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPort.AutoSize = True
        Me.lblPort.ForeColor = System.Drawing.Color.Black
        Me.lblPort.Location = New System.Drawing.Point(3, 88)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(37, 13)
        Me.lblPort.TabIndex = 4
        Me.lblPort.Text = "lblPort"
        '
        'lblMailDestination
        '
        Me.lblMailDestination.AutoSize = True
        Me.lblMailDestination.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblMailDestination.Location = New System.Drawing.Point(20, 234)
        Me.lblMailDestination.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.lblMailDestination.Name = "lblMailDestination"
        Me.lblMailDestination.Size = New System.Drawing.Size(89, 13)
        Me.lblMailDestination.TabIndex = 29
        Me.lblMailDestination.Text = "lblMailDestination"
        '
        'tlpReport
        '
        Me.tlpReport.AutoSize = True
        Me.tlpReport.ColumnCount = 3
        Me.tlpReport.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpReport.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpReport.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpReport.Controls.Add(Me.lblReport, 0, 0)
        Me.tlpReport.Controls.Add(Me.chkReport, 0, 1)
        Me.tlpReport.Controls.Add(Me.cboDays, 1, 1)
        Me.tlpReport.Controls.Add(Me.nlSendReport, 2, 1)
        Me.tlpReport.Location = New System.Drawing.Point(17, 381)
        Me.tlpReport.Margin = New System.Windows.Forms.Padding(17, 3, 3, 3)
        Me.tlpReport.Name = "tlpReport"
        Me.tlpReport.RowCount = 2
        Me.tlpReport.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpReport.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpReport.Size = New System.Drawing.Size(283, 46)
        Me.tlpReport.TabIndex = 30
        '
        'lblReport
        '
        Me.lblReport.AutoSize = True
        Me.lblReport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblReport.Location = New System.Drawing.Point(3, 3)
        Me.lblReport.Margin = New System.Windows.Forms.Padding(3)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(50, 13)
        Me.lblReport.TabIndex = 0
        Me.lblReport.Text = "lblReport"
        '
        'chkReport
        '
        Me.chkReport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkReport.AutoSize = True
        Me.chkReport.ForeColor = System.Drawing.Color.Black
        Me.chkReport.Location = New System.Drawing.Point(6, 24)
        Me.chkReport.Margin = New System.Windows.Forms.Padding(6, 3, 0, 3)
        Me.chkReport.Name = "chkReport"
        Me.chkReport.Size = New System.Drawing.Size(75, 17)
        Me.chkReport.TabIndex = 12
        Me.chkReport.Text = "chkReport"
        Me.chkReport.UseVisualStyleBackColor = True
        '
        'cboDays
        '
        Me.cboDays.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDays.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDays.FormattingEnabled = True
        Me.cboDays.Location = New System.Drawing.Point(81, 22)
        Me.cboDays.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.cboDays.Name = "cboDays"
        Me.cboDays.Size = New System.Drawing.Size(121, 21)
        Me.cboDays.TabIndex = 13
        '
        'nlSendReport
        '
        Me.nlSendReport.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.nlSendReport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.nlSendReport.AutoSize = True
        Me.nlSendReport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.nlSendReport.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.nlSendReport.Location = New System.Drawing.Point(208, 26)
        Me.nlSendReport.Name = "nlSendReport"
        Me.nlSendReport.Size = New System.Drawing.Size(72, 13)
        Me.nlSendReport.TabIndex = 14
        Me.nlSendReport.TabStop = True
        Me.nlSendReport.Text = "nlSendReport"
        '
        'tpUpdate
        '
        Me.tpUpdate.BackColor = System.Drawing.Color.White
        Me.tpUpdate.Controls.Add(Me.tlpUpdateContent)
        Me.tpUpdate.Location = New System.Drawing.Point(4, 40)
        Me.tpUpdate.Name = "tpUpdate"
        Me.tpUpdate.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUpdate.Size = New System.Drawing.Size(588, 387)
        Me.tpUpdate.TabIndex = 4
        Me.tpUpdate.Text = "tpUpdate"
        '
        'tlpUpdateContent
        '
        Me.tlpUpdateContent.AutoSize = True
        Me.tlpUpdateContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpUpdateContent.ColumnCount = 1
        Me.tlpUpdateContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpUpdateContent.Controls.Add(Me.tlpUpdate, 0, 3)
        Me.tlpUpdateContent.Controls.Add(tlpUpdateTitle, 0, 0)
        Me.tlpUpdateContent.Controls.Add(Me.lblUpdate, 0, 2)
        Me.tlpUpdateContent.Controls.Add(Me.HorizontalLine4, 0, 1)
        Me.tlpUpdateContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpUpdateContent.Location = New System.Drawing.Point(3, 3)
        Me.tlpUpdateContent.Name = "tlpUpdateContent"
        Me.tlpUpdateContent.RowCount = 4
        Me.tlpUpdateContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpUpdateContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpUpdateContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpUpdateContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpUpdateContent.Size = New System.Drawing.Size(582, 158)
        Me.tlpUpdateContent.TabIndex = 24
        '
        'tlpUpdate
        '
        Me.tlpUpdate.AutoSize = True
        Me.tlpUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpUpdate.ColumnCount = 3
        Me.tlpUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpUpdate.Controls.Add(Me.lblVirtual, 0, 2)
        Me.tlpUpdate.Controls.Add(Me.numUpdateVirtual, 1, 2)
        Me.tlpUpdate.Controls.Add(Me.lblMinutesVirt, 2, 2)
        Me.tlpUpdate.Controls.Add(Me.lblExternal, 0, 1)
        Me.tlpUpdate.Controls.Add(Me.numUpdateExt, 1, 1)
        Me.tlpUpdate.Controls.Add(Me.lblMinutesExt, 2, 1)
        Me.tlpUpdate.Controls.Add(Me.lblMinutes, 2, 0)
        Me.tlpUpdate.Controls.Add(Me.numUpdate, 1, 0)
        Me.tlpUpdate.Controls.Add(Me.lblInternal, 0, 0)
        Me.tlpUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpUpdate.Location = New System.Drawing.Point(3, 74)
        Me.tlpUpdate.Name = "tlpUpdate"
        Me.tlpUpdate.RowCount = 3
        Me.tlpUpdate.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpUpdate.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpUpdate.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpUpdate.Size = New System.Drawing.Size(576, 81)
        Me.tlpUpdate.TabIndex = 1
        '
        'lblVirtual
        '
        Me.lblVirtual.AutoSize = True
        Me.lblVirtual.ForeColor = System.Drawing.Color.Black
        Me.lblVirtual.Location = New System.Drawing.Point(0, 55)
        Me.lblVirtual.Margin = New System.Windows.Forms.Padding(0, 1, 3, 3)
        Me.lblVirtual.MinimumSize = New System.Drawing.Size(0, 21)
        Me.lblVirtual.Name = "lblVirtual"
        Me.lblVirtual.Size = New System.Drawing.Size(47, 21)
        Me.lblVirtual.TabIndex = 9
        Me.lblVirtual.Text = "lblVirtual"
        Me.lblVirtual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numUpdateVirtual
        '
        Me.numUpdateVirtual.BackColor = System.Drawing.Color.White
        Me.numUpdateVirtual.ForeColor = System.Drawing.Color.Black
        Me.numUpdateVirtual.Location = New System.Drawing.Point(63, 57)
        Me.numUpdateVirtual.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.numUpdateVirtual.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numUpdateVirtual.Name = "numUpdateVirtual"
        Me.numUpdateVirtual.ReadOnly = True
        Me.numUpdateVirtual.Size = New System.Drawing.Size(40, 21)
        Me.numUpdateVirtual.TabIndex = 2
        Me.numUpdateVirtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numUpdateVirtual.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblMinutesVirt
        '
        Me.lblMinutesVirt.AutoSize = True
        Me.lblMinutesVirt.ForeColor = System.Drawing.Color.Black
        Me.lblMinutesVirt.Location = New System.Drawing.Point(109, 55)
        Me.lblMinutesVirt.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.lblMinutesVirt.MinimumSize = New System.Drawing.Size(0, 21)
        Me.lblMinutesVirt.Name = "lblMinutesVirt"
        Me.lblMinutesVirt.Size = New System.Drawing.Size(70, 21)
        Me.lblMinutesVirt.TabIndex = 10
        Me.lblMinutesVirt.Text = "lblMinutesVirt"
        Me.lblMinutesVirt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblExternal
        '
        Me.lblExternal.AutoSize = True
        Me.lblExternal.ForeColor = System.Drawing.Color.Black
        Me.lblExternal.Location = New System.Drawing.Point(0, 28)
        Me.lblExternal.Margin = New System.Windows.Forms.Padding(0, 1, 3, 3)
        Me.lblExternal.MinimumSize = New System.Drawing.Size(0, 21)
        Me.lblExternal.Name = "lblExternal"
        Me.lblExternal.Size = New System.Drawing.Size(57, 21)
        Me.lblExternal.TabIndex = 6
        Me.lblExternal.Text = "lblExternal"
        Me.lblExternal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numUpdateExt
        '
        Me.numUpdateExt.BackColor = System.Drawing.Color.White
        Me.numUpdateExt.ForeColor = System.Drawing.Color.Black
        Me.numUpdateExt.Location = New System.Drawing.Point(63, 30)
        Me.numUpdateExt.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.numUpdateExt.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numUpdateExt.Name = "numUpdateExt"
        Me.numUpdateExt.ReadOnly = True
        Me.numUpdateExt.Size = New System.Drawing.Size(40, 21)
        Me.numUpdateExt.TabIndex = 1
        Me.numUpdateExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numUpdateExt.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblMinutesExt
        '
        Me.lblMinutesExt.AutoSize = True
        Me.lblMinutesExt.ForeColor = System.Drawing.Color.Black
        Me.lblMinutesExt.Location = New System.Drawing.Point(109, 28)
        Me.lblMinutesExt.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.lblMinutesExt.MinimumSize = New System.Drawing.Size(0, 21)
        Me.lblMinutesExt.Name = "lblMinutesExt"
        Me.lblMinutesExt.Size = New System.Drawing.Size(70, 21)
        Me.lblMinutesExt.TabIndex = 7
        Me.lblMinutesExt.Text = "lblMinutesExt"
        Me.lblMinutesExt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMinutes
        '
        Me.lblMinutes.AutoSize = True
        Me.lblMinutes.ForeColor = System.Drawing.Color.Black
        Me.lblMinutes.Location = New System.Drawing.Point(109, 1)
        Me.lblMinutes.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.lblMinutes.MinimumSize = New System.Drawing.Size(0, 21)
        Me.lblMinutes.Name = "lblMinutes"
        Me.lblMinutes.Size = New System.Drawing.Size(54, 21)
        Me.lblMinutes.TabIndex = 3
        Me.lblMinutes.Text = "lblMinutes"
        Me.lblMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numUpdate
        '
        Me.numUpdate.BackColor = System.Drawing.Color.White
        Me.numUpdate.ForeColor = System.Drawing.Color.Black
        Me.numUpdate.Location = New System.Drawing.Point(63, 3)
        Me.numUpdate.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.numUpdate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numUpdate.Name = "numUpdate"
        Me.numUpdate.ReadOnly = True
        Me.numUpdate.Size = New System.Drawing.Size(40, 21)
        Me.numUpdate.TabIndex = 0
        Me.numUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numUpdate.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblInternal
        '
        Me.lblInternal.AutoSize = True
        Me.lblInternal.ForeColor = System.Drawing.Color.Black
        Me.lblInternal.Location = New System.Drawing.Point(0, 1)
        Me.lblInternal.Margin = New System.Windows.Forms.Padding(0, 1, 3, 3)
        Me.lblInternal.MinimumSize = New System.Drawing.Size(0, 21)
        Me.lblInternal.Name = "lblInternal"
        Me.lblInternal.Size = New System.Drawing.Size(55, 21)
        Me.lblInternal.TabIndex = 4
        Me.lblInternal.Text = "lblInternal"
        Me.lblInternal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUpdate
        '
        Me.lblUpdate.AutoSize = True
        Me.lblUpdate.ForeColor = System.Drawing.Color.Black
        Me.lblUpdate.Location = New System.Drawing.Point(3, 52)
        Me.lblUpdate.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblUpdate.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.Size = New System.Drawing.Size(52, 16)
        Me.lblUpdate.TabIndex = 0
        Me.lblUpdate.Text = "lblUpdate"
        Me.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HorizontalLine4
        '
        Me.HorizontalLine4.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine4.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine4.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine4.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine4.Name = "HorizontalLine4"
        Me.HorizontalLine4.Size = New System.Drawing.Size(582, 1)
        Me.HorizontalLine4.TabIndex = 4
        Me.HorizontalLine4.TabStop = False
        '
        'tpMonitoring
        '
        Me.tpMonitoring.BackColor = System.Drawing.Color.White
        Me.tpMonitoring.Controls.Add(Me.tlpMonitoringContent)
        Me.tpMonitoring.Location = New System.Drawing.Point(4, 40)
        Me.tpMonitoring.Name = "tpMonitoring"
        Me.tpMonitoring.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMonitoring.Size = New System.Drawing.Size(588, 387)
        Me.tpMonitoring.TabIndex = 5
        Me.tpMonitoring.Text = "tpMonitoring"
        '
        'tlpMonitoringContent
        '
        Me.tlpMonitoringContent.AutoSize = True
        Me.tlpMonitoringContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMonitoringContent.ColumnCount = 1
        Me.tlpMonitoringContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMonitoringContent.Controls.Add(tlpMonitoringTitle, 0, 0)
        Me.tlpMonitoringContent.Controls.Add(tlpHdd, 0, 3)
        Me.tlpMonitoringContent.Controls.Add(Me.HorizontalLine8, 0, 1)
        Me.tlpMonitoringContent.Controls.Add(Me.lblParamToMonitor, 0, 2)
        Me.tlpMonitoringContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpMonitoringContent.Location = New System.Drawing.Point(3, 3)
        Me.tlpMonitoringContent.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.tlpMonitoringContent.Name = "tlpMonitoringContent"
        Me.tlpMonitoringContent.RowCount = 6
        Me.tlpMonitoringContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMonitoringContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMonitoringContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMonitoringContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMonitoringContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMonitoringContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMonitoringContent.Size = New System.Drawing.Size(582, 345)
        Me.tlpMonitoringContent.TabIndex = 24
        '
        'HorizontalLine8
        '
        Me.HorizontalLine8.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine8.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine8.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine8.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine8.Name = "HorizontalLine8"
        Me.HorizontalLine8.Size = New System.Drawing.Size(582, 1)
        Me.HorizontalLine8.TabIndex = 23
        Me.HorizontalLine8.TabStop = False
        '
        'lblParamToMonitor
        '
        Me.lblParamToMonitor.AutoSize = True
        Me.lblParamToMonitor.ForeColor = System.Drawing.Color.Black
        Me.lblParamToMonitor.Location = New System.Drawing.Point(0, 55)
        Me.lblParamToMonitor.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblParamToMonitor.Name = "lblParamToMonitor"
        Me.lblParamToMonitor.Size = New System.Drawing.Size(95, 13)
        Me.lblParamToMonitor.TabIndex = 24
        Me.lblParamToMonitor.Text = "lblParamToMonitor"
        '
        'tpWarnings
        '
        Me.tpWarnings.AutoScroll = True
        Me.tpWarnings.BackColor = System.Drawing.Color.White
        Me.tpWarnings.Controls.Add(Me.tlpWarningsContent)
        Me.tpWarnings.Location = New System.Drawing.Point(4, 40)
        Me.tpWarnings.Name = "tpWarnings"
        Me.tpWarnings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpWarnings.Size = New System.Drawing.Size(588, 387)
        Me.tpWarnings.TabIndex = 6
        Me.tpWarnings.Text = "tpWarnings"
        '
        'tlpWarningsContent
        '
        Me.tlpWarningsContent.AutoSize = True
        Me.tlpWarningsContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpWarningsContent.ColumnCount = 1
        Me.tlpWarningsContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpWarningsContent.Controls.Add(Me.tlpParamChange, 0, 6)
        Me.tlpWarningsContent.Controls.Add(tlpWarningsTitle, 0, 0)
        Me.tlpWarningsContent.Controls.Add(Me.chkParamChng, 0, 5)
        Me.tlpWarningsContent.Controls.Add(Me.chkTempThresh, 0, 3)
        Me.tlpWarningsContent.Controls.Add(Me.chkFailure, 0, 2)
        Me.tlpWarningsContent.Controls.Add(Me.HorizontalLine5, 0, 1)
        Me.tlpWarningsContent.Controls.Add(Me.tlpTempThreshold, 0, 4)
        Me.tlpWarningsContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpWarningsContent.Location = New System.Drawing.Point(3, 3)
        Me.tlpWarningsContent.Name = "tlpWarningsContent"
        Me.tlpWarningsContent.RowCount = 7
        Me.tlpWarningsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWarningsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWarningsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWarningsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWarningsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWarningsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWarningsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWarningsContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpWarningsContent.Size = New System.Drawing.Size(565, 419)
        Me.tlpWarningsContent.TabIndex = 24
        '
        'tlpParamChange
        '
        Me.tlpParamChange.AutoSize = True
        Me.tlpParamChange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpParamChange.ColumnCount = 2
        Me.tlpParamChange.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpParamChange.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpParamChange.Controls.Add(Me.chkIndilinxChng, 1, 1)
        Me.tlpParamChange.Controls.Add(Me.chkSamsungChng, 1, 4)
        Me.tlpParamChange.Controls.Add(Me.chkIntelChng, 1, 2)
        Me.tlpParamChange.Controls.Add(Me.chkMicronChng, 1, 3)
        Me.tlpParamChange.Controls.Add(Me.lblSsdChange, 1, 0)
        Me.tlpParamChange.Controls.Add(Me.lnkHddChngInvert, 0, 11)
        Me.tlpParamChange.Controls.Add(Me.chkDiskShiftChng, 0, 10)
        Me.tlpParamChange.Controls.Add(Me.chkSoftReadErrChng, 0, 9)
        Me.tlpParamChange.Controls.Add(Me.lnkSsdChngInvert, 1, 6)
        Me.tlpParamChange.Controls.Add(Me.chkOfflUncChng, 0, 8)
        Me.tlpParamChange.Controls.Add(Me.chkCurPenSectChng, 0, 7)
        Me.tlpParamChange.Controls.Add(Me.chkReallEvCtChng, 0, 6)
        Me.tlpParamChange.Controls.Add(Me.chkSpinRetryCtChng, 0, 5)
        Me.tlpParamChange.Controls.Add(Me.chkReallSectCtChng, 0, 4)
        Me.tlpParamChange.Controls.Add(Me.chkTempChng, 0, 1)
        Me.tlpParamChange.Controls.Add(Me.lblHddChange, 0, 3)
        Me.tlpParamChange.Controls.Add(Me.chkSandForceChng, 1, 5)
        Me.tlpParamChange.Controls.Add(Me.lblGenericChange, 0, 0)
        Me.tlpParamChange.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpParamChange.Location = New System.Drawing.Point(20, 148)
        Me.tlpParamChange.Margin = New System.Windows.Forms.Padding(20, 0, 3, 3)
        Me.tlpParamChange.Name = "tlpParamChange"
        Me.tlpParamChange.RowCount = 12
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpParamChange.Size = New System.Drawing.Size(542, 268)
        Me.tlpParamChange.TabIndex = 22
        '
        'chkIndilinxChng
        '
        Me.chkIndilinxChng.AutoSize = True
        Me.chkIndilinxChng.ForeColor = System.Drawing.Color.Black
        Me.chkIndilinxChng.Location = New System.Drawing.Point(274, 22)
        Me.chkIndilinxChng.Name = "chkIndilinxChng"
        Me.chkIndilinxChng.Size = New System.Drawing.Size(101, 17)
        Me.chkIndilinxChng.TabIndex = 14
        Me.chkIndilinxChng.Text = "chkIndilinxChng"
        Me.chkIndilinxChng.UseVisualStyleBackColor = True
        '
        'chkSamsungChng
        '
        Me.chkSamsungChng.AutoSize = True
        Me.chkSamsungChng.ForeColor = System.Drawing.Color.Black
        Me.chkSamsungChng.Location = New System.Drawing.Point(274, 91)
        Me.chkSamsungChng.Name = "chkSamsungChng"
        Me.chkSamsungChng.Size = New System.Drawing.Size(110, 17)
        Me.chkSamsungChng.TabIndex = 17
        Me.chkSamsungChng.Text = "chkSamsungChng"
        Me.chkSamsungChng.UseVisualStyleBackColor = True
        '
        'chkIntelChng
        '
        Me.chkIntelChng.AutoSize = True
        Me.chkIntelChng.ForeColor = System.Drawing.Color.Black
        Me.chkIntelChng.Location = New System.Drawing.Point(274, 45)
        Me.chkIntelChng.Name = "chkIntelChng"
        Me.chkIntelChng.Size = New System.Drawing.Size(89, 17)
        Me.chkIntelChng.TabIndex = 15
        Me.chkIntelChng.Text = "chkIntelChng"
        Me.chkIntelChng.UseVisualStyleBackColor = True
        '
        'chkMicronChng
        '
        Me.chkMicronChng.AutoSize = True
        Me.chkMicronChng.ForeColor = System.Drawing.Color.Black
        Me.chkMicronChng.Location = New System.Drawing.Point(274, 68)
        Me.chkMicronChng.Name = "chkMicronChng"
        Me.chkMicronChng.Size = New System.Drawing.Size(98, 17)
        Me.chkMicronChng.TabIndex = 16
        Me.chkMicronChng.Text = "chkMicronChng"
        Me.chkMicronChng.UseVisualStyleBackColor = True
        '
        'lblSsdChange
        '
        Me.lblSsdChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSsdChange.AutoSize = True
        Me.lblSsdChange.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSsdChange.Location = New System.Drawing.Point(271, 3)
        Me.lblSsdChange.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblSsdChange.Name = "lblSsdChange"
        Me.lblSsdChange.Size = New System.Drawing.Size(71, 13)
        Me.lblSsdChange.TabIndex = 12
        Me.lblSsdChange.Text = "lblSsdChange"
        '
        'lnkHddChngInvert
        '
        Me.lnkHddChngInvert.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkHddChngInvert.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lnkHddChngInvert.AutoSize = True
        Me.lnkHddChngInvert.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkHddChngInvert.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkHddChngInvert.Location = New System.Drawing.Point(20, 252)
        Me.lnkHddChngInvert.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.lnkHddChngInvert.Name = "lnkHddChngInvert"
        Me.lnkHddChngInvert.Size = New System.Drawing.Size(94, 13)
        Me.lnkHddChngInvert.TabIndex = 13
        Me.lnkHddChngInvert.TabStop = True
        Me.lnkHddChngInvert.Text = "lnkHddChngInvert"
        '
        'chkDiskShiftChng
        '
        Me.chkDiskShiftChng.AutoSize = True
        Me.chkDiskShiftChng.ForeColor = System.Drawing.Color.Black
        Me.chkDiskShiftChng.Location = New System.Drawing.Point(3, 229)
        Me.chkDiskShiftChng.Name = "chkDiskShiftChng"
        Me.chkDiskShiftChng.Size = New System.Drawing.Size(108, 17)
        Me.chkDiskShiftChng.TabIndex = 12
        Me.chkDiskShiftChng.Text = "chkDiskShiftChng"
        Me.chkDiskShiftChng.UseVisualStyleBackColor = True
        '
        'chkSoftReadErrChng
        '
        Me.chkSoftReadErrChng.AutoSize = True
        Me.chkSoftReadErrChng.ForeColor = System.Drawing.Color.Black
        Me.chkSoftReadErrChng.Location = New System.Drawing.Point(3, 206)
        Me.chkSoftReadErrChng.Name = "chkSoftReadErrChng"
        Me.chkSoftReadErrChng.Size = New System.Drawing.Size(126, 17)
        Me.chkSoftReadErrChng.TabIndex = 11
        Me.chkSoftReadErrChng.Text = "chkSoftReadErrChng"
        Me.chkSoftReadErrChng.UseVisualStyleBackColor = True
        '
        'lnkSsdChngInvert
        '
        Me.lnkSsdChngInvert.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSsdChngInvert.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lnkSsdChngInvert.AutoSize = True
        Me.lnkSsdChngInvert.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSsdChngInvert.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkSsdChngInvert.Location = New System.Drawing.Point(291, 139)
        Me.lnkSsdChngInvert.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.lnkSsdChngInvert.Name = "lnkSsdChngInvert"
        Me.lnkSsdChngInvert.Size = New System.Drawing.Size(92, 13)
        Me.lnkSsdChngInvert.TabIndex = 19
        Me.lnkSsdChngInvert.TabStop = True
        Me.lnkSsdChngInvert.Text = "lnkSsdChngInvert"
        '
        'chkOfflUncChng
        '
        Me.chkOfflUncChng.AutoSize = True
        Me.chkOfflUncChng.ForeColor = System.Drawing.Color.Black
        Me.chkOfflUncChng.Location = New System.Drawing.Point(3, 183)
        Me.chkOfflUncChng.Name = "chkOfflUncChng"
        Me.chkOfflUncChng.Size = New System.Drawing.Size(103, 17)
        Me.chkOfflUncChng.TabIndex = 10
        Me.chkOfflUncChng.Text = "chkOfflUncChng"
        Me.chkOfflUncChng.UseVisualStyleBackColor = True
        '
        'chkCurPenSectChng
        '
        Me.chkCurPenSectChng.AutoSize = True
        Me.chkCurPenSectChng.ForeColor = System.Drawing.Color.Black
        Me.chkCurPenSectChng.Location = New System.Drawing.Point(3, 160)
        Me.chkCurPenSectChng.Name = "chkCurPenSectChng"
        Me.chkCurPenSectChng.Size = New System.Drawing.Size(123, 17)
        Me.chkCurPenSectChng.TabIndex = 9
        Me.chkCurPenSectChng.Text = "chkCurPenSectChng"
        Me.chkCurPenSectChng.UseVisualStyleBackColor = True
        '
        'chkReallEvCtChng
        '
        Me.chkReallEvCtChng.AutoSize = True
        Me.chkReallEvCtChng.ForeColor = System.Drawing.Color.Black
        Me.chkReallEvCtChng.Location = New System.Drawing.Point(3, 137)
        Me.chkReallEvCtChng.Name = "chkReallEvCtChng"
        Me.chkReallEvCtChng.Size = New System.Drawing.Size(113, 17)
        Me.chkReallEvCtChng.TabIndex = 8
        Me.chkReallEvCtChng.Text = "chkReallEvCtChng"
        Me.chkReallEvCtChng.UseVisualStyleBackColor = True
        '
        'chkSpinRetryCtChng
        '
        Me.chkSpinRetryCtChng.AutoSize = True
        Me.chkSpinRetryCtChng.ForeColor = System.Drawing.Color.Black
        Me.chkSpinRetryCtChng.Location = New System.Drawing.Point(3, 114)
        Me.chkSpinRetryCtChng.Name = "chkSpinRetryCtChng"
        Me.chkSpinRetryCtChng.Size = New System.Drawing.Size(125, 17)
        Me.chkSpinRetryCtChng.TabIndex = 7
        Me.chkSpinRetryCtChng.Text = "chkSpinRetryCtChng"
        Me.chkSpinRetryCtChng.UseVisualStyleBackColor = True
        '
        'chkReallSectCtChng
        '
        Me.chkReallSectCtChng.AutoSize = True
        Me.chkReallSectCtChng.ForeColor = System.Drawing.Color.Black
        Me.chkReallSectCtChng.Location = New System.Drawing.Point(3, 91)
        Me.chkReallSectCtChng.Name = "chkReallSectCtChng"
        Me.chkReallSectCtChng.Size = New System.Drawing.Size(122, 17)
        Me.chkReallSectCtChng.TabIndex = 6
        Me.chkReallSectCtChng.Text = "chkReallSectCtChng"
        Me.chkReallSectCtChng.UseVisualStyleBackColor = True
        '
        'chkTempChng
        '
        Me.chkTempChng.AutoSize = True
        Me.chkTempChng.ForeColor = System.Drawing.Color.Black
        Me.chkTempChng.Location = New System.Drawing.Point(3, 22)
        Me.chkTempChng.Name = "chkTempChng"
        Me.chkTempChng.Size = New System.Drawing.Size(93, 17)
        Me.chkTempChng.TabIndex = 5
        Me.chkTempChng.Text = "chkTempChng"
        Me.chkTempChng.UseVisualStyleBackColor = True
        '
        'lblHddChange
        '
        Me.lblHddChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHddChange.AutoSize = True
        Me.lblHddChange.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHddChange.Location = New System.Drawing.Point(0, 72)
        Me.lblHddChange.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblHddChange.Name = "lblHddChange"
        Me.lblHddChange.Size = New System.Drawing.Size(73, 13)
        Me.lblHddChange.TabIndex = 11
        Me.lblHddChange.Text = "lblHddChange"
        '
        'chkSandForceChng
        '
        Me.chkSandForceChng.AutoSize = True
        Me.chkSandForceChng.ForeColor = System.Drawing.Color.Black
        Me.chkSandForceChng.Location = New System.Drawing.Point(274, 114)
        Me.chkSandForceChng.Name = "chkSandForceChng"
        Me.chkSandForceChng.Size = New System.Drawing.Size(118, 17)
        Me.chkSandForceChng.TabIndex = 18
        Me.chkSandForceChng.Text = "chkSandForceChng"
        Me.chkSandForceChng.UseVisualStyleBackColor = True
        '
        'lblGenericChange
        '
        Me.lblGenericChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGenericChange.AutoSize = True
        Me.lblGenericChange.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblGenericChange.Location = New System.Drawing.Point(0, 3)
        Me.lblGenericChange.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblGenericChange.Name = "lblGenericChange"
        Me.lblGenericChange.Size = New System.Drawing.Size(90, 13)
        Me.lblGenericChange.TabIndex = 17
        Me.lblGenericChange.Text = "lblGenericChange"
        '
        'chkParamChng
        '
        Me.chkParamChng.AutoSize = True
        Me.chkParamChng.ForeColor = System.Drawing.Color.Black
        Me.chkParamChng.Location = New System.Drawing.Point(3, 128)
        Me.chkParamChng.Name = "chkParamChng"
        Me.chkParamChng.Size = New System.Drawing.Size(97, 17)
        Me.chkParamChng.TabIndex = 4
        Me.chkParamChng.Text = "chkParamChng"
        Me.chkParamChng.UseVisualStyleBackColor = True
        '
        'chkTempThresh
        '
        Me.chkTempThresh.AutoSize = True
        Me.chkTempThresh.ForeColor = System.Drawing.Color.Black
        Me.chkTempThresh.Location = New System.Drawing.Point(3, 78)
        Me.chkTempThresh.Name = "chkTempThresh"
        Me.chkTempThresh.Size = New System.Drawing.Size(101, 17)
        Me.chkTempThresh.TabIndex = 1
        Me.chkTempThresh.Text = "chkTempThresh"
        Me.chkTempThresh.UseVisualStyleBackColor = True
        '
        'chkFailure
        '
        Me.chkFailure.AutoSize = True
        Me.chkFailure.ForeColor = System.Drawing.Color.Black
        Me.chkFailure.Location = New System.Drawing.Point(3, 55)
        Me.chkFailure.Name = "chkFailure"
        Me.chkFailure.Size = New System.Drawing.Size(74, 17)
        Me.chkFailure.TabIndex = 0
        Me.chkFailure.Text = "chkFailure"
        Me.chkFailure.UseVisualStyleBackColor = True
        '
        'HorizontalLine5
        '
        Me.HorizontalLine5.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine5.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine5.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine5.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine5.Name = "HorizontalLine5"
        Me.HorizontalLine5.Size = New System.Drawing.Size(565, 1)
        Me.HorizontalLine5.TabIndex = 6
        Me.HorizontalLine5.TabStop = False
        '
        'tlpTempThreshold
        '
        Me.tlpTempThreshold.AutoSize = True
        Me.tlpTempThreshold.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTempThreshold.ColumnCount = 3
        Me.tlpTempThreshold.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTempThreshold.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTempThreshold.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTempThreshold.Controls.Add(Me.chkCustomTemp, 0, 0)
        Me.tlpTempThreshold.Controls.Add(Me.numTemp, 1, 0)
        Me.tlpTempThreshold.Controls.Add(Me.lblTemp, 2, 0)
        Me.tlpTempThreshold.Location = New System.Drawing.Point(20, 98)
        Me.tlpTempThreshold.Margin = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.tlpTempThreshold.Name = "tlpTempThreshold"
        Me.tlpTempThreshold.RowCount = 1
        Me.tlpTempThreshold.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTempThreshold.Size = New System.Drawing.Size(209, 27)
        Me.tlpTempThreshold.TabIndex = 23
        '
        'chkCustomTemp
        '
        Me.chkCustomTemp.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkCustomTemp.AutoSize = True
        Me.chkCustomTemp.ForeColor = System.Drawing.Color.Black
        Me.chkCustomTemp.Location = New System.Drawing.Point(3, 2)
        Me.chkCustomTemp.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.chkCustomTemp.MinimumSize = New System.Drawing.Size(0, 21)
        Me.chkCustomTemp.Name = "chkCustomTemp"
        Me.chkCustomTemp.Size = New System.Drawing.Size(104, 21)
        Me.chkCustomTemp.TabIndex = 2
        Me.chkCustomTemp.Text = "chkCustomTemp"
        Me.chkCustomTemp.UseVisualStyleBackColor = True
        '
        'numTemp
        '
        Me.numTemp.BackColor = System.Drawing.Color.White
        Me.numTemp.ForeColor = System.Drawing.Color.Black
        Me.numTemp.Location = New System.Drawing.Point(113, 3)
        Me.numTemp.Name = "numTemp"
        Me.numTemp.ReadOnly = True
        Me.numTemp.Size = New System.Drawing.Size(47, 21)
        Me.numTemp.TabIndex = 3
        Me.numTemp.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'lblTemp
        '
        Me.lblTemp.AutoSize = True
        Me.lblTemp.ForeColor = System.Drawing.Color.Black
        Me.lblTemp.Location = New System.Drawing.Point(163, 1)
        Me.lblTemp.Margin = New System.Windows.Forms.Padding(0, 1, 3, 0)
        Me.lblTemp.MinimumSize = New System.Drawing.Size(0, 21)
        Me.lblTemp.Name = "lblTemp"
        Me.lblTemp.Size = New System.Drawing.Size(43, 21)
        Me.lblTemp.TabIndex = 2
        Me.lblTemp.Text = "lblTemp"
        Me.lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpShare
        '
        Me.tpShare.BackColor = System.Drawing.Color.White
        Me.tpShare.Controls.Add(Me.tlpShareContent)
        Me.tpShare.Location = New System.Drawing.Point(4, 40)
        Me.tpShare.Name = "tpShare"
        Me.tpShare.Padding = New System.Windows.Forms.Padding(3)
        Me.tpShare.Size = New System.Drawing.Size(588, 387)
        Me.tpShare.TabIndex = 7
        Me.tpShare.Text = "tpShare"
        '
        'tlpShareContent
        '
        Me.tlpShareContent.AutoSize = True
        Me.tlpShareContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpShareContent.ColumnCount = 1
        Me.tlpShareContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpShareContent.Controls.Add(flwXml, 0, 8)
        Me.tlpShareContent.Controls.Add(tlpShareTitle, 0, 0)
        Me.tlpShareContent.Controls.Add(Me.chkXml, 0, 7)
        Me.tlpShareContent.Controls.Add(flwShare, 0, 4)
        Me.tlpShareContent.Controls.Add(Me.lblSelFolder, 0, 3)
        Me.tlpShareContent.Controls.Add(Me.HorizontalLine9, 0, 1)
        Me.tlpShareContent.Controls.Add(Me.lblSharing, 0, 2)
        Me.tlpShareContent.Controls.Add(Me.lblXmlCreate, 0, 6)
        Me.tlpShareContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpShareContent.Location = New System.Drawing.Point(3, 3)
        Me.tlpShareContent.Name = "tlpShareContent"
        Me.tlpShareContent.RowCount = 9
        Me.tlpShareContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpShareContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpShareContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpShareContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpShareContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpShareContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpShareContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpShareContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpShareContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpShareContent.Size = New System.Drawing.Size(582, 278)
        Me.tlpShareContent.TabIndex = 24
        '
        'chkXml
        '
        Me.chkXml.AutoSize = True
        Me.chkXml.ForeColor = System.Drawing.Color.Black
        Me.chkXml.Location = New System.Drawing.Point(3, 183)
        Me.chkXml.Name = "chkXml"
        Me.chkXml.Size = New System.Drawing.Size(58, 17)
        Me.chkXml.TabIndex = 1
        Me.chkXml.Text = "chkXml"
        Me.chkXml.UseVisualStyleBackColor = True
        '
        'lblSelFolder
        '
        Me.lblSelFolder.AutoSize = True
        Me.lblSelFolder.ForeColor = System.Drawing.Color.Black
        Me.lblSelFolder.Location = New System.Drawing.Point(0, 72)
        Me.lblSelFolder.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblSelFolder.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblSelFolder.Name = "lblSelFolder"
        Me.lblSelFolder.Size = New System.Drawing.Size(61, 16)
        Me.lblSelFolder.TabIndex = 18
        Me.lblSelFolder.Text = "lblSelFolder"
        Me.lblSelFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HorizontalLine9
        '
        Me.HorizontalLine9.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine9.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine9.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine9.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine9.Name = "HorizontalLine9"
        Me.HorizontalLine9.Size = New System.Drawing.Size(582, 1)
        Me.HorizontalLine9.TabIndex = 22
        Me.HorizontalLine9.TabStop = False
        '
        'lblSharing
        '
        Me.lblSharing.AutoSize = True
        Me.lblSharing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSharing.Location = New System.Drawing.Point(0, 56)
        Me.lblSharing.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblSharing.Name = "lblSharing"
        Me.lblSharing.Size = New System.Drawing.Size(53, 13)
        Me.lblSharing.TabIndex = 23
        Me.lblSharing.Text = "lblSharing"
        '
        'lblXmlCreate
        '
        Me.lblXmlCreate.AutoSize = True
        Me.lblXmlCreate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblXmlCreate.Location = New System.Drawing.Point(0, 163)
        Me.lblXmlCreate.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblXmlCreate.Name = "lblXmlCreate"
        Me.lblXmlCreate.Size = New System.Drawing.Size(66, 13)
        Me.lblXmlCreate.TabIndex = 24
        Me.lblXmlCreate.Text = "lblXmlCreate"
        '
        'tpRating
        '
        Me.tpRating.BackColor = System.Drawing.Color.White
        Me.tpRating.Controls.Add(Me.tlpRatingContent)
        Me.tpRating.Location = New System.Drawing.Point(4, 40)
        Me.tpRating.Name = "tpRating"
        Me.tpRating.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRating.Size = New System.Drawing.Size(588, 387)
        Me.tpRating.TabIndex = 8
        Me.tpRating.Text = "tpRating"
        '
        'tlpRatingContent
        '
        Me.tlpRatingContent.AutoSize = True
        Me.tlpRatingContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpRatingContent.ColumnCount = 1
        Me.tlpRatingContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRatingContent.Controls.Add(Me.tlpTuneUp, 0, 4)
        Me.tlpRatingContent.Controls.Add(Me.chkTuneUp, 0, 3)
        Me.tlpRatingContent.Controls.Add(tlpRatingTitle, 0, 0)
        Me.tlpRatingContent.Controls.Add(Me.chkRating, 0, 2)
        Me.tlpRatingContent.Controls.Add(Me.HorizontalLine6, 0, 1)
        Me.tlpRatingContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpRatingContent.Location = New System.Drawing.Point(3, 3)
        Me.tlpRatingContent.Name = "tlpRatingContent"
        Me.tlpRatingContent.RowCount = 5
        Me.tlpRatingContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRatingContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRatingContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRatingContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRatingContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRatingContent.Size = New System.Drawing.Size(582, 185)
        Me.tlpRatingContent.TabIndex = 23
        '
        'tlpTuneUp
        '
        Me.tlpTuneUp.AutoSize = True
        Me.tlpTuneUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTuneUp.ColumnCount = 3
        Me.tlpTuneUp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTuneUp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTuneUp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTuneUp.Controls.Add(Me.lblCurPendTune, 0, 1)
        Me.tlpTuneUp.Controls.Add(Me.lnkResetOfflUnc, 2, 2)
        Me.tlpTuneUp.Controls.Add(Me.lblErrorsTune, 0, 0)
        Me.tlpTuneUp.Controls.Add(Me.lblOfflUncTune, 0, 2)
        Me.tlpTuneUp.Controls.Add(Me.lnkResetCurPending, 2, 1)
        Me.tlpTuneUp.Controls.Add(Me.numErrors, 1, 0)
        Me.tlpTuneUp.Controls.Add(Me.numCurPend, 1, 1)
        Me.tlpTuneUp.Controls.Add(Me.lnkResetErrors, 2, 0)
        Me.tlpTuneUp.Controls.Add(Me.numOfflUnc, 1, 2)
        Me.tlpTuneUp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpTuneUp.Location = New System.Drawing.Point(20, 101)
        Me.tlpTuneUp.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.tlpTuneUp.Name = "tlpTuneUp"
        Me.tlpTuneUp.RowCount = 4
        Me.tlpTuneUp.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTuneUp.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTuneUp.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTuneUp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTuneUp.Size = New System.Drawing.Size(559, 81)
        Me.tlpTuneUp.TabIndex = 3
        '
        'lblCurPendTune
        '
        Me.lblCurPendTune.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCurPendTune.AutoSize = True
        Me.lblCurPendTune.ForeColor = System.Drawing.Color.Black
        Me.lblCurPendTune.Location = New System.Drawing.Point(0, 34)
        Me.lblCurPendTune.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblCurPendTune.Name = "lblCurPendTune"
        Me.lblCurPendTune.Size = New System.Drawing.Size(82, 13)
        Me.lblCurPendTune.TabIndex = 7
        Me.lblCurPendTune.Text = "lblCurPendTune"
        '
        'lnkResetOfflUnc
        '
        Me.lnkResetOfflUnc.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkResetOfflUnc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lnkResetOfflUnc.AutoSize = True
        Me.lnkResetOfflUnc.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkResetOfflUnc.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkResetOfflUnc.Location = New System.Drawing.Point(154, 61)
        Me.lnkResetOfflUnc.Name = "lnkResetOfflUnc"
        Me.lnkResetOfflUnc.Size = New System.Drawing.Size(84, 13)
        Me.lnkResetOfflUnc.TabIndex = 7
        Me.lnkResetOfflUnc.TabStop = True
        Me.lnkResetOfflUnc.Text = "lnkResetOfflUnc"
        '
        'lblErrorsTune
        '
        Me.lblErrorsTune.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblErrorsTune.AutoSize = True
        Me.lblErrorsTune.ForeColor = System.Drawing.Color.Black
        Me.lblErrorsTune.Location = New System.Drawing.Point(0, 7)
        Me.lblErrorsTune.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblErrorsTune.Name = "lblErrorsTune"
        Me.lblErrorsTune.Size = New System.Drawing.Size(70, 13)
        Me.lblErrorsTune.TabIndex = 0
        Me.lblErrorsTune.Text = "lblErrorsTune"
        '
        'lblOfflUncTune
        '
        Me.lblOfflUncTune.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOfflUncTune.AutoSize = True
        Me.lblOfflUncTune.ForeColor = System.Drawing.Color.Black
        Me.lblOfflUncTune.Location = New System.Drawing.Point(0, 61)
        Me.lblOfflUncTune.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblOfflUncTune.Name = "lblOfflUncTune"
        Me.lblOfflUncTune.Size = New System.Drawing.Size(77, 13)
        Me.lblOfflUncTune.TabIndex = 10
        Me.lblOfflUncTune.Text = "lblOfflUncTune"
        '
        'lnkResetCurPending
        '
        Me.lnkResetCurPending.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkResetCurPending.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lnkResetCurPending.AutoSize = True
        Me.lnkResetCurPending.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkResetCurPending.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkResetCurPending.Location = New System.Drawing.Point(154, 34)
        Me.lnkResetCurPending.Name = "lnkResetCurPending"
        Me.lnkResetCurPending.Size = New System.Drawing.Size(103, 13)
        Me.lnkResetCurPending.TabIndex = 5
        Me.lnkResetCurPending.TabStop = True
        Me.lnkResetCurPending.Text = "lnkResetCurPending"
        '
        'numErrors
        '
        Me.numErrors.BackColor = System.Drawing.Color.White
        Me.numErrors.ForeColor = System.Drawing.Color.Black
        Me.numErrors.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numErrors.Location = New System.Drawing.Point(88, 3)
        Me.numErrors.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numErrors.Name = "numErrors"
        Me.numErrors.ReadOnly = True
        Me.numErrors.Size = New System.Drawing.Size(60, 21)
        Me.numErrors.TabIndex = 2
        Me.numErrors.Tag = "10"
        Me.numErrors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numErrors.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'numCurPend
        '
        Me.numCurPend.BackColor = System.Drawing.Color.White
        Me.numCurPend.ForeColor = System.Drawing.Color.Black
        Me.numCurPend.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numCurPend.Location = New System.Drawing.Point(88, 30)
        Me.numCurPend.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCurPend.Name = "numCurPend"
        Me.numCurPend.ReadOnly = True
        Me.numCurPend.Size = New System.Drawing.Size(60, 21)
        Me.numCurPend.TabIndex = 4
        Me.numCurPend.Tag = "10"
        Me.numCurPend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numCurPend.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lnkResetErrors
        '
        Me.lnkResetErrors.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkResetErrors.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lnkResetErrors.AutoSize = True
        Me.lnkResetErrors.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkResetErrors.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkResetErrors.Location = New System.Drawing.Point(154, 7)
        Me.lnkResetErrors.Name = "lnkResetErrors"
        Me.lnkResetErrors.Size = New System.Drawing.Size(77, 13)
        Me.lnkResetErrors.TabIndex = 3
        Me.lnkResetErrors.TabStop = True
        Me.lnkResetErrors.Text = "lnkResetErrors"
        '
        'numOfflUnc
        '
        Me.numOfflUnc.BackColor = System.Drawing.Color.White
        Me.numOfflUnc.ForeColor = System.Drawing.Color.Black
        Me.numOfflUnc.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numOfflUnc.Location = New System.Drawing.Point(88, 57)
        Me.numOfflUnc.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numOfflUnc.Name = "numOfflUnc"
        Me.numOfflUnc.ReadOnly = True
        Me.numOfflUnc.Size = New System.Drawing.Size(60, 21)
        Me.numOfflUnc.TabIndex = 6
        Me.numOfflUnc.Tag = "10"
        Me.numOfflUnc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numOfflUnc.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'chkTuneUp
        '
        Me.chkTuneUp.AutoSize = True
        Me.chkTuneUp.ForeColor = System.Drawing.Color.Black
        Me.chkTuneUp.Location = New System.Drawing.Point(3, 78)
        Me.chkTuneUp.Name = "chkTuneUp"
        Me.chkTuneUp.Size = New System.Drawing.Size(79, 17)
        Me.chkTuneUp.TabIndex = 1
        Me.chkTuneUp.Text = "chkTuneUp"
        Me.chkTuneUp.UseVisualStyleBackColor = True
        '
        'chkRating
        '
        Me.chkRating.AutoSize = True
        Me.chkRating.ForeColor = System.Drawing.Color.Black
        Me.chkRating.Location = New System.Drawing.Point(3, 55)
        Me.chkRating.Name = "chkRating"
        Me.chkRating.Size = New System.Drawing.Size(73, 17)
        Me.chkRating.TabIndex = 0
        Me.chkRating.Text = "chkRating"
        Me.chkRating.UseVisualStyleBackColor = True
        '
        'HorizontalLine6
        '
        Me.HorizontalLine6.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine6.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine6.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine6.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine6.Name = "HorizontalLine6"
        Me.HorizontalLine6.Size = New System.Drawing.Size(582, 1)
        Me.HorizontalLine6.TabIndex = 4
        Me.HorizontalLine6.TabStop = False
        '
        'tpTolerance
        '
        Me.tpTolerance.BackColor = System.Drawing.Color.White
        Me.tpTolerance.Controls.Add(Me.tlpToleranceContent)
        Me.tpTolerance.Location = New System.Drawing.Point(4, 40)
        Me.tpTolerance.Name = "tpTolerance"
        Me.tpTolerance.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTolerance.Size = New System.Drawing.Size(588, 387)
        Me.tpTolerance.TabIndex = 9
        Me.tpTolerance.Text = "tpTolerance"
        '
        'tlpToleranceContent
        '
        Me.tlpToleranceContent.AutoSize = True
        Me.tlpToleranceContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpToleranceContent.ColumnCount = 1
        Me.tlpToleranceContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpToleranceContent.Controls.Add(tlpToleranceTitle, 0, 0)
        Me.tlpToleranceContent.Controls.Add(Me.flwTolerance, 0, 4)
        Me.tlpToleranceContent.Controls.Add(Me.lblInfoTolerance, 0, 2)
        Me.tlpToleranceContent.Controls.Add(Me.chkTolerance, 0, 3)
        Me.tlpToleranceContent.Controls.Add(Me.HorizontalLine10, 0, 1)
        Me.tlpToleranceContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpToleranceContent.Location = New System.Drawing.Point(3, 3)
        Me.tlpToleranceContent.Name = "tlpToleranceContent"
        Me.tlpToleranceContent.RowCount = 5
        Me.tlpToleranceContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpToleranceContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpToleranceContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpToleranceContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpToleranceContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpToleranceContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpToleranceContent.Size = New System.Drawing.Size(582, 205)
        Me.tlpToleranceContent.TabIndex = 25
        '
        'flwTolerance
        '
        Me.flwTolerance.AutoSize = True
        Me.flwTolerance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flwTolerance.Controls.Add(Me.rbNormal)
        Me.flwTolerance.Controls.Add(Me.lblNormal)
        Me.flwTolerance.Controls.Add(Me.rbConservative)
        Me.flwTolerance.Controls.Add(Me.lblConservative)
        Me.flwTolerance.Controls.Add(Me.rbVeryPermissive)
        Me.flwTolerance.Controls.Add(Me.lblVeryPermissive)
        Me.flwTolerance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flwTolerance.Location = New System.Drawing.Point(16, 101)
        Me.flwTolerance.Margin = New System.Windows.Forms.Padding(16, 3, 3, 3)
        Me.flwTolerance.Name = "flwTolerance"
        Me.flwTolerance.Size = New System.Drawing.Size(563, 101)
        Me.flwTolerance.TabIndex = 7
        '
        'rbNormal
        '
        Me.rbNormal.AutoSize = True
        Me.flwTolerance.SetFlowBreak(Me.rbNormal, True)
        Me.rbNormal.ForeColor = System.Drawing.Color.Black
        Me.rbNormal.Location = New System.Drawing.Point(3, 3)
        Me.rbNormal.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(68, 17)
        Me.rbNormal.TabIndex = 1
        Me.rbNormal.TabStop = True
        Me.rbNormal.Text = "rbNormal"
        Me.rbNormal.UseVisualStyleBackColor = True
        '
        'lblNormal
        '
        Me.lblNormal.AutoSize = True
        Me.flwTolerance.SetFlowBreak(Me.lblNormal, True)
        Me.lblNormal.ForeColor = System.Drawing.Color.DimGray
        Me.lblNormal.Location = New System.Drawing.Point(20, 20)
        Me.lblNormal.Margin = New System.Windows.Forms.Padding(20, 0, 3, 3)
        Me.lblNormal.Name = "lblNormal"
        Me.lblNormal.Size = New System.Drawing.Size(50, 13)
        Me.lblNormal.TabIndex = 1
        Me.lblNormal.Text = "lblNormal"
        '
        'rbConservative
        '
        Me.rbConservative.AutoSize = True
        Me.flwTolerance.SetFlowBreak(Me.rbConservative, True)
        Me.rbConservative.ForeColor = System.Drawing.Color.Black
        Me.rbConservative.Location = New System.Drawing.Point(3, 37)
        Me.rbConservative.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbConservative.Name = "rbConservative"
        Me.rbConservative.Size = New System.Drawing.Size(99, 17)
        Me.rbConservative.TabIndex = 2
        Me.rbConservative.TabStop = True
        Me.rbConservative.Text = "rbConservative"
        Me.rbConservative.UseVisualStyleBackColor = True
        '
        'lblConservative
        '
        Me.lblConservative.AutoSize = True
        Me.flwTolerance.SetFlowBreak(Me.lblConservative, True)
        Me.lblConservative.ForeColor = System.Drawing.Color.DimGray
        Me.lblConservative.Location = New System.Drawing.Point(20, 54)
        Me.lblConservative.Margin = New System.Windows.Forms.Padding(20, 0, 3, 3)
        Me.lblConservative.Name = "lblConservative"
        Me.lblConservative.Size = New System.Drawing.Size(81, 13)
        Me.lblConservative.TabIndex = 3
        Me.lblConservative.Text = "lblConservative"
        '
        'rbVeryPermissive
        '
        Me.rbVeryPermissive.AutoSize = True
        Me.flwTolerance.SetFlowBreak(Me.rbVeryPermissive, True)
        Me.rbVeryPermissive.ForeColor = System.Drawing.Color.Black
        Me.rbVeryPermissive.Location = New System.Drawing.Point(3, 71)
        Me.rbVeryPermissive.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbVeryPermissive.Name = "rbVeryPermissive"
        Me.rbVeryPermissive.Size = New System.Drawing.Size(107, 17)
        Me.rbVeryPermissive.TabIndex = 3
        Me.rbVeryPermissive.TabStop = True
        Me.rbVeryPermissive.Text = "rbVeryPermissive"
        Me.rbVeryPermissive.UseVisualStyleBackColor = True
        '
        'lblVeryPermissive
        '
        Me.lblVeryPermissive.AutoSize = True
        Me.lblVeryPermissive.ForeColor = System.Drawing.Color.DimGray
        Me.lblVeryPermissive.Location = New System.Drawing.Point(20, 88)
        Me.lblVeryPermissive.Margin = New System.Windows.Forms.Padding(20, 0, 3, 0)
        Me.lblVeryPermissive.Name = "lblVeryPermissive"
        Me.lblVeryPermissive.Size = New System.Drawing.Size(89, 13)
        Me.lblVeryPermissive.TabIndex = 5
        Me.lblVeryPermissive.Text = "lblVeryPermissive"
        '
        'lblInfoTolerance
        '
        Me.lblInfoTolerance.AutoSize = True
        Me.lblInfoTolerance.ForeColor = System.Drawing.Color.DimGray
        Me.lblInfoTolerance.Location = New System.Drawing.Point(3, 55)
        Me.lblInfoTolerance.Margin = New System.Windows.Forms.Padding(3, 3, 3, 7)
        Me.lblInfoTolerance.Name = "lblInfoTolerance"
        Me.lblInfoTolerance.Size = New System.Drawing.Size(84, 13)
        Me.lblInfoTolerance.TabIndex = 3
        Me.lblInfoTolerance.Text = "lblInfoTolerance"
        '
        'chkTolerance
        '
        Me.chkTolerance.AutoSize = True
        Me.chkTolerance.ForeColor = System.Drawing.Color.Black
        Me.chkTolerance.Location = New System.Drawing.Point(3, 78)
        Me.chkTolerance.Name = "chkTolerance"
        Me.chkTolerance.Size = New System.Drawing.Size(89, 17)
        Me.chkTolerance.TabIndex = 0
        Me.chkTolerance.Text = "chkTolerance"
        Me.chkTolerance.UseVisualStyleBackColor = True
        '
        'HorizontalLine10
        '
        Me.HorizontalLine10.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine10.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine10.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine10.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine10.Name = "HorizontalLine10"
        Me.HorizontalLine10.Size = New System.Drawing.Size(582, 1)
        Me.HorizontalLine10.TabIndex = 8
        Me.HorizontalLine10.TabStop = False
        '
        'tpAddDevices
        '
        Me.tpAddDevices.Controls.Add(Me.tlpAddDevices)
        Me.tpAddDevices.Location = New System.Drawing.Point(4, 40)
        Me.tpAddDevices.Name = "tpAddDevices"
        Me.tpAddDevices.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAddDevices.Size = New System.Drawing.Size(588, 387)
        Me.tpAddDevices.TabIndex = 11
        Me.tpAddDevices.Text = "tpAddDevices"
        Me.tpAddDevices.UseVisualStyleBackColor = True
        '
        'tlpAddDevices
        '
        Me.tlpAddDevices.AutoSize = True
        Me.tlpAddDevices.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpAddDevices.ColumnCount = 1
        Me.tlpAddDevices.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAddDevices.Controls.Add(tlpAddDevicesTitle, 0, 0)
        Me.tlpAddDevices.Controls.Add(Me.lblInfoAddDevices, 0, 2)
        Me.tlpAddDevices.Controls.Add(Me.HorizontalLine11, 0, 1)
        Me.tlpAddDevices.Controls.Add(Me.tlpDevicesList, 0, 4)
        Me.tlpAddDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpAddDevices.Location = New System.Drawing.Point(3, 3)
        Me.tlpAddDevices.Name = "tlpAddDevices"
        Me.tlpAddDevices.RowCount = 5
        Me.tlpAddDevices.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAddDevices.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAddDevices.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAddDevices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpAddDevices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpAddDevices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpAddDevices.Size = New System.Drawing.Size(582, 381)
        Me.tlpAddDevices.TabIndex = 26
        '
        'lblInfoAddDevices
        '
        Me.lblInfoAddDevices.AutoSize = True
        Me.lblInfoAddDevices.ForeColor = System.Drawing.Color.DimGray
        Me.lblInfoAddDevices.Location = New System.Drawing.Point(3, 55)
        Me.lblInfoAddDevices.Margin = New System.Windows.Forms.Padding(3, 3, 3, 7)
        Me.lblInfoAddDevices.Name = "lblInfoAddDevices"
        Me.lblInfoAddDevices.Size = New System.Drawing.Size(93, 13)
        Me.lblInfoAddDevices.TabIndex = 3
        Me.lblInfoAddDevices.Text = "lblInfoAddDevices"
        '
        'HorizontalLine11
        '
        Me.HorizontalLine11.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine11.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine11.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine11.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine11.Name = "HorizontalLine11"
        Me.HorizontalLine11.Size = New System.Drawing.Size(582, 1)
        Me.HorizontalLine11.TabIndex = 10
        Me.HorizontalLine11.TabStop = False
        '
        'tlpDevicesList
        '
        Me.tlpDevicesList.ColumnCount = 2
        Me.tlpDevicesList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDevicesList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDevicesList.Controls.Add(Me.lvwAdditionalDevices, 0, 0)
        Me.tlpDevicesList.Controls.Add(Me.tlpAddDevice, 1, 0)
        Me.tlpDevicesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDevicesList.Location = New System.Drawing.Point(0, 85)
        Me.tlpDevicesList.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpDevicesList.Name = "tlpDevicesList"
        Me.tlpDevicesList.RowCount = 1
        Me.tlpDevicesList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDevicesList.Size = New System.Drawing.Size(582, 296)
        Me.tlpDevicesList.TabIndex = 29
        '
        'lvwAdditionalDevices
        '
        Me.lvwAdditionalDevices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDescription, Me.chCommand})
        Me.lvwAdditionalDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwAdditionalDevices.FullRowSelect = True
        Me.lvwAdditionalDevices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwAdditionalDevices.Location = New System.Drawing.Point(0, 0)
        Me.lvwAdditionalDevices.Margin = New System.Windows.Forms.Padding(0)
        Me.lvwAdditionalDevices.MultiSelect = False
        Me.lvwAdditionalDevices.Name = "lvwAdditionalDevices"
        Me.lvwAdditionalDevices.Size = New System.Drawing.Size(501, 296)
        Me.lvwAdditionalDevices.TabIndex = 0
        Me.lvwAdditionalDevices.UseCompatibleStateImageBehavior = False
        Me.lvwAdditionalDevices.View = System.Windows.Forms.View.Details
        '
        'chDescription
        '
        Me.chDescription.Text = "chDescription"
        Me.chDescription.Width = 150
        '
        'chCommand
        '
        Me.chCommand.Text = "chCommand"
        Me.chCommand.Width = 250
        '
        'tlpAddDevice
        '
        Me.tlpAddDevice.AutoSize = True
        Me.tlpAddDevice.ColumnCount = 1
        Me.tlpAddDevice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAddDevice.Controls.Add(Me.btnAddDevice, 0, 0)
        Me.tlpAddDevice.Controls.Add(Me.btnRemoveDevice, 0, 1)
        Me.tlpAddDevice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpAddDevice.Location = New System.Drawing.Point(501, 0)
        Me.tlpAddDevice.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpAddDevice.Name = "tlpAddDevice"
        Me.tlpAddDevice.RowCount = 2
        Me.tlpAddDevice.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpAddDevice.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpAddDevice.Size = New System.Drawing.Size(81, 296)
        Me.tlpAddDevice.TabIndex = 28
        '
        'btnAddDevice
        '
        Me.btnAddDevice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddDevice.Location = New System.Drawing.Point(3, 3)
        Me.btnAddDevice.Name = "btnAddDevice"
        Me.btnAddDevice.Size = New System.Drawing.Size(75, 23)
        Me.btnAddDevice.TabIndex = 1
        Me.btnAddDevice.Text = "btnAddDevice"
        Me.btnAddDevice.UseVisualStyleBackColor = True
        '
        'btnRemoveDevice
        '
        Me.btnRemoveDevice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveDevice.Location = New System.Drawing.Point(3, 270)
        Me.btnRemoveDevice.Name = "btnRemoveDevice"
        Me.btnRemoveDevice.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveDevice.TabIndex = 2
        Me.btnRemoveDevice.Text = "btnRemoveDevice"
        Me.btnRemoveDevice.UseVisualStyleBackColor = True
        '
        'tpSmartctl
        '
        Me.tpSmartctl.Controls.Add(Me.tlpSmartctl)
        Me.tpSmartctl.Location = New System.Drawing.Point(4, 40)
        Me.tpSmartctl.Name = "tpSmartctl"
        Me.tpSmartctl.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSmartctl.Size = New System.Drawing.Size(588, 387)
        Me.tpSmartctl.TabIndex = 12
        Me.tpSmartctl.Text = "tpSmartctl"
        Me.tpSmartctl.UseVisualStyleBackColor = True
        '
        'tlpSmartctl
        '
        Me.tlpSmartctl.AutoSize = True
        Me.tlpSmartctl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSmartctl.ColumnCount = 1
        Me.tlpSmartctl.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSmartctl.Controls.Add(FlowLayoutPanel1, 0, 3)
        Me.tlpSmartctl.Controls.Add(tlpSmartctlTitle, 0, 0)
        Me.tlpSmartctl.Controls.Add(Me.chkSmartctl, 0, 2)
        Me.tlpSmartctl.Controls.Add(Me.HorizontalLine12, 0, 1)
        Me.tlpSmartctl.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpSmartctl.Location = New System.Drawing.Point(3, 3)
        Me.tlpSmartctl.Name = "tlpSmartctl"
        Me.tlpSmartctl.RowCount = 4
        Me.tlpSmartctl.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSmartctl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpSmartctl.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSmartctl.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSmartctl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpSmartctl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpSmartctl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpSmartctl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpSmartctl.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpSmartctl.Size = New System.Drawing.Size(582, 151)
        Me.tlpSmartctl.TabIndex = 25
        '
        'chkSmartctl
        '
        Me.chkSmartctl.AutoSize = True
        Me.chkSmartctl.ForeColor = System.Drawing.Color.Black
        Me.chkSmartctl.Location = New System.Drawing.Point(3, 56)
        Me.chkSmartctl.Name = "chkSmartctl"
        Me.chkSmartctl.Size = New System.Drawing.Size(81, 17)
        Me.chkSmartctl.TabIndex = 0
        Me.chkSmartctl.Text = "chkSmartctl"
        Me.chkSmartctl.UseVisualStyleBackColor = True
        '
        'HorizontalLine12
        '
        Me.HorizontalLine12.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine12.Location = New System.Drawing.Point(0, 42)
        Me.HorizontalLine12.Margin = New System.Windows.Forms.Padding(0, 9, 0, 9)
        Me.HorizontalLine12.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine12.Name = "HorizontalLine12"
        Me.HorizontalLine12.Size = New System.Drawing.Size(582, 1)
        Me.HorizontalLine12.TabIndex = 22
        Me.HorizontalLine12.TabStop = False
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(796, 431)
        Me.Controls.Add(Me.htcSettings)
        Me.Controls.Add(Me.pnlMenu)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        tlpGeneralTitle.ResumeLayout(False)
        tlpGeneralTitle.PerformLayout()
        CType(Me.picHelpSetupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        tlpDetectionTitle.ResumeLayout(False)
        tlpDetectionTitle.PerformLayout()
        CType(Me.picHelpSetupDetection, System.ComponentModel.ISupportInitialize).EndInit()
        tlpMessagesTitle.ResumeLayout(False)
        tlpMessagesTitle.PerformLayout()
        CType(Me.picHelpSetupTranslation, System.ComponentModel.ISupportInitialize).EndInit()
        tlpMailAlertsTitle.ResumeLayout(False)
        tlpMailAlertsTitle.PerformLayout()
        CType(Me.picHelpSetupMailAlerts, System.ComponentModel.ISupportInitialize).EndInit()
        tlpUpdateTitle.ResumeLayout(False)
        tlpUpdateTitle.PerformLayout()
        CType(Me.picHelpSetupUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        tlpMonitoringTitle.ResumeLayout(False)
        tlpMonitoringTitle.PerformLayout()
        CType(Me.picHelpSetupMonitoring, System.ComponentModel.ISupportInitialize).EndInit()
        tlpHdd.ResumeLayout(False)
        tlpHdd.PerformLayout()
        tlpWarningsTitle.ResumeLayout(False)
        tlpWarningsTitle.PerformLayout()
        CType(Me.picHelpSetupWarnings, System.ComponentModel.ISupportInitialize).EndInit()
        flwXml.ResumeLayout(False)
        flwXml.PerformLayout()
        tlpShareTitle.ResumeLayout(False)
        tlpShareTitle.PerformLayout()
        CType(Me.picHelpSetupShare, System.ComponentModel.ISupportInitialize).EndInit()
        flwShare.ResumeLayout(False)
        flwShare.PerformLayout()
        tlpRatingTitle.ResumeLayout(False)
        tlpRatingTitle.PerformLayout()
        CType(Me.picHelpSetupRating, System.ComponentModel.ISupportInitialize).EndInit()
        tlpToleranceTitle.ResumeLayout(False)
        tlpToleranceTitle.PerformLayout()
        CType(Me.picHelpSetupTolerance, System.ComponentModel.ISupportInitialize).EndInit()
        tlpAddDevicesTitle.ResumeLayout(False)
        tlpAddDevicesTitle.PerformLayout()
        CType(Me.picHelpSetupAddDevice, System.ComponentModel.ISupportInitialize).EndInit()
        FlowLayoutPanel1.ResumeLayout(False)
        FlowLayoutPanel1.PerformLayout()
        tlpSmartctlTitle.ResumeLayout(False)
        tlpSmartctlTitle.PerformLayout()
        CType(Me.picHelpSmartctl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMenu.ResumeLayout(False)
        Me.tlpMenuItems.ResumeLayout(False)
        Me.tlpMenuItems.PerformLayout()
        Me.htcSettings.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.tpGeneral.PerformLayout()
        Me.tlpGeneral.ResumeLayout(False)
        Me.tlpGeneral.PerformLayout()
        CType(Me.HorizontalLine7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpBehaviour.ResumeLayout(False)
        Me.tlpBehaviour.PerformLayout()
        Me.tlpStartup.ResumeLayout(False)
        Me.tlpStartup.PerformLayout()
        Me.tlpUpdates.ResumeLayout(False)
        Me.tlpUpdates.PerformLayout()
        Me.tpDetection.ResumeLayout(False)
        Me.tpDetection.PerformLayout()
        Me.tlpDetectionContent.ResumeLayout(False)
        Me.tlpDetectionContent.PerformLayout()
        CType(Me.HorizontalLine1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpNeedRestart.ResumeLayout(False)
        Me.tlpNeedRestart.PerformLayout()
        CType(Me.picNeedRestart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTranslation.ResumeLayout(False)
        Me.tpTranslation.PerformLayout()
        Me.tlpMessagesContent.ResumeLayout(False)
        Me.tlpMessagesContent.PerformLayout()
        CType(Me.HorizontalLine2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpLanguageInfo.ResumeLayout(False)
        Me.tlpLanguageInfo.PerformLayout()
        Me.tpMailAlerts.ResumeLayout(False)
        Me.tpMailAlerts.PerformLayout()
        Me.tlpMailAlertsContent.ResumeLayout(False)
        Me.tlpMailAlertsContent.PerformLayout()
        Me.tlpWhenSendMail.ResumeLayout(False)
        Me.tlpWhenSendMail.PerformLayout()
        CType(Me.HorizontalLine3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMail.ResumeLayout(False)
        Me.tlpMail.PerformLayout()
        Me.tlpCustomServer.ResumeLayout(False)
        Me.tlpCustomServer.PerformLayout()
        Me.tlpReport.ResumeLayout(False)
        Me.tlpReport.PerformLayout()
        Me.tpUpdate.ResumeLayout(False)
        Me.tpUpdate.PerformLayout()
        Me.tlpUpdateContent.ResumeLayout(False)
        Me.tlpUpdateContent.PerformLayout()
        Me.tlpUpdate.ResumeLayout(False)
        Me.tlpUpdate.PerformLayout()
        CType(Me.numUpdateVirtual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUpdateExt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HorizontalLine4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMonitoring.ResumeLayout(False)
        Me.tpMonitoring.PerformLayout()
        Me.tlpMonitoringContent.ResumeLayout(False)
        Me.tlpMonitoringContent.PerformLayout()
        CType(Me.HorizontalLine8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpWarnings.ResumeLayout(False)
        Me.tpWarnings.PerformLayout()
        Me.tlpWarningsContent.ResumeLayout(False)
        Me.tlpWarningsContent.PerformLayout()
        Me.tlpParamChange.ResumeLayout(False)
        Me.tlpParamChange.PerformLayout()
        CType(Me.HorizontalLine5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpTempThreshold.ResumeLayout(False)
        Me.tlpTempThreshold.PerformLayout()
        CType(Me.numTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpShare.ResumeLayout(False)
        Me.tpShare.PerformLayout()
        Me.tlpShareContent.ResumeLayout(False)
        Me.tlpShareContent.PerformLayout()
        CType(Me.HorizontalLine9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpRating.ResumeLayout(False)
        Me.tpRating.PerformLayout()
        Me.tlpRatingContent.ResumeLayout(False)
        Me.tlpRatingContent.PerformLayout()
        Me.tlpTuneUp.ResumeLayout(False)
        Me.tlpTuneUp.PerformLayout()
        CType(Me.numErrors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCurPend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOfflUnc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HorizontalLine6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTolerance.ResumeLayout(False)
        Me.tpTolerance.PerformLayout()
        Me.tlpToleranceContent.ResumeLayout(False)
        Me.tlpToleranceContent.PerformLayout()
        Me.flwTolerance.ResumeLayout(False)
        Me.flwTolerance.PerformLayout()
        CType(Me.HorizontalLine10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAddDevices.ResumeLayout(False)
        Me.tpAddDevices.PerformLayout()
        Me.tlpAddDevices.ResumeLayout(False)
        Me.tlpAddDevices.PerformLayout()
        CType(Me.HorizontalLine11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpDevicesList.ResumeLayout(False)
        Me.tlpDevicesList.PerformLayout()
        Me.tlpAddDevice.ResumeLayout(False)
        Me.tpSmartctl.ResumeLayout(False)
        Me.tpSmartctl.PerformLayout()
        Me.tlpSmartctl.ResumeLayout(False)
        Me.tlpSmartctl.PerformLayout()
        CType(Me.HorizontalLine12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents tlpMenuItems As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents htcSettings As hdd_guardian.HeadlessTabControl
    Friend WithEvents tpGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tpDetection As System.Windows.Forms.TabPage
    Friend WithEvents tlpGeneral As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picHelpSetupGeneral As System.Windows.Forms.PictureBox
    Friend WithEvents lblGeneralTitle As System.Windows.Forms.Label
    Friend WithEvents chkFahrenheit As System.Windows.Forms.CheckBox
    Friend WithEvents chkUpdates As System.Windows.Forms.CheckBox
    Friend WithEvents chkStartupLink As System.Windows.Forms.CheckBox
    Friend WithEvents chkConfirmExit As System.Windows.Forms.CheckBox
    Friend WithEvents chkCloseOnTray As System.Windows.Forms.CheckBox
    Friend WithEvents chkRunMinimized As System.Windows.Forms.CheckBox
    Friend WithEvents chkAlwaysShowTray As System.Windows.Forms.CheckBox
    Friend WithEvents chkMinimizeInTray As System.Windows.Forms.CheckBox
    Friend WithEvents tlpDetectionContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents HorizontalLine1 As hdd_guardian.HorizontalLine
    Friend WithEvents picHelpSetupDetection As System.Windows.Forms.PictureBox
    Friend WithEvents lblDetectionTitle As System.Windows.Forms.Label
    Friend WithEvents chkMonitorUsb As System.Windows.Forms.CheckBox
    Friend WithEvents tpTranslation As System.Windows.Forms.TabPage
    Friend WithEvents tpMailAlerts As System.Windows.Forms.TabPage
    Friend WithEvents tpUpdate As System.Windows.Forms.TabPage
    Friend WithEvents tpMonitoring As System.Windows.Forms.TabPage
    Friend WithEvents tpWarnings As System.Windows.Forms.TabPage
    Friend WithEvents tpShare As System.Windows.Forms.TabPage
    Friend WithEvents tlpMessagesContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picHelpSetupTranslation As System.Windows.Forms.PictureBox
    Friend WithEvents lblTranslationTitle As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine2 As hdd_guardian.HorizontalLine
    Friend WithEvents tlpMailAlertsContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents HorizontalLine3 As hdd_guardian.HorizontalLine
    Friend WithEvents tlpMail As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtMail As System.Windows.Forms.TextBox
    Friend WithEvents lnkTestMail As hdd_guardian.NewLink
    Friend WithEvents picHelpSetupMailAlerts As System.Windows.Forms.PictureBox
    Friend WithEvents lblMailAlertsTitle As System.Windows.Forms.Label
    Friend WithEvents chkMailAlerts As System.Windows.Forms.CheckBox
    Friend WithEvents tlpUpdateContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpUpdate As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblVirtual As System.Windows.Forms.Label
    Friend WithEvents numUpdateVirtual As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMinutesVirt As System.Windows.Forms.Label
    Friend WithEvents lblExternal As System.Windows.Forms.Label
    Friend WithEvents numUpdateExt As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMinutesExt As System.Windows.Forms.Label
    Friend WithEvents lblMinutes As System.Windows.Forms.Label
    Friend WithEvents numUpdate As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblInternal As System.Windows.Forms.Label
    Friend WithEvents picHelpSetupUpdate As System.Windows.Forms.PictureBox
    Friend WithEvents lblUpdateTitle As System.Windows.Forms.Label
    Friend WithEvents lblUpdate As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine4 As hdd_guardian.HorizontalLine
    Friend WithEvents tlpMonitoringContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picHelpSetupMonitoring As System.Windows.Forms.PictureBox
    Friend WithEvents lblMonitoringTitle As System.Windows.Forms.Label
    Friend WithEvents chkReallSectCt As System.Windows.Forms.CheckBox
    Friend WithEvents chkSpinRetryCt As System.Windows.Forms.CheckBox
    Friend WithEvents chkTemp As System.Windows.Forms.CheckBox
    Friend WithEvents chkReallEvCt As System.Windows.Forms.CheckBox
    Friend WithEvents chkCurPenSect As System.Windows.Forms.CheckBox
    Friend WithEvents chkOfflUnc As System.Windows.Forms.CheckBox
    Friend WithEvents chkSoftReadErr As System.Windows.Forms.CheckBox
    Friend WithEvents chkDiskShift As System.Windows.Forms.CheckBox
    Friend WithEvents lnkInvertHddSel As hdd_guardian.NewLink
    Friend WithEvents chkIndilinx As System.Windows.Forms.CheckBox
    Friend WithEvents chkSandForce As System.Windows.Forms.CheckBox
    Friend WithEvents chkIntel As System.Windows.Forms.CheckBox
    Friend WithEvents chkSamsung As System.Windows.Forms.CheckBox
    Friend WithEvents chkMicron As System.Windows.Forms.CheckBox
    Friend WithEvents lnkInvertSsdSel As hdd_guardian.NewLink
    Friend WithEvents tlpWarningsContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picHelpSetupWarnings As System.Windows.Forms.PictureBox
    Friend WithEvents lblWarningsTitle As System.Windows.Forms.Label
    Friend WithEvents chkParamChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkTempThresh As System.Windows.Forms.CheckBox
    Friend WithEvents chkFailure As System.Windows.Forms.CheckBox
    Friend WithEvents tlpShareContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblXml As System.Windows.Forms.Label
    Friend WithEvents btnXml As System.Windows.Forms.Button
    Friend WithEvents lblXmlPath As System.Windows.Forms.Label
    Friend WithEvents picHelpSetupShare As System.Windows.Forms.PictureBox
    Friend WithEvents lblShareTitle As System.Windows.Forms.Label
    Friend WithEvents chkXml As System.Windows.Forms.CheckBox
    Friend WithEvents btnBrwsFolder As System.Windows.Forms.Button
    Friend WithEvents lblFolder As System.Windows.Forms.Label
    Friend WithEvents lblSelFolder As System.Windows.Forms.Label
    Friend WithEvents tpRating As System.Windows.Forms.TabPage
    Friend WithEvents tlpRatingContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpTuneUp As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCurPendTune As System.Windows.Forms.Label
    Friend WithEvents lnkResetOfflUnc As hdd_guardian.NewLink
    Friend WithEvents lblErrorsTune As System.Windows.Forms.Label
    Friend WithEvents lblOfflUncTune As System.Windows.Forms.Label
    Friend WithEvents lnkResetCurPending As hdd_guardian.NewLink
    Friend WithEvents numErrors As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCurPend As System.Windows.Forms.NumericUpDown
    Friend WithEvents lnkResetErrors As hdd_guardian.NewLink
    Friend WithEvents numOfflUnc As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkTuneUp As System.Windows.Forms.CheckBox
    Friend WithEvents picHelpSetupRating As System.Windows.Forms.PictureBox
    Friend WithEvents lblRatingTitle As System.Windows.Forms.Label
    Friend WithEvents chkRating As System.Windows.Forms.CheckBox
    Friend WithEvents HorizontalLine6 As hdd_guardian.HorizontalLine
    Friend WithEvents robGeneral As hdd_guardian.RibbonOptionButton
    Friend WithEvents robDetection As hdd_guardian.RibbonOptionButton
    Friend WithEvents robTranslation As hdd_guardian.RibbonOptionButton
    Friend WithEvents robMailAlerts As hdd_guardian.RibbonOptionButton
    Friend WithEvents robUpdate As hdd_guardian.RibbonOptionButton
    Friend WithEvents HorizontalLine7 As hdd_guardian.HorizontalLine
    Friend WithEvents lblStartup As System.Windows.Forms.Label
    Friend WithEvents lblBehaviour As System.Windows.Forms.Label
    Friend WithEvents lblUpdates As System.Windows.Forms.Label
    Friend WithEvents lblFahrenheit As System.Windows.Forms.Label
    Friend WithEvents robMonitoring As hdd_guardian.RibbonOptionButton
    Friend WithEvents robWarnings As hdd_guardian.RibbonOptionButton
    Friend WithEvents robShare As hdd_guardian.RibbonOptionButton
    Friend WithEvents robRating As hdd_guardian.RibbonOptionButton
    Friend WithEvents lblHdd As System.Windows.Forms.Label
    Friend WithEvents lblSsd As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine8 As hdd_guardian.HorizontalLine
    Friend WithEvents lblParamToMonitor As System.Windows.Forms.Label
    Friend WithEvents chkSandForceChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkIndilinxChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkSamsungChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkIntelChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkMicronChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkReallSectCtChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkSpinRetryCtChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkTempChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkReallEvCtChng As System.Windows.Forms.CheckBox
    Friend WithEvents lblHddChange As System.Windows.Forms.Label
    Friend WithEvents lblSsdChange As System.Windows.Forms.Label
    Friend WithEvents chkCurPenSectChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkOfflUncChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkSoftReadErrChng As System.Windows.Forms.CheckBox
    Friend WithEvents chkDiskShiftChng As System.Windows.Forms.CheckBox
    Friend WithEvents lnkHddChngInvert As hdd_guardian.NewLink
    Friend WithEvents lnkSsdChngInvert As hdd_guardian.NewLink
    Friend WithEvents HorizontalLine9 As hdd_guardian.HorizontalLine
    Friend WithEvents lblSharing As System.Windows.Forms.Label
    Friend WithEvents lblXmlCreate As System.Windows.Forms.Label
    Friend WithEvents lblGeneric As System.Windows.Forms.Label
    Friend WithEvents tlpTempThreshold As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkCustomTemp As System.Windows.Forms.CheckBox
    Friend WithEvents numTemp As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTemp As System.Windows.Forms.Label
    Friend WithEvents lblGenericChange As System.Windows.Forms.Label
    Friend WithEvents chkCsmi As System.Windows.Forms.CheckBox
    Friend WithEvents HorizontalLine5 As hdd_guardian.HorizontalLine
    Friend WithEvents optAutomatic As System.Windows.Forms.RadioButton
    Friend WithEvents optCustom As System.Windows.Forms.RadioButton
    Friend WithEvents chkRememberSize As System.Windows.Forms.CheckBox
    Friend WithEvents tlpWhenSendMail As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSendMailWhen As System.Windows.Forms.Label
    Friend WithEvents chkMailDeviceFail As System.Windows.Forms.CheckBox
    Friend WithEvents chkMailExcessiveTemp As System.Windows.Forms.CheckBox
    Friend WithEvents chkMailReliabilityDown As System.Windows.Forms.CheckBox
    Friend WithEvents tlpParamChange As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RibbonHorizontalSeparator1 As hdd_guardian.RibbonHorizontalSeparator
    Friend WithEvents lblSmartctl As System.Windows.Forms.Label
    Friend WithEvents robTolerance As hdd_guardian.RibbonOptionButton
    Friend WithEvents tpTolerance As System.Windows.Forms.TabPage
    Friend WithEvents tlpToleranceContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flwTolerance As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbNormal As System.Windows.Forms.RadioButton
    Friend WithEvents lblNormal As System.Windows.Forms.Label
    Friend WithEvents rbConservative As System.Windows.Forms.RadioButton
    Friend WithEvents lblConservative As System.Windows.Forms.Label
    Friend WithEvents rbVeryPermissive As System.Windows.Forms.RadioButton
    Friend WithEvents lblVeryPermissive As System.Windows.Forms.Label
    Friend WithEvents lblInfoTolerance As System.Windows.Forms.Label
    Friend WithEvents chkTolerance As System.Windows.Forms.CheckBox
    Friend WithEvents HorizontalLine10 As hdd_guardian.HorizontalLine
    Friend WithEvents picHelpSetupTolerance As System.Windows.Forms.PictureBox
    Friend WithEvents lblToleranceTitle As System.Windows.Forms.Label
    Friend WithEvents lblDebug As System.Windows.Forms.Label
    Friend WithEvents chkDebug As System.Windows.Forms.CheckBox
    Friend WithEvents tlpBehaviour As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpCustomServer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCustomMail As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtCustomMail As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents chkSsl As System.Windows.Forms.CheckBox
    Friend WithEvents txtSmtp As System.Windows.Forms.TextBox
    Friend WithEvents lblSmtp As System.Windows.Forms.Label
    Friend WithEvents tlpStartup As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents tlpLanguageInfo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblTranslator As System.Windows.Forms.Label
    Friend WithEvents lblVersionValue As System.Windows.Forms.Label
    Friend WithEvents lblTranslatorValue As System.Windows.Forms.Label
    Friend WithEvents tlpNeedRestart As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picNeedRestart As System.Windows.Forms.PictureBox
    Friend WithEvents lblNeedRestart As System.Windows.Forms.Label
    Friend WithEvents chkInfoPanel As System.Windows.Forms.CheckBox
    Friend WithEvents robAddDevices As hdd_guardian.RibbonOptionButton
    Friend WithEvents tpAddDevices As System.Windows.Forms.TabPage
    Friend WithEvents tlpAddDevices As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picHelpSetupAddDevice As System.Windows.Forms.PictureBox
    Friend WithEvents lblAddDevices As System.Windows.Forms.Label
    Friend WithEvents lblInfoAddDevices As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine11 As hdd_guardian.HorizontalLine
    Friend WithEvents tlpAddDevice As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAddDevice As System.Windows.Forms.Button
    Friend WithEvents tlpDevicesList As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lvwAdditionalDevices As System.Windows.Forms.ListView
    Friend WithEvents chDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRemoveDevice As System.Windows.Forms.Button
    Friend WithEvents chCommand As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblSetMailServer As System.Windows.Forms.Label
    Friend WithEvents lblMailDestination As System.Windows.Forms.Label
    Friend WithEvents tlpUpdates As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkLanguageUpdates As System.Windows.Forms.CheckBox
    Friend WithEvents tlpReport As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents chkReport As System.Windows.Forms.CheckBox
    Friend WithEvents cboDays As System.Windows.Forms.ComboBox
    Friend WithEvents lblLanguageInfo As System.Windows.Forms.Label
    Friend WithEvents robSmartctl As hdd_guardian.RibbonOptionButton
    Friend WithEvents tpSmartctl As System.Windows.Forms.TabPage
    Friend WithEvents tlpSmartctl As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSmartctlFolder As System.Windows.Forms.Label
    Friend WithEvents btnBrwsSmartctl As System.Windows.Forms.Button
    Friend WithEvents lblSmartctlPath As System.Windows.Forms.Label
    Friend WithEvents picHelpSmartctl As System.Windows.Forms.PictureBox
    Friend WithEvents lblSmartctlVersion As System.Windows.Forms.Label
    Friend WithEvents chkSmartctl As System.Windows.Forms.CheckBox
    Friend WithEvents HorizontalLine12 As hdd_guardian.HorizontalLine
    Friend WithEvents nlSendReport As hdd_guardian.NewLink
End Class
