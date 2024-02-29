// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
#pragma warning disable format
using System.Text;
using System.Text.RegularExpressions;   
using CsharpCalculator.Services;   
using CsharpCalculator.Constants;

namespace CsharpCalculator;

/* 
* ----Stage 1: Match digit + space plus digit , StAGE 1 fROM JETBRAINS ACADEMY, BUT IN C#.     
*Evaluate that string
* PRINT  sum of those two digits . +++ 
*----Stage 3: account for negative values+++   
*----Stage 4: multi sign input (4 ---3)   
*----Stage 5:
* 
*@"-{1,4}\d{1,3}\s?|\+{1,4}\d{1,3}\s?"  
*\s?\-{1,3}\s?\d{1,4}\s?|\+*\s?\d{1,4}
**/

public class Program {

      private const string PATTERN = @"-{1,4}\d{1,3}\s?|\+{1,4}\d{1,3}\s?"; // 3 + 34 -12 match sum

      private const string EXIT = "exit";
      private static bool RUNNING = true;
      private static Regex regex = new Regex(PATTERN);


      /* 
      * Input - Either valid Sum , Algebraic or Exit. 
      * Perform on Input padding of Starting + , Remove Spaces. 
      * 
      *
      */
      public static void Main(string[] args) {
              var val = "44 + 4";   
              //Validations.Algebra.EvaluateInput(val);  

          /* while (RUNNING) {   
                  var sum = Console.ReadLine();
                  
                  EvaluateInput(sum?
                   .Replace_Keys()
                   .SignLessInput()
                   .RemoveSpaces()
               );
            }   */ 

            Test(val);


      }
      private static void EvaluateInput(string? input) {
            var matchPattern = @"((\w+)|[aA-zZ])\s?\=\s?\d{1,5}";

            if (regex.IsMatch(input ?? "0")) {
                  Validations.ValidateUserInput(input ?? "");
            }
            else if (EXIT.ToRegex().IsMatch(input ?? "0")) {
                  RUNNING = false;
            } 
            // Save Algebraic Match input 
            else if(Regex.IsMatch(input, pattern: RegexStrings.Key_Match )) { 
            
                  Validations.Save_Pair_Value(input);

            }
            //Match Key with value , replace keys, else 0  [aA-aZ]|(\w+)|(\+|-)*|\d{1,4}
            else if(Regex.IsMatch(input, @"[aA-aZ]|(\w+)")) {    
                  //Get Match Collection.  
                  var matches = Regex.Matches(input, @"[aA-aZ]|(\w+)");    

                  //Replace its keys with values , return string . Extension Method.  

            }

      } 

      private static void Test(string input) {     
           var list =  input.ToList();     

          // list.ForEach(it => Console.WriteLine(it));

      }
}


public static class Extensions {

      public static void Foreach(this IEnumerable<char> source) {

            foreach (var item in source) { Console.WriteLine(item); }
      }

      public static void Foreach(this IEnumerable<char> source, Action<char> action) {

            foreach (var item in source) { action(item); }
      }

      public static void Foreach(this MatchCollection source, Action<string> action) {

            foreach (var item in source) { action(item.ToString() ?? " "); }
      }

      public static void ForEach(this IEnumerable<char> source, Action<char> action) {
            foreach (var item in source) { action(item); }
      }

      public static Regex ToRegex(this string input) {
            string escaped = Regex.Escape(input);
            // Create and return a new Regex object with the escaped string as the pattern
            return new Regex(escaped);

      }

      public static Int32 ToInteger(this string value) {
            return Int32.Parse(value);
      }

      //public static 

      public static int SumValues(this MatchCollection matches) {

          var sum = 0;
          var pattern_negative = @"\s?\-{1,3}\s?\d{1,4}\s?|\+*\s?\d{1,4}|\d{1,3}";

          var actionCheck = (string aNumber) => {
               string checkValue = Validations.SignChecker(aNumber);
               var number = Int32.Parse(checkValue);

               if (Int32.IsNegative(number)) {
                    sum = sum + number;
               }    
               else if(Int32.IsPositive(number)) { 
                    sum = sum + number;
               }
               else { sum = sum + number; }

          };

          foreach (Match num in matches) {
               var valueCaptured = num.Value;

               var checkValue = Validations.SignChecker(valueCaptured);
               var number = Int32.Parse(checkValue);

               if (Int32.IsNegative(number) ) {
                    sum += number;
               }
               else{ 
                 sum = sum + Int32.Parse(checkValue);
                    
               }

               
               //Console.WriteLine("--"+ num.ToString());
          }
          return sum;
      }

      public static int PlusCount(this string subInput) {
            var count = 0;
            foreach (char c in subInput) if (c == '+') { count++; }

            return count;
      }

      public static int NegativeCount(this string subInput) {
            var count = 0;
            foreach (char c in subInput) if (c == '-') { count++; }

            return count;
      }
      public static string SignLessInput(this string input) {
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
      public static string RemoveSpaces(this string input) {
            var stringBuilder = new StringBuilder();
            var pattern = @"[^\s]";
            // var input = "1+ (-4) + (7*2)";    

            var func = (char c) => {
                  if (Regex.IsMatch(c.ToString(), pattern: pattern)) {
                        stringBuilder.Append(c);
                  }
            };

            input.Foreach(it => func.Invoke(it));

            return stringBuilder.ToString();
      }  

      public static string Replace_Keys(this string input) { 

            StringBuilder sb = new();     

            var matches = Regex.Matches(input , @"[aA-aZ]|(\w+)|(\+|-)*|\d{1,4}");  

            foreach(Match match in matches) { 
                  var key = match.Value ;   
                  //Check if is Match in Value Pairs  
                  if(Validations.Algebra.ValuePairs.ContainsKey(key)) {  
                        //Replace Key with value    
                        string? value = Validations.Algebra.ValuePairs.GetValueOrDefault(key??"0");  
                        if(value == null) { 
                              return "0";
                        }     

                        //Add To String Builder   
                        sb.Append(value); 


                  }  

                  else { 
                        sb.Append(key);
                  }
            }
            //Convert to List , then Replace and stitch together.
          

           return sb.ToString();
      }

     
}

