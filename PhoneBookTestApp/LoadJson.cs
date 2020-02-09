
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace PhoneBookTestApp
{
    class LoadJson
    {
        public static List<Person> LoadData()
        {
            using (StreamReader r = new StreamReader("../../Data.Json"))
            {
                string json = r.ReadToEnd();
                List<Person> items = JsonConvert.DeserializeObject<List<Person>>(json);
                return items;
            }
            
        }
    }
}
