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
    public class TeacherQuery:GraphQL.Types.ObjectGraphType
    {
        private ITeacherService teacherService;
        public TeacherQuery(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
            Name = "teacherQuery";
            Description = "学生的查询";
            Field<TeacherType>("getTeacherById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id", Description = "老师的编号" }),
                resolve: context =>
                {
                    int teacherId = context.GetArgument<int>("id");
                    Teachers student = teacherService.GetById(teacherId);
                    return student;
                });
            Field<ListGraphType<TeacherType>>("getAllTeachers",
                resolve: context =>
                {
                    IList<Teachers> teachers = teacherService.GetAll();
                    return teachers;
                });
            Field<ListGraphType<TeacherType>>("getStudentsByTeacherId",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id", Description = "老师的编号" }),
                resolve: context =>
                {
                    int teacherId = context.GetArgument<int>("id");
                    IList<Students> students = teacherService.GetStudentsByTeacherId(teacherId);
                    return students;
                });
            Field<StringGraphType>("sendMessageToStudents",
                arguments: new QueryArguments(new QueryArgument<InputMessageType> { Name = "message", Description = "消息" }),
                resolve:context=> {
                    Messages message = context.GetArgument<Messages>("message");
                    return "发送成功";
                });
        }
    }
}
