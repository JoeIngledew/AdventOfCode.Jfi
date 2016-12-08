namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    public class BitwiseWiring
    {

        // COMPLETYELY WRONG
        public Dictionary<string, int> WireSignals { get; }

        private string[] _posTwoOperators = { "AND", "OR", "LSHIFT", "RSHIFT" };

        private const string PosOneOperator = "NOT";

        public BitwiseWiring()
        {
            WireSignals = new Dictionary<string, int>();
        }

        public void InterpretInstructions(string allInstructions)
        {
            var splitInstructions = allInstructions.Split('\n');

            foreach (var instruction in splitInstructions)
            {
                Interpret(instruction);
            }
        }

        private void Interpret(string instruction)
        {
            var instructionSplit = instruction.Split(' ');

            if (_posTwoOperators.Any(o => instructionSplit[1] == o))
            {
                DoPosTwoOps(instructionSplit);
            }
            else if (instructionSplit[0] == PosOneOperator)
            {
                DoNot(instructionSplit);
            }
            else
            {
                var key = instructionSplit[2];
                var value = instructionSplit[0];

                int val;
                if (!int.TryParse(value, out val))
                {
                    val = Convert.ToInt32(ToBinary(value), 2);
                }

                WireSignals.Add(key.Trim(), val);
            }
        }

        private void DoPosTwoOps(string[] ins)
        {
            switch (ins[1])
            {
                case "AND":
                    DoAnd(ins);
                    break;
                case "OR":
                    DoOr(ins);
                    break;
                case "LSHIFT":
                    DoLShift(ins);
                    break;
                case "RSHIFT":
                    DoRShift(ins);
                    break;
            }
        }

        private void DoNot(string[] ins)
        {
            var key = ins[3];
            var valOfOp = WireSignals.Any(s => s.Key == ins[1]) ? WireSignals.Single(k => k.Key == ins[1]).Value : Convert.ToInt32(ToBinary(ins[1]), 2);
            var val = ~valOfOp;

            WireSignals.Add(key.Trim(), val);
        }

        private void DoAnd(string[] ins)
        {
            var key = ins[4];
            var valOfOpOne = WireSignals.Any(s => s.Key == ins[0]) ? WireSignals.Single(k => k.Key == ins[0]).Value : Convert.ToInt32(ToBinary(ins[0]), 2);
            var valOfOpTwo = WireSignals.Any(s => s.Key == ins[2]) ? WireSignals.Single(k => k.Key == ins[2]).Value : Convert.ToInt32(ToBinary(ins[2]), 2);
            var val = valOfOpOne & valOfOpTwo;

            WireSignals.Add(key.Trim(), val);
        }

        private void DoOr(string[] ins)
        {
            var key = ins[4];
            var valOfOpOne = WireSignals.Any(s => s.Key == ins[0]) ?  WireSignals.Single(k => k.Key == ins[0]).Value : Convert.ToInt32(ToBinary(ins[0]), 2);
            var valOfOpTwo = WireSignals.Any(s => s.Key == ins[2]) ? WireSignals.Single(k => k.Key == ins[2]).Value : Convert.ToInt32(ToBinary(ins[2]), 2);

            var val = valOfOpOne | valOfOpTwo;

            WireSignals.Add(key.Trim(), val);
        }

        private void DoLShift(string[] ins)
        {
            var key = ins[4];
            var valOfOpOne = WireSignals.Any(s => s.Key == ins[0]) ? WireSignals.Single(k => k.Key == ins[0]).Value : Convert.ToInt32(ToBinary(ins[0]), 2);
            var valOfOpTwo = Convert.ToInt32(ToBinary(ins[2]), 2);

            var val = valOfOpOne << valOfOpTwo;

            WireSignals.Add(key.Trim(), val);
        }

        private void DoRShift(string[] ins)
        {
            var key = ins[4];
            var valOfOpOne = WireSignals.Any(s => s.Key == ins[0]) ? WireSignals.Single(k => k.Key == ins[0]).Value : Convert.ToInt32(ToBinary(ins[0]), 2);
            var valOfOpTwo = Convert.ToInt32(ToBinary(ins[2]), 2);

            var val = valOfOpOne >> valOfOpTwo;

            WireSignals.Add(key.Trim(), val);
        }

        public static string ToBinary(string data, bool formatBits = false)
        {
            char[] buffer = new char[(((data.Length * 8) + (formatBits ? (data.Length - 1) : 0)))];
            int index = 0;
            for (int i = 0; i < data.Length; i++)
            {
                string binary = Convert.ToString(data[i], 2).PadLeft(8, '0');
                for (int j = 0; j < 8; j++)
                {
                    buffer[index] = binary[j];
                    index++;
                }
                if (formatBits && i < (data.Length - 1))
                {
                    buffer[index] = ' ';
                    index++;
                }
            }
            return new string(buffer);
        }
    }
}