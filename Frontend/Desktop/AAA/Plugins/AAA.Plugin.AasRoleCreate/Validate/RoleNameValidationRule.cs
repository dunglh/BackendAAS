using Common.LibraryMessage;
using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AAA.Plugin.AasRoleCreate.Validate
{
    class RoleNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            try
            {
                if (value == null || String.IsNullOrWhiteSpace(value.ToString().Trim()))
                {
                    result = new ValidationResult(false, MessageUtil.GetMessage(Message.Enum.Common_TruongDuLieuBatBuoc));
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
            return result;
        }
    }
}
