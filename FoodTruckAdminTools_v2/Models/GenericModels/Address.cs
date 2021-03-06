﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTruckAdminTools_v2.Models
{
    public class Address
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(250, MinimumLength = 5, ErrorMessage = Constants.Errors.InvalidAddress1)]
        public string Address1 { get; set; }

        [StringLength(250, ErrorMessage = Constants.Errors.InvalidAddress2)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 2, ErrorMessage = Constants.Errors.InvalidCity)]
        public string City { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = Constants.Errors.InvalidZipcode)]
        public string Zipcode { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = Constants.Errors.InvalidState)]
        public string State { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        [NotMapped]
        public AddressTypeEnum AddressType{ get; set; }

        [Required]
        public int AddressTypeId { get; set; }
    }
}