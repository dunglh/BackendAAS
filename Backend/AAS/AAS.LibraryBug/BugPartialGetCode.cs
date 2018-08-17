namespace AAS.LibraryBug
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
                case Enum.AasApplicationRole_ThemMoiThatBai: code = CodeResource.AasApplicationRole_ThemMoiThatBai; break;
                case Enum.AasApplicationRole_CapNhatThatBai: code = CodeResource.AasApplicationRole_CapNhatThatBai; break;
                case Enum.AasCredentialData_ThemMoiThatBai: code = CodeResource.AasCredentialData_ThemMoiThatBai; break;
                case Enum.AasCredentialData_CapNhatThatBai: code = CodeResource.AasCredentialData_CapNhatThatBai; break;
                case Enum.AasApplication_ThemMoiThatBai: code = CodeResource.AasApplication_ThemMoiThatBai; break;
                case Enum.AasApplication_CapNhatThatBai: code = CodeResource.AasApplication_CapNhatThatBai; break;
                case Enum.AasModule_ThemMoiThatBai: code = CodeResource.AasModule_ThemMoiThatBai; break;
                case Enum.AasModule_CapNhatThatBai: code = CodeResource.AasModule_CapNhatThatBai; break;
                case Enum.AasModuleRole_ThemMoiThatBai: code = CodeResource.AasModuleRole_ThemMoiThatBai; break;
                case Enum.AasModuleRole_CapNhatThatBai: code = CodeResource.AasModuleRole_CapNhatThatBai; break;
                case Enum.AasRole_ThemMoiThatBai: code = CodeResource.AasRole_ThemMoiThatBai; break;
                case Enum.AasRole_CapNhatThatBai: code = CodeResource.AasRole_CapNhatThatBai; break;
                case Enum.AasUser_ThemMoiThatBai: code = CodeResource.AasUser_ThemMoiThatBai; break;
                case Enum.AasUser_CapNhatThatBai: code = CodeResource.AasUser_CapNhatThatBai; break;
                case Enum.AasUserRole_ThemMoiThatBai: code = CodeResource.AasUserRole_ThemMoiThatBai; break;
                case Enum.AasUserRole_CapNhatThatBai: code = CodeResource.AasUserRole_CapNhatThatBai; break;
                case Enum.Common_DuLieuDauVaoKhongChinhXac: code = CodeResource.Common_DuLieuDauVaoKhongChinhXac; break;

                default: code = defaultViMessage; break;
            }
            return code;
        }
    }
}
