using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPTelegramBotRPG
{
    public static class Player
    {
        public static int maxHp=10;
        public static int curHp=10;
        public static int coins=0;
        public static int damage=2;
        public static int hpPotion=3;
        public static int damageFactor=1;
        public static int regenPower=2;

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
        public static void refreshProperties()
        {
            maxHp = 10;
            curHp = 10;
            coins = 0;
            damage = 2;
            hpPotion = 3;
            damageFactor = 1;
            regenPower = 2;
    }
        public static void atack()
        {
            Enemy.hp -= damage * damageFactor;
            NotifyEvent.countGiveDamage += damage * damageFactor;
            NotifyEvent.addMessage($"you GIVE {damage * damageFactor} damage");
            damageFactor = 1;
        }
        public static bool deadCheck() => curHp < 1;
        public static void dodge()
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
                Enemy.atack();
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
