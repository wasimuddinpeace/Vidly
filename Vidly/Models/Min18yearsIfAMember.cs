﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18yearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if ( customer.Birthdate == null)
                return new ValidationResult("Birth date is required");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18)
             ? ValidationResult.Success 
             : new ValidationResult("Customer should be more than 18 years to go on to membership");
               
            
        }
    }
}