using WsApiExamen.Models;
using FluentValidation;
using FluentValidation.Results;

namespace WsApiExamen.Extensions
{
    public static class Extensions
    {

        public static InfrastructureResponse GetBdResponse(this BdActionResponse bdResponse)
        {
            return new()
            {
                Success = bdResponse.Codigo > -1,
                Message = bdResponse.Mensaje
            };
        }


        public static InfrastructureResponse GetExceptionResponse(this Exception ex)
        {
            return new InfrastructureResponse
            {
                Success = false,
                Message = ex.Message
            };
        }

        public static async Task<InfrastructureResponse> ValidateModelAsync<TModel>(this AbstractValidator<TModel> validator, TModel? model) where TModel : class
        {
            ArgumentNullException.ThrowIfNull(validator);

            if (model is null)
            {
                return new InfrastructureResponse
                {
                    Success = false,
                    Message = "El modelo de entrada se encuentra nulo"
                };
            }

            InfrastructureResponse _Response = new()
            {
                Success = true,
                Message = "OK"
            };

            ValidationResult validationResult = await validator.ValidateAsync(instance: model!);

            if (!validationResult.IsValid && validationResult.Errors.Count > 0)
            {
                ValidationFailure item = validationResult.Errors[0];
                _Response.Success = false;
                _Response.Message = item.ErrorMessage;
            }

            return _Response;

        }
    }
}
