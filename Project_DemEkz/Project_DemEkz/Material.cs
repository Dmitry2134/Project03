using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DemEkz
{
    class Material
    {
        public int id { get; set; }
      
        public string name { get; set; }

        public string category { get; set; }

        public int price { get; set; }

        public Material() { }

        public Material(string name, string category, int price)
        {
            this.name = name;
            this.category = category;
            this.price = price;
        }
    }
}
