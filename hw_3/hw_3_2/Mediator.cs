namespace hw_3_2
{
    public interface IChatMediator
    {
        void SendMessage(string message, User user);
        void AddUser(User user);
    }

    public class ChatRoom : IChatMediator
    {
        private List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            _users.Add(user);
            user.SetMediator(this);
        }

        public void SendMessage(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.Receive(message);
                }
            }
        }
    }

    public abstract class User
    {
        protected IChatMediator _mediator;
        public string Name { get; }

        public User(string name) => Name = name;

        public void SetMediator(IChatMediator mediator) => _mediator = mediator;

        public void Send(string message)
        {
            Console.WriteLine($"{Name} отправляет: {message}");
            _mediator.SendMessage(message, this);
        }

        public abstract void Receive(string message);
    }

    public class RegularUser : User
    {
        public RegularUser(string name) : base(name) { }

        public override void Receive(string message)
        {
            Console.WriteLine($"[Обычный пользователь {Name}] получил: {message}");
        }
    }

    public class AdminUser : User
    {
        public AdminUser(string name) : base(name) { }

        public override void Receive(string message)
        {
            Console.WriteLine($"[АДМИН {Name}] получил: {message}");
        }
    }
}
