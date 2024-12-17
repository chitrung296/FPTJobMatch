using FPTJobMatch.MVC.Commons;
using FPTJobMatch.MVC.Models;
using FluentValidation;

namespace FPTJobMatch.MVC.Validators
{
    public class JobValidator : AbstractValidator<JobViewModel>
    {
        public JobValidator() {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(MaxLengths.Title)
                .WithMessage("Vượt quá " + MaxLengths.Title + " ký tự");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(MaxLengths.Description)
                .WithMessage("Vượt quá " + MaxLengths.Description + " ký tự");

            RuleFor(x => x.Requirements)
                .MaximumLength(MaxLengths.Description)
                .WithMessage("Vượt quá " + MaxLengths.Description + " ký tự");

            RuleFor(x => x.JobCategoryId)
                .NotEmpty();

        }
    }
}
