using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTruckAdminTools_v2.Models
{
    public class FoodTruck
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = Constants.Errors.InvalidLicensePlate)]
        public string LicensePlate { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = Constants.Errors.InvalidTruckMake)]
        public string TruckMake { get; set; }

        [StringLength(100, ErrorMessage = Constants.Errors.InvalidTruckModel)]
        public string TruckModel { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = Constants.Errors.InvalidColor)]
        public string Color { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = Constants.Errors.InvalidTruckName)]
        public string Name { get; set; }

        [Required]
        [Range(1950, 2100, ErrorMessage = Constants.Errors.InvalidTruckYear)]
        public int Year { get; set; }

        [NotMapped]
        public MealTypeEnum MealType { get; set; }

        [Required]
        public int MealTypeId { get; set; }

        [NotMapped]
        public CuisineCategoryEnum CuisineCategory { get; set; }

        [Required]
        public int CuisineCategoryId { get; set; }

        [Required]
        public PersonalInfo Driver { get; set; }

        public PersonalInfo CookInfo { get; set; }

        [Range(0, 1000)]
        public int MaxCapacityPerMeal { get; set; }

        [Required]
        public virtual List<ContactInfo> Contacts { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [StringLength(100, ErrorMessage = Constants.Errors.InvalidHealthCode)]
        public string HealthCode { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public List<string> AreaOfOperation
        {
            get
            {
                return JsonConvert.DeserializeObject<List<string>>(AreaOfOperationString);
            }
            set
            {
                AreaOfOperationString = JsonConvert.SerializeObject(value);
            }
        }

        public string AreaOfOperationString { get; set; }

        [NotMapped]
        public List<object> AdditionalInfo
        {
            get
            {
                return JsonConvert.DeserializeObject<List<object>>(AdditionalInfoString);
            }
            set
            {
                AdditionalInfoString = JsonConvert.SerializeObject(value);
            }
        }

        public string AdditionalInfoString { get; set; }
    }
}
