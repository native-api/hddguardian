'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2016 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Xml

Partial Class Main

    Dim language As New Hashtable
    Dim external_language As New Hashtable
    Dim d_firmware, d_serial As String
    Public m_temperature, m_overallhealth As String
    Public h_overallpassed, h_overallfailed, h_unknown As String
    Dim badsect_no, badsect_few, badsect_several, badsect_one As String
    Dim w_no, w_repunavailabe, w_smartdisabled, w_smartunavailble As String
    Dim e_noerror, e_select, e_noerrorlogging As String
    Dim m_nologfordevice, m_nologforthisday As String
    Dim t_timestamp, t_timestamptxt, t_poweron, t_powerontxt As String
    'Dim l_noselftest, l_noselective As String
    Public m_attributes, m_formats, m_firmware As New Collection
    Public m_yes, m_no As String
    Dim m_available, m_unavailable, m_ambiguous, m_enabled, m_disabled, m_unknown As String
    Dim m_message, m_question As String
    Dim m_smartenabled, m_smartdisabled, m_smartnotsupported, m_smartambiguous, m_qdisablesmart As String
    Dim m_offldataenabled, m_offldatanotsupported, m_offldatadisabled, m_qdisableoffldata, m_unabletodisable As String
    Dim m_alarmdevstatus, m_degradation, m_recovery, m_from, m_to As String
    Dim m_temperaturealarm As String
    Dim m_failuretitle, m_failuretxt As String
    Dim m_exit, m_exitmsg As String
    Dim m_error, m_nodevices, m_nosmartctl As String
    Dim m_aborttitle, m_abortmsg As String
    Dim m_adminrights As String
    Dim m_tip, m_tiptext As String
    Dim m_updateavailable As String
    Public m_dataerror, m_nogooddata As String
    Dim m_testresults As New ResultsList
    Dim m_devicestatus As New DevStatusList
    Dim m_statusdescr As New DevStatusDescr
    Dim m_deviceindex, m_partitions, m_totalsize, m_availablesize As String
    Dim m_serialnumber As String
    Dim m_filesystem, m_numofblocks, m_blocksize, m_type, m_bootable, m_bootpartition, m_primarypartition As String
    Dim m_gathering As String
    Dim m_motherboard, m_processor, m_ram, m_video, m_partition, m_disk As String
    Dim error_no, error_few, error_several, error_one As String
    Dim m_notavailable, m_unabletodetermine As String
    Dim m_reserved, m_vendortime As String
    Public m_reliability As String
    Public m_remaininglife As String
    Dim m_bytes, m_logical, m_physical As String
    Dim m_indatabase, m_notindatabase As String
    Dim m_missadminrights As String
    Public m_healthpassed, m_healthfailed, m_healthunknown As String
    '*** SCSI ***
    Dim m_scsiread, m_scsiwrite, m_scsiverify, m_scsiecc, m_scsifast, m_scsidelayed, m_scsirrrw, m_scsicorrected, m_scsialgorithm, m_scsigb, m_scsiuncorrected As String
    Dim m_scsiresults As New ResultsList
    Dim m_scsidescription As New DevStatusDescr
    Dim m_off As String
    'reliability rating
    Dim hdd_reallevents, hdd_badsectors, hdd_curpending, hdd_offlunc As String
    Dim ssd_intel, ssd_indilinx, ssd_micron, ssd_samsung, ssd_sandforce As String
    'languages
    Public translations As New LanguagesList
    'times
    Public _y, _yy, _m, _mm, _d, _dd, _h, _hh As String

    Public Class ResultsList
        Inherits List(Of Results)
    End Class

    Public Structure Results
        Dim Original, Change As String
        Sub New(ByVal orig As String, ByVal chng As String)
            Original = orig
            Change = chng
        End Sub
    End Structure

    Public Class DevStatusDescr
        Inherits List(Of StatusDescr)
    End Class

    Public Structure StatusDescr
        Dim Original, Change As String
        Sub New(ByVal orig As String, ByVal chng As String)
            Original = orig
            Change = chng
        End Sub
    End Structure

    Public Class DevStatusList
        Inherits List(Of DevStatus)
    End Class

    Public Structure DevStatus
        Dim Original, Change As String
        Sub New(ByVal orig As String, ByVal chng As String)
            Original = orig
            Change = chng
        End Sub
    End Structure

    Public Class LanguagesList
        Inherits List(Of Languages)
    End Class

    Public Structure Languages
        Dim Language, Version, Translator, CultureCode As String
    End Structure

    Private Sub LoadInternalLanguage()
        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmldoc.LoadXml(My.Resources.default_interface)

        m_nodelist = m_xmldoc.SelectNodes("/interface/group")

        With language
            .Clear()
            For Each m_node In m_nodelist
                Dim group As String = m_node.Attributes.GetNamedItem("id").Value

                For i As Short = 0 To m_node.ChildNodes.Count - 1
                    If m_node.ChildNodes(i).Name <> "#comment" Then
                        .Add(group & m_node.ChildNodes(i).Attributes.GetNamedItem("id").Value, _
                             m_node.ChildNodes(i).Attributes.GetNamedItem("text").Value)
                    End If
                Next
            Next
        End With

        With SettingsForm
            .lblVersionValue.Text = My.Application.Info.Version.Major.ToString & "." & _
                                    My.Application.Info.Version.Minor.ToString & "." & _
                                    My.Application.Info.Version.Build.ToString
            .lblTranslatorValue.Text = My.Application.Info.CompanyName
        End With
    End Sub

    Private Sub LoadExternalLanguage(ByRef culture As String)
        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        If IO.File.Exists(culture & "\interface.xml") Then
            Try
                m_xmldoc.Load(culture & "\interface.xml")

                m_nodelist = m_xmldoc.SelectNodes("/interface/group")

                With external_language
                    .Clear()
                    For Each m_node In m_nodelist
                        Dim group As String = m_node.Attributes.GetNamedItem("id").Value

                        For i As Short = 0 To m_node.ChildNodes.Count - 1
                            If m_node.ChildNodes(i).Name <> "#comment" Then
                                .Add(group & m_node.ChildNodes(i).Attributes.GetNamedItem("id").Value, _
                                     m_node.ChildNodes(i).Attributes.GetNamedItem("text").Value)
                            End If
                        Next
                    Next
                End With
            Catch ex As Exception
                PrintDebug("Error while loading language: " & ex.ToString, True)
            End Try

            If IO.File.Exists(culture & "\info.xml") Then
                m_xmldoc.Load(culture & "\info.xml")
                m_nodelist = m_xmldoc.SelectNodes("/info")

                Dim t As String = m_nodelist(0).ChildNodes(1).InnerText
                Dim v As String = m_nodelist(0).ChildNodes(2).InnerText

                With SettingsForm
                    .lblVersionValue.Text = v
                    .lblTranslatorValue.Text = t
                End With
            End If
        End If
    End Sub

    Private Sub FillLanguagesList()
        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList

        'this fill settings language list
        'first, the english...
        With translations
            .Clear()
            Dim ti As Languages

            ti.Language = "English"
            ti.Version = My.Application.Info.Version.Major.ToString & "." & _
                                                  My.Application.Info.Version.Minor.ToString & "." & _
                                                  My.Application.Info.Version.Build.ToString
            ti.Translator = My.Application.Info.CompanyName
            ti.CultureCode = "en"

            .Add(ti)

            'then, all other cultures, if any one exists...
            Dim p As New IO.DirectoryInfo(My.Application.Info.DirectoryPath & "\languages")

            For Each f As IO.DirectoryInfo In p.GetDirectories
                If IO.File.Exists(f.FullName & "\info.xml") Then
                    m_xmldoc.Load(f.FullName & "\info.xml")
                    m_nodelist = m_xmldoc.SelectNodes("/info")

                    Dim l As String = m_nodelist(0).ChildNodes(0).InnerText
                    Dim t As String = m_nodelist(0).ChildNodes(1).InnerText
                    Dim v As String = m_nodelist(0).ChildNodes(2).InnerText

                    With ti
                        .Language = l
                        .Version = v
                        .Translator = t
                        .CultureCode = f.Name
                    End With

                    .Add(ti)
                End If
            Next
        End With

        With SettingsForm.cboLanguage
            .Sorted = False
            .Items.Clear()
            For i As Short = 0 To translations.Count - 1
                .Items.Add(translations(i).Language)
            Next

            If Not AppSettings.Language.AutomaticTranslation Then
                For i As Short = 0 To translations.Count - 1
                    If translations(i).CultureCode = AppSettings.Language.PreferredLanguage Then
                        .SelectedIndex = i
                        Exit For
                    End If
                Next
                With SettingsForm
                    .tlpLanguageInfo.Visible = True
                    .lblTranslatorValue.Text = translations(.cboLanguage.SelectedIndex).Translator
                    .lblVersionValue.Text = translations(.cboLanguage.SelectedIndex).Version
                End With
            End If
        End With
    End Sub

    Private Sub LoadLanguage()
        Dim curculture As String = My.Computer.Info.InstalledUICulture.Name 'it gets, by example, "es-AR"
        Dim languagesfolder As String = My.Application.Info.DirectoryPath & "\languages\"
        Dim cult() As String = curculture.Split("-")
        Dim curculturefolder0 As String = languagesfolder & curculture
        Dim curculturefolder1 As String = languagesfolder & cult(0)

        'load internal (english) interface translation
        LoadInternalLanguage()
        FillLanguagesList()

        If AppSettings.Language.AutomaticTranslation Then
            If FileIO.FileSystem.DirectoryExists(curculturefolder0) Then '[example] check if subfolder named "es-AR" exists
                LoadExternalLanguage(curculturefolder0)
            ElseIf FileIO.FileSystem.DirectoryExists(curculturefolder1) Then '[example] check if subfolder named "es" exists
                LoadExternalLanguage(curculturefolder1)
            End If
        Else
            If FileIO.FileSystem.DirectoryExists(languagesfolder & AppSettings.Language.PreferredLanguage) Then
                LoadExternalLanguage(languagesfolder & AppSettings.Language.PreferredLanguage)
            Else
                'are choosed the english builtin language
                external_language.Clear()
            End If
        End If

        'replace translation strings that exists into the external translation:
        'if external translation is incomplete, are used the strings into the internal translation
        If external_language.Count > 0 Then
            For Each de As DictionaryEntry In external_language
                If de.Value.ToString.Length > 0 Then
                    language(de.Key) = de.Value
                End If
            Next
        End If
    End Sub

    Friend Function GetString(ByVal value As Short) As String
        Dim val As String = String.Format("{0:D4}", value)
        Return language(val).ToString.Replace("\", vbCrLf)
    End Function

    Private Sub InterfaceTranslation()
        LoadLanguage()

        m_temperature = GetString(505)
        m_remaininglife = GetString(506)
        m_overallhealth = GetString(507)

        '***********************************************************************************************************
        '***                                              Main menu                                              ***
        '***********************************************************************************************************
        extOverview.Text = GetString(1)
        extManage.Text = GetString(2)
        extSystem.Text = GetString(3)
        extDebug.Text = GetString(4)
        extPlanner.Text = GetString(5)
        rmFile.Text = GetString(10)
        mnuSettings.Text = GetString(11)
        mnuAbout.Text = GetString(12)
        mnuExit.Text = GetString(13)
        mnuReloadDevices.Text = GetString(14)
        mnuUpdateDatabase.Text = GetString(932)

        ttMain.SetToolTip(picAdmin, GetString(4507))
        picNewVersion.Tag = GetString(4501)

        '******************************************************************************************************************
        '***                                              Devices overview                                              ***
        '******************************************************************************************************************
        With lvwDevices
            .Columns(0).Text = GetString(401)
            '.Columns(1).Text = GetString(402)
            '.Columns(2).Text = GetString(403)
            '.Columns(3).Text = GetString(404)
            '.Columns(4).Text = GetString(405)
            .Groups(0).Tag = GetString(421)
            .Groups(1).Tag = GetString(420)
            .Groups(2).Tag = GetString(422)
        End With

        '**********************
        '*** ribbon buttons ***
        '**********************
        mrbUpdateAll.Text = GetString(102)
        mrbRescanUsb.Text = GetString(105)
        mrbAddVirtual.Text = GetString(103)
        mrcSidePanel.Text = GetString(115)

        '****************************
        '*** devices context menu ***
        '****************************
        mnuRefreshSel.Text = GetString(101)
        mnuRefreshAll.Text = GetString(102)
        mnuSearchUsb.Text = GetString(105)
        mnuAddVirtualDev.Text = GetString(103)
        mnuRemoveVirtualDev.Text = GetString(104)
        mnuTrayIcon.Text = GetString(106)
        mnuTrayTemperature.Text = GetString(107)
        mnuTrayLife.Text = GetString(108)
        mnuSharing.Text = GetString(109)
        mnuShareThis.Text = GetString(110)
        mnuSharingFolder.Text = GetString(111)
        mnuXml.Text = GetString(112)
        mnuXmlCreate.Text = GetString(113)
        mnuXmlFolder.Text = GetString(114)
        mnuInfoPanel.Text = GetString(115)

        '************************************************************************************************************
        '***                                              Side panel                                              ***
        '************************************************************************************************************
        tpGeneral.Text = GetString(701)
        tpHealth.Text = GetString(702)
        'information
        lblInformation.Text = GetString(710)
        lblLocation.Text = GetString(724)
        lblManufacturer.Text = GetString(711)
        lblModel.Text = GetString(712)
        lblSerial.Text = GetString(713)
        exlWwnId.AtaText = GetString(714)
        exlWwnId.ScsiText = GetString(715)
        exlFirmware.AtaText = GetString(716)
        exlFirmware.ScsiText = GetString(717)
        lblSize.Text = GetString(718)
        exlSectorBlock.AtaText = GetString(719)
        exlSectorBlock.ScsiText = GetString(720)
        lblRotationRate.Text = GetString(721)
        lblFactoryForm.Text = GetString(722)
        lblInterface.Text = GetString(723)
        'smart
        lblSmartInfo.Text = GetString(730)
        'smartctl database
        lblDatabaseInfo.Text = GetString(740)
        m_indatabase = GetString(742)
        m_notindatabase = GetString(741)
        'warnings
        lblWarnings.Text = GetString(750)
        'summary
        lblSummary.Text = GetString(760)
        lblTemp.Text = GetString(761)
        lblRemainingLife.Text = GetString(762)
        lblLastTest.Text = GetString(763)
        lblHealth.Text = GetString(764)
        exlBadSectors.AtaText = GetString(765)
        exlBadSectors.ScsiText = GetString(766)
        exlErrors.AtaText = GetString(767)
        exlErrors.ScsiText = GetString(768)
        lblWorkTime.Text = GetString(769)
        lblLastUpdate.Text = GetString(770)
        'realiability
        lblReliabilityRating.Text = GetString(780)
        hdd_reallevents = GetString(783)
        hdd_curpending = GetString(784)
        hdd_offlunc = GetString(785)
        hdd_badsectors = GetString(782)
        'SSD
        ssd_indilinx = GetString(3920)
        ssd_intel = GetString(3921)
        ssd_micron = GetString(3922)
        ssd_samsung = GetString(3923)
        ssd_sandforce = GetString(3924)
        lblOverall.Text = GetString(786)
        _y = GetString(517)
        _yy = GetString(518)
        _m = GetString(519)
        _mm = GetString(520)
        _d = GetString(521)
        _dd = GetString(522)
        _h = GetString(523)
        _hh = GetString(524)

        '***********************************************************************************************************
        '***                                              Tray icon                                              ***
        '***********************************************************************************************************
        mnuRestoreTray.Text = GetString(201)
        mnuExitTray.Text = GetString(202)

        '********************************************************************************************************
        '***                                              Manage                                              ***
        '********************************************************************************************************
        'select device
        'lblSelDevice.Text = GetString(350)
        'device informations
        'robHealth.Text = GetString(301)
        'robInfo.Text = GetString(302)
        mrrAttributes.Text = GetString(303)
        mrrEvents.Text = GetString(307)
        mrrTemperatures.Text = GetString(306)
        'device setup
        mrrSmartSetup.Text = GetString(310)
        mrrAam.Text = GetString(311)
        mrrApm.Text = GetString(312)
        mrrStandby.Text = GetString(313)
        mrrReadWrite.Text = GetString(314)
        'device logs and run test
        mrrErrorsLog.Text = GetString(320)
        mrrTestsLog.Text = GetString(321)
        mrrRunTest.Text = GetString(322)
        'smartctl
        mrrOutput.Text = GetString(330)
        mrrAdvanced.Text = GetString(335)
        mrrSmartctl.Text = GetString(323)
        'sections labels
        lblInfo.Text = GetString(340)
        lblSetup.Text = GetString(341)
        lblErrorsTests.Text = GetString(342)
        lblSmartctl.Text = GetString(343)

        '*******************************************************************************************************
        '***                                              Debug                                              ***
        '*******************************************************************************************************
        mrbDebugSave.Text = GetString(601)
        chLogDate.Text = GetString(602)
        chEvent.Text = GetString(603)
        mrbDebugClean.Text = GetString(604)

        '**************************************************************************************************************
        '***                                              Test planner                                              ***
        '**************************************************************************************************************
        mrbTaskNew.Text = GetString(6001)
        mrbTaskEdit.Text = GetString(6002)
        mrbTaskDelete.Text = GetString(6003)
        mrbTaskTrash.Text = GetString(6004)
        chDevice.Text = GetString(6010)
        chTest.Text = GetString(6011)
        chTask.Text = GetString(6012)
        mnuTaskNew.Text = GetString(6001)
        mnuTaskEdit.Text = GetString(6002)
        mnuTaskDelete.Text = GetString(6003)
        mnuTaskTrash.Text = GetString(6004)

        '***********************************************************************************************************
        '***                                              SATA/PATA                                              ***
        '***********************************************************************************************************

        '*******************
        '*** device info ***
        '*******************
        h_overallpassed = GetString(970)
        h_overallfailed = GetString(971)
        h_unknown = GetString(972)

        badsect_no = GetString(980)
        badsect_few = GetString(983)
        badsect_several = GetString(982)
        badsect_one = GetString(981)

        error_no = GetString(990)
        error_few = GetString(993)
        'error_several = GetString(992)
        error_one = GetString(991)

        w_no = GetString(934)
        w_repunavailabe = GetString(935)
        w_smartdisabled = GetString(936)
        w_smartunavailble = GetString(937)

        'other strings
        m_bytes = GetString(4801)
        m_logical = GetString(4802)
        m_physical = GetString(4803)

        m_available = GetString(4804)
        m_unavailable = GetString(4805)
        m_ambiguous = GetString(4806)
        m_enabled = GetString(4807)
        m_disabled = GetString(4808)
        m_unknown = GetString(4809)

        '*********************
        '*** device health ***
        '*********************

        'device test results: here are loaded the text that change the default smartctl english output
        With m_testresults
            .Clear()
            .Add(New Results("Completed without error", GetString(950)))
            .Add(New Results("Aborted by host", GetString(951)))
            .Add(New Results("Interrupted (host reset)", GetString(952)))
            .Add(New Results("Fatal or unknown error", GetString(953)))
            .Add(New Results("Completed: unknown failure", GetString(954)))
            .Add(New Results("Completed: electrical failure", GetString(955)))
            .Add(New Results("Completed: servo/seek failure", GetString(956)))
            .Add(New Results("Completed: read failure", GetString(957)))
            .Add(New Results("Completed: handling damage", GetString(958)))
            .Add(New Results("Self-test routine in progress", GetString(959)))
            .Add(New Results("Unknown status", GetString(960)))
            .Add(New Results("---", GetString(961)))
        End With

        '***************************
        '*** reliability details ***
        '***************************
        'HDD
        lblReliabilityRating.Text = GetString(938)
        

        '********************
        '*** temperatures ***
        '********************
        lblCurrentTemp.Text = GetString(801)
        lblMin.Text = GetString(802)
        lblMax.Text = GetString(803)
        lblCycle.Text = GetString(804)
        lblLifeTime.Text = GetString(805)
        lblRecommended.Text = GetString(806)
        lblLimit.Text = GetString(807)
        lblTempMeans.Text = GetString(820)
        lblCycleMeans.Text = GetString(804)
        lblCycleValue.Text = GetString(821)
        lblLifeTimeMean.Text = GetString(805)
        lblLifeTimeValue.Text = GetString(822)
        lblRecommendedMean.Text = GetString(806)
        lblRecommendedValue.Text = GetString(823)
        lblLimitMean.Text = GetString(807)
        lblLimitValue.Text = GetString(824)

        '*******************
        '*** SMART setup ***
        '*******************
        lblAdminSmart.Text = GetString(5131)
        chkEnableSmart.Text = GetString(1001)
        lblSmart.Text = GetString(1002)
        chkEnableOffline.Text = GetString(1003)
        lblOfflineTest.Text = GetString(1004)
        chkEnableAutosave.Text = GetString(1005)
        lblAttrAutosave.Text = GetString(1006)

        m_message = GetString(1030)
        m_question = GetString(1031)

        m_smartenabled = GetString(1040)
        m_smartambiguous = GetString(1041)
        m_smartnotsupported = GetString(1042)
        m_qdisablesmart = GetString(1043)
        m_smartdisabled = GetString(1044)
        m_offldataenabled = GetString(1045)
        m_offldatanotsupported = GetString(1046)
        m_qdisableoffldata = GetString(1047)
        m_offldatadisabled = GetString(1048)
        m_unabletodisable = GetString(1049)

        '***********
        '*** AAM ***
        '***********
        lblInfoAam.Text = GetString(1101) & vbCrLf & vbCrLf & GetString(5131)
        lblQuiet.Text = GetString(1102)
        lblLoudest.Text = GetString(1103)
        lblAamValue.Tag = GetString(1108)
        lnkSetAam.Text = GetString(1204)
        lnkSetRecommended.Text = GetString(1104)
        lblAamRecommended.Tag = GetString(1105)
        lnkUndoAam.Text = GetString(1107)

        '***********
        '*** APM ***
        '***********
        lblInfoApm.Text = GetString(1201) & vbCrLf & vbCrLf & GetString(5131)
        lblApmValue.Tag = GetString(1203)
        lnkSetApm.Text = GetString(1204)
        lnkUndoApm.Text = GetString(1206)

        'common strings
        m_notavailable = GetString(1202)
        m_unabletodetermine = GetString(1109)

        '***************
        '*** standby ***
        '***************
        lblInfoStandby.Text = GetString(1301) & vbCrLf & vbCrLf & GetString(5131)
        lblStandbyValue.Tag = GetString(1108)
        lnkSetStandby.Text = GetString(1305)
        lnkUndoStandby.Text = GetString(1306)
        m_reserved = GetString(1302)
        m_vendortime = GetString(1303)
        m_off = GetString(1304)

        '***************************
        '*** read/writes options ***
        '***************************
        chkCache.Text = GetString(1401)
        lblCacheInfo.Text = GetString(1402)
        chkLookAhead.Text = GetString(1403)
        lblLookAheadInfo.Text = GetString(1404)
        chkCacheReorder.Text = GetString(1405)
        lblCacheReorderInfo.Text = GetString(1406)

        '******************************
        '*** SMART attributes table ***
        '******************************
        'attributes table
        lblDataStructure.Tag = GetString(1502) & ": "
        chStatus.Text = ""
        chID.Text = GetString(1510)
        chAttribute.Text = GetString(1511)
        chCurrent.Text = GetString(1512)
        chWorst.Text = GetString(1513)
        chThreshold.Text = GetString(1514)
        chRawValue.Text = GetString(1515)
        'attribute description
        'flags
        lblFlags.Text = GetString(1530)
        lblPrefailure.Text = GetString(1531)
        lblOnline.Text = GetString(1532)
        lblSpeed.Text = GetString(1533)
        lblErrRate.Text = GetString(1534)
        lblEvCount.Text = GetString(1535)
        lblSelfPres.Text = GetString(1536)
        'graph
        lblGraph.Text = GetString(1540)
        lblThreshold.Text = GetString(1514)
        lblCurValue.Text = GetString(1512)
        lblWorst.Text = GetString(1513)

        '**************
        '*** errors ***
        '**************
        lblErrLogVer.Tag = GetString(1603) & ": "
        lblPowerOn.Tag = GetString(1610) & ": " 'text is put into the tag because we have to display the error #
        lblDeviceStatus.Tag = GetString(1611)
        lblRegisters.Text = GetString(1612) & ":"
        lblCommands.Text = GetString(1613) & ":"

        e_noerror = GetString(1601)
        e_select = GetString(1602)
        e_noerrorlogging = GetString(1604)

        t_timestamp = GetString(1630)
        t_timestamptxt = GetString(1631)
        t_poweron = GetString(1632)
        t_powerontxt = GetString(1633)
        'device status: here are loaded the text that change the default smartctl english output
        With m_devicestatus
            .Clear()
            .Add(New DevStatus("in an unknown state", GetString(1620)))
            .Add(New DevStatus("sleeping", GetString(1621)))
            .Add(New DevStatus("in standby mode", GetString(1622)))
            .Add(New DevStatus("active or idle", GetString(1623)))
            .Add(New DevStatus("doing SMART Offline or Self-test", GetString(1624)))
            .Add(New DevStatus("in a reserved state", GetString(1625)))
            .Add(New DevStatus("in a vendor specific state", GetString(1626)))
        End With

        tpErrorDescription.Text = GetString(1605)
        tpErrorDetail.Text = GetString(1606)

        lblErrorNumber.Text = GetString(1660)
        lblErrorDescription.Text = GetString(1663)
        lblErrorSectors.Text = GetString(1664)
        lblErrorLba.Text = GetString(1665)
        lblErrorStatus.Text = GetString(1666)

        '**************************
        '*** self tests results ***
        '**************************
        With m_statusdescr
            .Clear()
            .Add(New StatusDescr("Short offline", GetString(1731)))
            .Add(New StatusDescr("Extended offline", GetString(1732)))
            .Add(New StatusDescr("Conveyance offline", GetString(1733)))
            .Add(New StatusDescr("Abort offline test", GetString(1734)))
            .Add(New StatusDescr("Short captive", GetString(1735)))
            .Add(New StatusDescr("Extended captive", GetString(1736)))
            .Add(New StatusDescr("Conveyance captive", GetString(1737)))
            .Add(New StatusDescr("Selective captive", GetString(1738)))
            .Add(New StatusDescr("Not testing", GetString(1739)))
        End With

        'self tests
        lblSelfTests.Tag = GetString(1710)
        chNum.Text = GetString(1711)
        chTestType.Text = GetString(1712)
        chTestStatus.Text = GetString(1713)
        chRemaining.Text = GetString(1714)
        chAge.Text = GetString(1717)
        chFirstError.Text = GetString(1716)

        '****************
        '*** run test ***
        '****************
        lblInfoTest.Text = GetString(1801) & vbCrLf & vbCrLf & GetString(5131)
        lblOfflineDuration.Tag = GetString(1808) & ": "
        lblShortDuration.Tag = GetString(1808) & ": "
        lblLongDuration.Tag = GetString(1808) & ": "
        lblConveyanceDuration.Tag = GetString(1808) & ": "
        'offline test
        optOffline.Text = GetString(1802)
        lblOfflineInfo.Text = GetString(1823)
        'short self test
        optShort.Text = GetString(1803)
        lblShortInfo.Text = GetString(1820)
        'extended self test
        optLong.Text = GetString(1804)
        lblLongInfo.Text = GetString(1821)
        'conveyance self test
        optConveyance.Text = GetString(1805)
        lblConveyanceInfo.Text = GetString(1822)

        btnRun.Text = GetString(1806)
        btnStop.Text = GetString(1807)
        lblExtimatedEnd.Tag = GetString(1811) & ": "
        m_aborttitle = GetString(1830)
        m_abortmsg = GetString(1831)

        '**********************************
        '*** advanced setup of smartctl ***
        '**********************************
        lblAdminAdvanced.Text = GetString(5130)

        '*************************
        '*** attributes format ***
        '*************************
        tpRemap.Text = GetString(332)
        chkAttributes.Text = GetString(2001)

        btnAdd.Text = GetString(2006)
        chAttrID.Text = GetString(2007)
        chAttrFormat.Text = GetString(2008)
        chAttrName.Text = GetString(2009)
        btnRemove.Text = GetString(2010)
        lblRemapInfo.Text = GetString(2020)

        With AddCustomAttribute
            .Text = GetString(2011)
            .lblID.Text = GetString(2003) & ":"
            .lblFormat.Text = GetString(2004) & ":"
            .lblName.Text = GetString(2005) & ":"
            .btnAdd.Text = GetString(2006)
            .btnCancel.Text = GetString(2012)

            'populate Formats, ID and attributes comboboxes
            m_formats.Clear()
            For i As Short = 0 To 13
                m_formats.Add(GetString(2050 + i))
            Next
            With .cboFormat
                With .Items
                    .Clear()
                    .Add("") '0
                    .Add("raw8") '1
                    .Add("raw16") '2
                    .Add("raw16(avg16)") '3
                    .Add("raw16(raw16)") '4
                    .Add("raw24/raw24") '5
                    .Add("raw48") '6
                    .Add("raw64") '7
                    .Add("hex48") '8
                    .Add("hex64") '9
                    .Add("min2hour") '10
                    .Add("sec2hour") '11
                    .Add("halfmin2hour") '12
                    .Add("tempminmax") '13
                    .Add("temp10x") '14
                End With
                .SelectedIndex = 0
            End With

            With .cboID
                With .Items
                    .Clear()
                    .Add("")
                    .Add("N")
                    For i As Short = 1 To 255
                        .Add(i)
                    Next
                End With
                .SelectedIndex = 0
            End With
            m_attributes.Clear()
            For i As Short = 0 To 13
                m_attributes.Add(GetString(2030 + i))
            Next
            With .cboAttributes
                With .Items()
                    .Clear()
                    .Add(GetString(2002)) '0
                    .Add("9: " & GetString(2070))
                    .Add("9: " & GetString(2071))
                    .Add("9: " & GetString(2072))
                    .Add("9: " & GetString(2073))
                    .Add("192: " & GetString(2074) & " (Fujitsu)")
                    .Add("193: " & GetString(2075))
                    .Add("194: " & GetString(2076))
                    .Add("194: " & GetString(2077))
                    .Add("197: " & GetString(2078))
                    .Add("198: " & GetString(2079))
                    .Add("198: " & GetString(2080) & " (Fujitsu)")
                    .Add("200: " & GetString(2081))
                    .Add("201: " & GetString(2082))
                    .Add("220: " & GetString(2073)) '14
                End With
                .SelectedIndex = 0
            End With
        End With

        '**********************
        '*** firmware debug ***
        '**********************
        tpFirmware.Text = GetString(333)
        chkFirmware.Text = GetString(2101)
        m_firmware.Clear()
        For i As Short = 0 To 3
            m_firmware.Add(GetString(2120 + i))
        Next
        With cboFirmware
            With .Items
                .Clear()
                .Add(GetString(2102))
                .Add("Samsung")
                .Add("Samsung2")
                .Add("Samsung3")
            End With
            .SelectedIndex = 0
        End With
        chkFixSwap.Text = GetString(2103)
        chkNoLogDir.Text = GetString(2104)
        chkXErrorLba.Text = GetString(2105)
        lblFixSwap.Text = GetString(2124)
        lblNoLogDir.Text = GetString(2125)
        lblXErrorLba.Text = GetString(2126)
        lblFirmwareDebugInfo.Text = GetString(2110)

        '************************
        '*** power mode check ***
        '************************
        tpPower.Text = GetString(334)
        lblPowerInfo.Text = GetString(2201)
        chkPowerMode.Text = GetString(2202)
        rbNever.Text = GetString(2203)
        lblNever.Text = GetString(2204)
        rbSleep.Text = GetString(2205)
        lblSleep.Text = GetString(2206)
        rbStandby.Text = GetString(2207)
        lblStandby.Text = GetString(2208)
        rbIdle.Text = GetString(2209)
        lblIdle.Text = GetString(2210)

        '*********************
        '*** ASMedia dedug ***
        '*********************
        tpAsmedia.Text = GetString(336)
        lblAsmedia.Text = GetString(2801)
        chkAsmedia.Text = GetString(2802)

        '******************************************************************************************************
        '***                                              SCSI                                              ***
        '******************************************************************************************************

        '*******************
        '*** SMART setup ***
        '*******************
        lblAdminScsiSmart.Text = GetString(5131)
        chkScsiSmart.Text = GetString(1001)
        lblScsiSmart.Text = GetString(1002)
        chkScsiGltsd.Text = GetString(2401)
        lblScsiGltsd.Text = GetString(2402)
        chkScsiWCache.Text = GetString(2403)
        lblScsiWCache.Text = GetString(2404)
        chkScsiRCache.Text = GetString(2405)
        lblScsiRCache.Text = GetString(2406)

        '**************
        '*** errors ***
        '**************
        lblScsiNoErrors.Text = GetString(2501)

        m_scsiread = GetString(2502)
        m_scsiwrite = GetString(2503)
        m_scsiverify = GetString(2504)
        m_scsiecc = GetString(2505)
        m_scsifast = GetString(2506)
        m_scsidelayed = GetString(2507)
        m_scsirrrw = GetString(2508)
        m_scsicorrected = GetString(2509)
        m_scsialgorithm = GetString(2510)
        m_scsigb = GetString(2511)
        m_scsiuncorrected = GetString(2512)

        '********************
        '*** test results ***
        '********************
        lblScsiTestCounter.Text = GetString(2601)
        chScsiNum.Text = GetString(2602)
        chScsiTest.Text = GetString(2603)
        chScsiStatus.Text = GetString(2604)
        chScsiSegment.Text = GetString(2605)
        chScsiLifetime.Text = GetString(2606)
        chScsiFirstErr.Text = GetString(2607)
        chScsiSK.Text = "SK"
        chScsiASK.Text = "ASK"
        chScsiASQ.Text = "ASQ"

        With m_scsidescription
            .Clear()
            .Add(New StatusDescr("Default", GetString("2660")))
            .Add(New StatusDescr("Background short", GetString("2661")))
            .Add(New StatusDescr("Background long", GetString("2662")))
            .Add(New StatusDescr("Reserved", GetString("2663") & " "))
            .Add(New StatusDescr("Abort background", GetString("2664")))
            .Add(New StatusDescr("Foreground short", GetString("2665")))
            .Add(New StatusDescr("Foreground long", GetString("2666")))
        End With

        With m_scsiresults
            .Clear()
            .Add(New Results("Completed", GetString(2650)))
            .Add(New Results("Aborted (by user command)", GetString(2651)))
            .Add(New Results("Aborted (device reset ?)", GetString(2652)))
            .Add(New Results("Unknown error, incomplete", GetString(2653)))
            .Add(New Results("Completed, segment failed", GetString(2654)))
            .Add(New Results("Failed in first segment", GetString(2655)))
            .Add(New Results("Failed in second segment", GetString(2656)))
            .Add(New Results("Failed in segment", GetString(2657)))
            .Add(New Results("Reserved", GetString(2658)))
            .Add(New Results("Self test in progress", GetString(2659)))
        End With

        '****************
        '*** run test ***
        '****************
        lblScsiInfoTest.Text = GetString(1801) & vbCrLf & vbCrLf & GetString(5131)
        lblScsiTest.Tag = GetString(2701)
        btnScsiRun.Text = GetString(1806)
        btnScsiStop.Text = GetString(1807)
        lblScsiExtimatedEnd.Tag = GetString(1808)

        '***********************************************************************************************************************
        '***                                              Devices common panels                                              ***
        '***********************************************************************************************************************

        '**************
        '*** events ***
        '**************
        lblNoEvents.Text = GetString(3008)
        chAttrLog.Text = GetString(3041)
        chTotalEvents.Text = GetString(3042)
        btnReload.Text = GetString(3006)
        btnExport.Text = GetString(3007)
        tpLogEvents.Text = GetString(3010)
        chDate.Text = GetString(3002)
        chFrom.Text = GetString(3003)
        chTo.Text = GetString(3004)
        chVariation.Text = GetString(3005)
        mnuCopyLog.Text = GetString(3011)
        mnuCopyAllLog.Text = GetString(3012)
        tpLogChart.Text = GetString(3020)
        chrChart.Tag = GetString(3021)
        lblDisplay.Text = GetString(3030)
        optEntire.Text = GetString(3031)
        optSelection.Text = GetString(3032)
        lblNoPeriodEvents.Text = GetString(3009)
        chkChartValues.Text = GetString(3022)
        lblPointSize.Text = GetString(3023)

        ttMain.SetToolTip(mrbReloadDevice, GetString(3006))

        '***********************
        '*** smartctl output ***
        '***********************
        btnSaveOutput.Text = GetString(3101)

        '*****************************************************************************************************************
        '***                                              Windows devices                                              ***
        '*****************************************************************************************************************
        lblLoadWmi.Text = GetString(3213)
        mrbRefresh.Text = GetString(101)
        m_deviceindex = GetString(3201)
        m_partitions = GetString(3202)
        m_totalsize = GetString(3203)
        m_availablesize = GetString(3204)
        m_serialnumber = GetString(3205)
        m_filesystem = GetString(3206)
        m_numofblocks = GetString(3207)
        m_blocksize = GetString(3208)
        m_type = GetString(3209)
        m_bootable = GetString(3210)
        m_bootpartition = GetString(3211)
        m_primarypartition = GetString(3212)
        m_gathering = GetString(3213)
        m_motherboard = GetString(3214)
        m_processor = GetString(3215)
        m_ram = GetString(3216)
        m_video = GetString(3217)
        m_disk = GetString(3218)
        m_partition = GetString(3219)
        m_yes = GetString(3220)
        m_no = GetString(3221)

        mnuProfessional.Text = GetString(3231)
        mnuGamer.Text = GetString(3232)
        mnuLaptop.Text = GetString(3233)

        '**********************************************************************************************************
        '***                                              Settings                                              ***
        '**********************************************************************************************************
        'window title
        SettingsForm.Text = GetString(11)

        '**********************
        '*** left side menu ***
        '**********************
        With SettingsForm
            .mrrGeneral.Text = GetString(3301)
            .mrrDetection.Text = GetString(3302)
            .mrrControllers.Text = GetString(3313)
            .mrrTranslation.Text = GetString(3305)
            .mrrMail.Text = GetString(3314)
            .mrrUpdate.Text = GetString(3306)
            .mrrMonitoring.Text = GetString(3315)
            .mrrWarnings.Text = GetString(3316)
            .mrrShare.Text = GetString(3309)
            .mrrRating.Text = GetString(3310)
            .lblSmartctl.Text = GetString(343)
            .mrrTolerance.Text = GetString(331)
            .mrrSmartctl.Text = GetString(3312)
            .btnImport.Text = GetString(3331)
            .btnExport.Text = GetString(3330)
        End With

        '************************
        '*** general settings ***
        '************************
        With SettingsForm
            .lblGeneralTitle.Text = GetString(3301)
            'startup
            .lblStartup.Text = GetString(3420)
            .chkStartupLink.Text = GetString(3401)
            .chkRunMinimized.Text = GetString(3402)
            'behaviour
            .lblBehaviour.Text = GetString(3421)
            .chkMinimizeInTray.Text = GetString(3403)
            .chkCloseOnTray.Text = GetString(3404)
            .chkAlwaysShowTray.Text = GetString(3405)
            .chkConfirmExit.Text = GetString(3406)
            .chkRememberSize.Text = GetString(3409)
            .chkInfoPanel.Text = GetString(3411)
            'updates
            .lblUpdates.Text = GetString(3422)
            .chkUpdates.Text = GetString(3407)
            .chkLanguageUpdates.Text = GetString(3412)
            'temperatures
            .lblFahrenheit.Text = GetString(3423)
            .chkFahrenheit.Text = GetString(3408)
            'debug
            .lblDebug.Text = GetString(3424)
            .chkDebug.Text = GetString(3410)
        End With

        '************************
        '*** device detection ***
        '************************
        With SettingsForm
            .lblDetectionTitle.Text = GetString(3302)
            .chkCsmi.Text = GetString(3503)
            .lblNeedRestart.Text = GetString(3504)
            .chk3ware.Text = GetString(3505)
            .lblAdditional.Text = GetString(3510)
            .lblAdditionalInfo.Text = GetString(3511)
            .lnkAdditional.Text = GetString(3512)
        End With

        '*******************
        '*** mail alerts ***
        '*******************
        With SettingsForm
            .lblMailAlertsTitle.Text = GetString(3314)

            'panels
            .tpMailServer.Text = GetString(3770)
            .tpMail.Text = GetString(3771)
            .tpTriggers.Text = GetString(3750)

            'mail setup
            .lblCustomMail.Text = GetString(3731)
            .lblMailPassword.Text = GetString(3732)
            .lblSmtp.Text = GetString(3733)
            .lblPort.Text = GetString(3734)
            .chkSsl.Text = GetString(3739)
            .lnkTestMail.Text = GetString(3703)
            .lblFrom.Text = GetString(3736)
            .lblTo.Text = GetString(3737)
            .lblProvider.Text = GetString(3738)

            With .cboProviders.Items
                .Clear()
                .Add(GetString(3780))
                .Add("Google")
                .Add("Microsoft")
                .Add("Yahoo")
            End With

            'optional message
            .lblMailSubject.Text = GetString(3760)
            .lblMailContent.Text = GetString(3761)

            'report
            .rbNoReport.Text = GetString(3751)
            .rbDaily.Text = GetString(3752)
            .rbWeekly.Text = GetString(3753)
            'add days names to combobox
            .cboDays.Items.Clear()
            For i As Short = 1 To 7
                .cboDays.Items.Add(WeekdayName(i))
            Next
            .cboDays.SelectedIndex = AppSettings.Mail.ReportDay
            .nlSendReport.Text = GetString(3754)
        End With

        '********************
        '*** translations ***
        '********************
        With SettingsForm
            .lblTranslationTitle.Text = GetString(3305)
            .optAutomatic.Text = GetString(4301)
            .optCustom.Text = GetString(4302)
            .lblLanguageInfo.Text = GetString(4306)
            .lblVersion.Text = GetString(4304) & ":"
            .lblTranslator.Text = GetString(4305) & ":"
        End With

        '**********************
        '*** devices update ***
        '**********************
        With SettingsForm
            .lblUpdateTitle.Text = GetString(3306)
            .lblUpdate.Text = GetString(3801)
            .lblInternal.Text = GetString(421) & ":"
            .lblExternal.Text = GetString(420) & ":"
            .lblVirtual.Text = GetString(422) & ":"
            .lblMinutes.Text = GetString(3802)
            .lblMinutesExt.Text = GetString(3802)
            .lblMinutesVirt.Text = GetString(3802)
        End With

        '******************
        '*** monitoring ***
        '******************
        With SettingsForm
            .lblMonitoringTitle.Text = GetString(3315)
            'generic parameters
            .lblGeneric.Text = GetString(3908)
            .lblVitalTemp.Text = GetString(3912)
            'hard disk drives
            .lblHdd.Text = GetString(3902)
            .lblReallSectCt.Text = GetString(3910)
            .lblSpinRetryCt.Text = GetString(3911)
            .lblReallEvCt.Text = GetString(3913)
            .lblCurPenSect.Text = GetString(3914)
            .lblOfflUnc.Text = GetString(3915)
            .lblSoftReadErr.Text = GetString(3916)
            .lblDiskShift.Text = GetString(3917)
            'solid state devices
            .lblSsd.Text = GetString(3907)
            .lblIndilinx.Text = GetString(3920) & " (Indilinx)"
            .lblIntel.Text = GetString(3921) & " (Intel)"
            .lblMicron.Text = GetString(3922) & " (Micron)"
            .lblSamsung.Text = GetString(3923) & " (Samsung)"
            .lblSandForce.Text = GetString(3924) & " (SandForce)"

            For Each c In .tlpActions.Controls
                If c.GetType.Name = "ComboBox" Then
                    c.Items.Clear()
                    c.Sorted = False
                    c.Items.Add(GetString(3940))
                    c.Items.Add(GetString(3941))
                    c.Items.Add(GetString(3942))
                    c.Items.Add(GetString(3943))
                End If
            Next
            .cboTemp.SelectedIndex = AppSettings.VitalParameters.Temperature
            .cboReallSectCt.SelectedIndex = AppSettings.VitalParameters.ReallocatedSectors
            .cboSpinRetryCt.SelectedIndex = AppSettings.VitalParameters.SpinRetry
            .cboReallEvCt.SelectedIndex = AppSettings.VitalParameters.ReallocationEvents
            .cboCurPenSect.SelectedIndex = AppSettings.VitalParameters.PendingSectors
            .cboOfflUnc.SelectedIndex = AppSettings.VitalParameters.OfflineUncorrectable
            .cboSoftReadErr.SelectedIndex = AppSettings.VitalParameters.SoftReadErrors
            .cboDiskShift.SelectedIndex = AppSettings.VitalParameters.DiskShift
            .cboIndilinx.SelectedIndex = AppSettings.VitalParameters.Indilinx
            .cboIntel.SelectedIndex = AppSettings.VitalParameters.Intel
            .cboMicron.SelectedIndex = AppSettings.VitalParameters.Micron
            .cboSamsung.SelectedIndex = AppSettings.VitalParameters.Samsung
            .cboSandForce.SelectedIndex = AppSettings.VitalParameters.SandForce

        End With

        '****************
        '*** warnings ***
        '****************
        With SettingsForm
            .lblWarningsTitle.Text = GetString(3316)
            .lblPopUp.Text = GetString(4002)
            .lblSendMail.Text = GetString(4010)
            .lnkMailSetup.Text = GetString(4011)
            .lblPlaySound.Text = GetString(4020)
            .lnkBrowse.Text = GetString(4021)
            .lnkPlay.Text = GetString(4022)
            .lblPowerOff.Text = GetString(4030)
            .lblTimeout.Text = GetString(4031)
            .lnkTimeout.Text = GetString(4032)
            .chkForce.Text = GetString(4033)
            .lblForce.Text = GetString(4034)

            For Each c In .tlpNotifications.Controls
                If c.GetType.Name = "ComboBox" Then
                    c.Items.Clear()
                    c.Sorted = False
                    c.Items.Add(GetString(4040))
                    c.Items.Add(GetString(4041))
                    c.Items.Add(GetString(4042))
                    c.Items.Add(GetString(4043))
                End If
            Next
            .cboPopUp.SelectedIndex = AppSettings.Warnings.Notify
            .cboSendMail.SelectedIndex = AppSettings.Warnings.SendMail
            .cboPlaySound.SelectedIndex = AppSettings.Warnings.PlaySound
            .cboPowerOff.SelectedIndex = AppSettings.Warnings.PowerOff
        End With

        '**********************
        '*** output sharing ***
        '**********************
        With SettingsForm
            .lblShareTitle.Text = GetString(3309)
            'smartctl output
            .lblSharing.Text = GetString(4120)
            .lblSelFolder.Text = GetString(4101)
            .btnBrwsFolder.Text = GetString(4102)
            .lblFolder.Tag = GetString(4103)
            'xml report
            .lblXmlCreate.Text = GetString(4121)
            .lblXml.Text = GetString(4110)
            .chkXml.Text = GetString(4111)
            .btnXml.Text = GetString(4102)
            .lblXmlPath.Tag = GetString(4103)
        End With

        '*********************
        '*** device rating ***
        '*********************
        With SettingsForm
            .lblRatingTitle.Text = GetString(3310)
            .chkRating.Text = GetString(4201)
            .chkTuneUp.Text = GetString(4202)
            Dim reset As String = GetString(4203)
            .lnkResetCurPending.Text = reset
            .lnkResetReall.Text = reset
            .lnkResetOfflUnc.Text = reset
            .lblReallTune.Text = hdd_reallevents & ":"
            .lblCurPendTune.Text = hdd_curpending & ":"
            .lblOfflUncTune.Text = hdd_offlunc & ":"
        End With
        m_reliability = GetString(3310) & ": "

        '**************************
        '*** smartctl tolerance ***
        '**************************
        With SettingsForm
            .lblToleranceTitle.Text = GetString(331)
            .chkTolerance.Text = GetString(1901)
            .rbNormal.Text = GetString(1902)
            .rbConservative.Text = GetString(1903)
            .rbVeryPermissive.Text = GetString(1904)
            .lblNormal.Text = GetString(1920)
            .lblConservative.Text = GetString(1921)
            .lblVeryPermissive.Text = GetString(1922)
            .lblInfoTolerance.Text = GetString(1910) & vbCrLf & vbCrLf & GetString(5131)
        End With

        '************************
        '*** RAID controllers ***
        '************************
        With SettingsForm
            .lblControllers.Text = GetString(3313)
            .lblNeedRestartControllers.Text = GetString(4603)
            .tpControllers.Text = GetString(4601)
            .tpAreca.Text = GetString(4602)

            .lvwControllers.Columns(0).Text = GetString(4610)
            .lvwControllers.Columns(1).Text = GetString(4611)
            .lvwControllers.Columns(2).Text = GetString(4612)
            .lvwControllers.Columns(3).Text = GetString(4613)
            .lvwControllers.Columns(4).Text = GetString(4614)

            .btnControllerAdd.Text = GetString(4620)
            .btnControllerEdit.Text = GetString(4621)
            .btnControllerRemove.Text = GetString(4622)

            .lblArecaSata.Text = GetString(4630)
            .lblArecaSataDisks.Text = GetString(4631)
            .lblArecaScsi.Text = GetString(4632)
            .lblArecaEnclosure1.Text = GetString(4633).Replace("%1", "1")
            .lblArecaEnclosure2.Text = GetString(4633).Replace("%1", "2")
            .lblArecaEnclosure3.Text = GetString(4633).Replace("%1", "3")
            .lblArecaEnclosure4.Text = GetString(4633).Replace("%1", "4")
            .lblArecaEnclosure5.Text = GetString(4633).Replace("%1", "5")
            .lblArecaEnclosure6.Text = GetString(4633).Replace("%1", "6")
            .lblArecaEnclosure7.Text = GetString(4633).Replace("%1", "7")
            .lblArecaEnclosure8.Text = GetString(4633).Replace("%1", "8")

        End With

        With EditController
            .Text = GetString(4610)
            .lblController.Text = GetString(4610)
            .lblLayer.Text = GetString(4611)
            .lblAllowedDevices.Text = GetString(4642)
            .lblTester.Text = GetString(4614)
            .btnAdd.Text = GetString(4620)
            .btnCancel.Text = GetString(4644)
        End With

        '************************************
        '*** smartctl alternative version ***
        '************************************
        With SettingsForm
            .lblSmartctlVersion.Text = GetString(3312)
            .chkSmartctl.Text = GetString(4401)
            .lblSmartctlFolder.Text = GetString(4402)
            .btnBrwsSmartctl.Text = GetString(4403)
            '.lblSmartctlPath.Text = ""
        End With

        '**********************************************************************************************************
        '***                                              Messages                                              ***
        '**********************************************************************************************************

        'tray icon tooltip: parameter variation
        m_alarmdevstatus = GetString(4901)
        m_from = GetString(4902)
        m_to = GetString(4903)
        m_degradation = GetString(4904)
        m_recovery = GetString(4905)

        'tray icon tooltip: high temperture and failing device
        m_temperaturealarm = GetString(4503)
        m_failuretitle = GetString(4504)
        m_failuretxt = GetString(4505)

        'quit confirm
        m_exit = GetString(5201)
        m_exitmsg = GetString(5202)

        'no devices found message error
        m_error = GetString(5101)
        m_nodevices = GetString(5102)
        m_nosmartctl = GetString(5103)

        'miss admin rights
        m_missadminrights = GetString(5111)

        '*************************************************************************************************************
        '***                                              Wait message                                             ***
        '*************************************************************************************************************
        With Me
            .lblAamWaitMessage.Text = GetString(4502)
            .lblApmWaitMessage.Text = GetString(4502)
            .lblStandbyWaitMessage.Text = GetString(4502)
            .lblWaitRWMessage.Text = GetString(4502)
        End With

        '*********************************************************************************************************************
        '***                                              Add virtual devices                                              ***
        '*********************************************************************************************************************
        With AddVirtualDevice
            .Text = GetString(5001)
            .lblDescription.Text = GetString(5002)
            .lblLocation.Text = GetString(5003)
            .btnAdd.Text = GetString(5004)
            .btnCancel.Text = GetString(5005)
        End With
        m_dataerror = GetString(5006)
        m_nogooddata = GetString(5007)

        '**********************************************************************************************************************
        '***                                              Tray icon info panel                                              ***
        '**********************************************************************************************************************
        With TrayPanel
            .lblHealthInfo.Text = m_overallhealth & ":"
            .lblTempInfo.Text = m_temperature & ":"
            .lblLife.Text = m_remaininglife & ":"
        End With

    End Sub

    Public Sub ChangeLanguage()
        LoadAttribInfos()
        InterfaceTranslation()
        InvokeOnClick(mrbUpdateAll, Nothing) 'overview
        'update device type
        With lvwDevices
            .Groups(0).Tag = GetString(421)
            .Groups(1).Tag = GetString(420)
            .Groups(2).Tag = GetString(422)
            .Groups(0).Header = .Groups(0).Tag & " - " & .Groups(0).Items.Count
            .Groups(1).Header = .Groups(1).Tag & " - " & .Groups(1).Items.Count
            .Groups(2).Header = .Groups(2).Tag & " - " & .Groups(2).Items.Count
        End With
        optOffline.Checked = True
        FillSidePanel()
        'FillBottomPanel()
        InvokeOnClick(mrbReloadDevice, Nothing) 'manage
        InvokeOnClick(mrbRefresh, Nothing) 'system
    End Sub

End Class