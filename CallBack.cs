using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Keyboard;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace Cursovaya_Bot
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallBack : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IVkApi _vkApi;
        public CallBack(IVkApi vkApi, IConfiguration configuration)
        {
            _configuration = configuration;
            _vkApi = vkApi;
        }

        [HttpPost]
        public IActionResult Callback([FromBody] JSON updates)
        {
            switch (updates.Type)
            {
                case "confirmation":
                    {
                        return Ok(_configuration["Config:Confirmation"]);
                    }

                case "message_new":
                    {
                        var msg = Message.FromJson(new VkResponse(updates.Object)); ;
                        Keyboards key = new Keyboards();
                        Messages text = new Messages();
                        DateTime parsedDate;
                        CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-RU");
                        DateTimeStyles styles = DateTimeStyles.None;
                        Random rnd = new Random();
                        if (msg.Text.ToLower() == "начать" || msg.Text.ToLower() == "start" || msg.Text.ToLower() == "привет")
                        {
                            _vkApi.Messages.Send(new MessagesSendParams
                            {
                                RandomId = rnd.Next(),
                                PeerId = msg.PeerId.Value,
                                Message = Messages.StartMessage,
                                Keyboard = key.MenuKeyboard()
                            });
                            break;
                        }

                        if (msg.Text.ToLower() == "записаться")
                        {
                            _vkApi.Messages.Send(new MessagesSendParams
                            {
                                RandomId = rnd.Next(),
                                PeerId = msg.PeerId.Value,
                                Message = Messages.StartRecording,
                                Keyboard = key.BackToMenuKeyboard()
                            });
                            break;
                        }

                        if (msg.Text.ToLower() == "программа экзаменов")
                        {
                            _vkApi.Messages.Send(new MessagesSendParams
                            {
                                RandomId = rnd.Next(),
                                PeerId = msg.PeerId.Value,
                                Message = Messages.ExamsProgram,
                                Keyboard = key.BackToMenuKeyboard()
                            });
                            break;
                        }
                        if (msg.Text.ToLower() == "вернуться в меню")
                        {
                            _vkApi.Messages.Send(new MessagesSendParams
                            {
                                RandomId = rnd.Next(),
                                PeerId = msg.PeerId.Value,
                                Message = "Меню",
                                Keyboard = key.MenuKeyboard()
                            });
                            break;
                        }
                        if (msg.Text.ToLower() == "электросила адрес")
                        {
                            _vkApi.Messages.Send(new MessagesSendParams
                            {
                                RandomId = rnd.Next(),
                                PeerId = msg.PeerId.Value,
                                Message = "https://vk.com/photo-76096366_457239029",
                                Keyboard = key.MenuKeyboard()
                            });
                            break;
                        }
                        if (msg.Text.ToLower() == "большевиков адрес")
                        {
                            _vkApi.Messages.Send(new MessagesSendParams
                            {
                                RandomId = rnd.Next(),
                                PeerId = msg.PeerId.Value,
                                Message = "https://vk.com/photo-76096366_457239028",
                                Keyboard = key.MenuKeyboard()
                            });
                            break;
                        }
                        if ((msg.Text.ToLower().Substring(0, 11) == "электросила" || msg.Text.ToLower().Substring(0, 11) == "большевиков") && msg.Text.ToLower() != "записаться" && msg.Text.ToLower() != "начать" && msg.Text.ToLower() != "start" && msg.Text.ToLower() != "вернуться в меню" && msg.Text.ToLower() != "электросила адрес" && msg.Text.ToLower() != "большевиков адрес" && msg.Text.ToLower() != "программа экзаменов" && msg.Text.ToLower() != "привет")
                        {
                            string TrainingDate = msg.Text.Substring(12).Trim();
                            if (DateTime.TryParse(TrainingDate, culture, styles, out parsedDate) == true)
                            {
                                recording record = new recording(msg.PeerId.Value, new Gym(msg.Text.ToLower().Substring(0, 11)));
                                if (parsedDate >= DateTime.Now)
                                {
                                    if (record.checkDate(parsedDate))
                                    {
                                        _vkApi.Messages.Send(new MessagesSendParams
                                        {
                                            RandomId = rnd.Next(),
                                            PeerId = msg.PeerId.Value,
                                            Message = Messages.Gratitude,
                                            Keyboard = key.BackToMenuKeyboard()
                                        });
                                        _vkApi.Messages.Send(new MessagesSendParams
                                        {
                                            RandomId = rnd.Next(),
                                            PeerId = 221583403,
                                            Message = text.Message_ToAdmin(record.peerId, record.gym.name, TrainingDate)
                                        });
                                    }
                                    else
                                    {
                                        _vkApi.Messages.Send(new MessagesSendParams
                                        {
                                            RandomId = rnd.Next(),
                                            PeerId = record.peerId,
                                            Message = text.Error_1(record.gym.name)
                                        });
                                        break;
                                    }
                                }
                                else
                                {
                                    _vkApi.Messages.Send(new MessagesSendParams
                                    {
                                        RandomId = rnd.Next(),
                                        PeerId = msg.PeerId,
                                        Message = Messages.RecordingCloseError
                                    });
                                    break;
                                }
                            }
                            else
                            {
                                _vkApi.Messages.Send(new MessagesSendParams
                                {
                                    RandomId = rnd.Next(),
                                    PeerId = msg.PeerId,
                                    Message = Messages.DateFormatError
                                });
                                break;
                            }
                        }
                        else
                        {
                            _vkApi.Messages.Send(new MessagesSendParams
                            {
                                RandomId = rnd.Next(),
                                PeerId = msg.PeerId,
                                Message = Messages.GymError
                            });
                            break;
                        }

                        break;
                    }
            }
            return Ok("ok");
        }
    }
}
