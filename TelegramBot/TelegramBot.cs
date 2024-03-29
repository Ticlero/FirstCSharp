﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramBot.Properties;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Helpers;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using System.IO;
namespace TelegramBot
{
    public partial class TelegramBot : Form
    {
        private static readonly Telegram.Bot.TelegramBotClient Bot = new TelegramBotClient("910742741:AAGNwe-O-F2U2pw9bN41AbTQhGDIGv4L41k");

        private readonly static string Usage = @"사용법 : 
/예린 - 오빠가 사랑하는 마음을 듬뿍 담아 사랑해 라는 말을 해준다.

/며칠 - 2017년 풋풋했던 대학생때 만나 현재 까지의 사귄 날짜를 말 해준다!
(/ㅁㅊ ,/며칠 가능)
/사랑해 오빠가 사랑하는 마음을 더욱 더 듬뿍 담아 사랑해 라는 말을 해준다.
/인라인 - 개발중
/키보드 - 개발중";

        public TelegramBot()
        {
            InitializeComponent();
        }

        private async void TelegramAPI()
        {
            //var Bot = new Telegram.Bot.TelegramBotClient("910742741:AAGNwe-O-F2U2pw9bN41AbTQhGDIGv4L41k");
            //var me = await Bot.GetMeAsync();
            this.Text = "My_TelegramBot";
            var me = Bot.GetMeAsync().Result;
            Console.WriteLine("Hello My name is {0}", me.FirstName);

            Bot.OnMessage += BotOnMessageReceived;


            Bot.OnMessageEdited += BotOnMessageReceived;

            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;

            Bot.OnInlineQuery += BotOnInlineQueryReceived;

            Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;

            
            Bot.StartReceiving(Array.Empty<UpdateType>());
            //Bot.StopReceiving();
        }

        

        private void TelegramBot_Load(object sender, EventArgs e)
        {
            TelegramAPI();
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message == null || message.Type != MessageType.Text)
                return;

            if(e.Message.Type == MessageType.Text)
            {
                if(e.Message.Text == "/예린")
                {
                    //var response = Bot.SendTextMessageAsync(chatId: "@YRSHlovenews", "hello");
                    //Console.WriteLine(response);
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "예린아 사랑해~~ 오빠가");
                }else if(e.Message.Text == "/며칠?" || e.Message.Text == "/ㅁㅊ" || e.Message.Text == "/며칠" )
                {
                    string datingDate = new DateTime(2017, 04, 04).ToShortDateString();
                    string nowDate = DateTime.Now.ToShortDateString();
                    TimeSpan span = DateTime.Parse(nowDate) - DateTime.Parse(datingDate);
                    string dDay = span.ToString();
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, $"우리가 벌써 사귄지! " + dDay.Substring(0,3) + "일 이나 됐오!!♥♥♥♥♥♥♥" 
                        + e.Message.Chat.Username);
                }
                else if (e.Message.Text == "/사랑해")
                {
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, @"울 사당둥이 이뿌니 린둥이 링뽀!
오빠도 많이많이 사당해여!!
♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥
♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥");

                }
                else if(e.Message.Text == "/인라인")
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                   {
                        new [] // first row
                        {
                            InlineKeyboardButton.WithCallbackData("1.1"),
                            InlineKeyboardButton.WithCallbackData("1.2"),
                            

                        },
                        new [] // second row
                        {
                            InlineKeyboardButton.WithCallbackData("2.1"),
                            InlineKeyboardButton.WithCallbackData("2.2")
                        }
                    });
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Choose", replyMarkup: inlineKeyboard);
                }else if(e.Message.Text == "/키보드")
                {
                    ReplyKeyboardMarkup ReplyKeyboard = new[]
                    {
                        new[] { "1.1" , "1.2", "1.3" },
                        new[] { "2.1", "2.2" },
                    };

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "골라주세요~",
                        replyMarkup: ReplyKeyboard);
                }
                else if(e.Message.Text == "/요청")
                {
                    var RequestReplyKeyboard = new ReplyKeyboardMarkup(new[]
                    {
                        KeyboardButton.WithRequestLocation("Location"),
                        KeyboardButton.WithRequestContact("Contact")
                    });

                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Who or Where are you?", replyMarkup:RequestReplyKeyboard);
                }
                else
                {
                    await Bot.SendTextMessageAsync(e.Message.Chat.Id, Usage, replyMarkup: new ReplyKeyboardRemove());

                }
            }
            //await Bot.SendTextMessageAsync(message.Chat.Id, message.Text);            
        }

        /*
        private static async void BotOnInlineQueryReceived(object sender, ChosenInlineResultEventArgs e)
        {
            InlineQueryResultBase[] results = {
                new InlineQueryResultLocation(
                    id: "1",
                    latitude: 40.7058316f,
                    longitude: -74.2581888f,
                    title: "New York")   // displayed result
                    {
                        InputMessageContent = new InputLocationMessageContent(
                            latitude: 40.7058316f,
                            longitude: -74.2581888f)    // message if result is selected
                    },

                new InlineQueryResultLocation(
                    id: "2",
                    latitude: 13.1449577f,
                    longitude: 52.507629f,
                    title: "Berlin") // displayed result
                    {
                        InputMessageContent = new InputLocationMessageContent(
                            latitude: 13.1449577f,
                            longitude: 52.507629f)   // message if result is selected
                    }
            };

            await Bot.AnswerInlineQueryAsync(
                e.ChosenInlineResult.InlineMessageId,
                results,
                isPersonal: true,
                cacheTime: 0);
        }
        */
        private static async void BotOnInlineQueryReceived(object sender, InlineQueryEventArgs inlineQueryEventArgs)
        {
            Console.WriteLine($"Received inline query from: {inlineQueryEventArgs.InlineQuery.From.Id}");

            InlineQueryResultBase[] results = {
                new InlineQueryResultLocation(
                    id: "1",
                    latitude: 40.7058316f,
                    longitude: -74.2581888f,
                    title: "New York")   // displayed result
                    {
                        InputMessageContent = new InputLocationMessageContent(
                            latitude: 40.7058316f,
                            longitude: -74.2581888f)    // message if result is selected
                    },

                new InlineQueryResultLocation(
                    id: "2",
                    latitude: 13.1449577f,
                    longitude: 52.507629f,
                    title: "Berlin") // displayed result
                    {
                        InputMessageContent = new InputLocationMessageContent(
                            latitude: 13.1449577f,
                            longitude: 52.507629f)   // message if result is selected
                    }
            };

            await Bot.AnswerInlineQueryAsync(
                inlineQueryEventArgs.InlineQuery.Id,
                results,
                isPersonal: true,
                cacheTime: 0);
        }


        private static void BotOnChosenInlineResultReceived(object sender, ChosenInlineResultEventArgs chosenInlineResultEventArgs)
        {
            Console.WriteLine($"Received inline result: {chosenInlineResultEventArgs.ChosenInlineResult.ResultId}");
        }

        //인라인 응답 이벤트
        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            await Bot.AnswerCallbackQueryAsync(
                callbackQuery.Id,
                $"Received {callbackQuery.Data}");

            await Bot.SendTextMessageAsync(
                callbackQuery.Message.Chat.Id,
                $"Received {callbackQuery.Data}");
        }



    }
}
