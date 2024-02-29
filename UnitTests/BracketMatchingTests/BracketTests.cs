using Xunit;   
using CsharpCalculator.DataStructures;


namespace CsharpCalculator.UnitTests.BracketMatchingTests;

public class BracketTests { 

      [Fact]
      public void Should_Be_3_Chars()  {   

            var stack = new BracketEvaluator("())"); 
               
            
            var ans =   stack.CharArrayCount;       

            
            Assert.Equal(3,ans);

      }
}
