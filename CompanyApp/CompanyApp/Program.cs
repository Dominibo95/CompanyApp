using CompanyApp.Repositories;
using CompanyApp.Entities;

var employeeRepositories = new GenericRepository<Employee, int>();

employeeRepositories.Add(new Employee { FirstName = "Dominik" });
employeeRepositories.Add(new Employee { FirstName = "Adam" });
employeeRepositories.Add(new Employee { FirstName = "Piotr" });

employeeRepositories.Safe();

Employee test = employeeRepositories.GetById(3);

Console.WriteLine(test);