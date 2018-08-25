using AAS.LibraryBug;
using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using System;

namespace AAS.BusinessManager.Base
{
    class BugUtil
    {
        public static void SetBugCode(CommonParam param, Bug.Enum bugCaseEnum)
        {
            try
            {
                Bug bug = AAS.LibraryBug.DatabaseBug.Get(bugCaseEnum);
                if (bug != null && !param.BugCodes.Contains(bug.code))
                {
                    param.BugCodes.Add(bug.code);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error("Co exception khi SetBugCode.", ex);
            }
        }
    }
}
