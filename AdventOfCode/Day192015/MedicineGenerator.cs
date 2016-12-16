namespace AdventOfCode.Day192015
{
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