'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Xml

Public Structure ScsiError
    Dim EccFast, EccDelayed, EccReReadsReWrites, ErrorsCorrected, CorrectionAlgorithmInvocations, GbProcessed, UncorrectedErrors As String
    Dim HaveEntries As Boolean
End Structure

Public Structure ScsiSelfTest
    Dim Num, Description, Status, SegmentNumber, LifeTime, LbaFirstError, SK, ASC, ASQ As String
End Structure

Public Class ScsiSelfTestsCollection
    Inherits List(Of ScsiSelfTest)
End Class

Partial Class Device

    Private m_isvirtual As Boolean
    Private m_isdisk As Boolean = False
    Private m_manufacturer, m_revision, m_blocksize, m_unitid, m_protocol, m_lastupdate As String
    Private m_growndefects, m_nonmediumerrors, m_testduration As String
    Private m_scsiwcache, m_scsircache As Boolean
    Private m_scsiwcacheavailable, m_scsircacheavailable As Boolean
    Private m_scsigltsd As Boolean = False
    Private m_haserrorslog As Boolean = False
    Private m_hasselftestlog As Boolean = False
    Private m_isscsi As Boolean = False
    Private m_logread As New ScsiError
    Private m_logwrite As New ScsiError
    Private m_logverify As New ScsiError
    Private m_scsiselftests As New ScsiSelfTestsCollection

    Private Sub GetScsiAttributes()
        Dim e As Short = 0

        Try
            Dim fulloutput As String = ""
            For i As Integer = 0 To m_output.Length - 1
                If Not IsNothing(m_output(i)) Then
                    fulloutput += m_output(i)
                End If
            Next
            m_isscsi = True
            m_manufacturer = GetInfo("Vendor")
            m_devicemodel = GetInfo("Product")
            m_revision = GetInfo("Revision")

            Dim size As String = GetInfo("User Capacity")
            Dim s() As String = size.Split("bytes")
            m_size = ToNumber(s(0))
            If m_size = "" Then m_size = "N/A"

            m_blocksize = GetInfo("Logical block size")
            m_unitid = GetInfo("Logical Unit id")
            m_serialnumber = GetInfo("Serial number")
            m_protocol = GetInfo("Transport protocol")
            m_lastupdate = GetInfo("Local Time is")
            m_rotation = GetInfo("Rotation Rate")

            Dim smart As String = GetInfo("SMART support is")
            m_smartavailable = Support.Unavailable
            m_smartenabled = Support.Disabled
            If smart.Contains("Available - device has SMART capability.") Then
                m_smartavailable = Support.Available
                For i As Short = 0 To m_output.Length - 2
                    If m_output(i).Contains("SMART support is") And m_output(i).Contains("Enabled") Then
                        m_smartenabled = Support.Enabled
                        Exit For
                    End If
                Next
            End If

            Dim health As String = GetInfo("SMART Health Status")
            If health = "OK" Then
                m_healthpassed = Status.Passed
            Else
                If m_smartavailable = Support.Unavailable Then
                    m_healthpassed = Status.Unkonwn
                Else
                    m_healthpassed = Status.Failed
                End If
            End If

            m_temperature = GetInfo("Current Drive Temperature").Replace(" C", "")
            If Not IsNumeric(m_temperature) Then m_temperature = "N/A"

            m_growndefects = GetInfo("Elements in grown defect list")
            m_nonmediumerrors = GetInfo("Non-medium error count")

            Dim duration As String = GetInfo("Long (extended) Self Test duration")
            Dim d() As String = duration.Split(" ")
            m_testduration = d(0).Trim

            Dim wcache As String = GetInfo("Writeback Cache is")
            m_scsiwcache = False
            m_scsiwcacheavailable = False
            If wcache.Contains("Disabled") Then
                m_scsiwcache = False
                m_scsiwcacheavailable = True
            ElseIf wcache.Contains("Enabled") Then
                m_scsiwcache = True
                m_scsiwcacheavailable = True
            End If

            Dim rcache As String = GetInfo("Read Cache is")
            m_scsircache = False
            m_scsircacheavailable = False
            If rcache.Contains("Disabled") Then
                m_scsircache = False
                m_scsircacheavailable = True
            ElseIf rcache.Contains("Enabled") Then
                m_scsircache = True
                m_scsircacheavailable = True
            End If

            For i As Short = 0 To m_output.Length - 2
                e = i
                If Not IsNothing(m_output(i)) Then
                    If m_output(i).Contains("Autosave enabled (GLTSD bit set).") Then
                        m_scsigltsd = True
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
            Dim diagnostic As New System.Diagnostics.StackTrace(ex, True)
            Main.PrintDebug("Encountered an error! " & ex.StackTrace & " at line " & diagnostic.GetFrame(0).GetFileLineNumber)
            Main.PrintDebug("Output content that generate the error is: '" & m_output(e) & "'")
        End Try

    End Sub

    Private Sub GetScsiErrorLog()
        Dim e As Short = 0

        Try
            Dim l As Short = 0

            For i As Short = 0 To m_output.Length - 2
                e = i
                If Not IsNothing(m_output(i)) Then
                    If m_output(i).Contains("Error counter log:") Then
                        m_haserrorslog = True
                        l = i + 4
                        Exit For
                    End If
                End If
            Next

            If m_haserrorslog Then
                m_logread.HaveEntries = False
                m_logwrite.HaveEntries = False
                m_logverify.HaveEntries = False
                For el As Short = l To l + 2
                    If m_output(el).Contains("read") Then
                        m_logread.HaveEntries = True
                        Dim r() As String = m_output(l).Trim.Split(" ", 8, StringSplitOptions.RemoveEmptyEntries)
                        If r.Length > 0 Then
                            With m_logread
                                .EccFast = r(1)
                                .EccDelayed = r(2)
                                .EccReReadsReWrites = r(3)
                                .ErrorsCorrected = r(4)
                                .CorrectionAlgorithmInvocations = r(5)
                                .GbProcessed = r(6)
                                .UncorrectedErrors = r(7)
                            End With
                        End If
                    ElseIf m_output(el).Contains("write") Then
                        m_logwrite.HaveEntries = True
                        Dim w() As String = m_output(l + 1).Trim.Split(" ", 8, StringSplitOptions.RemoveEmptyEntries)
                        If w.Length > 0 Then
                            With m_logwrite
                                .EccFast = w(1)
                                .EccDelayed = w(2)
                                .EccReReadsReWrites = w(3)
                                .ErrorsCorrected = w(4)
                                .CorrectionAlgorithmInvocations = w(5)
                                .GbProcessed = w(6)
                                .UncorrectedErrors = w(7)
                            End With
                        End If
                    ElseIf m_output(el).Contains("verify") Then
                        m_logverify.HaveEntries = True
                        Dim v() As String = m_output(l + 2).Trim.Split(" ", 8, StringSplitOptions.RemoveEmptyEntries)
                        If v.Length > 0 Then
                            With m_logverify
                                .EccFast = v(1)
                                .EccDelayed = v(2)
                                .EccReReadsReWrites = v(3)
                                .ErrorsCorrected = v(4)
                                .CorrectionAlgorithmInvocations = v(5)
                                .GbProcessed = v(6)
                                .UncorrectedErrors = v(7)
                            End With
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Dim diagnostic As New System.Diagnostics.StackTrace(ex, True)
            Main.PrintDebug("Encountered an error! " & ex.StackTrace & " at line " & diagnostic.GetFrame(0).GetFileLineNumber)
            Main.PrintDebug("Output content that generate the error is: '" & m_output(e) & "'")
        End Try
    End Sub

    Private Sub GetScsiSelfTest()
        Dim e As Short = 0

        Try
            Dim l As Short = 0

            For i As Short = 0 To m_output.Length - 2
                e = i
                If Not IsNothing(m_output(i)) Then
                    If m_output(i).Contains("SMART Self-test log") Then
                        m_hasselftestlog = True
                        l = i + 3
                        Exit For
                    End If
                End If
            Next

            m_scsiselftests.Clear()

            For r As Integer = l To m_output.Length - 1
                Dim row As String = m_output(r).Replace(vbCr, "").Replace(vbLf, "")
                If Not row.StartsWith("#") Then Exit For
                Dim s() As String = m_output(r).Split("[")
                Dim st() As String = s(0).Replace("#", "").Trim.Replace("  ", "_") _
                                   .Split("_", 6, StringSplitOptions.RemoveEmptyEntries)
                Dim skascasq() As String = s(1).Replace("[", "").Replace("]", "").Split(" ", 3, StringSplitOptions.RemoveEmptyEntries)

                Dim t As New ScsiSelfTest
                With t
                    .Num = st(0).Trim
                    .Description = st(1).Trim
                    .Status = st(2).Trim
                    .SegmentNumber = st(3).Trim
                    .LifeTime = st(4).Trim
                    .LbaFirstError = st(5).Trim
                    .SK = skascasq(0).Trim
                    .ASC = skascasq(1).Trim
                    .ASQ = skascasq(2).Trim
                End With
                m_scsiselftests.Add(t)
            Next
        Catch ex As Exception
            Dim diagnostic As New System.Diagnostics.StackTrace(ex, True)
            Main.PrintDebug("Encountered an error! " & ex.StackTrace & " at line " & diagnostic.GetFrame(0).GetFileLineNumber)
            Main.PrintDebug("Output content that generate the error is: '" & m_output(e) & "'")
        End Try
    End Sub

    Public ReadOnly Property IsScsi As Boolean
        Get
            Return m_isscsi
        End Get
    End Property

    Public ReadOnly Property Manufacturer As String
        Get
            Return m_manufacturer
        End Get
    End Property

    Public ReadOnly Property Revision As String
        Get
            Return m_revision
        End Get
    End Property

    Public ReadOnly Property LogicalBlockSize As String
        Get
            Return m_blocksize
        End Get
    End Property

    Public ReadOnly Property LogicalUnitId As String
        Get
            Return m_unitid
        End Get
    End Property

    Public ReadOnly Property IsDisk As Boolean
        Get
            Return m_isdisk
        End Get
    End Property

    Public ReadOnly Property InterfaceProtocol As String
        Get
            Return m_protocol
        End Get
    End Property

    Public ReadOnly Property GrownDefectsCount As String
        Get
            Return m_growndefects
        End Get
    End Property

    Public ReadOnly Property NonMediumErrors As String
        Get
            Return m_nonmediumerrors
        End Get
    End Property

    Public ReadOnly Property ScsiTestDuration As String
        Get
            Return m_testduration
        End Get
    End Property

    Public ReadOnly Property ScsiHasErrorLog As Boolean
        Get
            Return m_haserrorslog
        End Get
    End Property

    Public ReadOnly Property ScsiHasSelfTestLog As Boolean
        Get
            Return m_hasselftestlog
        End Get
    End Property

    Public ReadOnly Property ReadErrors As ScsiError
        Get
            Return m_logread
        End Get
    End Property

    Public ReadOnly Property WriteErrors As ScsiError
        Get
            Return m_logwrite
        End Get
    End Property

    Public ReadOnly Property VerifyErrors As ScsiError
        Get
            Return m_logverify
        End Get
    End Property

    Public ReadOnly Property ScsiSelfTests As ScsiSelfTestsCollection
        Get
            Return m_scsiselftests
        End Get
    End Property

    Public ReadOnly Property ScsiWriteCacheAvailable As Boolean
        Get
            Return m_scsiwcacheavailable
        End Get
    End Property

    Public ReadOnly Property ScsiWriteCacheEnabled As Boolean
        Get
            Return m_scsiwcache
        End Get
    End Property

    Public ReadOnly Property ScsiReadCacheAvailable As Boolean
        Get
            Return m_scsircacheavailable
        End Get
    End Property

    Public ReadOnly Property ScsiReadCacheEnabled As Boolean
        Get
            Return m_scsircache
        End Get
    End Property

    Public ReadOnly Property ScsiGltsdStatus As Boolean
        Get
            Return m_scsigltsd
        End Get
    End Property

    Public Property ScsiGltsd As Feature
        Get
            If m_scsigltsd = True Then
                Return Feature.Enable
            Else
                Return Feature.Disable
            End If
        End Get
        Set(ByVal value As Feature)
            If value = Feature.Enable Then
                smartctl.SendCmd("-S on " & m_location)
            ElseIf value = Feature.Disable Then
                smartctl.SendCmd("-S off " & m_location)
            End If
            Update()
        End Set
    End Property

    Public Property ScsiWriteCache As Feature
        Get
            If m_scsiwcache = True Then
                Return Feature.Enable
            Else
                Return Feature.Disable
            End If
        End Get
        Set(ByVal value As Feature)
            If value = Feature.Enable Then
                smartctl.SendCmd("-s wcache,on " & m_location)
            ElseIf value = Feature.Disable Then
                smartctl.SendCmd("-s wcache,off " & m_location)
            End If
            Update()
        End Set
    End Property

    Public Property ScsiReadCache As Feature
        Get
            If m_scsircache = True Then
                Return Feature.Enable
            Else
                Return Feature.Disable
            End If
        End Get
        Set(ByVal value As Feature)
            If value = Feature.Enable Then
                smartctl.SendCmd("-s rcache,on " & m_location)
            ElseIf value = Feature.Disable Then
                smartctl.SendCmd("-s rcache,off " & m_location)
            End If
            Update()
        End Set
    End Property
End Class
