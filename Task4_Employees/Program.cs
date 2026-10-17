using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var employees = new List<Employee>
{
    new Employee("Иван Петров", "Разработчик", 150000m),
    new Employee("Анна Смирнова", "Менеджер проектов", 120000m),
    new Employee("Олег Кузнецов", "Тестировщик", 90000m)
};

Console.WriteLine("=== Сотрудники ===");
employees.ForEach(e => e.PrintInfo());

// Повышение зарплаты на 10% всем сотрудникам
Console.WriteLine("\n=== Повышение зарплаты на 10% ===");
foreach (var employee in employees)
{
    employee.RaiseSalary(10);
    employee.PrintInfo();
}

/// <summary>
/// Сотрудник компании: имя, должность и зарплата.
/// </summary>
class Employee
{
    public string Name { get; }
    public string Position { get; }
    public decimal Salary { get; private set; }

    public Employee(string name, string position, decimal salary)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя не может быть пустым.", nameof(name));
        if (string.IsNullOrWhiteSpace(position))
            throw new ArgumentException("Должность не может быть пустой.", nameof(position));
        if (salary < 0)
            throw new ArgumentOutOfRangeException(nameof(salary), "Зарплата не может быть отрицательной.");

        Name = name;
        Position = position;
        Salary = salary;
    }

    // Повышает зарплату на указанный процент
    public void RaiseSalary(decimal percent)
    {
        if (percent <= 0)
            throw new ArgumentOutOfRangeException(nameof(percent), "Процент повышения должен быть больше нуля.");
        Salary += Salary * percent / 100;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"{Name}, {Position}, зарплата: {Salary:F2} руб.");
    }
}
