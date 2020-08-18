using System;
using System.Collections.Generic;
using System.Linq;
using static LinqForList.SamplesDelegate;

namespace LinqForList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ListManager.LoadSampleData();

            people = people.OrderBy(x => x.LastName).ToList();
            foreach (var person in people)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} ({person.Birth.ToShortDateString()}): Experience {person.YearsOfExperience}");
            }
            Console.WriteLine(" ");
            people = people.OrderByDescending(x => x.LastName).ToList();
            foreach (var person in people)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} ({person.Birth.ToShortDateString()}): Experience {person.YearsOfExperience}");
            }
            Console.WriteLine(" ");
            people = people.OrderByDescending(x => x.LastName).ThenByDescending(x => x.YearsOfExperience).ToList();
            foreach (var person in people)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} ({person.Birth.ToShortDateString()}): Experience {person.YearsOfExperience}");
            }
            Console.WriteLine(" ");

            List<Person> peopleList = ListManager.LoadSampleData();
            var personDefault = peopleList.Where(x => x.YearsOfExperience > 10).Select(x => x).FirstOrDefault();
            Console.WriteLine($"{personDefault.FirstName} {personDefault.LastName} ({personDefault.Birth.ToShortDateString()}): Experience {personDefault.YearsOfExperience}");
            Console.WriteLine(" ");

            //elvis-operator ?
            personDefault = peopleList.Where(x => x.YearsOfExperience > 16).Select(x => x).FirstOrDefault();
            Console.WriteLine($"{personDefault?.FirstName} {personDefault?.LastName} ({personDefault?.Birth.ToShortDateString()}): Experience {personDefault?.YearsOfExperience}");
            Console.WriteLine(" ");

            int years = people.Sum(x => x.YearsOfExperience);
            Console.WriteLine($"{years}");
            Console.WriteLine(" ");

            var personName = peopleList.OrderByDescending(x => x.YearsOfExperience).Select(x => x.FullName).FirstOrDefault();
            Console.WriteLine($"{personName}");
            Console.WriteLine(" ");

            string strNull = null;
            //Null-conditional operator
            int length = strNull?.Length ?? 0; // 0 if people is null

            List<Guest> guests = new List<Guest>(){
                new Guest{ Name = "Shenyi", Age = 52 },
                new Guest { Name = "Jianmei", Age = 49 },
                new Guest { Name = "Austin", Age = 14 }
            };

            var party = new Party<Guest>(guests);

            foreach(var guest in party)
            {
                Console.WriteLine($"{guest.Name} {guest.Age}");
            }

            IEnumerable<int> list1 = new int[]
            {
                1,
                2,
                1
            };

            // Empty list.
            List<int> list = new List<int>();
            var result = list.DefaultIfEmpty();

            // One element in collection with default(int) value.
            foreach (var value in result)
            {
                Console.WriteLine(value);
            }

            result = list.DefaultIfEmpty(-1);

            // One element in collection with -1 value.
            foreach (var value in result)
            {
                Console.WriteLine(value);
            }

            //default
            void Display<T>(T[] values) => Console.WriteLine($"[ {string.Join(", ", values)} ]");

            Display(InitializeArray<int>(3));  // output: [ 0, 0, 0 ]
            Display(InitializeArray<bool>(4, default));  // output: [ False, False, False, False ]

            System.Numerics.Complex fillValue = default;
            Display(InitializeArray(3, fillValue));  // output: [ (0, 0), (0, 0), (0, 0) ]
            Display(InitializeArray<int?>(2, default));
            

            //delegate
            delegateFuc();

            Console.ReadLine();

        }

        static void delegateFuc()
        {
            // Creates one delegate for each method. For the instance method, an
            // instance (mySC) must be supplied. For the static method, use the
            // class name.
            mySampleClass mySC = new mySampleClass();
            myMethodDelegate myD1 = new myMethodDelegate(mySC.myStringMethod);
            myMethodDelegate myD2 = new myMethodDelegate(mySampleClass.mySignMethod);

            // Invokes the delegates.
            Console.WriteLine("{0} is {1}; use the sign \"{2}\".", 5, myD1(5), myD2(5));
            Console.WriteLine("{0} is {1}; use the sign \"{2}\".", -3, myD1(-3), myD2(-3));
            Console.WriteLine("{0} is {1}; use the sign \"{2}\".", 0, myD1(0), myD2(0));
        }

        static T[] InitializeArray<T>(int length, T initialValue = default)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Array length must be nonnegative.");
            }

            var array = new T[length];
            for (var i = 0; i < length; i++)
            {
                array[i] = initialValue;
            }
            return array;
        }
    }
}
