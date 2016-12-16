namespace AdventOfCode.Day142015
{
    using System;
    using System.Collections.Generic;

    // unfinished
    public class ReindeerOlympics
    {
        public void CalculateDistancesAtTime(int secondsElapsed)
        {
            var rds = new List<Reindeer>();
            rds.Add(new Reindeer("Comet", 14, 10, 127));
            rds.Add(new Reindeer("Dancer", 16, 11, 162));

            foreach (Reindeer rd in rds)
            {
                CalculateDistanceAtTime(rd, secondsElapsed);
            }

            foreach (Reindeer reindeer in rds)
            {
                Console.WriteLine($"{reindeer.Name} travelled {reindeer.CurrentDistance}km");
            }
        }

        private void CalculateDistanceAtTime(Reindeer rd, int secondsElapsed)
        {
            int currentSeconds = 0;
            bool isResting = false;
            int flightCounter = 0;
            int restCounter = 0;

            while (currentSeconds < secondsElapsed)
            {
                if (isResting)
                {
                    restCounter++;
                    currentSeconds++;
                    if (restCounter == rd.RestTimeSeconds)
                    {
                        isResting = false;
                        Console.WriteLine($"{rd.Name} stops resting at {currentSeconds}");
                        restCounter = 0;
                    }
                }
                else
                {
                    rd.CurrentDistance += rd.SpeedInKms;
                    flightCounter++;
                    currentSeconds++;
                    if (flightCounter == rd.ContinuousFlightSeconds)
                    {
                        isResting = true;
                        Console.WriteLine($"{rd.Name} starts resting at {currentSeconds} having traveled {rd.CurrentDistance}km");
                        flightCounter = 0;
                    }
                }
            }
        }
    }

    public class Reindeer
    {
        public Reindeer(string name, int speedInKms, int continuousFlightSeconds, int restTimeSeconds)
        {
            Name = name;
            SpeedInKms = speedInKms;
            ContinuousFlightSeconds = continuousFlightSeconds;
            RestTimeSeconds = restTimeSeconds;
        }

        public string Name { get; }

        public int SpeedInKms { get; }

        public int ContinuousFlightSeconds { get; }

        public int RestTimeSeconds { get; }

        public int CurrentDistance { get; set; }
    }
}