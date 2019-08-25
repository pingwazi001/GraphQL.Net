using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_13_1
{
    class DogType:ObjectGraphType<Dog>
    {
        public DogType()
        {
            Name = "dogType";
            Description = "dog 的类型";
            Field(a => a.HoHo).Description("dog的叫声");
        }
    }
}
