using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var books = new List<Book>
{
    new Book("Мастер и Маргарита", "Михаил Булгаков"),
    new Book("Преступление и наказание", "Фёдор Достоевский"),
    new Book("Евгений Онегин", "Александр Пушкин")
};

Console.WriteLine("=== Книги в библиотеке ===");
books.ForEach(b => b.PrintInfo());

// Выдаём одну книгу и пробуем выдать её повторно
Console.WriteLine("\n=== Выдача книги ===");
books[0].ChangeStatus(isAvailable: false);
books[0].ChangeStatus(isAvailable: false);
books[0].PrintInfo();

// Возвращаем книгу
Console.WriteLine("\n=== Возврат книги ===");
books[0].ChangeStatus(isAvailable: true);
books[0].PrintInfo();

/// <summary>
/// Книга в библиотеке: название, автор и статус доступности.
/// </summary>
class Book
{
    public string Title { get; }
    public string Author { get; }
    public bool IsAvailable { get; private set; }

    public Book(string title, string author, bool isAvailable = true)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название не может быть пустым.", nameof(title));
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Автор не может быть пустым.", nameof(author));

        Title = title;
        Author = author;
        IsAvailable = isAvailable;
    }

    // Меняет статус книги: true — доступна, false — выдана
    public void ChangeStatus(bool isAvailable)
    {
        if (IsAvailable == isAvailable)
        {
            Console.WriteLine($"Книга «{Title}» уже {StatusText}.");
            return;
        }

        IsAvailable = isAvailable;
        Console.WriteLine($"Статус книги «{Title}» изменён: {StatusText}.");
    }

    private string StatusText => IsAvailable ? "доступна" : "выдана";

    public void PrintInfo()
    {
        Console.WriteLine($"«{Title}» — {Author} [{StatusText}]");
    }
}
