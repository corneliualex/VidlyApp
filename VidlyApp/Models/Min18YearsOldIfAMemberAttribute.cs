using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyApp.Models
{
    public class Min18YearsOldIfAMemberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required");

            return DateTime.Now.Year - customer.BirthDate.Value.Year >= 18 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old");
        }
    }
}