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
using Currency_Converter.Core;

namespace Currency_Converter.UI
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ChangeCurrencyPage : Page
    {
        public ChangeCurrencyPage()
        {
            this.InitializeComponent();
            CreateCurrenciesTable();
        }

        private void CreateCurrenciesTable()
        {
            string DisableCurrencyCharCode;
            string SelectedCurrencyCharCode;
            int SecectedCurrency;
            if (Core.CoreCurrencyConverter.GetCore().ChangeFirstWallet)
            {
                SelectedCurrencyCharCode = Core.CoreCurrencyConverter.GetCore().GetSecondWalletCurrencyCharCode();
                DisableCurrencyCharCode = Core.CoreCurrencyConverter.GetCore().GetFirstWalletCurrencyCharCode();
            }
            else
            {
                SelectedCurrencyCharCode = Core.CoreCurrencyConverter.GetCore().GetFirstWalletCurrencyCharCode();
                DisableCurrencyCharCode = Core.CoreCurrencyConverter.GetCore().GetSecondWalletCurrencyCharCode();
                
            }

            foreach (var OneCurrencies in Core.CoreCurrencyConverter.GetCore().GetDictionnaryOfCurrencies())
            {
                if (OneCurrencies.Value.CharCode == DisableCurrencyCharCode) {
                    continue;
                }
                SecectedCurrency =  OneCurrencies.Value.CharCode == SelectedCurrencyCharCode ? (int)Visibility.Visible : (int)Visibility.Collapsed;
                ListCurrenies.Items.Add(new Currency_Converter.Core.DictionaryOfCurrencies.Currency.NationalCurrency(OneCurrencies.Value.CharCode, 0, OneCurrencies.Value.Name, SecectedCurrency)); 
            } 
        }

        private void ListCurrenies_ItemClick(object sender, ItemClickEventArgs e)
        {
            Core.DictionaryOfCurrencies.Currency.NationalCurrency CharCode = (Core.DictionaryOfCurrencies.Currency.NationalCurrency)e.ClickedItem;
            ChangeWallet(CharCode.CharCode);
            this.Frame.Navigate(typeof(UI.CalculationPage));
        }

        private void ChangeWallet(string CharCode)
        {
            if (Core.CoreCurrencyConverter.GetCore().ChangeFirstWallet)
            {
                Core.CoreCurrencyConverter.GetCore().ChangeFirstWallet = false;
                Core.CoreCurrencyConverter.GetCore().SetFirstWalletCurrency(CharCode);
            }
            else if (Core.CoreCurrencyConverter.GetCore().ChangeSecondWallet)
            {
                Core.CoreCurrencyConverter.GetCore().ChangeSecondWallet = false;
                Core.CoreCurrencyConverter.GetCore().SetSecondWalletCurrency(CharCode);
            }
        }

    }
}
