namespace hw_3_1
{
    public class Torus : IShape
    {
        public double MajorRadius { get; }
        public double MinorRadius { get; }

        public Torus(double majorRadius, double minorRadius)
        {
            MajorRadius = majorRadius;
            MinorRadius = minorRadius;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}