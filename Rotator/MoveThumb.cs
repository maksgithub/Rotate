using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Rotator
{
    public class MoveThumb : Thumb
    {
        public event Action<Point> PositionChanged;
        public MoveThumb()
        {
            DragDelta += MoveThumb_DragDelta;
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (DataContext is ContentControl designerItem)
            {
                var dragDelta = new Point(e.HorizontalChange, e.VerticalChange);

                if (designerItem.RenderTransform is RotateTransform rotateTransform)
                {
                    dragDelta = rotateTransform.Transform(dragDelta);
                }

                var x = Canvas.GetLeft(designerItem) + dragDelta.X;
                var y = Canvas.GetTop(designerItem) + dragDelta.Y;
                Canvas.SetLeft(designerItem, x);
                Canvas.SetTop(designerItem, y);

                PositionChanged?.Invoke(new Point(x, y));
            }
        }
    }
}