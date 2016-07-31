'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is: http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2016 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System
Imports System.Xml
Imports System.Management

Module _Settings
    Public AppSettings As New CustomSettings
End Module

Public Class CustomSettings
    Dim _general As New SettingsGeneral
    Dim _language As New SettingsLanguage
    Dim _detection As New SettingsDetection
    Dim _areca As New SettingsAreca
    Dim _refresh As New SettingsRefresh
    Dim _vital As New SettingsVital
    Dim _warnings As New SettingsWarning
    Dim _mail As New SettingsMail
    Dim _reliability As New SettingsReliability
    Dim _sharing As New SettingsShare
    Dim _smartctl As New SettingsSmartctl

    Dim _portable As Boolean = IsPortable()

    Private Function IsPortable() As Boolean
        Try
            Dim p As String = My.Application.Info.DirectoryPath
            Dim r As String = My.Computer.FileSystem.GetDirectoryInfo(p).Root.ToString.Replace("\", "")

            Dim win32_logicaldisktopartition As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_LogicalDiskToPartition")
            For Each logicaldisktopartition As ManagementObject In win32_logicaldisktopartition.Get
                Dim dependent() As String = logicaldisktopartition("Dependent").ToString.Split("=")
                If dependent(1).Contains(r) Then
                    Dim antecedent() As String = logicaldisktopartition("Antecedent").ToString.Split("=")
                    Dim win32_diskpartition As New ManagementObjectSearcher("root/CIMV2", " SELECT * FROM Win32_DiskDriveToDiskPartition")
                    For Each diskpartition As ManagementObject In win32_diskpartition.Get
                        Dim dependent_dp() As String = diskpartition("Dependent").ToString.Split("=")
                        If dependent_dp(1).Contains(antecedent(1)) Then
                            Dim antecedent_dp() As String = diskpartition("Antecedent").ToString.Split("=")
                            Dim win32_diskdrive As New ManagementObjectSearcher("root/CIMV2", "SELECT * FROM Win32_DiskDrive WHERE DeviceID = " & antecedent_dp(1).Replace("""", "'"))
                            For Each diskdrive As ManagementObject In win32_diskdrive.Get
                                If diskdrive("InterfaceType").ToString.ToUpper = "USB" Then
                                    Return True
                                End If
                            Next
                            Exit For
                        End If
                    Next
                    Exit For
                End If
            Next

            Return False

        Catch err As ManagementException
            Return False
        End Try
    End Function

    Public Sub New()
        Load()
    End Sub

    Public Sub Load()
        Dim source As String

        If _portable Then
            source = My.Application.Info.DirectoryPath & "\settings.xml"
        Else
            source = My.Application.Info.DirectoryPath & "\Data\" & My.User.Name & "\settings.xml"
        End If

        LoadFrom(source)
    End Sub

    Public Sub Save()
        Dim dest As String

        If _portable Then
            dest = My.Application.Info.DirectoryPath
        Else
            dest = My.Application.Info.DirectoryPath & "\Data\" & My.User.Name
        End If

        If Not IO.Directory.Exists(dest) Then IO.Directory.CreateDirectory(dest)

        SaveTo(dest & "\settings.xml")
    End Sub

    Public Sub Import()
        Dim dlg As New OpenFileDialog
        Dim res As DialogResult

        With dlg
            .AddExtension = True
            .CheckPathExists = True
            .DefaultExt = "xml"
            .Filter = "eXtensible Markup Language|*.xml"
            .FileName = "settings"
            res = .ShowDialog()
        End With

        If res = DialogResult.OK Then
            LoadFrom(dlg.FileName)
            Save()
        End If
    End Sub

    Public Sub Export()
        Dim dlg As New SaveFileDialog
        Dim res As DialogResult

        With dlg
            .AddExtension = True
            .CheckPathExists = True
            .DefaultExt = "xml"
            .Filter = "eXtensible Markup Language|*.xml"
            .FileName = "settings"
            res = .ShowDialog()
        End With

        If res = DialogResult.OK Then SaveTo(dlg.FileName)
    End Sub

    Public Sub ResetToDefault()
        With _general
            .AlwaysDisplayTrayIcon = False
            .CheckForUpdates = True
            .CheckLanguageUpdates = False
            .CloseToTray = False
            .ComputerType = 0
            .ConfirmOnExit = False
            .DisplayDebug = False
            .DisplayInfoPanel = False
            .DisplaySidePanel = True
            .DisplayValues = False
            .HideToTray = False
            .IsMaximized = False
            .RememberWindowSize = False
            .RunMinimized = False
            .RunWithWindows = False
            .PointsSize = 8
            .SidePanelWidth = 0
            .ManageSideMenuWidth = 150
            .SystemTreeWidth = 250
            .TemperatureInFahrenheit = False
            .WindowSize = New Size(0, 0)
        End With
        With _language
            .AutomaticTranslation = True
            .PreferredLanguage = ""
        End With
        With _detection
            .Add3ware = False
            .Additional = ""
            .Csmi = True
        End With
        With _areca
            .SasEnclosure1 = 4
            .SasEnclosure2 = 4
            .SasEnclosure3 = 4
            .SasEnclosure4 = 4
            .SasEnclosure5 = 4
            .SasEnclosure6 = 4
            .SasEnclosure7 = 4
            .SasEnclosure8 = 4
            .SataDevices = 4
        End With
        With _refresh
            .External = 15
            .Internal = 5
            .Virtual = 5
        End With
        With _vital
            .DiskShift = SettingsVital.Vital.Complete
            .Indilinx = SettingsVital.Vital.Complete
            .Intel = SettingsVital.Vital.Complete
            .Micron = SettingsVital.Vital.Complete
            .OfflineUncorrectable = SettingsVital.Vital.Complete
            .PendingSectors = SettingsVital.Vital.Complete
            .ReallocatedSectors = SettingsVital.Vital.Complete
            .ReallocationEvents = SettingsVital.Vital.Complete
            .Samsung = SettingsVital.Vital.Complete
            .SandForce = SettingsVital.Vital.Complete
            .SoftReadErrors = SettingsVital.Vital.Complete
            .SpinRetry = SettingsVital.Vital.Complete
            .Temperature = SettingsVital.Vital.Track
        End With
        With _warnings
            .SendMail = SettingsWarning.Triggers.Both
            .PowerOff = SettingsWarning.Triggers.Never
            .PlaySound = SettingsWarning.Triggers.Never
            .Notify = SettingsWarning.Triggers.Both
            .SoundFile = ""
            .TimeOut = 30
            .ForceClose = False
        End With
        With _mail
            .Body = ""
            .Destination = ""
            .Login = ""
            .Password = ""
            .Report = SettingsMail.MailReport.None
            .ReportDay = 0
            .ReportTime = ""
            .Sender = ""
            .SmtpPort = ""
            .SmtpServer = ""
            .Subject = ""
            .UseSsl = True
        End With
        With _reliability
            .CustomThreshold = False
            .Enable = True
            .PendingSectors = 10
            .ReallocationEvents = 10
            .UncorrectableSectors = 10
        End With
        With _sharing
            .OutputFolder = ""
            .XmlFolder = ""
            .XmlReport = False
        End With
        With _smartctl
            .AlternativeVersion = False
            .ExecutableFolder = ""
            .SetTolerance = False
            .Tolerance = ""
            .SetPowerMode = False
            .PowerMode = ""
        End With
    End Sub

    Private Sub SaveTo(ByVal destination As String)
        Dim output As XmlWriterSettings = New XmlWriterSettings()
        output.Indent = True

        Using write As XmlWriter = XmlWriter.Create(destination, output)
            'begin writing
            write.WriteStartDocument()
            write.WriteStartElement("settings") 'root element
            'general group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "General")
            For Each p As Reflection.PropertyInfo In _general.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_general).ToString)
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            'language group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "Language")
            For Each p As Reflection.PropertyInfo In _language.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_language))
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            'detection group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "Detection")
            For Each p As Reflection.PropertyInfo In _detection.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_detection))
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            'areca group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "Areca")
            For Each p As Reflection.PropertyInfo In _areca.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_areca))
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            'refresh group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "Refresh")
            For Each p As Reflection.PropertyInfo In _refresh.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_refresh))
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            'vital group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "Vital")
            For Each p As Reflection.PropertyInfo In _vital.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_vital))
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            'warnings group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "Warnings")
            For Each p As Reflection.PropertyInfo In _warnings.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_warnings))
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            'mail group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "Mail")
            For Each p As Reflection.PropertyInfo In _mail.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_mail))
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            'reliability group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "Reliability")
            For Each p As Reflection.PropertyInfo In _reliability.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_reliability))
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            'share group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "Share")
            For Each p As Reflection.PropertyInfo In _sharing.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_sharing))
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            'smartctl group
            write.WriteStartElement("group")
            write.WriteAttributeString("name", "Smartctl")
            For Each p As Reflection.PropertyInfo In _smartctl.GetType.GetProperties
                write.WriteStartElement("setting")
                write.WriteAttributeString("name", p.Name)
                write.WriteAttributeString("value", p.GetValue(_smartctl))
                write.WriteEndElement()
            Next
            write.WriteEndElement()

            'end of root element & write the document
            write.WriteEndElement()
            write.WriteEndDocument()
        End Using
    End Sub

    Private Function ToSize(ByVal value As String) As Size
        '{Width=0, Height=0}
        Dim v() As Char = value.ToCharArray
        Dim s As String = ""

        For i As Short = 0 To v.Count - 1
            If IsNumeric(v(i)) Or v(i) = "," Then
                s += v(i)
            End If
        Next

        Dim wh() As String = s.Split(",")
        Return New Size(wh(0), wh(1))
    End Function

    Private Sub LoadFrom(ByVal source As String)
        If Not IO.File.Exists(source) Then
            ResetToDefault()
            Exit Sub
        End If

        Try
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            m_xmldoc.Load(source)
            m_nodelist = m_xmldoc.SelectNodes("/settings/group")

            For Each m_node In m_nodelist
                Dim name As String = m_node.Attributes.GetNamedItem("name").Value

                Dim s_node As XmlNode
                For Each s_node In m_node.ChildNodes
                    If Not IsNothing(s_node) And s_node.NodeType <> XmlNodeType.Comment Then
                        Dim setting_name As String = s_node.Attributes.GetNamedItem("name").Value
                        Dim setting_value As String = s_node.Attributes.GetNamedItem("value").Value

                        Select Case name
                            Case "General"
                                If setting_value.Contains("{") Then
                                    CallByName(_general, setting_name, CallType.Set, ToSize(setting_value))
                                Else
                                    CallByName(_general, setting_name, CallType.Set, setting_value)
                                End If
                            Case "Language"
                                CallByName(_language, setting_name, CallType.Set, setting_value)
                            Case "Detection"
                                CallByName(_detection, setting_name, CallType.Set, setting_value)
                            Case "Areca"
                                If Val(setting_value) > 8 Then setting_value = 8
                                If Val(setting_value) < 0 Then setting_value = 0
                                CallByName(_areca, setting_name, CallType.Set, setting_value)
                            Case "Refresh"
                                CallByName(_refresh, setting_name, CallType.Set, setting_value)
                            Case "Vital"
                                CallByName(_vital, setting_name, CallType.Set, setting_value)
                            Case "Warnings"
                                If setting_name = "TimeOut" Then
                                    If Val(setting_value) > 600 Then setting_value = 600
                                    If Val(setting_value) < 0 Then setting_value = 0
                                Else
                                    If Val(setting_value) > 3 Then setting_value = 3
                                    If Val(setting_value) < 0 Then setting_value = 0
                                End If
                                CallByName(_warnings, setting_name, CallType.Set, setting_value)
                            Case "Mail"
                                CallByName(_mail, setting_name, CallType.Set, setting_value)
                            Case "Reliability"
                                CallByName(_reliability, setting_name, CallType.Set, setting_value)
                            Case "Share"
                                CallByName(_sharing, setting_name, CallType.Set, setting_value)
                            Case "Smartctl"
                                CallByName(_smartctl, setting_name, CallType.Set, setting_value)
                        End Select
                    End If
                Next
            Next
        Catch ex As Exception
            ResetToDefault()
        End Try
    End Sub

#Region "Properties"
    Public ReadOnly Property General As SettingsGeneral
        Get
            Return _general
        End Get
    End Property

    Public ReadOnly Property Language As SettingsLanguage
        Get
            Return _language
        End Get
    End Property

    Public ReadOnly Property Detection As SettingsDetection
        Get
            Return _detection
        End Get
    End Property

    Public ReadOnly Property Areca As SettingsAreca
        Get
            Return _areca
        End Get
    End Property

    Public ReadOnly Property Refresh As SettingsRefresh
        Get
            Return _refresh
        End Get
    End Property

    Public ReadOnly Property VitalParameters As SettingsVital
        Get
            Return _vital
        End Get
    End Property

    Public ReadOnly Property Warnings As SettingsWarning
        Get
            Return _warnings
        End Get
    End Property

    Public ReadOnly Property Mail As SettingsMail
        Get
            Return _mail
        End Get
    End Property

    Public ReadOnly Property Reliability As SettingsReliability
        Get
            Return _reliability
        End Get
    End Property

    Public ReadOnly Property Sharing As SettingsShare
        Get
            Return _sharing
        End Get
    End Property

    Public ReadOnly Property Smartctl As SettingsSmartctl
        Get
            Return _smartctl
        End Get
    End Property
#End Region

#Region "Hidden (to Intellisense) classes"
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsGeneral
        Dim _runMinimized, _hideToTray, _closeToTray, _alwaysDisplayIcon, _confirmOnExit, _rememberWindowSize, _
            _displayInfoPanel, _displaySidePanel, _runWithWindows, _isMaximized As Boolean
        Dim _windowSize As Size
        Dim _sidePanelWitdh, _manageSideMenuWidth, _systemTreeWidth As Integer
        Dim _computerType As Short
        Dim _displayValues As Boolean
        Dim _pointsSize As Short

        Public Property PointsSize As Short
            Get
                Return _pointsSize
            End Get
            Set(value As Short)
                _pointsSize = value
            End Set
        End Property

        Public Property DisplayValues As Boolean
            Get
                Return _displayValues
            End Get
            Set(value As Boolean)
                _displayValues = value
            End Set
        End Property

        Public Property ComputerType As Short
            Get
                Return _computerType
            End Get
            Set(value As Short)
                _computerType = value
            End Set
        End Property

        Public Property IsMaximized As Boolean
            Get
                Return _isMaximized
            End Get
            Set(value As Boolean)
                _isMaximized = value
            End Set
        End Property

        Public Property RunWithWindows As Boolean
            Get
                Return _runWithWindows
            End Get
            Set(value As Boolean)
                _runWithWindows = value
            End Set
        End Property

        Public Property RunMinimized As Boolean
            Get
                Return _runMinimized
            End Get
            Set(value As Boolean)
                _runMinimized = value
            End Set
        End Property

        Public Property HideToTray As Boolean
            Get
                Return _hideToTray
            End Get
            Set(value As Boolean)
                _hideToTray = value
            End Set
        End Property

        Public Property CloseToTray As Boolean
            Get
                Return _closeToTray
            End Get
            Set(value As Boolean)
                _closeToTray = value
            End Set
        End Property

        Public Property AlwaysDisplayTrayIcon As Boolean
            Get
                Return _alwaysDisplayIcon
            End Get
            Set(value As Boolean)
                _alwaysDisplayIcon = value
            End Set
        End Property

        Public Property ConfirmOnExit As Boolean
            Get
                Return _confirmOnExit
            End Get
            Set(value As Boolean)
                _confirmOnExit = value
            End Set
        End Property

        Public Property RememberWindowSize As Boolean
            Get
                Return _rememberWindowSize
            End Get
            Set(value As Boolean)
                _rememberWindowSize = value
            End Set
        End Property

        Public Property WindowSize As Size
            Get
                Return _windowSize
            End Get
            Set(value As Size)
                _windowSize = value
            End Set
        End Property

        Public Property DisplayInfoPanel As Boolean
            Get
                Return _displayInfoPanel
            End Get
            Set(value As Boolean)
                _displayInfoPanel = value
            End Set
        End Property

        Public Property DisplaySidePanel As Boolean
            Get
                Return _displaySidePanel
            End Get
            Set(value As Boolean)
                _displaySidePanel = value
            End Set
        End Property

        Public Property SidePanelWidth As Integer
            Get
                Return _sidePanelWitdh
            End Get
            Set(value As Integer)
                _sidePanelWitdh = value
            End Set
        End Property

        Public Property ManageSideMenuWidth As Integer
            Get
                Return _manageSideMenuWidth
            End Get
            Set(value As Integer)
                _manageSideMenuWidth = value
            End Set
        End Property

        Public Property SystemTreeWidth As Integer
            Get
                Return _systemTreeWidth
            End Get
            Set(value As Integer)
                _systemTreeWidth = value
            End Set
        End Property

        Dim _checkForUpdates, _checkLanguageUpdates As Boolean

        Public Property CheckForUpdates As Boolean
            Get
                Return _checkForUpdates
            End Get
            Set(value As Boolean)
                _checkForUpdates = value
            End Set
        End Property

        Public Property CheckLanguageUpdates As Boolean
            Get
                Return _checkLanguageUpdates
            End Get
            Set(value As Boolean)
                _checkLanguageUpdates = value
            End Set
        End Property

        Dim _fahrenheit, _debug As Boolean

        Public Property TemperatureInFahrenheit As Boolean
            Get
                Return _fahrenheit
            End Get
            Set(value As Boolean)
                _fahrenheit = value
            End Set
        End Property

        Public Property DisplayDebug As Boolean
            Get
                Return _debug
            End Get
            Set(value As Boolean)
                _debug = value
            End Set
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsLanguage
        Dim _automaticTranslation As Boolean
        Dim _preferredLanguage As String

        Public Property AutomaticTranslation As Boolean
            Get
                Return _automaticTranslation
            End Get
            Set(value As Boolean)
                _automaticTranslation = value
            End Set
        End Property

        Public Property PreferredLanguage As String
            Get
                Return _preferredLanguage
            End Get
            Set(value As String)
                _preferredLanguage = value
            End Set
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsDetection
        Dim _csmi, _3ware As Boolean
        Dim _additional As String

        Public Property Csmi As Boolean
            Get
                Return _csmi
            End Get
            Set(value As Boolean)
                _csmi = value
            End Set
        End Property

        Public Property Add3ware As Boolean
            Get
                Return _3ware
            End Get
            Set(value As Boolean)
                _3ware = value
            End Set
        End Property

        Public Property Additional As String
            Get
                Return _additional
            End Get
            Set(value As String)
                _additional = value
            End Set
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsAreca
        Dim _sata As Short
        Dim _sas1 As Short
        Dim _sas2 As Short
        Dim _sas3 As Short
        Dim _sas4 As Short
        Dim _sas5 As Short
        Dim _sas6 As Short
        Dim _sas7 As Short
        Dim _sas8 As Short

        Public Property SataDevices As Short
            Get
                Return _sata
            End Get
            Set(value As Short)
                _sata = value
            End Set
        End Property

        Public Property SasEnclosure1 As Short
            Get
                Return _sas1
            End Get
            Set(value As Short)
                _sas1 = value
            End Set
        End Property

        Public Property SasEnclosure2 As Short
            Get
                Return _sas2
            End Get
            Set(value As Short)
                _sas2 = value
            End Set
        End Property

        Public Property SasEnclosure3 As Short
            Get
                Return _sas3
            End Get
            Set(value As Short)
                _sas3 = value
            End Set
        End Property

        Public Property SasEnclosure4 As Short
            Get
                Return _sas4
            End Get
            Set(value As Short)
                _sas4 = value
            End Set
        End Property

        Public Property SasEnclosure5 As Short
            Get
                Return _sas5
            End Get
            Set(value As Short)
                _sas5 = value
            End Set
        End Property

        Public Property SasEnclosure6 As Short
            Get
                Return _sas6
            End Get
            Set(value As Short)
                _sas6 = value
            End Set
        End Property

        Public Property SasEnclosure7 As Short
            Get
                Return _sas7
            End Get
            Set(value As Short)
                _sas7 = value
            End Set
        End Property

        Public Property SasEnclosure8 As Short
            Get
                Return _sas8
            End Get
            Set(value As Short)
                _sas8 = value
            End Set
        End Property

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsRefresh
        Dim _internal, _external, _virtual As Short

        Public Property Internal As Short
            Get
                Return _internal
            End Get
            Set(value As Short)
                _internal = value
            End Set
        End Property

        Public Property External As Short
            Get
                Return _external
            End Get
            Set(value As Short)
                _external = value
            End Set
        End Property

        Public Property Virtual As Short
            Get
                Return _virtual
            End Get
            Set(value As Short)
                _virtual = value
            End Set
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsVital
        <Flags()> _
        Public Enum Vital
            None = 0
            Track = 1
            Alarm = 2
            Complete = 3
        End Enum

        Dim _temperature, _reallocatedSectors, _spinRetry, _reallocationEvents, _pendingSectors, _offlineUncorrectable, _softReadErrors, _diskShift As Vital
        Dim _indilinx, _intel, _samsung, _micron, _sandForce As Vital

        Public Property Temperature As Vital
            Get
                Return _temperature
            End Get
            Set(value As Vital)
                _temperature = value
            End Set
        End Property

#Region "HDD"
        Public Property ReallocatedSectors As Vital
            Get
                Return _reallocatedSectors
            End Get
            Set(value As Vital)
                _reallocatedSectors = value
            End Set
        End Property

        Public Property SpinRetry As Vital
            Get
                Return _spinRetry
            End Get
            Set(value As Vital)
                _spinRetry = value
            End Set
        End Property

        Public Property ReallocationEvents As Vital
            Get
                Return _reallocationEvents
            End Get
            Set(value As Vital)
                _reallocationEvents = value
            End Set
        End Property

        Public Property PendingSectors As Vital
            Get
                Return _pendingSectors
            End Get
            Set(value As Vital)
                _pendingSectors = value
            End Set
        End Property

        Public Property OfflineUncorrectable As Vital
            Get
                Return _offlineUncorrectable
            End Get
            Set(value As Vital)
                _offlineUncorrectable = value
            End Set
        End Property

        Public Property SoftReadErrors As Vital
            Get
                Return _softReadErrors
            End Get
            Set(value As Vital)
                _softReadErrors = value
            End Set
        End Property

        Public Property DiskShift As Vital
            Get
                Return _diskShift
            End Get
            Set(value As Vital)
                _diskShift = value
            End Set
        End Property
#End Region

#Region "SSD"
        Public Property Indilinx As Vital
            Get
                Return _indilinx
            End Get
            Set(value As Vital)
                _indilinx = value
            End Set
        End Property

        Public Property Intel As Vital
            Get
                Return _intel
            End Get
            Set(value As Vital)
                _intel = value
            End Set
        End Property

        Public Property Samsung As Vital
            Get
                Return _samsung
            End Get
            Set(value As Vital)
                _samsung = value
            End Set
        End Property

        Public Property Micron As Vital
            Get
                Return _micron
            End Get
            Set(value As Vital)
                _micron = value
            End Set
        End Property

        Public Property SandForce As Vital
            Get
                Return _sandForce
            End Get
            Set(value As Vital)
                _sandForce = value
            End Set
        End Property
#End Region

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsWarning

        <Flags()> _
        Enum Triggers
            Never = 0
            Failure = 1
            HighTemp = 2
            Both = 3
        End Enum

        Dim _notify, _mail, _sound, _powerOff As Triggers
        Dim _soundFile As String
        Dim _timeOut As Short
        Dim _force As Boolean

        Public Property Notify As Triggers
            Get
                Return _notify
            End Get
            Set(value As Triggers)
                _notify = value
            End Set
        End Property

        Public Property SendMail As Triggers
            Get
                Return _mail
            End Get
            Set(value As Triggers)
                _mail = value
            End Set
        End Property

        Public Property PlaySound As Triggers
            Get
                Return _sound
            End Get
            Set(value As Triggers)
                _sound = value
            End Set
        End Property

        Public Property PowerOff As Triggers
            Get
                Return _powerOff
            End Get
            Set(value As Triggers)
                _powerOff = value
            End Set
        End Property

        Public Property SoundFile As String
            Get
                Return _soundFile
            End Get
            Set(value As String)
                _soundFile = value
            End Set
        End Property

        Public Property TimeOut As Short
            Get
                Return _timeOut
            End Get
            Set(value As Short)
                _timeOut = value
            End Set
        End Property

        Public Property ForceClose As Boolean
            Get
                Return _force
            End Get
            Set(value As Boolean)
                _force = value
            End Set
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsMail
        Enum MailReport
            None = 0
            Daily = 1
            Weekly = 2
        End Enum

        Dim _login, _password, _smtpServer, _smtpPort As String
        Dim _useSsl As Boolean
        Dim _from, _to, _subject, _body As String
        Dim _report As MailReport
        Dim _time As String
        Dim _day As Short

#Region "Mail server setup"
        Public Property Login As String
            Get
                Return _login
            End Get
            Set(value As String)
                _login = value
            End Set
        End Property

        Public Property Password As String
            Get
                Return _password
            End Get
            Set(value As String)
                _password = value
            End Set
        End Property

        Public Property SmtpServer As String
            Get
                Return _smtpServer
            End Get
            Set(value As String)
                _smtpServer = value
            End Set
        End Property

        Public Property SmtpPort As String
            Get
                Return _smtpPort
            End Get
            Set(value As String)
                _smtpPort = value
            End Set
        End Property

        Public Property UseSsl As Boolean
            Get
                Return _useSsl
            End Get
            Set(value As Boolean)
                _useSsl = value
            End Set
        End Property
#End Region

#Region "Mail setup"
        Public Property Sender As String
            Get
                Return _from
            End Get
            Set(value As String)
                _from = value
            End Set
        End Property

        Public Property Destination As String
            Get
                Return _to
            End Get
            Set(value As String)
                _to = value
            End Set
        End Property

        Public Property Subject As String
            Get
                Return _subject
            End Get
            Set(value As String)
                _subject = value
            End Set
        End Property

        Public Property Body As String
            Get
                Return _body
            End Get
            Set(value As String)
                _body = value
            End Set
        End Property
#End Region

#Region "Triggers"
        Public Property Report As MailReport
            Get
                Return _report
            End Get
            Set(value As MailReport)
                _report = value
            End Set
        End Property

        Public Property ReportTime As String
            Get
                Return _time
            End Get
            Set(value As String)
                _time = value
            End Set
        End Property

        Public Property ReportDay As Short
            Get
                Return _day
            End Get
            Set(value As Short)
                _day = value
            End Set
        End Property
#End Region

    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsReliability
        Dim _enable, _customThreshold As Boolean
        Dim _reallocationEvents, _pendingSectors, _uncorrectable As Short

        Public Property Enable As Boolean
            Get
                Return _enable
            End Get
            Set(value As Boolean)
                _enable = value
            End Set
        End Property

        Public Property CustomThreshold As Boolean
            Get
                Return _customThreshold
            End Get
            Set(value As Boolean)
                _customThreshold = value
            End Set
        End Property

        Public Property ReallocationEvents As Short
            Get
                Return _reallocationEvents
            End Get
            Set(value As Short)
                _reallocationEvents = value
            End Set
        End Property

        Public Property PendingSectors As Short
            Get
                Return _pendingSectors
            End Get
            Set(value As Short)
                _pendingSectors = value
            End Set
        End Property

        Public Property UncorrectableSectors As Short
            Get
                Return _uncorrectable
            End Get
            Set(value As Short)
                _uncorrectable = value
            End Set
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsShare
        Dim _outputFolder, _xmlFolder As String
        Dim _xml As Boolean

        Public Property OutputFolder As String
            Get
                Return _outputFolder
            End Get
            Set(value As String)
                _outputFolder = value
            End Set
        End Property

        Public Property XmlFolder As String
            Get
                Return _xmlFolder
            End Get
            Set(value As String)
                _xmlFolder = value
            End Set
        End Property

        Public Property XmlReport As Boolean
            Get
                Return _xml
            End Get
            Set(value As Boolean)
                _xml = value
            End Set
        End Property
    End Class

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Class SettingsSmartctl
        Enum SmartctlTolerance
            Normal = 0
            Conservative = 1
            VeryPermissive = 2
        End Enum

        Dim _smartctl, _setTolerance, _setPowerMode As Boolean
        Dim _path As String
        Dim _tolerance, _powerMode As String

        Public Property AlternativeVersion As Boolean
            Get
                Return _smartctl
            End Get
            Set(value As Boolean)
                _smartctl = value
            End Set
        End Property

        Public Property ExecutableFolder As String
            Get
                Return _path
            End Get
            Set(value As String)
                _path = value
            End Set
        End Property

        Public Property SetTolerance As Boolean
            Get
                Return _setTolerance
            End Get
            Set(value As Boolean)
                _setTolerance = value
            End Set
        End Property

        Public Property Tolerance As String
            Get
                Return _tolerance
            End Get
            Set(value As String)
                _tolerance = value
            End Set
        End Property

        Public Property SetPowerMode As Boolean
            Get
                Return _setPowerMode
            End Get
            Set(value As Boolean)
                _setPowerMode = value
            End Set
        End Property

        Public Property PowerMode As String
            Get
                Return _powerMode
            End Get
            Set(value As String)
                _powerMode = value
            End Set
        End Property
    End Class
#End Region

End Class
