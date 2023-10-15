namespace TADuc_TravelMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            DatTour = new HashSet<DatTour>();
        }

        [Key]
        public int MaTour { get; set; }

        [Required]
        [StringLength(150)]
        public string TenTour { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKhoiHanh { get; set; }
        public int SoNgay { get; set; }

        [Required]
        [StringLength(500)]
        public string HinhAnh { get; set; }

        public int Gia { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        public int? MaDanhMuc { get; set; }

        public virtual DanhMucTour DanhMucTour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatTour> DatTour { get; set; }
    }
}
