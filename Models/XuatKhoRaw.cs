using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_DM_Xuat_Kho_Raw_Data")]
    public class XuatKhoRaw
    {
        [Key]
        public int Id { get; set; }
        public int Xuat_Kho_ID { get; set; }
        [Required]
        public int San_Pham_ID { get; set; }
        [Required]
        public int SL_Xuat {  get; set; }
        [Required]
        public double Don_Gia_Xuat { get; set; }
    }
}
