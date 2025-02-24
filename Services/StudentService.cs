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

        public void UpdateStudent(Student updatedStudent)
        {
            var existingStudent = GetStudentById(updatedStudent.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Email = updatedStudent.Email;
                existingStudent.Age = updatedStudent.Age;
            }
        }

        public List<Student> SearchStudentsByName(string searchTerm)
        {
            return _students.Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Student> GetStudentsByAgeRange(int minAge, int maxAge)
        {
            return _students.Where(s => s.Age >= minAge && s.Age <= maxAge).ToList();
        }

        public double GetAverageAge()
        {
            if (!_students.Any()) return 0;
            return _students.Average(s => s.Age);
        }

        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }

        public void ClearAllStudents()
        {
            _students.Clear();
        }

        public bool IsEmailUnique(string email)
        {
            return !_students.Any(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
} 