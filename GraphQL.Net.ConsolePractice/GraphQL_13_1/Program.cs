using GraphQL;
using GraphQL.Types;
using System;
using static System.Console;

namespace GraphQL_13_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Schema schema = new Schema { Query = new RootQueries() };
            string resultJson = schema.Execute(_ =>
            {
                _.Query = "{queryCatAndDog{ ...on catType{ miaoMiao} ...on dogType{hoHo}}}";

            });
            WriteLine(resultJson);
            ReadKey();
        }
    }
}
