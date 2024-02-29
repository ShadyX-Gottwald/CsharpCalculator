

using System.Linq.Expressions;
using System.Text;
using CsharpCalculator;

/** 
* String Extensions For Calculations 
**/
public static class StringsEx1 {   

      public static int Sub_Sum_Answer(this string subInput) {     

            int Final_Answer = 0;   

      
            return 0;
      }

      public static string Remove_Brackets(this string subInput ) { 

            var sb = new StringBuilder();   

            subInput.ForEach((char c) => {  
                 
                 if(c is not '(' and not ')' ) sb.Append(c);   
                 //else if(c is not ')') sb.Append(c);

            });
            
            return  sb.ToString();
      }

}

