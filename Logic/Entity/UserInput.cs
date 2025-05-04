using InterfaceProject;
using ModelProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entity
{
    public class UserInput
    {

        public static char Tasking()
        {
            StuduntLogic _student = new StuduntLogic();
            while (true)
            {
                Console.WriteLine("\n\nChoose a Task: \n");

                Console.WriteLine("A - Add Student\n" +
                    "R - Read all Student Records\n" +
                    "U - Update Sudent List\n" +
                    "D - Delete Student List\n" +
                    "G - Calculator Grades\n" +
                    "E - Exit");
                Console.Write("Answer: ");
                string userInput = Console.ReadLine();

                if (char.TryParse(userInput, out char task))
                {
                    if (task == 'E')
                        return 'E';
                    switch (task)
                    {
                        case 'A':
                            _student.AddStudent();
                            break;
                        case 'R':
                            _student.ReadAllStudent();
                            break;
                        case 'U':
                            _student.UpdateStudent();
                            break;
                        case 'D':
                            _student.DeleteStudent();
                            break;
                        case 'G':
                            EnterGrades();
                            break;
                        default:
                            Console.WriteLine("Invalid Input!");
                            break;
                    }

                }
                else Console.WriteLine("Invalid Input");

            }
        }
        public static string EnterName()
        {
            while (true)
            {
                Console.Write("Enter Full Name: ");
                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine($"{nameof(userInput)} Cannot be Empty!");
                    continue;
                }
                return userInput;

            }

        }
        public static int EnterAge()
        {
            while (true)
            {
                Console.Write("Enter Age: ");
                string userAge = Console.ReadLine();

                //i
                if (!int.TryParse(userAge, out int age))
                {
                    Console.WriteLine($"{nameof(userAge)} is Invalid!");
                    continue;
                }

                if (age <= 5)
                {
                    Console.WriteLine("Age Cannot be less than 5");
                    continue;
                }
                else if (age > 100)
                {
                    Console.WriteLine("Age Cannot be Greater than 100");
                    continue;
                }

                return age;
            }
        }
        public static string EnterEmail()
        {
            while (true)
            {
                Console.Write("Enter Email: ");
                string userEmail = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userEmail))
                {
                    Console.WriteLine("Email Cannot be Empty");
                    continue;
                }

                if (!userEmail.Contains("@") && !userEmail.Contains("com"))
                {
                    Console.WriteLine("Invalid Email Adress");
                    continue;
                }
                return userEmail;
            }
        }

        public static Grades EnterGrades()
        {
            while (true)
            {
                Console.WriteLine("Insert Your Grades\n");

                Console.Write("English: ");
                string english = Console.ReadLine();

                Console.Write("P.E: ");
                string pe = Console.ReadLine();

                Console.Write("C#: ");
                string CSharp = Console.ReadLine();

                Console.Write("Algorithm: ");
                string Algorithm = Console.ReadLine();


                //if user insert a non decimal or letters 
                if (!decimal.TryParse(english, out decimal English) ||
                   !decimal.TryParse(pe, out decimal PE) ||
                    !decimal.TryParse(CSharp, out decimal Sharp) ||
                    !decimal.TryParse(Algorithm, out decimal Algorithmic))
                {
                    Console.WriteLine("Invalid Input."); 
                    continue;
                }
                else if(English <= 73 || PE <= 73 || Sharp <= 73 || Algorithmic <= 73 || English > 100 || PE > 100 || Sharp > 100 || Algorithmic > 100)
                {
                    Console.WriteLine("Grades Cannot be less than 73 Or Grades Cannot be Greater than 100");
                    continue;
                }

                var finalGrades = FinalGrades(English, PE, Sharp, Algorithmic);
                Console.WriteLine($"Your Final Grades is {finalGrades}");

                return new Grades
                {
                    English = English,
                    P_E = PE,
                    CSharp = Sharp,
                    Algorithm = Algorithmic
                };

                



            }
        }

        public static decimal FinalGrades(decimal a, decimal b, decimal c, decimal d)
        {

            decimal finalGrade = (a + b + c + d) / 4;

            return finalGrade;
        }

        public static int UpdateStudentMethod()
        {
            Console.Write( "Enter Student Key ID you want to Update: ");
            string input = Console.ReadLine();
            while (true)
            {
                if(!int.TryParse(input, out int userInput))
                {
                    Console.WriteLine("Invalid Input try Again!");
                    continue;
                }
                return userInput;
            }
        } 
        public static int DeleteStudentMethod()
        {
            Console.Write( "Enter Student Key ID you want to Delete: ");
            string input = Console.ReadLine();
            while (true)
            {
                if(!int.TryParse(input, out int userInput))
                {
                    Console.WriteLine("Invalid Input try Again!");
                    continue;
                }
                return userInput;
            }
        }
    }
}
