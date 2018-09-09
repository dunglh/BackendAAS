using PCS.DAO.StagingObject;
using PCS.EFMODEL.DataModels;
using PCS.Filter;
using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;

namespace PCS.GetManager.PcsPost
{
    public class PcsPostFilterQuery : PcsPostFilter
    {
        public PcsPostFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<Post, bool>>> listExpression = new List<System.Linq.Expressions.Expression<Func<Post, bool>>>();

        internal PcsPostSO Query()
        {
            PcsPostSO search = new PcsPostSO();
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
                if (this.AddressId.HasValue)
                {
                    listExpression.Add(o => o.AddressId == this.AddressId.Value);
                }
                if (this.AddressIds != null)
                {
                    listExpression.Add(o => this.AddressIds.Contains(o.AddressId));
                }
                if (this.PostSttId.HasValue)
                {
                    listExpression.Add(o => o.PostSttId == this.PostSttId.Value);
                }
                if (this.PostSttIds != null)
                {
                    listExpression.Add(o => this.PostSttIds.Contains(o.PostSttId));
                }
                if (this.PostTimeFrom.HasValue)
                {
                    listExpression.Add(o => o.PostTime.Value >= this.PostTimeFrom.Value);
                }
                if (this.PostTimeTo.HasValue)
                {
                    listExpression.Add(o => o.PostTime.Value <= this.PostTimeTo.Value);
                }
                if (this.ApprovalTimeFrom.HasValue)
                {
                    listExpression.Add(o => o.ApprovalTime.Value >= this.ApprovalTimeFrom.Value);
                }
                if (this.ApprovalTimeTo.HasValue)
                {
                    listExpression.Add(o => o.ApprovalTime.Value <= this.ApprovalTimeTo.Value);
                }
                if (!String.IsNullOrWhiteSpace(this.ApprovalLoginnameExact))
                {
                    listExpression.Add(o => o.ApprovalLoginname == this.ApprovalLoginnameExact);
                }
                if (!String.IsNullOrWhiteSpace(this.KeyWord))
                {
                    this.KeyWord = this.KeyWord.ToLower().Trim();
                    listExpression.Add(o => o.ApprovalLoginname.ToLower().Contains(this.KeyWord)
                    || o.ApprovalNote.ToLower().Contains(this.KeyWord)
                    || o.ApprovalUsername.ToLower().Contains(this.KeyWord)
                    || o.Author.ToLower().Contains(this.KeyWord)
                    || o.Content.ToLower().Contains(this.KeyWord)
                    || o.Creator.ToLower().Contains(this.KeyWord)
                    || o.Modifier.ToLower().Contains(this.KeyWord)
                    || o.PostType.ToLower().Contains(this.KeyWord)
                    || o.Status.ToLower().Contains(this.KeyWord)
                    || o.Tags.ToLower().Contains(this.KeyWord)
                    || o.Title.ToLower().Contains(this.KeyWord));
                }

                search.listPostExpression.AddRange(listExpression);
                search.OrderField = this.OrderField;
                search.OrderDirection = this.OrderDirection;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listPostExpression.Clear();
                search.listPostExpression.Add(o => o.Id == NegativeId);
            }
            return search;
        }
    }
}
