using System;
using System.Collections.Generic;
using System.Text;

namespace LinqForList
{
    public class SamplesDelegate
    {

        // Declares a delegate for a method that takes in an int and returns a String.
        public delegate String myMethodDelegate(int myInt);

        // Defines some methods to which the delegate can point.
        public class mySampleClass
        {

            // Defines an instance method.
            public String myStringMethod(int myInt)
            {
                if (myInt > 0)
                    return ("positive");
                if (myInt < 0)
                    return ("negative");
                return ("zero");
            }

            // Defines a static method.
            public static String mySignMethod(int myInt)
            {
                if (myInt > 0)
                    return ("+");
                if (myInt < 0)
                    return ("-");
                return ("");
            }
            
        }
    }


    /*
    This code produces the following output:

    5 is positive; use the sign "+".
    -3 is negative; use the sign "-".
    0 is zero; use the sign "".
    */

}
