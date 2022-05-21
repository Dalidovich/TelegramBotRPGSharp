using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;
using TelegramBotRPG;

namespace YPTelegramBotRPG
{
    public static class Places
    {
        public static async void welcome(Message m, ITelegramBotClient botClient)
        {
            Player.refrechProperties();
            string messageFromBot = NotifyEvent.ToString() + Player.ToString();
            NotifyEvent.clearLines();
            await botClient.SendTextMessageAsync(m.Chat, messageFromBot, replyMarkup: InlineButtons.GetButtonsOnEmptyPlace());
        }
        public static async void endGame(Message m, ITelegramBotClient botClient)
        {
            string messageFromBot = NotifyEvent.ToString() + Player.ToString() + NotifyEvent.statistic();
            NotifyEvent.clearLines();
            await botClient.SendTextMessageAsync(m.Chat, messageFromBot, replyMarkup: InlineButtons.GetButtonsOnEndGame());
        }
        public static async void emptyPlace(Message m, ITelegramBotClient botClient)
        {
            string messageFromBot = NotifyEvent.ToString() + Player.ToString();
            NotifyEvent.clearLines();
            await botClient.SendTextMessageAsync(m.Chat, messageFromBot, replyMarkup: InlineButtons.GetButtonsOnEmptyPlace());
        }
        public static async void fightPlace(Message m, ITelegramBotClient botClient)
        {
            if (Enemy.deadCheck())
            {
                NotifyEvent.addMessage(Enemy.ToString());
                Player.coins++;
                NotifyEvent.countKills++;
                emptyPlace(m, botClient);
                return;
            }
            if (Player.deadCheck())
            {
                endGame(m, botClient);
                return;
            }
            string messageFromBot = NotifyEvent.ToString() + Player.ToString() + Enemy.ToString();
            NotifyEvent.clearLines();
            await botClient.SendTextMessageAsync(m.Chat, messageFromBot, replyMarkup: InlineButtons.GetButtonsOnFight());
        }
        public static async void playerDodge(Message m, ITelegramBotClient botClient)
        {
            string messageFromBot = NotifyEvent.ToString() + Player.ToString() + Enemy.ToString();
            NotifyEvent.clearLines();
            await botClient.SendTextMessageAsync(m.Chat, messageFromBot, replyMarkup: InlineButtons.GetButtonsOnDodge());
        }
        public static void roomsGenerator(Message m, ITelegramBotClient botClient)
        {
            Random rnd = new Random();
            switch (rnd.Next(1, 4))
            {
                case 1:
                    Console.WriteLine("chest");
                    break;
                case 2:
                    Console.WriteLine("altar");
                    break;
                case 3:
                    Enemy.setSelfProperties();
                    NotifyEvent.addMessage("you find enemy in room");
                    Places.fightPlace(m, botClient);
                    break;
                default:
                    break;
            }
        }
    }
    //def roomsGenerator(message):
    //fortuna=random.randint(1,4)
    //global en
    //if fortuna >= 3:
    //    en = createEnemy(pl)
    //    notifyEvent.addMessage("you find enemy in room")
    //    fightPlace(message)
    //elif fortuna == 2:
    //    chestPlace(message)
    //elif fortuna == 1:
    //    lifeAltarPlace(message)
}
