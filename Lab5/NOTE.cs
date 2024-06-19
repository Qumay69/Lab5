using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class NOTE<T> : ICloneable, IComparable<NOTE<T>>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public T PhoneNumber { get; set; }
        public int[] BirthDate { get; set; } // [day, month, year]

        public NOTE() { }

        public NOTE(string lastName, string firstName, T phoneNumber, int[] birthDate)
        {
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
        }

        public object Clone()
        {
            return new NOTE<T>(LastName, FirstName, PhoneNumber, (int[])BirthDate.Clone());
        }

        public int CompareTo(NOTE<T> other)
        {
            string thisPhoneStart = PhoneNumber.ToString().Substring(0, 3);
            string otherPhoneStart = other.PhoneNumber.ToString().Substring(0, 3);
            return string.Compare(thisPhoneStart, otherPhoneStart, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}, Phone: {PhoneNumber}, Birth Date: {BirthDate[0]}.{BirthDate[1]}.{BirthDate[2]}";
        }
    }

    public class NoteComparer : IComparer<NOTE<object>>
    {
        public int Compare(NOTE<object> x, NOTE<object> y)
        {
            string xFullName = $"{x.LastName} {x.FirstName}";
            string yFullName = $"{y.LastName} {y.FirstName}";
            return string.Compare(xFullName, yFullName, StringComparison.Ordinal);
        }
    }
}
