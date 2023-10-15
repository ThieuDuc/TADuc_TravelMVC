using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TADuc_TravelMVC.Models
{
    public class DanhGia
    {
        QLTravelModel db = new QLTravelModel();

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set;}

        [Required]
        [StringLength(30)]
        public string Email {  get; set; }

        [Required]
        [StringLength(12)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Mota { get; set;}
    }
}