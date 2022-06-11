using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashalotHelper.FileSystem
{
    public static class FileSystem
    {
        public static string MainDirectory => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CashalotHelper";
        public static string BackupsDirectory => MainDirectory + "\\Backups";
        public static string BranchesDirectory => MainDirectory + "\\Branches";
    }
}
