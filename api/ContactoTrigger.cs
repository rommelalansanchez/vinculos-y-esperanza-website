using api.Models;
using api.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace VinculosyEsperanza.Functions
{
    public class ContactoTrigger
    {
        public ContactoTrigger()
        {

        }

        [FunctionName("ContactoTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Contacto data = JsonConvert.DeserializeObject<Contacto>(requestBody);

                RammarTech.Tools.EmailSender emailSender = new RammarTech.Tools.EmailSender();
                emailSender.SetSmtpServer(Environment.GetEnvironmentVariable("EmailSmtpServer"));
                emailSender.SetPort(Convert.ToInt16(Environment.GetEnvironmentVariable("EmailPort")));
                emailSender.SetAccountSending(Environment.GetEnvironmentVariable("EmailAccount"));
                emailSender.SetPassword(Environment.GetEnvironmentVariable("EmailPassword"));

                var mensaje = Common.ObtenerPlantillaContacto(data.Nombre, data.Correo, data.Telefono, data.Asunto, data.Mensaje);

                emailSender.Send(new System.Collections.Generic.List<string> { Environment.GetEnvironmentVariable("EmailSendTo") }, Environment.GetEnvironmentVariable("EmailDefaultSubject"), mensaje, Environment.GetEnvironmentVariable("EmailSenderName"));

                return new OkObjectResult(new { Message = "Mensaje enviado", Success = true });
            }
            catch (Exception)
            {
                return new OkObjectResult(new { Message = "Ha ocurrido un error", Success = false });
            }
            
        }
    }
}
