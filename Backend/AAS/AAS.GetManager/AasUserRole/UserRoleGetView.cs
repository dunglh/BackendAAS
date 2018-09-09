using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using AAS.EFMODEL.View;
using AAS.Filter;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.GetManager.AasUserRole
{
    partial class UserRoleGet : BusinessBase
    {
        internal List<ViewUserRole> GetView(AasUserRoleViewFilter filter)
        {
            try
            {
                StringBuilder sb = new StringBuilder().Append("SELECT * FROM \"ViewUserRole\"");
                string query = this.GetFilterQuery(filter);
                if (String.IsNullOrWhiteSpace(query))
                {
                    sb.Append(String.Format(" WHERE {0}", query));
                }
                if (!String.IsNullOrWhiteSpace(filter.OrderDirection) && !String.IsNullOrWhiteSpace(filter.OrderField))
                {
                    sb.Append(String.Format(" ORDER BY \"{0}\" {1}", filter.OrderField, filter.OrderDirection));
                    if (param.Limit.HasValue && param.Start.HasValue)
                    {
                        sb.Append(String.Format(" LIMIT {0} OFFSET {1}", param.Limit.Value, param.Start.Value));
                    }
                }
                string sqlQuery = sb.ToString();
                return DAOWorker.SqlDAO.GetSql<ViewUserRole>(sqlQuery);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        private string GetFilterQuery(AasUserRoleViewFilter filter)
        {
            StringBuilder sbFilter = new StringBuilder();
            bool addAnd = false;
            if (filter.Id.HasValue)
            {
                sbFilter.Append(String.Format(" \"ID\" = {0}", filter.Id.Value));
                addAnd = true;
            }
            if (filter.IsActive.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"IsActive\" = {0}", filter.IsActive.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"IsActive\" = {0}", filter.IsActive.Value));
                    addAnd = true;
                }
            }
            if (filter.UserId.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"UserId\" = {0}", filter.UserId.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"UserId\" = {0}", filter.UserId.Value));
                    addAnd = true;
                }
            }
            if (filter.RoleId.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"RoleId\" = {0}", filter.RoleId.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"RoleId\" = {0}", filter.RoleId.Value));
                    addAnd = true;
                }
            }
            if (filter.CreateTimeFrom.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"CreateTime\" >= {0}", filter.CreateTimeFrom.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"CreateTime\" >= {0}", filter.CreateTimeFrom.Value));
                    addAnd = true;
                }
            }
            if (filter.CreateTimeTo.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"CreateTime\" <= {0}", filter.CreateTimeTo.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"CreateTime\" <= {0}", filter.CreateTimeTo.Value));
                    addAnd = true;
                }
            }
            if (filter.CreateTimeFromGreater.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"CreateTime\" > {0}", filter.CreateTimeFromGreater.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"CreateTime\" > {0}", filter.CreateTimeFromGreater.Value));
                    addAnd = true;
                }
            }
            if (filter.CreateTimeToLess.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"CreateTime\" < {0}", filter.CreateTimeToLess.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"CreateTime\" < {0}", filter.CreateTimeToLess.Value));
                    addAnd = true;
                }
            }
            if (!String.IsNullOrWhiteSpace(filter.Creator))
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"Creator\" = {0}", filter.Creator));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"Creator\" = {0}", filter.Creator));
                    addAnd = true;
                }
            }
            if (!String.IsNullOrWhiteSpace(filter.Modifier))
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"Modifier\" = {0}", filter.Modifier));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"Modifier\" = {0}", filter.Modifier));
                    addAnd = true;
                }
            }
            if (filter.ModifyTimeFrom.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"ModifyTime\" >= {0}", filter.ModifyTimeFrom.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"ModifyTime\" >= {0}", filter.ModifyTimeFrom.Value));
                    addAnd = true;
                }
            }
            if (filter.ModifyTimeTo.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"ModifyTime\" <= {0}", filter.ModifyTimeTo.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"ModifyTime\" <= {0}", filter.ModifyTimeTo.Value));
                    addAnd = true;
                }
            }
            if (filter.ModifyTimeFromGreater.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"ModifyTime\" = {0}", filter.ModifyTimeFromGreater.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"ModifyTime\" = {0}", filter.ModifyTimeFromGreater.Value));
                    addAnd = true;
                }
            }
            if (filter.ModifyTimeToLess.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"ModifyTime\" < {0}", filter.ModifyTimeToLess.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"ModifyTime\" < {0}", filter.ModifyTimeToLess.Value));
                    addAnd = true;
                }
            }
            if (filter.UserIds != null)
            {
                string addIn = DAOWorker.SqlDAO.AddInClause(filter.UserIds, " {IN_CLAUSE}", "\"UserId\"");
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND {0}", addIn));
                }
                else
                {
                    sbFilter.Append(String.Format(" {0}", addIn));
                    addAnd = true;
                }
            }
            if (filter.RoleIds != null)
            {
                string addIn = DAOWorker.SqlDAO.AddInClause(filter.RoleIds, " {IN_CLAUSE}", "\"RoleId\"");
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND {0}", addIn));
                }
                else
                {
                    sbFilter.Append(String.Format(" {0}", addIn));
                    addAnd = true;
                }
            }
            if (filter.Ids != null)
            {
                string addIn = DAOWorker.SqlDAO.AddInClause(filter.Ids, " {IN_CLAUSE}", "\"Id\"");
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND {0}", addIn));
                }
                else
                {
                    sbFilter.Append(String.Format(" {0}", addIn));
                    addAnd = true;
                }
            }
            if (!String.IsNullOrWhiteSpace(filter.LoginnameExact))
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"Loginname\" = '{0}'", filter.LoginnameExact));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"Loginname\" = '{0}'", filter.LoginnameExact));
                    addAnd = true;
                }
            }
            if (!String.IsNullOrWhiteSpace(filter.RoleCodeExact))
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"RoleCode\" = '{0}'", filter.RoleCodeExact));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"RoleCode\" = '{0}'", filter.RoleCodeExact));
                    addAnd = true;
                }
            }
            if (!String.IsNullOrWhiteSpace(filter.KeyWord))
            {
                string key = filter.KeyWord.Trim();
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND ( \"Creator\" ILIKE '%{0}'", key))
                        .Append(String.Format(" OR \"Modifier\" ILIKE '%{0}'", key))
                        .Append(String.Format(" OR \"Loginname\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"Username\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"Email\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"Mobile\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"RoleCode\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"RoleName\" ILIKE '%{0}%' )", key));
                }
                else
                {
                    sbFilter.Append(String.Format(" ( \"Creator\" ILIKE '%{0}'", key))
                        .Append(String.Format(" OR \"Modifier\" ILIKE '%{0}'", key))
                        .Append(String.Format(" OR \"Loginname\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"Username\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"Email\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"Mobile\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"RoleCode\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"RoleName\" ILIKE '%{0}%' )", key));
                }
            }
            return sbFilter.ToString();
        }
    }
}
