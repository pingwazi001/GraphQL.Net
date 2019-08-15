using GraphQL.AspNetCore.Entity;
using GraphQL.AspNetCore.GraphQLType.EntityType;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.AspNetCore.GraphQLType.QueryType
{
    public class PersonsQuery:ObjectGraphType
    {
        public PersonsQuery()
        {
            Name = "personsQuery";
            Description = "persons查询的GraphQLType";
            Field<PersonsType>("default", resolve: context => new Persons { Id = 1, Age = 18, Name = "pwz" });
        }
    }
}
