using System;

namespace lrms.Application.DTOs;

public class StandardReponse
{
    public required string Message { get; set; }
    public required int StatusCode { get; set; }
}
