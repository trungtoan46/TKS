using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tonkho")]
    public class TonKhoViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ma_San_Pham {  get; set; }
        [Required]
        public string Ten_San_Pham { get; set; }
        public int SL_Dau_Ky {  get; set; }
        public int SL_Cuoi_Ky => SL_Dau_Ky + SL_Nhap - SL_Xuat;
        public int SL_Nhap {get; set; }
        public int SL_Xuat {  get; set; }

    }
}
