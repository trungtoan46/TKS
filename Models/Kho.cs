using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_DM_Kho")]
    public class Kho 
    {
        [Key]
        public int Kho_Id { get; set; }
        
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Chỉ được chứa chữ cái và số.")]

        public string Ten_Kho { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Chỉ được chứa chữ cái và số.")]

        public string Ghi_Chu { get; set; }
    }
}
