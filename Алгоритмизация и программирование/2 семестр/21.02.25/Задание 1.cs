using System;
using System.Collections.Generic;
class Programm
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите арифметическое выражение:");
        string ar_expression = Console.ReadLine();
        if (Check(ar_expression) == true)
        {
            Console.WriteLine("Скобки в выражении расставлены правильно");
        }
        else
        {
            Console.WriteLine("Скобки в выражении расставлены неправильно");
        }

    }
    static bool Check(string ar_expression)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char s in ar_expression)
        {
            if (s == '(' ||  s == '{' || s == '[')
            {
                stack.Push(s);
            }
            else if (s == ')' || s == '}' || s == ']')
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                char open = stack.Pop();
                if (Pair(open, s) == false)
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
    static bool Pair(char open, char close)
    {
        return (open == '(' && close == ')') || (open == '{' && close == '}') || (open == '[' && close == ']');
    }
}
