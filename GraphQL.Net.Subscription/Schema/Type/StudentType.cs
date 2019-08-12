using GraphQL.Net.Subscription.Model;
using GraphQL.Types;

namespace GraphQL.Net.Subscription.Schema.Type
{
    public class StudentType:ObjectGraphType<Students>
    {
        public StudentType()
        {
            Name = "studentType";
            Description = "学生";
            Field(s => s.Id).Description("学生编号");
            Field(s => s.Name).Description("学生姓名");
            Field(s => s.Professional).Description("学生专业");
            Field(s => s.Age).Description("学生的年龄");
            Field<ListGraphType<TeacherType>>("Teachers", description: "这个学生的老师");
        }
    }
}
