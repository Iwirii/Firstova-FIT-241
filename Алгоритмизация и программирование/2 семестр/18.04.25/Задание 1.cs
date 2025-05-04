//Дан файл с набором строк. В каждой строке распологаются различные символы(цифры, буквы и т.д.). 
//Необходимо в выходной(новый) файл выдать только те строки, в которых имеется хотя бы одно четное число. 
//Числом будем считать набор цифр ограниченный другими символами(конец строки тоже символ)
using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    static void Main()
    {
        string input = "input.txt";
        string output = "output.txt";

        var outputLines = new List<string>();

        foreach (string line in File.ReadAllLines(input))
        {
            if (ContainsEvenNumber(line))
            {
                outputLines.Add(line);
            }
        }
        File.WriteAllLines(output, outputLines);
        Console.WriteLine($"Готово! Результат сохранён в {output}");
    }

    static bool ContainsEvenNumber(string line)
    {
        string currentNumber = "";

        foreach (char c in line)
        {
            if (char.IsDigit(c))
            {
                currentNumber += c;
            }
            else if (currentNumber != "")
            {
                if (IsEven(currentNumber))
                    return true;

                currentNumber = "";
            }
        }
        return currentNumber != "" && IsEven(currentNumber);
    }

    static bool IsEven(string number)
    {
        char lastDigit = number[number.Length - 1]; 
        return lastDigit == '0' || lastDigit == '2' || lastDigit == '4' ||
               lastDigit == '6' || lastDigit == '8';
    }
}
