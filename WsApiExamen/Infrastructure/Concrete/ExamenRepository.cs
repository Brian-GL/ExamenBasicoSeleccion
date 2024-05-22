using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WsApiExamen.Entities;
using WsApiExamen.Extensions;
using WsApiExamen.Infrastructure.Abstract;
using WsApiExamen.Models;
using WsApiExamen.Models.Examen;
using WsApiExamen.Validators;

namespace WsApiExamen.Infrastructure.Concrete
{
    public class ExamenRepository(ExamenDbContext _DbContext) : IExamenRepository
    {
        public async Task<InfrastructureResponse> CreateAsync(CreateExamenRequest? model)
        {
            InfrastructureResponse _Response = new()
            {
                Success = false,
                Message = "Lo sentimos. No conseguimos acceder a la base de datos"
            };

            try
            {
                // Validar modelo:
                CreateExamenRequestValidator _Validator = new();
                _Response = await _Validator.ValidateModelAsync(model);

                if (!_Response.Success)
                    return _Response;

                // Llamar sp:
                using SqlConnection sqlConnection = new(connectionString: _DbContext.Database.GetConnectionString());
                await sqlConnection.OpenAsync();

                SqlCommand command = new("INSERT INTO dbo.tblExamen (Nombre,Descripcion) VALUES(@Nombre,@Descripcion)", sqlConnection)
                {
                    Transaction = sqlConnection.BeginTransaction()
                };

                command.Parameters.AddWithValue("@Nombre", (object?)model!.Nombre ?? DBNull.Value);
                command.Parameters.AddWithValue("@Descripcion", (object?)model.Descripcion ?? DBNull.Value);

                try
                {
                    using SqlDataReader reader = await command.ExecuteReaderAsync();

                    BdActionResponse bdActionResponse = new()
                    {
                        Codigo = 1,
                        Mensaje = "Registro insertado satisfactoriamente",
                    };

                    _Response = bdActionResponse.GetBdResponse();

                    await command.Transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _Response = ex.GetExceptionResponse();
                    await command.Transaction.RollbackAsync();
                }
                await sqlConnection.CloseAsync();
            }
            catch (Exception ex)
            {
                _Response = ex.GetExceptionResponse();
            }

            return _Response;
        }

        public async Task<InfrastructureResponse> DeleteAsync(DeleteExamenRequest? model)
        {
            InfrastructureResponse _Response = new()
            {
                Success = false,
                Message = "Lo sentimos. No conseguimos acceder a la base de datos"
            };

            try
            {
                // Validar modelo:
                DeleteExamenRequestValidator _Validator = new();
                _Response = await _Validator.ValidateModelAsync(model);

                if (!_Response.Success)
                    return _Response;

                // Llamar sp:
                using SqlConnection sqlConnection = new(connectionString: _DbContext.Database.GetConnectionString());
                await sqlConnection.OpenAsync();

                SqlCommand command = new("DELETE FROM dbo.tblExamen WHERE IdExamen = @IdExamen AND Activo = 1", sqlConnection)
                {
                    Transaction = sqlConnection.BeginTransaction()
                };
                command.Parameters.AddWithValue("@IdExamen", (object?)model!.IdExamen ?? DBNull.Value);

                try
                {
                    using SqlDataReader reader = await command.ExecuteReaderAsync();

                    BdActionResponse bdActionResponse = new()
                    {
                        Codigo = 1,
                        Mensaje = "Registro eliminado satisfactoriamente",
                    };

                    _Response = bdActionResponse.GetBdResponse();

                    await command.Transaction.CommitAsync();

                }
                catch (Exception ex)
                {
                    _Response = ex.GetExceptionResponse();
                    await command.Transaction.RollbackAsync();
                }

                await sqlConnection.CloseAsync();
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

                List<GetExamenBdResponse> _Responses = [];

                using (SqlConnection sqlConnection = new(connectionString: _DbContext.Database.GetConnectionString()))
                {
                    await sqlConnection.OpenAsync();

                    SqlCommand command = new("SELECT T0.IdExamen, T0.Nombre, T0.Descripcion FROM dbo.tblExamen T0 WITH(NOLOCK) WHERE T0.IdExamen = ISNULL(@IdExamen, T0.IdExamen) AND ISNULL(T0.Nombre, '1') = ISNULL(@Nombre, ISNULL(T0.Nombre, '1')) AND ISNULL(T0.Descripcion, '1') = ISNULL(@Descripcion, ISNULL(T0.Descripcion, '1')) AND T0.Activo = 1", sqlConnection);
                    command.Parameters.AddWithValue("@IdExamen", (object?)model!.IdExamen ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Nombre", (object?)model.Nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Descripcion", (object?)model.Descripcion ?? DBNull.Value);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            _Responses.Add(new GetExamenBdResponse
                            {
                                IdExamen = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2)
                            });
                        }
                    }

                    await sqlConnection.CloseAsync();
                }

                if (_Responses.Count > 0)
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
            InfrastructureResponse _Response = new()
            {
                Success = false,
                Message = "Lo sentimos. No conseguimos acceder a la base de datos"
            };

            try
            {
                // Validar modelo:
                UpdateExamenRequestValidator _Validator = new();
                _Response = await _Validator.ValidateModelAsync(model);

                if (!_Response.Success)
                    return _Response;

                // Llamar sp:
                using SqlConnection sqlConnection = new(connectionString: _DbContext.Database.GetConnectionString());
                await sqlConnection.OpenAsync();

                SqlCommand command = new("UPDATE T0 SET T0.Nombre = @Nombre, T0.Descripcion = @Descripcion FROM dbo.tblExamen T0 WITH(NOLOCK) WHERE t0.IdExamen = @IdExamen AND T0.Activo = 1", sqlConnection)
                {
                    Transaction = sqlConnection.BeginTransaction()
                };
                command.Parameters.AddWithValue("@IdExamen", (object?)model!.IdExamen ?? DBNull.Value);
                command.Parameters.AddWithValue("@Nombre", (object?)model!.Nombre ?? DBNull.Value);
                command.Parameters.AddWithValue("@Descripcion", (object?)model.Descripcion ?? DBNull.Value);
                
                try
                {
                    using SqlDataReader reader = await command.ExecuteReaderAsync();

                    BdActionResponse bdActionResponse = new()
                    {
                        Codigo = 1,
                        Mensaje = "Registro actualizado satisfactoriamente",
                    };

                    _Response = bdActionResponse.GetBdResponse();

                    await command.Transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _Response = ex.GetExceptionResponse();
                    await command.Transaction.RollbackAsync();
                }

                await sqlConnection.CloseAsync();
            }
            catch (Exception ex)
            {
                _Response = ex.GetExceptionResponse();
            }

            return _Response;
        }
    }
}
