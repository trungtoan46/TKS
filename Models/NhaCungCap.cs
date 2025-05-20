using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_DM_NCC")]
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ma_NCC { get; set; }
        [Required]
        public string Ten_NCC { get; set; }
        public string? GhiChu { get; set; }

    }
}
