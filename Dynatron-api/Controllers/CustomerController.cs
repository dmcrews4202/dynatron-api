using Microsoft.AspNetCore.Mvc;
using Dynatron_api.Models;

namespace Dynatron_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Customer> Get()
    {
        return new Customer[5];
    }

    [HttpGet("{id}")]
    public Customer Get(int id)
    {
        return new Customer();
    }

    [HttpPost]
    public Customer AddCustomer(Customer customer)
    {
        return customer;
    }

    [HttpPut("id")]
    public Customer PutCustomer(int id)
    {
        return new Customer();
    }

    [HttpDelete("id")]
    public void DeleteCustomer(int id)
    {
        return;
    }
}