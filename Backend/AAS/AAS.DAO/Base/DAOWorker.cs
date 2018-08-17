
using MyUtil.Repository;

namespace AAS.DAO.Base
{
    public static class DAOWorker
    {
        public static AasApplication.AasApplicationDAO AasApplicationDAO { get { return (AasApplication.AasApplicationDAO)Worker.Get<AasApplication.AasApplicationDAO>(); } }
        public static AasApplicationRole.AasApplicationRoleDAO AasApplicationRoleDAO { get { return (AasApplicationRole.AasApplicationRoleDAO)Worker.Get<AasApplicationRole.AasApplicationRoleDAO>(); } }
        public static AasModule.AasModuleDAO AasModuleDAO { get { return (AasModule.AasModuleDAO)Worker.Get<AasModule.AasModuleDAO>(); } }
        public static AasModuleRole.AasModuleRoleDAO AasModuleRoleDAO { get { return (AasModuleRole.AasModuleRoleDAO)Worker.Get<AasModuleRole.AasModuleRoleDAO>(); } }
        public static AasRole.AasRoleDAO AasRoleDAO { get { return (AasRole.AasRoleDAO)Worker.Get<AasRole.AasRoleDAO>(); } }
        public static AasUser.AasUserDAO AasUserDAO { get { return (AasUser.AasUserDAO)Worker.Get<AasUser.AasUserDAO>(); } }
        public static AasUserRole.AasUserRoleDAO AasUserRoleDAO { get { return (AasUserRole.AasUserRoleDAO)Worker.Get<AasUserRole.AasUserRoleDAO>(); } }
        public static AasCredentialData.AasCredentialDataDAO AasCredentialDataDAO { get { return (AasCredentialData.AasCredentialDataDAO)Worker.Get<AasCredentialData.AasCredentialDataDAO>(); } }
    }
}
