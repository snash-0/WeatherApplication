using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApplication.Interface;
using WeatherApplication.Model;
using WeatherApplication.Repository;


namespace WeatherApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly Icustomers _customer;

        public CustomerController(Icustomers customer)
        {
            _customer = customer;
        }
        [Authorize(Roles = "Admin")]
        // GET: CustomerController
        [HttpGet]
        public async Task<List<customers>> Index()
        {
            var customersList = await _customer.GetCustomerList();
            return customersList;
        }
        [Authorize(Roles = "Admin")]
        // GET: CustomerController/Details/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult<customers>> GetCustomerById(int id)
        {
            var singleCustomer = await _customer.GetCustomerById(id);
            return singleCustomer;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("name/{name}")]
        public async Task<ActionResult<customers>> GetCustomerByName(string name)
        {
            var singleCustomer = await _customer.GetCustomerByName(name);
            return singleCustomer;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Create(customers customer)
        {
            await _customer.AddCustomerAsync(customer);
            return Ok(customer);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch]
        public async Task<ActionResult> Update(customers customer)
        {
            await _customer.UpdateCustomerAsync(customer);
            return Ok(customer);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _customer.DeleteCustomerAsync(id);
            return Ok();
        }        
    }
}
