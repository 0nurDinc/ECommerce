using ECommerce.Domain.EntitesDataAttribute;
using ECommerce.Domain.EntitesException;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities.Common
{
    public abstract class Person:BaseEntity
    {
        private DateTime _birthOfDate;

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name less than 3 characters or more than 60 characters.")]
        public string FirstName { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Surname less than 3 characters or more than 60 characters.")]
        public string LastName { get; set; }


        [Display(Name = "Phone")]
        [TurkeyPhone(ErrorMessage = "The phone number was not entered in the correct format.")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Email Addres")]
        [Required(ErrorMessage = "This field cannot be left blank.")]
        [StringLength(150, MinimumLength = 15, ErrorMessage = "The e-mail address can be a minimum of 15 characters and a maximum of 150 characters.")]
        public string EmailAddress { get; set; }


        public DateTime BirthOfDate
        {
            get
            {
                return _birthOfDate;
            }
            set
            {
                TimeSpan timeDifference = DateTime.Now - value;
                if (timeDifference.TotalDays > 18 * 365)
                    _birthOfDate = value;
                else
                    throw new AgeException("Persons under the age of 18 cannot be employed.");
            }
        }
    }
}
