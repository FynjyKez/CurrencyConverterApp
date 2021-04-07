using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.DictionaryOfCurrencies.Currency;
using Newtonsoft.Json;

namespace Currency_Converter.Core.DictionaryOfCurrencies
{
    
    class DictionaryOfNationalCurrencies : IDictionaryOfCurrencies
    {
        [JsonProperty("Date")]
        private string Date;
        [JsonProperty("Valute")] 
        public virtual Dictionary<string, NationalCurrency> DictionaryCurrencies { get; set; }

        delegate string ErrorMessege(string Messege);
        event ErrorMessege ReturnErrorMessage;

        public virtual Dictionary<string, NationalCurrency> GetDictionary()
        {
            return DictionaryCurrencies;
        }
        public virtual Dictionary<string, NationalCurrency> SetDictionary(DictionaryOfNationalCurrencies Dictionary)
        {
            Date = Dictionary.Date;
            DictionaryCurrencies = Dictionary.DictionaryCurrencies;
            return DictionaryCurrencies;
        }

        public NationalCurrency AddCurrency(NationalCurrency NewCurrency)
        {
            DictionaryCurrencies.Add(NewCurrency.CharCode, NewCurrency);
            return NewCurrency;
        }

        public void AddToList(NationalCurrency AddCurrency)
        {
            try
            {
                DictionaryCurrencies.Add(AddCurrency.CharCode, AddCurrency);
            }
            catch (Exception ex)
            {
                ReturnErrorMessage?.Invoke(ex.Message);
            }
        }

        public NationalCurrency FindCurrencyByKey(string Key)
        {
            return DictionaryCurrencies[Key];
        }

        public void ParseFromJsonString(string Json)
        {
            this.DictionaryCurrencies = JsonParser.ParseString(Json).DictionaryCurrencies;
        }

    }
}
