using _1_ShipmentApis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_ShipmentApis.Controllers
{
    [Route("api/shippingfrom")]
    [ApiController]
    public class ShippingFromAddressController : Controller
    {
        private readonly ApplicationDBContext _con;
        public ShippingFromAddressController(ApplicationDBContext conn)
        {
            _con = conn;
        }
        [HttpGet]
        public IActionResult GetFromAddress()
        {
            var ShippimentFromList = _con.shipFromAddresses.ToList();
            return Ok(ShippimentFromList);
        }
        [HttpPost]
        public IActionResult AddFromAddress([FromBody] ShipFromAddress shipFromAddress)
        {
            if (ModelState.IsValid && shipFromAddress.ID == 0)
            {
                _con.shipFromAddresses.Add(shipFromAddress);
                _con.SaveChanges();
                return Ok(new {message="Data Added Successfully!!" });
            }
            return BadRequest(new { message = "Something Went Wrong!!" });
        }
        [HttpDelete]
        public IActionResult DeleteFromAddress(int id)
        {
            var FromAddressFromDb = _con.shipFromAddresses.FirstOrDefault(i => i.ID == id);
            if (FromAddressFromDb != null)
            {
                _con.shipFromAddresses.Remove(FromAddressFromDb);
                _con.SaveChanges();
                return Ok(new { message = "Data Deleted Successfully!!" });
            }
            else
            {
                return BadRequest(new { message = "Something Went Wrong!!" });
            }
        }
        [HttpPut]
        public IActionResult UpdateFromAddress([FromBody] ShipFromAddress shipFromAddress)
        {
            if (ModelState.IsValid && shipFromAddress.ID != 0)
            {
                _con.shipFromAddresses.Update(shipFromAddress);
                _con.SaveChanges();
                return Ok(new { message = "Data Updated Successfully!!" });
            }
            return BadRequest(new { message = "Something Went Wrong!!" });
        }
    }
}
