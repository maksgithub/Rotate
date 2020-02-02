using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WpfApp2
{
    public partial class MovingFrame
    {
        public MovingFrame()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(
            nameof(Foreground), typeof(Brush), typeof(MovingFrame), new PropertyMetadata(default));

        public Brush Foreground
        {
            get => (Brush) GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public static readonly DependencyProperty FrameWidthProperty = DependencyProperty.Register(
            nameof(FrameWidth), typeof(double), typeof(MovingFrame), new PropertyMetadata(default(double)));

        public double FrameWidth
        {
            get { return (double) GetValue(FrameWidthProperty); }
            set { SetValue(FrameWidthProperty, value); }
        }

        public static readonly DependencyProperty FrameHeightProperty = DependencyProperty.Register(
            nameof(FrameHeight), typeof(double), typeof(MovingFrame), new PropertyMetadata(default(double)));

        public double FrameHeight
        {
            get { return (double) GetValue(FrameHeightProperty); }
            set { SetValue(FrameHeightProperty, value); }
        }


        private static void PropertyChangedCallback2(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MovingFrame m)
            {
                var c = m.MoveFrame;
                var top = Canvas.GetTop(c);
                var left = Canvas.GetLeft(c);
                var center = new Point(left + c.Width / 2, top + c.Height / 2);
                Matrix myMatrix = new Matrix();
                myMatrix.RotateAt(45, center.X, center.Y);
                var point = new Point(left, top);
                point = myMatrix.Transform(point);
                Trace.TraceInformation("TOP_LEFT:" + point.ToString());
                //Trace.TraceInformation(new Point(top, left).ToString());
            }
        }


        public static readonly DependencyProperty M11Property = DependencyProperty.Register(
            "M11", typeof(ObservablePoint), typeof(MovingFrame), new PropertyMetadata(new ObservablePoint(0,0)));

        public ObservablePoint M11
        {
            get => (ObservablePoint) GetValue(M11Property);
            set => SetValue(M11Property, value);
        }
    }
}
