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
    [Route("api/shipment")]
    [ApiController]
    public class ShipmentController : Controller
    {
        private readonly ApplicationDBContext _con;
        public ShipmentController(ApplicationDBContext conn)
        {
            _con = conn;
        }
        [HttpGet]
        public IActionResult GetShipments()
        {
            var ShipmentList = _con.shipments.Include(c => c.Carrier).Include(c => c.client).Include(s => s.ShipFromAddress).Include(s => s.shipToAddress).ToList();
            return Ok(ShipmentList);
        }
        [HttpPost]
        public IActionResult AddShipment([FromBody] Shipment shippment)
        {
            if (ModelState.IsValid && shippment.Id == 0)
            {
                _con.shipments.Add(shippment);
                _con.SaveChanges();
                return Ok(new { message = "Data Added Successfully!!" });
            }
            return BadRequest(new { message = "Something Went Wrong!!" });
        }
        [HttpDelete]
        public IActionResult DeleteShipment(int id)
        {
            var ShipmentFromDb = _con.shipments.FirstOrDefault(s => s.Id == id);
            if (ShipmentFromDb == null)
                return NotFound();
            else
            {
                _con.shipments.Remove(ShipmentFromDb);
                _con.SaveChanges();
                return Ok(new { message = "Data Deleted Successfully!!" });
            }
        }
        [HttpPut]
        public IActionResult UpdateShipment([FromBody] Shipment shippment)
        {
            if (ModelState.IsValid && shippment.Id != 0)
            {
                _con.shipments.Update(shippment);
                _con.SaveChanges();
                return Ok(new { message = "Data Updated Successfully!!" });
            }
            return BadRequest(new { message = "Something Went Wrong!!" });
        }
    }
}
