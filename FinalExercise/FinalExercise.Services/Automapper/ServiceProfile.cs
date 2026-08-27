using AutoMapper;
using FinalExercise.Services.Contracts.Models;
using FinalExercise.Entities;

namespace FinalExercise.Services.Automapper;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Discipline, DisciplineModel>().ReverseMap();
        CreateMap<DisciplineCreateModel, Discipline>();
    }
}
