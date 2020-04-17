using AssociaServices.Security.Interfaces;
using AssociaServices.Security.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AssociaServices.Security.Logics
{
    public class ServiceHelper : IServiceHelper
    {
        private readonly ILogger<ServiceHelper> _log;
        public ServiceHelper(ILogger<ServiceHelper> log)
        {
            _log = log;
        }

        public ObjectResult CreateApiError(Exception ex)
        {
            _log.LogError(ex.Message);
            return new ObjectResult(new ResponseObject()
            {
                Status = "Error",
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                ResponseCode = new int?(500),
                Data = null
            });
        }

        public ResponseObject BuildResponse(string status, dynamic resData, string message, int resPonseCode)
        {
            var resObj = new ResponseObject()
            {
                Status = status,
                Message = message,
                StackTrace = null,
                ResponseCode = resPonseCode,
                Data = resData
            };
            return resObj;
        }

        public void LogDebug(string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
