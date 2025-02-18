using System;
using System.Collections.Generic;


public class ValidationException : Exception
{
    public IEnumerable<ValidationExceptionModel> Errors { get; }

    public ValidationException(IEnumerable<ValidationExceptionModel> errors) : 
    base("Validation error(s) occurred")
    {
        Errors = errors;
    }

public class ValidationExceptionModel
{
    public string Property { get; set; }
    public string Message { get; set; }
    public ValidationExceptionModel(string property, string message)
    {
        Property = property;
        Message = message;
    }
}
}
