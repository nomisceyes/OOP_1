Arena arena = new Arena();
string command;
bool isExit = false;

while (isExit != true)
{
    Console.WriteLine("Добро пожаловать на арену!\n\n");
    Console.WriteLine("1 - Посмотреть персонажей\n2 - Выбрать бойцов\n3 - БОЙ");
    command = Console.ReadLine();

    switch (command)
    {
        case "1":
            arena.ShowCharacters();
            break;
        case "2":
            arena.ChooseCharacters();
            break;
            break;
        case "3":
            arena.Combat();
            break;
    }

    Console.ReadKey();
    Console.Clear();
}
class Arena
{
    Character firstCharacter;
    Character secondCharacter;
    private List<Character> _characters = new List<Character>();
    public Arena()
    {
        _characters.Add(new Paladin());
        _characters.Add(new Warrior());
        _characters.Add(new Hunter());
        _characters.Add(new Rouge());
        _characters.Add(new Wizard());
    }
    public void ShowCharacters()
    {
        foreach (Character character in _characters)
        {
            character.ShowInfo();
            Console.WriteLine();
        }
    }

    public void Combat()
    {
        if (firstCharacter != null && secondCharacter != null)
        {
            while (firstCharacter.Health > 0 && secondCharacter.Health > 0)
            {
                firstCharacter.ShowHealth();
                if (secondCharacter.Health <= 0) { }
                secondCharacter.ShowHealth();

                Console.WriteLine();
                Console.WriteLine("-----------------------------");

                if (firstCharacter.Health <= 0)
                {
                    Console.WriteLine($"Победил {secondCharacter.Name}! ГЦ у него осталось {secondCharacter.Health} здоровья");
                    break;
                }

                firstCharacter.Attack(secondCharacter);

                if (secondCharacter.Health <= 0)
                {
                    Console.WriteLine($"Победил {firstCharacter.Name}! у него осталось {firstCharacter.Health} здоровья");
                    break;
                }

                secondCharacter.Attack(firstCharacter);
            }
            ClearFirstCharacter();
            ClearSecondCharacter();
        }
    }
    public void ShowFirstCharacter()
    {
        Console.WriteLine("Первый боец:");
        firstCharacter.ShowInfo();
    }
    public void ShowSecondCharacter()
    {
        Console.WriteLine("Второй боец:");
        secondCharacter.ShowInfo();
    }
    public void ChooseCharacters()
    {
        Character[] characters = { firstCharacter, secondCharacter };
        int firstNumberCharacter = 0;
        int secondNumberCharacter;

        for (int i = 0; i < characters.Length; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("Выберите первого бойца: ");
                firstNumberCharacter = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < _characters.Count; j++)
                {
                    if (firstNumberCharacter == j + 1)
                    {
                        firstCharacter = _characters[j];
                    }
                }
                ShowFirstCharacter();
            }
            else
            {
                Console.WriteLine("Выберите второго бойца: ");
                secondNumberCharacter = Convert.ToInt32(Console.ReadLine());
                if (secondNumberCharacter != firstNumberCharacter)
                {
                    for (int j = 0; j < _characters.Count; j++)
                    {
                        if (secondNumberCharacter == j + 1)
                        {
                            secondCharacter = _characters[j];
                        }
                    }
                    ShowSecondCharacter();
                }
                else
                {
                    Console.WriteLine("Герой занят, выберите другого.");
                }
            }
        }
    }
    public void ClearFirstCharacter()
    {
        firstCharacter = null;
    }
    public void ClearSecondCharacter()
    {
        secondCharacter = null;
    }
}
class Wizard : Character
{
    int chanseSummonCrystallShards = 25;
    int amountCrystallShards = 0;
    int damageCrystallShard = 20;
    bool summonCrystallShards = false;
    int chanseArcanBlast = 15;
    int damageArcanBlast = 100;
    public Wizard() : base("Волшебник", 150, 5, 15) { }

