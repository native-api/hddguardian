'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Partial Class Main
    Private Sub ScanMultiDock()
        PrintDebug("*** Try to detect multi dock USB devices ***", False, True)
        Dim prompt As New Console

        For i As Short = 97 To 122
            Dim scan() As String = prompt.SendCmd(" -i /dev/sd" & Chr(i))
            Dim port0occupied As Boolean = False

            For r As Short = 0 To scan.Count - 2
                If scan(r).Contains("Two devices connected, try '-d usbjmicron,[01]'") Then
                    'first, try with port 0
                    Dim output() As String = prompt.SendCmd(" -i /dev/sd" & Chr(i) & " -d usbjmicron,0")

                    For o As Short = 0 To output.Count - 2
                        If output(o).Contains("START OF INFORMATION SECTION") Then
                            Dim d As New Device("/dev/sd" & Chr(i) & " -d usbjmicron,0", DeviceType.USB)
                            Dim toadd As Boolean = True
                            For l As Short = 0 To devlist.Count - 1
                                If devlist(l).Model = d.Model And devlist(l).SerialNumber = d.SerialNumber Then
                                    toadd = False
                                    Exit For
                                End If
                            Next

                            If toadd = True Then
                                PrintDebug("Adding " & d.Location)
                                devlist.Add(d)
                                'If Not isloading Then UpdateLeftPanel(d)
                                port0occupied = True
                            End If
                            Exit For
                        End If
                    Next
                    If port0occupied = False Then
                        'then, try with port 1
                        Dim output1() As String = prompt.SendCmd(" -i /dev/sd" & Chr(i) & " -d usbjmicron,1")

                        For o As Short = 0 To output1.Count - 2
                            If output1(o).Contains("START OF INFORMATION SECTION") Then
                                Dim d As New Device("/dev/sd" & Chr(i) & " -d usbjmicron,1", DeviceType.USB)
                                Dim toadd As Boolean = True
                                For l As Short = 0 To devlist.Count - 1
                                    If devlist(l).Model = d.Model And devlist(l).SerialNumber = d.SerialNumber Then
                                        toadd = False
                                        Exit For
                                    End If
                                Next

                                If toadd = True Then
                                    PrintDebug("Adding " & d.Location)
                                    devlist.Add(d)
                                    'If Not isloading Then UpdateLeftPanel(d)
                                End If
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next
        Next i
    End Sub
End Class

