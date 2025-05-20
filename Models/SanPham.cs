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
        public required string Ma_San_Pham { get; set; }
        [Required]
        public required string Ten_San_Pham { get; set; }
        public int Loai_San_Pham_ID { get; set; }
        public int Don_Vi_Tinh_ID { get; set; }
        public string? GhiChu { get; set; }
        
    }
}
