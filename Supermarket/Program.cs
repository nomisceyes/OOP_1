Supermarket supermarket = new Supermarket();
supermarket.ShowProducts();
supermarket.AddBasket();
class Supermarket
{
    private Queue<Client> _clients = new Queue<Client>(5);
    private Dictionary<string, int> _products = new Dictionary<string, int>();
    private Random _random = new Random();
    public Supermarket()
    {

        string[] name = { "Картофель", "Молоко", "Пиво", "Вода", "Чипсы", "Колбаса", "Сыр" };
        int[] price = { 20, 50, 50, 30, 130, 200, 190 };

        for (int i = 0; i < name.Length; i++)
        {
            for (int j = 0; j < price.Length; j++)
            {
                _products.Add(name[i], price[j]);
            }
        }
    }
    public void ShowProducts()
    {
        foreach(var product in _products)
        {
            Console.WriteLine(product.Key + " - " + product.Value);
        }
    }
    public void AddBasket()
    {
        for(int i = 0; i < _clients.Count; i++)
        {
            _clients[i] = _random.Next(_products);
            Console.WriteLine(_clients[i]);
        } 
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
}
class Product
{
    public string Name { get; private set; }
    public int Price { get; private set; }
    public Product(string name, int price)
    {
        name = Name;
        price = Price;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"{Name} стоит - {Price} рублей.");
    }
}