using FPTJobMatch.MVC.Commons;
using FPTJobMatch.MVC.Models;
using FluentValidation;

namespace FPTJobMatch.MVC.Validators
{
    public class JobCategoryValidator : AbstractValidator<JobCategoryViewModel>
    {
        public JobCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(MaxLengths.Name)
                .WithMessage("Vượt quá " + MaxLengths.Name + " ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(MaxLengths.Description)
                .WithMessage("Vượt quá " + MaxLengths.Description + " ký tự");
        }
    }
}
