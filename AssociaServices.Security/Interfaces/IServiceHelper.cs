using AssociaServices.Security.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AssociaServices.Security.Interfaces
{
    public interface IServiceHelper
    {
        ObjectResult CreateApiError(Exception ex);
        ResponseObject BuildResponse(string status, dynamic resData, string message, int resPonseCode);
        void LogDebug(string message);
        void LogError(string message);
        void LogWarning(string message);
        void LogInfo(string message);
    }
}
