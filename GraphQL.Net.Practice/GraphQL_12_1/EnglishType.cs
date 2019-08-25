using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_12_1
{
    class EnglishType:ObjectGraphType<English>
    {
        public EnglishType()
        {
            Name = "englishType";
            Description = "personsType的实现类-english";
            Field(c => c.UserId).Description("用户id");
            Field(c => c.Name).Description("姓名");
            Field(c => c.ENEat).Description("西餐");
            Field(c => c.ENSay).Description("英文");
            Interface<PersonsType>();
        }
    }
}
