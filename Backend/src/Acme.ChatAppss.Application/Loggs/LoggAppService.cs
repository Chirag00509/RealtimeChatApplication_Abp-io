using Acme.ChatAppss.EntityFrameworkCore;
using Acme.ChatApp.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.ChatApp.Loggs
{
    public class LoggAppService : ApplicationService
    {
        private readonly ChatAppssDbContext _context;

        public LoggAppService(ChatAppssDbContext context)
        {
            _context = context;
        }

        public async Task<ListResultDto<LoggDto>> GetLogs(DateTime? startTime, DateTime? endTime)
        {
            IEnumerable<Logg> loggsQuery = _context.Loggs;

            if (startTime.HasValue)
            {
                loggsQuery = loggsQuery
                    .Where(log => log.TimeStamp >= startTime && (!endTime.HasValue || log.TimeStamp <= endTime));
            }
            else if (endTime.HasValue)
            {
                loggsQuery = loggsQuery
                    .Where(log => log.TimeStamp <= endTime);
            }

            var loggs = loggsQuery
                .Select(u => new LoggDto
                {
                    Id = Convert.ToString(u.Id),
                    Ip = u.Ip,
                    Username = u.Username,
                    RequestBody = u.RequestBody.Replace("\n", "").Replace("\"", "").Replace("\r", ""),
                    TimeStamp = u.TimeStamp,
                }).ToList();

            return new ListResultDto<LoggDto>(loggs);
        }
    }
}
