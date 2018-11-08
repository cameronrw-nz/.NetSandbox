namespace UnitTestProject1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    // Following MSDN to learn about boxing and unboxing
    // Boxing is the term used to "put" a value type into a reference type. Commonly used in method signatures e.g. string.Concat(object arg0, object arg1, object arg2)
    // The value type exists on the stack but when boxing it the value is not on the heap with a reference to the value existing on the stack
    // Unboxing is the act of explicitly stating the value type of the object, i.e going from object to int
    [TestClass]
    public class BoxingTest
    {
        // From MSDN
        [TestMethod]
        public void ChangingValueTest()
        {
            int i = 123;

            // Boxing copies the value of i into object o.
            object o = i;

            // Change the value of i.
            i = 456;

            // The change in i doesn't affect the value stored in o.
            Console.WriteLine("The value-type value = {0}", i);
            Console.WriteLine("The object-type value = {0}", o);
        }

        // From MSDN
        [TestMethod]
        public void BoxingExample2()
        {
            // String.Concat example.
            // String.Concat has many versions. Rest the mouse pointer on 
            // Concat in the following statement to verify that the version
            // that is used here takes three object arguments. Both 42 and
            // true must be boxed.
            Console.WriteLine(string.Concat("Answer", 42, true));

            // List example.
            // Create a list of objects to hold a heterogeneous collection 
            // of elements.
            List<object> mixedList = new List<object>();

            // Add a string element to the list. 
            mixedList.Add("First Group:");

            // Add some integers to the list. 
            for (int j = 1; j < 5; j++)
            {
                // Rest the mouse pointer over j to verify that you are adding
                // an int to a list of objects. Each element j is boxed when 
                // you add j to mixedList.
                mixedList.Add(j);
            }

            // Add another string and more integers.
            mixedList.Add("Second Group:");
            for (int j = 5; j < 10; j++)
            {
                mixedList.Add(j);
            }

            // Display the elements in the list. Declare the loop variable by 
            // using var, so that the compiler assigns its type.
            foreach (var item in mixedList)
            {
                // Rest the mouse pointer over item to verify that the elements
                // of mixedList are objects.
                Console.WriteLine(item);
            }

            // The following loop sums the squares of the first group of boxed
            // integers in mixedList. The list elements are objects, and cannot
            // be multiplied or added to the sum until they are unboxed. The
            // unboxing must be done explicitly.
            var sum = 0;
            for (var j = 1; j < 5; j++)
            {
                // The following statement causes a compiler error: Operator 
                // '*' cannot be applied to operands of type 'object' and
                // 'object'. 
                // sum += mixedList[j] * mixedList[j];

                // After the list elements are unboxed, the computation does 
                // not cause a compiler error.
                sum += (int)mixedList[j] * (int)mixedList[j];
            }

            // The sum displayed is 30, the sum of 1 + 4 + 9 + 16.
            Console.WriteLine("Sum: " + sum);

            // Output:
            // Answer42True
            // First Group:
            // 1
            // 2
            // 3
            // 4
            // Second Group:
            // 5
            // 6
            // 7
            // 8
            // 9
            // Sum: 30
        }

        [TestMethod]
        public void BoxingAndUnboxing()
        {
            int i = 100;
            object o = i;

            Console.WriteLine(i); // 100
            Console.WriteLine(o); // 100

            o = 101;

            Console.WriteLine(i); // 100
            Console.WriteLine(o); // 101

            int j = (int)o;
            i = (int)o;

            Console.WriteLine(i); // 101
            Console.WriteLine(j); // 101
        }

        [TestMethod]
        public void BoxingExamples()
        {
            ArrayList arrayList = new ArrayList();

            // this will do implicit boxing as the add method only accepts things of type object
            arrayList.Add(100);

            double d = 2.718281828459045;
            object o = d; // box

            try
            {
                int i = (int)o; // runtime exception due to needing to unbox before casting to int
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("{0} Error: Incorrect unboxing.", e.Message);
            }

            int successfullyCast = (int)(double)o;
            Console.WriteLine(successfullyCast);
        }
    }
}