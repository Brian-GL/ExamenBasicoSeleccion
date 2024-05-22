using ApiExamen.Models.Examen;
using FluentValidation;

namespace ApiExamen.Validators
{
    public class UpdateExamenRequestValidator : AbstractValidator<UpdateExamenRequest>
    {
        public UpdateExamenRequestValidator() 
        {
            RuleFor(x => x.IdExamen).NotNull();
            RuleFor(x => x.Nombre).Cascade(cascadeMode: CascadeMode.Stop).NotNull().NotEmpty().Length(min: 1, max: 255);
            RuleFor(x => x.Descripcion).Cascade(cascadeMode: CascadeMode.Stop).NotNull().NotEmpty().Length(min: 1, max: 255);
        }
    }
}
