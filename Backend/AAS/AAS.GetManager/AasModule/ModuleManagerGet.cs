﻿using AAS.EFMODEL.DataModels;
using MyUtil.Backend.MANAGER;
using MyUtil.CommonLogging;
using MyUtil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAS.GetManager.AasModule
{
    public class ModuleManagerGet : BusinessBase
    {
        public ModuleManagerGet()
            : base()
        {

        }

        public ModuleManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<Module>> GetResult(ModuleFilterQuery filter)
        {
            ApiResultObject<List<Module>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<Module> resultData = null;
                if (valid)
                {
                    resultData = new ModuleGet(param).Get(filter);
                }
                result = this.PackResult(resultData);
                this.FailLog(result.Success, filter, result.Data);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public List<Module> Get(ModuleFilterQuery filter)
        {
            List<Module> result = null;
            try
            {
                result = new ModuleGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public Module GetById(long id)
        {
            Module result = null;
            try
            {
                result = new ModuleGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }
    }
}