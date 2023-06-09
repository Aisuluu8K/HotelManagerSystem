﻿using System.Net;
using HotelManagerSystem.API.Responses;
using HotelManagerSystem.BL.DbLogger;
using HotelManagerSystem.DAL.Responses;
using Microsoft.AspNetCore.Diagnostics;

namespace HotelManagerSystem.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response
                            .WriteAsync(new Response(
                                context.Response.StatusCode,
                                false,
                                contextFeature.Error.Message)
                            .ToString());
                        
                    }
                });
            });
        }
        public static ILoggingBuilder AddDbLogger(this ILoggingBuilder builder, Action<DbLoggerOptions> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, DbLoggerProvider>();
            builder.Services.Configure(configure);
            return builder;
        }
    }
}
