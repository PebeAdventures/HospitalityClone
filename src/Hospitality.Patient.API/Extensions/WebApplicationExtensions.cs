﻿using Hospitality.Common.Middlewares;

namespace Hospitality.Patient.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void UseCustomMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
