Player player = new Player("Bob","Tank",17);

player.ShowInfo();


class Player
{
    private string _name;
    private string _role;
    private int _level;

    public Player(string name, string role, int level)
    {
        _name = name;
        _role = role;
        _level = level;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Name: {_name} \nRole: {_role} \nLevel: {_level}");
    }
}