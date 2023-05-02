using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShopPrint_Aplicativo.Listas
{
    internal class ListPage
    {
        public ObservableCollection<Products> ItemList { get; set; }

        public ListPage()
        {
            ItemList = new ObservableCollection<Products>
            {
                new Products { Title = "Cubo Magico", Category = "Brinquedo", Url = "Print_1", Description = "Um cubo Mágico", Price=50},
                new Products { Title = "Quebra-cabeça de 1000 peças", Category = "Brinquedos", Url = "Print_2", Description = "Um quebra-cabeça de 1000 peças", Price=60 },
                new Products { Title = "Jogo de xadrez", Category = "Peças", Url = "Print_3", Description = "Um jogo de xadrez com peças de madeira", Price=40 },
                new Products { Title = "Luminária de mesa", Category = "Utilitários", Url = "Print_4", Description = "Uma luminária de mesa com design moderno", Price=20 },
                new Products { Title = "Bicicleta infantil", Category = "Brinquedos", Url = "Print_5", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer accumsan laoreet magna vitae\r\nelementum. Duis semper ex pellentesque nibh ullamcorper lacinia. Suspendisse sed diam magna.\r\nOrci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In id\r\nmaximus turpis, mattis commodo mauris. Sed bibendum accumsan leo. Nulla placerat.\r\n", Price=55 },
                new Products { Title = "Caneca de porcelana", Category = "Utilitários", Url = "Print_1", Description = "Uma caneca de porcelana com estampa colorida", Price=254 },
                new Products { Title = "Jogo de tabuleiro War", Category = "Peças", Url = "Print_2", Description = "Um jogo de estratégia com miniaturas de exércitos", Price=91 },
                new Products { Title = "Urso de pelúcia gigante", Category = "Brinquedos", Url = "Print_3", Description = "Um urso de pelúcia gigante para abraçar", Price=97 },
                new Products { Title = "Garrafa térmica", Category = "Utilitários", Url = "Print_4", Description = "Uma garrafa térmica de aço inox para manter a bebida quente ou fria", Price=12 },
                new Products { Title = "Jogo de construção Lego", Category = "Brinquedos", Url = "Print_5", Description = "Um jogo de construção com peças de encaixar", Price=5 },
                new Products { Title = "Mala de viagem", Category = "Utilitários", Url = "Print_1", Description = "Uma mala de viagem com rodinhas e alça para transporte", Price=505 }
            };
        }
    }
}
