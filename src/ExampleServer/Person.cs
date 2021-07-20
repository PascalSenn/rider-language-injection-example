using HotChocolate;

namespace ExampleServer
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        [GraphQLDescription("The name of the person")]
        public string Name { get; }
    }
}