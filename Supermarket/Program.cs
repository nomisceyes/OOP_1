Supermarket supermarket = new Supermarket();
supermarket.FillingTheBasket();

class Supermarket
{
    private Queue<Client> _clients = new Queue<Client>(5);
    private List<Product> _products = new List<Product>();
    private Random _random = new Random();

    public Supermarket()
    {
        Product[] products = { new Product("Колбаса", 150), new Product("Хлеб", 40), new Product("Молоко", 60), new Product("Водка", 200), new Product("Картофель", 20) };
        _products.AddRange(products);
    }

    public void FillingTheBasket()
    {
        List<Product> basket = new List<Product>();
        
        for (int i = 0; i < 3; i++)
        {
            basket.Add(_products[_random.Next(_products.Count)]);

        }
        foreach (var product in basket)
        {
            product.ShowInfo();
        }
    }
    public void PurchaseAndSaleTransaction()
    {
       
    }
}
class Client
{
    public int AmountOfMoney { get; private set; }
    private Random _random = new Random();

    public Client(Product[] products)
    {
        AmountOfMoney = _random.Next(200, 500);
    }
    public void ShowAmountOfMoney()
    {
        Console.WriteLine($"Количество денег у покупателя: {AmountOfMoney}");
    }
}
class Product
{
    public string Name { get; private set; }
    public int Price { get; private set; }
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"{Name} стоит - {Price} рублей.");
    }
}