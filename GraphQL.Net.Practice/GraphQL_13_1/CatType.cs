using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_13_1
{
    class CatType:ObjectGraphType<Cat>
    {
        public CatType()
        {
            Name = "catType";
            Description = "cat的type";
            Field(a => a.MiaoMiao).Description("猫的叫");
        }
    }
}