    public override void Attack(Character target)
    {
        ArcaneBlaste(target);
        if (amountCrystallShards == 0)
        {
            if (random.Next(ChanseOfSuccess) >= ChanseOfSuccess - chanseSummonCrystallShards)
            {
                Console.WriteLine("Волшебник призывает кристальные осколки над головой.");
                summonCrystallShards = true;
                amountCrystallShards = 5;
            }
        }
        if (summonCrystallShards == true)
        {
            target.TakeDamage(damageCrystallShard);
            amountCrystallShards--;
        }
    }
    private void ArcaneBlaste(Character target)
    {
        if (random.Next(ChanseOfSuccess) >= ChanseOfSuccess - chanseArcanBlast)
        {
            Console.WriteLine($"Волшебник выпускает чародейский выстрел");
            target.TakeDamage(damageArcanBlast);
        }
        else
        {
            target.TakeDamage(Damage);
        }
    }
}
class Rouge : Character
{
    int _kidneyChanse = 35;
    int kidneyDamage = 45;
    public Rouge() : base("Разбойник", 200, 5, 15) { }

    public override void Attack(Character target)
    {
        if (random.Next(ChanseOfSuccess) >= ChanseOfSuccess - _kidneyChanse)
        {
            Console.WriteLine("Разбойник наносит подлый удар из-за которого противник выходит из строя.");
            target.TakeDamage(kidneyDamage);
        }
        else
        {
            target.TakeDamage(Damage);
        }
    }
}
class Warrior : Character
{
    private int _cleaveChanse = 50;
    private double _damageMultiplier = 1.5;
    public Warrior() : base("Воин", 250, 10, 20) { }

    public override void Attack(Character target)
    {
        int cleaveDamage = (int)(Damage * _damageMultiplier);
        if (random.Next(ChanseOfSuccess) > ChanseOfSuccess - _cleaveChanse)
        {
            Console.WriteLine("Воин наносит рассекающий удар.");
            target.TakeDamage(cleaveDamage);
        }
        else
        {
            target.TakeDamage(Damage);
        }
    }
}
class Hunter : Character
{
    private int _criticalDamageMultiplier = 3;
    private int _chanseCriticalDamage = 30;
    public Hunter() : base("Охотник", 200, 5, 20) { }

    public override void Attack(Character target)
    {
        int criticalDamage = (Damage * _criticalDamageMultiplier);

        Console.WriteLine("Охотник находит уязвимое место и пытается попасть.");

        if (random.Next(ChanseOfSuccess) >= ChanseOfSuccess - _chanseCriticalDamage)
        {
            Console.WriteLine("Охотник попадает прямо в цель!");
            target.TakeDamage(criticalDamage);
        }
        else
        {
            Console.WriteLine("Охх..Наверное,трудно попасть в движущуюся цель");
            target.TakeDamage(Damage);
        }
    }
}
class Paladin : Character
{
    private int _castChanse = 15;
    public Paladin() : base("Паладин", 300, 10, 25) { }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        HolyLight();
    }
    private void HolyLight()
    {
        int amountRecoveredHealth = 50;

        if (random.Next(ChanseOfSuccess) >= ChanseOfSuccess - _castChanse)
        {
            Console.WriteLine("Свет дарует мне победу!");
            RestorHealth(amountRecoveredHealth);
            Console.WriteLine($"Паладин восстанавливает {amountRecoveredHealth} здоровья.");
        }
    }
}
abstract class Character
{
    protected int ChanseOfSuccess = 100;
    protected Random random = new Random();

    public string Name { get; private set; }
    public int Health { get; private set; }
    public int CurrentHealth { get; private set; }
    public int Armor { get; private set; }
    public int Damage { get; private set; }

    public Character(string name, int health, int armor, int damage)
    {
        Name = name;
        Health = health;
        CurrentHealth = Health;
        Armor = armor;
        Damage = damage;
    }
    public virtual void Attack(Character target)
    {
        Console.WriteLine($"{Name} совершает удар нанеся - {Damage} урона");
        target.TakeDamage(Damage);
    }
    public virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            damage = 0;
        }
        if (Health < 0)
        {
            Health = 0;
        }
        if (damage - Armor < 0)
        {
            Health -= 0;
        }
        Console.WriteLine($"{Name} принимает удар получив - {damage - Armor} урона");
        Health -= damage - Armor;
    }
    public void ShowHealth()
    {
        Console.Write($"{Health}/{CurrentHealth} ---");
    }
    public void RestorHealth(int quantityHealth)
    {
        if (Health + quantityHealth > CurrentHealth)
        {
            Health = CurrentHealth;
        }
        else
        {
            Health += quantityHealth;
        }
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Класс - {Name}\nЗдоровье - {Health}\nБроня - {Armor}\nУрон - {Damage}");
    }
}