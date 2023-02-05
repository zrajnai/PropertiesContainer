using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomItemsControl;

public class PropertiesSectionContainer : ContentControl
{
    public static readonly DependencyProperty SectionNameProperty = DependencyProperty.Register(
        nameof(SectionName), typeof(string), typeof(PropertiesSectionContainer), new PropertyMetadata(default(string)));

    public string SectionName
    {
        get => (string)GetValue(SectionNameProperty);
        set => SetValue(SectionNameProperty, value);
    }
    public PropertiesSectionContainer()
    {
        DefaultStyleKey = typeof(PropertiesSectionContainer);
    }
}