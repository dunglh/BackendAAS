using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.Backend.EFMODEL
{
    public class ModifierDecorator
    {
        public static void Set<RAW>(RAW raw, string modifier)
        {
            try
            {
                PropertyInfo piModifier = typeof(RAW).GetProperty("Modifier");

                piModifier.SetValue(raw, modifier);
            }
            catch (Exception)
            {

            }
        }
    }
}
