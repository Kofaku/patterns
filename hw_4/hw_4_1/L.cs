using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_4_1
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Square : Rectangle
    {
        private int _side;

        public override int Width
        {
            get => _side;
            set => _side = value;
        }

        public override int Height
        {
            get => _side;
            set => _side = value;
        }
    }

    public class AreaCalculator
    {
        public void TestRectangleArea()
        {
            Rectangle rect = new Rectangle();
            rect.Width = 5;
            rect.Height = 3;

            Console.WriteLine($"Ожидаемая площадь: 15");
            Console.WriteLine($"Реальная площадь: {rect.CalculateArea()}");

            Rectangle squareAsRect = new Square();
            squareAsRect.Width = 5;
            squareAsRect.Height = 3;

            Console.WriteLine($"\nКвадрат");
            Console.WriteLine($"Ожидаемая площадь: 15");
            Console.WriteLine($"Реальная площадь: {squareAsRect.CalculateArea()}");
        }
}

}
