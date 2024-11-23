namespace RollingDiceApi.Repositories.Interfaces
{
    using System.Linq;
    using System.Threading.Tasks;
    using RollingDiceApi.DataAccess.Models;

    public interface IRollDiceRepository
    {
        Task<bool> SaveRolledDiceAsync(RolledDiceData rolledDiceData, CancellationToken ct);
        IQueryable<RolledDiceData> GetRolledDiceAsync(string email);
    }
}
