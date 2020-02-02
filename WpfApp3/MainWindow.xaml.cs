using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            canvas.Children.Clear();
            Point[] points = new Point[5]
            {
                new Point(0,  0),
                new Point(100 , 0),
                new Point(100, 100),
                new Point(0, 100 ),
                new Point(0,  0),
            };
            //DrawLine(points);
            DrawLine2(points);
            Matrix myMatrix = new Matrix();
            myMatrix.RotateAt(45, 50, 50);
            myMatrix.Transform(points);
            DrawLine2(points);
        }

        private void DrawLine(Point[] points)
        {
            int i;
            int count = points.Length;
            for (i = 0; i < count - 1; i++)
            {
                Line myline = new Line();
                myline.Stroke = Brushes.Red;
                myline.X1 = points[i].X;
                myline.Y1 = points[i].Y;
                myline.X2 = points[i + 1].X;
                myline.Y2 = points[i + 1].Y;
                canvas.Children.Add(myline);
            }
        }

        private void DrawLine2(Point[] points)
        {
            Polyline line = new Polyline();
            PointCollection collection = new PointCollection();
            foreach (Point p in points)
            {
                collection.Add(p);
            }
            line.Points = collection;
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeThickness = 1;
            line.Margin = new Thickness(20);
            canvas.Children.Add(line);
        }
    }
}
