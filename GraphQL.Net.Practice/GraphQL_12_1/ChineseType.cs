using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_12_1
{
    class ChineseType:ObjectGraphType<Chinese>
    {
        public ChineseType()
        {
            Name = "chineseType";
            Description = "personsType的实现类-chinese";
            Field(c => c.UserId).Description("用户id");
            Field(c => c.Name).Description("姓名");
            Field(c => c.CNEat).Description("中餐");
            Field(c => c.CNSay).Description("中文");
            Interface<PersonsType>();
        }
    }
}
