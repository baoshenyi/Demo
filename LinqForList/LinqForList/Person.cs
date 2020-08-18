using System;
using System.Collections.Generic;
using System.Text;

namespace LinqForList
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime Birth { get; set; }
        public  string FullName => $"{FirstName} {LastName}";
    }
}
