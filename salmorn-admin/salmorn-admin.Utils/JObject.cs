using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salmorn_admin.Utils
{
    public static class JObject
    {
        public static List<T> ConvertTo<T>(List<object> items)
        {
            List<T> datas = new List<T>();
            foreach (var i in items)
            {
                datas.Add((T)i);
            }
            return datas;
        }
    }
}
