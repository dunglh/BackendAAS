using AAS.DAO.StagingObject;
using AAS.EFMODEL.DataModels;
using AAS.Filter;
using MyUtil.CommonLogging;
using System;
using System.Collections.Generic;

namespace AAS.GetManager.AasModule
{
    public class ModuleFilterQuery : AasModuleFilter
    {
        public ModuleFilterQuery()
            : base()
        {

        }

        internal List<System.Linq.Expressions.Expression<Func<Module, bool>>> listExpression = new List<System.Linq.Expressions.Expression<Func<Module, bool>>>();

        internal AasModuleSO Query()
        {
            AasModuleSO search = new AasModuleSO();
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

                if (this.ApplicationId.HasValue)
                {
                    listExpression.Add(o => o.ApplicationId == this.ApplicationId);
                }
                if (this.ApplicationIds != null)
                {
                    listExpression.Add(o => this.ApplicationIds.Contains(o.ApplicationId));
                }
                if (!String.IsNullOrWhiteSpace(this.ModuleCodeExact))
                {
                    listExpression.Add(o => o.ModuleCode == this.ModuleCodeExact);
                }

                if (!String.IsNullOrWhiteSpace(this.KeyWord))
                {
                    this.KeyWord = this.KeyWord.ToLower().Trim();
                    listExpression.Add(o => o.Creator.ToLower().Contains(this.KeyWord)
                    || o.Modifier.ToLower().Contains(this.KeyWord)
                    || o.ModuleCode.ToLower().Contains(this.KeyWord)
                    || o.ModuleName.ToLower().Contains(this.KeyWord)
                    );
                }

                search.listModuleExpression.AddRange(listExpression);
                search.OrderField = this.OrderField;
                search.OrderDirection = this.OrderDirection;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                search.listModuleExpression.Clear();
                search.listModuleExpression.Add(o => o.Id == NegativeId);
            }
            return search;
        }
    }
}