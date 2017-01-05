'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Xml

Partial Class Main

    Dim allusersfolder As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData
    Dim curruserfolder As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData

    Public Sub LoadDeviceSettings(ByVal device As Device)
        If Not IsNothing(device.Options) Then
            If device.Options.Length > 0 Then
                ParseOptions(device.Options)
            End If
        End If
    End Sub

    Public Sub SaveDeviceSettings()
        If isloading_devsettings Then Exit Sub

        If lvwDevices.Items.Count = 0 Then Exit Sub
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        Dim attrformat As String = ""
        If chkAttributes.Checked Then
            With lvwAttrFormat
                If .Items.Count > 0 Then
                    For i As Integer = 0 To .Items.Count - 1
                        attrformat = attrformat & "-v " & .Items(i).Text & "," & _
                        .Items(i).SubItems(1).Text & "," & .Items(i).SubItems(2).Text & " "
                    Next
                End If
            End With
        End If

        Dim fdebug As String = ""
        Dim swap As String = ""
        Dim nologdir As String = ""
        Dim xerror As String = ""
        If chkFirmware.Checked Then
            Select Case cboFirmware.SelectedIndex
                Case 0
                    fdebug = "-F none "
                Case 1
                    fdebug = "-F samsung "
                Case 2
                    fdebug = "-F samsung2 "
                Case 3
                    fdebug = "-F samsung3 "
            End Select
            If chkFixSwap.Checked Then swap = "-F swapid "
            If chkNoLogDir.Checked Then nologdir = "-F nologdir "
            If chkXErrorLba.Checked Then xerror = "-F xerrorlba "
        End If

        Dim pmode As String = ""
        If chkPowerMode.Checked Then
            If rbNever.Checked Then pmode = "-n never "
            If rbSleep.Checked Then pmode = "-n sleep "
            If rbStandby.Checked Then pmode = "-n standby "
            If rbIdle.Checked Then pmode = "-n idle "
        End If

        Dim attrautosave As String = ""
        If chkEnableAutosave.Checked = True Then attrautosave = "-S on "

        Dim asmedia As String = ""
        If chkAsmedia.Checked Then asmedia = "-d sat "

        Dim content As String = attrformat & fdebug & swap & nologdir & xerror & pmode & attrautosave & asmedia

        dev.Options = content

        Dim standby As String = ""
        If trkStandby.Value > 0 And dev.Type <> DeviceType.SCSI Then dev.ATA.Features.Standby = trkStandby.Value
    End Sub


    Public Sub ParseOptions(ByVal options As String)
        isloading_devsettings = True 'this prevent a not required saving for device settings

        chkEnableAutosave.Checked = False
        chkAttributes.Checked = False
        chkFirmware.Checked = False
        chkAsmedia.Checked = False
        lvwAttrFormat.Items.Clear()

        If IsNothing(options) Then
            isloading_devsettings = False
            Exit Sub
        End If

        Dim commands() As String = options.Split("-", 255, StringSplitOptions.RemoveEmptyEntries)

        chkAttributes.Enabled = True
        chkFirmware.Enabled = True
        chkPowerMode.Enabled = True

        For i As Integer = 0 To commands.Length - 1
            Dim Param() As Char = commands(i).Trim.ToCharArray
            If Param.Length > 0 Then
                Select Case Param(0)
                    Case "v"
                        chkAttributes.Checked = True
                        Dim Attribute() As String = commands(i).Substring(1).Trim.Split(",")
                        If Attribute.Length = 2 Then
                            With lvwAttrFormat
                                .Items.Add(Attribute(0))
                                .Items(.Items.Count - 1).SubItems.Add(Attribute(1))
                            End With
                        Else
                            With lvwAttrFormat
                                .Items.Add(Attribute(0))
                                .Items(.Items.Count - 1).SubItems.Add(Attribute(1))
                                .Items(.Items.Count - 1).SubItems.Add(Attribute(2))
                            End With
                        End If
                    Case "F"
                        chkFirmware.Checked = True
                        If commands(i).Contains("none") Then cboFirmware.SelectedIndex = 0
                        If commands(i).Contains("samsung") Then cboFirmware.SelectedIndex = 1
                        If commands(i).Contains("samsung2") Then cboFirmware.SelectedIndex = 2
                        If commands(i).Contains("samsung3") Then cboFirmware.SelectedIndex = 3
                        If commands(i).Contains("swapid") Then chkFixSwap.Checked = True
                        If commands(i).Contains("nologdir") Then chkNoLogDir.Checked = True
                        If commands(i).Contains("xerrorlba") Then chkXErrorLba.Checked = True
                    Case "S"
                        If commands(i).Contains("on") Then
                            chkEnableAutosave.Enabled = True
                            chkEnableAutosave.Checked = True
                        Else
                            chkEnableAutosave.Enabled = True
                            chkEnableAutosave.Checked = False
                        End If
                    Case "n"
                        chkPowerMode.Checked = True
                        If commands(i).Contains("never") Then rbNever.Checked = True
                        If commands(i).Contains("sleep") Then rbSleep.Checked = True
                        If commands(i).Contains("standby") Then rbStandby.Checked = True
                        If commands(i).Contains("idle") Then rbIdle.Checked = True
                    Case "d"
                        chkAsmedia.Checked = True
                End Select
            End If
        Next

        commands = Nothing

        isloading_devsettings = False
    End Sub
End Class
