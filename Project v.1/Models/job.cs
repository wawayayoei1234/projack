using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_v._1.Models
{
    public class job
    {
        [BsonId]
        public string _id { get; set; }

        [Display(Name = "รูปภาพงาน")]
        public string pictruejob { get; set; }

        [Display(Name = "ชื่องาน")]
        [StringLength(150)]
        public string namejob { get; set; }

        [Display(Name = "รายละเอียดงาน")]
        [StringLength(250)]
        public string detail { get; set; }

        [Display(Name = "เบอร์โทรศัพท์")]
        public string phone { get; set; }

        [Display(Name = "สถานที่")]
        public string location { get; set; }

        [Display(Name = "ราคางาน")]
        public string price { get; set; }
    }
}
