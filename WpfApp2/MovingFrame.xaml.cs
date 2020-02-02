using System.Windows;
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
            "Top", typeof(double), typeof(MovingFrame), new PropertyMetadata(default(double)));

        public double Top
        {
            get { return (double) GetValue(TopProperty); }
            set { SetValue(TopProperty, value); }
        }
    }
}
