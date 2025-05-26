using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_DM_Nhap_Kho")]
    public class NhapKho
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string So_Phieu_Nhap_Kho { get; set; }
        [Required]
        public int Kho_ID { get; set; }
        [Required]
        public int NCC_ID { get; set; }
        [Required]
        public DateTime Ngay_Nhap_Kho { get; set; }

        public string Ghi_Chu {  get; set; }
    }
}
    