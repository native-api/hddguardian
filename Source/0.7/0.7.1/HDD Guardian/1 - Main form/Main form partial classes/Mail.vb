'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://hddguardian.codeplex.com/
'
'Copyright (C) 2010-2017 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System.Net.Mail

Partial Class Main
    Function SendMail(ByVal title As String, ByVal content As String, Optional ByVal html As Boolean = False) As Boolean

        Try
            PrintDebug("Start of mail setup", False, True)

            Dim login, pwd, host As String
            Dim port As Short
            Dim ssl As Boolean

            With AppSettings.Mail
                login = .Login
                If .Password.Length > 0 Then
                    Dim dec As New Aes
                    pwd = dec.Decrypt(.Password, aes_key, aes_iv)
                Else
                    pwd = ""
                End If
                port = Val(.SmtpPort)
                host = .SmtpServer
                ssl = .UseSsl


                Dim Smtp_Server As New SmtpClient
                Dim e_mail As New MailMessage()
                Smtp_Server.UseDefaultCredentials = False
                If .Login.Length > 0 Then
                    Smtp_Server.Credentials = New Net.NetworkCredential(login, pwd)
                Else
                    Smtp_Server.Credentials = Nothing
                End If
                Smtp_Server.Port = port
                Smtp_Server.EnableSsl = ssl
                Smtp_Server.Host = host

                e_mail = New MailMessage()
                e_mail.IsBodyHtml = html
                If AppSettings.Mail.Login.Length > 0 Then
                    If .Sender.Length > 0 Then
                        e_mail.From = New MailAddress(.Sender, "HDD Guardian")
                    Else
                        e_mail.From = New MailAddress(.Login, "HDD Guardian")
                    End If
                Else
                    e_mail.From = New MailAddress("local network")
                End If
                e_mail.To.Add(.Destination.Replace(" ", ""))
                If .Subject.Length > 0 Then
                    e_mail.Subject = title & " | " & .Subject
                Else
                    e_mail.Subject = title
                End If
                If .Body.Length > 0 Then
                    e_mail.Body = content & vbCrLf & vbCrLf & .Body
                Else
                    e_mail.Body = content
                End If
                Smtp_Server.Send(e_mail)

                PrintDebug("Mail sent to " & .Destination, False, True)

                Return True

            End With
        Catch error_t As Exception
            PrintDebug(error_t.Message)

            Return False
        End Try
    End Function

    Dim alreadysended As Boolean = False

    Public Sub RegularReport(Optional ByVal sendnow As Boolean = False)
        Dim nowtime As Boolean = False

        With AppSettings.Mail
            If IsDate(.ReportTime) Then
                Dim t As DateTime = .ReportTime
                If .Report = CustomSettings.SettingsMail.MailReport.Daily And (Now.Hour = t.Hour) And Now.Minute >= t.Minute And (Now.Minute <= t.Minute + AppSettings.Refresh.Internal) Then
                    nowtime = True
                End If
                t = Nothing
            End If

            If (.Report = CustomSettings.SettingsMail.MailReport.Weekly And (alreadysended = False) And .ReportDay + 1 = Today.DayOfWeek) Or (sendnow = True) Or _
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
                    If d.Type = DeviceType.SCSI Then
                        r += "<th colspan=""2"">" & d.Scsi.Info.Product & " (" & d.Scsi.Info.SerialNumber & ")</th>" & vbCrLf
                    Else
                        r += "<th colspan=""2"">" & d.ATA.Info.Model & " (" & d.ATA.Info.SerialNumber & ")</th>" & vbCrLf
                    End If
                    r += "</tr>" & vbCrLf
                    r += "<tr>" & vbCrLf
                    r += "<td class=""grey"">Location</td>" & vbCrLf
                    If d.IsVirtual Then
                        r += "<td class=""ar"">" & d.VirtualDeviceName & "</td>" & vbCrLf
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
                    If d.Type = DeviceType.SCSI Then
                        r += "<tr>" & vbCrLf
                        r += "<td class=""grey"">Non medium errors</td>" & vbCrLf
                        r += "<td class=""ar"">" & d.Scsi.Health.NonMediumErrors & "</td>" & vbCrLf
                        r += "</tr>" & vbCrLf
                        r += "<tr>" & vbCrLf
                        r += "<td class=""grey"">Grown defects count</td>" & vbCrLf
                        r += "<td class=""ar"">" & d.Scsi.Health.GrownDefectsCount & "</td>" & vbCrLf
                        r += "</tr>" & vbCrLf
                    Else
                        r += "<tr>" & vbCrLf
                        r += "<td class=""grey"">Reliabilty</td>" & vbCrLf
                        If d.ATA.Reliability.Overall >= 0 Then
                            r += "<td class=""ar"">" & d.ATA.Reliability.Overall & "/5</td>" & vbCrLf
                        Else
                            r += "<td class=""ar"">-</td>" & vbCrLf
                        End If
                        r += "</tr>" & vbCrLf
                        r += "<tr>" & vbCrLf
                        r += "<td class=""grey"">ATA errors</td>" & vbCrLf
                        r += "<td class=""ar"">" & d.ATA.Errors.TotalAmount & "</td>" & vbCrLf
                        r += "</tr>" & vbCrLf
                        r += "<tr>" & vbCrLf
                        r += "<td class=""grey"">Bad sectors</td>" & vbCrLf
                        r += "<td class=""ar"">" & d.ATA.Health.BadSectorsCount & "</td>" & vbCrLf
                        r += "</tr>" & vbCrLf
                        If d.ATA.IsSsd Then
                            r += "<tr>" & vbCrLf
                            r += "<td class=""grey"">Remaining life</td>" & vbCrLf
                            If IsNumeric(d.ATA.Health.RemainingLife) Then
                                r += "<td class=""ar"">" & d.ATA.Health.RemainingLife & "%</td>" & vbCrLf
                            Else
                                r += "<td class=""ar"">" & d.ATA.Health.RemainingLife & "</td>" & vbCrLf
                            End If
                            r += "</tr>" & vbCrLf
                        End If
                    End If
                    r += "</table>" & vbCrLf
                    r += "<br></br>" & vbCrLf

                Next
                r += "</body></html>" & vbCrLf

                alreadysended = SendMail("Current devices status report", r, True)
                r = Nothing
            End If
        End With
    End Sub
End Class
