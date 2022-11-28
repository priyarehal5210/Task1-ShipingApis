using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_ShipmentApis.Models
{
    public class ShipmentPackage
    {
        public int ID { get; set; }
        public int ShipmentID { get; set; }
        public Shipment Shipment { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
