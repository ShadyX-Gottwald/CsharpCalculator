using Xunit;   
using CsharpCalculator.Services;
using Xunit.Sdk;

/**Test Queue
* Have single sum match , 
* Push Numbers To Stack and Count First. Before Summing Values.
*/

public class TestQueue {

      [Fact]   
      public void Should_Have_One_Sum() {  

            var sum = "(4+5)-3";   

            var simple = new SolveSimple();  
            simple.BreakdownSum(sum);    

            Assert.Single(simple.Sub_Sums) ;    

      }


      [Fact]  
       public void Should_Have_No_Brackets() {  

            var sum = "(4+5)-3".Remove_Brackets();   

            Assert.Equal("4+5-3", sum);

      }     

      [Fact] 
      public void Should_Have_3_Strings_In_Stack() {     

             var sum = "(4+5)-3";     

             var simple = new SolveSimple();  
             simple.BreakdownSum(sum);  

            var answer =  simple.Solve();   

           // Assert.Equal(6, answer );   

           var count = simple.Strings_Stack.Count();   


            
          Assert.Equal(1, count);
      }


      
}
