using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
   public class UserConfig:BaseEntity
    {
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int CityId { get; set; }
        public string State { get; set; }
        public int StateId { get; set; }
        public long PinCode { get; set; }
        public string Contact { get; set; }
    }
}
