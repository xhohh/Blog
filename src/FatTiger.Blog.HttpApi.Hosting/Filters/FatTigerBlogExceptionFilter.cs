using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatTiger.Blog.HttpApi.Hosting.Filters
{
    public class FatTigerBlogExceptionFilter : IExceptionFilter
    {
        private readonly ILog _log;

        public FatTigerBlogExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(FatTigerBlogExceptionFilter));
        }

        public void OnException(ExceptionContext context)
        {
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
