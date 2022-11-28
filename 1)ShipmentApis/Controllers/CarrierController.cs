using _1_ShipmentApis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_ShipmentApis.Controllers
{
    [Route("api/carrier")]
    [ApiController]
    public class CarrierController : Controller
    {
        private readonly ApplicationDBContext _con;
        public CarrierController(ApplicationDBContext conn)
        {
            _con = conn;
        }
        [HttpGet]
        public IActionResult GetCarrier()
        {
            return Ok(_con.carriers.ToList());

        }
        [HttpPost]
        public IActionResult AddCarrier([FromBody] Carrier carrier)
        {
            if (ModelState.IsValid && carrier.ID == 0)
            {
                _con.carriers.Add(carrier);
                _con.SaveChanges();
                return Ok(new { message = "Data Added Successfully!!" });
            }
            return BadRequest();
        }
    }
}
