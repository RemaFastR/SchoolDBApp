using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SchoolDBApp.DataBase
{
    public class StudentRepository : ISchoolRepsitory
    {
        string connectionString = null;

        public StudentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int CalculateArithmeticMeanInThreeSubjects()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var calculateQuery = "SELECT (SUM(MathScore) + SUM(InformScore) + SUM(ForeignLangScore)) / 3 FROM Students";
                return connection.Query<int>(calculateQuery).First();
            }
        }

        public void Create(Student student)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var createStudentQuery = "INSERT INTO Students (SecondName, DateOfBirth, MathScore, InformScore, ForeignLangScore) VALUES(@SecondName, @DateOfBirth, @MathScore, @InformScore, @ForeignLangScore)";
                connection.Execute(createStudentQuery, student);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var deleteStudentQuery = "DELETE FROM Students WHERE Id = @id";
                connection.Execute(deleteStudentQuery, new { id });
            }
        }

        public Student Get(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Student>("SELECT * FROM Students WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<Student> GetStudents()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Student>("SELECT * FROM Students").ToList();
            }
        }

        public List<Student> MakeASample(int age)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Student>($"SELECT * FROM Students WHERE datediff(year, DateOfBirth, GETDATE()) > {age}").ToList();
            }
        }

        public List<Student> OrderBySecondName()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Student>("SELECT * FROM Students ORDER BY SecondName").ToList();
            }
        }

        public List<Student> SearchStudent(string secondName)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Student>($"SELECT * FROM Students WHERE SecondName = '{secondName}'").ToList();
            }
        }

        public void Update(int id, Student student)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var updateStudentQuery = $"UPDATE Students SET SecondName = @SecondName, DateOfBirth = @DateOfBirth, MathScore = @MathScore, InformScore = @InformScore, ForeignLangScore = @ForeignLangScore WHERE Id = {id}";
                connection.Execute(updateStudentQuery, student);
            }
        }
    }
}
