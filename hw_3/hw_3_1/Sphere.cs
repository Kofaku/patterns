namespace hw_3_1
{
    public class Sphere : IShape
    {
        public double Radius { get; }

        public Sphere(double radius)
        {
            Radius = radius;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}