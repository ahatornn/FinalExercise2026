using FinalExercise.Services.Contracts.Models;
using FluentValidation;

namespace FinalExercise.Services.Validators;

public abstract class DisciplineModelBaseValidator<T> : AbstractValidator<T>
    where T : DisciplineCreateModel
{
    public DisciplineModelBaseValidator()
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
