using GraphQL;
using GraphQL.Types;
using System;

namespace GraphQL_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Schema schema = new Schema { Query = new RootQueries() };
            string resultJson=schema.Execute(_ =>
            {
                _.Query = "{queryPerson{id name age}}";
            });
            Console.WriteLine(resultJson);
            Console.ReadKey();
        }
    }
}
