using System;
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

                if (_designerItem.RenderTransform is RotateTransform rotateTransform)
                {
                    _angle = rotateTransform.Angle * Math.PI / 180.0;
                }
                else
                {
                    _angle = 0;
                }
            }
        }

        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (_designerItem != null)
            {
                double deltaVertical, deltaHorizontal;

                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Bottom:
                        deltaVertical = Math.Min(-e.VerticalChange, _designerItem.ActualHeight - _designerItem.MinHeight);
                        Canvas.SetTop(_designerItem, Canvas.GetTop(_designerItem) + (_transformOrigin.Y * deltaVertical * (1 - Math.Cos(-_angle))));
                        Canvas.SetLeft(_designerItem, Canvas.GetLeft(_designerItem) - deltaVertical * _transformOrigin.Y * Math.Sin(-_angle));
                        _designerItem.Height -= deltaVertical;
                        break;
                    case VerticalAlignment.Top:
                        deltaVertical = Math.Min(e.VerticalChange, _designerItem.ActualHeight - _designerItem.MinHeight);
                        Canvas.SetTop(_designerItem, Canvas.GetTop(_designerItem) + deltaVertical * Math.Cos(-_angle) + (_transformOrigin.Y * deltaVertical * (1 - Math.Cos(-_angle))));
                        Canvas.SetLeft(_designerItem, Canvas.GetLeft(_designerItem) + deltaVertical * Math.Sin(-_angle) - (_transformOrigin.Y * deltaVertical * Math.Sin(-_angle)));
                        _designerItem.Height -= deltaVertical;
                        break;
                }

                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        deltaHorizontal = Math.Min(e.HorizontalChange, _designerItem.ActualWidth - _designerItem.MinWidth);
                        Canvas.SetTop(_designerItem, Canvas.GetTop(_designerItem) + deltaHorizontal * Math.Sin(_angle) - _transformOrigin.X * deltaHorizontal * Math.Sin(_angle));
                        Canvas.SetLeft(_designerItem, Canvas.GetLeft(_designerItem) + deltaHorizontal * Math.Cos(_angle) + (_transformOrigin.X * deltaHorizontal * (1 - Math.Cos(_angle))));
                        _designerItem.Width -= deltaHorizontal;
                        break;
                    case HorizontalAlignment.Right:
                        deltaHorizontal = Math.Min(-e.HorizontalChange, _designerItem.ActualWidth - _designerItem.MinWidth);
                        Canvas.SetTop(_designerItem, Canvas.GetTop(_designerItem) - _transformOrigin.X * deltaHorizontal * Math.Sin(_angle));
                        Canvas.SetLeft(_designerItem, Canvas.GetLeft(_designerItem) + (deltaHorizontal * _transformOrigin.X * (1 - Math.Cos(_angle))));
                        _designerItem.Width -= deltaHorizontal;
                        break;
                }
            }

            e.Handled = true;
        }
    }
}