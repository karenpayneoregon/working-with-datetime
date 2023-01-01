using CommonLibrary.Models;

namespace CommonLibrary.LanguageExtensions;

public static class GroupingExtensions
{
    public static IOrderedEnumerable<Car> Ordering(this IGrouping<string, Car> source) 
        => source.OrderBy(item => item.Model).ThenBy(item => item.ProductionDate.Month).ThenBy(item => item.ProductionDate.Day);
}