'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
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
                If .CustomServer Then
                    login = .ServerLogin
                    pwd = .ServerPassword
                    port = .ServerPort
                    host = .ServerHost
                    ssl = .ServerUseSsl
                Else
                    login = defaultmail
                    pwd = password
                    port = 587
                    host = "smtp.gmail.com"
                    ssl = True
                End If
            End With

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(login, pwd)
            Smtp_Server.Port = port
            Smtp_Server.EnableSsl = ssl
            Smtp_Server.Host = host

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(defaultmail, "HDD Guardian")
            e_mail.To.Add(My.Settings.MailDestination)
            e_mail.Subject = title
            e_mail.IsBodyHtml = False
            e_mail.Body = content
            Smtp_Server.Send(e_mail)

            Return True

            PrintDebug("Mail sent to " & My.Settings.MailDestination, False, True)

        Catch error_t As Exception
            Return False

            PrintDebug(error_t.ToString)
        End Try
    End Function
End Class
