using Xunit;
using CsharpCalculator.DataStructures;   
using CsharpCalculator.Services;

namespace CsharpCalculator.UnitTests.DataStructureTests;   


public class StackTests {     

      [Fact]
      public void Should_Have_One_Item() {      
            var stack = new StackCustom<char>();   
            stack.Push('c');   

            Assert.Equal(actual:stack.GetCount, expected: 1);

      }  

      //Test How many are pushed in Stack in sum: 2+2   

      [Fact]
      public void Should_Have_Two_Items_In_PostFix() {     
            
            var postFix = new PostFix("2+2");    

            var ans = postFix.Operands.GetCount;   

            Assert.Equal(2, ans);

      }  

      [Fact]
      public void Four_Plus_Four_PostFix() {   

            var sum = "4+4";  

            PostFix fix = new PostFix(sum);     

           var result =  fix.ConvertToPostFix()  ;  

           //Assert.Equal("44+", result );

      }

}
