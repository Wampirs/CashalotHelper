namespace CashalotHelper.Services
{
    public interface IFSControler
    {
        public bool IsAccessibly(string _pathToCheckAccess);
        public string GetFileVersion(string _fileToGetVer);
        public int GetFileNumber(string _dirToCountFiles);
        public bool IsExists(string _pathToEnsureExist);
        public void DeleteFile(string _fileToDelete);
        public void CleanDirectory(string _dirToClean);
        public void CreateShortcut(string _targetFilePath, string _shortcutName);
    }
}
