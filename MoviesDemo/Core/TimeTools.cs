using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WkSoftware.Core
{
    public static class TimeTools
    {

        #region Extensiones

        /// <summary>
        /// Obtiene el número de semana en el año
        /// </summary>
        /// <param name="dt">Fecha a la que pertenece la semana</param>
        /// <returns>Devuelve un entero</returns>
        public static int GetWeekNumber(this DateTime dt)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public static int GetWeekOfYear(DateTime date) => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static double CalculateDaysUntil(this DateTime startDate, DateTime endDate)
        {
            TimeSpan tiempoendias = new TimeSpan();
            tiempoendias = endDate - startDate;
            double td = tiempoendias.TotalDays;
            return td;
        }

        /// <summary>
        /// Obtiene el número de años,mese y dias entre la fecha y una fecha final
        /// </summary>
        /// <param name="ini">Fecha inicial</param>
        /// <param name="end">Fecha final</param>
        /// <returns>Array de enteros con el número de años, meses y dias en ese orden</returns>
        public static int[] CalculateDurationUntil(this DateTime ini, DateTime end)
        {
            var yearIni = ini.Year;
            var yearEnd = end.Year;
            var monthIni = ini.Month;
            var monthEnd = end.Month;
            var dayIni = ini.Day;
            var dayEnd = end.Day;

            // Diferencia de años. 
            // final - (inicial + x + y)
            // x. Los meses inicial y final son iguales. Si el dia final es menor que el dia inicial, se suma 1. ( No ha llegado a un año justo)
            // y. El mes final es menor que el mes inicial. Se suma 1
            var years = yearEnd - (yearIni +
                (monthEnd == monthIni ? (dayEnd < dayIni ? 1 : 0) : 0) +
                (monthEnd < monthIni ? 1 : 0));



            // Diferencia de meses
            // x - y
            // x. Condición a. Si el mes final es mayor o igual que el mes inicial más Condición b.
            //    Condición b. El dia final es mayor o igual que el dia inicial, valor 1.
            // Si se sumple la condición a y b, x es el valor del mes, al contrario, es el valor del mes + 12
            // y. Mes inicial + 1 si la condición de dia final es mayor o igual que el dia inicial. 
            var months = (monthEnd >= (monthIni + (dayEnd >= dayIni ? 0 : 1)) ? monthEnd : (monthEnd + 12)) -
                (monthIni + (dayEnd >= dayIni ? 0 : 1));

            // diferencia de dias
            // x - y
            // x. Condición. si el dia final es mayor o igual que el dia inicial, su valor es el dia final, en caso contrario, el dia final + 30
            // y. Dia inicial
            var days = (dayEnd >= dayIni ? dayEnd : dayEnd + 30) - dayIni;

            return new int[] { years, months, days };
        }

        #endregion

        public static DateTime CalculateEaster(int año)
        {
            int a = año % 19;
            int b = año % 4;
            int c = año % 7;
            int k = año / 100;
            int p = (13 + 8 * k) / 25;
            int q = k / 4;
            int M = (15 - p + k - q) % 30;
            int N = (4 + k - q) % 7;
            int d = (19 * a + M) % 30;
            int e = (2 * b + 4 * c + 6 * d + N) % 7;
            int dia = 22 + d + e;
            int mes = 3;
            if (dia > 31)
            {
                dia -= 31;
                mes = 4;
            }
            return new DateTime(año, mes, dia);
        }

        public static double CalculateDaysFromTo(DateTime endDate, DateTime startDate)
        {
            TimeSpan tiempoendias = new TimeSpan();
            tiempoendias = endDate - startDate; 
            double td = tiempoendias.TotalDays;
            return td;
        }

        public static string GetPluralDays(double days)
        {
            return $"{days} {(days == 1 ? "día" : "días")}";
        }

        public static string CalculateDurationFromTo(DateTime ini, DateTime end)
        {
            return GetPluralYearsMonthsDays(CalculateDurationUntil(ini, end));
        }

        public static string GetYearsMonthsDays(DateTime date)
        {
            return CalculateDurationFromTo(date, DateTime.Now);
        }

       

        public static string GetPluralYearsMonthsDays(int[] values)
        {
            return $"{values[0]} {(values[0] == 1 ? "año" : "años")},  {values[1]} {(values[1] == 1 ? "mes" : "meses")} y {values[2]} {(values[2] == 1 ? "dia" : "dias")}";
        }
        public static string GetDateToString(double td)
        {

            double aux = td % 365;
            double years = (td - aux) / 365;
            double tm = aux % 30;
            double month = (aux - tm) / 30;
            double days = tm;

            return $"{years} {(years == 1 ? "año" : "años")},  {month} {(month == 1 ? "mes" : "meses")} y {days} {(days == 1 ? "dia" : "dias")},";
            
        }

        public static string GetTimeHM(double ts, string CadenaIni = "")
        {
            string horas = "";
            string minutos = "";
            //string segundos = "";

            double aux = ts % 60;
            double tm = (ts - aux) / 60;
            ts = Convert.ToInt32(aux);

            aux = tm % 60;
            double th = (tm - aux) / 60;
            tm = aux;


            if (th > 0)
            {
                var h = tm == 0 ? th == 1 ? " hora " : " horas " : th == 1 ? " hora, " : " horas, ";
                horas = th.ToString() + h;
            }


            if (tm > 0) { minutos = tm.ToString() + " min. "; }

            //if (ts >= 0) { segundos = ts.ToString() + " seg"; }


            string FinalString = CadenaIni + horas + minutos; //+ segundos;

            return FinalString;

        }

       

       

        public static DateTime GetNextFirstDayOfWeek(DateTime today, bool reverse = false)
        {

            var value = reverse ? -1 : 1;

            for (int i = 0; i < 7; i++)
            {
                today = today.AddDays(value);
                if (today.DayOfWeek == DayOfWeek.Monday)
                {
                    break;
                }
            }
            return today;
        }
        public static DateTime GetNextFirstDayOfMonth(DateTime today, bool reverse = false)
        {
            var value = reverse ? -1 : 1;
            var m = today.AddMonths(value);
            var month = m.Month;
            var year = m.Year;
            return new DateTime(year, month, 1);
        }

        public static int GetAge(DateTime? bd)
        {
            var now = DateTime.Now;
            var birthday = bd != null ? bd.Value : now;
            var nextBirthday = new DateTime(now.Year, birthday.Month, birthday.Day);
            return now.Year - (birthday.Year + ((nextBirthday - now).TotalDays > 0 ? 1 : 0));
        }
    }
}
