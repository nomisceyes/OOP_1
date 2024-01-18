Player player = new Player();
Vendor vendor = new Vendor();
string command;
bool isExit = false;

while (isExit != true)
{
    Console.WriteLine("1 - купить предмет\n2 - посмотреть товар\n3 - посмотреть инвентарь игрока\n4 - выйти");
    command = Console.ReadLine();

    switch (command)
    {
        case "1":
            vendor.Sell(player);
            break;
        case "2":
            vendor.ShowItems();
            break;
        case "3":
            player.ShowPlayerItems();
            break;
        case "4":
            isExit = true;
            break;
    }
}
class Player
{
    private Inventory _inventory = new Inventory();

    public void BuyItem(Item item)
    {
        _inventory.AddItem(item);
    }

    public void ShowPlayerItems()
    {
        _inventory.ShowItems();
    }
}
class Vendor
{
    private Inventory _inventory = new Inventory();

    public Vendor()
    {
        Item[] items = { new Item("меч"), new Item("щит"), new Item("зелье") };
        _inventory.AddSomeItems(items);
    }

    public void ShowItems()
    {
        _inventory.ShowItems();
    }

    public void Sell(Player player)
    {
        Console.Write("Что вы хотите купить? - ");
        string itemName = Console.ReadLine();

        if (_inventory.TryGetItem(out Item item, itemName))
        {
            player.BuyItem(item);
            _inventory.DeleteItem(item);
        }
    }
}
class Inventory
{
    private List<Item> _items = new List<Item>();

    public void AddSomeItems(Item[] items)
    {
        _items.AddRange(items);
    }
    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void DeleteItem(Item item)
    {
        _items.Remove(item);
    }

    public void ShowItems()
    {
        foreach (var item in _items)
        {
            item.Show();
        }
    }
    public bool TryGetItem(out Item item, string itemName)
    {
        foreach (var _item in _items)
        {
            if (_item.Name == itemName)
            {
                item = _item;
                return true;
            }
        }
        item = null;
        return false;
    }
}
class Item
{
    public string Name { get; private set; }

    public Item(string name)
    {
        Name = name;
    }

    public void Show()
    {
        Console.WriteLine(Name);
    }
}