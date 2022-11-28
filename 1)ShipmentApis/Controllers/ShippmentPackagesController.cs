//using _1_ShipmentApis;
//using _1_ShipmentApis.Models;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;

//namespace _1_shipmentapis.controllers
//{
//    //[Route("api/shipingpackges")]
//    [ApiController]
//    public class shippmentpackagescontroller : Controller
//    {
//        private readonly ApplicationDBContext _con;
//        public shippmentpackagescontroller(ApplicationDBContext conn)
//        {
//            _con = conn;
//        }
//        [HttpGet]
//        public IActionResult getpackages()
//        {
//            return Ok(_con.shipmentPackages.Include(s => s.Shipment).Include(s => s.Shipment.Carrier).Include(s => s.Shipment.client).Include(s => s.Shipment.ShipFromAddress).Include(s => s.Shipment.shipToAddress).ToList());
//        }
//        [HttpPost]
//        public IActionResult addpackages([FromBody] ShipmentPackage shipmentpackage)
//        {
//            if (ModelState.IsValid && shipmentpackage.ID == 0)
//            {
//                _con.shipmentPackages.Add(shipmentpackage);
//                _con.SaveChanges();
//                return Ok();
//            }
//            return BadRequest();
//        }
//        [HttpDelete]
//        public IActionResult deletepackage(int id)
//        {
//            var packagefromdb = _con.shipmentPackages.FirstOrDefault(s => s.ID == id);
//            if (packagefromdb == null) return NotFound();
//            else
//            {
//                _con.shipmentPackages.Remove(packagefromdb);
//                _con.SaveChanges();
//                return Ok();
//            }
//        }
//        [HttpPut]
//        public IActionResult updatepackage([FromBody] ShipmentPackage shipmentpackage)
//        {
//            if (ModelState.IsValid && shipmentpackage.ID != 0)
//            {
//                _con.shipmentPackages.Update(shipmentpackage);
//                _con.SaveChanges();
//                return Ok();
//            }
//            return BadRequest();
//        }
//    }
//}
