//Выполнить построение бинарного дерева на основе данных, которые представляют собой объекты следующей структуры:
//1. Идентификационный номер студента
//2. ФИО студента
//3. Два указателя, которые указывают на левую часть дерева и на правую часть дерева
using System;
class StudentNode
{
    public int Id;
    public string FullName;
    public StudentNode Left;
    public StudentNode Right;

    public StudentNode(int id, string fullName)
    {
        Id = id;
        FullName = fullName;
        Left = null;
        Right = null;
    }
}

class BinaryTree
{
    public StudentNode Root;

    public BinaryTree()
    {
        Root = null;
    }

    public void Insert(int id, string fullName)
    {
        StudentNode newNode = new StudentNode(id, fullName);

        if (Root == null)
        {
            Root = newNode;
            return;
        }

        StudentNode current = Root;
        StudentNode parent = null;

        while (true)
        {
            parent = current;

            if (id < current.Id)
            {
                current = current.Left;
                if (current == null)
                {
                    parent.Left = newNode;
                    return;
                }
            }
            else 
            {
                current = current.Right;
                if (current == null)
                {
                    parent.Right = newNode;
                    return;
                }
            }
        }
    }

    public void Traverse(StudentNode node)
    {
        if (node == null)
            return;
        Console.WriteLine($"ID: {node.Id}, ФИО: {node.FullName}");
        Traverse(node.Left);
        Traverse(node.Right);
    }
}

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();

        Console.Write("Сколько студентов добавить? ");
        bool parsed = int.TryParse(Console.ReadLine(), out int count);
        if (!parsed || count <= 0)
        {
            Console.WriteLine("Неверное количество.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Студент №{i + 1}:");

            Console.Write("Введите ID студента: ");
            bool idParsed = int.TryParse(Console.ReadLine(), out int id);
            if (!idParsed)
            {
                Console.WriteLine("Неверный ID");
                i--;
                continue;
            }

            Console.Write("Введите ФИО студента: ");
            string fullName = Console.ReadLine();

            tree.Insert(id, fullName);
        }

        Console.WriteLine("\nДерево студентов:");
        tree.Traverse(tree.Root);
    }
}
