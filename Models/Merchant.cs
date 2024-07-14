using Seraphinia_The_Forgotten_Kingdom.Models;

class Merchant
{
    private List<Item> itemsForSale;

    public Merchant()
    {
        itemsForSale = new List<Item>
        {
            new Item("Poção de Vida", 0, 20),
            new Item("Espada Longa", 20, 100),
            new Item("Escudo de Aço", 10, 80)
        };
    }

    public void Interact(Player player)
    {
        Console.WriteLine("Bem-vindo à minha loja! Veja meus itens à venda:");

        for (int i = 0; i < itemsForSale.Count; i++)
        {
            Item item = itemsForSale[i];
            Console.WriteLine($"{i + 1}. {item.Name} - {item.Price} ouro (Força: +{item.HealingAmount})");
        }

        Console.WriteLine("Digite o número do item que deseja comprar ou '0' para sair.");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int choice) && choice > 0 && choice <= itemsForSale.Count)
        {
            Item selectedItem = itemsForSale[choice - 1];
            player.BuyItem(selectedItem);
        }
        else
        {
            Console.WriteLine("Até a próxima!");
        }
    }
}
