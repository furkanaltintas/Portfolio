using FluentValidation;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.ValidationRules.FluentValidation.DtoValidators;

public class SkillCreateDtoValidator : AbstractValidator<SkillCreateDto>
{
    public SkillCreateDtoValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty()
            .WithMessage("Ad boş olamaz");

        RuleFor(s => s.Name)
            .MaximumLength(50)
            .WithMessage("Ad 50 karakterden büyük olamaz");

        RuleFor(s => s.IconName)
            .NotEmpty()
            .WithMessage("İkon adı boş olamaz");

        RuleFor(s => s.IconName)
            .MaximumLength(100)
            .WithMessage("İkon 100 karakterden büyük olamaz");

        RuleFor(s => s.Point)
            .InclusiveBetween<SkillCreateDto, short>(0, 100)
            .WithMessage("0 ile 100 arasında olmak zorunda");
    }
}
