using InterfaceProject;
using Logic.Entity;
using ModelProject;

namespace Logic
{
    public class StuduntLogic : IStudent
    {
        //new instance of Student Model
        public List<Student> _students = new List<Student>();
        public void AddStudent()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string name = UserInput.EnterName();
            int age = UserInput.EnterAge();
            string email = UserInput.EnterEmail();
            Grades grades = UserInput.EnterGrades();

            var newStudent = new Student
            {
                ID = _students.Count + 1,//it's automatically increase the ID by 1
                FullName = name,
                Age = age,
                Email = email,
                Grades = grades
            };

            _students.Add(newStudent);
            Console.WriteLine("Successfully Added");
            
        }
        public void ReadAllStudent()
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var student in _students)
            {
                Console.WriteLine($"\n\nID: {student.ID}\n" +
                    $"Full Name: {student.FullName}\n" +
                    $"Age: {student.Age}\n" +
                    $"Email: {student.Email}\n" +
                    $"\n\n------------------------Grades------------------------------\n" +
                    $"English: {student.Grades.English}, PE: {student.Grades.P_E}, C#: {student.Grades.CSharp}, DataStructures&Alogorithm: {student.Grades.Algorithm}\n" +
                    $"________________________________________________________________");

            }
        }
        public void DeleteStudent()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            ReadAllStudent();
            if( _students.Count <= 0 )
                Console.WriteLine("\nList of students Are Empty!\n");
            int choice = UserInput.DeleteStudentMethod();

            var studentId = _students.Find(x => x.ID == choice);
            if(studentId != null)
            {
                _students.Remove(studentId);
                Console.WriteLine("Deleted Successfully!");
            }
            else Console.WriteLine("Student ID not Found");

        }
        public void UpdateStudent()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            ReadAllStudent();
            int choice = UserInput.UpdateStudentMethod(); //insert 10
            var studentId = _students.Find(x => x.ID == choice); //return null

            if(studentId != null)
            {
                studentId.FullName = UserInput.EnterName();
                studentId.Age = UserInput.EnterAge();
                studentId.Email = UserInput.EnterEmail();
                studentId.Grades = UserInput.EnterGrades();
                Console.WriteLine("\nSuccessfully Updated!");
            }
            else Console.WriteLine("Student ID not Found");

        }
    }
}
