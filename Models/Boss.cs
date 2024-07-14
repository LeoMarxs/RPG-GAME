using Seraphinia_The_Forgotten_Kingdom.Models;

class Boss : Monster
{
    public Boss(string name, int health, int experience, int gold, Item item)
        : base(name, health, experience, gold, item)
    {
    }
}
