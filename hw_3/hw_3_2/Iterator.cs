using System.Collections;

namespace hw_3_2
{
    public class BookCollection : IEnumerable<Book>
    {
        private List<Book> _books = new List<Book>();

        public void AddBook(Book book) => _books.Add(book);

        public IEnumerator<Book> GetEnumerator()
        {
            return new BookIterator(_books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Book
    {
        public string Title { get; }
        public string Author { get; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    public class BookIterator : IEnumerator<Book>
    {
        private List<Book> _books;
        private int _position = -1;

        public BookIterator(List<Book> books) => _books = books;

        public Book Current => _books[_position];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _position++;
            return _position < _books.Count;
        }

        public void Reset() => _position = -1;

        public void Dispose() { }
    }
}
