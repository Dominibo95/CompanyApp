using System;

namespace CompanyApp.Entities
{
    public class Employee : EntityBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public override string ToString() => $"id: {Id}, First Name: {FirstName} , Last Name : {LastName} ";

    }
}
