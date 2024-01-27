using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSE_434_project.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }


        [Display(Name = "Name")]
        public string TeacherName { get; set; }
        public string Subject { get; set; }


        [Display(Name = "Joining Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> JoiningDate { get; set; }


        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DOB { get; set; }


        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<CLASSESS> Classesses { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}