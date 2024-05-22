namespace WsApiExamen.Models
{
    public class SpecificInfrastructureResponse<T>
    {
        /// <summary>
        /// Define si la respuesta es correcta
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// Define el mensaje de la respuesta
        /// </summary>
        public string Message { get; set; } = string.Empty;

        public T? Value { get; set; }
    }
}
