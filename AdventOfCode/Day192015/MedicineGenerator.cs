namespace AdventOfCode.Day192015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    // TODO RUN
    public class MedicineGenerator
    {
        private string inputString =
            "CRnCaSiRnBSiRnFArTiBPTiTiBFArPBCaSiThSiRnTiBPBPMgArCaSiRnTiMgArCaSiThCaSiRnFArRnSiRnFArTiTiBFArCaCaSiRnSiThCaCaSiRnMgArFYSiRnFYCaFArSiThCaSiThPBPTiMgArCaPRnSiAlArPBCaCaSiRnFYSiThCaRnFArArCaCaSiRnPBSiRnFArMgYCaCaCaCaSiThCaCaSiAlArCaCaSiRnPBSiAlArBCaCaCaCaSiThCaPBSiThPBPBCaSiRnFYFArSiThCaSiRnFArBCaCaSiRnFYFArSiThCaPBSiThCaSiRnPMgArRnFArPTiBCaPRnFArCaCaCaCaSiRnCaCaSiRnFYFArFArBCaSiThFArThSiThSiRnTiRnPMgArFArCaSiThCaPBCaSiRnBFArCaCaPRnCaCaPMgArSiRnFYFArCaSiThRnPBPMgAr";

        private List<Transformation> _transformations = new List<Transformation>();

        public int GetNumberOfDistinctTransformations(string input)
        {
            var splitIn = input.Replace("\r", "").Split('\n');

            foreach (var s in splitIn)
            {
                var splitS = s.Split(' ');
                _transformations.Add(new Transformation(splitS[0], splitS[2]));
            }

            List<string> transformResults = (from transformation in _transformations
                                             let matches = Regex.Matches(inputString, transformation.From)
                                             from Match match in matches
                                             select
                                                 inputString.Remove(match.Index, match.Length)
                                                 .Insert(match.Index, transformation.To)).ToList();

            return transformResults.Distinct().Count();
        }

        public int GetMinStepsFrom(string startKey, string input)
        {
            //var splitIn = input.Replace("\r", "").Split('\n');

            //foreach (var s in splitIn)
            //{
            //    var splitS = s.Split(' ');
            //    _transformations.Add(new Transformation(splitS[0], splitS[2]));
            //}

            //var current = startKey;

            Func<string, int> countStr = x =>
            {
                var count = 0;
                for (var index = inputString.IndexOf(x); index >= 0; index = inputString.IndexOf(x, index + 1), ++count) { }
                return count;
            };

            var num = inputString.Count(char.IsUpper) - countStr("Rn") - countStr("Ar") - 2 * countStr("Y") - 1;
            //num.Dump();

            return num;
        }
    }

    public class Transformation
    {
        public Transformation(string @from, string to)
        {
            From = @from;
            To = to;
        }

        public string From { get; }
        public string To { get; }
    }
}