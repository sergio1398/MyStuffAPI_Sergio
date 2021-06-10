using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace MyStuffAPI_Sergio.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.All)]
    public sealed class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {

        // aquí se crea un atributo que se va a usar como decoración en los controllers para agregar una capa de seguridad en el momento de consumir el recurso 
        private const string NombreDelApiKey = "ApiKey"; // "123QWE"

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(NombreDelApiKey, out var ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "No se ha suministrado un API Key"
                };


                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();


            var apiKey = appSettings.GetValue<string>(NombreDelApiKey);


            if (!apiKey.Equals(ApiSalida))
            {



                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Valores de Api Key son inválidos, no sea rata, se le instalaron 500 virus por playo "
                };
                return;



            }



            await next();



        }

    }
}
