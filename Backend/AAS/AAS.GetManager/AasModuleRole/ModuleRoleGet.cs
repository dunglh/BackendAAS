﻿using AAS.DAO.Base;
using AAS.EFMODEL.DataModels;
using DungLH.Util.Backend.MANAGER;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.GetManager.AasModuleRole
{
    partial class ModuleRoleGet : BusinessBase
    {
        internal ModuleRoleGet()
            :base()
        {

        }

        internal ModuleRoleGet(CommonParam paramGet)
            : base(paramGet)
        {

        }

        internal List<ModuleRole> Get(ModuleRoleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasModuleRoleDAO.Get(filter.Query(), param);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal ModuleRole GetById(long id)
        {
            try
            {
                return GetById(id, new ModuleRoleFilterQuery());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }

        internal ModuleRole GetById(long id, ModuleRoleFilterQuery filter)
        {
            try
            {
                return DAOWorker.AasModuleRoleDAO.GetById(id, filter.Query());
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }
    }
}
