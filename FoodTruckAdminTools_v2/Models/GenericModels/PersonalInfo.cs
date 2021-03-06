﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTruckAdminTools_v2.Models
{
    public class PersonalInfo
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = Constants.Errors.InvaidFirstName, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ,.'-]*[a-zA-Z]$")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = Constants.Errors.InvaidLastName, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ,.'-]*[a-zA-Z]$")]
        public string LastName { get; set; }

        [StringLength(200, ErrorMessage = Constants.Errors.InvaidLastName)]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ,.'-]*[a-zA-Z]$")]
        public string  MiddleName { get; set; }

        [RegularExpression(@"^[0-9]{9}$")]
        public string SSN { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual List<ContactInfo> Contacts { get; set; }

        public virtual List<Phone> PhoneNumbers { get; set; }

        [NotMapped]
        public PersonRoleEnum Role { get; set; }
        
        [Required]
        public int RoleId { get; set; }

        public Address Address { get; set; }

    }
}
