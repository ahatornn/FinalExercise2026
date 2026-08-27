using AutoMapper;
using FinalExercise.Services.Contracts;
using FinalExercise.Api.Models;
using FinalExercise.Common;
using FinalExercise.Services.Contracts.Models;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace FinalExercise.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DisciplineController : ControllerBase
{
    private readonly IDisciplineService disciplineService;
    private readonly IMapper mapper;
    private readonly IValidateService validateService;

    public DisciplineController(IDisciplineService disciplineService, IMapper mapper, IValidateService validateService)
    {
        this.disciplineService = disciplineService;
        this.mapper = mapper;
        this.validateService = validateService;
    }

    [HttpGet]
    [ProducesResponseType<IReadOnlyCollection<DisciplineApiModel>>(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var disciplines = await disciplineService.GetDisciplines(cancellationToken);
        return Ok(mapper.Map<IReadOnlyCollection<DisciplineApiModel>>(disciplines));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType<DisciplineApiModel>(200)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var discipline = await disciplineService.GetDisciplineById(id, cancellationToken);
        return Ok(mapper.Map<DisciplineApiModel>(discipline));
    }

    [HttpPost]
    [ProducesResponseType<DisciplineApiModel>(200)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create(DisciplineCreateApiModel createModel, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<DisciplineCreateModel>(createModel);
        await validateService.ValidateAsync(mapped, cancellationToken);

        var result = await disciplineService.CreateDiscipline(mapped, cancellationToken);

        return Ok(mapper.Map<DisciplineApiModel>(result));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DisciplineCreateApiModel createModel, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<DisciplineModel>(createModel);
        await validateService.ValidateAsync(mapped, cancellationToken);

        mapped.Id = id;
        await disciplineService.UpdateDiscipline(mapped, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType<DisciplineApiModel>(204)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await disciplineService.DeleteDiscipline(id, cancellationToken);
        return NoContent();
    }
}
