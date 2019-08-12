using GraphQL.Net.Subscription.Model;
using System.Collections.Generic;

namespace GraphQL.Net.Subscription.IService
{
    public interface IStudentService
    {
        IList<Students> StudentList { get; }
        Students GetById(int id);
        IList<Students> GetAll();
        IList<Teachers> GetTeachersByStudentId(int studentId);
        IList<Messages> SendMessage(Messages message);
    }
}
