using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Windows.Data.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;  
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace LAB2
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const string SubscriptionKey = "fcadbdcb506f44399ee6fccd1bfb9b19";
        const string UriBase = "https://sblabs.cognitiveservices.azure.com/";
        // Подключение к когнитивному сервису
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter &&
                searchbox.Text.Trim().Length > 0)
            {
                string imageUrl = FindUrlOfImage(searchbox.Text);
                imagebing.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
            }
        }
        struct SearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> relevantHeaders;
        }
        private string searchbox(string targetString)
        {
            SearchResult result = PerformBingImageSearch(targetString);
        }

    }
}
