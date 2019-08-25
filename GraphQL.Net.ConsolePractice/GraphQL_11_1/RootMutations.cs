using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_11_1
{
    public  class RootMutations:ObjectGraphType
    {
        public RootMutations()
        {
            Name = "rootMutations";
            Description = "查询根";
            Field<PersonsType>("addPerson", arguments: new QueryArguments(new QueryArgument<InputPersonsType> { Name = "person" }),
                resolve: context =>
                {
                    Persons person = context.GetArgument<Persons>("person");
                    person.UserId += 1;
                    return person;
                });
        }
    }
}
