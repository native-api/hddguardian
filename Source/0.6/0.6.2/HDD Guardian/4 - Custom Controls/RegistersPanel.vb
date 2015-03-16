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

Public Class RegistersPanel
    Public Sub ClearRegisters()
        'clear registers row
        lblER.Text = ""
        lblST.Text = ""
        lblSC.Text = ""
        lblSN.Text = ""
        lblCL.Text = ""
        lblCH.Text = ""
        lblDH.Text = ""
        lblError.Text = ""
    End Sub

    Public Sub SetRegisters(ByVal er As String, ByVal st As String, ByVal sc As String, ByVal sn As String, _
                   ByVal cl As String, ByVal ch As String, ByVal dh As String, ByVal err As String)

        'set labels text and layout
        With lblER
            .Text = er
            .AutoSize = True
            ttRegisters.SetToolTip(lblER, "Error register")
        End With

        With lblST
            .Text = st
            .AutoSize = True
            ttRegisters.SetToolTip(lblST, "Status register")
        End With

        With lblSC
            .Text = sc
            .AutoSize = True
            ttRegisters.SetToolTip(lblSC, "Sector count register")
        End With

        With lblSN
            .Text = sn
            .AutoSize = True
            ttRegisters.SetToolTip(lblSN, "Sector number register")
        End With

        With lblCL
            .Text = cl
            .AutoSize = True
            ttRegisters.SetToolTip(lblCL, "Cylinder low register")
        End With

        With lblCH
            .Text = ch
            .AutoSize = True
            ttRegisters.SetToolTip(lblCH, "Cylinder high register")
        End With

        With lblDH
            .Text = dh
            .AutoSize = True
            ttRegisters.SetToolTip(lblDH, "Device/head register")
        End With

        With lblError
            .Text = err
            .AutoSize = True
        End With
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        'tlpRegisters.ColumnStyles.Item(0).SizeType = SizeType.AutoSize
        'tlpRegisters.ColumnStyles.Item(1).SizeType = SizeType.AutoSize
        'tlpRegisters.ColumnStyles.Item(2).SizeType = SizeType.AutoSize
        'tlpRegisters.ColumnStyles.Item(3).SizeType = SizeType.AutoSize
        'tlpRegisters.ColumnStyles.Item(4).SizeType = SizeType.AutoSize
        'tlpRegisters.ColumnStyles.Item(5).SizeType = SizeType.AutoSize
        'tlpRegisters.ColumnStyles.Item(6).SizeType = SizeType.AutoSize
        'the last (number eight) column automatic fill the size of control
        'so, don't need any istruction for size mode
    End Sub
End Class
