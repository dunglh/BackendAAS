using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using AAS.Filter;
using MyUtil.CommonLogging;
using System;
using System.Collections.Generic;

namespace AAS.GetManager.AasUser
{
    public class UserFilterQuery : AasUserFilter
    {
        public UserFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<User, bool>>> listExpression = new List<System.Linq.Expressions.Expression<Func<User, bool>>>();

        internal AasUserSO Query()
        {
            AasUserSO search = new AasUserSO();
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

                if (!String.IsNullOrWhiteSpace(this.LoginnameExact))
                {
                    listExpression.Add(o => o.Loginname == this.LoginnameExact);
                }

                if (!String.IsNullOrWhiteSpace(this.KeyWord))
                {
                    this.KeyWord = this.KeyWord.ToLower().Trim();
                    listExpression.Add(o => o.Creator.ToLower().Contains(this.KeyWord)
                    || o.Modifier.ToLower().Contains(this.KeyWord)
                    || o.Email.ToLower().Contains(this.KeyWord)
                    || o.Loginname.ToLower().Contains(this.KeyWord)
                    || o.Mobile.ToLower().Contains(this.KeyWord)
                    || o.Username.ToLower().Contains(this.KeyWord)
                    );
                }

                search.listUserExpression.AddRange(listExpression);
                search.OrderField = this.OrderField;
                search.OrderDirection = this.OrderDirection;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listUserExpression.Clear();
                search.listUserExpression.Add(o => o.Id == NegativeId);
            }
            return search;
        }
    }
}
