using PCS.DAO.StagingObject;
using PCS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.Repository;
using System;
using System.Collections.Generic;

namespace PCS.DAO.PcsPost
{
    public partial class PcsPostDAO : EntityBase
    {
        private PcsPostCreate CreateWorker
        {
            get
            {
                return (PcsPostCreate)Worker.Get<PcsPostCreate>();
            }
        }
        private PcsPostUpdate UpdateWorker
        {
            get
            {
                return (PcsPostUpdate)Worker.Get<PcsPostUpdate>();
            }
        }
        private PcsPostTruncate TruncateWorker
        {
            get
            {
                return (PcsPostTruncate)Worker.Get<PcsPostTruncate>();
            }
        }
        private PcsPostGet GetWorker
        {
            get
            {
                return (PcsPostGet)Worker.Get<PcsPostGet>();
            }
        }
        private PcsPostCheck CheckWorker
        {
            get
            {
                return (PcsPostCheck)Worker.Get<PcsPostCheck>();
            }
        }

        public bool Create(Post data)
        {
            bool result = false;
            try
            {
                result = CreateWorker.Create(data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool CreateList(List<Post> listData)
        {
            bool result = false;
            try
            {
                result = CreateWorker.CreateList(listData);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Update(Post data)
        {
            bool result = false;
            try
            {
                result = UpdateWorker.Update(data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool UpdateList(List<Post> listData)
        {
            bool result = false;
            try
            {
                result = UpdateWorker.UpdateList(listData);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }        

        public bool Truncate(Post data)
        {
            bool result = false;
            try
            {
                result = TruncateWorker.Truncate(data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool TruncateList(List<Post> listData)
        {
            bool result = false;
            try
            {
                result = TruncateWorker.TruncateList(listData);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public List<Post> Get(PcsPostSO search, CommonParam param)
        {
            List<Post> result = new List<Post>();
            try
            {
                result = GetWorker.Get(search, param);
            }
            catch (Exception ex)
            {
                param.HasException = true;
                LogSystem.Error(ex);
                result.Clear();
            }
            return result;
        }

        public Post GetById(long id, PcsPostSO search)
        {
            Post result = null;
            try
            {
                result = GetWorker.GetById(id, search);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = null;
            }

            return result;
        }

        public bool IsUnLock(long id)
        {
            try
            {
                return CheckWorker.IsUnLock(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                throw;
            }
        }
    }
}
