using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPTelegramBotRPG
{
    public class Enemy
    {
        public int hp;
        public int damage;

        public Enemy(int hp, int damage)
        {
            this.hp = hp;
            this.damage = damage;
        }
        public Enemy(Player player)
        {
            int playerPower = ((player.curHp + player.damage) / 2) - 2;
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
            this.hp = enemyHp;
            this.damage = enemyDamage;
        }
        public Player atack(Player player)
        {
            if (!player.deadCheck())
            {
                player.curHp -= this.damage;
                NotifyEvent.countTakeDamage += this.damage;
                NotifyEvent.addMessage($"you TAKE {this.damage} damage");
            }
            return player;
        }
        public bool deadCheck() => this.hp < 1;
        public override string ToString()
        {
            if (this.deadCheck())
            {
                return "enemy dead";
            }
            else
            {
                return $"enemy hp: {this.hp}\n" +
                       $"enemy damage: {this.damage}";
            }
        }
    }
}
