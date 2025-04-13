//Необходимо реализовать обобщенный класс, который позволяет хранить в массиве объекты любого типа. 
//В данном классе определить методы для добавления данных в массив, удаления из массива, получения элемента по индексу
using System;
public class GenericArray<T>
{
    private T[] array;
    private int count;

    public GenericArray(int size)
    {
        array = new T[size];
        count = 0;
    }

    public void Add(T item)
    {
        if (count >= array.Length)
        {
            ResizeArray();
        }
        array[count] = item;
        count++;
        Console.WriteLine("Был добавлен элемент");
        PrintArray();
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException("Индекс вне границ массива.");
        }

        for (int i = index; i < count - 1; i++)
        {
            array[i] = array[i + 1];
        }
        count--;
        array[count] = default;
        Console.WriteLine("Был удалён элемент");
        PrintArray();
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException("Индекс вне границ массива.");
        }

        return array[index];
    }

    private void ResizeArray()
    {
        T[] newArray = new T[array.Length * 2];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        array = newArray;
    }

    public void PrintArray()
    {
        Console.Write("Массив: ");
        for (int i = 0; i < count; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Пример 1:");
        GenericArray<int> intArray = new GenericArray<int>(5);
        intArray.Add(1);
        intArray.Add(2);
        intArray.Add(3);
        intArray.RemoveAt(1);
        Console.WriteLine("Элемент по индексу 1: " + intArray.Get(1));

        Console.WriteLine("\nПример 2:");
        GenericArray<string> stringArray = new GenericArray<string>(5);
        stringArray.Add("Hello");
        stringArray.Add("World");
        stringArray.RemoveAt(0);
        Console.WriteLine("Элемент по индексу 0: " + stringArray.Get(0));
    }
}
