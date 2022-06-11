using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using CashalotHelper.Services.Interfaces;

namespace CashalotHelper.Services
{
    internal class ArchivatorService : IArchivatorService
    {
        private readonly IRepository<Backup> _backups;

        public ArchivatorService(IRepository<Backup> backups)
        {
            _backups = backups;
        }


    }
}
