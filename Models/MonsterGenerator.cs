using Seraphinia_The_Forgotten_Kingdom.Models;

static class MonsterGenerator
{
    private static Random random = new Random();

    public static Monster GenerateMonster()
    {
        string[] names = { "Esqueleto", "Goblin", "Ogro", "Dragão", "Saqueador", "Morto Vivo", "Lobo" };
        string name = names[random.Next(names.Length)];

        int health = random.Next(50, 101); // Saúde entre 50 e 100
        int experience = random.Next(20, 41); // Experiência entre 20 e 40
        int gold = random.Next(10, 36); // Ouro entre 10 e 35

        // Suponha que todos os monstros tenham uma poção de cura como item
        Item item = new Item("Poção de Cura", 25, 20); // Cura 25 de vida

        return new Monster(name, health, experience, gold, item);
    }
}
