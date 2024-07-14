using Seraphinia_The_Forgotten_Kingdom.Models;

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Strength {get; set;}
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int ExperienceNeeded { get; set; }
    public int Experience { get; set; }
    public int Gold { get; set; }
    private List<Item> Inventory { get; set; }
    private Random Random;

    public Player()
    {
        Inventory = new List<Item>();
    }

    public void Setup()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("--------------------------------->");
        Console.WriteLine("Digite o nome do seu personagem:");
        Name = Console.ReadLine();
        Console.Clear();
        Level = 1;
        Health = 100;
        Strength = 10;
        MaxHealth = 100;
        Experience = 0;
        ExperienceNeeded = 100;
        Gold = 0;
    }

    public void DisplayStatus()
    {
        Console.Clear();
        Console.WriteLine("+------------------------>");
        Console.WriteLine("|   STATUS DO JOGADOR");
        Console.WriteLine("+------------------------>");
        Console.WriteLine($"| Nome: {Name}");
        Console.WriteLine($"| Nível: {Level}");
        Console.WriteLine($"| Vida: {Health}/{MaxHealth}");
        Console.WriteLine($"| Força: {Strength}");
        Console.WriteLine($"| Experiência: {Experience}/{ExperienceNeeded}");
        Console.WriteLine($"| Ouro: {Gold}");
        Console.WriteLine("+------------------------>");

        Console.WriteLine("| Inventário:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"| - {item.Name}");
        }
        Console.WriteLine("+------------------------>");
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public void Attack(Monster monster)
    {
        Random random = new Random();
        int damage = random.Next(10, 21); // Ataque básico entre 10 e 20 de dano
        monster.Health -= damage;
        Console.WriteLine($"\n+-{monster.Name} : {monster.Health}hp------------------------------->");
        Console.WriteLine($"| Você atacou o {monster.Name} causando {damage} de dano.");
    }


    public void GainGold(int amount)
    {
        Gold += amount;
        Console.WriteLine($"| Você ganhou {amount} unidades de ouro!");
    }

        public void GainExperience(int amount)
    {
        Experience += amount;
        Console.WriteLine("| Saque:");
        Console.WriteLine($"| Você ganhou {amount} pontos de experiência!");
        if (Experience >= ExperienceNeeded)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level++;
        MaxHealth += 12;
        Health = (int)(MaxHealth / 1.1);
        Experience -= ExperienceNeeded;
        ExperienceNeeded = (int)(ExperienceNeeded * 1.2);
        Random random = new Random();
        int damage = random.Next(5, 11); // Ataque básico entre 5 e 10 de dano
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("+-----------------------------------------------+");
        Console.WriteLine("|             Você subiu de nível!              |");
        Console.WriteLine("+-----------------------------------------------+");
        Console.ForegroundColor = ConsoleColor.White;

        if (Level % 10 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("+-----------------------------------------------+");
            Console.WriteLine("|          PREPARE-SE PARA O CHEFÃO!            |");
            Console.WriteLine("+-----------------------------------------------+");
            Health = MaxHealth;
        }
    }


    public void AddItem(Item item)
    {
        Inventory.Add(item);
        Console.WriteLine($"| Você obteve um(a) {item.Name}!");
        Console.WriteLine("+----------------------------------------------->");
    }

    public void GetRandomItem(Random random)
    {
        List<Item> items = new List<Item>
        {
            new Item("Espada Mágica", 15, 20),
            new Item("Armadura de Ferro", 10, 20),
            new Item("Anel de Força", 5, 20)
        };

        Item randomItem = items[random.Next(items.Count)];
        AddItem(randomItem);
    }

    public void UseItem()
    {
        if (Inventory.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n+---------------------------------+");
            Console.WriteLine("|  Você não tem itens para usar   |");
            Console.WriteLine("+---------------------------------+\n");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        Console.WriteLine("Escolha um item para usar:");
        for (int i = 0; i < Inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Inventory[i].Name}");
        }

        string input = Console.ReadLine();
        if (int.TryParse(input, out int choice) && choice > 0 && choice <= Inventory.Count)
        {
            Item item = Inventory[choice - 1];
            Health += item.HealingAmount;
            if (Health > MaxHealth)
                Health = MaxHealth;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine($"| Você usou {item.Name} e recuperou {item.HealingAmount} de vida.  |");
            Console.WriteLine("+--------------------------------------------------+");
            Inventory.RemoveAt(choice - 1);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção inválida.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public void BuyItem(Item item)
    {
        if (Gold >= item.Price)
        {
            Gold -= item.Price;
            AddItem(item);
            Console.WriteLine($"{Name} comprou {item.Name} por {item.Price} ouro.");
        }
        else
        {
            Console.WriteLine("Ouro insuficiente para comprar este item.");
        }
    }
}
