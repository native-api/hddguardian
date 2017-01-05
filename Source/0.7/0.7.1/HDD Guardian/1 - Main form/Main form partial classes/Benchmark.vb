'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Management
Imports System.ComponentModel
Imports System.Xml

Public Class Diskspd
    Private WithEvents Cmd As Process

    Public Function Run(ByVal command As String) As String
        Dim lines() As String

        Cmd = New Process

        'setup for hidden command window
        Cmd.StartInfo.RedirectStandardInput = True
        Cmd.StartInfo.RedirectStandardOutput = True
        Cmd.StartInfo.UseShellExecute = False 'required to redirect
        Cmd.StartInfo.CreateNoWindow = True 'this command avoid the creation of window
        Cmd.StartInfo.FileName = "cmd" 'the command window interpreter
        Cmd.StartInfo.WorkingDirectory = My.Application.Info.DirectoryPath & "\Diskspd"

        Cmd.Start() 'start hidden command window from current folder
        Cmd.StandardInput.WriteLine("diskspd " & command) 'write command to cmd window
        Cmd.StandardInput.WriteLine("exit") 'exit from cmd window
        lines = Cmd.StandardOutput.ReadToEnd.Split(vbCrLf) 'load output into an array

        Cmd.Close() 'release the resources
        Cmd.Dispose()

        'parse the output to get the result
        For i As Short = 0 To lines.Count - 1
            If lines(i).Contains("Total IO") Then
                Dim r() As String = lines(i + 3).Split("|")
                If IsNumeric(r(3).Trim.Replace(".", ",")) Then
                    Return r(3).Trim.Replace(".", ",")
                Else
                    Return 0
                End If
            End If
        Next
        Return ""
    End Function
End Class

Public Structure Benchmark
    Dim LogicalDiskSerialNumber As String
    Dim SequentialMultiWrite, RandomMultiWrite, SequentialWrite, RandomWrite As String
    Dim SequentialMultiRead, RandomMultiRead, SequentialRead, RandomRead As String
End Structure

