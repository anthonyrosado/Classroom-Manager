using System;
using System.Collections.Generic;



    public class Menu
    {

        ////////////////////////////////inputs///////////////////////////////////
        public string StringInput(string prompt)
        {
            string result;
            do
            {
                Console.WriteLine(prompt);
                result = Console.ReadLine();

            } while (result == "");
            return result;
        }
        public int IntInput(string prompt)
        {
            int result;


            Console.WriteLine(prompt);
            string resultString = Console.ReadLine();
            result = Convert.ToInt32(resultString);

            return result;
        }
        public void Back()
        {
            Console.WriteLine("press x to go back");
            string input = Console.ReadLine();
            if (input == "x")
            {
                MainMenu();
            }
            else { Console.WriteLine("invalid input"); }
        }
        ///////////////////////////////////////////////////////////////////
        static void WriteLogo()
        {
            string logo = @" 
'  ██╗ ██████╗ ██████╗  █████╗ ██████╗ ███████╗
'  ██║██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔════╝
'  ██║██║  ███╗██████╔╝███████║██║  ██║█████╗  
'  ██║██║   ██║██╔══██╗██╔══██║██║  ██║██╔══╝  
'  ██║╚██████╔╝██║  ██║██║  ██║██████╔╝███████╗ V.5
'  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝
'                                              
";
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", logo));
        }


        ////////////////////////////////////////////////////////////////////
        public List<Classroom> AllClassrooms = new List<Classroom>();

        ///////////////////////////////MainMenu/////////////////////////////
        public void MainMenu()
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;


            Console.Clear();
            WriteLogo();
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Select an option using  the numpad:"));
            string[] Options =
            {

                    "1.Show Classrooms",
                    "2.Add Classroom",
                    "3.Remove Classroom",
                    "4.Classroom Details",
                    "5.Exit App",
                };
            foreach (string Option in Options) { Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Option)); }
            int Input = Convert.ToInt32(Console.ReadLine());
            switch (Input)
            {
                case 1:
                    ShowClassrooms();

                    break;

                case 2:
                    AddClassroom(null);
                    break;

                case 3:
                    RemoveClassroom(null);
                    break;

                case 4:
                    ClassroomDetails();
                    break;

                case 5:
                    Console.WriteLine("Good Bye");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Not a valid input");
                    break;
            }
        }

        /////////////////////////////////////////////////////////////////////           

        /////////////////////////////ShowClassrom/////////////////////////////
        public void ShowClassrooms()
        {
            Console.Clear();
            foreach (Classroom newClassroom in AllClassrooms)
            {
                Console.WriteLine(newClassroom.Name);
            }

            MainMenu();
        }
        ////////////////////////////////////////////////////////////////////

        //////////////////////////////AddClassRoom/////////////////////////
        public void AddClassroom(string ClassroomID)
        {
            Console.Clear();
            ClassroomID = StringInput("Enter the Classroom name: ");

            Classroom newClassroom = new Classroom(ClassroomID);
            AllClassrooms.Add(newClassroom);

            MainMenu();
        }

        //////////////////////////////////////////////////////////////

        ////////////////////////RemoveClassroom///////////////////////
        public void RemoveClassroom(string ClassroomID)
        {
            Console.Clear();


            foreach (Classroom newClassroom in AllClassrooms)
            {
                Console.WriteLine(newClassroom.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Enter Classroom to remove");
            string userInput = Console.ReadLine();

            for (int index = 0; index < AllClassrooms.Count; index++)
            {
                if (userInput == AllClassrooms[index].Name)
                {
                    AllClassrooms.RemoveAt(index);
                }

            }
            MainMenu();
        }
        /////////////////////////////////////////////////////////////////////
        //////////////////////ClasrroomDetails//////////////////////////////
        public void ClassroomDetails()
        {
            Console.Clear();
            foreach (Classroom newClassroom in AllClassrooms)
            {
                Console.WriteLine(newClassroom.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Enter Classroom name");
            string userInput = Console.ReadLine();

            foreach (Classroom classroom in AllClassrooms)
            {
                if (userInput.Equals(classroom.Name))
                {
                    classroom.InClassroomMenu();

                }


            }
            MainMenu();


        }

        ///////////////////////////////////////////////////////////////////////////////

        /////////////////////////////EndofNamespace/////////////////////////

    }








