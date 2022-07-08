using System;

namespace CashalotHelper.Providers.FileSystem
{
    public static class FileSystem
    {
        public static string MainDirectory => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CashalotHelper";
        public static string BackupsDirectory => MainDirectory + "\\Backups";
        public static string BranchesDirectory => MainDirectory + "\\Branches";
    }
}
