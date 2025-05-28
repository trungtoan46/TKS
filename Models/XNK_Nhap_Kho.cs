using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_XNK_Nhap_Kho")]
    public class XNK_Nhap_Kho
    {
        [Key]
        public string So_Phieu_Nhap_Kho { get; set; }
        [Required]
        public string NCC { get; set; }
        [Required]
        public string Kho { get; set; }
        [Required]
        public DateTime Ngay_Nhap_Kho { get; set; }
    }
}
