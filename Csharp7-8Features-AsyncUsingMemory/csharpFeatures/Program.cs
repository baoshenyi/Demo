using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Csharp7();
            //_ = Csharp8Async();
            //asyc call
            //Task.Run(async () =>
            //{ await MakeTea(); }).Wait();
            //Console.ReadLine();
            //foreach (var result in PositiveInts(5))
            //    Console.WriteLine(result);
            testFromIHSMarkit();
        }

        private static void testFromIHSMarkit()
        {
            List<string> characters = new List<string>();

            for (char c = 'A'; c <= 'Z'; c++)
                characters.Add(c.ToString());
            StringBuilder str = new StringBuilder();
            int x = 100;

            foreach (var result in GetAlpha(x))
            {
                var index = (result - 1) % 26;
                str.Append(characters[index] + ", " + result.ToString() + ", ");
            }
        }

        private static IEnumerable<int>  GetAlpha(int x)
        {
            for (int i=1;i<=x;i++)
            {
                yield return i;
            }
        }
        /// <summary>
        /// yeild to get continue numbers instead of memory leaking
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private static IEnumerable<int> PositiveInts(int max)
        {
            int i = 1;
            while (true)
            {
                yield return i++;
                if(i>max)
                    yield break;
            }
        }

        public static async Task MakeTea()
        {
            var boilingWater = BoilWaterAsync();
            Console.WriteLine("take the cups out");

            //no waiting time here, another thread?
            var a = 0;
            for (int i = 0; i < 10000000; i++)
            {
                a += 1;//5 seconds
            }

            Console.WriteLine("pub tea in cups");
            //save thread state to be saved to thread pool (RAM)
            //await start a new thread
            //https://marketplace.visualstudio.com/items?itemName=SharpDevelopTeam.ILSpy
            var water = await boilingWater;//pre-request
            Console.WriteLine($"pour {water} in cups");
        }

        public static async Task<string> BoilWaterAsync()
        {
            Console.WriteLine("open the kettle");
            Console.WriteLine("waiting for the kettle");

            await Task.Delay(5000);
            Console.WriteLine("kettle finished boiling");
            return "hot water";
        }

        /// <summary>
        ///<PropertyGroup>
        //  <TargetFramework>netcoreapp3.1</TargetFramework>
        //  <LangVersion>8.0</LangVersion>
        //  <Nullable>enable</Nullable>
        //  <NullableContextOptions>enable</NullableContextOptions>
        //</PropertyGroup>
        /// </summary>
        private static async Task Csharp8Async() {
            //1. Readonly members
            //   private readonly string strReadONLY = "string";
            //2. Default interface method
            //3. Recursive Pattern Matching?
            //4. Switch expressin and Property patterns
            //   FromRainbowClassic
            //5. Tuple patterns
            //   RockPaperScissors
            //6. Positional patterns
            //  Point point = new Point(2, 3);
            //  var result = point.GetQuadrant(point);
            //7. Using declaration for variable
            //   using var file = new System.IO.StreamWriter("WriteLines2.txt");
            //8. Static local functions
            //  LocalFunction(); void LocalFunction() => y = 0;
            //9. Asynchronous stream
            //  var result = GenerateSequence();
            //10.Indices and ranges
            var words = new string[]
            {
                            // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };
            Console.WriteLine($"The last word is {words[^1]}");
            var quickBrownFox = words[1..4];
            Console.WriteLine($"quickBrownFox is {quickBrownFox.Aggregate((i,j)=>i+","+j)}");
            //11. Null-coalescing assignment
            List<int>? numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
            Console.WriteLine(i);  // output: 17
            //12. Unmanaged constructed types : Coords
            //13. Enhancement of interpolated verbatim strings : $@"..."

        }

        public struct Coords<T>
        {
            public T X;
            public T Y;
        }

        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(1000);
                //return successive elements in the asynchronous stream
                yield return i;
            }
            //int b=1, a=1;
            //int c = a * b; 
        }

        public class Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) => (X, Y) = (x, y);

            public void Deconstruct(out int x, out int y) =>
                (x, y) = (X, Y);

            public enum Quadrant
            {
                Unknown,
                Origin,
                One,
                Two,
                Three,
                Four,
                OnBorder
            }

            public Quadrant GetQuadrant(Point point) => point switch
            {
                (0, 0) => Quadrant.Origin,
                var (x, y) when x > 0 && y > 0 => Quadrant.One,
                var (x, y) when x < 0 && y > 0 => Quadrant.Two,
                var (x, y) when x < 0 && y < 0 => Quadrant.Three,
                var (x, y) when x > 0 && y < 0 => Quadrant.Four,
                var (_, _) => Quadrant.OnBorder,
                _ => Quadrant.Unknown
            };

        }



        /// <summary>
        /// Tuple input, this is example of 2 inputs
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static string RockPaperScissors(string first, string second)
        => (first, second) switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scissors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper covers rock. Paper wins.",
            ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
            ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
            ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
            (_, _) => "tie"
        };

        /// <summary>
        /// block body method to => expression method
        /// say 'such that' for "=>"
        /// say "discard" for "_
        /// </summary>
        /// <param name="colorBand"></param>
        /// <returns></returns>
        public static Color FromRainbowClassic(Rainbow colorBand) => colorBand switch
        {
            Rainbow.Red => Color.FromArgb(0xFF, 0x00, 0x00),
            Rainbow.Orange => Color.FromArgb(0xFF, 0x7F, 0x00),
            Rainbow.Yellow => Color.FromArgb(0xFF, 0xFF, 0x00),
            _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
        };

        public enum Rainbow
        {
            Red,
            Orange,
            Yellow
        }

        interface IDefaultInterfaceMethod
        {
            public void DefaultMethod()
            {
                Console.WriteLine("I am a default method in the interface!");
            }
        }


        
        private static void Csharp7()
        {
            string ageString = "21";
            int ageInt = 20;
            object ageObj = ageString;
            //1.Inline out variable
            //2.Pattern match
            if (ageObj is int age || (ageObj is string ageText
                && int.TryParse(ageText, out age)))
            {
                Console.WriteLine($"Your age is {age}."); 
                //var str = string.Format("your age {0}", age.ToString());
                //var str1 = "your age " + age.ToString() + "!";
            }
            else
            {
                Console.WriteLine("I do not know your age!");
            }

            //3. Powerful switch statement (finally)
            Employee emp1 = new Employee()
            {
                Name = "Shenyi",
                IsManager = false,
                YearsWorked = 2
            };
            Employee emp2 = new Employee()
            {
                Name = "Jianmei",
                IsManager = true,
                YearsWorked = 28
            };
            Customer cust1 = new Customer()
            {
                Name = "Jerry",
                TotalDollarSpent = 2342.15M
            };

            List<object> people = new List<object>() { emp1, emp2, cust1 };
            foreach (var p in people)
            {
                switch (p)
                {
                    //case nameof(Employee):
                    case Employee e when (e.IsManager == false):
                        Console.WriteLine($"{e.Name} is a good employee");
                        break;
                    case Employee e when (e.IsManager == true):
                        Console.WriteLine($"{e.Name} is a good manager");
                        break;
                    case Customer c when (c.TotalDollarSpent > 1000):
                        Console.WriteLine($"{c.Name} is a royal customer");
                        break;
                    case Customer c when (c.TotalDollarSpent <= 1000):
                        Console.WriteLine($"{c.Name} needs spend more");
                        break;
                    default:
                        break;
                }
            }

            //4. throw exception inside expression
            List<Employee> employes = new List<Employee>() { emp1, emp2 };
            Employee manager = employes.Where(x => x.IsManager).FirstOrDefault() ??
                throw new Exception("there is a problem to find manager");

            //Employee manager1 = employes.Where(x => x.IsManager).FirstOrDefault();
            //if(manager1 == null)
            //    throw new Exception("there is a problem to find manager");
            Console.WriteLine($"the manager is {manager.Name}");

            //5. Improved Tuples
            var name = "Shenyi Bao";
            var splitName = SplitName(name);
            Console.WriteLine($"First name:{splitName.FirstName} Last name:{splitName.LastName}");
        }

        /// <summary>
        /// structure, class
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static (string FirstName, string LastName) SplitName(string name)
        {
            string[] value = name.Split(" ");
            if (value.Length >= 2)
                return (value[0], value[1]);
            return ("", "");

        }
    }
}
