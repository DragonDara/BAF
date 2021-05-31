using BAF.Entities.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAF.Controller.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly string jsonMimeType = @"application/problem+json";

        private static readonly IDictionary<Type, int> exceptionStatusCodes = new Dictionary<Type, int>
        {
            [typeof(UserAlreadyExistsException)] = StatusCodes.Status409Conflict,
        };

        public CustomExceptionMiddleware(
            RequestDelegate next,
            ILogger<CustomExceptionMiddleware> logger,
            IWebHostEnvironment environment
            )
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the API exception middleware will not be executed.");
                    throw;
                }

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var problemDetails = GetObjectByException(exception);

            problemDetails.Instance = httpContext.Request.Path;
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = problemDetails.Status.Value;
            httpContext.Response.ContentType = jsonMimeType;

            var serializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails, serializerSettings));
        }

        private ValidationProblemDetails GetObjectByException(Exception exception)
        {
            ValidationProblemDetails problem = new ValidationProblemDetails();
            int statusCode;

            switch (exception)
            {
                case UserAlreadyExistsException userAlreadyExistsException:
                    AddExceptionInfoToProblemDetails(problem, userAlreadyExistsException);
                    statusCode = GetStatusCodeByExceptionType(userAlreadyExistsException.GetType());
                    break;

                default:
                    problem.Title = "Internal server error.";
                    if (!_environment.IsProduction())
                    {
                        problem.Extensions["debug"] = exception;
                    }
                    statusCode = StatusCodes.Status500InternalServerError;
                    _logger.LogError(exception, exception.Message);
                    break;
            }
            problem.Status = statusCode;
            return problem;
        }

        private static void AddExceptionInfoToProblemDetails(ProblemDetails problemDetails, Exception exception)
        {
            problemDetails.Title = exception.Message;
            problemDetails.Type = exception.GetType().Name;
        }

        private static int GetStatusCodeByExceptionType(Type exceptionType)
        {
            foreach ((Type exceptionTypeKey, int statusCode) in exceptionStatusCodes)
            {
                if (exceptionTypeKey.IsAssignableFrom(exceptionType))
                {
                    return statusCode;
                }
            }
            return StatusCodes.Status500InternalServerError;
        }
    }

    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
