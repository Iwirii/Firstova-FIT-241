//Работа со структурами слово Struct должно присутствовать(типо которые используем в классе, либо без класса работаем только со списком заданной структуры). 
//Будет база данный библиотека, будут элементы которые характеризуют книгу: фамилия автора, наименование книги, год издания, издательство, 
//сведения о выдаче и сдачи книги в виде дата выдачи и дата возврата, на основе этой базы данных надо выдать книги, 
//которые ни разу не выдавались и необходимо выдать книги, которые не возвращены в библиотеку, если поле не  заполнено, значит либо не выдана, либо не возвращена.
using System;
using System.Collections.Generic;

public struct Book
{
    public string Author;
    public string Title;
    public int Year;
    public string Publisher;
    public DateTime? IssueDate;  
    public DateTime? ReturnDate; 
}

class Program
{
    static void Main()
    {
        List<Book> library = new List<Book>
        {
            new Book { Author = "Толстой", Title = "Война и мир", Year = 1869, Publisher = "Русский вестник" },
            new Book { Author = "Достоевский", Title = "Преступление и наказание", Year = 1866, Publisher = "Русский вестник", IssueDate = new DateTime(2024, 1, 15), ReturnDate = new DateTime(2024, 2, 20) },
            new Book { Author = "Гоголь", Title = "Мертвые души", Year = 1842, Publisher = "Современник", IssueDate = new DateTime(2024, 3, 10) },
            new Book { Author = "Пушкин", Title = "Евгений Онегин", Year = 1833, Publisher = "Литературная газета" },
            new Book { Author = "Булгаков", Title = "Мастер и Маргарита", Year = 1967, Publisher = "Москва", IssueDate = new DateTime(2024, 5, 1), ReturnDate = null }
        };

        Console.WriteLine("Книги, которые никогда не выдавались:");
        foreach (Book book in library)
        {
            if (book.IssueDate == null)
            {
                Console.WriteLine($"{book.Author} - {book.Title} ({book.Year})");
            }
        }

        Console.WriteLine("\nКниги, которые не возвращены:");
        foreach (Book book in library)
        {
            if (book.IssueDate != null && book.ReturnDate == null)
            {
                Console.WriteLine($"{book.Author} - {book.Title} (выдана: {book.IssueDate:dd.MM.yyyy})");
            }
        }
    }
}
