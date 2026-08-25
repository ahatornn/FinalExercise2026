using AutoMapper;
using FinalExercis.Services.Contracts;
using FinalExercise.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalExercise.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DisciplineController : ControllerBase
{
    private readonly IDisciplineService disciplineService;
    private readonly IMapper mapper;

    public DisciplineController(IDisciplineService disciplineService, IMapper mapper)
    {
        this.disciplineService = disciplineService;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType<IReadOnlyCollection<DisciplineApiModel>>(200)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var disciplines = await disciplineService.GetDisciplines(cancellationToken);
        return Ok(mapper.Map<IReadOnlyCollection<DisciplineApiModel>>(disciplines));
    }
}
