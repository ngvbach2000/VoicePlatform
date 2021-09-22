using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using VoicePlatform.Data.Application;

namespace VoicePlatform.Application.Configurations.Middleware
{
    public class AuthorizeAttribute : Attribute
    {
      
    }
}
