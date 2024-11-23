namespace RollingDiceApi.Services.Models.RolledDiceGetData
{
    using System.Collections.Generic;

    public class RolledDiceGetDataServiceResponse
    {
        public List<RolledDataServiceEntity> Entities { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
    }
}
