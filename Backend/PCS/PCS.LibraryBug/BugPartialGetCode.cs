namespace PCS.LibraryBug
{
    public partial class Bug
    {
        private string GetCode(Enum enumBC)
        {
            string code = "";
            switch (enumBC)
            {
                case Enum.Common__KXDDDuLieuCanXuLy: code = CodeResource.Common__KXDDDuLieuCanXuLy; break;
                case Enum.Common__ThieuThongTinBatBuoc: code = CodeResource.Common__ThieuThongTinBatBuoc; break;
                case Enum.Common__LoiCauHinhHeThong: code = CodeResource.Common__LoiCauHinhHeThong; break;
                case Enum.Common__DuLieuDauVaoKhongChinhXac: code = CodeResource.Common__DuLieuDauVaoKhongChinhXac; break;
                case Enum.PcsAddress_ThemMoiThatBai: code = CodeResource.PcsAddress_ThemMoiThatBai; break;
                case Enum.PcsAddress_CapNhatThatBai: code = CodeResource.PcsAddress_CapNhatThatBai; break;
                case Enum.PcsEmployee_ThemMoiThatBai: code = CodeResource.PcsEmployee_ThemMoiThatBai; break;
                case Enum.PcsEmployee_CapNhatThatBai: code = CodeResource.PcsEmployee_CapNhatThatBai; break;
                case Enum.PcsPost_ThemMoiThatBai: code = CodeResource.PcsPost_ThemMoiThatBai; break;
                case Enum.PcsPost_CapNhatThatBai: code = CodeResource.PcsPost_CapNhatThatBai; break;
                case Enum.PcsProject_ThemMoiThatBai: code = CodeResource.PcsProject_ThemMoiThatBai; break;
                case Enum.PcsProject_CapNhatThatBai: code = CodeResource.PcsProject_CapNhatThatBai; break;

                default: code = defaultViMessage; break;
            }
            return code;
        }
    }
}
