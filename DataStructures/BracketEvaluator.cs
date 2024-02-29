namespace  CsharpCalculator.DataStructures;

public class BracketEvaluator {

      public string InputString { get; set; }

      private StackCustom<char> Stack { get; set; }

      private char[] BrokenDownString { get; set; }

      private delegate bool IsBracket(char character);

      public int CharArrayCount => BrokenDownString.Count();

      public BracketEvaluator(string input) {
            this.InputString = input;
            this.Stack = new StackCustom<char>();
            BrokenDownString = this.InputString.ToCharArray();
      }

      public void Print() {
            //Print Each Character
             BrokenDownString.Foreach();   
           // BrokenDownString.ForEach(character => CharIsBracketOpening(character));
            BrokenDownString.ForEach(character => CharHasClosingBracket(character));   
            LookForMatch();

      }

      /**
      * 
      * Check 
      *
      **/
      private bool CharIsBracketOpening(char character) {
            if (character == '(') {
                  Stack.Push(character);
                  return true;
            }
            else return false;

      }
      private bool CharHasClosingBracket(char character) {
            if (character == ')') {
                  Stack.Pop();
                  return true;
            }
            else return false;

      }
      public void LookForBracketClosing() {
            IsBracket br = CharIsBracketOpening;

            Stack.BackingArray.ForEach(tr => CharHasClosingBracket(tr));

            //Check if stack is empty   
            if (Stack.IsEmpty()) Console.WriteLine("Balanced Brackets");
            else if (Stack.GetCount > 1) { Console.WriteLine("Bracket Not Balanced"); }
            // br.Invoke('(');
      }

      public void LookForMatch() {
            for (var i = 0; i < BrokenDownString.Count(); i++) {
                  if (BrokenDownString[i] == ')') {
                        //var last = Stack.Pop();   
                        if (Stack.IsEmpty()) {
                              Console.WriteLine("Balanced Stack");
                              break;
                        }
                  }
                  else if (i == BrokenDownString.Count() - 1 && BrokenDownString[i] != ')') {
                        Console.WriteLine("Stack is Not Empty! Unbalanced");

                  }

            }
            Console.WriteLine("Done Checking! :) ");

      }

}


