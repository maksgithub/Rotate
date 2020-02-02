using System.Windows;

namespace WpfApp3
{
    public class RectInfo
    {
        public RectInfo(Point initialPoint, double width, double height, double angle)
        {
            InitialPoint = initialPoint;
            Width = width;
            Height = height;
            Angle = angle;
        }

        public Point InitialPoint { get; }
        public double Width { get; }
        public double Height { get; }
        public double Angle { get; }
    }
}