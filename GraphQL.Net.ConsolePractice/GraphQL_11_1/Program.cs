
using GraphQL;
using GraphQL.Types;
using System;
using static System.Console;

namespace GraphQL_11_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string paramJson = "{\"specialPerson\":{\"userId\":1,\"name\":\"pwz\",\"age\":10}}";
            Schema schema = new Schema { Mutation = new RootMutations() };
            string resultJson = schema.Execute(_=> {
                _.Query = "mutation createPersons($specialPerson:inputPersonsType){ addPerson(person:$specialPerson) { userId name}}";
                _.Inputs = paramJson.ToInputs();
            });
            WriteLine(resultJson);
            ReadKey();
        }
    }
}
