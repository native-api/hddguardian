'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2015 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Public Class AddVirtualDevice

    Dim content() As String

    Private Function GetInfo(ByVal info As String) As String
        Dim value As String = "N/A"
        For i As Integer = 0 To content.Length - 1
            If content(i).ToLower.Contains(info.ToLower) Then
                Dim result() As String = content(i).Split(":", 2, StringSplitOptions.RemoveEmptyEntries)
                If result(1).Trim.Contains("[No Information Found]") Then
                    Return "N/A"
                Else
                    Return result(1).Trim
                End If
            End If
        Next
        Return value
    End Function

    Private Sub AddVirtual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cs As New ColorScheme
        Me.BackColor = cs.BackColor
        pnlBottom.BackColor = cs.StatusBarBackColor
        lblDescription.ForeColor = cs.ForeColor
        lblLocation.ForeColor = cs.ForeColor
        lblFile.ForeColor = cs.GrayedText
        '-------------------------------------------

        txtDescription.Text = ""
        lblFile.Text = ""
        btnAdd.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        btnAdd.Enabled = False

        With dlgVirtual
            .FileName = ""
            .Filter = "*.txt|*.txt"
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                content = IO.File.ReadAllLines(.FileName)
                Dim havedata As Boolean = False
                For i As Short = 0 To content.Length - 1
                    If content(i).Contains("START OF INFORMATION SECTION") Then
                        havedata = True
                        Exit For
                    End If
                Next
                If havedata Then
                    lblFile.Text = IO.Path.GetFileNameWithoutExtension(.FileName)
                    lblFile.Tag = .FileName
                    btnAdd.Enabled = True
                Else
                    MsgBox(Main.m_nogooddata, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Main.m_dataerror)
                End If
            End If
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim virtualfolder As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData _
                                      .Substring(0, My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.LastIndexOf("\")) _
                                      & "\Virtual devices\"

        'get size, device model, serial number, firmware
        Dim devmodel As String = GetInfo("Device Model")
        If devmodel = "N/A" Then devmodel = GetInfo("Product")
        Dim devsize As String = GetInfo("User Capacity")
        Dim serial As String = GetInfo("Serial Number")
        Dim firmware As String = GetInfo("Firmware Version")

        'create a new configuration file containing some informations about the device
        '(model, size, serial number and firmware) and the virtual device file location
        Dim content As String = lblFile.Tag & vbCrLf & txtDescription.Text & vbCrLf & _
            devmodel & vbCrLf & devsize & vbCrLf & serial & vbCrLf & firmware
        If Not IO.Directory.Exists(virtualfolder) Then IO.Directory.CreateDirectory(virtualfolder)

        Dim ffn As String = devmodel & "_" & serial
        Dim fn() As Char = ffn.ToCharArray
        Dim vfn As String = ""

        For Each c As Char In fn
            Select Case c.ToString
                'validate only the following characters:
                Case "-", "a" To "z", "A" To "Z", "0" To "9", "_", " ", ".", ","
                    vfn += c
                Case Else
                    'discard all the others characters.
            End Select
        Next

        IO.File.WriteAllText(virtualfolder & vfn & ".vd", content, System.Text.Encoding.Default)

        'add virtual device to devices listview and collection
        With Main
            Main.devlist.Add(New Device(lblFile.Tag, DeviceType.Virtual))
            Dim dev As Device = Main.devlist(Main.devlist.Count - 1)
            Dim info As VirtualDeviceInfo
            With info
                .Description = txtDescription.Text
                .Model = devmodel
                .UserSize = devsize
                .SerialNumber = serial
                .Firmware = firmware
            End With
            dev.VirtualDeviceInfo = info

            With .lvwDevices
                .Items.Add(New ListViewItem(dev.Model, .Groups(2)))
                Dim i As Short = .Items.Count - 1
                .Items(i).UseItemStyleForSubItems = False

                If dev.InDatabase Then
                    Select Case dev.ReliabilityRating.Overall
                        Case 4 To 5
                            .Items(i).ImageIndex = 0
                        Case 2 To 3
                            .Items(i).ImageIndex = 3
                        Case 1
                            .Items(i).ImageIndex = 2
                        Case Else
                            .Items(i).ImageIndex = 1
                    End Select
                    If dev.Health = Status.Failed Then .Items(i).ImageIndex = 2
                Else 'here are rated unknown SATA and SCSI devices
                    Select Case dev.Health
                        Case Status.Unkonwn
                            .Items(i).ImageIndex = 1
                        Case Status.Failed
                            .Items(i).ImageIndex = 2
                        Case Status.Passed
                            .Items(i).ImageIndex = 0
                    End Select
                End If

                If IsNumeric(dev.Temperature) Then
                    If My.Settings.TempFahrenheit = True Then
                        .Items(i).SubItems.Add(Math.Round(dev.Temperature * 1.8 + 32) & "°F")
                    Else
                        .Items(i).SubItems.Add(dev.Temperature & "°C")
                    End If
                    Select Case Val(dev.Temperature)
                        Case 0 To 49
                            .Items(i).SubItems(1).ForeColor = temp_ok
                        Case 50 To 54
                            .Items(i).SubItems(1).ForeColor = temp_high
                        Case Is >= 55
                            .Items(i).SubItems(1).ForeColor = temp_alarm
                    End Select
                Else
                    .Items(i).SubItems.Add(dev.Temperature)
                    .Items(i).SubItems(1).ForeColor = Color.DarkGray
                End If

                If IsNumeric(dev.RemainingLife) Then
                    .Items(i).SubItems.Add(Val(dev.RemainingLife) & "%")
                    Select Case Val(dev.RemainingLife)
                        Case 0
                            .Items(i).SubItems(2).ForeColor = life_out
                        Case 1 To 10
                            .Items(i).SubItems(2).ForeColor = life_low
                        Case Is > 10
                            .Items(i).SubItems(2).ForeColor = life_ok
                    End Select
                Else
                    .Items(i).SubItems.Add(dev.RemainingLife)
                    .Items(i).SubItems(2).ForeColor = Color.DarkGray
                End If

                .Items(i).SubItems.Add(dev.DeviceInterface)

                If IsNumeric(dev.UserCapacity) Then
                    Dim iec As String = ""
                    If Val(dev.UserCapacity / 1024 ^ 3) > 1000 Then
                        iec = Format(Val(dev.UserCapacity / 1024 ^ 4), "#.#") & " TiB"
                    Else
                        iec = Format(Val(dev.UserCapacity / 1024 ^ 3), "#,###") & " GiB"
                    End If
                    Dim si As String = ""
                    If Val(dev.UserCapacity / 1000 ^ 3) > 1000 Then
                        si = Format(Val(dev.UserCapacity / 1000 ^ 4), "#.#") & " TB"
                    Else
                        si = Format(Val(dev.UserCapacity / 1000 ^ 3), "#,###") & " GB"
                    End If
                    .Items(i).SubItems.Add(iec & " / " & si)
                Else
                    .Items(i).SubItems.Add(dev.UserCapacity)
                End If

                Main.FillManageDeviceList()

                .Items(i).Selected = True
                .Items(i).EnsureVisible()

                .Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                .Columns(1).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                .Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                .Columns(3).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                .Columns(3).Width = .Columns(3).Width + 10
                .Columns(4).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)

                .Groups(2).Header = .Groups(2).Tag & " - " & .Groups(2).Items.Count
                Main.SetWindowTheme(.Handle, "explorer", Nothing)
            End With
        End With

        'exit from sub
        Me.Close()
    End Sub
End Class