using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSDynamoDBwithNetCore.WebAPI.Filters
{
    public class ResponseTimeActionFilter : IActionFilter
    {
        private const string ResponseTimeKey = "ResponseTimeKey";

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var startTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            string action = context.RouteData.Values["action"].ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append('=', 10).AppendFormat(" Method: {0} ", action).Append('=', 10);
            sb.AppendLine();
            sb.AppendFormat("Start Time: {0}", startTime);
            sb.AppendLine();
            LogResponseTime(sb.ToString());

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var endTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            string action = context.RouteData.Values["action"].ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append('=', 10).AppendFormat(" Method: {0} ", action).Append('=', 10);
            sb.AppendLine();
            sb.AppendFormat("End Time: {0}", endTime);
            sb.AppendLine();
            LogResponseTime(sb.ToString());

        }

        private void LogResponseTime(string response)
        {
            string filepath = @"ResponseLog/";  //Text File Path

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);

            }
            filepath = filepath + "ResponseLog-" + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Dispose();
            }

            File.AppendAllText(filepath, response);
        }
    }
}
