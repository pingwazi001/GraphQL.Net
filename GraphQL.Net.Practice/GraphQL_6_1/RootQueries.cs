using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_6_1
{
    public class RootQueries:ObjectGraphType
    {
        public RootQueries()
        {
            Name = "rootQueries";
            Description = "根查询";
            Field<PersonsType>("queryPerson",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context =>
                {
                    string name = context.GetArgument<string>("name");
                    Console.WriteLine($"我的名字是：{name}");
                    return new Persons { Id = 1, Name = "pwz", Age = 10, Addr = "四川省成都市" };
                });
        }
    }
}
