using PCS.DAO.Base;
using PCS.EFMODEL.DataModels;
using PCS.EFMODEL.View;
using PCS.Filter;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS.GetManager.PcsPost
{
    partial class PcsPostGet : BusinessBase
    {
        internal List<ViewPost> GetView(PcsPostViewFilter filter)
        {
            try
            {
                StringBuilder sb = new StringBuilder().Append("SELECT * FROM \"ViewPost\"");
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
                return DAOWorker.SqlDAO.GetSql<ViewPost>(sqlQuery);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        private string GetFilterQuery(PcsPostViewFilter filter)
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
            if (filter.AddressId.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"AddressId\" = {0}", filter.AddressId.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"AddressId\" = {0}", filter.AddressId.Value));
                    addAnd = true;
                }
            }
            if (filter.PostSttId.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"PostSttId\" = {0}", filter.PostSttId.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"PostSttId\" = {0}", filter.PostSttId.Value));
                    addAnd = true;
                }
            }
            if (filter.ProjectId.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"ProjectId\" = {0}", filter.ProjectId.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"ProjectId\" = {0}", filter.ProjectId.Value));
                    addAnd = true;
                }
            }
            if (filter.ProjectSttId.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"ProjectSttId\" = {0}", filter.ProjectSttId.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"ProjectSttId\" = {0}", filter.ProjectSttId.Value));
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
            if (filter.ApprovalTimeFrom.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"ApprovalTime\" >= {0}", filter.ApprovalTimeFrom.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"ApprovalTime\" >= {0}", filter.ApprovalTimeFrom.Value));
                    addAnd = true;
                }
            }
            if (filter.ApprovalTimeTo.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"ApprovalTime\" <= {0}", filter.ApprovalTimeTo.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"ApprovalTime\" <= {0}", filter.ApprovalTimeTo.Value));
                    addAnd = true;
                }
            }
            if (filter.FinishTimeFrom.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"FinishTime\" >= {0}", filter.FinishTimeFrom.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"FinishTime\" >= {0}", filter.FinishTimeFrom.Value));
                    addAnd = true;
                }
            }
            if (filter.FinishTimeTo.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"FinishTime\" <= {0}", filter.FinishTimeTo.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"FinishTime\" <= {0}", filter.FinishTimeTo.Value));
                    addAnd = true;
                }
            }
            if (filter.PostTimeFrom.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"PostTime\" >= {0}", filter.PostTimeFrom.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"PostTime\" >= {0}", filter.PostTimeFrom.Value));
                    addAnd = true;
                }
            }
            if (filter.PostTimeTo.HasValue)
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"PostTime\" <= {0}", filter.PostTimeTo.Value));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"PostTime\" <= {0}", filter.PostTimeTo.Value));
                    addAnd = true;
                }
            }
            if (filter.AddressIds != null)
            {
                string addIn = DAOWorker.SqlDAO.AddInClause(filter.AddressIds, " {IN_CLAUSE}", "\"AddressId\"");
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
            if (filter.ProjectIds != null)
            {
                string addIn = DAOWorker.SqlDAO.AddInClause(filter.ProjectIds, " {IN_CLAUSE}", "\"ProjectId\"");
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
            if (filter.ProjectSttIds != null)
            {
                string addIn = DAOWorker.SqlDAO.AddInClause(filter.ProjectSttIds, " {IN_CLAUSE}", "\"ProjectSttId\"");
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
            if (!String.IsNullOrWhiteSpace(filter.ApprovalLoginnameExact))
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"ApprovalLoginname\" = '{0}'", filter.ApprovalLoginnameExact));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"ApprovalLoginname\" = '{0}'", filter.ApprovalLoginnameExact));
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
            if (!String.IsNullOrWhiteSpace(filter.ProjectCodeExact))
            {
                if (addAnd)
                {
                    sbFilter.Append(String.Format(" AND \"ProjectCode\" = '{0}'", filter.ProjectCodeExact));
                }
                else
                {
                    sbFilter.Append(String.Format(" \"ProjectCode\" = '{0}'", filter.ProjectCodeExact));
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
                        .Append(String.Format(" OR \"Title\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"Status\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"PostType\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"Content\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"Author\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"Tags\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"ApprovalLoginname\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"ApprovalUsername\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"ProjectCode\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"ProjectName\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"BaseUrl\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"Loginname\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"Password\" ILIKE '%{0}%' )", key));
                }
                else
                {
                    sbFilter.Append(String.Format(" ( \"Creator\" ILIKE '%{0}'", key))
                        .Append(String.Format(" OR \"Modifier\" ILIKE '%{0}'", key))
                        .Append(String.Format(" OR \"Title\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"Status\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"PostType\" ILIKE '%{0}%'", key))
                        .Append(String.Format(" OR \"Content\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"Author\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"Tags\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"ApprovalLoginname\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"ApprovalUsername\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"ProjectCode\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"ProjectName\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"BaseUrl\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"Loginname\" ILIKE '%{0}%' )", key))
                        .Append(String.Format(" OR \"Password\" ILIKE '%{0}%' )", key));
                }
            }
            return sbFilter.ToString();
        }
    }
}
