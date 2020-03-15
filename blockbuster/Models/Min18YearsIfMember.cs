using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace blockbuster.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthday == null)
            {
                return new ValidationResult("Birth Date is required");
            }
            var age = ((DateTime.Today.Month > customer.Birthday.Value.Month)||
                (DateTime.Today.Month == customer.Birthday.Value.Month && DateTime.Today.Day >= customer.Birthday.Value.Day))
                ?(DateTime.Today.Year - customer.Birthday.Value.Year)
                : (DateTime.Today.Year - customer.Birthday.Value.Year - 1);

            return (age < 18)
                ? new ValidationResult("Customer must be atleast 18 for membership")
                : ValidationResult.Success;
        }
    }
}