using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_DM_Nhap_Kho_Raw_Data")]
    public class NhapKhoRaw
    {
        [Key]
        public int Id { get; set; }
        public int Nhap_Kho_ID {  get; set; }
        public int San_Pham_ID { get; set; }
        public int SL_Nhap {  get; set; }
        public double Don_Gia_Nhap { get; set; }
    }
}
