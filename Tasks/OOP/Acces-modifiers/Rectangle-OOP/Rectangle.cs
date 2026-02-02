public class Rectangle
{
    private double _width;
    private double _height;

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    public double Width
    {
        get => _width;
        set
        {
            if (value <= 0) throw new ArgumentException("Ширина не должна быть отрицательной или 0");
            _width = value;
        }
    }

    public double Height
    {
        get => _height;
        set
        {
            if (value <= 0) throw new ArgumentException("Высота не должна быть отрицательной или 0");
            _height = value;
        }
    }
    public double CalculateArea()
    {
        return _width * _height;
    }

    public double CalculatePerimeter()
    {
        return 2 * (_width + _height);
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Размеры: Ширина {Width}, Высота {Height}");
        Console.WriteLine($"Площадь: {CalculateArea()}");
        Console.WriteLine($"Периметр: {CalculatePerimeter()}");
    }
}