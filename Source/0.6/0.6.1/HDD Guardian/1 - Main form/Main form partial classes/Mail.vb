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

Imports System.Net.Mail

Partial Class Main
    Function SendMail(ByVal title As String, ByVal content As String) As Boolean

        Try
            PrintDebug("Start of mail setup", False, True)

            Dim login, pwd, port, host As String
            Dim ssl As Boolean

            With My.Settings
                login = .ServerLogin
                Dim dec As New Aes
                pwd = dec.Decrypt(.ServerPassword, aes_key, aes_iv)
                port = .ServerPort
                host = .ServerHost
                ssl = .ServerUseSsl
            End With

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            If My.Settings.ServerLogin.Length > 0 Then
                Smtp_Server.Credentials = New Net.NetworkCredential(login, pwd)
            Else
                Smtp_Server.Credentials = Nothing
            End If
            Smtp_Server.Port = port
            Smtp_Server.EnableSsl = ssl
            Smtp_Server.Host = host

            e_mail = New MailMessage()
            If My.Settings.ServerLogin.Length > 0 Then
                e_mail.From = New MailAddress(login, "HDD Guardian")
            Else
                e_mail.From = New MailAddress("local network")
            End If
            e_mail.To.Add(My.Settings.MailDestination)
            e_mail.Subject = title
            e_mail.IsBodyHtml = False
            e_mail.Body = content
            Smtp_Server.Send(e_mail)

            PrintDebug("Mail sent to " & My.Settings.MailDestination, False, True)

            Return True

        Catch error_t As Exception
            PrintDebug(error_t.ToString)

            Return False
        End Try
    End Function
End Class
