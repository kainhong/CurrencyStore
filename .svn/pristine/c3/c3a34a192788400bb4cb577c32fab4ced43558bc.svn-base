using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Common.ExtensionMethod
{
    public static class ValueTypeExtension
    {
        #region Bool与Int互转
        /// <summary>
        /// Bool转Int
        /// </summary>
        /// <param name="target">bool</param>
        /// <returns>true->1，false->0</returns>
        public static int ToInt(this bool target)
        {
            return target ? 1 : 0;
        }

        /// <summary>
        /// Int转Bool
        /// </summary>
        /// <param name="i">int</param>
        /// <returns>1->true，0->false</returns>
        public static bool ToBool(this int target)
        {
            return target.Equals(1) ? true : false;
        }
        #endregion
    }
}
