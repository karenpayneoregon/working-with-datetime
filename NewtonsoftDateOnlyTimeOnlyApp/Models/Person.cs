﻿

namespace NewtonsoftDateOnlyTimeOnlyApp.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }

    public Person(int identifier)
    {
        Id = identifier;
    }

    public Person() { }
        
}