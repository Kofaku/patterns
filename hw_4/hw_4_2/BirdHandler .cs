namespace hw_4_2
{

    public interface IBirdActionHandler
    {
        void Handle(object bird);
    }

    public class MoveHandler : IBirdActionHandler
    {
        public void Handle(object bird)
        {
            if (bird is IMovable movable)
            {
                movable.Walk();
            }

            if (bird is IFlyable flyable)
            {
                flyable.Fly();
            }
        }
    }

    public class MultiplyHandler : IBirdActionHandler
    {
        public void Handle(object bird)
        {
            if (bird is IMultipliable multipliable)
            {
                multipliable.SearchForSpouse();
                multipliable.Sing();
                multipliable.Dance();
            }
        }
    }

    public class ParentHandler : IBirdActionHandler
    {
        public void Handle(object bird)
        {
            if (bird is IParent parent)
            {
                parent.ProduceEgg();
                parent.DefendEgg();
            }
        }
    }

    public class BirdHandler
    {
        private readonly IBirdFactory _birdFactory;
        private readonly List<IBirdActionHandler> _actionHandlers;

        public BirdHandler(IBirdFactory birdFactory)
        {
            _birdFactory = birdFactory;
            _actionHandlers = new List<IBirdActionHandler>
            {
                new MoveHandler(),
                new MultiplyHandler(),
                new ParentHandler()
            };
        }

        public void DoBirdAction(string birdType)
        {
            var bird = _birdFactory.CreateBird(birdType);

            foreach (var handler in _actionHandlers)
            {
                handler.Handle(bird);
            }
        }
    }
}
