namespace hw_3_1
{
    public class Parallelepiped : IShape
    {
        public double Length { get; }
        public double Width { get; }
        public double Height { get; }

        public Parallelepiped(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}