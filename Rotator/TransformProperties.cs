using System.Windows;
using System.Windows.Media;

namespace Rotator
{
    internal class TransformProperties
    {
        public const string MainGroup = nameof(MainGroup);
        public const string RotateGroup = nameof(RotateGroup);
        public const string TranslateGroup = nameof(TranslateGroup);

        public const string MainRotateTransform = nameof(MainRotateTransform);


        public static readonly DependencyProperty GroupNameProperty = DependencyProperty.RegisterAttached(
            "GroupName", typeof(string), typeof(Transform), new PropertyMetadata(default(string)));

        public static void SetGroupName(Transform element, string value)
        {
            element.SetValue(GroupNameProperty, value);
        }
        public static string GetGroupName(Transform element)
        {
            return (string)element.GetValue(GroupNameProperty);
        }
    }
}