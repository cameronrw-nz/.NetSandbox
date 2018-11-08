namespace UnitTestProject1
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The reflection test.
    /// </summary>
    [TestClass]
    public class ReflectionTest
    {
        // MSDN Example for Reflection
        [TestMethod]
        public void MsdnExample()
        {
            int i = 42;
            Type type = i.GetType();
            Console.WriteLine(type);

            // Using Reflection to get information from an Assembly:  
            Assembly info = typeof(Int32).Assembly;
            Console.WriteLine(info);
        }

        [TestMethod]
        public void GetAttributesTest()
        {
            // Get the Current class attribute.
            var testClassAttribute = (TestClassAttribute)Attribute.GetCustomAttribute(GetType(), typeof(TestClassAttribute));
            Console.WriteLine($"The current class attribute is: {testClassAttribute}");

            // Get the Current method attribute.
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            var testMethodAttribute = (TestMethodAttribute)currentMethod.GetCustomAttribute(typeof(TestMethodAttribute));
            Console.WriteLine($"The current method attribute is: {testMethodAttribute}");

            // Get the SerializableObject attribute.
            var dataContractAttribute = (DataContractAttribute)Attribute.GetCustomAttribute(typeof(SerializableObject), typeof(DataContractAttribute));
            Console.WriteLine($"The SerializableObject attribute is: {dataContractAttribute}");
            Console.WriteLine($"The SerializableObject name attribute is: {dataContractAttribute?.Name}");

            // Get the SerializableObject.TestMethod attribute.
            var conditionalAttribute =
                (ConditionalAttribute)
                typeof(SerializableObject).GetMethod(nameof(SerializableObject.TestMethod))?.GetCustomAttribute(typeof(ConditionalAttribute));
            Console.WriteLine($"The TestMethod attribute is: {conditionalAttribute}");
            Console.WriteLine($"The TestMethod ConditionString attribute is: {conditionalAttribute?.ConditionString}");

            // Get the SerializableObject.TestProperty attribute.
            var dataMemberAttribute =
                (DataMemberAttribute)
                typeof(SerializableObject).GetProperty(nameof(SerializableObject.TestProperty))?.GetCustomAttribute(typeof(DataMemberAttribute));
            Console.WriteLine($"The TestProperty attribute is: {dataMemberAttribute}");
            Console.WriteLine($"The TestProperty order attribute is: {dataMemberAttribute?.Order}");
        }

        [TestMethod]
        public void GetPrivateFieldsTest()
        {
            var serializableObject = new SerializableObject();

            var privateField = typeof(SerializableObject).GetField("_privateField", BindingFlags.Instance | BindingFlags.NonPublic);

            if (privateField != null)
            {
                Console.WriteLine($"The private field is: {privateField}");
                Console.WriteLine($"The private field old value is: {privateField.GetValue(serializableObject)}");

                privateField.SetValue(serializableObject, 100);
                Console.WriteLine($"The private field new value is: {privateField.GetValue(serializableObject)}");
            }
            else
            {
                Console.WriteLine("The private field is not returned");
            }
        }

        [DataContract(Name = "TestAttribute")]
        private class SerializableObject
        {
            private int _privateField = 0;

            [DataMember(Order = 1)]
            public string TestProperty { get; set; }

            [Conditional(conditionString: "DEBUG")]
            public void TestMethod()
            {
            }
        }
    }
}