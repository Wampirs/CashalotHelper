using CashalotHelper.Data.Entities.Base;
using System;

namespace CashalotHelper.Data.Entities
{
    public class Backup : Entity
    {
        public string Name { get; set; } = "NotSet";
        public string Path { get; set; } = "NotSet";
        public DateTime CreateDate { get; set; } = DateTime.MinValue;
        public string Version { get; set; } = "NotSet";
        public int FileCount { get; set; } = -1;
        public string Note { get; set; } = string.Empty;
    }
}
