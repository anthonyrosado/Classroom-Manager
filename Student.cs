using System;
using System.Collections.Generic;
using System.Linq;



    public class Student
    {
        public string Name { get; set; }

        public List<Assignment> Assignments = new List<Assignment>();

        public double BestGrade { get; set; } = 0;
        public double WorstGrade { get; set; } = 100;

        public double AverageGrade { get; set; }

        public bool AssignmentsComplete = false;

        public List<double> gradesList = new List<double>();

        public Student(string studentName)
        {
            Name = studentName;
        }

        /////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////////////////// 




        /// /////////////////////////////////////////////////////////////////////////////////////
        /// /////////////////////////////////////////////////////////////////////////////////

        public void BackToCr()
        {
            Console.WriteLine("press x to go back");
            string input = Console.ReadLine();
            if (input == "x")
            {
                Classroom classroom;
            }
            else { Console.WriteLine("invalid input"); }
        }


        ////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////


        public void InsideStudent()
        {
            Console.Clear();
            Console.WriteLine($"Student Details\nName: {Name}");
            string[] selections = {
                                "1.Show Student Summary",
                                "2.Assign Work to Student",
                                "3.Unassign Work to Student",
                                "4.Show Assignments",
                                "5.Grade Assignments",
                                "6.Show Best Grade",
                                "7.Show Worst Grade",
                                "8.Back"};
            foreach (string selection in selections)
            { Console.WriteLine(selection); }


            int Select = Convert.ToInt32(Console.ReadLine());
            switch (Select)
            {
                case 1:
                    StudentSummary();

                    break;

                case 2:
                    AssignWork();
                    break;

                case 3:
                    UnassignWork();
                    break;

                case 4:
                    ShowAssignment();
                    break;

                case 5:
                    GradeAssignment();
                    break;

                case 6:
                    ShowBestGrade();
                    break;

                case 7:
                    ShowWorstGrade();
                    break;

                case 8:
                    BackToCr();
                    break;



                default:
                    Console.WriteLine("Not a valid input");
                    break;
            }
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////

        public void StudentSummary()
        {
            Console.Clear();
            bool allAssignmentsComplete = AllAssignmentsComplete();
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Average grade is: {AverageGrade}");
            Console.WriteLine($"All assignments complete: {allAssignmentsComplete}");
            Console.WriteLine($"Assignments assigned: {Assignments.Count}");

            Console.WriteLine("Press ENTER to return to the Student menu");
            Console.ReadLine();



            InsideStudent();
        }
        ///////////////////////////////////////////////////////////////////////////////////////
        ///
        void AssignWork()
        {
            Console.Clear();
            Console.WriteLine("Enter new Assignment");

            string AssignmentName = Console.ReadLine();


            Assignment assignment = new Assignment(AssignmentName);
            Assignments.Add(assignment);


            InsideStudent();
        }

        /// 
        /// /////////////////////////////////////////////////////////////////////////////////
        /// 
        void UnassignWork()
        {
            Console.Clear();
            foreach (Assignment assignment in Assignments)
            {
                Console.WriteLine(assignment.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Enter Classroom name");
            string userInput = Console.ReadLine();

            for (int index = 0; index < Assignments.Count; index++)
            {
                if (userInput == Assignments[index].Name)
                {
                    Assignments.RemoveAt(index);
                }

            }
            InsideStudent();

        }

        /// ////////////////////////////////////////////////////////////////////////////////////

        public void ShowAssignment()
        {
            Console.Clear();
            foreach (Assignment assignment in Assignments)
            {
                Console.WriteLine(assignment.Name);
            }
            InsideStudent();
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///
        public void GradeAssignment()
        {
            Console.Clear();
            foreach (Assignment assignment in Assignments)
            {
                Console.WriteLine(assignment.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Enter Assignment name");
            string userInput = Console.ReadLine();

            foreach (Assignment assignment in Assignments)
            {
                if (userInput.Equals(assignment.Name))
                {




                    Console.Clear();
                    Console.WriteLine($"Grading Assignment: {assignment.Name}");
                    Console.WriteLine("Enter Grade score:");

                    double assignmentGrade = double.Parse(Console.ReadLine());

                    assignment.Grade = assignmentGrade;

                    if (assignmentGrade > BestGrade)
                    {
                        BestGrade = assignmentGrade;
                    }
                    else if (assignmentGrade < WorstGrade)
                    {
                        WorstGrade = assignmentGrade;
                    }

                    gradesList.Add(assignmentGrade);
                    this.AverageGrade = gradesList.Average();






                }

            }
            InsideStudent();
        }


        /// //////////////////////////////////////////////////////////////////////////

        public void ShowBestGrade()
        {
            Console.Clear();
            Console.WriteLine($"The best grade is: {BestGrade}");

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();

            InsideStudent();

        }

        /// //////////////////////////////////////////////////////////////////////////////////////////

        public void ShowWorstGrade()
        {


            Console.Clear();
            Console.WriteLine($"The worst grade is: {WorstGrade}");

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();

            InsideStudent();

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////


        bool AllAssignmentsComplete()
        {
            bool allComplete = true;

            foreach (Assignment assignment in Assignments)
            {
                if (assignment.Completed == false)
                {
                    allComplete = false;
                    break;
                }
            }
            AssignmentsComplete = allComplete;

            return AssignmentsComplete;

        }
    }

