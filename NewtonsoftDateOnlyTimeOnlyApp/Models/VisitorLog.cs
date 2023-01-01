namespace NewtonsoftDateOnlyTimeOnlyApp.Models;

public class VisitorLog
{

    public DateOnly VisitOn { get; set; }

    public TimeOnly EnteredTime { get; set; }

    public TimeOnly ExitedTime { get; set; }

}