using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;


namespace McShares.API.Filter
{
    public class JwtHeaderFilter : IOperationFilter
    {
        /// <summary>
        /// Adds an authorization header to the given operation in Swagger.
        /// </summary>
        /// <param name="operation">The Swashbuckle operation.</param>
        /// <param name="context">The Swashbuckle operation filter context.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            if (operation.Security == null)
                operation.Security = new List<OpenApiSecurityRequirement>();


            var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [scheme] = new List<string>()
            });

            //operation.Parameters.Add(new OpenApiParameter
            //{
            //    Description = "API version",
            //    In = ParameterLocation.Header,
            //    Name = "api-version",
            //    Required = false,
            //    Schema = new OpenApiSchema
            //    {
            //        Type = "String",
            //        //Default = new OpenApiString("1.0"),
            //    }
            //});
        }
    }
}
