/*
 * Problem : Check if the input string of braces contains matching opening and closing braces or not. 
 * 
 * Input : Array of strings containing values as "{[()]}" "}[]{", "{()[]", "{([]})",...
 * Output : Array of strings containing result of braces match "YES" "NO" "NO" "YES"
 * 
 * Explanation : So in input "{[()]}" all the braces have matching close braces so the output will be "YES" but in second the closing brace is before an opening brace so output is "NO", similarly in third the opening braces are not balanced so output is "NO"
 * NOTE : In fourth input, although all the open braces have closing braces but in real world its illegal balancing. But as part of this question, it is legal. 
 *
 * Author : Naphstor
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBraces
{
  class Program
  {
    // Check if the opening brace has a matching close brace. 
    public void BasicIfElseCheck(string[] arrBraces, out string[] result)
    {
      result = new String[arrBraces.Length];
      for (int i = 0; i < arrBraces.Length; i++)
      {
        Console.WriteLine(arrBraces[i]);
        int curly = 0, square = 0, round = 0;

        foreach (char c in arrBraces[i])
        {
          if (c == '{')
          {
            curly++;
          }
          else if (c == '[')
          {
            square++;
          }
          else if (c == '(')
          {
            round++;
          }
          else if (c == '}')
          {
            if (curly > 0)
            {
              curly--;
            }
            else
            {
              curly = -1;
              break;
            }
          }
          else if (c == ']')
          {
            if (square > 0)
            {
              square--;
            }
            else
            {
              square = -1;
              break;
            }
          }
          else if (c == ')')
          {
            if (round > 0)
            {
              round--;
            }
            else
            {
              round = -1;
              break;
            }
          }
        }

        if (curly == 0 && square == 0 && round == 0)
        {
          result[i] = "YES";
        }
        else
        {
          result[i] = "NO";
        }
      }    
    }

    // Use stack data structure to match the opening and closing braces.
    public void CheckUsingStack(string[] arrBraces, out string[] result)
    {
      result = new String[arrBraces.Length];
      for (int i = 0; i < arrBraces.Length; i++) {
        Console.WriteLine(arrBraces[i]);
        var pairs = new Dictionary<char, char>() {
                      {'}','{'},
                      {']','['},
                      {')','('}
        };

        var braces = new Stack<char>();

        foreach (char c in arrBraces[i]) {
          if (pairs.ContainsValue(c)) braces.Push(c);

          if (pairs.ContainsKey(c) && (braces.Count == 0 || braces.Pop() != pairs[c])) { 
            result[i] = "NO";
          }
        }
        if (braces.Count() == 0) {
          result[i] = "YES";
        }
        else {
          result[i] = "NO";
        }
      }
    }

    static void Main(string[] args)
    {
      string[] arrBraces = Console.ReadLine().Split(' ');
      string[] result;

      Program p = new Program();
      p.BasicIfElseCheck(arrBraces, out result);
      Console.Write("Result of BasicIfElseCheck :");
      foreach (string str in result) {
        Console.Write (" {0}", str);
      }

      p.CheckUsingStack(arrBraces, out result);
      Console.Write("Result of CheckUsingStack :");
      foreach (string str in result)
      {
        Console.Write(" {0}", str);
      }
      
      Console.ReadKey();
    }
  }
}
