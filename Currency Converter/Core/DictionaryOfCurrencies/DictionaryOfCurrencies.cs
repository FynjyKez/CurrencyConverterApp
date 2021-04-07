using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.DictionaryOfCurrencies.Currency;
using Newtonsoft.Json;

namespace Currency_Converter.Core.DictionaryOfCurrencies
{
    class DictionaryOfCurrencies : IDictionaryOfCurrencies
    {
        [JsonProperty("Valute")]
        private Dictionary<string, ICurrency> ListCurrencies { get; set; }

        delegate string ErrorMessege(string Messege);
        event ErrorMessege ReturnErrorMassege;

        public Dictionary<string, ICurrency> GetList()
        {
            return ListCurrencies;
        }
        public Dictionary<string, ICurrency> SetList(IDictionaryOfCurrencies Dictionary)
        {
            return ListCurrencies;
        }

        public ICurrency AddCurrency(string CharCode, int Nominal, string Name, int Value)
        {
            ICurrency NewCurrency = new NationalCurrency(CharCode, Nominal, Name, Value);
            ListCurrencies.Add(CharCode, NewCurrency);
            return NewCurrency;
        }

        public void AddToList(NationalCurrency AddCurrency)
        {
            try
            {
                ListCurrencies.Add(AddCurrency.CharCode, AddCurrency);
            }
            catch (Exception ex)
            {
                ReturnErrorMassege?.Invoke(ex.Message);
            }
        }

        public ICurrency FindCurrencyByKey(string Key)
        {
            return ListCurrencies[Key];
        }

        public void ParseFromJsonString(string Json)
        {
            this.ListCurrencies = JsonParser.ParseString(Json, this).GetList();
        }

    }
}
