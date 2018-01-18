using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace salmorn.Models
{
    public static class GenCore
    {
        public static Assembly getAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
