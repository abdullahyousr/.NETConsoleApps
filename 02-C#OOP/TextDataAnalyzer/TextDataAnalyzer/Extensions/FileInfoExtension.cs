using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDataAnalyzer.Extensions
{
    public static class FileInfoExtension
    {
        public static bool IsTextFile(this FileInfo file)
        {
            if(file.Extension == ".txt")
                return true;
            return false;
        }
        public static bool IsCSVFile(this FileInfo file)
        {
            if (file.Extension == ".csv")
                return true;
            return false;
        }
    }
}
