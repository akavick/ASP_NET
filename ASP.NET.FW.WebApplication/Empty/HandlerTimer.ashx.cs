using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Empty
{
    /// <summary>
    /// Сводное описание для HandlerTimer
    /// </summary>
    public class HandlerTimer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(DateTime.Now.ToString(CultureInfo.CurrentCulture));
        }

        public bool IsReusable => false;
    }
}