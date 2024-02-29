using System.Security.AccessControl;
using System.Text.RegularExpressions;
namespace CsharpCalculator;

public class AlgebraCalculator {

      public Dictionary<string, string> ValuePairs { get; set; }
      public string PATTERN = @"[aA-zZ]\s?\=\s?\d{1,4}";
      private string KeyPattern = @"[aA-zZ]";
      private string ValuePattern = @"\d{1,4}";


      public AlgebraCalculator() {
            ValuePairs = new Dictionary<string, string>();
      }

      public void EvaluateInput(string input) {
            //var matches = Regex.Matches();   

            //Check for matches and save
            if (Regex.IsMatch(input, KeyPattern) && Regex.IsMatch(input, ValuePattern)) {
                  var key = Regex.Match(input, pattern: KeyPattern).ToString();
                  var value = Regex.Match(input, pattern: ValuePattern).ToString();

                  //Set that matching Key and Value
                  ValuePairs[key] = value;

            }
            else {
                  var answer = RevealAnswer(input: input);

            }

      }

      public int RevealAnswer(string input) {
            var sum = 0;


            var getValue = (string match) => {
                  var number = match.ToInteger();
                  sum = sum + number;
            };

            var matches = Regex.Matches(input, pattern: KeyPattern);

            matches.Foreach(it => getValue(it));

            return sum;

      }

}
