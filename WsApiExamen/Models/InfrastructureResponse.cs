namespace WsApiExamen.Models
{
    /// <summary>
    /// Modelo para las salidas de los métodos de infrastructura
    /// </summary>
    public class InfrastructureResponse
    {
        /// <summary>
        /// Define si la respuesta es correcta
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// Define el mensaje de la respuesta
        /// </summary>
        public string Message { get; set; } = string.Empty;

        public object? Value {  get; set; }
    }
}
