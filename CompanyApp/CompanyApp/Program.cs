using CompanyApp.Repositories;
using CompanyApp.Entities;
using CompanyApp.Data;

var employeeRepository = new SqliteRepository<Employee>(new CompanyAppSqliteContext());
employeeRepository.ItemAdded += EmployeAddedToRepository;
employeeRepository.ItemRemove += EmployeeRemoveFromRepository;
var bPartners = new SqliteRepository<BusinessPartners>(new CompanyAppSqliteContext());
bPartners.ItemAdded += BPartnersAddedToRepository;
bPartners.ItemRemove += BPartnersRemoveFromRepository;

do
{
    Menu();

    string input = Console.ReadLine();
    if (input == "q" || input == "Q")
        break;

    switch (input)
    {
        case "1":
            WriteAllEmployeeToConsole(employeeRepository);
            break;
        case "2":
            WriteAllBPartnersToConsole(bPartners);
            break;
        case "3":
            AddEmployee(employeeRepository);
            break;
        case "4":
            RemoveEmployee(employeeRepository);
            break;
        case "5":
            AddBusinessPartners(bPartners);
            break;
        case "6":
            RemoveBPartners(bPartners);
            break;
        case "c":
        case "C":
            Console.Clear();
            break;
        default:
            Console.WriteLine("wrong option");
            break;
    }
} while (true);

void AddEmployee(SqliteRepository<Employee> employeeRepository)
{
    Console.WriteLine("Please provide the following information in this order:\n1. Name\n2. Surname");

    employeeRepository.Add(new Employee { FirstName = Console.ReadLine(), LastName = Console.ReadLine() });
    employeeRepository.Save();

}
void AddBusinessPartners(SqliteRepository<BusinessPartners> repository)
{
    Console.WriteLine("Please provide the following information in this order:\n1. Name\n2. Owner Name \n3 Contact Number \n4 Description");

    repository.Add(new BusinessPartners { Name = Console.ReadLine(), OwnerName = Console.ReadLine(), ContactNumber = Console.ReadLine(), Description = Console.ReadLine() });
    repository.Save();

}
    void RemoveEmployee(SqliteRepository<Employee> repository)
    {
        Console.WriteLine("Enter the Id of Employee you want to delete");
        try
        {
            repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
            repository.Save();
        }
        catch
        {
            throw new Exception("Failure: there is no such an item to remove.");
        }
    }

void RemoveBPartners(SqliteRepository<BusinessPartners> repository)
{
    Console.WriteLine("Enter the Id of Business Partners you want to delete");
    try
    {
        repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
        repository.Save();
    }
    catch
    {
        throw new Exception("Failure: there is no such an item to remove.");
    }
}
void WriteAllEmployeeToConsole(SqliteRepository<Employee> employeeRepository)
    {
        var items = employeeRepository.GetAll();

        if (items.Any())
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("elements not found");
        }
        Console.ReadKey();
    }

    void WriteAllBPartnersToConsole(SqliteRepository<BusinessPartners> repository)
    {
        var items = repository.GetAll();

        if (items.Any())
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("elements not found");
        }
        Console.ReadKey();
    }

    void EmployeAddedToRepository(object? sender, Employee e)
    {
        Console.WriteLine($"Employee added => {e.FirstName} To {sender?.GetType().Name}");
        String write = $"{DateTime.Now} Employee {e.FirstName} added by {sender?.GetType().Name} ";
        using (var writer = File.AppendText("Log.txt"))
        {
            writer.WriteLine(write);
        }

    }

    void EmployeeRemoveFromRepository(object? sender, Employee e)
    {
        Console.WriteLine($"Employee Removed => {e.FirstName} by {sender?.GetType().Name}");
        String write = $"{DateTime.Now} Employee {e.FirstName} removed by {sender?.GetType().Name} ";
        using (var writer = File.AppendText("Log.txt"))
        {
            writer.WriteLine(write);
        }
    }

    void BPartnersAddedToRepository(object? sender, BusinessPartners e)
    {
        Console.WriteLine($"BusinessPartners added => {e.Name} To {sender?.GetType().Name}");
        String write = $"{DateTime.Now} Business Partners {e.Name} added by {sender?.GetType().Name} ";
        using (var writer = File.AppendText("bLog.txt"))
        {
            writer.WriteLine(write);
        }
    }

    void BPartnersRemoveFromRepository(object? sender, BusinessPartners e)
    {
        Console.WriteLine($"BusinessPartners remove => {e.Name} To {sender?.GetType().Name}");
        String write = $"{DateTime.Now} Business Partners {e.Name} remove by {sender?.GetType().Name} ";
        using (var writer = File.AppendText("bLog.txt"))
        {
            writer.WriteLine(write);
        }
    }

    static void Menu()
    {
        Console.WriteLine("|----------------------MENU----------------------|");
        Console.WriteLine("1 - show all Employee");
        Console.WriteLine("2 - show all Business Partners");
        Console.WriteLine("3 - register Employee");
        Console.WriteLine("4 - delete the selected Employee");
        Console.WriteLine("5 - Add Business Partners");
        Console.WriteLine("6 - delete selected Business Partners");
        Console.WriteLine("c - clear console");
        Console.WriteLine("q - exit the program");
    }

