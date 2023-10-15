namespace TADuc_TravelMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatTour")]
    public partial class DatTour
    {
        [Key]
        [Column(Order = 0)]
        public int MaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTour { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDat { get; set; }

        public int SoLuong { get; set; }

        public decimal? Gia { get; set; }

        public decimal? ThanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
