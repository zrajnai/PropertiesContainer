using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomItemsControl;

public class PropertiesSection : ContentControl
{
    public static readonly DependencyProperty SectionNameProperty = DependencyProperty.Register(
        nameof(SectionName), typeof(string), typeof(PropertiesSection), new PropertyMetadata(default(string), PropertyChangedCallback));

    public string SectionName
    {
        get => (string)GetValue(SectionNameProperty);
        set => SetValue(SectionNameProperty, value);
    }

    public PropertiesSection()
    {
        DefaultStyleKey = typeof(PropertiesSection);
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        UpdateVisualState();
    }

    private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var section = (PropertiesSection)d;

        section.UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        VisualStateManager.GoToState(this, string.IsNullOrWhiteSpace(SectionName) ? "NoTitle" : "Normal", false);
    }
}