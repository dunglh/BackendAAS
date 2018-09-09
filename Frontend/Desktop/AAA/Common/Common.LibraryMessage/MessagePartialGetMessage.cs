namespace Common.LibraryMessage
{
    public partial class Message
    {
        private string GetMessage(Enum enumBC)
        {
            string message = "";
            if (Language == LanguageEnum.Vietnamese)
            {
                switch (enumBC)
                {
                    case Enum.Common_XuLyThanhCong: message = MessageViResource.Common_XuLyThanhCong; break;
                    case Enum.Common_XuLyThatBai: message = MessageViResource.Common_XuLyThatBai; break;
                    case Enum.Common_TruongDuLieuBatBuoc: message = MessageViResource.Common_TruongDuLieuBatBuoc; break;
                    case Enum.Common_ThongBao: message = MessageViResource.Common_ThongBao; break;
                    case Enum.Common_CanhBao: message = MessageViResource.Common_CanhBao; break;
                    case Enum.Common_ThieuTruongThongTinBatBuoc: message = MessageViResource.Common_ThieuTruongThongTinBatBuoc; break;

                    default: message = defaultViMessage; break;
                }
            }
            else if (Language == LanguageEnum.English)
            {
                switch (enumBC)
                {
                    default: message = defaultEnMessage; break;
                }
            }
            return message;
        }
    }
}
