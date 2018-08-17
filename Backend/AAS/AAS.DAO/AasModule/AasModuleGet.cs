using AAS.DAO.Base;
using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AAS.DAO.AasModule
{
    partial class AasModuleGet : EntityBase
    {
        public List<Module> Get(AasModuleSO search, CommonParam param)
        {
            List<Module> list = new List<Module>();
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.Modules.AsQueryable();
                        if (search.listModuleExpression != null && search.listModuleExpression.Count > 0)
                        {
                            foreach (var item in search.listModuleExpression)
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

        public Module GetById(long id, AasModuleSO search)
        {
            Module result = null;
            try
            {
                bool valid = true;
                valid = valid && IsGreaterThanZero(id);
                if (valid)
                {
                    using (var ctx = new Base.AppContext())
                    {
                        var query = ctx.Modules.AsQueryable().Where(p => p.Id == id);
                        if (search.listModuleExpression != null && search.listModuleExpression.Count > 0)
                        {
                            foreach (var item in search.listModuleExpression)
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
