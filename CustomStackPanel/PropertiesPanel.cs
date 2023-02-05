using System;
using System.Linq;

using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomStackPanel
{
    public class PropertiesPanel : StackPanel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            if (Children.Any(c => !(c is PropertiesSection)))
            {
                throw new ApplicationException("All children must be Sections");
            }

            foreach (var child in Children.OfType<PropertiesSection>())
            {
                child.IsLast = false;
            }

            var last = Children.LastOrDefault(element => element.Visibility == Visibility.Visible);
            if (last is PropertiesSection lastSection)
            {
                lastSection.IsLast = true;
            }
            return base.MeasureOverride(availableSize);
        }
    }
}
