using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
    public class Admin
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string FoodLincNum { get; set; }
        public string Address { get; set; }
        public string Gst { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string IfscCode { get; set; }
        public string BankAddress { get; set; }
    
        
        public string PinCode { get; set; }
        public string RestaurentLogo { get; set; }
        public string RestaurentSeal { get; set; }
        public string Signature { get; set; }
        public string TermAndCondition { get; set; }
        public string CodeImage { get; set; }
        public string CodeNumber { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
       
        public int StateId { get; set; }
        public string State { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDAte { get; set; } = DateTime.Now.AddDays(30);
        public int SubscriptionStatus { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string UpiImage { get; set; }

        public int UserId { get; set; }

    }
}
