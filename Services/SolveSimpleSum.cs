using System.Text.RegularExpressions;
using CsharpCalculator;
using CsharpCalculator.DataStructures;   
using System.Collections.Generic;
using Microsoft.VisualBasic;

/*
* Class to Solve a simple sum , with Brackets , plus an Minus 
* Methods -> BreakdownSum() , Solve  
*/
public class SolveSimple: SolveSum { 

      public static int Final_Answer {get;set;} = 0;
      public Queue<string> Sub_Sums {get ; set ;} = new() ;    

      public Stack<string> Strings_Stack {get; set;} = new();

      private static int Sub_Answer {get; set;} = 0;

      private  static string Rgx_String {get;set;} = @"\(\d{1,3}[+|-]\d{1,3}\)[+|-]\d{1,3}.?";  
      private static Regex Rgx {get;set;} = new Regex(Rgx_String);  


      public  SolveSimple() { 
            this.Strings_Stack = new();
      }


      public override void BreakdownSum(string sum) {  

            var break_down_text = Rgx.Matches(sum);      

            // Strings_Stack = new Stack<string>() ;

           //var ans =  break_down_text.SumValues();   
            //"(4+5)-3"
           foreach (Match match in break_down_text) {    
              Sub_Sums.Enqueue(match.Value);
            
           }

            
            
      }

      public override int Solve() {   

            while(Sub_Sums.Count > 0 ) {     

                  //Purify Sub Sum
                  var subSum = Sub_Sums.Dequeue() 
                                      .Remove_Brackets();       

                  //Validation For Signs                    

                  var  validated = Validations.SignChecker(subSum) ;     

                  MatchDigits(sum:validated) ;             


            }
            
            return Final_Answer;
      }

      private  void MatchDigits(string sum ) {      
             //Stack for saving numbers 
                     
                  //Regex for Sign and Digit.   
                  var regex_string = @"[+|-]\d{1,3}";   
                  var regex = new  Regex(regex_string);  

            //Grab Matching Collection 

            var matches = regex.Matches(sum);   

           

            foreach(Match match in matches) {       
                  //For Testing Push sum values to Stack.   
                  
                  Strings_Stack.Push(match.Value);
                  //Convert String to Int For Calculation
                  var parsed_value = int.Parse(match.Value);  
                  //stack.Push(parsed_value);

                  if( int.IsNegative(parsed_value)) {    
                        Sub_Answer+= parsed_value;
                        
                  }   

                  else if(int.IsPositive(parsed_value)) {   
                        Sub_Answer+= parsed_value;

                  }

            }   

            Final_Answer = Final_Answer +  Sub_Answer;

      }
}
