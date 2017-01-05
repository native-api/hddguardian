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

    Public Function GetDeviceImage(ByVal index As Short) As Bitmap
        Dim dev As Device = devlist(index)

        If dev.Type = DeviceType.Threeware Then Return My.Resources.threeware

        Dim model, manufacturer As String

        If dev.Type = DeviceType.SCSI Then
            model = dev.Scsi.Info.Product
            manufacturer = dev.Scsi.Info.Vendor
        Else
            model = dev.ATA.Info.Model
            manufacturer = dev.ATA.Info.Family
        End If

        For i As Short = 0 To manufacturersList.Count - 1
            Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
            If re.Match(model).Success Then
                If dev.Type = DeviceType.USB Then
                    Return manufacturersList(i).USB
                ElseIf dev.Type = DeviceType.ATA Then
                    If dev.ATA.IsSsd Then
                        Return manufacturersList(i).SDD
                    Else
                        Return manufacturersList(i).HDD
                    End If
                ElseIf dev.Type = DeviceType.SCSI Then
                    Return manufacturersList(i).HDD
                End If
                re = Nothing
                dev = Nothing
            End If
        Next

        'try with manufacturer
        For i As Short = 0 To manufacturersList.Count - 1
            Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
            If re.Match(manufacturer).Success Then
                If dev.Type = DeviceType.USB Then
                    Return manufacturersList(i).USB
                ElseIf dev.Type = DeviceType.ATA Then
                    If dev.ATA.IsSsd Then
                        Return manufacturersList(i).SDD
                    Else
                        Return manufacturersList(i).HDD
                    End If
                ElseIf dev.Type = DeviceType.SCSI Then
                    Return manufacturersList(i).HDD
                End If
                re = Nothing
                dev = Nothing
            End If
        Next


        If dev.Type = DeviceType.USB Then
            Return My.Resources.XCraft
        Else
            Return My.Resources.Raptor_X
        End If

    End Function

    Public Sub SetManufacturer(ByVal dev As Device)
        picManufacturer.Image = Nothing

        Dim m As String
        If dev.Type = DeviceType.SCSI Then
            m = dev.Scsi.Info.Vendor
        Else
            m = dev.ATA.Info.Model
        End If

        'try to detect manufacturer from device model
        For i As Short = 0 To manufacturersList.Count - 1
            If Not IsNothing(m) Then
                Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                If re.Match(m).Success Then
                    picManufacturer.Image = manufacturersList(i).Banner
                    lnkManufacturer.Text = manufacturersList(i).FullName
                    lnkManufacturer.Tag = manufacturersList(i).Web
                    re = Nothing
                    Exit Sub
                End If
            End If
        Next

        'try to detect manufacturer from device family if the previous block have failed
        If dev.Type <> DeviceType.SCSI Then
            For i As Short = 0 To manufacturersList.Count - 1
                If Not IsNothing(dev.ATA.Info.Family) Then
                    Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                    If re.Match(dev.ATA.Info.Family).Success Then
                        picManufacturer.Image = manufacturersList(i).Banner
                        lnkManufacturer.Text = manufacturersList(i).FullName
                        lnkManufacturer.Tag = manufacturersList(i).Web
                        re = Nothing
                        Exit Sub
                        re = Nothing
                        Exit Sub
                    End If
                End If
            Next
        End If

        If dev.Type = DeviceType.Threeware Then
            lnkManufacturer.Text = "3ware"
            lnkManufacturer.Tag = "http://www.lsi.com/products/raid-controllers/pages/default.aspx"
            picManufacturer.Image = My.Resources.threewarelogo
        End If
    End Sub

End Class
