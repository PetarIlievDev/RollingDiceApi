namespace RollingDiceApi.Services.Interfaces
{
    using System.Threading.Tasks;
    using RollingDiceApi.Services.Models.RollDice;
    using RollingDiceApi.Services.Models.RolledDiceGetData;

    public interface IRollDiceService
    {
        Task<RollDiceServiceResponse> RollDiceAsync(RollDiceServiceRequest request, CancellationToken ct);
        Task<RolledDiceGetDataServiceResponse> GetRolledDiceDataAsync(RolledDiceGetDataServiceRequest request, CancellationToken ct);
    }
}
