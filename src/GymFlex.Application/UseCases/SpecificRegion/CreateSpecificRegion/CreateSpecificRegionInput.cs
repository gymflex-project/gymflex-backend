using GymFlex.Application.UseCases.SpecificRegion.Common;
using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.CreateSpecificRegion
{
    public class CreateSpecificRegionInput(
        string name,
        Guid muscleGroupId
    ) : IRequest<SpecificRegionModelOutput>
    { 
        public string Name { get; set; } = name;
        public Guid MuscleGroupId { get; set; } = muscleGroupId;
    }
}

