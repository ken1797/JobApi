using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teknorix.JobsApiFull.Data;
using Teknorix.JobsApiFull.Models;

namespace Teknorix.JobsApiFull.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class JobsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public JobsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Job job)
    {
        job.PostedDate = DateTime.UtcNow;
        job.Code = "JOB-" + new Random().Next(1000, 9999);
        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();
        return Created($"/api/v1/jobs/{job.Id}", job);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Job job)
    {
        var existing = await _context.Jobs.FindAsync(id);
        if (existing == null) return NotFound();
        existing.Title = job.Title;
        existing.Description = job.Description;
        existing.LocationId = job.LocationId;
        existing.DepartmentId = job.DepartmentId;
        existing.ClosingDate = job.ClosingDate;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var job = await _context.Jobs
            .Include(j => j.Location)
            .Include(j => j.Department)
            .FirstOrDefaultAsync(j => j.Id == id);
        if (job == null) return NotFound();
        return Ok(job);
    }
}