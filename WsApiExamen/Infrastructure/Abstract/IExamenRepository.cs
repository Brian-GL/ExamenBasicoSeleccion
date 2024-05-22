using WsApiExamen.Models;
using WsApiExamen.Models.Examen;

namespace WsApiExamen.Infrastructure.Abstract
{
    public interface IExamenRepository
    {
        Task<InfrastructureResponse> CreateAsync(CreateExamenRequest? model);
        Task<InfrastructureResponse> DeleteAsync(DeleteExamenRequest? model);
        Task<InfrastructureResponse> GetAsync(GetExamenRequest? model);
        Task<InfrastructureResponse> UpdateAsync(UpdateExamenRequest? model);
    }
}
