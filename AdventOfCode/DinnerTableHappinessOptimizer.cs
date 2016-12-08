namespace AdventOfCode
{
    using System.Collections.Generic;

    public class DinnerTableHappinessOptimizer
    {
        public int GetOptimalDeltaHappiness(string input)
        {
            var statements = input.Replace("\r", "").Split('\n');

            List<HappinessMapping> mappings = new List<HappinessMapping>();

            foreach (string statement in statements)
            {
                var split = statement.Replace(".", "").Split(' ');
                var personOne = split[0];
                var personTwo = split[10];
                var isPositive = split[2] == "gain";
                var amount = int.Parse(split[3]);
                var delta = isPositive ? amount : 0 - amount;

                mappings.Add(new HappinessMapping(personOne, personTwo, delta));
            }
            return 1;
        }
    }

    public class HappinessMapping
    {
        public HappinessMapping(string personOneName, string personTwoName, int deltaHappiness)
        {
            PersonOneName = personOneName;
            PersonTwoName = personTwoName;
            DeltaHappiness = deltaHappiness;
        }

        public string PersonOneName { get; }

        public string PersonTwoName { get; }

        public int DeltaHappiness { get; }
    }
}