using GraphQL.AspNetCore.Entity;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.AspNetCore.GraphQLType.EntityType
{
    public class PersonsType:ObjectGraphType<Persons>
    {
        public PersonsType()
        {
            Name = "personsType";
            Description = "persons对应的GraphQLType";
            Field(p => p.Id).Description("编号");
            Field(p => p.Name).Description("姓名");
            Field(p => p.Age).Description("年龄");
        }
    }
}
