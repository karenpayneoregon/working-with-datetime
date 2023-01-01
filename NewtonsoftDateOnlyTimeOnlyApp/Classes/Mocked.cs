using NewtonsoftDateOnlyTimeOnlyApp.Models;
using Bogus;
using Person = NewtonsoftDateOnlyTimeOnlyApp.Models.Person;
namespace NewtonsoftDateOnlyTimeOnlyApp.Classes;

public class Mocked
{
    public static List<Container> Container() =>
        new()
        {
            new()
            {
                Id = 1,
                FirstName = "Karen",
                LastName = "Payne",
                StartDate = new DateOnly(2022,12,1),
                StartTime = new TimeOnly(14,15)
            },
            new()
            {
                Id = 2,
                FirstName = "May",
                LastName = "Gallagher",
                StartDate = new DateOnly(2022,12,11),
                StartTime = new TimeOnly(16,0)
            }
        };
    /// <summary>
    /// Create random list of <see cref="Models.Person"/>
    /// </summary>
    /// <param name="count">Amount of people to create, passing nothing will create 10</param>
    /// <returns>List of Person</returns>
    public static List<Person> People(int count = 10)
    {
        int identifier = 1;

        Faker<Person> fakePerson = new Faker<Person>()
                .CustomInstantiator(f => new Person(identifier++))
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.BirthDate, f => 
                    f.Date.BetweenDateOnly(new DateOnly(2000, 1, 1), new DateOnly(2022, 12, 1)))
            ;


        return fakePerson.Generate(count);

    }
}

