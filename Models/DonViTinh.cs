using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;

namespace TKS.Models
{
    [Table("tbl_DM_Don_Vi_Tinh")] 
    public class DonViTinh
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên đơn vị tính không được để trống")]

        public string Ten_Don_Vi_Tinh { get; set; } = string.Empty;
        public string? GhiChu { get; set; }
       
    }
}
