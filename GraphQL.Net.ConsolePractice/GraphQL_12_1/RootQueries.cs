using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_12_1
{
    class RootQueries:ObjectGraphType
    {
        public RootQueries()
        {
            Name = "rootQueries";
            Description = "查询根";
            Field<PersonsType>("queryPerson", resolve: context =>
            {
                //return new Chinese { UserId = 1, Name = "pwz", CNEat = "川菜", CNSay = "四川话" };
                return new English { UserId = 1, Name = "pwz", ENEat = "西餐", ENSay = "英文" };
            });
        }
    }
}
