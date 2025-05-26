using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_DM_San_Pham")]
    public class SanPham
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Chỉ được chứa chữ cái và số.")]

        public required string Ma_San_Pham { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Chỉ được chứa chữ cái và số.")]

        public required string Ten_San_Pham { get; set; }

        public int Loai_San_Pham_ID { get; set; }
        public LoaiSanPham? loaiSanPham { get; set; }

        public int Don_Vi_Tinh_ID { get; set; }
        public DonViTinh? donViTinh { get; set; }

        public string? GhiChu { get; set; }
        
    }
}
