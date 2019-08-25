using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_23_1
{
    public class RootQueries:ObjectGraphType
    {
        public RootQueries()
        {
            Name = "rootQueries";
            Description = "根查询";
            Field<PersonsType>("queryPerson", resolve: context => new Persons { Id = 1, Name = "pwz", Age = 10, Addr = "四川省成都市" });
        }
    }
}
