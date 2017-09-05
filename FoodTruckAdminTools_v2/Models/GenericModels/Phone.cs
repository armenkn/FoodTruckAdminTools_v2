using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTruckAdminTools_v2.Models
{
    public class Phone
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = Constants.Errors.InvalidContactText)]
        public string PhoneNumber{ get; set; }

        [NotMapped]
        public PhoneTypeEnum PhoneType{ get; set; }

        [Required]
        public int PhoneTypeId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
