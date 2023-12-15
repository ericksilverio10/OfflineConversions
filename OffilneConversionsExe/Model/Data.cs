using System;
namespace OfflineConversions.Model
{
    public class FinalData
    {
        public List<Order> data { get; set; }

        public FinalData(List<Order> Data)
        {
            data = Data;
        }
    }
}

