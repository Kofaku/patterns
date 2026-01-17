namespace hw_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            VolumeVisitor volumeCalculator = new VolumeVisitor();

            Sphere sphere = new Sphere(5);
            Parallelepiped box = new Parallelepiped(3, 4, 5);
            Torus donut = new Torus(10, 3);
            Cube cube = new Cube(4);

            IShape[] shapes = { sphere, box, donut, cube };

            foreach (IShape shape in shapes)
            {
                shape.Accept(volumeCalculator);
            }
        }
    }
}