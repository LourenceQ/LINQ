using Infra;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("customers")]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _customerRepository.GetEmployees();

        return Ok(customers);
    }
}
