using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;

public class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse? _response;

    public HttpResponse Response
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }

    protected override Task HandleException(BusinessException businessException)
    {
        var details = new BusinessProblemDetails(businessException.Message);
        
        Response.ContentType = "application/json";
        Response.StatusCode = StatusCodes.Status400BadRequest;
        return WriteAsJsonAsync(Response, details);
    } 

    protected override Task HandleException(ValidationException validationException)
    {
        var details = new ValidationProblemDetails(validationException.Errors);
        
        Response.ContentType = "application/json";
        Response.StatusCode = StatusCodes.Status400BadRequest;
        return WriteAsJsonAsync(Response, details);
    }

    protected override Task HandleException(AuthorizationException authorizationException)
    {
        var details = new AuthorizationProblemDetails(authorizationException.Message);
        
        Response.ContentType = "application/json";
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        return WriteAsJsonAsync(Response, details);
    }

    protected override Task HandleException(Exception exception)
    {
        var details = new InternalServerErrorProblemDetails(exception.Message);

        Response.ContentType = "application/json";
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        return WriteAsJsonAsync(Response, details);
    }
    private static Task WriteAsJsonAsync<T>(HttpResponse response, T value)
    {
        response.ContentType = "application/json";
        return JsonSerializer.SerializeAsync(response.Body, value);
    }
} 