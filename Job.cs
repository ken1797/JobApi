namespace Teknorix.JobsApiFull.Models;

public class Job
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int LocationId { get; set; }
    public Location? Location { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public DateTime PostedDate { get; set; } = DateTime.UtcNow;
    public DateTime ClosingDate { get; set; }
}