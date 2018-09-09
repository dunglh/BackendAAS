
using DungLH.Util.Repository;

namespace PCS.DAO.Base
{
    public static class DAOWorker
    {
        public static PcsAddress.PcsAddressDAO PcsAddressDAO { get { return (PcsAddress.PcsAddressDAO)Worker.Get<PcsAddress.PcsAddressDAO>(); } }
        public static PcsPost.PcsPostDAO PcsPostDAO { get { return (PcsPost.PcsPostDAO)Worker.Get<PcsPost.PcsPostDAO>(); } }
        public static PcsEmployee.PcsEmployeeDAO PcsEmployeeDAO { get { return (PcsEmployee.PcsEmployeeDAO)Worker.Get<PcsEmployee.PcsEmployeeDAO>(); } }
        public static PcsProject.PcsProjectDAO PcsProjectDAO { get { return (PcsProject.PcsProjectDAO)Worker.Get<PcsProject.PcsProjectDAO>(); } }
        public static Sql.SqlDAO SqlDAO { get { return (Sql.SqlDAO)Worker.Get<Sql.SqlDAO>(); } }
    }
}
