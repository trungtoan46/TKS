using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_DM_Xuat_Kho")]
    public class XuatKho
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string So_Phieu_Xuat_Kho { get; set; }
        [Required]
        public int Kho_ID { get; set; }
        [Required]
        public DateTime Ngay_Xuat_Kho { get; set; }
        public string Ghi_Chu {  get; set; }
    }
}
