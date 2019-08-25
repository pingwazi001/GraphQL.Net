using GraphQL.Instrumentation;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_23_1
{
    class MyMiddleWare
    {
        public Task<object> Resolve(ResolveFieldContext context, FieldMiddlewareDelegate next)
        {
            var metadata = new Dictionary<string, object>
            {
                {"typeName", context.ParentType.Name},
                {"fieldName", context.FieldName},
                {"path", context.Path}
            };
            //Console.WriteLine("hello world");
            using (context.Metrics.Subject("field", context.FieldName, metadata))
            {
                return next(context);
            }
        }
    }
}
