using System.IO;

namespace api.Tools
{
    public class Common
    {
        public static string ObtenerPlantillaContacto(string nombre, string correo, string telefono, string asunto, string mensaje)
        {
            string readText = File.ReadAllText("RespuestaContacto.html")
                .Replace("{{nombre}}", nombre)
                .Replace("{{correo}}", correo)
                .Replace("{{telefono}}", telefono)
                .Replace("{{asunto}}", telefono)
                .Replace("{{mensaje}}", mensaje);
            return readText;
        }
    }
}
