using GymFlex.Application.UseCases.SpecificRegion.Common;
using MediatR;

namespace GymFlex.Application.UseCases.SpecificRegion.UpdateSpecificRegion
{
    public class UpdateSpecificRegionInput(
        Guid id,
        string name,
        Guid muscleGroupId
    ) : IRequest<SpecificRegionModelOutput>
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;
        public Guid MuscleGroupId { get; set; } = muscleGroupId;
    }
}