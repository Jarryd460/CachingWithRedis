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
}
