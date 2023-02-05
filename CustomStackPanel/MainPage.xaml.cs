using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomStackPanel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            var timer1 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            var timer2 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };

            timer1.Tick += (_, _) => IsVisibleTest ^= true;
            timer2.Tick += (_, _) => IsLoadedTest ^= true;

            timer1.Start();
            timer2.Start();
        }

        public static readonly DependencyProperty IsVisibleTestProperty = DependencyProperty.Register(
            nameof(IsVisibleTest), typeof(bool), typeof(MainPage), new PropertyMetadata(default(bool)));

        public bool IsVisibleTest
        {
            get => (bool)GetValue(IsVisibleTestProperty);
            set => SetValue(IsVisibleTestProperty, value);
        }

        public static readonly DependencyProperty IsLoadedTestProperty = DependencyProperty.Register(
            nameof(IsLoadedTest), typeof(bool), typeof(MainPage), new PropertyMetadata(true));

        public bool IsLoadedTest
        {
            get => (bool)GetValue(IsLoadedTestProperty);
            set => SetValue(IsLoadedTestProperty, value);
        }
    }
}
