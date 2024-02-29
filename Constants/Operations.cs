using System.Text.RegularExpressions;

namespace CsharpCalculator.Constants;

public class Signs {

      public static string Plus = "+";

      public static string Minus = "-";

}  

public class SignMatch {  

      public static Regex Plus_Minus = new(@"(\+|-)");

      public static Regex Multi_Divide =  new(@"(\*|/)");
}  


