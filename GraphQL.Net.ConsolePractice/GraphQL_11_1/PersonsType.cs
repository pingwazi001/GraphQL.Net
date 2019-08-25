using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_11_1
{
    public class PersonsType:ObjectGraphType<Persons>
    {
        public PersonsType()
        {
            Name = "personsType";
            Description = "graphql中的persons类型";
            Field(p => p.UserId).Description("用户id");
            Field(p => p.Age).Description("年龄");
            Field(p => p.Name).Description("姓名");
        }
    }
}
