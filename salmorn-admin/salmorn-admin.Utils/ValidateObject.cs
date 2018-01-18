using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin
{
    public static class ValidateObject
    {
        public static bool IsThereValues<T>(this List<T> datas)
        {
            return datas != null && datas.Count > 0;
        }
        public static bool IsThereValues<T>(this T data)
        {
            return data != null;
        }
    }
}
