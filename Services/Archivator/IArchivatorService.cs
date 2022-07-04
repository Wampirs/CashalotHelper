using CashalotHelper.Data.Entities;
using CashalotHelper.Models;

namespace CashalotHelper.Services.Interfaces;

public interface IArchivatorService
{
    public void PackBackup(Cashalot program);
    public void UnpackBackup(Cashalot program,Backup backup);
}