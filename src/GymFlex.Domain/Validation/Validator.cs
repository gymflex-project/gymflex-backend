namespace GymFlex.Domain.Validation
{
    public abstract class Validator(ValidationHandler handler)
    {
        protected readonly ValidationHandler _handler = handler;

        public abstract void Validate();
    }

}
