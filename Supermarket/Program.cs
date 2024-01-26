Supermarket supermarket = new Supermarket();
supermarket.WorkShop();

class Supermarket
{
    private Queue<Client> _clients = new Queue<Client>();
    private List<Product> _products = new List<Product>();
    private Random _random = new Random();
    private int _money = 0;

    public Supermarket()
    {
        int _minCountClients = 5;
        int _maxCountClients = 9;
        int clientsCount = _random.Next(_minCountClients, _maxCountClients);

        Product[] products = { new Product("Колбаса", 150),
                               new Product("Хлеб", 40),
                               new Product("Молоко", 60),
                               new Product("Водка", 200),
                               new Product("Картофель", 20)
                             };

        _products.AddRange(products);

        for (int i = 0; i < clientsCount; i++)
        {
            _clients.Enqueue(new Client(_random.Next(200, 500), FillingBasket()));
        }
    }

    public void WorkShop()
    {
        Console.WriteLine("Добро пожаловать!");

        while (_clients.Count > 0)
        {
            ServeClient(_clients.Dequeue());
        }
    }

    private List<Product> FillingBasket()
    {
        List<Product> productBasket = new List<Product>();

        for (int i = 0; i < _random.Next(1, _products.Count); i++)
        {
            productBasket.Add(_products[_random.Next(_products.Count)]);
        }
        return productBasket;
    }

    private void ServeClient(Client client)
    {
        client.BuyProducts();
        Console.ReadKey();
        Console.Clear();
    }
}

class Client
{
    private List<Product> _basket = new List<Product>();
    private Random _random = new Random();
    private int _purchaseAmount;
    private int _amountOfMoney;

    public Client(int amountOfMoney, List<Product> products)
    {
        _amountOfMoney = amountOfMoney;
        _basket.AddRange(products);
    }

    public int BuyProducts()
    {
        ShowAmountOfMoney();
        BasketPrice();

        if (_amountOfMoney >= _purchaseAmount)
        {
            PayBasket();
        }
        else
        {
            RemoveProductFromBasket();
            PayBasket();
        }

        return _purchaseAmount;
    }

    private void RemoveProductFromBasket()
    {
        while (_amountOfMoney < _purchaseAmount)
        {
            int indexRemoveProduct = _random.Next(_basket.Count);

            Console.WriteLine($"Клиент убирает из корзины: {_basket[indexRemoveProduct].Name}");

            _basket.RemoveAt(indexRemoveProduct);

            BasketPrice();
        }
    }

    private void BasketPrice()
    {
        _purchaseAmount = 0;

        foreach (var product in _basket)
        {
            _purchaseAmount += product.Price;
            Console.WriteLine(product.Name + "-" + product.Price);
        }

        Console.WriteLine($"Итоговая сумма: {_purchaseAmount}");
        Console.ReadKey();
    }

    private void PayBasket()
    {
        _amountOfMoney -= _purchaseAmount;
        _basket.Clear();
        Console.WriteLine($"Остаток денег: {_amountOfMoney}");
    }

    public void ShowAmountOfMoney()
    {
        Console.WriteLine($"Количество денег у покупателя: {_amountOfMoney}");
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