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

Public Class CapabilitesList

    Dim m_index As Integer

    Public Sub Clear()
        m_index = 0
        'clear all rows and destroy all labels
        With tlpList
            .AutoScroll = False
            .Visible = False
            For i As Short = 1 To 10
                .Controls("lblCap" & i).Text = ""
                .Controls("lblCap" & i).Visible = False
                .Controls("lblValue" & i).Text = ""
                .Controls("lblValue" & i).Visible = False
                .Controls("lblMeaning" & i).Text = ""
                .Controls("lblMeaning" & i).Visible = False
            Next
            .Visible = True
        End With
    End Sub

    Public Sub Add(ByVal capability As String, ByVal value As String, ByVal meaning As String)
        m_index += 1

        'select the row labels
        Dim lblcapability, lblvalue, lblmeaning As String
        lblcapability = "lblCap" & m_index
        lblvalue = "lblValue" & m_index
        lblmeaning = "lblMeaning" & m_index

        'set labels caption
        Me.tlpList.Controls(lblcapability).Text = capability
        Me.tlpList.Controls(lblvalue).Text = value
        Me.tlpList.Controls(lblmeaning).Text = meaning
        Me.tlpList.Controls(lblcapability).Visible = True
        Me.tlpList.Controls(lblvalue).Visible = True
        Me.tlpList.Controls(lblmeaning).Visible = True
        tlpList.AutoScroll = True
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        tlpList.ColumnStyles.Item(0).SizeType = SizeType.AutoSize
        tlpList.ColumnStyles.Item(1).SizeType = SizeType.AutoSize
        'the last (third) column automatic fill the size of control
        'so, don't need any istruction for size mode

        'the scroll capability was setted for tablelayoutpanel (tlpList), not for the usercontrol!

        'note: this is the simpliest way to create a listview with multilines on items!
    End Sub

End Class
