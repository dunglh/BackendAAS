using AAS.EFMODEL.Decorator;
using MyUtil.Backend.EFMODEL;
using MyUtil.CommonLogging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;

namespace AAS.DAO.Base
{
    /// <summary>
    /// CREATE
    /// - Thanh cong khi co du lieu duoc insert vao DB thuc (savechange > 0 && == so luong can insert)
    /// UPDATE
    /// - Thanh cong khi tim thay du lieu, cap nhat & savechange ma khong co exception gi. Khong quan tam toi viec thuc te du lieu trong database co thay doi gi hay khong (truong hop du lieu update giong het du lieu dang ton tai).
    /// - That bai khi khong tim duoc du lieu, hoac savechange co exception
    /// DELETE
    /// - Tuong tu nhu update, can phai tim thay du lieu (can delete), thuc hien set IS_DELETE = 1 & savechange thanh cong
    /// - That bai khi khong tim duoc du lieu, hoac savechange co exception
    /// - Tuong tu truong hop can delete 1 list danh sach, chi can 1 du lieu trong list khong duoc tim thay, return false khong thuc hien xoa
    /// TRUNCATE
    /// - Tuong tu delete
    /// </summary>
    /// <typeparam name="DTO"></typeparam>
    /// <typeparam name="RAW"></typeparam>
    class BridgeDAO<RAW> : MyUtil.Core.EntityBase
        where RAW : class
    {
        const string APP_CODE = "AAS";

        public BridgeDAO()
        {

        }

        public bool Truncate(long id)
        {
            bool result = false;
            try
            {
                if (IsGreaterThanZero(id))
                {
                    using (var ctx = new AppContext())
                    {
                        var dbSet = ctx.GetDbSet<RAW>();
                        RAW raw = (RAW)dbSet.Find(id);
                        if (raw != null)
                        {
                            dbSet.Remove(raw);
                            ctx.SaveChanges();
                            result = true;
                        }
                        else
                        {
                            Logging("Khong tim duoc ban ghi trong cSDL theo id de truncate." + MyUtil.CommonLogging.LogUtil.TraceData("id", id), LogType.Error);
                        }
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("id", id), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("id", id), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }

            return result;
        }

        public bool TruncateListRaw(List<RAW> listRaw)
        {
            bool result = false;
            try
            {
                if (IsNotNullOrEmpty(listRaw))
                {
                    using (var ctx = new AppContext())
                    {
                        System.Data.Entity.DbSet dbSet = ctx.GetDbSet<RAW>();
                        foreach (var raw in listRaw)
                        {
                            dbSet.Attach(raw);
                            dbSet.Remove(raw);
                        }
                        ctx.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("listRaw", listRaw), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("listRaw", listRaw), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }

            return result;
        }

        public bool IsUnLock(long id)
        {
            bool result = false;
            using (var ctx = new AppContext())
            {
                ContextUtil<RAW, AppContext> ctxUtil = new ContextUtil<RAW, AppContext>(ctx);
                result = ctxUtil.CheckIsActive(id);
            }
            return result;
        }

        public bool Create(RAW data)
        {
            bool result = false;
            try
            {
                if (IsNotNull(data))
                {
                    string loginname = MyUtil.Token.Backend.BackendTokenManager.GetLoginname();
                    CreatorDecorator.Set<RAW>(data, loginname);
                    DummyDecorator.Set<RAW>(data);

                    using (var ctx = new AppContext())
                    {
                        ctx.GetDbSet<RAW>().Add(data);
                        result = (ctx.SaveChanges() > 0);
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("data", data), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("data", data), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }

            return result;
        }

        public bool CreateList(List<RAW> listData)
        {
            bool result = false;
            try
            {
                if (IsNotNullOrEmpty(listData))
                {
                    string loginName = MyUtil.Token.Backend.BackendTokenManager.GetLoginname();

                    using (var ctx = new AppContext())
                    {
                        var dbSet = ctx.GetDbSet<RAW>();
                        foreach (var data in listData)
                        {
                            CreatorDecorator.Set<RAW>(data, loginName);
                            DummyDecorator.Set<RAW>(data);

                            dbSet.Add(data);
                        }
                        result = (ctx.SaveChanges() > 0);
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(Newtonsoft.Json.JsonConvert.SerializeObject(listData), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(Newtonsoft.Json.JsonConvert.SerializeObject(listData), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Update(RAW data)
        {
            bool result = false;
            try
            {
                if (IsNotNull(data))
                {
                    using (var ctx = new AppContext())
                    {
                        string loginname = MyUtil.Token.Backend.BackendTokenManager.GetLoginname();
                        ModifierDecorator.Set<RAW>(data, loginname);
                        var entry = ctx.Entry<RAW>(data);
                        ctx.GetDbSet<RAW>().Attach(data);                        
                        ctx.Entry<RAW>(data).State = EntityState.Modified;

                        List<string> notChangeFields = DenyUpdateDecorator.Get<RAW>();
                        if (notChangeFields != null && notChangeFields.Count > 0)
                        {
                            foreach (string field in notChangeFields)
                            {
                                entry.Property(field).IsModified = false;
                            }
                        }

                        ctx.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("data", data), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("data", data), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool UpdateList(List<RAW> listData)
        {
            bool result = false;
            try
            {
                if (IsNotNullOrEmpty(listData))
                {
                    using (var ctx = new AppContext())
                    {
                        var dbSet = ctx.GetDbSet<RAW>();
                        string loginName = MyUtil.Token.Backend.BackendTokenManager.GetLoginname();
                        List<string> notChangeFields = DenyUpdateDecorator.Get<RAW>();

                        foreach (RAW data in listData)
                        {
                            ModifierDecorator.Set<RAW>(data, loginName);
                            ctx.Entry(data).State = System.Data.Entity.EntityState.Detached;
                            dbSet.Attach(data);

                            var entry = ctx.Entry(data);
                            entry.State = EntityState.Modified;

                            if (notChangeFields != null && notChangeFields.Count > 0)
                            {
                                foreach (string field in notChangeFields)
                                {
                                    entry.Property(field).IsModified = false;
                                }
                            }
                        }
                        ctx.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("listData", listData), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("listData", listData), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool ExecuteSql(string sql)
        {
            bool result = false;
            try
            {
                if (!String.IsNullOrEmpty(sql))
                {
                    using (var ctx = new AppContext())
                    {
                        var count = ctx.Database.ExecuteSqlCommand(sql);
                        if (count == 0)
                        {
                            MyUtil.CommonLogging.LogSystem.Info("SQL thuc hien thanh cong tuy nhien khong co du lieu duoc tac dong." + MyUtil.CommonLogging.LogUtil.TraceData("sql", sql));
                        }
                        result = true;
                    }
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Logging(LogUtil.TraceDbException(ex), LogType.Error);
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("sql", sql), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            catch (Exception ex)
            {
                Logging(MyUtil.CommonLogging.LogUtil.TraceData("sql", sql), LogType.Error);
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}