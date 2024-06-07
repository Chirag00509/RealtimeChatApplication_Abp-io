using Acme.ChatAppss.EntityFrameworkCore;
using Acme.ChatApp.Loggs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Acme.ChatApp.Middleware
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;
        private readonly ChatAppssDbContext _dbcontext;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger, ChatAppssDbContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            var userName = context.User.Claims.FirstOrDefault(u => u.Type == "preferred_username");

            string ip = context.Connection.RemoteIpAddress?.ToString();

            //context.Request.EnableBuffering();
            //string RequestBody = await new System.IO.StreamReader(context.Request.Body).ReadToEndAsync();
            //context.Request.Body.Position = 0;

            string RequestBody = await getRequestBodyAsync(context.Request);

            string TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string UserName = null;

            if (userName != null)
            {
                UserName = userName.Value;
            }

            string log = $"IP: {ip}, Username: {UserName}, Timestamp: {TimeStamp}, Request Body: {RequestBody}";

            _logger.LogInformation(log);

            _dbcontext.Loggs.Add(new Logg
            {
                Ip = ip,
                RequestBody = RequestBody,
                TimeStamp = Convert.ToDateTime(TimeStamp),
                Username = UserName,
            });

            await _dbcontext.SaveChangesAsync();

            await next(context);
        }

        public async Task<string> getRequestBodyAsync(HttpRequest req)
        {
            req.EnableBuffering();

            using var reader = new StreamReader(req.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
            string requestBody = await reader.ReadToEndAsync();

            Console.WriteLine(requestBody);

            req.Body.Position = 0;

            return requestBody;
        }
    }
}