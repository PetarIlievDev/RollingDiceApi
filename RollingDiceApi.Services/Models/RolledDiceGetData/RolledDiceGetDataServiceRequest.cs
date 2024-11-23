namespace RollingDiceApi.Services.Models.RolledDiceGetData
{
    using RollingDiceApi.Helpers.Enums;
    using RollingDiceApi.Services.Models.Common;

    public class RolledDiceGetDataServiceRequest
    {
        public required string Email { get; set; }
        public DateOnly Filter { get; set; }
        public DateTimeFiter DateTimeFilter { get; set; }
        public Sorting Sorting { get; set; }
        public required ServicePagination Pagination { get; set; }
    }
}
