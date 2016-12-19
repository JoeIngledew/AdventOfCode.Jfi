namespace AdventOfCode.Day142015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreLinq;

    // unfinished - or rather -advent of code is broken for this puzzle for me.
    public class ReindeerOlympics
    {
        public void CalculateDistancesAtTime(int secondsElapsed, string input)
        {
            var inputLines = input.Replace("\r", "").Split('\n');

            var rds = new List<Reindeer>();

            foreach (var inputLine in inputLines)
            {
                var splitLine = inputLine.Split(' ');
                var name = splitLine[0];
                var speed = int.Parse(splitLine[3]);
                var flightTime = int.Parse(splitLine[6]);
                var restTime = int.Parse(splitLine[13]);
                rds.Add(new Reindeer(name, speed, flightTime, restTime));
            }

            //foreach (Reindeer rd in rds)
            //{
            //    CalculateDistanceAtTime(rd, secondsElapsed);
            //}



            //foreach (Reindeer reindeer in rds)
            //{
            //    Console.WriteLine($"{reindeer.Name} travelled {reindeer.CurrentDistance}km");
            //}

            //var bestDistance = rds.Max(r => r.CurrentDistance);
            //var bestRd = rds.Single(r => r.CurrentDistance == bestDistance).Name;

            //Console.WriteLine($"BEST: {bestRd} at {bestDistance} km");

            SimulateRace(rds, secondsElapsed);
        }

        private void SimulateRace(List<Reindeer> rds, int toSeconds)
        {
            int currentSeconds = 0;
            

            while (currentSeconds < toSeconds)
            {
                foreach (Reindeer reindeer in rds)
                {
                    if (reindeer.IsResting)
                    {
                        reindeer.RestCounter++;
                        
                        if (reindeer.RestCounter == reindeer.RestTimeSeconds)
                        {
                            reindeer.IsResting = false;
                            Console.WriteLine($"{reindeer.Name} stops resting at {currentSeconds}");
                            reindeer.RestCounter = 0;
                        }
                    }
                    else
                    {
                        reindeer.CurrentDistance += reindeer.SpeedInKms;
                        reindeer.FilghtCounter++;
                        
                        if (reindeer.FilghtCounter == reindeer.ContinuousFlightSeconds)
                        {
                            reindeer.IsResting = true;
                            Console.WriteLine($"{reindeer.Name} starts resting at {currentSeconds} having traveled {reindeer.CurrentDistance}km");
                            reindeer.FilghtCounter = 0;
                        }
                    }
                }

                currentSeconds++;

                var reindeerInLead = rds.Where(x => x.CurrentDistance == rds.Max(r => r.CurrentDistance));
                reindeerInLead.ForEach(r => r.Points++);
            }

            var rdWithMostPoints = rds.First(r => r.Points == rds.Max(x => x.Points));

            Console.WriteLine($"WINNER: {rdWithMostPoints.Name} WITH {rdWithMostPoints.Points} points");
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
            Points = 0;
            IsResting = false;
            RestCounter = 0;
            FilghtCounter = 0;
        }

        public string Name { get; }

        public int SpeedInKms { get; }

        public int ContinuousFlightSeconds { get; }

        public int RestTimeSeconds { get; }

        public int CurrentDistance { get; set; }

        public int Points { get; set; }

        public bool IsResting { get; set; }

        public int RestCounter { get; set; }

        public int FilghtCounter { get; set; }
    }
}