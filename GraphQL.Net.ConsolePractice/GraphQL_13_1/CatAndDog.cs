using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_13_1
{
    class CatAndDog:UnionGraphType
    {
        public CatAndDog()
        {
            Name = "catAndDogType";
            Description = "cat和dog的联合类型";
            Type<CatType>();
            Type<DogType>();
        }
    }
}
