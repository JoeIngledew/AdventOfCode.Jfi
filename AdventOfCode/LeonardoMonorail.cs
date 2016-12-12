namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;

    public class LeonardoMonorail
    {
        public Dictionary<string, int> Registers = new Dictionary<string, int>()
        {
            {"a",0},
            {"b",0},
            {"c",1},
            {"d",0}
        };
        // initial setup for part 2 above

        public void Execute(string instructions)
        {
            var splitInstructions = instructions.Replace("\r", "").Split('\n');
            var currentInstruction = 0;
            var instructionsExecuted = 0;
            while (currentInstruction < splitInstructions.Length)
            {
                bool jumped = false;
                //Console.WriteLine($"Executing instruction {currentInstruction}: {splitInstructions[currentInstruction]}");
                var splitS = splitInstructions[currentInstruction].Split(' ');
                var instruction = splitS[0];

                switch (instruction)
                {
                    case "cpy":
                        var transient = 0;
                        if (int.TryParse(splitS[1], out transient))
                        {
                            Copy(transient, splitS[2]);
                        }
                        else
                        {
                            Copy(splitS[1], splitS[2]);
                        }
                        break;
                    case "inc":
                        Increment(splitS[1]);
                        break;
                    case "dec":
                        Decrement(splitS[1]);
                        break;
                    case "jnz":
                        if (int.TryParse(splitS[1], out transient))
                        {
                            if (transient != 0)
                            {
                                currentInstruction += int.Parse(splitS[2]);
                                jumped = true;
                            }
                        }
                        else {
                            if (Registers[splitS[1]] != 0)
                            {
                                currentInstruction += int.Parse(splitS[2]);
                                jumped = true;
                            }
                        }
                        break;
                    }
                

                if (!jumped)
                {
                    currentInstruction++;
                }
                instructionsExecuted++;

                if (instructionsExecuted % 100000 == 0)
                {
                    Console.WriteLine($"Instructions executed: {instructionsExecuted}");
                    Console.WriteLine($"A val: {Registers["a"]}");
                    Console.WriteLine($"B val: {Registers["b"]}");
                    Console.WriteLine($"C val: {Registers["c"]}");
                    Console.WriteLine($"D val: {Registers["d"]}");
                    Console.WriteLine();
                }
            }
        }

        private void Copy(int value, string register)
        {
            Registers[register] = value;
        }

        private void Copy(string registerFrom, string registerTo)
        {
            Registers[registerTo] = Registers[registerFrom];
        }

        private void Increment(string register)
        {
            Registers[register]++; //= Registers[register] + 1;
        }

        private void Decrement(string register)
        {
            Registers[register]--;
        }
    }
}