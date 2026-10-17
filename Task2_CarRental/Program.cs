using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var cars = new List<Car>
{
    new Car("Toyota", "Camry", 2022, 4500m),
    new Car("Kia", "Rio", 2020, 2500m),
    new Car("BMW", "X5", 2023, 12000m)
};

int days = 5;
foreach (var car in cars)
{
    car.PrintInfo();
    Console.WriteLine($"Аренда на {days} дн.: {car.CalculateRentalCost(days):F2} руб.");
    Console.WriteLine(new string('-', 30));
}

/// <summary>
/// Автомобиль для аренды: марка, модель, год выпуска и суточная ставка.
/// </summary>
class Car
{
    public string Brand { get; }
    public string Model { get; }
    public int Year { get; }
    public decimal PricePerDay { get; }

    public Car(string brand, string model, int year, decimal pricePerDay)
    {
        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException("Марка не может быть пустой.", nameof(brand));
        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Модель не может быть пустой.", nameof(model));
        if (year < 1886 || year > DateTime.Now.Year + 1)
            throw new ArgumentOutOfRangeException(nameof(year), "Некорректный год выпуска.");
        if (pricePerDay < 0)
            throw new ArgumentOutOfRangeException(nameof(pricePerDay), "Цена не может быть отрицательной.");

        Brand = brand;
        Model = model;
        Year = year;
        PricePerDay = pricePerDay;
    }

    // Стоимость аренды = количество дней * суточная ставка
    public decimal CalculateRentalCost(int days)
    {
        if (days <= 0)
            throw new ArgumentOutOfRangeException(nameof(days), "Количество дней должно быть больше нуля.");
        return days * PricePerDay;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Автомобиль: {Brand} {Model}");
        Console.WriteLine($"Год выпуска: {Year}");
        Console.WriteLine($"Цена за день: {PricePerDay:F2} руб.");
    }
}
