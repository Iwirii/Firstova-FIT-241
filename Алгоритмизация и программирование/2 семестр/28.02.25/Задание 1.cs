using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Введите выражение в постфиксной польской записи: ");
        string input = Console.ReadLine();
        var result = calculate_expression(input);
        if (result.success)
        {
            Console.WriteLine("Результат: " + result.value);
        }
        else
        {
            Console.WriteLine("Ошибка: " + result.error_message);
        }
    }
    static (bool success, double value, string error_message) calculate_expression(string expression)
    {
        string[] elements = expression.Split(' ');
        Stack<double> stack = new Stack<double>();
        foreach (string element in elements)
        {
            if (element == "+" || element == "-" || element == "*" || element == "/")
            {
                if (stack.Count < 2)
                {
                    return (false, 0, "Недостаточно операндов для операции");
                }

                double operand2 = stack.Pop();
                double operand1 = stack.Pop();
              
                double result;
                switch (element)
                {
                    case "+":
                        result = operand1 + operand2;
                        break;
                    case "-":
                        result = operand1 - operand2;
                        break;
                    case "*":
                        result = operand1 * operand2;
                        break;
                    case "/":
                        if (operand2 != 0)
                        {
                            result = operand1 / operand2;
                        }
                        else
                        {
                            return (false, 0, "Деление на ноль");
                        }
                        break;
                    default:
                        return (false, 0, "Недопустимая операция");
                }
                stack.Push(result);
            }
            else
            {
                if (double.TryParse(element, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    return (false, 0, "Недопустимый элемент в выражении");
                }
            }
        }
        if (stack.Count != 1)
        {
            return (false, 0, "Неверное выражение");
        }
        return (true, stack.Pop(), "");
    }
}
