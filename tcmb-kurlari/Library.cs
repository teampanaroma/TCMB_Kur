using System;

namespace tcmb_kurlari
{
    public class Library
    {
        public DateTime MoveDateNextOrPrev(string dateTime, int prevOrNext)
        {
            DateTime d1 = Convert.ToDateTime(dateTime);
            // + gün önümüzdeki tarihlere gitmek için – gün geçmiş günlere gitmek için
            d1 = d1.AddDays(prevOrNext);
            return d1;
        }

        public DateTime GetFirstDayOfMonth(DateTime dateTime)
        {
            DateTime dtFrom = dateTime;
            dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1));
            return dtFrom;
        }

        public DateTime GetLastDayOfMonth(DateTime dateTime)
        {
            DateTime dtTo = dateTime;
            dtTo = dtTo.AddMonths(1);
            dtTo = dtTo.AddDays(-(dtTo.Day));
            return dtTo;
        }

        public int GetDayFromDate(string dateTime)
        {
            return Convert.ToDateTime(dateTime).Day;
        }

        public int GetMonthFromDate(string dateTime)
        {
            return Convert.ToDateTime(dateTime).Month;
        }

        public int GetYearFromDate(string dateTime)
        {
            return Convert.ToDateTime(dateTime).Year;
        }
    }
}