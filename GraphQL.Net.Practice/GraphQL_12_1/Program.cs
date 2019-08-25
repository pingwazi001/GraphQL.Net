using GraphQL.Types;
using GraphQL;
using System;
using static System.Console;

namespace GraphQL_12_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Schema schema = new Schema { Query = new RootQueries() };
            schema.RegisterType<ChineseType>();
            schema.RegisterType<EnglishType>();
            string resultJson = schema.Execute(_ =>
            {
                _.Query = "{queryPerson{ ...on chineseType{userId name cNEat cNSay} ...on englishType{userId name eNEat eNSay} }}";

            });
            WriteLine(resultJson);
            ReadKey();
        }
    }
}
