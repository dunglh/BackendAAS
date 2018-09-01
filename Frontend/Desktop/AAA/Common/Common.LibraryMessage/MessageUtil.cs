using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.LibraryMessage
{
    public class MessageUtil
    {
        private static Dictionary<Message.LanguageEnum, Dictionary<Message.Enum, Message>> dicMultiLanguage = new Dictionary<Message.LanguageEnum, Dictionary<Message.Enum, Message>>();
        private static Dictionary<Message.Enum, Message> dic = new Dictionary<Message.Enum, Message>();
        private static Object thisLock = new Object();

        public static string GetMessage(Message.Enum MessageCaseEnum, params string[] extraMessage)
        {
            string result = "";
            try
            {
                Message MessageCase = Get(GetLang(), MessageCaseEnum);
                if (MessageCase != null)
                {
                    if (extraMessage != null && extraMessage.Length > 0)
                    {
                        result = String.Format(MessageCase.message, extraMessage);
                    }
                    else
                    {
                        result = MessageCase.message;
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error("Co exception khi SetParam co tham so phu.", ex);
            }
            return result;
        }

        public static void SetMessage(CommonParam param, LibraryMessage.Message.Enum en, params string[] extraMessage)
        {
            try
            {
                string message = GetMessage(en, extraMessage);
                AddMessage(param, message);
            }
            catch (Exception ex)
            {
                LogSystem.Error("Co exception khi SetParam co tham so phu.", ex);
            }
        }

        private static void AddMessage(CommonParam param, string message)
        {
            if (message != null)
            {
                if (!param.Messages.Contains(message))
                {
                    param.Messages.Add(message);
                }
            }
        }

        private static Message Get(string languageCode, Message.Enum enumBC)
        {
            Message result = null;
            Dictionary<Message.Enum, Message> dic = null;
            Message.LanguageEnum languageEnum = Message.GetLanguageEnum(languageCode);
            if (!dicMultiLanguage.TryGetValue(languageEnum, out dic))
            {
                lock (thisLock)
                {
                    dic = new Dictionary<Message.Enum, Message>();
                    result = new Message(languageEnum, enumBC);
                    dic.Add(enumBC, result);
                }
                dicMultiLanguage.Add(languageEnum, dic);
            }
            else
            {
                if (!dic.TryGetValue(enumBC, out result))
                {
                    lock (thisLock)
                    {
                        result = new Message(languageEnum, enumBC);
                    }
                    dic.Add(enumBC, result);
                }
            }
            return result;
        }

        private static string GetLang()
        {
            var lang = DungLH.Util.Language.LanguageManager.GetLanguage();
            string langCode = lang == DungLH.Util.Language.LanguageEnum.En ? Message.LanguageCode.EN : Message.LanguageCode.VI;
            return langCode;
        }
    }
}
