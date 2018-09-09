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

namespace AAS.GetManager.AasModuleRole
{
    public class ModuleRoleManagerGet : BusinessBase
    {
        public ModuleRoleManagerGet()
            : base()
        {

        }

        public ModuleRoleManagerGet(CommonParam param)
            : base(param)
        {

        }

        public ApiResultObject<List<ModuleRole>> GetResult(ModuleRoleFilterQuery filter)
        {
            ApiResultObject<List<ModuleRole>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<ModuleRole> resultData = null;
                if (valid)
                {
                    resultData = new ModuleRoleGet(param).Get(filter);
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

        public List<ModuleRole> Get(ModuleRoleFilterQuery filter)
        {
            List<ModuleRole> result = null;
            try
            {
                result = new ModuleRoleGet(param).Get(filter);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public ModuleRole GetById(long id)
        {
            ModuleRole result = null;
            try
            {
                result = new ModuleRoleGet(param).GetById(id);
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = null;
            }
            return result;
        }

        public ApiResultObject<List<ViewModuleRole>> GetViewResult(AasModuleRoleViewFilter filter)
        {
            ApiResultObject<List<ViewModuleRole>> result = null;
            try
            {
                bool valid = true;
                valid = valid && IsNotNull(param);
                valid = valid && IsNotNull(filter);
                List<ViewModuleRole> resultData = null;
                if (valid)
                {
                    resultData = new ModuleRoleGet(param).GetView(filter);
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

        public List<ViewModuleRole> GetView(AasModuleRoleViewFilter filter)
        {
            List<ViewModuleRole> result = null;
            try
            {
                result = new ModuleRoleGet(param).GetView(filter);
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
