using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.SignalR.Api.DAL;

namespace TakeAway.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly Context _context;

        public DeliveriesController ( Context context )
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get ()
        {
            var values= _context.Deliveries.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Post ( Delivery delivery )
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
            return Ok("Saved.");
        }
        [HttpPut]
        public IActionResult Put ( Delivery delivery )
        {
            _context.Deliveries.Update(delivery);
            _context.SaveChanges();
            return Ok("Updated.");
        }
        [HttpDelete]
        public IActionResult Delete ( int id )
        {
            var value = _context.Deliveries.Find(id);
            _context.Deliveries.Remove(value);
            _context.SaveChanges();
            return Ok("Deleted.");
        }
        [HttpGet("GetDeliveryByStatusIsOnWay")]
        public IActionResult GetDeliveryByStatusIsOnWay ()
        {
            int values = _context.Deliveries.Where(x => x.Status == "On Way").Count();
            return Ok(values);
        }
        
        [HttpGet("GetDeliveryByStatusIsOrderTaken")]
        public IActionResult GetDeliveryByStatusIsOrderTaken ()
        {
            int values = _context.Deliveries.Where(x => x.Status == "Order Taken").Count();
            return Ok(values);
        }
        [HttpGet("GetDeliveryByStatusIsPreparing")]
        public IActionResult GetDeliveryByStatusIsPreparing ()
        {
            int values = _context.Deliveries.Where(x => x.Status == "Preparing").Count();
            return Ok(values);
        }
        [HttpGet("GetDeliveryByStatusIsDelivered")]
        public IActionResult GetDeliveryByStatusIsDelivered ()
        {
            int values = _context.Deliveries.Where(x => x.Status == "Order Delivered").Count();
            return Ok(values);
        }
        
        [HttpGet("GetTotalPrice")]
        public IActionResult GetTotalPrice ( int id )
        {
            decimal value = _context.Deliveries.Sum(x => x.TotalPrice);
            return Ok(value);
        }

        [HttpGet("GetTotalDelivery")]
        public IActionResult GetTotalDelivery ( int id )
        {
            int value = _context.Deliveries.Count();
            return Ok(value);
        }
    }


    
}
