namespace AdventOfCode
{
    public class ElevatorFloorCalc
    {
        private int _currentFloor;

        public ElevatorFloorCalc()
        {
            _currentFloor = 0;
            FirstBasement = 0;
        }

        public int FirstBasement { get; set; }

        public int GetFloorFromInstructions(string instructions)
        {
            var instructionArray = instructions.ToCharArray();

            int currentPosition = 1;

            foreach (var instruction in instructionArray)
            {
                switch (instruction)
                {
                    case '(':
                        _currentFloor++;
                        break;
                    case ')':
                        _currentFloor--;
                        break;
                    default:
                        break;
                }

                if (_currentFloor == -1 && FirstBasement == 0)
                {
                    FirstBasement = currentPosition;
                }

                currentPosition++;
            }

            return _currentFloor;
        }
    }
}