using BeachApi.Data;
using BeachApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeachApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BeachController: ControllerBase
{
    private readonly MyWorldDbContext _myWorldDbContext;

    public BeachController(MyWorldDbContext myWorldDbContext)
    {
        _myWorldDbContext = myWorldDbContext;
    }

    [HttpGet]
        public async Task<IActionResult> Get()
        {
            var beaches =  await _myWorldDbContext.Beach.ToListAsync();
            return Ok(beaches);
        }


    [HttpPost]
         
         public async Task<IActionResult> Post(Beach newBeach)
         {
            _myWorldDbContext.Beach.Add(newBeach);
            await _myWorldDbContext.SaveChangesAsync();
            return Ok(newBeach);
         }


    [HttpGet]
    [Route("{id:int}")]

    public async Task<IActionResult> Get(int id)
    {
        var beachById = await _myWorldDbContext.Beach.Where(_ => _.Id == id).FirstOrDefaultAsync();
        return Ok(beachById);
    }

    [HttpPut]

    public async Task<IActionResult> Put(Beach beachToUpdate)
    {
        _myWorldDbContext.Beach.Update(beachToUpdate);
        await _myWorldDbContext.SaveChangesAsync();
        return Ok(beachToUpdate);
    }

    [HttpDelete]
    [Route("{id:int}")]

    public async Task<IActionResult> Delete(int id)
    {
        var beachToDelete = await _myWorldDbContext.Beach.FindAsync(id);
        if(beachToDelete == null) 
        {
            return NotFound();

        }
        _myWorldDbContext.Beach.Remove(beachToDelete);
        await _myWorldDbContext.SaveChangesAsync();
        return Ok();
    }

}
