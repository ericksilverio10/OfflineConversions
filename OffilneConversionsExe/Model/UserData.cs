using System;
namespace OfflineConversions.Model
{
    public class UserData
    {
        public string em { get; set; }
        public string ph { get; set; }

        public UserData(string Em, string Ph)
        {
            em = Em;
            ph = Ph;
        }
    }
}

