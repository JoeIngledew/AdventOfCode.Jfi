namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LightsToggle
    {
        private List<LightPoint> Lights;

        public LightsToggle()
        {
            Lights = new List<LightPoint>();

            // set up light array
            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    Lights.Add(new LightPoint(j, i));
                }
            }
        }

        public long InterpretInstructionAndGetLightsLit(string instructions)
        {
            var instructionList = instructions.Split('\n');

            foreach (var s in instructionList)
            {
                Interpret(s.Trim().ToLower());
            }

            return Lights.Sum(l => l.Brightness);
        }

        private void Interpret(string singleInstruction)
        {
            var coordSets = Regex.Matches(singleInstruction, "[0-9]{1,3},[0-9]{1,3}");
            var start = coordSets[0].Value.Split(',');
            var end = coordSets[1].Value.Split(',');
            var startX = int.Parse(start[0]);
            var startY = int.Parse(start[1]);
            var endX = int.Parse(end[0]);
            var endY = int.Parse(end[1]);

            var relevantLights =
                Lights.Where(
                    l =>
                    l.LightPosition.XCoord >= startX && l.LightPosition.XCoord <= endX
                    && l.LightPosition.YCoord >= startY && l.LightPosition.YCoord <= endY)
                .ToList();

            if (singleInstruction.Contains("turn on"))
            {
                relevantLights.ForEach(l => l.TurnOn());
            }
            else if (singleInstruction.Contains("turn off"))
            {
                relevantLights.ForEach(l => l.TurnOff());
            }
            else
            {
                relevantLights.ForEach(l => l.ToggleLight());
            }
        }
    }

    internal class Point
    {
        public Point(int x, int y)
        {
            XCoord = x;
            YCoord = y;
        }

        public int XCoord { get; }

        public int YCoord { get; }
    }

    internal class LightPoint
    {
        public LightPoint(int x, int y, int brightness = 0)
        {
            LightPosition = new Point(x, y);
            Brightness = brightness;
        }

        public Point LightPosition { get; set; }

        public long Brightness { get; set; }

        public void ToggleLight()
        {
            Brightness += 2;
        }

        public void TurnOff()
        {
            Brightness--;

            if (Brightness < 0) Brightness = 0;
        }

        public void TurnOn()
        {
            Brightness++;
        }
    }
}