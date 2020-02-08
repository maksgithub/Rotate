using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Rotator
{
    public static class TranslateExtensions
    {
        public static List<T> GetTransforms<T>(this UIElement source) where T : Transform
        {
            var renderTransform = source?.RenderTransform;
            if (renderTransform != null)
            {
                if (renderTransform is T t)
                    return new List<T>() { t };

                if (renderTransform is TransformGroup group)
                {
                    return group.Children.Select(GetTransforms<T>).Where(x=> x!=null).ToList();
                }
            }

            return null;
        }

        public static T GetTransforms<T>(this Transform source) where T : Transform
        {
            if (source is T t)
                return t;

            if (source is TransformGroup group)
            {
                foreach (var child in group.Children)
                {
                    return GetTransforms<T>(child);
                }
            }

            return null;
        }
    }
}