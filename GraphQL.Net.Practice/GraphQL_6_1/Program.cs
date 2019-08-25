using GraphQL;
using GraphQL.Types;
using System;

namespace GraphQL_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 第一种传参数的方式
            /*
            Schema schema = new Schema { Query = new RootQueries() };
            string resultJson=schema.Execute(_ =>
            {
                _.Query = "{queryPerson(name:\"pwz\"){id name age}}";
            });
            Console.WriteLine(resultJson);
            Console.ReadKey();
            */
            #endregion
            #region 第二中传参数的方式
            string variableJson = "{name:'pwz'}";
            Inputs inputs = variableJson.ToInputs();
            Schema schema = new Schema { Query = new RootQueries() };
            string resultJson = schema.Execute(_ =>
            {
                _.Query = "query rootQueries($name:String){queryPerson(name:$name){id name age}}";
                _.Inputs = inputs;
            });
            Console.WriteLine(resultJson);
            Console.ReadKey();
            #endregion
        }
    }
}
