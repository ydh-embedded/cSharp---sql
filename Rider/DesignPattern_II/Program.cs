using static System.Console;

namespace DesignPattern_II
{

    public class Rectangle          // Represents a rectangle with width and height.
    {
        public int Width { get; }   // Gets the width of the rectangle.

        public int Height { get; }      // Gets the height of the rectangle.

        public Rectangle(int width, int height)         // Initializes a new instance of the Rectangle class with the specified width and height.
        {
            Width = width;
            Height = height;
        }

        public override string ToString()           // Returns a string representation of the rectangle.
        {
            return $"{nameof(Width)}: {Width}, " +
                   $"{nameof(Height)}: {Height} ";
        }
    }

    public class Demo
    {

        private static int Area(Rectangle r) => r.Width * r.Height; // Calculates the area of the specified rectangle.
        
        private static void Main(string[] args)                   // Main entry point of the application.
        {
            var rcRectangle = new Rectangle(2, 3);
            WriteLine($"{rcRectangle} has area {Area(rcRectangle)}");
        }
    }
}