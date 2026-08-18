using AutoMapper;
using FinalExercis.Services.Contracts.Models;
using FinalExercise.Entities;

namespace FinalExercis.Services.Automapper;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Discipline, DisciplineModel>().ReverseMap();
        CreateMap<DisciplineCreateModel, Discipline>();
    }
}
