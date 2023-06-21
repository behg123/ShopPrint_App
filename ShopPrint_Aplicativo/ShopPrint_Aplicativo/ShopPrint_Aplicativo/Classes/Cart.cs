using System;
using System.Collections.Generic;
using System.Text;

namespace ShopPrint_Aplicativo.Classes
{
    public class Cart
    {
        public string id { get; set; }
        public string userId { get; set; }
        public List<Products> Items { get; set; }
        public int totalPrice { get; set; }
    }
}
