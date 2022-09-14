namespace CashalotHelper.Providers.Settings
{
    public interface ISettingsProvider
    {
        public string PathToMasterBranch { get; set; }
        public string PathToBranchesFolder { get; set; }
        public string PathToNonReleaseFiles { get; set; }
    }
}
