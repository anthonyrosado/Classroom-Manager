using System;
using System.Collections.Generic;
using System.Linq;


    public class Classroom
    {
        public string Name { get; set; }

        public List<Student> AllStudents = new List<Student>();

        public List<double> allClassGrades = new List<double>();

        public Classroom(string classroomName)
        {
            Name = classroomName;
        }



        /// /////////////////////////////////////////////////////////////////////////////


        public void BackToMain()
        {
            Console.WriteLine("press x to go back");
            string input = Console.ReadLine();
            if (input == "x")
            {
                Menu menu;
            }
            else { Console.WriteLine("Invalid input"); }
        }

        /// /////////////////////////////////////////////////////////////////////////

        public void InClassroomMenu()
        {


            {
                Console.WriteLine($"Now Editing {Name}");
                string[] options = {"1.Show Students",
                                "2.Add Student",
                                "3.Remove Students",
                                "4.Class Average",
                                "5.Student Details",
                                "6.Show Top Student",
                                "7.Show Worst Student",
                                "8.Compare 2 Students",
                                "9.Back" };

                foreach (string option in options) { Console.WriteLine(option); }
                int Input = Convert.ToInt32(Console.ReadLine());
                switch (Input)
                {
                    case 1:
                        ShowStudents();

                        break;

                    case 2:
                        AddStudent(null);
                        break;

                    case 3:
                        RemoveStudent(null);
                        break;

                    case 4:
                        ClassAverage();
                        break;

                    case 5:
                        StudentDetails();
                        break;

                    case 6:
                        TopStudent();
                        break;

                    case 7:
                        BottomStudent();
                        break;

                    case 8:
                        Compare();
                        break;

                    case 9:
                        BackToMain();

                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }

        }

        /// ////////////////////////////////////////////////////////////////////////////////

        public void ShowStudents()
        {
            Console.Clear();
            foreach (Student student in AllStudents)
            {
                Console.WriteLine(student.Name);
            }
            InClassroomMenu();
        }

        ////////////////////////////////////////////////////////////////////////////////////
        public void AddStudent(string StudentID)
        {
            Console.Clear();
            Console.WriteLine("Enter Student name");

            StudentID = Console.ReadLine();

            Student student = new Student(StudentID);
            AllStudents.Add(student);

            InClassroomMenu();



        }
        //////////////////////////////////////////////////////////////////////////////////////
        public void RemoveStudent(string StudentID)
        {
            Console.Clear();


            foreach (Student student in AllStudents)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Enter Classroom to remove");
            string userInput = Console.ReadLine();

            for (int index = 0; index < AllStudents.Count; index++)
            {
                if (userInput == AllStudents[index].Name)
                {
                    AllStudents.RemoveAt(index);
                }

            }
            InClassroomMenu();
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////

        public void ClassAverage()
        {
            Console.Clear();
            gatherGrades();
            Console.WriteLine($"The class average is: {allClassGrades.Average()}");

            BackToMain();

        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////

        public void StudentDetails()
        {
            Console.Clear();
            foreach (Student student in AllStudents)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("Select Student");

            string userInput = Console.ReadLine();

            foreach (Student student in AllStudents)
            {
                if (userInput.Equals(student.Name))
                {
                    student.InsideStudent();

                }

            }
            InClassroomMenu();
        }

        /// ///////////////////////////////////////////////////////////////////

        public void TopStudent()
        {

            Student topStudent = new Student("not_a_student");
            topStudent.AverageGrade = 0;

            Console.Clear();
            foreach (Student student in AllStudents)
            {
                if (student.AverageGrade > topStudent.AverageGrade)
                {
                    topStudent = student;
                }
            }

            Console.WriteLine($"The top student is: {topStudent.Name}");

            InClassroomMenu();
        }

        /// /////////////////////////////////////////////////////////////////////////

        public void BottomStudent()
        {
            Console.Clear();
            Student worstStudent = new Student("not_a_student");
            worstStudent.AverageGrade = 100;

            Console.Clear();
            foreach (Student student in AllStudents)
            {
                if (student.AverageGrade < worstStudent.AverageGrade)
                {
                    worstStudent = student;
                }
                Console.WriteLine($"The worst student is: {worstStudent.Name}");

            }

            InClassroomMenu();

        }

        public void Compare()
        {
            string firstStudentName;
            string secondStudentName;

            Student firstStudent = new Student("student1");
            Student secondStudent = new Student("student2");

            Console.Clear();
            DisplayStudents();
            Console.WriteLine("Choose first student");
            firstStudentName = Console.ReadLine();
            Console.WriteLine("Choose second student");
            secondStudentName = Console.ReadLine();

            for (int index = 0; index < AllStudents.Count; index++)
            {
                if (firstStudentName == AllStudents[index].Name)
                {
                    firstStudent = AllStudents[index];
                }

                if (secondStudentName == AllStudents[index].Name)
                {
                    secondStudent = AllStudents[index];
                }
                if (firstStudent.AverageGrade > secondStudent.AverageGrade)
                {
                    Console.WriteLine($"The better student is {firstStudent.Name}");
                }
                else
                {
                    Console.WriteLine($"The better student is {secondStudent.Name}");
                }

            }
            InClassroomMenu();

        }


        void gatherGrades()
        {
            foreach (Student student in AllStudents)
            {
                foreach (Assignment assignment in student.Assignments)
                {
                    if (assignment.Completed == true)
                    {
                        allClassGrades.Add(assignment.Grade);
                    }

                }
            }
        }

        void DisplayStudents()
        {
            foreach (Student student in AllStudents)
            {
                Console.WriteLine(student.Name);
            }


        }
    }


