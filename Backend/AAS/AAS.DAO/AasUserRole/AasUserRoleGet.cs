using AAS.DAO.Base;
using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasUserRole
{
    partial class AasUserRoleGet : EntityBase
    {
        public List<UserRole> Get(AasUserRoleSO search, CommonParam param)
        {
            List<UserRole> list = new List<UserRole>();
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.UserRoles.AsQueryable();
                        if (search.listUserRoleExpression != null && search.listUserRoleExpression.Count > 0)
                        {
                            foreach (var item in search.listUserRoleExpression)
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

        public UserRole GetById(long id, AasUserRoleSO search)
        {
            UserRole result = null;
            try
            {
                bool valid = true;
                valid = valid && IsGreaterThanZero(id);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.UserRoles.AsQueryable().Where(p => p.Id == id);
                        if (search.listUserRoleExpression != null && search.listUserRoleExpression.Count > 0)
                        {
                            foreach (var item in search.listUserRoleExpression)
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
