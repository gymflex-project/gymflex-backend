using FluentValidation;

namespace GymFlex.Application.UseCases.ExerciseSubstitution.GetExerciseSubstitution
{
    public class GetExerciseSubstitutionInputValidator : AbstractValidator<GetExerciseSubstitutionInput>
    {
        public GetExerciseSubstitutionInputValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
