using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1_ShipmentApis.Models
{
    public class Client
    {
        public int id { get; set; }
        public string CreatedDate { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
        public int CountryCode { get; set; }
    }
}
