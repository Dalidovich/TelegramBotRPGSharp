using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPTelegramBotRPG
{
    public static class Player
    {
        public static int maxHp;
        public static int curHp;
        public static int coins;
        public static int damage;
        public static int hpPotion;
        public static int damageFactor;
        public static int regenPower;

        //public Player(int maxHp, int curHp, int coins, int damage, int hpPotion, int damageFactor=1, int regenPower=2)
        //{
        //    this.maxHp = maxHp;
        //    this.curHp = curHp;
        //    this.coins = coins;
        //    this.damage = damage;
        //    this.hpPotion = hpPotion;
        //    this.damageFactor = damageFactor;
        //    this.regenPower = regenPower;
        //}
        public static double avgHp()=>(maxHp+curHp)/2;
        public static new string ToString()
        {
            return $"HP: {curHp}/{maxHp}\n" +
                   $"DAMAGE: {damage}\n" +
                   $"COINS: {coins}\n" +
                   $"HP POTION: {hpPotion}\n" +
                   $"POTION REGEN {regenPower}\n\n";
        }
        public static Enemy atack(Enemy enemy)
        {
            enemy.hp -= damage * damageFactor;
            NotifyEvent.countGiveDamage += damage * damageFactor;
            NotifyEvent.addMessage($"you GIVE {damage * damageFactor} damage");
            damageFactor = 1;
            return enemy;
        }
        public static bool deadCheck() => curHp < 1;
        public static void dodge(Enemy enemy)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 1)
            {
                damageFactor = 2;
                NotifyEvent.addMessage("you dodge, you can hit in bag, use potion or escape from enemy");
            }
            else
            {
                NotifyEvent.addMessage("you not dodge, loser");
                enemy.atack();
            }
        }
        public static void useHpPotion()
        {
            NotifyEvent.addMessage($"you regen {regenPower} health points");
            hpPotion -= 1;
            NotifyEvent.countRegenPoints += regenPower;
            curHp += regenPower;
            curHp = curHp > maxHp ? maxHp : curHp;
        }
    }
}
