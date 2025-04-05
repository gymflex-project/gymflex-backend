using GymFlex.Domain.Validation;

namespace GymFlex.Domain.Validation
{
    public class NotificationValidationHandler : ValidationHandler
    {
        private readonly List<ValidationError> _errors = [];

        public IReadOnlyCollection<ValidationError> Errors 
            => _errors.AsReadOnly();

        public bool HasErrors() => _errors.Count > 0;

        protected override void HandleError(ValidationError error)
            => _errors.Add(error);
    }
}
