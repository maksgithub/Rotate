﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Rotator
{
    public class RotateThumb : Thumb
    {
        private Point _centerPoint;
        private Vector _startVector;
        private double _initialAngle;
        private Canvas _designerCanvas;
        private ContentControl _designerItem;
        private RotateTransform _rotateTransform;

        public RotateThumb()
        {
            DragDelta += RotateThumb_DragDelta;
            DragStarted += RotateThumb_DragStarted;
        }

        private void RotateThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            _designerItem = DataContext as ContentControl;

            if (_designerItem != null)
            {
                _designerCanvas = VisualTreeHelper.GetParent(_designerItem) as Canvas;

                if (_designerCanvas != null)
                {
                    _centerPoint = _designerItem.TranslatePoint(
                        new Point(_designerItem.Width * _designerItem.RenderTransformOrigin.X,
                                  _designerItem.Height * _designerItem.RenderTransformOrigin.Y),
                                  _designerCanvas);

                    var startPoint = Mouse.GetPosition(_designerCanvas);
                    _startVector = Point.Subtract(startPoint, _centerPoint);

                    var rotateTransforms = ((TransformGroup)_designerItem.RenderTransform)
                        .Children.OfType<RotateTransform>().ToArray();

                    var angle = rotateTransforms.Sum(x => x.Angle);
                    _rotateTransform = rotateTransforms.First();
                    _initialAngle = _rotateTransform.Angle;
                }
            }
        }

        private void RotateThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (_designerItem != null && _designerCanvas != null)
            {
                var currentPoint = Mouse.GetPosition(_designerCanvas);
                var deltaVector = Point.Subtract(currentPoint, _centerPoint);

                var angle = Vector.AngleBetween(_startVector, deltaVector);

                _rotateTransform.Angle = _initialAngle + Math.Round(angle, 0);
                _designerItem.InvalidateMeasure();
            }
        }
    }
}