using WsApiExamen.Models.Examen;
using FluentValidation;

namespace WsApiExamen.Validators
{
    public class DeleteExamenRequestValidator : AbstractValidator<DeleteExamenRequest>
    {
        public DeleteExamenRequestValidator()
        {
            RuleFor(x => x.IdExamen).NotNull();
        }
    }
}
