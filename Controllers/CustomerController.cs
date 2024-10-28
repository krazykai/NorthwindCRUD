using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using NorthwindCRUD.Models.Parameters;
using NorthwindCRUD.Services;

namespace NorthwindCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            try
            {
                List<Customer> customers = await _customerService.GetAll();
                return customers;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Customer>> GetById([FromQuery] string CustomerId)
        {
            try
            {
                Customer customer = await _customerService.GetById(CustomerId);
                return customer;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Query")]
        public async Task<ActionResult<List<Customer>>> Query([FromBody] CustomerQueryParameters parameters)
        {
            try
            {
                List<Customer> customers = await _customerService.Query(parameters);
                return customers;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<bool>> Create([FromBody] CustomerCreateParameters parameters)
        {
            try
            {
                bool createIsSuccess = await _customerService.Create(parameters);
                return createIsSuccess;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<bool>> Update([FromBody] CustomerUpdateParameters parameters)
        {
            try
            {
                bool updateIsSuccess = await _customerService.Update(parameters);
                return updateIsSuccess;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<bool>> Delete(string CustomerId)
        {
            try
            {
                bool deleteIsSuccess = await _customerService.Delete(CustomerId);
                return deleteIsSuccess;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
