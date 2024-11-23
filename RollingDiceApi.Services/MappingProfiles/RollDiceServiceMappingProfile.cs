namespace RollingDiceApi.Services.MappingProfiles
{
    using AutoMapper;
    using RollingDiceApi.DataAccess.Models;
    using RollingDiceApi.Services.Models.RolledDiceGetData;

    public class RollDiceServiceMappingProfile : Profile
    {
        public RollDiceServiceMappingProfile()
        {
            CreateMap<RolledDiceData, RolledDataServiceEntity>();
        }
    }
}