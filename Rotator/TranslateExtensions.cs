using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Rotator
{
    public static class TranslateExtensions
    {
        public static T GetTransform<T>(this UIElement uiElement, string name) where T : Transform
        {
            return uiElement?.RenderTransform.GetTransform<T>(name);
        }
        public static T GetTransform<T>(this Transform transform, string name) where T : Transform
        {
            if (transform != null)
            {
                if (transform is T result && result.GetName() == name)
                    return result;

                if (transform is TransformGroup group)
                {
                    foreach (var child in group.Children)
                    {
                        var r = child.GetTransform<T>(name);
                        if (r != null)
                            return r;
                    }
                }
            }

            return null;
        }

        public static string GetName(this Transform transform)
        {
            return transform?.GetValue(TransformProperties.GroupNameProperty) as string;
        }
    }
}