using System.Text;
using System.Text.RegularExpressions;
using CsharpCalculator;       
using CsharpCalculator.CalculatorTypes;


/*
* Entry Point For All Calculations to Start - Add Algebraic 
**/
public static class Validations {

      //(\s?\-{1,3}\s?\d{1,4}\s?|\+*\s?\d{1,4}\))|\b[^\d\W]+\b
      private static string NegativeMatch = "-{1,4}\\d{1,3}\\s?";
      private static string PATTERN = @"\s?\-{1,3}\s?\d{1,4}\s?|\+*\s?\d{1,4}";
      //public static StackCustom<int> Stack = new StackCustom<int>(); 

      public static AlgebraicCalculations Algebra = new();

      public static void ValidateUserInput(string input) {
            //Add to stack ,matching digits.     
            var rgx = Regex.Matches(input: input, pattern: PATTERN);

            var summedValue = rgx.SumValues();  
            
            Console.WriteLine(summedValue);

      }
      public static string SignChecker(string match) {
            var result = "";
            var resultBuilder = new StringBuilder();

            if (match.PlusCount() >= 1) {
                  //Match Digit and Take  ,Append appropriate char at start.  
                  var number = Regex.Match(match, @"\d{1,5}");
                  var stringBuilder = resultBuilder.Append($"+{number.ToString()}");
            }
            //Number of Minus Signs infront of number, pad String Appropriately. 
            else if (match.NegativeCount() == 2) {
                  var number = Regex.Match(match, @"\d{1,5}");
                  var stringBuilder = resultBuilder.Append($"+{number.ToString()}");
            }
            //
            else if (match.NegativeCount() == 3) {
                  var number = Regex.Match(match, @"\d{1,5}");
                  var stringBuilder = resultBuilder.Append($"-{number.ToString()}");

            }
            else if (match.NegativeCount() == 1) {
                  var number = Regex.Match(match, @"\d{1,5}");
                  var stringBuilder = resultBuilder.Append($"-{number.ToString()}");
            }
            else if (match.NegativeCount() == 0) {
                  //var number = Regex.Match(match, @"\d{1,5}");   
                  var stringBuilder = resultBuilder.Append(match);

            }
            return resultBuilder.ToString();
      }
      
      public static string SignLessInput(string input) {
            var result = "+";
            var stringBuilder = new StringBuilder();
            var regex = @"\d";

            var rg = Regex.Match(input.First().ToString(), regex);

            if (rg.Success) {
                  stringBuilder.Append(result + input);
            }
            else { stringBuilder.Append(result + input); }


            return stringBuilder.ToString();
      }   

      public static void Save_Pair_Value(string input) {  
            //Match Key   
            var key = Regex.Match(input, @"((\w+)|[aA-zZ])").ToString();   
            
            // Match Value and link to its Key.    
            var value = Regex.Match(input, @"\d{1,5}").ToString();   

            Algebra.ValuePairs.Add(key, value);


      }
}
