using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
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
                _angle = GetCurrentAngle();
            }
        }

        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            HorizontalAlignment ha;
            if (_designerItem != null)
            {
                var scaleTransform = _designerItem.GetTransform<ScaleTransform>(null);
                var scaleX = scaleTransform.ScaleX;
                var scaleY = scaleTransform.ScaleY;

                var p = Mouse.GetPosition(_designerItem);
                var x = p.X * scaleX;
                var y = p.Y * scaleY;

                //Trace.TraceInformation($"{x}:{y}");
                if (x < -5 && scaleTransform.ScaleX > 0)
                {
                    //scaleTransform.ScaleX *= -1;
                    // Trace.TraceInformation($"Enter");
                }


                ha = scaleTransform.ScaleX == -1 ? Invert(HorizontalAlignment) : HorizontalAlignment;
                var va = scaleTransform.ScaleY == -1 ? Invert(VerticalAlignment) : VerticalAlignment;
                Resize(e, va, ha);
            }

            e.Handled = true;
        }

        private static HorizontalAlignment Invert(HorizontalAlignment alignment)
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

        private static VerticalAlignment Invert(VerticalAlignment alignment)
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

        private void Resize(DragDeltaEventArgs e,
            VerticalAlignment verticalAlignment,
            HorizontalAlignment horizontalAlignment)
        {
            var scaleTransform = _designerItem.GetTransform<ScaleTransform>(null);
            var scaleX = scaleTransform.ScaleX;
            var scaleY = scaleTransform.ScaleY;

            switch (verticalAlignment)
            {
                case VerticalAlignment.Bottom:
                    ResizeBottom(-e.VerticalChange * scaleY);
                    break;
                case VerticalAlignment.Top:
                    ResizeTop(e.VerticalChange * scaleY);
                    break;
            }

            switch (horizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    ResizeLeft(e.HorizontalChange * scaleX);
                    break;
                case HorizontalAlignment.Right:
                    ResizeRight(-e.HorizontalChange * scaleX);
                    break;
            }
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

        private double GetCurrentAngle()
        {
            var angle = _designerItem
                .GetTransform<TransformGroup>(TransformProperties.RotateGroup)
                .GetChildren<RotateTransform>()
                .Sum(x => x.Angle);

            return angle * Math.PI / 180.0;
        }
    }
}