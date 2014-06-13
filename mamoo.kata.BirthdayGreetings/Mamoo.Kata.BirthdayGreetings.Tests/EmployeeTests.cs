using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mamoo.Kata.BirthdayGreetings.Tests
{
    [TestClass]
    public class EmployeeTests
    {
	    [TestMethod]
	    public void TestBirthday() {
		    var employee = new Employee()
		    {
                FirstName = "foo",
                LastName = "bar",
                BirthDate = new XDate(new DateTime(1999, 09, 30)),
                Email = "a@b.c"
		    };
            Assert.IsFalse(employee.IsBirthday(new XDate(new DateTime(1999, 09, 29))), "It is not his birthday");
            Assert.IsTrue(employee.IsBirthday(new XDate(new DateTime(1999, 09, 30))), "It is his birthday");
	    }
	
	    [TestMethod]
	    public void TestEquality() {
            var baseEmployee = new Employee()
            {
                FirstName = "First",
                LastName = "Last",
                BirthDate = new XDate(new DateTime(1999, 09, 01)),
                Email = "first@last.com"
            }; 
            var same = new Employee()
            {
                FirstName = "First",
                LastName = "Last",
                BirthDate = new XDate(new DateTime(1999, 09, 01)),
                Email = "first@last.com"
            }; 
		    var different = new Employee()
            {
                FirstName = "First",
                LastName = "Last",
                BirthDate = new XDate(new DateTime(1999, 09, 01)),
                Email = "boom@boom.com"
            }; 

            Assert.IsFalse(baseEmployee.Equals(null));
            Assert.IsFalse(baseEmployee.Equals(""));
            Assert.IsTrue(baseEmployee.Equals(same));
            Assert.IsFalse(baseEmployee.Equals(different));
	    }
    }
}
