namespace AdventOfCode.Day162015
{
    using System.Collections.Generic;
    using System.Linq;

    using MoreLinq;

    public class WhichAuntSue
    {
        // MFCSAM output hard-coded
        const int NumChildren = 3;
        const int NumCats = 7;
        const int NumSamoyeds = 2;
        const int NumPomeranians = 3;
        const int NumAkitas = 0;
        const int NumVizslas = 0;
        const int NumGoldfish = 5;
        const int NumTrees = 3;
        const int NumCars = 2;
        const int NumPerfumes = 1;
        // Sue 62: samoyeds: 2, cats: 8, goldfish: 7

        public int FindAunt(string input)
        {
            var splitIn = input.Replace("\r", "").Replace(":", "").Replace(",", "").Split('\n');
            List<Aunt> aunts = new List<Aunt>();

            foreach (var s in splitIn)
            {

                int index = 0;
                int? numChildren = null;
                int? numCats = null;
                int? numSamoyeds = null;
                int? numPomeranians = null;
                int? numAkitas = null;
                int? numVizslas = null;
                int? numGoldfish = null;
                int? numTrees = null;
                int? numCars = null;
                int? numPerfumes = null;
                var splitS = s.Split(' ').ToList();
                index = int.Parse(splitS[1]);
                if (s.Contains("children"))
                {
                    numChildren = int.Parse(splitS[splitS.IndexOf("children") + 1]);
                }
                if (s.Contains("cats"))
                {
                    numCats = int.Parse(splitS[splitS.IndexOf("cats") + 1]);
                }
                if (s.Contains("samoyeds"))
                {
                    numSamoyeds = int.Parse(splitS[splitS.IndexOf("samoyeds") + 1]);
                }
                if (s.Contains("pomeranians"))
                {
                    numPomeranians = int.Parse(splitS[splitS.IndexOf("pomeranians") + 1]);
                }
                if (s.Contains("akitas"))
                {
                    numAkitas = int.Parse(splitS[splitS.IndexOf("akitas") + 1]);
                }
                if (s.Contains("vizslas"))
                {
                    numVizslas = int.Parse(splitS[splitS.IndexOf("vizslas") + 1]);
                }
                if (s.Contains("goldfish"))
                {
                    numGoldfish = int.Parse(splitS[splitS.IndexOf("goldfish") + 1]);
                }
                if (s.Contains("trees"))
                {
                    numTrees = int.Parse(splitS[splitS.IndexOf("trees") + 1]);
                }
                if (s.Contains("cars"))
                {
                    numCars = int.Parse(splitS[splitS.IndexOf("cars") + 1]);
                }
                if (s.Contains("perfumes"))
                {
                    numPerfumes = int.Parse(splitS[splitS.IndexOf("perfumes") + 1]);
                }

                aunts.Add(
                    new Aunt(
                        index,
                        numChildren,
                        numCats,
                        numSamoyeds,
                        numPomeranians,
                        numAkitas,
                        numVizslas,
                        numGoldfish,
                        numTrees,
                        numCars,
                        numPerfumes));
            }

            foreach (Aunt aunt in aunts)
            {
                bool isCorrect = true;
                if (aunt.NumChildren != null)
                {
                    if (aunt.NumChildren != NumChildren) isCorrect = false;
                }
                if (aunt.NumCats != null)
                {
                    if (aunt.NumCats <= NumCats) isCorrect = false;
                }
                if (aunt.NumSamoyeds != null)
                {
                    if (aunt.NumSamoyeds != NumSamoyeds) isCorrect = false;
                }
                if (aunt.NumPomeranians != null)
                {
                    if (aunt.NumPomeranians >= NumPomeranians) isCorrect = false;
                }
                if (aunt.NumAkitas != null)
                {
                    if (aunt.NumAkitas != NumAkitas) isCorrect = false;
                }
                if (aunt.NumVizslas != null)
                {
                    if (aunt.NumVizslas != NumVizslas) isCorrect = false;
                }
                if (aunt.NumGoldfish != null)
                {
                    if (aunt.NumGoldfish >= NumGoldfish)
                    {
                        isCorrect = false;
                    }
                }
                if (aunt.NumTrees != null)
                {
                    if (aunt.NumTrees <= NumTrees) isCorrect = false;
                }
                if (aunt.NumCars != null)
                {
                    if (aunt.NumCars != NumCars) isCorrect = false;
                }
                if (aunt.NumPerfumes != null)
                {
                    if (aunt.NumPerfumes != NumPerfumes) isCorrect = false;
                }

                if (isCorrect)
                {
                    return aunt.Index;
                }
            }
            return -1;
        }
    }

    public class Aunt
    {
        public Aunt(
            int index,
            int? numChildren,
            int? numCats,
            int? numSamoyeds,
            int? numPomeranians,
            int? numAkitas,
            int? numVizslas,
            int? numGoldfish,
            int? numTrees,
            int? numCars,
            int? numPerfumes)
        {
            Index = index;
            NumChildren = numChildren;
            NumCats = numCats;
            NumSamoyeds = numSamoyeds;
            NumPomeranians = numPomeranians;
            NumAkitas = numAkitas;
            NumVizslas = numVizslas;
            NumGoldfish = numGoldfish;
            NumTrees = numTrees;
            NumCars = numCars;
            NumPerfumes = numPerfumes;
        }

        public int Index { get; }
        public int? NumChildren { get; }
        public int? NumCats { get; }
        public int? NumSamoyeds { get; }
        public int? NumPomeranians { get; }
        public int? NumAkitas { get; }
        public int? NumVizslas { get; }
        public int? NumGoldfish { get; }
        public int? NumTrees { get; }
        public int? NumCars { get; }
        public int? NumPerfumes { get; }
    }
}