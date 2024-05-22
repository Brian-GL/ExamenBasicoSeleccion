using ApiExamen.Extensions;
using ApiExamen.Infrastructure.Abstract;
using ApiExamen.Models;
using ApiExamen.Models.Examen;
using ApiExamen.Validators;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ApiExamen.Infrastructure.Concrete
{
    public class ExamenService : IExamenService, IDisposable
    {
        private readonly SqlConnection _SqlConnection;

        public ExamenService()
        {
            _SqlConnection = new SqlConnection(connectionString: "data source=localhost; initial catalog=BdiExamen;persist security info=True; Integrated Security=SSPI;");
            _SqlConnection.Open();
        }


        public async Task<InfrastructureResponse> CreateAsync(CreateExamenRequest? model)
        {
            InfrastructureResponse _Response;

            try
            {

                // Validar modelo:
                CreateExamenRequestValidator _Validator = new();
                _Response = await _Validator.ValidateModelAsync(model);

                if (!_Response.Success)
                    return _Response;

                // Llamar sp:
                DynamicParameters parameters = new();
                parameters.Add(name: "@Nombre", value: model!.Nombre, dbType: DbType.String, direction: ParameterDirection.Input, size: 255);
                parameters.Add(name: "@Descripcion", value: model.Descripcion, dbType: DbType.String, direction: ParameterDirection.Input, size: 255);

                IEnumerable<BdActionResponse> _Responses = await _SqlConnection.QueryAsync<BdActionResponse>(sql: "dbo.spAgregar", param: parameters);

                if (_Responses.Any())
                {
                    _Response = _Responses.First().GetBdResponse();
                }
                else 
                {
                    _Response = new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder a la base de datos"
                    };
                }
            }
            catch(Exception ex)
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

                // Validar modelo:
                DeleteExamenRequestValidator _Validator = new();
                _Response = await _Validator.ValidateModelAsync(model);

                if (!_Response.Success)
                    return _Response;

                // Llamar sp:
                DynamicParameters parameters = new();
                parameters.Add(name: "@IdExamen", value: model!.IdExamen, dbType: DbType.Int32, direction: ParameterDirection.Input);

                IEnumerable<BdActionResponse> _Responses = await _SqlConnection.QueryAsync<BdActionResponse>(sql: "dbo.spEliminar", param: parameters);

                if (_Responses.Any())
                {
                    _Response = _Responses.First().GetBdResponse();

                }
                else
                {
                    _Response = new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder a la base de datos"
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
                // Validar modelo:
                if (model is null)
                {
                    return new InfrastructureResponse
                    {
                        Success = false,
                        Message = "El modelo de entrada se encuentra nulo"
                    };
                }

                // Llamar sp:
                DynamicParameters parameters = new();
                parameters.Add(name: "@IdExamen", value: model!.IdExamen, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add(name: "@Nombre", value: model.Nombre, dbType: DbType.String, direction: ParameterDirection.Input, size: 255);
                parameters.Add(name: "@Descripcion", value: model.Descripcion, dbType: DbType.String, direction: ParameterDirection.Input, size: 255);

                IEnumerable<GetExamenBdResponse> _Responses = await _SqlConnection.QueryAsync<GetExamenBdResponse>(sql: "dbo.spConsultar", param: parameters);

                if (_Responses.Any())
                {
                    _Response = new()
                    {
                        Success = true,
                        Message = "OK",
                        Value = _Responses.ToList()
                    };
                }
                else
                {
                    _Response = new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No se encontraron registros"
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

                // Validar modelo:
                CreateExamenRequestValidator _Validator = new();
                _Response = await _Validator.ValidateModelAsync(model);

                if (!_Response.Success)
                    return _Response;

                // Llamar sp:
                DynamicParameters parameters = new();
                parameters.Add(name: "@IdExamen", value: model!.IdExamen, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add(name: "@Nombre", value: model.Nombre, dbType: DbType.String, direction: ParameterDirection.Input, size: 255);
                parameters.Add(name: "@Descripcion", value: model.Descripcion, dbType: DbType.String, direction: ParameterDirection.Input, size: 255);

                IEnumerable<BdActionResponse> _Responses = await _SqlConnection.QueryAsync<BdActionResponse>(sql: "dbo.spActualizar", param: parameters);

                if (_Responses.Any())
                {
                    _Response = _Responses.First().GetBdResponse();

                }
                else
                {
                    _Response = new()
                    {
                        Success = false,
                        Message = "Lo sentimos. No conseguimos acceder a la base de datos"
                    };
                }
            }
            catch (Exception ex)
            {
                _Response = ex.GetExceptionResponse();
            }

            return _Response;
        }

        public void Dispose()
        {
            _SqlConnection.Close();
            _SqlConnection.Dispose();
        }

    }
}
