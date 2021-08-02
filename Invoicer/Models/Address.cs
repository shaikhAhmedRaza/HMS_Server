﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicer.Models
{
    public class Address 
    {
        //Hotel
        //    Name
        public string Title { get; set; }
       //Hotel Address
        public string[] AddressLines { get; set; }
        //Hotel Gst number
        public string VatNumber { get; set; }
        //Hotel contact Number
        public string CompanyNumber { get; set; }

        public bool HasCompanyNumber { get { return !string.IsNullOrEmpty(CompanyNumber); } }
        public bool HasVatNumber { get { return !string.IsNullOrEmpty(VatNumber); } }

        public static Address Make(string title, string[] address, string company = null, string vat = null)
        {
            return new Address
            {
                Title = title,
                AddressLines = address,
                CompanyNumber = company,
                VatNumber = vat,
            };
        }
    }
}
