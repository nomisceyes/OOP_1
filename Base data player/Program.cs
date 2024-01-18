const string AddPlayerCommand = "add";
const string ShowPlayersCommand = "show";
const string BanPlayerCommand = "ban";
const string UnbanPlayerCommand = "unban";
const string DeletePlayerCommand = "delete";
const string ExitPlayerCommand = "exit";

string command;
bool isExit = false;
Database database = new Database();

while (isExit != true)
{
    Console.WriteLine($"{AddPlayerCommand} add player \n{ShowPlayersCommand} show player stats\n{BanPlayerCommand} ban player\n{UnbanPlayerCommand} unban player\n{DeletePlayerCommand} delete player\n{ExitPlayerCommand} exit.");
    command = Console.ReadLine();

    switch (command)
    {
        case AddPlayerCommand:
            database.AddPlayer();
            break;
        case ShowPlayersCommand:
            database.ShowInfo();
            break;
        case BanPlayerCommand:
            database.BanPlayer();
            break;
        case UnbanPlayerCommand:
            database.UnbanPlayer();
            break;
        case DeletePlayerCommand:
            database.DeletePlayer();
            break;
        case ExitPlayerCommand:
            isExit = true;
            break;
        default:
            Console.WriteLine("Wrong command.");
            break;

    }
    Console.ReadKey();
    Console.Clear();
}


class Database
{
    List<Player> _players = new List<Player>();
    public void AddPlayer()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Player player = new Player(name);
        _players.Add(player);
    }

    public void ShowInfo()
    {
        foreach (var player in _players)
        {
            player.ShowStats();
        }
    }

    public void BanPlayer()
    {
        if (TryGetPlayer(out Player player))
        {
            player.Ban();
        }
    }

    public void UnbanPlayer()
    {
        if (TryGetPlayer(out Player player))
        {
            player.Unban();
        }
    }

    public void DeletePlayer()
    {
        if (TryGetPlayer(out Player player))
        {
            _players.Remove(player);
        }
    }

    public bool TryGetPlayer(out Player player)
    {
        Console.Write("Enter id: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            foreach (var _player in _players)
            {
                if (_player.ID == id)
                {
                    player = _player;
                    return true;
                }
            }

            player = null;
            Console.WriteLine("Wrong id!");
            return false;
        }
        else
        {
            player = null;
            Console.WriteLine("Wrong id!");
            return false;
        }
    }
}

class Player
{
    public string Name { get; private set; }
    public int ID { get; private set; }
    public int Level { get; private set; }
    public bool IsActive { get; private set; }

    public Player(string name)
    {
        Random random = new Random();

        Name = name;
        ID = random.Next(10, 30);
        Level = random.Next(10, 80);
        IsActive = true;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Name - {Name}\nID - {ID}\nLevel - {Level}\nIsActive - {IsActive}");
    }

    public void Ban()
    {
        if (IsActive == true)
        {
            IsActive = false;
            Console.WriteLine("Player was banned.");
        }
        else
        {
            Console.WriteLine("Player is already banned.");
        }
    }

    public void Unban()
    {
        if (IsActive == false)
        {
            IsActive = true;
            Console.WriteLine("Player was unbanned.");
        }
        else
        {
            Console.WriteLine("Player is already active.");
        }
    }
}