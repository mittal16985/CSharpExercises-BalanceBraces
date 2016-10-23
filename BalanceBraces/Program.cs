/*
 * Input : Array of strings containing values as "{[()]}" "}[]{", "{()[]", ...
 * Output : Array of strings containing result of braces match "YES" "NO"
 * Explanation : So in input "{[()]}" all the braces have matching close braces so the output will be "YES" 
 * but in second the closing brace is before an opening brace so output is "NO", similarly in third braces are not balanced so output is "NO" 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBraces
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] arrBraces = Console.ReadLine().Split(' ');
      string[] result = new String[arrBraces.Length];

      /* *****Solution using basic if-else conditions.*****/
       for (int i = 0; i < arrBraces.Length; i++) {
        Console.WriteLine(arrBraces[i]);
        int curly = 0, square = 0, round = 0;

        foreach (char c in arrBraces[i]) {
          if (c == '{') {
            curly++;
          } else if (c == '[') {
            square++;
          } else if (c == '(') {
            round++;
          } else if (c == '}') {
            if (curly > 0) {
              curly--;
            } else {
              curly = -1;
              break;
            }
          } else if (c == ']') {
            if (square > 0) {
              square--;
            } else {
              square = -1;
              break;
            }
          } else if (c == ')') {
            if (round > 0) {
              round--;
            } else {
              round = -1;
              break;
            }
          }
        }

        if (curly == 0 && square == 0 && round == 0) {
          result[i] = "YES";
        } else {
          result[i] = "NO";
        }
      }
      

      /* *****Solution using Stack.*****
      for (int i = 0; i < arrBraces.Length; i++) {
        Console.WriteLine(arrBraces[i]);
        var pairs = new Dictionary<char, char>() {
            {'}','{'},
            {']','['},
            {')','('}
        };

        var history = new Stack<char>();

        foreach (char c in arrBraces[i]) {
          if (pairs.ContainsValue(c)) history.Push(c);

          if (pairs.ContainsKey(c) && (history.Count == 0 || history.Pop() != pairs[c])) {
            result[i] = "NO";
          }
        }
        if (history.Count() == 0) {
          result[i] = "YES";
        }
        else {
          result[i] = "NO";
        }
      }
      */

      foreach (string str in result) {
        Console.WriteLine (str);
      }
      Console.ReadKey();
    }
  }
}
