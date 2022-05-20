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
            await botClient.SendTextMessageAsync(m.Chat, messageFromBot,replyMarkup: InlineButtons.GetButtonsOnEmptyPlace());
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
            string messageFromBot = NotifyEvent.ToString() + Player.ToString()+Enemy.ToString();
            NotifyEvent.clearLines();
            await botClient.SendTextMessageAsync(m.Chat, messageFromBot, replyMarkup: InlineButtons.GetButtonsOnDodge());
        }
    }
}
