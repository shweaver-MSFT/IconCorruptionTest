using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace IconCorruptionTest
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                var grid = Content as Grid;
                var imageHeight = 32;
                var imageWidth = 32;
                var columns = Math.Floor(ActualWidth / imageWidth);
                var rows = Math.Floor(ActualHeight / imageHeight);

                for (var r = 0; r < rows; r++)
                {
                    grid.RowDefinitions.Add(new RowDefinition());

                    for (var c = 0; c < columns; c++)
                    {
                        if (r == 0)
                        {
                            grid.ColumnDefinitions.Add(new ColumnDefinition());
                        }

                        var testImage = new Image()
                        {
                            Source = new BitmapImage(new Uri("ms-appx:///Assets/TestImage.png", UriKind.Absolute)),
                            Height = imageHeight,
                            Width = imageWidth
                        };
                        Grid.SetRow(testImage, r);
                        Grid.SetColumn(testImage, c);

                        grid.Children.Add(testImage);
                    }
                }
            });
        }
    }
}
