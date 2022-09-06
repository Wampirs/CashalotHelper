using CashalotHelper.Data.Entities;
using CashalotHelper.Models;
using System.Threading.Tasks;

namespace CashalotHelper.Services.Interfaces;

public interface IArchivatorService
{
    public Task<bool> PackBackup(Cashalot program);
    public Task<bool> UnpackBackup(Cashalot program, Backup backup);
}