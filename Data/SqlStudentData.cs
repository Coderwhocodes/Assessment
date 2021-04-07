using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try2.Model;

namespace try2.Data
{
    public class SqlStudentData : IStuData
    {
        private StudentContext _studentcontext;

        public SqlStudentData(StudentContext studentContext)
        {
            _studentcontext = studentContext;
        }


        public Student AddStudent(Student student)
        {
            _studentcontext.Students.Add(student);
            _studentcontext.SaveChanges();
            return student;
        }

        public void DeleteStudent(Student student)
        {
            _studentcontext.Students.Remove(student);
            _studentcontext.SaveChanges();
        }

        public Student GetStudent(int id)
        {
            var student = _studentcontext.Students.Find(id);
            return student;
        }

        public List<Student> GetStudents()
        {
           return _studentcontext.Students.ToList();
        }

        public Student UpdateStudent(Student student)
        {
            var existingStudent = _studentcontext.Students.Find(student.Id);
            if(existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Class = student.Class;
                _studentcontext.Students.Update(existingStudent);
                _studentcontext.SaveChanges();
            }
            return student;
        }
    }
}
