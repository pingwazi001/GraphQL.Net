using GraphQL.Net.Subscription.Model;
using GraphQL.Types;

namespace GraphQL.Net.Subscription.Schema.Type
{
    public class TeacherType:ObjectGraphType<Teachers>
    {
        public TeacherType()
        {
            Name = "teacherType";
            Description = "老师";
            Field(t => t.Id).Description("老师的编号");
            Field(t => t.Name).Description("老师的姓名");
            Field(t => t.Age).Description("老师的年龄");
            Field(t => t.Subject).Description("老师的教授的学科");
            Field<ListGraphType<StudentType>>("students", description: "老师的学生");
        }
    }
}
