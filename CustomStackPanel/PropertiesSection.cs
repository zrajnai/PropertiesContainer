using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomStackPanel
{
    public class PropertiesSection : ContentControl
    {
        public PropertiesSection()
        {
            DefaultStyleKey = typeof(PropertiesSection);
        }

        public static readonly DependencyProperty SectionNameProperty = DependencyProperty.Register(
            nameof(SectionName), typeof(string), typeof(PropertiesSection), new PropertyMetadata(default(string)));

        public string SectionName
        {
            get => (string)GetValue(SectionNameProperty);
            set => SetValue(SectionNameProperty, value);
        }

        public static readonly DependencyProperty IsLastProperty = DependencyProperty.Register(
            nameof(IsLast), typeof(bool), typeof(PropertiesSection), new PropertyMetadata(default(bool)));

        public bool IsLast
        {
            get => (bool)GetValue(IsLastProperty);
            internal set => SetValue(IsLastProperty, value);
        }

        public bool HasName => !string.IsNullOrWhiteSpace(SectionName);
    }
}