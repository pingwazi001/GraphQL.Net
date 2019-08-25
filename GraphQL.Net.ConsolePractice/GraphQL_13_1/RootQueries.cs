using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_13_1
{
    class RootQueries:ObjectGraphType
    {
        public RootQueries()
        {
            Name = "rootQueries";
            Description = "查询根";
            Field<CatAndDog>("queryCatAndDog",resolve:context=> new Dog { HoHo="吼吼"});
        }
    }
}
