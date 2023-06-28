using AutoMapper;
using TrainComponentManagement.Dtos;
using TrainComponentManagement.Models;

namespace TrainComponentManagement.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TrainComponent, TrainComponentDto>();
            CreateMap<TrainComponentDto, TrainComponent>();
        }
    }
}
