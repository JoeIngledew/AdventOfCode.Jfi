namespace AdventOfCode.Day19
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WhiteElephant
    {
        List<int> _participants = new List<int>();

        public WhiteElephant(int numParticipants)
        {
            foreach (var i in Enumerable.Range(1, numParticipants))
            {
                _participants.Add(i);
            }
        }

        public void Solve()
        {
            int counter = 0;
            int currentParticipant = 1;
            int presentsTaken = 0;
            while (_participants.Count > 1)
            {
                if (_participants.Any(p => p > currentParticipant))
                {
                    var toRemove = _participants.First(p => p > currentParticipant);
                    _participants.Remove(toRemove);
                    presentsTaken += 1;

                }
                else if (_participants.Any(p => p < currentParticipant))
                {
                    var toRemove = _participants.First();
                    _participants.Remove(toRemove);
                    presentsTaken += 1;
                }

                

                if (_participants.Any(p => p > currentParticipant))
                {
                    var next = _participants.First(p => p > currentParticipant);
                    currentParticipant = next;
                }
                else if (_participants.Any(p => p < currentParticipant))
                {
                    var next = _participants.First();
                    currentParticipant = next;
                }

                if (counter % 1000 == 0)
                {
                    Console.WriteLine($"Iteration {counter} CURRENT: {currentParticipant} LEFT: {_participants.Count}");
                }

                counter++;
            }


            Console.WriteLine($"Participants with presents: {_participants.Count}");
            Console.WriteLine($"Final participant: {_participants.Single()}");
        }
    }

    public class WeParticipant
    {
        public int Id { get; set; }

        public bool HasPresents { get; set; }
    }
}