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


        public static readonly DependencyProperty LeftProperty = DependencyProperty.Register(
            "Left", typeof(double), typeof(MovingFrame), new PropertyMetadata(default(double)));

        public double Left
        {   
            get { return (double) GetValue(LeftProperty); }
            set { SetValue(LeftProperty, value); }
        }

        public static readonly DependencyProperty TopProperty = DependencyProperty.Register(
            "Top", typeof(double), typeof(MovingFrame), new PropertyMetadata(default(double), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
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



        public double Top
        {
            get { return (double) GetValue(TopProperty); }
            set { SetValue(TopProperty, value); }
        }

        private void Thumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            var c = Canvas.GetTop(MoveFrame as UIElement);
            //Trace.TraceInformation(c.ToString());
        }
    }
}
