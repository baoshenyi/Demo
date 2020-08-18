using System;
using System.Collections.Generic;
using System.Text;

namespace LinqForList
{
    public class ListManager
    {
        public static List<Person> LoadSampleData()
        {
            List<Person> output = new List<Person>()
            {
                new Person{FirstName="Tim", LastName="Corey", Birth=DateTime.Parse("1970-2-25"), YearsOfExperience = 10 },
                new Person{FirstName="Shenyi", LastName="Bao", Birth=DateTime.Parse("1968-4-25"), YearsOfExperience = 13 },
                new Person{FirstName="Austin", LastName="Bao", Birth=DateTime.Parse("1990-4-25"), YearsOfExperience = 14 },
                new Person{FirstName="Jianmei", LastName="Luo", Birth=DateTime.Parse("1975-4-25"), YearsOfExperience = 7 },
            };
            return output;
        }
    }
}
