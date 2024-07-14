
namespace Seraphinia_The_Forgotten_Kingdom.Models
{
    public class Item
    {
        public string Name { get; internal set; }
        public int HealingAmount { get; internal set; }
        public int Price { get; internal set; }

        public Item(string name, int healingAmount, int price)
        {
            Name = name;
            HealingAmount = healingAmount;
            Price = price;
        }
    }
}