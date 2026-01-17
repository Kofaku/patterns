namespace hw_3_1
{
    public class VolumeVisitor : IVisitor
    {
        public void Visit(Sphere sphere)
        {
            double volume = (4.0 / 3.0) * Math.PI * Math.Pow(sphere.Radius, 3);
            Console.WriteLine($"Объем сферы (радиус = {sphere.Radius}): {volume:F2}");
        }

        public void Visit(Parallelepiped parallelepiped)
        {
            double volume = parallelepiped.Length * parallelepiped.Width * parallelepiped.Height;
            Console.WriteLine($"Объем параллелепипеда ({parallelepiped.Length}x{parallelepiped.Width}x{parallelepiped.Height}): {volume:F2}");
        }

        public void Visit(Torus torus)
        {
            double volume = 2 * Math.PI * Math.PI * torus.MajorRadius * Math.Pow(torus.MinorRadius, 2);
            Console.WriteLine($"Объем тора (R = {torus.MajorRadius}, r = {torus.MinorRadius}): {volume:F2}");
        }

        public void Visit(Cube cube)
        {
            double volume = Math.Pow(cube.Side, 3);
            Console.WriteLine($"Объем куба (сторона = {cube.Side}): {volume:F2}");
        }
    }
}