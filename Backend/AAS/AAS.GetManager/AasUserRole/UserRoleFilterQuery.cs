using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using AAS.Filter;
using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;

namespace AAS.GetManager.AasUserRole
{
    public class UserRoleFilterQuery : AasUserRoleFilter
    {
        public UserRoleFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<UserRole, bool>>> listExpression = new List<System.Linq.Expressions.Expression<Func<UserRole, bool>>>();

        internal AasUserRoleSO Query()
        {
            AasUserRoleSO search = new AasUserRoleSO();
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

                if (this.UserId.HasValue)
                {
                    listExpression.Add(o => o.UserId == this.UserId.Value);
                }
                if (this.UserIds != null)
                {
                    listExpression.Add(o => this.UserIds.Contains(o.UserId));
                }
                if (this.RoleId.HasValue)
                {
                    listExpression.Add(o => o.RoleId == this.RoleId.Value);
                }
                if (this.RoleIds != null)
                {
                    listExpression.Add(o => this.RoleIds.Contains(o.RoleId));
                }

                search.listUserRoleExpression.AddRange(listExpression);
                search.OrderField = this.OrderField;
                search.OrderDirection = this.OrderDirection;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listUserRoleExpression.Clear();
                search.listUserRoleExpression.Add(o => o.Id == NegativeId);
            }
            return search;
        }
    }
}
