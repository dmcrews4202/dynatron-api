using Microsoft.AspNetCore.Mvc;
using Dynatron_api.Models;
using Dynatron_api.Data;

namespace Dynatron_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomersController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Customer>> Get()
    {
        var data = await _service.GetAllAsync();
        return data;
    }

    [HttpGet("{id}")]
    public async Task<Customer> Get(int id)
    {
        var data = await _service.GetByIdAsync(id);
        return data;
    }

    [HttpPost]
    public async Task<Customer> AddCustomer(Customer customer)
    {
        await _service.AddAsync(customer);
        return customer;
    }

    [HttpPut("id")]
    public async Task<Customer> PutCustomer(int id, Customer customer)
    {
        await _service.UpdateAsync(id, customer);
        return customer;
    }

    [HttpDelete("id")]
    public async Task DeleteCustomer(int id)
    {
        await _service.DeleteAsync(id);
        return;
    }
}