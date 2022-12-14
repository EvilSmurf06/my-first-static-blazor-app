using System.Linq;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using BlazorApp.Shared;
using System;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;

namespace Api
{
    public class ProductsGet
    {
        private readonly ILogger _logger;
 

        public ProductsGet(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ProductsGet>();
        }
       
        [Function("ProductsGet")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {


            var result =  new SendMail
            {
                Title = "Test Baþlýðý",
                Body = "Bu bir deneme mailidir.",

            };
 
            MailMessage message = new MailMessage();
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            message.From = new MailAddress("infoargeinvex@gmail.com");
            message.To.Add(new MailAddress("fatih.emecen98@gmail.com"));
            message.Subject = result.Title;
            message.IsBodyHtml = true;
            message.Body = result.Body;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("infoargeinvex@gmail.com", "tpomvynthxqdxmys");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
            
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(result);

            return response;
        }

       
    }
}
