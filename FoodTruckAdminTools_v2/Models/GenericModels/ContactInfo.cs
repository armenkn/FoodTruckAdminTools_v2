using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTruckAdminTools_v2.Models
{
    public class ContactInfo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = Constants.Errors.InvalidContactText)]
        public string Contact { get; set; }

        [NotMapped]
        public ContactTypeEnum ContactType { get; set; }

        [Required]
        public int ContactTypeId { get; set; }

        public int DisplayOrder { get; set; }
    }
}
