using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDBApp.DataBase
{
    public interface ISchoolRepsitory
    {
        void Create(Student student);
        void Delete(int id);
        Student Get(int id);
        List<Student> GetStudents();
        void Update(int id, Student student);
        int CalculateArithmeticMeanInThreeSubjects();
        List<Student> SearchStudent(string secondName);
        List<Student> OrderBySecondName();
        List<Student> MakeASample(int age);
    }
}
