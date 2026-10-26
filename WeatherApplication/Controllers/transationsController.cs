using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApplication.Interface;
using WeatherApplication.Model;
using WeatherApplication.Repository.DBContext;

[Route("api/[controller]")]
[ApiController]
public class transationsController : ControllerBase
{
    private readonly Itransition _transaction;
    public transationsController(Itransition transaction)
    {
        _transaction = transaction;
    }
    [Authorize]
    // GET: api/transation
    [HttpGet]
    public async Task<ActionResult<IEnumerable<transation>>> Gettransation()
    {
        var transitionList = await _transaction.GetTransitionList();
        return Ok(transitionList);
    }
    [Authorize]
    // GET: api/transation/5
    [HttpGet("{transationid}")]
    public async Task<ActionResult<transation>> Gettransation(string transationid)
    {
        var transation = await _transaction.GetTransitionByType(transationid);

        if (transation == null)
        {
            return NotFound();
        }

        return Ok(transation);
    }
    [Authorize]
    // PUT: api/transation/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{transationid}")]
    public async Task<IActionResult> CreateTransation(transation transation)
    {
        var transationToUpdate = await _transaction.CreateTransition(transation);
        return Ok(transationToUpdate);
    }
    [Authorize]
    // POST: api/transation
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<transation>> Posttransation(transation transation)
    {
        var createdTransation = await _transaction.CreateTransition(transation);
        return Ok(createdTransation);
    }

    // DELETE: api/transation/5
    [HttpDelete("{transationid}")]
    [Authorize]
    public async Task<IActionResult> Deletetransation(int transationid)
    {
        var transation = await _transaction.DeleteTransition(transationid);
        return Ok(transation);
    }

}
