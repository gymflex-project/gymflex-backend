using FluentValidation;

namespace GymFlex.Application.UseCases.Exercise.GetExercise
{
    public class GetExerciseInputValidator : AbstractValidator<GetExerciseInput>
    {
        public GetExerciseInputValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
