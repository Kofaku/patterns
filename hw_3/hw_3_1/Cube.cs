namespace hw_3_1
{
    public class Cube : IShape
    {
        public double Side { get; }

        public Cube(double side)
        {
            Side = side;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}