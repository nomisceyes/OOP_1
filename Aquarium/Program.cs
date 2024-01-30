const string CommandAddFish = "1";
const string CommandRemoveFish = "2";
const string CommandeExit = "3";

Aquarium aquarium = new Aquarium();
string command;
bool isWork = true;

while (isWork)
{
    aquarium.ShowInfo();

    Console.WriteLine("1 - Добавить рыбу в аквариум\n2 - Убрать рыбу из аквариума");
    command = Console.ReadLine();

    switch (command)
    {
        case CommandAddFish:
            aquarium.AddFish();
            break;

        case CommandRemoveFish:
            aquarium.RemoveFish();
            break;

        case CommandeExit:
            isWork = false;
            break;
    }

    Console.ReadKey();
    aquarium.LifetimeFishes();
    Console.Clear();
}

class Aquarium
{
    private List<Fish> _fishes = new List<Fish>();

    public Aquarium()
    {
        Fish[] fish = { new Fish("Вобла", 10), new Fish("Скат", 7) };

        _fishes.AddRange(fish);
    }

    public void AddFish()
    {
        string name;
        int lifetime;

        if (_fishes.Count == 5)
        {
            Console.WriteLine("Аквариум заполнен.");
        }
        else
        {
            Console.Write("Введите название рыбы: ");
            name = Console.ReadLine();

            Console.Write("Введите время жизни рыбы: ");
            lifetime = Convert.ToInt32(Console.ReadLine());


            _fishes.Add(new Fish(name, lifetime));
        }
    }


public void RemoveFish()
{
    _fishes.Remove(SearchFish());
}

private Fish SearchFish()
{
    Console.WriteLine("Какую рыбу вы хотите убрать?");
    string name = Console.ReadLine();

    foreach (Fish fish in _fishes)
    {
        if (fish.Name.ToLower() == name.ToLower())
        {
            return fish;
        }
    }
    return null;
}

public void LifetimeFishes()
{
    foreach (Fish fish in _fishes)
    {
        if (fish.Lifetime > 0)
        {
            fish.Lifetime--;
        }
    }
}

public void ShowInfo()
{
    int positionX = 60;
    int positionY = 0;

    foreach (Fish fish in _fishes)
    {
        Console.SetCursorPosition(positionX, positionY);
        fish.ShowInfo();

        if (fish.Lifetime == 0)
        {
            fish.Lifetime = 0;

            positionX += 43;

            Console.SetCursorPosition(positionX, positionY);
            Console.WriteLine("Рыбу стоит убрать.");

            positionX = 60;
        }

        positionY++;
        Console.SetCursorPosition(0, 0);
    }
}
}

class Fish
{
    public string Name;
    public int Lifetime;

    public Fish(string name, int lifetime)
    {
        Name = name;
        Lifetime = lifetime;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Имя рыбы: {Name},оставшееся время жизни: {Lifetime}.");
    }
}