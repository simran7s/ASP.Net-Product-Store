using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public class Product
    {
        //Use "prop" + tab for a shortcut to make constructors
        public string Id { get; set; }
        public string Maker { get; set; }
       
        //mapping img from json into Image
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int[] Ratings { get; set; }

        //C# objects (classes) should always have a ToString. Here we are overriding the default ToString() object
        public override string ToString()
        {
            //Turning it back into Json (serial = do one after another)
            return JsonSerializer.Serialize<Product>(this);
        }
    }
}
