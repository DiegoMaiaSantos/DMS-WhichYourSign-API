﻿using System.Runtime.Serialization;

namespace DMS_WhichYourSign_API.Src.Application.Errors
{
    [Serializable]
    public class AppException : Exception
    {
        public int? StatusCode { get; set; }

        public AppException(string message) : base(message)
        {
        }

        public AppException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        protected AppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
