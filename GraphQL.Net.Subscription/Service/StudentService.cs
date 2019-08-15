using GraphQL.Net.Subscription.IService;
using GraphQL.Net.Subscription.Model;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Net.Subscription.Service
{
    public class StudentService : IStudentService
    {
        public IList<Students> StudentList { get; }
        private ITeacherService teacherService;
        public StudentService(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
            StudentList = new List<Students>();
            StudentList.Add(new Students { Id = 1, Name = "student1", Age = 18, Professional = "计算机", TeacherId = 1 });
            StudentList.Add(new Students { Id = 2, Name = "student2", Age = 19, Professional = "地球物理", TeacherId = 1 });
            StudentList.Add(new Students { Id = 3, Name = "student3", Age = 20, Professional = "化学", TeacherId = 1 });
            StudentList.Add(new Students { Id = 4, Name = "student4", Age = 21, Professional = "生物", TeacherId = 2 });
            StudentList.Add(new Students { Id = 5, Name = "student5", Age = 22, Professional = "政治", TeacherId = 2 });
            StudentList.Add(new Students { Id = 6, Name = "student6", Age = 23, Professional = "法律", TeacherId = 3 });
        }



        public IList<Students> GetAll()
        {
            foreach (Students student in StudentList)
            {
                student.Teachers = teacherService.TeacherList.Where(s => s.StudentId == student.Id).ToList();
            }
            return StudentList;
        }

        public Students GetById(int id)
        {
            return StudentList.Where(s => s.Id == id).SingleOrDefault();
        }

        public IList<Teachers> GetTeachersByStudentId(int studentId)
        {
            return teacherService.TeacherList.Where(t => t.StudentId == studentId).ToList();
        }

        public IList<Messages> SendMessage(Messages message)
        {
            throw new System.NotImplementedException();
        }
    }
}
