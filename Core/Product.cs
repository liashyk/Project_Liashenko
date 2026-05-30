namespace Core;

public class Product
{
    public Product() { }

    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    // business logic: total cost
    public decimal TotalPrice => Price * Quantity;

    // simple validation
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new System.ArgumentException("Name is required");
        if (Price < 0) throw new System.ArgumentOutOfRangeException(nameof(Price));
        if (Quantity < 0) throw new System.ArgumentOutOfRangeException(nameof(Quantity));
    }
}
