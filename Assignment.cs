

    public class Assignment
    {

        public string Name { get; set; }

        private double _grade = 0;

        public bool Completed { get; private set; } = false;

        public double Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                Completed = true;
            }
        }

        public Assignment(string assignmentName)
        {
            Name = assignmentName;
        }


        /// //////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////
    }

