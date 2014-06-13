using System;
using System.Globalization;

namespace Mamoo.Kata.BirthdayGreetings
{
    public class XDate
    {
        private readonly DateTime _d;

        public int Day
        {
            get { return _d.Day; } 
        }

        public int Month
        {
            get { return _d.Month; }
        }

        public int Year
        {
            get { return _d.Year; }
        }

        public XDate(string d):this(DateTime.ParseExact(d, "yyyy/MM/dd", null, DateTimeStyles.None)) {}

        public XDate(DateTime d)
        {
            _d = d;
            if (d == null) throw new ArgumentNullException("s");
        }

        public bool IsSameDay(object anotherDate)
        {
            if (anotherDate == null) return false;
            if (!(anotherDate is XDate)) return false;
            var date = (XDate) anotherDate;
            return _d.Day == date.Day && _d.Month == date.Month;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is XDate)) return false;
            var _date = (XDate)obj;
            return _date.IsSameDay(this) && _date.Year == this.Year;
        }
    }
}