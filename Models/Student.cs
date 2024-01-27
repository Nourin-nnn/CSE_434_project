/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSE_434_project.Models
{
    public class Student
    {
        public int StudentID { get; set; }


        [Required(ErrorMessage = "This Field is Required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "You Must Give Minimum 3 and Maximum 20 Character")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }


        [Required(ErrorMessage = "This Field is Required!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "You Must Give Minimum 2 and Maximum 20 Character")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }


        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email Address")]
        //[Remote("EmailisExists", "MyStudent", ErrorMessage = "This Email Address Exist")]
        public string Email { get; set; }


        [StringLength(11, MinimumLength = 11, ErrorMessage = "You Must Give 11 Character")]
        [Required(ErrorMessage = "This Field is Required!")]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }

        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Mobile")]
        [Display(Name = "Confirm Mobile Number")]
        public string ConfirmMobile { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [MyDateTimeValidation(ErrorMessage = "Date Must be 1990 and 2014")] //custom validator
        [Display(Name = "Date OF Birth")]
        public Nullable<System.DateTime> DOB { get; set; }
        
        [Required(ErrorMessage = "This Field is Required!")]
        public string Shift { get; set; }
        public string Address { get; set; }

        [Required]
        public string Picture { get; set; }
        public Nullable<bool> Status { get; set; } = false;
        

        public int ClassID { get; set; }
        public virtual CLASSESS Classess { get; set; }

        public int ParentID { get; set; }
        public virtual Parent Parent { get; set; }


        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }

        
    }
}*/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSE_434_project.Models
{
    public class Student
    {
        public int StudentID { get; set; }


        [Required(ErrorMessage = "This Field is Required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "You Must Give Minimum 3 and Maximum 20 Character")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }


        [Required(ErrorMessage = "This Field is Required!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "You Must Give Minimum 2 and Maximum 20 Character")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }


        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email Address")]
        //[Remote("EmailisExists", "MyStudent", ErrorMessage = "This Email Address Exist")]
        public string Email { get; set; }


        [StringLength(11, MinimumLength = 11, ErrorMessage = "You Must Give 11 Character")]
        [Required(ErrorMessage = "This Field is Required!")]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }

        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Mobile")]
        [Display(Name = "Confirm Mobile Number")]
        public string ConfirmMobile { get; set; }


        public string Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [MyDateTimeValidation(ErrorMessage = "Date Must be 1990 and 2014")] //custom validator
        [Display(Name = "Date OF Birth")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        public string Shift { get; set; }
        public string Address { get; set; }

        public string Picture { get; set; }
        public Nullable<bool> Status { get; set; } = false;


        public int ClassID { get; set; }
        public virtual CLASSESS Classess { get; set; }

        public int ParentID { get; set; }
        public virtual Parent Parent { get; set; }


        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }


    }
}
