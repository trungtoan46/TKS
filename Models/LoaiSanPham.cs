﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS.Models
{
    [Table("tbl_DM_Loai_San_Pham")]
    public class LoaiSanPham
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Ma_LSP { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Chỉ được chứa chữ cái và số.")]

        public required string  Ten_LSP { get; set; }

        public string? GhiChu { get; set; }
    }
}
