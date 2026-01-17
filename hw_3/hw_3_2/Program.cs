namespace hw_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Chain of Responsobility
            var manager = new ManagerHandler();
            var director = new DirectorHandler();
            var president = new PresidentHandler();

            manager.SetNext(director).SetNext(president);

            int[] requests = { 500, 2500, 7500, 15000 };

            foreach (var request in requests)
            {
                Console.WriteLine($"\nОбработка запроса на {request}:");
                manager.HandleRequest(request);
            }

            Console.WriteLine();

            //Iterator
            var library = new BookCollection();
            library.AddBook(new Book("Война и мир", "Лев Толстой"));
            library.AddBook(new Book("Преступление и наказание", "Фёдор Достоевский"));
            library.AddBook(new Book("1984", "Джордж Оруэлл"));

            Console.WriteLine("Все книги в библиотеке:");
            foreach (var book in library)
            {
                Console.WriteLine($"- {book.Title} ({book.Author})");
            }

            Console.WriteLine("\nПеребор вручную:");
            var iterator = library.GetEnumerator();
            while (iterator.MoveNext())
            {
                Console.WriteLine($"Книга: {iterator.Current.Title}");
            }
            iterator.Reset();

            Console.WriteLine();

            //Mediator 
            var chatRoom = new ChatRoom();

            var alice = new RegularUser("Алиса");
            var bob = new RegularUser("Боб");
            var admin = new AdminUser("Администратор");

            chatRoom.AddUser(alice);
            chatRoom.AddUser(bob);
            chatRoom.AddUser(admin);

            alice.Send("Привет всем!");
            admin.Send("Добро пожаловать в чат!");
            bob.Send("Спасибо!");


        }
    }
}
