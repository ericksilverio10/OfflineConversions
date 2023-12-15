using System;
namespace OfflineConversions.Model
{
    public class OrderDetails
    {
        public int order_id { get; set; }
        public string currency { get; set; }
        public decimal value { get; set; }
        public List<Product> contents { get; set; }

        public OrderDetails(int OrderId, string Currency, decimal Value, List<Product> Contents)
        {
            order_id = OrderId;
            currency = Currency;
            value = Value;
            contents = Contents;
        }
    }
}

