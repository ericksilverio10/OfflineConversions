using System;
namespace OfflineConversions.Model
{
    public class Order
    {
        public string event_name { get; set; }
        public long event_time { get; set; }
        public UserData user_data { get; set; }
        public OrderDetails custom_data { get; set; }
        public string action_source { get; set; }

        public Order(string EventName, long EventTime, UserData UserData, OrderDetails orderDetails, string ActionSource)
        {
            event_name = EventName;
            event_time = EventTime;
            user_data = UserData;
            custom_data = orderDetails;
            action_source = ActionSource;
        }
    }
}

