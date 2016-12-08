namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.Remoting;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class Abacus
    {
        public int SumAllNumbers(string input)
        {
//            MatchCollection matchingReds = Regex.Matches(input, "{.*\"red\".*}");
//
//            foreach (Match red in matchingReds)
//            {
//                input = input.Replace(red.Value, "{}");
//            }

            MatchCollection numbers = Regex.Matches(input, "-{0,1}[0-9]+");

            int result = 0;

            if (numbers.Count > 0)
            {
                Trace.Write(numbers[0].Value);
//                for (var i = 0; i < numbers.Count; i++)
//                {
//                    result += int.Parse(numbers[i].Value);
//                }
                foreach (Match match in numbers)
                {
                    Trace.WriteLine(match.Value);
                    result += int.Parse(match.Value);
                }
            }

            return result;
        }

        public int SumAllNonRedNumbers(string input)
        {
            JArray removedReds = new JArray();

            var horridObject = JsonConvert.DeserializeObject<JArray>(input);

            var lessHorridObject = GetTrimmedArray(horridObject);


            var newString = JsonConvert.SerializeObject(lessHorridObject);

            return SumAllNumbers(newString);
        }

        private JArray GetTrimmedArray(JArray horridArray)
        {
            JArray newArr = new JArray();

            foreach (JToken token in horridArray)
            {
                var obj = JObject.Parse(JsonConvert.SerializeObject(token));

                if (obj != null)
                {
                    newArr.Add(RecursiveRemoveReds(obj));
                }
                else
                {
                    newArr.Add(token);
                }
            }

            return newArr;
        }

        private JObject RecursiveRemoveReds(JObject obj)
        {
            if (obj.Children().Any())
            {
                foreach (var child in obj.Children())
                {
                    var o = JObject.Parse(JsonConvert.SerializeObject(child));
                    if (o != null)
                    {
                        RecursiveRemoveReds(o);
                    }
                }
            }
            return !obj.Values<string>().Contains("red") ? obj : new JObject();
        }
    }
}