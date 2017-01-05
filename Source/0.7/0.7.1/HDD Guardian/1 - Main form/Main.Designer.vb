<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Dim MenuItem4 As System.Windows.Forms.MenuItem
        Dim MenuItem2 As System.Windows.Forms.MenuItem
        Dim MenuItem5 As System.Windows.Forms.MenuItem
        Dim tlpRibbonMenu As System.Windows.Forms.TableLayoutPanel
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim flwWarnings As System.Windows.Forms.FlowLayoutPanel
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Phisycal", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("External", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Virtual", System.Windows.Forms.HorizontalAlignment.Left)
        Dim RibbonHorizontalSeparator2 As hdd_guardian.RibbonHorizontalSeparator
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint1 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42513.9506944444R, 27.0R)
        Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42514.939525463R, 27.0R)
        Dim DataPoint3 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42514.9499421296R, 28.0R)
        Dim DataPoint4 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42514.9603819444R, 30.0R)
        Dim DataPoint5 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42514.970775463R, 31.0R)
        Dim DataPoint6 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42515.9306481481R, 2.0R)
        Dim DataPoint7 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42515.94R, 27.0R)
        Dim DataPoint8 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42515.9528125R, 30.0R)
        Dim DataPoint9 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42515.9632291667R, 31.0R)
        Dim DataPoint10 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42515.9840625R, 32.0R)
        Dim DataPoint11 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42516.0673958333R, 33.0R)
        Dim DataPoint12 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42519.4775231481R, 31.0R)
        Dim DataPoint13 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42519.6805555556R, 29.0R)
        Dim DataPoint14 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42519.6909722222R, 31.0R)
        Dim DataPoint15 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42519.701400463R, 32.0R)
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint16 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42503.0R, 55.0R)
        Dim DataPoint17 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(42521.0R, 55.0R)
        Dim tlpAam As System.Windows.Forms.TableLayoutPanel
        Dim tlpAamLoud As System.Windows.Forms.TableLayoutPanel
        Dim tlpApm As System.Windows.Forms.TableLayoutPanel
        Dim tlpStandby As System.Windows.Forms.TableLayoutPanel
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("grpErrorCount", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("grpRead", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup6 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("grpWrite", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup7 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("grpVerify", System.Windows.Forms.HorizontalAlignment.Left)
        Me.tlpMessages = New System.Windows.Forms.TableLayoutPanel()
        Me.picAdmin = New System.Windows.Forms.PictureBox()
        Me.picNewVersion = New System.Windows.Forms.PictureBox()
        Me.ttMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.niTrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.mnuGuide = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrFlushMem = New System.Windows.Forms.Timer(Me.components)
        Me.tmrTest = New System.Windows.Forms.Timer(Me.components)
        Me.dlgFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.tmrRefreshExt = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRefreshVirtual = New System.Windows.Forms.Timer(Me.components)
        Me.cmTrayIcon = New System.Windows.Forms.ContextMenu()
        Me.mnuRestoreTray = New System.Windows.Forms.MenuItem()
        Me.mnuExitTray = New System.Windows.Forms.MenuItem()
        Me.cmDevices = New System.Windows.Forms.ContextMenu()
        Me.mnuTitle = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuRefreshSel = New System.Windows.Forms.MenuItem()
        Me.mnuRefreshAll = New System.Windows.Forms.MenuItem()
        Me.mnuSearchUsb = New System.Windows.Forms.MenuItem()
        Me.mnuAddVirtualDev = New System.Windows.Forms.MenuItem()
        Me.mnuRemoveVirtualDev = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.mnuTrayIcon = New System.Windows.Forms.MenuItem()
        Me.mnuTrayTemperature = New System.Windows.Forms.MenuItem()
        Me.mnuTrayLife = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuInfoPanel = New System.Windows.Forms.MenuItem()
        Me.mnuSharing = New System.Windows.Forms.MenuItem()
        Me.mnuShareThis = New System.Windows.Forms.MenuItem()
        Me.mnuSharingFolder = New System.Windows.Forms.MenuItem()
        Me.mnuXml = New System.Windows.Forms.MenuItem()
        Me.mnuXmlCreate = New System.Windows.Forms.MenuItem()
        Me.mnuXmlFolder = New System.Windows.Forms.MenuItem()
        Me.mnuDeviceImage = New System.Windows.Forms.MenuItem()
        Me.mnuDeviceImageSet = New System.Windows.Forms.MenuItem()
        Me.mnuDeviceImageRemove = New System.Windows.Forms.MenuItem()
        Me.cmFile = New System.Windows.Forms.ContextMenu()
        Me.mnuReloadDevices = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.mnuUpdateDatabase = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.mnuSettings = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.cmDeviceImage = New System.Windows.Forms.ContextMenu()
        Me.mnuProfessional = New System.Windows.Forms.MenuItem()
        Me.mnuGamer = New System.Windows.Forms.MenuItem()
        Me.mnuLaptop = New System.Windows.Forms.MenuItem()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.tslSmartctl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmTask = New System.Windows.Forms.ContextMenu()
        Me.mnuTaskNew = New System.Windows.Forms.MenuItem()
        Me.mnuTaskEdit = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.mnuTaskDelete = New System.Windows.Forms.MenuItem()
        Me.MenuItem14 = New System.Windows.Forms.MenuItem()
        Me.mnuTaskTrash = New System.Windows.Forms.MenuItem()
        Me.cmLog = New System.Windows.Forms.ContextMenu()
        Me.mnuCopyLog = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.mnuCopyAllLog = New System.Windows.Forms.MenuItem()
        Me.htcMain = New hdd_guardian.HeadlessTabControl()
        Me.tpOverview = New System.Windows.Forms.TabPage()
        Me.tlpOverview = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpDeviceInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.tabSidePanel = New System.Windows.Forms.TabControl()
        Me.tpGeneral = New System.Windows.Forms.TabPage()
        Me.tlpGeneral = New System.Windows.Forms.TableLayoutPanel()
        Me.lblInformation = New System.Windows.Forms.Label()
        Me.HorizontalLine10 = New hdd_guardian.HorizontalLine()
        Me.tlpGeneralInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.lnkManufacturer = New hdd_guardian.NewLink()
        Me.lblModelValue = New System.Windows.Forms.Label()
        Me.lblSerial = New System.Windows.Forms.Label()
        Me.lblSerialValue = New System.Windows.Forms.Label()
        Me.exlWwnId = New hdd_guardian.ExtendedLabel()
        Me.lblWwnIdValue = New System.Windows.Forms.Label()
        Me.exlFirmware = New hdd_guardian.ExtendedLabel()
        Me.lblFirmwareValue = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblSizeValue = New System.Windows.Forms.Label()
        Me.exlSectorBlock = New hdd_guardian.ExtendedLabel()
        Me.lblSectorBlockValue = New System.Windows.Forms.Label()
        Me.lblRotationRate = New System.Windows.Forms.Label()
        Me.lblRotationRateValue = New System.Windows.Forms.Label()
        Me.lblFactoryForm = New System.Windows.Forms.Label()
        Me.lblFactoryFormValue = New System.Windows.Forms.Label()
        Me.lblInterface = New System.Windows.Forms.Label()
        Me.lblInterfaceValue = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblLocationValue = New System.Windows.Forms.Label()
        Me.lblLetter = New System.Windows.Forms.Label()
        Me.lblLetterValue = New System.Windows.Forms.Label()
        Me.lblSmartInfo = New System.Windows.Forms.Label()
        Me.HorizontalLine11 = New hdd_guardian.HorizontalLine()
        Me.lblSmartInfoValue = New System.Windows.Forms.Label()
        Me.tlpDatabase = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDatabaseInfo = New System.Windows.Forms.Label()
        Me.lblDatabaseInfoValue = New System.Windows.Forms.Label()
        Me.HorizontalLine15 = New hdd_guardian.HorizontalLine()
        Me.lnkUpdateDatabase = New hdd_guardian.NewLink()
        Me.tlpWarnings = New System.Windows.Forms.TableLayoutPanel()
        Me.lblWarningValue = New System.Windows.Forms.Label()
        Me.lnkWeb1 = New hdd_guardian.NewLink()
        Me.lnkWeb2 = New hdd_guardian.NewLink()
        Me.lnkWeb3 = New hdd_guardian.NewLink()
        Me.lblWarnings = New System.Windows.Forms.Label()
        Me.HorizontalLine16 = New hdd_guardian.HorizontalLine()
        Me.tpHealth = New System.Windows.Forms.TabPage()
        Me.tlpHealth = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpRating = New System.Windows.Forms.TableLayoutPanel()
        Me.lblReliabilityRating = New System.Windows.Forms.Label()
        Me.HorizontalLine18 = New hdd_guardian.HorizontalLine()
        Me.tlpRatingTable = New System.Windows.Forms.TableLayoutPanel()
        Me.picOverall = New System.Windows.Forms.PictureBox()
        Me.lblRating4 = New System.Windows.Forms.Label()
        Me.lblRating4Value = New System.Windows.Forms.Label()
        Me.lblRating3 = New System.Windows.Forms.Label()
        Me.lblRating3Value = New System.Windows.Forms.Label()
        Me.lblRating2 = New System.Windows.Forms.Label()
        Me.picRating4 = New System.Windows.Forms.PictureBox()
        Me.picRating2 = New System.Windows.Forms.PictureBox()
        Me.picRating3 = New System.Windows.Forms.PictureBox()
        Me.lblRating2Value = New System.Windows.Forms.Label()
        Me.picRating1 = New System.Windows.Forms.PictureBox()
        Me.lblRating1Value = New System.Windows.Forms.Label()
        Me.lblRating1 = New System.Windows.Forms.Label()
        Me.lblOverall = New System.Windows.Forms.Label()
        Me.lblOverallRating = New System.Windows.Forms.Label()
        Me.tlpSummary = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTemp = New System.Windows.Forms.Label()
        Me.lblTempValue = New System.Windows.Forms.Label()
        Me.lblErrors = New System.Windows.Forms.Label()
        Me.lblBadSectors = New System.Windows.Forms.Label()
        Me.lblHealth = New System.Windows.Forms.Label()
        Me.lblHealthValue = New System.Windows.Forms.Label()
        Me.lblLastTestValue = New System.Windows.Forms.Label()
        Me.lblLastTest = New System.Windows.Forms.Label()
        Me.lblLastUpdate = New System.Windows.Forms.Label()
        Me.lblLastUpdateValue = New System.Windows.Forms.Label()
        Me.lblRemainingLife = New System.Windows.Forms.Label()
        Me.lblRemainingLifeValue = New System.Windows.Forms.Label()
        Me.lblWorkTime = New System.Windows.Forms.Label()
        Me.lblWorkTimeValue = New System.Windows.Forms.Label()
        Me.exlBadSectors = New hdd_guardian.ExtendedLabel()
        Me.exlErrors = New hdd_guardian.ExtendedLabel()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.HorizontalLine17 = New hdd_guardian.HorizontalLine()
        Me.picManufacturer = New System.Windows.Forms.PictureBox()
        Me.lvwDevices = New System.Windows.Forms.ListView()
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rspOverview = New hdd_guardian.MimicExplorer.RibbonSplitter()
        Me.tlpMenuItems = New System.Windows.Forms.TableLayoutPanel()
        Me.mrbUpdateAll = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.picOverviewHelp = New System.Windows.Forms.PictureBox()
        Me.mrcSidePanel = New hdd_guardian.MimicExplorer.RibbonCheck()
        Me.mrbAddVirtual = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.mrbRescanUsb = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.RibbonVerticalSeparator7 = New hdd_guardian.RibbonVerticalSeparator()
        Me.tpManage = New System.Windows.Forms.TabPage()
        Me.tlpManage = New System.Windows.Forms.TableLayoutPanel()
        Me.htcManage = New hdd_guardian.HeadlessTabControl()
        Me.tpInfo = New System.Windows.Forms.TabPage()
        Me.htcInfo = New hdd_guardian.HeadlessTabControl()
        Me.tpAtaSmartAttributes = New System.Windows.Forms.TabPage()
        Me.tlpAttributes = New System.Windows.Forms.TableLayoutPanel()
        Me.lvwSmart = New System.Windows.Forms.ListView()
        Me.chID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAttribute = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chRawValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chValues = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlAttribuesInfo = New System.Windows.Forms.Panel()
        Me.tlpAttributeDetails = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMeaning = New System.Windows.Forms.Label()
        Me.lblDataStructure = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblPrefailure = New System.Windows.Forms.Label()
        Me.lblOnline = New System.Windows.Forms.Label()
        Me.lblSpeed = New System.Windows.Forms.Label()
        Me.lblErrRate = New System.Windows.Forms.Label()
        Me.lblEvCount = New System.Windows.Forms.Label()
        Me.lblSelfPres = New System.Windows.Forms.Label()
        Me.lblFlags = New System.Windows.Forms.Label()
        Me.tpEvents = New System.Windows.Forms.TabPage()
        Me.tlpChartContent = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNoEvents = New System.Windows.Forms.Label()
        Me.tlpDisplayEvent = New System.Windows.Forms.TableLayoutPanel()
        Me.lvwEvents = New System.Windows.Forms.ListView()
        Me.chAttrLog = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTotalEvents = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mcLog = New System.Windows.Forms.MonthCalendar()
        Me.lblDisplay = New System.Windows.Forms.Label()
        Me.tlpLogCmd = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.RibbonHorizontalSeparator4 = New hdd_guardian.RibbonHorizontalSeparator()
        Me.optEntire = New System.Windows.Forms.RadioButton()
        Me.optSelection = New System.Windows.Forms.RadioButton()
        Me.RibbonHorizontalSeparator7 = New hdd_guardian.RibbonHorizontalSeparator()
        Me.tlpEventChart = New System.Windows.Forms.TableLayoutPanel()
        Me.tabLog = New System.Windows.Forms.TabControl()
        Me.tpLogEvents = New System.Windows.Forms.TabPage()
        Me.lvwLog = New System.Windows.Forms.ListView()
        Me.chDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFrom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chVariation = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpLogChart = New System.Windows.Forms.TabPage()
        Me.chrChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tlpChartOptions = New System.Windows.Forms.TableLayoutPanel()
        Me.chkChartValues = New System.Windows.Forms.CheckBox()
        Me.lblPointSize = New System.Windows.Forms.Label()
        Me.numPointSize = New System.Windows.Forms.NumericUpDown()
        Me.lblNoPeriodEvents = New System.Windows.Forms.Label()
        Me.tpTemperatures = New System.Windows.Forms.TabPage()
        Me.tlpTemperatures = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpTempGraphs = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLifeTimeMax = New System.Windows.Forms.Label()
        Me.lblCurrentTemp = New System.Windows.Forms.Label()
        Me.lblCycleMin = New System.Windows.Forms.Label()
        Me.lblMin = New System.Windows.Forms.Label()
        Me.lblMax = New System.Windows.Forms.Label()
        Me.lblCycleMax = New System.Windows.Forms.Label()
        Me.lblRecommendedMax = New System.Windows.Forms.Label()
        Me.lblLimitMax = New System.Windows.Forms.Label()
        Me.lblCycle = New System.Windows.Forms.Label()
        Me.lblLifeTime = New System.Windows.Forms.Label()
        Me.lblLifeTimeMin = New System.Windows.Forms.Label()
        Me.lblRecommendedMin = New System.Windows.Forms.Label()
        Me.lblLimitMin = New System.Windows.Forms.Label()
        Me.lblRecommended = New System.Windows.Forms.Label()
        Me.lblLimit = New System.Windows.Forms.Label()
        Me.lblCurrentTempValue = New System.Windows.Forms.Label()
        Me.tbCycle = New hdd_guardian.TemperaturesBar()
        Me.tbLifeTime = New hdd_guardian.TemperaturesBar()
        Me.tbRecommended = New hdd_guardian.TemperaturesBar()
        Me.tbLimit = New hdd_guardian.TemperaturesBar()
        Me.lblZero = New System.Windows.Forms.Label()
        Me.lblTempMeans = New System.Windows.Forms.Label()
        Me.tlpTempMeans = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLimitValue = New System.Windows.Forms.Label()
        Me.lblLimitMean = New System.Windows.Forms.Label()
        Me.lblCycleMeans = New System.Windows.Forms.Label()
        Me.lblLifeTimeMean = New System.Windows.Forms.Label()
        Me.lblRecommendedMean = New System.Windows.Forms.Label()
        Me.lblCycleValue = New System.Windows.Forms.Label()
        Me.lblLifeTimeValue = New System.Windows.Forms.Label()
        Me.lblRecommendedValue = New System.Windows.Forms.Label()
        Me.tpSetup = New System.Windows.Forms.TabPage()
        Me.htcSetup = New hdd_guardian.HeadlessTabControl()
        Me.tpAtaSmartSetup = New System.Windows.Forms.TabPage()
        Me.tlpAtaSmart = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSmart = New System.Windows.Forms.Label()
        Me.lblAdminSmart = New System.Windows.Forms.Label()
        Me.lblOfflineTest = New System.Windows.Forms.Label()
        Me.lblAttrAutosave = New System.Windows.Forms.Label()
        Me.chkEnableSmart = New System.Windows.Forms.CheckBox()
        Me.chkEnableOffline = New System.Windows.Forms.CheckBox()
        Me.chkEnableAutosave = New System.Windows.Forms.CheckBox()
        Me.HorizontalLine2 = New hdd_guardian.HorizontalLine()
        Me.tpScsiSmartSetup = New System.Windows.Forms.TabPage()
        Me.tlpScsiSmart = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAdminScsiSmart = New System.Windows.Forms.Label()
        Me.lblScsiGltsd = New System.Windows.Forms.Label()
        Me.lblScsiRCache = New System.Windows.Forms.Label()
        Me.chkScsiRCache = New System.Windows.Forms.CheckBox()
        Me.chkScsiWCache = New System.Windows.Forms.CheckBox()
        Me.lblScsiWCache = New System.Windows.Forms.Label()
        Me.chkScsiSmart = New System.Windows.Forms.CheckBox()
        Me.chkScsiGltsd = New System.Windows.Forms.CheckBox()
        Me.lblScsiSmart = New System.Windows.Forms.Label()
        Me.HorizontalLine13 = New hdd_guardian.HorizontalLine()
        Me.tpAtaAam = New System.Windows.Forms.TabPage()
        Me.tlpAtaAam = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAamValue = New System.Windows.Forms.Label()
        Me.lblAamRecommended = New System.Windows.Forms.Label()
        Me.lnkSetAam = New hdd_guardian.NewLink()
        Me.lnkSetRecommended = New hdd_guardian.NewLink()
        Me.lnkUndoAam = New hdd_guardian.NewLink()
        Me.trkAam = New System.Windows.Forms.TrackBar()
        Me.lblQuiet = New System.Windows.Forms.Label()
        Me.lblLoudest = New System.Windows.Forms.Label()
        Me.HorizontalLine3 = New hdd_guardian.HorizontalLine()
        Me.lblInfoAam = New System.Windows.Forms.Label()
        Me.tlpAamWaitMessage = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAamWaitMessage = New System.Windows.Forms.Label()
        Me.picLoaderAam = New System.Windows.Forms.PictureBox()
        Me.tpAtaApm = New System.Windows.Forms.TabPage()
        Me.tlpApmContent = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpApmWaitMessage = New System.Windows.Forms.TableLayoutPanel()
        Me.lblApmWaitMessage = New System.Windows.Forms.Label()
        Me.picLoaderApm = New System.Windows.Forms.PictureBox()
        Me.trkApm = New System.Windows.Forms.TrackBar()
        Me.lblApmValue = New System.Windows.Forms.Label()
        Me.lnkSetApm = New hdd_guardian.NewLink()
        Me.lnkUndoApm = New hdd_guardian.NewLink()
        Me.HorizontalLine4 = New hdd_guardian.HorizontalLine()
        Me.lblInfoApm = New System.Windows.Forms.Label()
        Me.tpAtaStandby = New System.Windows.Forms.TabPage()
        Me.tlpStandbyContent = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpStandbyWaitMessage = New System.Windows.Forms.TableLayoutPanel()
        Me.lblStandbyWaitMessage = New System.Windows.Forms.Label()
        Me.picLoaderStandby = New System.Windows.Forms.PictureBox()
        Me.lnkSetStandby = New hdd_guardian.NewLink()
        Me.lblStandbyValue = New System.Windows.Forms.Label()
        Me.lnkUndoStandby = New hdd_guardian.NewLink()
        Me.trkStandby = New System.Windows.Forms.TrackBar()
        Me.HorizontalLine5 = New hdd_guardian.HorizontalLine()
        Me.lblInfoStandby = New System.Windows.Forms.Label()
        Me.tpAtaReadWrite = New System.Windows.Forms.TabPage()
        Me.tlpOtherContent = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpWaitRWMessage = New System.Windows.Forms.TableLayoutPanel()
        Me.lblWaitRWMessage = New System.Windows.Forms.Label()
        Me.picLoaderRW = New System.Windows.Forms.PictureBox()
        Me.flwOtherFeatures = New System.Windows.Forms.FlowLayoutPanel()
        Me.chkCache = New System.Windows.Forms.CheckBox()
        Me.lblCacheInfo = New System.Windows.Forms.Label()
        Me.chkCacheReorder = New System.Windows.Forms.CheckBox()
        Me.lblCacheReorderInfo = New System.Windows.Forms.Label()
        Me.chkLookAhead = New System.Windows.Forms.CheckBox()
        Me.lblLookAheadInfo = New System.Windows.Forms.Label()
        Me.tpErrorsTests = New System.Windows.Forms.TabPage()
        Me.htcErrorsTests = New hdd_guardian.HeadlessTabControl()
        Me.tpAtaErrors = New System.Windows.Forms.TabPage()
        Me.tlpAtaErrorsContent = New System.Windows.Forms.TableLayoutPanel()
        Me.lblErrLogVer = New System.Windows.Forms.Label()
        Me.tlpErrorList = New System.Windows.Forms.TableLayoutPanel()
        Me.lvwErrors = New System.Windows.Forms.ListView()
        Me.chErrors = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tlpErrorDetails = New System.Windows.Forms.TableLayoutPanel()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.lblErrorDescTitle = New System.Windows.Forms.Label()
        Me.lblNoError = New System.Windows.Forms.Label()
        Me.tpAtaTests = New System.Windows.Forms.TabPage()
        Me.tlpTestsContent = New System.Windows.Forms.TableLayoutPanel()
        Me.lvwSelfTest = New System.Windows.Forms.ListView()
        Me.chNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTestType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTestStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chRemaining = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAge = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFirstError = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tlpSelfTests = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNoSelfTests = New System.Windows.Forms.Label()
        Me.lblSelfTests = New System.Windows.Forms.Label()
        Me.tpAtaRunTest = New System.Windows.Forms.TabPage()
        Me.tlpAtaTestContent = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpTestProgress = New System.Windows.Forms.TableLayoutPanel()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.flwProgress = New System.Windows.Forms.FlowLayoutPanel()
        Me.prbTestProgress = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblExtimatedEnd = New System.Windows.Forms.Label()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.lblInfoTest = New System.Windows.Forms.Label()
        Me.HorizontalLine8 = New hdd_guardian.HorizontalLine()
        Me.flwTests = New System.Windows.Forms.FlowLayoutPanel()
        Me.optOffline = New System.Windows.Forms.RadioButton()
        Me.lblOfflineDuration = New System.Windows.Forms.Label()
        Me.lblOfflineInfo = New System.Windows.Forms.Label()
        Me.optShort = New System.Windows.Forms.RadioButton()
        Me.lblShortDuration = New System.Windows.Forms.Label()
        Me.lblShortInfo = New System.Windows.Forms.Label()
        Me.optLong = New System.Windows.Forms.RadioButton()
        Me.lblLongDuration = New System.Windows.Forms.Label()
        Me.lblLongInfo = New System.Windows.Forms.Label()
        Me.optConveyance = New System.Windows.Forms.RadioButton()
        Me.lblConveyanceDuration = New System.Windows.Forms.Label()
        Me.lblConveyanceInfo = New System.Windows.Forms.Label()
        Me.tpScsiErrors = New System.Windows.Forms.TabPage()
        Me.tlpScsiErrorsContent = New System.Windows.Forms.TableLayoutPanel()
        Me.lblScsiNoErrors = New System.Windows.Forms.Label()
        Me.lvwScsiErrors = New System.Windows.Forms.ListView()
        Me.chScsiErrorItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScsiErrorItemValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpScsiTests = New System.Windows.Forms.TabPage()
        Me.tlpScsiTestsContent = New System.Windows.Forms.TableLayoutPanel()
        Me.lblScsiTestCounter = New System.Windows.Forms.Label()
        Me.lvwScsiTests = New System.Windows.Forms.ListView()
        Me.chScsiNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScsiTest = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScsiStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScsiSegment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScsiLifetime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScsiFirstErr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScsiSK = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScsiASK = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScsiASQ = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpScsiRunTest = New System.Windows.Forms.TabPage()
        Me.tlpScsiTestContent = New System.Windows.Forms.TableLayoutPanel()
        Me.lblScsiInfoTest = New System.Windows.Forms.Label()
        Me.tlpScsiTest = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlScsiTestRun = New System.Windows.Forms.Panel()
        Me.lblScsiExtimatedEnd = New System.Windows.Forms.Label()
        Me.prbScsiTestProgress = New System.Windows.Forms.ProgressBar()
        Me.lblScsiProgress = New System.Windows.Forms.Label()
        Me.lblScsiTest = New System.Windows.Forms.Label()
        Me.btnScsiStop = New System.Windows.Forms.Button()
        Me.btnScsiRun = New System.Windows.Forms.Button()
        Me.HorizontalLine14 = New hdd_guardian.HorizontalLine()
        Me.tpSmartctl = New System.Windows.Forms.TabPage()
        Me.htcSmartctl = New hdd_guardian.HeadlessTabControl()
        Me.tpOutput = New System.Windows.Forms.TabPage()
        Me.tlpOutput = New System.Windows.Forms.TableLayoutPanel()
        Me.txtReport = New System.Windows.Forms.TextBox()
        Me.btnSaveOutput = New System.Windows.Forms.Button()
        Me.tpAdvanced = New System.Windows.Forms.TabPage()
        Me.tlpAdvanced = New System.Windows.Forms.TableLayoutPanel()
        Me.HorizontalLine12 = New hdd_guardian.HorizontalLine()
        Me.lblAdminAdvanced = New System.Windows.Forms.Label()
        Me.tabAdvanced = New System.Windows.Forms.TabControl()
        Me.tpPower = New System.Windows.Forms.TabPage()
        Me.tlpPowerModeContent = New System.Windows.Forms.TableLayoutPanel()
        Me.flwPowerMode = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbNever = New System.Windows.Forms.RadioButton()
        Me.lblNever = New System.Windows.Forms.Label()
        Me.rbSleep = New System.Windows.Forms.RadioButton()
        Me.lblSleep = New System.Windows.Forms.Label()
        Me.rbStandby = New System.Windows.Forms.RadioButton()
        Me.lblStandby = New System.Windows.Forms.Label()
        Me.rbIdle = New System.Windows.Forms.RadioButton()
        Me.lblIdle = New System.Windows.Forms.Label()
        Me.lblPowerInfo = New System.Windows.Forms.Label()
        Me.chkPowerMode = New System.Windows.Forms.CheckBox()
        Me.tpRemap = New System.Windows.Forms.TabPage()
        Me.tlpRemapContent = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlAttributes = New System.Windows.Forms.Panel()
        Me.lvwAttrFormat = New System.Windows.Forms.ListView()
        Me.chAttrID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAttrFormat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAttrName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tlpButtons = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.lblRemapInfo = New System.Windows.Forms.Label()
        Me.chkAttributes = New System.Windows.Forms.CheckBox()
        Me.tpFirmware = New System.Windows.Forms.TabPage()
        Me.tlpFirmwareContent = New System.Windows.Forms.TableLayoutPanel()
        Me.flwFirmware = New System.Windows.Forms.FlowLayoutPanel()
        Me.cboFirmware = New System.Windows.Forms.ComboBox()
        Me.lblFirmwareDebug = New System.Windows.Forms.Label()
        Me.chkFixSwap = New System.Windows.Forms.CheckBox()
        Me.lblFixSwap = New System.Windows.Forms.Label()
        Me.chkNoLogDir = New System.Windows.Forms.CheckBox()
        Me.lblNoLogDir = New System.Windows.Forms.Label()
        Me.chkXErrorLba = New System.Windows.Forms.CheckBox()
        Me.lblXErrorLba = New System.Windows.Forms.Label()
        Me.lblFirmwareDebugInfo = New System.Windows.Forms.Label()
        Me.chkFirmware = New System.Windows.Forms.CheckBox()
        Me.tpAsmedia = New System.Windows.Forms.TabPage()
        Me.tlpAsmedia = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAsmedia = New System.Windows.Forms.Label()
        Me.chkAsmedia = New System.Windows.Forms.CheckBox()
        Me.tpVersion = New System.Windows.Forms.TabPage()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.pnlSideMenu = New System.Windows.Forms.Panel()
        Me.tlpSideMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.mrrSmartctl = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrAdvanced = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrOutput = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrRunTest = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrTestsLog = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrErrorsLog = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrReadWrite = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrStandby = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrApm = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrAam = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrTemperatures = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrEvents = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.mrrAttributes = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.lblSetup = New System.Windows.Forms.Label()
        Me.lblSmartctl = New System.Windows.Forms.Label()
        Me.mrrSmartSetup = New hdd_guardian.MimicExplorer.RibbonRadio()
        Me.lblErrorsTests = New System.Windows.Forms.Label()
        Me.rspManage = New hdd_guardian.MimicExplorer.RibbonSplitter()
        Me.RibbonHorizontalSeparator3 = New hdd_guardian.RibbonHorizontalSeparator()
        Me.tlpManageMenuContent = New System.Windows.Forms.TableLayoutPanel()
        Me.picManageHelp = New System.Windows.Forms.PictureBox()
        Me.tlpSelDevice = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlComboBorder = New System.Windows.Forms.Panel()
        Me.cboDevices = New System.Windows.Forms.ComboBox()
        Me.mrbReloadDevice = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.mrbLeft = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.mrbRight = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.tpWmiDevices = New System.Windows.Forms.TabPage()
        Me.tlpSystem = New System.Windows.Forms.TableLayoutPanel()
        Me.tvwComputer = New System.Windows.Forms.TreeView()
        Me.rspSystem = New hdd_guardian.MimicExplorer.RibbonSplitter()
        Me.htcSystem = New hdd_guardian.HeadlessTabControl()
        Me.tpHardware = New System.Windows.Forms.TabPage()
        Me.tlpHardware = New System.Windows.Forms.TableLayoutPanel()
        Me.picHardware = New System.Windows.Forms.PictureBox()
        Me.tlpHrwDetails = New System.Windows.Forms.TableLayoutPanel()
        Me.lblHrwBios = New System.Windows.Forms.Label()
        Me.lblHrwMotherboard = New System.Windows.Forms.Label()
        Me.lblHrwProcessor = New System.Windows.Forms.Label()
        Me.lblHrwRam = New System.Windows.Forms.Label()
        Me.picBios = New System.Windows.Forms.PictureBox()
        Me.picMotherboard = New System.Windows.Forms.PictureBox()
        Me.picProcessor = New System.Windows.Forms.PictureBox()
        Me.picRam = New System.Windows.Forms.PictureBox()
        Me.picVideoCard = New System.Windows.Forms.PictureBox()
        Me.lblHrwVideoCard = New System.Windows.Forms.Label()
        Me.lblHrwBiosValue = New System.Windows.Forms.Label()
        Me.lblHrwMotherboardValue = New System.Windows.Forms.Label()
        Me.lblHrwProcessorValue = New System.Windows.Forms.Label()
        Me.lblHrwRamValue = New System.Windows.Forms.Label()
        Me.lblHrwVideoCardValue = New System.Windows.Forms.Label()
        Me.tpDisk = New System.Windows.Forms.TabPage()
        Me.tlpDisk = New System.Windows.Forms.TableLayoutPanel()
        Me.picDisk = New System.Windows.Forms.PictureBox()
        Me.tlpDiskDetails = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDiskSN = New System.Windows.Forms.Label()
        Me.lblDiskSizeValue = New System.Windows.Forms.Label()
        Me.lblDiskPartitionsValue = New System.Windows.Forms.Label()
        Me.lblDiskIndexValue = New System.Windows.Forms.Label()
        Me.lblDiskSNValue = New System.Windows.Forms.Label()
        Me.lblDiskSize = New System.Windows.Forms.Label()
        Me.lblDiskPartitions = New System.Windows.Forms.Label()
        Me.lblDiskIndex = New System.Windows.Forms.Label()
        Me.tpPartition = New System.Windows.Forms.TabPage()
        Me.tlpPartition = New System.Windows.Forms.TableLayoutPanel()
        Me.picPartition = New System.Windows.Forms.PictureBox()
        Me.tlpPartitionDetails = New System.Windows.Forms.TableLayoutPanel()
        Me.lblBootable = New System.Windows.Forms.Label()
        Me.lblPartitionTypeValue = New System.Windows.Forms.Label()
        Me.lblPrimaryPartitionValue = New System.Windows.Forms.Label()
        Me.lblBootPartitionValue = New System.Windows.Forms.Label()
        Me.lblBootableValue = New System.Windows.Forms.Label()
        Me.lblPartitionType = New System.Windows.Forms.Label()
        Me.lblPrimaryPartition = New System.Windows.Forms.Label()
        Me.lblBootPartition = New System.Windows.Forms.Label()
        Me.lblBlocks = New System.Windows.Forms.Label()
        Me.lblBlockSize = New System.Windows.Forms.Label()
        Me.lblPartitionSize = New System.Windows.Forms.Label()
        Me.lblBlocksValue = New System.Windows.Forms.Label()
        Me.lblBlockSizeValue = New System.Windows.Forms.Label()
        Me.lblPartitionSizeValue = New System.Windows.Forms.Label()
        Me.tpLogicalDisk = New System.Windows.Forms.TabPage()
        Me.tlpLogical = New System.Windows.Forms.TableLayoutPanel()
        Me.picLogical = New System.Windows.Forms.PictureBox()
        Me.tlpLogicalDetails = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLogicalSN = New System.Windows.Forms.Label()
        Me.lblLogicalSizeValue = New System.Windows.Forms.Label()
        Me.lblFileSystemValue = New System.Windows.Forms.Label()
        Me.lblLogicalSNValue = New System.Windows.Forms.Label()
        Me.lblLogicalSize = New System.Windows.Forms.Label()
        Me.lblFileSystem = New System.Windows.Forms.Label()
        Me.tlpBenchmark = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpRandom = New System.Windows.Forms.TableLayoutPanel()
        Me.bbReadR = New hdd_guardian.BenchmarkBar()
        Me.bbWriteR = New hdd_guardian.BenchmarkBar()
        Me.lblReadR = New System.Windows.Forms.Label()
        Me.lblWriteR = New System.Windows.Forms.Label()
        Me.tlpRandomMulti = New System.Windows.Forms.TableLayoutPanel()
        Me.bbReadRMulti = New hdd_guardian.BenchmarkBar()
        Me.bbWriteRMulti = New hdd_guardian.BenchmarkBar()
        Me.lblReadRMulti = New System.Windows.Forms.Label()
        Me.lblWriteRMulti = New System.Windows.Forms.Label()
        Me.lblSequentialMulti = New System.Windows.Forms.Label()
        Me.lblRandomMulti = New System.Windows.Forms.Label()
        Me.RibbonVerticalSeparator1 = New hdd_guardian.RibbonVerticalSeparator()
        Me.RibbonVerticalSeparator2 = New hdd_guardian.RibbonVerticalSeparator()
        Me.tlpSequentialMulti = New System.Windows.Forms.TableLayoutPanel()
        Me.bbReadSMulti = New hdd_guardian.BenchmarkBar()
        Me.bbWriteSMulti = New hdd_guardian.BenchmarkBar()
        Me.lblReadSMulti = New System.Windows.Forms.Label()
        Me.lblWriteSMulti = New System.Windows.Forms.Label()
        Me.lblSequential = New System.Windows.Forms.Label()
        Me.lblRandom = New System.Windows.Forms.Label()
        Me.RibbonVerticalSeparator3 = New hdd_guardian.RibbonVerticalSeparator()
        Me.RibbonVerticalSeparator4 = New hdd_guardian.RibbonVerticalSeparator()
        Me.tlpSequential = New System.Windows.Forms.TableLayoutPanel()
        Me.bbReadS = New hdd_guardian.BenchmarkBar()
        Me.bbWriteS = New hdd_guardian.BenchmarkBar()
        Me.lblReadS = New System.Windows.Forms.Label()
        Me.lblWriteS = New System.Windows.Forms.Label()
        Me.lnkRunAll = New hdd_guardian.NewLink()
        Me.tlpBenchInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.picBenchInfo = New System.Windows.Forms.PictureBox()
        Me.lblBenching = New System.Windows.Forms.Label()
        Me.prbBench = New System.Windows.Forms.ProgressBar()
        Me.lblBenchProgress = New System.Windows.Forms.Label()
        Me.lblBenchmark = New System.Windows.Forms.Label()
        Me.tlpNoBenchmark = New System.Windows.Forms.TableLayoutPanel()
        Me.picNoBench = New System.Windows.Forms.PictureBox()
        Me.lblNoBench = New System.Windows.Forms.Label()
        Me.RibbonHorizontalSeparator6 = New hdd_guardian.RibbonHorizontalSeparator()
        Me.tlpWmiMenuItems = New System.Windows.Forms.TableLayoutPanel()
        Me.picWmiDevicesHelp = New System.Windows.Forms.PictureBox()
        Me.tlpLoadWmi = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLoadWmi = New System.Windows.Forms.Label()
        Me.picLoadWmi = New System.Windows.Forms.PictureBox()
        Me.mrbRefresh = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.tpDebug = New System.Windows.Forms.TabPage()
        Me.tlpDebug = New System.Windows.Forms.TableLayoutPanel()
        Me.lvwProgLog = New System.Windows.Forms.ListView()
        Me.chLogDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chEvent = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tlpDebugMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.mrbDebugSave = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.mrbDebugClean = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.RibbonHorizontalSeparator5 = New hdd_guardian.RibbonHorizontalSeparator()
        Me.tpPlanner = New System.Windows.Forms.TabPage()
        Me.lvwTasks = New System.Windows.Forms.ListView()
        Me.chDevice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTest = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTask = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RibbonHorizontalSeparator1 = New hdd_guardian.RibbonHorizontalSeparator()
        Me.tlpTask = New System.Windows.Forms.TableLayoutPanel()
        Me.mrbTaskNew = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.mrbTaskEdit = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.mrbTaskDelete = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.mrbTaskTrash = New hdd_guardian.MimicExplorer.RibbonButton()
        Me.picPlannerHelp = New System.Windows.Forms.PictureBox()
        Me.rmFile = New hdd_guardian.MimicExplorer.RibbonMenu()
        Me.extOverview = New hdd_guardian.MimicExplorer.ExplorerTab()
        Me.extManage = New hdd_guardian.MimicExplorer.ExplorerTab()
        Me.extSystem = New hdd_guardian.MimicExplorer.ExplorerTab()
        Me.extPlanner = New hdd_guardian.MimicExplorer.ExplorerTab()
        Me.extDebug = New hdd_guardian.MimicExplorer.ExplorerTab()
        MenuItem4 = New System.Windows.Forms.MenuItem()
        MenuItem2 = New System.Windows.Forms.MenuItem()
        MenuItem5 = New System.Windows.Forms.MenuItem()
        tlpRibbonMenu = New System.Windows.Forms.TableLayoutPanel()
        flwWarnings = New System.Windows.Forms.FlowLayoutPanel()
        RibbonHorizontalSeparator2 = New hdd_guardian.RibbonHorizontalSeparator()
        tlpAam = New System.Windows.Forms.TableLayoutPanel()
        tlpAamLoud = New System.Windows.Forms.TableLayoutPanel()
        tlpApm = New System.Windows.Forms.TableLayoutPanel()
        tlpStandby = New System.Windows.Forms.TableLayoutPanel()
        tlpRibbonMenu.SuspendLayout()
        Me.tlpMessages.SuspendLayout()
        CType(Me.picAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNewVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssStatus.SuspendLayout()
        Me.htcMain.SuspendLayout()
        Me.tpOverview.SuspendLayout()
        Me.tlpOverview.SuspendLayout()
        Me.tlpDeviceInfo.SuspendLayout()
        Me.tabSidePanel.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.tlpGeneral.SuspendLayout()
        CType(Me.HorizontalLine10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpGeneralInfo.SuspendLayout()
        CType(Me.HorizontalLine11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpDatabase.SuspendLayout()
        CType(Me.HorizontalLine15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpWarnings.SuspendLayout()
        flwWarnings.SuspendLayout()
        CType(Me.HorizontalLine16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpHealth.SuspendLayout()
        Me.tlpHealth.SuspendLayout()
        Me.tlpRating.SuspendLayout()
        CType(Me.HorizontalLine18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpRatingTable.SuspendLayout()
        CType(Me.picOverall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRating4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRating2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRating3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRating1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpSummary.SuspendLayout()
        CType(Me.HorizontalLine17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picManufacturer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMenuItems.SuspendLayout()
        CType(Me.picOverviewHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpManage.SuspendLayout()
        Me.tlpManage.SuspendLayout()
        Me.htcManage.SuspendLayout()
        Me.tpInfo.SuspendLayout()
        Me.htcInfo.SuspendLayout()
        Me.tpAtaSmartAttributes.SuspendLayout()
        Me.tlpAttributes.SuspendLayout()
        Me.pnlAttribuesInfo.SuspendLayout()
        Me.tlpAttributeDetails.SuspendLayout()
        Me.tpEvents.SuspendLayout()
        Me.tlpChartContent.SuspendLayout()
        Me.tlpDisplayEvent.SuspendLayout()
        Me.tlpLogCmd.SuspendLayout()
        Me.tlpEventChart.SuspendLayout()
        Me.tabLog.SuspendLayout()
        Me.tpLogEvents.SuspendLayout()
        Me.tpLogChart.SuspendLayout()
        CType(Me.chrChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpChartOptions.SuspendLayout()
        CType(Me.numPointSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTemperatures.SuspendLayout()
        Me.tlpTemperatures.SuspendLayout()
        Me.tlpTempGraphs.SuspendLayout()
        Me.tlpTempMeans.SuspendLayout()
        Me.tpSetup.SuspendLayout()
        Me.htcSetup.SuspendLayout()
        Me.tpAtaSmartSetup.SuspendLayout()
        Me.tlpAtaSmart.SuspendLayout()
        CType(Me.HorizontalLine2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpScsiSmartSetup.SuspendLayout()
        Me.tlpScsiSmart.SuspendLayout()
        CType(Me.HorizontalLine13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAtaAam.SuspendLayout()
        Me.tlpAtaAam.SuspendLayout()
        tlpAam.SuspendLayout()
        CType(Me.trkAam, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpAamLoud.SuspendLayout()
        CType(Me.HorizontalLine3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpAamWaitMessage.SuspendLayout()
        CType(Me.picLoaderAam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAtaApm.SuspendLayout()
        Me.tlpApmContent.SuspendLayout()
        Me.tlpApmWaitMessage.SuspendLayout()
        CType(Me.picLoaderApm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkApm, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpApm.SuspendLayout()
        CType(Me.HorizontalLine4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAtaStandby.SuspendLayout()
        Me.tlpStandbyContent.SuspendLayout()
        Me.tlpStandbyWaitMessage.SuspendLayout()
        CType(Me.picLoaderStandby, System.ComponentModel.ISupportInitialize).BeginInit()
        tlpStandby.SuspendLayout()
        CType(Me.trkStandby, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HorizontalLine5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAtaReadWrite.SuspendLayout()
        Me.tlpOtherContent.SuspendLayout()
        Me.tlpWaitRWMessage.SuspendLayout()
        CType(Me.picLoaderRW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flwOtherFeatures.SuspendLayout()
        Me.tpErrorsTests.SuspendLayout()
        Me.htcErrorsTests.SuspendLayout()
        Me.tpAtaErrors.SuspendLayout()
        Me.tlpAtaErrorsContent.SuspendLayout()
        Me.tlpErrorList.SuspendLayout()
        Me.tlpErrorDetails.SuspendLayout()
        Me.tpAtaTests.SuspendLayout()
        Me.tlpTestsContent.SuspendLayout()
        Me.tlpSelfTests.SuspendLayout()
        Me.tpAtaRunTest.SuspendLayout()
        Me.tlpAtaTestContent.SuspendLayout()
        Me.tlpTestProgress.SuspendLayout()
        Me.flwProgress.SuspendLayout()
        CType(Me.HorizontalLine8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flwTests.SuspendLayout()
        Me.tpScsiErrors.SuspendLayout()
        Me.tlpScsiErrorsContent.SuspendLayout()
        Me.tpScsiTests.SuspendLayout()
        Me.tlpScsiTestsContent.SuspendLayout()
        Me.tpScsiRunTest.SuspendLayout()
        Me.tlpScsiTestContent.SuspendLayout()
        Me.tlpScsiTest.SuspendLayout()
        Me.pnlScsiTestRun.SuspendLayout()
        CType(Me.HorizontalLine14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSmartctl.SuspendLayout()
        Me.htcSmartctl.SuspendLayout()
        Me.tpOutput.SuspendLayout()
        Me.tlpOutput.SuspendLayout()
        Me.tpAdvanced.SuspendLayout()
        Me.tlpAdvanced.SuspendLayout()
        CType(Me.HorizontalLine12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAdvanced.SuspendLayout()
        Me.tpPower.SuspendLayout()
        Me.tlpPowerModeContent.SuspendLayout()
        Me.flwPowerMode.SuspendLayout()
        Me.tpRemap.SuspendLayout()
        Me.tlpRemapContent.SuspendLayout()
        Me.pnlAttributes.SuspendLayout()
        Me.tlpButtons.SuspendLayout()
        Me.tpFirmware.SuspendLayout()
        Me.tlpFirmwareContent.SuspendLayout()
        Me.flwFirmware.SuspendLayout()
        Me.tpAsmedia.SuspendLayout()
        Me.tlpAsmedia.SuspendLayout()
        Me.tpVersion.SuspendLayout()
        Me.pnlSideMenu.SuspendLayout()
        Me.tlpSideMenu.SuspendLayout()
        Me.tlpManageMenuContent.SuspendLayout()
        CType(Me.picManageHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpSelDevice.SuspendLayout()
        Me.pnlComboBorder.SuspendLayout()
        Me.tpWmiDevices.SuspendLayout()
        Me.tlpSystem.SuspendLayout()
        Me.htcSystem.SuspendLayout()
        Me.tpHardware.SuspendLayout()
        Me.tlpHardware.SuspendLayout()
        CType(Me.picHardware, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpHrwDetails.SuspendLayout()
        CType(Me.picBios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMotherboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picProcessor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picVideoCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDisk.SuspendLayout()
        Me.tlpDisk.SuspendLayout()
        CType(Me.picDisk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpDiskDetails.SuspendLayout()
        Me.tpPartition.SuspendLayout()
        Me.tlpPartition.SuspendLayout()
        CType(Me.picPartition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpPartitionDetails.SuspendLayout()
        Me.tpLogicalDisk.SuspendLayout()
        Me.tlpLogical.SuspendLayout()
        CType(Me.picLogical, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpLogicalDetails.SuspendLayout()
        Me.tlpBenchmark.SuspendLayout()
        Me.tlpRandom.SuspendLayout()
        Me.tlpRandomMulti.SuspendLayout()
        Me.tlpSequentialMulti.SuspendLayout()
        Me.tlpSequential.SuspendLayout()
        Me.tlpBenchInfo.SuspendLayout()
        CType(Me.picBenchInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpNoBenchmark.SuspendLayout()
        CType(Me.picNoBench, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpWmiMenuItems.SuspendLayout()
        CType(Me.picWmiDevicesHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpLoadWmi.SuspendLayout()
        CType(Me.picLoadWmi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDebug.SuspendLayout()
        Me.tlpDebug.SuspendLayout()
        Me.tlpDebugMenu.SuspendLayout()
        Me.tpPlanner.SuspendLayout()
        Me.tlpTask.SuspendLayout()
        CType(Me.picPlannerHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuItem4
        '
        MenuItem4.Index = 1
        MenuItem4.Text = "-"
        '
        'MenuItem2
        '
        MenuItem2.Index = 4
        MenuItem2.Text = "-"
        '
        'MenuItem5
        '
        MenuItem5.Index = 6
        MenuItem5.Text = "-"
        '
        'tlpRibbonMenu
        '
        tlpRibbonMenu.AutoSize = True
        tlpRibbonMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpRibbonMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        tlpRibbonMenu.ColumnCount = 7
        tlpRibbonMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpRibbonMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpRibbonMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpRibbonMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpRibbonMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpRibbonMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpRibbonMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        tlpRibbonMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        tlpRibbonMenu.Controls.Add(Me.tlpMessages, 6, 0)
        tlpRibbonMenu.Controls.Add(Me.rmFile, 0, 0)
        tlpRibbonMenu.Controls.Add(Me.extOverview, 1, 0)
        tlpRibbonMenu.Controls.Add(Me.extManage, 2, 0)
        tlpRibbonMenu.Controls.Add(Me.extSystem, 3, 0)
        tlpRibbonMenu.Controls.Add(Me.extPlanner, 4, 0)
        tlpRibbonMenu.Controls.Add(Me.extDebug, 5, 0)
        tlpRibbonMenu.Dock = System.Windows.Forms.DockStyle.Top
        tlpRibbonMenu.Location = New System.Drawing.Point(0, 0)
        tlpRibbonMenu.Name = "tlpRibbonMenu"
        tlpRibbonMenu.RowCount = 1
        tlpRibbonMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpRibbonMenu.Size = New System.Drawing.Size(892, 24)
        tlpRibbonMenu.TabIndex = 39
        '
        'tlpMessages
        '
        Me.tlpMessages.AutoSize = True
        Me.tlpMessages.BackColor = System.Drawing.Color.White
        Me.tlpMessages.ColumnCount = 3
        Me.tlpMessages.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMessages.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMessages.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMessages.Controls.Add(Me.picAdmin, 1, 0)
        Me.tlpMessages.Controls.Add(Me.picNewVersion, 2, 0)
        Me.tlpMessages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMessages.Location = New System.Drawing.Point(407, 0)
        Me.tlpMessages.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.tlpMessages.Name = "tlpMessages"
        Me.tlpMessages.RowCount = 1
        Me.tlpMessages.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMessages.Size = New System.Drawing.Size(485, 23)
        Me.tlpMessages.TabIndex = 3
        '
        'picAdmin
        '
        Me.picAdmin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.picAdmin.Location = New System.Drawing.Point(444, 3)
        Me.picAdmin.Name = "picAdmin"
        Me.picAdmin.Size = New System.Drawing.Size(16, 16)
        Me.picAdmin.TabIndex = 8
        Me.picAdmin.TabStop = False
        '
        'picNewVersion
        '
        Me.picNewVersion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picNewVersion.Location = New System.Drawing.Point(466, 3)
        Me.picNewVersion.Name = "picNewVersion"
        Me.picNewVersion.Size = New System.Drawing.Size(16, 16)
        Me.picNewVersion.TabIndex = 9
        Me.picNewVersion.TabStop = False
        '
        'niTrayIcon
        '
        Me.niTrayIcon.Icon = CType(resources.GetObject("niTrayIcon.Icon"), System.Drawing.Icon)
        Me.niTrayIcon.Text = "HDD Guardian"
        '
        'tmrRefresh
        '
        '
        'mnuGuide
        '
        Me.mnuGuide.Name = "mnuGuide"
        Me.mnuGuide.ShowShortcutKeys = False
        Me.mnuGuide.Size = New System.Drawing.Size(123, 22)
        Me.mnuGuide.Text = "mnuGuide"
        Me.mnuGuide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mnuGuide.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(120, 6)
        '
        'mnuInfo
        '
        Me.mnuInfo.Name = "mnuInfo"
        Me.mnuInfo.ShowShortcutKeys = False
        Me.mnuInfo.Size = New System.Drawing.Size(123, 22)
        Me.mnuInfo.Text = "mnuInfo"
        Me.mnuInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mnuInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'tmrFlushMem
        '
        Me.tmrFlushMem.Enabled = True
        Me.tmrFlushMem.Interval = 60000
        '
        'tmrTest
        '
        '
        'tmrRefreshExt
        '
        '
        'cmTrayIcon
        '
        Me.cmTrayIcon.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRestoreTray, MenuItem4, Me.mnuExitTray})
        '
        'mnuRestoreTray
        '
        Me.mnuRestoreTray.Index = 0
        Me.mnuRestoreTray.Text = "mnuRestoreTray"
        '
        'mnuExitTray
        '
        Me.mnuExitTray.Index = 2
        Me.mnuExitTray.Text = "mnuExitTray"
        '
        'cmDevices
        '
        Me.cmDevices.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuTitle, Me.MenuItem3, Me.mnuRefreshSel, Me.mnuRefreshAll, MenuItem2, Me.mnuSearchUsb, MenuItem5, Me.mnuAddVirtualDev, Me.mnuRemoveVirtualDev, Me.MenuItem6, Me.mnuTrayIcon, Me.mnuSharing, Me.mnuXml, Me.mnuDeviceImage})
        '
        'mnuTitle
        '
        Me.mnuTitle.Enabled = False
        Me.mnuTitle.Index = 0
        Me.mnuTitle.Text = "mnuTitle"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "-"
        '
        'mnuRefreshSel
        '
        Me.mnuRefreshSel.Index = 2
        Me.mnuRefreshSel.Text = "mnuRefreshSel"
        '
        'mnuRefreshAll
        '
        Me.mnuRefreshAll.Index = 3
        Me.mnuRefreshAll.Text = "mnuRefreshAll"
        '
        'mnuSearchUsb
        '
        Me.mnuSearchUsb.Index = 5
        Me.mnuSearchUsb.Text = "mnuSearchUsb"
        '
        'mnuAddVirtualDev
        '
        Me.mnuAddVirtualDev.Index = 7
        Me.mnuAddVirtualDev.Text = "mnuAddVirtualDev"
        '
        'mnuRemoveVirtualDev
        '
        Me.mnuRemoveVirtualDev.Index = 8
        Me.mnuRemoveVirtualDev.Text = "mnuRemoveVirtualDev"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 9
        Me.MenuItem6.Text = "-"
        '
        'mnuTrayIcon
        '
        Me.mnuTrayIcon.Index = 10
        Me.mnuTrayIcon.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuTrayTemperature, Me.mnuTrayLife, Me.MenuItem1, Me.mnuInfoPanel})
        Me.mnuTrayIcon.Text = "mnuTrayIcon"
        '
        'mnuTrayTemperature
        '
        Me.mnuTrayTemperature.Index = 0
        Me.mnuTrayTemperature.Text = "mnuTrayTemperature"
        '
        'mnuTrayLife
        '
        Me.mnuTrayLife.Index = 1
        Me.mnuTrayLife.Text = "mnuTrayLife"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 2
        Me.MenuItem1.Text = "-"
        '
        'mnuInfoPanel
        '
        Me.mnuInfoPanel.Index = 3
        Me.mnuInfoPanel.Text = "mnuInfoPanel"
        '
        'mnuSharing
        '
        Me.mnuSharing.Index = 11
        Me.mnuSharing.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuShareThis, Me.mnuSharingFolder})
        Me.mnuSharing.Text = "mnuSharing"
        '
        'mnuShareThis
        '
        Me.mnuShareThis.Index = 0
        Me.mnuShareThis.Text = "mnuShareThis"
        '
        'mnuSharingFolder
        '
        Me.mnuSharingFolder.Index = 1
        Me.mnuSharingFolder.Text = "mnuSharingFolder"
        '
        'mnuXml
        '
        Me.mnuXml.Index = 12
        Me.mnuXml.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuXmlCreate, Me.mnuXmlFolder})
        Me.mnuXml.Text = "mnuXml"
        '
        'mnuXmlCreate
        '
        Me.mnuXmlCreate.Index = 0
        Me.mnuXmlCreate.Text = "mnuXmlCreate"
        '
        'mnuXmlFolder
        '
        Me.mnuXmlFolder.Index = 1
        Me.mnuXmlFolder.Text = "mnuXmlFolder"
        '
        'mnuDeviceImage
        '
        Me.mnuDeviceImage.Index = 13
        Me.mnuDeviceImage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuDeviceImageSet, Me.mnuDeviceImageRemove})
        Me.mnuDeviceImage.Text = "mnuDeviceImage"
        '
        'mnuDeviceImageSet
        '
        Me.mnuDeviceImageSet.Index = 0
        Me.mnuDeviceImageSet.Text = "mnuDeviceImageSet"
        '
        'mnuDeviceImageRemove
        '
        Me.mnuDeviceImageRemove.Index = 1
        Me.mnuDeviceImageRemove.Text = "mnuDeviceImageRemove"
        '
        'cmFile
        '
        Me.cmFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuReloadDevices, Me.MenuItem10, Me.mnuUpdateDatabase, Me.MenuItem8, Me.mnuSettings, Me.mnuAbout, Me.MenuItem7, Me.mnuExit})
        '
        'mnuReloadDevices
        '
        Me.mnuReloadDevices.Index = 0
        Me.mnuReloadDevices.Text = "mnuReloadDevices"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 1
        Me.MenuItem10.Text = "-"
        '
        'mnuUpdateDatabase
        '
        Me.mnuUpdateDatabase.Index = 2
        Me.mnuUpdateDatabase.Text = "mnuUpdateDatabase"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 3
        Me.MenuItem8.Text = "-"
        '
        'mnuSettings
        '
        Me.mnuSettings.Index = 4
        Me.mnuSettings.Text = "mnuSettings"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 5
        Me.mnuAbout.Text = "mnuAbout"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 6
        Me.MenuItem7.Text = "-"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 7
        Me.mnuExit.Text = "mnuExit"
        '
        'cmDeviceImage
        '
        Me.cmDeviceImage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuProfessional, Me.mnuGamer, Me.mnuLaptop})
        '
        'mnuProfessional
        '
        Me.mnuProfessional.Index = 0
        Me.mnuProfessional.Text = "mnuProfessional"
        '
        'mnuGamer
        '
        Me.mnuGamer.Index = 1
        Me.mnuGamer.Text = "mnuGamer"
        '
        'mnuLaptop
        '
        Me.mnuLaptop.Index = 2
        Me.mnuLaptop.Text = "mnuLaptop"
        '
        'ssStatus
        '
        Me.ssStatus.BackColor = System.Drawing.Color.Transparent
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslSmartctl})
        Me.ssStatus.Location = New System.Drawing.Point(0, 498)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(892, 24)
        Me.ssStatus.TabIndex = 43
        Me.ssStatus.Text = "StatusStrip1"
        '
        'tslSmartctl
        '
        Me.tslSmartctl.BackColor = System.Drawing.Color.Transparent
        Me.tslSmartctl.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tslSmartctl.Name = "tslSmartctl"
        Me.tslSmartctl.Size = New System.Drawing.Size(67, 19)
        Me.tslSmartctl.Text = "tslSmartctl"
        '
        'cmTask
        '
        Me.cmTask.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuTaskNew, Me.mnuTaskEdit, Me.MenuItem12, Me.mnuTaskDelete, Me.MenuItem14, Me.mnuTaskTrash})
        '
        'mnuTaskNew
        '
        Me.mnuTaskNew.Index = 0
        Me.mnuTaskNew.Text = "mnuTaskNew"
        '
        'mnuTaskEdit
        '
        Me.mnuTaskEdit.Index = 1
        Me.mnuTaskEdit.Text = "mnuTaskEdit"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 2
        Me.MenuItem12.Text = "-"
        '
        'mnuTaskDelete
        '
        Me.mnuTaskDelete.Index = 3
        Me.mnuTaskDelete.Text = "mnuTaskDelete"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 4
        Me.MenuItem14.Text = "-"
        '
        'mnuTaskTrash
        '
        Me.mnuTaskTrash.Index = 5
        Me.mnuTaskTrash.Text = "mnuTaskTrash"
        '
        'cmLog
        '
        Me.cmLog.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCopyLog, Me.MenuItem9, Me.mnuCopyAllLog})
        '
        'mnuCopyLog
        '
        Me.mnuCopyLog.Index = 0
        Me.mnuCopyLog.Text = "mnuCopyLog"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 1
        Me.MenuItem9.Text = "-"
        '
        'mnuCopyAllLog
        '
        Me.mnuCopyAllLog.Index = 2
        Me.mnuCopyAllLog.Text = "mnuCopyAllLog"
        '
        'htcMain
        '
        Me.htcMain.Controls.Add(Me.tpOverview)
        Me.htcMain.Controls.Add(Me.tpManage)
        Me.htcMain.Controls.Add(Me.tpWmiDevices)
        Me.htcMain.Controls.Add(Me.tpDebug)
        Me.htcMain.Controls.Add(Me.tpPlanner)
        Me.htcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htcMain.Location = New System.Drawing.Point(0, 24)
        Me.htcMain.Margin = New System.Windows.Forms.Padding(0)
        Me.htcMain.Name = "htcMain"
        Me.htcMain.SelectedIndex = 0
        Me.htcMain.Size = New System.Drawing.Size(892, 474)
        Me.htcMain.TabIndex = 42
        '
        'tpOverview
        '
        Me.tpOverview.BackColor = System.Drawing.Color.White
        Me.tpOverview.Controls.Add(Me.tlpOverview)
        Me.tpOverview.Controls.Add(RibbonHorizontalSeparator2)
        Me.tpOverview.Controls.Add(Me.tlpMenuItems)
        Me.tpOverview.Location = New System.Drawing.Point(4, 22)
        Me.tpOverview.Name = "tpOverview"
        Me.tpOverview.Size = New System.Drawing.Size(884, 448)
        Me.tpOverview.TabIndex = 0
        Me.tpOverview.Text = "tpOverview"
        '
        'tlpOverview
        '
        Me.tlpOverview.ColumnCount = 3
        Me.tlpOverview.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpOverview.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpOverview.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277.0!))
        Me.tlpOverview.Controls.Add(Me.tlpDeviceInfo, 2, 0)
        Me.tlpOverview.Controls.Add(Me.lvwDevices, 0, 0)
        Me.tlpOverview.Controls.Add(Me.rspOverview, 1, 0)
        Me.tlpOverview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpOverview.Location = New System.Drawing.Point(0, 35)
        Me.tlpOverview.Name = "tlpOverview"
        Me.tlpOverview.RowCount = 1
        Me.tlpOverview.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpOverview.Size = New System.Drawing.Size(884, 413)
        Me.tlpOverview.TabIndex = 26
        '
        'tlpDeviceInfo
        '
        Me.tlpDeviceInfo.AutoSize = True
        Me.tlpDeviceInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDeviceInfo.ColumnCount = 1
        Me.tlpDeviceInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDeviceInfo.Controls.Add(Me.tabSidePanel, 0, 1)
        Me.tlpDeviceInfo.Controls.Add(Me.picManufacturer, 0, 0)
        Me.tlpDeviceInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDeviceInfo.Location = New System.Drawing.Point(610, 3)
        Me.tlpDeviceInfo.Name = "tlpDeviceInfo"
        Me.tlpDeviceInfo.RowCount = 2
        Me.tlpDeviceInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDeviceInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDeviceInfo.Size = New System.Drawing.Size(271, 407)
        Me.tlpDeviceInfo.TabIndex = 22
        '
        'tabSidePanel
        '
        Me.tabSidePanel.Controls.Add(Me.tpGeneral)
        Me.tabSidePanel.Controls.Add(Me.tpHealth)
        Me.tabSidePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabSidePanel.Location = New System.Drawing.Point(0, 63)
        Me.tabSidePanel.Margin = New System.Windows.Forms.Padding(0)
        Me.tabSidePanel.Name = "tabSidePanel"
        Me.tabSidePanel.SelectedIndex = 0
        Me.tabSidePanel.Size = New System.Drawing.Size(271, 344)
        Me.tabSidePanel.TabIndex = 3
        '
        'tpGeneral
        '
        Me.tpGeneral.AutoScroll = True
        Me.tpGeneral.Controls.Add(Me.tlpGeneral)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpGeneral.Margin = New System.Windows.Forms.Padding(0)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(263, 318)
        Me.tpGeneral.TabIndex = 0
        Me.tpGeneral.Text = "tpGeneral"
        Me.tpGeneral.UseVisualStyleBackColor = True
        '
        'tlpGeneral
        '
        Me.tlpGeneral.AutoSize = True
        Me.tlpGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpGeneral.ColumnCount = 1
        Me.tlpGeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGeneral.Controls.Add(Me.lblInformation, 0, 0)
        Me.tlpGeneral.Controls.Add(Me.HorizontalLine10, 0, 1)
        Me.tlpGeneral.Controls.Add(Me.tlpGeneralInfo, 0, 2)
        Me.tlpGeneral.Controls.Add(Me.lblSmartInfo, 0, 4)
        Me.tlpGeneral.Controls.Add(Me.HorizontalLine11, 0, 5)
        Me.tlpGeneral.Controls.Add(Me.lblSmartInfoValue, 0, 6)
        Me.tlpGeneral.Controls.Add(Me.tlpDatabase, 0, 8)
        Me.tlpGeneral.Controls.Add(Me.tlpWarnings, 0, 10)
        Me.tlpGeneral.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpGeneral.Location = New System.Drawing.Point(3, 3)
        Me.tlpGeneral.Name = "tlpGeneral"
        Me.tlpGeneral.RowCount = 11
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGeneral.Size = New System.Drawing.Size(240, 498)
        Me.tlpGeneral.TabIndex = 0
        '
        'lblInformation
        '
        Me.lblInformation.AutoSize = True
        Me.lblInformation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblInformation.Location = New System.Drawing.Point(0, 3)
        Me.lblInformation.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.lblInformation.Name = "lblInformation"
        Me.lblInformation.Size = New System.Drawing.Size(73, 13)
        Me.lblInformation.TabIndex = 0
        Me.lblInformation.Tag = "Title"
        Me.lblInformation.Text = "lblInformation"
        '
        'HorizontalLine10
        '
        Me.HorizontalLine10.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine10.Dock = System.Windows.Forms.DockStyle.Top
        Me.HorizontalLine10.Location = New System.Drawing.Point(3, 25)
        Me.HorizontalLine10.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine10.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine10.Name = "HorizontalLine10"
        Me.HorizontalLine10.Size = New System.Drawing.Size(234, 1)
        Me.HorizontalLine10.TabIndex = 1
        Me.HorizontalLine10.TabStop = False
        '
        'tlpGeneralInfo
        '
        Me.tlpGeneralInfo.AutoSize = True
        Me.tlpGeneralInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpGeneralInfo.ColumnCount = 2
        Me.tlpGeneralInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpGeneralInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGeneralInfo.Controls.Add(Me.lblManufacturer, 0, 1)
        Me.tlpGeneralInfo.Controls.Add(Me.lblModel, 0, 2)
        Me.tlpGeneralInfo.Controls.Add(Me.lnkManufacturer, 1, 1)
        Me.tlpGeneralInfo.Controls.Add(Me.lblModelValue, 1, 2)
        Me.tlpGeneralInfo.Controls.Add(Me.lblSerial, 0, 3)
        Me.tlpGeneralInfo.Controls.Add(Me.lblSerialValue, 1, 3)
        Me.tlpGeneralInfo.Controls.Add(Me.exlWwnId, 0, 4)
        Me.tlpGeneralInfo.Controls.Add(Me.lblWwnIdValue, 1, 4)
        Me.tlpGeneralInfo.Controls.Add(Me.exlFirmware, 0, 5)
        Me.tlpGeneralInfo.Controls.Add(Me.lblFirmwareValue, 1, 5)
        Me.tlpGeneralInfo.Controls.Add(Me.lblSize, 0, 6)
        Me.tlpGeneralInfo.Controls.Add(Me.lblSizeValue, 1, 6)
        Me.tlpGeneralInfo.Controls.Add(Me.exlSectorBlock, 0, 7)
        Me.tlpGeneralInfo.Controls.Add(Me.lblSectorBlockValue, 1, 7)
        Me.tlpGeneralInfo.Controls.Add(Me.lblRotationRate, 0, 8)
        Me.tlpGeneralInfo.Controls.Add(Me.lblRotationRateValue, 1, 8)
        Me.tlpGeneralInfo.Controls.Add(Me.lblFactoryForm, 0, 9)
        Me.tlpGeneralInfo.Controls.Add(Me.lblFactoryFormValue, 1, 9)
        Me.tlpGeneralInfo.Controls.Add(Me.lblInterface, 0, 10)
        Me.tlpGeneralInfo.Controls.Add(Me.lblInterfaceValue, 1, 10)
        Me.tlpGeneralInfo.Controls.Add(Me.lblLocation, 0, 0)
        Me.tlpGeneralInfo.Controls.Add(Me.lblLocationValue, 1, 0)
        Me.tlpGeneralInfo.Controls.Add(Me.lblLetter, 0, 11)
        Me.tlpGeneralInfo.Controls.Add(Me.lblLetterValue, 1, 11)
        Me.tlpGeneralInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpGeneralInfo.Location = New System.Drawing.Point(0, 35)
        Me.tlpGeneralInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpGeneralInfo.Name = "tlpGeneralInfo"
        Me.tlpGeneralInfo.RowCount = 12
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpGeneralInfo.Size = New System.Drawing.Size(240, 192)
        Me.tlpGeneralInfo.TabIndex = 2
        '
        'lblManufacturer
        '
        Me.lblManufacturer.AutoSize = True
        Me.lblManufacturer.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblManufacturer.Location = New System.Drawing.Point(3, 16)
        Me.lblManufacturer.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(82, 13)
        Me.lblManufacturer.TabIndex = 0
        Me.lblManufacturer.Tag = "Grayed"
        Me.lblManufacturer.Text = "lblManufacturer"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblModel.Location = New System.Drawing.Point(3, 32)
        Me.lblModel.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(45, 13)
        Me.lblModel.TabIndex = 1
        Me.lblModel.Tag = "Grayed"
        Me.lblModel.Text = "lblModel"
        '
        'lnkManufacturer
        '
        Me.lnkManufacturer.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkManufacturer.AutoEllipsis = True
        Me.lnkManufacturer.AutoSize = True
        Me.lnkManufacturer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lnkManufacturer.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkManufacturer.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkManufacturer.Location = New System.Drawing.Point(91, 16)
        Me.lnkManufacturer.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lnkManufacturer.Name = "lnkManufacturer"
        Me.lnkManufacturer.Size = New System.Drawing.Size(146, 13)
        Me.lnkManufacturer.TabIndex = 2
        Me.lnkManufacturer.TabStop = True
        Me.lnkManufacturer.Text = "lnkManufacturer"
        '
        'lblModelValue
        '
        Me.lblModelValue.AutoEllipsis = True
        Me.lblModelValue.AutoSize = True
        Me.lblModelValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblModelValue.Location = New System.Drawing.Point(91, 32)
        Me.lblModelValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblModelValue.Name = "lblModelValue"
        Me.lblModelValue.Size = New System.Drawing.Size(146, 13)
        Me.lblModelValue.TabIndex = 3
        Me.lblModelValue.Text = "lblModelValue"
        '
        'lblSerial
        '
        Me.lblSerial.AutoSize = True
        Me.lblSerial.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblSerial.Location = New System.Drawing.Point(3, 48)
        Me.lblSerial.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblSerial.Name = "lblSerial"
        Me.lblSerial.Size = New System.Drawing.Size(63, 13)
        Me.lblSerial.TabIndex = 4
        Me.lblSerial.Tag = "Grayed"
        Me.lblSerial.Text = "lblInfoSerial"
        '
        'lblSerialValue
        '
        Me.lblSerialValue.AutoEllipsis = True
        Me.lblSerialValue.AutoSize = True
        Me.lblSerialValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSerialValue.Location = New System.Drawing.Point(91, 48)
        Me.lblSerialValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblSerialValue.Name = "lblSerialValue"
        Me.lblSerialValue.Size = New System.Drawing.Size(146, 13)
        Me.lblSerialValue.TabIndex = 5
        Me.lblSerialValue.Text = "lblSerialValue"
        '
        'exlWwnId
        '
        Me.exlWwnId.AtaText = Nothing
        Me.exlWwnId.AutoSize = True
        Me.exlWwnId.ForeColor = System.Drawing.SystemColors.GrayText
        Me.exlWwnId.Location = New System.Drawing.Point(3, 64)
        Me.exlWwnId.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.exlWwnId.Name = "exlWwnId"
        Me.exlWwnId.ScsiText = Nothing
        Me.exlWwnId.Size = New System.Drawing.Size(55, 13)
        Me.exlWwnId.TabIndex = 6
        Me.exlWwnId.Tag = "Grayed"
        Me.exlWwnId.Text = "exlWwnId"
        '
        'lblWwnIdValue
        '
        Me.lblWwnIdValue.AutoEllipsis = True
        Me.lblWwnIdValue.AutoSize = True
        Me.lblWwnIdValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblWwnIdValue.Location = New System.Drawing.Point(91, 64)
        Me.lblWwnIdValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblWwnIdValue.Name = "lblWwnIdValue"
        Me.lblWwnIdValue.Size = New System.Drawing.Size(146, 13)
        Me.lblWwnIdValue.TabIndex = 7
        Me.lblWwnIdValue.Text = "lblWwnIdValue"
        '
        'exlFirmware
        '
        Me.exlFirmware.AtaText = Nothing
        Me.exlFirmware.AutoSize = True
        Me.exlFirmware.ForeColor = System.Drawing.SystemColors.GrayText
        Me.exlFirmware.Location = New System.Drawing.Point(3, 80)
        Me.exlFirmware.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.exlFirmware.Name = "exlFirmware"
        Me.exlFirmware.ScsiText = Nothing
        Me.exlFirmware.Size = New System.Drawing.Size(65, 13)
        Me.exlFirmware.TabIndex = 8
        Me.exlFirmware.Tag = "Grayed"
        Me.exlFirmware.Text = "exlFirmware"
        '
        'lblFirmwareValue
        '
        Me.lblFirmwareValue.AutoEllipsis = True
        Me.lblFirmwareValue.AutoSize = True
        Me.lblFirmwareValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFirmwareValue.Location = New System.Drawing.Point(91, 80)
        Me.lblFirmwareValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblFirmwareValue.Name = "lblFirmwareValue"
        Me.lblFirmwareValue.Size = New System.Drawing.Size(146, 13)
        Me.lblFirmwareValue.TabIndex = 9
        Me.lblFirmwareValue.Text = "lblFirmwareValue"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblSize.Location = New System.Drawing.Point(3, 96)
        Me.lblSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(36, 13)
        Me.lblSize.TabIndex = 10
        Me.lblSize.Tag = "Grayed"
        Me.lblSize.Text = "lblSize"
        '
        'lblSizeValue
        '
        Me.lblSizeValue.AutoEllipsis = True
        Me.lblSizeValue.AutoSize = True
        Me.lblSizeValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSizeValue.Location = New System.Drawing.Point(91, 96)
        Me.lblSizeValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblSizeValue.Name = "lblSizeValue"
        Me.lblSizeValue.Size = New System.Drawing.Size(146, 13)
        Me.lblSizeValue.TabIndex = 11
        Me.lblSizeValue.Text = "lblSizeValue"
        '
        'exlSectorBlock
        '
        Me.exlSectorBlock.AtaText = Nothing
        Me.exlSectorBlock.AutoSize = True
        Me.exlSectorBlock.ForeColor = System.Drawing.SystemColors.GrayText
        Me.exlSectorBlock.Location = New System.Drawing.Point(3, 112)
        Me.exlSectorBlock.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.exlSectorBlock.Name = "exlSectorBlock"
        Me.exlSectorBlock.ScsiText = Nothing
        Me.exlSectorBlock.Size = New System.Drawing.Size(76, 13)
        Me.exlSectorBlock.TabIndex = 12
        Me.exlSectorBlock.Tag = "Grayed"
        Me.exlSectorBlock.Text = "exlSectorBlock"
        '
        'lblSectorBlockValue
        '
        Me.lblSectorBlockValue.AutoEllipsis = True
        Me.lblSectorBlockValue.AutoSize = True
        Me.lblSectorBlockValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSectorBlockValue.Location = New System.Drawing.Point(91, 112)
        Me.lblSectorBlockValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblSectorBlockValue.Name = "lblSectorBlockValue"
        Me.lblSectorBlockValue.Size = New System.Drawing.Size(146, 13)
        Me.lblSectorBlockValue.TabIndex = 13
        Me.lblSectorBlockValue.Text = "lblSectorBlockValue"
        '
        'lblRotationRate
        '
        Me.lblRotationRate.AutoSize = True
        Me.lblRotationRate.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblRotationRate.Location = New System.Drawing.Point(3, 128)
        Me.lblRotationRate.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblRotationRate.Name = "lblRotationRate"
        Me.lblRotationRate.Size = New System.Drawing.Size(81, 13)
        Me.lblRotationRate.TabIndex = 14
        Me.lblRotationRate.Tag = "Grayed"
        Me.lblRotationRate.Text = "lblRotationRate"
        '
        'lblRotationRateValue
        '
        Me.lblRotationRateValue.AutoEllipsis = True
        Me.lblRotationRateValue.AutoSize = True
        Me.lblRotationRateValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRotationRateValue.Location = New System.Drawing.Point(91, 128)
        Me.lblRotationRateValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblRotationRateValue.Name = "lblRotationRateValue"
        Me.lblRotationRateValue.Size = New System.Drawing.Size(146, 13)
        Me.lblRotationRateValue.TabIndex = 15
        Me.lblRotationRateValue.Text = "lblRotationRateValue"
        '
        'lblFactoryForm
        '
        Me.lblFactoryForm.AutoSize = True
        Me.lblFactoryForm.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblFactoryForm.Location = New System.Drawing.Point(3, 144)
        Me.lblFactoryForm.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblFactoryForm.Name = "lblFactoryForm"
        Me.lblFactoryForm.Size = New System.Drawing.Size(78, 13)
        Me.lblFactoryForm.TabIndex = 16
        Me.lblFactoryForm.Tag = "Grayed"
        Me.lblFactoryForm.Text = "lblFactoryForm"
        '
        'lblFactoryFormValue
        '
        Me.lblFactoryFormValue.AutoEllipsis = True
        Me.lblFactoryFormValue.AutoSize = True
        Me.lblFactoryFormValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFactoryFormValue.Location = New System.Drawing.Point(91, 144)
        Me.lblFactoryFormValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblFactoryFormValue.Name = "lblFactoryFormValue"
        Me.lblFactoryFormValue.Size = New System.Drawing.Size(146, 13)
        Me.lblFactoryFormValue.TabIndex = 17
        Me.lblFactoryFormValue.Text = "lblFactoryFormValue"
        '
        'lblInterface
        '
        Me.lblInterface.AutoSize = True
        Me.lblInterface.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblInterface.Location = New System.Drawing.Point(3, 160)
        Me.lblInterface.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblInterface.Name = "lblInterface"
        Me.lblInterface.Size = New System.Drawing.Size(62, 13)
        Me.lblInterface.TabIndex = 18
        Me.lblInterface.Tag = "Grayed"
        Me.lblInterface.Text = "lblInterface"
        '
        'lblInterfaceValue
        '
        Me.lblInterfaceValue.AutoEllipsis = True
        Me.lblInterfaceValue.AutoSize = True
        Me.lblInterfaceValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInterfaceValue.Location = New System.Drawing.Point(91, 160)
        Me.lblInterfaceValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblInterfaceValue.Name = "lblInterfaceValue"
        Me.lblInterfaceValue.Size = New System.Drawing.Size(146, 13)
        Me.lblInterfaceValue.TabIndex = 19
        Me.lblInterfaceValue.Text = "lblInterfaceValue"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblLocation.Location = New System.Drawing.Point(3, 0)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(57, 13)
        Me.lblLocation.TabIndex = 20
        Me.lblLocation.Tag = "Grayed"
        Me.lblLocation.Text = "lblLocation"
        '
        'lblLocationValue
        '
        Me.lblLocationValue.AutoEllipsis = True
        Me.lblLocationValue.AutoSize = True
        Me.lblLocationValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLocationValue.Location = New System.Drawing.Point(91, 0)
        Me.lblLocationValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLocationValue.Name = "lblLocationValue"
        Me.lblLocationValue.Size = New System.Drawing.Size(146, 13)
        Me.lblLocationValue.TabIndex = 21
        Me.lblLocationValue.Text = "lblLocationValue"
        '
        'lblLetter
        '
        Me.lblLetter.AutoSize = True
        Me.lblLetter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLetter.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblLetter.Location = New System.Drawing.Point(3, 176)
        Me.lblLetter.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLetter.Name = "lblLetter"
        Me.lblLetter.Size = New System.Drawing.Size(82, 13)
        Me.lblLetter.TabIndex = 22
        Me.lblLetter.Tag = "Grayed"
        Me.lblLetter.Text = "lblLetter"
        '
        'lblLetterValue
        '
        Me.lblLetterValue.AutoSize = True
        Me.lblLetterValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLetterValue.Location = New System.Drawing.Point(91, 176)
        Me.lblLetterValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLetterValue.Name = "lblLetterValue"
        Me.lblLetterValue.Size = New System.Drawing.Size(146, 13)
        Me.lblLetterValue.TabIndex = 23
        Me.lblLetterValue.Text = "lblLetterValue"
        '
        'lblSmartInfo
        '
        Me.lblSmartInfo.AutoSize = True
        Me.lblSmartInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSmartInfo.Location = New System.Drawing.Point(0, 250)
        Me.lblSmartInfo.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.lblSmartInfo.Name = "lblSmartInfo"
        Me.lblSmartInfo.Size = New System.Drawing.Size(65, 13)
        Me.lblSmartInfo.TabIndex = 3
        Me.lblSmartInfo.Tag = "Title"
        Me.lblSmartInfo.Text = "lblSmartInfo"
        '
        'HorizontalLine11
        '
        Me.HorizontalLine11.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine11.Location = New System.Drawing.Point(3, 272)
        Me.HorizontalLine11.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine11.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine11.Name = "HorizontalLine11"
        Me.HorizontalLine11.Size = New System.Drawing.Size(234, 1)
        Me.HorizontalLine11.TabIndex = 4
        Me.HorizontalLine11.TabStop = False
        '
        'lblSmartInfoValue
        '
        Me.lblSmartInfoValue.AutoSize = True
        Me.lblSmartInfoValue.Location = New System.Drawing.Point(3, 282)
        Me.lblSmartInfoValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblSmartInfoValue.Name = "lblSmartInfoValue"
        Me.lblSmartInfoValue.Size = New System.Drawing.Size(91, 13)
        Me.lblSmartInfoValue.TabIndex = 5
        Me.lblSmartInfoValue.Text = "lblSmartInfoValue"
        '
        'tlpDatabase
        '
        Me.tlpDatabase.AutoSize = True
        Me.tlpDatabase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDatabase.ColumnCount = 1
        Me.tlpDatabase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDatabase.Controls.Add(Me.lblDatabaseInfo, 0, 0)
        Me.tlpDatabase.Controls.Add(Me.lblDatabaseInfoValue, 0, 2)
        Me.tlpDatabase.Controls.Add(Me.HorizontalLine15, 0, 1)
        Me.tlpDatabase.Controls.Add(Me.lnkUpdateDatabase, 0, 3)
        Me.tlpDatabase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDatabase.Location = New System.Drawing.Point(0, 318)
        Me.tlpDatabase.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpDatabase.Name = "tlpDatabase"
        Me.tlpDatabase.RowCount = 4
        Me.tlpDatabase.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDatabase.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDatabase.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDatabase.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDatabase.Size = New System.Drawing.Size(240, 64)
        Me.tlpDatabase.TabIndex = 6
        '
        'lblDatabaseInfo
        '
        Me.lblDatabaseInfo.AutoSize = True
        Me.lblDatabaseInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDatabaseInfo.Location = New System.Drawing.Point(3, 0)
        Me.lblDatabaseInfo.Name = "lblDatabaseInfo"
        Me.lblDatabaseInfo.Size = New System.Drawing.Size(83, 13)
        Me.lblDatabaseInfo.TabIndex = 0
        Me.lblDatabaseInfo.Tag = "Title"
        Me.lblDatabaseInfo.Text = "lblDatabaseInfo"
        '
        'lblDatabaseInfoValue
        '
        Me.lblDatabaseInfoValue.AutoSize = True
        Me.lblDatabaseInfoValue.Location = New System.Drawing.Point(3, 32)
        Me.lblDatabaseInfoValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblDatabaseInfoValue.Name = "lblDatabaseInfoValue"
        Me.lblDatabaseInfoValue.Size = New System.Drawing.Size(109, 13)
        Me.lblDatabaseInfoValue.TabIndex = 1
        Me.lblDatabaseInfoValue.Text = "lblDatabaseInfoValue"
        '
        'HorizontalLine15
        '
        Me.HorizontalLine15.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine15.Location = New System.Drawing.Point(3, 22)
        Me.HorizontalLine15.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine15.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine15.Name = "HorizontalLine15"
        Me.HorizontalLine15.Size = New System.Drawing.Size(234, 1)
        Me.HorizontalLine15.TabIndex = 2
        Me.HorizontalLine15.TabStop = False
        '
        'lnkUpdateDatabase
        '
        Me.lnkUpdateDatabase.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkUpdateDatabase.AutoSize = True
        Me.lnkUpdateDatabase.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkUpdateDatabase.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkUpdateDatabase.Location = New System.Drawing.Point(3, 48)
        Me.lnkUpdateDatabase.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lnkUpdateDatabase.Name = "lnkUpdateDatabase"
        Me.lnkUpdateDatabase.Size = New System.Drawing.Size(101, 13)
        Me.lnkUpdateDatabase.TabIndex = 3
        Me.lnkUpdateDatabase.TabStop = True
        Me.lnkUpdateDatabase.Text = "lnkUpdateDatabase"
        '
        'tlpWarnings
        '
        Me.tlpWarnings.AutoSize = True
        Me.tlpWarnings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpWarnings.ColumnCount = 1
        Me.tlpWarnings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpWarnings.Controls.Add(flwWarnings, 0, 2)
        Me.tlpWarnings.Controls.Add(Me.lblWarnings, 0, 0)
        Me.tlpWarnings.Controls.Add(Me.HorizontalLine16, 0, 1)
        Me.tlpWarnings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpWarnings.Location = New System.Drawing.Point(0, 402)
        Me.tlpWarnings.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpWarnings.Name = "tlpWarnings"
        Me.tlpWarnings.RowCount = 3
        Me.tlpWarnings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWarnings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWarnings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWarnings.Size = New System.Drawing.Size(240, 96)
        Me.tlpWarnings.TabIndex = 7
        '
        'flwWarnings
        '
        flwWarnings.AutoSize = True
        flwWarnings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        flwWarnings.Controls.Add(Me.lblWarningValue)
        flwWarnings.Controls.Add(Me.lnkWeb1)
        flwWarnings.Controls.Add(Me.lnkWeb2)
        flwWarnings.Controls.Add(Me.lnkWeb3)
        flwWarnings.Dock = System.Windows.Forms.DockStyle.Top
        flwWarnings.Location = New System.Drawing.Point(0, 35)
        flwWarnings.Margin = New System.Windows.Forms.Padding(0)
        flwWarnings.Name = "flwWarnings"
        flwWarnings.Size = New System.Drawing.Size(240, 64)
        flwWarnings.TabIndex = 51
        '
        'lblWarningValue
        '
        Me.lblWarningValue.AutoSize = True
        flwWarnings.SetFlowBreak(Me.lblWarningValue, True)
        Me.lblWarningValue.ForeColor = System.Drawing.Color.Black
        Me.lblWarningValue.Location = New System.Drawing.Point(3, 0)
        Me.lblWarningValue.Name = "lblWarningValue"
        Me.lblWarningValue.Size = New System.Drawing.Size(83, 13)
        Me.lblWarningValue.TabIndex = 14
        Me.lblWarningValue.Text = "lblWarningValue"
        '
        'lnkWeb1
        '
        Me.lnkWeb1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkWeb1.AutoSize = True
        flwWarnings.SetFlowBreak(Me.lnkWeb1, True)
        Me.lnkWeb1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkWeb1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkWeb1.Location = New System.Drawing.Point(3, 16)
        Me.lnkWeb1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lnkWeb1.Name = "lnkWeb1"
        Me.lnkWeb1.Size = New System.Drawing.Size(48, 13)
        Me.lnkWeb1.TabIndex = 45
        Me.lnkWeb1.TabStop = True
        Me.lnkWeb1.Text = "lnkWeb1"
        '
        'lnkWeb2
        '
        Me.lnkWeb2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkWeb2.AutoSize = True
        flwWarnings.SetFlowBreak(Me.lnkWeb2, True)
        Me.lnkWeb2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkWeb2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkWeb2.Location = New System.Drawing.Point(3, 32)
        Me.lnkWeb2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lnkWeb2.Name = "lnkWeb2"
        Me.lnkWeb2.Size = New System.Drawing.Size(48, 13)
        Me.lnkWeb2.TabIndex = 46
        Me.lnkWeb2.TabStop = True
        Me.lnkWeb2.Text = "lnkWeb2"
        '
        'lnkWeb3
        '
        Me.lnkWeb3.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkWeb3.AutoSize = True
        Me.lnkWeb3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkWeb3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkWeb3.Location = New System.Drawing.Point(3, 48)
        Me.lnkWeb3.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lnkWeb3.Name = "lnkWeb3"
        Me.lnkWeb3.Size = New System.Drawing.Size(48, 13)
        Me.lnkWeb3.TabIndex = 47
        Me.lnkWeb3.TabStop = True
        Me.lnkWeb3.Text = "lnkWeb3"
        '
        'lblWarnings
        '
        Me.lblWarnings.AutoSize = True
        Me.lblWarnings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblWarnings.Location = New System.Drawing.Point(0, 3)
        Me.lblWarnings.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.lblWarnings.Name = "lblWarnings"
        Me.lblWarnings.Size = New System.Drawing.Size(62, 13)
        Me.lblWarnings.TabIndex = 50
        Me.lblWarnings.Tag = "Title"
        Me.lblWarnings.Text = "lblWarnings"
        '
        'HorizontalLine16
        '
        Me.HorizontalLine16.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine16.Location = New System.Drawing.Point(3, 25)
        Me.HorizontalLine16.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine16.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine16.Name = "HorizontalLine16"
        Me.HorizontalLine16.Size = New System.Drawing.Size(234, 1)
        Me.HorizontalLine16.TabIndex = 0
        Me.HorizontalLine16.TabStop = False
        '
        'tpHealth
        '
        Me.tpHealth.AutoScroll = True
        Me.tpHealth.Controls.Add(Me.tlpHealth)
        Me.tpHealth.Location = New System.Drawing.Point(4, 22)
        Me.tpHealth.Margin = New System.Windows.Forms.Padding(0)
        Me.tpHealth.Name = "tpHealth"
        Me.tpHealth.Padding = New System.Windows.Forms.Padding(3)
        Me.tpHealth.Size = New System.Drawing.Size(263, 318)
        Me.tpHealth.TabIndex = 1
        Me.tpHealth.Text = "tpHealth"
        Me.tpHealth.UseVisualStyleBackColor = True
        '
        'tlpHealth
        '
        Me.tlpHealth.AutoSize = True
        Me.tlpHealth.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpHealth.ColumnCount = 1
        Me.tlpHealth.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpHealth.Controls.Add(Me.tlpRating, 0, 4)
        Me.tlpHealth.Controls.Add(Me.tlpSummary, 0, 2)
        Me.tlpHealth.Controls.Add(Me.lblSummary, 0, 0)
        Me.tlpHealth.Controls.Add(Me.HorizontalLine17, 0, 1)
        Me.tlpHealth.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpHealth.Location = New System.Drawing.Point(3, 3)
        Me.tlpHealth.Name = "tlpHealth"
        Me.tlpHealth.RowCount = 5
        Me.tlpHealth.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHealth.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHealth.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHealth.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpHealth.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHealth.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpHealth.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpHealth.Size = New System.Drawing.Size(257, 298)
        Me.tlpHealth.TabIndex = 4
        '
        'tlpRating
        '
        Me.tlpRating.AutoSize = True
        Me.tlpRating.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpRating.ColumnCount = 1
        Me.tlpRating.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRating.Controls.Add(Me.lblReliabilityRating, 0, 0)
        Me.tlpRating.Controls.Add(Me.HorizontalLine18, 0, 1)
        Me.tlpRating.Controls.Add(Me.tlpRatingTable, 0, 2)
        Me.tlpRating.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRating.Location = New System.Drawing.Point(0, 183)
        Me.tlpRating.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpRating.Name = "tlpRating"
        Me.tlpRating.RowCount = 3
        Me.tlpRating.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRating.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRating.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRating.Size = New System.Drawing.Size(257, 115)
        Me.tlpRating.TabIndex = 53
        '
        'lblReliabilityRating
        '
        Me.lblReliabilityRating.AutoSize = True
        Me.lblReliabilityRating.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblReliabilityRating.Location = New System.Drawing.Point(0, 3)
        Me.lblReliabilityRating.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.lblReliabilityRating.Name = "lblReliabilityRating"
        Me.lblReliabilityRating.Size = New System.Drawing.Size(48, 13)
        Me.lblReliabilityRating.TabIndex = 51
        Me.lblReliabilityRating.Tag = "Title"
        Me.lblReliabilityRating.Text = "lblRating"
        '
        'HorizontalLine18
        '
        Me.HorizontalLine18.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine18.Location = New System.Drawing.Point(3, 25)
        Me.HorizontalLine18.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine18.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine18.Name = "HorizontalLine18"
        Me.HorizontalLine18.Size = New System.Drawing.Size(251, 1)
        Me.HorizontalLine18.TabIndex = 52
        Me.HorizontalLine18.TabStop = False
        '
        'tlpRatingTable
        '
        Me.tlpRatingTable.AutoSize = True
        Me.tlpRatingTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpRatingTable.ColumnCount = 3
        Me.tlpRatingTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpRatingTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpRatingTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRatingTable.Controls.Add(Me.picOverall, 1, 0)
        Me.tlpRatingTable.Controls.Add(Me.lblRating4, 0, 4)
        Me.tlpRatingTable.Controls.Add(Me.lblRating4Value, 2, 4)
        Me.tlpRatingTable.Controls.Add(Me.lblRating3, 0, 3)
        Me.tlpRatingTable.Controls.Add(Me.lblRating3Value, 2, 3)
        Me.tlpRatingTable.Controls.Add(Me.lblRating2, 0, 2)
        Me.tlpRatingTable.Controls.Add(Me.picRating4, 1, 4)
        Me.tlpRatingTable.Controls.Add(Me.picRating2, 1, 2)
        Me.tlpRatingTable.Controls.Add(Me.picRating3, 1, 3)
        Me.tlpRatingTable.Controls.Add(Me.lblRating2Value, 2, 2)
        Me.tlpRatingTable.Controls.Add(Me.picRating1, 1, 1)
        Me.tlpRatingTable.Controls.Add(Me.lblRating1Value, 2, 1)
        Me.tlpRatingTable.Controls.Add(Me.lblRating1, 0, 1)
        Me.tlpRatingTable.Controls.Add(Me.lblOverall, 0, 0)
        Me.tlpRatingTable.Controls.Add(Me.lblOverallRating, 2, 0)
        Me.tlpRatingTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRatingTable.Location = New System.Drawing.Point(0, 35)
        Me.tlpRatingTable.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpRatingTable.Name = "tlpRatingTable"
        Me.tlpRatingTable.RowCount = 5
        Me.tlpRatingTable.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRatingTable.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRatingTable.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRatingTable.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRatingTable.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRatingTable.Size = New System.Drawing.Size(257, 80)
        Me.tlpRatingTable.TabIndex = 52
        '
        'picOverall
        '
        Me.picOverall.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.picOverall.Location = New System.Drawing.Point(60, 4)
        Me.picOverall.Name = "picOverall"
        Me.picOverall.Size = New System.Drawing.Size(48, 8)
        Me.picOverall.TabIndex = 54
        Me.picOverall.TabStop = False
        '
        'lblRating4
        '
        Me.lblRating4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRating4.AutoEllipsis = True
        Me.lblRating4.AutoSize = True
        Me.lblRating4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblRating4.Location = New System.Drawing.Point(0, 64)
        Me.lblRating4.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblRating4.Name = "lblRating4"
        Me.lblRating4.Size = New System.Drawing.Size(54, 13)
        Me.lblRating4.TabIndex = 5
        Me.lblRating4.Tag = "Grayed"
        Me.lblRating4.Text = "lblRating4"
        '
        'lblRating4Value
        '
        Me.lblRating4Value.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRating4Value.AutoEllipsis = True
        Me.lblRating4Value.AutoSize = True
        Me.lblRating4Value.ForeColor = System.Drawing.Color.Black
        Me.lblRating4Value.Location = New System.Drawing.Point(114, 65)
        Me.lblRating4Value.Name = "lblRating4Value"
        Me.lblRating4Value.Size = New System.Drawing.Size(80, 13)
        Me.lblRating4Value.TabIndex = 25
        Me.lblRating4Value.Text = "lblRating4Value"
        '
        'lblRating3
        '
        Me.lblRating3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRating3.AutoEllipsis = True
        Me.lblRating3.AutoSize = True
        Me.lblRating3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblRating3.Location = New System.Drawing.Point(0, 48)
        Me.lblRating3.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblRating3.Name = "lblRating3"
        Me.lblRating3.Size = New System.Drawing.Size(54, 13)
        Me.lblRating3.TabIndex = 4
        Me.lblRating3.Tag = "Grayed"
        Me.lblRating3.Text = "lblRating3"
        '
        'lblRating3Value
        '
        Me.lblRating3Value.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRating3Value.AutoEllipsis = True
        Me.lblRating3Value.AutoSize = True
        Me.lblRating3Value.ForeColor = System.Drawing.Color.Black
        Me.lblRating3Value.Location = New System.Drawing.Point(114, 49)
        Me.lblRating3Value.Name = "lblRating3Value"
        Me.lblRating3Value.Size = New System.Drawing.Size(80, 13)
        Me.lblRating3Value.TabIndex = 24
        Me.lblRating3Value.Text = "lblRating3Value"
        '
        'lblRating2
        '
        Me.lblRating2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRating2.AutoEllipsis = True
        Me.lblRating2.AutoSize = True
        Me.lblRating2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblRating2.Location = New System.Drawing.Point(0, 32)
        Me.lblRating2.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblRating2.Name = "lblRating2"
        Me.lblRating2.Size = New System.Drawing.Size(54, 13)
        Me.lblRating2.TabIndex = 3
        Me.lblRating2.Tag = "Grayed"
        Me.lblRating2.Text = "lblRating2"
        '
        'picRating4
        '
        Me.picRating4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.picRating4.Location = New System.Drawing.Point(60, 68)
        Me.picRating4.Name = "picRating4"
        Me.picRating4.Size = New System.Drawing.Size(48, 8)
        Me.picRating4.TabIndex = 15
        Me.picRating4.TabStop = False
        '
        'picRating2
        '
        Me.picRating2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.picRating2.Location = New System.Drawing.Point(60, 36)
        Me.picRating2.Name = "picRating2"
        Me.picRating2.Size = New System.Drawing.Size(48, 8)
        Me.picRating2.TabIndex = 13
        Me.picRating2.TabStop = False
        '
        'picRating3
        '
        Me.picRating3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.picRating3.Location = New System.Drawing.Point(60, 52)
        Me.picRating3.Name = "picRating3"
        Me.picRating3.Size = New System.Drawing.Size(48, 8)
        Me.picRating3.TabIndex = 14
        Me.picRating3.TabStop = False
        '
        'lblRating2Value
        '
        Me.lblRating2Value.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRating2Value.AutoEllipsis = True
        Me.lblRating2Value.AutoSize = True
        Me.lblRating2Value.ForeColor = System.Drawing.Color.Black
        Me.lblRating2Value.Location = New System.Drawing.Point(114, 33)
        Me.lblRating2Value.Name = "lblRating2Value"
        Me.lblRating2Value.Size = New System.Drawing.Size(80, 13)
        Me.lblRating2Value.TabIndex = 23
        Me.lblRating2Value.Text = "lblRating2Value"
        '
        'picRating1
        '
        Me.picRating1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.picRating1.Location = New System.Drawing.Point(60, 20)
        Me.picRating1.Name = "picRating1"
        Me.picRating1.Size = New System.Drawing.Size(48, 8)
        Me.picRating1.TabIndex = 12
        Me.picRating1.TabStop = False
        '
        'lblRating1Value
        '
        Me.lblRating1Value.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRating1Value.AutoEllipsis = True
        Me.lblRating1Value.AutoSize = True
        Me.lblRating1Value.ForeColor = System.Drawing.Color.Black
        Me.lblRating1Value.Location = New System.Drawing.Point(114, 17)
        Me.lblRating1Value.Name = "lblRating1Value"
        Me.lblRating1Value.Size = New System.Drawing.Size(80, 13)
        Me.lblRating1Value.TabIndex = 22
        Me.lblRating1Value.Text = "lblRating1Value"
        '
        'lblRating1
        '
        Me.lblRating1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRating1.AutoEllipsis = True
        Me.lblRating1.AutoSize = True
        Me.lblRating1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblRating1.Location = New System.Drawing.Point(0, 16)
        Me.lblRating1.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblRating1.Name = "lblRating1"
        Me.lblRating1.Size = New System.Drawing.Size(54, 13)
        Me.lblRating1.TabIndex = 1
        Me.lblRating1.Tag = "Grayed"
        Me.lblRating1.Text = "lblRating1"
        '
        'lblOverall
        '
        Me.lblOverall.AutoSize = True
        Me.lblOverall.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblOverall.Location = New System.Drawing.Point(0, 0)
        Me.lblOverall.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblOverall.Name = "lblOverall"
        Me.lblOverall.Size = New System.Drawing.Size(51, 13)
        Me.lblOverall.TabIndex = 26
        Me.lblOverall.Tag = "Grayed"
        Me.lblOverall.Text = "lblOverall"
        '
        'lblOverallRating
        '
        Me.lblOverallRating.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOverallRating.AutoSize = True
        Me.lblOverallRating.Location = New System.Drawing.Point(114, 1)
        Me.lblOverallRating.Name = "lblOverallRating"
        Me.lblOverallRating.Size = New System.Drawing.Size(82, 13)
        Me.lblOverallRating.TabIndex = 27
        Me.lblOverallRating.Text = "lblOverallRating"
        '
        'tlpSummary
        '
        Me.tlpSummary.AutoSize = True
        Me.tlpSummary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSummary.ColumnCount = 2
        Me.tlpSummary.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSummary.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSummary.Controls.Add(Me.lblTemp, 0, 0)
        Me.tlpSummary.Controls.Add(Me.lblTempValue, 1, 0)
        Me.tlpSummary.Controls.Add(Me.lblErrors, 1, 5)
        Me.tlpSummary.Controls.Add(Me.lblBadSectors, 1, 4)
        Me.tlpSummary.Controls.Add(Me.lblHealth, 0, 3)
        Me.tlpSummary.Controls.Add(Me.lblHealthValue, 1, 3)
        Me.tlpSummary.Controls.Add(Me.lblLastTestValue, 1, 2)
        Me.tlpSummary.Controls.Add(Me.lblLastTest, 0, 2)
        Me.tlpSummary.Controls.Add(Me.lblLastUpdate, 0, 7)
        Me.tlpSummary.Controls.Add(Me.lblLastUpdateValue, 1, 7)
        Me.tlpSummary.Controls.Add(Me.lblRemainingLife, 0, 1)
        Me.tlpSummary.Controls.Add(Me.lblRemainingLifeValue, 1, 1)
        Me.tlpSummary.Controls.Add(Me.lblWorkTime, 0, 6)
        Me.tlpSummary.Controls.Add(Me.lblWorkTimeValue, 1, 6)
        Me.tlpSummary.Controls.Add(Me.exlBadSectors, 0, 4)
        Me.tlpSummary.Controls.Add(Me.exlErrors, 0, 5)
        Me.tlpSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSummary.Location = New System.Drawing.Point(0, 35)
        Me.tlpSummary.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpSummary.Name = "tlpSummary"
        Me.tlpSummary.RowCount = 8
        Me.tlpSummary.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSummary.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSummary.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSummary.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSummary.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSummary.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSummary.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSummary.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSummary.Size = New System.Drawing.Size(257, 128)
        Me.tlpSummary.TabIndex = 4
        '
        'lblTemp
        '
        Me.lblTemp.AutoSize = True
        Me.lblTemp.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblTemp.Location = New System.Drawing.Point(0, 0)
        Me.lblTemp.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblTemp.Name = "lblTemp"
        Me.lblTemp.Size = New System.Drawing.Size(43, 13)
        Me.lblTemp.TabIndex = 0
        Me.lblTemp.Tag = "Grayed"
        Me.lblTemp.Text = "lblTemp"
        '
        'lblTempValue
        '
        Me.lblTempValue.AutoEllipsis = True
        Me.lblTempValue.AutoSize = True
        Me.lblTempValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTempValue.ForeColor = System.Drawing.Color.Black
        Me.lblTempValue.Location = New System.Drawing.Point(89, 0)
        Me.lblTempValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblTempValue.Name = "lblTempValue"
        Me.lblTempValue.Size = New System.Drawing.Size(165, 13)
        Me.lblTempValue.TabIndex = 1
        Me.lblTempValue.Text = "lblTempValue"
        '
        'lblErrors
        '
        Me.lblErrors.AutoEllipsis = True
        Me.lblErrors.AutoSize = True
        Me.lblErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblErrors.ForeColor = System.Drawing.Color.Black
        Me.lblErrors.Location = New System.Drawing.Point(89, 80)
        Me.lblErrors.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblErrors.Name = "lblErrors"
        Me.lblErrors.Size = New System.Drawing.Size(165, 13)
        Me.lblErrors.TabIndex = 12
        Me.lblErrors.Text = "lblErrors"
        '
        'lblBadSectors
        '
        Me.lblBadSectors.AutoEllipsis = True
        Me.lblBadSectors.AutoSize = True
        Me.lblBadSectors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBadSectors.ForeColor = System.Drawing.Color.Black
        Me.lblBadSectors.Location = New System.Drawing.Point(89, 64)
        Me.lblBadSectors.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblBadSectors.Name = "lblBadSectors"
        Me.lblBadSectors.Size = New System.Drawing.Size(165, 13)
        Me.lblBadSectors.TabIndex = 5
        Me.lblBadSectors.Text = "lblBadSectors"
        '
        'lblHealth
        '
        Me.lblHealth.AutoSize = True
        Me.lblHealth.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblHealth.Location = New System.Drawing.Point(0, 48)
        Me.lblHealth.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblHealth.Name = "lblHealth"
        Me.lblHealth.Size = New System.Drawing.Size(48, 13)
        Me.lblHealth.TabIndex = 9
        Me.lblHealth.Tag = "Grayed"
        Me.lblHealth.Text = "lblHealth"
        '
        'lblHealthValue
        '
        Me.lblHealthValue.AutoEllipsis = True
        Me.lblHealthValue.AutoSize = True
        Me.lblHealthValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHealthValue.ForeColor = System.Drawing.Color.Black
        Me.lblHealthValue.Location = New System.Drawing.Point(89, 48)
        Me.lblHealthValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblHealthValue.Name = "lblHealthValue"
        Me.lblHealthValue.Size = New System.Drawing.Size(165, 13)
        Me.lblHealthValue.TabIndex = 11
        Me.lblHealthValue.Text = "lblHealthValue"
        '
        'lblLastTestValue
        '
        Me.lblLastTestValue.AutoEllipsis = True
        Me.lblLastTestValue.AutoSize = True
        Me.lblLastTestValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLastTestValue.ForeColor = System.Drawing.Color.Black
        Me.lblLastTestValue.Location = New System.Drawing.Point(89, 32)
        Me.lblLastTestValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLastTestValue.Name = "lblLastTestValue"
        Me.lblLastTestValue.Size = New System.Drawing.Size(165, 13)
        Me.lblLastTestValue.TabIndex = 8
        Me.lblLastTestValue.Text = "lblLastTestValue"
        '
        'lblLastTest
        '
        Me.lblLastTest.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLastTest.AutoSize = True
        Me.lblLastTest.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblLastTest.Location = New System.Drawing.Point(0, 32)
        Me.lblLastTest.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLastTest.Name = "lblLastTest"
        Me.lblLastTest.Size = New System.Drawing.Size(58, 13)
        Me.lblLastTest.TabIndex = 6
        Me.lblLastTest.Tag = "Grayed"
        Me.lblLastTest.Text = "lblLastTest"
        '
        'lblLastUpdate
        '
        Me.lblLastUpdate.AutoSize = True
        Me.lblLastUpdate.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblLastUpdate.Location = New System.Drawing.Point(0, 112)
        Me.lblLastUpdate.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLastUpdate.Name = "lblLastUpdate"
        Me.lblLastUpdate.Size = New System.Drawing.Size(72, 13)
        Me.lblLastUpdate.TabIndex = 56
        Me.lblLastUpdate.Tag = "Grayed"
        Me.lblLastUpdate.Text = "lblLastUpdate"
        '
        'lblLastUpdateValue
        '
        Me.lblLastUpdateValue.AutoEllipsis = True
        Me.lblLastUpdateValue.AutoSize = True
        Me.lblLastUpdateValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLastUpdateValue.ForeColor = System.Drawing.Color.Black
        Me.lblLastUpdateValue.Location = New System.Drawing.Point(89, 112)
        Me.lblLastUpdateValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLastUpdateValue.Name = "lblLastUpdateValue"
        Me.lblLastUpdateValue.Size = New System.Drawing.Size(165, 13)
        Me.lblLastUpdateValue.TabIndex = 57
        Me.lblLastUpdateValue.Text = "lblLastUpdateValue"
        '
        'lblRemainingLife
        '
        Me.lblRemainingLife.AutoSize = True
        Me.lblRemainingLife.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblRemainingLife.Location = New System.Drawing.Point(0, 16)
        Me.lblRemainingLife.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblRemainingLife.Name = "lblRemainingLife"
        Me.lblRemainingLife.Size = New System.Drawing.Size(83, 13)
        Me.lblRemainingLife.TabIndex = 37
        Me.lblRemainingLife.Tag = "Grayed"
        Me.lblRemainingLife.Text = "lblRemainingLife"
        '
        'lblRemainingLifeValue
        '
        Me.lblRemainingLifeValue.AutoEllipsis = True
        Me.lblRemainingLifeValue.AutoSize = True
        Me.lblRemainingLifeValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRemainingLifeValue.ForeColor = System.Drawing.Color.Black
        Me.lblRemainingLifeValue.Location = New System.Drawing.Point(89, 16)
        Me.lblRemainingLifeValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblRemainingLifeValue.Name = "lblRemainingLifeValue"
        Me.lblRemainingLifeValue.Size = New System.Drawing.Size(165, 13)
        Me.lblRemainingLifeValue.TabIndex = 38
        Me.lblRemainingLifeValue.Text = "lblRemainingLifeValue"
        '
        'lblWorkTime
        '
        Me.lblWorkTime.AutoSize = True
        Me.lblWorkTime.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblWorkTime.Location = New System.Drawing.Point(0, 96)
        Me.lblWorkTime.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblWorkTime.Name = "lblWorkTime"
        Me.lblWorkTime.Size = New System.Drawing.Size(64, 13)
        Me.lblWorkTime.TabIndex = 60
        Me.lblWorkTime.Tag = "Grayed"
        Me.lblWorkTime.Text = "lblWorkTime"
        '
        'lblWorkTimeValue
        '
        Me.lblWorkTimeValue.AutoEllipsis = True
        Me.lblWorkTimeValue.AutoSize = True
        Me.lblWorkTimeValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblWorkTimeValue.ForeColor = System.Drawing.Color.Black
        Me.lblWorkTimeValue.Location = New System.Drawing.Point(89, 96)
        Me.lblWorkTimeValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblWorkTimeValue.Name = "lblWorkTimeValue"
        Me.lblWorkTimeValue.Size = New System.Drawing.Size(165, 13)
        Me.lblWorkTimeValue.TabIndex = 61
        Me.lblWorkTimeValue.Text = "lblWorkTimeValue"
        '
        'exlBadSectors
        '
        Me.exlBadSectors.AtaText = Nothing
        Me.exlBadSectors.AutoSize = True
        Me.exlBadSectors.ForeColor = System.Drawing.SystemColors.GrayText
        Me.exlBadSectors.Location = New System.Drawing.Point(0, 64)
        Me.exlBadSectors.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.exlBadSectors.Name = "exlBadSectors"
        Me.exlBadSectors.ScsiText = Nothing
        Me.exlBadSectors.Size = New System.Drawing.Size(75, 13)
        Me.exlBadSectors.TabIndex = 62
        Me.exlBadSectors.Tag = "Grayed"
        Me.exlBadSectors.Text = "exlBadSectors"
        '
        'exlErrors
        '
        Me.exlErrors.AtaText = Nothing
        Me.exlErrors.AutoSize = True
        Me.exlErrors.ForeColor = System.Drawing.SystemColors.GrayText
        Me.exlErrors.Location = New System.Drawing.Point(0, 80)
        Me.exlErrors.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.exlErrors.Name = "exlErrors"
        Me.exlErrors.ScsiText = Nothing
        Me.exlErrors.Size = New System.Drawing.Size(50, 13)
        Me.exlErrors.TabIndex = 63
        Me.exlErrors.Tag = "Grayed"
        Me.exlErrors.Text = "exlErrors"
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSummary.Location = New System.Drawing.Point(0, 3)
        Me.lblSummary.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(61, 13)
        Me.lblSummary.TabIndex = 50
        Me.lblSummary.Tag = "Title"
        Me.lblSummary.Text = "lblSummary"
        '
        'HorizontalLine17
        '
        Me.HorizontalLine17.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine17.Location = New System.Drawing.Point(3, 25)
        Me.HorizontalLine17.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine17.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine17.Name = "HorizontalLine17"
        Me.HorizontalLine17.Size = New System.Drawing.Size(251, 1)
        Me.HorizontalLine17.TabIndex = 51
        Me.HorizontalLine17.TabStop = False
        '
        'picManufacturer
        '
        Me.picManufacturer.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.picManufacturer.Location = New System.Drawing.Point(50, 3)
        Me.picManufacturer.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.picManufacturer.MaximumSize = New System.Drawing.Size(170, 50)
        Me.picManufacturer.MinimumSize = New System.Drawing.Size(170, 50)
        Me.picManufacturer.Name = "picManufacturer"
        Me.picManufacturer.Size = New System.Drawing.Size(170, 50)
        Me.picManufacturer.TabIndex = 4
        Me.picManufacturer.TabStop = False
        '
        'lvwDevices
        '
        Me.lvwDevices.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvwDevices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName})
        Me.lvwDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwDevices.FullRowSelect = True
        ListViewGroup1.Header = "Phisycal"
        ListViewGroup1.Name = "grpPhisycal"
        ListViewGroup2.Header = "External"
        ListViewGroup2.Name = "grpExternal"
        ListViewGroup3.Header = "Virtual"
        ListViewGroup3.Name = "grpVirtual"
        Me.lvwDevices.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.lvwDevices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwDevices.HideSelection = False
        Me.lvwDevices.Location = New System.Drawing.Point(0, 0)
        Me.lvwDevices.Margin = New System.Windows.Forms.Padding(0)
        Me.lvwDevices.MultiSelect = False
        Me.lvwDevices.Name = "lvwDevices"
        Me.lvwDevices.OwnerDraw = True
        Me.lvwDevices.Size = New System.Drawing.Size(598, 413)
        Me.lvwDevices.TabIndex = 0
        Me.lvwDevices.UseCompatibleStateImageBehavior = False
        Me.lvwDevices.View = System.Windows.Forms.View.Details
        '
        'chName
        '
        Me.chName.Text = "chName"
        Me.chName.Width = 950
        '
        'rspOverview
        '
        Me.rspOverview.BackColor = System.Drawing.Color.Transparent
        Me.rspOverview.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.rspOverview.Dock = System.Windows.Forms.DockStyle.Left
        Me.rspOverview.Location = New System.Drawing.Point(601, 3)
        Me.rspOverview.Name = "rspOverview"
        Me.rspOverview.Padding = New System.Windows.Forms.Padding(1)
        Me.rspOverview.Size = New System.Drawing.Size(3, 407)
        Me.rspOverview.TabIndex = 23
        '
        'RibbonHorizontalSeparator2
        '
        RibbonHorizontalSeparator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        RibbonHorizontalSeparator2.Dock = System.Windows.Forms.DockStyle.Top
        RibbonHorizontalSeparator2.Location = New System.Drawing.Point(0, 34)
        RibbonHorizontalSeparator2.MaximumSize = New System.Drawing.Size(0, 1)
        RibbonHorizontalSeparator2.MinimumSize = New System.Drawing.Size(80, 1)
        RibbonHorizontalSeparator2.Name = "RibbonHorizontalSeparator2"
        RibbonHorizontalSeparator2.Size = New System.Drawing.Size(884, 1)
        RibbonHorizontalSeparator2.TabIndex = 25
        '
        'tlpMenuItems
        '
        Me.tlpMenuItems.AutoSize = True
        Me.tlpMenuItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMenuItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tlpMenuItems.ColumnCount = 6
        Me.tlpMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenuItems.Controls.Add(Me.mrbUpdateAll, 0, 0)
        Me.tlpMenuItems.Controls.Add(Me.picOverviewHelp, 5, 0)
        Me.tlpMenuItems.Controls.Add(Me.mrcSidePanel, 4, 0)
        Me.tlpMenuItems.Controls.Add(Me.mrbAddVirtual, 2, 0)
        Me.tlpMenuItems.Controls.Add(Me.mrbRescanUsb, 1, 0)
        Me.tlpMenuItems.Controls.Add(Me.RibbonVerticalSeparator7, 3, 0)
        Me.tlpMenuItems.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpMenuItems.Location = New System.Drawing.Point(0, 0)
        Me.tlpMenuItems.Name = "tlpMenuItems"
        Me.tlpMenuItems.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.tlpMenuItems.RowCount = 1
        Me.tlpMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMenuItems.Size = New System.Drawing.Size(884, 34)
        Me.tlpMenuItems.TabIndex = 24
        '
        'mrbUpdateAll
        '
        Me.mrbUpdateAll.AutoSize = True
        Me.mrbUpdateAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbUpdateAll.BackColor = System.Drawing.Color.Transparent
        Me.mrbUpdateAll.FlatAppearance.BorderSize = 0
        Me.mrbUpdateAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbUpdateAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbUpdateAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbUpdateAll.Icon = Nothing
        Me.mrbUpdateAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrbUpdateAll.Location = New System.Drawing.Point(3, 6)
        Me.mrbUpdateAll.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbUpdateAll.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbUpdateAll.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbUpdateAll.Name = "mrbUpdateAll"
        Me.mrbUpdateAll.Size = New System.Drawing.Size(81, 22)
        Me.mrbUpdateAll.TabIndex = 4
        Me.mrbUpdateAll.Text = "mrbUpdateAll"
        Me.mrbUpdateAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbUpdateAll.UseVisualStyleBackColor = False
        '
        'picOverviewHelp
        '
        Me.picOverviewHelp.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.picOverviewHelp.Location = New System.Drawing.Point(863, 9)
        Me.picOverviewHelp.Margin = New System.Windows.Forms.Padding(2)
        Me.picOverviewHelp.Name = "picOverviewHelp"
        Me.picOverviewHelp.Size = New System.Drawing.Size(16, 16)
        Me.picOverviewHelp.TabIndex = 3
        Me.picOverviewHelp.TabStop = False
        '
        'mrcSidePanel
        '
        Me.mrcSidePanel.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrcSidePanel.AutoSize = True
        Me.mrcSidePanel.BackColor = System.Drawing.Color.Transparent
        Me.mrcSidePanel.FlatAppearance.BorderSize = 0
        Me.mrcSidePanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrcSidePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrcSidePanel.Icon = Nothing
        Me.mrcSidePanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrcSidePanel.Location = New System.Drawing.Point(263, 6)
        Me.mrcSidePanel.Margin = New System.Windows.Forms.Padding(0)
        Me.mrcSidePanel.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrcSidePanel.MinimumSize = New System.Drawing.Size(56, 22)
        Me.mrcSidePanel.Name = "mrcSidePanel"
        Me.mrcSidePanel.Size = New System.Drawing.Size(80, 22)
        Me.mrcSidePanel.TabIndex = 7
        Me.mrcSidePanel.Text = "mrcSidePanel"
        Me.mrcSidePanel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrcSidePanel.UseVisualStyleBackColor = False
        '
        'mrbAddVirtual
        '
        Me.mrbAddVirtual.AutoSize = True
        Me.mrbAddVirtual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbAddVirtual.BackColor = System.Drawing.Color.Transparent
        Me.mrbAddVirtual.FlatAppearance.BorderSize = 0
        Me.mrbAddVirtual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbAddVirtual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbAddVirtual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbAddVirtual.Icon = Nothing
        Me.mrbAddVirtual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrbAddVirtual.Location = New System.Drawing.Point(172, 6)
        Me.mrbAddVirtual.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbAddVirtual.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbAddVirtual.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbAddVirtual.Name = "mrbAddVirtual"
        Me.mrbAddVirtual.Size = New System.Drawing.Size(84, 22)
        Me.mrbAddVirtual.TabIndex = 6
        Me.mrbAddVirtual.Text = "mrbAddVirtual"
        Me.mrbAddVirtual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbAddVirtual.UseVisualStyleBackColor = False
        '
        'mrbRescanUsb
        '
        Me.mrbRescanUsb.AutoSize = True
        Me.mrbRescanUsb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbRescanUsb.BackColor = System.Drawing.Color.Transparent
        Me.mrbRescanUsb.FlatAppearance.BorderSize = 0
        Me.mrbRescanUsb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbRescanUsb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbRescanUsb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbRescanUsb.Icon = Nothing
        Me.mrbRescanUsb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrbRescanUsb.Location = New System.Drawing.Point(84, 6)
        Me.mrbRescanUsb.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbRescanUsb.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbRescanUsb.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbRescanUsb.Name = "mrbRescanUsb"
        Me.mrbRescanUsb.Size = New System.Drawing.Size(88, 22)
        Me.mrbRescanUsb.TabIndex = 5
        Me.mrbRescanUsb.Text = "mrbRescanUsb"
        Me.mrbRescanUsb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbRescanUsb.UseVisualStyleBackColor = False
        '
        'RibbonVerticalSeparator7
        '
        Me.RibbonVerticalSeparator7.AutoSize = True
        Me.RibbonVerticalSeparator7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.RibbonVerticalSeparator7.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator7.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonVerticalSeparator7.Location = New System.Drawing.Point(259, 6)
        Me.RibbonVerticalSeparator7.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.RibbonVerticalSeparator7.MaximumSize = New System.Drawing.Size(1, 80)
        Me.RibbonVerticalSeparator7.MinimumSize = New System.Drawing.Size(1, 0)
        Me.RibbonVerticalSeparator7.Name = "RibbonVerticalSeparator7"
        Me.RibbonVerticalSeparator7.Size = New System.Drawing.Size(1, 22)
        Me.RibbonVerticalSeparator7.TabIndex = 8
        '
        'tpManage
        '
        Me.tpManage.BackColor = System.Drawing.Color.White
        Me.tpManage.Controls.Add(Me.tlpManage)
        Me.tpManage.Controls.Add(Me.RibbonHorizontalSeparator3)
        Me.tpManage.Controls.Add(Me.tlpManageMenuContent)
        Me.tpManage.Location = New System.Drawing.Point(4, 22)
        Me.tpManage.Name = "tpManage"
        Me.tpManage.Size = New System.Drawing.Size(884, 448)
        Me.tpManage.TabIndex = 1
        Me.tpManage.Text = "tpManage"
        '
        'tlpManage
        '
        Me.tlpManage.ColumnCount = 3
        Me.tlpManage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlpManage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpManage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpManage.Controls.Add(Me.htcManage, 2, 0)
        Me.tlpManage.Controls.Add(Me.pnlSideMenu, 0, 0)
        Me.tlpManage.Controls.Add(Me.rspManage, 1, 0)
        Me.tlpManage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpManage.Location = New System.Drawing.Point(0, 35)
        Me.tlpManage.Name = "tlpManage"
        Me.tlpManage.RowCount = 1
        Me.tlpManage.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpManage.Size = New System.Drawing.Size(884, 413)
        Me.tlpManage.TabIndex = 32
        '
        'htcManage
        '
        Me.htcManage.Controls.Add(Me.tpInfo)
        Me.htcManage.Controls.Add(Me.tpSetup)
        Me.htcManage.Controls.Add(Me.tpErrorsTests)
        Me.htcManage.Controls.Add(Me.tpSmartctl)
        Me.htcManage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htcManage.Location = New System.Drawing.Point(162, 3)
        Me.htcManage.Name = "htcManage"
        Me.htcManage.SelectedIndex = 0
        Me.htcManage.Size = New System.Drawing.Size(719, 407)
        Me.htcManage.TabIndex = 30
        Me.htcManage.TabStop = False
        '
        'tpInfo
        '
        Me.tpInfo.BackColor = System.Drawing.Color.White
        Me.tpInfo.Controls.Add(Me.htcInfo)
        Me.tpInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpInfo.Name = "tpInfo"
        Me.tpInfo.Size = New System.Drawing.Size(711, 381)
        Me.tpInfo.TabIndex = 0
        Me.tpInfo.Text = "tpInfo"
        '
        'htcInfo
        '
        Me.htcInfo.Controls.Add(Me.tpAtaSmartAttributes)
        Me.htcInfo.Controls.Add(Me.tpEvents)
        Me.htcInfo.Controls.Add(Me.tpTemperatures)
        Me.htcInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htcInfo.Location = New System.Drawing.Point(0, 0)
        Me.htcInfo.Name = "htcInfo"
        Me.htcInfo.SelectedIndex = 0
        Me.htcInfo.Size = New System.Drawing.Size(711, 381)
        Me.htcInfo.TabIndex = 0
        Me.htcInfo.TabStop = False
        '
        'tpAtaSmartAttributes
        '
        Me.tpAtaSmartAttributes.BackColor = System.Drawing.Color.White
        Me.tpAtaSmartAttributes.Controls.Add(Me.tlpAttributes)
        Me.tpAtaSmartAttributes.Location = New System.Drawing.Point(4, 22)
        Me.tpAtaSmartAttributes.Name = "tpAtaSmartAttributes"
        Me.tpAtaSmartAttributes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAtaSmartAttributes.Size = New System.Drawing.Size(703, 355)
        Me.tpAtaSmartAttributes.TabIndex = 4
        Me.tpAtaSmartAttributes.Text = "tpAtaSmartAttributes"
        '
        'tlpAttributes
        '
        Me.tlpAttributes.ColumnCount = 2
        Me.tlpAttributes.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAttributes.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.tlpAttributes.Controls.Add(Me.lvwSmart, 0, 0)
        Me.tlpAttributes.Controls.Add(Me.pnlAttribuesInfo, 1, 0)
        Me.tlpAttributes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpAttributes.Location = New System.Drawing.Point(3, 3)
        Me.tlpAttributes.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.tlpAttributes.Name = "tlpAttributes"
        Me.tlpAttributes.RowCount = 1
        Me.tlpAttributes.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAttributes.Size = New System.Drawing.Size(697, 349)
        Me.tlpAttributes.TabIndex = 27
        '
        'lvwSmart
        '
        Me.lvwSmart.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chID, Me.chAttribute, Me.chRawValue, Me.chValues})
        Me.lvwSmart.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvwSmart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwSmart.FullRowSelect = True
        Me.lvwSmart.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwSmart.Location = New System.Drawing.Point(0, 0)
        Me.lvwSmart.Margin = New System.Windows.Forms.Padding(0)
        Me.lvwSmart.MultiSelect = False
        Me.lvwSmart.Name = "lvwSmart"
        Me.lvwSmart.OwnerDraw = True
        Me.lvwSmart.Size = New System.Drawing.Size(447, 349)
        Me.lvwSmart.TabIndex = 0
        Me.lvwSmart.UseCompatibleStateImageBehavior = False
        Me.lvwSmart.View = System.Windows.Forms.View.Details
        '
        'chID
        '
        Me.chID.Text = "chID"
        '
        'chAttribute
        '
        Me.chAttribute.Text = "chAttribute"
        Me.chAttribute.Width = 75
        '
        'chRawValue
        '
        Me.chRawValue.Text = "chRawValue"
        Me.chRawValue.Width = 74
        '
        'chValues
        '
        Me.chValues.Text = "chValues"
        '
        'pnlAttribuesInfo
        '
        Me.pnlAttribuesInfo.AutoScroll = True
        Me.pnlAttribuesInfo.Controls.Add(Me.tlpAttributeDetails)
        Me.pnlAttribuesInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAttribuesInfo.Location = New System.Drawing.Point(447, 0)
        Me.pnlAttribuesInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAttribuesInfo.Name = "pnlAttribuesInfo"
        Me.pnlAttribuesInfo.Size = New System.Drawing.Size(250, 349)
        Me.pnlAttribuesInfo.TabIndex = 1
        '
        'tlpAttributeDetails
        '
        Me.tlpAttributeDetails.AutoSize = True
        Me.tlpAttributeDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpAttributeDetails.ColumnCount = 1
        Me.tlpAttributeDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAttributeDetails.Controls.Add(Me.lblMeaning, 0, 3)
        Me.tlpAttributeDetails.Controls.Add(Me.lblDataStructure, 0, 0)
        Me.tlpAttributeDetails.Controls.Add(Me.lblTitle, 0, 2)
        Me.tlpAttributeDetails.Controls.Add(Me.lblPrefailure, 0, 6)
        Me.tlpAttributeDetails.Controls.Add(Me.lblOnline, 0, 7)
        Me.tlpAttributeDetails.Controls.Add(Me.lblSpeed, 0, 8)
        Me.tlpAttributeDetails.Controls.Add(Me.lblErrRate, 0, 9)
        Me.tlpAttributeDetails.Controls.Add(Me.lblEvCount, 0, 10)
        Me.tlpAttributeDetails.Controls.Add(Me.lblSelfPres, 0, 11)
        Me.tlpAttributeDetails.Controls.Add(Me.lblFlags, 0, 5)
        Me.tlpAttributeDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpAttributeDetails.Location = New System.Drawing.Point(0, 0)
        Me.tlpAttributeDetails.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.tlpAttributeDetails.Name = "tlpAttributeDetails"
        Me.tlpAttributeDetails.RowCount = 13
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAttributeDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpAttributeDetails.Size = New System.Drawing.Size(250, 193)
        Me.tlpAttributeDetails.TabIndex = 28
        '
        'lblMeaning
        '
        Me.lblMeaning.AutoSize = True
        Me.lblMeaning.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMeaning.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeaning.ForeColor = System.Drawing.Color.Black
        Me.lblMeaning.Location = New System.Drawing.Point(3, 45)
        Me.lblMeaning.Margin = New System.Windows.Forms.Padding(3)
        Me.lblMeaning.Name = "lblMeaning"
        Me.lblMeaning.Size = New System.Drawing.Size(244, 13)
        Me.lblMeaning.TabIndex = 6
        Me.lblMeaning.Text = "lblMeaning"
        '
        'lblDataStructure
        '
        Me.lblDataStructure.AutoSize = True
        Me.lblDataStructure.ForeColor = System.Drawing.Color.Black
        Me.lblDataStructure.Location = New System.Drawing.Point(0, 0)
        Me.lblDataStructure.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDataStructure.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblDataStructure.Name = "lblDataStructure"
        Me.lblDataStructure.Size = New System.Drawing.Size(85, 16)
        Me.lblDataStructure.TabIndex = 13
        Me.lblDataStructure.Text = "lblDataStructure"
        Me.lblDataStructure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(0, 26)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTitle.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(37, 16)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Tag = "Group"
        Me.lblTitle.Text = "lblTitle"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrefailure
        '
        Me.lblPrefailure.AutoSize = True
        Me.lblPrefailure.ForeColor = System.Drawing.Color.Black
        Me.lblPrefailure.Location = New System.Drawing.Point(3, 87)
        Me.lblPrefailure.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblPrefailure.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblPrefailure.Name = "lblPrefailure"
        Me.lblPrefailure.Size = New System.Drawing.Size(63, 16)
        Me.lblPrefailure.TabIndex = 0
        Me.lblPrefailure.Text = "lblPrefailure"
        Me.lblPrefailure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOnline
        '
        Me.lblOnline.AutoSize = True
        Me.lblOnline.ForeColor = System.Drawing.Color.Black
        Me.lblOnline.Location = New System.Drawing.Point(3, 103)
        Me.lblOnline.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblOnline.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblOnline.Name = "lblOnline"
        Me.lblOnline.Size = New System.Drawing.Size(47, 16)
        Me.lblOnline.TabIndex = 1
        Me.lblOnline.Text = "lblOnline"
        Me.lblOnline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSpeed
        '
        Me.lblSpeed.AutoSize = True
        Me.lblSpeed.ForeColor = System.Drawing.Color.Black
        Me.lblSpeed.Location = New System.Drawing.Point(3, 119)
        Me.lblSpeed.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblSpeed.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(47, 16)
        Me.lblSpeed.TabIndex = 2
        Me.lblSpeed.Text = "lblSpeed"
        Me.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblErrRate
        '
        Me.lblErrRate.AutoSize = True
        Me.lblErrRate.ForeColor = System.Drawing.Color.Black
        Me.lblErrRate.Location = New System.Drawing.Point(3, 135)
        Me.lblErrRate.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblErrRate.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblErrRate.Name = "lblErrRate"
        Me.lblErrRate.Size = New System.Drawing.Size(54, 16)
        Me.lblErrRate.TabIndex = 3
        Me.lblErrRate.Text = "lblErrRate"
        Me.lblErrRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvCount
        '
        Me.lblEvCount.AutoSize = True
        Me.lblEvCount.ForeColor = System.Drawing.Color.Black
        Me.lblEvCount.Location = New System.Drawing.Point(3, 151)
        Me.lblEvCount.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEvCount.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblEvCount.Name = "lblEvCount"
        Me.lblEvCount.Size = New System.Drawing.Size(58, 16)
        Me.lblEvCount.TabIndex = 4
        Me.lblEvCount.Text = "lblEvCount"
        Me.lblEvCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSelfPres
        '
        Me.lblSelfPres.AutoSize = True
        Me.lblSelfPres.ForeColor = System.Drawing.Color.Black
        Me.lblSelfPres.Location = New System.Drawing.Point(3, 167)
        Me.lblSelfPres.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblSelfPres.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblSelfPres.Name = "lblSelfPres"
        Me.lblSelfPres.Size = New System.Drawing.Size(56, 16)
        Me.lblSelfPres.TabIndex = 5
        Me.lblSelfPres.Text = "lblSelfPres"
        Me.lblSelfPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFlags
        '
        Me.lblFlags.AutoSize = True
        Me.lblFlags.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblFlags.Location = New System.Drawing.Point(0, 71)
        Me.lblFlags.Margin = New System.Windows.Forms.Padding(0)
        Me.lblFlags.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblFlags.Name = "lblFlags"
        Me.lblFlags.Size = New System.Drawing.Size(42, 16)
        Me.lblFlags.TabIndex = 6
        Me.lblFlags.Tag = "Group"
        Me.lblFlags.Text = "lblFlags"
        Me.lblFlags.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpEvents
        '
        Me.tpEvents.AutoScroll = True
        Me.tpEvents.BackColor = System.Drawing.Color.White
        Me.tpEvents.Controls.Add(Me.tlpChartContent)
        Me.tpEvents.Location = New System.Drawing.Point(4, 22)
        Me.tpEvents.Name = "tpEvents"
        Me.tpEvents.Size = New System.Drawing.Size(703, 355)
        Me.tpEvents.TabIndex = 3
        Me.tpEvents.Text = "tpEvents"
        '
        'tlpChartContent
        '
        Me.tlpChartContent.AutoSize = True
        Me.tlpChartContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpChartContent.ColumnCount = 2
        Me.tlpChartContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChartContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpChartContent.Controls.Add(Me.lblNoEvents, 0, 0)
        Me.tlpChartContent.Controls.Add(Me.tlpDisplayEvent, 1, 1)
        Me.tlpChartContent.Controls.Add(Me.tlpEventChart, 0, 1)
        Me.tlpChartContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpChartContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpChartContent.Name = "tlpChartContent"
        Me.tlpChartContent.RowCount = 2
        Me.tlpChartContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpChartContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChartContent.Size = New System.Drawing.Size(703, 355)
        Me.tlpChartContent.TabIndex = 24
        '
        'lblNoEvents
        '
        Me.lblNoEvents.AutoSize = True
        Me.lblNoEvents.ForeColor = System.Drawing.Color.Black
        Me.lblNoEvents.Location = New System.Drawing.Point(3, 0)
        Me.lblNoEvents.MinimumSize = New System.Drawing.Size(0, 23)
        Me.lblNoEvents.Name = "lblNoEvents"
        Me.lblNoEvents.Size = New System.Drawing.Size(63, 23)
        Me.lblNoEvents.TabIndex = 26
        Me.lblNoEvents.Text = "lblNoEvents"
        Me.lblNoEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpDisplayEvent
        '
        Me.tlpDisplayEvent.AutoSize = True
        Me.tlpDisplayEvent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDisplayEvent.ColumnCount = 1
        Me.tlpDisplayEvent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisplayEvent.Controls.Add(Me.lvwEvents, 0, 0)
        Me.tlpDisplayEvent.Controls.Add(Me.mcLog, 0, 5)
        Me.tlpDisplayEvent.Controls.Add(Me.lblDisplay, 0, 2)
        Me.tlpDisplayEvent.Controls.Add(Me.tlpLogCmd, 0, 7)
        Me.tlpDisplayEvent.Controls.Add(Me.RibbonHorizontalSeparator4, 0, 1)
        Me.tlpDisplayEvent.Controls.Add(Me.optEntire, 0, 3)
        Me.tlpDisplayEvent.Controls.Add(Me.optSelection, 0, 4)
        Me.tlpDisplayEvent.Controls.Add(Me.RibbonHorizontalSeparator7, 0, 6)
        Me.tlpDisplayEvent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDisplayEvent.Location = New System.Drawing.Point(468, 23)
        Me.tlpDisplayEvent.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpDisplayEvent.Name = "tlpDisplayEvent"
        Me.tlpDisplayEvent.RowCount = 8
        Me.tlpDisplayEvent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDisplayEvent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisplayEvent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisplayEvent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisplayEvent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisplayEvent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisplayEvent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisplayEvent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisplayEvent.Size = New System.Drawing.Size(235, 332)
        Me.tlpDisplayEvent.TabIndex = 15
        '
        'lvwEvents
        '
        Me.lvwEvents.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chAttrLog, Me.chTotalEvents})
        Me.lvwEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwEvents.FullRowSelect = True
        Me.lvwEvents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwEvents.HideSelection = False
        Me.lvwEvents.Location = New System.Drawing.Point(3, 20)
        Me.lvwEvents.Margin = New System.Windows.Forms.Padding(3, 20, 3, 3)
        Me.lvwEvents.MultiSelect = False
        Me.lvwEvents.Name = "lvwEvents"
        Me.lvwEvents.Size = New System.Drawing.Size(229, 35)
        Me.lvwEvents.TabIndex = 27
        Me.lvwEvents.UseCompatibleStateImageBehavior = False
        Me.lvwEvents.View = System.Windows.Forms.View.Details
        '
        'chAttrLog
        '
        Me.chAttrLog.Text = "chAttrLog"
        '
        'chTotalEvents
        '
        Me.chTotalEvents.Text = "chTotalEvents"
        Me.chTotalEvents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'mcLog
        '
        Me.mcLog.BackColor = System.Drawing.Color.White
        Me.mcLog.Location = New System.Drawing.Point(3, 133)
        Me.mcLog.Margin = New System.Windows.Forms.Padding(3)
        Me.mcLog.MaxSelectionCount = 31
        Me.mcLog.Name = "mcLog"
        Me.mcLog.TabIndex = 28
        Me.mcLog.TrailingForeColor = System.Drawing.SystemColors.InactiveCaption
        '
        'lblDisplay
        '
        Me.lblDisplay.AutoSize = True
        Me.lblDisplay.Location = New System.Drawing.Point(3, 68)
        Me.lblDisplay.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDisplay.Name = "lblDisplay"
        Me.lblDisplay.Size = New System.Drawing.Size(51, 13)
        Me.lblDisplay.TabIndex = 29
        Me.lblDisplay.Text = "lblDisplay"
        '
        'tlpLogCmd
        '
        Me.tlpLogCmd.AutoSize = True
        Me.tlpLogCmd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpLogCmd.ColumnCount = 2
        Me.tlpLogCmd.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLogCmd.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLogCmd.Controls.Add(Me.btnExport, 1, 0)
        Me.tlpLogCmd.Controls.Add(Me.btnReload, 0, 0)
        Me.tlpLogCmd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpLogCmd.Location = New System.Drawing.Point(0, 305)
        Me.tlpLogCmd.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpLogCmd.Name = "tlpLogCmd"
        Me.tlpLogCmd.RowCount = 1
        Me.tlpLogCmd.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLogCmd.Size = New System.Drawing.Size(235, 27)
        Me.tlpLogCmd.TabIndex = 28
        '
        'btnExport
        '
        Me.btnExport.AutoSize = True
        Me.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnExport.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExport.Location = New System.Drawing.Point(120, 3)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.btnExport.MinimumSize = New System.Drawing.Size(0, 24)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(112, 24)
        Me.btnExport.TabIndex = 36
        Me.btnExport.Text = "btnExport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnReload
        '
        Me.btnReload.AutoSize = True
        Me.btnReload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnReload.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReload.Location = New System.Drawing.Point(3, 3)
        Me.btnReload.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.btnReload.MinimumSize = New System.Drawing.Size(0, 24)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(111, 24)
        Me.btnReload.TabIndex = 35
        Me.btnReload.Text = "btnReload"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'RibbonHorizontalSeparator4
        '
        Me.RibbonHorizontalSeparator4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonHorizontalSeparator4.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonHorizontalSeparator4.Location = New System.Drawing.Point(3, 61)
        Me.RibbonHorizontalSeparator4.MaximumSize = New System.Drawing.Size(0, 1)
        Me.RibbonHorizontalSeparator4.MinimumSize = New System.Drawing.Size(80, 1)
        Me.RibbonHorizontalSeparator4.Name = "RibbonHorizontalSeparator4"
        Me.RibbonHorizontalSeparator4.Size = New System.Drawing.Size(229, 1)
        Me.RibbonHorizontalSeparator4.TabIndex = 31
        '
        'optEntire
        '
        Me.optEntire.AutoSize = True
        Me.optEntire.Location = New System.Drawing.Point(6, 87)
        Me.optEntire.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.optEntire.Name = "optEntire"
        Me.optEntire.Size = New System.Drawing.Size(69, 17)
        Me.optEntire.TabIndex = 32
        Me.optEntire.TabStop = True
        Me.optEntire.Text = "optEntire"
        Me.optEntire.UseVisualStyleBackColor = True
        '
        'optSelection
        '
        Me.optSelection.AutoSize = True
        Me.optSelection.Location = New System.Drawing.Point(6, 110)
        Me.optSelection.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.optSelection.Name = "optSelection"
        Me.optSelection.Size = New System.Drawing.Size(84, 17)
        Me.optSelection.TabIndex = 33
        Me.optSelection.TabStop = True
        Me.optSelection.Text = "optSelection"
        Me.optSelection.UseVisualStyleBackColor = True
        '
        'RibbonHorizontalSeparator7
        '
        Me.RibbonHorizontalSeparator7.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonHorizontalSeparator7.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonHorizontalSeparator7.Location = New System.Drawing.Point(3, 301)
        Me.RibbonHorizontalSeparator7.MaximumSize = New System.Drawing.Size(0, 1)
        Me.RibbonHorizontalSeparator7.MinimumSize = New System.Drawing.Size(80, 1)
        Me.RibbonHorizontalSeparator7.Name = "RibbonHorizontalSeparator7"
        Me.RibbonHorizontalSeparator7.Size = New System.Drawing.Size(229, 1)
        Me.RibbonHorizontalSeparator7.TabIndex = 34
        '
        'tlpEventChart
        '
        Me.tlpEventChart.ColumnCount = 1
        Me.tlpEventChart.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpEventChart.Controls.Add(Me.tabLog, 0, 1)
        Me.tlpEventChart.Controls.Add(Me.lblNoPeriodEvents, 0, 0)
        Me.tlpEventChart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpEventChart.Location = New System.Drawing.Point(0, 23)
        Me.tlpEventChart.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpEventChart.Name = "tlpEventChart"
        Me.tlpEventChart.RowCount = 2
        Me.tlpEventChart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpEventChart.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpEventChart.Size = New System.Drawing.Size(468, 332)
        Me.tlpEventChart.TabIndex = 28
        '
        'tabLog
        '
        Me.tabLog.Controls.Add(Me.tpLogEvents)
        Me.tabLog.Controls.Add(Me.tpLogChart)
        Me.tabLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabLog.Location = New System.Drawing.Point(0, 23)
        Me.tabLog.Margin = New System.Windows.Forms.Padding(0)
        Me.tabLog.Name = "tabLog"
        Me.tabLog.SelectedIndex = 0
        Me.tabLog.Size = New System.Drawing.Size(468, 309)
        Me.tabLog.TabIndex = 27
        '
        'tpLogEvents
        '
        Me.tpLogEvents.Controls.Add(Me.lvwLog)
        Me.tpLogEvents.Location = New System.Drawing.Point(4, 22)
        Me.tpLogEvents.Name = "tpLogEvents"
        Me.tpLogEvents.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLogEvents.Size = New System.Drawing.Size(460, 283)
        Me.tpLogEvents.TabIndex = 0
        Me.tpLogEvents.Text = "tpLogEvents"
        Me.tpLogEvents.UseVisualStyleBackColor = True
        '
        'lvwLog
        '
        Me.lvwLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDate, Me.chFrom, Me.chTo, Me.chVariation})
        Me.lvwLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwLog.FullRowSelect = True
        Me.lvwLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwLog.HideSelection = False
        Me.lvwLog.Location = New System.Drawing.Point(3, 3)
        Me.lvwLog.Name = "lvwLog"
        Me.lvwLog.Size = New System.Drawing.Size(454, 277)
        Me.lvwLog.TabIndex = 1
        Me.lvwLog.UseCompatibleStateImageBehavior = False
        Me.lvwLog.View = System.Windows.Forms.View.Details
        '
        'chDate
        '
        Me.chDate.Text = "chDate"
        Me.chDate.Width = 120
        '
        'chFrom
        '
        Me.chFrom.Text = "chFrom"
        Me.chFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chFrom.Width = 80
        '
        'chTo
        '
        Me.chTo.Text = "chTo"
        Me.chTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chTo.Width = 80
        '
        'chVariation
        '
        Me.chVariation.Text = "chVariation"
        Me.chVariation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chVariation.Width = 80
        '
        'tpLogChart
        '
        Me.tpLogChart.Controls.Add(Me.chrChart)
        Me.tpLogChart.Controls.Add(Me.tlpChartOptions)
        Me.tpLogChart.Location = New System.Drawing.Point(4, 22)
        Me.tpLogChart.Name = "tpLogChart"
        Me.tpLogChart.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLogChart.Size = New System.Drawing.Size(460, 283)
        Me.tpLogChart.TabIndex = 1
        Me.tpLogChart.Text = "tpLogChart"
        Me.tpLogChart.UseVisualStyleBackColor = True
        '
        'chrChart
        '
        Me.chrChart.BorderlineColor = System.Drawing.Color.Empty
        Me.chrChart.BorderSkin.BorderColor = System.Drawing.Color.LightGray
        ChartArea1.Area3DStyle.Inclination = 0
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.IsMarginVisible = False
        ChartArea1.AxisX.IsStartedFromZero = False
        ChartArea1.AxisX.LabelAutoFitMaxFontSize = 7
        ChartArea1.AxisX.LabelAutoFitMinFontSize = 7
        ChartArea1.AxisX.LabelAutoFitStyle = CType((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) _
            Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea1.AxisX.LabelStyle.Angle = -90
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX.TitleForeColor = System.Drawing.Color.DimGray
        ChartArea1.AxisX2.LineColor = System.Drawing.Color.Empty
        ChartArea1.AxisX2.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX2.TitleForeColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelAutoFitMaxFontSize = 7
        ChartArea1.AxisY.LabelAutoFitMinFontSize = 7
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.TitleForeColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY2.LineColor = System.Drawing.Color.Empty
        ChartArea1.AxisY2.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY2.TitleForeColor = System.Drawing.Color.DimGray
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.BorderColor = System.Drawing.Color.Empty
        ChartArea1.Name = "ChartArea1"
        Me.chrChart.ChartAreas.Add(ChartArea1)
        Me.chrChart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chrChart.Location = New System.Drawing.Point(3, 3)
        Me.chrChart.Margin = New System.Windows.Forms.Padding(0)
        Me.chrChart.Name = "chrChart"
        Me.chrChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Me.chrChart.PaletteCustomColors = New System.Drawing.Color() {System.Drawing.Color.DodgerBlue, System.Drawing.Color.Red}
        Series1.BorderWidth = 2
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.MarkerSize = 8
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series1.Name = "Log"
        Series1.Points.Add(DataPoint1)
        Series1.Points.Add(DataPoint2)
        Series1.Points.Add(DataPoint3)
        Series1.Points.Add(DataPoint4)
        Series1.Points.Add(DataPoint5)
        Series1.Points.Add(DataPoint6)
        Series1.Points.Add(DataPoint7)
        Series1.Points.Add(DataPoint8)
        Series1.Points.Add(DataPoint9)
        Series1.Points.Add(DataPoint10)
        Series1.Points.Add(DataPoint11)
        Series1.Points.Add(DataPoint12)
        Series1.Points.Add(DataPoint13)
        Series1.Points.Add(DataPoint14)
        Series1.Points.Add(DataPoint15)
        Series1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series2.LabelBackColor = System.Drawing.Color.White
        Series2.Name = "TempMax"
        Series2.Points.Add(DataPoint16)
        Series2.Points.Add(DataPoint17)
        Series2.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime
        Me.chrChart.Series.Add(Series1)
        Me.chrChart.Series.Add(Series2)
        Me.chrChart.Size = New System.Drawing.Size(454, 250)
        Me.chrChart.TabIndex = 20
        Me.chrChart.Text = "Chart1"
        '
        'tlpChartOptions
        '
        Me.tlpChartOptions.AutoSize = True
        Me.tlpChartOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpChartOptions.ColumnCount = 4
        Me.tlpChartOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpChartOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpChartOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpChartOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChartOptions.Controls.Add(Me.chkChartValues, 0, 0)
        Me.tlpChartOptions.Controls.Add(Me.lblPointSize, 2, 0)
        Me.tlpChartOptions.Controls.Add(Me.numPointSize, 3, 0)
        Me.tlpChartOptions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlpChartOptions.Location = New System.Drawing.Point(3, 253)
        Me.tlpChartOptions.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpChartOptions.Name = "tlpChartOptions"
        Me.tlpChartOptions.RowCount = 1
        Me.tlpChartOptions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChartOptions.Size = New System.Drawing.Size(454, 27)
        Me.tlpChartOptions.TabIndex = 21
        '
        'chkChartValues
        '
        Me.chkChartValues.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkChartValues.AutoSize = True
        Me.chkChartValues.Location = New System.Drawing.Point(3, 5)
        Me.chkChartValues.Name = "chkChartValues"
        Me.chkChartValues.Size = New System.Drawing.Size(100, 17)
        Me.chkChartValues.TabIndex = 0
        Me.chkChartValues.Text = "chkChartValues"
        Me.chkChartValues.UseVisualStyleBackColor = True
        '
        'lblPointSize
        '
        Me.lblPointSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPointSize.AutoSize = True
        Me.lblPointSize.Location = New System.Drawing.Point(129, 7)
        Me.lblPointSize.Name = "lblPointSize"
        Me.lblPointSize.Size = New System.Drawing.Size(60, 13)
        Me.lblPointSize.TabIndex = 1
        Me.lblPointSize.Text = "lblPointSize"
        '
        'numPointSize
        '
        Me.numPointSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.numPointSize.Location = New System.Drawing.Point(195, 3)
        Me.numPointSize.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numPointSize.Name = "numPointSize"
        Me.numPointSize.Size = New System.Drawing.Size(50, 21)
        Me.numPointSize.TabIndex = 2
        Me.numPointSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNoPeriodEvents
        '
        Me.lblNoPeriodEvents.AutoSize = True
        Me.lblNoPeriodEvents.Location = New System.Drawing.Point(3, 0)
        Me.lblNoPeriodEvents.MinimumSize = New System.Drawing.Size(0, 23)
        Me.lblNoPeriodEvents.Name = "lblNoPeriodEvents"
        Me.lblNoPeriodEvents.Size = New System.Drawing.Size(93, 23)
        Me.lblNoPeriodEvents.TabIndex = 28
        Me.lblNoPeriodEvents.Text = "lblNoPeriodEvents"
        Me.lblNoPeriodEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpTemperatures
        '
        Me.tpTemperatures.AutoScroll = True
        Me.tpTemperatures.Controls.Add(Me.tlpTemperatures)
        Me.tpTemperatures.Location = New System.Drawing.Point(4, 22)
        Me.tpTemperatures.Name = "tpTemperatures"
        Me.tpTemperatures.Size = New System.Drawing.Size(703, 355)
        Me.tpTemperatures.TabIndex = 7
        Me.tpTemperatures.Text = "tpTemperatures"
        Me.tpTemperatures.UseVisualStyleBackColor = True
        '
        'tlpTemperatures
        '
        Me.tlpTemperatures.AutoSize = True
        Me.tlpTemperatures.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTemperatures.ColumnCount = 1
        Me.tlpTemperatures.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTemperatures.Controls.Add(Me.tlpTempGraphs, 0, 0)
        Me.tlpTemperatures.Controls.Add(Me.lblTempMeans, 0, 2)
        Me.tlpTemperatures.Controls.Add(Me.tlpTempMeans, 0, 3)
        Me.tlpTemperatures.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpTemperatures.Location = New System.Drawing.Point(0, 0)
        Me.tlpTemperatures.Name = "tlpTemperatures"
        Me.tlpTemperatures.RowCount = 4
        Me.tlpTemperatures.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTemperatures.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpTemperatures.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTemperatures.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTemperatures.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpTemperatures.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpTemperatures.Size = New System.Drawing.Size(703, 256)
        Me.tlpTemperatures.TabIndex = 25
        '
        'tlpTempGraphs
        '
        Me.tlpTempGraphs.AutoSize = True
        Me.tlpTempGraphs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTempGraphs.ColumnCount = 4
        Me.tlpTempGraphs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTempGraphs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTempGraphs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTempGraphs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTempGraphs.Controls.Add(Me.lblLifeTimeMax, 3, 4)
        Me.tlpTempGraphs.Controls.Add(Me.lblCurrentTemp, 0, 0)
        Me.tlpTempGraphs.Controls.Add(Me.lblCycleMin, 1, 3)
        Me.tlpTempGraphs.Controls.Add(Me.lblMin, 1, 2)
        Me.tlpTempGraphs.Controls.Add(Me.lblMax, 3, 2)
        Me.tlpTempGraphs.Controls.Add(Me.lblCycleMax, 3, 3)
        Me.tlpTempGraphs.Controls.Add(Me.lblRecommendedMax, 3, 5)
        Me.tlpTempGraphs.Controls.Add(Me.lblLimitMax, 3, 6)
        Me.tlpTempGraphs.Controls.Add(Me.lblCycle, 0, 3)
        Me.tlpTempGraphs.Controls.Add(Me.lblLifeTime, 0, 4)
        Me.tlpTempGraphs.Controls.Add(Me.lblLifeTimeMin, 1, 4)
        Me.tlpTempGraphs.Controls.Add(Me.lblRecommendedMin, 1, 5)
        Me.tlpTempGraphs.Controls.Add(Me.lblLimitMin, 1, 6)
        Me.tlpTempGraphs.Controls.Add(Me.lblRecommended, 0, 5)
        Me.tlpTempGraphs.Controls.Add(Me.lblLimit, 0, 6)
        Me.tlpTempGraphs.Controls.Add(Me.lblCurrentTempValue, 1, 0)
        Me.tlpTempGraphs.Controls.Add(Me.tbCycle, 2, 3)
        Me.tlpTempGraphs.Controls.Add(Me.tbLifeTime, 2, 4)
        Me.tlpTempGraphs.Controls.Add(Me.tbRecommended, 2, 5)
        Me.tlpTempGraphs.Controls.Add(Me.tbLimit, 2, 6)
        Me.tlpTempGraphs.Controls.Add(Me.lblZero, 2, 2)
        Me.tlpTempGraphs.Location = New System.Drawing.Point(3, 3)
        Me.tlpTempGraphs.Name = "tlpTempGraphs"
        Me.tlpTempGraphs.RowCount = 7
        Me.tlpTempGraphs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTempGraphs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpTempGraphs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTempGraphs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTempGraphs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTempGraphs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTempGraphs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTempGraphs.Size = New System.Drawing.Size(697, 138)
        Me.tlpTempGraphs.TabIndex = 3
        '
        'lblLifeTimeMax
        '
        Me.lblLifeTimeMax.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLifeTimeMax.AutoSize = True
        Me.lblLifeTimeMax.ForeColor = System.Drawing.Color.Black
        Me.lblLifeTimeMax.Location = New System.Drawing.Point(607, 82)
        Me.lblLifeTimeMax.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLifeTimeMax.Name = "lblLifeTimeMax"
        Me.lblLifeTimeMax.Size = New System.Drawing.Size(76, 13)
        Me.lblLifeTimeMax.TabIndex = 5
        Me.lblLifeTimeMax.Text = "lblLifeTimeMax"
        '
        'lblCurrentTemp
        '
        Me.lblCurrentTemp.AutoSize = True
        Me.lblCurrentTemp.ForeColor = System.Drawing.Color.DimGray
        Me.lblCurrentTemp.Location = New System.Drawing.Point(0, 0)
        Me.lblCurrentTemp.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblCurrentTemp.MinimumSize = New System.Drawing.Size(0, 23)
        Me.lblCurrentTemp.Name = "lblCurrentTemp"
        Me.lblCurrentTemp.Size = New System.Drawing.Size(80, 23)
        Me.lblCurrentTemp.TabIndex = 50
        Me.lblCurrentTemp.Tag = "Grayed"
        Me.lblCurrentTemp.Text = "lblCurrentTemp"
        Me.lblCurrentTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCycleMin
        '
        Me.lblCycleMin.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCycleMin.AutoSize = True
        Me.lblCycleMin.ForeColor = System.Drawing.Color.Black
        Me.lblCycleMin.Location = New System.Drawing.Point(137, 63)
        Me.lblCycleMin.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblCycleMin.Name = "lblCycleMin"
        Me.lblCycleMin.Size = New System.Drawing.Size(59, 13)
        Me.lblCycleMin.TabIndex = 9
        Me.lblCycleMin.Text = "lblCycleMin"
        '
        'lblMin
        '
        Me.lblMin.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblMin.AutoSize = True
        Me.lblMin.ForeColor = System.Drawing.Color.Black
        Me.lblMin.Location = New System.Drawing.Point(139, 46)
        Me.lblMin.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(57, 13)
        Me.lblMin.TabIndex = 6
        Me.lblMin.Text = "lblMinimum"
        '
        'lblMax
        '
        Me.lblMax.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMax.AutoSize = True
        Me.lblMax.ForeColor = System.Drawing.Color.Black
        Me.lblMax.Location = New System.Drawing.Point(607, 46)
        Me.lblMax.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblMax.Name = "lblMax"
        Me.lblMax.Size = New System.Drawing.Size(61, 13)
        Me.lblMax.TabIndex = 8
        Me.lblMax.Text = "lblMaximum"
        '
        'lblCycleMax
        '
        Me.lblCycleMax.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCycleMax.AutoSize = True
        Me.lblCycleMax.ForeColor = System.Drawing.Color.Black
        Me.lblCycleMax.Location = New System.Drawing.Point(607, 63)
        Me.lblCycleMax.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblCycleMax.Name = "lblCycleMax"
        Me.lblCycleMax.Size = New System.Drawing.Size(63, 13)
        Me.lblCycleMax.TabIndex = 11
        Me.lblCycleMax.Text = "lblCycleMax"
        '
        'lblRecommendedMax
        '
        Me.lblRecommendedMax.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRecommendedMax.AutoSize = True
        Me.lblRecommendedMax.ForeColor = System.Drawing.Color.Black
        Me.lblRecommendedMax.Location = New System.Drawing.Point(607, 101)
        Me.lblRecommendedMax.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblRecommendedMax.Name = "lblRecommendedMax"
        Me.lblRecommendedMax.Size = New System.Drawing.Size(107, 13)
        Me.lblRecommendedMax.TabIndex = 12
        Me.lblRecommendedMax.Text = "lblRecommendedMax"
        '
        'lblLimitMax
        '
        Me.lblLimitMax.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLimitMax.AutoSize = True
        Me.lblLimitMax.ForeColor = System.Drawing.Color.Black
        Me.lblLimitMax.Location = New System.Drawing.Point(607, 120)
        Me.lblLimitMax.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLimitMax.Name = "lblLimitMax"
        Me.lblLimitMax.Size = New System.Drawing.Size(58, 13)
        Me.lblLimitMax.TabIndex = 59
        Me.lblLimitMax.Text = "lblLimitMax"
        '
        'lblCycle
        '
        Me.lblCycle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCycle.AutoSize = True
        Me.lblCycle.ForeColor = System.Drawing.Color.DimGray
        Me.lblCycle.Location = New System.Drawing.Point(0, 63)
        Me.lblCycle.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblCycle.Name = "lblCycle"
        Me.lblCycle.Size = New System.Drawing.Size(43, 13)
        Me.lblCycle.TabIndex = 37
        Me.lblCycle.Tag = "Grayed"
        Me.lblCycle.Text = "lblCycle"
        '
        'lblLifeTime
        '
        Me.lblLifeTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLifeTime.AutoSize = True
        Me.lblLifeTime.ForeColor = System.Drawing.Color.DimGray
        Me.lblLifeTime.Location = New System.Drawing.Point(0, 82)
        Me.lblLifeTime.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLifeTime.Name = "lblLifeTime"
        Me.lblLifeTime.Size = New System.Drawing.Size(56, 13)
        Me.lblLifeTime.TabIndex = 38
        Me.lblLifeTime.Tag = "Grayed"
        Me.lblLifeTime.Text = "lblLifeTime"
        '
        'lblLifeTimeMin
        '
        Me.lblLifeTimeMin.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblLifeTimeMin.AutoSize = True
        Me.lblLifeTimeMin.ForeColor = System.Drawing.Color.Black
        Me.lblLifeTimeMin.Location = New System.Drawing.Point(124, 82)
        Me.lblLifeTimeMin.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLifeTimeMin.Name = "lblLifeTimeMin"
        Me.lblLifeTimeMin.Size = New System.Drawing.Size(72, 13)
        Me.lblLifeTimeMin.TabIndex = 0
        Me.lblLifeTimeMin.Text = "lblLifeTimeMin"
        '
        'lblRecommendedMin
        '
        Me.lblRecommendedMin.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblRecommendedMin.AutoSize = True
        Me.lblRecommendedMin.ForeColor = System.Drawing.Color.Black
        Me.lblRecommendedMin.Location = New System.Drawing.Point(93, 101)
        Me.lblRecommendedMin.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblRecommendedMin.Name = "lblRecommendedMin"
        Me.lblRecommendedMin.Size = New System.Drawing.Size(103, 13)
        Me.lblRecommendedMin.TabIndex = 58
        Me.lblRecommendedMin.Text = "lblRecommendedMin"
        '
        'lblLimitMin
        '
        Me.lblLimitMin.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblLimitMin.AutoSize = True
        Me.lblLimitMin.ForeColor = System.Drawing.Color.Black
        Me.lblLimitMin.Location = New System.Drawing.Point(142, 120)
        Me.lblLimitMin.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLimitMin.Name = "lblLimitMin"
        Me.lblLimitMin.Size = New System.Drawing.Size(54, 13)
        Me.lblLimitMin.TabIndex = 56
        Me.lblLimitMin.Text = "lblLimitMin"
        '
        'lblRecommended
        '
        Me.lblRecommended.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRecommended.AutoSize = True
        Me.lblRecommended.ForeColor = System.Drawing.Color.DimGray
        Me.lblRecommended.Location = New System.Drawing.Point(0, 101)
        Me.lblRecommended.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblRecommended.Name = "lblRecommended"
        Me.lblRecommended.Size = New System.Drawing.Size(87, 13)
        Me.lblRecommended.TabIndex = 51
        Me.lblRecommended.Tag = "Grayed"
        Me.lblRecommended.Text = "lblRecommended"
        '
        'lblLimit
        '
        Me.lblLimit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLimit.AutoEllipsis = True
        Me.lblLimit.AutoSize = True
        Me.lblLimit.ForeColor = System.Drawing.Color.DimGray
        Me.lblLimit.Location = New System.Drawing.Point(0, 120)
        Me.lblLimit.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLimit.Name = "lblLimit"
        Me.lblLimit.Size = New System.Drawing.Size(38, 13)
        Me.lblLimit.TabIndex = 1
        Me.lblLimit.Tag = "Grayed"
        Me.lblLimit.Text = "lblLimit"
        '
        'lblCurrentTempValue
        '
        Me.lblCurrentTempValue.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCurrentTempValue.AutoSize = True
        Me.lblCurrentTempValue.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentTempValue.Location = New System.Drawing.Point(90, 5)
        Me.lblCurrentTempValue.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblCurrentTempValue.Name = "lblCurrentTempValue"
        Me.lblCurrentTempValue.Size = New System.Drawing.Size(106, 13)
        Me.lblCurrentTempValue.TabIndex = 1
        Me.lblCurrentTempValue.Text = "lblCurrentTempValue"
        '
        'tbCycle
        '
        Me.tbCycle.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.tbCycle.Barcolor = System.Drawing.Color.MediumAquamarine
        Me.tbCycle.Location = New System.Drawing.Point(202, 65)
        Me.tbCycle.Name = "tbCycle"
        Me.tbCycle.Padding = New System.Windows.Forms.Padding(1)
        Me.tbCycle.Size = New System.Drawing.Size(402, 13)
        Me.tbCycle.TabIndex = 60
        '
        'tbLifeTime
        '
        Me.tbLifeTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.tbLifeTime.Barcolor = System.Drawing.Color.MediumSeaGreen
        Me.tbLifeTime.Location = New System.Drawing.Point(202, 84)
        Me.tbLifeTime.Name = "tbLifeTime"
        Me.tbLifeTime.Padding = New System.Windows.Forms.Padding(1)
        Me.tbLifeTime.Size = New System.Drawing.Size(402, 13)
        Me.tbLifeTime.TabIndex = 61
        '
        'tbRecommended
        '
        Me.tbRecommended.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.tbRecommended.Barcolor = System.Drawing.Color.DodgerBlue
        Me.tbRecommended.Location = New System.Drawing.Point(202, 103)
        Me.tbRecommended.Name = "tbRecommended"
        Me.tbRecommended.Padding = New System.Windows.Forms.Padding(1)
        Me.tbRecommended.Size = New System.Drawing.Size(402, 13)
        Me.tbRecommended.TabIndex = 62
        '
        'tbLimit
        '
        Me.tbLimit.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.tbLimit.Barcolor = System.Drawing.Color.Red
        Me.tbLimit.Location = New System.Drawing.Point(202, 122)
        Me.tbLimit.Name = "tbLimit"
        Me.tbLimit.Padding = New System.Windows.Forms.Padding(1)
        Me.tbLimit.Size = New System.Drawing.Size(402, 13)
        Me.tbLimit.TabIndex = 63
        '
        'lblZero
        '
        Me.lblZero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblZero.ForeColor = System.Drawing.Color.Black
        Me.lblZero.Location = New System.Drawing.Point(199, 46)
        Me.lblZero.Margin = New System.Windows.Forms.Padding(0)
        Me.lblZero.Name = "lblZero"
        Me.lblZero.Size = New System.Drawing.Size(408, 16)
        Me.lblZero.TabIndex = 64
        Me.lblZero.Text = "lblZero"
        Me.lblZero.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTempMeans
        '
        Me.lblTempMeans.AutoSize = True
        Me.lblTempMeans.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTempMeans.Location = New System.Drawing.Point(3, 167)
        Me.lblTempMeans.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTempMeans.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblTempMeans.Name = "lblTempMeans"
        Me.lblTempMeans.Size = New System.Drawing.Size(74, 16)
        Me.lblTempMeans.TabIndex = 7
        Me.lblTempMeans.Tag = "Group"
        Me.lblTempMeans.Text = "lblTempMeans"
        Me.lblTempMeans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpTempMeans
        '
        Me.tlpTempMeans.AutoSize = True
        Me.tlpTempMeans.ColumnCount = 2
        Me.tlpTempMeans.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTempMeans.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTempMeans.Controls.Add(Me.lblLimitValue, 1, 3)
        Me.tlpTempMeans.Controls.Add(Me.lblLimitMean, 0, 3)
        Me.tlpTempMeans.Controls.Add(Me.lblCycleMeans, 0, 0)
        Me.tlpTempMeans.Controls.Add(Me.lblLifeTimeMean, 0, 1)
        Me.tlpTempMeans.Controls.Add(Me.lblRecommendedMean, 0, 2)
        Me.tlpTempMeans.Controls.Add(Me.lblCycleValue, 1, 0)
        Me.tlpTempMeans.Controls.Add(Me.lblLifeTimeValue, 1, 1)
        Me.tlpTempMeans.Controls.Add(Me.lblRecommendedValue, 1, 2)
        Me.tlpTempMeans.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpTempMeans.Location = New System.Drawing.Point(3, 189)
        Me.tlpTempMeans.Name = "tlpTempMeans"
        Me.tlpTempMeans.RowCount = 4
        Me.tlpTempMeans.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTempMeans.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTempMeans.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTempMeans.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTempMeans.Size = New System.Drawing.Size(697, 64)
        Me.tlpTempMeans.TabIndex = 8
        '
        'lblLimitValue
        '
        Me.lblLimitValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLimitValue.AutoSize = True
        Me.lblLimitValue.ForeColor = System.Drawing.Color.Black
        Me.lblLimitValue.Location = New System.Drawing.Point(116, 48)
        Me.lblLimitValue.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLimitValue.Name = "lblLimitValue"
        Me.lblLimitValue.Size = New System.Drawing.Size(64, 13)
        Me.lblLimitValue.TabIndex = 45
        Me.lblLimitValue.Text = "lblLimitValue"
        '
        'lblLimitMean
        '
        Me.lblLimitMean.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLimitMean.AutoSize = True
        Me.lblLimitMean.ForeColor = System.Drawing.Color.DimGray
        Me.lblLimitMean.Location = New System.Drawing.Point(0, 48)
        Me.lblLimitMean.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLimitMean.Name = "lblLimitMean"
        Me.lblLimitMean.Size = New System.Drawing.Size(64, 13)
        Me.lblLimitMean.TabIndex = 41
        Me.lblLimitMean.Tag = "Grayed"
        Me.lblLimitMean.Text = "lblLimitMean"
        '
        'lblCycleMeans
        '
        Me.lblCycleMeans.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCycleMeans.AutoSize = True
        Me.lblCycleMeans.ForeColor = System.Drawing.Color.DimGray
        Me.lblCycleMeans.Location = New System.Drawing.Point(0, 0)
        Me.lblCycleMeans.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblCycleMeans.Name = "lblCycleMeans"
        Me.lblCycleMeans.Size = New System.Drawing.Size(69, 13)
        Me.lblCycleMeans.TabIndex = 38
        Me.lblCycleMeans.Tag = "Grayed"
        Me.lblCycleMeans.Text = "lblCycleMean"
        '
        'lblLifeTimeMean
        '
        Me.lblLifeTimeMean.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLifeTimeMean.AutoSize = True
        Me.lblLifeTimeMean.ForeColor = System.Drawing.Color.DimGray
        Me.lblLifeTimeMean.Location = New System.Drawing.Point(0, 16)
        Me.lblLifeTimeMean.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLifeTimeMean.Name = "lblLifeTimeMean"
        Me.lblLifeTimeMean.Size = New System.Drawing.Size(82, 13)
        Me.lblLifeTimeMean.TabIndex = 39
        Me.lblLifeTimeMean.Tag = "Grayed"
        Me.lblLifeTimeMean.Text = "lblLifeTimeMean"
        '
        'lblRecommendedMean
        '
        Me.lblRecommendedMean.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRecommendedMean.AutoSize = True
        Me.lblRecommendedMean.ForeColor = System.Drawing.Color.DimGray
        Me.lblRecommendedMean.Location = New System.Drawing.Point(0, 32)
        Me.lblRecommendedMean.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblRecommendedMean.Name = "lblRecommendedMean"
        Me.lblRecommendedMean.Size = New System.Drawing.Size(113, 13)
        Me.lblRecommendedMean.TabIndex = 40
        Me.lblRecommendedMean.Tag = "Grayed"
        Me.lblRecommendedMean.Text = "lblRecommendedMean"
        '
        'lblCycleValue
        '
        Me.lblCycleValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCycleValue.AutoSize = True
        Me.lblCycleValue.ForeColor = System.Drawing.Color.Black
        Me.lblCycleValue.Location = New System.Drawing.Point(116, 0)
        Me.lblCycleValue.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblCycleValue.Name = "lblCycleValue"
        Me.lblCycleValue.Size = New System.Drawing.Size(69, 13)
        Me.lblCycleValue.TabIndex = 42
        Me.lblCycleValue.Text = "lblCycleValue"
        '
        'lblLifeTimeValue
        '
        Me.lblLifeTimeValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLifeTimeValue.AutoSize = True
        Me.lblLifeTimeValue.ForeColor = System.Drawing.Color.Black
        Me.lblLifeTimeValue.Location = New System.Drawing.Point(116, 16)
        Me.lblLifeTimeValue.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblLifeTimeValue.Name = "lblLifeTimeValue"
        Me.lblLifeTimeValue.Size = New System.Drawing.Size(82, 13)
        Me.lblLifeTimeValue.TabIndex = 43
        Me.lblLifeTimeValue.Text = "lblLifeTimeValue"
        '
        'lblRecommendedValue
        '
        Me.lblRecommendedValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRecommendedValue.AutoSize = True
        Me.lblRecommendedValue.ForeColor = System.Drawing.Color.Black
        Me.lblRecommendedValue.Location = New System.Drawing.Point(116, 32)
        Me.lblRecommendedValue.Margin = New System.Windows.Forms.Padding(0, 0, 3, 3)
        Me.lblRecommendedValue.Name = "lblRecommendedValue"
        Me.lblRecommendedValue.Size = New System.Drawing.Size(113, 13)
        Me.lblRecommendedValue.TabIndex = 44
        Me.lblRecommendedValue.Text = "lblRecommendedValue"
        '
        'tpSetup
        '
        Me.tpSetup.BackColor = System.Drawing.Color.White
        Me.tpSetup.Controls.Add(Me.htcSetup)
        Me.tpSetup.Location = New System.Drawing.Point(4, 22)
        Me.tpSetup.Name = "tpSetup"
        Me.tpSetup.Size = New System.Drawing.Size(711, 381)
        Me.tpSetup.TabIndex = 1
        Me.tpSetup.Text = "tpSetup"
        '
        'htcSetup
        '
        Me.htcSetup.Controls.Add(Me.tpAtaSmartSetup)
        Me.htcSetup.Controls.Add(Me.tpScsiSmartSetup)
        Me.htcSetup.Controls.Add(Me.tpAtaAam)
        Me.htcSetup.Controls.Add(Me.tpAtaApm)
        Me.htcSetup.Controls.Add(Me.tpAtaStandby)
        Me.htcSetup.Controls.Add(Me.tpAtaReadWrite)
        Me.htcSetup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htcSetup.Location = New System.Drawing.Point(0, 0)
        Me.htcSetup.Name = "htcSetup"
        Me.htcSetup.SelectedIndex = 0
        Me.htcSetup.Size = New System.Drawing.Size(711, 381)
        Me.htcSetup.TabIndex = 0
        Me.htcSetup.TabStop = False
        '
        'tpAtaSmartSetup
        '
        Me.tpAtaSmartSetup.BackColor = System.Drawing.Color.White
        Me.tpAtaSmartSetup.Controls.Add(Me.tlpAtaSmart)
        Me.tpAtaSmartSetup.Location = New System.Drawing.Point(4, 22)
        Me.tpAtaSmartSetup.Name = "tpAtaSmartSetup"
        Me.tpAtaSmartSetup.Size = New System.Drawing.Size(703, 355)
        Me.tpAtaSmartSetup.TabIndex = 0
        Me.tpAtaSmartSetup.Text = "tpAtaSmartSetup"
        '
        'tlpAtaSmart
        '
        Me.tlpAtaSmart.AutoSize = True
        Me.tlpAtaSmart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpAtaSmart.ColumnCount = 1
        Me.tlpAtaSmart.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAtaSmart.Controls.Add(Me.lblSmart, 0, 3)
        Me.tlpAtaSmart.Controls.Add(Me.lblAdminSmart, 0, 0)
        Me.tlpAtaSmart.Controls.Add(Me.lblOfflineTest, 0, 5)
        Me.tlpAtaSmart.Controls.Add(Me.lblAttrAutosave, 0, 7)
        Me.tlpAtaSmart.Controls.Add(Me.chkEnableSmart, 0, 2)
        Me.tlpAtaSmart.Controls.Add(Me.chkEnableOffline, 0, 4)
        Me.tlpAtaSmart.Controls.Add(Me.chkEnableAutosave, 0, 6)
        Me.tlpAtaSmart.Controls.Add(Me.HorizontalLine2, 0, 1)
        Me.tlpAtaSmart.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpAtaSmart.Location = New System.Drawing.Point(0, 0)
        Me.tlpAtaSmart.Name = "tlpAtaSmart"
        Me.tlpAtaSmart.RowCount = 8
        Me.tlpAtaSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaSmart.Size = New System.Drawing.Size(703, 150)
        Me.tlpAtaSmart.TabIndex = 15
        '
        'lblSmart
        '
        Me.lblSmart.AutoSize = True
        Me.lblSmart.ForeColor = System.Drawing.Color.DimGray
        Me.lblSmart.Location = New System.Drawing.Point(20, 60)
        Me.lblSmart.Margin = New System.Windows.Forms.Padding(20, 1, 3, 5)
        Me.lblSmart.Name = "lblSmart"
        Me.lblSmart.Size = New System.Drawing.Size(45, 13)
        Me.lblSmart.TabIndex = 1
        Me.lblSmart.Tag = "Grayed"
        Me.lblSmart.Text = "lblSmart"
        '
        'lblAdminSmart
        '
        Me.lblAdminSmart.AutoSize = True
        Me.lblAdminSmart.ForeColor = System.Drawing.Color.DimGray
        Me.lblAdminSmart.Location = New System.Drawing.Point(3, 7)
        Me.lblAdminSmart.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblAdminSmart.Name = "lblAdminSmart"
        Me.lblAdminSmart.Size = New System.Drawing.Size(74, 13)
        Me.lblAdminSmart.TabIndex = 18
        Me.lblAdminSmart.Tag = "Grayed"
        Me.lblAdminSmart.Text = "lblAdminSmart"
        '
        'lblOfflineTest
        '
        Me.lblOfflineTest.AutoSize = True
        Me.lblOfflineTest.ForeColor = System.Drawing.Color.DimGray
        Me.lblOfflineTest.Location = New System.Drawing.Point(20, 96)
        Me.lblOfflineTest.Margin = New System.Windows.Forms.Padding(20, 1, 3, 5)
        Me.lblOfflineTest.Name = "lblOfflineTest"
        Me.lblOfflineTest.Size = New System.Drawing.Size(70, 13)
        Me.lblOfflineTest.TabIndex = 3
        Me.lblOfflineTest.Tag = "Grayed"
        Me.lblOfflineTest.Text = "lblOfflineTest"
        '
        'lblAttrAutosave
        '
        Me.lblAttrAutosave.AutoSize = True
        Me.lblAttrAutosave.ForeColor = System.Drawing.Color.DimGray
        Me.lblAttrAutosave.Location = New System.Drawing.Point(20, 132)
        Me.lblAttrAutosave.Margin = New System.Windows.Forms.Padding(20, 1, 3, 5)
        Me.lblAttrAutosave.Name = "lblAttrAutosave"
        Me.lblAttrAutosave.Size = New System.Drawing.Size(82, 13)
        Me.lblAttrAutosave.TabIndex = 5
        Me.lblAttrAutosave.Tag = "Grayed"
        Me.lblAttrAutosave.Text = "lblAttrAutosave"
        '
        'chkEnableSmart
        '
        Me.chkEnableSmart.AutoSize = True
        Me.chkEnableSmart.ForeColor = System.Drawing.Color.Black
        Me.chkEnableSmart.Location = New System.Drawing.Point(3, 42)
        Me.chkEnableSmart.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkEnableSmart.Name = "chkEnableSmart"
        Me.chkEnableSmart.Size = New System.Drawing.Size(102, 17)
        Me.chkEnableSmart.TabIndex = 0
        Me.chkEnableSmart.Text = "chkEnableSmart"
        Me.chkEnableSmart.UseVisualStyleBackColor = True
        '
        'chkEnableOffline
        '
        Me.chkEnableOffline.AutoSize = True
        Me.chkEnableOffline.ForeColor = System.Drawing.Color.Black
        Me.chkEnableOffline.Location = New System.Drawing.Point(3, 78)
        Me.chkEnableOffline.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkEnableOffline.Name = "chkEnableOffline"
        Me.chkEnableOffline.Size = New System.Drawing.Size(106, 17)
        Me.chkEnableOffline.TabIndex = 1
        Me.chkEnableOffline.Text = "chkEnableOffline"
        Me.chkEnableOffline.UseVisualStyleBackColor = True
        '
        'chkEnableAutosave
        '
        Me.chkEnableAutosave.AutoSize = True
        Me.chkEnableAutosave.ForeColor = System.Drawing.Color.Black
        Me.chkEnableAutosave.Location = New System.Drawing.Point(3, 114)
        Me.chkEnableAutosave.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkEnableAutosave.Name = "chkEnableAutosave"
        Me.chkEnableAutosave.Size = New System.Drawing.Size(120, 17)
        Me.chkEnableAutosave.TabIndex = 2
        Me.chkEnableAutosave.Text = "chkEnableAutosave"
        Me.chkEnableAutosave.UseVisualStyleBackColor = True
        '
        'HorizontalLine2
        '
        Me.HorizontalLine2.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine2.Location = New System.Drawing.Point(3, 32)
        Me.HorizontalLine2.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine2.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine2.Name = "HorizontalLine2"
        Me.HorizontalLine2.Size = New System.Drawing.Size(697, 1)
        Me.HorizontalLine2.TabIndex = 24
        Me.HorizontalLine2.TabStop = False
        '
        'tpScsiSmartSetup
        '
        Me.tpScsiSmartSetup.BackColor = System.Drawing.Color.White
        Me.tpScsiSmartSetup.Controls.Add(Me.tlpScsiSmart)
        Me.tpScsiSmartSetup.Location = New System.Drawing.Point(4, 22)
        Me.tpScsiSmartSetup.Margin = New System.Windows.Forms.Padding(0)
        Me.tpScsiSmartSetup.Name = "tpScsiSmartSetup"
        Me.tpScsiSmartSetup.Size = New System.Drawing.Size(703, 355)
        Me.tpScsiSmartSetup.TabIndex = 1
        Me.tpScsiSmartSetup.Text = "tpScsiSmartSetup"
        '
        'tlpScsiSmart
        '
        Me.tlpScsiSmart.AutoSize = True
        Me.tlpScsiSmart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpScsiSmart.ColumnCount = 1
        Me.tlpScsiSmart.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpScsiSmart.Controls.Add(Me.lblAdminScsiSmart, 0, 0)
        Me.tlpScsiSmart.Controls.Add(Me.lblScsiGltsd, 0, 5)
        Me.tlpScsiSmart.Controls.Add(Me.lblScsiRCache, 0, 9)
        Me.tlpScsiSmart.Controls.Add(Me.chkScsiRCache, 0, 8)
        Me.tlpScsiSmart.Controls.Add(Me.chkScsiWCache, 0, 6)
        Me.tlpScsiSmart.Controls.Add(Me.lblScsiWCache, 0, 7)
        Me.tlpScsiSmart.Controls.Add(Me.chkScsiSmart, 0, 2)
        Me.tlpScsiSmart.Controls.Add(Me.chkScsiGltsd, 0, 4)
        Me.tlpScsiSmart.Controls.Add(Me.lblScsiSmart, 0, 3)
        Me.tlpScsiSmart.Controls.Add(Me.HorizontalLine13, 0, 1)
        Me.tlpScsiSmart.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpScsiSmart.Location = New System.Drawing.Point(0, 0)
        Me.tlpScsiSmart.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpScsiSmart.Name = "tlpScsiSmart"
        Me.tlpScsiSmart.RowCount = 10
        Me.tlpScsiSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiSmart.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiSmart.Size = New System.Drawing.Size(703, 186)
        Me.tlpScsiSmart.TabIndex = 16
        '
        'lblAdminScsiSmart
        '
        Me.lblAdminScsiSmart.AutoSize = True
        Me.lblAdminScsiSmart.ForeColor = System.Drawing.Color.DimGray
        Me.lblAdminScsiSmart.Location = New System.Drawing.Point(3, 7)
        Me.lblAdminScsiSmart.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblAdminScsiSmart.Name = "lblAdminScsiSmart"
        Me.lblAdminScsiSmart.Size = New System.Drawing.Size(92, 13)
        Me.lblAdminScsiSmart.TabIndex = 28
        Me.lblAdminScsiSmart.Tag = "Grayed"
        Me.lblAdminScsiSmart.Text = "lblAdminScsiSmart"
        '
        'lblScsiGltsd
        '
        Me.lblScsiGltsd.AutoSize = True
        Me.lblScsiGltsd.ForeColor = System.Drawing.Color.DimGray
        Me.lblScsiGltsd.Location = New System.Drawing.Point(20, 96)
        Me.lblScsiGltsd.Margin = New System.Windows.Forms.Padding(20, 1, 3, 5)
        Me.lblScsiGltsd.Name = "lblScsiGltsd"
        Me.lblScsiGltsd.Size = New System.Drawing.Size(59, 13)
        Me.lblScsiGltsd.TabIndex = 5
        Me.lblScsiGltsd.Tag = "Grayed"
        Me.lblScsiGltsd.Text = "lblScsiGltsd"
        '
        'lblScsiRCache
        '
        Me.lblScsiRCache.AutoSize = True
        Me.lblScsiRCache.ForeColor = System.Drawing.Color.DimGray
        Me.lblScsiRCache.Location = New System.Drawing.Point(20, 168)
        Me.lblScsiRCache.Margin = New System.Windows.Forms.Padding(20, 1, 3, 5)
        Me.lblScsiRCache.Name = "lblScsiRCache"
        Me.lblScsiRCache.Size = New System.Drawing.Size(72, 13)
        Me.lblScsiRCache.TabIndex = 27
        Me.lblScsiRCache.Tag = "Grayed"
        Me.lblScsiRCache.Text = "lblScsiRCache"
        '
        'chkScsiRCache
        '
        Me.chkScsiRCache.AutoSize = True
        Me.chkScsiRCache.ForeColor = System.Drawing.Color.Black
        Me.chkScsiRCache.Location = New System.Drawing.Point(3, 150)
        Me.chkScsiRCache.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkScsiRCache.Name = "chkScsiRCache"
        Me.chkScsiRCache.Size = New System.Drawing.Size(97, 17)
        Me.chkScsiRCache.TabIndex = 3
        Me.chkScsiRCache.Text = "chkScsiRCache"
        Me.chkScsiRCache.UseVisualStyleBackColor = True
        '
        'chkScsiWCache
        '
        Me.chkScsiWCache.AutoSize = True
        Me.chkScsiWCache.ForeColor = System.Drawing.Color.Black
        Me.chkScsiWCache.Location = New System.Drawing.Point(3, 114)
        Me.chkScsiWCache.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkScsiWCache.Name = "chkScsiWCache"
        Me.chkScsiWCache.Size = New System.Drawing.Size(100, 17)
        Me.chkScsiWCache.TabIndex = 2
        Me.chkScsiWCache.Text = "chkScsiWCache"
        Me.chkScsiWCache.UseVisualStyleBackColor = True
        '
        'lblScsiWCache
        '
        Me.lblScsiWCache.AutoSize = True
        Me.lblScsiWCache.ForeColor = System.Drawing.Color.DimGray
        Me.lblScsiWCache.Location = New System.Drawing.Point(20, 132)
        Me.lblScsiWCache.Margin = New System.Windows.Forms.Padding(20, 1, 3, 5)
        Me.lblScsiWCache.Name = "lblScsiWCache"
        Me.lblScsiWCache.Size = New System.Drawing.Size(75, 13)
        Me.lblScsiWCache.TabIndex = 26
        Me.lblScsiWCache.Tag = "Grayed"
        Me.lblScsiWCache.Text = "lblScsiWCache"
        '
        'chkScsiSmart
        '
        Me.chkScsiSmart.AutoSize = True
        Me.chkScsiSmart.ForeColor = System.Drawing.Color.Black
        Me.chkScsiSmart.Location = New System.Drawing.Point(3, 42)
        Me.chkScsiSmart.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkScsiSmart.Name = "chkScsiSmart"
        Me.chkScsiSmart.Size = New System.Drawing.Size(88, 17)
        Me.chkScsiSmart.TabIndex = 0
        Me.chkScsiSmart.Text = "chkScsiSmart"
        Me.chkScsiSmart.UseVisualStyleBackColor = True
        '
        'chkScsiGltsd
        '
        Me.chkScsiGltsd.AutoSize = True
        Me.chkScsiGltsd.ForeColor = System.Drawing.Color.Black
        Me.chkScsiGltsd.Location = New System.Drawing.Point(3, 78)
        Me.chkScsiGltsd.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkScsiGltsd.Name = "chkScsiGltsd"
        Me.chkScsiGltsd.Size = New System.Drawing.Size(84, 17)
        Me.chkScsiGltsd.TabIndex = 1
        Me.chkScsiGltsd.Text = "chkScsiGltsd" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkScsiGltsd.UseVisualStyleBackColor = True
        '
        'lblScsiSmart
        '
        Me.lblScsiSmart.AutoSize = True
        Me.lblScsiSmart.ForeColor = System.Drawing.Color.DimGray
        Me.lblScsiSmart.Location = New System.Drawing.Point(20, 60)
        Me.lblScsiSmart.Margin = New System.Windows.Forms.Padding(20, 1, 3, 5)
        Me.lblScsiSmart.Name = "lblScsiSmart"
        Me.lblScsiSmart.Size = New System.Drawing.Size(63, 13)
        Me.lblScsiSmart.TabIndex = 1
        Me.lblScsiSmart.Tag = "Grayed"
        Me.lblScsiSmart.Text = "lblScsiSmart"
        '
        'HorizontalLine13
        '
        Me.HorizontalLine13.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine13.Location = New System.Drawing.Point(3, 32)
        Me.HorizontalLine13.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine13.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine13.Name = "HorizontalLine13"
        Me.HorizontalLine13.Size = New System.Drawing.Size(697, 1)
        Me.HorizontalLine13.TabIndex = 29
        Me.HorizontalLine13.TabStop = False
        '
        'tpAtaAam
        '
        Me.tpAtaAam.AutoScroll = True
        Me.tpAtaAam.BackColor = System.Drawing.Color.White
        Me.tpAtaAam.Controls.Add(Me.tlpAtaAam)
        Me.tpAtaAam.Location = New System.Drawing.Point(4, 22)
        Me.tpAtaAam.Name = "tpAtaAam"
        Me.tpAtaAam.Size = New System.Drawing.Size(703, 355)
        Me.tpAtaAam.TabIndex = 2
        Me.tpAtaAam.Text = "tpAtaAam"
        '
        'tlpAtaAam
        '
        Me.tlpAtaAam.AutoSize = True
        Me.tlpAtaAam.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpAtaAam.ColumnCount = 1
        Me.tlpAtaAam.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAtaAam.Controls.Add(tlpAam, 0, 4)
        Me.tlpAtaAam.Controls.Add(Me.trkAam, 0, 3)
        Me.tlpAtaAam.Controls.Add(tlpAamLoud, 0, 2)
        Me.tlpAtaAam.Controls.Add(Me.HorizontalLine3, 0, 1)
        Me.tlpAtaAam.Controls.Add(Me.lblInfoAam, 0, 0)
        Me.tlpAtaAam.Controls.Add(Me.tlpAamWaitMessage, 0, 6)
        Me.tlpAtaAam.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpAtaAam.Location = New System.Drawing.Point(0, 0)
        Me.tlpAtaAam.Name = "tlpAtaAam"
        Me.tlpAtaAam.RowCount = 7
        Me.tlpAtaAam.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaAam.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaAam.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaAam.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaAam.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaAam.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpAtaAam.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaAam.Size = New System.Drawing.Size(703, 226)
        Me.tlpAtaAam.TabIndex = 3
        '
        'tlpAam
        '
        tlpAam.AutoSize = True
        tlpAam.ColumnCount = 2
        tlpAam.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        tlpAam.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        tlpAam.Controls.Add(Me.lblAamValue, 0, 0)
        tlpAam.Controls.Add(Me.lblAamRecommended, 0, 1)
        tlpAam.Controls.Add(Me.lnkSetAam, 1, 0)
        tlpAam.Controls.Add(Me.lnkSetRecommended, 1, 1)
        tlpAam.Controls.Add(Me.lnkUndoAam, 1, 2)
        tlpAam.Dock = System.Windows.Forms.DockStyle.Top
        tlpAam.Location = New System.Drawing.Point(0, 118)
        tlpAam.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        tlpAam.Name = "tlpAam"
        tlpAam.RowCount = 3
        tlpAam.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpAam.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpAam.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpAam.Size = New System.Drawing.Size(700, 57)
        tlpAam.TabIndex = 32
        '
        'lblAamValue
        '
        Me.lblAamValue.AutoSize = True
        Me.lblAamValue.ForeColor = System.Drawing.Color.Black
        Me.lblAamValue.Location = New System.Drawing.Point(3, 3)
        Me.lblAamValue.Margin = New System.Windows.Forms.Padding(3)
        Me.lblAamValue.Name = "lblAamValue"
        Me.lblAamValue.Size = New System.Drawing.Size(64, 13)
        Me.lblAamValue.TabIndex = 27
        Me.lblAamValue.Text = "lblAamValue"
        '
        'lblAamRecommended
        '
        Me.lblAamRecommended.AutoSize = True
        Me.lblAamRecommended.ForeColor = System.Drawing.Color.Black
        Me.lblAamRecommended.Location = New System.Drawing.Point(3, 22)
        Me.lblAamRecommended.Margin = New System.Windows.Forms.Padding(3)
        Me.lblAamRecommended.Name = "lblAamRecommended"
        Me.lblAamRecommended.Size = New System.Drawing.Size(108, 13)
        Me.lblAamRecommended.TabIndex = 29
        Me.lblAamRecommended.Text = "lblAamRecommended"
        '
        'lnkSetAam
        '
        Me.lnkSetAam.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSetAam.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lnkSetAam.AutoSize = True
        Me.lnkSetAam.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSetAam.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkSetAam.Location = New System.Drawing.Point(640, 3)
        Me.lnkSetAam.Margin = New System.Windows.Forms.Padding(3)
        Me.lnkSetAam.Name = "lnkSetAam"
        Me.lnkSetAam.Size = New System.Drawing.Size(57, 13)
        Me.lnkSetAam.TabIndex = 1
        Me.lnkSetAam.TabStop = True
        Me.lnkSetAam.Text = "lnkSetAam"
        '
        'lnkSetRecommended
        '
        Me.lnkSetRecommended.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSetRecommended.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lnkSetRecommended.AutoSize = True
        Me.lnkSetRecommended.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSetRecommended.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkSetRecommended.Location = New System.Drawing.Point(591, 22)
        Me.lnkSetRecommended.Margin = New System.Windows.Forms.Padding(3)
        Me.lnkSetRecommended.Name = "lnkSetRecommended"
        Me.lnkSetRecommended.Size = New System.Drawing.Size(106, 13)
        Me.lnkSetRecommended.TabIndex = 2
        Me.lnkSetRecommended.TabStop = True
        Me.lnkSetRecommended.Text = "lnkSetRecommended"
        '
        'lnkUndoAam
        '
        Me.lnkUndoAam.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkUndoAam.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lnkUndoAam.AutoSize = True
        Me.lnkUndoAam.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkUndoAam.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkUndoAam.Location = New System.Drawing.Point(631, 41)
        Me.lnkUndoAam.Margin = New System.Windows.Forms.Padding(3)
        Me.lnkUndoAam.Name = "lnkUndoAam"
        Me.lnkUndoAam.Size = New System.Drawing.Size(66, 13)
        Me.lnkUndoAam.TabIndex = 3
        Me.lnkUndoAam.TabStop = True
        Me.lnkUndoAam.Text = "lnkUndoAam"
        '
        'trkAam
        '
        Me.trkAam.BackColor = System.Drawing.Color.White
        Me.trkAam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trkAam.Location = New System.Drawing.Point(0, 67)
        Me.trkAam.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.trkAam.Maximum = 254
        Me.trkAam.Name = "trkAam"
        Me.trkAam.Size = New System.Drawing.Size(700, 45)
        Me.trkAam.TabIndex = 0
        Me.trkAam.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'tlpAamLoud
        '
        tlpAamLoud.ColumnCount = 2
        tlpAamLoud.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        tlpAamLoud.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        tlpAamLoud.Controls.Add(Me.lblQuiet, 0, 0)
        tlpAamLoud.Controls.Add(Me.lblLoudest, 1, 0)
        tlpAamLoud.Dock = System.Windows.Forms.DockStyle.Fill
        tlpAamLoud.Location = New System.Drawing.Point(0, 45)
        tlpAamLoud.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        tlpAamLoud.Name = "tlpAamLoud"
        tlpAamLoud.RowCount = 1
        tlpAamLoud.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        tlpAamLoud.Size = New System.Drawing.Size(700, 16)
        tlpAamLoud.TabIndex = 29
        '
        'lblQuiet
        '
        Me.lblQuiet.AutoSize = True
        Me.lblQuiet.ForeColor = System.Drawing.Color.DimGray
        Me.lblQuiet.Location = New System.Drawing.Point(3, 0)
        Me.lblQuiet.Name = "lblQuiet"
        Me.lblQuiet.Size = New System.Drawing.Size(43, 13)
        Me.lblQuiet.TabIndex = 0
        Me.lblQuiet.Text = "lblQuiet"
        '
        'lblLoudest
        '
        Me.lblLoudest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLoudest.AutoSize = True
        Me.lblLoudest.ForeColor = System.Drawing.Color.DimGray
        Me.lblLoudest.Location = New System.Drawing.Point(642, 0)
        Me.lblLoudest.Name = "lblLoudest"
        Me.lblLoudest.Size = New System.Drawing.Size(55, 13)
        Me.lblLoudest.TabIndex = 1
        Me.lblLoudest.Text = "lblLoudest"
        Me.lblLoudest.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'HorizontalLine3
        '
        Me.HorizontalLine3.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine3.Location = New System.Drawing.Point(3, 32)
        Me.HorizontalLine3.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine3.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine3.Name = "HorizontalLine3"
        Me.HorizontalLine3.Size = New System.Drawing.Size(697, 1)
        Me.HorizontalLine3.TabIndex = 34
        Me.HorizontalLine3.TabStop = False
        '
        'lblInfoAam
        '
        Me.lblInfoAam.AutoSize = True
        Me.lblInfoAam.ForeColor = System.Drawing.Color.DimGray
        Me.lblInfoAam.Location = New System.Drawing.Point(3, 7)
        Me.lblInfoAam.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblInfoAam.Name = "lblInfoAam"
        Me.lblInfoAam.Size = New System.Drawing.Size(58, 13)
        Me.lblInfoAam.TabIndex = 3
        Me.lblInfoAam.Text = "lblInfoAam"
        '
        'tlpAamWaitMessage
        '
        Me.tlpAamWaitMessage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tlpAamWaitMessage.AutoSize = True
        Me.tlpAamWaitMessage.ColumnCount = 2
        Me.tlpAamWaitMessage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpAamWaitMessage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpAamWaitMessage.Controls.Add(Me.lblAamWaitMessage, 1, 0)
        Me.tlpAamWaitMessage.Controls.Add(Me.picLoaderAam, 0, 0)
        Me.tlpAamWaitMessage.Location = New System.Drawing.Point(286, 201)
        Me.tlpAamWaitMessage.Name = "tlpAamWaitMessage"
        Me.tlpAamWaitMessage.RowCount = 1
        Me.tlpAamWaitMessage.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAamWaitMessage.Size = New System.Drawing.Size(130, 22)
        Me.tlpAamWaitMessage.TabIndex = 4
        '
        'lblAamWaitMessage
        '
        Me.lblAamWaitMessage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAamWaitMessage.AutoSize = True
        Me.lblAamWaitMessage.ForeColor = System.Drawing.Color.Black
        Me.lblAamWaitMessage.Location = New System.Drawing.Point(25, 4)
        Me.lblAamWaitMessage.Name = "lblAamWaitMessage"
        Me.lblAamWaitMessage.Size = New System.Drawing.Size(102, 13)
        Me.lblAamWaitMessage.TabIndex = 0
        Me.lblAamWaitMessage.Text = "lblAamWaitMessage"
        '
        'picLoaderAam
        '
        Me.picLoaderAam.Image = Global.hdd_guardian.My.Resources.Resources.loader
        Me.picLoaderAam.Location = New System.Drawing.Point(3, 3)
        Me.picLoaderAam.MaximumSize = New System.Drawing.Size(16, 16)
        Me.picLoaderAam.Name = "picLoaderAam"
        Me.picLoaderAam.Size = New System.Drawing.Size(16, 16)
        Me.picLoaderAam.TabIndex = 1
        Me.picLoaderAam.TabStop = False
        '
        'tpAtaApm
        '
        Me.tpAtaApm.AutoScroll = True
        Me.tpAtaApm.BackColor = System.Drawing.Color.White
        Me.tpAtaApm.Controls.Add(Me.tlpApmContent)
        Me.tpAtaApm.Location = New System.Drawing.Point(4, 22)
        Me.tpAtaApm.Name = "tpAtaApm"
        Me.tpAtaApm.Size = New System.Drawing.Size(703, 355)
        Me.tpAtaApm.TabIndex = 3
        Me.tpAtaApm.Text = "tpAtaApm"
        '
        'tlpApmContent
        '
        Me.tlpApmContent.AutoSize = True
        Me.tlpApmContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpApmContent.ColumnCount = 1
        Me.tlpApmContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpApmContent.Controls.Add(Me.tlpApmWaitMessage, 0, 5)
        Me.tlpApmContent.Controls.Add(Me.trkApm, 0, 2)
        Me.tlpApmContent.Controls.Add(tlpApm, 0, 3)
        Me.tlpApmContent.Controls.Add(Me.HorizontalLine4, 0, 1)
        Me.tlpApmContent.Controls.Add(Me.lblInfoApm, 0, 0)
        Me.tlpApmContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpApmContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpApmContent.Name = "tlpApmContent"
        Me.tlpApmContent.RowCount = 6
        Me.tlpApmContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpApmContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpApmContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpApmContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpApmContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpApmContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpApmContent.Size = New System.Drawing.Size(703, 185)
        Me.tlpApmContent.TabIndex = 4
        '
        'tlpApmWaitMessage
        '
        Me.tlpApmWaitMessage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tlpApmWaitMessage.AutoSize = True
        Me.tlpApmWaitMessage.ColumnCount = 2
        Me.tlpApmWaitMessage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpApmWaitMessage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpApmWaitMessage.Controls.Add(Me.lblApmWaitMessage, 1, 0)
        Me.tlpApmWaitMessage.Controls.Add(Me.picLoaderApm, 0, 0)
        Me.tlpApmWaitMessage.Location = New System.Drawing.Point(286, 160)
        Me.tlpApmWaitMessage.Name = "tlpApmWaitMessage"
        Me.tlpApmWaitMessage.RowCount = 1
        Me.tlpApmWaitMessage.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpApmWaitMessage.Size = New System.Drawing.Size(130, 22)
        Me.tlpApmWaitMessage.TabIndex = 35
        '
        'lblApmWaitMessage
        '
        Me.lblApmWaitMessage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblApmWaitMessage.AutoSize = True
        Me.lblApmWaitMessage.ForeColor = System.Drawing.Color.Black
        Me.lblApmWaitMessage.Location = New System.Drawing.Point(25, 4)
        Me.lblApmWaitMessage.Name = "lblApmWaitMessage"
        Me.lblApmWaitMessage.Size = New System.Drawing.Size(102, 13)
        Me.lblApmWaitMessage.TabIndex = 0
        Me.lblApmWaitMessage.Text = "lblApmWaitMessage"
        '
        'picLoaderApm
        '
        Me.picLoaderApm.Image = Global.hdd_guardian.My.Resources.Resources.loader
        Me.picLoaderApm.Location = New System.Drawing.Point(3, 3)
        Me.picLoaderApm.MaximumSize = New System.Drawing.Size(16, 16)
        Me.picLoaderApm.Name = "picLoaderApm"
        Me.picLoaderApm.Size = New System.Drawing.Size(16, 16)
        Me.picLoaderApm.TabIndex = 1
        Me.picLoaderApm.TabStop = False
        '
        'trkApm
        '
        Me.trkApm.BackColor = System.Drawing.SystemColors.Window
        Me.trkApm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trkApm.Location = New System.Drawing.Point(0, 45)
        Me.trkApm.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.trkApm.Maximum = 254
        Me.trkApm.Name = "trkApm"
        Me.trkApm.Size = New System.Drawing.Size(700, 45)
        Me.trkApm.TabIndex = 0
        Me.trkApm.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'tlpApm
        '
        tlpApm.AutoSize = True
        tlpApm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpApm.ColumnCount = 2
        tlpApm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        tlpApm.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        tlpApm.Controls.Add(Me.lblApmValue, 0, 0)
        tlpApm.Controls.Add(Me.lnkSetApm, 1, 0)
        tlpApm.Controls.Add(Me.lnkUndoApm, 1, 1)
        tlpApm.Dock = System.Windows.Forms.DockStyle.Top
        tlpApm.Location = New System.Drawing.Point(0, 96)
        tlpApm.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        tlpApm.Name = "tlpApm"
        tlpApm.RowCount = 2
        tlpApm.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpApm.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpApm.Size = New System.Drawing.Size(700, 38)
        tlpApm.TabIndex = 32
        '
        'lblApmValue
        '
        Me.lblApmValue.AutoSize = True
        Me.lblApmValue.ForeColor = System.Drawing.Color.Black
        Me.lblApmValue.Location = New System.Drawing.Point(3, 3)
        Me.lblApmValue.Margin = New System.Windows.Forms.Padding(3)
        Me.lblApmValue.Name = "lblApmValue"
        Me.lblApmValue.Size = New System.Drawing.Size(64, 13)
        Me.lblApmValue.TabIndex = 27
        Me.lblApmValue.Text = "lblApmValue"
        '
        'lnkSetApm
        '
        Me.lnkSetApm.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSetApm.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lnkSetApm.AutoSize = True
        Me.lnkSetApm.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSetApm.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkSetApm.Location = New System.Drawing.Point(640, 3)
        Me.lnkSetApm.Margin = New System.Windows.Forms.Padding(3)
        Me.lnkSetApm.Name = "lnkSetApm"
        Me.lnkSetApm.Size = New System.Drawing.Size(57, 13)
        Me.lnkSetApm.TabIndex = 1
        Me.lnkSetApm.TabStop = True
        Me.lnkSetApm.Text = "lnkSetApm"
        '
        'lnkUndoApm
        '
        Me.lnkUndoApm.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkUndoApm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkUndoApm.AutoSize = True
        Me.lnkUndoApm.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkUndoApm.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkUndoApm.Location = New System.Drawing.Point(631, 22)
        Me.lnkUndoApm.Margin = New System.Windows.Forms.Padding(3)
        Me.lnkUndoApm.Name = "lnkUndoApm"
        Me.lnkUndoApm.Size = New System.Drawing.Size(66, 13)
        Me.lnkUndoApm.TabIndex = 2
        Me.lnkUndoApm.TabStop = True
        Me.lnkUndoApm.Text = "lnkUndoApm"
        '
        'HorizontalLine4
        '
        Me.HorizontalLine4.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine4.Location = New System.Drawing.Point(3, 32)
        Me.HorizontalLine4.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine4.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine4.Name = "HorizontalLine4"
        Me.HorizontalLine4.Size = New System.Drawing.Size(697, 1)
        Me.HorizontalLine4.TabIndex = 34
        Me.HorizontalLine4.TabStop = False
        '
        'lblInfoApm
        '
        Me.lblInfoApm.AutoSize = True
        Me.lblInfoApm.ForeColor = System.Drawing.Color.DimGray
        Me.lblInfoApm.Location = New System.Drawing.Point(3, 7)
        Me.lblInfoApm.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblInfoApm.Name = "lblInfoApm"
        Me.lblInfoApm.Size = New System.Drawing.Size(58, 13)
        Me.lblInfoApm.TabIndex = 3
        Me.lblInfoApm.Text = "lblInfoApm"
        '
        'tpAtaStandby
        '
        Me.tpAtaStandby.AutoScroll = True
        Me.tpAtaStandby.BackColor = System.Drawing.Color.White
        Me.tpAtaStandby.Controls.Add(Me.tlpStandbyContent)
        Me.tpAtaStandby.Location = New System.Drawing.Point(4, 22)
        Me.tpAtaStandby.Name = "tpAtaStandby"
        Me.tpAtaStandby.Size = New System.Drawing.Size(703, 355)
        Me.tpAtaStandby.TabIndex = 4
        Me.tpAtaStandby.Text = "tpAtaStandby"
        '
        'tlpStandbyContent
        '
        Me.tlpStandbyContent.AutoSize = True
        Me.tlpStandbyContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpStandbyContent.ColumnCount = 1
        Me.tlpStandbyContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpStandbyContent.Controls.Add(Me.tlpStandbyWaitMessage, 0, 5)
        Me.tlpStandbyContent.Controls.Add(tlpStandby, 0, 3)
        Me.tlpStandbyContent.Controls.Add(Me.trkStandby, 0, 2)
        Me.tlpStandbyContent.Controls.Add(Me.HorizontalLine5, 0, 1)
        Me.tlpStandbyContent.Controls.Add(Me.lblInfoStandby, 0, 0)
        Me.tlpStandbyContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpStandbyContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpStandbyContent.Name = "tlpStandbyContent"
        Me.tlpStandbyContent.RowCount = 6
        Me.tlpStandbyContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpStandbyContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpStandbyContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpStandbyContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpStandbyContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpStandbyContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpStandbyContent.Size = New System.Drawing.Size(703, 186)
        Me.tlpStandbyContent.TabIndex = 5
        '
        'tlpStandbyWaitMessage
        '
        Me.tlpStandbyWaitMessage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tlpStandbyWaitMessage.AutoSize = True
        Me.tlpStandbyWaitMessage.ColumnCount = 2
        Me.tlpStandbyWaitMessage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpStandbyWaitMessage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpStandbyWaitMessage.Controls.Add(Me.lblStandbyWaitMessage, 1, 0)
        Me.tlpStandbyWaitMessage.Controls.Add(Me.picLoaderStandby, 0, 0)
        Me.tlpStandbyWaitMessage.Location = New System.Drawing.Point(277, 161)
        Me.tlpStandbyWaitMessage.Name = "tlpStandbyWaitMessage"
        Me.tlpStandbyWaitMessage.RowCount = 1
        Me.tlpStandbyWaitMessage.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpStandbyWaitMessage.Size = New System.Drawing.Size(149, 22)
        Me.tlpStandbyWaitMessage.TabIndex = 36
        '
        'lblStandbyWaitMessage
        '
        Me.lblStandbyWaitMessage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblStandbyWaitMessage.AutoSize = True
        Me.lblStandbyWaitMessage.ForeColor = System.Drawing.Color.Black
        Me.lblStandbyWaitMessage.Location = New System.Drawing.Point(25, 4)
        Me.lblStandbyWaitMessage.Name = "lblStandbyWaitMessage"
        Me.lblStandbyWaitMessage.Size = New System.Drawing.Size(121, 13)
        Me.lblStandbyWaitMessage.TabIndex = 0
        Me.lblStandbyWaitMessage.Text = "lblStandbyWaitMessage"
        '
        'picLoaderStandby
        '
        Me.picLoaderStandby.Image = Global.hdd_guardian.My.Resources.Resources.loader
        Me.picLoaderStandby.Location = New System.Drawing.Point(3, 3)
        Me.picLoaderStandby.MaximumSize = New System.Drawing.Size(16, 16)
        Me.picLoaderStandby.Name = "picLoaderStandby"
        Me.picLoaderStandby.Size = New System.Drawing.Size(16, 16)
        Me.picLoaderStandby.TabIndex = 1
        Me.picLoaderStandby.TabStop = False
        '
        'tlpStandby
        '
        tlpStandby.AutoSize = True
        tlpStandby.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        tlpStandby.ColumnCount = 2
        tlpStandby.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpStandby.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        tlpStandby.Controls.Add(Me.lnkSetStandby, 1, 0)
        tlpStandby.Controls.Add(Me.lblStandbyValue, 0, 0)
        tlpStandby.Controls.Add(Me.lnkUndoStandby, 1, 1)
        tlpStandby.Dock = System.Windows.Forms.DockStyle.Top
        tlpStandby.Location = New System.Drawing.Point(0, 96)
        tlpStandby.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        tlpStandby.Name = "tlpStandby"
        tlpStandby.RowCount = 2
        tlpStandby.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        tlpStandby.RowStyles.Add(New System.Windows.Forms.RowStyle())
        tlpStandby.Size = New System.Drawing.Size(700, 39)
        tlpStandby.TabIndex = 32
        '
        'lnkSetStandby
        '
        Me.lnkSetStandby.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSetStandby.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkSetStandby.AutoSize = True
        Me.lnkSetStandby.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSetStandby.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkSetStandby.Location = New System.Drawing.Point(621, 3)
        Me.lnkSetStandby.Margin = New System.Windows.Forms.Padding(3)
        Me.lnkSetStandby.Name = "lnkSetStandby"
        Me.lnkSetStandby.Size = New System.Drawing.Size(76, 13)
        Me.lnkSetStandby.TabIndex = 1
        Me.lnkSetStandby.TabStop = True
        Me.lnkSetStandby.Text = "lnkSetStandby"
        '
        'lblStandbyValue
        '
        Me.lblStandbyValue.AutoSize = True
        Me.lblStandbyValue.ForeColor = System.Drawing.Color.Black
        Me.lblStandbyValue.Location = New System.Drawing.Point(3, 3)
        Me.lblStandbyValue.Margin = New System.Windows.Forms.Padding(3)
        Me.lblStandbyValue.Name = "lblStandbyValue"
        Me.lblStandbyValue.Size = New System.Drawing.Size(83, 13)
        Me.lblStandbyValue.TabIndex = 27
        Me.lblStandbyValue.Text = "lblStandbyValue"
        '
        'lnkUndoStandby
        '
        Me.lnkUndoStandby.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkUndoStandby.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkUndoStandby.AutoSize = True
        Me.lnkUndoStandby.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkUndoStandby.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkUndoStandby.Location = New System.Drawing.Point(612, 23)
        Me.lnkUndoStandby.Margin = New System.Windows.Forms.Padding(3)
        Me.lnkUndoStandby.Name = "lnkUndoStandby"
        Me.lnkUndoStandby.Size = New System.Drawing.Size(85, 13)
        Me.lnkUndoStandby.TabIndex = 2
        Me.lnkUndoStandby.TabStop = True
        Me.lnkUndoStandby.Text = "lnkUndoStandby"
        '
        'trkStandby
        '
        Me.trkStandby.BackColor = System.Drawing.SystemColors.Window
        Me.trkStandby.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trkStandby.Location = New System.Drawing.Point(0, 45)
        Me.trkStandby.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.trkStandby.Maximum = 255
        Me.trkStandby.Name = "trkStandby"
        Me.trkStandby.Size = New System.Drawing.Size(700, 45)
        Me.trkStandby.TabIndex = 0
        Me.trkStandby.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'HorizontalLine5
        '
        Me.HorizontalLine5.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine5.Location = New System.Drawing.Point(3, 32)
        Me.HorizontalLine5.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine5.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine5.Name = "HorizontalLine5"
        Me.HorizontalLine5.Size = New System.Drawing.Size(697, 1)
        Me.HorizontalLine5.TabIndex = 34
        Me.HorizontalLine5.TabStop = False
        '
        'lblInfoStandby
        '
        Me.lblInfoStandby.AutoSize = True
        Me.lblInfoStandby.ForeColor = System.Drawing.Color.DimGray
        Me.lblInfoStandby.Location = New System.Drawing.Point(3, 7)
        Me.lblInfoStandby.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblInfoStandby.Name = "lblInfoStandby"
        Me.lblInfoStandby.Size = New System.Drawing.Size(77, 13)
        Me.lblInfoStandby.TabIndex = 3
        Me.lblInfoStandby.Text = "lblInfoStandby"
        '
        'tpAtaReadWrite
        '
        Me.tpAtaReadWrite.AutoScroll = True
        Me.tpAtaReadWrite.BackColor = System.Drawing.Color.White
        Me.tpAtaReadWrite.Controls.Add(Me.tlpOtherContent)
        Me.tpAtaReadWrite.Location = New System.Drawing.Point(4, 22)
        Me.tpAtaReadWrite.Name = "tpAtaReadWrite"
        Me.tpAtaReadWrite.Size = New System.Drawing.Size(703, 355)
        Me.tpAtaReadWrite.TabIndex = 5
        Me.tpAtaReadWrite.Text = "tpAtaReadWrite"
        '
        'tlpOtherContent
        '
        Me.tlpOtherContent.AutoSize = True
        Me.tlpOtherContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpOtherContent.ColumnCount = 1
        Me.tlpOtherContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpOtherContent.Controls.Add(Me.tlpWaitRWMessage, 0, 2)
        Me.tlpOtherContent.Controls.Add(Me.flwOtherFeatures, 0, 0)
        Me.tlpOtherContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpOtherContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpOtherContent.Name = "tlpOtherContent"
        Me.tlpOtherContent.RowCount = 3
        Me.tlpOtherContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOtherContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpOtherContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOtherContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpOtherContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpOtherContent.Size = New System.Drawing.Size(703, 174)
        Me.tlpOtherContent.TabIndex = 24
        '
        'tlpWaitRWMessage
        '
        Me.tlpWaitRWMessage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tlpWaitRWMessage.AutoSize = True
        Me.tlpWaitRWMessage.ColumnCount = 2
        Me.tlpWaitRWMessage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpWaitRWMessage.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpWaitRWMessage.Controls.Add(Me.lblWaitRWMessage, 1, 0)
        Me.tlpWaitRWMessage.Controls.Add(Me.picLoaderRW, 0, 0)
        Me.tlpWaitRWMessage.Location = New System.Drawing.Point(288, 149)
        Me.tlpWaitRWMessage.Name = "tlpWaitRWMessage"
        Me.tlpWaitRWMessage.RowCount = 1
        Me.tlpWaitRWMessage.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWaitRWMessage.Size = New System.Drawing.Size(126, 22)
        Me.tlpWaitRWMessage.TabIndex = 36
        '
        'lblWaitRWMessage
        '
        Me.lblWaitRWMessage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWaitRWMessage.AutoSize = True
        Me.lblWaitRWMessage.ForeColor = System.Drawing.Color.Black
        Me.lblWaitRWMessage.Location = New System.Drawing.Point(25, 4)
        Me.lblWaitRWMessage.Name = "lblWaitRWMessage"
        Me.lblWaitRWMessage.Size = New System.Drawing.Size(98, 13)
        Me.lblWaitRWMessage.TabIndex = 0
        Me.lblWaitRWMessage.Text = "lblWaitRWMessage"
        '
        'picLoaderRW
        '
        Me.picLoaderRW.Image = Global.hdd_guardian.My.Resources.Resources.loader
        Me.picLoaderRW.Location = New System.Drawing.Point(3, 3)
        Me.picLoaderRW.MaximumSize = New System.Drawing.Size(16, 16)
        Me.picLoaderRW.Name = "picLoaderRW"
        Me.picLoaderRW.Size = New System.Drawing.Size(16, 16)
        Me.picLoaderRW.TabIndex = 1
        Me.picLoaderRW.TabStop = False
        '
        'flwOtherFeatures
        '
        Me.flwOtherFeatures.AutoSize = True
        Me.flwOtherFeatures.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flwOtherFeatures.Controls.Add(Me.chkCache)
        Me.flwOtherFeatures.Controls.Add(Me.lblCacheInfo)
        Me.flwOtherFeatures.Controls.Add(Me.chkCacheReorder)
        Me.flwOtherFeatures.Controls.Add(Me.lblCacheReorderInfo)
        Me.flwOtherFeatures.Controls.Add(Me.chkLookAhead)
        Me.flwOtherFeatures.Controls.Add(Me.lblLookAheadInfo)
        Me.flwOtherFeatures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flwOtherFeatures.Location = New System.Drawing.Point(0, 3)
        Me.flwOtherFeatures.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.flwOtherFeatures.Name = "flwOtherFeatures"
        Me.flwOtherFeatures.Size = New System.Drawing.Size(700, 120)
        Me.flwOtherFeatures.TabIndex = 0
        '
        'chkCache
        '
        Me.chkCache.AutoSize = True
        Me.flwOtherFeatures.SetFlowBreak(Me.chkCache, True)
        Me.chkCache.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCache.ForeColor = System.Drawing.Color.Black
        Me.chkCache.Location = New System.Drawing.Point(3, 3)
        Me.chkCache.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.chkCache.MinimumSize = New System.Drawing.Size(0, 16)
        Me.chkCache.Name = "chkCache"
        Me.chkCache.Size = New System.Drawing.Size(72, 17)
        Me.chkCache.TabIndex = 0
        Me.chkCache.Text = "chkCache"
        Me.chkCache.UseVisualStyleBackColor = True
        '
        'lblCacheInfo
        '
        Me.lblCacheInfo.AutoSize = True
        Me.flwOtherFeatures.SetFlowBreak(Me.lblCacheInfo, True)
        Me.lblCacheInfo.ForeColor = System.Drawing.Color.DimGray
        Me.lblCacheInfo.Location = New System.Drawing.Point(20, 20)
        Me.lblCacheInfo.Margin = New System.Windows.Forms.Padding(20, 0, 3, 7)
        Me.lblCacheInfo.Name = "lblCacheInfo"
        Me.lblCacheInfo.Size = New System.Drawing.Size(67, 13)
        Me.lblCacheInfo.TabIndex = 23
        Me.lblCacheInfo.Tag = "Grayed"
        Me.lblCacheInfo.Text = "lblCacheInfo"
        '
        'chkCacheReorder
        '
        Me.chkCacheReorder.AutoSize = True
        Me.flwOtherFeatures.SetFlowBreak(Me.chkCacheReorder, True)
        Me.chkCacheReorder.ForeColor = System.Drawing.Color.Black
        Me.chkCacheReorder.Location = New System.Drawing.Point(3, 40)
        Me.chkCacheReorder.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkCacheReorder.Name = "chkCacheReorder"
        Me.chkCacheReorder.Size = New System.Drawing.Size(111, 17)
        Me.chkCacheReorder.TabIndex = 1
        Me.chkCacheReorder.Text = "chkCacheReorder"
        Me.chkCacheReorder.UseVisualStyleBackColor = True
        '
        'lblCacheReorderInfo
        '
        Me.lblCacheReorderInfo.AutoSize = True
        Me.flwOtherFeatures.SetFlowBreak(Me.lblCacheReorderInfo, True)
        Me.lblCacheReorderInfo.ForeColor = System.Drawing.Color.DimGray
        Me.lblCacheReorderInfo.Location = New System.Drawing.Point(20, 60)
        Me.lblCacheReorderInfo.Margin = New System.Windows.Forms.Padding(20, 0, 3, 7)
        Me.lblCacheReorderInfo.Name = "lblCacheReorderInfo"
        Me.lblCacheReorderInfo.Size = New System.Drawing.Size(106, 13)
        Me.lblCacheReorderInfo.TabIndex = 26
        Me.lblCacheReorderInfo.Tag = "Grayed"
        Me.lblCacheReorderInfo.Text = "lblCacheReorderInfo"
        '
        'chkLookAhead
        '
        Me.chkLookAhead.AutoSize = True
        Me.flwOtherFeatures.SetFlowBreak(Me.chkLookAhead, True)
        Me.chkLookAhead.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLookAhead.ForeColor = System.Drawing.Color.Black
        Me.chkLookAhead.Location = New System.Drawing.Point(3, 80)
        Me.chkLookAhead.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkLookAhead.MinimumSize = New System.Drawing.Size(0, 16)
        Me.chkLookAhead.Name = "chkLookAhead"
        Me.chkLookAhead.Size = New System.Drawing.Size(95, 17)
        Me.chkLookAhead.TabIndex = 2
        Me.chkLookAhead.Text = "chkLookAhead"
        Me.chkLookAhead.UseVisualStyleBackColor = True
        '
        'lblLookAheadInfo
        '
        Me.lblLookAheadInfo.AutoSize = True
        Me.flwOtherFeatures.SetFlowBreak(Me.lblLookAheadInfo, True)
        Me.lblLookAheadInfo.ForeColor = System.Drawing.Color.DimGray
        Me.lblLookAheadInfo.Location = New System.Drawing.Point(20, 100)
        Me.lblLookAheadInfo.Margin = New System.Windows.Forms.Padding(20, 0, 3, 7)
        Me.lblLookAheadInfo.Name = "lblLookAheadInfo"
        Me.lblLookAheadInfo.Size = New System.Drawing.Size(90, 13)
        Me.lblLookAheadInfo.TabIndex = 24
        Me.lblLookAheadInfo.Tag = "Grayed"
        Me.lblLookAheadInfo.Text = "lblLookAheadInfo"
        '
        'tpErrorsTests
        '
        Me.tpErrorsTests.BackColor = System.Drawing.Color.White
        Me.tpErrorsTests.Controls.Add(Me.htcErrorsTests)
        Me.tpErrorsTests.Location = New System.Drawing.Point(4, 22)
        Me.tpErrorsTests.Name = "tpErrorsTests"
        Me.tpErrorsTests.Size = New System.Drawing.Size(711, 381)
        Me.tpErrorsTests.TabIndex = 2
        Me.tpErrorsTests.Text = "tpErrorsTests"
        '
        'htcErrorsTests
        '
        Me.htcErrorsTests.Controls.Add(Me.tpAtaErrors)
        Me.htcErrorsTests.Controls.Add(Me.tpAtaTests)
        Me.htcErrorsTests.Controls.Add(Me.tpAtaRunTest)
        Me.htcErrorsTests.Controls.Add(Me.tpScsiErrors)
        Me.htcErrorsTests.Controls.Add(Me.tpScsiTests)
        Me.htcErrorsTests.Controls.Add(Me.tpScsiRunTest)
        Me.htcErrorsTests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htcErrorsTests.Location = New System.Drawing.Point(0, 0)
        Me.htcErrorsTests.Name = "htcErrorsTests"
        Me.htcErrorsTests.SelectedIndex = 0
        Me.htcErrorsTests.Size = New System.Drawing.Size(711, 381)
        Me.htcErrorsTests.TabIndex = 0
        Me.htcErrorsTests.TabStop = False
        '
        'tpAtaErrors
        '
        Me.tpAtaErrors.AutoScroll = True
        Me.tpAtaErrors.BackColor = System.Drawing.Color.White
        Me.tpAtaErrors.Controls.Add(Me.tlpAtaErrorsContent)
        Me.tpAtaErrors.Location = New System.Drawing.Point(4, 22)
        Me.tpAtaErrors.Name = "tpAtaErrors"
        Me.tpAtaErrors.Size = New System.Drawing.Size(703, 355)
        Me.tpAtaErrors.TabIndex = 0
        Me.tpAtaErrors.Text = "tpAtaErrors"
        '
        'tlpAtaErrorsContent
        '
        Me.tlpAtaErrorsContent.AutoSize = True
        Me.tlpAtaErrorsContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpAtaErrorsContent.ColumnCount = 1
        Me.tlpAtaErrorsContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAtaErrorsContent.Controls.Add(Me.lblErrLogVer, 0, 0)
        Me.tlpAtaErrorsContent.Controls.Add(Me.tlpErrorList, 0, 2)
        Me.tlpAtaErrorsContent.Controls.Add(Me.lblNoError, 0, 1)
        Me.tlpAtaErrorsContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpAtaErrorsContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpAtaErrorsContent.Name = "tlpAtaErrorsContent"
        Me.tlpAtaErrorsContent.RowCount = 3
        Me.tlpAtaErrorsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaErrorsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaErrorsContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAtaErrorsContent.Size = New System.Drawing.Size(703, 355)
        Me.tlpAtaErrorsContent.TabIndex = 24
        '
        'lblErrLogVer
        '
        Me.lblErrLogVer.AutoSize = True
        Me.lblErrLogVer.ForeColor = System.Drawing.Color.Black
        Me.lblErrLogVer.Location = New System.Drawing.Point(3, 0)
        Me.lblErrLogVer.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblErrLogVer.MinimumSize = New System.Drawing.Size(0, 23)
        Me.lblErrLogVer.Name = "lblErrLogVer"
        Me.lblErrLogVer.Size = New System.Drawing.Size(64, 23)
        Me.lblErrLogVer.TabIndex = 20
        Me.lblErrLogVer.Text = "lblErrLogVer"
        Me.lblErrLogVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpErrorList
        '
        Me.tlpErrorList.ColumnCount = 2
        Me.tlpErrorList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpErrorList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.tlpErrorList.Controls.Add(Me.lvwErrors, 0, 0)
        Me.tlpErrorList.Controls.Add(Me.tlpErrorDetails, 1, 0)
        Me.tlpErrorList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpErrorList.Location = New System.Drawing.Point(0, 42)
        Me.tlpErrorList.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpErrorList.Name = "tlpErrorList"
        Me.tlpErrorList.RowCount = 1
        Me.tlpErrorList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpErrorList.Size = New System.Drawing.Size(703, 313)
        Me.tlpErrorList.TabIndex = 24
        '
        'lvwErrors
        '
        Me.lvwErrors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chErrors})
        Me.lvwErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwErrors.FullRowSelect = True
        ListViewGroup4.Header = "grpErrorCount"
        ListViewGroup4.Name = "grpErrorCount"
        Me.lvwErrors.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup4})
        Me.lvwErrors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwErrors.HideSelection = False
        Me.lvwErrors.Location = New System.Drawing.Point(0, 0)
        Me.lvwErrors.Margin = New System.Windows.Forms.Padding(0)
        Me.lvwErrors.MultiSelect = False
        Me.lvwErrors.Name = "lvwErrors"
        Me.lvwErrors.OwnerDraw = True
        Me.lvwErrors.Size = New System.Drawing.Size(503, 313)
        Me.lvwErrors.TabIndex = 4
        Me.lvwErrors.UseCompatibleStateImageBehavior = False
        Me.lvwErrors.View = System.Windows.Forms.View.Details
        '
        'chErrors
        '
        Me.chErrors.Text = "chErrors"
        Me.chErrors.Width = 950
        '
        'tlpErrorDetails
        '
        Me.tlpErrorDetails.AutoSize = True
        Me.tlpErrorDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpErrorDetails.ColumnCount = 1
        Me.tlpErrorDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpErrorDetails.Controls.Add(Me.lblErrorDescription, 0, 1)
        Me.tlpErrorDetails.Controls.Add(Me.lblErrorDescTitle, 0, 0)
        Me.tlpErrorDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpErrorDetails.Location = New System.Drawing.Point(506, 3)
        Me.tlpErrorDetails.Name = "tlpErrorDetails"
        Me.tlpErrorDetails.RowCount = 2
        Me.tlpErrorDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpErrorDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpErrorDetails.Size = New System.Drawing.Size(194, 32)
        Me.tlpErrorDetails.TabIndex = 6
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.AutoSize = True
        Me.lblErrorDescription.Location = New System.Drawing.Point(3, 19)
        Me.lblErrorDescription.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.Size = New System.Drawing.Size(94, 13)
        Me.lblErrorDescription.TabIndex = 5
        Me.lblErrorDescription.Text = "lblErrorDescription"
        '
        'lblErrorDescTitle
        '
        Me.lblErrorDescTitle.AutoSize = True
        Me.lblErrorDescTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblErrorDescTitle.Location = New System.Drawing.Point(3, 0)
        Me.lblErrorDescTitle.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblErrorDescTitle.Name = "lblErrorDescTitle"
        Me.lblErrorDescTitle.Size = New System.Drawing.Size(84, 13)
        Me.lblErrorDescTitle.TabIndex = 6
        Me.lblErrorDescTitle.Tag = "group"
        Me.lblErrorDescTitle.Text = "lblErrorDescTitle"
        '
        'lblNoError
        '
        Me.lblNoError.AutoSize = True
        Me.lblNoError.Location = New System.Drawing.Point(3, 26)
        Me.lblNoError.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblNoError.Name = "lblNoError"
        Me.lblNoError.Size = New System.Drawing.Size(54, 13)
        Me.lblNoError.TabIndex = 25
        Me.lblNoError.Text = "lblNoError"
        '
        'tpAtaTests
        '
        Me.tpAtaTests.BackColor = System.Drawing.Color.White
        Me.tpAtaTests.Controls.Add(Me.tlpTestsContent)
        Me.tpAtaTests.Location = New System.Drawing.Point(4, 22)
        Me.tpAtaTests.Name = "tpAtaTests"
        Me.tpAtaTests.Size = New System.Drawing.Size(703, 355)
        Me.tpAtaTests.TabIndex = 1
        Me.tpAtaTests.Text = "tpAtaTests"
        '
        'tlpTestsContent
        '
        Me.tlpTestsContent.AutoSize = True
        Me.tlpTestsContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTestsContent.ColumnCount = 1
        Me.tlpTestsContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTestsContent.Controls.Add(Me.lvwSelfTest, 0, 1)
        Me.tlpTestsContent.Controls.Add(Me.tlpSelfTests, 0, 0)
        Me.tlpTestsContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpTestsContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpTestsContent.Name = "tlpTestsContent"
        Me.tlpTestsContent.RowCount = 2
        Me.tlpTestsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTestsContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTestsContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpTestsContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpTestsContent.Size = New System.Drawing.Size(703, 355)
        Me.tlpTestsContent.TabIndex = 24
        '
        'lvwSelfTest
        '
        Me.lvwSelfTest.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chNum, Me.chTestType, Me.chTestStatus, Me.chRemaining, Me.chAge, Me.chFirstError})
        Me.lvwSelfTest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwSelfTest.FullRowSelect = True
        Me.lvwSelfTest.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwSelfTest.Location = New System.Drawing.Point(3, 26)
        Me.lvwSelfTest.Name = "lvwSelfTest"
        Me.lvwSelfTest.Size = New System.Drawing.Size(697, 326)
        Me.lvwSelfTest.TabIndex = 1
        Me.lvwSelfTest.UseCompatibleStateImageBehavior = False
        Me.lvwSelfTest.View = System.Windows.Forms.View.Details
        '
        'chNum
        '
        Me.chNum.Text = "Num"
        '
        'chTestType
        '
        Me.chTestType.Text = "Test Type"
        '
        'chTestStatus
        '
        Me.chTestStatus.Text = "Status"
        Me.chTestStatus.Width = 61
        '
        'chRemaining
        '
        Me.chRemaining.Text = "Remaining"
        Me.chRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chRemaining.Width = 72
        '
        'chAge
        '
        Me.chAge.Text = "Device age"
        Me.chAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chAge.Width = 73
        '
        'chFirstError
        '
        Me.chFirstError.Text = "LBA first error"
        Me.chFirstError.Width = 87
        '
        'tlpSelfTests
        '
        Me.tlpSelfTests.AutoSize = True
        Me.tlpSelfTests.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSelfTests.ColumnCount = 2
        Me.tlpSelfTests.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSelfTests.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSelfTests.Controls.Add(Me.lblNoSelfTests, 1, 0)
        Me.tlpSelfTests.Controls.Add(Me.lblSelfTests, 0, 0)
        Me.tlpSelfTests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSelfTests.Location = New System.Drawing.Point(0, 0)
        Me.tlpSelfTests.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpSelfTests.Name = "tlpSelfTests"
        Me.tlpSelfTests.RowCount = 1
        Me.tlpSelfTests.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSelfTests.Size = New System.Drawing.Size(703, 23)
        Me.tlpSelfTests.TabIndex = 9
        '
        'lblNoSelfTests
        '
        Me.lblNoSelfTests.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblNoSelfTests.AutoSize = True
        Me.lblNoSelfTests.ForeColor = System.Drawing.Color.Black
        Me.lblNoSelfTests.Location = New System.Drawing.Point(67, 5)
        Me.lblNoSelfTests.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblNoSelfTests.Name = "lblNoSelfTests"
        Me.lblNoSelfTests.Size = New System.Drawing.Size(74, 13)
        Me.lblNoSelfTests.TabIndex = 6
        Me.lblNoSelfTests.Text = "lblNoSelfTests"
        '
        'lblSelfTests
        '
        Me.lblSelfTests.AutoSize = True
        Me.lblSelfTests.ForeColor = System.Drawing.Color.DimGray
        Me.lblSelfTests.Location = New System.Drawing.Point(3, 0)
        Me.lblSelfTests.MinimumSize = New System.Drawing.Size(0, 23)
        Me.lblSelfTests.Name = "lblSelfTests"
        Me.lblSelfTests.Size = New System.Drawing.Size(61, 23)
        Me.lblSelfTests.TabIndex = 7
        Me.lblSelfTests.Text = "lblSelfTests"
        Me.lblSelfTests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpAtaRunTest
        '
        Me.tpAtaRunTest.AutoScroll = True
        Me.tpAtaRunTest.BackColor = System.Drawing.Color.White
        Me.tpAtaRunTest.Controls.Add(Me.tlpAtaTestContent)
        Me.tpAtaRunTest.Location = New System.Drawing.Point(4, 22)
        Me.tpAtaRunTest.Name = "tpAtaRunTest"
        Me.tpAtaRunTest.Size = New System.Drawing.Size(703, 355)
        Me.tpAtaRunTest.TabIndex = 2
        Me.tpAtaRunTest.Text = "tpAtaRunTest"
        '
        'tlpAtaTestContent
        '
        Me.tlpAtaTestContent.AutoSize = True
        Me.tlpAtaTestContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpAtaTestContent.ColumnCount = 1
        Me.tlpAtaTestContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAtaTestContent.Controls.Add(Me.tlpTestProgress, 0, 3)
        Me.tlpAtaTestContent.Controls.Add(Me.lblInfoTest, 0, 0)
        Me.tlpAtaTestContent.Controls.Add(Me.HorizontalLine8, 0, 1)
        Me.tlpAtaTestContent.Controls.Add(Me.flwTests, 0, 2)
        Me.tlpAtaTestContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpAtaTestContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpAtaTestContent.Name = "tlpAtaTestContent"
        Me.tlpAtaTestContent.RowCount = 4
        Me.tlpAtaTestContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaTestContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpAtaTestContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaTestContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAtaTestContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpAtaTestContent.Size = New System.Drawing.Size(703, 270)
        Me.tlpAtaTestContent.TabIndex = 24
        '
        'tlpTestProgress
        '
        Me.tlpTestProgress.AutoSize = True
        Me.tlpTestProgress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTestProgress.ColumnCount = 3
        Me.tlpTestProgress.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTestProgress.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTestProgress.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTestProgress.Controls.Add(Me.btnStop, 2, 0)
        Me.tlpTestProgress.Controls.Add(Me.flwProgress, 0, 0)
        Me.tlpTestProgress.Controls.Add(Me.btnRun, 1, 0)
        Me.tlpTestProgress.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpTestProgress.Location = New System.Drawing.Point(3, 214)
        Me.tlpTestProgress.Name = "tlpTestProgress"
        Me.tlpTestProgress.RowCount = 1
        Me.tlpTestProgress.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTestProgress.Size = New System.Drawing.Size(697, 53)
        Me.tlpTestProgress.TabIndex = 23
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.Location = New System.Drawing.Point(614, 3)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(80, 23)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "btnStop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'flwProgress
        '
        Me.flwProgress.AutoSize = True
        Me.flwProgress.Controls.Add(Me.prbTestProgress)
        Me.flwProgress.Controls.Add(Me.lblProgress)
        Me.flwProgress.Controls.Add(Me.lblExtimatedEnd)
        Me.flwProgress.Dock = System.Windows.Forms.DockStyle.Top
        Me.flwProgress.Location = New System.Drawing.Point(0, 0)
        Me.flwProgress.Margin = New System.Windows.Forms.Padding(0)
        Me.flwProgress.Name = "flwProgress"
        Me.flwProgress.Size = New System.Drawing.Size(525, 40)
        Me.flwProgress.TabIndex = 22
        '
        'prbTestProgress
        '
        Me.prbTestProgress.Location = New System.Drawing.Point(3, 3)
        Me.prbTestProgress.Name = "prbTestProgress"
        Me.prbTestProgress.Size = New System.Drawing.Size(288, 21)
        Me.prbTestProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prbTestProgress.TabIndex = 16
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblProgress.AutoSize = True
        Me.flwProgress.SetFlowBreak(Me.lblProgress, True)
        Me.lblProgress.ForeColor = System.Drawing.Color.Black
        Me.lblProgress.Location = New System.Drawing.Point(297, 7)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(59, 13)
        Me.lblProgress.TabIndex = 0
        Me.lblProgress.Text = "lblProgress"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblExtimatedEnd
        '
        Me.lblExtimatedEnd.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblExtimatedEnd.AutoSize = True
        Me.lblExtimatedEnd.ForeColor = System.Drawing.Color.Black
        Me.lblExtimatedEnd.Location = New System.Drawing.Point(0, 27)
        Me.lblExtimatedEnd.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblExtimatedEnd.Name = "lblExtimatedEnd"
        Me.lblExtimatedEnd.Size = New System.Drawing.Size(83, 13)
        Me.lblExtimatedEnd.TabIndex = 2
        Me.lblExtimatedEnd.Text = "lblExtimatedEnd"
        '
        'btnRun
        '
        Me.btnRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRun.AutoSize = True
        Me.btnRun.Location = New System.Drawing.Point(528, 3)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(80, 23)
        Me.btnRun.TabIndex = 1
        Me.btnRun.Text = "btnRun"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'lblInfoTest
        '
        Me.lblInfoTest.AutoSize = True
        Me.lblInfoTest.ForeColor = System.Drawing.Color.DimGray
        Me.lblInfoTest.Location = New System.Drawing.Point(3, 7)
        Me.lblInfoTest.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblInfoTest.Name = "lblInfoTest"
        Me.lblInfoTest.Size = New System.Drawing.Size(58, 13)
        Me.lblInfoTest.TabIndex = 3
        Me.lblInfoTest.Text = "lblInfoTest"
        '
        'HorizontalLine8
        '
        Me.HorizontalLine8.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine8.Location = New System.Drawing.Point(3, 32)
        Me.HorizontalLine8.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine8.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine8.Name = "HorizontalLine8"
        Me.HorizontalLine8.Size = New System.Drawing.Size(697, 1)
        Me.HorizontalLine8.TabIndex = 24
        Me.HorizontalLine8.TabStop = False
        '
        'flwTests
        '
        Me.flwTests.AutoSize = True
        Me.flwTests.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flwTests.Controls.Add(Me.optOffline)
        Me.flwTests.Controls.Add(Me.lblOfflineDuration)
        Me.flwTests.Controls.Add(Me.lblOfflineInfo)
        Me.flwTests.Controls.Add(Me.optShort)
        Me.flwTests.Controls.Add(Me.lblShortDuration)
        Me.flwTests.Controls.Add(Me.lblShortInfo)
        Me.flwTests.Controls.Add(Me.optLong)
        Me.flwTests.Controls.Add(Me.lblLongDuration)
        Me.flwTests.Controls.Add(Me.lblLongInfo)
        Me.flwTests.Controls.Add(Me.optConveyance)
        Me.flwTests.Controls.Add(Me.lblConveyanceDuration)
        Me.flwTests.Controls.Add(Me.lblConveyanceInfo)
        Me.flwTests.Dock = System.Windows.Forms.DockStyle.Top
        Me.flwTests.Location = New System.Drawing.Point(3, 46)
        Me.flwTests.Name = "flwTests"
        Me.flwTests.Size = New System.Drawing.Size(697, 162)
        Me.flwTests.TabIndex = 27
        '
        'optOffline
        '
        Me.optOffline.AutoSize = True
        Me.optOffline.Location = New System.Drawing.Point(3, 0)
        Me.optOffline.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.optOffline.Name = "optOffline"
        Me.optOffline.Size = New System.Drawing.Size(73, 17)
        Me.optOffline.TabIndex = 25
        Me.optOffline.TabStop = True
        Me.optOffline.Text = "optOffline"
        Me.optOffline.UseVisualStyleBackColor = True
        '
        'lblOfflineDuration
        '
        Me.lblOfflineDuration.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOfflineDuration.AutoSize = True
        Me.flwTests.SetFlowBreak(Me.lblOfflineDuration, True)
        Me.lblOfflineDuration.Location = New System.Drawing.Point(82, 2)
        Me.lblOfflineDuration.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblOfflineDuration.Name = "lblOfflineDuration"
        Me.lblOfflineDuration.Size = New System.Drawing.Size(90, 13)
        Me.lblOfflineDuration.TabIndex = 26
        Me.lblOfflineDuration.Text = "lblOfflineDuration"
        '
        'lblOfflineInfo
        '
        Me.lblOfflineInfo.AutoSize = True
        Me.flwTests.SetFlowBreak(Me.lblOfflineInfo, True)
        Me.lblOfflineInfo.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblOfflineInfo.Location = New System.Drawing.Point(20, 20)
        Me.lblOfflineInfo.Margin = New System.Windows.Forms.Padding(20, 0, 3, 9)
        Me.lblOfflineInfo.Name = "lblOfflineInfo"
        Me.lblOfflineInfo.Size = New System.Drawing.Size(69, 13)
        Me.lblOfflineInfo.TabIndex = 26
        Me.lblOfflineInfo.Text = "lblOfflineInfo"
        '
        'optShort
        '
        Me.optShort.AutoSize = True
        Me.optShort.Location = New System.Drawing.Point(3, 42)
        Me.optShort.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.optShort.Name = "optShort"
        Me.optShort.Size = New System.Drawing.Size(67, 17)
        Me.optShort.TabIndex = 27
        Me.optShort.TabStop = True
        Me.optShort.Text = "optShort"
        Me.optShort.UseVisualStyleBackColor = True
        '
        'lblShortDuration
        '
        Me.lblShortDuration.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblShortDuration.AutoSize = True
        Me.flwTests.SetFlowBreak(Me.lblShortDuration, True)
        Me.lblShortDuration.Location = New System.Drawing.Point(76, 44)
        Me.lblShortDuration.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblShortDuration.Name = "lblShortDuration"
        Me.lblShortDuration.Size = New System.Drawing.Size(84, 13)
        Me.lblShortDuration.TabIndex = 28
        Me.lblShortDuration.Text = "lblShortDuration"
        '
        'lblShortInfo
        '
        Me.lblShortInfo.AutoSize = True
        Me.flwTests.SetFlowBreak(Me.lblShortInfo, True)
        Me.lblShortInfo.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblShortInfo.Location = New System.Drawing.Point(20, 62)
        Me.lblShortInfo.Margin = New System.Windows.Forms.Padding(20, 0, 3, 9)
        Me.lblShortInfo.Name = "lblShortInfo"
        Me.lblShortInfo.Size = New System.Drawing.Size(63, 13)
        Me.lblShortInfo.TabIndex = 29
        Me.lblShortInfo.Text = "lblShortInfo"
        '
        'optLong
        '
        Me.optLong.AutoSize = True
        Me.optLong.Location = New System.Drawing.Point(3, 84)
        Me.optLong.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.optLong.Name = "optLong"
        Me.optLong.Size = New System.Drawing.Size(64, 17)
        Me.optLong.TabIndex = 30
        Me.optLong.TabStop = True
        Me.optLong.Text = "optLong"
        Me.optLong.UseVisualStyleBackColor = True
        '
        'lblLongDuration
        '
        Me.lblLongDuration.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLongDuration.AutoSize = True
        Me.flwTests.SetFlowBreak(Me.lblLongDuration, True)
        Me.lblLongDuration.Location = New System.Drawing.Point(73, 86)
        Me.lblLongDuration.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLongDuration.Name = "lblLongDuration"
        Me.lblLongDuration.Size = New System.Drawing.Size(81, 13)
        Me.lblLongDuration.TabIndex = 31
        Me.lblLongDuration.Text = "lblLongDuration"
        '
        'lblLongInfo
        '
        Me.lblLongInfo.AutoSize = True
        Me.flwTests.SetFlowBreak(Me.lblLongInfo, True)
        Me.lblLongInfo.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblLongInfo.Location = New System.Drawing.Point(20, 104)
        Me.lblLongInfo.Margin = New System.Windows.Forms.Padding(20, 0, 3, 9)
        Me.lblLongInfo.Name = "lblLongInfo"
        Me.lblLongInfo.Size = New System.Drawing.Size(60, 13)
        Me.lblLongInfo.TabIndex = 32
        Me.lblLongInfo.Text = "lblLongInfo"
        '
        'optConveyance
        '
        Me.optConveyance.AutoSize = True
        Me.optConveyance.Location = New System.Drawing.Point(3, 126)
        Me.optConveyance.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.optConveyance.Name = "optConveyance"
        Me.optConveyance.Size = New System.Drawing.Size(101, 17)
        Me.optConveyance.TabIndex = 33
        Me.optConveyance.TabStop = True
        Me.optConveyance.Text = "optConveyance"
        Me.optConveyance.UseVisualStyleBackColor = True
        '
        'lblConveyanceDuration
        '
        Me.lblConveyanceDuration.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblConveyanceDuration.AutoSize = True
        Me.lblConveyanceDuration.CausesValidation = False
        Me.flwTests.SetFlowBreak(Me.lblConveyanceDuration, True)
        Me.lblConveyanceDuration.Location = New System.Drawing.Point(110, 128)
        Me.lblConveyanceDuration.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblConveyanceDuration.Name = "lblConveyanceDuration"
        Me.lblConveyanceDuration.Size = New System.Drawing.Size(118, 13)
        Me.lblConveyanceDuration.TabIndex = 34
        Me.lblConveyanceDuration.Text = "lblConveyanceDuration"
        '
        'lblConveyanceInfo
        '
        Me.lblConveyanceInfo.AutoSize = True
        Me.lblConveyanceInfo.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblConveyanceInfo.Location = New System.Drawing.Point(20, 146)
        Me.lblConveyanceInfo.Margin = New System.Windows.Forms.Padding(20, 0, 3, 3)
        Me.lblConveyanceInfo.Name = "lblConveyanceInfo"
        Me.lblConveyanceInfo.Size = New System.Drawing.Size(97, 13)
        Me.lblConveyanceInfo.TabIndex = 35
        Me.lblConveyanceInfo.Text = "lblConveyanceInfo"
        '
        'tpScsiErrors
        '
        Me.tpScsiErrors.BackColor = System.Drawing.Color.White
        Me.tpScsiErrors.Controls.Add(Me.tlpScsiErrorsContent)
        Me.tpScsiErrors.Location = New System.Drawing.Point(4, 22)
        Me.tpScsiErrors.Name = "tpScsiErrors"
        Me.tpScsiErrors.Size = New System.Drawing.Size(703, 355)
        Me.tpScsiErrors.TabIndex = 3
        Me.tpScsiErrors.Text = "tpScsiErrors"
        '
        'tlpScsiErrorsContent
        '
        Me.tlpScsiErrorsContent.AutoSize = True
        Me.tlpScsiErrorsContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpScsiErrorsContent.ColumnCount = 1
        Me.tlpScsiErrorsContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpScsiErrorsContent.Controls.Add(Me.lblScsiNoErrors, 0, 0)
        Me.tlpScsiErrorsContent.Controls.Add(Me.lvwScsiErrors, 0, 1)
        Me.tlpScsiErrorsContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpScsiErrorsContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpScsiErrorsContent.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpScsiErrorsContent.Name = "tlpScsiErrorsContent"
        Me.tlpScsiErrorsContent.RowCount = 2
        Me.tlpScsiErrorsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiErrorsContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpScsiErrorsContent.Size = New System.Drawing.Size(703, 355)
        Me.tlpScsiErrorsContent.TabIndex = 24
        '
        'lblScsiNoErrors
        '
        Me.lblScsiNoErrors.AutoSize = True
        Me.lblScsiNoErrors.ForeColor = System.Drawing.Color.Black
        Me.lblScsiNoErrors.Location = New System.Drawing.Point(3, 7)
        Me.lblScsiNoErrors.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblScsiNoErrors.Name = "lblScsiNoErrors"
        Me.lblScsiNoErrors.Size = New System.Drawing.Size(77, 13)
        Me.lblScsiNoErrors.TabIndex = 1
        Me.lblScsiNoErrors.Text = "lblScsiNoErrors"
        '
        'lvwScsiErrors
        '
        Me.lvwScsiErrors.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chScsiErrorItem, Me.chScsiErrorItemValue})
        Me.lvwScsiErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwScsiErrors.FullRowSelect = True
        ListViewGroup5.Header = "grpRead"
        ListViewGroup5.Name = "grpRead"
        ListViewGroup6.Header = "grpWrite"
        ListViewGroup6.Name = "grpWrite"
        ListViewGroup7.Header = "grpVerify"
        ListViewGroup7.Name = "grpVerify"
        Me.lvwScsiErrors.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup5, ListViewGroup6, ListViewGroup7})
        Me.lvwScsiErrors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwScsiErrors.Location = New System.Drawing.Point(3, 26)
        Me.lvwScsiErrors.MultiSelect = False
        Me.lvwScsiErrors.Name = "lvwScsiErrors"
        Me.lvwScsiErrors.Size = New System.Drawing.Size(697, 326)
        Me.lvwScsiErrors.TabIndex = 2
        Me.lvwScsiErrors.UseCompatibleStateImageBehavior = False
        Me.lvwScsiErrors.View = System.Windows.Forms.View.Details
        '
        'chScsiErrorItem
        '
        Me.chScsiErrorItem.Text = "chScsiErrorItem"
        '
        'chScsiErrorItemValue
        '
        Me.chScsiErrorItemValue.Text = "chScsiErrorItemValue"
        Me.chScsiErrorItemValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tpScsiTests
        '
        Me.tpScsiTests.BackColor = System.Drawing.Color.White
        Me.tpScsiTests.Controls.Add(Me.tlpScsiTestsContent)
        Me.tpScsiTests.Location = New System.Drawing.Point(4, 22)
        Me.tpScsiTests.Name = "tpScsiTests"
        Me.tpScsiTests.Size = New System.Drawing.Size(703, 355)
        Me.tpScsiTests.TabIndex = 4
        Me.tpScsiTests.Text = "tpScsiTests"
        '
        'tlpScsiTestsContent
        '
        Me.tlpScsiTestsContent.AutoSize = True
        Me.tlpScsiTestsContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpScsiTestsContent.ColumnCount = 1
        Me.tlpScsiTestsContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpScsiTestsContent.Controls.Add(Me.lblScsiTestCounter, 0, 0)
        Me.tlpScsiTestsContent.Controls.Add(Me.lvwScsiTests, 0, 1)
        Me.tlpScsiTestsContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpScsiTestsContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpScsiTestsContent.Name = "tlpScsiTestsContent"
        Me.tlpScsiTestsContent.RowCount = 2
        Me.tlpScsiTestsContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiTestsContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpScsiTestsContent.Size = New System.Drawing.Size(703, 355)
        Me.tlpScsiTestsContent.TabIndex = 24
        '
        'lblScsiTestCounter
        '
        Me.lblScsiTestCounter.AutoSize = True
        Me.lblScsiTestCounter.ForeColor = System.Drawing.Color.Black
        Me.lblScsiTestCounter.Location = New System.Drawing.Point(3, 7)
        Me.lblScsiTestCounter.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblScsiTestCounter.Name = "lblScsiTestCounter"
        Me.lblScsiTestCounter.Size = New System.Drawing.Size(95, 13)
        Me.lblScsiTestCounter.TabIndex = 2
        Me.lblScsiTestCounter.Text = "lblScsiTestCounter"
        '
        'lvwScsiTests
        '
        Me.lvwScsiTests.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chScsiNum, Me.chScsiTest, Me.chScsiStatus, Me.chScsiSegment, Me.chScsiLifetime, Me.chScsiFirstErr, Me.chScsiSK, Me.chScsiASK, Me.chScsiASQ})
        Me.lvwScsiTests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwScsiTests.FullRowSelect = True
        Me.lvwScsiTests.Location = New System.Drawing.Point(3, 26)
        Me.lvwScsiTests.Name = "lvwScsiTests"
        Me.lvwScsiTests.Size = New System.Drawing.Size(697, 326)
        Me.lvwScsiTests.TabIndex = 3
        Me.lvwScsiTests.UseCompatibleStateImageBehavior = False
        Me.lvwScsiTests.View = System.Windows.Forms.View.Details
        '
        'chScsiNum
        '
        Me.chScsiNum.Text = "chScsiNum"
        '
        'chScsiTest
        '
        Me.chScsiTest.Text = "chScsiTest"
        '
        'chScsiStatus
        '
        Me.chScsiStatus.Text = "chScsiStatus"
        '
        'chScsiSegment
        '
        Me.chScsiSegment.Text = "chScsiSegment"
        Me.chScsiSegment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chScsiLifetime
        '
        Me.chScsiLifetime.Text = "chScsiLifetime"
        Me.chScsiLifetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chScsiFirstErr
        '
        Me.chScsiFirstErr.Text = "chScsiFirstErr"
        Me.chScsiFirstErr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chScsiSK
        '
        Me.chScsiSK.Text = "chScsiSK"
        Me.chScsiSK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chScsiASK
        '
        Me.chScsiASK.Text = "chScsiASK"
        Me.chScsiASK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chScsiASQ
        '
        Me.chScsiASQ.Text = "chScsiASQ"
        Me.chScsiASQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tpScsiRunTest
        '
        Me.tpScsiRunTest.BackColor = System.Drawing.Color.White
        Me.tpScsiRunTest.Controls.Add(Me.tlpScsiTestContent)
        Me.tpScsiRunTest.Location = New System.Drawing.Point(4, 22)
        Me.tpScsiRunTest.Name = "tpScsiRunTest"
        Me.tpScsiRunTest.Size = New System.Drawing.Size(703, 355)
        Me.tpScsiRunTest.TabIndex = 5
        Me.tpScsiRunTest.Text = "tpScsiRunTest"
        '
        'tlpScsiTestContent
        '
        Me.tlpScsiTestContent.AutoSize = True
        Me.tlpScsiTestContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpScsiTestContent.ColumnCount = 1
        Me.tlpScsiTestContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpScsiTestContent.Controls.Add(Me.lblScsiInfoTest, 0, 0)
        Me.tlpScsiTestContent.Controls.Add(Me.tlpScsiTest, 0, 2)
        Me.tlpScsiTestContent.Controls.Add(Me.HorizontalLine14, 0, 1)
        Me.tlpScsiTestContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpScsiTestContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpScsiTestContent.Name = "tlpScsiTestContent"
        Me.tlpScsiTestContent.RowCount = 3
        Me.tlpScsiTestContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiTestContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpScsiTestContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiTestContent.Size = New System.Drawing.Size(703, 110)
        Me.tlpScsiTestContent.TabIndex = 23
        '
        'lblScsiInfoTest
        '
        Me.lblScsiInfoTest.AutoSize = True
        Me.lblScsiInfoTest.ForeColor = System.Drawing.Color.DimGray
        Me.lblScsiInfoTest.Location = New System.Drawing.Point(3, 7)
        Me.lblScsiInfoTest.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblScsiInfoTest.Name = "lblScsiInfoTest"
        Me.lblScsiInfoTest.Size = New System.Drawing.Size(76, 13)
        Me.lblScsiInfoTest.TabIndex = 4
        Me.lblScsiInfoTest.Text = "lblScsiInfoTest"
        '
        'tlpScsiTest
        '
        Me.tlpScsiTest.AutoSize = True
        Me.tlpScsiTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpScsiTest.ColumnCount = 3
        Me.tlpScsiTest.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpScsiTest.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpScsiTest.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpScsiTest.Controls.Add(Me.pnlScsiTestRun, 0, 1)
        Me.tlpScsiTest.Controls.Add(Me.lblScsiTest, 0, 0)
        Me.tlpScsiTest.Controls.Add(Me.btnScsiStop, 2, 1)
        Me.tlpScsiTest.Controls.Add(Me.btnScsiRun, 1, 1)
        Me.tlpScsiTest.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpScsiTest.Location = New System.Drawing.Point(0, 43)
        Me.tlpScsiTest.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpScsiTest.Name = "tlpScsiTest"
        Me.tlpScsiTest.RowCount = 2
        Me.tlpScsiTest.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiTest.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpScsiTest.Size = New System.Drawing.Size(703, 67)
        Me.tlpScsiTest.TabIndex = 22
        '
        'pnlScsiTestRun
        '
        Me.pnlScsiTestRun.AutoSize = True
        Me.pnlScsiTestRun.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlScsiTestRun.Controls.Add(Me.lblScsiExtimatedEnd)
        Me.pnlScsiTestRun.Controls.Add(Me.prbScsiTestProgress)
        Me.pnlScsiTestRun.Controls.Add(Me.lblScsiProgress)
        Me.pnlScsiTestRun.Location = New System.Drawing.Point(3, 27)
        Me.pnlScsiTestRun.Name = "pnlScsiTestRun"
        Me.pnlScsiTestRun.Size = New System.Drawing.Size(376, 37)
        Me.pnlScsiTestRun.TabIndex = 21
        '
        'lblScsiExtimatedEnd
        '
        Me.lblScsiExtimatedEnd.AutoSize = True
        Me.lblScsiExtimatedEnd.ForeColor = System.Drawing.Color.Black
        Me.lblScsiExtimatedEnd.Location = New System.Drawing.Point(0, 24)
        Me.lblScsiExtimatedEnd.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblScsiExtimatedEnd.Name = "lblScsiExtimatedEnd"
        Me.lblScsiExtimatedEnd.Size = New System.Drawing.Size(101, 13)
        Me.lblScsiExtimatedEnd.TabIndex = 2
        Me.lblScsiExtimatedEnd.Text = "lblScsiExtimatedEnd"
        '
        'prbScsiTestProgress
        '
        Me.prbScsiTestProgress.Location = New System.Drawing.Point(0, 0)
        Me.prbScsiTestProgress.Name = "prbScsiTestProgress"
        Me.prbScsiTestProgress.Size = New System.Drawing.Size(288, 21)
        Me.prbScsiTestProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prbScsiTestProgress.TabIndex = 16
        '
        'lblScsiProgress
        '
        Me.lblScsiProgress.AutoSize = True
        Me.lblScsiProgress.ForeColor = System.Drawing.Color.Black
        Me.lblScsiProgress.Location = New System.Drawing.Point(296, 0)
        Me.lblScsiProgress.MinimumSize = New System.Drawing.Size(0, 21)
        Me.lblScsiProgress.Name = "lblScsiProgress"
        Me.lblScsiProgress.Size = New System.Drawing.Size(77, 21)
        Me.lblScsiProgress.TabIndex = 0
        Me.lblScsiProgress.Text = "lblScsiProgress"
        Me.lblScsiProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScsiTest
        '
        Me.lblScsiTest.AutoSize = True
        Me.lblScsiTest.ForeColor = System.Drawing.Color.Black
        Me.lblScsiTest.Location = New System.Drawing.Point(3, 3)
        Me.lblScsiTest.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblScsiTest.MinimumSize = New System.Drawing.Size(0, 21)
        Me.lblScsiTest.Name = "lblScsiTest"
        Me.lblScsiTest.Size = New System.Drawing.Size(56, 21)
        Me.lblScsiTest.TabIndex = 0
        Me.lblScsiTest.Text = "lblScsiTest"
        Me.lblScsiTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnScsiStop
        '
        Me.btnScsiStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScsiStop.Location = New System.Drawing.Point(620, 27)
        Me.btnScsiStop.Name = "btnScsiStop"
        Me.btnScsiStop.Size = New System.Drawing.Size(80, 23)
        Me.btnScsiStop.TabIndex = 2
        Me.btnScsiStop.Text = "btnScsiStop"
        Me.btnScsiStop.UseVisualStyleBackColor = True
        '
        'btnScsiRun
        '
        Me.btnScsiRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScsiRun.AutoSize = True
        Me.btnScsiRun.Location = New System.Drawing.Point(534, 27)
        Me.btnScsiRun.Name = "btnScsiRun"
        Me.btnScsiRun.Size = New System.Drawing.Size(80, 23)
        Me.btnScsiRun.TabIndex = 1
        Me.btnScsiRun.Text = "btnScsiRun"
        Me.btnScsiRun.UseVisualStyleBackColor = True
        '
        'HorizontalLine14
        '
        Me.HorizontalLine14.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine14.Location = New System.Drawing.Point(3, 32)
        Me.HorizontalLine14.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine14.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine14.Name = "HorizontalLine14"
        Me.HorizontalLine14.Size = New System.Drawing.Size(697, 1)
        Me.HorizontalLine14.TabIndex = 25
        Me.HorizontalLine14.TabStop = False
        '
        'tpSmartctl
        '
        Me.tpSmartctl.BackColor = System.Drawing.Color.White
        Me.tpSmartctl.Controls.Add(Me.htcSmartctl)
        Me.tpSmartctl.Location = New System.Drawing.Point(4, 22)
        Me.tpSmartctl.Name = "tpSmartctl"
        Me.tpSmartctl.Size = New System.Drawing.Size(711, 381)
        Me.tpSmartctl.TabIndex = 3
        Me.tpSmartctl.Text = "tpSmartctl"
        '
        'htcSmartctl
        '
        Me.htcSmartctl.Controls.Add(Me.tpOutput)
        Me.htcSmartctl.Controls.Add(Me.tpAdvanced)
        Me.htcSmartctl.Controls.Add(Me.tpVersion)
        Me.htcSmartctl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htcSmartctl.Location = New System.Drawing.Point(0, 0)
        Me.htcSmartctl.Name = "htcSmartctl"
        Me.htcSmartctl.SelectedIndex = 0
        Me.htcSmartctl.Size = New System.Drawing.Size(711, 381)
        Me.htcSmartctl.TabIndex = 0
        Me.htcSmartctl.TabStop = False
        '
        'tpOutput
        '
        Me.tpOutput.BackColor = System.Drawing.Color.Transparent
        Me.tpOutput.Controls.Add(Me.tlpOutput)
        Me.tpOutput.Location = New System.Drawing.Point(4, 22)
        Me.tpOutput.Name = "tpOutput"
        Me.tpOutput.Size = New System.Drawing.Size(703, 355)
        Me.tpOutput.TabIndex = 0
        Me.tpOutput.Text = "tpOutput"
        '
        'tlpOutput
        '
        Me.tlpOutput.AutoSize = True
        Me.tlpOutput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpOutput.ColumnCount = 1
        Me.tlpOutput.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpOutput.Controls.Add(Me.txtReport, 0, 0)
        Me.tlpOutput.Controls.Add(Me.btnSaveOutput, 0, 1)
        Me.tlpOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpOutput.Location = New System.Drawing.Point(0, 0)
        Me.tlpOutput.Name = "tlpOutput"
        Me.tlpOutput.RowCount = 2
        Me.tlpOutput.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpOutput.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpOutput.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpOutput.Size = New System.Drawing.Size(703, 355)
        Me.tlpOutput.TabIndex = 24
        '
        'txtReport
        '
        Me.txtReport.BackColor = System.Drawing.Color.White
        Me.txtReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtReport.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReport.ForeColor = System.Drawing.Color.Black
        Me.txtReport.Location = New System.Drawing.Point(3, 3)
        Me.txtReport.Multiline = True
        Me.txtReport.Name = "txtReport"
        Me.txtReport.ReadOnly = True
        Me.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtReport.Size = New System.Drawing.Size(697, 320)
        Me.txtReport.TabIndex = 0
        Me.txtReport.WordWrap = False
        '
        'btnSaveOutput
        '
        Me.btnSaveOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveOutput.Location = New System.Drawing.Point(625, 329)
        Me.btnSaveOutput.Name = "btnSaveOutput"
        Me.btnSaveOutput.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveOutput.TabIndex = 1
        Me.btnSaveOutput.Text = "btnSaveOutput"
        Me.btnSaveOutput.UseVisualStyleBackColor = True
        '
        'tpAdvanced
        '
        Me.tpAdvanced.Controls.Add(Me.tlpAdvanced)
        Me.tpAdvanced.Location = New System.Drawing.Point(4, 22)
        Me.tpAdvanced.Name = "tpAdvanced"
        Me.tpAdvanced.Size = New System.Drawing.Size(703, 355)
        Me.tpAdvanced.TabIndex = 4
        Me.tpAdvanced.Text = "tpAdvanced"
        Me.tpAdvanced.UseVisualStyleBackColor = True
        '
        'tlpAdvanced
        '
        Me.tlpAdvanced.AutoSize = True
        Me.tlpAdvanced.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpAdvanced.ColumnCount = 1
        Me.tlpAdvanced.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAdvanced.Controls.Add(Me.HorizontalLine12, 0, 1)
        Me.tlpAdvanced.Controls.Add(Me.lblAdminAdvanced, 0, 0)
        Me.tlpAdvanced.Controls.Add(Me.tabAdvanced, 0, 2)
        Me.tlpAdvanced.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpAdvanced.Location = New System.Drawing.Point(0, 0)
        Me.tlpAdvanced.Name = "tlpAdvanced"
        Me.tlpAdvanced.RowCount = 3
        Me.tlpAdvanced.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAdvanced.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAdvanced.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAdvanced.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpAdvanced.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpAdvanced.Size = New System.Drawing.Size(703, 355)
        Me.tlpAdvanced.TabIndex = 0
        '
        'HorizontalLine12
        '
        Me.HorizontalLine12.BackColor = System.Drawing.Color.Silver
        Me.HorizontalLine12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalLine12.Location = New System.Drawing.Point(3, 32)
        Me.HorizontalLine12.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.HorizontalLine12.MaximumSize = New System.Drawing.Size(0, 1)
        Me.HorizontalLine12.Name = "HorizontalLine12"
        Me.HorizontalLine12.Size = New System.Drawing.Size(697, 1)
        Me.HorizontalLine12.TabIndex = 9
        Me.HorizontalLine12.TabStop = False
        '
        'lblAdminAdvanced
        '
        Me.lblAdminAdvanced.AutoSize = True
        Me.lblAdminAdvanced.ForeColor = System.Drawing.Color.DimGray
        Me.lblAdminAdvanced.Location = New System.Drawing.Point(3, 7)
        Me.lblAdminAdvanced.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.lblAdminAdvanced.Name = "lblAdminAdvanced"
        Me.lblAdminAdvanced.Size = New System.Drawing.Size(94, 13)
        Me.lblAdminAdvanced.TabIndex = 4
        Me.lblAdminAdvanced.Text = "lblAdminAdvanced"
        '
        'tabAdvanced
        '
        Me.tabAdvanced.Controls.Add(Me.tpPower)
        Me.tabAdvanced.Controls.Add(Me.tpRemap)
        Me.tabAdvanced.Controls.Add(Me.tpFirmware)
        Me.tabAdvanced.Controls.Add(Me.tpAsmedia)
        Me.tabAdvanced.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabAdvanced.Location = New System.Drawing.Point(3, 42)
        Me.tabAdvanced.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.tabAdvanced.Name = "tabAdvanced"
        Me.tabAdvanced.SelectedIndex = 0
        Me.tabAdvanced.Size = New System.Drawing.Size(697, 312)
        Me.tabAdvanced.TabIndex = 29
        '
        'tpPower
        '
        Me.tpPower.Controls.Add(Me.tlpPowerModeContent)
        Me.tpPower.Location = New System.Drawing.Point(4, 22)
        Me.tpPower.Name = "tpPower"
        Me.tpPower.Size = New System.Drawing.Size(689, 286)
        Me.tpPower.TabIndex = 0
        Me.tpPower.Text = "tpPower"
        Me.tpPower.UseVisualStyleBackColor = True
        '
        'tlpPowerModeContent
        '
        Me.tlpPowerModeContent.AutoSize = True
        Me.tlpPowerModeContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPowerModeContent.ColumnCount = 1
        Me.tlpPowerModeContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPowerModeContent.Controls.Add(Me.flwPowerMode, 0, 2)
        Me.tlpPowerModeContent.Controls.Add(Me.lblPowerInfo, 0, 0)
        Me.tlpPowerModeContent.Controls.Add(Me.chkPowerMode, 0, 1)
        Me.tlpPowerModeContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpPowerModeContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpPowerModeContent.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpPowerModeContent.Name = "tlpPowerModeContent"
        Me.tlpPowerModeContent.RowCount = 3
        Me.tlpPowerModeContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPowerModeContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPowerModeContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPowerModeContent.Size = New System.Drawing.Size(689, 187)
        Me.tlpPowerModeContent.TabIndex = 28
        '
        'flwPowerMode
        '
        Me.flwPowerMode.AutoScroll = True
        Me.flwPowerMode.AutoSize = True
        Me.flwPowerMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flwPowerMode.Controls.Add(Me.rbNever)
        Me.flwPowerMode.Controls.Add(Me.lblNever)
        Me.flwPowerMode.Controls.Add(Me.rbSleep)
        Me.flwPowerMode.Controls.Add(Me.lblSleep)
        Me.flwPowerMode.Controls.Add(Me.rbStandby)
        Me.flwPowerMode.Controls.Add(Me.lblStandby)
        Me.flwPowerMode.Controls.Add(Me.rbIdle)
        Me.flwPowerMode.Controls.Add(Me.lblIdle)
        Me.flwPowerMode.Dock = System.Windows.Forms.DockStyle.Top
        Me.flwPowerMode.Location = New System.Drawing.Point(16, 49)
        Me.flwPowerMode.Margin = New System.Windows.Forms.Padding(16, 3, 3, 3)
        Me.flwPowerMode.Name = "flwPowerMode"
        Me.flwPowerMode.Size = New System.Drawing.Size(670, 135)
        Me.flwPowerMode.TabIndex = 9
        '
        'rbNever
        '
        Me.rbNever.AutoSize = True
        Me.flwPowerMode.SetFlowBreak(Me.rbNever, True)
        Me.rbNever.ForeColor = System.Drawing.Color.Black
        Me.rbNever.Location = New System.Drawing.Point(3, 3)
        Me.rbNever.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.rbNever.Name = "rbNever"
        Me.rbNever.Size = New System.Drawing.Size(64, 17)
        Me.rbNever.TabIndex = 10
        Me.rbNever.TabStop = True
        Me.rbNever.Text = "rbNever"
        Me.rbNever.UseVisualStyleBackColor = True
        '
        'lblNever
        '
        Me.lblNever.AutoSize = True
        Me.flwPowerMode.SetFlowBreak(Me.lblNever, True)
        Me.lblNever.ForeColor = System.Drawing.Color.DimGray
        Me.lblNever.Location = New System.Drawing.Point(20, 20)
        Me.lblNever.Margin = New System.Windows.Forms.Padding(20, 0, 3, 3)
        Me.lblNever.Name = "lblNever"
        Me.lblNever.Size = New System.Drawing.Size(46, 13)
        Me.lblNever.TabIndex = 1
        Me.lblNever.Tag = "Grayed"
        Me.lblNever.Text = "lblNever"
        '
        'rbSleep
        '
        Me.rbSleep.AutoSize = True
        Me.flwPowerMode.SetFlowBreak(Me.rbSleep, True)
        Me.rbSleep.ForeColor = System.Drawing.Color.Black
        Me.rbSleep.Location = New System.Drawing.Point(3, 37)
        Me.rbSleep.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbSleep.Name = "rbSleep"
        Me.rbSleep.Size = New System.Drawing.Size(61, 17)
        Me.rbSleep.TabIndex = 11
        Me.rbSleep.TabStop = True
        Me.rbSleep.Text = "rbSleep"
        Me.rbSleep.UseVisualStyleBackColor = True
        '
        'lblSleep
        '
        Me.lblSleep.AutoSize = True
        Me.flwPowerMode.SetFlowBreak(Me.lblSleep, True)
        Me.lblSleep.ForeColor = System.Drawing.Color.DimGray
        Me.lblSleep.Location = New System.Drawing.Point(20, 54)
        Me.lblSleep.Margin = New System.Windows.Forms.Padding(20, 0, 3, 3)
        Me.lblSleep.Name = "lblSleep"
        Me.lblSleep.Size = New System.Drawing.Size(43, 13)
        Me.lblSleep.TabIndex = 3
        Me.lblSleep.Tag = "Grayed"
        Me.lblSleep.Text = "lblSleep"
        '
        'rbStandby
        '
        Me.rbStandby.AutoSize = True
        Me.flwPowerMode.SetFlowBreak(Me.rbStandby, True)
        Me.rbStandby.ForeColor = System.Drawing.Color.Black
        Me.rbStandby.Location = New System.Drawing.Point(3, 71)
        Me.rbStandby.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbStandby.Name = "rbStandby"
        Me.rbStandby.Size = New System.Drawing.Size(75, 17)
        Me.rbStandby.TabIndex = 12
        Me.rbStandby.TabStop = True
        Me.rbStandby.Text = "rbStandby"
        Me.rbStandby.UseVisualStyleBackColor = True
        '
        'lblStandby
        '
        Me.lblStandby.AutoSize = True
        Me.flwPowerMode.SetFlowBreak(Me.lblStandby, True)
        Me.lblStandby.ForeColor = System.Drawing.Color.DimGray
        Me.lblStandby.Location = New System.Drawing.Point(20, 88)
        Me.lblStandby.Margin = New System.Windows.Forms.Padding(20, 0, 3, 3)
        Me.lblStandby.Name = "lblStandby"
        Me.lblStandby.Size = New System.Drawing.Size(57, 13)
        Me.lblStandby.TabIndex = 5
        Me.lblStandby.Tag = "Grayed"
        Me.lblStandby.Text = "lblStandby"
        '
        'rbIdle
        '
        Me.rbIdle.AutoSize = True
        Me.flwPowerMode.SetFlowBreak(Me.rbIdle, True)
        Me.rbIdle.ForeColor = System.Drawing.Color.Black
        Me.rbIdle.Location = New System.Drawing.Point(3, 105)
        Me.rbIdle.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.rbIdle.Name = "rbIdle"
        Me.rbIdle.Size = New System.Drawing.Size(53, 17)
        Me.rbIdle.TabIndex = 13
        Me.rbIdle.TabStop = True
        Me.rbIdle.Text = "rbIdle"
        Me.rbIdle.UseVisualStyleBackColor = True
        '
        'lblIdle
        '
        Me.lblIdle.AutoSize = True
        Me.lblIdle.ForeColor = System.Drawing.Color.DimGray
        Me.lblIdle.Location = New System.Drawing.Point(20, 122)
        Me.lblIdle.Margin = New System.Windows.Forms.Padding(20, 0, 3, 0)
        Me.lblIdle.Name = "lblIdle"
        Me.lblIdle.Size = New System.Drawing.Size(35, 13)
        Me.lblIdle.TabIndex = 7
        Me.lblIdle.Tag = "Grayed"
        Me.lblIdle.Text = "lblIdle"
        '
        'lblPowerInfo
        '
        Me.lblPowerInfo.AutoSize = True
        Me.lblPowerInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblPowerInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPowerInfo.ForeColor = System.Drawing.Color.DimGray
        Me.lblPowerInfo.Location = New System.Drawing.Point(0, 3)
        Me.lblPowerInfo.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblPowerInfo.Name = "lblPowerInfo"
        Me.lblPowerInfo.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblPowerInfo.Size = New System.Drawing.Size(689, 17)
        Me.lblPowerInfo.TabIndex = 1
        Me.lblPowerInfo.Text = "lblPowerInfo"
        Me.lblPowerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkPowerMode
        '
        Me.chkPowerMode.AutoSize = True
        Me.chkPowerMode.ForeColor = System.Drawing.Color.Black
        Me.chkPowerMode.Location = New System.Drawing.Point(3, 26)
        Me.chkPowerMode.Name = "chkPowerMode"
        Me.chkPowerMode.Size = New System.Drawing.Size(98, 17)
        Me.chkPowerMode.TabIndex = 9
        Me.chkPowerMode.Text = "chkPowerMode"
        Me.chkPowerMode.UseVisualStyleBackColor = True
        '
        'tpRemap
        '
        Me.tpRemap.Controls.Add(Me.tlpRemapContent)
        Me.tpRemap.Location = New System.Drawing.Point(4, 22)
        Me.tpRemap.Name = "tpRemap"
        Me.tpRemap.Size = New System.Drawing.Size(689, 286)
        Me.tpRemap.TabIndex = 1
        Me.tpRemap.Text = "tpRemap"
        Me.tpRemap.UseVisualStyleBackColor = True
        '
        'tlpRemapContent
        '
        Me.tlpRemapContent.AutoSize = True
        Me.tlpRemapContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpRemapContent.ColumnCount = 1
        Me.tlpRemapContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRemapContent.Controls.Add(Me.pnlAttributes, 0, 2)
        Me.tlpRemapContent.Controls.Add(Me.lblRemapInfo, 0, 0)
        Me.tlpRemapContent.Controls.Add(Me.chkAttributes, 0, 1)
        Me.tlpRemapContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRemapContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpRemapContent.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpRemapContent.Name = "tlpRemapContent"
        Me.tlpRemapContent.RowCount = 3
        Me.tlpRemapContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRemapContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRemapContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRemapContent.Size = New System.Drawing.Size(689, 286)
        Me.tlpRemapContent.TabIndex = 26
        '
        'pnlAttributes
        '
        Me.pnlAttributes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlAttributes.Controls.Add(Me.lvwAttrFormat)
        Me.pnlAttributes.Controls.Add(Me.tlpButtons)
        Me.pnlAttributes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAttributes.Location = New System.Drawing.Point(16, 49)
        Me.pnlAttributes.Margin = New System.Windows.Forms.Padding(16, 3, 3, 3)
        Me.pnlAttributes.Name = "pnlAttributes"
        Me.pnlAttributes.Size = New System.Drawing.Size(670, 234)
        Me.pnlAttributes.TabIndex = 7
        '
        'lvwAttrFormat
        '
        Me.lvwAttrFormat.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chAttrID, Me.chAttrFormat, Me.chAttrName})
        Me.lvwAttrFormat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwAttrFormat.FullRowSelect = True
        Me.lvwAttrFormat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwAttrFormat.HideSelection = False
        Me.lvwAttrFormat.Location = New System.Drawing.Point(0, 0)
        Me.lvwAttrFormat.Name = "lvwAttrFormat"
        Me.lvwAttrFormat.Size = New System.Drawing.Size(586, 234)
        Me.lvwAttrFormat.TabIndex = 1
        Me.lvwAttrFormat.UseCompatibleStateImageBehavior = False
        Me.lvwAttrFormat.View = System.Windows.Forms.View.Details
        '
        'chAttrID
        '
        Me.chAttrID.Text = "chAttrID"
        '
        'chAttrFormat
        '
        Me.chAttrFormat.Text = "chAttrFormat"
        '
        'chAttrName
        '
        Me.chAttrName.Text = "chAttrName"
        '
        'tlpButtons
        '
        Me.tlpButtons.AutoSize = True
        Me.tlpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpButtons.ColumnCount = 1
        Me.tlpButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpButtons.Controls.Add(Me.btnAdd, 0, 0)
        Me.tlpButtons.Controls.Add(Me.btnRemove, 0, 1)
        Me.tlpButtons.Dock = System.Windows.Forms.DockStyle.Right
        Me.tlpButtons.Location = New System.Drawing.Point(586, 0)
        Me.tlpButtons.Name = "tlpButtons"
        Me.tlpButtons.RowCount = 2
        Me.tlpButtons.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpButtons.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpButtons.Size = New System.Drawing.Size(84, 234)
        Me.tlpButtons.TabIndex = 7
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(3, 0)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(78, 24)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "btnAdd"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnRemove.Location = New System.Drawing.Point(3, 210)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(78, 24)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "btnRemove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'lblRemapInfo
        '
        Me.lblRemapInfo.AutoSize = True
        Me.lblRemapInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblRemapInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRemapInfo.ForeColor = System.Drawing.Color.DimGray
        Me.lblRemapInfo.Location = New System.Drawing.Point(0, 3)
        Me.lblRemapInfo.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblRemapInfo.Name = "lblRemapInfo"
        Me.lblRemapInfo.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblRemapInfo.Size = New System.Drawing.Size(689, 17)
        Me.lblRemapInfo.TabIndex = 1
        Me.lblRemapInfo.Text = "lblRemapInfo"
        Me.lblRemapInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAttributes
        '
        Me.chkAttributes.AutoSize = True
        Me.chkAttributes.ForeColor = System.Drawing.Color.Black
        Me.chkAttributes.Location = New System.Drawing.Point(3, 26)
        Me.chkAttributes.Name = "chkAttributes"
        Me.chkAttributes.Size = New System.Drawing.Size(90, 17)
        Me.chkAttributes.TabIndex = 0
        Me.chkAttributes.Text = "chkAttributes"
        Me.chkAttributes.UseVisualStyleBackColor = True
        '
        'tpFirmware
        '
        Me.tpFirmware.Controls.Add(Me.tlpFirmwareContent)
        Me.tpFirmware.Location = New System.Drawing.Point(4, 22)
        Me.tpFirmware.Name = "tpFirmware"
        Me.tpFirmware.Size = New System.Drawing.Size(689, 286)
        Me.tpFirmware.TabIndex = 2
        Me.tpFirmware.Text = "tpFirmware"
        Me.tpFirmware.UseVisualStyleBackColor = True
        '
        'tlpFirmwareContent
        '
        Me.tlpFirmwareContent.AutoSize = True
        Me.tlpFirmwareContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpFirmwareContent.ColumnCount = 1
        Me.tlpFirmwareContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFirmwareContent.Controls.Add(Me.flwFirmware, 0, 2)
        Me.tlpFirmwareContent.Controls.Add(Me.lblFirmwareDebugInfo, 0, 0)
        Me.tlpFirmwareContent.Controls.Add(Me.chkFirmware, 0, 1)
        Me.tlpFirmwareContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpFirmwareContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpFirmwareContent.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpFirmwareContent.Name = "tlpFirmwareContent"
        Me.tlpFirmwareContent.RowCount = 3
        Me.tlpFirmwareContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFirmwareContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpFirmwareContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpFirmwareContent.Size = New System.Drawing.Size(689, 216)
        Me.tlpFirmwareContent.TabIndex = 27
        '
        'flwFirmware
        '
        Me.flwFirmware.AutoScroll = True
        Me.flwFirmware.AutoSize = True
        Me.flwFirmware.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flwFirmware.Controls.Add(Me.cboFirmware)
        Me.flwFirmware.Controls.Add(Me.lblFirmwareDebug)
        Me.flwFirmware.Controls.Add(Me.chkFixSwap)
        Me.flwFirmware.Controls.Add(Me.lblFixSwap)
        Me.flwFirmware.Controls.Add(Me.chkNoLogDir)
        Me.flwFirmware.Controls.Add(Me.lblNoLogDir)
        Me.flwFirmware.Controls.Add(Me.chkXErrorLba)
        Me.flwFirmware.Controls.Add(Me.lblXErrorLba)
        Me.flwFirmware.Dock = System.Windows.Forms.DockStyle.Top
        Me.flwFirmware.Location = New System.Drawing.Point(16, 49)
        Me.flwFirmware.Margin = New System.Windows.Forms.Padding(16, 3, 3, 3)
        Me.flwFirmware.Name = "flwFirmware"
        Me.flwFirmware.Size = New System.Drawing.Size(670, 164)
        Me.flwFirmware.TabIndex = 25
        '
        'cboFirmware
        '
        Me.cboFirmware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.flwFirmware.SetFlowBreak(Me.cboFirmware, True)
        Me.cboFirmware.FormattingEnabled = True
        Me.cboFirmware.Location = New System.Drawing.Point(3, 0)
        Me.cboFirmware.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.cboFirmware.Name = "cboFirmware"
        Me.cboFirmware.Size = New System.Drawing.Size(224, 21)
        Me.cboFirmware.TabIndex = 5
        '
        'lblFirmwareDebug
        '
        Me.lblFirmwareDebug.AutoSize = True
        Me.flwFirmware.SetFlowBreak(Me.lblFirmwareDebug, True)
        Me.lblFirmwareDebug.ForeColor = System.Drawing.Color.DimGray
        Me.lblFirmwareDebug.Location = New System.Drawing.Point(20, 24)
        Me.lblFirmwareDebug.Margin = New System.Windows.Forms.Padding(20, 2, 3, 7)
        Me.lblFirmwareDebug.Name = "lblFirmwareDebug"
        Me.lblFirmwareDebug.Size = New System.Drawing.Size(92, 13)
        Me.lblFirmwareDebug.TabIndex = 3
        Me.lblFirmwareDebug.Tag = "Grayed"
        Me.lblFirmwareDebug.Text = "lblFirmwareDebug"
        '
        'chkFixSwap
        '
        Me.chkFixSwap.AutoSize = True
        Me.flwFirmware.SetFlowBreak(Me.chkFixSwap, True)
        Me.chkFixSwap.ForeColor = System.Drawing.Color.Black
        Me.chkFixSwap.Location = New System.Drawing.Point(3, 44)
        Me.chkFixSwap.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkFixSwap.Name = "chkFixSwap"
        Me.chkFixSwap.Size = New System.Drawing.Size(82, 17)
        Me.chkFixSwap.TabIndex = 6
        Me.chkFixSwap.Text = "chkFixSwap"
        Me.chkFixSwap.UseVisualStyleBackColor = True
        '
        'lblFixSwap
        '
        Me.lblFixSwap.AutoSize = True
        Me.flwFirmware.SetFlowBreak(Me.lblFixSwap, True)
        Me.lblFixSwap.ForeColor = System.Drawing.Color.DimGray
        Me.lblFixSwap.Location = New System.Drawing.Point(20, 64)
        Me.lblFixSwap.Margin = New System.Windows.Forms.Padding(20, 0, 3, 7)
        Me.lblFixSwap.Name = "lblFixSwap"
        Me.lblFixSwap.Size = New System.Drawing.Size(57, 13)
        Me.lblFixSwap.TabIndex = 4
        Me.lblFixSwap.Tag = "Grayed"
        Me.lblFixSwap.Text = "lblFixSwap"
        '
        'chkNoLogDir
        '
        Me.chkNoLogDir.AutoSize = True
        Me.flwFirmware.SetFlowBreak(Me.chkNoLogDir, True)
        Me.chkNoLogDir.ForeColor = System.Drawing.Color.Black
        Me.chkNoLogDir.Location = New System.Drawing.Point(3, 84)
        Me.chkNoLogDir.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkNoLogDir.Name = "chkNoLogDir"
        Me.chkNoLogDir.Size = New System.Drawing.Size(85, 17)
        Me.chkNoLogDir.TabIndex = 7
        Me.chkNoLogDir.Text = "chkNoLogDir"
        Me.chkNoLogDir.UseVisualStyleBackColor = True
        '
        'lblNoLogDir
        '
        Me.lblNoLogDir.AutoSize = True
        Me.flwFirmware.SetFlowBreak(Me.lblNoLogDir, True)
        Me.lblNoLogDir.ForeColor = System.Drawing.Color.DimGray
        Me.lblNoLogDir.Location = New System.Drawing.Point(20, 104)
        Me.lblNoLogDir.Margin = New System.Windows.Forms.Padding(20, 0, 3, 7)
        Me.lblNoLogDir.Name = "lblNoLogDir"
        Me.lblNoLogDir.Size = New System.Drawing.Size(60, 13)
        Me.lblNoLogDir.TabIndex = 7
        Me.lblNoLogDir.Tag = "Grayed"
        Me.lblNoLogDir.Text = "lblNoLogDir"
        '
        'chkXErrorLba
        '
        Me.chkXErrorLba.AutoSize = True
        Me.flwFirmware.SetFlowBreak(Me.chkXErrorLba, True)
        Me.chkXErrorLba.ForeColor = System.Drawing.Color.Black
        Me.chkXErrorLba.Location = New System.Drawing.Point(3, 124)
        Me.chkXErrorLba.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.chkXErrorLba.Name = "chkXErrorLba"
        Me.chkXErrorLba.Size = New System.Drawing.Size(89, 17)
        Me.chkXErrorLba.TabIndex = 8
        Me.chkXErrorLba.Text = "chkXErrorLba"
        Me.chkXErrorLba.UseVisualStyleBackColor = True
        '
        'lblXErrorLba
        '
        Me.lblXErrorLba.AutoSize = True
        Me.flwFirmware.SetFlowBreak(Me.lblXErrorLba, True)
        Me.lblXErrorLba.ForeColor = System.Drawing.Color.DimGray
        Me.lblXErrorLba.Location = New System.Drawing.Point(20, 144)
        Me.lblXErrorLba.Margin = New System.Windows.Forms.Padding(20, 0, 3, 7)
        Me.lblXErrorLba.Name = "lblXErrorLba"
        Me.lblXErrorLba.Size = New System.Drawing.Size(64, 13)
        Me.lblXErrorLba.TabIndex = 9
        Me.lblXErrorLba.Tag = "Grayed"
        Me.lblXErrorLba.Text = "lblXErrorLba"
        '
        'lblFirmwareDebugInfo
        '
        Me.lblFirmwareDebugInfo.AutoSize = True
        Me.lblFirmwareDebugInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblFirmwareDebugInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFirmwareDebugInfo.ForeColor = System.Drawing.Color.DimGray
        Me.lblFirmwareDebugInfo.Location = New System.Drawing.Point(0, 3)
        Me.lblFirmwareDebugInfo.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblFirmwareDebugInfo.Name = "lblFirmwareDebugInfo"
        Me.lblFirmwareDebugInfo.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblFirmwareDebugInfo.Size = New System.Drawing.Size(689, 17)
        Me.lblFirmwareDebugInfo.TabIndex = 1
        Me.lblFirmwareDebugInfo.Text = "lblFirmwareDebugInfo"
        Me.lblFirmwareDebugInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkFirmware
        '
        Me.chkFirmware.AutoSize = True
        Me.chkFirmware.ForeColor = System.Drawing.Color.Black
        Me.chkFirmware.Location = New System.Drawing.Point(3, 26)
        Me.chkFirmware.Name = "chkFirmware"
        Me.chkFirmware.Size = New System.Drawing.Size(86, 17)
        Me.chkFirmware.TabIndex = 4
        Me.chkFirmware.Text = "chkFirmware"
        Me.chkFirmware.UseVisualStyleBackColor = True
        '
        'tpAsmedia
        '
        Me.tpAsmedia.Controls.Add(Me.tlpAsmedia)
        Me.tpAsmedia.Location = New System.Drawing.Point(4, 22)
        Me.tpAsmedia.Name = "tpAsmedia"
        Me.tpAsmedia.Size = New System.Drawing.Size(689, 286)
        Me.tpAsmedia.TabIndex = 3
        Me.tpAsmedia.Text = "tpAsmedia"
        Me.tpAsmedia.UseVisualStyleBackColor = True
        '
        'tlpAsmedia
        '
        Me.tlpAsmedia.AutoSize = True
        Me.tlpAsmedia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpAsmedia.ColumnCount = 1
        Me.tlpAsmedia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAsmedia.Controls.Add(Me.lblAsmedia, 0, 0)
        Me.tlpAsmedia.Controls.Add(Me.chkAsmedia, 0, 1)
        Me.tlpAsmedia.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpAsmedia.Location = New System.Drawing.Point(0, 0)
        Me.tlpAsmedia.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpAsmedia.Name = "tlpAsmedia"
        Me.tlpAsmedia.RowCount = 2
        Me.tlpAsmedia.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAsmedia.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAsmedia.Size = New System.Drawing.Size(689, 46)
        Me.tlpAsmedia.TabIndex = 28
        '
        'lblAsmedia
        '
        Me.lblAsmedia.AutoSize = True
        Me.lblAsmedia.BackColor = System.Drawing.Color.Transparent
        Me.lblAsmedia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAsmedia.ForeColor = System.Drawing.Color.DimGray
        Me.lblAsmedia.Location = New System.Drawing.Point(0, 3)
        Me.lblAsmedia.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblAsmedia.Name = "lblAsmedia"
        Me.lblAsmedia.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.lblAsmedia.Size = New System.Drawing.Size(689, 17)
        Me.lblAsmedia.TabIndex = 1
        Me.lblAsmedia.Text = "lblAsmedia"
        Me.lblAsmedia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAsmedia
        '
        Me.chkAsmedia.AutoSize = True
        Me.chkAsmedia.ForeColor = System.Drawing.Color.Black
        Me.chkAsmedia.Location = New System.Drawing.Point(3, 26)
        Me.chkAsmedia.Name = "chkAsmedia"
        Me.chkAsmedia.Size = New System.Drawing.Size(82, 17)
        Me.chkAsmedia.TabIndex = 4
        Me.chkAsmedia.Text = "chkAsmedia"
        Me.chkAsmedia.UseVisualStyleBackColor = True
        '
        'tpVersion
        '
        Me.tpVersion.Controls.Add(Me.lblVersion)
        Me.tpVersion.Location = New System.Drawing.Point(4, 22)
        Me.tpVersion.Name = "tpVersion"
        Me.tpVersion.Padding = New System.Windows.Forms.Padding(3, 7, 3, 3)
        Me.tpVersion.Size = New System.Drawing.Size(703, 355)
        Me.tpVersion.TabIndex = 5
        Me.tpVersion.Text = "tpVersion"
        Me.tpVersion.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblVersion.Location = New System.Drawing.Point(3, 7)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(52, 13)
        Me.lblVersion.TabIndex = 0
        Me.lblVersion.Text = "lblVersion"
        '
        'pnlSideMenu
        '
        Me.pnlSideMenu.AutoScroll = True
        Me.pnlSideMenu.Controls.Add(Me.tlpSideMenu)
        Me.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSideMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlSideMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSideMenu.Name = "pnlSideMenu"
        Me.pnlSideMenu.Size = New System.Drawing.Size(150, 413)
        Me.pnlSideMenu.TabIndex = 32
        '
        'tlpSideMenu
        '
        Me.tlpSideMenu.AutoSize = True
        Me.tlpSideMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSideMenu.BackColor = System.Drawing.Color.White
        Me.tlpSideMenu.ColumnCount = 1
        Me.tlpSideMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSideMenu.Controls.Add(Me.mrrSmartctl, 0, 20)
        Me.tlpSideMenu.Controls.Add(Me.mrrAdvanced, 0, 19)
        Me.tlpSideMenu.Controls.Add(Me.mrrOutput, 0, 18)
        Me.tlpSideMenu.Controls.Add(Me.mrrRunTest, 0, 15)
        Me.tlpSideMenu.Controls.Add(Me.mrrTestsLog, 0, 14)
        Me.tlpSideMenu.Controls.Add(Me.mrrErrorsLog, 0, 13)
        Me.tlpSideMenu.Controls.Add(Me.mrrReadWrite, 0, 10)
        Me.tlpSideMenu.Controls.Add(Me.mrrStandby, 0, 9)
        Me.tlpSideMenu.Controls.Add(Me.mrrApm, 0, 8)
        Me.tlpSideMenu.Controls.Add(Me.mrrAam, 0, 7)
        Me.tlpSideMenu.Controls.Add(Me.mrrTemperatures, 0, 3)
        Me.tlpSideMenu.Controls.Add(Me.mrrEvents, 0, 2)
        Me.tlpSideMenu.Controls.Add(Me.mrrAttributes, 0, 1)
        Me.tlpSideMenu.Controls.Add(Me.lblInfo, 0, 0)
        Me.tlpSideMenu.Controls.Add(Me.lblSetup, 0, 5)
        Me.tlpSideMenu.Controls.Add(Me.lblSmartctl, 0, 17)
        Me.tlpSideMenu.Controls.Add(Me.mrrSmartSetup, 0, 6)
        Me.tlpSideMenu.Controls.Add(Me.lblErrorsTests, 0, 12)
        Me.tlpSideMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpSideMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlpSideMenu.Name = "tlpSideMenu"
        Me.tlpSideMenu.RowCount = 21
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSideMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpSideMenu.Size = New System.Drawing.Size(133, 414)
        Me.tlpSideMenu.TabIndex = 31
        '
        'mrrSmartctl
        '
        Me.mrrSmartctl.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrSmartctl.BackColor = System.Drawing.Color.Transparent
        Me.mrrSmartctl.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrSmartctl.FlatAppearance.BorderSize = 0
        Me.mrrSmartctl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrSmartctl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrSmartctl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrSmartctl.Location = New System.Drawing.Point(0, 392)
        Me.mrrSmartctl.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrSmartctl.Name = "mrrSmartctl"
        Me.mrrSmartctl.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrSmartctl.Size = New System.Drawing.Size(133, 22)
        Me.mrrSmartctl.TabIndex = 2
        Me.mrrSmartctl.TabStop = True
        Me.mrrSmartctl.Text = "mrrSmartctl"
        Me.mrrSmartctl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrSmartctl.UseVisualStyleBackColor = False
        '
        'mrrAdvanced
        '
        Me.mrrAdvanced.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrAdvanced.BackColor = System.Drawing.Color.Transparent
        Me.mrrAdvanced.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrAdvanced.FlatAppearance.BorderSize = 0
        Me.mrrAdvanced.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrAdvanced.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrAdvanced.Location = New System.Drawing.Point(0, 370)
        Me.mrrAdvanced.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrAdvanced.Name = "mrrAdvanced"
        Me.mrrAdvanced.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrAdvanced.Size = New System.Drawing.Size(133, 22)
        Me.mrrAdvanced.TabIndex = 1
        Me.mrrAdvanced.TabStop = True
        Me.mrrAdvanced.Text = "mrrAdvanced"
        Me.mrrAdvanced.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrAdvanced.UseVisualStyleBackColor = False
        '
        'mrrOutput
        '
        Me.mrrOutput.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrOutput.BackColor = System.Drawing.Color.Transparent
        Me.mrrOutput.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrOutput.FlatAppearance.BorderSize = 0
        Me.mrrOutput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrOutput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrOutput.Location = New System.Drawing.Point(0, 348)
        Me.mrrOutput.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrOutput.Name = "mrrOutput"
        Me.mrrOutput.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrOutput.Size = New System.Drawing.Size(133, 22)
        Me.mrrOutput.TabIndex = 0
        Me.mrrOutput.TabStop = True
        Me.mrrOutput.Text = "mrrOutput"
        Me.mrrOutput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrOutput.UseVisualStyleBackColor = False
        '
        'mrrRunTest
        '
        Me.mrrRunTest.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrRunTest.BackColor = System.Drawing.Color.Transparent
        Me.mrrRunTest.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrRunTest.FlatAppearance.BorderSize = 0
        Me.mrrRunTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrRunTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrRunTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrRunTest.Location = New System.Drawing.Point(0, 297)
        Me.mrrRunTest.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrRunTest.Name = "mrrRunTest"
        Me.mrrRunTest.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrRunTest.Size = New System.Drawing.Size(133, 22)
        Me.mrrRunTest.TabIndex = 2
        Me.mrrRunTest.TabStop = True
        Me.mrrRunTest.Text = "mrrRunTest"
        Me.mrrRunTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrRunTest.UseVisualStyleBackColor = False
        '
        'mrrTestsLog
        '
        Me.mrrTestsLog.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrTestsLog.BackColor = System.Drawing.Color.Transparent
        Me.mrrTestsLog.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrTestsLog.FlatAppearance.BorderSize = 0
        Me.mrrTestsLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrTestsLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrTestsLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrTestsLog.Location = New System.Drawing.Point(0, 275)
        Me.mrrTestsLog.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrTestsLog.Name = "mrrTestsLog"
        Me.mrrTestsLog.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrTestsLog.Size = New System.Drawing.Size(133, 22)
        Me.mrrTestsLog.TabIndex = 1
        Me.mrrTestsLog.TabStop = True
        Me.mrrTestsLog.Text = "mrrTestsLog"
        Me.mrrTestsLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrTestsLog.UseVisualStyleBackColor = False
        '
        'mrrErrorsLog
        '
        Me.mrrErrorsLog.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrErrorsLog.BackColor = System.Drawing.Color.Transparent
        Me.mrrErrorsLog.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrErrorsLog.FlatAppearance.BorderSize = 0
        Me.mrrErrorsLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrErrorsLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrErrorsLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrErrorsLog.Location = New System.Drawing.Point(0, 253)
        Me.mrrErrorsLog.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrErrorsLog.Name = "mrrErrorsLog"
        Me.mrrErrorsLog.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrErrorsLog.Size = New System.Drawing.Size(133, 22)
        Me.mrrErrorsLog.TabIndex = 0
        Me.mrrErrorsLog.TabStop = True
        Me.mrrErrorsLog.Text = "mrrErrorsLog"
        Me.mrrErrorsLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrErrorsLog.UseVisualStyleBackColor = False
        '
        'mrrReadWrite
        '
        Me.mrrReadWrite.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrReadWrite.BackColor = System.Drawing.Color.Transparent
        Me.mrrReadWrite.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrReadWrite.FlatAppearance.BorderSize = 0
        Me.mrrReadWrite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrReadWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrReadWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrReadWrite.Location = New System.Drawing.Point(0, 202)
        Me.mrrReadWrite.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrReadWrite.Name = "mrrReadWrite"
        Me.mrrReadWrite.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrReadWrite.Size = New System.Drawing.Size(133, 22)
        Me.mrrReadWrite.TabIndex = 4
        Me.mrrReadWrite.TabStop = True
        Me.mrrReadWrite.Text = "mrrReadWrite"
        Me.mrrReadWrite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrReadWrite.UseVisualStyleBackColor = False
        '
        'mrrStandby
        '
        Me.mrrStandby.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrStandby.BackColor = System.Drawing.Color.Transparent
        Me.mrrStandby.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrStandby.FlatAppearance.BorderSize = 0
        Me.mrrStandby.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrStandby.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrStandby.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrStandby.Location = New System.Drawing.Point(0, 180)
        Me.mrrStandby.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrStandby.Name = "mrrStandby"
        Me.mrrStandby.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrStandby.Size = New System.Drawing.Size(133, 22)
        Me.mrrStandby.TabIndex = 3
        Me.mrrStandby.TabStop = True
        Me.mrrStandby.Text = "mrrStandby"
        Me.mrrStandby.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrStandby.UseVisualStyleBackColor = False
        '
        'mrrApm
        '
        Me.mrrApm.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrApm.BackColor = System.Drawing.Color.Transparent
        Me.mrrApm.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrApm.FlatAppearance.BorderSize = 0
        Me.mrrApm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrApm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrApm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrApm.Location = New System.Drawing.Point(0, 158)
        Me.mrrApm.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrApm.Name = "mrrApm"
        Me.mrrApm.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrApm.Size = New System.Drawing.Size(133, 22)
        Me.mrrApm.TabIndex = 2
        Me.mrrApm.TabStop = True
        Me.mrrApm.Text = "mrrApm"
        Me.mrrApm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrApm.UseVisualStyleBackColor = False
        '
        'mrrAam
        '
        Me.mrrAam.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrAam.BackColor = System.Drawing.Color.Transparent
        Me.mrrAam.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrAam.FlatAppearance.BorderSize = 0
        Me.mrrAam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrAam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrAam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrAam.Location = New System.Drawing.Point(0, 136)
        Me.mrrAam.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrAam.Name = "mrrAam"
        Me.mrrAam.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrAam.Size = New System.Drawing.Size(133, 22)
        Me.mrrAam.TabIndex = 1
        Me.mrrAam.TabStop = True
        Me.mrrAam.Text = "mrrAam"
        Me.mrrAam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrAam.UseVisualStyleBackColor = False
        '
        'mrrTemperatures
        '
        Me.mrrTemperatures.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrTemperatures.BackColor = System.Drawing.Color.Transparent
        Me.mrrTemperatures.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrTemperatures.FlatAppearance.BorderSize = 0
        Me.mrrTemperatures.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrTemperatures.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrTemperatures.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrTemperatures.Location = New System.Drawing.Point(0, 63)
        Me.mrrTemperatures.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrTemperatures.Name = "mrrTemperatures"
        Me.mrrTemperatures.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrTemperatures.Size = New System.Drawing.Size(133, 22)
        Me.mrrTemperatures.TabIndex = 3
        Me.mrrTemperatures.TabStop = True
        Me.mrrTemperatures.Text = "mrrTemperatures"
        Me.mrrTemperatures.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrTemperatures.UseVisualStyleBackColor = False
        '
        'mrrEvents
        '
        Me.mrrEvents.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrEvents.BackColor = System.Drawing.Color.Transparent
        Me.mrrEvents.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrEvents.FlatAppearance.BorderSize = 0
        Me.mrrEvents.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrEvents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrEvents.Location = New System.Drawing.Point(0, 41)
        Me.mrrEvents.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrEvents.Name = "mrrEvents"
        Me.mrrEvents.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrEvents.Size = New System.Drawing.Size(133, 22)
        Me.mrrEvents.TabIndex = 2
        Me.mrrEvents.TabStop = True
        Me.mrrEvents.Text = "mrrEvents"
        Me.mrrEvents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrEvents.UseVisualStyleBackColor = False
        '
        'mrrAttributes
        '
        Me.mrrAttributes.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrAttributes.BackColor = System.Drawing.Color.Transparent
        Me.mrrAttributes.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrAttributes.FlatAppearance.BorderSize = 0
        Me.mrrAttributes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrAttributes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrAttributes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrAttributes.Location = New System.Drawing.Point(0, 19)
        Me.mrrAttributes.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrAttributes.Name = "mrrAttributes"
        Me.mrrAttributes.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrAttributes.Size = New System.Drawing.Size(133, 22)
        Me.mrrAttributes.TabIndex = 0
        Me.mrrAttributes.TabStop = True
        Me.mrrAttributes.Text = "mrrAttributes"
        Me.mrrAttributes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mrrAttributes.UseVisualStyleBackColor = False
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblInfo.Location = New System.Drawing.Point(3, 3)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(37, 13)
        Me.lblInfo.TabIndex = 26
        Me.lblInfo.Text = "lblInfo"
        '
        'lblSetup
        '
        Me.lblSetup.AutoSize = True
        Me.lblSetup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSetup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSetup.Location = New System.Drawing.Point(3, 98)
        Me.lblSetup.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSetup.Name = "lblSetup"
        Me.lblSetup.Size = New System.Drawing.Size(45, 13)
        Me.lblSetup.TabIndex = 27
        Me.lblSetup.Text = "lblSetup"
        '
        'lblSmartctl
        '
        Me.lblSmartctl.AutoSize = True
        Me.lblSmartctl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSmartctl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSmartctl.Location = New System.Drawing.Point(3, 332)
        Me.lblSmartctl.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSmartctl.Name = "lblSmartctl"
        Me.lblSmartctl.Size = New System.Drawing.Size(56, 13)
        Me.lblSmartctl.TabIndex = 29
        Me.lblSmartctl.Text = "lblSmartctl"
        '
        'mrrSmartSetup
        '
        Me.mrrSmartSetup.Appearance = System.Windows.Forms.Appearance.Button
        Me.mrrSmartSetup.BackColor = System.Drawing.Color.Transparent
        Me.mrrSmartSetup.Dock = System.Windows.Forms.DockStyle.Top
        Me.mrrSmartSetup.FlatAppearance.BorderSize = 0
        Me.mrrSmartSetup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrrSmartSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrrSmartSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrrSmartSetup.Location = New System.Drawing.Point(0, 114)
        Me.mrrSmartSetup.Margin = New System.Windows.Forms.Padding(0)
        Me.mrrSmartSetup.Name = "mrrSmartSetup"
        Me.mrrSmartSetup.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.mrrSmartSetup.Size = New System.Drawing.Size(133, 22)
        Me.mrrSmartSetup.TabIndex = 0
        Me.mrrSmartSetup.TabStop = True
        Me.mrrSmartSetup.Text = "mrrSmartSetup"
        Me.mrrSmartSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrrSmartSetup.UseVisualStyleBackColor = False
        '
        'lblErrorsTests
        '
        Me.lblErrorsTests.AutoSize = True
        Me.lblErrorsTests.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorsTests.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblErrorsTests.Location = New System.Drawing.Point(3, 237)
        Me.lblErrorsTests.Margin = New System.Windows.Forms.Padding(3)
        Me.lblErrorsTests.Name = "lblErrorsTests"
        Me.lblErrorsTests.Size = New System.Drawing.Size(72, 13)
        Me.lblErrorsTests.TabIndex = 28
        Me.lblErrorsTests.Text = "lblErrorsTests"
        '
        'rspManage
        '
        Me.rspManage.BackColor = System.Drawing.Color.Transparent
        Me.rspManage.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.rspManage.Dock = System.Windows.Forms.DockStyle.Left
        Me.rspManage.Location = New System.Drawing.Point(153, 3)
        Me.rspManage.Name = "rspManage"
        Me.rspManage.Padding = New System.Windows.Forms.Padding(1)
        Me.rspManage.Size = New System.Drawing.Size(3, 407)
        Me.rspManage.TabIndex = 33
        '
        'RibbonHorizontalSeparator3
        '
        Me.RibbonHorizontalSeparator3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonHorizontalSeparator3.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonHorizontalSeparator3.Location = New System.Drawing.Point(0, 34)
        Me.RibbonHorizontalSeparator3.MaximumSize = New System.Drawing.Size(0, 1)
        Me.RibbonHorizontalSeparator3.MinimumSize = New System.Drawing.Size(80, 1)
        Me.RibbonHorizontalSeparator3.Name = "RibbonHorizontalSeparator3"
        Me.RibbonHorizontalSeparator3.Size = New System.Drawing.Size(884, 1)
        Me.RibbonHorizontalSeparator3.TabIndex = 27
        '
        'tlpManageMenuContent
        '
        Me.tlpManageMenuContent.AutoSize = True
        Me.tlpManageMenuContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpManageMenuContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tlpManageMenuContent.ColumnCount = 2
        Me.tlpManageMenuContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpManageMenuContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpManageMenuContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpManageMenuContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpManageMenuContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpManageMenuContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpManageMenuContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpManageMenuContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpManageMenuContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpManageMenuContent.Controls.Add(Me.picManageHelp, 1, 0)
        Me.tlpManageMenuContent.Controls.Add(Me.tlpSelDevice, 0, 0)
        Me.tlpManageMenuContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpManageMenuContent.Location = New System.Drawing.Point(0, 0)
        Me.tlpManageMenuContent.Name = "tlpManageMenuContent"
        Me.tlpManageMenuContent.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.tlpManageMenuContent.RowCount = 1
        Me.tlpManageMenuContent.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpManageMenuContent.Size = New System.Drawing.Size(884, 34)
        Me.tlpManageMenuContent.TabIndex = 28
        '
        'picManageHelp
        '
        Me.picManageHelp.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.picManageHelp.Cursor = System.Windows.Forms.Cursors.Default
        Me.picManageHelp.Location = New System.Drawing.Point(863, 9)
        Me.picManageHelp.Margin = New System.Windows.Forms.Padding(2)
        Me.picManageHelp.MaximumSize = New System.Drawing.Size(16, 16)
        Me.picManageHelp.MinimumSize = New System.Drawing.Size(16, 16)
        Me.picManageHelp.Name = "picManageHelp"
        Me.picManageHelp.Size = New System.Drawing.Size(16, 16)
        Me.picManageHelp.TabIndex = 19
        Me.picManageHelp.TabStop = False
        '
        'tlpSelDevice
        '
        Me.tlpSelDevice.AutoSize = True
        Me.tlpSelDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSelDevice.BackColor = System.Drawing.Color.Transparent
        Me.tlpSelDevice.ColumnCount = 4
        Me.tlpSelDevice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSelDevice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSelDevice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSelDevice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSelDevice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpSelDevice.Controls.Add(Me.pnlComboBorder, 2, 0)
        Me.tlpSelDevice.Controls.Add(Me.mrbReloadDevice, 3, 0)
        Me.tlpSelDevice.Controls.Add(Me.mrbLeft, 0, 0)
        Me.tlpSelDevice.Controls.Add(Me.mrbRight, 1, 0)
        Me.tlpSelDevice.Location = New System.Drawing.Point(3, 5)
        Me.tlpSelDevice.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpSelDevice.Name = "tlpSelDevice"
        Me.tlpSelDevice.RowCount = 1
        Me.tlpSelDevice.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSelDevice.Size = New System.Drawing.Size(808, 24)
        Me.tlpSelDevice.TabIndex = 26
        '
        'pnlComboBorder
        '
        Me.pnlComboBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pnlComboBorder.Controls.Add(Me.cboDevices)
        Me.pnlComboBorder.Location = New System.Drawing.Point(44, 0)
        Me.pnlComboBorder.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlComboBorder.Name = "pnlComboBorder"
        Me.pnlComboBorder.Padding = New System.Windows.Forms.Padding(1)
        Me.pnlComboBorder.Size = New System.Drawing.Size(664, 24)
        Me.pnlComboBorder.TabIndex = 18
        '
        'cboDevices
        '
        Me.cboDevices.BackColor = System.Drawing.Color.White
        Me.cboDevices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDevices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDevices.FormattingEnabled = True
        Me.cboDevices.Location = New System.Drawing.Point(1, 1)
        Me.cboDevices.Name = "cboDevices"
        Me.cboDevices.Size = New System.Drawing.Size(662, 22)
        Me.cboDevices.TabIndex = 0
        '
        'mrbReloadDevice
        '
        Me.mrbReloadDevice.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mrbReloadDevice.AutoSize = True
        Me.mrbReloadDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbReloadDevice.BackColor = System.Drawing.Color.Transparent
        Me.mrbReloadDevice.DrawText = False
        Me.mrbReloadDevice.FlatAppearance.BorderSize = 0
        Me.mrbReloadDevice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbReloadDevice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbReloadDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbReloadDevice.Icon = Nothing
        Me.mrbReloadDevice.Location = New System.Drawing.Point(708, 1)
        Me.mrbReloadDevice.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbReloadDevice.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbReloadDevice.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbReloadDevice.Name = "mrbReloadDevice"
        Me.mrbReloadDevice.Size = New System.Drawing.Size(100, 22)
        Me.mrbReloadDevice.TabIndex = 21
        Me.mrbReloadDevice.Text = "mrbReloadDevice"
        Me.mrbReloadDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbReloadDevice.UseVisualStyleBackColor = False
        '
        'mrbLeft
        '
        Me.mrbLeft.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mrbLeft.AutoSize = True
        Me.mrbLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbLeft.BackColor = System.Drawing.Color.Transparent
        Me.mrbLeft.DrawText = False
        Me.mrbLeft.FlatAppearance.BorderSize = 0
        Me.mrbLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbLeft.Icon = Nothing
        Me.mrbLeft.Location = New System.Drawing.Point(0, 1)
        Me.mrbLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbLeft.MaximumSize = New System.Drawing.Size(22, 22)
        Me.mrbLeft.MinimumSize = New System.Drawing.Size(22, 22)
        Me.mrbLeft.Name = "mrbLeft"
        Me.mrbLeft.Size = New System.Drawing.Size(22, 22)
        Me.mrbLeft.TabIndex = 19
        Me.mrbLeft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbLeft.UseVisualStyleBackColor = False
        '
        'mrbRight
        '
        Me.mrbRight.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mrbRight.AutoSize = True
        Me.mrbRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbRight.BackColor = System.Drawing.Color.Transparent
        Me.mrbRight.DrawText = False
        Me.mrbRight.FlatAppearance.BorderSize = 0
        Me.mrbRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbRight.Icon = Nothing
        Me.mrbRight.Location = New System.Drawing.Point(22, 1)
        Me.mrbRight.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbRight.MaximumSize = New System.Drawing.Size(22, 22)
        Me.mrbRight.MinimumSize = New System.Drawing.Size(22, 22)
        Me.mrbRight.Name = "mrbRight"
        Me.mrbRight.Size = New System.Drawing.Size(22, 22)
        Me.mrbRight.TabIndex = 20
        Me.mrbRight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbRight.UseVisualStyleBackColor = False
        '
        'tpWmiDevices
        '
        Me.tpWmiDevices.BackColor = System.Drawing.Color.White
        Me.tpWmiDevices.Controls.Add(Me.tlpSystem)
        Me.tpWmiDevices.Controls.Add(Me.RibbonHorizontalSeparator6)
        Me.tpWmiDevices.Controls.Add(Me.tlpWmiMenuItems)
        Me.tpWmiDevices.Location = New System.Drawing.Point(4, 22)
        Me.tpWmiDevices.Name = "tpWmiDevices"
        Me.tpWmiDevices.Size = New System.Drawing.Size(884, 448)
        Me.tpWmiDevices.TabIndex = 2
        Me.tpWmiDevices.Text = "tpWmiDevices"
        '
        'tlpSystem
        '
        Me.tlpSystem.ColumnCount = 3
        Me.tlpSystem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.tlpSystem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSystem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSystem.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpSystem.Controls.Add(Me.tvwComputer, 0, 0)
        Me.tlpSystem.Controls.Add(Me.rspSystem, 1, 0)
        Me.tlpSystem.Controls.Add(Me.htcSystem, 2, 0)
        Me.tlpSystem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSystem.Location = New System.Drawing.Point(0, 35)
        Me.tlpSystem.Name = "tlpSystem"
        Me.tlpSystem.RowCount = 1
        Me.tlpSystem.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSystem.Size = New System.Drawing.Size(884, 413)
        Me.tlpSystem.TabIndex = 29
        '
        'tvwComputer
        '
        Me.tvwComputer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvwComputer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwComputer.FullRowSelect = True
        Me.tvwComputer.HideSelection = False
        Me.tvwComputer.ItemHeight = 20
        Me.tvwComputer.Location = New System.Drawing.Point(0, 0)
        Me.tvwComputer.Margin = New System.Windows.Forms.Padding(0)
        Me.tvwComputer.Name = "tvwComputer"
        Me.tvwComputer.ShowRootLines = False
        Me.tvwComputer.Size = New System.Drawing.Size(250, 413)
        Me.tvwComputer.TabIndex = 28
        '
        'rspSystem
        '
        Me.rspSystem.BackColor = System.Drawing.Color.Transparent
        Me.rspSystem.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.rspSystem.Dock = System.Windows.Forms.DockStyle.Left
        Me.rspSystem.Location = New System.Drawing.Point(253, 3)
        Me.rspSystem.Name = "rspSystem"
        Me.rspSystem.Padding = New System.Windows.Forms.Padding(1)
        Me.rspSystem.Size = New System.Drawing.Size(3, 407)
        Me.rspSystem.TabIndex = 29
        '
        'htcSystem
        '
        Me.htcSystem.Controls.Add(Me.tpHardware)
        Me.htcSystem.Controls.Add(Me.tpDisk)
        Me.htcSystem.Controls.Add(Me.tpPartition)
        Me.htcSystem.Controls.Add(Me.tpLogicalDisk)
        Me.htcSystem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htcSystem.Location = New System.Drawing.Point(259, 0)
        Me.htcSystem.Margin = New System.Windows.Forms.Padding(0)
        Me.htcSystem.Name = "htcSystem"
        Me.htcSystem.SelectedIndex = 0
        Me.htcSystem.Size = New System.Drawing.Size(625, 413)
        Me.htcSystem.TabIndex = 30
        '
        'tpHardware
        '
        Me.tpHardware.AutoScroll = True
        Me.tpHardware.Controls.Add(Me.tlpHardware)
        Me.tpHardware.Location = New System.Drawing.Point(4, 22)
        Me.tpHardware.Name = "tpHardware"
        Me.tpHardware.Size = New System.Drawing.Size(617, 387)
        Me.tpHardware.TabIndex = 0
        Me.tpHardware.Text = "tpHardware"
        Me.tpHardware.UseVisualStyleBackColor = True
        '
        'tlpHardware
        '
        Me.tlpHardware.AutoSize = True
        Me.tlpHardware.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpHardware.ColumnCount = 1
        Me.tlpHardware.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpHardware.Controls.Add(Me.picHardware, 0, 0)
        Me.tlpHardware.Controls.Add(Me.tlpHrwDetails, 0, 1)
        Me.tlpHardware.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpHardware.Location = New System.Drawing.Point(0, 0)
        Me.tlpHardware.Name = "tlpHardware"
        Me.tlpHardware.RowCount = 2
        Me.tlpHardware.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHardware.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHardware.Size = New System.Drawing.Size(617, 316)
        Me.tlpHardware.TabIndex = 5
        '
        'picHardware
        '
        Me.picHardware.BackColor = System.Drawing.Color.Transparent
        Me.picHardware.Location = New System.Drawing.Point(8, 8)
        Me.picHardware.Margin = New System.Windows.Forms.Padding(8)
        Me.picHardware.MinimumSize = New System.Drawing.Size(90, 90)
        Me.picHardware.Name = "picHardware"
        Me.picHardware.Size = New System.Drawing.Size(90, 90)
        Me.picHardware.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picHardware.TabIndex = 0
        Me.picHardware.TabStop = False
        '
        'tlpHrwDetails
        '
        Me.tlpHrwDetails.AutoSize = True
        Me.tlpHrwDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpHrwDetails.ColumnCount = 2
        Me.tlpHrwDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpHrwDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpHrwDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpHrwDetails.Controls.Add(Me.lblHrwBios, 1, 0)
        Me.tlpHrwDetails.Controls.Add(Me.lblHrwMotherboard, 1, 2)
        Me.tlpHrwDetails.Controls.Add(Me.lblHrwProcessor, 1, 4)
        Me.tlpHrwDetails.Controls.Add(Me.lblHrwRam, 1, 6)
        Me.tlpHrwDetails.Controls.Add(Me.picBios, 0, 0)
        Me.tlpHrwDetails.Controls.Add(Me.picMotherboard, 0, 2)
        Me.tlpHrwDetails.Controls.Add(Me.picProcessor, 0, 4)
        Me.tlpHrwDetails.Controls.Add(Me.picRam, 0, 6)
        Me.tlpHrwDetails.Controls.Add(Me.picVideoCard, 0, 9)
        Me.tlpHrwDetails.Controls.Add(Me.lblHrwVideoCard, 1, 9)
        Me.tlpHrwDetails.Controls.Add(Me.lblHrwBiosValue, 1, 1)
        Me.tlpHrwDetails.Controls.Add(Me.lblHrwMotherboardValue, 1, 3)
        Me.tlpHrwDetails.Controls.Add(Me.lblHrwProcessorValue, 1, 5)
        Me.tlpHrwDetails.Controls.Add(Me.lblHrwRamValue, 1, 7)
        Me.tlpHrwDetails.Controls.Add(Me.lblHrwVideoCardValue, 1, 10)
        Me.tlpHrwDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpHrwDetails.Location = New System.Drawing.Point(3, 109)
        Me.tlpHrwDetails.Name = "tlpHrwDetails"
        Me.tlpHrwDetails.RowCount = 11
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpHrwDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpHrwDetails.Size = New System.Drawing.Size(611, 204)
        Me.tlpHrwDetails.TabIndex = 4
        '
        'lblHrwBios
        '
        Me.lblHrwBios.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHrwBios.AutoSize = True
        Me.lblHrwBios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHrwBios.Location = New System.Drawing.Point(25, 4)
        Me.lblHrwBios.Margin = New System.Windows.Forms.Padding(3)
        Me.lblHrwBios.Name = "lblHrwBios"
        Me.lblHrwBios.Size = New System.Drawing.Size(55, 13)
        Me.lblHrwBios.TabIndex = 0
        Me.lblHrwBios.Tag = "Group"
        Me.lblHrwBios.Text = "lblHrwBios"
        Me.lblHrwBios.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHrwMotherboard
        '
        Me.lblHrwMotherboard.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHrwMotherboard.AutoSize = True
        Me.lblHrwMotherboard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHrwMotherboard.Location = New System.Drawing.Point(25, 45)
        Me.lblHrwMotherboard.Margin = New System.Windows.Forms.Padding(3)
        Me.lblHrwMotherboard.Name = "lblHrwMotherboard"
        Me.lblHrwMotherboard.Size = New System.Drawing.Size(98, 13)
        Me.lblHrwMotherboard.TabIndex = 2
        Me.lblHrwMotherboard.Tag = "Group"
        Me.lblHrwMotherboard.Text = "lblHrwMotherboard"
        Me.lblHrwMotherboard.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHrwProcessor
        '
        Me.lblHrwProcessor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHrwProcessor.AutoSize = True
        Me.lblHrwProcessor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHrwProcessor.Location = New System.Drawing.Point(25, 86)
        Me.lblHrwProcessor.Margin = New System.Windows.Forms.Padding(3)
        Me.lblHrwProcessor.Name = "lblHrwProcessor"
        Me.lblHrwProcessor.Size = New System.Drawing.Size(83, 13)
        Me.lblHrwProcessor.TabIndex = 8
        Me.lblHrwProcessor.Tag = "Group"
        Me.lblHrwProcessor.Text = "lblHrwProcessor"
        Me.lblHrwProcessor.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHrwRam
        '
        Me.lblHrwRam.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHrwRam.AutoSize = True
        Me.lblHrwRam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHrwRam.Location = New System.Drawing.Point(25, 127)
        Me.lblHrwRam.Margin = New System.Windows.Forms.Padding(3)
        Me.lblHrwRam.Name = "lblHrwRam"
        Me.lblHrwRam.Size = New System.Drawing.Size(57, 13)
        Me.lblHrwRam.TabIndex = 10
        Me.lblHrwRam.Tag = "Group"
        Me.lblHrwRam.Text = "lblHrwRam"
        Me.lblHrwRam.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'picBios
        '
        Me.picBios.Location = New System.Drawing.Point(3, 3)
        Me.picBios.Name = "picBios"
        Me.picBios.Size = New System.Drawing.Size(16, 16)
        Me.picBios.TabIndex = 16
        Me.picBios.TabStop = False
        '
        'picMotherboard
        '
        Me.picMotherboard.Location = New System.Drawing.Point(3, 44)
        Me.picMotherboard.Name = "picMotherboard"
        Me.picMotherboard.Size = New System.Drawing.Size(16, 16)
        Me.picMotherboard.TabIndex = 17
        Me.picMotherboard.TabStop = False
        '
        'picProcessor
        '
        Me.picProcessor.Location = New System.Drawing.Point(3, 85)
        Me.picProcessor.Name = "picProcessor"
        Me.picProcessor.Size = New System.Drawing.Size(16, 16)
        Me.picProcessor.TabIndex = 18
        Me.picProcessor.TabStop = False
        '
        'picRam
        '
        Me.picRam.Location = New System.Drawing.Point(3, 126)
        Me.picRam.Name = "picRam"
        Me.picRam.Size = New System.Drawing.Size(16, 16)
        Me.picRam.TabIndex = 19
        Me.picRam.TabStop = False
        '
        'picVideoCard
        '
        Me.picVideoCard.Location = New System.Drawing.Point(3, 167)
        Me.picVideoCard.Name = "picVideoCard"
        Me.picVideoCard.Size = New System.Drawing.Size(16, 14)
        Me.picVideoCard.TabIndex = 20
        Me.picVideoCard.TabStop = False
        '
        'lblHrwVideoCard
        '
        Me.lblHrwVideoCard.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHrwVideoCard.AutoSize = True
        Me.lblHrwVideoCard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHrwVideoCard.Location = New System.Drawing.Point(25, 167)
        Me.lblHrwVideoCard.Margin = New System.Windows.Forms.Padding(3)
        Me.lblHrwVideoCard.Name = "lblHrwVideoCard"
        Me.lblHrwVideoCard.Size = New System.Drawing.Size(85, 13)
        Me.lblHrwVideoCard.TabIndex = 11
        Me.lblHrwVideoCard.Tag = "Group"
        Me.lblHrwVideoCard.Text = "lblHrwVideoCard"
        Me.lblHrwVideoCard.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHrwBiosValue
        '
        Me.lblHrwBiosValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHrwBiosValue.AutoSize = True
        Me.lblHrwBiosValue.ForeColor = System.Drawing.Color.Black
        Me.lblHrwBiosValue.Location = New System.Drawing.Point(37, 25)
        Me.lblHrwBiosValue.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.lblHrwBiosValue.Name = "lblHrwBiosValue"
        Me.lblHrwBiosValue.Size = New System.Drawing.Size(81, 13)
        Me.lblHrwBiosValue.TabIndex = 4
        Me.lblHrwBiosValue.Text = "lblHrwBiosValue"
        Me.lblHrwBiosValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblHrwMotherboardValue
        '
        Me.lblHrwMotherboardValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHrwMotherboardValue.AutoSize = True
        Me.lblHrwMotherboardValue.ForeColor = System.Drawing.Color.Black
        Me.lblHrwMotherboardValue.Location = New System.Drawing.Point(37, 66)
        Me.lblHrwMotherboardValue.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.lblHrwMotherboardValue.Name = "lblHrwMotherboardValue"
        Me.lblHrwMotherboardValue.Size = New System.Drawing.Size(124, 13)
        Me.lblHrwMotherboardValue.TabIndex = 5
        Me.lblHrwMotherboardValue.Text = "lblHrwMotherboardValue"
        Me.lblHrwMotherboardValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblHrwProcessorValue
        '
        Me.lblHrwProcessorValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHrwProcessorValue.AutoSize = True
        Me.lblHrwProcessorValue.ForeColor = System.Drawing.Color.Black
        Me.lblHrwProcessorValue.Location = New System.Drawing.Point(37, 107)
        Me.lblHrwProcessorValue.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.lblHrwProcessorValue.Name = "lblHrwProcessorValue"
        Me.lblHrwProcessorValue.Size = New System.Drawing.Size(109, 13)
        Me.lblHrwProcessorValue.TabIndex = 6
        Me.lblHrwProcessorValue.Text = "lblHrwProcessorValue"
        Me.lblHrwProcessorValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblHrwRamValue
        '
        Me.lblHrwRamValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHrwRamValue.AutoSize = True
        Me.lblHrwRamValue.ForeColor = System.Drawing.Color.Black
        Me.lblHrwRamValue.Location = New System.Drawing.Point(37, 148)
        Me.lblHrwRamValue.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.lblHrwRamValue.Name = "lblHrwRamValue"
        Me.lblHrwRamValue.Size = New System.Drawing.Size(83, 13)
        Me.lblHrwRamValue.TabIndex = 7
        Me.lblHrwRamValue.Text = "lblHrwRamValue"
        Me.lblHrwRamValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblHrwVideoCardValue
        '
        Me.lblHrwVideoCardValue.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHrwVideoCardValue.AutoSize = True
        Me.lblHrwVideoCardValue.ForeColor = System.Drawing.Color.Black
        Me.lblHrwVideoCardValue.Location = New System.Drawing.Point(37, 187)
        Me.lblHrwVideoCardValue.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.lblHrwVideoCardValue.Name = "lblHrwVideoCardValue"
        Me.lblHrwVideoCardValue.Size = New System.Drawing.Size(111, 13)
        Me.lblHrwVideoCardValue.TabIndex = 12
        Me.lblHrwVideoCardValue.Text = "lblHrwVideoCardValue"
        Me.lblHrwVideoCardValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tpDisk
        '
        Me.tpDisk.Controls.Add(Me.tlpDisk)
        Me.tpDisk.Location = New System.Drawing.Point(4, 22)
        Me.tpDisk.Name = "tpDisk"
        Me.tpDisk.Size = New System.Drawing.Size(617, 387)
        Me.tpDisk.TabIndex = 1
        Me.tpDisk.Text = "tpDisk"
        Me.tpDisk.UseVisualStyleBackColor = True
        '
        'tlpDisk
        '
        Me.tlpDisk.AutoSize = True
        Me.tlpDisk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDisk.ColumnCount = 1
        Me.tlpDisk.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisk.Controls.Add(Me.picDisk, 0, 0)
        Me.tlpDisk.Controls.Add(Me.tlpDiskDetails, 0, 1)
        Me.tlpDisk.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpDisk.Location = New System.Drawing.Point(0, 0)
        Me.tlpDisk.Name = "tlpDisk"
        Me.tlpDisk.RowCount = 2
        Me.tlpDisk.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisk.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisk.Size = New System.Drawing.Size(617, 158)
        Me.tlpDisk.TabIndex = 23
        '
        'picDisk
        '
        Me.picDisk.BackColor = System.Drawing.Color.Transparent
        Me.picDisk.Location = New System.Drawing.Point(8, 8)
        Me.picDisk.Margin = New System.Windows.Forms.Padding(8)
        Me.picDisk.Name = "picDisk"
        Me.picDisk.Size = New System.Drawing.Size(64, 64)
        Me.picDisk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picDisk.TabIndex = 0
        Me.picDisk.TabStop = False
        '
        'tlpDiskDetails
        '
        Me.tlpDiskDetails.AutoSize = True
        Me.tlpDiskDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDiskDetails.ColumnCount = 2
        Me.tlpDiskDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDiskDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDiskDetails.Controls.Add(Me.lblDiskSN, 0, 0)
        Me.tlpDiskDetails.Controls.Add(Me.lblDiskSizeValue, 1, 3)
        Me.tlpDiskDetails.Controls.Add(Me.lblDiskPartitionsValue, 1, 2)
        Me.tlpDiskDetails.Controls.Add(Me.lblDiskIndexValue, 1, 1)
        Me.tlpDiskDetails.Controls.Add(Me.lblDiskSNValue, 1, 0)
        Me.tlpDiskDetails.Controls.Add(Me.lblDiskSize, 0, 3)
        Me.tlpDiskDetails.Controls.Add(Me.lblDiskPartitions, 0, 2)
        Me.tlpDiskDetails.Controls.Add(Me.lblDiskIndex, 0, 1)
        Me.tlpDiskDetails.Location = New System.Drawing.Point(3, 83)
        Me.tlpDiskDetails.Name = "tlpDiskDetails"
        Me.tlpDiskDetails.RowCount = 4
        Me.tlpDiskDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpDiskDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpDiskDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpDiskDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpDiskDetails.Size = New System.Drawing.Size(200, 72)
        Me.tlpDiskDetails.TabIndex = 2
        '
        'lblDiskSN
        '
        Me.lblDiskSN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDiskSN.AutoSize = True
        Me.lblDiskSN.ForeColor = System.Drawing.Color.DimGray
        Me.lblDiskSN.Location = New System.Drawing.Point(3, 2)
        Me.lblDiskSN.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblDiskSN.Name = "lblDiskSN"
        Me.lblDiskSN.Size = New System.Drawing.Size(49, 13)
        Me.lblDiskSN.TabIndex = 0
        Me.lblDiskSN.Tag = "Grayed"
        Me.lblDiskSN.Text = "lblDiskSN"
        Me.lblDiskSN.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDiskSizeValue
        '
        Me.lblDiskSizeValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDiskSizeValue.AutoSize = True
        Me.lblDiskSizeValue.ForeColor = System.Drawing.Color.Black
        Me.lblDiskSizeValue.Location = New System.Drawing.Point(90, 56)
        Me.lblDiskSizeValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblDiskSizeValue.Name = "lblDiskSizeValue"
        Me.lblDiskSizeValue.Size = New System.Drawing.Size(81, 13)
        Me.lblDiskSizeValue.TabIndex = 7
        Me.lblDiskSizeValue.Text = "lblDiskSizeValue"
        Me.lblDiskSizeValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblDiskPartitionsValue
        '
        Me.lblDiskPartitionsValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDiskPartitionsValue.AutoSize = True
        Me.lblDiskPartitionsValue.ForeColor = System.Drawing.Color.Black
        Me.lblDiskPartitionsValue.Location = New System.Drawing.Point(90, 38)
        Me.lblDiskPartitionsValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblDiskPartitionsValue.Name = "lblDiskPartitionsValue"
        Me.lblDiskPartitionsValue.Size = New System.Drawing.Size(107, 13)
        Me.lblDiskPartitionsValue.TabIndex = 6
        Me.lblDiskPartitionsValue.Text = "lblDiskPartitionsValue"
        Me.lblDiskPartitionsValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblDiskIndexValue
        '
        Me.lblDiskIndexValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDiskIndexValue.AutoSize = True
        Me.lblDiskIndexValue.ForeColor = System.Drawing.Color.Black
        Me.lblDiskIndexValue.Location = New System.Drawing.Point(90, 20)
        Me.lblDiskIndexValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblDiskIndexValue.Name = "lblDiskIndexValue"
        Me.lblDiskIndexValue.Size = New System.Drawing.Size(90, 13)
        Me.lblDiskIndexValue.TabIndex = 5
        Me.lblDiskIndexValue.Text = "lblDiskIndexValue"
        Me.lblDiskIndexValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblDiskSNValue
        '
        Me.lblDiskSNValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDiskSNValue.AutoSize = True
        Me.lblDiskSNValue.ForeColor = System.Drawing.Color.Black
        Me.lblDiskSNValue.Location = New System.Drawing.Point(90, 2)
        Me.lblDiskSNValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblDiskSNValue.Name = "lblDiskSNValue"
        Me.lblDiskSNValue.Size = New System.Drawing.Size(75, 13)
        Me.lblDiskSNValue.TabIndex = 4
        Me.lblDiskSNValue.Text = "lblDiskSNValue"
        Me.lblDiskSNValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblDiskSize
        '
        Me.lblDiskSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDiskSize.AutoSize = True
        Me.lblDiskSize.ForeColor = System.Drawing.Color.DimGray
        Me.lblDiskSize.Location = New System.Drawing.Point(3, 56)
        Me.lblDiskSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblDiskSize.Name = "lblDiskSize"
        Me.lblDiskSize.Size = New System.Drawing.Size(55, 13)
        Me.lblDiskSize.TabIndex = 3
        Me.lblDiskSize.Tag = "Grayed"
        Me.lblDiskSize.Text = "lblDiskSize"
        Me.lblDiskSize.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDiskPartitions
        '
        Me.lblDiskPartitions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDiskPartitions.AutoSize = True
        Me.lblDiskPartitions.ForeColor = System.Drawing.Color.DimGray
        Me.lblDiskPartitions.Location = New System.Drawing.Point(3, 38)
        Me.lblDiskPartitions.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblDiskPartitions.Name = "lblDiskPartitions"
        Me.lblDiskPartitions.Size = New System.Drawing.Size(81, 13)
        Me.lblDiskPartitions.TabIndex = 2
        Me.lblDiskPartitions.Tag = "Grayed"
        Me.lblDiskPartitions.Text = "lblDiskPartitions"
        Me.lblDiskPartitions.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDiskIndex
        '
        Me.lblDiskIndex.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDiskIndex.AutoSize = True
        Me.lblDiskIndex.ForeColor = System.Drawing.Color.DimGray
        Me.lblDiskIndex.Location = New System.Drawing.Point(3, 20)
        Me.lblDiskIndex.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblDiskIndex.Name = "lblDiskIndex"
        Me.lblDiskIndex.Size = New System.Drawing.Size(64, 13)
        Me.lblDiskIndex.TabIndex = 1
        Me.lblDiskIndex.Tag = "Grayed"
        Me.lblDiskIndex.Text = "lblDiskIndex"
        Me.lblDiskIndex.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tpPartition
        '
        Me.tpPartition.Controls.Add(Me.tlpPartition)
        Me.tpPartition.Location = New System.Drawing.Point(4, 22)
        Me.tpPartition.Name = "tpPartition"
        Me.tpPartition.Size = New System.Drawing.Size(617, 387)
        Me.tpPartition.TabIndex = 2
        Me.tpPartition.Text = "tpPartition"
        Me.tpPartition.UseVisualStyleBackColor = True
        '
        'tlpPartition
        '
        Me.tlpPartition.AutoSize = True
        Me.tlpPartition.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPartition.ColumnCount = 1
        Me.tlpPartition.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPartition.Controls.Add(Me.picPartition, 0, 0)
        Me.tlpPartition.Controls.Add(Me.tlpPartitionDetails, 0, 1)
        Me.tlpPartition.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpPartition.Location = New System.Drawing.Point(0, 0)
        Me.tlpPartition.Name = "tlpPartition"
        Me.tlpPartition.RowCount = 2
        Me.tlpPartition.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPartition.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPartition.Size = New System.Drawing.Size(617, 216)
        Me.tlpPartition.TabIndex = 24
        '
        'picPartition
        '
        Me.picPartition.BackColor = System.Drawing.Color.Transparent
        Me.picPartition.Location = New System.Drawing.Point(8, 8)
        Me.picPartition.Margin = New System.Windows.Forms.Padding(8)
        Me.picPartition.Name = "picPartition"
        Me.picPartition.Size = New System.Drawing.Size(64, 64)
        Me.picPartition.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picPartition.TabIndex = 0
        Me.picPartition.TabStop = False
        '
        'tlpPartitionDetails
        '
        Me.tlpPartitionDetails.AutoSize = True
        Me.tlpPartitionDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPartitionDetails.ColumnCount = 2
        Me.tlpPartitionDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPartitionDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPartitionDetails.Controls.Add(Me.lblBootable, 0, 0)
        Me.tlpPartitionDetails.Controls.Add(Me.lblPartitionTypeValue, 1, 3)
        Me.tlpPartitionDetails.Controls.Add(Me.lblPrimaryPartitionValue, 1, 2)
        Me.tlpPartitionDetails.Controls.Add(Me.lblBootPartitionValue, 1, 1)
        Me.tlpPartitionDetails.Controls.Add(Me.lblBootableValue, 1, 0)
        Me.tlpPartitionDetails.Controls.Add(Me.lblPartitionType, 0, 3)
        Me.tlpPartitionDetails.Controls.Add(Me.lblPrimaryPartition, 0, 2)
        Me.tlpPartitionDetails.Controls.Add(Me.lblBootPartition, 0, 1)
        Me.tlpPartitionDetails.Controls.Add(Me.lblBlocks, 0, 4)
        Me.tlpPartitionDetails.Controls.Add(Me.lblBlockSize, 0, 5)
        Me.tlpPartitionDetails.Controls.Add(Me.lblPartitionSize, 0, 6)
        Me.tlpPartitionDetails.Controls.Add(Me.lblBlocksValue, 1, 4)
        Me.tlpPartitionDetails.Controls.Add(Me.lblBlockSizeValue, 1, 5)
        Me.tlpPartitionDetails.Controls.Add(Me.lblPartitionSizeValue, 1, 6)
        Me.tlpPartitionDetails.Location = New System.Drawing.Point(3, 83)
        Me.tlpPartitionDetails.Name = "tlpPartitionDetails"
        Me.tlpPartitionDetails.RowCount = 7
        Me.tlpPartitionDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpPartitionDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpPartitionDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpPartitionDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpPartitionDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpPartitionDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPartitionDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPartitionDetails.Size = New System.Drawing.Size(224, 130)
        Me.tlpPartitionDetails.TabIndex = 2
        '
        'lblBootable
        '
        Me.lblBootable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBootable.AutoSize = True
        Me.lblBootable.ForeColor = System.Drawing.Color.DimGray
        Me.lblBootable.Location = New System.Drawing.Point(3, 2)
        Me.lblBootable.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblBootable.Name = "lblBootable"
        Me.lblBootable.Size = New System.Drawing.Size(59, 13)
        Me.lblBootable.TabIndex = 0
        Me.lblBootable.Tag = "Grayed"
        Me.lblBootable.Text = "lblBootable"
        Me.lblBootable.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPartitionTypeValue
        '
        Me.lblPartitionTypeValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPartitionTypeValue.AutoSize = True
        Me.lblPartitionTypeValue.ForeColor = System.Drawing.Color.Black
        Me.lblPartitionTypeValue.Location = New System.Drawing.Point(102, 56)
        Me.lblPartitionTypeValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblPartitionTypeValue.Name = "lblPartitionTypeValue"
        Me.lblPartitionTypeValue.Size = New System.Drawing.Size(107, 13)
        Me.lblPartitionTypeValue.TabIndex = 7
        Me.lblPartitionTypeValue.Text = "lblPartitionTypeValue"
        Me.lblPartitionTypeValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblPrimaryPartitionValue
        '
        Me.lblPrimaryPartitionValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPrimaryPartitionValue.AutoSize = True
        Me.lblPrimaryPartitionValue.ForeColor = System.Drawing.Color.Black
        Me.lblPrimaryPartitionValue.Location = New System.Drawing.Point(102, 38)
        Me.lblPrimaryPartitionValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblPrimaryPartitionValue.Name = "lblPrimaryPartitionValue"
        Me.lblPrimaryPartitionValue.Size = New System.Drawing.Size(119, 13)
        Me.lblPrimaryPartitionValue.TabIndex = 6
        Me.lblPrimaryPartitionValue.Text = "lblPrimaryPartitionValue"
        Me.lblPrimaryPartitionValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblBootPartitionValue
        '
        Me.lblBootPartitionValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBootPartitionValue.AutoSize = True
        Me.lblBootPartitionValue.ForeColor = System.Drawing.Color.Black
        Me.lblBootPartitionValue.Location = New System.Drawing.Point(102, 20)
        Me.lblBootPartitionValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblBootPartitionValue.Name = "lblBootPartitionValue"
        Me.lblBootPartitionValue.Size = New System.Drawing.Size(105, 13)
        Me.lblBootPartitionValue.TabIndex = 5
        Me.lblBootPartitionValue.Text = "lblBootPartitionValue"
        Me.lblBootPartitionValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblBootableValue
        '
        Me.lblBootableValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBootableValue.AutoSize = True
        Me.lblBootableValue.ForeColor = System.Drawing.Color.Black
        Me.lblBootableValue.Location = New System.Drawing.Point(102, 2)
        Me.lblBootableValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblBootableValue.Name = "lblBootableValue"
        Me.lblBootableValue.Size = New System.Drawing.Size(85, 13)
        Me.lblBootableValue.TabIndex = 4
        Me.lblBootableValue.Text = "lblBootableValue"
        Me.lblBootableValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblPartitionType
        '
        Me.lblPartitionType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPartitionType.AutoSize = True
        Me.lblPartitionType.ForeColor = System.Drawing.Color.DimGray
        Me.lblPartitionType.Location = New System.Drawing.Point(3, 56)
        Me.lblPartitionType.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblPartitionType.Name = "lblPartitionType"
        Me.lblPartitionType.Size = New System.Drawing.Size(81, 13)
        Me.lblPartitionType.TabIndex = 3
        Me.lblPartitionType.Tag = "Grayed"
        Me.lblPartitionType.Text = "lblPartitionType"
        Me.lblPartitionType.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPrimaryPartition
        '
        Me.lblPrimaryPartition.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPrimaryPartition.AutoSize = True
        Me.lblPrimaryPartition.ForeColor = System.Drawing.Color.DimGray
        Me.lblPrimaryPartition.Location = New System.Drawing.Point(3, 38)
        Me.lblPrimaryPartition.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblPrimaryPartition.Name = "lblPrimaryPartition"
        Me.lblPrimaryPartition.Size = New System.Drawing.Size(93, 13)
        Me.lblPrimaryPartition.TabIndex = 2
        Me.lblPrimaryPartition.Tag = "Grayed"
        Me.lblPrimaryPartition.Text = "lblPrimaryPartition"
        Me.lblPrimaryPartition.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBootPartition
        '
        Me.lblBootPartition.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBootPartition.AutoSize = True
        Me.lblBootPartition.ForeColor = System.Drawing.Color.DimGray
        Me.lblBootPartition.Location = New System.Drawing.Point(3, 20)
        Me.lblBootPartition.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblBootPartition.Name = "lblBootPartition"
        Me.lblBootPartition.Size = New System.Drawing.Size(79, 13)
        Me.lblBootPartition.TabIndex = 1
        Me.lblBootPartition.Tag = "Grayed"
        Me.lblBootPartition.Text = "lblBootPartition"
        Me.lblBootPartition.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBlocks
        '
        Me.lblBlocks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBlocks.AutoSize = True
        Me.lblBlocks.ForeColor = System.Drawing.Color.DimGray
        Me.lblBlocks.Location = New System.Drawing.Point(3, 74)
        Me.lblBlocks.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblBlocks.Name = "lblBlocks"
        Me.lblBlocks.Size = New System.Drawing.Size(46, 13)
        Me.lblBlocks.TabIndex = 8
        Me.lblBlocks.Tag = "Grayed"
        Me.lblBlocks.Text = "lblBlocks"
        Me.lblBlocks.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBlockSize
        '
        Me.lblBlockSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBlockSize.AutoSize = True
        Me.lblBlockSize.ForeColor = System.Drawing.Color.DimGray
        Me.lblBlockSize.Location = New System.Drawing.Point(3, 94)
        Me.lblBlockSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblBlockSize.Name = "lblBlockSize"
        Me.lblBlockSize.Size = New System.Drawing.Size(60, 13)
        Me.lblBlockSize.TabIndex = 9
        Me.lblBlockSize.Tag = "Grayed"
        Me.lblBlockSize.Text = "lblBlockSize"
        Me.lblBlockSize.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPartitionSize
        '
        Me.lblPartitionSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPartitionSize.AutoSize = True
        Me.lblPartitionSize.ForeColor = System.Drawing.Color.DimGray
        Me.lblPartitionSize.Location = New System.Drawing.Point(3, 114)
        Me.lblPartitionSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblPartitionSize.Name = "lblPartitionSize"
        Me.lblPartitionSize.Size = New System.Drawing.Size(76, 13)
        Me.lblPartitionSize.TabIndex = 10
        Me.lblPartitionSize.Tag = "Grayed"
        Me.lblPartitionSize.Text = "lblPartitionSize"
        Me.lblPartitionSize.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBlocksValue
        '
        Me.lblBlocksValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBlocksValue.AutoSize = True
        Me.lblBlocksValue.ForeColor = System.Drawing.Color.Black
        Me.lblBlocksValue.Location = New System.Drawing.Point(102, 74)
        Me.lblBlocksValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblBlocksValue.Name = "lblBlocksValue"
        Me.lblBlocksValue.Size = New System.Drawing.Size(72, 13)
        Me.lblBlocksValue.TabIndex = 12
        Me.lblBlocksValue.Text = "lblBlocksValue"
        Me.lblBlocksValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblBlockSizeValue
        '
        Me.lblBlockSizeValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBlockSizeValue.AutoSize = True
        Me.lblBlockSizeValue.ForeColor = System.Drawing.Color.Black
        Me.lblBlockSizeValue.Location = New System.Drawing.Point(102, 94)
        Me.lblBlockSizeValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblBlockSizeValue.Name = "lblBlockSizeValue"
        Me.lblBlockSizeValue.Size = New System.Drawing.Size(86, 13)
        Me.lblBlockSizeValue.TabIndex = 13
        Me.lblBlockSizeValue.Text = "lblBlockSizeValue"
        Me.lblBlockSizeValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblPartitionSizeValue
        '
        Me.lblPartitionSizeValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPartitionSizeValue.AutoSize = True
        Me.lblPartitionSizeValue.ForeColor = System.Drawing.Color.Black
        Me.lblPartitionSizeValue.Location = New System.Drawing.Point(102, 114)
        Me.lblPartitionSizeValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblPartitionSizeValue.Name = "lblPartitionSizeValue"
        Me.lblPartitionSizeValue.Size = New System.Drawing.Size(102, 13)
        Me.lblPartitionSizeValue.TabIndex = 14
        Me.lblPartitionSizeValue.Text = "lblPartitionSizeValue"
        Me.lblPartitionSizeValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'tpLogicalDisk
        '
        Me.tpLogicalDisk.AutoScroll = True
        Me.tpLogicalDisk.Controls.Add(Me.tlpLogical)
        Me.tpLogicalDisk.Location = New System.Drawing.Point(4, 22)
        Me.tpLogicalDisk.Name = "tpLogicalDisk"
        Me.tpLogicalDisk.Size = New System.Drawing.Size(617, 387)
        Me.tpLogicalDisk.TabIndex = 3
        Me.tpLogicalDisk.Text = "tpLogicalDisk"
        Me.tpLogicalDisk.UseVisualStyleBackColor = True
        '
        'tlpLogical
        '
        Me.tlpLogical.AutoSize = True
        Me.tlpLogical.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpLogical.ColumnCount = 1
        Me.tlpLogical.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLogical.Controls.Add(Me.picLogical, 0, 0)
        Me.tlpLogical.Controls.Add(Me.tlpLogicalDetails, 0, 1)
        Me.tlpLogical.Controls.Add(Me.tlpBenchmark, 0, 3)
        Me.tlpLogical.Controls.Add(Me.lblBenchmark, 0, 2)
        Me.tlpLogical.Controls.Add(Me.tlpNoBenchmark, 0, 4)
        Me.tlpLogical.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpLogical.Location = New System.Drawing.Point(0, 0)
        Me.tlpLogical.Name = "tlpLogical"
        Me.tlpLogical.RowCount = 5
        Me.tlpLogical.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLogical.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLogical.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLogical.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLogical.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLogical.Size = New System.Drawing.Size(600, 479)
        Me.tlpLogical.TabIndex = 24
        '
        'picLogical
        '
        Me.picLogical.BackColor = System.Drawing.Color.Transparent
        Me.picLogical.Location = New System.Drawing.Point(8, 8)
        Me.picLogical.Margin = New System.Windows.Forms.Padding(8)
        Me.picLogical.Name = "picLogical"
        Me.picLogical.Size = New System.Drawing.Size(64, 64)
        Me.picLogical.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picLogical.TabIndex = 0
        Me.picLogical.TabStop = False
        '
        'tlpLogicalDetails
        '
        Me.tlpLogicalDetails.AutoSize = True
        Me.tlpLogicalDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpLogicalDetails.ColumnCount = 2
        Me.tlpLogicalDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLogicalDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLogicalDetails.Controls.Add(Me.lblLogicalSN, 0, 0)
        Me.tlpLogicalDetails.Controls.Add(Me.lblLogicalSizeValue, 1, 2)
        Me.tlpLogicalDetails.Controls.Add(Me.lblFileSystemValue, 1, 1)
        Me.tlpLogicalDetails.Controls.Add(Me.lblLogicalSNValue, 1, 0)
        Me.tlpLogicalDetails.Controls.Add(Me.lblLogicalSize, 0, 2)
        Me.tlpLogicalDetails.Controls.Add(Me.lblFileSystem, 0, 1)
        Me.tlpLogicalDetails.Location = New System.Drawing.Point(3, 83)
        Me.tlpLogicalDetails.Name = "tlpLogicalDetails"
        Me.tlpLogicalDetails.RowCount = 3
        Me.tlpLogicalDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpLogicalDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpLogicalDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpLogicalDetails.Size = New System.Drawing.Size(174, 54)
        Me.tlpLogicalDetails.TabIndex = 2
        '
        'lblLogicalSN
        '
        Me.lblLogicalSN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLogicalSN.AutoSize = True
        Me.lblLogicalSN.ForeColor = System.Drawing.Color.DimGray
        Me.lblLogicalSN.Location = New System.Drawing.Point(3, 2)
        Me.lblLogicalSN.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLogicalSN.Name = "lblLogicalSN"
        Me.lblLogicalSN.Size = New System.Drawing.Size(62, 13)
        Me.lblLogicalSN.TabIndex = 0
        Me.lblLogicalSN.Tag = "Grayed"
        Me.lblLogicalSN.Text = "lblLogicalSN"
        Me.lblLogicalSN.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLogicalSizeValue
        '
        Me.lblLogicalSizeValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLogicalSizeValue.AutoSize = True
        Me.lblLogicalSizeValue.ForeColor = System.Drawing.Color.Black
        Me.lblLogicalSizeValue.Location = New System.Drawing.Point(77, 38)
        Me.lblLogicalSizeValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLogicalSizeValue.Name = "lblLogicalSizeValue"
        Me.lblLogicalSizeValue.Size = New System.Drawing.Size(94, 13)
        Me.lblLogicalSizeValue.TabIndex = 6
        Me.lblLogicalSizeValue.Text = "lblLogicalSizeValue"
        Me.lblLogicalSizeValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblFileSystemValue
        '
        Me.lblFileSystemValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFileSystemValue.AutoSize = True
        Me.lblFileSystemValue.ForeColor = System.Drawing.Color.Black
        Me.lblFileSystemValue.Location = New System.Drawing.Point(77, 20)
        Me.lblFileSystemValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblFileSystemValue.Name = "lblFileSystemValue"
        Me.lblFileSystemValue.Size = New System.Drawing.Size(94, 13)
        Me.lblFileSystemValue.TabIndex = 5
        Me.lblFileSystemValue.Text = "lblFileSystemValue"
        Me.lblFileSystemValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblLogicalSNValue
        '
        Me.lblLogicalSNValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLogicalSNValue.AutoSize = True
        Me.lblLogicalSNValue.ForeColor = System.Drawing.Color.Black
        Me.lblLogicalSNValue.Location = New System.Drawing.Point(77, 2)
        Me.lblLogicalSNValue.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLogicalSNValue.Name = "lblLogicalSNValue"
        Me.lblLogicalSNValue.Size = New System.Drawing.Size(88, 13)
        Me.lblLogicalSNValue.TabIndex = 4
        Me.lblLogicalSNValue.Text = "lblLogicalSNValue"
        Me.lblLogicalSNValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblLogicalSize
        '
        Me.lblLogicalSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLogicalSize.AutoSize = True
        Me.lblLogicalSize.ForeColor = System.Drawing.Color.DimGray
        Me.lblLogicalSize.Location = New System.Drawing.Point(3, 38)
        Me.lblLogicalSize.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblLogicalSize.Name = "lblLogicalSize"
        Me.lblLogicalSize.Size = New System.Drawing.Size(68, 13)
        Me.lblLogicalSize.TabIndex = 2
        Me.lblLogicalSize.Tag = "Grayed"
        Me.lblLogicalSize.Text = "lblLogicalSize"
        Me.lblLogicalSize.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFileSystem
        '
        Me.lblFileSystem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFileSystem.AutoSize = True
        Me.lblFileSystem.ForeColor = System.Drawing.Color.DimGray
        Me.lblFileSystem.Location = New System.Drawing.Point(3, 20)
        Me.lblFileSystem.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblFileSystem.Name = "lblFileSystem"
        Me.lblFileSystem.Size = New System.Drawing.Size(68, 13)
        Me.lblFileSystem.TabIndex = 1
        Me.lblFileSystem.Tag = "Grayed"
        Me.lblFileSystem.Text = "lblFileSystem"
        Me.lblFileSystem.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tlpBenchmark
        '
        Me.tlpBenchmark.AutoSize = True
        Me.tlpBenchmark.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpBenchmark.ColumnCount = 3
        Me.tlpBenchmark.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpBenchmark.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpBenchmark.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpBenchmark.Controls.Add(Me.tlpRandom, 2, 3)
        Me.tlpBenchmark.Controls.Add(Me.tlpRandomMulti, 2, 1)
        Me.tlpBenchmark.Controls.Add(Me.lblSequentialMulti, 0, 0)
        Me.tlpBenchmark.Controls.Add(Me.lblRandomMulti, 0, 1)
        Me.tlpBenchmark.Controls.Add(Me.RibbonVerticalSeparator1, 1, 0)
        Me.tlpBenchmark.Controls.Add(Me.RibbonVerticalSeparator2, 1, 1)
        Me.tlpBenchmark.Controls.Add(Me.tlpSequentialMulti, 2, 0)
        Me.tlpBenchmark.Controls.Add(Me.lblSequential, 0, 2)
        Me.tlpBenchmark.Controls.Add(Me.lblRandom, 0, 3)
        Me.tlpBenchmark.Controls.Add(Me.RibbonVerticalSeparator3, 1, 2)
        Me.tlpBenchmark.Controls.Add(Me.RibbonVerticalSeparator4, 1, 3)
        Me.tlpBenchmark.Controls.Add(Me.tlpSequential, 2, 2)
        Me.tlpBenchmark.Controls.Add(Me.lnkRunAll, 2, 4)
        Me.tlpBenchmark.Controls.Add(Me.tlpBenchInfo, 2, 5)
        Me.tlpBenchmark.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpBenchmark.Location = New System.Drawing.Point(3, 166)
        Me.tlpBenchmark.Name = "tlpBenchmark"
        Me.tlpBenchmark.RowCount = 6
        Me.tlpBenchmark.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBenchmark.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBenchmark.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBenchmark.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBenchmark.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBenchmark.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBenchmark.Size = New System.Drawing.Size(594, 282)
        Me.tlpBenchmark.TabIndex = 3
        '
        'tlpRandom
        '
        Me.tlpRandom.AutoSize = True
        Me.tlpRandom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpRandom.ColumnCount = 2
        Me.tlpRandom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpRandom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpRandom.Controls.Add(Me.bbReadR, 0, 0)
        Me.tlpRandom.Controls.Add(Me.bbWriteR, 0, 1)
        Me.tlpRandom.Controls.Add(Me.lblReadR, 1, 0)
        Me.tlpRandom.Controls.Add(Me.lblWriteR, 1, 1)
        Me.tlpRandom.Dock = System.Windows.Forms.DockStyle.Left
        Me.tlpRandom.Location = New System.Drawing.Point(105, 141)
        Me.tlpRandom.Name = "tlpRandom"
        Me.tlpRandom.RowCount = 2
        Me.tlpRandom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpRandom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpRandom.Size = New System.Drawing.Size(317, 40)
        Me.tlpRandom.TabIndex = 14
        '
        'bbReadR
        '
        Me.bbReadR.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bbReadR.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.bbReadR.Barcolor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.bbReadR.Location = New System.Drawing.Point(3, 3)
        Me.bbReadR.MaximumSize = New System.Drawing.Size(255, 13)
        Me.bbReadR.MinimumSize = New System.Drawing.Size(255, 13)
        Me.bbReadR.Name = "bbReadR"
        Me.bbReadR.Padding = New System.Windows.Forms.Padding(1)
        Me.bbReadR.Size = New System.Drawing.Size(255, 13)
        Me.bbReadR.TabIndex = 0
        Me.bbReadR.Value = 254.0R
        '
        'bbWriteR
        '
        Me.bbWriteR.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bbWriteR.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.bbWriteR.Barcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bbWriteR.Location = New System.Drawing.Point(3, 23)
        Me.bbWriteR.MaximumSize = New System.Drawing.Size(255, 13)
        Me.bbWriteR.MinimumSize = New System.Drawing.Size(255, 13)
        Me.bbWriteR.Name = "bbWriteR"
        Me.bbWriteR.Padding = New System.Windows.Forms.Padding(1)
        Me.bbWriteR.Size = New System.Drawing.Size(255, 13)
        Me.bbWriteR.TabIndex = 1
        Me.bbWriteR.Value = 500.0R
        '
        'lblReadR
        '
        Me.lblReadR.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblReadR.AutoSize = True
        Me.lblReadR.Location = New System.Drawing.Point(264, 3)
        Me.lblReadR.Name = "lblReadR"
        Me.lblReadR.Size = New System.Drawing.Size(49, 13)
        Me.lblReadR.TabIndex = 2
        Me.lblReadR.Text = "lblReadR"
        '
        'lblWriteR
        '
        Me.lblWriteR.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWriteR.AutoSize = True
        Me.lblWriteR.Location = New System.Drawing.Point(264, 23)
        Me.lblWriteR.Name = "lblWriteR"
        Me.lblWriteR.Size = New System.Drawing.Size(50, 13)
        Me.lblWriteR.TabIndex = 3
        Me.lblWriteR.Text = "lblWriteR"
        '
        'tlpRandomMulti
        '
        Me.tlpRandomMulti.AutoSize = True
        Me.tlpRandomMulti.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpRandomMulti.ColumnCount = 2
        Me.tlpRandomMulti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpRandomMulti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpRandomMulti.Controls.Add(Me.bbReadRMulti, 0, 0)
        Me.tlpRandomMulti.Controls.Add(Me.bbWriteRMulti, 0, 1)
        Me.tlpRandomMulti.Controls.Add(Me.lblReadRMulti, 1, 0)
        Me.tlpRandomMulti.Controls.Add(Me.lblWriteRMulti, 1, 1)
        Me.tlpRandomMulti.Dock = System.Windows.Forms.DockStyle.Left
        Me.tlpRandomMulti.Location = New System.Drawing.Point(105, 49)
        Me.tlpRandomMulti.Name = "tlpRandomMulti"
        Me.tlpRandomMulti.RowCount = 2
        Me.tlpRandomMulti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpRandomMulti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpRandomMulti.Size = New System.Drawing.Size(339, 40)
        Me.tlpRandomMulti.TabIndex = 10
        '
        'bbReadRMulti
        '
        Me.bbReadRMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bbReadRMulti.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.bbReadRMulti.Barcolor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.bbReadRMulti.Location = New System.Drawing.Point(3, 3)
        Me.bbReadRMulti.MaximumSize = New System.Drawing.Size(255, 13)
        Me.bbReadRMulti.MinimumSize = New System.Drawing.Size(255, 13)
        Me.bbReadRMulti.Name = "bbReadRMulti"
        Me.bbReadRMulti.Padding = New System.Windows.Forms.Padding(1)
        Me.bbReadRMulti.Size = New System.Drawing.Size(255, 13)
        Me.bbReadRMulti.TabIndex = 0
        Me.bbReadRMulti.Value = 254.0R
        '
        'bbWriteRMulti
        '
        Me.bbWriteRMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bbWriteRMulti.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.bbWriteRMulti.Barcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bbWriteRMulti.Location = New System.Drawing.Point(3, 23)
        Me.bbWriteRMulti.MaximumSize = New System.Drawing.Size(255, 13)
        Me.bbWriteRMulti.MinimumSize = New System.Drawing.Size(255, 13)
        Me.bbWriteRMulti.Name = "bbWriteRMulti"
        Me.bbWriteRMulti.Padding = New System.Windows.Forms.Padding(1)
        Me.bbWriteRMulti.Size = New System.Drawing.Size(255, 13)
        Me.bbWriteRMulti.TabIndex = 1
        Me.bbWriteRMulti.Value = 500.0R
        '
        'lblReadRMulti
        '
        Me.lblReadRMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblReadRMulti.AutoSize = True
        Me.lblReadRMulti.Location = New System.Drawing.Point(264, 3)
        Me.lblReadRMulti.Name = "lblReadRMulti"
        Me.lblReadRMulti.Size = New System.Drawing.Size(71, 13)
        Me.lblReadRMulti.TabIndex = 2
        Me.lblReadRMulti.Text = "lblReadRMulti"
        '
        'lblWriteRMulti
        '
        Me.lblWriteRMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWriteRMulti.AutoSize = True
        Me.lblWriteRMulti.Location = New System.Drawing.Point(264, 23)
        Me.lblWriteRMulti.Name = "lblWriteRMulti"
        Me.lblWriteRMulti.Size = New System.Drawing.Size(72, 13)
        Me.lblWriteRMulti.TabIndex = 3
        Me.lblWriteRMulti.Text = "lblWriteRMulti"
        '
        'lblSequentialMulti
        '
        Me.lblSequentialMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSequentialMulti.AutoSize = True
        Me.lblSequentialMulti.Location = New System.Drawing.Point(3, 16)
        Me.lblSequentialMulti.Name = "lblSequentialMulti"
        Me.lblSequentialMulti.Size = New System.Drawing.Size(89, 13)
        Me.lblSequentialMulti.TabIndex = 0
        Me.lblSequentialMulti.Text = "lblSequentialMulti"
        '
        'lblRandomMulti
        '
        Me.lblRandomMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRandomMulti.AutoSize = True
        Me.lblRandomMulti.Location = New System.Drawing.Point(3, 62)
        Me.lblRandomMulti.Name = "lblRandomMulti"
        Me.lblRandomMulti.Size = New System.Drawing.Size(78, 13)
        Me.lblRandomMulti.TabIndex = 1
        Me.lblRandomMulti.Text = "lblRandomMulti"
        '
        'RibbonVerticalSeparator1
        '
        Me.RibbonVerticalSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonVerticalSeparator1.Location = New System.Drawing.Point(98, 3)
        Me.RibbonVerticalSeparator1.MaximumSize = New System.Drawing.Size(1, 80)
        Me.RibbonVerticalSeparator1.Name = "RibbonVerticalSeparator1"
        Me.RibbonVerticalSeparator1.Size = New System.Drawing.Size(1, 40)
        Me.RibbonVerticalSeparator1.TabIndex = 2
        '
        'RibbonVerticalSeparator2
        '
        Me.RibbonVerticalSeparator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator2.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonVerticalSeparator2.Location = New System.Drawing.Point(98, 49)
        Me.RibbonVerticalSeparator2.MaximumSize = New System.Drawing.Size(1, 80)
        Me.RibbonVerticalSeparator2.Name = "RibbonVerticalSeparator2"
        Me.RibbonVerticalSeparator2.Size = New System.Drawing.Size(1, 40)
        Me.RibbonVerticalSeparator2.TabIndex = 3
        '
        'tlpSequentialMulti
        '
        Me.tlpSequentialMulti.AutoSize = True
        Me.tlpSequentialMulti.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSequentialMulti.ColumnCount = 2
        Me.tlpSequentialMulti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSequentialMulti.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSequentialMulti.Controls.Add(Me.bbReadSMulti, 0, 0)
        Me.tlpSequentialMulti.Controls.Add(Me.bbWriteSMulti, 0, 1)
        Me.tlpSequentialMulti.Controls.Add(Me.lblReadSMulti, 1, 0)
        Me.tlpSequentialMulti.Controls.Add(Me.lblWriteSMulti, 1, 1)
        Me.tlpSequentialMulti.Dock = System.Windows.Forms.DockStyle.Left
        Me.tlpSequentialMulti.Location = New System.Drawing.Point(105, 3)
        Me.tlpSequentialMulti.Name = "tlpSequentialMulti"
        Me.tlpSequentialMulti.RowCount = 2
        Me.tlpSequentialMulti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSequentialMulti.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSequentialMulti.Size = New System.Drawing.Size(338, 40)
        Me.tlpSequentialMulti.TabIndex = 4
        '
        'bbReadSMulti
        '
        Me.bbReadSMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bbReadSMulti.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.bbReadSMulti.Barcolor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.bbReadSMulti.Location = New System.Drawing.Point(3, 3)
        Me.bbReadSMulti.MaximumSize = New System.Drawing.Size(255, 13)
        Me.bbReadSMulti.MinimumSize = New System.Drawing.Size(255, 13)
        Me.bbReadSMulti.Name = "bbReadSMulti"
        Me.bbReadSMulti.Padding = New System.Windows.Forms.Padding(1)
        Me.bbReadSMulti.Size = New System.Drawing.Size(255, 13)
        Me.bbReadSMulti.TabIndex = 0
        Me.bbReadSMulti.Value = 254.0R
        '
        'bbWriteSMulti
        '
        Me.bbWriteSMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bbWriteSMulti.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.bbWriteSMulti.Barcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bbWriteSMulti.Location = New System.Drawing.Point(3, 23)
        Me.bbWriteSMulti.MaximumSize = New System.Drawing.Size(255, 13)
        Me.bbWriteSMulti.MinimumSize = New System.Drawing.Size(255, 13)
        Me.bbWriteSMulti.Name = "bbWriteSMulti"
        Me.bbWriteSMulti.Padding = New System.Windows.Forms.Padding(1)
        Me.bbWriteSMulti.Size = New System.Drawing.Size(255, 13)
        Me.bbWriteSMulti.TabIndex = 1
        Me.bbWriteSMulti.Value = 500.0R
        '
        'lblReadSMulti
        '
        Me.lblReadSMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblReadSMulti.AutoSize = True
        Me.lblReadSMulti.Location = New System.Drawing.Point(264, 3)
        Me.lblReadSMulti.Name = "lblReadSMulti"
        Me.lblReadSMulti.Size = New System.Drawing.Size(70, 13)
        Me.lblReadSMulti.TabIndex = 2
        Me.lblReadSMulti.Text = "lblReadSMulti"
        '
        'lblWriteSMulti
        '
        Me.lblWriteSMulti.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWriteSMulti.AutoSize = True
        Me.lblWriteSMulti.Location = New System.Drawing.Point(264, 23)
        Me.lblWriteSMulti.Name = "lblWriteSMulti"
        Me.lblWriteSMulti.Size = New System.Drawing.Size(71, 13)
        Me.lblWriteSMulti.TabIndex = 3
        Me.lblWriteSMulti.Text = "lblWriteSMulti"
        '
        'lblSequential
        '
        Me.lblSequential.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSequential.AutoSize = True
        Me.lblSequential.Location = New System.Drawing.Point(3, 108)
        Me.lblSequential.Name = "lblSequential"
        Me.lblSequential.Size = New System.Drawing.Size(67, 13)
        Me.lblSequential.TabIndex = 6
        Me.lblSequential.Text = "lblSequential"
        '
        'lblRandom
        '
        Me.lblRandom.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRandom.AutoSize = True
        Me.lblRandom.Location = New System.Drawing.Point(3, 154)
        Me.lblRandom.Name = "lblRandom"
        Me.lblRandom.Size = New System.Drawing.Size(56, 13)
        Me.lblRandom.TabIndex = 7
        Me.lblRandom.Text = "lblRandom"
        '
        'RibbonVerticalSeparator3
        '
        Me.RibbonVerticalSeparator3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator3.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonVerticalSeparator3.Location = New System.Drawing.Point(98, 95)
        Me.RibbonVerticalSeparator3.MaximumSize = New System.Drawing.Size(1, 80)
        Me.RibbonVerticalSeparator3.Name = "RibbonVerticalSeparator3"
        Me.RibbonVerticalSeparator3.Size = New System.Drawing.Size(1, 40)
        Me.RibbonVerticalSeparator3.TabIndex = 8
        '
        'RibbonVerticalSeparator4
        '
        Me.RibbonVerticalSeparator4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonVerticalSeparator4.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonVerticalSeparator4.Location = New System.Drawing.Point(98, 141)
        Me.RibbonVerticalSeparator4.MaximumSize = New System.Drawing.Size(1, 80)
        Me.RibbonVerticalSeparator4.Name = "RibbonVerticalSeparator4"
        Me.RibbonVerticalSeparator4.Size = New System.Drawing.Size(1, 40)
        Me.RibbonVerticalSeparator4.TabIndex = 9
        '
        'tlpSequential
        '
        Me.tlpSequential.AutoSize = True
        Me.tlpSequential.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSequential.ColumnCount = 2
        Me.tlpSequential.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSequential.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSequential.Controls.Add(Me.bbReadS, 0, 0)
        Me.tlpSequential.Controls.Add(Me.bbWriteS, 0, 1)
        Me.tlpSequential.Controls.Add(Me.lblReadS, 1, 0)
        Me.tlpSequential.Controls.Add(Me.lblWriteS, 1, 1)
        Me.tlpSequential.Dock = System.Windows.Forms.DockStyle.Left
        Me.tlpSequential.Location = New System.Drawing.Point(105, 95)
        Me.tlpSequential.Name = "tlpSequential"
        Me.tlpSequential.RowCount = 2
        Me.tlpSequential.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSequential.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSequential.Size = New System.Drawing.Size(316, 40)
        Me.tlpSequential.TabIndex = 11
        '
        'bbReadS
        '
        Me.bbReadS.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bbReadS.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.bbReadS.Barcolor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.bbReadS.Location = New System.Drawing.Point(3, 3)
        Me.bbReadS.MaximumSize = New System.Drawing.Size(255, 13)
        Me.bbReadS.MinimumSize = New System.Drawing.Size(255, 13)
        Me.bbReadS.Name = "bbReadS"
        Me.bbReadS.Padding = New System.Windows.Forms.Padding(1)
        Me.bbReadS.Size = New System.Drawing.Size(255, 13)
        Me.bbReadS.TabIndex = 0
        Me.bbReadS.Value = 254.0R
        '
        'bbWriteS
        '
        Me.bbWriteS.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.bbWriteS.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.bbWriteS.Barcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bbWriteS.Location = New System.Drawing.Point(3, 23)
        Me.bbWriteS.MaximumSize = New System.Drawing.Size(255, 13)
        Me.bbWriteS.MinimumSize = New System.Drawing.Size(255, 13)
        Me.bbWriteS.Name = "bbWriteS"
        Me.bbWriteS.Padding = New System.Windows.Forms.Padding(1)
        Me.bbWriteS.Size = New System.Drawing.Size(255, 13)
        Me.bbWriteS.TabIndex = 1
        Me.bbWriteS.Value = 500.0R
        '
        'lblReadS
        '
        Me.lblReadS.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblReadS.AutoSize = True
        Me.lblReadS.Location = New System.Drawing.Point(264, 3)
        Me.lblReadS.Name = "lblReadS"
        Me.lblReadS.Size = New System.Drawing.Size(48, 13)
        Me.lblReadS.TabIndex = 2
        Me.lblReadS.Text = "lblReadS"
        '
        'lblWriteS
        '
        Me.lblWriteS.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWriteS.AutoSize = True
        Me.lblWriteS.Location = New System.Drawing.Point(264, 23)
        Me.lblWriteS.Name = "lblWriteS"
        Me.lblWriteS.Size = New System.Drawing.Size(49, 13)
        Me.lblWriteS.TabIndex = 3
        Me.lblWriteS.Text = "lblWriteS"
        '
        'lnkRunAll
        '
        Me.lnkRunAll.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkRunAll.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lnkRunAll.AutoSize = True
        Me.lnkRunAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkRunAll.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lnkRunAll.Location = New System.Drawing.Point(105, 187)
        Me.lnkRunAll.Margin = New System.Windows.Forms.Padding(3)
        Me.lnkRunAll.Name = "lnkRunAll"
        Me.lnkRunAll.Size = New System.Drawing.Size(50, 13)
        Me.lnkRunAll.TabIndex = 16
        Me.lnkRunAll.TabStop = True
        Me.lnkRunAll.Text = "lnkRunAll"
        '
        'tlpBenchInfo
        '
        Me.tlpBenchInfo.AutoSize = True
        Me.tlpBenchInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpBenchInfo.ColumnCount = 2
        Me.tlpBenchInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpBenchInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpBenchInfo.Controls.Add(Me.picBenchInfo, 0, 0)
        Me.tlpBenchInfo.Controls.Add(Me.lblBenching, 1, 0)
        Me.tlpBenchInfo.Controls.Add(Me.prbBench, 1, 1)
        Me.tlpBenchInfo.Controls.Add(Me.lblBenchProgress, 1, 2)
        Me.tlpBenchInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpBenchInfo.Location = New System.Drawing.Point(105, 206)
        Me.tlpBenchInfo.Name = "tlpBenchInfo"
        Me.tlpBenchInfo.RowCount = 3
        Me.tlpBenchInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBenchInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBenchInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBenchInfo.Size = New System.Drawing.Size(486, 73)
        Me.tlpBenchInfo.TabIndex = 17
        '
        'picBenchInfo
        '
        Me.picBenchInfo.Location = New System.Drawing.Point(3, 3)
        Me.picBenchInfo.Name = "picBenchInfo"
        Me.picBenchInfo.Size = New System.Drawing.Size(16, 16)
        Me.picBenchInfo.TabIndex = 0
        Me.picBenchInfo.TabStop = False
        '
        'lblBenching
        '
        Me.lblBenching.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBenching.AutoSize = True
        Me.lblBenching.Location = New System.Drawing.Point(25, 4)
        Me.lblBenching.Name = "lblBenching"
        Me.lblBenching.Size = New System.Drawing.Size(60, 13)
        Me.lblBenching.TabIndex = 1
        Me.lblBenching.Text = "lblBenching"
        '
        'prbBench
        '
        Me.prbBench.Dock = System.Windows.Forms.DockStyle.Top
        Me.prbBench.Location = New System.Drawing.Point(25, 25)
        Me.prbBench.Maximum = 9
        Me.prbBench.Name = "prbBench"
        Me.prbBench.Size = New System.Drawing.Size(458, 23)
        Me.prbBench.Step = 1
        Me.prbBench.TabIndex = 2
        '
        'lblBenchProgress
        '
        Me.lblBenchProgress.AutoSize = True
        Me.lblBenchProgress.Location = New System.Drawing.Point(25, 54)
        Me.lblBenchProgress.Margin = New System.Windows.Forms.Padding(3)
        Me.lblBenchProgress.MinimumSize = New System.Drawing.Size(0, 16)
        Me.lblBenchProgress.Name = "lblBenchProgress"
        Me.lblBenchProgress.Size = New System.Drawing.Size(88, 16)
        Me.lblBenchProgress.TabIndex = 3
        Me.lblBenchProgress.Text = "lblBenchProgress"
        Me.lblBenchProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBenchmark
        '
        Me.lblBenchmark.AutoSize = True
        Me.lblBenchmark.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblBenchmark.Location = New System.Drawing.Point(6, 150)
        Me.lblBenchmark.Margin = New System.Windows.Forms.Padding(6, 10, 3, 0)
        Me.lblBenchmark.Name = "lblBenchmark"
        Me.lblBenchmark.Size = New System.Drawing.Size(69, 13)
        Me.lblBenchmark.TabIndex = 4
        Me.lblBenchmark.Text = "lblBenchmark"
        '
        'tlpNoBenchmark
        '
        Me.tlpNoBenchmark.AutoSize = True
        Me.tlpNoBenchmark.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpNoBenchmark.ColumnCount = 2
        Me.tlpNoBenchmark.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNoBenchmark.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpNoBenchmark.Controls.Add(Me.picNoBench, 0, 0)
        Me.tlpNoBenchmark.Controls.Add(Me.lblNoBench, 1, 0)
        Me.tlpNoBenchmark.Location = New System.Drawing.Point(6, 454)
        Me.tlpNoBenchmark.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.tlpNoBenchmark.Name = "tlpNoBenchmark"
        Me.tlpNoBenchmark.RowCount = 1
        Me.tlpNoBenchmark.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpNoBenchmark.Size = New System.Drawing.Size(87, 22)
        Me.tlpNoBenchmark.TabIndex = 5
        '
        'picNoBench
        '
        Me.picNoBench.Location = New System.Drawing.Point(3, 3)
        Me.picNoBench.Name = "picNoBench"
        Me.picNoBench.Size = New System.Drawing.Size(16, 16)
        Me.picNoBench.TabIndex = 0
        Me.picNoBench.TabStop = False
        '
        'lblNoBench
        '
        Me.lblNoBench.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblNoBench.AutoSize = True
        Me.lblNoBench.Location = New System.Drawing.Point(25, 4)
        Me.lblNoBench.Name = "lblNoBench"
        Me.lblNoBench.Size = New System.Drawing.Size(59, 13)
        Me.lblNoBench.TabIndex = 1
        Me.lblNoBench.Text = "lblNoBench"
        '
        'RibbonHorizontalSeparator6
        '
        Me.RibbonHorizontalSeparator6.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonHorizontalSeparator6.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonHorizontalSeparator6.Location = New System.Drawing.Point(0, 34)
        Me.RibbonHorizontalSeparator6.MaximumSize = New System.Drawing.Size(0, 1)
        Me.RibbonHorizontalSeparator6.MinimumSize = New System.Drawing.Size(80, 1)
        Me.RibbonHorizontalSeparator6.Name = "RibbonHorizontalSeparator6"
        Me.RibbonHorizontalSeparator6.Size = New System.Drawing.Size(884, 1)
        Me.RibbonHorizontalSeparator6.TabIndex = 26
        '
        'tlpWmiMenuItems
        '
        Me.tlpWmiMenuItems.AutoSize = True
        Me.tlpWmiMenuItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpWmiMenuItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tlpWmiMenuItems.ColumnCount = 3
        Me.tlpWmiMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpWmiMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpWmiMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpWmiMenuItems.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpWmiMenuItems.Controls.Add(Me.picWmiDevicesHelp, 2, 0)
        Me.tlpWmiMenuItems.Controls.Add(Me.tlpLoadWmi, 1, 0)
        Me.tlpWmiMenuItems.Controls.Add(Me.mrbRefresh, 0, 0)
        Me.tlpWmiMenuItems.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpWmiMenuItems.Location = New System.Drawing.Point(0, 0)
        Me.tlpWmiMenuItems.Name = "tlpWmiMenuItems"
        Me.tlpWmiMenuItems.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.tlpWmiMenuItems.RowCount = 1
        Me.tlpWmiMenuItems.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpWmiMenuItems.Size = New System.Drawing.Size(884, 34)
        Me.tlpWmiMenuItems.TabIndex = 25
        '
        'picWmiDevicesHelp
        '
        Me.picWmiDevicesHelp.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.picWmiDevicesHelp.Location = New System.Drawing.Point(863, 9)
        Me.picWmiDevicesHelp.Margin = New System.Windows.Forms.Padding(2)
        Me.picWmiDevicesHelp.Name = "picWmiDevicesHelp"
        Me.picWmiDevicesHelp.Size = New System.Drawing.Size(16, 16)
        Me.picWmiDevicesHelp.TabIndex = 5
        Me.picWmiDevicesHelp.TabStop = False
        '
        'tlpLoadWmi
        '
        Me.tlpLoadWmi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tlpLoadWmi.AutoSize = True
        Me.tlpLoadWmi.ColumnCount = 2
        Me.tlpLoadWmi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLoadWmi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLoadWmi.Controls.Add(Me.lblLoadWmi, 1, 0)
        Me.tlpLoadWmi.Controls.Add(Me.picLoadWmi, 0, 0)
        Me.tlpLoadWmi.Location = New System.Drawing.Point(428, 6)
        Me.tlpLoadWmi.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpLoadWmi.Name = "tlpLoadWmi"
        Me.tlpLoadWmi.RowCount = 1
        Me.tlpLoadWmi.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpLoadWmi.Size = New System.Drawing.Size(88, 22)
        Me.tlpLoadWmi.TabIndex = 6
        '
        'lblLoadWmi
        '
        Me.lblLoadWmi.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLoadWmi.AutoSize = True
        Me.lblLoadWmi.ForeColor = System.Drawing.Color.Black
        Me.lblLoadWmi.Location = New System.Drawing.Point(25, 4)
        Me.lblLoadWmi.Name = "lblLoadWmi"
        Me.lblLoadWmi.Size = New System.Drawing.Size(60, 13)
        Me.lblLoadWmi.TabIndex = 0
        Me.lblLoadWmi.Text = "lblLoadWmi"
        '
        'picLoadWmi
        '
        Me.picLoadWmi.Image = Global.hdd_guardian.My.Resources.Resources.loader2
        Me.picLoadWmi.Location = New System.Drawing.Point(3, 3)
        Me.picLoadWmi.MaximumSize = New System.Drawing.Size(16, 16)
        Me.picLoadWmi.Name = "picLoadWmi"
        Me.picLoadWmi.Size = New System.Drawing.Size(16, 16)
        Me.picLoadWmi.TabIndex = 1
        Me.picLoadWmi.TabStop = False
        '
        'mrbRefresh
        '
        Me.mrbRefresh.AutoSize = True
        Me.mrbRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbRefresh.BackColor = System.Drawing.Color.Transparent
        Me.mrbRefresh.FlatAppearance.BorderSize = 0
        Me.mrbRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbRefresh.Icon = Nothing
        Me.mrbRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrbRefresh.Location = New System.Drawing.Point(3, 6)
        Me.mrbRefresh.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbRefresh.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbRefresh.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbRefresh.Name = "mrbRefresh"
        Me.mrbRefresh.Size = New System.Drawing.Size(80, 22)
        Me.mrbRefresh.TabIndex = 7
        Me.mrbRefresh.Text = "mrbRefresh"
        Me.mrbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbRefresh.UseVisualStyleBackColor = False
        '
        'tpDebug
        '
        Me.tpDebug.BackColor = System.Drawing.Color.White
        Me.tpDebug.Controls.Add(Me.tlpDebug)
        Me.tpDebug.Location = New System.Drawing.Point(4, 22)
        Me.tpDebug.Name = "tpDebug"
        Me.tpDebug.Size = New System.Drawing.Size(884, 448)
        Me.tpDebug.TabIndex = 3
        Me.tpDebug.Text = "tpDebug"
        '
        'tlpDebug
        '
        Me.tlpDebug.ColumnCount = 1
        Me.tlpDebug.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDebug.Controls.Add(Me.lvwProgLog, 0, 2)
        Me.tlpDebug.Controls.Add(Me.tlpDebugMenu, 0, 0)
        Me.tlpDebug.Controls.Add(Me.RibbonHorizontalSeparator5, 0, 1)
        Me.tlpDebug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDebug.Location = New System.Drawing.Point(0, 0)
        Me.tlpDebug.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpDebug.Name = "tlpDebug"
        Me.tlpDebug.RowCount = 3
        Me.tlpDebug.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDebug.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDebug.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDebug.Size = New System.Drawing.Size(884, 448)
        Me.tlpDebug.TabIndex = 2
        '
        'lvwProgLog
        '
        Me.lvwProgLog.BackColor = System.Drawing.Color.White
        Me.lvwProgLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvwProgLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chLogDate, Me.chEvent})
        Me.lvwProgLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwProgLog.ForeColor = System.Drawing.Color.Black
        Me.lvwProgLog.FullRowSelect = True
        Me.lvwProgLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwProgLog.Location = New System.Drawing.Point(0, 35)
        Me.lvwProgLog.Margin = New System.Windows.Forms.Padding(0)
        Me.lvwProgLog.MultiSelect = False
        Me.lvwProgLog.Name = "lvwProgLog"
        Me.lvwProgLog.Size = New System.Drawing.Size(884, 413)
        Me.lvwProgLog.TabIndex = 1
        Me.lvwProgLog.UseCompatibleStateImageBehavior = False
        Me.lvwProgLog.View = System.Windows.Forms.View.Details
        '
        'chLogDate
        '
        Me.chLogDate.Text = "chLogDate"
        Me.chLogDate.Width = 150
        '
        'chEvent
        '
        Me.chEvent.Text = "chEvent"
        Me.chEvent.Width = 600
        '
        'tlpDebugMenu
        '
        Me.tlpDebugMenu.AutoSize = True
        Me.tlpDebugMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDebugMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tlpDebugMenu.ColumnCount = 2
        Me.tlpDebugMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDebugMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDebugMenu.Controls.Add(Me.mrbDebugSave, 0, 0)
        Me.tlpDebugMenu.Controls.Add(Me.mrbDebugClean, 1, 0)
        Me.tlpDebugMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpDebugMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlpDebugMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpDebugMenu.Name = "tlpDebugMenu"
        Me.tlpDebugMenu.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.tlpDebugMenu.RowCount = 1
        Me.tlpDebugMenu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDebugMenu.Size = New System.Drawing.Size(884, 34)
        Me.tlpDebugMenu.TabIndex = 26
        '
        'mrbDebugSave
        '
        Me.mrbDebugSave.AutoSize = True
        Me.mrbDebugSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbDebugSave.BackColor = System.Drawing.Color.Transparent
        Me.mrbDebugSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mrbDebugSave.FlatAppearance.BorderSize = 0
        Me.mrbDebugSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbDebugSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbDebugSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbDebugSave.Icon = Nothing
        Me.mrbDebugSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrbDebugSave.Location = New System.Drawing.Point(3, 6)
        Me.mrbDebugSave.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbDebugSave.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbDebugSave.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbDebugSave.Name = "mrbDebugSave"
        Me.mrbDebugSave.Size = New System.Drawing.Size(90, 22)
        Me.mrbDebugSave.TabIndex = 2
        Me.mrbDebugSave.Text = "mrbDebugSave"
        Me.mrbDebugSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbDebugSave.UseVisualStyleBackColor = False
        '
        'mrbDebugClean
        '
        Me.mrbDebugClean.AutoSize = True
        Me.mrbDebugClean.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbDebugClean.BackColor = System.Drawing.Color.Transparent
        Me.mrbDebugClean.FlatAppearance.BorderSize = 0
        Me.mrbDebugClean.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbDebugClean.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbDebugClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbDebugClean.Icon = Nothing
        Me.mrbDebugClean.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrbDebugClean.Location = New System.Drawing.Point(93, 6)
        Me.mrbDebugClean.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbDebugClean.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbDebugClean.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbDebugClean.Name = "mrbDebugClean"
        Me.mrbDebugClean.Size = New System.Drawing.Size(93, 22)
        Me.mrbDebugClean.TabIndex = 3
        Me.mrbDebugClean.Text = "mrbDebugClean"
        Me.mrbDebugClean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbDebugClean.UseVisualStyleBackColor = False
        '
        'RibbonHorizontalSeparator5
        '
        Me.RibbonHorizontalSeparator5.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonHorizontalSeparator5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonHorizontalSeparator5.Location = New System.Drawing.Point(0, 34)
        Me.RibbonHorizontalSeparator5.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonHorizontalSeparator5.MaximumSize = New System.Drawing.Size(0, 1)
        Me.RibbonHorizontalSeparator5.MinimumSize = New System.Drawing.Size(80, 1)
        Me.RibbonHorizontalSeparator5.Name = "RibbonHorizontalSeparator5"
        Me.RibbonHorizontalSeparator5.Size = New System.Drawing.Size(884, 1)
        Me.RibbonHorizontalSeparator5.TabIndex = 27
        '
        'tpPlanner
        '
        Me.tpPlanner.BackColor = System.Drawing.Color.White
        Me.tpPlanner.Controls.Add(Me.lvwTasks)
        Me.tpPlanner.Controls.Add(Me.RibbonHorizontalSeparator1)
        Me.tpPlanner.Controls.Add(Me.tlpTask)
        Me.tpPlanner.Location = New System.Drawing.Point(4, 22)
        Me.tpPlanner.Name = "tpPlanner"
        Me.tpPlanner.Size = New System.Drawing.Size(884, 448)
        Me.tpPlanner.TabIndex = 4
        Me.tpPlanner.Text = "tpPlanner"
        '
        'lvwTasks
        '
        Me.lvwTasks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvwTasks.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDevice, Me.chTest, Me.chTask})
        Me.lvwTasks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwTasks.FullRowSelect = True
        Me.lvwTasks.Location = New System.Drawing.Point(0, 35)
        Me.lvwTasks.Name = "lvwTasks"
        Me.lvwTasks.Size = New System.Drawing.Size(884, 413)
        Me.lvwTasks.TabIndex = 28
        Me.lvwTasks.UseCompatibleStateImageBehavior = False
        Me.lvwTasks.View = System.Windows.Forms.View.Details
        '
        'chDevice
        '
        Me.chDevice.Text = "chDevice"
        '
        'chTest
        '
        Me.chTest.Text = "chTest"
        '
        'chTask
        '
        Me.chTask.Text = "chTask"
        '
        'RibbonHorizontalSeparator1
        '
        Me.RibbonHorizontalSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RibbonHorizontalSeparator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonHorizontalSeparator1.Location = New System.Drawing.Point(0, 34)
        Me.RibbonHorizontalSeparator1.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonHorizontalSeparator1.MaximumSize = New System.Drawing.Size(0, 1)
        Me.RibbonHorizontalSeparator1.MinimumSize = New System.Drawing.Size(80, 1)
        Me.RibbonHorizontalSeparator1.Name = "RibbonHorizontalSeparator1"
        Me.RibbonHorizontalSeparator1.Size = New System.Drawing.Size(884, 1)
        Me.RibbonHorizontalSeparator1.TabIndex = 29
        '
        'tlpTask
        '
        Me.tlpTask.AutoSize = True
        Me.tlpTask.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTask.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.tlpTask.ColumnCount = 5
        Me.tlpTask.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTask.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTask.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTask.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTask.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTask.Controls.Add(Me.mrbTaskNew, 0, 0)
        Me.tlpTask.Controls.Add(Me.mrbTaskEdit, 1, 0)
        Me.tlpTask.Controls.Add(Me.mrbTaskDelete, 2, 0)
        Me.tlpTask.Controls.Add(Me.mrbTaskTrash, 3, 0)
        Me.tlpTask.Controls.Add(Me.picPlannerHelp, 4, 0)
        Me.tlpTask.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpTask.Location = New System.Drawing.Point(0, 0)
        Me.tlpTask.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpTask.Name = "tlpTask"
        Me.tlpTask.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.tlpTask.RowCount = 1
        Me.tlpTask.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpTask.Size = New System.Drawing.Size(884, 34)
        Me.tlpTask.TabIndex = 27
        '
        'mrbTaskNew
        '
        Me.mrbTaskNew.AutoSize = True
        Me.mrbTaskNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbTaskNew.BackColor = System.Drawing.Color.Transparent
        Me.mrbTaskNew.FlatAppearance.BorderSize = 0
        Me.mrbTaskNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbTaskNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbTaskNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbTaskNew.Icon = Nothing
        Me.mrbTaskNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrbTaskNew.Location = New System.Drawing.Point(3, 6)
        Me.mrbTaskNew.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbTaskNew.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbTaskNew.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbTaskNew.Name = "mrbTaskNew"
        Me.mrbTaskNew.Size = New System.Drawing.Size(80, 22)
        Me.mrbTaskNew.TabIndex = 2
        Me.mrbTaskNew.Text = "mrbTaskNew"
        Me.mrbTaskNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbTaskNew.UseVisualStyleBackColor = False
        '
        'mrbTaskEdit
        '
        Me.mrbTaskEdit.AutoSize = True
        Me.mrbTaskEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbTaskEdit.BackColor = System.Drawing.Color.Transparent
        Me.mrbTaskEdit.FlatAppearance.BorderSize = 0
        Me.mrbTaskEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbTaskEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbTaskEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbTaskEdit.Icon = Nothing
        Me.mrbTaskEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrbTaskEdit.Location = New System.Drawing.Point(83, 6)
        Me.mrbTaskEdit.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbTaskEdit.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbTaskEdit.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbTaskEdit.Name = "mrbTaskEdit"
        Me.mrbTaskEdit.Size = New System.Drawing.Size(80, 22)
        Me.mrbTaskEdit.TabIndex = 3
        Me.mrbTaskEdit.Text = "mrbTaskEdit"
        Me.mrbTaskEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbTaskEdit.UseVisualStyleBackColor = False
        '
        'mrbTaskDelete
        '
        Me.mrbTaskDelete.AutoSize = True
        Me.mrbTaskDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbTaskDelete.BackColor = System.Drawing.Color.Transparent
        Me.mrbTaskDelete.FlatAppearance.BorderSize = 0
        Me.mrbTaskDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbTaskDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbTaskDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbTaskDelete.Icon = Nothing
        Me.mrbTaskDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrbTaskDelete.Location = New System.Drawing.Point(163, 6)
        Me.mrbTaskDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbTaskDelete.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbTaskDelete.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbTaskDelete.Name = "mrbTaskDelete"
        Me.mrbTaskDelete.Size = New System.Drawing.Size(88, 22)
        Me.mrbTaskDelete.TabIndex = 4
        Me.mrbTaskDelete.Text = "mrbTaskDelete"
        Me.mrbTaskDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbTaskDelete.UseVisualStyleBackColor = False
        '
        'mrbTaskTrash
        '
        Me.mrbTaskTrash.AutoSize = True
        Me.mrbTaskTrash.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mrbTaskTrash.BackColor = System.Drawing.Color.Transparent
        Me.mrbTaskTrash.FlatAppearance.BorderSize = 0
        Me.mrbTaskTrash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mrbTaskTrash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mrbTaskTrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mrbTaskTrash.Icon = Nothing
        Me.mrbTaskTrash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mrbTaskTrash.Location = New System.Drawing.Point(251, 6)
        Me.mrbTaskTrash.Margin = New System.Windows.Forms.Padding(0)
        Me.mrbTaskTrash.MaximumSize = New System.Drawing.Size(0, 22)
        Me.mrbTaskTrash.MinimumSize = New System.Drawing.Size(80, 22)
        Me.mrbTaskTrash.Name = "mrbTaskTrash"
        Me.mrbTaskTrash.Size = New System.Drawing.Size(84, 22)
        Me.mrbTaskTrash.TabIndex = 5
        Me.mrbTaskTrash.Text = "mrbTaskTrash"
        Me.mrbTaskTrash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.mrbTaskTrash.UseVisualStyleBackColor = False
        '
        'picPlannerHelp
        '
        Me.picPlannerHelp.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.picPlannerHelp.Location = New System.Drawing.Point(863, 9)
        Me.picPlannerHelp.Margin = New System.Windows.Forms.Padding(2)
        Me.picPlannerHelp.Name = "picPlannerHelp"
        Me.picPlannerHelp.Size = New System.Drawing.Size(16, 16)
        Me.picPlannerHelp.TabIndex = 6
        Me.picPlannerHelp.TabStop = False
        '
        'rmFile
        '
        Me.rmFile.AutoSize = True
        Me.rmFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.rmFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.rmFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.rmFile.FlatAppearance.BorderSize = 0
        Me.rmFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.rmFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.rmFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.rmFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rmFile.ForeColor = System.Drawing.Color.White
        Me.rmFile.Location = New System.Drawing.Point(0, 0)
        Me.rmFile.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.rmFile.MinimumSize = New System.Drawing.Size(56, 23)
        Me.rmFile.Name = "rmFile"
        Me.rmFile.Size = New System.Drawing.Size(56, 23)
        Me.rmFile.TabIndex = 46
        Me.rmFile.Text = "rmFile"
        Me.rmFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rmFile.UseVisualStyleBackColor = False
        '
        'extOverview
        '
        Me.extOverview.Appearance = System.Windows.Forms.Appearance.Button
        Me.extOverview.AutoSize = True
        Me.extOverview.BackColor = System.Drawing.SystemColors.Window
        Me.extOverview.FlatAppearance.BorderSize = 0
        Me.extOverview.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.extOverview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.extOverview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.extOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.extOverview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.extOverview.Location = New System.Drawing.Point(56, 0)
        Me.extOverview.Margin = New System.Windows.Forms.Padding(0)
        Me.extOverview.MinimumSize = New System.Drawing.Size(58, 24)
        Me.extOverview.Name = "extOverview"
        Me.extOverview.Size = New System.Drawing.Size(79, 24)
        Me.extOverview.TabIndex = 47
        Me.extOverview.TabStop = True
        Me.extOverview.Text = "extOverview"
        Me.extOverview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.extOverview.UseVisualStyleBackColor = False
        '
        'extManage
        '
        Me.extManage.Appearance = System.Windows.Forms.Appearance.Button
        Me.extManage.AutoSize = True
        Me.extManage.BackColor = System.Drawing.SystemColors.Window
        Me.extManage.FlatAppearance.BorderSize = 0
        Me.extManage.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.extManage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.extManage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.extManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.extManage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.extManage.Location = New System.Drawing.Point(135, 0)
        Me.extManage.Margin = New System.Windows.Forms.Padding(0)
        Me.extManage.MinimumSize = New System.Drawing.Size(58, 24)
        Me.extManage.Name = "extManage"
        Me.extManage.Size = New System.Drawing.Size(71, 24)
        Me.extManage.TabIndex = 48
        Me.extManage.TabStop = True
        Me.extManage.Text = "extManage"
        Me.extManage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.extManage.UseVisualStyleBackColor = False
        '
        'extSystem
        '
        Me.extSystem.Appearance = System.Windows.Forms.Appearance.Button
        Me.extSystem.AutoSize = True
        Me.extSystem.BackColor = System.Drawing.SystemColors.Window
        Me.extSystem.FlatAppearance.BorderSize = 0
        Me.extSystem.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.extSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.extSystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.extSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.extSystem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.extSystem.Location = New System.Drawing.Point(206, 0)
        Me.extSystem.Margin = New System.Windows.Forms.Padding(0)
        Me.extSystem.MinimumSize = New System.Drawing.Size(58, 24)
        Me.extSystem.Name = "extSystem"
        Me.extSystem.Size = New System.Drawing.Size(68, 24)
        Me.extSystem.TabIndex = 49
        Me.extSystem.TabStop = True
        Me.extSystem.Text = "extSystem"
        Me.extSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.extSystem.UseVisualStyleBackColor = False
        '
        'extPlanner
        '
        Me.extPlanner.Appearance = System.Windows.Forms.Appearance.Button
        Me.extPlanner.AutoSize = True
        Me.extPlanner.BackColor = System.Drawing.SystemColors.Window
        Me.extPlanner.FlatAppearance.BorderSize = 0
        Me.extPlanner.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.extPlanner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.extPlanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.extPlanner.ForeColor = System.Drawing.SystemColors.ControlText
        Me.extPlanner.Location = New System.Drawing.Point(274, 0)
        Me.extPlanner.Margin = New System.Windows.Forms.Padding(0)
        Me.extPlanner.MinimumSize = New System.Drawing.Size(58, 24)
        Me.extPlanner.Name = "extPlanner"
        Me.extPlanner.Size = New System.Drawing.Size(69, 24)
        Me.extPlanner.TabIndex = 51
        Me.extPlanner.TabStop = True
        Me.extPlanner.Text = "extPlanner"
        Me.extPlanner.UseVisualStyleBackColor = False
        '
        'extDebug
        '
        Me.extDebug.Appearance = System.Windows.Forms.Appearance.Button
        Me.extDebug.AutoSize = True
        Me.extDebug.BackColor = System.Drawing.SystemColors.Window
        Me.extDebug.FlatAppearance.BorderSize = 0
        Me.extDebug.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.extDebug.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.extDebug.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.extDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.extDebug.ForeColor = System.Drawing.SystemColors.ControlText
        Me.extDebug.Location = New System.Drawing.Point(343, 0)
        Me.extDebug.Margin = New System.Windows.Forms.Padding(0)
        Me.extDebug.MinimumSize = New System.Drawing.Size(58, 24)
        Me.extDebug.Name = "extDebug"
        Me.extDebug.Size = New System.Drawing.Size(64, 24)
        Me.extDebug.TabIndex = 50
        Me.extDebug.TabStop = True
        Me.extDebug.Text = "extDebug"
        Me.extDebug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.extDebug.UseVisualStyleBackColor = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(892, 522)
        Me.Controls.Add(Me.htcMain)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(tlpRibbonMenu)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(900, 480)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " HDD Guardian"
        tlpRibbonMenu.ResumeLayout(False)
        tlpRibbonMenu.PerformLayout()
        Me.tlpMessages.ResumeLayout(False)
        CType(Me.picAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNewVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.htcMain.ResumeLayout(False)
        Me.tpOverview.ResumeLayout(False)
        Me.tpOverview.PerformLayout()
        Me.tlpOverview.ResumeLayout(False)
        Me.tlpOverview.PerformLayout()
        Me.tlpDeviceInfo.ResumeLayout(False)
        Me.tabSidePanel.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.tpGeneral.PerformLayout()
        Me.tlpGeneral.ResumeLayout(False)
        Me.tlpGeneral.PerformLayout()
        CType(Me.HorizontalLine10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpGeneralInfo.ResumeLayout(False)
        Me.tlpGeneralInfo.PerformLayout()
        CType(Me.HorizontalLine11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpDatabase.ResumeLayout(False)
        Me.tlpDatabase.PerformLayout()
        CType(Me.HorizontalLine15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpWarnings.ResumeLayout(False)
        Me.tlpWarnings.PerformLayout()
        flwWarnings.ResumeLayout(False)
        flwWarnings.PerformLayout()
        CType(Me.HorizontalLine16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpHealth.ResumeLayout(False)
        Me.tpHealth.PerformLayout()
        Me.tlpHealth.ResumeLayout(False)
        Me.tlpHealth.PerformLayout()
        Me.tlpRating.ResumeLayout(False)
        Me.tlpRating.PerformLayout()
        CType(Me.HorizontalLine18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpRatingTable.ResumeLayout(False)
        Me.tlpRatingTable.PerformLayout()
        CType(Me.picOverall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRating4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRating2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRating3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRating1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpSummary.ResumeLayout(False)
        Me.tlpSummary.PerformLayout()
        CType(Me.HorizontalLine17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picManufacturer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMenuItems.ResumeLayout(False)
        Me.tlpMenuItems.PerformLayout()
        CType(Me.picOverviewHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpManage.ResumeLayout(False)
        Me.tpManage.PerformLayout()
        Me.tlpManage.ResumeLayout(False)
        Me.htcManage.ResumeLayout(False)
        Me.tpInfo.ResumeLayout(False)
        Me.htcInfo.ResumeLayout(False)
        Me.tpAtaSmartAttributes.ResumeLayout(False)
        Me.tlpAttributes.ResumeLayout(False)
        Me.pnlAttribuesInfo.ResumeLayout(False)
        Me.pnlAttribuesInfo.PerformLayout()
        Me.tlpAttributeDetails.ResumeLayout(False)
        Me.tlpAttributeDetails.PerformLayout()
        Me.tpEvents.ResumeLayout(False)
        Me.tpEvents.PerformLayout()
        Me.tlpChartContent.ResumeLayout(False)
        Me.tlpChartContent.PerformLayout()
        Me.tlpDisplayEvent.ResumeLayout(False)
        Me.tlpDisplayEvent.PerformLayout()
        Me.tlpLogCmd.ResumeLayout(False)
        Me.tlpLogCmd.PerformLayout()
        Me.tlpEventChart.ResumeLayout(False)
        Me.tlpEventChart.PerformLayout()
        Me.tabLog.ResumeLayout(False)
        Me.tpLogEvents.ResumeLayout(False)
        Me.tpLogChart.ResumeLayout(False)
        Me.tpLogChart.PerformLayout()
        CType(Me.chrChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpChartOptions.ResumeLayout(False)
        Me.tlpChartOptions.PerformLayout()
        CType(Me.numPointSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTemperatures.ResumeLayout(False)
        Me.tpTemperatures.PerformLayout()
        Me.tlpTemperatures.ResumeLayout(False)
        Me.tlpTemperatures.PerformLayout()
        Me.tlpTempGraphs.ResumeLayout(False)
        Me.tlpTempGraphs.PerformLayout()
        Me.tlpTempMeans.ResumeLayout(False)
        Me.tlpTempMeans.PerformLayout()
        Me.tpSetup.ResumeLayout(False)
        Me.htcSetup.ResumeLayout(False)
        Me.tpAtaSmartSetup.ResumeLayout(False)
        Me.tpAtaSmartSetup.PerformLayout()
        Me.tlpAtaSmart.ResumeLayout(False)
        Me.tlpAtaSmart.PerformLayout()
        CType(Me.HorizontalLine2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpScsiSmartSetup.ResumeLayout(False)
        Me.tpScsiSmartSetup.PerformLayout()
        Me.tlpScsiSmart.ResumeLayout(False)
        Me.tlpScsiSmart.PerformLayout()
        CType(Me.HorizontalLine13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAtaAam.ResumeLayout(False)
        Me.tpAtaAam.PerformLayout()
        Me.tlpAtaAam.ResumeLayout(False)
        Me.tlpAtaAam.PerformLayout()
        tlpAam.ResumeLayout(False)
        tlpAam.PerformLayout()
        CType(Me.trkAam, System.ComponentModel.ISupportInitialize).EndInit()
        tlpAamLoud.ResumeLayout(False)
        tlpAamLoud.PerformLayout()
        CType(Me.HorizontalLine3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpAamWaitMessage.ResumeLayout(False)
        Me.tlpAamWaitMessage.PerformLayout()
        CType(Me.picLoaderAam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAtaApm.ResumeLayout(False)
        Me.tpAtaApm.PerformLayout()
        Me.tlpApmContent.ResumeLayout(False)
        Me.tlpApmContent.PerformLayout()
        Me.tlpApmWaitMessage.ResumeLayout(False)
        Me.tlpApmWaitMessage.PerformLayout()
        CType(Me.picLoaderApm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkApm, System.ComponentModel.ISupportInitialize).EndInit()
        tlpApm.ResumeLayout(False)
        tlpApm.PerformLayout()
        CType(Me.HorizontalLine4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAtaStandby.ResumeLayout(False)
        Me.tpAtaStandby.PerformLayout()
        Me.tlpStandbyContent.ResumeLayout(False)
        Me.tlpStandbyContent.PerformLayout()
        Me.tlpStandbyWaitMessage.ResumeLayout(False)
        Me.tlpStandbyWaitMessage.PerformLayout()
        CType(Me.picLoaderStandby, System.ComponentModel.ISupportInitialize).EndInit()
        tlpStandby.ResumeLayout(False)
        tlpStandby.PerformLayout()
        CType(Me.trkStandby, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HorizontalLine5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAtaReadWrite.ResumeLayout(False)
        Me.tpAtaReadWrite.PerformLayout()
        Me.tlpOtherContent.ResumeLayout(False)
        Me.tlpOtherContent.PerformLayout()
        Me.tlpWaitRWMessage.ResumeLayout(False)
        Me.tlpWaitRWMessage.PerformLayout()
        CType(Me.picLoaderRW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flwOtherFeatures.ResumeLayout(False)
        Me.flwOtherFeatures.PerformLayout()
        Me.tpErrorsTests.ResumeLayout(False)
        Me.htcErrorsTests.ResumeLayout(False)
        Me.tpAtaErrors.ResumeLayout(False)
        Me.tpAtaErrors.PerformLayout()
        Me.tlpAtaErrorsContent.ResumeLayout(False)
        Me.tlpAtaErrorsContent.PerformLayout()
        Me.tlpErrorList.ResumeLayout(False)
        Me.tlpErrorList.PerformLayout()
        Me.tlpErrorDetails.ResumeLayout(False)
        Me.tlpErrorDetails.PerformLayout()
        Me.tpAtaTests.ResumeLayout(False)
        Me.tpAtaTests.PerformLayout()
        Me.tlpTestsContent.ResumeLayout(False)
        Me.tlpTestsContent.PerformLayout()
        Me.tlpSelfTests.ResumeLayout(False)
        Me.tlpSelfTests.PerformLayout()
        Me.tpAtaRunTest.ResumeLayout(False)
        Me.tpAtaRunTest.PerformLayout()
        Me.tlpAtaTestContent.ResumeLayout(False)
        Me.tlpAtaTestContent.PerformLayout()
        Me.tlpTestProgress.ResumeLayout(False)
        Me.tlpTestProgress.PerformLayout()
        Me.flwProgress.ResumeLayout(False)
        Me.flwProgress.PerformLayout()
        CType(Me.HorizontalLine8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flwTests.ResumeLayout(False)
        Me.flwTests.PerformLayout()
        Me.tpScsiErrors.ResumeLayout(False)
        Me.tpScsiErrors.PerformLayout()
        Me.tlpScsiErrorsContent.ResumeLayout(False)
        Me.tlpScsiErrorsContent.PerformLayout()
        Me.tpScsiTests.ResumeLayout(False)
        Me.tpScsiTests.PerformLayout()
        Me.tlpScsiTestsContent.ResumeLayout(False)
        Me.tlpScsiTestsContent.PerformLayout()
        Me.tpScsiRunTest.ResumeLayout(False)
        Me.tpScsiRunTest.PerformLayout()
        Me.tlpScsiTestContent.ResumeLayout(False)
        Me.tlpScsiTestContent.PerformLayout()
        Me.tlpScsiTest.ResumeLayout(False)
        Me.tlpScsiTest.PerformLayout()
        Me.pnlScsiTestRun.ResumeLayout(False)
        Me.pnlScsiTestRun.PerformLayout()
        CType(Me.HorizontalLine14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSmartctl.ResumeLayout(False)
        Me.htcSmartctl.ResumeLayout(False)
        Me.tpOutput.ResumeLayout(False)
        Me.tpOutput.PerformLayout()
        Me.tlpOutput.ResumeLayout(False)
        Me.tlpOutput.PerformLayout()
        Me.tpAdvanced.ResumeLayout(False)
        Me.tpAdvanced.PerformLayout()
        Me.tlpAdvanced.ResumeLayout(False)
        Me.tlpAdvanced.PerformLayout()
        CType(Me.HorizontalLine12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAdvanced.ResumeLayout(False)
        Me.tpPower.ResumeLayout(False)
        Me.tpPower.PerformLayout()
        Me.tlpPowerModeContent.ResumeLayout(False)
        Me.tlpPowerModeContent.PerformLayout()
        Me.flwPowerMode.ResumeLayout(False)
        Me.flwPowerMode.PerformLayout()
        Me.tpRemap.ResumeLayout(False)
        Me.tpRemap.PerformLayout()
        Me.tlpRemapContent.ResumeLayout(False)
        Me.tlpRemapContent.PerformLayout()
        Me.pnlAttributes.ResumeLayout(False)
        Me.pnlAttributes.PerformLayout()
        Me.tlpButtons.ResumeLayout(False)
        Me.tpFirmware.ResumeLayout(False)
        Me.tpFirmware.PerformLayout()
        Me.tlpFirmwareContent.ResumeLayout(False)
        Me.tlpFirmwareContent.PerformLayout()
        Me.flwFirmware.ResumeLayout(False)
        Me.flwFirmware.PerformLayout()
        Me.tpAsmedia.ResumeLayout(False)
        Me.tpAsmedia.PerformLayout()
        Me.tlpAsmedia.ResumeLayout(False)
        Me.tlpAsmedia.PerformLayout()
        Me.tpVersion.ResumeLayout(False)
        Me.tpVersion.PerformLayout()
        Me.pnlSideMenu.ResumeLayout(False)
        Me.pnlSideMenu.PerformLayout()
        Me.tlpSideMenu.ResumeLayout(False)
        Me.tlpSideMenu.PerformLayout()
        Me.tlpManageMenuContent.ResumeLayout(False)
        Me.tlpManageMenuContent.PerformLayout()
        CType(Me.picManageHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpSelDevice.ResumeLayout(False)
        Me.tlpSelDevice.PerformLayout()
        Me.pnlComboBorder.ResumeLayout(False)
        Me.tpWmiDevices.ResumeLayout(False)
        Me.tpWmiDevices.PerformLayout()
        Me.tlpSystem.ResumeLayout(False)
        Me.htcSystem.ResumeLayout(False)
        Me.tpHardware.ResumeLayout(False)
        Me.tpHardware.PerformLayout()
        Me.tlpHardware.ResumeLayout(False)
        Me.tlpHardware.PerformLayout()
        CType(Me.picHardware, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpHrwDetails.ResumeLayout(False)
        Me.tlpHrwDetails.PerformLayout()
        CType(Me.picBios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMotherboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picProcessor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picVideoCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDisk.ResumeLayout(False)
        Me.tpDisk.PerformLayout()
        Me.tlpDisk.ResumeLayout(False)
        Me.tlpDisk.PerformLayout()
        CType(Me.picDisk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpDiskDetails.ResumeLayout(False)
        Me.tlpDiskDetails.PerformLayout()
        Me.tpPartition.ResumeLayout(False)
        Me.tpPartition.PerformLayout()
        Me.tlpPartition.ResumeLayout(False)
        Me.tlpPartition.PerformLayout()
        CType(Me.picPartition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpPartitionDetails.ResumeLayout(False)
        Me.tlpPartitionDetails.PerformLayout()
        Me.tpLogicalDisk.ResumeLayout(False)
        Me.tpLogicalDisk.PerformLayout()
        Me.tlpLogical.ResumeLayout(False)
        Me.tlpLogical.PerformLayout()
        CType(Me.picLogical, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpLogicalDetails.ResumeLayout(False)
        Me.tlpLogicalDetails.PerformLayout()
        Me.tlpBenchmark.ResumeLayout(False)
        Me.tlpBenchmark.PerformLayout()
        Me.tlpRandom.ResumeLayout(False)
        Me.tlpRandom.PerformLayout()
        Me.tlpRandomMulti.ResumeLayout(False)
        Me.tlpRandomMulti.PerformLayout()
        Me.tlpSequentialMulti.ResumeLayout(False)
        Me.tlpSequentialMulti.PerformLayout()
        Me.tlpSequential.ResumeLayout(False)
        Me.tlpSequential.PerformLayout()
        Me.tlpBenchInfo.ResumeLayout(False)
        Me.tlpBenchInfo.PerformLayout()
        CType(Me.picBenchInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpNoBenchmark.ResumeLayout(False)
        Me.tlpNoBenchmark.PerformLayout()
        CType(Me.picNoBench, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpWmiMenuItems.ResumeLayout(False)
        Me.tlpWmiMenuItems.PerformLayout()
        CType(Me.picWmiDevicesHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpLoadWmi.ResumeLayout(False)
        Me.tlpLoadWmi.PerformLayout()
        CType(Me.picLoadWmi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDebug.ResumeLayout(False)
        Me.tlpDebug.ResumeLayout(False)
        Me.tlpDebug.PerformLayout()
        Me.tlpDebugMenu.ResumeLayout(False)
        Me.tlpDebugMenu.PerformLayout()
        Me.tpPlanner.ResumeLayout(False)
        Me.tpPlanner.PerformLayout()
        Me.tlpTask.ResumeLayout(False)
        Me.tlpTask.PerformLayout()
        CType(Me.picPlannerHelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ttMain As System.Windows.Forms.ToolTip
    Friend WithEvents niTrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents tmrFlushMem As System.Windows.Forms.Timer
    Friend WithEvents tmrTest As System.Windows.Forms.Timer
    Friend WithEvents mnuGuide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuInfo As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents tipTest As hddguardian.TipPanel
    'Friend WithEvents tipTolerance As hddguardian.TipPanel
    'Friend WithEvents tipAttributes As hddguardian.TipPanel
    'Friend WithEvents tipFirmware As hddguardian.TipPanel
    Friend WithEvents dlgFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tmrRefreshExt As System.Windows.Forms.Timer
    Friend WithEvents tmrRefreshVirtual As System.Windows.Forms.Timer
    Friend WithEvents cmTrayIcon As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuRestoreTray As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExitTray As System.Windows.Forms.MenuItem
    Friend WithEvents cmDevices As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuRefreshSel As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRefreshAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSearchUsb As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAddVirtualDev As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRemoveVirtualDev As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTrayIcon As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTrayTemperature As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTrayLife As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSharing As System.Windows.Forms.MenuItem
    Friend WithEvents mnuShareThis As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSharingFolder As System.Windows.Forms.MenuItem
    Friend WithEvents mnuXml As System.Windows.Forms.MenuItem
    Friend WithEvents mnuXmlCreate As System.Windows.Forms.MenuItem
    Friend WithEvents mnuXmlFolder As System.Windows.Forms.MenuItem
    Friend WithEvents htcMain As hdd_guardian.HeadlessTabControl
    Friend WithEvents tpOverview As System.Windows.Forms.TabPage
    Friend WithEvents tpManage As System.Windows.Forms.TabPage
    Friend WithEvents tpWmiDevices As System.Windows.Forms.TabPage
    Friend WithEvents tlpDeviceInfo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpMenuItems As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lvwDevices As System.Windows.Forms.ListView
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents tlpSelDevice As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlComboBorder As System.Windows.Forms.Panel
    Friend WithEvents cboDevices As System.Windows.Forms.ComboBox
    Friend WithEvents RibbonHorizontalSeparator3 As hdd_guardian.RibbonHorizontalSeparator
    Friend WithEvents tlpManageMenuContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents lblSetup As System.Windows.Forms.Label
    Friend WithEvents lblErrorsTests As System.Windows.Forms.Label
    Friend WithEvents lblSmartctl As System.Windows.Forms.Label
    Friend WithEvents htcManage As hdd_guardian.HeadlessTabControl
    Friend WithEvents tpInfo As System.Windows.Forms.TabPage
    Friend WithEvents htcInfo As hdd_guardian.HeadlessTabControl
    Friend WithEvents tpEvents As System.Windows.Forms.TabPage
    Friend WithEvents tpSetup As System.Windows.Forms.TabPage
    Friend WithEvents htcSetup As hdd_guardian.HeadlessTabControl
    Friend WithEvents tpAtaSmartSetup As System.Windows.Forms.TabPage
    Friend WithEvents tpScsiSmartSetup As System.Windows.Forms.TabPage
    Friend WithEvents tpAtaAam As System.Windows.Forms.TabPage
    Friend WithEvents tpAtaApm As System.Windows.Forms.TabPage
    Friend WithEvents tpAtaStandby As System.Windows.Forms.TabPage
    Friend WithEvents tpAtaReadWrite As System.Windows.Forms.TabPage
    Friend WithEvents tpErrorsTests As System.Windows.Forms.TabPage
    Friend WithEvents htcErrorsTests As hdd_guardian.HeadlessTabControl
    Friend WithEvents tpAtaErrors As System.Windows.Forms.TabPage
    Friend WithEvents tpAtaTests As System.Windows.Forms.TabPage
    Friend WithEvents tpAtaRunTest As System.Windows.Forms.TabPage
    Friend WithEvents tpScsiErrors As System.Windows.Forms.TabPage
    Friend WithEvents tpScsiTests As System.Windows.Forms.TabPage
    Friend WithEvents tpScsiRunTest As System.Windows.Forms.TabPage
    Friend WithEvents tpSmartctl As System.Windows.Forms.TabPage
    Friend WithEvents htcSmartctl As hdd_guardian.HeadlessTabControl
    Friend WithEvents tpOutput As System.Windows.Forms.TabPage
    Friend WithEvents tlpAtaSmart As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSmart As System.Windows.Forms.Label
    Friend WithEvents lblAdminSmart As System.Windows.Forms.Label
    Friend WithEvents lblOfflineTest As System.Windows.Forms.Label
    Friend WithEvents lblAttrAutosave As System.Windows.Forms.Label
    Friend WithEvents chkEnableSmart As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableOffline As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableAutosave As System.Windows.Forms.CheckBox
    Friend WithEvents HorizontalLine2 As hdd_guardian.HorizontalLine
    Friend WithEvents tlpAtaAam As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblAamValue As System.Windows.Forms.Label
    Friend WithEvents lblAamRecommended As System.Windows.Forms.Label
    Friend WithEvents lnkSetAam As hdd_guardian.NewLink
    Friend WithEvents lnkSetRecommended As hdd_guardian.NewLink
    Friend WithEvents lnkUndoAam As hdd_guardian.NewLink
    Friend WithEvents trkAam As System.Windows.Forms.TrackBar
    Friend WithEvents lblQuiet As System.Windows.Forms.Label
    Friend WithEvents lblLoudest As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine3 As hdd_guardian.HorizontalLine
    Friend WithEvents lblInfoAam As System.Windows.Forms.Label
    Friend WithEvents tlpApmContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents trkApm As System.Windows.Forms.TrackBar
    Friend WithEvents lblApmValue As System.Windows.Forms.Label
    Friend WithEvents lnkSetApm As hdd_guardian.NewLink
    Friend WithEvents lnkUndoApm As hdd_guardian.NewLink
    Friend WithEvents HorizontalLine4 As hdd_guardian.HorizontalLine
    Friend WithEvents lblInfoApm As System.Windows.Forms.Label
    Friend WithEvents tlpStandbyContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lnkSetStandby As hdd_guardian.NewLink
    Friend WithEvents lblStandbyValue As System.Windows.Forms.Label
    Friend WithEvents lnkUndoStandby As hdd_guardian.NewLink
    Friend WithEvents trkStandby As System.Windows.Forms.TrackBar
    Friend WithEvents HorizontalLine5 As hdd_guardian.HorizontalLine
    Friend WithEvents lblInfoStandby As System.Windows.Forms.Label
    Friend WithEvents tlpOtherContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkCache As System.Windows.Forms.CheckBox
    Friend WithEvents lblCacheInfo As System.Windows.Forms.Label
    Friend WithEvents chkLookAhead As System.Windows.Forms.CheckBox
    Friend WithEvents lblLookAheadInfo As System.Windows.Forms.Label
    Friend WithEvents tpAtaSmartAttributes As System.Windows.Forms.TabPage
    Friend WithEvents tlpAttributes As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lvwSmart As System.Windows.Forms.ListView
    Friend WithEvents chID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAttribute As System.Windows.Forms.ColumnHeader
    Friend WithEvents chValues As System.Windows.Forms.ColumnHeader
    Friend WithEvents chRawValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlAttribuesInfo As System.Windows.Forms.Panel
    Friend WithEvents tlpAttributeDetails As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMeaning As System.Windows.Forms.Label
    Friend WithEvents lblDataStructure As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblPrefailure As System.Windows.Forms.Label
    Friend WithEvents lblOnline As System.Windows.Forms.Label
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents lblErrRate As System.Windows.Forms.Label
    Friend WithEvents lblEvCount As System.Windows.Forms.Label
    Friend WithEvents lblSelfPres As System.Windows.Forms.Label
    Friend WithEvents lblFlags As System.Windows.Forms.Label
    Friend WithEvents tlpAtaErrorsContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblErrLogVer As System.Windows.Forms.Label
    Friend WithEvents tlpTestsContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblNoSelfTests As System.Windows.Forms.Label
    Friend WithEvents lvwSelfTest As System.Windows.Forms.ListView
    Friend WithEvents chNum As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTestType As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTestStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents chRemaining As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAge As System.Windows.Forms.ColumnHeader
    Friend WithEvents chFirstError As System.Windows.Forms.ColumnHeader
    Friend WithEvents tlpAtaTestContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpTestProgress As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents lblExtimatedEnd As System.Windows.Forms.Label
    Friend WithEvents prbTestProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents lblInfoTest As System.Windows.Forms.Label
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents HorizontalLine8 As hdd_guardian.HorizontalLine
    Friend WithEvents tlpScsiSmart As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblScsiGltsd As System.Windows.Forms.Label
    Friend WithEvents lblScsiRCache As System.Windows.Forms.Label
    Friend WithEvents chkScsiRCache As System.Windows.Forms.CheckBox
    Friend WithEvents chkScsiWCache As System.Windows.Forms.CheckBox
    Friend WithEvents lblScsiWCache As System.Windows.Forms.Label
    Friend WithEvents chkScsiSmart As System.Windows.Forms.CheckBox
    Friend WithEvents chkScsiGltsd As System.Windows.Forms.CheckBox
    Friend WithEvents lblScsiSmart As System.Windows.Forms.Label
    Friend WithEvents tlpScsiErrorsContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblScsiNoErrors As System.Windows.Forms.Label
    Friend WithEvents tlpScsiTestsContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblScsiTestCounter As System.Windows.Forms.Label
    Friend WithEvents lvwScsiTests As System.Windows.Forms.ListView
    Friend WithEvents chScsiNum As System.Windows.Forms.ColumnHeader
    Friend WithEvents chScsiTest As System.Windows.Forms.ColumnHeader
    Friend WithEvents chScsiStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents chScsiSegment As System.Windows.Forms.ColumnHeader
    Friend WithEvents chScsiLifetime As System.Windows.Forms.ColumnHeader
    Friend WithEvents chScsiFirstErr As System.Windows.Forms.ColumnHeader
    Friend WithEvents chScsiSK As System.Windows.Forms.ColumnHeader
    Friend WithEvents chScsiASK As System.Windows.Forms.ColumnHeader
    Friend WithEvents chScsiASQ As System.Windows.Forms.ColumnHeader
    Friend WithEvents tlpScsiTest As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlScsiTestRun As System.Windows.Forms.Panel
    Friend WithEvents lblScsiExtimatedEnd As System.Windows.Forms.Label
    Friend WithEvents prbScsiTestProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents lblScsiProgress As System.Windows.Forms.Label
    Friend WithEvents lblScsiTest As System.Windows.Forms.Label
    Friend WithEvents btnScsiRun As System.Windows.Forms.Button
    Friend WithEvents btnScsiStop As System.Windows.Forms.Button
    Friend WithEvents tlpChartContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chrChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents lblNoEvents As System.Windows.Forms.Label
    Friend WithEvents lvwLog As System.Windows.Forms.ListView
    Friend WithEvents chDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents chFrom As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTo As System.Windows.Forms.ColumnHeader
    Friend WithEvents chVariation As System.Windows.Forms.ColumnHeader
    Friend WithEvents tlpDisplayEvent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpOutput As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtReport As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveOutput As System.Windows.Forms.Button
    Friend WithEvents RibbonHorizontalSeparator6 As hdd_guardian.RibbonHorizontalSeparator
    Friend WithEvents tlpWmiMenuItems As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tvwComputer As System.Windows.Forms.TreeView
    Friend WithEvents lblAdminScsiSmart As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine13 As hdd_guardian.HorizontalLine
    Friend WithEvents picManageHelp As System.Windows.Forms.PictureBox
    Friend WithEvents cmFile As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuSettings As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents tlpScsiTestContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblScsiInfoTest As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine14 As hdd_guardian.HorizontalLine
    Friend WithEvents tlpSelfTests As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSelfTests As System.Windows.Forms.Label
    Friend WithEvents picAdmin As System.Windows.Forms.PictureBox
    Friend WithEvents tlpMessages As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picNewVersion As System.Windows.Forms.PictureBox
    Friend WithEvents picOverviewHelp As System.Windows.Forms.PictureBox
    Friend WithEvents picWmiDevicesHelp As System.Windows.Forms.PictureBox
    Friend WithEvents mnuTitle As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents cmDeviceImage As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuProfessional As System.Windows.Forms.MenuItem
    Friend WithEvents mnuGamer As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLaptop As System.Windows.Forms.MenuItem
    Friend WithEvents chkCacheReorder As System.Windows.Forms.CheckBox
    Friend WithEvents lblCacheReorderInfo As System.Windows.Forms.Label
    Friend WithEvents tlpAamWaitMessage As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblAamWaitMessage As System.Windows.Forms.Label
    Friend WithEvents picLoaderAam As System.Windows.Forms.PictureBox
    Friend WithEvents tlpApmWaitMessage As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblApmWaitMessage As System.Windows.Forms.Label
    Friend WithEvents picLoaderApm As System.Windows.Forms.PictureBox
    Friend WithEvents tlpStandbyWaitMessage As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblStandbyWaitMessage As System.Windows.Forms.Label
    Friend WithEvents picLoaderStandby As System.Windows.Forms.PictureBox
    Friend WithEvents tlpWaitRWMessage As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblWaitRWMessage As System.Windows.Forms.Label
    Friend WithEvents picLoaderRW As System.Windows.Forms.PictureBox
    Friend WithEvents tpDebug As System.Windows.Forms.TabPage
    Friend WithEvents lvwProgLog As System.Windows.Forms.ListView
    Friend WithEvents chLogDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents chEvent As System.Windows.Forms.ColumnHeader
    Friend WithEvents tlpLoadWmi As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLoadWmi As System.Windows.Forms.Label
    Friend WithEvents picLoadWmi As System.Windows.Forms.PictureBox
    Friend WithEvents tlpDebug As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpDebugMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RibbonHorizontalSeparator5 As hdd_guardian.RibbonHorizontalSeparator
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuInfoPanel As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReloadDevices As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuUpdateDatabase As System.Windows.Forms.MenuItem
    Friend WithEvents tpTemperatures As System.Windows.Forms.TabPage
    Friend WithEvents lblLifeTimeMax As System.Windows.Forms.Label
    Friend WithEvents lblCurrentTemp As System.Windows.Forms.Label
    Friend WithEvents lblCycleMin As System.Windows.Forms.Label
    Friend WithEvents lblMin As System.Windows.Forms.Label
    Friend WithEvents lblMax As System.Windows.Forms.Label
    Friend WithEvents lblCycleMax As System.Windows.Forms.Label
    Friend WithEvents lblRecommendedMax As System.Windows.Forms.Label
    Friend WithEvents lblLimitMax As System.Windows.Forms.Label
    Friend WithEvents lblCycle As System.Windows.Forms.Label
    Friend WithEvents lblLifeTime As System.Windows.Forms.Label
    Friend WithEvents lblLifeTimeMin As System.Windows.Forms.Label
    Friend WithEvents lblRecommendedMin As System.Windows.Forms.Label
    Friend WithEvents lblLimitMin As System.Windows.Forms.Label
    Friend WithEvents lblRecommended As System.Windows.Forms.Label
    Friend WithEvents lblLimit As System.Windows.Forms.Label
    Friend WithEvents lblCurrentTempValue As System.Windows.Forms.Label
    Friend WithEvents tbCycle As hdd_guardian.TemperaturesBar
    Friend WithEvents tbLifeTime As hdd_guardian.TemperaturesBar
    Friend WithEvents tbRecommended As hdd_guardian.TemperaturesBar
    Friend WithEvents tbLimit As hdd_guardian.TemperaturesBar
    Friend WithEvents lblZero As System.Windows.Forms.Label
    Friend WithEvents tlpTemperatures As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTempMeans As System.Windows.Forms.Label
    Friend WithEvents tlpTempMeans As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLimitValue As System.Windows.Forms.Label
    Friend WithEvents lblLimitMean As System.Windows.Forms.Label
    Friend WithEvents lblCycleMeans As System.Windows.Forms.Label
    Friend WithEvents lblLifeTimeMean As System.Windows.Forms.Label
    Friend WithEvents lblRecommendedMean As System.Windows.Forms.Label
    Friend WithEvents lblCycleValue As System.Windows.Forms.Label
    Friend WithEvents lblLifeTimeValue As System.Windows.Forms.Label
    Friend WithEvents lblRecommendedValue As System.Windows.Forms.Label
    Friend WithEvents tpAdvanced As System.Windows.Forms.TabPage
    Friend WithEvents tlpAdvanced As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents HorizontalLine12 As hdd_guardian.HorizontalLine
    Friend WithEvents lblAdminAdvanced As System.Windows.Forms.Label
    Friend WithEvents tlpRemapContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlAttributes As System.Windows.Forms.Panel
    Friend WithEvents lvwAttrFormat As System.Windows.Forms.ListView
    Friend WithEvents chAttrID As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAttrFormat As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAttrName As System.Windows.Forms.ColumnHeader
    Friend WithEvents tlpButtons As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents chkAttributes As System.Windows.Forms.CheckBox
    Friend WithEvents lblRemapInfo As System.Windows.Forms.Label
    Friend WithEvents lblPowerInfo As System.Windows.Forms.Label
    Friend WithEvents tlpFirmwareContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flwFirmware As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cboFirmware As System.Windows.Forms.ComboBox
    Friend WithEvents lblFirmwareDebug As System.Windows.Forms.Label
    Friend WithEvents chkFixSwap As System.Windows.Forms.CheckBox
    Friend WithEvents lblFixSwap As System.Windows.Forms.Label
    Friend WithEvents chkNoLogDir As System.Windows.Forms.CheckBox
    Friend WithEvents lblNoLogDir As System.Windows.Forms.Label
    Friend WithEvents chkXErrorLba As System.Windows.Forms.CheckBox
    Friend WithEvents lblXErrorLba As System.Windows.Forms.Label
    Friend WithEvents chkFirmware As System.Windows.Forms.CheckBox
    Friend WithEvents lblFirmwareDebugInfo As System.Windows.Forms.Label
    Friend WithEvents tlpPowerModeContent As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flwPowerMode As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents rbNever As System.Windows.Forms.RadioButton
    Friend WithEvents lblNever As System.Windows.Forms.Label
    Friend WithEvents rbSleep As System.Windows.Forms.RadioButton
    Friend WithEvents lblSleep As System.Windows.Forms.Label
    Friend WithEvents rbStandby As System.Windows.Forms.RadioButton
    Friend WithEvents lblStandby As System.Windows.Forms.Label
    Friend WithEvents rbIdle As System.Windows.Forms.RadioButton
    Friend WithEvents lblIdle As System.Windows.Forms.Label
    Friend WithEvents chkPowerMode As System.Windows.Forms.CheckBox
    Friend WithEvents tabAdvanced As System.Windows.Forms.TabControl
    Friend WithEvents tpPower As System.Windows.Forms.TabPage
    Friend WithEvents tpRemap As System.Windows.Forms.TabPage
    Friend WithEvents tpFirmware As System.Windows.Forms.TabPage
    Friend WithEvents tlpTempGraphs As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flwOtherFeatures As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tpAsmedia As System.Windows.Forms.TabPage
    Friend WithEvents tlpAsmedia As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblAsmedia As System.Windows.Forms.Label
    Friend WithEvents chkAsmedia As System.Windows.Forms.CheckBox
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tslSmartctl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlpOverview As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tabSidePanel As System.Windows.Forms.TabControl
    Friend WithEvents tpGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tpHealth As System.Windows.Forms.TabPage
    Friend WithEvents tlpGeneral As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblInformation As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine10 As hdd_guardian.HorizontalLine
    Friend WithEvents tlpGeneralInfo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblManufacturer As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents lnkManufacturer As hdd_guardian.NewLink
    Friend WithEvents lblModelValue As System.Windows.Forms.Label
    Friend WithEvents lblSerial As System.Windows.Forms.Label
    Friend WithEvents lblSerialValue As System.Windows.Forms.Label
    Friend WithEvents exlWwnId As hdd_guardian.ExtendedLabel
    Friend WithEvents lblWwnIdValue As System.Windows.Forms.Label
    Friend WithEvents exlFirmware As hdd_guardian.ExtendedLabel
    Friend WithEvents lblFirmwareValue As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents lblSizeValue As System.Windows.Forms.Label
    Friend WithEvents exlSectorBlock As hdd_guardian.ExtendedLabel
    Friend WithEvents lblSectorBlockValue As System.Windows.Forms.Label
    Friend WithEvents lblRotationRate As System.Windows.Forms.Label
    Friend WithEvents lblRotationRateValue As System.Windows.Forms.Label
    Friend WithEvents lblFactoryForm As System.Windows.Forms.Label
    Friend WithEvents lblFactoryFormValue As System.Windows.Forms.Label
    Friend WithEvents lblInterface As System.Windows.Forms.Label
    Friend WithEvents lblInterfaceValue As System.Windows.Forms.Label
    Friend WithEvents lblSmartInfo As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine11 As hdd_guardian.HorizontalLine
    Friend WithEvents lblSmartInfoValue As System.Windows.Forms.Label
    Friend WithEvents tlpDatabase As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDatabaseInfo As System.Windows.Forms.Label
    Friend WithEvents lblDatabaseInfoValue As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine15 As hdd_guardian.HorizontalLine
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblLocationValue As System.Windows.Forms.Label
    Friend WithEvents lnkUpdateDatabase As hdd_guardian.NewLink
    Friend WithEvents tlpWarnings As System.Windows.Forms.TableLayoutPanel
    Protected WithEvents lblWarningValue As System.Windows.Forms.Label
    Friend WithEvents lnkWeb1 As hdd_guardian.NewLink
    Friend WithEvents lnkWeb2 As hdd_guardian.NewLink
    Friend WithEvents lnkWeb3 As hdd_guardian.NewLink
    Friend WithEvents lblWarnings As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine16 As hdd_guardian.HorizontalLine
    Friend WithEvents picManufacturer As System.Windows.Forms.PictureBox
    Friend WithEvents tlpHealth As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpRating As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblReliabilityRating As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine18 As hdd_guardian.HorizontalLine
    Friend WithEvents tlpRatingTable As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picOverall As System.Windows.Forms.PictureBox
    Friend WithEvents lblRating4 As System.Windows.Forms.Label
    Friend WithEvents lblRating4Value As System.Windows.Forms.Label
    Friend WithEvents lblRating3 As System.Windows.Forms.Label
    Friend WithEvents lblRating3Value As System.Windows.Forms.Label
    Friend WithEvents lblRating2 As System.Windows.Forms.Label
    Friend WithEvents picRating4 As System.Windows.Forms.PictureBox
    Friend WithEvents picRating2 As System.Windows.Forms.PictureBox
    Friend WithEvents picRating3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblRating2Value As System.Windows.Forms.Label
    Friend WithEvents picRating1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblRating1Value As System.Windows.Forms.Label
    Friend WithEvents lblRating1 As System.Windows.Forms.Label
    Friend WithEvents lblOverall As System.Windows.Forms.Label
    Friend WithEvents lblOverallRating As System.Windows.Forms.Label
    Friend WithEvents tlpSummary As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTemp As System.Windows.Forms.Label
    Friend WithEvents lblTempValue As System.Windows.Forms.Label
    Friend WithEvents lblErrors As System.Windows.Forms.Label
    Friend WithEvents lblBadSectors As System.Windows.Forms.Label
    Friend WithEvents lblHealth As System.Windows.Forms.Label
    Friend WithEvents lblHealthValue As System.Windows.Forms.Label
    Friend WithEvents lblLastTestValue As System.Windows.Forms.Label
    Friend WithEvents lblLastTest As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdate As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdateValue As System.Windows.Forms.Label
    Friend WithEvents lblRemainingLife As System.Windows.Forms.Label
    Friend WithEvents lblRemainingLifeValue As System.Windows.Forms.Label
    Friend WithEvents lblWorkTime As System.Windows.Forms.Label
    Friend WithEvents lblWorkTimeValue As System.Windows.Forms.Label
    Friend WithEvents exlBadSectors As hdd_guardian.ExtendedLabel
    Friend WithEvents exlErrors As hdd_guardian.ExtendedLabel
    Friend WithEvents lblSummary As System.Windows.Forms.Label
    Friend WithEvents HorizontalLine17 As hdd_guardian.HorizontalLine
    Friend WithEvents rmFile As hdd_guardian.MimicExplorer.RibbonMenu
    Friend WithEvents extOverview As hdd_guardian.MimicExplorer.ExplorerTab
    Friend WithEvents extManage As hdd_guardian.MimicExplorer.ExplorerTab
    Friend WithEvents extSystem As hdd_guardian.MimicExplorer.ExplorerTab
    Friend WithEvents extDebug As hdd_guardian.MimicExplorer.ExplorerTab
    Friend WithEvents mrrAttributes As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrEvents As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrTemperatures As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrbUpdateAll As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents mrbRescanUsb As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents mrbAddVirtual As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents mrcSidePanel As hdd_guardian.MimicExplorer.RibbonCheck
    Friend WithEvents mrrSmartSetup As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrAam As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrApm As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrStandby As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrReadWrite As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrErrorsLog As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrTestsLog As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrRunTest As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrOutput As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrAdvanced As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrrSmartctl As hdd_guardian.MimicExplorer.RibbonRadio
    Friend WithEvents mrbRefresh As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents mrbDebugSave As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents mrbDebugClean As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents mrbLeft As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents mrbRight As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents mrbReloadDevice As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents tpVersion As System.Windows.Forms.TabPage
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents extPlanner As hdd_guardian.MimicExplorer.ExplorerTab
    Friend WithEvents tpPlanner As System.Windows.Forms.TabPage
    Friend WithEvents tlpTask As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents mrbTaskNew As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents mrbTaskEdit As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents flwTests As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents optOffline As System.Windows.Forms.RadioButton
    Friend WithEvents lblOfflineDuration As System.Windows.Forms.Label
    Friend WithEvents lblOfflineInfo As System.Windows.Forms.Label
    Friend WithEvents optShort As System.Windows.Forms.RadioButton
    Friend WithEvents lblShortDuration As System.Windows.Forms.Label
    Friend WithEvents lblShortInfo As System.Windows.Forms.Label
    Friend WithEvents optLong As System.Windows.Forms.RadioButton
    Friend WithEvents lblLongDuration As System.Windows.Forms.Label
    Friend WithEvents lblLongInfo As System.Windows.Forms.Label
    Friend WithEvents optConveyance As System.Windows.Forms.RadioButton
    Friend WithEvents lblConveyanceDuration As System.Windows.Forms.Label
    Friend WithEvents lblConveyanceInfo As System.Windows.Forms.Label
    Friend WithEvents flwProgress As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lvwTasks As System.Windows.Forms.ListView
    Friend WithEvents chDevice As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTest As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTask As System.Windows.Forms.ColumnHeader
    Friend WithEvents mrbTaskDelete As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents mrbTaskTrash As hdd_guardian.MimicExplorer.RibbonButton
    Friend WithEvents RibbonHorizontalSeparator1 As hdd_guardian.RibbonHorizontalSeparator
    Friend WithEvents cmTask As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuTaskNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTaskEdit As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTaskDelete As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTaskTrash As System.Windows.Forms.MenuItem
    Friend WithEvents RibbonVerticalSeparator7 As RibbonVerticalSeparator
    Friend WithEvents picHardware As PictureBox
    Friend WithEvents tlpHrwDetails As TableLayoutPanel
    Friend WithEvents lblHrwBios As Label
    Friend WithEvents lblHrwRamValue As Label
    Friend WithEvents lblHrwProcessorValue As Label
    Friend WithEvents lblHrwMotherboardValue As Label
    Friend WithEvents lblHrwBiosValue As Label
    Friend WithEvents lblHrwMotherboard As Label
    Friend WithEvents lblHrwProcessor As Label
    Friend WithEvents lblHrwRam As Label
    Friend WithEvents lblHrwVideoCard As Label
    Friend WithEvents lblHrwVideoCardValue As Label
    Friend WithEvents tlpHardware As TableLayoutPanel
    Friend WithEvents tlpSideMenu As TableLayoutPanel
    Friend WithEvents tlpManage As TableLayoutPanel
    Friend WithEvents pnlSideMenu As Panel
    Friend WithEvents tlpSystem As TableLayoutPanel
    Friend WithEvents lvwEvents As ListView
    Friend WithEvents chAttrLog As ColumnHeader
    Friend WithEvents chTotalEvents As ColumnHeader
    Friend WithEvents mcLog As MonthCalendar
    Friend WithEvents tabLog As TabControl
    Friend WithEvents tpLogEvents As TabPage
    Friend WithEvents tpLogChart As TabPage
    Friend WithEvents lblDisplay As Label
    Friend WithEvents RibbonHorizontalSeparator4 As RibbonHorizontalSeparator
    Friend WithEvents optEntire As RadioButton
    Friend WithEvents optSelection As RadioButton
    Friend WithEvents btnExport As Button
    Friend WithEvents btnReload As Button
    Friend WithEvents RibbonHorizontalSeparator7 As RibbonHorizontalSeparator
    Friend WithEvents tlpLogCmd As TableLayoutPanel
    Friend WithEvents cmLog As ContextMenu
    Friend WithEvents mnuCopyLog As MenuItem
    Friend WithEvents MenuItem9 As MenuItem
    Friend WithEvents mnuCopyAllLog As MenuItem
    Friend WithEvents rspManage As MimicExplorer.RibbonSplitter
    Friend WithEvents rspSystem As MimicExplorer.RibbonSplitter
    Friend WithEvents rspOverview As MimicExplorer.RibbonSplitter
    Friend WithEvents tlpEventChart As TableLayoutPanel
    Friend WithEvents tlpChartOptions As TableLayoutPanel
    Friend WithEvents lblPointSize As Label
    Friend WithEvents lblNoPeriodEvents As Label
    Public WithEvents chkChartValues As CheckBox
    Public WithEvents numPointSize As NumericUpDown
    Friend WithEvents picPlannerHelp As PictureBox
    Friend WithEvents lblLetter As Label
    Friend WithEvents lblLetterValue As Label
    Friend WithEvents htcSystem As HeadlessTabControl
    Friend WithEvents tpHardware As TabPage
    Friend WithEvents picBios As PictureBox
    Friend WithEvents picMotherboard As PictureBox
    Friend WithEvents picProcessor As PictureBox
    Friend WithEvents picRam As PictureBox
    Friend WithEvents picVideoCard As PictureBox
    Friend WithEvents tpDisk As TabPage
    Friend WithEvents tpPartition As TabPage
    Friend WithEvents tpLogicalDisk As TabPage
    Friend WithEvents tlpDisk As TableLayoutPanel
    Friend WithEvents tlpDiskDetails As TableLayoutPanel
    Friend WithEvents lblDiskSN As Label
    Friend WithEvents lblDiskSizeValue As Label
    Friend WithEvents lblDiskPartitionsValue As Label
    Friend WithEvents lblDiskIndexValue As Label
    Friend WithEvents lblDiskSNValue As Label
    Friend WithEvents lblDiskSize As Label
    Friend WithEvents lblDiskPartitions As Label
    Friend WithEvents lblDiskIndex As Label
    Friend WithEvents picDisk As PictureBox
    Friend WithEvents tlpPartition As TableLayoutPanel
    Friend WithEvents picPartition As PictureBox
    Friend WithEvents tlpPartitionDetails As TableLayoutPanel
    Friend WithEvents lblBootable As Label
    Friend WithEvents lblPartitionTypeValue As Label
    Friend WithEvents lblPrimaryPartitionValue As Label
    Friend WithEvents lblBootPartitionValue As Label
    Friend WithEvents lblBootableValue As Label
    Friend WithEvents lblPartitionType As Label
    Friend WithEvents lblPrimaryPartition As Label
    Friend WithEvents lblBootPartition As Label
    Friend WithEvents lblBlocks As Label
    Friend WithEvents lblBlockSize As Label
    Friend WithEvents lblPartitionSize As Label
    Friend WithEvents lblBlocksValue As Label
    Friend WithEvents lblBlockSizeValue As Label
    Friend WithEvents lblPartitionSizeValue As Label
    Friend WithEvents tlpLogical As TableLayoutPanel
    Friend WithEvents picLogical As PictureBox
    Friend WithEvents tlpLogicalDetails As TableLayoutPanel
    Friend WithEvents lblLogicalSN As Label
    Friend WithEvents lblLogicalSizeValue As Label
    Friend WithEvents lblFileSystemValue As Label
    Friend WithEvents lblLogicalSNValue As Label
    Friend WithEvents lblLogicalSize As Label
    Friend WithEvents lblFileSystem As Label
    Friend WithEvents tlpBenchmark As TableLayoutPanel
    Friend WithEvents lblSequentialMulti As Label
    Friend WithEvents lblRandomMulti As Label
    Friend WithEvents RibbonVerticalSeparator1 As RibbonVerticalSeparator
    Friend WithEvents RibbonVerticalSeparator2 As RibbonVerticalSeparator
    Friend WithEvents tlpSequentialMulti As TableLayoutPanel
    Friend WithEvents bbReadSMulti As BenchmarkBar
    Friend WithEvents bbWriteSMulti As BenchmarkBar
    Friend WithEvents tlpRandom As TableLayoutPanel
    Friend WithEvents bbReadR As BenchmarkBar
    Friend WithEvents bbWriteR As BenchmarkBar
    Friend WithEvents lblReadR As Label
    Friend WithEvents lblWriteR As Label
    Friend WithEvents tlpRandomMulti As TableLayoutPanel
    Friend WithEvents bbReadRMulti As BenchmarkBar
    Friend WithEvents bbWriteRMulti As BenchmarkBar
    Friend WithEvents lblReadRMulti As Label
    Friend WithEvents lblWriteRMulti As Label
    Friend WithEvents lblReadSMulti As Label
    Friend WithEvents lblWriteSMulti As Label
    Friend WithEvents lblSequential As Label
    Friend WithEvents lblRandom As Label
    Friend WithEvents RibbonVerticalSeparator3 As RibbonVerticalSeparator
    Friend WithEvents RibbonVerticalSeparator4 As RibbonVerticalSeparator
    Friend WithEvents tlpSequential As TableLayoutPanel
    Friend WithEvents bbReadS As BenchmarkBar
    Friend WithEvents bbWriteS As BenchmarkBar
    Friend WithEvents lblReadS As Label
    Friend WithEvents lblWriteS As Label
    Friend WithEvents lnkRunAll As NewLink
    Friend WithEvents lblBenchmark As Label
    Friend WithEvents tlpNoBenchmark As TableLayoutPanel
    Friend WithEvents picNoBench As PictureBox
    Friend WithEvents lblNoBench As Label
    Friend WithEvents lvwErrors As ListView
    Friend WithEvents chErrors As ColumnHeader
    Friend WithEvents tlpErrorList As TableLayoutPanel
    Friend WithEvents lblErrorDescription As Label
    Friend WithEvents lblNoError As Label
    Friend WithEvents tlpErrorDetails As TableLayoutPanel
    Friend WithEvents lblErrorDescTitle As Label
    Friend WithEvents mnuDeviceImage As MenuItem
    Friend WithEvents mnuDeviceImageSet As MenuItem
    Friend WithEvents mnuDeviceImageRemove As MenuItem
    Friend WithEvents tlpBenchInfo As TableLayoutPanel
    Friend WithEvents picBenchInfo As PictureBox
    Friend WithEvents lblBenching As Label
    Friend WithEvents prbBench As ProgressBar
    Friend WithEvents lblBenchProgress As Label
    Friend WithEvents lvwScsiErrors As ListView
    Friend WithEvents chScsiErrorItem As ColumnHeader
    Friend WithEvents chScsiErrorItemValue As ColumnHeader
End Class
