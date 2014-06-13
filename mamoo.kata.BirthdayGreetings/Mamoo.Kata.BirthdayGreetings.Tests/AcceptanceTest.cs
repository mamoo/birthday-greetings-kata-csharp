using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nDumbster.smtp;

namespace Mamoo.Kata.BirthdayGreetings.Tests
{
    [TestClass]
    public class AcceptanceTest
    {
        private const int NONSTANDARD_PORT = 3003;
        private SimpleSmtpServer server;
	    private SmtpMessage[] emailIterator;

	    [TestInitialize] 
	    public void SetUp() {
		    server = SimpleSmtpServer.Start(NONSTANDARD_PORT);
	    }
	
	    [TestCleanup] 
	    public void TearDown() {
		    server.Stop();
	    }
	
	    [TestMethod]
	    public void SendGreetings() {
		    StartBirthdayServiceFor(@"resources\employee_data.txt", "2008/10/08");
		    ExpectNumberOfEmailSentIs(1);
		    ExpectEmailWithSubject_andBody_sentTo("Happy Birthday!", "Happy Birthday, dear John!", "john.doe@foobar.com");
	    }

	    private void ExpectEmailWithSubject_andBody_sentTo(String subject, String body, String recipient) {
		    SmtpMessage message = emailIterator.First();
		    Assert.AreEqual(body, message.Body.Trim());
		    Assert.AreEqual(subject, message.Headers["Subject"]);
		    Assert.AreEqual(recipient, message.Headers["To"]);		
	    }

	    private void ExpectNumberOfEmailSentIs(int expected) {
		    Assert.AreEqual(expected, server.ReceivedEmail.Length);
	    }

	    private void StartBirthdayServiceFor(String employeeFileName, String date) {
		    var service = new BirthdayService();
		    service.SendGreetings(employeeFileName, new XDate(date), "localhost", NONSTANDARD_PORT);
            emailIterator = server.ReceivedEmail;
	    }         
    }
}