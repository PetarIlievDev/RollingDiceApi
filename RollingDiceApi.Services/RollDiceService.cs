namespace RollingDiceApi.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using RollingDiceApi.DataAccess.Models;
    using RollingDiceApi.Helpers.Enums;
    using RollingDiceApi.Repositories.Interfaces;
    using RollingDiceApi.Services.Interfaces;
    using RollingDiceApi.Services.Models.Common;
    using RollingDiceApi.Services.Models.RollDice;
    using RollingDiceApi.Services.Models.RolledDiceGetData;

    public class RollDiceService(IMapper mapper, IRollDiceRepository rollDiceRepository) : IRollDiceService
    {
        public async Task<RollDiceServiceResponse> RollDiceAsync(RollDiceServiceRequest request, CancellationToken ct)
        {
            var dice1 = new Random().Next(1, 6);
            var dice2 = new Random().Next(1, 6);
            var sum = dice1 + dice2;

            var result = await rollDiceRepository.SaveRolledDiceAsync(new RolledDiceData
            {
                Dice1 = dice1,
                Dice2 = dice2,
                Sum = sum,
                Email = request.Email,
                CreatedAtUtc = DateTime.UtcNow
            }, ct);

            if (!result)
            {
                throw new Exception("Failed to save rolled dice data");
            }

            return new RollDiceServiceResponse
            {
                Dice1 = dice1,
                Dice2 = dice2,
                Sum = sum
            };
        }
        public async Task<RolledDiceGetDataServiceResponse> GetRolledDiceDataAsync(RolledDiceGetDataServiceRequest request, CancellationToken ct)
        {
            var baseQuery = rollDiceRepository.GetRolledDiceAsync(request.Email);

            switch (request.DateTimeFilter)
            {
                case DateTimeFiter.Year:
                    baseQuery = baseQuery
                        .Where(x => 
                        x.CreatedAtUtc.Year == request.Filter.Year);
                    break;
                case DateTimeFiter.Month:
                    baseQuery = baseQuery
                        .Where(x => 
                        x.CreatedAtUtc.Month == request.Filter.Month && 
                        x.CreatedAtUtc.Year == request.Filter.Year);
                    break;
                case DateTimeFiter.Day:
                    baseQuery = baseQuery
                        .Where(x => 
                        x.CreatedAtUtc.Day == request.Filter.Day && 
                        x.CreatedAtUtc.Month == request.Filter.Month && 
                        x.CreatedAtUtc.Year == request.Filter.Year);
                    break;
                default:
                    break;
            }

            switch(request.Sorting)
            {
                case Sorting.SumOfDiceAscending:
                    baseQuery = baseQuery.OrderBy(x => x.Sum);
                    break;
                case Sorting.SumOfDiceDescending:
                    baseQuery = baseQuery.OrderByDescending(x => x.Sum);
                    break;
                case Sorting.DateTimeAscending:
                    baseQuery = baseQuery.OrderBy(x => x.CreatedAtUtc);
                    break;
                case Sorting.DateTimeDescending:
                    baseQuery = baseQuery.OrderByDescending(x => x.CreatedAtUtc);
                    break;
                case Sorting.SumOfDiceAscending | Sorting.DateTimeAscending:
                    baseQuery = baseQuery.OrderBy(x => x.Sum).ThenBy(x => x.CreatedAtUtc);
                    break;
                case Sorting.SumOfDiceDescending | Sorting.DateTimeDescending:
                    baseQuery = baseQuery.OrderByDescending(x => x.Sum).ThenByDescending(x => x.CreatedAtUtc);
                    break;
                case Sorting.SumOfDiceAscending | Sorting.DateTimeDescending:
                    baseQuery = baseQuery.OrderBy(x => x.Sum).ThenByDescending(x => x.CreatedAtUtc);
                    break;
                case Sorting.SumOfDiceDescending | Sorting.DateTimeAscending:
                    baseQuery = baseQuery.OrderByDescending(x => x.Sum).ThenBy(x => x.CreatedAtUtc);
                    break;
                default:
                    break;
            }

            var pagedQuery = baseQuery.ApplyPagination(request.Pagination);
            var entities = await pagedQuery.ToListAsync(ct);
            var result = new RolledDiceGetDataServiceResponse();
            if (entities.Count > 0)
            {
                result.TotalCount = await baseQuery.CountAsync(ct);
                result.CurrentPage = request.Pagination.Page;
                result.Entities = mapper.Map<List<RolledDataServiceEntity>>(entities);
            }
            return result;
        }
    }
}
