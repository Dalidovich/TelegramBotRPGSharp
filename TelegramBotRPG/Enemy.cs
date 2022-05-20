using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPTelegramBotRPG
{
    public static class Enemy
    {
        public static int hp=1;
        public static int damage=1;

        //public Enemy(int hp, int damage)
        //{
        //    this.hp = hp;
        //    this.damage = damage;
        //}
        //public Enemy()
        //{
        //    int playerPower = ((Player.curHp + Player.damage) / 2) - 2;
        //    int enemyDamage = 1;
        //    int enemyHp = 1;
        //    while (playerPower > 0)
        //    {
        //        Random rnd = new Random();
        //        if (rnd.Next(0, 2) == 0)
        //        {
        //            enemyDamage += 1;
        //        }
        //        else
        //        { 
        //            enemyHp += 1;
        //        }
        //        playerPower -= 1;
        //    }
        //    this.hp = enemyHp;
        //    this.damage = enemyDamage;
        //}
        public static void setSelfProperties()
        {
            int playerPower = ((Player.curHp + Player.damage) / 2) - 2;
            int enemyDamage = 1;
            int enemyHp = 1;
            while (playerPower > 0)
            {
                Random rnd = new Random();
                if (rnd.Next(0, 2) == 0)
                {
                    enemyDamage += 1;
                }
                else
                {
                    enemyHp += 1;
                }
                playerPower -= 1;
            }
            hp = enemyHp;
            damage=enemyDamage;
        }
        public static void atack()
        {
            if (!Player.deadCheck())
            {
                Player.curHp -= damage;
                NotifyEvent.countTakeDamage += damage;
                NotifyEvent.addMessage($"you TAKE {damage} damage");
            }
        }
        public static bool deadCheck() => hp < 1;
        public static new string ToString()
        {
            if (deadCheck())
            {
                return "enemy dead";
            }
            else
            {
                return $"enemy hp: {hp}\n" +
                       $"enemy damage: {damage}\n";
            }
        }
    }
}
