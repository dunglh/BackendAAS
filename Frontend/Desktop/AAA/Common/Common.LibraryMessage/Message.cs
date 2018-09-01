namespace Common.LibraryMessage
{
    public partial class Message
    {
        public LanguageEnum Language;
        public string message;
        public Enum EnumBC;

        private static string defaultViMessage = "[].";
        private static string defaultEnMessage = "[].";

        public Message(LanguageEnum language, Enum en)
        {
            Language = language;
            EnumBC = en;
            message = GetMessage(en);
        }

        public enum LanguageEnum
        {
            Vietnamese,
            English,
        }

        public class LanguageCode
        {
            public const string VI = "Vi";
            public const string EN = "En";
        }

        public static string GetLanguageCode(LanguageEnum type)
        {
            string result = LanguageCode.VI;
            switch (type)
            {
                case LanguageEnum.Vietnamese:
                    result = LanguageCode.VI;
                    break;
                case LanguageEnum.English:
                    result = LanguageCode.EN;
                    break;
                default:
                    result = LanguageCode.VI;
                    break;
            }
            return result;
        }

        public static LanguageEnum GetLanguageEnum(string languageName)
        {
            LanguageEnum result = LanguageEnum.Vietnamese;
            switch (languageName)
            {
                case LanguageCode.VI:
                    result = LanguageEnum.Vietnamese;
                    break;
                case LanguageCode.EN:
                    result = LanguageEnum.English;
                    break;
                default:
                    result = LanguageEnum.Vietnamese;
                    break;
            }
            return result;
        }
    }
}
