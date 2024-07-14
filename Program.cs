using System;
using System.Collections.Generic;
using System.Drawing;
using Seraphinia_The_Forgotten_Kingdom.Models;

class Program
{
    static void Main(string[] args)
    {   
        Console.CursorVisible = false;
        Console.SetCursorPosition(1, 1);
        
        for (int i = 0; i < 101; i++)
        {
            for (int y = 0; y < i; y++)
            {
                string pb = "\u2551";
                Console.Write(pb);
            }

            Console.Write(i + " / 100");
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("CARREGANDO O MUNDO...");
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n\n");
        Console.WriteLine("                                                        .-.");
        Console.WriteLine("                                                      __|=|__");
        Console.WriteLine("       +-Wellcome to---------------------------+     (_/`-`V_)");
        Console.WriteLine("       |   Seraphinia: The Forgotten Kingdom   |     ||V___/||");
        Console.WriteLine("       +---------------------------by LeoMarxs-+     <>/   V<>");
        Console.WriteLine("                                                      V|_._|/");
        Console.WriteLine("                                                       <_I_>");
        Console.WriteLine("                                                        |||");
        Console.WriteLine("                                                       /_|_V ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n\nPressione ENTER para iniciar!");
        Console.ReadLine();
        Console.Clear();


        Player player = new Player();
        player.Setup();

        History.Introducao(player);

        while (player.IsAlive())
        {
            Console.WriteLine("\nO que você gostaria de fazer?");
            Console.WriteLine("1. Explorar");
            Console.WriteLine("2. Ver status do jogador");
            Console.WriteLine("3. Sair do jogo");

            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {

                case "1":
                    Explore(player);
                    break;
                case "2":
                    player.DisplayStatus();
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("+-----------------------------+");
                    Console.WriteLine("|                             |             ______________ "); 
                    Console.WriteLine("|                             |             |            | ");
                    Console.WriteLine("|                             |             |Desenvolvido| ");
                    Console.WriteLine("|                             |             |    por     | ");
                    Console.WriteLine("|     Obrigado por jogar!     |             |  LeoMarxs  | ");
                    Console.WriteLine("|                             |             |____________| ");
                    Console.WriteLine("|                             |            ( __/) ||       ");
                    Console.WriteLine("|                             |            (•ㅅ•) ||       ");
                    Console.WriteLine("|                             |            /    づ         ");
                    Console.WriteLine("|                             |");
                    Console.WriteLine("+-----------------------------+\n");   
                    return;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nComando inválido. Tente novamente.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }
        }
    }
    

  static void Explore(Player player)
    {
        Random random = new Random();
        int encounterChance = random.Next(1, 101);

        if (player.Level % 10 == 0) // Enfrentar chefão a cada 10 níveis
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Boss boss = BossGenerator.GenerateBoss();
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            Console.WriteLine($" Você encontrou um CHEFÃO: {boss.Name}!");
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

            while (player.IsAlive() && boss.IsAlive())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nO que você gostaria de fazer?");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Usar item");
                Console.WriteLine("3. Fugir");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        player.Attack(boss);
                        if (boss.IsAlive())
                            boss.Attack(player);
                        break;
                    case "2":
                        player.UseItem();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                        Console.WriteLine("Você não pode fugir de um chefão!");
                        Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\n");
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Comando inválido. Tente novamente.");
                        break;
                }
            }

            if (player.IsAlive())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("+----------------------------------------------->");
                Console.WriteLine($"| Você derrotou o CHEFÃO: {boss.Name}!");
                Console.WriteLine("+----------------------------------------------->");
                Console.ForegroundColor = ConsoleColor.White;
                player.GainExperience(boss.Experience);
                player.GainGold(boss.Gold);
                player.AddItem(boss.Item);
            }
            else
            {
                GameOver();
            }
        }
        else
        {

            if (encounterChance <= 60)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Monster monster = MonsterGenerator.GenerateMonster();
                Console.WriteLine($"Você encontrou um {monster.Name}!");

                while (player.IsAlive() && monster.IsAlive())
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nO que você gostaria de fazer?");
                    Console.WriteLine("1. Atacar");
                    Console.WriteLine("2. Usar item");
                    Console.WriteLine("3. Fugir");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Console.Clear();
                            player.Attack(monster);
                            if (monster.IsAlive())
                                monster.Attack(player);
                            break;
                        case "2":
                            player.UseItem();
                            break;
                        case "3":
                            Console.WriteLine("\nVocê fugiu!");
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Comando inválido. Tente novamente.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }

                if (player.IsAlive())
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("+----------------------------------------------->");
                    Console.WriteLine($"| Você derrotou o {monster.Name}!");
                    Console.WriteLine("+----------------------------------------------->");
                    Console.ForegroundColor = ConsoleColor.White;
                    player.GainExperience(monster.Experience);
                    player.GainGold(monster.Gold);
                    player.AddItem(monster.Item);
                }
                else
                {
                    GameOver();
                }
            }
            else
            {
                Console.WriteLine("Você não encontrou nada de interessante.");
            }
        }
    }

    static void GameOver()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n+-----------------------------+");
        Console.WriteLine("|     Você foi derrotado!     |");
        Console.WriteLine("+-----------------------------+");
        Console.WriteLine("|       Tente novamente       |");
        Console.WriteLine("+-----------------------------+\n\n");

    } 
}
