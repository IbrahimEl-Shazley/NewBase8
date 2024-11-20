using AutoMapper;
using NewBase.Service.Interfaces.General;
//using NewBase.Core.Entities.Schema.ACC;
//using NewBase.Services.Interfaces.General;
//using NewBase.Services.DTOs.Schema.ACC;

namespace NewBase.Services.MapperConfig
{
    public partial class MapperProfile : Profile
    {
        public void MapAcc(ICurrentUserService currentUserService)
        {
            //CreateMap<BillCreateDTO, Bill>();
            //CreateMap<Bill, BillDTO>().ReverseMap();

            //CreateMap<WalletTransactionCreateDTO, WalletTransaction>();
            //CreateMap<WalletTransaction, WalletTransactionDTO>().ReverseMap();

        }
    }
}
