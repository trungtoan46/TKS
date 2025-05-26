using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_DM_Kho_User")]
    public class KhoUser
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Chỉ được chứa chữ cái và số.")]
        public string Ma_Dang_Nhap { get; set; }
        
        [Required]
        public int Kho_Id { get; set; }
        [NotMapped]
        public Kho Kho { get; set; }
    }
}
