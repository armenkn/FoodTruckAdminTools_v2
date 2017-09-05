using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FoodTruckAdminTools_v2.Models
{
    public class FoodTruckCompany
    {
        public int ID { get; set; }

        public PersonalInfo OwnerInfo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = Constants.Errors.InvalidBusinessName)]
        public string BusinessName { get; set; }

        [NotMapped]
        public CompanyTypeEnum CompanyType
        {
            get
            {
                var enumItem = CompanyTypeEnum.None;
                Enum.TryParse(CompanyTypeName, out enumItem);
                return enumItem;
            }
            set
            {
                CompanyTypeName = value.ToString();
            }
        }

        [Required]
        public string CompanyTypeName { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = Constants.Errors.InvalidBusinessName)]
        public string PermitNumber { get; set; }

        private List<CuisineCategory> _cuisineCategories;

        public virtual List<CuisineCategory> CuisineCategories
        {
            get
            {
                _cuisineCategories = new List<CuisineCategory>();
                foreach (var item in CuisineCategoyNames)
                {
                    var cuisineCategoryEnumItem = CuisineCategoryEnum.None;
                    if (Enum.TryParse(item, out cuisineCategoryEnumItem))
                    {
                        _cuisineCategories.Add(new CuisineCategory
                        {
                            CategoryId = (int)cuisineCategoryEnumItem,
                            CategoryName = cuisineCategoryEnumItem.ToString()
                        });
                    }
                }
                return _cuisineCategories;
            }
            set
            {
                _cuisineCategories = value;
                CuisineCategoyNames = _cuisineCategories.Select(x => x.ToString()).ToList();
            }

        }

        [NotMapped]
        public List<string> CuisineCategoyNames { get; set; }

        [Required]
        public virtual List<OfficeLocation> OfficeLocations { get; set; }

        [Required]
        public virtual List<ContactInfo> Contacts { get; set; }

        [Required]
        public virtual List<Phone> PhoneNumbers { get; set; }

        private List<MealType> _mealTypes;

        [Required]
        public virtual List<MealType> MealTypes
        {
            get
            {
                _mealTypes = new List<MealType>();
                foreach (var item in MealTypeNames)
                {
                    var enumItem = MealTypeEnum.None;
                    if (Enum.TryParse(item, out enumItem))
                    {
                        _mealTypes.Add(new MealType
                        {
                            MealTypeId = (int)enumItem,
                            Type = enumItem.ToString()
                        });
                    }
                }
                return _mealTypes;
            }
            set
            {
                _mealTypes = value;
                MealTypeNames = _mealTypes.Select(x => x.ToString()).ToList();
            }
        }

        [NotMapped]
        public List<string> MealTypeNames { get; set; }

        public bool HasVegeterianFood { get; set; }

        public bool HasVigenFood { get; set; }

        public bool HasCatering { get; set; }

        [StringLength(100, ErrorMessage = Constants.Errors.InvalidHealthCode)]
        public string HealthCode { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public List<string> AreaOfOperation
        {
            get
            {
                return (string.IsNullOrWhiteSpace(AreaOfOperationString))? null : JsonConvert.DeserializeObject<List<string>>(AreaOfOperationString);
            }
            set
            {
                AreaOfOperationString = JsonConvert.SerializeObject(value);
            }
        }

        public string AreaOfOperationString { get; set; }

        [Required]
        public virtual List<FoodTruck> FoodTrucks { get; set; }

        [NotMapped]
        public List<object> AdditionalInfo
        {
            get
            {
                return (string.IsNullOrWhiteSpace(AdditionalInfoString))? null :  JsonConvert.DeserializeObject<List<object>>(AdditionalInfoString);
            }
            set
            {
                AdditionalInfoString = JsonConvert.SerializeObject(value);
            }
        }

        public string AdditionalInfoString { get; set; }
    }
}