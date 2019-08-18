using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_6_1
{
    public class PersonsType:ObjectGraphType<Persons>
    {
        public PersonsType()
        {
            Name = "persons";
            Description = "人";
            Field(a => a.Id).Description("编号");
            Field(a => a.Name).Description("姓名");
            Field(a => a.Age).Description("年龄");
            Field(a => a.Addr).Description("地址");
        }
    }
}
