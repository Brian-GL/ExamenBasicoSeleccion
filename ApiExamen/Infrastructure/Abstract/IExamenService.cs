using ApiExamen.Models;
using ApiExamen.Models.Examen;

namespace ApiExamen.Infrastructure.Abstract
{
    public interface IExamenService
    {
        Task<InfrastructureResponse> CreateAsync(CreateExamenRequest? model);
        Task<InfrastructureResponse> DeleteAsync(DeleteExamenRequest? model);
        Task<InfrastructureResponse> GetAsync(GetExamenRequest? model);
        Task<InfrastructureResponse> UpdateAsync(UpdateExamenRequest? model);
    }
}
