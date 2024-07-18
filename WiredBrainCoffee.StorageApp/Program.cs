using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entites;
using WiredBrainCoffee.StorageApp.Respositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var employeeRepository = new SqlRepository<Employee>(new StorageAppDBContext());

        employeeRepository.itemadded += EmployeeRepository_itemadded;
        AddEmployees(employeeRepository);

        AddMangers(employeeRepository);

        GetEmployeebyId(employeeRepository);

        WriteAlltoConsole(employeeRepository);

        var organizationRepository = new ListRepository<Organization>();
        AddOrganizations(organizationRepository);
        WriteAlltoConsole(organizationRepository);

        Console.ReadLine();
    }

    private static void EmployeeRepository_itemadded(object? sender, Employee e)
    {
        Console.WriteLine($"Employee added => {e.FirstName}");
    }

    private static void AddMangers(IWriteRepository<Manager> managerRepository)
    {
        var saraManager = new Manager { FirstName = "Sara" };
        var saraManagerCopy = saraManager.Copy();

        if(saraManagerCopy is not null)
        {
            saraManagerCopy.FirstName += "_Copy";
            managerRepository.Add(saraManagerCopy);
        }


        managerRepository.Add(saraManager);
        managerRepository.Add(new Manager { FirstName = "Henry" });
        managerRepository.save();
    }

    private static void WriteAlltoConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach(var item in items) 
        {
            Console.WriteLine(item);
        }
    }

    private static void GetEmployeebyId(IRepository<Employee> employeeRepository)
    {
        var employee = employeeRepository.GetById(2);
        Console.WriteLine($"The employee at index 2 is {employee.FirstName}");
    }

    private static void AddOrganizations(IRepository<Organization> organizationRepository)
    {
        var organizations = new[]
        {
            new Organization {Name = "Pluralsight" },
            new Organization { Name = "Globomantics" }
        };

        organizationRepository.AddBatch(organizations);
  
    }

    private static void AddEmployees(IRepository<Employee> employeeRepository)
    {
        var employees = new[]
        {
        new Employee { FirstName = "Julia" },
        new Employee { FirstName = "Anna" },
        new Employee { FirstName = "Thomas" }
        };
        employeeRepository.AddBatch(employees);
    }
}