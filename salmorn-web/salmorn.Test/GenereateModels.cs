using Microsoft.VisualStudio.TestTools.UnitTesting;
using salmorn.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace salmorn.Test
{
    [TestClass]
    public class GenereateModels
    {
        private static string baseNamespace = "salmorn.Models";

        private static string targetModelFolder = @"C:\Projects\My Projects\Salmorn\salmorn-web\salmorn-web\ClientApp\components\models\";
        [TestMethod]
        public void Generate()
        {
            List<string> folders = new List<string>();
            SortedList<string, SortedList<string, Type>> myTypeList = ExtractListOfTypes(GenCore.getAssembly());

            DumpTypeList(myTypeList);
        }

        private static void genModels(SortedList<string, SortedList<string, Type>> myTypeList)
        {
            foreach (var m in myTypeList)
            {
                if (m.Key == baseNamespace) continue;
                string path = targetModelFolder + m.Key.Replace(myTypeList + ".", "");

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            }
        }
        private static void genModels(SortedList<string, Type> values)
        {

        }

        private static SortedList<string, SortedList<string, Type>> ExtractListOfTypes(Assembly assem)
        {
            SortedList<string, SortedList<string, Type>> theList =
                new SortedList<string, SortedList<string, Type>>();

            foreach (Type t in assem.GetTypes())
            {
                if (t.Namespace == null) continue;
                // Add namespace if it's not already in list
                if (!theList.ContainsKey(t.Namespace))
                    theList.Add(t.Namespace, new SortedList<string, Type>());

                // And add type under appropriate namespace
                theList[t.Namespace].Add(t.FullName, t);
            }

            return theList;
        }

        private static void DumpTypeList(SortedList<string, SortedList<string, Type>> theList)
        {
            foreach (KeyValuePair<string, SortedList<string, Type>> kvp in theList)
            {
                Console.WriteLine(string.Format("Namespace: [{0}]", kvp.Key));

                foreach (KeyValuePair<string, Type> kvpInner in kvp.Value)
                {
                    Console.WriteLine(string.Format("  Type: [{0}]", ((Type)kvpInner.Value).FullName));
                }

                Console.WriteLine();
            }
        }
    }

    
}
