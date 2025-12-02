public interface IBook
{
    void Read();
}

public class Book : IBook
{
    private string _title;

    public Book(string title)
    {
        _title = title;
        LoadBookFromDatabase();
    }

    private void LoadBookFromDatabase()
    {
        Console.WriteLine($"Загрузка книги '{_title}' из базы данных. Это может занять время");
        System.Threading.Thread.Sleep(2000);
    }

    public void Read()
    {
        Console.WriteLine($"Вы читаете книгу: {_title}");
    }
}

public class User
{
    public string Username { get; set; }
    public bool IsRegistered { get; set; }
    public List<string> AllowedBooks { get; set; } = new List<string>();
}

public class BookProxy : IBook
{
    private string _title;
    private User _user;
    private Book _book;

    public BookProxy(string title, User user)
    {
        _title = title;
        _user = user;
    }

    public void Read()
    {
        if (!_user.IsRegistered)
        {
            Console.WriteLine("Доступ запрещен: пользователь не зарегистрирован.");
            return;
        }

        if (!HasAccess())
        {
            Console.WriteLine($"Доступ запрещен: у пользователя {_user.Username} нет прав на книгу '{_title}'.");
            return;
        }

        if (_book == null)
        {
            _book = new Book(_title);
        }

        _book.Read();
    }

    private bool HasAccess()
    {
        return _user.AllowedBooks.Contains(_title);
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user1 = new User
        {
            Username = "Иван",
            IsRegistered = true,
            AllowedBooks = { "Война и мир", "Преступление и наказание" }
        };

        IBook bookProxy1 = new BookProxy("Война и мир", user1);
        bookProxy1.Read();

        Console.WriteLine();

        User user2 = new User
        {
            Username = "Петр",
            IsRegistered = true,
            AllowedBooks = { "Анна Каренина" }
        };

        IBook bookProxy2 = new BookProxy("Война и мир", user2);
        bookProxy2.Read();

        Console.WriteLine();

        User user3 = new User
        {
            Username = "Сидор",
            IsRegistered = false,
            AllowedBooks = { "Война и мир" }
        };

        IBook bookProxy3 = new BookProxy("Война и мир", user3);
        bookProxy3.Read();
    }
}