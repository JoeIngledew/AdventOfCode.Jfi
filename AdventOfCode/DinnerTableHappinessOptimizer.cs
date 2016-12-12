namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Linq;

    using MoreLinq;

    public class DinnerTableHappinessOptimizer
    {
        public int GetOptimalDeltaHappiness(string input)
        {
            var statements = input.Replace("\r", "").Split('\n');

            List<HappinessMapping> mappings = new List<HappinessMapping>();
            List<Person> people = new List<Person>();

            foreach (string statement in statements)
            {
                var split = statement.Split(' ');
                var personOne = split[0];
                var personTwo = split[10];
                var isPositive = split[2] == "gain";
                var amount = int.Parse(split[3]);
                var delta = isPositive ? amount : 0 - amount;

                if (people.Any(p => p.Name == personOne))
                {
                    Person otherP;
                    if (people.All(p => p.Name != personTwo))
                    {
                        otherP = new Person(personTwo);
                        people.Add(otherP);
                    }
                    else
                    {
                        otherP = people.Single(p => p.Name == personTwo);
                    }
                    people.Single(p => p.Name == personOne).Mappings.Add(new HMapping(otherP, delta));
                }
                else
                {
                    var person = new Person(personOne);
                    Person otherP;
                    if (people.All(p => p.Name != personTwo))
                    {
                        otherP = new Person(personTwo);
                        people.Add(otherP);
                    }
                    else
                    {
                        otherP = people.Single(p => p.Name == personTwo);
                    }
                    person.Mappings.Add(new HMapping(otherP, delta));
                    people.Add(person);
                }
                //mappings.Add(new HappinessMapping(personOne, personTwo, delta));
            }



            return 1;

            // todo replace
            //            var permutations = GetPermutations(people);
            //
            //            var lowestHappiness = int.MaxValue;
            //            var highestHappiness = int.MinValue;
            //            IList<HappinessMapping> optimalConfiguration = new List<HappinessMapping>();
            //            IList<HappinessMapping> leastOptimalConfiguration = new List<HappinessMapping>();
            //
            //            foreach (var permutation in permutations)
            //            {
            //                var happinessMappings = permutation as IList<Person> ?? permutation.ToList();
            //                var thisPermHappiness = happinessMappings.Sum();
            //                if (thisPermHappiness > highestHappiness)
            //                {
            //                    highestHappiness = thisPermHappiness;
            //                    optimalConfiguration = happinessMappings;
            //                }
            //                else if (thisPermHappiness < lowestHappiness)
            //                {
            //                    lowestHappiness = thisPermHappiness;
            //                    leastOptimalConfiguration = happinessMappings;
            //                }
            //                Console.WriteLine($"This permutation: {string.Join(" | ", happinessMappings.Select(h => $"{h.PersonOneName}/{h.DeltaHappiness}/{h.PersonTwoName}"))}");
            //                Console.WriteLine($"Total happiness: {thisPermHappiness}");
            //            }
            //
            //            return highestHappiness;
        }

        public static IEnumerable<PersonToPersonMap> Permute(IList<Person> people)
        {
            throw new NotImplementedException();
        }

        public static IList<PersonToPersonMap> GeneratePermutation(IList<Person> people)
        {
            throw new NotImplementedException();
        }

        // shamelessly stolen from stackoverflow
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items)
        {
            if (items.Count() > 1)
            {
                return items.SelectMany(item => GetPermutations(items.Where(i => !i.Equals(item))),
                    (item, permutation) => new[] { item }.Concat(permutation));
            }
            else
            {
                return new[] { items };
            }
        }
    }

    public class Person : IEquatable<Person>
    {
        public Person(string name)
        {
            Name = name;
            Mappings = new List<HMapping>();
        }

        public string Name { get; }

        public List<HMapping> Mappings { get; set; }

        public bool Equals(Person other)
        {
            return other != null && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != typeof(Person))
            {
                return false;
            }

            var other = (Person)obj;

            return Equals(other);
        }
    }

    public class HMapping
    {
        public HMapping(Person otherPerson, int deltaHappiness)
        {
            OtherPerson = otherPerson;
            DeltaHappiness = deltaHappiness;
        }

        public Person OtherPerson { get; }

        public int DeltaHappiness { get; }
    }

    public class PersonToPersonMap : IEquatable<PersonToPersonMap>
    {
        public PersonToPersonMap(int delta, Person firstPerson, Person secondPerson)
        {
            Delta = delta;
            FirstPerson = firstPerson;
            SecondPerson = secondPerson;
        }

        public Person FirstPerson { get; }

        public Person SecondPerson { get; }

        public int Delta { get; }

        public bool Equals(PersonToPersonMap other)
        {
            return other != null
                   && (FirstPerson.Equals(other.FirstPerson)
                       && SecondPerson.Equals(other.SecondPerson));
        }

        public override int GetHashCode()
        {
            return FirstPerson.GetHashCode() ^ SecondPerson.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(PersonToPersonMap))
            {
                return false;
            }
            else
            {
                return Equals((PersonToPersonMap)obj);
            }
        }
    }

    public class HappinessMapping : IEquatable<HappinessMapping>
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

        public override int GetHashCode()
        {
            return PersonOneName.GetHashCode() ^ PersonTwoName.GetHashCode() ^ DeltaHappiness.GetHashCode();
        }

        public bool Equals(HappinessMapping other)
        {
            return other?.Equals((object)this) ?? false;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != typeof(HappinessMapping))
            {
                return false;
            }

            var other = (HappinessMapping)obj;

            return PersonOneName == other.PersonOneName;// && PersonTwoName == other.PersonTwoName
                   //&& DeltaHappiness == other.DeltaHappiness;
        }
    }
}