using System;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FastEndpoints;
using luftborn_task.Endpoints.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SharedKernel.Guards;

namespace luftborn_task.Extentions;

public static class ExceptionHandlerExtensions
{
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app,
                                                                 ILogger? logger = null,
                                                                 bool logStructuredException = false,
                                                                 bool useGenericReason = false)
    {
        app.UseExceptionHandler(
            errApp =>
            {
                errApp.Run(
                    async context =>
                    {
                        HttpResponse response = context.Response;

                        // Will not use it is ref only
                        var req = context.Request;


                        response.ContentType = "application/json";

                        var exceptionHandlerPathFeature =
                                    context.Features.Get<IExceptionHandlerPathFeature>();

                        var _logger = context.Resolve<ILogger<ExceptionContext>>();
                        _logger.LogError(exceptionHandlerPathFeature.Error.Message);


                        response.StatusCode = (int)HttpStatusCode.OK;
                        BaseResponse responseObject;

                        if (exceptionHandlerPathFeature.Error is BusinessLogicException)
                        {
                            responseObject = new BaseResponse()
                            {
                                IsSuccess = false,
                                Message = exceptionHandlerPathFeature.Error.Message
                            };
                        }
                        else
                        {
                            responseObject = new BaseResponse()
                            {
                                IsSuccess = false,
                                Message = "An error occurred while processing your request"
                            };
                        }

                        await response.WriteAsJsonAsync(responseObject);
                    });
            });

        return app;
    }
}