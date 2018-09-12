using PCS.DAO.StagingObject;
using PCS.EFMODEL.DataModels;
using PCS.Filter;
using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;

namespace PCS.GetManager.PcsAddress
{
    public class PcsAddressFilterQuery : PcsAddressFilter
    {
        public PcsAddressFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<Address, bool>>> listExpression = new List<System.Linq.Expressions.Expression<Func<Address, bool>>>();

        internal PcsAddressSO Query()
        {
            PcsAddressSO search = new PcsAddressSO();
            try
            {
                #region Abstract Base
                if (this.Id.HasValue)
                {
                    listExpression.Add(o => o.Id == this.Id.Value);
                }
                if (this.IsActive.HasValue)
                {
                    listExpression.Add(o => o.IsActive == this.IsActive.Value);
                }
                if (this.CreateTimeFrom.HasValue)
                {
                    listExpression.Add(o => o.CreateTime.Value >= this.CreateTimeFrom.Value);
                }
                if (this.CreateTimeFromGreater.HasValue)
                {
                    listExpression.Add(o => o.CreateTime.Value > this.CreateTimeFromGreater.Value);
                }
                if (this.CreateTimeTo.HasValue)
                {
                    listExpression.Add(o => o.CreateTime.Value <= this.CreateTimeTo.Value);
                }
                if (this.CreateTimeToLess.HasValue)
                {
                    listExpression.Add(o => o.CreateTime.Value < this.CreateTimeToLess.Value);
                }
                if (this.ModifyTimeFrom.HasValue)
                {
                    listExpression.Add(o => o.ModifyTime.Value >= this.ModifyTimeFrom.Value);
                }
                if (this.ModifyTimeFromGreater.HasValue)
                {
                    listExpression.Add(o => o.ModifyTime.Value > this.ModifyTimeFromGreater.Value);
                }
                if (this.ModifyTimeTo.HasValue)
                {
                    listExpression.Add(o => o.ModifyTime.Value <= this.ModifyTimeTo.Value);
                }
                if (this.ModifyTimeToLess.HasValue)
                {
                    listExpression.Add(o => o.ModifyTime.Value < this.ModifyTimeToLess.Value);
                }
                if (!String.IsNullOrEmpty(this.Creator))
                {
                    listExpression.Add(o => o.Creator == this.Creator);
                }
                if (!String.IsNullOrEmpty(this.Modifier))
                {
                    listExpression.Add(o => o.Modifier == this.Modifier);
                }
                if (this.Ids != null)
                {
                    listExpression.Add(o => this.Ids.Contains(o.Id));
                }
                #endregion

                if (this.ProjectId.HasValue)
                {
                    listExpression.Add(o => o.ProjectId == this.ProjectId.Value);
                }
                if (this.ProjectIds != null)
                {
                    listExpression.Add(o => this.ProjectIds.Contains(o.ProjectId));
                }
                if (this.BlogId.HasValue)
                {
                    listExpression.Add(o => o.BlogId.HasValue && o.BlogId.Value == this.BlogId.Value);
                }
                if (this.BlogIds != null)
                {
                    listExpression.Add(o => o.BlogId.HasValue && this.BlogIds.Contains(o.BlogId.Value));
                }
                if (!String.IsNullOrWhiteSpace(this.LoginnameExact))
                {
                    listExpression.Add(o => o.Loginname == this.LoginnameExact);
                }

                search.listAddressExpression.AddRange(listExpression);
                search.OrderField = this.OrderField;
                search.OrderDirection = this.OrderDirection;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listAddressExpression.Clear();
                search.listAddressExpression.Add(o => o.Id == NegativeId);
            }
            return search;
        }
    }
}
