using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPTelegramBotRPG
{
    public class Player
    {
        public int maxHp;
        public int curHp;
        public int coins;
        public int damage;
        public int hpPotion;
        public int damageFactor;
        public int regenPower;

        public Player(int maxHp, int curHp, int coins, int damage, int hpPotion, int damageFactor=1, int regenPower=2)
        {
            this.maxHp = maxHp;
            this.curHp = curHp;
            this.coins = coins;
            this.damage = damage;
            this.hpPotion = hpPotion;
            this.damageFactor = damageFactor;
            this.regenPower = regenPower;
        }
        public double avgHp()=>(this.maxHp+this.curHp)/2;
        public override string ToString()
        {
            return $"HP: {this.curHp}/{this.maxHp}\n" +
                   $"DAMAGE: {this.damage}\n" +
                   $"COINS: {this.coins}\n" +
                   $"HP POTION: {this.hpPotion}\n" +
                   $"POTION REGEN {this.regenPower}\n\n";
        }
        public Enemy atack(Enemy enemy)
        {
            enemy.hp -= this.damage * this.damageFactor;
            NotifyEvent.countGiveDamage += this.damage * this.damageFactor;
            NotifyEvent.addMessage($"you GIVE {this.damage * this.damageFactor} damage");
            this.damageFactor = 1;
            return enemy;
        }
        public bool deadCheck() => this.curHp < 1;
        public Player dodge(Enemy enemy,Player player)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 1)
            {
                this.damageFactor = 2;
                NotifyEvent.addMessage("you dodge, you can hit in bag, use potion or escape from enemy");
            }
            else
            {
                NotifyEvent.addMessage("you not dodge, loser");
                player=enemy.atack(this);
            }
            return player;
        }
        public void useHpPotion()
        {
            NotifyEvent.addMessage($"you regen {this.regenPower} health points");
            this.hpPotion -= 1;
            NotifyEvent.countRegenPoints += this.regenPower;
            this.curHp += this.regenPower;
            this.curHp = this.curHp > this.maxHp ? this.maxHp : this.curHp;
        }
    }
}
