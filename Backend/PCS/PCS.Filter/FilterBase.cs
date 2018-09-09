using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.Filter
{
    public class FilterBase
    {
        protected static readonly long NegativeId = -1;

        public string OrderField { get; set; }

        public string OrderDirection { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// Trang thai kich hoat
        /// </summary>
        public short? IsActive { get; set; }
        /// <summary>
        /// Thoi gian tao (tu)
        /// </summary>
        public long? CreateTimeFrom { get; set; }
        public long? CreateTimeFromGreater { get; set; }
        /// <summary>
        /// Thoi gian tao (den)
        /// </summary>
        public long? CreateTimeTo { get; set; }
        public long? CreateTimeToLess { get; set; }
        /// <summary>
        /// Thoi gian sua (tu)
        /// </summary>
        public long? ModifyTimeFrom { get; set; }
        public long? ModifyTimeFromGreater { get; set; }
        /// <summary>
        /// Thoi gian sua (den)
        /// </summary>
        public long? ModifyTimeTo { get; set; }
        public long? ModifyTimeToLess { get; set; }
        /// <summary>
        /// Nguoi tao
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// Nguoi sua
        /// </summary>
        public string Modifier { get; set; }
        /// <summary>
        /// Tu khoa tim kiem
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// Danh sach cac Id
        /// </summary>
        public List<long> Ids { get; set; }
    }
}
