using AppForSkills.Application.Common.Interfaces;
using System;

namespace AppForSkills.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
