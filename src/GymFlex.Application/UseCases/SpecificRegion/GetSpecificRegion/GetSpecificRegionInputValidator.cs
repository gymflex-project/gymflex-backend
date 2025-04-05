using FluentValidation;

namespace GymFlex.Application.UseCases.SpecificRegion.GetSpecificRegion
{
    public class GetSpecificRegionInputValidator : AbstractValidator<GetSpecificRegionInput>
    {
        public GetSpecificRegionInputValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
