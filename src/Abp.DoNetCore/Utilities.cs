using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Abp.DoNetCore
{

    /// <summary>
    /// Utility tool
    /// </summary>
    /// <remarks>It should be optimized on next Sprint</remarks>
    public static class Utilities
    {
        public static string GetApplicationPath()
        {
            return Path.GetDirectoryName(System.Reflection
                    .Assembly.GetExecutingAssembly().CodeBase);
        }

        public static string GetFilePathOfStoring()
        {
            var exePath = Utilities.GetApplicationPath();
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return Path.Combine(appRoot, "documents");
        }
    }


}
