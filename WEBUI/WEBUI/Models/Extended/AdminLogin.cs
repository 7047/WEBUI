using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBUI.Models
{
    [MetadataType(typeof(AdminLoginMetadata))]
    public partial class AdminLogin
    {
    }
    public class AdminLoginMetadata
    {
        [Display(Name = "User Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Display(Name ="Password")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}