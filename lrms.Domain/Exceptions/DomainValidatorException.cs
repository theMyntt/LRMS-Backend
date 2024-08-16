using System;

namespace lrms.Domain.Exceptions;

public class DomainValidatorException(string message) : Exception(message)
{
    public static void When(bool hasError, string message)
    {
        if (hasError)
        {
            throw new DomainValidatorException(message);
        }
    }
}
