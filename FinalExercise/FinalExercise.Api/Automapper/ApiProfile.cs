using AutoMapper;
using FinalExercis.Services.Contracts.Models;
using FinalExercise.Api.Models;

namespace FinalExercise.Api.Automapper;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<DisciplineModel, DisciplineApiModel>();
    }
}
