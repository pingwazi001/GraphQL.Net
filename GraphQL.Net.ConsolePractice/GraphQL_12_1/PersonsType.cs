using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_12_1
{
    public class PersonsType:InterfaceGraphType<Persons>
    {
        public PersonsType()
        {
            Name = "personsType";
            Description = "接口类型";
            Field(p => p.UserId).Description("用户id");
            Field(p => p.Name).Description("姓名");
        }
    }
}
