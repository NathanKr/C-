using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilsGeneric
{
    public class Utils
    {
        public static string GetAssemblyFileVersion()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            FileVersionInfo fileVersion =
                FileVersionInfo.GetVersionInfo(assembly.Location);

            return fileVersion.FileVersion;
        }
    }
}
