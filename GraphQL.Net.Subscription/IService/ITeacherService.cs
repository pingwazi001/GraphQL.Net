using GraphQL.Net.Subscription.Model;
using System.Collections.Generic;

namespace GraphQL.Net.Subscription.IService
{
    public interface ITeacherService
    {
        IList<Teachers> TeacherList { get; } 
        Teachers GetById(int id);
        IList<Teachers> GetAll();
        IList<Students> GetStudentsByTeacherId(int teacherId);
        IList<Messages> SendMessage(Messages message);
    }
}
