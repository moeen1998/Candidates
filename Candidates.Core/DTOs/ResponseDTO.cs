using Candidates.Core.Enums;
using Candidates.Core.Helpers;

namespace Candidates.Core.DTOs;

public class ResponseDTO
{
    public ResponseDTO
        (ResponseStatusCode statusCode, bool success, dynamic? data = null, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? StatusCode.GetDescription();
        Data = data;
        Success = success;
    }

    public ResponseStatusCode StatusCode { get; set; }
    public string Status => StatusCode.GetDescription();
    public string Message { get; set; }
    public bool Success { get; set; }
    public dynamic? Data { get; set; }
}
