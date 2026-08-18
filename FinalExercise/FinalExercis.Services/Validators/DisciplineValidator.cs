using FinalExercise.Entities;
using FluentValidation;

namespace FinalExercis.Services.Validators;

public class DisciplineValidator : AbstractValidator<Discipline>
{
    public DisciplineValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Описание обязательно")
            .MaximumLength(200)
            .WithMessage("Длина описания не может быть больше 200 символов");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Название обязательно")
            .MaximumLength(70)
            .WithMessage("Длина названия не может быть больше 70 символов");
    }
}
