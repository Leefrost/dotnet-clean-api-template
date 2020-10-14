using System;
using CleanApiTemplate.Application.Common;

namespace CleanApiTemplate.Services.System
{
    public class DateService: IDateService
    {
        public DateTime Now => DateTime.Now;
    }
}
