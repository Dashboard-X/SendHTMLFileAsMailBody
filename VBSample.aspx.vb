Imports System.Net.Mail
Imports System.IO
Imports System.Configuration
Partial Class VBSample
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs)

    End Sub
    Protected Sub btnSend_Click(sender As Object, e As EventArgs)
        SendHTMLMail()
    End Sub
    ' Method Which is used to Get HTML File and replace HTML File values with dynamic values and send mail 
    Public Sub SendHTMLMail()
        Dim reader As New StreamReader(Server.MapPath("~/HTMLPage.htm"))
        Dim readFile As String = reader.ReadToEnd()
        Dim myString As String = ""
        myString = readFile
        myString = myString.Replace("$$Admin$$", "Suresh Dasari")
        myString = myString.Replace("$$CompanyName$$", "Dasari Group")
        myString = myString.Replace("$$Email$$", "suresh@gmail.com")
        myString = myString.Replace("$$Website$$", "http://www.aspdotnet-suresh.com")
        Dim Msg As New MailMessage()
        Dim fromMail As New MailAddress("administrator@aspdotnet-suresh.com")
        ' Sender e-mail address.
        Msg.From = fromMail
        ' Recipient e-mail address.
        Msg.[To].Add(New MailAddress("suresh@gmail.com"))
        ' Subject of e-mail
        Msg.Subject = "Send Mail with HTML File"
        Msg.Body = myString.ToString()
        Msg.IsBodyHtml = True
        Dim sSmtpServer As String = ""
        sSmtpServer = "10.2.69.121"
        Dim a As New SmtpClient()
        a.Host = sSmtpServer
        a.Send(Msg)
        reader.Dispose()
    End Sub

End Class
