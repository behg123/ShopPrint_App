using ShopPrint_Aplicativo.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShopPrint_Aplicativo.Listas
{


    public class CartList
    {
        public static ObservableCollection<Cart> CartItemList { get; set; } = new ObservableCollection<Cart>();

        public CartList() 
        {
            CartItemList = new ObservableCollection<Cart>();
        }


}
}
