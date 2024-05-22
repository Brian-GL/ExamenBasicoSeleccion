using ApiExamen.Models.Examen;
using FluentValidation;

namespace ApiExamen.Validators
{
    public class DeleteExamenRequestValidator : AbstractValidator<DeleteExamenRequest>
    {
        public DeleteExamenRequestValidator()
        {
            RuleFor(x => x.IdExamen).NotNull();
        }
    }
}
