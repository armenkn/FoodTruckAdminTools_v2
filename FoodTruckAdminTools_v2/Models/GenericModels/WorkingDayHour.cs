using System;

namespace FoodTruckAdminTools_v2.Models
{
    public class WorkingDayHour
    {
        public int ID { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

    }
}
