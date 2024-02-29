
using System.Text;
using System.Text.RegularExpressions;
using CsharpCalculator;


public class Test {

      public static void Testing() {


            var count = 0;
            var reg = @"\s?\-{1,3}\s?\d{1,4}\s?|\+*\s?\d{1,4}";

            var test = "4+4+4--2";
            var modifiedInput = Validations.SignLessInput(test);
            var regex = Regex.Matches(modifiedInput, reg);


            foreach (Match match in regex) {
                  var value = match.Value;
                  if (value.NegativeCount() == 1) {
                        Console.WriteLine(value);

                        var number = Int32.Parse(value);
                        if (Int32.IsNegative(number)) {
                              count = count + number;
                        }

                  }
                  else if (value.PlusCount() == 1) {
                        Console.WriteLine(value);

                        var number = Int32.Parse(value);
                        if (Int32.IsNegative(number)) {
                              count = count + number;
                        }
                        else {
                              count = count + number;
                        }

                  }

                  else if (value.NegativeCount() == 3) {
                        string checkValue = Validations.SignChecker(value);
                        var number = Int32.Parse(checkValue);
                        if (Int32.IsNegative(number)) {
                              count = count + number;
                        }

                  }
                  else if (value.NegativeCount() == 0) {
                        string checkValue = Validations.SignChecker(value);
                        var number = Int32.Parse(checkValue);
                        if (Int32.IsNegative(number)) {
                              count = count + number;
                        }
                        else {
                              count = count + number;
                        }

                  }

            }

            Console.WriteLine(count);
      }
      public static string Test2() {

            var stringBuilder = new StringBuilder();
            var pattern = @"[^\s]";
            var input = "1+ (-4) + (7*2)";

            var func = (char c) => {
                  
                  if (Regex.IsMatch(c.ToString(), pattern: pattern)) {
                        stringBuilder.Append(c);
                  }
            };

            input.Foreach(it => func.Invoke(it));

            return stringBuilder.ToString();

      }

}
