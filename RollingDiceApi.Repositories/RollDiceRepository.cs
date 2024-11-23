namespace RollingDiceApi.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using RollingDiceApi.DataAccess;
    using RollingDiceApi.DataAccess.Models;
    using RollingDiceApi.Repositories.Interfaces;

    public class RollDiceRepository(ApplicationDbContext context) : IRollDiceRepository
    {
        public async Task<bool> SaveRolledDiceAsync(RolledDiceData rolledDiceData, CancellationToken ct)
        {
            await context.RolledDice.AddAsync(rolledDiceData, ct);
            var created = await context.SaveChangesAsync(ct);

            return created > 0;
        }

        public IQueryable<RolledDiceData> GetRolledDiceAsync(string email)
        {
            var query = context.RolledDice
                .Where(x => x.Email == email)
                .AsQueryable();

            return query;
        }
    }
}
