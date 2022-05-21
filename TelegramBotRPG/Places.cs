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
                    Places.chestPlace(m, botClient);
                    break;
                case 2:
                    Places.lifeAltarPlace(m, botClient);
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
        public static void chestPlace(Message m, ITelegramBotClient botClient)
        {
            Random rnd = new Random();
            string messageFromBot = "you find chest.\n";
            int choose = rnd.Next(0, 2);
            if (choose == 0)
            {
                messageFromBot += "you found new weapon in chest";
                Player.damage += 1;
            }
            else if (choose == 1)
            {
                messageFromBot += "you found coins in chest";
                Player.coins += 1;
            }
            else
            {
                int countPotion = rnd.Next(1, 3);
                messageFromBot += $"you found {countPotion} hp potion in chest";
                Player.hpPotion += countPotion;
            }
            NotifyEvent.addMessage(messageFromBot);
            Places.emptyPlace(m,botClient);
        }
        public static void lifeAltarPlace(Message m, ITelegramBotClient botClient)
        {
            string messageFromBot = "you find life altar.\nWhat do you want to improve?";
            NotifyEvent.clearLines();
            botClient.SendTextMessageAsync(m.Chat.Id, messageFromBot,replyMarkup: InlineButtons.GetButtonsOnLifeAltar());

        }
    //    def lifeAltarPlace(message):
    //markup = types.InlineKeyboardMarkup(row_width=2)
    //itembtn1 = types.InlineKeyboardButton('potion power', callback_data='pu')
    //itembtn2 = types.InlineKeyboardButton('max hp', callback_data='hu')
    //markup.add(itembtn1, itembtn2)
    //messageFromBot = "you find life altar.\nWhat do you want to improve?"
    //notifyEvent.clearLines()
    //bot.edit_message_text(text= messageFromBot, chat_id= message.chat.id, message_id= message.message_id, reply_markup= markup)
    //# bot.send_message(message.chat.id, messageFromBot, reply_markup=markup)

    }
}
