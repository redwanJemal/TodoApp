﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message = null, string detail = null) : base(statusCode, message)
        {
            Details = detail;
        }

        public string Details { get; set; }
    }
}
