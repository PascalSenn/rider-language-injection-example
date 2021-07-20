using System.Collections.Generic;
using HotChocolate.Types;

namespace ExampleServer
{
    public class Query
    {
        [UsePaging]
        public IReadOnlyList<Person> GetPersons() => new[]
            {
                new Person("Luke Skywalker"),
                new Person("Darth Vader")
            };
    }
}