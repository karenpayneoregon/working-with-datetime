
namespace NewtonsoftDateOnlyTimeOnlyApp.Models;

public class Container
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly StartDate { get; set; }
    public TimeOnly StartTime { get; set; }
}