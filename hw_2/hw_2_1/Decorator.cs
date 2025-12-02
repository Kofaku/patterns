namespace hw2_1
{
    interface IBoxGiver
    {
        void Give(string box);
    }

    class SimpleGiver : IBoxGiver
    {
        public void Give(string box)
        {
            Console.WriteLine($"Подарено: {box}");
        }
    }

    abstract class GiftBoxDecorator : IBoxGiver
    {
        protected IBoxGiver _giver;
        public GiftBoxDecorator(IBoxGiver giver)
        {
            _giver = giver;
        }
        public virtual void Give(string box)
        {
            _giver.Give(box);
        }
    }

    class BowKnotDecorator : GiftBoxDecorator
    {
        public BowKnotDecorator(IBoxGiver giver) : base(giver) { }
        public override void Give(string box)
        {
            string decoratedBowKnot = "Украшено бантом (" + box + ")";
            base.Give(decoratedBowKnot);
        }
    }

    class WrappingPaperDecorator : GiftBoxDecorator
    {
        public WrappingPaperDecorator(IBoxGiver giver) : base(giver) { }
        public override void Give(string box)
        {
            string decoratedWrappingPaper = "Украшено бумагой (" + box + ")";
            base.Give(decoratedWrappingPaper);
        }
    }
}