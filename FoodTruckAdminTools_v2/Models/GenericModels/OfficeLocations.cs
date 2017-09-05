using System.Collections.Generic;

namespace FoodTruckAdminTools_v2.Models
{
    public class OfficeLocation
    {
        public int ID { get; set; }

        public Address Address { get; set; }

        public virtual List<Phone> PhoneNumbers { get; set; }

        public virtual List<WorkingDayHour> WorkingDayHours { get; set; }

    }
}
