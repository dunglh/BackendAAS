namespace PCS.LibraryMessage
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
                    case Enum.PcsProject__DuAnDaKetThuc: message = MessageViResource.PcsProject__DuAnDaKetThuc; break;
                    case Enum.PcsPost__TrangThaiBaiDangKhongHopLe: message = MessageViResource.PcsPost__TrangThaiBaiDangKhongHopLe; break;
                    case Enum.PcsPost__TonTaiBaiDangKhongThuocDuAn: message = MessageViResource.PcsPost__TonTaiBaiDangKhongThuocDuAn; break;
                    case Enum.PcsPost__DuAnChuaCoBaiDangNaoChuaDuyet: message = MessageViResource.PcsPost__DuAnChuaCoBaiDangNaoChuaDuyet; break;
                    case Enum.PcsPost__DuAnKhongCoBaiDangNaoHopLe: message = MessageViResource.PcsPost__DuAnKhongCoBaiDangNaoHopLe; break;
                    case Enum.PcsEmployee__BanKhongCoQuyenThucHienChucNangNay: message = MessageViResource.PcsEmployee__BanKhongCoQuyenThucHienChucNangNay; break;
                    case Enum.PcsPost__ThieuThongTinLyDoTuChoiDuyet: message = MessageViResource.PcsPost__ThieuThongTinLyDoTuChoiDuyet; break;

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
