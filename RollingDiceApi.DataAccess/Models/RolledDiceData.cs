namespace RollingDiceApi.DataAccess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RolledDiceData
    {
        [Key]
        public int Id { get; set; }
        public required string Email { get; set; }
        public int Dice1 { get; set; }
        public int Dice2 { get; set; }
        public int Sum { get; set; }
        public DateTime CreatedAtUtc { get; set; }

    }
}
