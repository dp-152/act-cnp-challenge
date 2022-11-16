﻿namespace CnpChallenge.Application.Contracts.Exceptions;

public class ApplicationException : Exception
{
    protected ApplicationException() : base()
    { }

    protected ApplicationException(string? message) : base(message)
    { }
    
    protected ApplicationException(string? message, Exception? innerException) : base(message, innerException)
    { }
}
