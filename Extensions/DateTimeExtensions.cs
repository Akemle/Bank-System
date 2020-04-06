using System;
using System.Collections.Generic;
using System.Text;
using BankSystem_exceptions.Entities.Exceptions;

namespace BankSystem_exceptions.Extensions
{
    static class DateTimeExtensions
    {   
        public static string ElapsedTime(this DateTime elapsTime)
        {
            if(elapsTime > DateTime.Now)
            {
                throw new DomainException("Date time does not match.");
            }
            TimeSpan duration = DateTime.Now.Subtract(elapsTime);   //SUBTRAINDO DO VALOR ATUAL A DATA DIGITADA 

            if (duration.TotalHours > 24)
            {
                return "modificado "+ duration.TotalDays.ToString("F1") + " dias atrás.";

            }
            else
            {
                return "modificado "+ duration.TotalHours.ToString("F1") + " horas atrás.";
            }
        }
    }
}
