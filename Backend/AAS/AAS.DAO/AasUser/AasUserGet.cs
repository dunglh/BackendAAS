using AAS.DAO.Base;
using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasUser
{
    partial class AasUserGet : EntityBase
    {
        public List<User> Get(AasUserSO search, CommonParam param)
        {
            List<User> list = new List<User>();
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.Users.AsQueryable();
                        if (search.listUserExpression != null && search.listUserExpression.Count > 0)
                        {
                            foreach (var item in search.listUserExpression)
                            {
                                query = query.Where(item);
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(search.OrderField) && !string.IsNullOrWhiteSpace(search.OrderDirection))
                        {
                            if (!param.Start.HasValue || !param.Limit.HasValue)
                            {
                                list = query.OrderByProperty(search.OrderField, search.OrderDirection).ToList();
                            }
                            else
                            {
                                param.Count = (from r in query select r).Count(); query = query.OrderByProperty(search.OrderField, search.OrderDirection);
                                if (param.Count <= param.Limit.Value && param.Start.Value == 0)
                                {
                                    list = query.ToList();
                                }
                                else
                                {
                                    list = query.Skip(param.Start.Value).Take(param.Limit.Value).ToList();
                                }
                            }
                        }
                        else
                        {
                            list = query.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging(LogUtil.TraceData("search", search) + LogUtil.TraceData("param", param), LogType.Error);
                LogSystem.Error(ex);
                list.Clear();
            }
            return list;
        }

        public User GetById(long id, AasUserSO search)
        {
            User result = null;
            try
            {
                bool valid = true;
                valid = valid && IsGreaterThanZero(id);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.Users.AsQueryable().Where(p => p.Id == id);
                        if (search.listUserExpression != null && search.listUserExpression.Count > 0)
                        {
                            foreach (var item in search.listUserExpression)
                            {
                                query = query.Where(item);
                            }
                        }
                        result = query.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging(LogUtil.TraceData("id", id) + LogUtil.TraceData("search", search), LogType.Error);
                LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}
