using System;
using System.Threading;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game Manager
            bool endGame = false;
            bool endMainMenu = false;
            bool endAttackSelect = true;

            //Main Menu Initilization
            string option = null;
            int optionNumber = 0;

            //Player Setting
            int playerHealth = 100;
            string attackSelected = null;
            int attackSelectedNumber = 0;
            int attackDmg = 0;
            bool playerDied = false;
            int playerWins = 20;
            int playerLoses = 22;
            //Enemy
            int enemyHealth = 100;
            int enemyDmg = 0;
            bool enemyDied = false;

            //Game Start
            while (endGame == false)
            {
                endMainMenu = false;

                option = null;
                optionNumber = 0;

                playerHealth = 100;
                attackSelected = null;
                attackSelectedNumber = 0;
                attackDmg = 0;
                playerDied = false;

                enemyHealth = EnemyHealth(enemyHealth, playerWins);
                enemyDmg = 0;
                enemyDied = false;


                while (endMainMenu == false)
                {
                    Console.Clear();
                    MainMenu();
                    option = Console.ReadLine();
                    optionNumber = Convert.ToInt16(option);

                    if (optionNumber == 1)
                    {
                        endMainMenu = true;
                    }
                }

                MenuSwitiching(optionNumber, enemyHealth, playerHealth);

                if (optionNumber == 1)
                {

                    while (enemyDied != true && playerDied != true)
                    {
                        //Resetting the health bars
                        Console.Clear();
                        PlayerHealth(playerHealth, playerLoses);

                        BattleMenu(enemyHealth, playerHealth);

                        //Player Selecting Attck
                        attackSelected = Console.ReadLine();
                        attackSelectedNumber = Convert.ToInt32(attackSelected);

                        //Player Damaging the enemy
                        attackDmg = PlayerAttackDamage(attackSelectedNumber, attackDmg);
                        enemyHealth -= attackDmg;

                        //Enemy Damaging the player
                        enemyDmg = EnemyAttackDamage(enemyDmg);
                        playerHealth -= enemyDmg;


                        if (enemyHealth <= 0)
                        {
                            enemyHealth = 0;
                            Console.Clear();
                            enemyDied = true;
                            playerWins++;
                            WinScreen(playerDied, enemyDied, playerWins, playerLoses);
                        }
                        else if (playerHealth <= 0)
                        {
                            playerHealth = 0;
                            Console.Clear();
                            playerDied = true;
                            playerLoses++;
                            WinScreen(playerDied, enemyDied, playerWins, playerLoses);
                        }
                    }

                }

                endGame = false;
            }
        }

        static void MainMenu()
        {
            //MENU SIZING
            Console.Title = "Main Menu";

            int width = 50;
            int height = 15;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            //END MENU SIZING

            //Spacers
            string dashes = new string('-', width - 2);
            string emptySpacer = new string(' ', width - 2);
            //END Spacers

            Console.Write($"/{dashes}\\"); //TOP

            for (int i = 1; i < height - 2; i++)
            {
                Console.Write($"|{emptySpacer}|");
            }

            Console.Write($"\\{dashes}/"); //BOTTOM

            Console.SetCursorPosition(19, 4);
            Console.Write("Option: ");

        }

        static void BattleMenu(int enemyHealth, int playerHealth)
        {
            //MENU SIZING
            Console.Title = "Battle Menu";

            int width = 50;
            int height = 15;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            //END MENU SIZING

            //Spacers
            string dashes = new string('-', width - 2);
            string emptySpacer = new string(' ', width - 2);
            //END Spacers

            Console.Write($"/{dashes}\\"); //TOP

            for (int i = 1; i < height - 2; i++)
            {
                Console.Write($"|{emptySpacer}|");
            }

            Console.Write($"\\{dashes}/"); //BOTTOM

            Console.SetCursorPosition(0, 8);
            Console.Write($"|{dashes}|");

            Console.SetCursorPosition(1, 9);
            Console.Write("1. Slash");

            Console.SetCursorPosition(1, 10);
            Console.Write("2. Shield");

            Console.SetCursorPosition(1, 1);
            Console.Write($"Enemy Health: {enemyHealth}");

            Console.SetCursorPosition(31, 7);
            Console.Write($"Player Health: {playerHealth}");

            Console.SetCursorPosition(18, 10);
            Console.Write($"Attack: ");


        }

        static void UpgradeMenu()
        {
            //MENU SIZING
            Console.Title = "Upgrade Menu";

            int width = 50;
            int height = 15;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            //END MENU SIZING

            //Spacers
            string dashes = new string('-', width - 2);
            string emptySpacer = new string(' ', width - 2);
            //END Spacers

            Console.Write($"/{dashes}\\"); //TOP

            for (int i = 1; i < height - 2; i++)
            {
                Console.Write($"|{emptySpacer}|");
            }

            Console.Write($"\\{dashes}/"); //BOTTOM

            Console.SetCursorPosition(19, 4);
            Console.Write("Upgrade Menu");

        }

        static void MenuSwitiching(int optionNumber, int enemyHealth, int playerHealth)
        {
            switch (optionNumber)
            {
                case 1:
                    BattleMenu(enemyHealth, playerHealth);
                    break;
                /* case 2:
                    UpgradeMenu();
                    break;
                    */
                default:
                    break;
            }
        }

        static int PlayerAttackDamage(int attackSelectedNumber, int attackDmg)
        {
            Random playerAttackRandomizer = new Random();

            switch (attackSelectedNumber)
            {
                case 1:
                    attackDmg = playerAttackRandomizer.Next(4, 6);
                    break;
                case 2:
                    attackDmg = playerAttackRandomizer.Next(10, 12);
                    break;
                default:
                    break;
            }

            return attackDmg;

        }

        static int PlayerHealth(int playerHealth, int playerLoses)
        {
            //playerHealth = 0; 

            if (playerLoses >= 20)
            {
                playerHealth = playerHealth + 80;
            }
            else if (playerLoses >= 15 && playerLoses <= 19)
            {
                playerHealth = playerHealth + 60;
            }
            else if (playerLoses >= 10 && playerLoses <= 14)
            {
                playerHealth = playerHealth + 30;
            }
            else if (playerLoses >= 5 && playerLoses <= 9)
            {
                playerHealth = playerHealth + 25;
            }
            else
            {
                playerHealth = playerHealth + 15;
            }
            return playerHealth;
        }
        static int EnemyAttackDamage(int enemyDmg)
        {
            Random enemyAttackRandomizer = new Random();
            int enemyAttack = enemyAttackRandomizer.Next(1, 4);
            // enemyAttack = enemyAttack / 10;

            switch (enemyAttack)
            {
                case 1:
                    enemyDmg = enemyAttackRandomizer.Next(0);
                    break;
                case 2:
                    enemyDmg = enemyAttackRandomizer.Next(0);
                    break;
                default:
                    break;
            }

            return enemyDmg;

        }

        static int EnemyHealth(int enemyHealth, int playerWins)
        {
            Random enemyHealthRNG = new Random();

            if (playerWins >= 20)
            {
                enemyHealth = enemyHealthRNG.Next(150, 201);
            }
            else if (playerWins >= 15 && playerWins <= 19)
            {
                enemyHealth = enemyHealthRNG.Next(125, 149);
            }
            else if (playerWins >= 10 && playerWins <= 14)
            {
                enemyHealth = enemyHealthRNG.Next(100, 125);
            }
            else if (playerWins >= 5 && playerWins <= 9)
            {
                enemyHealth = enemyHealthRNG.Next(100, 111);
            }
            else
            {
                enemyHealth = enemyHealthRNG.Next(100, 101);
            }
            return enemyHealth;
        }

        static void WinScreen(bool playerDied, bool enemyDied, int playerWins, int playerLoses)
        {
            //MENU SIZING
            Console.Title = "Results";

            int width = 25;
            int height = 10;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            //END MENU SIZING

            if (playerDied == true)
            {
                Console.WriteLine("YOU LOSS!");
                // Console.WriteLine($"Lose:{playerLoses}");
                Thread.Sleep(5000);
            }
            else if (enemyDied == true)
            {
                Console.WriteLine("YOU WIN!");
                Console.WriteLine($"Win:{playerWins}");
                Thread.Sleep(5000);
            }
        }

    }
}
