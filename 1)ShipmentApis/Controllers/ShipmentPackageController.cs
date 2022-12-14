using _1_ShipmentApis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_ShipmentApis.Controllers
{
    [Route("api/shipmentpackage")]
    [ApiController]
    public class ShipmentPackageController : Controller
    {
        private readonly ApplicationDBContext _con;
        public ShipmentPackageController(ApplicationDBContext conn)
        {
            _con = conn;
        }
        [HttpGet]
        public IActionResult getpackages()
        {
            return Ok(_con.shipmentPackages.Include(s => s.Shipment).Include(s => s.Shipment.Carrier).Include(s => s.Shipment.client).Include(s => s.Shipment.ShipFromAddress).Include(s => s.Shipment.shipToAddress).ToList());
        }
        [HttpPost]
        public IActionResult addpackages([FromBody] ShipmentPackage shipmentpackage)
        {
            if (ModelState.IsValid && shipmentpackage.ID == 0)
            {
                _con.shipmentPackages.Add(shipmentpackage);
                _con.SaveChanges();
                return Ok(new { message = "Data Added Successfully!!" });
            }
            return BadRequest(new { message = "Something Went Wrong!!" });
        }
        [HttpDelete]
        public IActionResult deletepackage(int id)
        {
            var packagefromdb = _con.shipmentPackages.Find(id);
            if (packagefromdb == null) return NotFound();
            else
            {
                _con.shipmentPackages.Remove(packagefromdb);
                _con.SaveChanges();
                return Ok(new { message = "Data Deleted Successfully!!" });
            }
        }
        [HttpPut]
        public IActionResult updatepackage([FromBody] ShipmentPackage shipmentpackage)
        {
            if (ModelState.IsValid && shipmentpackage.ID != 0)
            {
                _con.shipmentPackages.Update(shipmentpackage);
                _con.SaveChanges();
                return Ok(new { message = "Data Updated Successfully!!" });
            }
            return BadRequest(new { message = "Something Went Wrong!!" });
        }
    }
}
