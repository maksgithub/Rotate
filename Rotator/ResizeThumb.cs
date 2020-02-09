using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Rotator
{
    public class ResizeThumb : Thumb
    {
        private double _angle;
        private Point _transformOrigin;
        private ContentControl _designerItem;

        public ResizeThumb()
        {
            DragStarted += ResizeThumb_DragStarted;
            DragDelta += ResizeThumb_DragDelta;
        }

        private void ResizeThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            _designerItem = DataContext as ContentControl;

            if (_designerItem != null)
            {
                _transformOrigin = _designerItem.RenderTransformOrigin;
               // var angle = _designerItem.GetTransforms<RotateTransform>().Sum(x => x.Angle);
               // _angle = angle * Math.PI / 180.0;
            }
        }

        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (_designerItem != null)
            {
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Bottom:
                        ResizeBottom(-e.VerticalChange);
                        break;
                    case VerticalAlignment.Top:
                        ResizeTop(e.VerticalChange);
                        break;
                }

                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        ResizeLeft(e.HorizontalChange);
                        break;
                    case HorizontalAlignment.Right:
                        ResizeRight(-e.HorizontalChange);
                        break;
                }
            }

            e.Handled = true;
        }

        private void ResizeRight(double horizontalChange)
        {
            var deltaHorizontal = Math.Min(horizontalChange, _designerItem.ActualWidth - _designerItem.MinWidth);
            var top = Canvas.GetTop(_designerItem) - _transformOrigin.X * deltaHorizontal * Math.Sin(_angle);
            var left = Canvas.GetLeft(_designerItem) + (deltaHorizontal * _transformOrigin.X * (1 - Math.Cos(_angle)));
            Canvas.SetTop(_designerItem, top);
            Canvas.SetLeft(_designerItem, left);
            _designerItem.Width -= deltaHorizontal;
        }

        private void ResizeLeft(double horizontalChange)
        {
            var deltaHorizontal = Math.Min(horizontalChange, _designerItem.ActualWidth - _designerItem.MinWidth);
            var top = Canvas.GetTop(_designerItem) + deltaHorizontal * Math.Sin(_angle) - _transformOrigin.X * deltaHorizontal * Math.Sin(_angle);
            var left = Canvas.GetLeft(_designerItem) + deltaHorizontal * Math.Cos(_angle) + (_transformOrigin.X * deltaHorizontal * (1 - Math.Cos(_angle)));
            Canvas.SetTop(_designerItem, top);
            Canvas.SetLeft(_designerItem, left);
            _designerItem.Width -= deltaHorizontal;
        }

        private void ResizeTop(double verticalChange)
        {
            var deltaVertical = Math.Min(verticalChange, _designerItem.ActualHeight - _designerItem.MinHeight);
            var top = Canvas.GetTop(_designerItem) + deltaVertical * Math.Cos(-_angle) + (_transformOrigin.Y * deltaVertical * (1 - Math.Cos(-_angle)));
            var left = Canvas.GetLeft(_designerItem) + deltaVertical * Math.Sin(-_angle) - (_transformOrigin.Y * deltaVertical * Math.Sin(-_angle));
            Canvas.SetTop(_designerItem, top);
            Canvas.SetLeft(_designerItem, left);
            _designerItem.Height -= deltaVertical;
        }

        private void ResizeBottom(double verticalChange)
        {
            var deltaVertical = Math.Min(verticalChange, _designerItem.ActualHeight - _designerItem.MinHeight);
            var top = Canvas.GetTop(_designerItem) + (_transformOrigin.Y * deltaVertical * (1 - Math.Cos(-_angle)));
            var left = Canvas.GetLeft(_designerItem) - deltaVertical * _transformOrigin.Y * Math.Sin(-_angle);
            Canvas.SetTop(_designerItem, top);
            Canvas.SetLeft(_designerItem, left);
            _designerItem.Height -= deltaVertical;
        }
    }
}