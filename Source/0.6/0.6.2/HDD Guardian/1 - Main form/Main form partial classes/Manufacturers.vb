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

Imports System.Xml
Imports System.Text.RegularExpressions

Partial Class Main

    Structure Manufacturer
        Dim Name As String
        Dim RegExp, Web As String
        Dim Banner As Image
        Dim HDD As Image
        Dim USB As Image
        Dim SDD As Image
        Dim FullName As String
    End Structure

    Class Manufacturers
        Inherits List(Of Manufacturer)
    End Class

    Public manufacturersList As New Manufacturers

    Private Sub LoadManufacturers()
        Dim man_folder As String = My.Application.Info.DirectoryPath & "\graphics\manufacturers\"

        Dim m_xmldoc As New XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmldoc.Load(man_folder & "manufacturers.xml")
        m_nodelist = m_xmldoc.SelectNodes("/manufacturers/manufacturer")

        manufacturersList.Clear()
        For Each m_node In m_nodelist
            Dim vendor As New Manufacturer
            With vendor
                .Name = m_node.Attributes.GetNamedItem("folder").Value
                .RegExp = m_node.Attributes.GetNamedItem("regex").Value
                .Banner = Image.FromFile(man_folder & .Name & "\logo.png")
                If IO.File.Exists(man_folder & .Name & "\hdd.png") Then
                    .HDD = Image.FromFile(man_folder & .Name & "\hdd.png")
                Else
                    .HDD = My.Resources.Raptor_X
                End If
                If IO.File.Exists(man_folder & .Name & "\usb.png") Then
                    .USB = Image.FromFile(man_folder & .Name & "\usb.png")
                Else
                    .USB = My.Resources.XCraft
                End If
                If IO.File.Exists(man_folder & .Name & "\ssd.png") Then
                    .SDD = Image.FromFile(man_folder & .Name & "\ssd.png")
                Else
                    .SDD = My.Resources.XCraft
                End If
                .Web = m_node.Attributes.GetNamedItem("web").Value
                .FullName = m_node.Attributes.GetNamedItem("fullname").Value
            End With
            manufacturersList.Add(vendor)
        Next
    End Sub

    Public Sub SetDeviceImage()
        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)

        picDeviceImage.Image = Nothing
        lnkManufacturer.Text = ""

        'try to detect manufacturer from device model
        For i As Short = 0 To manufacturersList.Count - 1
            If Not IsNothing(dev.Model) Then
                Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                If re.Match(dev.Model).Success Then
                    If dev.Type = DeviceType.USB Then
                        picDeviceImage.Image = manufacturersList(i).USB
                    Else
                        If dev.IsSsd Then
                            picDeviceImage.Image = manufacturersList(i).SDD
                        Else
                            picDeviceImage.Image = manufacturersList(i).HDD
                        End If
                    End If
                    lnkManufacturer.Text = manufacturersList(i).FullName
                    lnkManufacturer.Tag = manufacturersList(i).Web
                    re = Nothing
                    dev = Nothing
                    Exit Sub
                End If
            End If
        Next

        'try to detect manufacturer from device family if the previous block have failed
        If IsNothing(picDeviceImage.Image) Then
            For i As Short = 0 To manufacturersList.Count - 1
                If Not IsNothing(dev.Family) Then
                    Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                    If re.Match(dev.Family).Success Then
                        If dev.Type = DeviceType.USB Then
                            picDeviceImage.Image = manufacturersList(i).USB
                        Else
                            If dev.IsSsd Then
                                picDeviceImage.Image = manufacturersList(i).SDD
                            Else
                                picDeviceImage.Image = manufacturersList(i).HDD
                            End If
                        End If
                        lnkManufacturer.Text = manufacturersList(i).FullName
                        lnkManufacturer.Tag = manufacturersList(i).Web
                        re = Nothing
                        dev = Nothing
                        Exit Sub
                    End If
                End If
            Next
        End If

        If IsNothing(picDeviceImage.Image) Then
            If dev.Type = DeviceType.USB Then
                picDeviceImage.Image = My.Resources.XCraft
            ElseIf dev.Type = DeviceType.Threeware Then
                picDeviceImage.Image = My.Resources.threeware
                lnkManufacturer.Text = "3ware"
                lnkManufacturer.Tag = "http://www.lsi.com/products/raid-controllers/pages/default.aspx"
            Else
                picDeviceImage.Image = My.Resources.Raptor_X
            End If
        End If
        dev = Nothing
    End Sub

    Public Sub SetBottomPanelManufacturer()
        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)

        'try to detect manufacturer from device model
        For i As Short = 0 To manufacturersList.Count - 1
            If Not IsNothing(dev.Model) Then
                Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                If re.Match(dev.Model).Success Then
                    lnkManufacturer.Text = manufacturersList(i).FullName
                    lnkManufacturer.Tag = manufacturersList(i).Web
                    re = Nothing
                    dev = Nothing
                    Exit Sub
                End If
            End If
        Next

        'try to detect manufacturer from device family if the previous block have failed
        For i As Short = 0 To manufacturersList.Count - 1
            If Not IsNothing(dev.Family) Then
                Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                If re.Match(dev.Family).Success Then
                    lnkManufacturer.Text = manufacturersList(i).FullName
                    lnkManufacturer.Tag = manufacturersList(i).Web
                    re = Nothing
                    dev = Nothing
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Public Sub SetManufacturer()
        Dim dev As Device = devlist(cboDevices.SelectedIndex)

        picScsiVendor.Image = Nothing
        picManufacturer.Image = Nothing

        'try to detect manufacturer from device model
        For i As Short = 0 To manufacturersList.Count - 1
            If Not IsNothing(dev.Model) Then
                Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                If re.Match(dev.Model).Success Then
                    If dev.IsScsi Then
                        picScsiVendor.Image = manufacturersList(i).Banner
                        lnkVendor.Text = manufacturersList(i).FullName
                        lnkVendor.Tag = manufacturersList(i).Web
                    Else
                        picManufacturer.Image = manufacturersList(i).Banner
                        lnkAtaManufacturer.Text = manufacturersList(i).FullName
                        lnkAtaManufacturer.Tag = manufacturersList(i).Web
                    End If
                    re = Nothing
                    dev = Nothing
                    Exit Sub
                End If
            End If
        Next

        'try to detect manufacturer from device family if the previous block have failed
        For i As Short = 0 To manufacturersList.Count - 1
            If Not IsNothing(dev.Family) Then
                Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                If re.Match(dev.Family).Success Then
                    If dev.IsScsi Then
                        picScsiVendor.Image = manufacturersList(i).Banner
                        lnkVendor.Text = manufacturersList(i).FullName
                        lnkVendor.Tag = manufacturersList(i).Web
                    Else
                        picManufacturer.Image = manufacturersList(i).Banner
                        lnkAtaManufacturer.Text = manufacturersList(i).FullName
                        lnkAtaManufacturer.Tag = manufacturersList(i).Web
                    End If
                    re = Nothing
                    dev = Nothing
                    Exit Sub
                End If
            End If
        Next

        If dev.Type = DeviceType.Threeware Then
            lnkAtaManufacturer.Text = "3ware"
            lnkAtaManufacturer.Tag = "http://www.lsi.com/products/raid-controllers/pages/default.aspx"
            picManufacturer.Image = My.Resources.threewarelogo
            dev = Nothing
        End If
    End Sub

End Class
