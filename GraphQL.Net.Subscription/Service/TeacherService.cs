using GraphQL.Net.Subscription.IService;
using GraphQL.Net.Subscription.Model;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Net.Subscription.Service
{
    public class TeacherService : ITeacherService
    {
        public IList<Teachers> TeacherList { get; }
        private IStudentService studentService;

        public TeacherService(IStudentService studentService)
        {
            this.studentService = studentService;
            TeacherList = new List<Teachers>();
            TeacherList.Add(new Teachers { Id = 1, Age = 38, Name = "张三", Subject = "数学", StudentId = 1 });
            TeacherList.Add(new Teachers { Id = 2, Age = 39, Name = "王五", Subject = "化学", StudentId = 2 });
            TeacherList.Add(new Teachers { Id = 3, Age = 40, Name = "李四", Subject = "生物", StudentId = 3 });
        }



        public IList<Teachers> GetAll()
        {
            foreach (Teachers teacher in TeacherList)
            {
                teacher.Students = studentService.StudentList.Where(s => s.TeacherId == teacher.Id).ToList();
            }
            return TeacherList;
        }

        public Teachers GetById(int id)
        {
            Teachers teacher = TeacherList.Where(t => t.Id == id).SingleOrDefault();
            return teacher;
        }

        public IList<Students> GetStudentsByTeacherId(int teacherId)
        {
           IList<Students> students=studentService.StudentList.Where(s => s.TeacherId == teacherId).ToList();
            return students;
        }

        public IList<Messages> SendMessage(Messages message)
        {
            throw new System.NotImplementedException();
        }
    }
}
