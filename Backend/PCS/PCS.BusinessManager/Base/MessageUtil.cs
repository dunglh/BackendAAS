﻿using PCS.LibraryMessage;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;

namespace PCS.BusinessManager.Base
{
    public class MessageUtil
    {
        public static void SetMessage(CommonParam param, Message.Enum en, params string[] extraMessage)
        {
            try
            {
                string message = GetMessage(en, param.LanguageCode);
                if (extraMessage != null && extraMessage.Length > 0)
                {
                    message = String.Format(message, extraMessage);
                }
                AddMessage(param, message);
            }
            catch (Exception ex)
            {
                LogSystem.Error("Co exception khi SetParam co tham so phu.", ex);
            }
        }

        private static string GetMessage(Message.Enum en, string languageCode)
        {
            languageCode = string.IsNullOrWhiteSpace(languageCode) ? Message.LanguageCode.VI : languageCode;
            Message message = DatabaseMessage.Get(languageCode, en);
            return message != null ? message.message : null;
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
    }
}