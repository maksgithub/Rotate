using System.Windows;

namespace Rotator
{
    public static class AlignmentExtensions
    {
        public static HorizontalAlignment Invert(this HorizontalAlignment alignment)
        {
            switch (alignment)
            {
                case HorizontalAlignment.Left:
                    return HorizontalAlignment.Right;
                case HorizontalAlignment.Right:
                    return HorizontalAlignment.Left;
                default:
                    return alignment;
            }
        }

        public static VerticalAlignment Invert(this VerticalAlignment alignment)
        {
            switch (alignment)
            {
                case VerticalAlignment.Top:
                    return VerticalAlignment.Bottom;
                case VerticalAlignment.Bottom:
                    return VerticalAlignment.Top;
                default:
                    return alignment;
            }
        }
    }
}