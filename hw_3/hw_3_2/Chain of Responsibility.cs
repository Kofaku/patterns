namespace hw_3_2
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void HandleRequest(int request);
    }

    public abstract class BaseHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual void HandleRequest(int request)
        {
            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine($"Запрос {request} никто не обработал!");
            }
        }
    }

    public class ManagerHandler : BaseHandler
    {
        public override void HandleRequest(int request)
        {
            if (request <= 1000)
            {
                Console.WriteLine($"Менеджер обработал запрос на сумму {request}");
            }
            else
            {
                Console.WriteLine($"Менеджер не может обработать {request}, передаю дальше");
                base.HandleRequest(request);
            }
        }
    }

    public class DirectorHandler : BaseHandler
    {
        public override void HandleRequest(int request)
        {
            if (request <= 5000)
            {
                Console.WriteLine($"Директор одобрил запрос на {request}");
            }
            else
            {
                Console.WriteLine($"Директор не может одобрить {request}, передаю дальше");
                base.HandleRequest(request);
            }
        }
    }

    public class PresidentHandler : BaseHandler
    {
        public override void HandleRequest(int request)
        {
            if (request <= 10000)
            {
                Console.WriteLine($"Президент компании одобрил {request}");
            }
            else
            {
                base.HandleRequest(request);
            }
        }
    }
}
