using Seraphinia_The_Forgotten_Kingdom.Models;

public class Monster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Experience { get; set; }
    public int Gold { get; set; }
    public Item Item { get; set; }

    public Monster(string name, int health, int experience, int gold, Item item)
    {
        Name = name;
        Health = health;
        Experience = experience;
        Gold = gold;
        Item = item;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public void Attack(Player player)
    {
        Random random = new Random();
        int damage = random.Next(5, 11); // Ataque básico entre 5 e 10 de dano
        player.Health -= damage;
        Console.WriteLine($"| O {Name} atacou você causando {damage} de dano.");
    }
}
