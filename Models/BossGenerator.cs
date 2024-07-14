using Seraphinia_The_Forgotten_Kingdom.Models;
// Gerador de chefões
class BossGenerator
{
    private static Random random = new Random();

    public static Boss GenerateBoss()
    {
        string[] names = { "Dragão Ancião", "Titã das Trevas", "Demônio Supremo", "Rei Esqueleto", "Fenrir" };
        string name = names[random.Next(names.Length)];

        int damage = random.Next(10, 26);
        int health = random.Next(200, 251); // Saúde entre 200 e 250
        int experience = random.Next(250, 351); // Experiência entre 250 e 350
        int gold = random.Next(50, 121); // Ouro entre 50 e 120

        // Suponha que todos os chefões tenham um item especial
        Item item = new Item("Elixir Supremo", 65, 20); // Cura 65 de vida


        return new Boss(name, health, experience, gold, item);
    }
}
