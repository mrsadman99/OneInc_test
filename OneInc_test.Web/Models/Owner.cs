using OneInc_test.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneInc_test.Web.Models
{
    public class Owner
    {
        public Owner(string name,string surname,DateTime birthdate)
        {
            Name = name;
            Surname=surname;
            BirthDate = birthdate;
        }

        [Display(Name = "Owner name")]
        public string Name { get;private set; }
        [Display(Name = "Owner surname")]
        public string Surname { get;private set; }
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get;private set; }
    }
}