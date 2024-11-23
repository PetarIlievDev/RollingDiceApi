namespace RollingDiceApi.MapperProfiles
{
    using AutoMapper;
    using RollingDiceApi.Models.Common;
    using RollingDiceApi.Models.RollDice;
    using RollingDiceApi.Services.Models.Common;
    using RollingDiceApi.Services.Models.RolledDiceGetData;

    public class RollDiceRequestMappingProfile : Profile
    {
        public RollDiceRequestMappingProfile()
        {
            CreateMap<RolledDiceGetDataRequest, RolledDiceGetDataServiceRequest>();
            CreateMap<Pagination, ServicePagination>();
        }
    }
}
