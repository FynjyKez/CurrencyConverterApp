using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Currency_Converter.Core.DataLoader
{
    class DataLoader
    {
        const string DEFAULT_DATA_ADDRESS = @"https://www.cbr-xml-daily.ru/daily_json.js";

        delegate string ErrorMessege(string Messege);
        event ErrorMessege ConectionErrorLoad;

        public string LoadData()
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    return wc.DownloadString(DEFAULT_DATA_ADDRESS);
                }
                catch(Exception ex)
                {
                    ConectionErrorLoad?.Invoke(ex.Message);
                }
                return null;
            }
            
        }
    }
}
