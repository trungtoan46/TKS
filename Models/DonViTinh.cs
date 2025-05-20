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
        [Required]
        
        public string TenDonViTinh { get; set; }
        public string? GhiChu { get; set; }
       
    }
}
