using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mamoo.Kata.BirthdayGreetings.Tests
{
    [TestClass]
    public class XDateTests
    {
	    [TestMethod]
	    public void getters() {
		    var xDate = new XDate("1789/01/24");
		    Assert.AreEqual(1, xDate.Month);
		    Assert.AreEqual(24, xDate.Day);
	    }
	
	    [TestMethod]
	    public void isSameDate()  {
		    var xDate = new XDate("1789/01/24");
		    var sameDay = new XDate("2001/01/24");
		    var notSameDay = new XDate("1789/01/25");
		    var notSameMonth = new XDate("1789/02/25");

            Assert.IsTrue(xDate.IsSameDay(sameDay), "same");
            Assert.IsFalse(xDate.IsSameDay(notSameDay), "not same day");
            Assert.IsFalse(xDate.IsSameDay(notSameMonth), "not same month");
	    }
	
	    [TestMethod]
	    public void equality() {
		    var baseDate = new XDate("2000/01/02");
		    var same = new XDate("2000/01/02");
		    var different = new XDate("2000/01/04");

            Assert.IsFalse(baseDate.Equals(null));
            Assert.IsFalse(baseDate.Equals(""));
            Assert.IsTrue(baseDate.Equals(baseDate));
            Assert.IsTrue(baseDate.Equals(same));
            Assert.IsFalse(baseDate.Equals(different));
	    }         
    }
}