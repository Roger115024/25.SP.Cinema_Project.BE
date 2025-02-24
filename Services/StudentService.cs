using TestGithubActions.Models;

namespace TestGithubActions.Services
{
    public class StudentService
    {
        private List<Student> _students;

        public StudentService()
        {
            _students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student? GetStudentById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }
    }
} 