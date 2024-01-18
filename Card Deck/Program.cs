Deck deck = new Deck();
Player player = new Player();
string command;
bool isExit = false;

deck.FillDeck();

while (isExit != true)
{
    Console.WriteLine("1 - взять карту 2 - выйти");
    command = Console.ReadLine();
    switch (command)
    {
        case "1":
            player.TakeCard(deck);
            break;
        case "2":
            isExit = true;  
            break;
    }
    player.ShowHand();
}

class Player
{
    private List<Card> _cards = new List<Card>();
    private Random _rand = new Random();

    public void TakeCard(Deck deck)
    {
        if (deck.GetSize() > 0)
        {
            _cards.Add(deck.IssueCard(_rand.Next(0, deck.GetSize())));
            Console.WriteLine("Вы берете карту из колоды.");
        }
        else
        {
            Console.WriteLine("В колоде недостаточно карт.");
        }
    }

    public void ShowHand()
    {
        foreach (var card in _cards)
        {
            card.ShowInfo();
        }
    }
}

class Deck
{
    private int _minCardNumber = 6;
    private int _maxCardNumber = 10;
    private string[] _suits = { "Черви", "Бубны", "Крести", "Пики" };
    private List<Card> _cards = new List<Card>();

    public int GetSize()
    {
        return _cards.Count;
    }

    public void FillDeck()
    {
        foreach (var suit in _suits)
        {
            for (int i = _minCardNumber; i < _maxCardNumber; i++)
            {
                _cards.Add(new Card(suit, i));
            }
        }
    }

    public Card IssueCard(int index)
    {
        Card card = _cards[index];
        _cards.RemoveAt(index);
        return card;
    }

    public void Show()
    {
        foreach (var card in _cards)
        {
            card.ShowInfo();
        }
    }
}

class Card
{
    private string _suit;
    private int _number;

    public Card(string suit, int number)
    {
        _suit = suit;
        _number = number;
    }

    public void ShowInfo()
    {
        Console.WriteLine(_number + _suit);
    }
}