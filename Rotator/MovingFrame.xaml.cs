using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Rotator
{
    /// <summary>
    /// Interaction logic for MovingFrame.xaml
    /// </summary>
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
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public static readonly DependencyProperty FrameWidthProperty = DependencyProperty.Register(
            nameof(FrameWidth), typeof(double), typeof(MovingFrame), new PropertyMetadata(default(double)));

        public double FrameWidth
        {
            get { return (double)GetValue(FrameWidthProperty); }
            set { SetValue(FrameWidthProperty, value); }
        }

        public static readonly DependencyProperty FrameHeightProperty = DependencyProperty.Register(
            nameof(FrameHeight), typeof(double), typeof(MovingFrame), new PropertyMetadata(default(double)));

        public double FrameHeight
        {
            get { return (double)GetValue(FrameHeightProperty); }
            set { SetValue(FrameHeightProperty, value); }
        }

        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
            nameof(Angle), typeof(double), typeof(MovingFrame), new PropertyMetadata(default(double)));

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public static readonly DependencyProperty XProperty = DependencyProperty.Register(
            nameof(X), typeof(double), typeof(MovingFrame), new PropertyMetadata(default(double)));

        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        public static readonly DependencyProperty YProperty = DependencyProperty.Register(
            nameof(Y), typeof(double), typeof(MovingFrame), new PropertyMetadata(default(double)));

        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        public static readonly RoutedEvent UserManipulationCompletedEvent = EventManager.RegisterRoutedEvent(
            nameof(UserManipulationCompleted), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MovingFrame));

        public event RoutedEventHandler UserManipulationCompleted
        {
            add { AddHandler(UserManipulationCompletedEvent, value); }
            remove { RemoveHandler(UserManipulationCompletedEvent, value); }
        }

        private void Thumb_OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            var newEventArgs = new RoutedEventArgs(UserManipulationCompletedEvent, sender);
            RaiseEvent(newEventArgs);
        }
    }
}
