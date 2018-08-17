using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.Backend.EFMODEL
{
    public class CreatorDecorator
    {
        public static void Set<RAW>(RAW raw, string creator)
        {
            try
            {
                PropertyInfo piCreator = typeof(RAW).GetProperty("Creator");
                PropertyInfo piModifier = typeof(RAW).GetProperty("Modifier");

                piCreator.SetValue(raw, creator);
                piModifier.SetValue(raw, creator);
            }
            catch (Exception)
            {

            }
        }
    }
}
