using System;
using System.Globalization;
using System.Net.Mail;

namespace Mamoo.Kata.BirthdayGreetings
{
    public class BirthdayService
    {
	    public void SendGreetings(String fileName, XDate xDate, String smtpHost, int smtpPort) {
            if (System.IO.File.Exists(fileName))
            {
                var objReader = new System.IO.StreamReader(fileName);
                do
                {
                    var textLine = objReader.ReadLine();
                    if (!String.IsNullOrEmpty(textLine) && !textLine.Contains("last_name"))
                    {
                        var employeeData = textLine.Split(new char[]{','});
                        var employee = new Employee()
                        {
                            FirstName = employeeData[1],
                            LastName = employeeData[0],
                            BirthDate = new XDate(employeeData[2]),
                            Email = employeeData[3]
                        };
                        if (employee.IsBirthday(xDate))
                        {
                            var recipient = employee.Email;
                            var body = String.Format("Happy Birthday, dear {0}!", employee.FirstName);
                            var subject = "Happy Birthday!";
                            SendMessage(smtpHost, smtpPort, "sender@here.com", subject, body, recipient);
                        }
                    }
                } while (objReader.Peek() != -1);
            }

	    }

	    private void SendMessage(String smtpHost, int smtpPort, String sender, String subject, String body, String recipient) {
		    // Create a mail session
		    //java.util.Properties props = new java.util.Properties();
		    //props.put("mail.smtp.host", smtpHost);
		    //props.put("mail.smtp.port", "" + smtpPort);
		    
		    // Construct the message
		    var  msg = new MailMessage(sender, recipient, subject, body);
		    // Send the message
		    SendMessage(msg);

	    }

	    // made protected for testing :-(
	    protected void SendMessage(MailMessage mail)
	    {
	        var smtpClient = new SmtpClient();//"mail.MyWebsiteDomainName.com", 25);
            smtpClient.Credentials = new System.Net.NetworkCredential("info@MyWebsiteDomainName.com", "myIDPassword");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = false;
            smtpClient.Send(mail);
	    }         
    }
}