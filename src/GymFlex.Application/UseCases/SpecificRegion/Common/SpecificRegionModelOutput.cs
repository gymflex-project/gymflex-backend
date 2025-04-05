using DomainEntity = GymFlex.Domain.Entities;

namespace GymFlex.Application.UseCases.SpecificRegion.Common
{
    public class SpecificRegionModelOutput(Guid id, string name)
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;

        public static SpecificRegionModelOutput FromSpecificRegion(DomainEntity.SpecificRegion specificRegion) 
            => new(specificRegion.Id, specificRegion.Name);
    }
}
