using _1_ShipmentApis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_ShipmentApis.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ApplicationDBContext _con;
        public ClientController(ApplicationDBContext conn)
        {
            _con = conn;
        }
        [HttpGet]
        public IActionResult GetClients()
        {
            var ClientList = _con.clients.ToList();
            return Ok(ClientList);
        }
        [HttpPost]
        public IActionResult AddClient([FromBody] Client client)
        {
            if (ModelState.IsValid && client.id == 0)
            {
                _con.clients.Add(client);
                _con.SaveChanges();
                return Ok(new { message = "Data Added Successfully!!" });
            }
            return BadRequest(new { message = "Something Went Wrong!!" });
        }
        [HttpPut]
        public IActionResult UpdateClient([FromBody] Client client)
        {
            if (ModelState.IsValid && client.id != 0)
            {
                _con.clients.Update(client);
                _con.SaveChanges();
                return Ok(new { message = "Data Updated Successfully!!" });
            }
            return BadRequest(new { message = "Something Went Wrong!!" });
        }
        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            var ClientFromDB = _con.clients.Find(id);
            if (ClientFromDB == null) return NotFound();
            else
            {
                _con.clients.Remove(ClientFromDB);
                _con.SaveChanges();
                return Ok(new { message = "Data Deleted Successfully!!" });
            }
        }
    }
}
