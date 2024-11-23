namespace RollingDiceApi.Helpers.Enums
{
    using System;

    [Flags]
    public enum Sorting
    {
        None = 0,
        SumOfDiceAscending = 1,
        SumOfDiceDescending = 2,
        DateTimeAscending = 4,
        DateTimeDescending = 8
    }
}
