using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currency_Converter.Core.DictionaryOfCurrencies
{
    static class JsonParser
    {
        public static IDictionaryOfCurrencies ParseString(string String, IDictionaryOfCurrencies Dictionary)
        {
            try
            {
                Dictionary = JsonConvert.DeserializeObject<IDictionaryOfCurrencies>(String);
                return Dictionary;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
