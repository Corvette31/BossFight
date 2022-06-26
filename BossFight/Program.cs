using System;

namespace BossFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string userInput = "";
            #region Player
            float playerHealth;
            float playerMaxHealth;
            int playerHealthMinValue = 300;
            int playerHealthMaxValue = 501;
            float playerArmor;
            float playerArmorCurrent = 0;
            float playerBlockedArmor ;
            int playerArmorMinValue = 20;
            int playerArmorMaxValue = 70;
            float playerDamage;
            float playerDamageCurrent = 0;
            int playerDamageMinValue = 50;
            int playerDamageMaxValue = 101;
            #endregion
            #region Ally
            float allyDamage;
            int allyDamageMinValue = 50;
            int allyDamageMaxValue = 151;
            bool isAllyCalled = false; 
            int allyMove;
            int allyMoveCurrent = 0;
            int allyMoveMinValue = 3;
            int allyMoveMaxValue = 6;
            int allyCooldown;
            bool isAllyCooldown = false;
            int allyCooldownCurrent = 0; 
            int allyCooldownMinValue = 2;
            int allyCooldownMaxValue = 5;
            float costAllyCalled;
            int costAllyCalledMinValue = 50;
            int costAllyCalledMaxValue = 151;
            #endregion
            #region DebuffAttack
            float debuffDamage;
            int debuffDamageMinValue = 100;
            int debuffDamageMaxValue = 300;
            int debuffMove;
            int debuffMoveCurrent = 0;
            int debuffMoveMinValue = 2;
            int debuffMoveMaxValue = 6;
            bool isRunDebuffDamage = false; 
            #endregion
            #region RecoveryHealth;
            float recoveryHealth;
            int recoveryHealthMinValue = 50;
            int recoveryHealthMaxValue = 200;
            int recoveryHealthCooldown;
            float recoveryHealthCooldownCurrent = 0;
            int recoveryHealthCooldownMinValue = 2;
            int recoveryHealthCooldownMaxValue = 5;
            bool isRunRecoveryHealthCooldown = false;
            #endregion
            #region Berserk
            float criticalDamage = 0;
            float criticalDamageRatio = 2.5f;
            int criticalDamageChance;
            int criticalDamageChanceMinValue = 30;
            int criticalDamageChanceMaxValue = 80;
            bool isCriticalDamageRun = false;
            int criticalDamageMove;
            int criticalDamageMoveCurrent;
            int criticalDamageMoveMinValue = 2;
            int criticalDamageMoveMaxValue = 6;
            int criticalDamageCooldown;
            int criticalDamageCooldownCurrent = 0;
            int criticalDamageCooldownMinValue = 2;
            int criticalDamageCooldownMaxValue = 5;
            int percentHealth;
            int percentHealthMinValue = 25;
            int percentHealthMaxValue = 50;
            int calculatingPercent = 100;
            bool isCriticalDamageCooldown = false;
            float playerHealthToActivate;
            int zeroValue = 0;
            #endregion
            #region Enemy
            float enemyHealth;
            int enemyHealthMinValue = 500;
            int enemyHealthMaxValue = 1001;
            float enemyArmor;
            int enemyArmorMinValue = 5;
            int enemyArmorMaxValue = 15;
            float enemyDamage;
            int enemyDamageMinValue = 100;
            int enemyDamageMaxValue = 200;
            float enemyBlockedArmor;
            bool causeDamage = true;
            #endregion

            playerHealth = random.Next(playerHealthMinValue, playerHealthMaxValue);
            playerMaxHealth = playerHealth;
            playerDamage = random.Next(playerDamageMinValue, playerDamageMaxValue);
            playerArmor = random.Next(playerArmorMinValue, playerArmorMaxValue);
            allyDamage = random.Next(allyDamageMinValue, allyDamageMaxValue);
            costAllyCalled = random.Next(costAllyCalledMinValue, costAllyCalledMaxValue);
            allyMove = random.Next(allyMoveMinValue, allyMoveMaxValue);
            allyCooldown = random.Next(allyCooldownMinValue, allyCooldownMaxValue);
            debuffDamage = random.Next(debuffDamageMinValue, debuffDamageMaxValue);
            debuffMove = random.Next(debuffMoveMinValue, debuffMoveMaxValue);
            recoveryHealth = random.Next(recoveryHealthMinValue, recoveryHealthMaxValue);
            recoveryHealthCooldown = random.Next(recoveryHealthCooldownMinValue, recoveryHealthCooldownMaxValue);
            criticalDamageChance = random.Next(criticalDamageChanceMinValue, criticalDamageChanceMaxValue);
            criticalDamageMove = random.Next(criticalDamageMoveMinValue, criticalDamageMoveMaxValue);
            criticalDamageCooldown = random.Next(criticalDamageCooldownMinValue, criticalDamageCooldownMaxValue);
            percentHealth = random.Next(percentHealthMinValue, percentHealthMaxValue);
            playerHealthToActivate = playerHealth - (playerHealth / calculatingPercent * percentHealth);

            enemyHealth = random.Next(enemyHealthMinValue, enemyHealthMaxValue);
            enemyDamage = random.Next(enemyDamageMinValue, enemyDamageMaxValue);
            enemyArmor = random.Next(enemyArmorMinValue, enemyArmorMaxValue);

            allyMoveCurrent = allyMove;
            debuffMoveCurrent = debuffMove;
            recoveryHealthCooldownCurrent = recoveryHealthCooldown;
            criticalDamage = criticalDamageRatio * playerDamage;
            criticalDamageMoveCurrent = criticalDamageMove;
            criticalDamageCooldownCurrent = criticalDamageCooldown;

            Console.WriteLine("Ослепший старый маг, ночью по лесу бродил, на кладбище разлил, он волшебный элексир... услышав огромного злова орка...\nПриготовьтесь к сражению!");
            Console.WriteLine($"\nВаш маг имеет {playerHealth} здоровья, умеет делать следующие заклинания :") ;
            Console.WriteLine($"1 Черная молния - стандартное заклинание, сила атаки : {playerDamage}");
            Console.WriteLine($"2 Призыв духа - призывает духа павшего война, который наносит противнику {allyDamage} ед. урона, но в замен отнимает у игрока {costAllyCalled} здоровья");
            Console.WriteLine($"    Союзник доступен в течении {allyMove} ходов, время до повторного призыва {allyCooldown} ходов");
            Console.WriteLine($"3 Вечная боль - в течении {debuffMove} ходов, наносит противнику {debuffDamage} урона.");
            Console.WriteLine("    Заклинание может быть использовано, только с Призывом духа");
            Console.WriteLine($"4 Чувство света - магическое всечение восстанавливает магу {recoveryHealth} здоровья, при этом делает его не уязвимым к атаке врага на один ход");
            Console.WriteLine($"    Заклинание может быть повторно использовано через {recoveryHealthCooldown} ходов");
            Console.WriteLine($"5 Первозданная ярость - маг на {criticalDamageMove} ходов становится берсерком, может нанести в {criticalDamageRatio} раза больше урона");
            Console.WriteLine($"    с шансом {criticalDamageChance} %, дополнительно дает магу {playerArmor} % брони");
            Console.WriteLine($"    Заклинание может быть использовано, когда у мага остается меньше {playerHealthToActivate} здоровья");
            Console.WriteLine($"    Заклинание может быть повторно использовано через {criticalDamageCooldown} ходов");
            Console.WriteLine($"\nУ противника {enemyHealth} здоровья, {enemyDamage} силы атаки и {enemyArmor} % брони\n");

            while (playerHealth > 0 && enemyHealth > 0)
            {
                Console.WriteLine("Введите номер заклинания для атаки :");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        playerDamageCurrent = playerDamage + criticalDamage;
                        enemyBlockedArmor = playerDamageCurrent / calculatingPercent * enemyArmor;
                        enemyHealth -= playerDamageCurrent - enemyBlockedArmor;
                        Console.WriteLine($"Заклинанием : \"Черная молния\" маг нанес врагу {playerDamage + criticalDamage} урона, броней заблокировано {enemyBlockedArmor} урона. У противника осталось {enemyHealth} здоровья");
                        break;
                    case "2":
                        if (isAllyCalled == false)
                        {
                            if (isAllyCooldown)
                            {                            
                                Console.WriteLine($"Вы не можете призывать духа еще {allyCooldownCurrent} ход");
                            }
                            else
                            {
                                isAllyCalled = true;
                                allyMoveCurrent = allyMove;
                                playerHealth -= costAllyCalled;
                                Console.WriteLine($"Вы призвали духа, но получили при этом {costAllyCalled} повреждений. У вас осталось {playerHealth} здоровья ");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Призванный дух еще активен {allyMoveCurrent} хода! Вы не можете призывать повторно духа");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        break;
                    case "3":
                        if (isAllyCalled)
                        {
                            if (isRunDebuffDamage == false && debuffMoveCurrent > 0)
                            {
                                isRunDebuffDamage = true;
                                Console.WriteLine($"Вы приминили заклинание Вечная боль, теперь противнику будет дополнительно наносится по {debuffDamage} в течении {debuffMove} ходов");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Вы не можете повторно приминить заклинание Вечная боль");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Вы не можете повторно заклинание Вечная боль не призвав союзного духа!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        break;
                    case "4":
                        if (isRunRecoveryHealthCooldown == false)
                        {
                            playerHealth += recoveryHealth;
                            isRunRecoveryHealthCooldown = true;

                            if (playerHealth > playerMaxHealth)
                            {
                                playerHealth = playerMaxHealth;
                            }

                            Console.WriteLine($"Заклинанием Чувство света было восстановлено {recoveryHealth} здоровья. У вас теперь {playerHealth} здоровья");
                            Console.WriteLine("Из-за активного заклинания Чувство света, противник не смог нанести вам урон");
                            causeDamage = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Вы не можете повторно заклинание Чувство света в течении {recoveryHealthCooldownCurrent} ходов");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        break;
                    case "5":
                        if (isCriticalDamageRun == false)
                        {
                            if (isCriticalDamageCooldown)
                            {
                                Console.WriteLine($"Вы не можете использовать заклинание Первозданная ярость еще {criticalDamageCooldownCurrent} ход");
                            }
                            else if (playerHealth > playerHealthToActivate)
                            {
                                Console.WriteLine($"У вас не достаточно здоровья для активации данного залинания, требуется менее {playerHealthToActivate} , у вас {playerHealth}");
                            } else
                            {
                                isCriticalDamageRun = true;
                                criticalDamageMoveCurrent = criticalDamageMove;
                                Console.WriteLine($"Вы приминили заклинание Первозданная ярость, теперь у мага есть {criticalDamageChance} % вероятности нанести {criticalDamage} урона. Броня мага составляет {playerArmor}");
                                Console.WriteLine($"Время эффекта {criticalDamageMove} ходов, перезарядка заклинания {criticalDamageCooldown} ходов");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine($"Вы не можете повторно использовать заклинание Первозданная ярость в течении {criticalDamageMoveCurrent} ходов");

                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        break;
                    default:
                        Console.WriteLine("Не корректаня команда, вы пропускаете ход!");
                        break;
                }
                
                //Призыв союзника
                if (isAllyCalled)
                {
                    enemyBlockedArmor = allyDamage / calculatingPercent * enemyArmor;
                    enemyHealth -= allyDamage - enemyBlockedArmor;
                    
                    Console.WriteLine($"Призванный дух нанес врагу {allyDamage} урона, броней заблокировано {enemyBlockedArmor} урона. У противника осталось {enemyHealth} здоровья");
                    Console.WriteLine($"Дух будет активен еще {allyMoveCurrent} хода");

                    allyMoveCurrent--;

                    if (allyMoveCurrent == 0)
                    {
                        isAllyCalled = false;
                        isAllyCooldown = true;
                        allyCooldownCurrent = allyCooldown;
                    }
                }
                if (isAllyCooldown)
                {
                    allyCooldownCurrent--;

                    if (allyCooldownCurrent == 0)
                    {
                        allyCooldownCurrent = allyCooldown;
                        isAllyCooldown = false;
                    }
                }

                //Дебафф противника
                if (isRunDebuffDamage)
                {
                    enemyBlockedArmor = debuffDamage / calculatingPercent * enemyArmor;
                    enemyHealth -= debuffDamage - enemyBlockedArmor;

                    Console.WriteLine($"Заклинанием \"Вечная боль\" нанесено врагу {debuffDamage} урона, броней заблокировано {enemyBlockedArmor} урона. У противника осталось {enemyHealth} здоровья");
                    Console.WriteLine($"Заклинание будет активено еще {debuffMoveCurrent} хода");

                    debuffMoveCurrent--;

                    if(debuffMoveCurrent == 0)
                    {
                        isRunDebuffDamage = false;
                        debuffMoveCurrent = debuffMove;
                    }
                }

                //Берсерк
                if (isCriticalDamageRun)
                {
                    criticalDamage = Convert.ToInt32(random.Next(zeroValue, ++criticalDamageChance) <= criticalDamageChance) * criticalDamageRatio * playerDamage;
                    playerArmorCurrent = playerArmor;

                    criticalDamageMoveCurrent--;

                    if (criticalDamageMoveCurrent == 0)
                    {
                        isCriticalDamageRun = false;
                        isCriticalDamageCooldown = true;
                    } 
                }
                if (isCriticalDamageCooldown)
                {
                    criticalDamageCooldownCurrent--; 

                    if (criticalDamageCooldownCurrent == 0)
                    {
                        criticalDamageCooldownCurrent = criticalDamageCooldown;
                        isCriticalDamageCooldown = false;
                    }
                }
                //Урон врагом
                playerBlockedArmor = (enemyDamage / calculatingPercent) * playerArmorCurrent;

                if (causeDamage)
                {
                    playerHealth -= enemyDamage - playerBlockedArmor;
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Орк нанес магу {enemyDamage} урона, броней заблокировано {playerBlockedArmor} урона. У вас осталось {playerHealth} здоровья");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                //Восстановление здоровья
                if (isRunRecoveryHealthCooldown)
                {
                    recoveryHealthCooldownCurrent--;
                    causeDamage = true;

                    if (recoveryHealthCooldownCurrent == 0)
                    {
                        recoveryHealthCooldownCurrent = recoveryHealthCooldown;
                        isRunRecoveryHealthCooldown = false;

                    }
                }

            }

            if (playerHealth <= 0 && enemyHealth <=0)
            {
                Console.WriteLine("Ничья!");
            }
            else if (playerHealth > 0)
            {
                Console.WriteLine("Вы победили!");
            } else
            {
                Console.WriteLine("Противник победил!");
            }
            Console.WriteLine("Игра окончена!");
        }
    }
}
