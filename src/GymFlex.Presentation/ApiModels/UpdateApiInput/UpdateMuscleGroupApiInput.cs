namespace GymFlex.Presentation.ApiModels.UpdateApiInput
{
    public class UpdateMuscleGroupApiInput(
        string name
    )
    {
        public string Name { get; set; } = name;
    }
}