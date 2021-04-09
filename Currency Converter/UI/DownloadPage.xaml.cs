using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Currency_Converter.UI
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class DownloadPage : Page
    {
        public DownloadPage()
        {
            this.InitializeComponent();
        }

        private void StartLoadData(object sender, RoutedEventArgs e)
        {
            splashProgressRing.IsActive = true;
            Task Tread = Task.Run(() =>
            {
                ///Ожидание чтобы показать что окно загрузки работает
                Task.Delay(20000);
                Core.CoreCurrencyConverter.GetCore().LoadDefoultData();
            });

            Tread.GetAwaiter().OnCompleted(() =>
            {
                splashProgressRing.IsActive = false;
                if (CoreDataIsLoaded())
                {
                    InCalculationPage();
                }
                else
                {
                    ReloadDataEnable();
                }
            });
            
        }

        private bool CoreDataIsLoaded()
        {
            return Core.CoreCurrencyConverter.GetCore().SuccsessLoad;
        }

        private void InCalculationPage()
        {
            this.Frame?.Navigate(typeof(UI.CalculationPage));
        }

        private void ReloadDataEnable()
        {
            ReloadTextBlock.Visibility = Visibility.Visible;
            ReloadButton.IsEnabled = true;
            ReloadButton.Visibility = Visibility.Visible;
        }

        private void ReloadDataDisable()
        {
            ReloadTextBlock.Visibility = Visibility.Collapsed;
            ReloadButton.IsEnabled = false;
            ReloadButton.Visibility = Visibility.Collapsed;
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadDataDisable();
            StartLoadData(sender, e);    
        }
    }
}
