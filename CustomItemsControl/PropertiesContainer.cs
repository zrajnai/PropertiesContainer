using System;
using System.Linq;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomItemsControl
{
    public class PropertiesContainer : ItemsControl
    {
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
            if (element is not PropertiesSectionContainer propertiesSectionContainer ||
                item is not PropertiesSection propertiesSection)
            {
                return;
            }

            propertiesSectionContainer.Content = propertiesSection.Content;
            propertiesSectionContainer.SectionName = propertiesSection.SectionName;
            propertiesSectionContainer.ApplyTemplate();

            UpdateVisualStates();
        }

        private void UpdateVisualStates()
        {
            foreach (var item in Items!.OfType<PropertiesSection>())
            {
                var container = (Control)ItemContainerGenerator.ContainerFromItem(item);
                if (container is null)
                    continue;
                VisualStateManager.GoToState(container, "Normal", false);

                if (string.IsNullOrWhiteSpace(item.SectionName))
                {
                    VisualStateManager.GoToState(container, "NoTitle", false);
                }
            }

            var lastItem = Items.OfType<PropertiesSection>().LastOrDefault();
            if (lastItem is not null)
            {
                var container = (Control)ItemContainerGenerator.ContainerFromItem(lastItem);
                if (container is not null)
                {
                    VisualStateManager.GoToState(container, "LastItem", false);
                }
            }
        }

        public PropertiesContainer()
        {
            DefaultStyleKey = typeof(PropertiesContainer);

            Items!.VectorChanged += ItemsOnVectorChanged;
        }

        private void ItemsOnVectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs @event)
        {
            UpdateVisualStates();
            ;
            if (@event.CollectionChange != CollectionChange.ItemInserted)
            {
                return;
            }
            if (!(sender?[(int)@event.Index] is PropertiesSection))
            {
                throw new ApplicationException();
            }

        }
    }
}
