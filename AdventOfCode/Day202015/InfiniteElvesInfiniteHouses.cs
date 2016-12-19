namespace AdventOfCode.Day202015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InfiniteElvesInfiniteHouses
    {
        public void GetLowestHouseNumberToGetAtLeastThisManyPresents(int numPresents)
        {
            int maxPresents = 0;
            int currentHouse = 1;
            var firstHouse = 0;
            while (maxPresents < numPresents)
            {
                List<int> delivery = new List<int>();
                for (int i = 0; i < (currentHouse / 2) + 1; i++)
                {
                    if (currentHouse % (i + 1) == 0)
                    {
                        delivery.Add(i + 1);
                    }
                }

                var presentsToThisHouse = delivery.Sum(d => d * 10);
                if (presentsToThisHouse > maxPresents)
                {
                    firstHouse = currentHouse;
                    maxPresents = presentsToThisHouse;
                }

                if (currentHouse % 1000 == 0)
                {
                    Console.WriteLine($"House now: {currentHouse} Max: {maxPresents}");
                }

                currentHouse++;
            }

            Console.WriteLine($"Delivered to {firstHouse}");
            Console.WriteLine($"Presents: {maxPresents}");
        }
    }
}