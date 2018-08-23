using DungLH.Util.CommonLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.Core
{
    public class ResultUtil
    {
        /// <summary>
        /// Quyet dinh ket qua xu ly cua API la thanh cong hay that bai dua tren ket qua tra ve.
        /// - Neu du lieu tra ve = null --> ket qua = that bai (false).
        /// - Neu du lieu tra ve kieu bool --> ket qua = du lieu tra ve
        /// - Khac (doi tuong, tap hop...) --> ket qua = thanh cong (true)
        /// </summary>
        /// <param name="resultData"></param>
        /// <returns></returns>
        public static bool DecisionApiResult(object resultData)
        {
            bool result = false;
            try
            {
                if (resultData != null)
                {
                    if (resultData.GetType() == typeof(bool))
                    {
                        result = (bool)resultData;
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