Partial Class Main
    Dim WithEvents BenchmarkBGWorker As New BackgroundWorker
    Dim diskToBench As String = ""
    Dim partitionSerial As String = ""
    Dim benchResults As Benchmark
    Dim benchList As New List(Of Benchmark)

    Private Sub StartBench() Handles BenchmarkBGWorker.DoWork
        RunBenchmark()
    End Sub

    Private Sub BenchCompleted() Handles BenchmarkBGWorker.RunWorkerCompleted
        tlpBenchInfo.Visible = False

        If benchList.Count > 0 Then
            Dim newAddition As Boolean = True
            For i As Short = 0 To benchList.Count - 1
                If benchList(i).LogicalDiskSerialNumber = benchResults.LogicalDiskSerialNumber Then
                    benchList(i) = benchResults
                    newAddition = False
                    Exit For
                End If
            Next
            If newAddition Then benchList.Add(benchResults)
        Else
            benchList.Add(benchResults)
        End If
        SaveBenchmarks()

        lnkRunAll.Enabled = True
    End Sub

    Private Sub ClearBench()
        bbReadSMulti.Value = 0
        lblReadSMulti.Text = "-"
        bbReadRMulti.Value = 0
        lblReadRMulti.Text = "-"
        bbReadS.Value = 0
        lblReadS.Text = "-"
        bbReadR.Value = 0
        lblReadR.Text = "-"
        bbWriteSMulti.Value = 0
        lblWriteSMulti.Text = "-"
        bbWriteRMulti.Value = 0
        lblWriteRMulti.Text = "-"
        bbWriteS.Value = 0
        lblWriteS.Text = "-"
        bbWriteR.Value = 0
        lblWriteR.Text = "-"
    End Sub

    Private Sub RunBenchmark()
        BeginInvoke(Sub() prbBench.Value = 0)
        BeginInvoke(Sub() lblBenchProgress.Text = "")
        BeginInvoke(Sub() lblBenching.Text = GetString(3250) & " " & diskToBench)

        If diskToBench = "" Then Exit Sub
        Dim bench As New Diskspd
        Dim fileBench As String = "hddguardian.testfile"

        benchResults.LogicalDiskSerialNumber = partitionSerial
        'first, create a file to use with benchmark... (50 MiB)
        BeginInvoke(Sub() tlpBenchInfo.Visible = True)
        BeginInvoke(Sub() lblBenchProgress.Text = GetString(3252))
        Dim r As New Random
        Dim buffer(1024 * 1024 - 1) As Byte
        Dim data(50 * 1024 * 1024 - 1) As Byte
        r.NextBytes(buffer)
        For i As Long = 0 To 50 - 1
            buffer.CopyTo(data, i * 1024 * 1024)
        Next
        IO.File.WriteAllBytes(diskToBench & "\" & fileBench, data)
        data = Nothing
        buffer = Nothing
        BeginInvoke(Sub() prbBench.Value = 1)
        'then, run all benchmarks...
        BeginInvoke(Sub() lblBenchProgress.Text = GetString(3251) & ": " & GetString(3241).Replace(vbCrLf, " ") & " - " & GetString(3245))
        Threading.Thread.Sleep(5000)
        benchResults.SequentialMultiRead = bench.Run("-b128k -d5 -o32 -t1 -W0 -S -w0 " & diskToBench & "\" & fileBench)
        BeginInvoke(Sub() bbReadSMulti.Value = benchResults.SequentialMultiRead)
        BeginInvoke(Sub() lblReadSMulti.Text = GetString(3245) & ": " & benchResults.SequentialMultiRead & " MiB/s")
        BeginInvoke(Sub() prbBench.Value = 2)

        BeginInvoke(Sub() lblBenchProgress.Text = GetString(3251) & ": " & GetString(3242).Replace(vbCrLf, " ") & " - " & GetString(3245))
        Threading.Thread.Sleep(5000)
        benchResults.RandomMultiRead = bench.Run("-b4k -d5 -o32 -t1 -W0 -r -S -w0 " & diskToBench & "\" & fileBench)
        BeginInvoke(Sub() bbReadRMulti.Value = benchResults.RandomMultiRead)
        BeginInvoke(Sub() lblReadRMulti.Text = GetString(3245) & ": " & benchResults.RandomMultiRead & " MiB/s")
        BeginInvoke(Sub() prbBench.Value = 3)

        BeginInvoke(Sub() lblBenchProgress.Text = GetString(3251) & ": " & GetString(3243).Replace(vbCrLf, " ") & " - " & GetString(3245))
        Threading.Thread.Sleep(5000)
        benchResults.SequentialRead = bench.Run("-b1M -d5 -o1 -t1 -W0 -S -w0 " & diskToBench & "\" & fileBench)
        BeginInvoke(Sub() bbReadS.Value = benchResults.SequentialRead)
        BeginInvoke(Sub() lblReadS.Text = GetString(3245) & ": " & benchResults.SequentialRead & " MiB/s")
        BeginInvoke(Sub() prbBench.Value = 4)

        BeginInvoke(Sub() lblBenchProgress.Text = GetString(3251) & ": " & GetString(3244).Replace(vbCrLf, " ") & " - " & GetString(3245))
        Threading.Thread.Sleep(5000)
        benchResults.RandomRead = bench.Run("-b4k -d5 -o1 -t1 -W0 -r -S -w0 " & diskToBench & "\" & fileBench)
        BeginInvoke(Sub() bbReadR.Value = benchResults.RandomRead)
        BeginInvoke(Sub() lblReadR.Text = GetString(3245) & ": " & benchResults.RandomRead & " MiB/s")
        BeginInvoke(Sub() prbBench.Value = 5)

        BeginInvoke(Sub() lblBenchProgress.Text = GetString(3251) & ": " & GetString(3241).Replace(vbCrLf, " ") & " - " & GetString(3246))
        Threading.Thread.Sleep(5000)
        benchResults.SequentialMultiWrite = bench.Run("-b128k -d5 -o32 -t1 -W0 -S -w100 -Z128k " & diskToBench & "\" & fileBench)
        BeginInvoke(Sub() bbWriteSMulti.Value = benchResults.SequentialMultiWrite)
        BeginInvoke(Sub() lblWriteSMulti.Text = GetString(3246) & ": " & benchResults.SequentialMultiWrite & " MiB/s")
        BeginInvoke(Sub() prbBench.Value = 6)

        BeginInvoke(Sub() lblBenchProgress.Text = GetString(3251) & ": " & GetString(3242).Replace(vbCrLf, " ") & " - " & GetString(3246))
        Threading.Thread.Sleep(5000)
        benchResults.RandomMultiWrite = bench.Run("-b4k -d5 -o32 -t1 -W0 -r -S -w100 -Z4k " & diskToBench & "\" & fileBench)
        BeginInvoke(Sub() bbWriteRMulti.Value = benchResults.RandomMultiWrite)
        BeginInvoke(Sub() lblWriteRMulti.Text = GetString(3246) & ": " & benchResults.RandomMultiWrite & " MiB/s")
        BeginInvoke(Sub() prbBench.Value = 7)

        BeginInvoke(Sub() lblBenchProgress.Text = GetString(3251) & ": " & GetString(3243).Replace(vbCrLf, " ") & " - " & GetString(3246))
        Threading.Thread.Sleep(5000)
        benchResults.SequentialWrite = bench.Run("-b1M -d5 -o1 -t1 -W0 -S -w100 -Z1M " & diskToBench & "\" & fileBench)
        BeginInvoke(Sub() bbWriteS.Value = benchResults.SequentialWrite)
        BeginInvoke(Sub() lblWriteS.Text = GetString(3246) & ": " & benchResults.SequentialWrite & " MiB/s")
        BeginInvoke(Sub() prbBench.Value = 8)

        BeginInvoke(Sub() lblBenchProgress.Text = GetString(3251) & ": " & GetString(3244).Replace(vbCrLf, " ") & " - " & GetString(3246))
        Threading.Thread.Sleep(5000)
        benchResults.RandomWrite = bench.Run("-b4k -d5 -o1 -t1 -W0 -r -S -w100 -Z4k " & diskToBench & "\" & fileBench)
        BeginInvoke(Sub() bbWriteR.Value = benchResults.RandomWrite)
        BeginInvoke(Sub() lblWriteR.Text = GetString(3246) & ": " & benchResults.RandomWrite & " MiB/s")
        BeginInvoke(Sub() prbBench.Value = 9)

        If IO.File.Exists(diskToBench & "\" & fileBench) Then IO.File.Delete(diskToBench & "\" & fileBench)
        BeginInvoke(Sub() tlpBenchInfo.Visible = False)
    End Sub

    Private Sub PopulateBench()
        ClearBench()

        lnkRunAll.Enabled = Not BenchmarkBGWorker.IsBusy

        If BenchmarkBGWorker.IsBusy Then
            If benchResults.LogicalDiskSerialNumber = partitionSerial Then
                If Val(benchResults.SequentialMultiRead) > 0 Then
                    bbReadSMulti.Value = benchResults.SequentialMultiRead
                    lblReadSMulti.Text = GetString(3245) & ": " & benchResults.SequentialMultiRead & " MiB/s"
                End If
                If Val(benchResults.RandomMultiRead) > 0 Then
                    bbReadRMulti.Value = benchResults.RandomMultiRead
                    lblReadRMulti.Text = GetString(3245) & ": " & benchResults.RandomMultiRead & " MiB/s"
                End If
                If Val(benchResults.SequentialRead) > 0 Then
                    bbReadS.Value = benchResults.SequentialRead
                    lblReadS.Text = GetString(3245) & ": " & benchResults.SequentialRead & " MiB/s"
                End If
                If Val(benchResults.RandomRead) > 0 Then
                    bbReadR.Value = benchResults.RandomRead
                    lblReadR.Text = GetString(3245) & ": " & benchResults.RandomRead & " MiB/s"
                End If
                If Val(benchResults.SequentialMultiWrite) > 0 Then
                    bbWriteSMulti.Value = benchResults.SequentialMultiWrite
                    lblWriteSMulti.Text = GetString(3246) & ": " & benchResults.SequentialMultiWrite & " MiB/s"
                End If
                If Val(benchResults.RandomMultiWrite) > 0 Then
                    bbWriteRMulti.Value = benchResults.RandomMultiWrite
                    lblWriteRMulti.Text = GetString(3246) & ": " & benchResults.RandomMultiWrite & " MiB/s"
                End If
                If Val(benchResults.SequentialWrite) > 0 Then
                    bbWriteS.Value = benchResults.SequentialWrite
                    lblWriteS.Text = GetString(3246) & ": " & benchResults.SequentialWrite & " MiB/s"
                End If
                If Val(benchResults.RandomWrite) > 0 Then
                    bbWriteR.Value = benchResults.RandomWrite
                    lblWriteR.Text = GetString(3246) & ": " & benchResults.RandomWrite & " MiB/s"
                End If
                Exit Sub
            End If
        End If

        If Not IsNothing(benchList) Then
            For i As Short = 0 To benchList.Count - 1
                If benchList(i).LogicalDiskSerialNumber = partitionSerial Then
                    bbReadSMulti.Value = benchList(i).SequentialMultiRead
                    lblReadSMulti.Text = GetString(3245) & ": " & benchList(i).SequentialMultiRead & " MiB/s"
                    bbReadRMulti.Value = benchList(i).RandomMultiRead
                    lblReadRMulti.Text = GetString(3245) & ": " & benchList(i).RandomMultiRead & " MiB/s"
                    bbReadS.Value = benchList(i).SequentialRead
                    lblReadS.Text = GetString(3245) & ": " & benchList(i).SequentialRead & " MiB/s"
                    bbReadR.Value = benchList(i).RandomRead
                    lblReadR.Text = GetString(3245) & ": " & benchList(i).RandomRead & " MiB/s"
                    bbWriteSMulti.Value = benchList(i).SequentialMultiWrite
                    lblWriteSMulti.Text = GetString(3246) & ": " & benchList(i).SequentialMultiWrite & " MiB/s"
                    bbWriteRMulti.Value = benchList(i).RandomMultiWrite
                    lblWriteRMulti.Text = GetString(3246) & ": " & benchList(i).RandomMultiWrite & " MiB/s"
                    bbWriteS.Value = benchList(i).SequentialWrite
                    lblWriteS.Text = GetString(3246) & ": " & benchList(i).SequentialWrite & " MiB/s"
                    bbWriteR.Value = benchList(i).RandomWrite
                    lblWriteR.Text = GetString(3246) & ": " & benchList(i).RandomWrite & " MiB/s"
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub SaveBenchmarks()
        If benchList.Count = 0 Then Exit Sub

        Dim folder As String = My.Application.Info.DirectoryPath & "\Data\" & My.Computer.Name
        Dim output As XmlWriterSettings = New XmlWriterSettings()
        output.Indent = True
        Using write As XmlWriter = XmlWriter.Create(folder & "\benchmarks.xml", output)
            write.WriteStartDocument()
            write.WriteStartElement("diskspd")
            For i As Short = 0 To benchList.Count - 1
                write.WriteStartElement("benchmark")
                write.WriteAttributeString("serialnumber", benchList(i).LogicalDiskSerialNumber)
                write.WriteAttributeString("sequentialmultiread", benchList(i).SequentialMultiRead)
                write.WriteAttributeString("sequentialmultiwrite", benchList(i).SequentialMultiWrite)
                write.WriteAttributeString("randommultiread", benchList(i).RandomMultiRead)
                write.WriteAttributeString("randommultiwrite", benchList(i).RandomMultiWrite)
                write.WriteAttributeString("sequentialread", benchList(i).SequentialRead)
                write.WriteAttributeString("sequentialwrite", benchList(i).SequentialWrite)
                write.WriteAttributeString("randomread", benchList(i).RandomRead)
                write.WriteAttributeString("randomwrite", benchList(i).RandomWrite)
                write.WriteEndElement()
            Next
            write.WriteEndElement()
            write.WriteEndDocument()
        End Using
    End Sub

    Private Sub LoadBenchmarks()
        Dim folder As String = My.Application.Info.DirectoryPath & "\Data\" & My.Computer.Name

        If IO.File.Exists(folder & "\benchmarks.xml") Then
            Dim m_xmldoc As New XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            Try
                m_xmldoc.Load(folder & "\benchmarks.xml")
                m_nodelist = m_xmldoc.SelectNodes("/diskspd/benchmark")
                For Each m_node In m_nodelist
                    Dim b As Benchmark
                    b.LogicalDiskSerialNumber = m_node.Attributes.GetNamedItem("serialnumber").Value
                    b.SequentialMultiRead = m_node.Attributes.GetNamedItem("sequentialmultiread").Value
                    b.SequentialMultiWrite = m_node.Attributes.GetNamedItem("sequentialmultiwrite").Value
                    b.RandomMultiRead = m_node.Attributes.GetNamedItem("randommultiread").Value
                    b.RandomMultiWrite = m_node.Attributes.GetNamedItem("randommultiwrite").Value
                    b.SequentialRead = m_node.Attributes.GetNamedItem("sequentialread").Value
                    b.SequentialWrite = m_node.Attributes.GetNamedItem("sequentialwrite").Value
                    b.RandomRead = m_node.Attributes.GetNamedItem("randomread").Value
                    b.RandomWrite = m_node.Attributes.GetNamedItem("randomwrite").Value
                    benchList.Add(b)
                    b = Nothing
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
