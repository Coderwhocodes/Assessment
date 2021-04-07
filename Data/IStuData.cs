using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try2.Model;

namespace try2.Data
{
    public interface IStuData
    {
        List<Student> GetStudents();

        Student GetStudent(int Id);

        Student AddStudent(Student student);

        void DeleteStudent(Student student);

        Student UpdateStudent(Student student);
    }
}
