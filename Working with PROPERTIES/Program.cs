Player player = new Player(10, 10);
Renderer renderer = new Renderer();

renderer.DrawPlayer(player.X, player.Y);

class Player
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Player(int x, int y)
    {
        X = x;
        Y = y;
    }


}

class Renderer
{
    public void DrawPlayer(int x, int y, char ch = '@')
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(ch);
    }
}