using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Keyboard;
using VkNet.Model.RequestParams;

namespace Cursovaya_Bot
{
    public class Keyboards
    {
        public MessageKeyboard MenuKeyboard()
        {
            KeyboardBuilder keyMenu = new KeyboardBuilder();
            keyMenu.AddButton("Записаться", "", KeyboardButtonColor.Negative);
            keyMenu.AddLine();
            keyMenu.AddButton("Программа экзаменов", "", KeyboardButtonColor.Primary);
            keyMenu.AddLine();
            keyMenu.AddButton("Электросила адрес", "", KeyboardButtonColor.Primary);
            keyMenu.AddLine();
            keyMenu.AddButton("Большевиков адрес", "", KeyboardButtonColor.Primary);
            MessageKeyboard keyboardMenu = keyMenu.Build();
            return keyboardMenu;
        }
        public MessageKeyboard BackToMenuKeyboard()
        {
            KeyboardBuilder keyBackToMenu = new KeyboardBuilder();
            keyBackToMenu.AddButton("Вернуться в меню", "", KeyboardButtonColor.Negative);
            MessageKeyboard keyboardBackToMenu = keyBackToMenu.Build();
            return keyboardBackToMenu;
        }
        

    }
}
