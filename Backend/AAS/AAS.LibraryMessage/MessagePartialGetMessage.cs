namespace AAS.LibraryMessage
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
                    case Enum.Common__ThieuThongTinBatBuoc: message = MessageViResource.Common__ThieuThongTinBatBuoc; break;
                    case Enum.Common__MaDaTonTaiTrenHeThong: message = MessageViResource.Common__MaDaTonTaiTrenHeThong; break;
                    case Enum.Common__DuLieuDangBiKhoa: message = MessageViResource.Common__DuLieuDangBiKhoa; break;
                    case Enum.Common__LoiCauHinhHeThong: message = MessageViResource.Common__LoiCauHinhHeThong; break;
                    case Enum.Common__DuLieuDangMoKhoa: message = MessageViResource.Common__DuLieuDangMoKhoa; break;
                    case Enum.Common__MatKhauKhongDuocNhoHon6KyTu: message = MessageViResource.Common__MatKhauKhongDuocNhoHon6KyTu; break;
                    case Enum.Common_TaiKhoanKhongChinhXac: message = MessageViResource.Common_TaiKhoanKhongChinhXac; break;
                    case Enum.Common_TaiKhoanHoacMatKhauKhongChinhXac: message = MessageViResource.Common_TaiKhoanHoacMatKhauKhongChinhXac; break;
                    case Enum.Common_UngDungChuaDuocDangKyTrenHeThong: message = MessageViResource.Common_UngDungChuaDuocDangKyTrenHeThong; break;
                    case Enum.Common_TaiKhoanKhongCoQuyenTruyCapUngDung: message = MessageViResource.Common_TaiKhoanKhongCoQuyenTruyCapUngDung; break;

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
