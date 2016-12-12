namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class BalanceBots
    {
        public List<Bot> Bots = new List<Bot>();
        public List<Output> Outputs = new List<Output>();

        public void Setup(string instructionSet)
        {
            Console.WriteLine("Initiating Setup");
            var splitInstructions = instructionSet.Replace("\r", "").Split('\n');
            foreach (var i in splitInstructions)
            {
                var splitI = i.Split(' ');

                if (splitI[0] == "value")
                {
                    var botId = int.Parse(splitI[5]);

                    if (Bots.Any(b => b.BotId == botId))
                    {
                        Bot thisBot = Bots.Single(b => b.BotId == botId);
                        thisBot.Chips.Add(int.Parse(splitI[1]));
                    }
                    else
                    {
                        var thisBot = new Bot(botId);
                        thisBot.Chips.Add(int.Parse(splitI[1]));
                        Bots.Add(thisBot);
                    }
                }

                else
                {
                    var botId = int.Parse(splitI[1]);
                    var lowToId = int.Parse(splitI[6]);
                    var highToId = int.Parse(splitI[11]);
                    bool isLowToOutput = splitI[5] == "output";
                    bool isHighToOutput = splitI[10] == "output";

                    if (Bots.Any(b => b.BotId == botId))
                    {
                        var thisBot = Bots.Single(b => b.BotId == botId);
                        if (isLowToOutput)
                        {
                            thisBot.LowOutputBin = lowToId;
                            if (Outputs.All(o => o.OutId != lowToId))
                            {
                                Outputs.Add(new Output(lowToId));
                            }
                        }
                        else
                        {
                            thisBot.LowOutputBot = lowToId;
                        }
                        if (isHighToOutput)
                        {
                            thisBot.HighOutputBin = highToId;
                            if (Outputs.All(o => o.OutId != highToId))
                            {
                                Outputs.Add(new Output(highToId));
                            }
                        }
                        else
                        {
                            thisBot.HighOutputBot = highToId;
                        }
                    }
                    else
                    {
                        var thisBot = new Bot(botId);
                        if (isLowToOutput)
                        {
                            thisBot.LowOutputBin = lowToId;
                            if (Outputs.All(o => o.OutId != lowToId))
                            {
                                Outputs.Add(new Output(lowToId));
                            }
                        }
                        else
                        {
                            thisBot.LowOutputBot = lowToId;
                        }
                        if (isHighToOutput)
                        {
                            thisBot.HighOutputBin = highToId;
                            if (Outputs.All(o => o.OutId != highToId))
                            {
                                Outputs.Add(new Output(highToId));
                            }
                        }
                        else
                        {
                            thisBot.HighOutputBot = highToId;
                        }
                        Bots.Add(thisBot);
                    }
                }
            }
            Console.WriteLine("Finished setting up scenario");
        }

        public int Execute()
        {
            Console.WriteLine("Starting eval...");
            bool isEvaluatedEnough = Bots.Any(b => b.Chips.Contains(61) && b.Chips.Contains(17));

            while (!isEvaluatedEnough)
            {
                var botsWithEnoughChips = Bots.Where(b => b.Chips.Count == 2).ToList();
                foreach (Bot bot in botsWithEnoughChips)
                {
                    var lowChipId = bot.Chips.OrderBy(c => c).First();
                    var highChipId = bot.Chips.OrderBy(c => c).Last();

                    bool isLowToOutputBin = bot.LowOutputBin != null;
                    bool isHighToOutputBin = bot.HighOutputBin != null;

                    bool canPassOnChips = true;
                    if (!isLowToOutputBin || !isHighToOutputBin)
                    {
                        if (!isLowToOutputBin)
                        {
                            var outBot = Bots.Single(b => b.BotId == bot.LowOutputBot);
                            if (outBot.Chips.Count > 1)
                            {
                                canPassOnChips = false;
                            }
                        }
                        if (!isHighToOutputBin)
                        {
                            var outBot = Bots.Single(b => b.BotId == bot.HighOutputBot);
                            if (outBot.Chips.Count > 1)
                            {
                                canPassOnChips = false;
                            }
                        }
                    }

                    if (canPassOnChips)
                    {
                        if (isLowToOutputBin)
                        {
                            var toOut = Outputs.Single(o => o.OutId == bot.LowOutputBin);
                            toOut.Chips.Add(lowChipId);
                            bot.Chips.Remove(lowChipId);
                        }
                        else
                        {
                            var outputBot = Bots.Single(b => b.BotId == bot.LowOutputBot);
                            if (outputBot.Chips.Count < 2)
                            {
                                outputBot.Chips.Add(lowChipId);
                                bot.Chips.Remove(lowChipId);
                            }
                        }

                        if (isHighToOutputBin)
                        {
                            var toOut = Outputs.Single(o => o.OutId == bot.HighOutputBin);
                            toOut.Chips.Add(highChipId);
                            bot.Chips.Remove(highChipId);
                        }
                        else
                        {
                            var outputBot = Bots.Single(b => b.BotId == bot.HighOutputBot);
                            if (outputBot.Chips.Count < 2)
                            {
                                outputBot.Chips.Add(highChipId);
                                bot.Chips.Remove(highChipId);
                            }
                        }
                    }
                }

                isEvaluatedEnough = Bots.All(b => b.Chips.Count != 2);
                if (!isEvaluatedEnough)
                {
                    Console.WriteLine("Not evaluated fully. Retrying...");
                }
            }

            return 1;
        }

        public int GetMultiplyRes()
        {
            var chipInZero = Outputs.Single(o => o.OutId == 0).Chips.First();
            var chipInOne = Outputs.Single(o => o.OutId == 1).Chips.First();
            var chipInTwo = Outputs.Single(o => o.OutId == 2).Chips.First();

            return chipInZero * chipInOne * chipInTwo;
        }
    }

    public class Bot
    {
        public Bot(int id)
        {
            BotId = id;
            Chips = new List<int>();
            Console.WriteLine($"Bot {id} initialised");
        }

        public int BotId { get; }

        public List<int> Chips { get; set; }

        public int? LowOutputBot { get; set; }
        
        public int? LowOutputBin { get; set; }

        public int? HighOutputBot { get; set; }

        public int? HighOutputBin { get; set; }
    }

    public class Output
    {
        public Output(int outId)
        {
            OutId = outId;
            Chips = new List<int>();
        }

        public int OutId { get; }

        public List<int> Chips { get; set; }
    }
}
