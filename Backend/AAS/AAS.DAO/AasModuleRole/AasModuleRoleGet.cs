using AAS.DAO.Base;
using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasModuleRole
{
    partial class AasModuleRoleGet : EntityBase
    {
        public List<ModuleRole> Get(AasModuleRoleSO search, CommonParam param)
        {
            List<ModuleRole> list = new List<ModuleRole>();
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.ModuleRoles.AsQueryable();
                        if (search.listModuleRoleExpression != null && search.listModuleRoleExpression.Count > 0)
                        {
                            foreach (var item in search.listModuleRoleExpression)
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

        public ModuleRole GetById(long id, AasModuleRoleSO search)
        {
            ModuleRole result = null;
            try
            {
                bool valid = true;
                valid = valid && IsGreaterThanZero(id);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.ModuleRoles.AsQueryable().Where(p => p.Id == id);
                        if (search.listModuleRoleExpression != null && search.listModuleRoleExpression.Count > 0)
                        {
                            foreach (var item in search.listModuleRoleExpression)
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
