using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Resources;
using Cursovaya_Bot.Properties;

namespace Cursovaya_Bot
{
    public class Messages
    {

        public static readonly string StartMessage = "Привет, Я бот Хонг За СПб и вот что я умею:\n\n1) Нажав кнопку Записаться,\nВы сможете записаться на тренировку;\n\n2) Нажав одну из кнопок Электросила адрес/Большевиков адрес,\nВы получите фотографию с маршрутом от ближайшей станции метро до зала\n\n3) Нажав кнопку Прогрмама экзамена,\nВы получите документ с программой экзаменов на чёрный пояс";

        public static readonly string StartRecording = " Наши 2 зала находятся по следующим адресам:\n1) Метро Электросила, Варшавская улица д.5АЖ\nДни тренировок: ПН, СР, ПТ.\n\n 2) Метро проспект Большевиков, Проспект Солидарности д.3к3\nДни тренировок: ВТ, ЧТ, СБ.\n\nВ следующем сообщении напишите зал, в который вы хотели бы записаться, и дату, на которую вы хотите записаться(формат: Электросила/Большевиков, ДД.ММ.ГГГГ).";
        public static readonly string ExamsProgram = "https://vk.com/doc-76096366_547338121?dl=85d0c5d52841eef478";
        public static readonly string DateFormatError = "Проверьте пожалуйста написание даты";
        public static readonly string ExamsProgram2 = "doc8449014_445387365";
        public static readonly string GymError = "Простите, не помню, какой зал вы выбрали...\nНапомните? Электросила или Большевиков?";
        public static readonly string Gratitude = Resources.Thanks;
        public static readonly string RecordingCloseError = "Запись на эту дату уже закрыта";
        public string Message_ToAdmin(long peerId, string _gym, string date)
        {
            string message = "https://vk.com/id" + peerId + " " + "записался на тренировку:" + " " + _gym + " " + date;
            return message;
        }
        public string Error_1(string gymName)
        {
            string message = "Извините, в выбранный день нет тренировки в зале на станции " + " " + gymName + "\nВыберите зал!";
            return message;
        }
    }
}
