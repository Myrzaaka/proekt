using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Список заказов ресторана
var orders = new List<Order>
{
    new Order("Борщ", 2, 350m),
    new Order("Стейк рибай", 1, 1890m),
    new Order("Чай чёрный", 3, 120m)
};

decimal grandTotal = 0;
foreach (var order in orders)
{
    order.PrintInfo();
    grandTotal += order.CalculateTotal();
}

Console.WriteLine($"Итого по всем заказам: {grandTotal:F2} руб.");

/// <summary>
/// Заказ в ресторане: блюдо, количество порций и цена за порцию.
/// </summary>
class Order
{
    public string DishName { get; }
    public int Quantity { get; }
    public decimal PricePerPortion { get; }

    public Order(string dishName, int quantity, decimal pricePerPortion)
    {
        if (string.IsNullOrWhiteSpace(dishName))
            throw new ArgumentException("Название блюда не может быть пустым.", nameof(dishName));
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Количество порций должно быть больше нуля.");
        if (pricePerPortion < 0)
            throw new ArgumentOutOfRangeException(nameof(pricePerPortion), "Цена не может быть отрицательной.");

        DishName = dishName;
        Quantity = quantity;
        PricePerPortion = pricePerPortion;
    }

    // Общая стоимость заказа = количество * цена за порцию
    public decimal CalculateTotal() => Quantity * PricePerPortion;

    public void PrintInfo()
    {
        Console.WriteLine($"Блюдо: {DishName}");
        Console.WriteLine($"Количество порций: {Quantity}");
        Console.WriteLine($"Цена за порцию: {PricePerPortion:F2} руб.");
        Console.WriteLine($"Общая стоимость: {CalculateTotal():F2} руб.");
        Console.WriteLine(new string('-', 30));
    }
}
