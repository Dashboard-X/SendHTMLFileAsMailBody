using System;
using System.Net.Mail;
using System.IO;


public partial class SendMailwithHtml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        SendHTMLMail();
    }
    // Method Which is used to Get HTML File and replace HTML File values with dynamic values and send mail 
    public void SendHTMLMail()
      {
        StreamReader reader = new StreamReader(Server.MapPath("~/HTMLPage.htm"));
        string readFile = reader.ReadToEnd();
        string myString = "";
        myString = readFile;
        myString = myString.Replace("$$Admin$$", "Suresh Dasari");
        myString = myString.Replace("$$CompanyName$$", "Dasari Group");
        myString = myString.Replace("$$Email$$", "suresh@gmail.com");
        myString = myString.Replace("$$Website$$", "http://www.aspdotnet-suresh.com");
        MailMessage Msg = new MailMessage();
        MailAddress fromMail = new MailAddress("administrator@aspdotnet-suresh.com");
        // Sender e-mail address.
        Msg.From = fromMail;
        // Recipient e-mail address.
        Msg.To.Add(new MailAddress("suresh@gmail.com"));
        // Subject of e-mail
        Msg.Subject = "Send Mail with HTML File";
        Msg.Body = myString.ToString();
        Msg.IsBodyHtml = true;
        string sSmtpServer = "";
        sSmtpServer = "10.2.69.121";
        SmtpClient a = new SmtpClient();
        a.Host = sSmtpServer;
        a.Send(Msg);
        reader.Dispose();
    }
  
}