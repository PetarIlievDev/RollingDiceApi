namespace RollingDiceApi.Services.Models.RolledDiceGetData
{
    using System;

    public class RolledDataServiceEntity
    {
        public int Dice1 { get; set; }
        public int Dice2 { get; set; }
        public int Sum { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
