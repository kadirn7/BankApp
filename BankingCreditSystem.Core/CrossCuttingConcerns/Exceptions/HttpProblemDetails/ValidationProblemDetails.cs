
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public IEnumerable<ValidationException.ValidationExceptionModel> Errors { get; init; }

        public ValidationProblemDetails(IEnumerable<ValidationException.ValidationExceptionModel> errors)
        {
            Title = "Validation error(s)";
            Detail = "One or more validation errors occurred.";
            Errors = errors;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://example.com/probs/validation";
        }
    }
} 