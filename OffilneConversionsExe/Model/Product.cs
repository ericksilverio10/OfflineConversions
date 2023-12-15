using System;
namespace OfflineConversions.Model
{
    public class Product
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public string delivery_category { get; set; }

        public Product(int Id, int Qtd, string Categoria)
        {
            id = Id;
            quantity = Qtd;
            delivery_category = Categoria;
        }
    }
}

