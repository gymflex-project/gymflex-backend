using GymFlex.Domain.Validation;

namespace GymFlex.Domain.Validation
{
    public abstract class ValidationHandler
    {
        protected abstract void HandleError(ValidationError error);

        public void HandleError(string message)
            => HandleError(new ValidationError(message));
    }

}
