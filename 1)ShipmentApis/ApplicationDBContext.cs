using _1_ShipmentApis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_ShipmentApis
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {

        }
        public DbSet<Shipment> shipments { get; set; }
        public DbSet<ShipmentPackage> shipmentPackages { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<ShipFromAddress> shipFromAddresses { get; set; }
        public DbSet<ShipToAddress> shipToAddresses { get; set; }
        public DbSet<Carrier> carriers { get; set; }
    }
}
