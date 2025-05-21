namespace GymFlex.Presentation.ApiModels.UpdateApiInput
{
    public class UpdateSpecificRegionApiInput(
        string name,
        Guid muscleGroupId
    )
    {
        public string Name { get; set; } = name;
        public Guid MuscleGroupId { get; set; } = muscleGroupId;
    }
}