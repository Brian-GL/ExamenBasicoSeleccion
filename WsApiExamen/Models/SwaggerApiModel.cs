namespace WsApiExamen.Models
{
    /// <summary>
    /// Modelo para asbtraer las configuraciones del swagger
    /// </summary>
    public class SwaggerApiModel
    {
        /// <summary>
        /// Crea un nuevo <see cref="SwaggerApiModel"/> con valores por defecto
        /// </summary>
        public SwaggerApiModel()
            => Title = Description = Version = TermsOfService = ContactName = ContactUrl = EndpointUrl = EndpointName = string.Empty;

        /// <summary>
        /// Título de la aplicación
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Descripción de la aplicación
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Versión de la aplicación
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Url de términos y condiciones de la aplicación
        /// </summary>
        public string TermsOfService { get; set; }

        /// <summary>
        /// Nombre de contacto de la aplicación
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Url de contacto de la aplicación
        /// </summary>
        public string ContactUrl { get; set; }

        /// <summary>
        /// Url de Swagger
        /// </summary>
        public string EndpointUrl { get; set; }

        /// <summary>
        /// Nombre de endpoint de Swagger
        /// </summary>
        public string EndpointName { get; set; }
    }
}
