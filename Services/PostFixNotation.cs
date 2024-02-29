

using CsharpCalculator.DataStructures;
using System.Text;
using System.Text.RegularExpressions;    
using CsharpCalculator.Constants;

namespace CsharpCalculator.Services;   

/*
* Convert Sum string to PostFix Notation.
* Operand and Operation Stack .
* Get 
*/    

interface IPostfix { 
      
      string ConvertToPostFix();     
      void FindOperands();    

      void FindOperations();
}  


public class PostFix: IPostfix { 
      public  string Input {get; set;}     

      public char[] ArrayChar  => Input.ToCharArray();       

      //Stack Data Structures     
      public StackCustom<string> Operations = new ();   

      public StackCustom<string> Operands = new();   

      //Delegate to Match Operand and Operations
     // public Delegate IsOperationOrOperand;

      

            
      public  PostFix(string Input) {    
            this.Input = Input;          

            FindOperands();
      }

      public string ConvertToPostFix() {     

            StringBuilder sb = new ();  

            //Get all Matches correctly , Left to right.
            MatchCollection matchCollection = Regex.Matches(Input,pattern: RegexStrings.Valid_Sum_Match)  ;     
            List<Match> values = matchCollection.ToList(); 
            var count = 0;

             while(count < values.Count() ) { 

                  // Check if that match is a number then push. operands stack.
                  if(Regex.IsMatch(values[count].Value , pattern: @"\d{1,4}")) { 
                        var value = values[count].Value ;
                        sb.Append(value) ;
                        count++;  

                  } 
                  else  {  
                       // while(!Operations.IsEmpty()) { 
                              //Pop operation stack  
                             // sb.Append(Operations.Pop()) ;
                       // }
                  }
            }

           


            // From input string 

            return sb.ToString().RemoveSpaces();
           
      } 

      private bool IsOperationOrOperand(char character) { 

            var operandMatch = Regex.Match(character.ToString(), @"\d[1,5]");
            if(operandMatch.Success) {    
                  var value = operandMatch.Value;
                  Operands.Push(value);   
                  return true;
            }
            return false;
      }  

      public void FindOperands() { 
            var matches = Regex.Matches(Input,  @"\d{1,5}");   

            matches.Foreach(it => Operands.Push(it));
      }

      public void FindOperations() { 

            var matches = Regex.Matches(Input,  @"(\+|-)");   

            matches.Foreach(it => Operands.Push(it));

      }   


}
