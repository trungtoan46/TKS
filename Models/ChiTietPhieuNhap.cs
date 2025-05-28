using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_Chi_Tiet_Phieu_Nhap")]
    public class ChiTietPhieuNhap
    {

        public string Ma_San_Pham {  get; set; }
        public string Ten_San_Pham { get; set; }
        public int So_Luong { get; set; }
        public decimal Don_Gia { get; set; }
        public decimal Thanh_Tien => Don_Gia * So_Luong;
    }
}
