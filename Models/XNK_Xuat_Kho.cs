using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_XNK_Xuat_Kho")]
    public class XNK_Xuat_Kho
    {
        [Key]
        public string So_Phieu_Xuat_Kho { get; set; }
        [Required]
        public string Kho { get; set; }
        [Required]
        public DateTime Ngay_Xuat_Kho { get; set; }
    }
}
