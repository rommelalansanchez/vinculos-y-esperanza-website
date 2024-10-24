namespace api.Tools
{
    public class Common
    {
        public static string ObtenerPlantillaContacto(string nombre, string correo, string telefono, string asunto, string mensaje)
        {
            string readText = "Contacto desde la página web de Vínculos y Esperanza.\r\n<br />\r\n<strong>Datos de contacto</strong>\r\n<p>\r\n  <strong>Nombre:</strong> {{nombre}}\r\n  <br />\r\n  <strong>Asunto:</strong> {{asunto}}\r\n  <br />\r\n  <strong>Correo:</strong> {{correo}}\r\n  <br />\r\n  <strong>Teléfono:</strong> {{telefono}}\r\n  <br />\r\n  <strong>Mensaje:</strong> {{mensaje}}\r\n</p>\r\n"
                //File.ReadAllText("RespuestaContacto.html")
                .Replace("{{nombre}}", nombre)
                .Replace("{{correo}}", correo)
                .Replace("{{telefono}}", telefono)
                .Replace("{{asunto}}", telefono)
                .Replace("{{mensaje}}", mensaje);
            return readText;
        }
    }
}
