using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WpfApp3
{
    public class PointHelper
    {
        private static readonly Vector _horizontalVector = Point.Subtract(
            new Point(0, 0),
            new Point(1, 0));
        public static double GetHorizontalAngle(Point p1, Point p2)
        {
            var v1 = Point.Subtract(p1, p2);
            return Vector.AngleBetween(_horizontalVector, v1);
        }

        public static RectInfo GetRectInfoFromPoints(Point p1, Point p2, Point p3)
        {
            var angle = GetHorizontalAngle(p1, p2);
            var width = Point.Subtract(p2, p1).Length;
            var height = Point.Subtract(p3, p2).Length;
            var centerPoint = GetMidPoint(p1, p3);
            Matrix myMatrix = new Matrix();
            myMatrix.RotateAt(-angle, centerPoint.X, centerPoint.Y);
            Point initialPoint = myMatrix.Transform(p1);
            return new RectInfo(initialPoint, width, height, angle);
        }

        private static Point GetMidPoint(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X)/2, (p1.Y + p2.Y) / 2);
        }
    }
}
