using System;
using CleanApiTemplate.Application.Common;

namespace CleanApiTemplate.Services.System
{
    public class DateTimeService: IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
