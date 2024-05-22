using FluentValidation;
using ApiExamen.Models.Examen;

namespace ApiExamen.Validators
{
    /// <summary>
    /// Clase validadora para las propiedades del modelo <see cref="CreateExamenRequest"/>
    /// </summary>
    public class CreateExamenRequestValidator : AbstractValidator<CreateExamenRequest>
    {
        /// <summary>
        /// Crea las reglas de validaciones para las propiedades del modelo <see cref="CreateExamenRequest"/>
        /// </summary>
        public CreateExamenRequestValidator()
        {
            RuleFor(x => x.Nombre).Cascade(cascadeMode: CascadeMode.Stop).NotNull().NotEmpty().Length(min: 1, max: 255);
            RuleFor(x => x.Descripcion).Cascade(cascadeMode: CascadeMode.Stop).NotNull().NotEmpty().Length(min: 1, max: 255);
        }
    }
}
