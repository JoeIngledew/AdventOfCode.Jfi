namespace AdventOfCode.Day15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreLinq;

    public class TimingIsEverything
    {
        public List<Disk> Disks;

        public TimingIsEverything()
        {
            Disks = new List<Disk>();
        }

        public void Setup(string input)
        {
            var instructions = input.Replace("\r", "").Split('\n');

            foreach (var instruction in instructions)
            {
                var diskNum = int.Parse(instruction.Substring(6, 1));

                var words = instruction.Replace(".", "").Split(' ');

                var numPositions = int.Parse(words[3]);
                var posAtEpoch = int.Parse(words.Last());

                Disks.Add(new Disk(diskNum, numPositions, posAtEpoch));
            }
        }

        public void SecondSetup(int numPositionsOfNewDisk, int epochOfNewDisk)
        {
            Disks.Add(new Disk(Disks.Max(d => d.Id) + 1, numPositionsOfNewDisk, epochOfNewDisk));
            Disks.ForEach(d => d.CurrentPosition = d.PositionAtEpoch);
            Disks.ForEach(d => d.HasBeenPassed = false);
        }

        public int GetFirstTimeWhereCapsuleCanBeGot()
        {
            int time = 0;
            bool success = false;

            while (!success)//(!Disks.All(d => d.HasBeenPassed))
            {
                ArrangeDisks(time);
                success = Simulate(time);

                Console.WriteLine($"Time: {time}s");
                foreach (Disk disk in Disks)
                {
                    Console.WriteLine($"Disk {disk.Id} position: {disk.CurrentPosition} (max {disk.NumberOfPositions})");
                }

                if (!success)
                {
                    time++;
                }
                //if (time % 1000 == 0)
                //{
                //}
            }

            return time;
        }

        public int TestThis()
        {
            bool success = false;
            int time = 0;

            while (!success)
            {
                List<Disk> disksAtTimeT = new List<Disk>();
                bool successSoFar = true;

                foreach (int i in Enumerable.Range(0, Disks.Count))
                {
                    var d = Disks[i];
                    var newDisk = new Disk(d.Id, d.NumberOfPositions, d.PositionAtEpoch, d.GetPositionAtTime(i + time + 1));
                    disksAtTimeT.Add(newDisk);
                    if (newDisk.CurrentPosition != newDisk.NumberOfPositions - 1)
                    {
                        successSoFar = false;
                    }
                    success = successSoFar;
                    if (!successSoFar) break;
                }

                if (time % 100 == 0)
                {
                    Console.WriteLine($"TIME {time}s");
                }

                if (!successSoFar) time++;
            }

            return time;
        }

        public int PleaseWork()
        {
            bool success = false;
            int time = 0;
            int subTime = 0;

            while (!success)
            {
                foreach (Disk disk in Disks)
                {
                    disk.AdvanceTSteps(disk.Id);
                    Console.WriteLine($"TIME {time + disk.Id} DISK {disk.Id} POS {disk.CurrentPosition} (MAX {disk.NumberOfPositions - 1})");
                    if (disk.CurrentPosition != 0)
                    {
                    }
                    else
                    {
                        disk.HasBeenPassed = true;
                    }
                }

                if (Disks.All(d => d.HasBeenPassed))
                {
                    success = true;
                }
                else
                {
                    Disks.ForEach(d => d.HasBeenPassed = false);
                    Disks.ForEach(d => d.ReverseMovements(d.Id));
                    Disks.ForEach(d => d.AdvanceTSteps(1));
                    time++;
                }
            }

            return time;
        }

        private void ArrangeDisks(int time)
        {
            if (time == 0) return;

            foreach (Disk disk in Disks)
            {
                disk.AdvanceTSteps(time);
            }
        }

        private bool Simulate(int time)
        {
            bool passed = true;

            foreach (var i in Enumerable.Range(0, Disks.Count))
            {
                if (Disks[i].GetAdvancedSimulatedPosition(i + 1) != 0)
                {
                    //Console.WriteLine($"Simulation failed for time {time}s");
                    passed = false;
                }
                if (!passed) break;
            }

            return passed;
        }
    }

    public class Disk
    {
        public Disk(int id, int numberOfPositions, int positionAtEpoch)
        {
            Id = id;
            NumberOfPositions = numberOfPositions;
            PositionAtEpoch = positionAtEpoch;
            CurrentPosition = positionAtEpoch;
        }

        public Disk(int id, int numberOfPositions, int positionAtEpoch, int positionNow)
        {
            Id = id;
            NumberOfPositions = numberOfPositions;
            PositionAtEpoch = positionAtEpoch;
            CurrentPosition = positionNow;
        }

        public int Id { get; }

        public int NumberOfPositions { get; }

        public int PositionAtEpoch { get; }

        public int CurrentPosition { get; set; }

        public bool HasBeenPassed { get; set; }
    }

    public static class DiskExtensions
    {
        public static void AdvanceTSteps(this Disk disk, int time)
        {
            for (var i = 0; i < time; i++)
            {
                disk.CurrentPosition++;
                if (disk.CurrentPosition == disk.NumberOfPositions)
                {
                    disk.CurrentPosition = 0;
                }
            }
        }

        public static void ReverseMovements(this Disk disk, int time)
        {
            for (var i = 0; i < time; i++)
            {
                disk.CurrentPosition--;
                if (disk.CurrentPosition < 0)
                {
                    disk.CurrentPosition = disk.NumberOfPositions - 1;
                }
            }
        }

        public static int GetAdvancedSimulatedPosition(this Disk disk, int timeToSimulateAdvancement)
        {
            int position = disk.CurrentPosition;

            foreach (var i in Enumerable.Range(0, timeToSimulateAdvancement))
            {
                position++;
                if (position == disk.NumberOfPositions)
                {
                    position = 0;
                }
            }

            return position;
        }

        public static int GetPositionAtTime(this Disk disk, int time)
        {
            var positionAtTimeBeforeNormalising = disk.CurrentPosition + time;

            return positionAtTimeBeforeNormalising % disk.NumberOfPositions - 1;
        }
    }
}