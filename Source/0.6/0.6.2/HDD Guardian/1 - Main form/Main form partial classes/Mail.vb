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

Imports System.Net.Mail

Partial Class Main
    Function SendMail(ByVal title As String, ByVal content As String, Optional ByVal html As Boolean = False) As Boolean

        Try
            PrintDebug("Start of mail setup", False, True)

            Dim login, pwd, port, host As String
            Dim ssl As Boolean

            With My.Settings
                login = .MailServerLogin
                Dim dec As New Aes
                pwd = dec.Decrypt(.MailServerPassword, aes_key, aes_iv)
                port = .MailServerPort
                host = .MailServerHost
                ssl = .MailServerUseSsl
            End With

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            If My.Settings.MailServerLogin.Length > 0 Then
                Smtp_Server.Credentials = New Net.NetworkCredential(login, pwd)
            Else
                Smtp_Server.Credentials = Nothing
            End If
            Smtp_Server.Port = port
            Smtp_Server.EnableSsl = ssl
            Smtp_Server.Host = host

            e_mail = New MailMessage()
            e_mail.IsBodyHtml = html
            If My.Settings.MailServerLogin.Length > 0 Then
                If My.Settings.MailFrom.Length > 0 Then
                    e_mail.From = New MailAddress(My.Settings.MailFrom, "HDD Guardian")
                Else
                    e_mail.From = New MailAddress(My.Settings.MailServerLogin, "HDD Guardian")
                End If
            Else
                e_mail.From = New MailAddress("local network")
            End If
            e_mail.To.Add(My.Settings.MailTo.Replace(" ", ""))
            If My.Settings.MailSubject.Length > 0 Then
                e_mail.Subject = title & " | " & My.Settings.MailSubject
            Else
                e_mail.Subject = title
            End If
            If My.Settings.MailContent.Length > 0 Then
                e_mail.Body = content & vbCrLf & vbCrLf & My.Settings.MailContent
            Else
                e_mail.Body = content
            End If
            Smtp_Server.Send(e_mail)

            PrintDebug("Mail sent to " & My.Settings.MailTo, False, True)

            Return True

        Catch error_t As Exception
            PrintDebug(error_t.Message)

            Return False
        End Try
    End Function

    Dim alreadysended As Boolean = False

    Public Sub RegularReport(Optional ByVal sendnow As Boolean = False)
        Dim nowtime As Boolean = False

        If IsDate(My.Settings.MailDailyTime) Then
            Dim t As DateTime = My.Settings.MailDailyTime
            If My.Settings.MailDailyReport And (Now.Hour = t.Hour) And Now.Minute >= t.Minute And (Now.Minute <= t.Minute + My.Settings.DataUpdate) Then
                nowtime = True
            End If
            t = Nothing
        End If

        If (My.Settings.MailWeeklyReport And (alreadysended = False) And My.Settings.MailDayNumber + 1 = Today.DayOfWeek) Or (sendnow = True) Or _
            nowtime Then
            Dim r As String = ""

            'first, add header to html...
            r += "<html><head><meta http-equiv=""content-type"" content=""text/html; charset=utf-8"">" & vbCrLf
            r += "<style type=""text/css"">" & vbCrLf
            r += "table{border-collapse:collapse;font-family:Arial;font-size:14px;}" & vbCrLf
            r += "table, tr, td, th{padding:5px 5px;border:1px solid #c0c0c0;}" & vbCrLf
            r += "th{font-weight:bold;background-color:#c0c0c0;color:#000000}" & vbCrLf
            r += ".ar{text-align:right}" & vbCrLf
            r += ".grey{background-color:#efefef}" & vbCrLf
            r += "</style></head><body>" & vbCrLf

            For i As Short = 0 To devlist.Count - 1 Step 1
                Dim d As Device = devlist(i)
                r += "<table>" & vbCrLf
                r += "<tr>" & vbCrLf
                r += "<th colspan=""2"">" & d.Model & " (" & d.SerialNumber & ")</th>" & vbCrLf
                r += "</tr>" & vbCrLf
                r += "<tr>" & vbCrLf
                r += "<td class=""grey"">Location</td>" & vbCrLf
                If d.Type = DeviceType.Virtual Then
                    r += "<td class=""ar"">" & d.VirtualDeviceInfo.Description & "</td>" & vbCrLf
                Else
                    r += "<td class=""ar"">" & d.Location & "</td>" & vbCrLf
                End If
                r += "</tr>" & vbCrLf
                r += "<tr>" & vbCrLf
                r += "<td class=""grey"">Type</td>" & vbCrLf
                If d.Type = DeviceType.SCSI Or d.Type = DeviceType.ATA Then
                    r += "<td class=""ar"">Internal</td>" & vbCrLf
                ElseIf d.Type = DeviceType.USB Then
                    r += "<td class=""ar"">External</td>" & vbCrLf
                Else
                    r += "<td class=""ar"">Virtual</td>" & vbCrLf
                End If
                r += "</tr>" & vbCrLf
                r += "<tr>" & vbCrLf
                r += "<td class=""grey"">Temperature</td>" & vbCrLf
                r += "<td class=""ar"">" & CorF(d.Temperature) & "</td>" & vbCrLf
                r += "</tr>" & vbCrLf
                r += "<tr>" & vbCrLf
                r += "<td class=""grey"">Health check</td>" & vbCrLf
                r += "<td class=""ar"">" & d.Health.ToString & "</td>" & vbCrLf
                r += "</tr>" & vbCrLf
                r += "<tr>" & vbCrLf
                r += "<td class=""grey"">Reliabilty</td>" & vbCrLf
                r += "<td class=""ar"">" & d.ReliabilityRating.Overall & "/5</td>" & vbCrLf
                r += "</tr>" & vbCrLf
                If d.IsScsi Then
                    r += "<tr>" & vbCrLf
                    r += "<td class=""grey"">Non medium errors</td>" & vbCrLf
                    r += "<td class=""ar"">" & d.NonMediumErrors & "</td>" & vbCrLf
                    r += "</tr>" & vbCrLf
                    r += "<tr>" & vbCrLf
                    r += "<td class=""grey"">Grown defects count</td>" & vbCrLf
                    r += "<td class=""ar"">" & d.GrownDefectsCount & "</td>" & vbCrLf
                    r += "</tr>" & vbCrLf
                Else
                    r += "<tr>" & vbCrLf
                    r += "<td class=""grey"">ATA errors</td>" & vbCrLf
                    r += "<td class=""ar"">" & d.TotalErrors & "</td>" & vbCrLf
                    r += "</tr>" & vbCrLf
                    r += "<tr>" & vbCrLf
                    r += "<td class=""grey"">Bad sectors</td>" & vbCrLf
                    r += "<td class=""ar"">" & d.BadSectorsCount & "</td>" & vbCrLf
                    r += "</tr>" & vbCrLf
                End If
                If d.IsSsd Then
                    r += "<tr>" & vbCrLf
                    r += "<td class=""grey"">Remaining life</td>" & vbCrLf
                    r += "<td class=""ar"">" & d.RemainingLife & "%</td>" & vbCrLf
                    r += "</tr>" & vbCrLf
                End If
                r += "</table>" & vbCrLf
                r += "<br></br>" & vbCrLf

            Next
            r += "</body></html>" & vbCrLf

            PrintDebug("Sending regular report...", False, True)

            alreadysended = SendMail("Current devices status report", r, True)
            r = Nothing
        End If
    End Sub
End Class
