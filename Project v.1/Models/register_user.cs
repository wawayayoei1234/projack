using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Project_v._1.Models
{
    public class register_user
    {
        [BsonId]
        public string _id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 4)]
        [Display(Name = "UserName")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 4)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "ชื่อ-นามสกุล")]
        public string name_lastname { get; set; }

        [Display(Name = "รูปโปรไฟล์")]
        public string pictrue_profile { get; set; }

        [Display(Name = "รูปบัตรประจำตัวประชาชน")]
        public string pictrue { get; set; }
    }
}
