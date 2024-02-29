
namespace CsharpCalculator.DataStructures;

public interface StackFunctions<T> {
      void Push(T obj);

      T Pop();

      T Peek();

      bool IsEmpty();  

      bool IsBalanced(string text);

}


public class StackCustom<T> : StackFunctions<T> {

      public const int Top = -1;

      public List<T> BackingArray { get; set; }

      public int GetCount => BackingArray.Count;

      public StackCustom() {
            BackingArray = new List<T>();

      }

      public void Push(T obj) {
            BackingArray.Add(obj);
      }

      public T Peek() {
            return BackingArray.Last();
      }

      public T Pop() {

            var last = BackingArray.Count() - 1;   
            T value = BackingArray[last];
           return  value;
      }

      public bool IsEmpty() { 
           if(BackingArray.Count == 0 ) return true; 
           else return false;
      }

      public bool IsBalanced(string text) {  

            var subArray = new List<char>();

            var bracketMatch = (char i) => {  
                  if(i == '(' || i == ')') {subArray.Add(i);}

            };
            text.ForEach(it => bracketMatch(it));   

            if(subArray.Count == 0 ) return true;   
            else return false;
           
      }
}
