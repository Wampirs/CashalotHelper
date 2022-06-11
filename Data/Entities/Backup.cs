using System;
using CashalotHelper.Data.Entities.Base;

namespace CashalotHelper.Data.Entities
{
    public class Backup : Entity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime CreateDate { get; set; }
        public string Version { get; set; }
        public int FileCount { get; set; }
        public string Note { get; set; }
    }
}
