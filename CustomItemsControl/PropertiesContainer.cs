using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomItemsControl
{
    public class PropertiesContainer : ItemsControl
    {
        public PropertiesContainer()
        {
            DefaultStyleKey = typeof(PropertiesContainer);

            Items!.VectorChanged += ItemsOnVectorChanged;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new PropertiesSectionContainer();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is PropertiesSectionContainer;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            if (element is not PropertiesSectionContainer propertiesSectionContainer)
            {
                return;
            }

            propertiesSectionContainer.Content = item;
            propertiesSectionContainer.ApplyTemplate();

            (item as FrameworkElement)?.RegisterPropertyChangedCallback(VisibilityProperty, (_, _) => UpdateVisualStates());

            UpdateVisualStates();
        }

        private void UpdateVisualStates()
        {
            if (Items!.Count == 0)
            {
                return;
            }

            PropertiesSectionContainer lastVisibleContainer = null;
            for (var index = 0; index <= Items.Count - 1; index++)
            {
                if (ContainerFromIndex(index) is not PropertiesSectionContainer container)
                    continue;

                var isContentVisible = (container.Content as UIElement)?.Visibility == Visibility.Visible;
                var shouldHideSeparator = index == Items.Count - 1 || !isContentVisible;

                if (isContentVisible)
                {
                    lastVisibleContainer = container;
                }
                VisualStateManager.GoToState(container, shouldHideSeparator ? "LastItem" : "Normal", false);
            }

            if (lastVisibleContainer is not null)
            {
                VisualStateManager.GoToState(lastVisibleContainer, "LastItem", false);
            }
        }

        private void ItemsOnVectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs @event)
        {
            UpdateVisualStates();
        }
    }
}
