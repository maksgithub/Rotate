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
    }
}
