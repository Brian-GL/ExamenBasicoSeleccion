using ApiExamen.Extensions;
using ApiExamen.Infrastructure.Abstract;
using ApiExamen.Models;
using ApiExamen.Models.Examen;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;

namespace ApiExamen.Infrastructure.Concrete
{
    public class ExamenApi : IExamenApi, IDisposable
    {
        private readonly HttpClient _HttpClient;

        public ExamenApi()
        {
            _HttpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:44364/api/"),
                Timeout = TimeSpan.FromMinutes(5D)
            };
        }

        public async Task<InfrastructureResponse> CreateAsync(CreateExamenRequest? model)
        {
            InfrastructureResponse _Response;

            try
            {

                // Llamar API

                using StringContent stringContent = new(content: JsonConvert.SerializeObject(model), encoding: Encoding.UTF8, mediaType: MediaTypeNames.Application.Json);
                using HttpResponseMessage responseMessage = await _HttpClient.PostAsync(requestUri: string.Concat(_HttpClient.BaseAddress, "Examen/AgregarExamen"), stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string body = await responseMessage.Content.ReadAsStringAsync();
                    _Response = JsonConvert.DeserializeObject<InfrastructureResponse>(body) ?? new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder al web service"
                    }; ;
                }
                else
                {
                    _Response = new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder al web service"
                    };
                }
            }
            catch (Exception ex)
            {
                _Response = ex.GetExceptionResponse();
            }

            return _Response;
        }

        public async Task<InfrastructureResponse> DeleteAsync(DeleteExamenRequest? model)
        {
            InfrastructureResponse _Response;

            try
            {

                // Llamar API

                using StringContent stringContent = new(content: JsonConvert.SerializeObject(model), encoding: Encoding.UTF8, mediaType: MediaTypeNames.Application.Json);
                using HttpResponseMessage responseMessage = await _HttpClient.PutAsync(requestUri: string.Concat(_HttpClient.BaseAddress, "Examen/EliminarExamen"), stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string body = await responseMessage.Content.ReadAsStringAsync();
                    _Response = JsonConvert.DeserializeObject<InfrastructureResponse>(body) ?? new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder al web service"
                    }; ;
                }
                else
                {
                    _Response = new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder al web service"
                    };
                }
            }
            catch (Exception ex)
            {
                _Response = ex.GetExceptionResponse();
            }

            return _Response;
        }

        public async Task<InfrastructureResponse> GetAsync(GetExamenRequest? model)
        {
            InfrastructureResponse _Response;

            try
            {

                // Llamar API

                using StringContent stringContent = new(content: JsonConvert.SerializeObject(model), encoding: Encoding.UTF8, mediaType: MediaTypeNames.Application.Json);
                using HttpResponseMessage responseMessage = await _HttpClient.PostAsync(requestUri: string.Concat(_HttpClient.BaseAddress, "Examen/ConsultarExamen"), stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string body = await responseMessage.Content.ReadAsStringAsync();

                    SpecificInfrastructureResponse<List<GetExamenBdResponse>> _PrevResponse
                        = JsonConvert.DeserializeObject<SpecificInfrastructureResponse<List<GetExamenBdResponse>>>(body) ?? new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder al web service",
                        Value = []
                    };

                    _Response = new()
                    {
                        Success = _PrevResponse.Success,
                        Message = _PrevResponse.Message,
                        Value = _PrevResponse.Value

                    };
                }
                else
                {
                    _Response = new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder al web service"
                    };
                }
            }
            catch (Exception ex)
            {
                _Response = ex.GetExceptionResponse();
            }

            return _Response;
        }

        public async Task<InfrastructureResponse> UpdateAsync(UpdateExamenRequest? model)
        {
            InfrastructureResponse _Response;

            try
            {

                // Llamar API

                using StringContent stringContent = new(content: JsonConvert.SerializeObject(model), encoding: Encoding.UTF8, mediaType: MediaTypeNames.Application.Json);
                using HttpResponseMessage responseMessage = await _HttpClient.PutAsync(requestUri: string.Concat(_HttpClient.BaseAddress, "Examen/ActualizarExamen"), stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string body = await responseMessage.Content.ReadAsStringAsync();
                    _Response = JsonConvert.DeserializeObject<InfrastructureResponse>(body) ?? new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder al web service"
                    }; ;
                }
                else
                {
                    _Response = new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder al web service"
                    };
                }
            }
            catch (Exception ex)
            {
                _Response = ex.GetExceptionResponse();
            }

            return _Response;
        }

        public void Dispose() => _HttpClient.Dispose();
    }
}
