using ApiExamen.Infrastructure.Concrete;
using ApiExamen.Models;
using ApiExamen.Models.Examen;

namespace ApiExamen
{
    public class ClsExamen : IDisposable
    {
        private readonly ExamenService _ExamenService;
        private readonly ExamenApi _ExamenApi;

        public ClsExamen() 
        {
            _ExamenService = new();
            _ExamenApi = new();
        }

        public Task<InfrastructureResponse> CreateExamenAsync(CreateExamenRequest? model)
            => _ExamenService.CreateAsync(model);

        public Task<InfrastructureResponse> CreateWsExamenAsync(CreateExamenRequest? model)
            => _ExamenApi.CreateAsync(model);

        public Task<InfrastructureResponse> DeleteExamenAsync(DeleteExamenRequest? model)
           => _ExamenService.DeleteAsync(model);

        public Task<InfrastructureResponse> DeleteWsExamenAsync(DeleteExamenRequest? model)
           => _ExamenApi.DeleteAsync(model);

        public Task<InfrastructureResponse> GetExamenesAsync(GetExamenRequest? model)
            => _ExamenService.GetAsync(model);

        public Task<InfrastructureResponse> GetWsExamenesAsync(GetExamenRequest? model)
            => _ExamenApi.GetAsync(model);

        public Task<InfrastructureResponse> UpdateExamenAsync(UpdateExamenRequest? model)
            => _ExamenService.UpdateAsync(model);

        public Task<InfrastructureResponse> UpdateWsExamenAsync(UpdateExamenRequest? model)
           => _ExamenApi.UpdateAsync(model);

        public void Dispose()
        {
            _ExamenService.Dispose();
            _ExamenApi.Dispose();
        }

    }
}
