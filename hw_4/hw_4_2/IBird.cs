namespace hw_4_2
{
    public interface IMovable
    {
        void Walk();
    }

    public interface IFlyable
    {
        void Fly();
    }

    public interface IMultipliable
    {
        void SearchForSpouse();
        void Sing();
        void Dance();
    }

    public interface IParent
    {
        void ProduceEgg();
        void DefendEgg();
    }
}
