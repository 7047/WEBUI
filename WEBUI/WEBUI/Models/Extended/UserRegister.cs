using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WEBUI.Models
{
    [MetadataType(typeof(UserRegisterMetadata))]
    public partial class UserRegister
    {
        public string ConfirmPassword { get; set; }
    }
    public class UserRegisterMetadata
    {
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name require")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name require")]
        public string LastName { get; set; }



      
        [Display(Name ="Address")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Address is required")]
        public string Address { get; set; }
        [Display(Name ="Contact Number")]
     //   [RegularExpression("^[7 - 9][0 - 9]{9}$", ErrorMessage ="Must be Indian Contact no")]
        [DataType(DataType.PhoneNumber)]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Required")]
        public decimal ContactNo { get; set; }

        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id require")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required to enter City")]
        public string City { get; set; }
        [Display(Name = "Country")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country is Require")]
        public string Country { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password require")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 char")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password donot match")]
        public string ConfirmPassword { get; set; }


    }
}