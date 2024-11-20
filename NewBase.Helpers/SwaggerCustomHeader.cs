using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace NewBase.Helpers
{
    public class SwaggerCustomHeaderAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Language",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "String"
                },
                Example = new OpenApiString("ar"),
            });

            //operation.Parameters.Add(new OpenApiParameter
            //{
            //    Name = "SecretKey",
            //    In = ParameterLocation.Header,
            //    Required = false,
            //    Schema = new OpenApiSchema
            //    {
            //        Type = "String"
            //    },
            //    Example = new OpenApiString("5da5c05d484b5d2802ad194fe1dc96a214fa689ca17d4f8f53f2e8e13599fc92"),
            //});
        }
    }
}
