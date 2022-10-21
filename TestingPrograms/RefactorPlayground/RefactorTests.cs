namespace TestingPrograms.RefactorPlayground
{
    [TestFixture]
    internal class RefactorTests
    {
        /// <summary>
        /// This case is not that useful, becuase we already know the type.
        /// </summary>
        [Test]
        public void ReflectionWithGenerics_typeof()
        {
            var dic = new Dictionary<string, int>();
            Console.WriteLine(dic.GetType());

            var dicType = typeof(Dictionary<,>);
            Console.WriteLine(dicType);

            var genericDicType = dicType.MakeGenericType(typeof(string), typeof(int));
            Console.WriteLine(genericDicType);

            // Create an Instance by reflection
            var dicObjInstance = Activator.CreateInstance(genericDicType);
            Console.WriteLine(dicObjInstance);

            // Using Interface
            var dicObj = dicObjInstance as IDictionary<string, int>;
            dicObj.Add("Key1", 1);
            dicObj.Add("Key2", 2);
            dicObj.Add("Key3", 3);
            Console.WriteLine($"there are {dicObj.Count} elemens in the IDictionary.");
        }

        [Test]
        public void ReflectionWithGenerics_TypeName()
        {
            var dic = new Dictionary<string, int>();
            // Console.WriteLine(dic.GetType()); // Output: System.Collections.Generic.Dictionary`2[System.String,System.Int32]

            var dicType = Type.GetType("System.Collections.Generic.Dictionary`2");
            Console.WriteLine(dicType); // Output: System.Collections.Generic.Dictionary`2[TKey,TValue]

            var genericDicType = dicType.MakeGenericType(Type.GetType("System.String"), Type.GetType("System.Int32"));
            Console.WriteLine(genericDicType); // Output: System.Collections.Generic.Dictionary`2[System.String,System.Int32]

            // Create an Instance by reflection
            object? dicObjInstance = Activator.CreateInstance(genericDicType);
            Console.WriteLine(dicObjInstance); // Output: System.Collections.Generic.Dictionary`2[System.String,System.Int32]

            // Using Interface
            var dicObj = dicObjInstance as IDictionary<string, int>;
            dicObj.Add("Key1", 1);
            dicObj.Add("Key2", 2);
            dicObj.Add("Key3", 3);
            Console.WriteLine($"there are {dicObj.Count} elemens in the IDictionary.");
        }
    }
}
