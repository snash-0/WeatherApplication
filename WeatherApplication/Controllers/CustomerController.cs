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

        // GET: CustomerController
        [HttpGet]
        public async Task<List<customers>> Index()
        {
            var customersList = await _customer.GetCustomerList();
            return customersList;
        }

        // GET: CustomerController/Details/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult<customers>> GetCustomerById(int id)
        {
            var singleCustomer = await _customer.GetCustomerById(id);
            return singleCustomer;
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<customers>> GetCustomerByName(string name)
        {
            var singleCustomer = await _customer.GetCustomerByName(name);
            return singleCustomer;
        }

        [HttpPost]
        public async Task<ActionResult> Create(customers customer)
        {
            await _customer.AddCustomerAsync(customer);
            return Ok(customer);
        }

        [HttpPatch]
        public async Task<ActionResult> Update(customers customer)
        {
            await _customer.UpdateCustomerAsync(customer);
            return Ok(customer);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _customer.DeleteCustomerAsync(id);
            return Ok();
        }
        //// GET: CustomerController/Create
        //public async Task<ActionResult<customers>> Create(customers customer)
        //{
        //    await _customer.AddCustomerAsync(customer);
        //    return customer;
        //}

        //// POST: CustomerController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(customers customer)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CustomerController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CustomerController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
