namespace TADuc_TravelMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            DatTour = new HashSet<DatTour>();
        }

        [Key]
        public int MaDon { get; set; }

        public DateTime NgayDat { get; set; }

        public decimal TongTien { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        [Required]
        [StringLength(50)]
        public string DiemDen { get; set; }

        public int SoNgay { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDi { get; set; }

        public decimal Gia { get; set; }

        [Required]
        [StringLength(50)]
        public string PhuongThucTT { get; set; }

        public int MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatTour> DatTour { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
