using System;

namespace BossFight
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandAttack = "1";
            const string CommandSoulStones = "2";
            const string CommandPowerfulAttack = "3";
            const string CommandHeal = "4";

            int playerHealth = 2500;
            int maxPlayerHealthValue;
            int playerMana = 800;
            int maxManaValue;
            int bossHealth = 10000;
            int bossDamage = 50;
            int simpleDamage = 100;
            int powerfulDamage = 500;
            int soulStones = 3;
            int playerSoulStones = 0;
            int heal = 150;
            int manaToHeal = 50;
            int damageIntoPlayer = 100;
            int multipier = 2;
            int manaRegeneration = 10;
            string userInput;

            maxManaValue = playerMana;
            maxPlayerHealthValue = playerHealth;

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine($"Перед вами босс, у которого {bossHealth} жизней, который наносит {bossDamage} урона.");
                Console.WriteLine($"\nУ вас {playerHealth} жизней, {playerSoulStones} камней душ, {playerMana} маны.\n");
                Console.WriteLine($"{CommandAttack} - атака, которая наносит {simpleDamage} урона и заполняет один камень души.");
                Console.WriteLine($"{CommandSoulStones} - мощная атака, котороая выпускает все накопленные души и наносит {powerfulDamage} урона. Для активации требует {soulStones} камней души.");
                Console.WriteLine($"{CommandPowerfulAttack} - способность, которая выжигает всю ману, игрок жертвует {damageIntoPlayer} хп, наносит боссу урон соразмерный отнятой мане х{multipier}.");
                Console.WriteLine($"{CommandHeal} - способность, восстанавливающая {heal} жизней. Требует {manaToHeal} маны.");
                Console.WriteLine("Выберите способность");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAttack:
                        bossHealth -= simpleDamage;
                        playerSoulStones++;
                        break;

                    case CommandSoulStones:
                        if (playerSoulStones >= soulStones)
                        {
                            bossHealth -= powerfulDamage;
                            playerSoulStones -= soulStones;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно камней душ. Вы теряете ход");
                            Console.ReadKey();
                        }

                        break;

                    case CommandPowerfulAttack:
                        bossHealth -= playerMana * multipier;
                        playerMana = 0;
                        break;

                    case CommandHeal:
                        if (playerMana >= manaToHeal)
                        {
                            playerHealth += heal;
                            playerMana -= manaToHeal;

                            if (playerHealth > maxPlayerHealthValue)
                            {
                                playerHealth = maxPlayerHealthValue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно камней душ. Вы теряете ход");
                            Console.ReadKey();
                        }

                        break;
                }

                playerHealth -= bossDamage;
                playerMana += manaRegeneration;

                if (playerMana > maxManaValue)
                {
                    playerMana = maxManaValue;
                }

                Console.Clear();
            }

            if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("Оба мертвы.");
            }
            else if (playerHealth > 0 && bossHealth <= 0)
            {
                Console.WriteLine("Игрок победил.");
            }
            else
            {
                Console.WriteLine("Босс победил.");
            }
        }
    }
}
