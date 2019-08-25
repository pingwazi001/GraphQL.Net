using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_11_1
{
    public class InputPersonsType:InputObjectGraphType<Persons>
    {
        public InputPersonsType()
        {
            Name = "inputPersonsType";
            Description = "graphql中的persons的输入类型";
            Field(p => p.UserId).Description("用户id");
            Field(p => p.Age).Description("年龄");
            Field(p => p.Name).Description("姓名");
        }
    }
}
