using Microsoft.AspNetCore.Mvc;
using WsApiExamen.Infrastructure.Abstract;
using WsApiExamen.Models;
using WsApiExamen.Models.Examen;

namespace WsApiExamen.Controllers
{
    /// <summary>
    /// Controlador para los métodos de examen
    /// </summary>
    /// <param name="_IExamenRepository">Interfaz con los métodos CRUD de examen</param>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamenController(IExamenRepository _IExamenRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AgregarExamen([FromBody] CreateExamenRequest? model)
        {
            InfrastructureResponse _Response = await _IExamenRepository.CreateAsync(model);
            return new JsonResult(value: _Response);
        }

        [HttpPost]
        public async Task<IActionResult> ConsultarExamen([FromBody] GetExamenRequest? model)
        {
            InfrastructureResponse _Response = await _IExamenRepository.GetAsync(model);
            return new JsonResult(value: _Response);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarExamen([FromBody] UpdateExamenRequest? model)
        {
            InfrastructureResponse _Response = await _IExamenRepository.UpdateAsync(model);
            return new JsonResult(value: _Response);
        }

        [HttpPut]
        public async Task<IActionResult> EliminarExamen([FromBody] DeleteExamenRequest? model)
        {
            InfrastructureResponse _Response = await _IExamenRepository.DeleteAsync(model);
            return new JsonResult(value: _Response);
        }

    }
}
