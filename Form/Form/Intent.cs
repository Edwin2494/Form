using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Form
{

    public class Intent
    {

        private Page _startPage { get; set; }
        private Page _endPage { get; set; }
        public Dictionary<string, object> DataObject { get; set; }
        public Dictionary<string, string> DataString { get; set; }

        public Intent( Page StartPage, Page EndPage)
        {
            _startPage = StartPage;
            _endPage = EndPage;
            DataObject = new Dictionary<string, object>();
            DataString = new Dictionary<string, string>();
        }

        public void PutObject(String key, Object obj)
        {
            if (DataObject.ContainsKey(key))
            {
                throw new ArgumentException("La llave ya existe");
            }
            DataObject.Add(key, obj);
        }

        public void PutString(string key, string value)
        {
            if (DataString.ContainsKey(key))
            {
                throw new ArgumentException("La llave ya existe");
            }
            DataString.Add(key, value);
        }

        public string GetString(string key)
        {
            if (DataString.ContainsKey(key))
            {
                return DataString[key];
            }
            throw new ArgumentException("La llave no existe");
        }

        public T GetObject<T>(string key)
        {
            if (DataObject.ContainsKey(key))
            {
                return (T)DataObject[key];
            }
            throw new ArgumentException("La llave no existe"); 
        }

        public void StartIntent()
        {
            Navigation.intent = this;
            _startPage.Navigation.PushModalAsync(_endPage, true);
        }

        public class Navigation
        {
            public static Intent intent { get; set; }
        }
    }
}
