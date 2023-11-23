using CompanyApp.Entities;
using System.Xml.Serialization;

namespace CompanyApp.Repositories
{
    public class EmployeeRepositories
    {
        private readonly List<Employee> _employees = new();

        public void Add(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            _employees.Add(employee);
        }

        public void Safe()
        {
            foreach (var employee in _employees)
            {
                Console.WriteLine(employee);
            }
        }

        public Employee GetById(int id)
        {
            return _employees.Single(Employee => Employee.Id == id);
        }
    }
}
