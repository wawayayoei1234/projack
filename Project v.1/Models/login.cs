using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Project_v._1.Models
{
    public class login
    {
        [Required]
        [StringLength(150, MinimumLength = 6)]
        [Display(Name = "UserName")]
        public string idname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 4)]
        [Display(Name = "PassWord")]
        public string pword { get; set; }
    }
}
