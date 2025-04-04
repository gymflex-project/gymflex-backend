using FluentValidation;

namespace GymFlex.Application.UseCases.MuscleGroup.GetMuscleGroup
{
    public class GetMuscleGroupInputValidator : AbstractValidator<GetMuscleGroupInput>
    {
        public GetMuscleGroupInputValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
