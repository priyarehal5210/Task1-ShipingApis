using _1_ShipmentApis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_ShipmentApis.Controllers
{
    [Route("api/shippingtoaddress")]
    [ApiController]
    public class ShippingToAddressController : Controller
    {
        private readonly ApplicationDBContext _con;
        public ShippingToAddressController(ApplicationDBContext conn)
        {
            _con = conn;
        }
        [HttpGet]
        public IActionResult GetToAddress()
        {
            var ToAddressList = _con.shipToAddresses.ToList();
            return Ok(ToAddressList);
        }
        [HttpPost]
        public IActionResult AddToAddress([FromBody] ShipToAddress shippingToAddress)
        {
            if (ModelState.IsValid && shippingToAddress.ID == 0)
            {
                _con.shipToAddresses.Add(shippingToAddress);
                _con.SaveChanges();
                return Ok(new { message = "Data Added Successfully!!" });
            }
            return BadRequest(new { message = "Something Went Wrong!!" });
        }
        [HttpDelete]
        public IActionResult DeleteToAddress(int id)
        {
            var ToAddressFromDb = _con.shipToAddresses.Find(id);
            if (ToAddressFromDb == null) return BadRequest(new { message = "Something Went Wrong!!" });
            else
            {
                _con.shipToAddresses.Remove(ToAddressFromDb);
                _con.SaveChanges();
                return Ok(new { message = "Data Deleted Successfully!!" });
            }
        }
        [HttpPut]
        public IActionResult UpdateToAddress([FromBody] ShipToAddress shippingToAddress)
        {
            if (ModelState.IsValid && shippingToAddress.ID != 0)
            {
                _con.shipToAddresses.Update(shippingToAddress);
                _con.SaveChanges();
                return Ok(new { message = "Data Updated Successfully!!" });
            }
            return BadRequest(new { message = "Something Went Wrong!!" });
        }
    }
}
