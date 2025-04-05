using GymFlex.Domain.Validation;

namespace GymFlex.Domain.Exceptions;

public class EntityValidationException(
    string? message,
    IReadOnlyCollection<ValidationError>? errors = null)
    : Exception(message)
{
    public IReadOnlyCollection<ValidationError>? Errors { get; } = errors;
}
