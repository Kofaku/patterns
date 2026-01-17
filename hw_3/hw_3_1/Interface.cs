namespace hw_3_1
{
    using System;

    public interface IShape
    {
        void Accept(IVisitor visitor);
    }

    public interface IVisitor
    {
        void Visit(Sphere sphere);
        void Visit(Parallelepiped parallelepiped);
        void Visit(Torus torus);
        void Visit(Cube cube);
    }
}