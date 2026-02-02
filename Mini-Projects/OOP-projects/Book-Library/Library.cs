namespace Book_Library
{
    public class Library
    {
        private List<Book> _books = new();
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public List<Book> GetBooksList()
        {
            return new List<Book>(_books);
        }

        public Book GetBookByNumber(int bookNumber)
        {
            int index = bookNumber - 1;
            return _books[index];
        }

        public bool Borrow(Book book)
        {
            if (book.IsAvailable)
            {
                book.SetAvailability(false);
                return true;
            }
            return false;
        }

        public bool Return(Book book)
        {
            if (!book.IsAvailable)
            {
                book.SetAvailability(true);
                return true;
            }
            return false;
        }

        public List<Book> FindByAuthor(string author)
        {
            List<Book> findedBooks = new List<Book>();

            foreach (Book book in _books)
            {
                if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    findedBooks.Add(book);
                }
            }
            return findedBooks;
        }
    }
}