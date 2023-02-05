using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomItemsControl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            var timer1 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            var timer2 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.5) };
            var timer3 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.5) };

            timer1.Tick += (_, _) => Test1 ^= true;
            timer2.Tick += (_, _) => Test2 ^= true;
            timer3.Tick += (_, _) => Test3 ^= true;

            timer1.Start();
            timer3.Start();
        }

        public static readonly DependencyProperty Test1Property = DependencyProperty.Register(
            nameof(Test1), typeof(bool), typeof(MainPage), new PropertyMetadata(default(bool)));

        public bool Test1
        {
            get => (bool)GetValue(Test1Property);
            set => SetValue(Test1Property, value);
        }

        public static readonly DependencyProperty Test2Property = DependencyProperty.Register(
            nameof(Test2), typeof(bool), typeof(MainPage), new PropertyMetadata(true));

        public bool Test2
        {
            get => (bool)GetValue(Test2Property);
            set => SetValue(Test2Property, value);
        }

        public static readonly DependencyProperty Test3Property = DependencyProperty.Register(
            nameof(Test3), typeof(bool), typeof(MainPage), new PropertyMetadata(default(bool)));

        public bool Test3
        {
            get => (bool)GetValue(Test3Property);
            set => SetValue(Test3Property, value);
        }
    }
}