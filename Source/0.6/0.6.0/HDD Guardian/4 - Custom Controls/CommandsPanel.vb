'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home pages are http://code.google.com/p/hddguardian/
'               http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Public Class CommandsPanel

    Dim m_poweruptooltip As String = ""
    Dim m_poweruptooltiptitle As String = ""
    Dim m_index As Short = 0

    Public Sub HideRows(ByVal rows As Integer)
        'clear registers labels
        m_index = 0

        If rows = 0 Then Exit Sub
        For i As Short = 5 - rows To 5
            tlpCommands.Controls("lblCR" & i).Visible = False
            tlpCommands.Controls("lblFR" & i).Visible = False
            tlpCommands.Controls("lblSC" & i).Visible = False
            tlpCommands.Controls("lblSN" & i).Visible = False
            tlpCommands.Controls("lblCL" & i).Visible = False
            tlpCommands.Controls("lblCH" & i).Visible = False
            tlpCommands.Controls("lblDH" & i).Visible = False
            tlpCommands.Controls("lblDC" & i).Visible = False
            tlpCommands.Controls("lblPowerUP" & i).Visible = False
            tlpCommands.Controls("lblCmd" & i).Visible = False
        Next
    End Sub

    Public Sub SetPowerUpTooltip(ByVal title As String, ByVal caption As String)
        m_poweruptooltip = caption
        m_poweruptooltiptitle = title
    End Sub

    Public Sub AddCommand(ByVal cr As String, ByVal fr As String, ByVal sc As String, ByVal sn As String, _
                          ByVal cl As String, ByVal ch As String, ByVal dh As String, ByVal dc As String, _
                          ByVal poweruptime As String, ByVal command As String)

        m_index += 1

        'now, set labels text and layout
        With tlpCommands.Controls("lblCR" & m_index)
            .Visible = True
            .Text = cr
            ttCommands.SetToolTip(tlpCommands.Controls("lblCR" & m_index), "Command register")
        End With

        With tlpCommands.Controls("lblFR" & m_index)
            .Visible = True
            .Text = fr
            ttCommands.SetToolTip(tlpCommands.Controls("lblFR" & m_index), "Fetaures register")
        End With

        With tlpCommands.Controls("lblSC" & m_index)
            .Visible = True
            .Text = sc
            ttCommands.SetToolTip(tlpCommands.Controls("lblSC" & m_index), "Sector count register")
        End With

        With tlpCommands.Controls("lblSN" & m_index)
            .Visible = True
            .Text = sn
            ttCommands.SetToolTip(tlpCommands.Controls("lblSN" & m_index), "Sector number register")
        End With

        With tlpCommands.Controls("lblCL" & m_index)
            .Visible = True
            .Text = cl
            ttCommands.SetToolTip(tlpCommands.Controls("lblCL" & m_index), "Cylinder low register")
        End With

        With tlpCommands.Controls("lblCH" & m_index)
            .Visible = True
            .Text = ch
            ttCommands.SetToolTip(tlpCommands.Controls("lblCH" & m_index), "Cylinder high register")
        End With

        With tlpCommands.Controls("lblDH" & m_index)
            .Visible = True
            .Text = dh
            ttCommands.SetToolTip(tlpCommands.Controls("lblDH" & m_index), "Device/head register")
        End With

        With tlpCommands.Controls("lblDC" & m_index)
            .Visible = True
            .Text = dc
            ttCommands.SetToolTip(tlpCommands.Controls("lblDC" & m_index), "Device command register")
        End With

        With tlpCommands.Controls("lblPowerUp" & m_index)
            .Visible = True
            .Text = poweruptime
            ttPowerUp.ToolTipTitle = m_poweruptooltiptitle
            ttPowerUp.SetToolTip(tlpCommands.Controls("lblPowerUp" & m_index), m_poweruptooltip)
        End With

        With tlpCommands.Controls("lblCmd" & m_index)
            .Visible = True
            .Text = command
        End With
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        'tlpCommands.ColumnStyles.Item(0).SizeType = SizeType.AutoSize
        'tlpCommands.ColumnStyles.Item(1).SizeType = SizeType.AutoSize
        'tlpCommands.ColumnStyles.Item(2).SizeType = SizeType.AutoSize
        'tlpCommands.ColumnStyles.Item(3).SizeType = SizeType.AutoSize
        'tlpCommands.ColumnStyles.Item(4).SizeType = SizeType.AutoSize
        'tlpCommands.ColumnStyles.Item(5).SizeType = SizeType.AutoSize
        'tlpCommands.ColumnStyles.Item(6).SizeType = SizeType.AutoSize
        'tlpCommands.ColumnStyles.Item(7).SizeType = SizeType.AutoSize
        'tlpCommands.ColumnStyles.Item(8).SizeType = SizeType.AutoSize
        'the last (tenth) column automatic fill the size of control
        'so, don't need any istruction for size mode
    End Sub

End Class
