namespace RollingDiceApi.Models.RollDice
{
    using RollingDiceApi.Helpers.Enums;
    using RollingDiceApi.Models.Common;

    public class RolledDiceGetDataRequest
    {
        public DateOnly Filter { get; set; }
        public DateTimeFiter DateTimeFilter { get; set; }
        public Sorting Sorting { get; set; }
        public required Pagination Pagination { get; set; }
    }
}
