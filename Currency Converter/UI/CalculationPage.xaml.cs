using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Currency_Converter.UI.cs;

namespace Currency_Converter.UI
{
    /// <summary>
    /// Страница конвертации валют
    /// </summary>
    public sealed partial class CalculationPage : Page
    {
        public CalculationPage()
        {
            this.InitializeComponent();
            LoadWalletsData();
        }

        /// <summary>
        /// Загрузка данных из кошельков
        /// </summary>
        public void LoadWalletsData()
        {
            FirstWalletValueTextBlock.Text = Core.CoreCurrencyConverter.GetCore().GetFirstWalletValue().ToString();
            FirstWalletCharCodeTextBlock.Text = Core.CoreCurrencyConverter.GetCore().GetFirstWalletCurrencyCharCode();
            SecondWalletValueTextBlock.Text = Core.CoreCurrencyConverter.GetCore().GetSecondWalletValue().ToString();
            SecondWalletCharCodeTextBlock.Text = Core.CoreCurrencyConverter.GetCore().GetSecondWalletCurrencyCharCode();
        }

        /// <summary>
        /// Изменить значение первого кошелька
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstWalletValueTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            OpenChangeValueGrid((TextBlock)sender);
        }
        /// <summary>
        /// Изменить значение второго кошелька
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondWalletValueTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            OpenChangeValueGrid((TextBlock)sender);
        }
        /// <summary>
        /// Изменить валюту первого кошелька
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstWalletChangeTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Core.CoreCurrencyConverter.GetCore().ChangeFirstWallet = true;
            this.Frame.Navigate(typeof(UI.ChangeCurrencyPage), Core.CoreCurrencyConverter.GetCore().GetFirstWalletCurrencyCharCode());
        }
        /// <summary>
        /// Изменить валюту второго кошелька
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondWalletChangeTextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Core.CoreCurrencyConverter.GetCore().ChangeSecondWallet = true;
            this.Frame.Navigate(typeof(UI.ChangeCurrencyPage), Core.CoreCurrencyConverter.GetCore().GetSecondWalletCurrencyCharCode());
        }
        /// <summary>
        /// Подтвердить изменения значения для кошелька
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeValueOK_Tapped(object sender, TappedRoutedEventArgs e)
        {  
            if(FirstWalletValueTextBlock.Tag?.ToString() == "Tap")
            {
                Core.CoreCurrencyConverter.GetCore().SetFirstWalletValue(ChangeValueTextBox.Text);
            }
            else if(SecondWalletValueTextBlock.Tag?.ToString() == "Tap")
            {
                Core.CoreCurrencyConverter.GetCore().SetSecondWalletValue(ChangeValueTextBox.Text);
            }
            FirstWalletValueTextBlock.Text = Core.CoreCurrencyConverter.GetCore().GetFirstWalletValue().ToString();
            SecondWalletValueTextBlock.Text = Core.CoreCurrencyConverter.GetCore().GetSecondWalletValue().ToString();
            CloseChangeValueGrid();
        }
        /// <summary>
        /// Отменить изменения значения кошелька
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeValueCancel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CloseChangeValueGrid();
        }

        /// <summary>
        /// Открыть окно изменения значения кошелька и поставить метку
        /// </summary>
        /// <param name="Tapped">На объект <c>TextBlock</c> в поле <c>Tag</c> ставится метка <c>(string)</c>"Tap"</param>
        private void OpenChangeValueGrid(TextBlock Tapped)
        {
            ChangeValueTextBox.Text = Tapped.Text;
            ChangeGrid.Visibility = Visibility.Visible;
            ChangeGrid.IsTapEnabled = false;
            Tapped.Tag = "Tap";
        }
        /// <summary>
        /// Закрыть окно изменения значения кошелька и обнуление меток
        /// </summary>
        private void CloseChangeValueGrid()
        {
            ChangeGrid.Visibility = Visibility.Collapsed;
            ChangeGrid.IsTapEnabled = false;
            FirstWalletValueTextBlock.Tag = null;
            SecondWalletValueTextBlock.Tag = null;
        }

        /// <summary>
        /// Валидатор для поля ответственного за изменения значения кошелька
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ChangeValueTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = ValidatorValueWallet.HasErrors(args.NewText);
        }
    }
}
