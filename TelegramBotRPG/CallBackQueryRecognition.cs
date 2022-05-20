using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using YPTelegramBotRPG;

namespace TelegramBotRPG
{
    public static class CallBackQueryRecognition
    {
        public static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            switch (callbackQuery.Data)
            {
                case "q":
                    Places.endGame(callbackQuery.Message, botClient);
                    break;
                case "nr":
                    Enemy.setSelfProperties();
                    Places.fightPlace(callbackQuery.Message, botClient);
                    break;
                case "a":
                    if (!Enemy.deadCheck())
                    {
                        Player.atack();
                        Enemy.atack();
                        Places.fightPlace(callbackQuery.Message,botClient);
                    }
                    else
                    {
                        Places.emptyPlace(callbackQuery.Message, botClient);
                    }
                    break;
                case "d":
                    if(!Enemy.deadCheck())
                    {
                        Player.dodge();
                        if (Player.damageFactor == 2)
                        {
                            Places.playerDodge(callbackQuery.Message, botClient);
                        }
                        else
                        {
                            Places.fightPlace(callbackQuery.Message, botClient);
                        }
                    }
                    else
                    {
                        Places.emptyPlace(callbackQuery.Message, botClient);
                    }
                    break;
                default:
                    break;
            }
            //await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "lol", replyMarkup: InlineButtons.GetButtonsOnEmptyPlace());
            return;
        }
    }
}
