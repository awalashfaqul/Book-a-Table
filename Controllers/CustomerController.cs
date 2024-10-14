using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_a_Table.Models.DTO.Customer;
using Book_a_Table.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Book_a_Table.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("CREATE_Customer")]
        public async Task<IActionResult> AddCustomerAsync(CreateCustomerDTO createCustomerDto)
        {
            await _customerService.AddCustomerAsync(createCustomerDto);
            return Created();
        }

        [HttpGet]
        [Route("READ_All_Customers")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            return Ok(await _customerService.GetAllCustomersAsync());
        }

    [HttpGet]
    [Route("READ_Customer_By_Id")]
    public async Task<IActionResult> GetCustomerByIdAsync(int customerId)
    {
      return Ok(await _customerService.GetCustomerByIdAsync(customerId));
    }

    [HttpPut]
    [Route("UPDATE_Customer")]
    public async Task<IActionResult> UpdateCustomerAsync(int customerId, UpdateCustomerDTO updateCustomerDto)
    {
      await _customerService.UpdateCustomerAsync(customerId, updateCustomerDto);
      return NoContent();
    }

    [HttpDelete]
    [Route("DELETE_Customer")]
    public async Task<IActionResult> DeleteCustomerAsync(int customerId)
    {
      await _customerService.DeleteCustomerAsync(customerId);
      return NoContent();
    }
    }
}