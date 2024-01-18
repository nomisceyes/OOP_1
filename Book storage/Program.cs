StorageBook books = new StorageBook();
bool isExit = false;
string command;

while (isExit != true)
{
    Console.WriteLine("1 - add book \n2 - show book \n3 - delete book \n4 - search book \n5 - exit");
    command = Console.ReadLine();

    switch (command)
    {
        case "1":
            books.AddBook();
            break;
        case "2":
            books.ShowBooks();
            break;
        case "3":
            books.DeleteBook();
            break;
        case "4":
            books.SearchBook();
            break;
        case "5":
            isExit = true;
            break;
    }
    Console.ReadKey();
    Console.Clear();
}


class StorageBook
{
    private List<Book> _books = new List<Book>();
    string autorBook;
    public void AddBook()
    {
        Console.Write("Enter name book: ");
        string nameBook;
        nameBook = Console.ReadLine();

        Console.Write("Enter autor: ");

        autorBook = Console.ReadLine();

        Console.Write("Enter year of issue: ");
        int yearOfIssueBook;
        yearOfIssueBook = Convert.ToInt32(Console.ReadLine());

        Book book = new Book(nameBook, autorBook, yearOfIssueBook);
        _books.Add(book);
    }

    public void SearchBook()
    {
        Console.Write("Enter autor: ");
        string autor = Console.ReadLine();

        foreach (Book book in _books)
        {
            if (book._autor == autor)
            {
                book.ShowInfo();
            }
        }
    }

    public void DeleteBook()
    {
        if (TryGetBook(out Book book))
        {
            _books.Remove(book);
        }
    }

    public void ShowBooks()
    {
        foreach (var _book in _books)
        {
            _book.ShowInfo();
        }
    }

    public bool TryGetBook(out Book book)
    {
        Console.Write("Enter book id: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            foreach (var _book in _books)
            {
                if (_book.idBook == id)
                {
                    book = _book;
                    return true;
                }
            }
            book = null;
            Console.WriteLine("Wrong id.");
            return false;
        }
        else
        {
            book = null;
            Console.WriteLine("Wrong id.");
            return false;
        }
    }
}
class Book
{
    private string _nameBook;
    public string _autor { get;private set; }
    private int _yearOfIssue;
    public int idBook;

    public Book(string name, string autor, int yearOfIssue)
    {
        Random random = new Random();
        _nameBook = name;
        _autor = autor;
        _yearOfIssue = yearOfIssue;
        idBook = random.Next(10, 100);
    }

    public void ShowInfo()
    {
        Console.WriteLine(idBook + "." + _nameBook + "-" + _autor + "-" + _yearOfIssue);
    }
}