using GraphQL.Net.Subscription.IService;
using GraphQL.Net.Subscription.Model;
using GraphQL.Net.Subscription.Schema.Type;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Net.Subscription.Schema.Query
{
    public class StudentQuery:GraphQL.Types.ObjectGraphType
    {
        private IStudentService studentService;
        public StudentQuery(IStudentService studentService)
        {
            this.studentService = studentService;
            Name = "studentQuery";
            Description = "学生的查询类型";
            Field<StudentType>("getStudentById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id", Description = "学生的编号" }),
                resolve: context =>
                {
                    int studentId = context.GetArgument<int>("id");
                    Students student = studentService.GetById(studentId);
                    return student;
                });
            Field<ListGraphType<StudentType>>("getAllStudents",
                resolve: context =>
                {
                    IList<Students> students = studentService.GetAll();
                    return students;
                });
            Field<ListGraphType<TeacherType>>("getTeacherByStudentId",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id", Description = "学生的编号" }),
                resolve: context =>
                {
                    int studentId = context.GetArgument<int>("id");
                    IList<Teachers> teachers = studentService.GetTeachersByStudentId(studentId);
                    return teachers;
                });
        }
    }
}
