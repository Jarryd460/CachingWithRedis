using CachingWithRedis.Infrastructure;
using CachingWithRedis.Models;
using Microsoft.AspNetCore.Mvc;

namespace CachingWithRedis.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public CustomerController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> Customers()
    {
        return _dbContext.Customers.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomerById(int id)
    {
        var customer = _dbContext.Customers.Find(id);

        if (customer is null)
        {
            return NotFound();
        }

        return customer;
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer([FromBody] Customer customer)
    {
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
    {
        var customer = _dbContext.Customers.Find(id);

        if (customer is null)
        {
            return NotFound();
        }

        customer.PhoneNumber = updatedCustomer.PhoneNumber;
        customer.DateOfBirth = updatedCustomer.DateOfBirth;
        customer.Address = updatedCustomer.Address;
        customer.Email = updatedCustomer.Email;
        customer.Firstname = updatedCustomer.Firstname;
        customer.Lastname = updatedCustomer.Lastname;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var customer = _dbContext.Customers.Find(id);
        
        if (customer is null)
        {
            return NotFound();
        }

        _dbContext.Customers.Remove(customer);
        _dbContext.SaveChanges();

        return NoContent();
    }
}
