'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2014 Samuele Parise
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
        Dim Internal As Image
        Dim External As Image
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
                .Name = m_node.Attributes.GetNamedItem("name").Value
                .RegExp = m_node.ChildNodes.Item(0).InnerText
                .Banner = Image.FromFile(man_folder & m_node.ChildNodes.Item(1).InnerText)
                If IO.File.Exists(man_folder & "internal\" & m_node.ChildNodes.Item(1).InnerText) Then
                    .Internal = Image.FromFile(man_folder & "internal\" & m_node.ChildNodes.Item(1).InnerText)
                Else
                    .Internal = My.Resources.Raptor_X
                End If
                If IO.File.Exists(man_folder & "external\" & m_node.ChildNodes.Item(1).InnerText) Then
                    .External = Image.FromFile(man_folder & "external\" & m_node.ChildNodes.Item(1).InnerText)
                Else
                    .External = My.Resources.XCraft
                End If
                .Web = m_node.ChildNodes.Item(2).InnerText
                .FullName = m_node.ChildNodes(3).InnerText
            End With
            manufacturersList.Add(vendor)
        Next
    End Sub

    Public Sub SetDeviceImage()
        Dim dev As Device = devlist(lvwDevices.SelectedItems(0).Index)

        picDeviceImage.BackgroundImage = Nothing

        'try to detect manufacturer from device model
        For i As Short = 0 To manufacturersList.Count - 1
            If Not IsNothing(dev.Model) Then
                Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                If re.Match(dev.Model).Success Then
                    If dev.Type = DeviceType.USB Then
                        picDeviceImage.BackgroundImage = manufacturersList(i).External
                    Else
                        picDeviceImage.BackgroundImage = manufacturersList(i).Internal
                    End If
                    If dev.IsScsi Then
                        lnkManufacturer.Text = manufacturersList(i).FullName
                        lnkManufacturer.Tag = manufacturersList(i).Web
                    Else
                        lnkManufacturer.Text = manufacturersList(i).FullName
                        lnkManufacturer.Tag = manufacturersList(i).Web
                    End If
                    Exit Sub
                End If
            End If
        Next

        'try to detect manufacturer from device family if the previous block have failed
        If IsNothing(picDeviceImage.BackgroundImage) Then
            For i As Short = 0 To manufacturersList.Count - 1
                If Not IsNothing(dev.Family) Then
                    Dim re As New Regex(manufacturersList(i).RegExp, RegexOptions.IgnoreCase)
                    If re.Match(dev.Family).Success Then
                        If dev.Type = DeviceType.USB Then
                            picDeviceImage.BackgroundImage = manufacturersList(i).External
                        Else
                            picDeviceImage.BackgroundImage = manufacturersList(i).Internal
                        End If
                        If dev.IsScsi Then
                            lnkManufacturer.Text = manufacturersList(i).FullName
                            lnkManufacturer.Tag = manufacturersList(i).Web
                        Else
                            lnkManufacturer.Text = manufacturersList(i).FullName
                            lnkManufacturer.Tag = manufacturersList(i).Web
                        End If
                        Exit Sub
                    End If
                End If
            Next
        End If

        If IsNothing(picDeviceImage.BackgroundImage) Then
            If dev.Type = DeviceType.USB Then
                picDeviceImage.BackgroundImage = My.Resources.XCraft
            Else
                picDeviceImage.BackgroundImage = My.Resources.Raptor_X
            End If
        End If
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
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Public Sub SetManufacturer()
        Dim dev As Device = devlist(cboDevices.SelectedIndex) ' devlist(lvwDevices.SelectedItems(0).Index)

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
                    Exit Sub
                End If
            End If
        Next

        'try to detect manufacturer from device family if the previous block have failed
        If IsNothing(picDeviceImage.BackgroundImage) Then
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
                        Exit Sub
                    End If
                End If
            Next
        End If
    End Sub

End Class
